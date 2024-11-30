using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Implementa los métodos de la interfaz IArticuloSucursalRepository para interactuar con la tabla ArticuloxSucursal.
    public class ArticuloSucursalDatos : IArticuloSucursalRepository
    {
        private readonly IConexion conexion;

        // Constructor para inicializar la conexión.
        public ArticuloSucursalDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<ArticuloSucursal> ObtenerArticulosSucursal()
        {
            var articulosSucursal = new List<ArticuloSucursal>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM ArticuloxSucursal";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obtener los datos de Articulo y Sucursal de la base de datos.
                            var articulo = new Articulo
                            {
                                Id = Convert.ToInt32(reader["id_articulo"]),
                                Descripcion = reader["descripcion"].ToString(),
                                CategoriaArticulo = new Categoria { Id = Convert.ToInt32(reader["id_categoria"]) },
                                Marca = reader["marca"].ToString(),
                                Activo = Convert.ToBoolean(reader["activo"])
                            };

                            var sucursal = new Sucursal
                            {
                                IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                AdminSucursal = new Administrador { Identificacion = Convert.ToInt32(reader["id_administrador"]) },
                                Activo = Convert.ToBoolean(reader["activo"])
                            };

                            articulosSucursal.Add(new ArticuloSucursal(sucursal, articulo, Convert.ToInt32(reader["cantidad"])));
                        }
                    }
                }
            }
            return articulosSucursal;
        }

        public List<ArticuloSucursal> ObtenerArticulosPorSucursal(int idSucursal)
        {
            var articulosSucursal = new List<ArticuloSucursal>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM ArticuloxSucursal WHERE id_sucursal = @idSucursal";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var articulo = new Articulo
                            {
                                Id = Convert.ToInt32(reader["id_articulo"]),
                                Descripcion = reader["descripcion"].ToString(),
                                CategoriaArticulo = new Categoria { Id = Convert.ToInt32(reader["id_categoria"]) },
                                Marca = reader["marca"].ToString(),
                                Activo = Convert.ToBoolean(reader["activo"])
                            };

                            var sucursal = new Sucursal
                            {
                                IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                AdminSucursal = new Administrador { Identificacion = Convert.ToInt32(reader["id_administrador"]) },
                                Activo = Convert.ToBoolean(reader["activo"])
                            };

                            articulosSucursal.Add(new ArticuloSucursal(sucursal, articulo, Convert.ToInt32(reader["cantidad"])));
                        }
                    }
                }
            }
            return articulosSucursal;
        }

        public void AgregarArticuloSucursal(ArticuloSucursal articuloSucursal)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "INSERT INTO ArticuloxSucursal (id_sucursal, id_articulo, cantidad) " +
                               "VALUES (@idSucursal, @idArticulo, @cantidad)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSucursal", articuloSucursal.Sucursal.IdSucursal);
                    cmd.Parameters.AddWithValue("@idArticulo", articuloSucursal.Articulo.Id);
                    cmd.Parameters.AddWithValue("@cantidad", articuloSucursal.Cantidad);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Método para actualizar la cantidad de un artículo en una sucursal, manejando concurrencia.
        public void ActualizarCantidad(ArticuloSucursal articuloSucursal, int cantidadCambio)
        {
            using (var conn = conexion.GetConnection())
            {
                // Empezamos una transacción para manejar la concurrencia.
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Verificar el valor actual de la cantidad para prevenir conflictos de concurrencia.
                        string selectQuery = "SELECT cantidad FROM ArticuloxSucursal WHERE id_sucursal = @idSucursal AND id_articulo = @idArticulo";
                        using (var cmd = new SqlCommand(selectQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@idSucursal", articuloSucursal.Sucursal.IdSucursal);
                            cmd.Parameters.AddWithValue("@idArticulo", articuloSucursal.Articulo.Id);

                            int cantidadActual = Convert.ToInt32(cmd.ExecuteScalar());

                            // Verificar que la cantidad actual sea suficiente para restar en caso de reserva.
                            if (cantidadActual + cantidadCambio < 0)
                            {
                                throw new InvalidOperationException("No hay suficiente cantidad disponible.");
                            }

                            // Si todo está bien, actualizamos la cantidad.
                            string updateQuery = "UPDATE ArticuloxSucursal SET cantidad = cantidad + @cantidadCambio WHERE id_sucursal = @idSucursal AND id_articulo = @idArticulo";
                            using (var updateCmd = new SqlCommand(updateQuery, conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@idSucursal", articuloSucursal.Sucursal.IdSucursal);
                                updateCmd.Parameters.AddWithValue("@idArticulo", articuloSucursal.Articulo.Id);
                                updateCmd.Parameters.AddWithValue("@cantidadCambio", cantidadCambio);

                                int filasAfectadas = updateCmd.ExecuteNonQuery();

                                // Si no se actualizó ninguna fila, es posible que otro usuario haya modificado la cantidad.
                                if (filasAfectadas == 0)
                                {
                                    throw new InvalidOperationException("Hubo un conflicto de concurrencia al intentar actualizar la cantidad.");
                                }
                            }
                        }

                        // Si todo fue exitoso, confirmamos la transacción.
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        // Si ocurrió algún error, revertimos la transacción.
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
