using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models;

namespace proyecto_1.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        [HttpPost]
        public ActionResult AgregarCarrito(int id)
        {
            try
            {
                if (Session["carrito"] == null)
                {
                    List<CarritoItem> compras = new List<CarritoItem>();
                    using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                    {
                        compras.Add(new CarritoItem(db.productos.Find(id), 1));
                        Session["carrito"] = compras;

                    }

                }
                else
                {
                    List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                    using (practicaprofesionalEntities1 db = new practicaprofesionalEntities1())
                    {
                        int indexExistente = getIndex(id);
                            if(indexExistente == -1)
                            {
                                compras.Add(new CarritoItem(db.productos.Find(id), 1));
                            }
                            else
                            {
                            compras[indexExistente].Cantidad++;
                            }
                    }

                       
                        Session["carrito"] = compras;

                    
                }
                return Content("1");
            }
            catch(Exception e)
            {
                return Content("ocurrio un problema al agregar el producto", e.Message);
            }
        }





        public int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            
            for(int i=0; i< compras.Count; i++)
            {
                if(compras[i].Producto.id_producto == id)
                {
                    return i;
                }
             
            }
            return -1;
        }

        [HttpPost]
        public ActionResult EliminarItem (int id)
        {

            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return Content("1");
        }

       
    }
}