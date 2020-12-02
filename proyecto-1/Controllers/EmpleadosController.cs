using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;
using proyecto_1.Models.ViewModel;

namespace proyecto_1.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            try
            {
                int idEmpleado = 0;
                int idComercio = 0;
                int tipo = 0;

                if (Session.Count > 1)
                {
                    idEmpleado = (int)Session["usuario"];
                    idComercio = (int)Session["comercio"];
                    tipo = (int)Session["tipo"];
                    if(tipo == 2) {
                        return Redirect(Url.Content("~/Home"));
                    }
                }
                
                List<ListaEmpleadosViewModel> lst = null;
                using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                {
                    lst = (from e in db.empleado
                           join t in db.tipo_empleado on
                           e.id_tipo equals t.id_tipo
                           where e.id_comercio == idComercio && e.estado == "1"
                           select new ListaEmpleadosViewModel
                           {
                               id_empleado = e.id_empleado,
                               nombre = e.nombre,
                               apellido = e.apellido,
                               cargo = t.tipo
                           }).ToList();
                }

                return View(lst);
            }catch(Exception e)
            {
                return Content("error no tiene permiso para entrar" + e.Message);
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
         if (Session.Count > 1 && (int)Session["tipo"] == 2)
            { 
                    return Redirect(Url.Content("~/Home"));
                
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Crear(EmpleadoViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                empleado oEmpleado = new empleado();
                oEmpleado.nombre = model.nombre;
                oEmpleado.apellido = model.apellido;
                oEmpleado.estado = "1";
                oEmpleado.dni = model.dni;
                oEmpleado.Contraseña = model.password;
                oEmpleado.id_comercio = idComercio;
                oEmpleado.id_tipo = model.id_tipo;

                db.empleado.Add(oEmpleado);

                db.SaveChanges();


            }




            return Redirect(Url.Content("~/Empleados"));
        }



        public ActionResult Editar(int id)
        {
           
            try
            {
                
                EditarEmpleadoViewModel model = new EditarEmpleadoViewModel();
                
                int flag = 0;
               
                
                using (var db = new practicaprofesionalEntities1())
                {
                    var oEmpleado = db.empleado.Find(id);
                    model.id_empleado = oEmpleado.id_empleado;
                    model.nombre = oEmpleado.nombre.Trim();
                    model.apellido = oEmpleado.apellido.Trim();
                    model.dni = oEmpleado.dni;
                    model.id_tipo = oEmpleado.id_tipo;



                    if (oEmpleado.id_comercio == (int)Session["comercio"] && (int)Session["tipo"] == 1)
                    {
                        flag = 1;
                    }
                    if (oEmpleado.id_comercio == (int)Session["comercio"] && id == (int)Session["usuario"])
                    {
                        flag = 1;
                    }


                }
                if(flag == 1)
                return View(model);
                else
                    return Redirect(Url.Content("~/Home"));

            }
            catch
            {
                return Redirect(Url.Content("~/Home"));
            }
          

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(EditarEmpleadoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            using (var db = new practicaprofesionalEntities1())
            {
                var oEmpleado = db.empleado.Find(model.id_empleado);
                oEmpleado.nombre = model.nombre;
                oEmpleado.apellido = model.apellido;
                oEmpleado.dni = model.dni;
        
                

                if(model.password != null && model.password.Trim() != "")
                {
                    oEmpleado.Contraseña = model.password;
                }

                db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            if (Session.Count > 1 && (int)Session["tipo"] == 2)
            {
                return Redirect(Url.Content("~/Home"));

            }
            else
            {
                return Redirect(Url.Content("~/Empleados"));

            }

        }

       
        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            if (Session.Count > 1 && (int)Session["tipo"] == 2)
            {
                return Redirect(Url.Content("~/Home"));

            }
            using (var db = new practicaprofesionalEntities1())
            {
                var oEmpleado = db.empleado.Find(id);
                oEmpleado.estado = "0"; //eliminado logico

                db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

    }
}