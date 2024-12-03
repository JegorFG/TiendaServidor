using System;
using System.Collections.Generic;
using CapaDatos.Interfaces;
using CapaEntidades;

namespace CapaLogica
{
    public class ReservaService
    {
        private readonly IReservaRepository _repositorio;

        // Constructor que recibe la implementación del repositorio
        public ReservaService(IReservaRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Método para obtener todas las reservas
        public List<Reserva> ObtenerTodas()
        {
            var reservas = _repositorio.ObtenerReservas();
            return reservas?.Count > 0 ? reservas : throw new Exception("No se encontraron reservas registradas.");
        }

        // Método para obtener una reserva por su ID
        public Reserva ObtenerPorId(int idReserva)
        {
            if (idReserva <= 0)
                throw new ArgumentException("El ID de la reserva debe ser mayor a cero.", nameof(idReserva));

            var reserva = _repositorio.ObtenerReservaPorId(idReserva);
            return reserva ?? throw new Exception($"No se encontró ninguna reserva con el ID: {idReserva}.");
        }

        // Método para agregar una nueva reserva
        public void Agregar(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");

            if (_repositorio.Existe(reserva.IdReserva))
                throw new Exception($"Ya existe una reserva con el ID: {reserva.IdReserva}.");

            _repositorio.AgregarReserva(reserva);
        }

        // Método para actualizar una reserva existente
        public void Actualizar(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva), "La reserva no puede ser nula.");

            if (!_repositorio.Existe(reserva.IdReserva))
                throw new Exception($"No se puede actualizar. La reserva con ID: {reserva.IdReserva} no existe.");

            _repositorio.ActualizarReserva(reserva);
        }

        // Método para verificar si una reserva existe por su ID
        public bool Existe(int idReserva)
        {
            if (idReserva <= 0)
                throw new ArgumentException("El ID de la reserva debe ser mayor a cero.", nameof(idReserva));

            return _repositorio.Existe(idReserva);
        }
    }
}
