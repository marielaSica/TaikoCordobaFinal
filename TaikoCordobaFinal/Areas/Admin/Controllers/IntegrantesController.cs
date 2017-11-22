using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Areas.Admin.Models;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Utilities;
using System.IO;

namespace TaikoCordobaFinal.Areas.Admin.Controllers
{
    public class IntegrantesController : AdminBaseController
    {
        // GET: Admin/Integrantes
        public ActionResult Integrantes()
        {
            ViewBag.Estados = IntegrantesManager.GetEstados();
            List<Integrante> integrantes = IntegrantesManager.GetIntegrantes();
            return View(integrantes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Integrantes(int? estadoId) //int? significa que es un int nulleable.
        {
            ViewBag.Estados = IntegrantesManager.GetEstados();
            List<Integrante> integrantes;
            if (estadoId.HasValue) //HasValue nos dice si el nulleable tiene valor.
            {
                integrantes = IntegrantesManager.GetPorEstado(estadoId.Value); //.Value sobre un nulleable nos retorna el valor.
            }
            else
            {
                integrantes = IntegrantesManager.GetIntegrantes();
            }

            return View(integrantes);
        }
        public ActionResult DetalleIntegrantes(int id)
        {
            Integrante integrantes = IntegrantesManager.GetById(id);
            return View(integrantes);
        }

        public ActionResult NuevoIntegrante()
        {
            IntegrantesViewModel model = new IntegrantesViewModel
            {
                Estados = new SelectList(IntegrantesManager.GetEstados(), "Id", "Nombre")
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoIntegrante(IntegrantesViewModel model)
        {
            //verifico, si subio imagen, que la imagen sea jpg
            if (model.Imagen != null && !model.Imagen.ContentType.Equals("image/jpeg"))
            {
                ModelState.AddModelError("Imagen", "La imagen debe ser jpg.");
            }

            if (ModelState.IsValid)
            {
                string imageUri = "";
                if (model.Imagen != null && model.Imagen.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(model.Imagen.FileName);
                    var uploadDir = "~/Uploads/integrantes";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), fileName);
                    model.Imagen.SaveAs(imagePath);
                    imageUri = string.Format("{0}/{1}", uploadDir, fileName);
                }
                //Creo mi entidad a partir del ViewModel.


                Integrante integrantes = new Integrante
                {

                    Nombre = model.Nombre,
                    ImagenUri = imageUri,
                    Apellido = model.Apellido,
                    Email = model.Email,
                    Telefono = model.Telefono,
                    TelefonoEmergencia = model.TelefonoEmergencia,
                    Direccion = model.Direccion,
                    Estado = new Estado { Id = model.EstadoId },
                };

                //le paso la entidad. NUNCA se pasa un viewModel (Los viewModel son para las vistas!!!)
                IntegrantesManager.NuevoIntegrante(integrantes);

                TempData[Strings.KeyMensajeDeAccion] = "Se ha cargado un nuevo integrante";
                return RedirectToAction("Integrantes");
            }
            else
            {
                model.Estados = new SelectList(IntegrantesManager.GetEstados(), "Id", "Nombre");
            }

             return View(model);
        }

        public ActionResult EditarIntegrante(int id)
        {
            //obtengo la entidad
            Integrante integrante = IntegrantesManager.GetById(id);

            //a partir de la entidad, armo el viewModel que necesita la vista.
            IntegrantesViewModel model = new IntegrantesViewModel
            {
                Id = integrante.Id,
                ImagenUri = integrante.ImagenUri,
                Nombre = integrante.Nombre,
                Apellido = integrante.Apellido,
                Email = integrante.Email,
                Telefono = integrante.Telefono,
                TelefonoEmergencia = integrante.TelefonoEmergencia,
                Direccion = integrante.Direccion,
                Estados = new SelectList(IntegrantesManager.GetEstados(), "Id", "Nombre"),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarIntegrante(IntegrantesViewModel model)
        {
            if (model.Imagen != null && !model.Imagen.ContentType.Equals("image/jpeg"))
            {
                ModelState.AddModelError("Imagen", "La imagen debe ser jpg.");
            }

            if (ModelState.IsValid)
            {
                string imageUri = ""; //inicializo.. 
                if (!string.IsNullOrEmpty(model.ImagenUri))
                {
                    //Si no es vacio, la inicializo con el valor q tenia..
                    imageUri = model.ImagenUri;
                }
                if (model.Imagen != null && model.Imagen.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(model.Imagen.FileName);
                    var uploadDir = "~/Uploads/integrantes";
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), fileName);
                    model.Imagen.SaveAs(imagePath);
                    imageUri = string.Format("{0}/{1}", uploadDir, fileName);
                }
                //Obtengo mi entidad, y la actualizo mi entidad a partir del ViewModel.

                Integrante integrante = IntegrantesManager.GetById(model.Id);
                integrante.ImagenUri = imageUri;
                integrante.Nombre = model.Nombre;
                integrante.Apellido = model.Apellido;
                integrante.Email = model.Email;
                integrante.Telefono = model.Telefono;
                integrante.TelefonoEmergencia = model.TelefonoEmergencia;
                integrante.Direccion = model.Direccion;
                integrante.Estado = new Estado { Id = model.EstadoId };



                //edito pasandole la entidad modificada...
                IntegrantesManager.EditarIntegrante(integrante);

                TempData[Strings.KeyMensajeDeAccion] = "se modificó correctamente la información de este integrante.";
                return RedirectToAction("Integrantes");
            }
            else
            {
                model.Estados = new SelectList(IntegrantesManager.GetEstados(), "Id", "Nombre");
            }

            return View(model);

        }

        public ActionResult BorrarIntegrante(int id)
        {
            IntegrantesManager.BorrarIntegrante(id);

            TempData[Strings.KeyMensajeDeAccion] = "se eliminó correctamente al integrante.";
            return RedirectToAction("Integrantes");
        }
    }
}