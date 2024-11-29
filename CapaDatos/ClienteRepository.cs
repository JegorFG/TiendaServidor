using System.Data.SqlClient;
using CapaDatos.Interfaces;
using CapaEntidades;

namespace CapaDatos
{
    // Implementación de la clase ClienteDatos, que interactúa con la base de datos para realizar operaciones CRUD sobre la tabla Cliente
    public class ClienteDatos : IClienteRepository
    {
        // Dependencia de una interfaz de conexión para desacoplar la lógica de la conexión
        private readonly IConexion conexion;

        // Constructor que inicializa la clase con una implementación de IConexion
        public ClienteDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        // Obtiene todos los clientes de la tabla Cliente
        public List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>(); // Lista para almacenar los resultados
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                using (var cmd = new SqlCommand("SELECT * FROM Cliente", conn)) // Se prepara el comando SQL
                {
                    using (var reader = cmd.ExecuteReader()) // Ejecuta la consulta y obtiene un DataReader
                    {
                        // Itera sobre los resultados de la consulta
                        while (reader.Read())
                        {
                            // Mapea cada fila a un objeto Cliente y lo agrega a la lista
                            clientes.Add(new Cliente
                            {
                                Identificacion = Convert.ToInt32(reader["identificacion"]),
                                Nombre = reader["nombre"].ToString(),
                                PrimerApellido = reader["apellido1"].ToString(),
                                SegundoApellido = reader["apellido2"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["fec_nacimiento"]),
                                Activo = Convert.ToBoolean(reader["activo"])
                            });
                        }
                    }
                }
            }
            return clientes; // Retorna la lista de clientes
        }

        // Obtiene un cliente específico por su identificación
        public Cliente ObtenerClientePorId(int identificacion)
        {
            Cliente cliente = null; // Variable para almacenar el cliente encontrado
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                string query = "SELECT * FROM Cliente WHERE identificacion = @identificacion"; // Consulta SQL parametrizada

                using (var cmd = new SqlCommand(query, conn)) // Se prepara el comando SQL
                {
                    cmd.Parameters.AddWithValue("@identificacion", identificacion); // Se asigna el valor del parámetro
                    using (var reader = cmd.ExecuteReader()) // Ejecuta la consulta y obtiene un DataReader
                    {
                        if (reader.Read()) // Si hay un resultado
                        {
                            // Mapea la fila a un objeto Cliente
                            cliente = new Cliente
                            {
                                Identificacion = Convert.ToInt32(reader["identificacion"]),
                                Nombre = reader["nombre"].ToString(),
                                PrimerApellido = reader["apellido1"].ToString(),
                                SegundoApellido = reader["apellido2"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(reader["fec_nacimiento"]),
                                Activo = Convert.ToBoolean(reader["activo"])
                            };
                        }
                    }
                }
            }
            return cliente; // Retorna el cliente o null si no existe
        }

        // Agrega un nuevo cliente a la base de datos
        public void AgregarCliente(Cliente cliente)
        {
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                string query = "INSERT INTO Cliente (identificacion, nombre, apellido1, apellido2, fec_nacimiento, activo) " +
                               "VALUES (@identificacion, @nombre, @apellido1, @apellido2, @fec_nacimiento, @activo)";

                using (var cmd = new SqlCommand(query, conn)) // Se prepara el comando SQL
                {
                    // Asignación de parámetros para evitar inyección SQL
                    cmd.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido1", cliente.PrimerApellido);
                    cmd.Parameters.AddWithValue("@apellido2", cliente.SegundoApellido);
                    cmd.Parameters.AddWithValue("@fec_nacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@activo", cliente.Activo);

                    cmd.ExecuteNonQuery(); // Ejecuta el comando de inserción
                }
            }
        }

        // Actualiza los datos de un cliente existente
        public void ActualizarCliente(Cliente cliente)
        {
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                using (var cmd = new SqlCommand(
                    "UPDATE Cliente SET nombre = @Nombre, apellido1 = @PrimerApellido WHERE identificacion = @identificacion",
                    conn))
                {
                    // Asignación de parámetros para la consulta de actualización
                    cmd.Parameters.AddWithValue("@identificacion", cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);

                    cmd.ExecuteNonQuery(); // Ejecuta el comando de actualización
                }
            }
        }

        // Elimina un cliente de la base de datos por su identificación
        public void EliminarCliente(int identificacion)
        {
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                using (var cmd = new SqlCommand("DELETE FROM Cliente WHERE identificacion = @identificacion", conn))
                {
                    cmd.Parameters.AddWithValue("@identificacion", identificacion); // Asigna el parámetro de identificación
                    cmd.ExecuteNonQuery(); // Ejecuta el comando de eliminación
                }
            }
        }

        // Verifica si un cliente existe en la base de datos por su identificación
        public bool Existe(int identificacion)
        {
            using (var conn = conexion.GetConnection()) // Se obtiene una conexión abierta
            {
                string query = "SELECT COUNT(*) FROM Cliente WHERE identificacion = @identificacion"; // Consulta para contar registros

                using (SqlCommand command = new SqlCommand(query, conn)) // Se prepara el comando SQL
                {
                    command.Parameters.AddWithValue("@identificacion", identificacion); // Asigna el parámetro de identificación
                    int count = (int)command.ExecuteScalar(); // Ejecuta la consulta y obtiene el resultado
                    return count > 0; // Retorna true si existe al menos un registro
                }
            }
        }
    }
}
