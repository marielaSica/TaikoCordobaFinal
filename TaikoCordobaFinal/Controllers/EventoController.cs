using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Models;

namespace TaikoCordobaFinal.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(SolicitudEventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Solicitud de evento de: {0} Email: {1} Tel: {2} </p>" +
                    "<p>Datos del evento solicitado:</p>" +
                    "<p>Motivo: {3}</p>" +
                    "<p>Fecha y hora: {4}</p>" +
                    "<p>Lugar: {5}</p>" +
                    "<p>Duración: {6}</p>" +
                    "<p>Dimensiones: {7}</p>" +
                    "<p>FechaLimite: {8}</p>" +
                    "<p>Comentarios: {9}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("taikocordoba@gmail.com"));
                message.Subject = "Solicitud de evento";
                message.Body = string.Format(body, model.NombreSolicitante, model.EmailSolicitante, model.TelefonoSolicitante, model.MotivoNombre, model.FechaHora, model.Lugar, model.Duracion, model.Dimensiones, model.FechaLimite, model.Comentarios);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("GraciasEvento");
                }
            }
            return View(model);
        }

        public ActionResult GraciasEvento()
        {
            ViewBag.Message = "Gracias";

            return View();
        }

    }
}