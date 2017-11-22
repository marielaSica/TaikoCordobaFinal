using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Models;


namespace TaikoCordobaFinal.Controllers
{
    public class InscripcionController : Controller
    {
        // GET: Inscripcion
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(InscripcionViewModel model)
        {
            //verifico, si subio imagen, que la imagen sea jpg
            if (model.Imagen != null && !model.Imagen.ContentType.Equals("image/jpeg"))
            {
                ModelState.AddModelError("Imagen", "La imagen debe ser jpg.");
            }


            if (ModelState.IsValid)
            {
                var body = "<p>Solicitud de inscripcion de: {0} {1}, Email: {2}</p>" +
                    "<p>Datos del Inscripto:</p>" +
                    "<p>Nombre: {0}</p>" +
                    "<p>Apellido: {1}</p>" +
                    "<p>Email: {2}</p>" +
                    "<p>Teléfono: {3}</p>" +
                    "<p>Teléfono de Emergencia: {4}</p>" +
                    "<p>Dirección: {5}</p>";

                var message = new MailMessage();
                message.To.Add(new MailAddress("taikocordoba@gmail.com"));
                message.Subject = "Nueva Inscripcion";
                message.Body = string.Format(body, model.Nombre, model.Apellido, model.Email, model.Telefono, model.TelefonoEmergencia, model.Direccion);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);

                }


            }

            string imageUri = "";
            if (model.Imagen != null)
            {
                var uploadDir = "~/Uploads/integrantes";
                var imagePath = Path.Combine(Server.MapPath(uploadDir), model.Imagen.FileName);
                model.Imagen.SaveAs(imagePath);
                imageUri = string.Format("{0}/{1}", uploadDir, model.Imagen.FileName);
            }
            //Creo mi entidad a partir del ViewModel.
            Integrante integrantes = new Integrante
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Email = model.Email,
                Telefono = model.Telefono,
                TelefonoEmergencia = model.TelefonoEmergencia,
                Direccion = model.Direccion,
                Estado = new Estado { Id = 3 },


            };

            //le paso la entidad. NUNCA se pasa un viewModel (Los viewModel son para las vistas!!!)
            IntegrantesManager.NuevoIntegrante(integrantes);


            return View("GraciasInscripcion");
        }


    }
}