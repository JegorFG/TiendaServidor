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
    public partial class RegistrarArticulo : Form
    {
        private CategoriaService _categoriaService; // Servicio para las categorías
        private ArticuloService _articuloService; // Servicio para artículos.

        public RegistrarArticulo()
        {
            InitializeComponent();
            CargarCategorias(); // Llama al método para cargar las categorías
            CargarOpcionesActivo(); // Cargar opciones para el estado activo
        }

        private void CargarCategorias()
        {
            // Obtener las categorías y agregarlas al ComboBox
            List<Categoria> categorias = _categoriaService.ObtenerTodas();
            cmbCategoriaArticulo.Items.Clear(); // Limpiar elementos anteriores

            // Configurar qué propiedad mostrar y cuál usar como valor
            cmbCategoriaArticulo.DisplayMember = "Nombre"; // Mostrar el nombre de la categoría
            cmbCategoriaArticulo.ValueMember = "IdCategoria"; // Usar el ID como valor

            // Establecer el estilo de dropdown a solo lista
            cmbCategoriaArticulo.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir


            // Agregar cada categoría al ComboBox
            foreach (var categoria in categorias)
            {
                // Asegurarse de que la categoría no sea nula antes de agregar
                if (categoria != null)
                {
                    cmbCategoriaArticulo.Items.Add(categoria); // Agregar el objeto completo de la categoría
                }
            }

            // Seleccionar la primera categoría como predeterminada
            if (cmbCategoriaArticulo.Items.Count > 0)
            {
                cmbCategoriaArticulo.SelectedIndex = 0; // Selecciona la primera categoría
            }
        }

        private void CargarOpcionesActivo()
        {
            // Limpiar elementos anteriores, si los hay
            cmbActivoArticulo.Items.Clear();

            // Agregar opciones "Sí" y "No" al ComboBox
            cmbActivoArticulo.Items.Add("Sí");
            cmbActivoArticulo.Items.Add("No");

            // Seleccionar "Sí" como opción predeterminada
            cmbActivoArticulo.SelectedIndex = 0;

            // Establecer el estilo de dropdown a solo lista
            cmbActivoArticulo.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir
        }

        private void btnRegistrarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el ID de la Artículo sea un número entero y esté dentro del rango permitido
                if (string.IsNullOrWhiteSpace(txtIdArticulo.Text) || 
                    !int.TryParse(txtIdArticulo.Text, out int idArticulo) ||
                    idArticulo < 0 || idArticulo > 9999)
                {
                    MessageBox.Show("Por favor, ingrese un ID válido para el artículo entre 1 y 9999.");
                    txtIdArticulo.Clear();
                    txtIdArticulo.Focus(); // Colocar el cursor en el cuadro de texto de ID
                    return;
                }

                // Validar que la descripción no esté vacía
                if (string.IsNullOrWhiteSpace(txtDescripcionArticulo.Text))
                {
                    MessageBox.Show("Por favor, ingrese una descripción para el artículo.");
                    txtDescripcionArticulo.Focus(); // Colocar el cursor en el cuadro de texto de descripción
                    return;
                }

                // Validar que se haya seleccionado una categoría
                if (cmbCategoriaArticulo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione una categoría para el artículo (Si o No)");
                    cmbCategoriaArticulo.Focus(); // Colocar el cursor en el ComboBox de categoría
                    return;
                }

                // Validar que la marca no esté vacía
                if (string.IsNullOrWhiteSpace(txtMarcaArticulo.Text))
                {
                    MessageBox.Show("Por favor, ingrese la marca del artículo.");
                    txtMarcaArticulo.Focus(); // Colocar el cursor en el cuadro de texto de marca
                    return;
                }

                // Crear un nuevo artículo utilizando el constructor parametrizado
                Articulo articulo = new Articulo(
                    idArticulo,  // Id del artículo tomado de la validación en el if
                    txtDescripcionArticulo.Text,    // Descripción del artículo
                    (Categoria)cmbCategoriaArticulo.SelectedItem,  // Seleccionar la categoría del ComboBox
                    txtMarcaArticulo.Text,           // Marca del artículo
                    cmbActivoArticulo.SelectedItem.ToString() == "Sí" // Convertir a bool (Activo o Inactivo)
                );

                // Aquí llamas al servicio para registrar el artículo
                _articuloService.Agregar(articulo);

                MessageBox.Show("Artículo registrado correctamente.");

                // Limpiar campos
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el artículo: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            // Método para limpiar los campos del formulario
            txtIdArticulo.Clear();
            txtDescripcionArticulo.Clear();
            txtMarcaArticulo.Clear();
            cmbCategoriaArticulo.SelectedIndex = 0; // Restablecer a la primera categoría
            cmbActivoArticulo.SelectedIndex = 0; // Restablecer a "Sí"
        }
    }
}
