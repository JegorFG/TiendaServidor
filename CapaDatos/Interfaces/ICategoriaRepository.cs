using System.Collections.Generic;

namespace CapaDatos.Interfaces
{
    // Interfaz que define los métodos que se deben implementar para interactuar con la tabla Categoria.
    public interface ICategoriaRepository
    {
        // Método para obtener todas las categorías.
        List<Categoria> ObtenerCategorias();

        // Método para obtener una categoría por su ID.
        Categoria ObtenerCategoriaPorId(int id);

        // Método para agregar una nueva categoría.
        void AgregarCategoria(Categoria categoria);

        // Método para verificar si una categoría existe.
        bool Existe(int id);
    }
}
