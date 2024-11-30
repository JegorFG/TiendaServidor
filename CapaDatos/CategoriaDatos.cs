using CapaDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    // Implementa los métodos de la interfaz ICategoriaRepository para interactuar con la tabla Categoria.
    public class CategoriaDatos : ICategoriaRepository
    {
        private readonly IConexion conexion;

        // Constructor para inicializar la conexión.
        public CategoriaDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        // Obtiene todas las categorías de la base de datos.
        public List<Categoria> ObtenerCategorias()
        {
            var categorias = new List<Categoria>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM Categoria";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crea un objeto Categoria y lo agrega a la lista.
                            categorias.Add(new Categoria
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString()
                            });
                        }
                    }
                }
            }
            return categorias;
        }

        // Obtiene una categoría específica por su ID.
        public Categoria ObtenerCategoriaPorId(int id)
        {
            Categoria categoria = null;

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT * FROM Categoria WHERE id = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crea un objeto Categoria con los datos obtenidos.
                            categoria = new Categoria
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString()
                            };
                        }
                    }
                }
            }
            return categoria;
        }

        // Agrega una nueva categoría a la base de datos.
        public void AgregarCategoria(Categoria categoria)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "INSERT INTO Categoria (id, nombre, descripcion) " +
                               "VALUES (@id, @nombre, @descripcion)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    // Asigna los valores de los parámetros.
                    cmd.Parameters.AddWithValue("@id", categoria.Id);
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

                    // Ejecuta el comando para insertar la categoría.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Verifica si una categoría existe en la base de datos.
        public bool Existe(int id)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Categoria WHERE id = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    // Ejecuta el comando y verifica si el resultado es mayor a 0.
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}

