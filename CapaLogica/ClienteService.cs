using CapaDatos.Interfaces;
using CapaEntidades;

namespace CapaLogica
{
    public class ClienteService
    {
        private readonly IClienteRepository _repositorio;

        // Constructor que recibe el repositorio para interactuar con la base de datos.
        public ClienteService(IClienteRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        // Método para obtener todos los clientes registrados.
        public List<Cliente> ObtenerTodos()
        {
            var clientes = _repositorio.ObtenerClientes();

            return (clientes == null || clientes.Count == 0)
                ? throw new Exception("No se encontraron clientes registrados.")
                : clientes;
        }

        // Método para obtener un cliente específico por su ID.
        public Cliente ObtenerPorId(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del cliente debe ser mayor a 0.");

            var cliente = _repositorio.ObtenerClientePorId(id);

            if (cliente == null)
                throw new Exception($"No se encontró ningún cliente con ID: {id}");

            return cliente;
        }

        // Método para agregar un nuevo cliente.
        public void Agregar(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente no puede estar vacío.");

            if (_repositorio.Existe(cliente.Identificacion))
                throw new Exception($"El cliente con ID {cliente.Identificacion} ya existe.");

            _repositorio.AgregarCliente(cliente);
        }

        // Método para actualizar un cliente existente.
        public void Actualizar(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            if (cliente.Identificacion <= 0)
                throw new ArgumentException("El ID del cliente debe ser mayor a 0.");

            if (!_repositorio.Existe(cliente.Identificacion))
                throw new Exception($"No se encontró ningún cliente con ID: {cliente.Identificacion}");

            _repositorio.ActualizarCliente(cliente);
        }

        // Método para eliminar un cliente por su ID.
        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID del cliente debe ser mayor a 0.");

            if (!_repositorio.Existe(id))
                throw new Exception($"No se encontró ningún cliente con ID: {id}");

            _repositorio.EliminarCliente(id);
        }
    }
}
