using System.Configuration;
using System.Data.SqlClient;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class Conexion : IConexion
    {
        private readonly string connectionString;

        // Constructor para inicializar la cadena de conexión desde App.config
        public Conexion(string connectionName = "MiConexion")
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings[connectionName]?.ConnectionString
                                   ?? throw new Exception($"No se encontró la cadena de conexión: {connectionName}");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la cadena de conexión: " + ex.Message);
            }
        }

        // Método para obtener una instancia de SqlConnection
        public SqlConnection GetConnection()
        {
            // Se crea una nueva conexión usando la cadena de conexión proporcionada.
            SqlConnection connection = new SqlConnection(connectionString);

            // Se abre la conexión.
            connection.Open();

            // Si la conexión fue exitosa, se retorna la conexión abierta.
            return connection;
        }

        // Método para cerrar una conexión
        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error al cerrar la conexión a la base de datos: " + ex.Message);
                }
            }
        }
    }
}
