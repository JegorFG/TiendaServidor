using Microsoft.Extensions.DependencyInjection;
using CapaLogica;
using CapaDatos;
using CapaDatos.Interfaces;
using Servidor;
using CapaPresentacion;

// Clase de configuración para la inyección de dependencias
public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        // Registrar implementaciones de interfaces de la capa de datos
        // Se utilizan para abstraer el acceso a la base de datos y facilitar pruebas unitarias

        services.AddSingleton<IConexion, Conexion>(); // Registrar la implementación de la conexión a la base de datos como Singleton
        services.AddScoped<IClienteRepository, ClienteDatos>(); // Registrar el repositorio de Cliente
        services.AddScoped<IAdministradorRepository, AdministradorDatos>(); // Registrar el repositorio de Administrador
        services.AddScoped<IArticuloRepository, ArticuloDatos>(); // Registrar el repositorio de Artículo
        services.AddScoped<IArticuloSucursalRepository, ArticuloSucursalDatos>(); // Registrar el repositorio de ArtículoSucursal
        services.AddScoped<ICategoriaRepository, CategoriaDatos>(); // Registrar el repositorio de Categoría
        services.AddScoped<IReservaRepository, ReservaDatos>(); // Registrar el repositorio de Reserva
        services.AddScoped<ISucursalRepository, SucursalDatos>(); // Registrar el repositorio de Sucursal

        // Registrar los servicios de la capa lógica que contienen la lógica de negocio
        // Estos servicios dependen de los repositorios y encapsulan operaciones importantes para cada entidad

        services.AddScoped<ClienteService>(); // Servicio Cliente para la lógica relacionada con clientes
        services.AddScoped<AdministradorService>(); // Servicio Administrador para la lógica relacionada con administradores
        services.AddScoped<ArticuloService>(); // Servicio Artículo para la lógica relacionada con artículos
        services.AddScoped<ArticuloSucursalService>(); // Servicio ArtículoSucursal para la lógica relacionada con las asociaciones de artículos a sucursales
        services.AddScoped<CategoriaService>(); // Servicio Categoría para la lógica relacionada con categorías de artículos
        services.AddScoped<ReservaService>(); // Servicio Reserva para la lógica relacionada con reservas
        services.AddScoped<SucursalService>(); // Servicio Sucursal para la lógica relacionada con sucursales

        //Formularios
        services.AddScoped<ConsultaAdministrador>();
        services.AddScoped<RegistrarAdministrador>();
        services.AddScoped<ConsultaArticulos>();
        services.AddScoped<RegistrarArticulo>();
        services.AddScoped<ConsultaArticulosSucursal>();
        services.AddScoped<RegistrarArtículosSucursal>();
        services.AddScoped<ConsultaCategoriaArticulos>();
        services.AddScoped<RegistrarCategoriaArticulos>();
        services.AddScoped<ConsultaClientes>();
        services.AddScoped<RegistrarCliente>();
        services.AddScoped<ConsultaSucursal>();
        services.AddScoped<RegistrarSucursal>();


        // Registrar el formulario principal con sus dependencias
        // Esto permite que la inyección de dependencias se aplique a este formulario
        services.AddScoped<FormServidor>();

        // Devuelve el contenedor de servicios configurado
        return services;
    }
}


