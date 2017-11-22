using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaikoCordobaFinal.Utilities;

namespace TaikoCordobaFinal.Areas.Admin.Controllers
{
    public class AdminBaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session.IsNewSession || Session[Strings.KeyCurrentAdmin] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.Unauthorized, Strings.UIMessageUnauthorized);
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "InicioSesion" },
                        { "Action", "Index" },
                        { "Area", "" }
                    });
                }
            }
        }
    }

}