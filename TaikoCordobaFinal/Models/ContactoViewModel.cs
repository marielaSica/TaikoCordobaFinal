using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaikoCordobaFinal.Models
{
    public class ContactoViewModel
    {
       
        public string Nombre { get; set; }
              
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Mensaje { get; set; }
    }
}