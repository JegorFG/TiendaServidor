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
 * ChatGPT de OpenAI para sugerencias en la validación y mejora del diseño, 
 * GitHub para el control de versiones
*/

using CapaEntidades;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class RegistrarSucursal : Form
    {
        private SucursalService _sucursalService;
        private AdministradorService _administradorService; // Conexión con la capa de lógica de negocio para administradores

        public RegistrarSucursal()
        {
            InitializeComponent();
            CargarAdministradores(); // Cargar administradores en el ComboBox
            CargarOpcionesEstado(); // Cargar opciones de estado (Sí, No) en el ComboBox
        }
        // Cargar los administradores en el ComboBox cmbAdminSucursal
        private void CargarAdministradores()
        {
            var administradores = _administradorService.ObtenerTodos(); // Obtener la lista de administradores
            cmbAdminSucursal.Items.Clear(); // Limpiar los elementos anteriores del ComboBox

            // Verificar que la lista de administradores no sea nula
            if (administradores != null && administradores.Count > 0) // Verifica que administradores no sea nulo
            {
                // Configurar qué propiedad del objeto Administrador se mostrará en el ComboBox
                cmbAdminSucursal.DisplayMember = "Identificacion"; // Mostrar la identificación del administrador en el ComboBox
                cmbAdminSucursal.ValueMember = "Nombre"; // Mantener el valor oculto como el nombre del administrador

                // Agregar cada administrador al ComboBox
                foreach (var admin in administradores)
                {
                    if (admin != null) // Verifica que el administrador no sea nulo
                    {
                        cmbAdminSucursal.Items.Add(admin); // Agregar el objeto completo al ComboBox
                    }
                }

                // Seleccionar un valor predeterminado
                if (cmbAdminSucursal.Items.Count > 0)
                {
                    cmbAdminSucursal.SelectedIndex = 0; // Seleccionar el primer administrador por defecto
                }

                // Establecer el estilo de dropdown a solo lista
                cmbAdminSucursal.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir
            }
            else
            {
                // Si no hay administradores cierra el Form
                MessageBox.Show("No hay administradores disponibles."); // Mensaje si no hay administradores
                this.Close();
                return;
            }
        }

        // Cargar las opciones "Sí" y "No" en el ComboBox cmbActivoSucursal
        private void CargarOpcionesEstado()
        {
            cmbActivoSucursal.Items.Clear();
            cmbActivoSucursal.Items.Add("Sí");
            cmbActivoSucursal.Items.Add("No");

            // Seleccionar "Sí" como opción predeterminada
            cmbActivoSucursal.SelectedIndex = 0;

            // Establecer el estilo de dropdown a solo lista
            cmbActivoSucursal.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir
        }

        // Evento Click para registrar la sucursal
        private void btnRegistrarSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos de texto no estén vacíos o tengan solo espacios en blanco
                if (string.IsNullOrWhiteSpace(txtIdSucursal.Text) || 
                    !int.TryParse(txtIdSucursal.Text, out int identificacion) ||
                 identificacion < 0 || identificacion > 9999)
                {
                    MessageBox.Show("Por favor, ingrese un ID para la sucursal entre 1 y 9999.");
                    txtIdSucursal.Clear();
                    txtIdSucursal.Focus(); // Colocar el cursor en el campo
                    return; // Detener el proceso si no se cumple la validación
                }

                if (string.IsNullOrWhiteSpace(txtNombreSucursal.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la sucursal.");
                    txtNombreSucursal.Focus(); // Colocar el cursor en el campo
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDireccionSucursal.Text))
                {
                    MessageBox.Show("Por favor, ingrese una dirección para la sucursal.");
                    txtDireccionSucursal.Focus(); // Colocar el cursor en el campo
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonoSucursal.Text) || 
                    !int.TryParse(txtTelefonoSucursal.Text, out int telefono) ||
                    telefono < 0 || telefono > 9999999999)
                {
                    MessageBox.Show("Por favor, ingrese un teléfono válido para la sucursal entre 1 y 9999999999.");
                    txtTelefonoSucursal.Clear();
                    txtTelefonoSucursal.Focus(); // Colocar el cursor en el campo
                    return;
                }

                // Validar que se haya seleccionado una opción en el ComboBox de Activo
                if (cmbActivoSucursal.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione el estado del cliente (Si o No).");
                    // Seleccionar "Sí" como opción predeterminada
                    cmbActivoSucursal.SelectedIndex = 0;
                    cmbActivoSucursal.Focus(); // Poner el cursor en el ComboBox de activo
                    return;
                }


                // Crear la nueva sucursal utilizando el constructor
                Sucursal sucursal = new Sucursal(
                    identificacion, // ID de la sucursal
                    txtNombreSucursal.Text, // Nombre de la sucursal
                    txtDireccionSucursal.Text, // Dirección de la sucursal
                    txtTelefonoSucursal.Text, // Teléfono de la sucursal
                    cmbActivoSucursal.SelectedItem.ToString() == "Sí", // Convertir a bool según la selección
                    cmbAdminSucursal.SelectedItem != null ? (Administrador)cmbAdminSucursal.SelectedItem : null // Administrador seleccionado, si hay uno
                );

                // Registrar la sucursal aquí llamando al servicio de sucursal
                _sucursalService.Agregar(sucursal);

                MessageBox.Show("Sucursal registrada correctamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la sucursal: " + ex.Message);
            }
        }

        // Método para limpiar los campos después de registrar
        private void LimpiarCampos()
        {
            txtIdSucursal.Clear();
            txtNombreSucursal.Clear();
            txtDireccionSucursal.Clear();
            txtTelefonoSucursal.Clear();
            cmbAdminSucursal.SelectedIndex = 0; // Restablecer el ComboBox de administradores
            cmbActivoSucursal.SelectedIndex = 0; // Restablecer el ComboBox de estado a "Sí"
        }
    }
}
