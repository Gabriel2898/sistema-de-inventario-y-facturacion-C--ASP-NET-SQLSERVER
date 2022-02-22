using sistemadefacturacion.datos;
using sistemadeinventario.entity.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sistema_inventario_webservice.Controllers
{
    [Authorize]
    [RoutePrefix("api/Empleados")]

    public class EmpleadosController : ApiController
    {
        private DAEmpleados daempleados;
        public EmpleadosController()
        {
            daempleados = new DAEmpleados();
        }

        
        [HttpPost]
        [Route("validarCantUsers")]
        public IHttpActionResult validarCantUsers(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.validarCantUsers(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("registrarUsuario")]
        public IHttpActionResult registrarUsuario(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.registrarUsuario(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listaEmpleados")]
        public IHttpActionResult listarEmpleados(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.listaEmpleados(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        [Route("listarCargos")]
        public IHttpActionResult listarCargos(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.listarCargos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("activarEmpleado")]
        public IHttpActionResult activarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.activarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("obteditarEmpleado")]
        public IHttpActionResult obteditarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.obteditarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("desactivarEmpleado")]
        public IHttpActionResult desactivarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.desactivarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("eliminarEmpleado")]
        public IHttpActionResult eliminarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.eliminarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("editarEmpleado")]
        public IHttpActionResult editarEmpleado(ENEmpleados paramss)
        {
            try
            {
                var rpt = daempleados.editarEmpleado(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
