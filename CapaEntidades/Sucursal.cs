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
    // Representa una sucursal.
    public class Sucursal
    {
        public int IdSucursal { get; set; } // ID único de la sucursal.
        public string Nombre { get; set; } // Nombre de la sucursal.
        public Administrador AdminSucursal { get; set; } // Administrador asignado a la sucursal.
        public string Direccion { get; set; } // Dirección de la sucursal.
        public string Telefono { get; set; } // Teléfono de contacto de la sucursal.
        public bool Activo { get; set; } // Indica si la sucursal está activa.
                
        // Constructor
        public Sucursal(int idSucursal, string nombre, string direccion, string telefono, bool activo, Administrador adminSucursal = null)
        {
            IdSucursal = idSucursal;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Activo = activo;
            AdminSucursal = adminSucursal; // Asignar administrador, si se proporciona
        }

        public Sucursal() { }
    }
}
