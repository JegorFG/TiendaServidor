using CapaEntidades;
using System.Collections.Generic;

namespace CapaDatos.Interfaces
{
    // Interfaz que define los métodos para interactuar con la tabla Sucursal.
    public interface ISucursalRepository
    {
        List<Sucursal> ObtenerSucursales();
        Sucursal ObtenerSucursalPorId(int idSucursal);
        void AgregarSucursal(Sucursal sucursal);
        void ActualizarSucursal(Sucursal sucursal);
        bool Existe(int idSucursal);
    }
}

