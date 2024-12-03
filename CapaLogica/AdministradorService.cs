using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class AdministradorService
    {
        private readonly IAdministradorRepository _repositorio;

        // Constructor: Recibe el repositorio que interactúa con la base de datos.
        public AdministradorService(IAdministradorRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Obtiene la lista de administradores
        public List<Administrador> ObtenerTodos()
        {
            return _repositorio.ObtenerAdministradores();
        }

        // Busca un administrador por su ID
        public Administrador ObtenerPorId(int idAdministrador)
        {
            if (idAdministrador <= 0)
                throw new ArgumentException("El ID del administrador debe ser mayor a 0.");

            var administrador = _repositorio.ObtenerAdministradorPorId(idAdministrador);

            if (administrador == null)
                throw new Exception($"No se encontró un administrador con el ID: {idAdministrador}");

            return administrador;
        }

        // Agrega un nuevo administrador
        public void Agregar(Administrador administrador)
        {
            if (administrador == null)
                throw new ArgumentNullException(nameof(administrador));

            if (string.IsNullOrWhiteSpace(administrador.Nombre))
                throw new ArgumentException("El nombre del administrador no puede estar vacío.");

            if (_repositorio.Existe(administrador.Identificacion))
                throw new Exception($"Ya existe un administrador con el ID: {administrador.Identificacion}");

            _repositorio.AgregarAdministrador(administrador);
        }

        // Elimina un administrador por su ID
        public void Eliminar(int idAdministrador)
        {
            if (idAdministrador <= 0)
                throw new ArgumentException("El ID del administrador debe ser mayor a 0.");

            if (!_repositorio.Existe(idAdministrador))
                throw new Exception($"No se puede eliminar porque el administrador con ID: {idAdministrador} no existe.");

            _repositorio.EliminarAdministrador(idAdministrador);
        }

        // Verifica si un administrador existe
        public bool Existe(int idAdministrador)
        {
            if (idAdministrador <= 0)
                throw new ArgumentException("El ID del administrador debe ser mayor a 0.");

            return _repositorio.Existe(idAdministrador);
        }
    }
}

