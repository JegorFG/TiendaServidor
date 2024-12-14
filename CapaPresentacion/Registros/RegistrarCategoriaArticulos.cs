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

using CapaLogica;

namespace CapaPresentacion
{
    public partial class RegistrarCategoriaArticulos : Form
    {
        // Instancia del servicio que maneja las operaciones de la categoría
        private CategoriaService _categoriaService;

        public RegistrarCategoriaArticulos()
        {
            InitializeComponent();
        }

        private void btnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID de la categoría sea un número entero y esté dentro del rango permitido
                if (string.IsNullOrWhiteSpace(txtIdCategoria.Text) ||
                    !int.TryParse(txtIdCategoria.Text, out int idCategoria) ||
                    idCategoria < 0 || idCategoria > 9999)
                {
                    MessageBox.Show("Por favor, ingrese un ID válido para la categoría entre 1 y 9999.");
                    txtIdCategoria.Clear();
                    txtIdCategoria.Focus(); // Colocar el cursor en el cuadro de texto de ID
                    return; // Salir del método si no se cumple la validación
                }

                // Validar que el nombre de la categoría no esté vacío
                if (string.IsNullOrWhiteSpace(txtNombreCategoria.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la categoría.");
                    txtNombreCategoria.Focus(); // Colocar el cursor en el cuadro de texto de nombre
                    return;
                }

                // Validar que la descripción no esté vacía
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para la categoría.");
                    txtDescripcion.Focus(); // Colocar el cursor en el cuadro de texto de descripción
                    return;
                }

                // Crear un nuevo objeto de categoría utilizando el constructor
                Categoria categoria = new Categoria(
                    idCategoria,              // ID de la categoría
                    txtNombreCategoria.Text,  // Nombre de la categoría
                    txtDescripcion.Text       // Descripción de la categoría
                );

                // Llamar al servicio para registrar la categoría
                _categoriaService.Agregar(categoria);

                MessageBox.Show("Categoría registrada correctamente.");

                // Limpiar los campos después de registrar
                LimpiarCampos();
            }
            catch (FormatException)
            {
                MessageBox.Show("El ID debe ser un número entero.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la categoría: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos del formulario
            txtIdCategoria.Clear();
            txtNombreCategoria.Clear();
            txtDescripcion.Clear();
        }
    }
}
