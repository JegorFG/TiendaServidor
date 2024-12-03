using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;

namespace CapaLogica
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repositorio;

        // Constructor que recibe el repositorio para interactuar con la base de datos.
        public CategoriaService(ICategoriaRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Obtiene todas las categorías registradas.
        public List<Categoria> ObtenerTodas()
        {
            var categorias = _repositorio.ObtenerCategorias();

            if (categorias == null || categorias.Count == 0)
                throw new Exception("No se encontraron categorías registradas.");

            return categorias;
        }

        // Obtiene una categoría específica por su ID.
        public Categoria ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID de la categoría debe ser mayor a 0.");

            var categoria = _repositorio.ObtenerCategoriaPorId(id);

            if (categoria == null)
                throw new Exception($"No se encontró ninguna categoría con ID: {id}");

            return categoria;
        }

        // Agrega una nueva categoría.
        public void Agregar(Categoria categoria)
        {
            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            if (string.IsNullOrWhiteSpace(categoria.Nombre))
                throw new ArgumentException("El nombre de la categoría no puede estar vacío.");

            if (_repositorio.Existe(categoria.Id))
                throw new Exception($"La categoría con ID {categoria.Id} ya existe.");

            _repositorio.AgregarCategoria(categoria);
        }
    }
}

