using sistemadeinventario.business;
using sistemadeinventario.entity.Encrypt;
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
    public class LoginController : Controller
    {
       private BULogin bulogin;
        
        public LoginController()
        {
            bulogin = new BULogin();
        }
        [HttpPost]
        public ActionResult Acceder(ENLogin paramss)
        {
            var clave = Encrypt.GetSHA256(paramss.pass);
            paramss.pass = clave;
            var rpt = bulogin.Acceder(paramss);
            Session.Set(GlobalKey.CurrentUser, rpt);
            SetCurrenUser(rpt);
            return Json(new { dt = rpt });
        }
        protected void SetCurrenUser(ResponseLogin login)
        {
            Session["Username"] = login;
        }


    }

}
