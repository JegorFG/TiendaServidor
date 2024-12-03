using System.Configuration;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos una instancia de la clase Conexion de la capa de datos
                Conexion conexion = new Conexion();

                // Obtenemos la conexi�n abierta
                var connection = conexion.GetConnection();

                // Si la conexi�n se ha abierto correctamente, mostramos un mensaje
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Conexi�n abierta con �xito", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cerrar la conexi�n (puedes hacerlo despu�s de que termines de usarla)
                conexion.CloseConnection(connection);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo mostramos en un MessageBox
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
