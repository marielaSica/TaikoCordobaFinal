using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaikoCordobaFinal.Entities
{
    public class Pago
    {
        public int Id { get; set; }

        public Integrante Integrante { get; set; }

        public int Monto { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        public int TalonPago { get; set; }

        public string Comentarios { get; set; }

        public int TotalPagos { get; set; }

    }

}