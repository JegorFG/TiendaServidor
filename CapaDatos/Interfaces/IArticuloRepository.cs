using CapaEntidades;

namespace CapaDatos.Interfaces
{
    // Define los métodos que manejarán las operaciones para la tabla Articulo.
    public interface IArticuloRepository
    {
        // Obtiene una lista de todos los artículos.
        List<Articulo> ObtenerArticulos();

        // Obtiene un artículo específico por su ID.
        Articulo ObtenerArticuloPorId(int id);

        // Agrega un nuevo artículo a la base de datos.
        void AgregarArticulo(Articulo articulo);

        // Verifica si un artículo existe en la base de datos usando su ID.
        bool Existe(int id);
    }
}

