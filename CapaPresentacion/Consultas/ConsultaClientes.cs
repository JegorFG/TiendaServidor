
/*
 * UNED III Cuatrimestre
 * Proyecto 1: Sistema para Tienda Deportiva
 * Estudiante: Jesús Garita Obando
 * Cédula: 303870610
 * Fecha: 30/09/2024
 * 
 * Fuentes Externas y Asistencia
 * El código del proyecto fue desarrollado principalmente por el autor, con ayuda de:
 * La tutoría de la UNED https://www.youtube.com/watch?v=2ZOUapJjgpg y 
 * ChatGPT de OpenAI para sugerencias en la validación y mejora del diseño.
 * GitHub para el control de versiones
*/

using CapaEntidades;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class ConsultaClientes : Form
    {
        private readonly ClienteService _clienteService;

        public ConsultaClientes(ClienteService clienteService)
        {
            InitializeComponent();

            _clienteService = clienteService;

            CargarClientes(); // Cargar todos los clientes al iniciar el formulario
        }

        private void CargarClientes()
        {
            try
            {
                // Llama a ObtenerClientes y asigna el resultado al DataSource del DataGridView
                List<Cliente> clientes = _clienteService.ObtenerTodos();
                dgvConsultaClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
        }
    }
}
