using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaikoCordobaFinal.Manager;
using TaikoCordobaFinal.Entities;
using TaikoCordobaFinal.Models;
using TaikoCordobaFinal.Utilities;

namespace TaikoCordobaFinal.Controllers
{
    public class InicioSesionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IniciarSesion model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }


            Admin admnistrador = AdminManager.Login(model.Email, model.Password);
            if (admnistrador == null)
            {
                ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                return View(model);
            }

            Session[Strings.KeyCurrentAdmin] = admnistrador;
            return RedirectToAction("ProximosEventos", "ProximosEventos", new { area = "Admin" });


         
        }

        public ActionResult Logout()
        {
            Session.Remove(Strings.KeyCurrentAdmin);
            return RedirectToAction("Index", "Home");
        }
    }


}