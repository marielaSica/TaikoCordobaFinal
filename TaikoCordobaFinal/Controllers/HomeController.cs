using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Models;

namespace TaikoCordobaFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InicioViewModel model = new InicioViewModel
            {
                Contacto = new ContactoViewModel(),
                DatosEvento = EventoManager.GetProximosEventos()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(InicioViewModel model)
        {

            if (ModelState.IsValid)
            {
                var body = "<p>Consulta de: {0} , email: {1} </p>" + "<p>Mensaje:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("taikocordoba@gmail.com"));
                message.Subject = "Consulta";
                message.Body = string.Format(body, model.Contacto.Nombre, model.Contacto.Email, model.Contacto.Mensaje);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("GraciasContacto");
                }
                
            }
            else
            {
                InicioViewModel modelInicio = new InicioViewModel
                {
                    Contacto = new ContactoViewModel(),
                    DatosEvento = EventoManager.GetProximosEventos()
                };

                return View(modelInicio);


            }

        }

        public ActionResult GraciasContacto()
        {
            ViewBag.Message = "Gracias";

            return View();
        }

    }
}