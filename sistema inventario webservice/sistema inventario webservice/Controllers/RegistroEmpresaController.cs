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
    [RoutePrefix("api/RegistroEmpresa")]
    public class RegistroEmpresaController : ApiController
    {
        private DAPaises dapaises;
        private DARegistroEmpresa daregistroempresa;
        public RegistroEmpresaController()
        {
            dapaises = new DAPaises();
            daregistroempresa = new DARegistroEmpresa();
        }

        [HttpPost]
        [Route("listarPaises")]
        public IHttpActionResult listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarPaises(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listarMoneda")]
        public IHttpActionResult listarMoneda(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarMoneda(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listarTipoImpuesto")]
        public IHttpActionResult listarTipoImpuesto(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarTipoImpuesto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("listarPorcentaje")]
        public IHttpActionResult listarPorcentaje(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = dapaises.listarPorcentaje(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("validarRegistro")]
        public IHttpActionResult validarRegistro(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = daregistroempresa.validarRegistro(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insertarEmpresa")]
        public IHttpActionResult insertarEmpresa(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = daregistroempresa.insertarEmpresa(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("insertarUserAdminEmpresa")]
        public IHttpActionResult insertarUserAdminEmpresa(ENRegistroEmpresa paramss)
        {
            try
            {
                var rpt = daregistroempresa.insertarUserAdminEmpresa(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [Route("activarCuenta")]
        public IHttpActionResult activarCuenta(string ruc)
        {
            try
            {
                var rpt = daregistroempresa.activarCuenta(ruc);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
