using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class ArticuloService
    {
        private readonly IArticuloRepository _repositorio;

        // Constructor: Recibe el repositorio que interactúa con la base de datos.
        public ArticuloService(IArticuloRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Obtiene la lista de todos los artículos
        public List<Articulo> ObtenerTodos()
        {
            var articulos = _repositorio.ObtenerArticulos();

            if (articulos == null || articulos.Count == 0)
                throw new Exception("No se encontraron artículos registrados.");

            return articulos;
        }

        // Busca un artículo por su ID
        public Articulo ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del artículo debe ser mayor a 0.");

            var articulo = _repositorio.ObtenerArticuloPorId(id);

            if (articulo == null)
                throw new Exception($"No se encontró un artículo con el ID: {id}");

            return articulo;
        }

        // Agrega un nuevo artículo
        public void Agregar(Articulo articulo)
        {
            if (articulo == null)
                throw new ArgumentNullException(nameof(articulo));

            if (string.IsNullOrWhiteSpace(articulo.Descripcion))
                throw new ArgumentException("La descripción del artículo no puede estar vacía.");

            if (articulo.CategoriaArticulo == null || articulo.CategoriaArticulo.Id <= 0)
                throw new ArgumentException("El artículo debe estar asociado a una categoría válida.");

            if (_repositorio.Existe(articulo.Id))
                throw new Exception($"Ya existe un artículo con el ID: {articulo.Id}");

            _repositorio.AgregarArticulo(articulo);
        }

        // Verifica si un artículo existe
        public bool Existe(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del artículo debe ser mayor a 0.");

            return _repositorio.Existe(id);
        }
    }
}

