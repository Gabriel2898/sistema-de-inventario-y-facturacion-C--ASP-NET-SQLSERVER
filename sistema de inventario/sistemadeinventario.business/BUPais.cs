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
    public class BUPais
    {
        private Client client;
        public BUPais()
        {
            client = new Client();
        }
        public List<ResponsePais> listaPaises(ENRegistroEmpresa paramss,string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePais>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPaises", paramss ,token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ResponseMoneda> listaMoneda(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseMoneda>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarMoneda", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ResponseTipoImpuesto> listaTipoImpuesto(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponseTipoImpuesto>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarTipoImpuesto", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ResponsePorcentaje> listaPorcentaje(ENRegistroEmpresa paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePorcentaje>>(client.Post<ENRegistroEmpresa>("RegistroEmpresa/listarPorcentaje", paramss, token));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
