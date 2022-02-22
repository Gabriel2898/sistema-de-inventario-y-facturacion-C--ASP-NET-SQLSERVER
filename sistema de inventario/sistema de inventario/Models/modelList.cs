using sistemadeinventario.entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sistema_de_inventario.Models
{
    public class modelList
    {
        public List<ResponsePais> listPais { get; set; }
        public List<ResponseMoneda> listMoneda { get; set; }
        public List<ResponseTipoImpuesto> listTipoImpuesto { get; set; }
        public List<ResponsePorcentaje> listPorcentaje { get; set; }
        public ResponseRegistroEmpresa msjActivarCuenta { get; set; }

        public List<ResponseEmpleados> listaEmpleados { get; set; }
        public List<ResponseEmpleados> listarCargos { get; set; }

        public List<ResponseProveedores> listaProveedores { get; set; }

        public List<ResponseDepartamentos> listDepart { get; set; }
        public List<ResponseProductos> listProduct { get; set; }
        public List<ResponseProductos> buscarPro { get; set; }
        public List<ResponseProductos> buscarProductdepart { get; set; }
        public ResponseProductos tmoneda { get; set; }

        public List<ResponseDepartamentos> listadepartamentos { get; set; }
        
       public List<ResponsePromociones> listaPromociones { get; set; }

    }



}