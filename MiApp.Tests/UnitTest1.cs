using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CapaDatos;  
using CapaDatos.Interfaces;
using System.Diagnostics;
using CapaEntidades;

namespace MiApp.Tests
{
    [TestClass]
    public class ReservaDatosTests
    {
        private IConexion conexion;
        private CapaDatos.ClienteDatos clienteDatos;

        [TestInitialize]
        public void Setup()
        {
            // Aquí puedes inicializar objetos que se usarán en las pruebas
            conexion = new Conexion(); // Suponiendo que tienes una clase que implementa IConexion
            clienteDatos = new CapaDatos.ClienteDatos(conexion);
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
        
        [TestMethod]
        public void TestAgregarCliente()
        {
            var cliente = new CapaEntidades.Cliente()
            {
                Identificacion = 123,
                Nombre = "Juanito",
                PrimerApellido = "Apellido1",
                SegundoApellido = "Apellido2",
                FechaNacimiento = DateTime.Now,
                Activo = true
            };

            // Act: ejecuta el método que deseas probar
            this.clienteDatos.AgregarCliente(cliente);

            // Assert: verifica que el comportamiento es el esperado
            var resultado = this.clienteDatos.ObtenerClientePorId(123);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(123, resultado.Identificacion);
            Assert.AreEqual("Juanito", resultado.Nombre);
        }
        
        // Aquí puedes agregar más métodos de prueba
    }
}
