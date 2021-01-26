using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;

namespace proyecto_1.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(int documento, string password)
        {
            try
            {
               
                

                using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                {

                    var docu = documento.ToString();

                    if(docu.Length >8 || docu.Length < 1)
                    {
                        return Content("No se puede ingresar más de 8 caracteres");
                    }

                    if (password.Length < 1)
                    {
                        return Content("No se puede ingresar menos de 1 caracter");
                    }


                    var passwordHash=System.Web.Helpers.Crypto.Hash(password);


                    var lst = from d in db.empleado
                              where d.dni == documento && d.Contraseña == passwordHash
                              select d;

                    if (lst.Count() > 0)
                    {
                         
                        empleado oEmpleado = lst.First();
                        Session["usuario"] = oEmpleado.id_empleado;
                        Session["comercio"] = oEmpleado.id_comercio;
                        Session["tipo"] = oEmpleado.id_tipo;
                        Session["nombre"] = oEmpleado.nombre;
                        Session["empleado"] = oEmpleado;


                        var lt = from d in db.comercio
                                  where d.id_comercio == oEmpleado.id_comercio
                                  select d;

                        if(lt.Count() > 0)
                        {
                            comercio oComercio = lt.First();
                            Session["nombrecomercio"] = oComercio.razon_social;

                        }
                        



                        return Content("1");
                    }
                    else
                    {
                        return Content("no se encontro al usuario");
                    }
                }

                
               
            }
            catch(Exception e)
            {
                return Content("ocurrio un error" + e.Message);
            }
        }

    }
}