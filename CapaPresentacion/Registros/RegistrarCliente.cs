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
    public partial class RegistrarCliente : Form
    {
        private ClienteService _clienteService; // Conexión con el servicio

        public RegistrarCliente()
        {
            InitializeComponent();
            CargarOpcionesActivo(); // Llamar al método para cargar opciones
        }

        private void CargarOpcionesActivo()
        {
            // Limpiar elementos anteriores, si los hay
            cmbActivoCliente.Items.Clear();

            // Agregar opciones "Sí" y "No" al ComboBox
            cmbActivoCliente.Items.Add("Sí");
            cmbActivoCliente.Items.Add("No");

            // Seleccionar una opción predeterminada
            cmbActivoCliente.SelectedIndex = 0; // Seleccionar "Sí" como predeterminado

            // Establecer el estilo de dropdown a solo lista
            cmbActivoCliente.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que la identificación no esté vacía y contenga solo números
                if (string.IsNullOrWhiteSpace(txtIdentificacionCliente.Text) || 
                    !int.TryParse(txtIdentificacionCliente.Text, out int identificacion) || 
                    identificacion < 0 || identificacion > 999999999)
                {
                    MessageBox.Show("Por favor, ingrese una identificación válida (solo números).");
                    txtIdentificacionCliente.Clear();
                    txtIdentificacionCliente.Focus(); // Poner el cursor en el campo de identificación
                    return;
                }

                // Validar que el nombre no esté vacío
                if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del cliente.");
                    txtNombreCliente.Focus(); // Poner el cursor en el campo de nombre
                    return;
                }

                // Validar que el primer apellido no esté vacío
                if (string.IsNullOrWhiteSpace(txtPrimerApellidoCliente.Text))
                {
                    MessageBox.Show("Por favor, ingrese el primer apellido del cliente.");
                    txtPrimerApellidoCliente.Focus(); // Poner el cursor en el campo de primer apellido
                    return;
                }

                // Validar que el segundo apellido no esté vacío
                if (string.IsNullOrWhiteSpace(txtSegundoApellidoCliente.Text))
                {
                    MessageBox.Show("Por favor, ingrese el segundo apellido del cliente.");
                    txtSegundoApellidoCliente.Focus(); // Poner el cursor en el campo de segundo apellido
                    return;
                }

                // Validar que se haya seleccionado una opción en el ComboBox de Activo
                if (cmbActivoCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione el estado del cliente (Si o No).");
                    cmbActivoCliente.Focus(); // Poner el cursor en el ComboBox de activo
                    return;
                }

                // Crear un nuevo cliente utilizando el constructor
                Cliente cliente = new Cliente(
                    identificacion,                           // Identificación
                    txtNombreCliente.Text,                    // Nombre
                    txtPrimerApellidoCliente.Text,            // Primer Apellido
                    txtSegundoApellidoCliente.Text,           // Segundo Apellido
                    dtpFechaNacimientoCliente.Value,          // Fecha de Nacimiento
                    cmbActivoCliente.SelectedItem.ToString() == "Sí" // Convertir a bool (Activo o Inactivo)
                );

                // Llamar al servicio para registrar el cliente
                _clienteService.Agregar(cliente);

                MessageBox.Show("Cliente registrado correctamente.");
                LimpiarCampos(); // Método para limpiar los campos después de registrar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el cliente: " + ex.Message);
            }
            
        }

        private void LimpiarCampos()
        {
            // Método para limpiar los campos del formulario
            txtIdentificacionCliente.Clear();
            txtNombreCliente.Clear();
            txtPrimerApellidoCliente.Clear();
            txtSegundoApellidoCliente.Clear();
            dtpFechaNacimientoCliente.Value = DateTime.Now; // Establecer la fecha actual
            cmbActivoCliente.SelectedIndex = 0; // Restablecer a "Sí"
        }
    }
}
