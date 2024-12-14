using Microsoft.Extensions.DependencyInjection;
using CapaLogica;
using CapaDatos;
using CapaDatos.Interfaces;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureServices(IServiceCollection services)
    {
        // Registrar implementaciones de interfaces de la capa de datos
        services.AddSingleton<IConexion, Conexion>(); // Registrar conexión a la base de datos
        services.AddScoped<IClienteRepository, ClienteDatos>(); // Registro del repositorio Cliente
        services.AddScoped<IAdministradorRepository, AdministradorDatos>(); // Registrar repositorio Administrador
        services.AddScoped<IArticuloRepository, ArticuloDatos>(); // Registrar repositorio Artículo
        services.AddScoped<IArticuloSucursalRepository, ArticuloSucursalDatos>(); // Registrar repositorio ArtículoSucursal
        services.AddScoped<ICategoriaRepository, CategoriaDatos>(); // Registrar repositorio Categoría
        services.AddScoped<IReservaRepository, ReservaDatos>(); // Registrar repositorio Reserva
        services.AddScoped<ISucursalRepository, SucursalDatos>(); // Registrar repositorio Sucursal

        // Registrar servicios de la capa lógica
        services.AddScoped<ClienteService>(); // Servicio Cliente
        services.AddScoped<AdministradorService>(); // Servicio Administrador
        services.AddScoped<ArticuloService>(); // Servicio Artículo
        services.AddScoped<ArticuloSucursalService>(); // Servicio ArtículoSucursal
        services.AddScoped<CategoriaService>(); // Servicio Categoría
        services.AddScoped<ReservaService>(); // Servicio Reserva
        services.AddScoped<SucursalService>(); // Servicio Sucursal

        // Registrar el formulario principal con sus dependencias
        services.AddScoped<FormServidor>();

        return services;
    }
}

