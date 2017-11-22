using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Utilities;
using static TaikoCordobaFinal.Entities.Integrante;

namespace TaikoCordobaFinal.Manager
{
    public class IntegrantesManager: BaseManager
    {
        #region Consultas
        /// <summary>
        /// Obtiene los estados de los integrantes 
        /// </summary>
        /// <returns></returns>
        public static List<Estado> GetEstados()
        {
            var estados = new List<Estado>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Estado order by Nombre", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var estado = new Estado
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Nombre = dr["Nombre"].ToString()
                        };
                        estados.Add(estado);
                    }
                }
            }

            return estados;
        }

        public static List<Integrante> GetPorEstado(int estadoId)
        {
            var estados = new List<Integrante>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"select i.*, e.Nombre as NombreEstado
                                            from Integrante i inner join Estado e on (i.EstadoId = e.Id)
                                            where i.EstadoId = @estado
                                            order by i.Nombre", con);
                query.Parameters.AddWithValue("@estado", estadoId);

                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var estado = MapearIntegranteParcial(dr);
                        estados.Add(estado);
                    }
                }
            }

            return estados;
        }

        /// <summary>
        /// Retorna todos los integrantes ordenados por nombre mostrando solo imagen, nombre e Email
        /// </summary>
        /// <returns></returns>
        public static List<Integrante> GetIntegrantes()
        {
            var integrantes = new List<Integrante>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"select i.*, e.Nombre as NombreEstado
                                            from Integrante i inner join Estado e on (i.EstadoId = e.Id)
                                            order by i.Nombre", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var integrante = MapearIntegranteParcial(dr);
                        integrantes.Add(integrante);
                    }
                }
            }

            return integrantes;
        }

        /// <summary>
        /// Obtiene un integrante a partir de su Id.
        /// </summary>
        /// <param name="idIntegrante"></param>
        /// <returns></returns>
        public static Integrante GetById(int idIntegrante)
        {
            Integrante integrante = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"select i.*, e.Nombre as NombreEstado
                                            from Integrante i inner join Estado e on (i.EstadoId = e.Id)
                                           WHERE i.Id = @id", con);
                query.Parameters.AddWithValue("@id", idIntegrante);

                using (var dr = query.ExecuteReader())
                {
                    dr.Read();
                    if (dr.HasRows)
                    {
                        integrante = MapearIntegranteTodo(dr);
                    }
                }
            }

            return integrante;
        }
        #endregion

        #region ABMs
        /// <summary>
        /// Crea un nuevo plato en la BD.
        /// </summary>
        /// <param name="plato"></param>
        public static void NuevoIntegrante(Integrante integrante)
        {
            if (integrante.ImagenUri == null)
            {
                integrante.ImagenUri = "";
            }
           
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("INSERT INTO Integrante (ImagenUri, Nombre, Apellido, Email, Telefono, TelefonoEmergencia, Direccion, EstadoId ) VALUES (@ImagenUri, @Nombre, @Apellido,  @Email, @Telefono, @TelefonoEmergencia, @Direccion, @Estado )", con);

                query.Parameters.AddWithValue("@ImagenUri", integrante.ImagenUri);
                query.Parameters.AddWithValue("@Nombre", integrante.Nombre);
                query.Parameters.AddWithValue("@Apellido", integrante.Apellido);
                query.Parameters.AddWithValue("@Email", integrante.Email);
                query.Parameters.AddWithValue("@Telefono", integrante.Telefono);
                query.Parameters.AddWithValue("@TelefonoEmergencia", integrante.TelefonoEmergencia);
                query.Parameters.AddWithValue("@Direccion", integrante.Direccion);
                query.Parameters.AddWithValue("@Estado", integrante.Estado.Id);

                query.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edita un integrante 
        /// </summary>
        /// <param name="integrante"></param>
        public static void EditarIntegrante(Integrante integrante)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Integrante set ImagenUri= @ImagenUri, Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, TelefonoEmergencia = @TelefonoEmergencia, Direccion = @Direccion, EstadoId = @estado WHERE Id = @id", con);

                query.Parameters.AddWithValue("@Id", integrante.Id);
                query.Parameters.AddWithValue("@ImagenUri", integrante.ImagenUri);
                query.Parameters.AddWithValue("@Nombre", integrante.Nombre);
                query.Parameters.AddWithValue("@Apellido", integrante.Apellido);
                query.Parameters.AddWithValue("@Email", integrante.Email);
                query.Parameters.AddWithValue("@Telefono", integrante.Telefono);
                query.Parameters.AddWithValue("@TelefonoEmergencia", integrante.TelefonoEmergencia);
                query.Parameters.AddWithValue("@Direccion", integrante.Direccion);
                query.Parameters.AddWithValue("@estado", integrante.Estado.Id);

                query.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Borra un integrante
        /// </summary>
        /// <param name="idIntegrante"></param>
        public static void BorrarIntegrante(int idIntegrante)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                var query = new SqlCommand("DELETE FROM Integrante WHERE Id = @id", con);
                query.Parameters.AddWithValue("@id", idIntegrante);
                query.ExecuteNonQuery();
            }
        }

        #endregion


        private static Integrante MapearIntegranteParcial(SqlDataReader dr)
        {
            var integrante = new Integrante
            {
                Id = Convert.ToInt32(dr["Id"].ToString()),
                ImagenUri = dr["ImagenUri"].ToString(),
                Nombre = dr["Nombre"].ToString(),
                Email = dr["Email"].ToString(),
                Estado = new Estado
                {
                    Id = Convert.ToInt32(dr["EstadoId"]),
                    Nombre = ColumnExists(dr, "NombreEstado") ? dr["NombreEstado"].ToString() : string.Empty
                },

            };
            return integrante;
        }

        private static Integrante MapearIntegranteTodo(SqlDataReader dr)
        {
            var integrante = new Integrante
            {
                Id = Convert.ToInt32(dr["Id"]),
                ImagenUri = dr["ImagenUri"].ToString(),
                Nombre = dr["Nombre"].ToString(),
                Apellido = dr["Apellido"].ToString(),
                Email = dr["Email"].ToString(),
                Telefono = dr["Telefono"].ToString(),
                TelefonoEmergencia = dr["TelefonoEmergencia"].ToString(),
                Direccion = dr["Direccion"].ToString(),
                Estado = new Estado
                {
                    Id = Convert.ToInt32(dr["EstadoId"]),
                    Nombre = ColumnExists(dr, "NombreEstado") ? dr["NombreEstado"].ToString() : string.Empty
                },

            };
            return integrante;
        }
    }
}