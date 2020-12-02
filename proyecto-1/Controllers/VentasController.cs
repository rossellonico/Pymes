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


            return View();
        }


    }
}