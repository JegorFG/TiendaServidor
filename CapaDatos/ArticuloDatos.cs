using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Implementa los métodos de la interfaz IArticuloRepository para interactuar con la tabla Articulo.
    public class ArticuloDatos : IArticuloRepository
    {
        private readonly IConexion conexion;

        // Constructor para inicializar la conexión.
        public ArticuloDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        // Obtiene todos los artículos de la base de datos.
        public List<Articulo> ObtenerArticulos()
        {
            var articulos = new List<Articulo>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM Articulo";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crea un objeto Articulo y lo agrega a la lista.
                            articulos.Add(new Articulo
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Descripcion = reader["descripcion"].ToString(),
                                CategoriaArticulo = new Categoria { Id = Convert.ToInt32(reader["id_categoria"]) },
                                Marca = reader["marca"].ToString(),
                                Activo = Convert.ToBoolean(reader["activo"])
                            });
                        }
                    }
                }
            }
            return articulos;
        }

        // Obtiene un artículo específico por su ID.
        public Articulo ObtenerArticuloPorId(int id)
        {
            Articulo articulo = null;

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM Articulo WHERE id = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crea un objeto Articulo con los datos obtenidos.
                            articulo = new Articulo
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Descripcion = reader["descripcion"].ToString(),
                                CategoriaArticulo = new Categoria { Id = Convert.ToInt32(reader["id_categoria"]) },
                                Marca = reader["marca"].ToString(),
                                Activo = Convert.ToBoolean(reader["activo"])
                            };
                        }
                    }
                }
            }
            return articulo;
        }

        // Agrega un nuevo artículo a la base de datos.
        public void AgregarArticulo(Articulo articulo)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Articulo (id, descripcion, id_categoria, marca, activo) " +
                               "VALUES (@id, @descripcion, @id_categoria, @marca, @activo)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    // Asigna los valores de los parámetros.
                    cmd.Parameters.AddWithValue("@id", articulo.Id);
                    cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                    cmd.Parameters.AddWithValue("@id_categoria", articulo.CategoriaArticulo.Id);
                    cmd.Parameters.AddWithValue("@marca", articulo.Marca);
                    cmd.Parameters.AddWithValue("@activo", articulo.Activo);

                    // Ejecuta el comando para insertar el artículo.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Verifica si un artículo existe en la base de datos.
        public bool Existe(int id)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Articulo WHERE id = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    // Ejecuta el comando y verifica si el resultado es mayor a 0.
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}

