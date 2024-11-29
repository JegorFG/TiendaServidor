using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * UNED III Cuatrimestre
 * Proyecto: Sistema para Tienda Deportiva
 * Estudiante: Jesús Garita Obando
 * Cédula: 303870610
 * Fecha: 30/11/2024
 * 
 * Fuentes Externas y Asistencia
 * El código del proyecto fue desarrollado principalmente por el autor, con ayuda de:
 * La tutoría de la UNED https://www.youtube.com/watch?v=2ZOUapJjgpg y 
 * ChatGPT de OpenAI para sugerencias en la validación y mejora del diseño.
 * GitHub para el control de versiones
*/

public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    // Constructor vacío
    public Categoria() { }

    // Constructor que acepta parámetros
    public Categoria(int idCategoria, string nombre, string descripcion)
    {
        IdCategoria = idCategoria;
        Nombre = nombre;
        Descripcion = descripcion;
    }
}
