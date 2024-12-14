using CapaPresentacion;
using CapaRed;
using Microsoft.Extensions.DependencyInjection;

namespace Servidor
{
    public partial class FormServidor : Form
    {
        private readonly ServidorTCP _servidorTCP;
        private readonly IServiceProvider _serviceProvider; // Contenedor de servicios para resolver dependencias

        public FormServidor(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider; // Guardar el contenedor de servicios
            _servidorTCP = new ServidorTCP();
        }

        private void btnIniciarServidor_Click(object sender, EventArgs e)
        {
            // Iniciar servidor
            _servidorTCP.IniciarServidor(ActualizarBitacora, ActualizarContadorClientes);
        }

        private void btnDetenerServidor_Click(object sender, EventArgs e)
        {
            // Detener servidor
            _servidorTCP.DetenerServidor(ActualizarBitacora, ActualizarContadorClientes);
        }

        private void ActualizarContadorClientes(int contador)
        {
            if (lbServidor.InvokeRequired)
            {
                lbServidor.Invoke(new Action(() => lbServidor.Text = $"Clientes conectados: {contador}"));
            }
            else
            {
                lbServidor.Text = $"Clientes conectados: {contador}";
            }
        }

        private void ActualizarBitacora(string mensaje)
        {
            if (lstBitacora.InvokeRequired)
            {
                lstBitacora.Invoke(new Action(() =>
                {
                    lstBitacora.Items.Add(mensaje);
                    lstBitacora.TopIndex = lstBitacora.Items.Count - 1;
                }));
            }
            else
            {
                lstBitacora.Items.Add(mensaje);
                lstBitacora.TopIndex = lstBitacora.Items.Count - 1;
            }
        }

        /// <summary>
        /// Abre un formulario de tipo T de manera segura. 
        /// Solo se abrirá si no existe una instancia abierta de ese formulario.
        /// </summary>
        /// <typeparam name="T">Tipo de formulario que se desea abrir (debe ser un Form).</typeparam>
        /// <param name="formFactory">Función de fábrica para crear la instancia del formulario.</param>
        
        private void OpenForm<T>(Func<T> formFactory) where T : Form
        {
            // Comprueba si ya existe un formulario abierto de tipo T.
            if (Application.OpenForms.OfType<T>().Any())
                return; // Si ya existe, no hacer nada y salir del método.

            // Si no existe, se crea una instancia del formulario utilizando la función de fábrica.
            T frm = formFactory();

            // Muestra el formulario en pantalla.
            frm.Show();
        }

        private void tsConsultarAdministrador_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaAdministrador>());
        }

        private void tsRegistrarAdministrador_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarAdministrador>());
        }

        private void tsConsultarArticulos_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaArticulos>());
        }

        private void tsRegistrarArticulos_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarArticulo>());
        }

        private void tsConsultarArticulosSucursal_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaArticulosSucursal>());
        }

        private void tsRegistrarArticulosSucursal_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarArtículosSucursal>());
        }

        private void tsConsultarCategoríaArticulos_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaCategoriaArticulos>());
        }

        private void tsRegistrarCategoríaArticulos_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarCategoriaArticulos>());
        }

        private void tsConsultarCliente_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaClientes>());
        }

        private void tsRegistrarCliente_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarCliente>());
        }

        private void tsConsultarSucursal_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<ConsultaSucursal>());
        }

        private void tsRegistrarSucursal_Click(object sender, EventArgs e)
        {
            OpenForm(() => _serviceProvider.GetRequiredService<RegistrarSucursal>());
        }
    }
}
