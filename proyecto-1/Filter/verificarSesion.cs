using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;
using proyecto_1.Controllers;

namespace proyecto_1.Filter
{
    public class verificarSesion :   ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oEmpleado = (empleado)HttpContext.Current.Session["empleado"];

            if(oEmpleado == null)
            {
                if(filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Index"); 
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }

            }


            base.OnActionExecuting(filterContext);
        }
    }
}