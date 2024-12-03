using CapaEntidades;
using System;
using System.Collections.Generic;

namespace CapaDatos.Interfaces
{
    // Interfaz que define los métodos para interactuar con la tabla Reserva.
    public interface IReservaRepository
    {
        List<Reserva> ObtenerReservas();
        Reserva ObtenerReservaPorId(int idReserva);
        void AgregarReserva(Reserva reserva);
        void ActualizarReserva(Reserva reserva);
        bool Existe(int idReserva);
    }
}

