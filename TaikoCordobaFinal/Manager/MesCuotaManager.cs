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
    public class MesCuotaManager: BaseManager
    {

        private static List<MesCuota> mescuota = new List<MesCuota>
        {
            new MesCuota
            {   Id = 0,
                Integrante = new Integrante {Id = 1, Nombre = "Bren"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 2

            },

            new MesCuota
            {   Id = 1,
                Integrante = new Integrante {Id = 2, Nombre = "Cris" },
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 3

            },

            new MesCuota
            {  Id = 2,
               Integrante = new Integrante {Id = 3, Nombre = "Juli"},
               Monto = 400,
               Fecha = DateTime.Now,
               Mes = DateTime.Now.AddMonths(3),
               TalonPago = 4

            },

            new MesCuota
            {
               Id = 3,
               Integrante = new Integrante {Id = 4, Nombre = "Yami"},
               Monto = 400,
               Fecha = DateTime.Now,
               Mes = DateTime.Now.AddMonths(3),
               TalonPago = 5

            },

            new MesCuota
            {
                  Id = 4,
                  Integrante = new Integrante {Id = 5, Nombre = "Mica", },
                  Monto = 400,
                  Fecha = DateTime.Now,
                  Mes = DateTime.Now.AddMonths(3),
                  TalonPago = 6

            },

            new MesCuota
            {   Id = 5,
                Integrante = new Integrante {Id = 6, Nombre = "Ailin"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 7

            },

            new MesCuota
            {   Id = 6,
                Integrante = new Integrante {Id = 7, Nombre = "Leila"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 8

            },

            new MesCuota
            {   Id = 7,
                Integrante = new Integrante {Id = 8, Nombre = "Nadu"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 9

            },

            new MesCuota
            {   Id = 8,
                Integrante = new Integrante {Id = 9, Nombre = "Ari"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 10

            },

            new MesCuota
            {   Id = 9,
                Integrante = new Integrante {Id = 10, Nombre = "Ivan"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 11

            },

            new MesCuota
            {   Id = 10,
                Integrante = new Integrante {Id = 11, Nombre = "Mirta"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 12

            },

            new MesCuota
            {   Id = 11,
                Integrante = new Integrante {Id = 12, Nombre = "Maia"},
                Monto = 400,
                Fecha = DateTime.Now,
                Mes = DateTime.Now.AddMonths(3),
                TalonPago = 13

            },

        };

        public static List<MesCuota> GetMesCuotaMuestra()
        {
            return mescuota;
        }

        public static MesCuota GetById(int idEvento)
        {
            return mescuota.Where(p => p.Id.Equals(idEvento)).SingleOrDefault();
        }


        public static void NuevoMes(MesCuota mescuotas)
        {
            mescuotas.Id = mescuota.Count() + 1;
            //aca lo debería guardar en BD..
            mescuota.Add(mescuotas);
        }


        public static void EditarMes(MesCuota mescuotas)
        {
            //a fines de simulacion, lo borro y lo agrego..
            var p = GetById(mescuotas.Id);
            p = mescuotas;
        }

    }
}