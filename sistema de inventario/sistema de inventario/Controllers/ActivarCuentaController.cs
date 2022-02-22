using sistema_de_inventario.Models;
using sistemadeinventario.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistema_de_inventario.Controllers
{
    public class ActivarCuentaController : Controller
    {
        private modelList model;
        private BURegistroEmpresa buregistroempresa;
        public ActivarCuentaController()
        {
            model = new modelList();
            buregistroempresa=new BURegistroEmpresa();
        }
        public ActionResult ActivarCuenta(string ruc)
        {
            string token = "";
            model.msjActivarCuenta = buregistroempresa.activarCuenta(ruc,token);
            return View(model);
        }

       
    }
}
