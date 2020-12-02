using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace proyecto_1.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult CerrarSesion()
        {
            Session.RemoveAll();
            Session["empleado"] = null;
            Session["usuario"] = null;
            Session["comercio"] = null;
            Session["tipo"] = null;
            Session.Clear();
            

            return RedirectToAction("Index", "Acceso");


        }
    }
}