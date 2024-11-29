using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * UNED III Cuatrimestre
 * Proyecto: Sistema para Tienda Deportiva
 * Estudiante: Jesús Garita Obando
 * Cédula: 303870610
 * Fecha: 30/11/2024
 * 
 * Fuentes Externas y Asistencia
 * El código del proyecto fue desarrollado principalmente por el autor, con ayuda de:
 * La tutoría de la UNED https://www.youtube.com/watch?v=2ZOUapJjgpg y 
 * ChatGPT de OpenAI para sugerencias en la validación y mejora del diseño.
 * GitHub para el control de versiones
*/

namespace CapaEntidades
{
    // Representa un artículo.
    public class Articulo
    {
        public int Id { get; set; } // ID único del artículo.
        public string Descripcion { get; set; } // Descripción del artículo.
        public Categoria CategoriaArticulo { get; set; } // Categoría del artículo.
        public string Marca { get; set; } // Marca del artículo.
        public bool Activo { get; set; } // Indica si el artículo está activo.


        // Constructor parametrizado para inicializar las propiedades.
        public Articulo(int id, string descripcion, Categoria categoriaArticulo, string marca, bool activo)
        {
            Id = id;
            Descripcion = descripcion;
            CategoriaArticulo = categoriaArticulo;
            Marca = marca;
            Activo = activo;
        }

        public Articulo() { }
    }
}
