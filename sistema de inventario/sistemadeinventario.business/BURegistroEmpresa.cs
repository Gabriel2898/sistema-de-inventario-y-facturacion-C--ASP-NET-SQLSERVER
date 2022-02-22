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
    public class BURegistroEmpresa
    {
        private Client client;
        public BURegistroEmpresa()
        {
            client = new Client();
        }
        public ResponseRegistroEmpresa validarRegistro(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/validarRegistro", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public ResponseRegistroEmpresa insertarEmpresa(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/insertarEmpresa", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseRegistroEmpresa insertarUserAdminEmpresa(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseRegistroEmpresa>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/insertarUserAdminEmpresa",  paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseRegistroEmpresa activarCuenta(string ruc, string token)
        {
            try
            {
                return client.Get<ResponseRegistroEmpresa>(string.Format("RegistroEmpresa/activarCuenta?ruc={0}",ruc,token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
