using proyecto_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models.ViewModel;

namespace proyecto_1.Controllers
{
    public class ProveedoresController : Controller
    {
        // GET: Proveedores
        public ActionResult Index()
        {
            try
            {
               
                int idComercio = 0;

                if (Session.Count > 1)
                {
                  //  idEmpleado = (int)Session["usuario"];
                    idComercio = (int)Session["comercio"];
                }
                
                List<ListaProveedoresViewModel> lst = null;
                using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                {
                    lst = (from p in db.proveedores
                           join pc in db.proveedores_comercios on
                           p.id_proveedor equals pc.id_proveedor
                           where pc.id_comercio == idComercio 
                           && p.estado == "1"
                           select new ListaProveedoresViewModel
                           {
                               id = p.id_proveedor,
                               razon_social = p.razon_social,
                               email = p.email,
                               telefono = p.telefono
                           }).ToList();
                }

                return View(lst);
            }
            catch (Exception e)
            {
                return Content("error no tiene permiso para entrar" + e.Message);
            }
        }


         [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Crear(ProveedorViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                proveedores oProveedor = new proveedores();

                oProveedor.razon_social = model.razon_social;
                oProveedor.estado = "1";
                oProveedor.email = model.email;
                oProveedor.telefono = Convert.ToString(model.telefono);
                
                db.proveedores.Add(oProveedor);

                db.SaveChanges();

                int newIdentityValue = oProveedor.id_proveedor;

                //insert en tabla proveedores_comercios
                proveedores_comercios p_comercio = new proveedores_comercios();
                p_comercio.id_comercio = idComercio;
                p_comercio.id_proveedor = newIdentityValue;

                db.proveedores_comercios.Add(p_comercio);
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";



            }

            return Redirect(Url.Content("~/Proveedores"));
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            int idComercio = (int)Session["comercio"];

            EditarProveedorViewModel model = new EditarProveedorViewModel();

            using (var db = new practicaprofesionalEntities1())
            {
                var oProveedor = db.proveedores.Find(id);
                model.razon_social = oProveedor.razon_social;
                model.email = oProveedor.email;
                model.telefono = Convert.ToInt32(oProveedor.telefono);
               
            }



            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(EditarProveedorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new practicaprofesionalEntities1())
            {
                var oProveedor = db.proveedores.Find(model.id);
                oProveedor.razon_social = model.razon_social.Trim();
                oProveedor.email = model.email;
                oProveedor.telefono = Convert.ToString(model.telefono);


                db.Entry(oProveedor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";


            }

            return Redirect(Url.Content("~/Proveedores"));

        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (var db = new practicaprofesionalEntities1())
                {
                    var oPoveedor = db.proveedores.Find(id);
                    oPoveedor.estado = "0"; //eliminado logico

                    db.Entry(oPoveedor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception e)
            {
                return Content("ocurrio un problema al elminar el producto", e.Message);
            }
        }



    }
}