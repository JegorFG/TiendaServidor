using System.Collections.Generic;
using CapaEntidades;

namespace CapaDatos.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ObtenerClientes();
        Cliente ObtenerClientePorId(int id);
        void AgregarCliente(Cliente cliente);
        void ActualizarCliente(Cliente cliente);
        void EliminarCliente(int id);
        bool Existe(int id);

    }
}

