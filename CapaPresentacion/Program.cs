using Servidor;
using Microsoft.Extensions.DependencyInjection;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// El punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar la inyección de dependencias
            var services = new ServiceCollection();
            DependencyInjectionConfig.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            try
            {
                // Configurar la aplicación (ajustes básicos de configuración)
                ApplicationConfiguration.Initialize();

                // Resolver la dependencia para el formulario principal
                var formServidor = serviceProvider.GetRequiredService<FormServidor>();

                // Ejecutar la aplicación con la instancia del formulario principal
                Application.Run(formServidor);
            }
            catch (Exception ex)
            {
                // Manejo básico de excepciones al inicializar la aplicación
                MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

