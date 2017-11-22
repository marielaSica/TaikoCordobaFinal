using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Areas.Admin.Models;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Utilities;


namespace TaikoCordobaFinal.Areas.Admin.Controllers
{
    public class FinanzasController : AdminBaseController
    {
        // GET: Admin/Finanzas
        public ActionResult Finanzas()
        {
            FinanzasViewModel viewModel = new FinanzasViewModel();
            viewModel.MesCuotaMuestra = MesCuotaManager.GetMesCuotaMuestra();

            return View(viewModel);
        }

        public ActionResult IntegrantesModal(int id)
        {
            Integrante integrante = IntegrantesManager.GetById(id);
            return PartialView("_DetalleIntegrantesModal", integrante);
        }

        public ActionResult MesPasado()
        {
            FinanzasViewModel viewModel = new FinanzasViewModel();
            viewModel.MesCuotaMuestra = MesCuotaManager.GetMesCuotaMuestra();

            return View(viewModel);
        }


        public ActionResult Archivo()
        {
            FinanzasViewModel viewModel = new FinanzasViewModel();
            viewModel.MesCuotaMuestra = MesCuotaManager.GetMesCuotaMuestra();

            return View(viewModel);
        }

        public ActionResult NuevoMesCuota()
        {
            MesCuotaViewModel model = new MesCuotaViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoIntegrante(MesCuotaViewModel model)
        {

            if (ModelState.IsValid)
            {
                //Creo mi entidad a partir del ViewModel.
                MesCuota mescuota = new MesCuota
                {
                    //Integrante = new List<Integrantes> { Id = model.Nombre}
                    Monto = model.Monto,
                    Fecha = model.Fecha,
                    Mes = model.Mes,
                    TalonPago = model.TalonPago,
                    Comentarios = model.Comentarios

                };

                //le paso la entidad. NUNCA se pasa un viewModel (Los viewModel son para las vistas!!!)
                MesCuotaManager.NuevoMes(mescuota);

                TempData[Strings.KeyMensajeDeAccion] = "Se ha cargado un nuevo mes correctamente";
                return RedirectToAction("Finanzas");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult EditarMesCuota(int id)
        {
            //obtengo la entidad
            MesCuota mescuota = MesCuotaManager.GetById(id);

            //a partir de la entidad, armo el viewModel que necesita la vista.
            MesCuotaViewModel model = new MesCuotaViewModel
            {
                Monto = mescuota.Monto,
                Fecha = mescuota.Fecha,
                Mes = mescuota.Mes,
                TalonPago = mescuota.TalonPago,
                Comentarios = mescuota.Comentarios
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMesCuota(MesCuotaViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Obtengo mi entidad, y la actualizo mi entidad a partir del ViewModel.
                MesCuota mescuota = MesCuotaManager.GetById(model.Id);

                mescuota.Monto = model.Monto;
                mescuota.Fecha = model.Fecha;
                mescuota.Mes = model.Mes;
                mescuota.TalonPago = model.TalonPago;
                mescuota.Comentarios = model.Comentarios;

                //edito pasandole la entidad modificada...
                MesCuotaManager.EditarMes(mescuota);

                TempData[Strings.KeyMensajeDeAccion] = "El mes se modificó correctamente.";
                return RedirectToAction("Finanzas");
            }
            else
            {
                return View(model);
            }


        }

    }
}