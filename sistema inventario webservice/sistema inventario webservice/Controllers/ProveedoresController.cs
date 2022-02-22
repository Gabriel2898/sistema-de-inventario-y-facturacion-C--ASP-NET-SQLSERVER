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
    [RoutePrefix("api/Proveedores")]
    [Authorize]
    public class ProveedoresController : ApiController
    {
        private DAProveedores daprov;
        public ProveedoresController()
        {
            daprov = new DAProveedores();
        }
        [HttpPost]
        [Route("registrarProv")]
        public IHttpActionResult registrarProv(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.registrarProv(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("listarProveedores")]
        public IHttpActionResult listarProveedores(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.listarProveedores(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("desactivarProveedor")]
        public IHttpActionResult desactivarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.desactivarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("activarProveedor")]
        public IHttpActionResult activarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.activarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("eliminarProveedor")]
        public IHttpActionResult eliminarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.eliminarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("obteditarProveedor")]
        public IHttpActionResult obteditarProveedor(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.obteditarProveedor(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
          [HttpPost]
        [Route("editarProv")]
        public IHttpActionResult editarProv(ENProveedores paramss)
        {
            try
            {
                var rpt = daprov.editarProv(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
