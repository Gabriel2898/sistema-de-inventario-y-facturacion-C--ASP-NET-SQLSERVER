using sistema_de_inventario.Models;
using sistemadeinventario.business;
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
    public class DepartamentosController : Controller
    {

        private BUDepartamentos budepart;
        private modelList model;

        public DepartamentosController()
        {
            budepart = new BUDepartamentos();
            model = new modelList();
        }


        // GET: Departamentos
        public ActionResult Departamentos()
        {
            var session = Session.GetCurrentUser();

            if (session != null)
            {
                if (session.productos == 1 | session.cargo == "superadmin")
                {
                    ENDepartamentos paramss = new ENDepartamentos();
                    paramss.rucempresa = session.ruc;
                    var token = session.responsetoken;


                    model.listadepartamentos = budepart.listadepartamentos(paramss, token);
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
        public ActionResult guardarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = budepart.guardarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }


        [HttpPost]
        public ActionResult eliminarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;


            var rpt = budepart.eliminarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }


        [HttpPost]
        public ActionResult obtEditarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            ResponseDepartamentos rpt = new ResponseDepartamentos();

            string iddepartamento = paramss.datos;
            String[] strlist = iddepartamento.Split('|');
            var count = strlist.Count() - 1;

            if (count == 1)
            {
                rpt = budepart.obtEditarDepartamento(paramss, token);
                return Json(new { dt = rpt });
            }
            else
            {
                rpt.response = "Error";
                return Json(new { dt = rpt });
            }


        }


        [HttpPost]
        public ActionResult editarDepartamento(ENDepartamentos paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.rucempresa = session.ruc;

            var rpt = budepart.editarDepartamento(paramss, token);
            return Json(new { dt = rpt });
        }



    }
}