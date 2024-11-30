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
    // Representa una reserva realizada en el sistema
    public class Reserva
    {
        public int IdReserva { get; set; }
        public ArticuloSucursal ArticuloSucursal { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaReserva { get; set; }

        // Constructor parametrizado para inicializar todas las propiedades
        public Reserva(int idReserva, ArticuloSucursal articuloSucursal, Cliente cliente, DateTime fechaReserva)
        {
            IdReserva = idReserva;
            ArticuloSucursal = articuloSucursal;
            Cliente = cliente;
            FechaReserva = fechaReserva;
        }

        // Constructor vacío para inicializar una reserva sin parámetros
        public Reserva() { }

        public bool EsValida()
        {
            return FechaReserva >= DateTime.Now;
        }

    }
}
