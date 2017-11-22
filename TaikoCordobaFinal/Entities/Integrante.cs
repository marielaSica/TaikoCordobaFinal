using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaikoCordobaFinal.Entities
{
    public class Integrante
    {
        //public enum EConfirmado
        //{
        //    [Display(Name = "Confirmado")]
        //    Confirmado,
        //    [Display(Name = "No Confirmado")]
        //    NoConfirmado,

        //}
        public int Id { get; set; }

        [DisplayName("Imagen")]
        public string ImagenUri { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [DisplayName("Teléfono de emergencia")]
        public string TelefonoEmergencia { get; set; }

        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        public Estado Estado { get; set; }

        //public EConfirmado Confirmado { get; set; }
        



    }
}