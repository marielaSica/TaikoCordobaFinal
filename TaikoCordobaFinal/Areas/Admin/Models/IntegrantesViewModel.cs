﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static TaikoCordobaFinal.Entities.Integrante;

namespace TaikoCordobaFinal.Areas.Admin.Models
{
    public class IntegrantesViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Imagen JPG")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Imagen { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string ImagenUri { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Phone]
        [Display(Name = "Teléfono de emergencia")]
        public string TelefonoEmergencia { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        //[Display(Name = "Integrante Confirmado")]
        //[Required]
        //public EConfirmado? Confirmado { get; set; }

        [Display(Name = "Estado")]
        public int EstadoId { get; set; }
        public IEnumerable<SelectListItem> Estados { get; set; }

    }
}