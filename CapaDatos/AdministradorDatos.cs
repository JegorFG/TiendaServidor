using CapaDatos.Interfaces;
using CapaEntidades;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Clase para gestionar las operaciones relacionadas con administradores.
    public class AdministradorDatos : IAdministradorRepository
    {
        private readonly IConexion _conexion;

        // Constructor que recibe la dependencia de la conexión.
        public AdministradorDatos(IConexion conexion)
        {
            this._conexion = conexion;
        }

        // Obtiene todos los administradores registrados en la base de datos.
        public List<Administrador> ObtenerAdministradores()
        {
            var administradores = new List<Administrador>();

            using (var conn = _conexion.GetConnection())
            {
                string query = "SELECT * FROM Administrador";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            administradores.Add(new Administrador
                            {
                                Identificacion = Convert.ToInt32(reader["identificacion"]),
                                Nombre = reader["nombre"].ToString(),
                                PrimerApellido = reader["apellido1"].ToString(),
                                SegundoApellido = reader["apellido2"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["fec_nacimiento"]),
                                FechaIngreso = Convert.ToDateTime(reader["fec_ingreso"])
                            });
                        }
                    }
                }
            }
            return administradores; // Retorna la lista de administradores.
        }

        // Busca un administrador por su ID.
        public Administrador ObtenerAdministradorPorId(int idAdministrador)
        {
            Administrador administrador = null;

            using (var conn = _conexion.GetConnection())
            {
                string query = "SELECT * FROM Administrador WHERE identificacion = @identificacion";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idntificacion", idAdministrador);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            administrador = new Administrador
                            {
                                Identificacion = Convert.ToInt32(reader["identificacion"]),
                                Nombre = reader["nombre"].ToString(),
                                PrimerApellido = reader["apellido1"].ToString(),
                                SegundoApellido = reader["apellido2"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["fec_nacimiento"]),
                                FechaIngreso = Convert.ToDateTime(reader["fec_ingreso"]),
                            };
                        }
                    }
                }
            }
            return administrador; // Retorna el administrador encontrado o null.
        }

        // Agrega un nuevo administrador.
        public void AgregarAdministrador(Administrador administrador)
        {
            using (var conn = _conexion.GetConnection())
            {
                string query = "INSERT INTO Administrador (identificacion, nombre, apellido1, apellido2, fec_nacimiento, fec_ingreso) " +
                           "VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @FechaIngreso)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    // Asignar los parámetros del comando SQL
                    cmd.Parameters.AddWithValue("@Identificacion", administrador.Identificacion);
                    cmd.Parameters.AddWithValue("@Nombre", administrador.Nombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", administrador.PrimerApellido);
                    cmd.Parameters.AddWithValue("@SegundoApellido", administrador.SegundoApellido);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", administrador.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@FechaIngreso", administrador.FechaIngreso);

                    cmd.ExecuteNonQuery(); // Ejecuta la inserción.
                }
            }
        }

        // Elimina un administrador por su ID.
        public void EliminarAdministrador(int idAdministrador)
        {
            using (var conn = _conexion.GetConnection())
            {
                string query = "DELETE FROM Administrador WHERE identificacion = @identificacion";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@identificacion", idAdministrador);

                    cmd.ExecuteNonQuery(); // Ejecuta la eliminación.
                }
            }
        }

        // Verifica si un administrador existe en la base de datos.
        public bool Existe(int idAdministrador)
        {
            using (var conn = _conexion.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Administrador WHERE id = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idAdministrador);

                    int count = Convert.ToInt32(cmd.ExecuteScalar()); // Obtiene el conteo.
                    return count > 0; // Retorna true si el administrador existe.
                }
            }
        }
    }
}

