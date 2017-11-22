using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Entities;


namespace TaikoCordobaFinal.Areas.Admin.Models
{
    public class EventoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreSolicitante { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        public string TelefonoSolicitante { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string EmailSolicitante { get; set; }

        [Display(Name = "Motivo o nombre del evento")]
        public string MotivoNombre { get; set; }

        [Display(Name = "Fecha del evento")]
        [Required]
        [DataType(DataType.Date)]
        public string Fecha { get; set; }

        [Display(Name = "Hora del evento")]
        [Required]
        [DataType(DataType.Time)]
        public string Hora { get; set; }

        [Required]
        public string Lugar { get; set; }

        [Display(Name = "Duración")]
        public string Duracion { get; set; }

        public string Dimensiones { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; }

        [DataType(DataType.MultilineText)]
        public string Transporte { get; set; }
        
        [Display(Name = "Evento facebook")]
        public string LinkFacebook { get; set; }

      

    }
}