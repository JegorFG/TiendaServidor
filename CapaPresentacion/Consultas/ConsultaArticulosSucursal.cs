using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public partial class ConsultaArticulosSucursal : Form
    {
        private readonly ArticuloSucursalService _articulosxSucursalService; // Servicio para manejar asociaciones

        public ConsultaArticulosSucursal(ArticuloSucursalService articuloSucursalService)
        {
            InitializeComponent();

            _articulosxSucursalService = articuloSucursalService;
            
            CargarArticulosPorSucursal(); // Cargar todas las asociaciones al iniciar el formulario
        }

        // Método para cargar todas las asociaciones de artículos por sucursal
        private void CargarArticulosPorSucursal()
        {
            // Obtener todas las asignaciones
            var asignaciones = _articulosxSucursalService.ObtenerTodas(); // Obtener todas las asignaciones

            // Crear una lista anónima para mostrar en el DataGridView
            var asignacionesDetalladas = asignaciones.Select(a => new
            {
                a.Sucursal.IdSucursal,                      // ID de la sucursal
                NombreSucursal = a.Sucursal.Nombre,        // Nombre de la sucursal
                a.Articulo.Id,                             // ID del artículo
                NombreArticulo = a.Articulo.Descripcion,   // Descripción del artículo
                a.Cantidad,                                 // Cantidad asignada
                Estado = a.Sucursal.Activo ? "Activo" : "Inactivo" // Estado de la sucursal
            }).ToList();

            dgvConsultaArticulosSucursal.DataSource = asignacionesDetalladas; // Cargar las asignaciones en el DataGridView

            // Configurar encabezados de columnas
            dgvConsultaArticulosSucursal.Columns["IdSucursal"].HeaderText = "ID de Sucursal";
            dgvConsultaArticulosSucursal.Columns["NombreSucursal"].HeaderText = "Nombre de Sucursal";
            dgvConsultaArticulosSucursal.Columns["Id"].HeaderText = "ID del Artículo";
            dgvConsultaArticulosSucursal.Columns["NombreArticulo"].HeaderText = "Descripción del Artículo";
            dgvConsultaArticulosSucursal.Columns["Cantidad"].HeaderText = "Cantidad Asignada";
            dgvConsultaArticulosSucursal.Columns["Estado"].HeaderText = "Estado"; // Mostrar estado de la sucursal
        }
    }
}
