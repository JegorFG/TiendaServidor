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
    public class Cliente : Persona
    {
        public bool Activo { get; set; }

        // Constructor para inicializar tanto las propiedades heredadas como la propiedad Activo
        public Cliente(int identificacion, string nombre, string primerApellido, string segundoApellido, DateTime fechaNacimiento, bool activo)
            : base(identificacion, nombre, primerApellido, segundoApellido, fechaNacimiento)
        {
            Activo = activo;
        }

        // Constructor vacío (opcional)
        public Cliente() { }

        public void ActivarCliente()
        {
            Activo = true;
        }

        public void DesactivarCliente()
        {
            Activo = false;
        }

    }
}

