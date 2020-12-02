using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;
using proyecto_1.Models.ViewModel;

namespace proyecto_1.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            int idComercio = 0;
            if (Session.Count > 1)
            {
                idComercio = (int)Session["comercio"];
            }
            List<ListaProductosViewModel> lst = null;
            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                lst = (from e in db.productos                      
                       where e.id_comercio == idComercio && e.estado == "1"
                       select new ListaProductosViewModel
                       {
                           id = e.id_producto,
                           descripcion = e.descripcion,
                           stock = e.stock,
                           precio = e.precio
                       }).ToList();
            }
            return View(lst);
        }


        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Crear(ProductoViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                productos oProducto = new productos();
                
                oProducto.descripcion = model.descripcion;
                oProducto.estado = "1";
                oProducto.stock = model.stock;
                oProducto.precio = model.precio;
                oProducto.id_comercio = idComercio;
                
                db.productos.Add(oProducto);

                db.SaveChanges();


            }

            return Redirect(Url.Content("~/Productos"));
        }

        public ActionResult Editar(int id)
        {
            EditarProductoViewModel model = new EditarProductoViewModel();

            using (var db = new practicaprofesionalEntities1())
            {
                var oProducto = db.productos.Find(id);
                model.descripcion = oProducto.descripcion;
                model.stock = oProducto.stock;
                model.precio = oProducto.precio;
                model.id_provedor = oProducto.id_comercio;

            }

            return View(model);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(EditarProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new practicaprofesionalEntities1())
            {
                var oProducto = db.productos.Find(model.id);
                oProducto.descripcion = model.descripcion.Trim();
                oProducto.stock = model.stock;
                oProducto.precio = model.precio;
               

                db.Entry(oProducto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Productos"));

        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (var db = new practicaprofesionalEntities1())
                {
                    var oProductos = db.productos.Find(id);
                    oProductos.estado = "0"; //eliminado logico

                    db.Entry(oProductos).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }catch(Exception e)
            {
                return Content("ocurrio un problema al elminar el producto", e.Message);
            }
        }
    }
}