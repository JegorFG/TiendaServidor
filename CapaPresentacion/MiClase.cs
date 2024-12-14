using System.Configuration;

public class MiClase
{
    public void RecorrerAppConfig()
    {
        string mensaje = ""; // Variable para almacenar las claves y valores

        // Obtiene todas las claves en la sección AppSettings
        foreach (string key in ConfigurationManager.AppSettings)
        {
            // Obtiene el valor correspondiente a la clave
            string value = ConfigurationManager.AppSettings[key];

            // Construye el mensaje
            mensaje += $"Clave: {key}, Valor: {value}\n";
        }

        // Muestra el mensaje en una ventana emergente
        MessageBox.Show(mensaje, "Configuraciones del App.config", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    public void RecorrerConnectionStrings()
    {
        string mensaje = ""; // Variable para construir el mensaje

        // Recorre todas las cadenas de conexión definidas
        foreach (ConnectionStringSettings connection in ConfigurationManager.ConnectionStrings)
        {
            // Obtiene los detalles de cada cadena
            string name = connection.Name;
            string connectionString = connection.ConnectionString;
            string provider = connection.ProviderName;

            // Construye el mensaje con la información
            mensaje += $"Nombre: {name}\nCadena: {connectionString}\nProveedor: {provider}\n\n";
        }

        // Muestra el resultado en un MessageBox
        MessageBox.Show(mensaje, "Connection Strings", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}

