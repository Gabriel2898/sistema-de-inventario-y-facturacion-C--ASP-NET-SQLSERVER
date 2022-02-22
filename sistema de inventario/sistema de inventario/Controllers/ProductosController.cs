using sistema_de_inventario.Models;
using sistemadeinventario.business;
using sistemadeinventario.clients;
using sistemadeinventario.entity.Parametros;
using sistemadeinventario.entity.Response;
using sistemadeinventario.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema_de_inventario.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private BUProductos buprod;
        private modelList model;
        public ProductosController()
        {
            buprod = new BUProductos();
            model = new modelList();
        }
        public ActionResult Productos()
        {
            var session = Session.GetCurrentUser();
            if (session != null)
            {
                if (session.usuarios == 1 || session.cargo == "superadmin")
                {
                    ENDepartamentos paramss= new ENDepartamentos();
                    ENProductos paramss1= new ENProductos();

                    var token = session.responsetoken;
                    paramss1.rucempresa = session.ruc; 
                    model.listDepart = buprod.listDepart(paramss, token);
                    model.listProduct = buprod.listarProductos(paramss1, token);
                    model.tmoneda = buprod.tmoneda(paramss1, token);
                    
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Panel", "Panel");
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
        [HttpPost]
        public ActionResult validarAccesoModulo()
        {
            var session = Session.GetCurrentUser();
            if (session.cargo == "superadmin")
            {
                var rpt = "ok";
                return Json(new { dt = rpt });
            }
            else
            {
                if (session.productos == 1)
                {
                    var rpt = "ok";
                    return Json(new { dt = rpt });
                }
                else
                {
                    var rpt = "error";
                    return Json(new { dt = rpt });
                }

            }
        }
        [HttpPost]
        public ActionResult CalcularPventaSinImpuestos(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;


            var rpt = buprod.CalcularPventaSinImpuestos(paramss, token);
            return Json(new { dt = rpt });
        }
        [HttpPost]
        public ActionResult calculoPrecios(ENProductos paramss)
        {
            if (paramss.pmayoreo > paramss.pventa)
            {
                var rpt = "error";
                return Json(new { dt = rpt });
            }
            else
            {
                var rpt = "ok";
                return Json(new { dt = rpt });
            }

        }
        [HttpPost]
        public ActionResult guardarProduct(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buprod.guardarProduct(paramss, token);
            return Json(new { dt = rpt });
        }
        public ActionResult listarProductos(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buprod.listarProductos(paramss, token);
            return Json(new { dt = rpt });
        }
        

        [HttpPost]
        public ActionResult buscarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            model.buscarPro = buprod.buscarProducto(paramss, token);
            return Json(new { dt = model.buscarPro, total = model.buscarPro.Count() });
        }
        

        [HttpPost]
        public ActionResult buscarProductodepart(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            model.buscarProductdepart = buprod.buscarProductodepart(paramss, token);
            return Json(new { dt = model.buscarProductdepart, total = model.buscarProductdepart.Count() });
        }


        
        [HttpPost]
        public ActionResult eliminarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buprod.eliminarProducto(paramss, token);
            return Json(new { dt = rpt });
        }

        
        [HttpPost]
        public ActionResult obtEditarProducto(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            ResponseProductos rpt = new ResponseProductos();

            string idproductos = paramss.datos;
            String[] strlist = idproductos.Split('|');
            var count = strlist.Count() - 1;

            if (count == 1)
            {
                rpt = buprod.obtEditarProducto(paramss, token);
                return Json(new { dt = rpt });
            }
            else
            {
                rpt.response = "Error";
                return Json(new { dt = rpt });
            }


        }

        
        [HttpPost]
        public ActionResult editarProduct(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = buprod.editarProduct(paramss, token);
            return Json(new { dt = rpt });
        }
        /*

        [HttpPost]
        public JsonResult obtlistaProducto(string letra)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;

            ENProductos paramss = new ENProductos();
            paramss.rucempresa = session.ruc;
            paramss.letra = letra;
            return Json(buproduc.obtlistaProducto(paramss, token), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult obtlistaProducto_cod(ENProductos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;
            paramss.letra = paramss.codbarra;

            var rpt = buproduc.obtlistaProducto(paramss, token);
            return Json(new { dt = rpt });


        }*/
    }
}