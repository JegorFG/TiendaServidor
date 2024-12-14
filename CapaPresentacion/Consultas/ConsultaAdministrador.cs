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
    public partial class ConsultaAdministrador : Form
    {
        private readonly AdministradorService _administradorService; // Servicio para manejar administradores

        public ConsultaAdministrador(AdministradorService administradorService)
        {            
            // Recibe el servicio ya configurado como dependencia
            _administradorService = administradorService;

            InitializeComponent();
            CargarAdministradores(); // Cargar todos los administradores al iniciar el formulario
                                     
        }

        // Método para cargar todos los administradores
        private void CargarAdministradores()
        {
            // Usa la Capa Lógica para obtener los datos
            var administradores = _administradorService.ObtenerTodos();
            dgvConsultaAdministrador.DataSource = administradores;
        }
    }
}
