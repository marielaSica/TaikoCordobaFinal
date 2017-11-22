using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Entities;

namespace TaikoCordobaFinal.Areas.Admin.Models
{
    public class MesCuotaViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Integrante Integrante { get; set; }

        [Required]
        public int Monto { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM}")]
        public DateTime Mes { get; set; }


        public int TalonPago { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; }


    }
}