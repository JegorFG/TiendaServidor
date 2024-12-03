using CapaDatos;
using System.Configuration;
using System.Diagnostics;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            var cadena = ConfigurationManager.ConnectionStrings["MiConexion"]?.ConnectionString;
            Console.WriteLine(cadena ?? "No se encontró la conexión");
        }

        [TestMethod]
        public void TestConexion()
        {
            try
            {
                var conexion = new Conexion();
                Assert.IsNotNull(conexion); // Asegúrate de que la conexión se haya creado

                // Verifica que la cadena de conexión sea correcta
                Debug.WriteLine("Cadena de Conexión en la prueba: " + conexion.GetConnection().ConnectionString);
            }
            catch (Exception ex)
            {
                Assert.Fail("Error al obtener la cadena de conexión: " + ex.Message);
            }
        }

    }
}