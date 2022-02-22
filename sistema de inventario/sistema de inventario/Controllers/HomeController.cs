using sistemadeinventario.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace sistema_de_inventario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var session = Session.GetCurrentUser();
            if (session != null)
            {
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                return RedirectToAction("Panel", "Panle");
                
            }
            else
            {
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
                return View();
            }
        }
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            return RedirectToAction("Index");
        }

       
    }
}