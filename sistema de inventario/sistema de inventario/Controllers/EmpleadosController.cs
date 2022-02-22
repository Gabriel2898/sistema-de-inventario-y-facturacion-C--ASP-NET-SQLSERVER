using sistema_de_inventario.Models;
using sistemadeinventario.business;
using sistemadeinventario.entity.Encrypt;
using sistemadeinventario.entity.Parametros;
using sistemadeinventario.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace sistema_de_inventario.Controllers
{
    public class EmpleadosController : Controller
    {
        private BUEmpleados  buempleados;
        private modelList model;
            public EmpleadosController(){
            buempleados = new BUEmpleados();
                model = new modelList();
        }
        public ActionResult Empleados()
        {
            var session = Session.GetCurrentUser();
            if (session != null)
            {
                if (session.usuarios==1 || session.cargo=="superadmin")
                {
                    ENEmpleados paramss = new ENEmpleados();
                    var token = session.responsetoken;
                    paramss.ruc = session.ruc;
                    paramss.slcargo = session.cargo;
                    model.listaEmpleados = buempleados.listaEmpleados(paramss,token);
                    model.listarCargos = buempleados.listarCargos(paramss,token);
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
            if (session.cargo=="superadmin")
            {
                var rpt = "ok";
                return Json(new { dt = rpt });
            }
            else
            {
                if (session.usuarios == 1)
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
        public ActionResult validarCantUsers()
        {
            var session = Session.GetCurrentUser();

            ENEmpleados paramss = new ENEmpleados();

            paramss.ruc = session.ruc;
            var token = session.responsetoken;

            var rpt = buempleados.validarCantUsers(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult registrarUsuario(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();

           

            paramss.ruc = session.ruc;
            var token = session.responsetoken;
            var clave = Encrypt.GetSHA256(paramss.password);
            paramss.password = clave;
            var rpt = buempleados.registrarUsuario(paramss, token);
            

            if (rpt.response == "ok")
            {
                string url = string.Format("http://localhost:64699/Index" );
                SmtpClient smtpCliente;
                MailMessage mailMsg;

                string emailUsuario;
                string emailClave;
                string emailServidor;
                int numPuerto;
                string para = paramss.email;
                string asunto = "Datos  de accesos al Sistema de Inventario  y Facturacion ";
                string mensaje = "<b>Se registraron los accesos para ingresar al sistema<b/>" + "<br/><br/>" + "Estas son sus credenciales de Acceso " + "<br/><br/>" + "Usuario: " + paramss.user + "<br/>" + "Contraseña:" + paramss.password + "<br/>" + "Cargo:" + paramss.slcargo + "<br/></br>" + "!!!Para poder acceder al sistema por favor ingrese <a href=\"" + url + "\"> aqui </a>" + "<br/></br>" + "Recuerde esto es un periodo de prueba por 15 días, Para obtener un licencia  escribenos al correo gabriel2898cc@gmail.com";

                emailServidor = "smtp.gmail.com";
                numPuerto = 587;
                emailUsuario = "peperez1924@gmail.com";
                emailClave = "qwertyuiopasdfghjklzxcvbnm123456789";
                smtpCliente = new SmtpClient();
                smtpCliente.Port = numPuerto;
                smtpCliente.Host = emailServidor;
                smtpCliente.EnableSsl = true;
                smtpCliente.Timeout = 60000;
                smtpCliente.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpCliente.UseDefaultCredentials = false;
                smtpCliente.Credentials = new System.Net.NetworkCredential(emailUsuario, emailClave);
                EnviarCorreo(para, mensaje);
                Boolean EnviarCorreo(string destino, string msg)
                {

                    emailServidor = "smtp.gmail.com";
                    numPuerto = 587;
                    emailUsuario = "peperez1924@gmail.com";
                    emailClave = "qwertyuiopasdfghjklzxcvbnm123456789";
                    try
                    {
                        mailMsg = new MailMessage(emailUsuario, destino, asunto, mensaje);
                        mailMsg.IsBodyHtml = true;
                        mailMsg.BodyEncoding = UTF8Encoding.UTF8;
                        mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                        smtpCliente.Send(mailMsg);
                        return true;

                    }
                    catch (Exception)
                    {
                        return false;
                    }

                }

                return Json(new { dt = rpt }); 
            }
            else
            {

                return Json(new { dt = rpt });
            }



        }

        [HttpPost]
        public ActionResult activarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;
            var rpt = buempleados.activarEmpleado(paramss, token);
            return Json(new { dt = rpt }); 
        }
        
            [HttpPost]
        public ActionResult desactivarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;
            var rpt = buempleados.desactivarEmpleado(paramss, token);
            return Json(new { dt = rpt });
        }
        [HttpPost]
        public ActionResult eliminarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;
            var rpt = buempleados.eliminarEmpleado(paramss, token);
            return Json(new { dt = rpt });
        }
        [HttpPost]
        public ActionResult obteditarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();
            var token = session.responsetoken;
            paramss.ruc = session.ruc;
            paramss.slcargo = session.cargo;
            var rpt = buempleados.obteditarEmpleado(paramss, token);
            return Json(new { dt = rpt });
        }

        [HttpPost]
        public ActionResult editarEmpleado(ENEmpleados paramss)
        {
            var session = Session.GetCurrentUser();



            paramss.ruc = session.ruc;
            var token = session.responsetoken;
            if(paramss.password != "0")
            {

                var clave = Encrypt.GetSHA256(paramss.password);
                paramss.password = clave;
            }
            var rpt = buempleados.editarEmpleado(paramss, token);


            if (rpt.response == "ok")
            {

                return Json(new { dt = rpt });
            }
            else
            {

                return Json(new { dt = rpt });
            }



        }
    }
}
