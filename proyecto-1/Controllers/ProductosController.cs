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
                lst = (from pd in db.productos
                       join pp in db.proveedores_productos on
                       pd.id_producto equals pp.id_producto
                       join pr in db.proveedores on
                       pp.id_proveedor equals pr.id_proveedor
                       where pd.id_comercio == idComercio && pd.estado == "1"
                       select new ListaProductosViewModel
                       {
                           id = pd.id_producto,
                           descripcion = pd.descripcion,
                           stock = pd.stock,
                           precio = pd.precio,
                           razon_social= pr.razon_social
                       }).ToList();
            }
            return View(lst);
        }


        [HttpGet]
        public ActionResult Crear()
        {
            int idComercio = 0;
            idComercio = (int)Session["comercio"];

            //Select de proveedores
            List<ProductoViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from p in db.proveedores
                       join pc in db.proveedores_comercios on
                       p.id_proveedor equals pc.id_proveedor
                       where p.estado == "1" && pc.id_comercio == idComercio
                       select new ProductoViewModel
                       {
                           id_proveedor = p.id_proveedor,
                           razon_social = p.razon_social
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.razon_social.ToString(),
                    Value = d.id_proveedor.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Crear(ProductoViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                //Select de proveedores
                List<ProductoViewModel> lst = null;
                using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
                {
                    lst = (from p in db.proveedores
                           select new ProductoViewModel
                           {
                               id_proveedor = p.id_proveedor,
                               razon_social = p.razon_social
                           }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.razon_social.ToString(),
                        Value = d.id_proveedor.ToString(),
                        Selected = false

                    };
                });
                ViewBag.items = items;
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
                
                int newIdentityValue = oProducto.id_producto;

                //insert en tabla proveedores_productos
                proveedores_productos p_productos = new proveedores_productos();
                p_productos.id_producto = newIdentityValue;
                p_productos.id_proveedor = model.id_proveedor;

                db.proveedores_productos.Add(p_productos);
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";

            }

            return Redirect(Url.Content("~/Productos"));
        }

        public ActionResult Editar(int id)
        {
            int idComercio = (int)Session["comercio"];
            
            //Select de proveedores
            List<ProductoViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from p in db.proveedores
                       join pc in db.proveedores_comercios on
                       p.id_proveedor equals pc.id_proveedor
                       where p.estado == "1" && pc.id_comercio == idComercio
                       select new ProductoViewModel
                       {
                           id_proveedor = p.id_proveedor,
                           razon_social = p.razon_social
                       }).ToList();
            }

            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.razon_social.ToString(),
                    Value = d.id_proveedor.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;
            


            EditarProductoViewModel model = new EditarProductoViewModel();

            using (var db = new practicaprofesionalEntities1())
            {
                var oProducto = db.productos.Find(id);
                
                model.descripcion = oProducto.descripcion;
                model.stock = oProducto.stock;
                model.precio = Decimal.Round(oProducto.precio,2);
                model.id_proveedor = oProducto.id_comercio;

            }

            return View(model);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Editar(EditarProductoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                int idComercio = (int)Session["comercio"];
            
                //Select de proveedores
                List<ProductoViewModel> lst = null;
                using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
                {
                    lst = (from p in db.proveedores
                           join pc in db.proveedores_comercios on
                           p.id_proveedor equals pc.id_proveedor
                           where p.estado == "1" && pc.id_comercio == idComercio
                           select new ProductoViewModel
                           {
                               id_proveedor = p.id_proveedor,
                               razon_social = p.razon_social
                           }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.razon_social.ToString(),
                        Value = d.id_proveedor.ToString(),
                        Selected = false

                    };
                });
                ViewBag.items = items;
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
                TempData["Referrer"] = "SaveRegister";

                //update en tabla proveedores_productos
                int newIdentityValue = oProducto.id_producto;

                var id_proveedor_producto = from pc in db.proveedores_productos
                    where pc.id_producto == newIdentityValue
                    select pc.id_proveedor_producto;

                var oProveedores_productos = db.proveedores_productos.Find(id_proveedor_producto.First());
                oProveedores_productos.id_proveedor = model.id_proveedor;
                db.Entry(oProveedores_productos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";

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