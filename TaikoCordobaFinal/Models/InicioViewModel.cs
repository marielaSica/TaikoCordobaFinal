using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Models;

namespace TaikoCordobaFinal.Models
{
    public class InicioViewModel
    {
        public List<Evento> DatosEvento { get; set; }
        public ContactoViewModel Contacto { get; set; }
    }
}