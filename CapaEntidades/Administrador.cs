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
    public class Administrador : Persona
    {
        public DateTime FechaIngreso { get; set; }

        // Constructor para inicializar tanto las propiedades heredadas como la propiedad FechaIngreso
        public Administrador(int identificacion, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, DateTime fechaIngreso)
            : base(identificacion, nombre, primerApellido, segundoApellido, fechaNacimiento)
        {
            if (fechaIngreso > DateTime.Now)
                throw new ArgumentException("La fecha de ingreso no puede ser en el futuro.");
            FechaIngreso = fechaIngreso;
        }

        // Constructor vacío (opcional)
        public Administrador() { }
    }
}
