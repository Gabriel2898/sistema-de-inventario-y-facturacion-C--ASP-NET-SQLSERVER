 using Newtonsoft.Json;
using sistemadeinventario.clients;
using sistemadeinventario.entity.Parametros;
using sistemadeinventario.entity.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemadeinventario.business
{
    public class BUProveedores
    {
        private Client clients;

            public BUProveedores()
            {
                 clients = new Client();
            }
    

        public ResponseProveedores registrarProv(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/registrarProv", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ResponseProveedores> listarProveedores(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseProveedores>>(clients.Post<ENProveedores>("Proveedores/listarProveedores", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseProveedores desactivarProveedor(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/desactivarProveedor", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
              public ResponseProveedores activarProveedor(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/activarProveedor", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseProveedores eliminarProveedor(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/eliminarProveedor", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseProveedores obteditarProveedor(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/obteditarProveedor", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseProveedores editarProv(ENProveedores paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseProveedores>(clients.Post<ENProveedores>("Proveedores/editarProv", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }


}
