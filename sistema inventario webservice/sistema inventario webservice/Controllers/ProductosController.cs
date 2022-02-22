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
    [RoutePrefix("api/Productos")]
    [Authorize]
    public class ProductosController : ApiController
    {
        private DAProductos daprod;
        public ProductosController()
        {
            daprod = new DAProductos();
        }
        [HttpPost]
        [Route("CalcularPventaSinImpuestos")]
        public IHttpActionResult CalcularPventaSinImpuestos(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.CalcularPventaSinImpuestos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("listDepart")]
        public IHttpActionResult listDepart(ENDepartamentos paramss)
        {
            try
            {
                var rpt = daprod.listDepart(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [Route("guardarProduct")]
        public IHttpActionResult guardarProduct(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.guardarProduct(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("listarProductos")]
        public IHttpActionResult listarProductos(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.listarProductos(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("buscarProducto")]
        public IHttpActionResult buscarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.buscarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("buscarProductodepart")]
        public IHttpActionResult buscarProductodepart(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.buscarProductodepart(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("eliminarProducto")]
        public IHttpActionResult eliminarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.eliminarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost]
        [Route("tmoneda")]
        public IHttpActionResult tmoneda(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.tmoneda(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("obtEditarProducto")]
        public IHttpActionResult obtEditarProducto(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.obtEditarProducto(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost]
        [Route("editarProduct")]
        public IHttpActionResult editarProduct(ENProductos paramss)
        {
            try
            {
                var rpt = daprod.editarProduct(paramss);
                return Ok(rpt);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        //[HttpPost]
        //[Route("obtlistaProducto")]
        //public IHttpActionResult obtlistaProducto(ENProductos paramss)
        //{
        //    try
        //    {
        //        var rpt = daproduc.obtlistaProducto(paramss);
        //        return Ok(rpt);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}
