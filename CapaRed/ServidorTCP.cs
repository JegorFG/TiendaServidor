using CapaEntidades;
using CapaLogica;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Text;

namespace CapaRed
{
    public class ServidorTCP
    {
        // Listener encargado de aceptar conexiones entrantes.
        private TcpListener _listener;

        // Lista para almacenar los clientes conectados al servidor.
        private List<TcpClient> _clientesConectados = new List<TcpClient>();

        // Configuración del servidor: dirección IP y puerto, leídos del archivo de configuración.
        private readonly string _serverIP = ConfigurationManager.AppSettings["ServidorIP"];
        private readonly int _puerto = int.Parse(ConfigurationManager.AppSettings["ServidorPuerto"]);

        // Componente encargado de procesar las instrucciones enviadas por los clientes.
        private readonly ProcesadorDeMensajes _procesadorDeMensajes;

        // Bandera para indicar si el servidor está activo.
        public bool ServidorIniciado { get; private set; } = false;

        // Constructor que inicializa el servidor y el procesador de mensajes.
        public ServidorTCP()
        {
            _listener = new TcpListener(IPAddress.Parse(_serverIP), _puerto);
            _procesadorDeMensajes = new ProcesadorDeMensajes();
        }

        // Método para iniciar el servidor y comenzar a escuchar conexiones de clientes.
        public void IniciarServidor(Action<string> actualizarBitacora, Action<int> actualizarContadorClientes)
        {
            if (ServidorIniciado) return; // Prevenir múltiples inicios.

            _listener.Start(); // Inicia el listener.
            ServidorIniciado = true;
            actualizarBitacora($"Servidor iniciado en {_serverIP}:{_puerto}");

            // Crea un hilo para manejar las conexiones entrantes.
            Thread hiloEscucha = new Thread(() => EscucharClientes(actualizarBitacora, actualizarContadorClientes));
            hiloEscucha.Start();
        }

        // Método para escuchar y aceptar nuevas conexiones de clientes.
        private void EscucharClientes(Action<string> actualizarBitacora, Action<int> actualizarContadorClientes)
        {
            while (ServidorIniciado)
            {
                try
                {
                    // Acepta una nueva conexión de cliente.
                    TcpClient cliente = _listener.AcceptTcpClient();

                    // Agrega el cliente a la lista de clientes conectados (protegiendo el acceso concurrente).
                    lock (_clientesConectados)
                    {
                        _clientesConectados.Add(cliente);
                    }

                    actualizarBitacora($"Cliente conectado desde {cliente.Client.RemoteEndPoint}");
                    actualizarContadorClientes(_clientesConectados.Count);

                    // Crea un hilo separado para manejar la comunicación con este cliente.
                    Thread hiloCliente = new Thread(() => ManejarCliente(cliente, actualizarBitacora, actualizarContadorClientes));
                    hiloCliente.Start();
                }
                catch (SocketException ex)
                {
                    // Maneja errores al escuchar conexiones.
                    actualizarBitacora($"Error en la escucha de clientes: {ex.Message}");
                }
            }
        }

        // Método para manejar la comunicación con un cliente específico.
        private void ManejarCliente(TcpClient cliente, Action<string> actualizarBitacora, Action<int> actualizarContadorClientes)
        {
            NetworkStream stream = cliente.GetStream(); // Obtiene el stream para la comunicación.
            try
            {
                string mensajeRecibido;
                // Lee mensajes enviados por el cliente hasta que cierre la conexión.
                while ((mensajeRecibido = RecibirMensaje(stream)) != null)
                {
                    // Deserializa el mensaje en una instrucción genérica.
                    var instruccion = JsonSerializer.Deserialize<Instruccion<object>>(mensajeRecibido);
                    if (instruccion != null)
                    {
                        // Procesa la instrucción recibida utilizando el procesador de mensajes.
                        var respuesta = _procesadorDeMensajes.ProcesarInstruccion(instruccion);

                        // Serializa la respuesta y la envía de vuelta al cliente.
                        string respuestaJson = JsonSerializer.Serialize(respuesta);
                        EnviarMensaje(stream, respuestaJson);
                    }
                    else
                    {
                        // Envía un mensaje de error si la instrucción no es válida.
                        EnviarMensaje(stream, JsonSerializer.Serialize(new Instruccion<object>
                        {
                            Mensaje = "Error en formato de mensaje",
                            Dato = null
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                // Maneja errores durante la comunicación con el cliente.
                actualizarBitacora($"Error manejando cliente: {ex.Message}");
            }
            finally
            {
                // Cierra el stream y la conexión del cliente.
                stream.Close();
                cliente.Close();

                // Remueve el cliente de la lista de clientes conectados (protegiendo el acceso concurrente).
                lock (_clientesConectados)
                {
                    _clientesConectados.Remove(cliente);
                }

                actualizarContadorClientes(_clientesConectados.Count);
                actualizarBitacora("Cliente desconectado");
            }
        }

        // Método para recibir mensajes del cliente.
        private string RecibirMensaje(NetworkStream stream)
        {
            byte[] buffer = new byte[8000]; // Buffer de lectura.
            int bytesRead = stream.Read(buffer, 0, buffer.Length); // Lee datos del stream.
            return Encoding.UTF8.GetString(buffer, 0, bytesRead); // Convierte los datos en una cadena.
        }

        // Método para enviar mensajes al cliente.
        private void EnviarMensaje(NetworkStream stream, string mensaje)
        {
            byte[] data = Encoding.UTF8.GetBytes(mensaje); // Convierte el mensaje en bytes.
            stream.Write(data, 0, data.Length); // Escribe los datos en el stream.
            stream.Flush(); // Asegura que los datos se envíen inmediatamente.
        }

        // Método para detener el servidor y cerrar todas las conexiones activas.
        public void DetenerServidor(Action<string> actualizarBitacora, Action<int> actualizarContadorClientes)
        {
            if (!ServidorIniciado) return; // Prevenir múltiples detenciones.

            ServidorIniciado = false;
            _listener.Stop(); // Detiene el listener.
            actualizarBitacora("Servidor detenido.");

            // Cierra todas las conexiones activas.
            lock (_clientesConectados)
            {
                foreach (var cliente in _clientesConectados)
                {
                    cliente.Close();
                }
                _clientesConectados.Clear();
            }

            actualizarContadorClientes(0);
        }
    }
}
