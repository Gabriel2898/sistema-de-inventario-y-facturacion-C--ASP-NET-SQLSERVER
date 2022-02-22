using sistema_de_inventario.Models;
using sistemadeinventario.business;
using sistemadeinventario.entity.Encrypt;
using sistemadeinventario.entity.Parametros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace sistema_de_inventario.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais bupais;
        private BURegistroEmpresa buresgistroempresa;
        public RegistroEmpresaController()
        {
            model = new modelList();
            bupais = new BUPais();
            buresgistroempresa = new BURegistroEmpresa();
        }
        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
            string token = "";
            model.listPais = bupais.listaPaises(paramss, token);
            model.listMoneda = bupais.listaMoneda(paramss, token);
            model.listTipoImpuesto = bupais.listaTipoImpuesto(paramss, token);
            model.listPorcentaje = bupais.listaPorcentaje(paramss, token);
            return View(model);
        }

       [AllowAnonymous]
       [HttpPost]
       public ActionResult validarRegistro(ENRegistroEmpresa paramss)
        {
            string token = "";
            var rpt = buresgistroempresa.validarRegistro(paramss, token );
            return Json(new { dt = rpt });
        }
        [HttpPost]
        public ActionResult insertarEmpresa(HttpPostedFileBase file, string razonsocial, string ruc, string email, int idpais, int idmoneda, string direccion, int idimpuesto, int idporcentaje,int vendeimpuesto, string usuario, string username, string contraseña )
        {
            try
            {
                var clave = Encrypt.GetSHA256(contraseña);
                var filename = "";
                if(file != null)
                {
                    string path = Server.MapPath("~/Content/img/img_empresas/"+ruc+"/");
                    string filePath = string.Empty;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    filePath = path + Path.GetFileName(file.FileName);
                    file.SaveAs(filePath);
                    filename = file.FileName;
                }
                var paramss = new ENRegistroEmpresa();
                paramss.razonsocial = razonsocial;
                paramss.ruc = ruc;
                paramss.email = email;
                paramss.direccion = direccion;
                paramss.idpais = idpais;
                paramss.idmoneda = idmoneda;
                paramss.idimpuesto = idimpuesto;
                paramss.vendeimpuestos = vendeimpuesto;
                paramss.username = username;
                paramss.usuario = usuario;
                paramss.contraseña = clave;
                paramss.cantuser = 1;
                paramss.cargo = "superadmin";
                paramss.filename = filename;
                paramss.proyecto = "FACTUR";
                string token = "";
                var rpt = buresgistroempresa.insertarEmpresa(paramss,token);
                if (rpt.response=="ok")
                {
                    rpt = buresgistroempresa.insertarUserAdminEmpresa(paramss, token);
                    if (rpt.response == "ok")
                    {

                        string url = string.Format("http://localhost:64699/ActivarCuenta/ActivarCuenta?ruc=" + ruc);
                        SmtpClient smtpCliente;
                        MailMessage mailMsg;

                        string emailUsuario;
                        string emailClave;
                        string emailServidor;
                        int numPuerto;
                        string para = email;
                        string asunto = "Activación de Cuenta | Sistema de Inventario  y Facturacion ";
                        string mensaje = "<b>Gracias por registrarse<b/>" + "<br/><br/>" + "Estas son sus credenciales de Acceso " + "<br/><br/>" + "Usuario: " + usuario + "<br/>" + "Contraseña:" + contraseña + "<br/>" + "Cargo:" + paramss.cargo + "<br/></br>" + "!!!Para poder acceder al sistema debe primero activar la cuenta. Activela <a href=\"" + url + "\"> aqui </a>" + "<br/></br>" + "Recuerde esto es un periodo de prueba por 15 días, Para obtener un licencia  escribenos al correo gabriel2898cc@gmail.com";

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
                        //string url = string.Format("http://localhost:64699/ActivarCuenta/ActivarCuenta?ruc=" + ruc);
                        //string para = email;
                        //string asunto = "Activación de Cuenta | Sistema de Inventario  y Facturacion ";
                        //string mensaje = "<b>Gracias por registrarse<b/>" + "<br/><br/>" + "Estas son sus credenciales de Acceso " + "<br/><br/>" + "Usuario: " + usuario + "<br/>" + "Contraseña" + contraseña + "<br/>" + "Cargo" + paramss.cargo + "<br/></br>" + "Para poder acceder al sistema debe primero activar la cuenta. Activela <a href=\"" + url + "\"> aqui </a>" + "<br/></br>" + "Recuerde esto es un periodo de prueba por 15 días, Para obtener un licencia  escribenos al correo gabriel2898cc@gmail.com";
                        //MailMessage correo = new MailMessage();
                        //correo.From = new MailAddress("peperez1924@gmail.com");
                        //correo.To.Add(para);
                        //correo.Subject = asunto;
                        //correo.Body = mensaje;
                        //correo.IsBodyHtml = true;
                        //SmtpClient smtp = new SmtpClient("smtp.gmail.com");//Aqui va el host 
                        //string sCuentaCorreo = "peperez1924@gmail.com";
                        //string spassword = "qwertyuiopasdfghjklzxcvbnm123456789";//contraseña
                        //NetworkCredential credential = new NetworkCredential(sCuentaCorreo, spassword);
                        //smtp.UseDefaultCredentials = false;
                        //smtp.Credentials = credential;
                        //smtp.Port = 587;//numero de puerto
                        //smtp.EnableSsl = false;
                        //smtp.Send(correo);
                        return Json(new { dt = rpt });
                    }
                    else
                    {
                        return Json(new { dt = rpt });

                    }
                    
                }
                else
                {
                    return Json(new { dt = rpt });
                }
                return Json(new { dt = rpt });
            }catch(Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
