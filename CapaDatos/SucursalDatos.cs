using CapaDatos.Interfaces;
using CapaEntidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Implementa los métodos de la interfaz ISucursalRepository para interactuar con la tabla Sucursal.
    public class SucursalDatos : ISucursalRepository
    {
        private readonly IConexion conexion;

        // Constructor para inicializar la conexión.
        public SucursalDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Sucursal> ObtenerSucursales()
        {
            var sucursales = new List<Sucursal>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT S.id, S.nombre, S.direccion, S.telefono, S.id_administrador, S.activo, A.nombre AS administrador " +
                               "FROM Sucursal S INNER JOIN Administrador A ON S.id_administrador = A.identificacion";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var administrador = new Administrador
                            {
                                Identificacion = Convert.ToInt32(reader["id_administrador"]),
                                Nombre = reader["administrador"].ToString()
                            };

                            var sucursal = new Sucursal
                            {
                                IdSucursal = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                AdminSucursal = administrador,
                                Activo = Convert.ToBoolean(reader["activo"])
                            };

                            sucursales.Add(sucursal);
                        }
                    }
                }
            }
            return sucursales;
        }

        public Sucursal ObtenerSucursalPorId(int idSucursal)
        {
            Sucursal sucursal = null;

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT S.id, S.nombre, S.direccion, S.telefono, S.id_administrador, S.activo, A.nombre AS administrador " +
                               "FROM Sucursal S INNER JOIN Administrador A ON S.id_administrador = A.identificacion " +
                               "WHERE S.id = @idSucursal";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var administrador = new Administrador
                            {
                                Identificacion = Convert.ToInt32(reader["id_administrador"]),
                                Nombre = reader["administrador"].ToString()
                            };

                            sucursal = new Sucursal
                            {
                                IdSucursal = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Direccion = reader["direccion"].ToString(),
                                Telefono = reader["telefono"].ToString(),
                                AdminSucursal = administrador,
                                Activo = Convert.ToBoolean(reader["activo"])
                            };
                        }
                    }
                }
            }
            return sucursal;
        }

        public void AgregarSucursal(Sucursal sucursal)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Sucursal (nombre, direccion, telefono, id_administrador, activo) " +
                               "VALUES (@nombre, @direccion, @telefono, @id_administrador, @activo)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                    cmd.Parameters.AddWithValue("@id_administrador", sucursal.AdminSucursal.Identificacion);
                    cmd.Parameters.AddWithValue("@activo", sucursal.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarSucursal(Sucursal sucursal)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "UPDATE Sucursal SET nombre = @nombre, direccion = @direccion, telefono = @telefono, " +
                               "id_administrador = @id_administrador, activo = @activo WHERE id = @idSucursal";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSucursal", sucursal.IdSucursal);
                    cmd.Parameters.AddWithValue("@nombre", sucursal.Nombre);
                    cmd.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                    cmd.Parameters.AddWithValue("@telefono", sucursal.Telefono);
                    cmd.Parameters.AddWithValue("@id_administrador", sucursal.AdminSucursal.Identificacion);
                    cmd.Parameters.AddWithValue("@activo", sucursal.Activo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Existe(int idSucursal)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Sucursal WHERE id = @idSucursal";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idSucursal", idSucursal);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}

