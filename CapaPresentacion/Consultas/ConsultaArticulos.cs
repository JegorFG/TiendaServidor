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
using CapaLogica;

namespace CapaPresentacion
{
    public partial class ConsultaArticulos : Form
    {
        private readonly ArticuloService _articuloService; // Servicio para manejar los artículos

        public ConsultaArticulos(ArticuloService articuloService)
        {
            _articuloService = articuloService;

            InitializeComponent();
            CargarArticulos(); // Cargar todos los artículos al iniciar el formulario
        }

        // Método para cargar todos los artículos
        private void CargarArticulos()
        {
            // Obtener todos los artículos
            var articulos = _articuloService.ObtenerTodos();

            // Crear una lista anónima con las propiedades que deseas mostrar en el DataGridView
            var articulosDetallados = articulos.Select(a => new
            {
                a.Id,                                  // ID del artículo
                a.Descripcion,                         // Descripción del artículo
                NombreCategoria = a.CategoriaArticulo?.Nombre ?? "Sin Categoría", // Nombre de la categoría (o "Sin Categoría" si es nula)
                a.Marca,                               // Marca del artículo
                Estado = a.Activo ? "Activo" : "Inactivo" // Estado del artículo
            }).ToList();

            // Asignar la lista anónima al DataGridView
            dgvConsultaArticulos.DataSource = articulosDetallados;

            // Configurar encabezados de columnas para hacerlos más amigables
            dgvConsultaArticulos.Columns["Id"].HeaderText = "ID del Artículo";
            dgvConsultaArticulos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvConsultaArticulos.Columns["NombreCategoria"].HeaderText = "Categoría";
            dgvConsultaArticulos.Columns["Marca"].HeaderText = "Marca";
            dgvConsultaArticulos.Columns["Estado"].HeaderText = "Estado";
        }
    }
}