using CapaEntidades;

namespace CapaDatos.Interfaces
{
    // Define las operaciones para gestionar administradores.
    public interface IAdministradorRepository
    {
        // Devuelve todos los administradores registrados.
        List<Administrador> ObtenerAdministradores();

        // Busca un administrador por su ID.
        Administrador ObtenerAdministradorPorId(int idAdministrador);

        // Agrega un nuevo administrador.
        void AgregarAdministrador(Administrador administrador);

        // Elimina un administrador por su ID.
        void EliminarAdministrador(int idAdministrador);

        // Verifica si un administrador existe.
        bool Existe(int idAdministrador);
    }
}

