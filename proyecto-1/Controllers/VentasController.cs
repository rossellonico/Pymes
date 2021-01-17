using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;
using proyecto_1.Models.ViewModel;

namespace proyecto_1.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public ActionResult Registrar()
        {
            int idComercio = 0;
            if (Session.Count > 1)
            {
                idComercio = (int)Session["comercio"];
            }
            List<ListaProductosVentasViewModel> lst = null;
            using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
            {
                lst = (from e in db.productos
                       where e.id_comercio == idComercio && e.estado == "1"
                       select new ListaProductosVentasViewModel
                       {
                           id = e.id_producto,
                           descripcion = e.descripcion,
                           stock = e.stock,
                           precio = e.precio,
                           cantidad = e.stock
                       }).ToList();
            }
            return View(lst);



        }


        public ActionResult VerCarrito()
        {
            try
            {

                int idComercio = 0;
                int idEmpleado = 0;

                if (Session.Count > 1)
                {
                    idEmpleado = (int)Session["usuario"];
                    idComercio = (int)Session["comercio"];
                }

                List<ListaClientesViewModel> lst = null;
                using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                {
                    lst = (from c in db.clientes
                           join cc in db.cliente_comercio on
                           c.id_cliente equals cc.id_cliente
                           join si in db.situacion_iva on
                           c.IVA equals si.id_iva

                           where cc.id_comercio == idComercio
                           && c.estado == "1"
                           select new ListaClientesViewModel
                           {
                               id_cliente = c.id_cliente,
                               nombre = c.nombre,
                               direccion = c.direccion,
                               telefono = c.telefono,
                               CUIT = c.CUIT,
                               descripcion = si.descripcion
                           }).ToList();
                }

                List<SelectListItem> items = lst.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.nombre.ToString(),
                        Value = d.id_cliente.ToString(),
                        Selected = false

                    };
                });
                ViewBag.items = items;






                return View();
            }
            catch (Exception e)
            {
                return Content("error no tiene permiso para entrar" + e.Message);
            }
        }






    }
}