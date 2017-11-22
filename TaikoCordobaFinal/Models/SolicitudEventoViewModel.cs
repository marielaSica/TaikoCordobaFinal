using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaikoCordobaFinal.Models
{
    public class SolicitudEventoViewModel
    {
        [Required]
        [Display(Name = "Nombre de la persona o entidad solicitante")]
        public string NombreSolicitante { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        public string TelefonoSolicitante { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string EmailSolicitante { get; set; }

        [Display(Name = "Nombre o motivo del evento")]
        [Required]
        public string MotivoNombre { get; set; }

        [Display(Name = "Fecha y hora del evento")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaHora { get; set; }

        [Required]
        public string Lugar { get; set; }

        [Display(Name = "Duración")]
        public string Duracion { get; set; }

        public string Dimensiones { get; set; }
        [Display(Name = "Fecha límite de confirmación")]

        [DataType(DataType.Date)]
        public DateTime FechaLimite { get; set; }

       
        [DataType(DataType.MultilineText)]
        public string Comentarios { get; set; }
    }
}