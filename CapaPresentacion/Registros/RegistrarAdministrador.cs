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
    public partial class RegistrarAdministrador : Form
    {
        // Instancia del servicio de Administrador para interactuar con la capa de lógica de negocio
        private AdministradorService _administradorService;

        public RegistrarAdministrador()
        {
            InitializeComponent();
        }

        // Evento click del botón para registrar al administrador
        private void btnRegistrarAdministrador_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de entrada: el campo Identificación no puede estar vacío y debe ser numérico
                if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) || 
                    !int.TryParse(txtIdentificacion.Text, out int identificacion))
                {
                    MessageBox.Show("Por favor, ingrese una identificación válida.");
                    txtIdentificacion.Clear();
                    txtIdentificacion.Focus();
                    return;
                }

                // Validación: la identificación no puede ser cero
                if (identificacion == 0)
                {
                    MessageBox.Show("La identificación no puede ser cero.");
                    txtIdentificacion.Clear();
                    txtIdentificacion.Focus();
                    return;
                }

                // Verificación de desbordamiento: el valor de identificación debe estar dentro de un rango específico
                if (identificacion < 0 || identificacion > 999999999)
                {
                    MessageBox.Show("La identificación debe ser un valor positivo con un máximo de 9 dígitos.");
                    txtIdentificacion.Clear();
                    txtIdentificacion.Focus();
                    return;
                }

                // Validación de nombre
                if (string.IsNullOrWhiteSpace(txtNombreAdministrador.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre del administrador.");
                    txtNombreAdministrador.Focus();
                    return;
                }

                // Validación de primer apellido
                if (string.IsNullOrWhiteSpace(txtPrimerApellidoAdministrador.Text))
                {
                    MessageBox.Show("Por favor, ingrese el primer apellido del administrador.");
                    txtPrimerApellidoAdministrador.Focus();
                    return;
                }

                // Validación de segundo apellido
                if (string.IsNullOrWhiteSpace(txtSegundoApellidoAdministrador.Text))
                {
                    MessageBox.Show("Por favor, ingrese el segundo apellido del administrador.");
                    txtSegundoApellidoAdministrador.Focus();
                    return;
                }

                // Crear y asignar valores al nuevo objeto Administrador
                Administrador administrador = new Administrador(
                    identificacion, // Identificación
                    txtNombreAdministrador.Text,
                    txtPrimerApellidoAdministrador.Text,
                    txtSegundoApellidoAdministrador.Text,
                    dtpFechaNacimientoAdministrador.Value,
                    dtpFechaIngresoAdministrador.Value
                );

                // Registrar el administrador utilizando el servicio
                _administradorService.Agregar(administrador);

                MessageBox.Show("Administrador registrado correctamente.");

                // Limpiar los campos del formulario después de registrar
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                // Capturar y mostrar cualquier excepción
                MessageBox.Show("Error al registrar el administrador: " + ex.Message);
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            txtIdentificacion.Clear();
            txtNombreAdministrador.Clear();
            txtPrimerApellidoAdministrador.Clear();
            txtSegundoApellidoAdministrador.Clear();
            dtpFechaNacimientoAdministrador.Value = DateTime.Now; // Restablece la fecha actual
            dtpFechaIngresoAdministrador.Value = DateTime.Now;    // Restablece la fecha actual
        }
    }
}
