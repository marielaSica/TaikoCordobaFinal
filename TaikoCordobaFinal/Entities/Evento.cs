using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaikoCordobaFinal.Entities
{
    public class Evento
    {
        public int Id { get; set; }

        [DisplayName("Solicitante")]
        public string NombreSolicitante { get; set; }

        [DisplayName("Teléfono")]
        public string TelefonoSolicitante { get; set; }

        [DisplayName("Email")]
        public string EmailSolicitante { get; set; }

        [DisplayName("Nombre evento")]
        public string MotivoNombre { get; set; } //nulleable

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        public string Lugar { get; set; }

        [DisplayName("Duración")]
        public string Duracion { get; set; } //nulleable

        public string Dimensiones { get; set; }  //nulleable

        public string Comentarios { get; set; } //nulleable

        public string Transporte { get; set; }  //nulleable

        [DisplayName("Link Facebook")]
        public string LinkFacebook { get; set; }  //nulleable

    }
}