using System;
using System.Collections.Generic;
using CapaDatos.Interfaces;
using CapaEntidades;

namespace CapaLogica
{
    public class SucursalService
    {
        private readonly ISucursalRepository _repositorio;

        // Constructor que recibe la implementación del repositorio
        public SucursalService(ISucursalRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Método para obtener todas las sucursales
        public List<Sucursal> ObtenerTodas()
        {
            var sucursales = _repositorio.ObtenerSucursales();
            return sucursales?.Count > 0 ? sucursales : throw new Exception("No se encontraron sucursales registradas.");
        }

        // Método para obtener una sucursal por su ID
        public Sucursal ObtenerPorId(int idSucursal)
        {
            if (idSucursal <= 0)
                throw new ArgumentException("El ID de la sucursal debe ser mayor a cero.", nameof(idSucursal));

            var sucursal = _repositorio.ObtenerSucursalPorId(idSucursal);
            return sucursal ?? throw new Exception($"No se encontró ninguna sucursal con el ID: {idSucursal}.");
        }

        // Método para agregar una nueva sucursal
        public void Agregar(Sucursal sucursal)
        {
            if (sucursal == null)
                throw new ArgumentNullException(nameof(sucursal), "La sucursal no puede ser nula.");

            if (_repositorio.Existe(sucursal.IdSucursal))
                throw new Exception($"Ya existe una sucursal con el ID: {sucursal.IdSucursal}.");

            _repositorio.AgregarSucursal(sucursal);
        }

        // Método para actualizar una sucursal existente
        public void Actualizar(Sucursal sucursal)
        {
            if (sucursal == null)
                throw new ArgumentNullException(nameof(sucursal), "La sucursal no puede ser nula.");

            if (!_repositorio.Existe(sucursal.IdSucursal))
                throw new Exception($"No se puede actualizar. La sucursal con ID: {sucursal.IdSucursal} no existe.");

            _repositorio.ActualizarSucursal(sucursal);
        }

        // Método para verificar si una sucursal existe por su ID
        public bool Existe(int idSucursal)
        {
            if (idSucursal <= 0)
                throw new ArgumentException("El ID de la sucursal debe ser mayor a cero.", nameof(idSucursal));

            return _repositorio.Existe(idSucursal);
        }
    }
}
