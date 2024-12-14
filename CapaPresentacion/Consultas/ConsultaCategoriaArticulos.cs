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
    public partial class ConsultaCategoriaArticulos : Form
    {
        private readonly CategoriaService _categoriaService; // Servicio para manejar las categorías

        public ConsultaCategoriaArticulos()
        {
            InitializeComponent();
            CargarCategorias(); // Cargar todas las categorías al iniciar el formulario
        }

        // Método para cargar todas las categorías
        private void CargarCategorias()
        {
            dgvConsultaCategoriaArticulos.DataSource = _categoriaService.ObtenerTodas(); // Cargar las categorías en el DataGridView
        }
    }
}
