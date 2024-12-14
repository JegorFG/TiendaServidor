
namespace CapaEntidades
{
    public class Instruccion<T>
    {
        public string Mensaje { get; set; }
        public T Dato { get; set; }

        public Instruccion() { }
    }
}
