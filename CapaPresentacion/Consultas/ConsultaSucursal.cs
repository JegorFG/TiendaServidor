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
using System.Data;

namespace CapaPresentacion
{
    public partial class ConsultaSucursal : Form
    {
        private readonly SucursalService _sucursalService; // Servicio para manejar las sucursales

        public ConsultaSucursal(SucursalService sucursalService)
        {
            InitializeComponent();

            _sucursalService = sucursalService;

            CargarSucursales(); // Cargar todas las sucursales al iniciar el formulario
        }

        private void CargarSucursales()
        {
            var sucursales = _sucursalService.ObtenerTodas(); // Obtener todas las sucursales

            // Crear una lista anónima para mostrar en el DataGridView
            var sucursalesConAdministrador = sucursales.Select(s => new
            {
                s.IdSucursal,
                s.Nombre,
                s.Direccion,
                s.Telefono,
                NombreAdministrador = s.AdminSucursal != null ? $"{s.AdminSucursal.Nombre} {s.AdminSucursal.PrimerApellido} {s.AdminSucursal.SegundoApellido}" : "Sin Administrador", // Obtener el nombre directamente del objeto AdminSucursal
                Estado = s.Activo ? "Activo" : "Inactivo" // Mostrar el estado como texto
            }).ToList();

            dgvConsultaSucursal.DataSource = sucursalesConAdministrador; // Cargar las sucursales en el DataGridView

            // Configurar encabezados de columnas
            dgvConsultaSucursal.Columns["IdSucursal"].HeaderText = "ID de Sucursal";
            dgvConsultaSucursal.Columns["Nombre"].HeaderText = "Nombre de Sucursal";
            dgvConsultaSucursal.Columns["Direccion"].HeaderText = "Dirección";
            dgvConsultaSucursal.Columns["Telefono"].HeaderText = "Teléfono";
            dgvConsultaSucursal.Columns["Estado"].HeaderText = "Estado";
            dgvConsultaSucursal.Columns["NombreAdministrador"].HeaderText = "Administrador"; // Mostrar nombre del administrador
        }
    }
}
