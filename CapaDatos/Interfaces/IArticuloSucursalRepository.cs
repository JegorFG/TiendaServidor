using CapaEntidades;
using System.Collections.Generic;

namespace CapaDatos.Interfaces
{
    // Interfaz que define los métodos para interactuar con la tabla ArticuloxSucursal.
    public interface IArticuloSucursalRepository
    {
        // Método para obtener todas las relaciones Articulo-Sucursal.
        List<ArticuloSucursal> ObtenerArticulosSucursal();

        // Método para obtener las relaciones de un artículo en una sucursal específica.
        List<ArticuloSucursal> ObtenerArticulosPorSucursal(int idSucursal);

        // Método para agregar una nueva relación Articulo-Sucursal.
        void AgregarArticuloSucursal(ArticuloSucursal articuloSucursal);

        // Método para actualizar la cantidad de un artículo en una sucursal, manejando concurrencia.
        void ActualizarCantidad(ArticuloSucursal articuloSucursal, int cantidadCambio);
    }
}
