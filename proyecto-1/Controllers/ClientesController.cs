﻿using proyecto_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_1.Models.ViewModel;
namespace proyecto_1.Controllers

{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
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
            // Select de situacion frente al IVA
            List<ClienteViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from d in db.situacion_iva
                       select new ClienteViewModel
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
        public ActionResult Crear(ClienteViewModel model)
        {

            int idComercio = (int)Session["comercio"];

            if (!ModelState.IsValid)
            {
                // Select de situacion frente al IVA
                List<ClienteViewModel> lst = null;
                using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
                {
                    lst = (from d in db.situacion_iva
                           select new ClienteViewModel
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
                clientes oCliente = new clientes();

                oCliente.nombre = model.nombre;
                oCliente.direccion = model.direccion;
                oCliente.telefono = model.telefono;
                oCliente.estado = "1";
                oCliente.CUIT = model.CUIT;
                oCliente.IVA = model.id_IVA;

                db.clientes.Add(oCliente);

                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";

                int newIdentityValue = oCliente.id_cliente;

                //insert en tabla cliente_comercio
                cliente_comercio c_comercio = new cliente_comercio();
                c_comercio.id_comercio = idComercio;
                c_comercio.id_cliente = newIdentityValue;

                db.cliente_comercio.Add(c_comercio);
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";
            }

            return Redirect(Url.Content("~/Clientes"));
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            int idComercio = (int)Session["comercio"];

            // Select de situacion frente al IVA
            List<ClienteViewModel> lst = null;
            using (Models.practicaprofesionalEntities1 db = new Models.practicaprofesionalEntities1())
            {
                lst = (from d in db.situacion_iva
                       select new ClienteViewModel
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

            EditarClienteViewModel model = new EditarClienteViewModel();

            using (var db = new practicaprofesionalEntities1())
            {
                var oCliente = db.clientes.Find(id);
                model.nombre = oCliente.nombre;
                model.direccion = oCliente.direccion;
                model.telefono = oCliente.telefono;
                model.CUIT = oCliente.CUIT;
                model.id_IVA = (int) oCliente.IVA;

            }
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(EditarClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new practicaprofesionalEntities1())
            {
                var oCliente = db.clientes.Find(model.id);
                oCliente.nombre = model.nombre.Trim();
                oCliente.direccion = model.direccion;
                oCliente.telefono = model.telefono;
                oCliente.CUIT = model.CUIT;
                oCliente.IVA = model.id_IVA;


                db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["Referrer"] = "SaveRegister";

            }

            return Redirect(Url.Content("~/Clientes"));

        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {
                using (var db = new practicaprofesionalEntities1())
                {
                    var oCliente = db.clientes.Find(id);
                    oCliente.estado = "0"; //eliminado logico

                    db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception e)
            {
                return Content("ocurrio un problema al eliminar el cliente", e.Message);
            }
        }



    }
}