using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Utilities;

namespace TaikoCordobaFinal.Manager
{
    public class EventoManager : BaseManager
    {
        #region Consultas

        public static List<Evento> GetProximosEventos()
        {
            var eventos = new List<Evento>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT TOP 4 * FROM Evento WHERE Fecha > GETDATE() ORDER BY Fecha ASC;", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var evento = MapearEventoParcial(dr);
                        eventos.Add(evento);
                    }
                }
            }

            return eventos;
        }

        public static List<Evento> ArchivoEventos()
        {
            var eventos = new List<Evento>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Evento WHERE Fecha < GETDATE() ORDER BY Fecha ASC;", con);
                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var evento = MapearEventoParcial(dr);
                        eventos.Add(evento);
                    }
                }
            }

            return eventos;
        }

        /// <summary>
        /// RETORNA UN EVENTO POR SU ID
        /// </summary>
        /// <param name="idEvento"></param>
        /// <returns></returns>
        public static Evento GetById(int idEvento)
        {
            Evento evento = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("SELECT * FROM Evento WHERE Id = @id", con);


                query.Parameters.AddWithValue("@id", idEvento);

                using (var dr = query.ExecuteReader())
                {
                    dr.Read();
                    if (dr.HasRows)
                    {
                        evento = MapearEventoTodo(dr);
                    }
                }
            }

            return evento;
        }

        #endregion

        #region ABMs
        /// <summary>
        /// agrega un evento 
        /// </summary>
        /// <param name="evento"></param>
        public static void NuevoEvento(Evento evento)
        {
            
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                //recupero ID autoincremental con SCOPE IDENTITY
                var query = new SqlCommand("INSERT INTO Evento (NombreSolicitante, TelefonoSolicitante, EMailSolicitante, MotivoNombre, Fecha, Lugar, Duracion, Dimensiones, Comentarios, Transporte, LinkFacebook ) VALUES (@NombreSolicitante, @TelefonoSolicitante, @EMailSolicitante, @MotivoNombre, @Fecha, @Lugar, @Duracion, @Dimensiones, @Comentarios, @Transporte, @LinkFacebook)", con);

                query.Parameters.AddWithValue("@NombreSolicitante", evento.NombreSolicitante);
                query.Parameters.AddWithValue("@TelefonoSolicitante", evento.TelefonoSolicitante);
                query.Parameters.AddWithValue("@EMailSolicitante", evento.EmailSolicitante);
                query.Parameters.AddWithValue("@MotivoNombre", evento.MotivoNombre);
                query.Parameters.AddWithValue("@Fecha", evento.Fecha);
                query.Parameters.AddWithValue("@Lugar", evento.Lugar);
                query.Parameters.AddWithValue("@Duracion", evento.Duracion);
                query.Parameters.AddWithValue("@Dimensiones", evento.Dimensiones);
                query.Parameters.AddWithValue("@Comentarios", evento.Comentarios);
                query.Parameters.AddWithValue("@Transporte", evento.Transporte);
                query.Parameters.AddWithValue("@LinkFacebook", evento.LinkFacebook);

                query.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Editar evento 
        /// </summary>
        /// <param name="evento"></param>
        public static void EditarEvento(Evento evento)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                //recordar que borre de la consulta las listas
                var query = new SqlCommand("UPDATE Evento set NombreSolicitante = @NombreSolicitante, TelefonoSolicitante = @TelefonoSolicitante, EMailSolicitante = @EMailSolicitante, MotivoNombre = @MotivoNombre, Fecha = @Fecha, Lugar = @Lugar, Duracion = @Duracion, Dimensiones = @Dimensiones, Comentarios = @Comentarios, Transporte = @Transporte, LinkFacebook = @LinkFacebook WHERE Id = @id", con);

                query.Parameters.AddWithValue("@Id", evento.Id);
                query.Parameters.AddWithValue("@NombreSolicitante", evento.NombreSolicitante);
                query.Parameters.AddWithValue("@TelefonoSolicitante", evento.TelefonoSolicitante);
                query.Parameters.AddWithValue("@EmailSolicitante", evento.EmailSolicitante);
                query.Parameters.AddWithValue("@MotivoNombre", evento.MotivoNombre);
                query.Parameters.AddWithValue("@Fecha", evento.Fecha);
                query.Parameters.AddWithValue("@Lugar", evento.Lugar);
                query.Parameters.AddWithValue("@Duracion", evento.Duracion);
                query.Parameters.AddWithValue("@Dimensiones", evento.Dimensiones);
                query.Parameters.AddWithValue("@Comentarios", evento.Comentarios);
                query.Parameters.AddWithValue("@Transporte", evento.Transporte);
                query.Parameters.AddWithValue("@LinkFacebook", evento.LinkFacebook);

                query.ExecuteNonQuery();

            }
        }



        /// <summary>
        /// Borra un evento
        /// </summary>
        /// <param name="idEvento"></param>
        public static void BorrarEvento(int idEvento)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                var query = new SqlCommand("DELETE FROM Evento WHERE Id = @id", con);
                query.Parameters.AddWithValue("@id", idEvento);
                query.ExecuteNonQuery();
            }
        }

        #endregion

        #region Mapeo
        private static Evento MapearEventoTodo(SqlDataReader dr)
        {
            var evento = new Evento
            {
                Id = Convert.ToInt32(dr["Id"]),
                NombreSolicitante = dr["NombreSolicitante"].ToString(),
                TelefonoSolicitante = dr["TelefonoSolicitante"].ToString(),
                EmailSolicitante = dr["EMailSolicitante"].ToString(),
                MotivoNombre = dr["MotivoNombre"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                Lugar = dr["Lugar"].ToString(),
                Duracion = dr["Duracion"].ToString(),
                Dimensiones = dr["Dimensiones"].ToString(),
                Comentarios = dr["Comentarios"].ToString(),
                Transporte = dr["EMailSolicitante"].ToString(),
                LinkFacebook = dr["LinkFacebook"].ToString(),

            };
            return evento;
        }

        private static Evento MapearEventoParcial(SqlDataReader dr)
        {
            var evento = new Evento
            {
                Id = Convert.ToInt32(dr["Id"]),
                NombreSolicitante = dr["NombreSolicitante"].ToString(),
                MotivoNombre = dr["MotivoNombre"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                Lugar = dr["Lugar"].ToString()

            };
            return evento;
        }
    }
}

#endregion