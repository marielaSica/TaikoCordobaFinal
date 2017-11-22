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
    public class PagoManager : BaseManager
    {

        public static List<Pago> GetPorMescuota(int pagoId)
        {
            var pagos = new List<Pago>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT Año, Mes , Total 
                                            FROM MesCuota_Pago mcp 
                                            inner join MesCuota mc ON mcp.MesCuotaId = mc.Id  
                                            WHERE mcp.PagoId = @pago ", con);
                query.Parameters.AddWithValue("@pedido", pagoId);

                using (var dr = query.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var pago = MapearPago(dr);
                        pagos.Add(pago);
                    }
                }
            }

            return pagos;
        }


        public static void NuevoPago(Pago pago)
        {
            //seteo la cantidad de platos al pedido.
            //mescuota.Total = mescuota.Monto.Sum(p => mc.Total);
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                
                var query = new SqlCommand("INSERT INTO Pago (Monto , Fecha , Mes, TalonPago, Comentarios, IntegranteId) VALUES (@monto , @fecha , @mes, @talonPago, @comentarios, @integranteId)", con);

                query.Parameters.AddWithValue("@monto", pago.Monto);
                query.Parameters.AddWithValue("@fecha", pago.Fecha);
                query.Parameters.AddWithValue("@talonPago", pago.TalonPago);
                query.Parameters.AddWithValue("@comentarios", pago.Comentarios);
                query.Parameters.AddWithValue("@clienteId", pago.Integrante.Id);

                query.ExecuteNonQuery();
    
            }

        }

        public static void EditarPago(Pago pago)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand("UPDATE Pago set Monto = @monto, Fecha = @fecha,  TalonPago = @talonPago, Comentarios = @comentarios, IntegranteId = @integranteId WHERE Id = @id", con);

                query.Parameters.AddWithValue("@id", pago.Id);
                query.Parameters.AddWithValue("@monto", pago.Monto);
                query.Parameters.AddWithValue("@fecha", pago.Fecha);
                query.Parameters.AddWithValue("@talonPago", pago.TalonPago);
                query.Parameters.AddWithValue("@comentarios", pago.Comentarios);
                query.Parameters.AddWithValue("@integranteId", pago.Integrante.Id);
                query.ExecuteNonQuery();
                
            }
        }

        /// <summary>
        /// Borra un pago
        /// </summary>
        /// <param name="idPago"></param>
        public static void BorrarPago(int idPago)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();
                var query = new SqlCommand("DELETE FROM Pago WHERE Id = @id", con);
                query.Parameters.AddWithValue("@id", idPago);
                query.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retorna un pedido junto con la info del cliente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Pago GetById(int id)
        {
            Pago pago = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                con.Open();

                var query = new SqlCommand(@"SELECT p.*, i.Nombre AS NombreIntegrante 
                                             FROM Pago p inner join Integrante i ON p.IntegranteId = i.Id WHERE p.Id = @id", con);
                query.Parameters.AddWithValue("@id", id);

                using (var dr = query.ExecuteReader())
                {
                    dr.Read();
                    if (dr.HasRows)
                    {
                        pago = MapearPago(dr);
                    }
                }
            }

            return pago;
        }

       
        /// <summary>
        /// mapeo del mes de facturacion 
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static Pago MapearPago(SqlDataReader dr)
        {
            var pagos = new Pago
            {
                Id = Convert.ToInt32(dr["Id"]),
                Monto = Convert.ToInt32(dr["Monto"]),
                TalonPago = Convert.ToInt32(dr["TalonPago"]),
                Comentarios = dr["Comentarios"].ToString(),
                Fecha = Convert.ToDateTime(dr["Fecha"].ToString()),
                Integrante = new Integrante
                {
                    Id = Convert.ToInt32(dr["IntegranteId"]),
                    Nombre = dr["NombreIntegrante"].ToString(),
                   
                }

            };
            return pagos;
        }
    }
}









