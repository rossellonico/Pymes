using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;
using proyecto_1.Models.ViewModel;

namespace proyecto_1.Controllers
{
    public class ComerciosController : Controller
    {
        // GET: Comercios
        public ActionResult Index()
        {
            int idComercio = 0;
            if (Session.Count > 1)
            {
                idComercio = (int)Session["comercio"];
            }
            List<ListaComerciosViewModel> lst = null;
            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                lst = (from c in db.comercio
                       where c.id_comercio != 0 && c.estado == "1"
                       select new ListaComerciosViewModel
                       {
                           id_comercio = c.id_comercio,
                           razon_social = c.razon_social,
                           ingresos_brutos = c.Ingresos_brutos,
                           fecha_inicio = (DateTime)c.fecha_inicio, 
                           CUIT = c.CUIT,
                           IVA = (int) c.IVA
                       }).ToList();
            }
            return View(lst);
        }


        [HttpGet]
        public ActionResult Crear()
        {
            //Select de situacion frente al IVA
            List<ComercioViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from d in db.situacion_iva
                       select new ComercioViewModel
                       {
                           id_IVA = d.id_iva,
                           descripcion = d.descripcion
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.descripcion.ToString(),
                    Value = d.id_IVA.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Crear(ComercioViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                //Select de situacion frente al IVA
                List<ComercioViewModel> lst = null;
                using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
                {
                    lst = (from d in db.situacion_iva
                           select new ComercioViewModel
                           {
                               id_IVA = d.id_iva,
                               descripcion = d.descripcion
                           }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.descripcion.ToString(),
                        Value = d.id_IVA.ToString(),
                        Selected = false

                    };
                });
                ViewBag.items = items;
                return View(model);
            }

            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                comercio oComercio = new comercio();

                oComercio.razon_social = model.razon_social;
                oComercio.estado = "1";
                oComercio.IVA = model.id_IVA;
                oComercio.Ingresos_brutos = model.Ingresos_brutos;
                oComercio.CUIT = model.CUIT;
                oComercio.fecha_inicio = Convert.ToDateTime(model.fecha_inicios);
                //oComercio.fecha_inicio = model.fecha_inicio;

                db.comercio.Add(oComercio);

                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";
            }

            return Redirect(Url.Content("~/Comercios"));
        }

        public ActionResult Editar(int id)
        {

            //Select de situacion frente al IVA
            List<ComercioViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from d in db.situacion_iva
                       select new ComercioViewModel
                       {
                           id_IVA = d.id_iva,
                           descripcion = d.descripcion
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.descripcion.ToString(),
                    Value = d.id_IVA.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;

            EditarComercioViewModel model = new EditarComercioViewModel();

            using (var db = new practicaprofesionalEntities1())
            {
                var oComercio = db.comercio.Find(id);
                model.razon_social = oComercio.razon_social;
                model.id_IVA = (int) oComercio.IVA;
                model.Ingresos_brutos = oComercio.Ingresos_brutos;
                model.fecha_inicio = (DateTime) oComercio.fecha_inicio;
                model.CUIT = oComercio.CUIT;

            }
            model.fecha_inicios = model.fecha_inicio.ToShortDateString();
            return View(model);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(EditarComercioViewModel model)
        {
            if (!ModelState.IsValid)
            {  
                //Select de situacion frente al IVA
                List<ComercioViewModel> lst = null;
                using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
                {
                    lst = (from d in db.situacion_iva
                           select new ComercioViewModel
                           {
                               id_IVA = d.id_iva,
                               descripcion = d.descripcion
                           }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.descripcion.ToString(),
                        Value = d.id_IVA.ToString(),
                        Selected = false

                    };
                });
                ViewBag.items = items;
                return View(model);
            }

            using (var db = new practicaprofesionalEntities1())
            {
                var oComercio = db.comercio.Find(model.id);
                oComercio.razon_social = model.razon_social;
                oComercio.IVA = model.id_IVA;
                oComercio.Ingresos_brutos = model.Ingresos_brutos;
                oComercio.fecha_inicio = Convert.ToDateTime(model.fecha_inicios);
                oComercio.CUIT = model.CUIT;


                db.Entry(oComercio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";

            }

            return Redirect(Url.Content("~/Comercios"));

        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (var db = new practicaprofesionalEntities1())
                {
                    var oComercio = db.comercio.Find(id);
                    oComercio.estado = "0"; //eliminado logico

                    db.Entry(oComercio).State = System.Data.Entity.EntityState.Modified;
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
    
    
    
