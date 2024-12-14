using Servidor;
using Microsoft.Extensions.DependencyInjection;

namespace CapaPresentacion
{
    internal static class Program
    {
        /// <summary>
        /// El punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configurar la inyecci�n de dependencias
            var services = new ServiceCollection();
            DependencyInjectionConfig.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            try
            {
                // Configurar la aplicaci�n (ajustes b�sicos de configuraci�n)
                ApplicationConfiguration.Initialize();

                // Resolver la dependencia para el formulario principal
                var formServidor = serviceProvider.GetRequiredService<FormServidor>();

                // Ejecutar la aplicaci�n con la instancia del formulario principal
                Application.Run(formServidor);
            }
            catch (Exception ex)
            {
                // Manejo b�sico de excepciones al inicializar la aplicaci�n
                MessageBox.Show($"Error al iniciar la aplicaci�n: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

