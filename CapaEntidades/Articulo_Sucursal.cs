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
    public class Articulo_Sucursal
    {
        public Sucursal Sucursal { get; set; } // Objeto Sucursal
        public Articulo Articulo { get; set; } // Objeto Articulo
        public int Cantidad { get; set; } // Cantidad de artículos asignados

        public Articulo_Sucursal(Sucursal sucursal, Articulo articulo, int cantidad)
        {
            Sucursal = sucursal;
            Articulo = articulo;
            Cantidad = cantidad;
        }

        public Articulo_Sucursal() { }

        public void RestarCantidad(int cantidad)
        {
            if (Cantidad - cantidad < 0)
                throw new InvalidOperationException("No hay suficiente cantidad.");
            Cantidad -= cantidad;
        }

    }
}

