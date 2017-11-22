using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Utilities;

namespace TaikoCordobaFinal.Manager

{
    public class AdminManager
    {

        /// <summary>
        /// Retorna un usuario a partir de un E-mail.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static Admin GetByEmail(string email)
        {
            Admin admin = null;

            //creo una conexion con la base de datos.
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[Strings.KeyConnectionStringTaikoCordoba].ToString()))
            {
                //abro la conexion
                con.Open();

                //Preparo la consulta a realizar.
                var query = new SqlCommand("SELECT * FROM Administrador WHERE Email = @email", con);
                //Seteo los parametros
                query.Parameters.AddWithValue("@email", email);

                //creo un lector
                using (var dr = query.ExecuteReader())
                {
                    //le digo al lector que lea la 1er fila
                    dr.Read();
                    if (dr.HasRows) //Si hay fila..
                    {
                        //Mapeo la fila con la entidad.
                        admin = MapearUsuario(dr);
                    }
                }
            }

            return admin;
        }
        /// <summary>
        /// Este metodo retorna el usuario (clase Entity) que coincide con el email y password. Caso contrario retorna null.
        /// </summary>
        /// <param name="email">email del usuario</param>
        /// <param name="password">password del usuario</param>
        /// <returns>Usuario o null</returns>
        public static Admin Login(string email, string password)
        {
            Admin admin = GetByEmail(email);
            string passwordEncriptada = Strings.Encriptar(password);
            if (admin != null && admin.Contraseña == passwordEncriptada)
            {
                return admin;
            }
            return null;
        }

        private static Admin MapearUsuario(SqlDataReader dr)
        {
            var admin = new Admin
            {
                Id = Convert.ToInt32(dr["Id"]),
                Nombre = dr["Nombre"].ToString(),
                Apellido = dr["Apellido"].ToString(),
                Email = dr["Email"].ToString(),
                Contraseña = dr["Contraseña"].ToString(),
                
            };
            return admin;
        }
       

    }



}
