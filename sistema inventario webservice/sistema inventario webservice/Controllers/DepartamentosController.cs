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
    [RoutePrefix("api/Departamentos")]
    [Authorize]
    public class DepartamentosController : ApiController
    {
        private DADepartamentos dadepart;

        public DepartamentosController()
        {
            dadepart = new DADepartamentos();
        }



        [HttpPost]
        [Route("guardarDepartamento")]
        public IHttpActionResult guardarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                var rpt = dadepart.guardarDepartamento(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("listadepartamentos")]
        public IHttpActionResult listadepartamentos(ENDepartamentos paramss)
        {
            try
            {
                var rpt = dadepart.listadepartamentos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("eliminarDepartamento")]
        public IHttpActionResult eliminarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                var rpt = dadepart.eliminarDepartamento(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("obtEditarDepartamento")]
        public IHttpActionResult obtEditarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                var rpt = dadepart.obtEditarDepartamento(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost]
        [Route("editarDepartamento")]
        public IHttpActionResult editarDepartamento(ENDepartamentos paramss)
        {
            try
            {
                var rpt = dadepart.editarDepartamento(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
