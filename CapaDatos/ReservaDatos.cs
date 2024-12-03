using CapaDatos.Interfaces;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ReservaDatos : IReservaRepository
    {
        private readonly IConexion conexion;

        public ReservaDatos(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public List<Reserva> ObtenerReservas()
        {
            var reservas = new List<Reserva>();

            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT R.id, R.id_sucursal, R.id_articulo, R.id_cliente, R.fec_reserva, " +
                               "A.descripcion AS articulo, S.nombre AS sucursal, C.nombre AS cliente " +
                               "FROM Reserva R " +
                               "INNER JOIN ArticuloxSucursal AS AXS ON R.id_sucursal = AXS.id_sucursal AND R.id_articulo = AXS.id_articulo " +
                               "INNER JOIN Articulo A ON A.id = R.id_articulo " +
                               "INNER JOIN Sucursal S ON S.id = R.id_sucursal " +
                               "INNER JOIN Cliente C ON C.identificacion = R.id_cliente";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var reserva = new Reserva
                            {
                                IdReserva = Convert.ToInt32(reader["id"]),
                                ArticuloSucursal = new ArticuloSucursal
                                {
                                    Sucursal = new Sucursal
                                    {
                                        IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                                        Nombre = reader["sucursal"].ToString()
                                    },
                                    Articulo = new Articulo
                                    {
                                        Id = Convert.ToInt32(reader["id_articulo"]),
                                        Descripcion = reader["articulo"].ToString()
                                    },
                                    Cantidad = 0 // La cantidad podría obtenerse de alguna otra fuente si es necesario
                                },
                                Cliente = new Cliente
                                {
                                    Identificacion = Convert.ToInt32(reader["id_cliente"]),
                                    Nombre = reader["cliente"].ToString()
                                },
                                FechaReserva = Convert.ToDateTime(reader["fec_reserva"])
                            };

                            reservas.Add(reserva);
                        }
                    }
                }
            }

            return reservas;
        }

        public Reserva ObtenerReservaPorId(int idReserva)
        {
            Reserva reserva = null;

            using (var conn = conexion.GetConnection())
            {
                // Bloqueo de la fila con UPDLOCK para evitar actualizaciones concurrentes
                string query = "SELECT R.id, R.id_sucursal, R.id_articulo, R.id_cliente, R.fec_reserva, " +
                               "A.descripcion AS articulo, S.nombre AS sucursal, C.nombre AS cliente " +
                               "FROM Reserva R " +
                               "INNER JOIN ArticuloxSucursal AS AXS ON R.id_sucursal = AXS.id_sucursal AND R.id_articulo = AXS.id_articulo " +
                               "INNER JOIN Articulo A ON A.id = R.id_articulo " +
                               "INNER JOIN Sucursal S ON S.id = R.id_sucursal " +
                               "INNER JOIN Cliente C ON C.identificacion = R.id_cliente " +
                               "WHERE R.id = @idReserva " +
                               "FOR UPDATE";  // Esto bloquea la fila para evitar que otros procesos la actualicen

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reserva = new Reserva
                            {
                                IdReserva = Convert.ToInt32(reader["id"]),
                                ArticuloSucursal = new ArticuloSucursal
                                {
                                    Sucursal = new Sucursal
                                    {
                                        IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                                        Nombre = reader["sucursal"].ToString()
                                    },
                                    Articulo = new Articulo
                                    {
                                        Id = Convert.ToInt32(reader["id_articulo"]),
                                        Descripcion = reader["articulo"].ToString()
                                    },
                                    Cantidad = 0 // Ajustar la cantidad según sea necesario
                                },
                                Cliente = new Cliente
                                {
                                    Identificacion = Convert.ToInt32(reader["id_cliente"]),
                                    Nombre = reader["cliente"].ToString()
                                },
                                FechaReserva = Convert.ToDateTime(reader["fec_reserva"])
                            };
                        }
                    }
                }
            }

            return reserva;
        }

        public void AgregarReserva(Reserva reserva)
        {
            using (var conn = conexion.GetConnection())
            {
                // Bloqueo en la transacción de inserción para evitar que otros procesos la modifiquen
                string query = "INSERT INTO Reserva (id_sucursal, id_articulo, id_cliente, fec_reserva) " +
                               "VALUES (@id_sucursal, @id_articulo, @id_cliente, @fec_reserva)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_sucursal", reserva.ArticuloSucursal.Sucursal.IdSucursal);
                    cmd.Parameters.AddWithValue("@id_articulo", reserva.ArticuloSucursal.Articulo.Id);
                    cmd.Parameters.AddWithValue("@id_cliente", reserva.Cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@fec_reserva", reserva.FechaReserva);

                    // Implementación de transacción con BEGIN TRANSACTION y COMMIT
                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void ActualizarReserva(Reserva reserva)
        {
            using (var conn = conexion.GetConnection())
            {
                // Bloqueo en la transacción de actualización para evitar que otros procesos la modifiquen
                string query = "UPDATE Reserva SET id_sucursal = @id_sucursal, id_articulo = @id_articulo, " +
                               "id_cliente = @id_cliente, fec_reserva = @fec_reserva WHERE id = @idReserva";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", reserva.IdReserva);
                    cmd.Parameters.AddWithValue("@id_sucursal", reserva.ArticuloSucursal.Sucursal.IdSucursal);
                    cmd.Parameters.AddWithValue("@id_articulo", reserva.ArticuloSucursal.Articulo.Id);
                    cmd.Parameters.AddWithValue("@id_cliente", reserva.Cliente.Identificacion);
                    cmd.Parameters.AddWithValue("@fec_reserva", reserva.FechaReserva);

                    // Implementación de transacción con BEGIN TRANSACTION y COMMIT
                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    try
                    {
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Existe(int idReserva)
        {
            using (var conn = conexion.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Reserva WHERE id = @idReserva";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReserva", idReserva);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}
