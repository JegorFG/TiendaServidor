using System.Data.SqlClient;

namespace CapaDatos.Interfaces
{
    public interface IConexion
    {
        SqlConnection GetConnection();
        void CloseConnection(SqlConnection connection);
    }
}

