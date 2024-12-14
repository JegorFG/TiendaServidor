using CapaEntidades;

namespace CapaLogica
{
    public class ProcesadorDeMensajes
    {
        public Instruccion<object> ProcesarInstruccion(Instruccion<object> instruccion)
        {
            switch (instruccion.Mensaje)
            {
                case "RegistrarCliente":
                    if (instruccion.Dato is Cliente cliente)
                    {
                        return RegistrarCliente(cliente);
                    }
                    return new Instruccion<object>
                    {
                        Mensaje = "Error: Dato no es del tipo Cliente",
                        Dato = null
                    };
                case "ConsultarCliente":
                    return ConsultarCliente(Convert.ToInt32(instruccion.Dato));
                default:
                    return new Instruccion<object>
                    {
                        Mensaje = "Comando no reconocido",
                        Dato = null
                    };
            }
        }

        private Instruccion<object> RegistrarCliente(Cliente? cliente)
        {
            if (cliente == null)
            {
                return new Instruccion<object>
                {
                    Mensaje = "Error al registrar cliente: datos inválidos",
                    Dato = null
                };
            }

            // Simulación de registro
            return new Instruccion<object>
            {
                Mensaje = "Cliente registrado correctamente",
                Dato = cliente
            };
        }

        private Instruccion<object> ConsultarCliente(int idCliente)
        {
            // Simulación de consulta
            Cliente cliente = new Cliente
            {
                Identificacion = idCliente,
                Nombre = "Cliente de prueba",
                Activo = true
            };

            return new Instruccion<object>
            {
                Mensaje = "Consulta exitosa",
                Dato = cliente
            };
        }
    }
}

