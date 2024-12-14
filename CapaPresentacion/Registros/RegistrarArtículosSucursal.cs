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

using System.Data;
using CapaEntidades;
using CapaLogica;

namespace CapaPresentacion
{
    public partial class RegistrarArtículosSucursal : Form
    {
        private SucursalService _sucursalService;
        private ArticuloService _articuloService;
        private ArticuloSucursalService _articuloSucursalService;

        public RegistrarArtículosSucursal()
        {
            InitializeComponent();
            CargarSucursales(); // Método para cargar sucursales
            CargarArticulos();  // Método para cargar artículos en el DataGridView
        }

        private void CargarSucursales()
        {

            List<Sucursal> sucursales = _sucursalService.ObtenerTodas().Where(s => s.Activo).ToList();

            cmbSucursal.DisplayMember = "Nombre"; // Muestra el nombre de la sucursal
            cmbSucursal.ValueMember = "IdSucursal"; // Usa el ID de la sucursal como valor
            cmbSucursal.DataSource = sucursales; // Asignar la lista de sucursales al ComboBox

            // Establecer el estilo de dropdown a solo lista
            cmbSucursal.DropDownStyle = ComboBoxStyle.DropDownList; // Esto hace que no se pueda escribir

        }

        private void CargarArticulos()
        {
            // Obtener todos los artículos activos
            List<Articulo> articulos = _articuloService.ObtenerTodos().Where(a => a.Activo).ToList();

            // Asignar directamente la lista de artículos al DataGridView
            dgvArticulos.DataSource = articulos;

            // El DataGridView se encargará de manejar las columnas automáticamente
        }

        // Evento para el botón de registrar artículos por sucursal
        private void btnRegistrarArticulosPorSucursal_Click(object sender, EventArgs e)
        {
            // Verificar si el ComboBox está vacío
            if (cmbSucursal.Items.Count == 0)
            {
                MessageBox.Show("No hay sucursales disponibles por favor vaya a la pestaña e ingrese sucursal.");
                return;
            }
            // Verificar si no se ha seleccionado ningún elemento
            if (cmbSucursal.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una sucursal.");
                return;
            }

            // Verificar que se haya seleccionado al menos un artículo
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un artículo.");
                return;
            }

            // Aquí se valida que la cantidad sea numérica y mayor a cero.
            if (string.IsNullOrWhiteSpace(txtCantidadArticulos.Text) || 
                !int.TryParse(txtCantidadArticulos.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a cero.");
                txtCantidadArticulos.Clear();
                txtCantidadArticulos.Focus();
                return;
            }

            Sucursal sucursalSeleccionada = (Sucursal)cmbSucursal.SelectedItem;

            // Recorrer las filas seleccionadas en el DataGridView
            foreach (DataGridViewRow row in dgvArticulos.SelectedRows)
            {
                Articulo articuloSeleccionado = (Articulo)row.DataBoundItem;

                ArticuloSucursal articuloSucursal = new ArticuloSucursal
                {
                    Sucursal = sucursalSeleccionada,
                    Articulo = articuloSeleccionado,
                    Cantidad = cantidad
                };

                try
                {
                    // Registrar la asociación del artículo con la sucursal
                    _articuloSucursalService.Agregar(articuloSucursal);
                    MessageBox.Show($"Artículo '{articuloSeleccionado.Descripcion}' registrado para la sucursal '{sucursalSeleccionada.Nombre}' con cantidad {cantidad}.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Limpiar el campo de cantidad después de registrar
            txtCantidadArticulos.Clear();
        }
    }
}
