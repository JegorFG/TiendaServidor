using CapaDatos.Interfaces;
using CapaEntidades;

namespace CapaLogica
{
    public class ArticuloSucursalService
    {
        private readonly IArticuloSucursalRepository _repositorio;

        // Constructor: Recibe el repositorio que interactúa con la base de datos.
        public ArticuloSucursalService(IArticuloSucursalRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Obtiene todas las relaciones entre artículos y sucursales
        public List<ArticuloSucursal> ObtenerTodas()
        {
            var relaciones = _repositorio.ObtenerArticulosSucursal();

            if (relaciones == null || relaciones.Count == 0)
                throw new Exception("No se encontraron relaciones Artículo-Sucursal.");

            return relaciones;
        }

        // Obtiene los artículos registrados en una sucursal específica
        public List<ArticuloSucursal> ObtenerPorSucursal(int idSucursal)
        {
            if (idSucursal <= 0)
                throw new ArgumentException("El ID de la sucursal debe ser mayor a 0.");

            var articulosSucursal = _repositorio.ObtenerArticulosPorSucursal(idSucursal);

            if (articulosSucursal == null || articulosSucursal.Count == 0)
                throw new Exception($"No se encontraron artículos para la sucursal con ID: {idSucursal}");

            return articulosSucursal;
        }

        // Agrega una nueva relación Artículo-Sucursal
        public void Agregar(ArticuloSucursal articuloSucursal)
        {
            if (articuloSucursal == null)
                throw new ArgumentNullException(nameof(articuloSucursal));

            if (articuloSucursal.Sucursal == null || articuloSucursal.Sucursal.IdSucursal <= 0)
                throw new ArgumentException("La sucursal asociada debe ser válida.");

            if (articuloSucursal.Articulo == null || articuloSucursal.Articulo.Id <= 0)
                throw new ArgumentException("El artículo asociado debe ser válido.");

            if (articuloSucursal.Cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            _repositorio.AgregarArticuloSucursal(articuloSucursal);
        }

        // Actualiza la cantidad de un artículo en una sucursal
        public void ActualizarCantidad(ArticuloSucursal articuloSucursal, int cantidadCambio)
        {
            if (articuloSucursal == null)
                throw new ArgumentNullException(nameof(articuloSucursal));

            if (articuloSucursal.Sucursal == null || articuloSucursal.Sucursal.IdSucursal <= 0)
                throw new ArgumentException("La sucursal asociada debe ser válida.");

            if (articuloSucursal.Articulo == null || articuloSucursal.Articulo.Id <= 0)
                throw new ArgumentException("El artículo asociado debe ser válido.");

            if (cantidadCambio == 0)
                throw new ArgumentException("El cambio en la cantidad no puede ser cero.");

            _repositorio.ActualizarCantidad(articuloSucursal, cantidadCambio);
        }
    }
}
