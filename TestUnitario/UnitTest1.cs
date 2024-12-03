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
            Console.WriteLine(cadena ?? "No se encontr� la conexi�n");
        }

        [TestMethod]
        public void TestConexion()
        {
            try
            {
                var conexion = new Conexion();
                Assert.IsNotNull(conexion); // Aseg�rate de que la conexi�n se haya creado

                // Verifica que la cadena de conexi�n sea correcta
                Debug.WriteLine("Cadena de Conexi�n en la prueba: " + conexion.GetConnection().ConnectionString);
            }
            catch (Exception ex)
            {
                Assert.Fail("Error al obtener la cadena de conexi�n: " + ex.Message);
            }
        }

    }
}