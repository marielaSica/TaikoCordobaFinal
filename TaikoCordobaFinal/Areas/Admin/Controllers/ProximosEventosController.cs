using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Areas.Admin.Models;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Utilities;

namespace TaikoCordobaFinal.Areas.Admin.Controllers
{
    public class ProximosEventosController : AdminBaseController
    {
        // GET: Admin/Admin
        public ActionResult ProximosEventos()
        {

            return View(EventoManager.GetProximosEventos());
        }

        public ActionResult ArchivoEventos()
        {

            return View(EventoManager.ArchivoEventos());
        }

        public ActionResult DetalleEventos(int id)
        {
            Evento evento = EventoManager.GetById(id);
            return View(evento);
        }

        public ActionResult DetalleEventosArchivo(int id)
        {
            Evento evento = EventoManager.GetById(id);
            return View(evento);
        }

        public ActionResult NuevoEvento()
        {
            EventoViewModel model = new EventoViewModel
            {

            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoEvento(EventoViewModel model)
        {
            if (ModelState.IsValid)
            {

                Evento evento = new Evento
                {
                    NombreSolicitante = model.NombreSolicitante,
                    TelefonoSolicitante = model.TelefonoSolicitante,
                    EmailSolicitante = model.EmailSolicitante,
                    MotivoNombre = model.MotivoNombre,
                    Fecha = Convert.ToDateTime(model.Fecha + " " + model.Hora),
                    Lugar = model.Lugar,
                    Duracion = model.Duracion,
                    Dimensiones = model.Dimensiones,
                    Comentarios = model.Comentarios,
                    Transporte = model.Transporte,
                    LinkFacebook = model.LinkFacebook,


                };


                //le paso la entidad. NUNCA se pasa un viewModel (Los viewModel son para las vistas!!!)
                EventoManager.NuevoEvento(evento);

                TempData[Strings.KeyMensajeDeAccion] = "El evento se cargó con éxito";
                return RedirectToAction("ProximosEventos");
            }
            else
            {
                return View(model);
            }



        }

        public ActionResult EditarEvento(int id)
        {
            //obtengo la entidad
            Evento evento = EventoManager.GetById(id);

            //a partir de la entidad, armo el viewModel que necesita la vista.
            EventoViewModel model = new EventoViewModel
            {
                Id = evento.Id,
                NombreSolicitante = evento.NombreSolicitante,
                TelefonoSolicitante = evento.TelefonoSolicitante,
                EmailSolicitante = evento.EmailSolicitante,
                MotivoNombre = evento.MotivoNombre,
                Fecha = evento.Fecha.ToShortDateString(),
                Hora = evento.Fecha.ToShortTimeString(),
                Duracion = evento.Duracion,
                Dimensiones = evento.Dimensiones,
                Comentarios = evento.Comentarios,
                Transporte = evento.Transporte,
                LinkFacebook = evento.LinkFacebook,

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEvento(EventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Evento evento = EventoManager.GetById(model.Id);
                //edito pasandole la entidad modificada...
                evento.NombreSolicitante = model.NombreSolicitante;
                evento.TelefonoSolicitante = model.TelefonoSolicitante;
                evento.EmailSolicitante = model.EmailSolicitante;
                evento.MotivoNombre = model.MotivoNombre;
                evento.Fecha = Convert.ToDateTime(model.Fecha + " " + model.Hora);
                evento.Duracion = model.Duracion;
                evento.Dimensiones = model.Dimensiones;
                evento.Comentarios = model.Comentarios;
                evento.Transporte = model.Transporte;
                evento.LinkFacebook = model.LinkFacebook;


                EventoManager.EditarEvento(evento);

                TempData[Strings.KeyMensajeDeAccion] = "El evento se modificó correctamente.";
                return RedirectToAction("ProximosEventos");
            }
            else
            {
                return View(model);
            }


        }



        public ActionResult BorrarEvento(int id)
        {
            EventoManager.BorrarEvento(id);

            TempData[Strings.KeyMensajeDeAccion] = "El evento se eliminó correctamente.";
            return RedirectToAction("ProximosEventos");
        }
    }
}





