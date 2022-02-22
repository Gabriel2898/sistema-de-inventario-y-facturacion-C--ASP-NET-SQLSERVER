﻿using Newtonsoft.Json;
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
  public  class BUPromociones
    {
        private Client clients;

        public BUPromociones()
        {
            clients = new Client();
        }


        public ResponsePromociones guardarPromocion(ENPromociones paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponsePromociones>(clients.Post<ENPromociones>("Promociones/guardarPromocion", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<ResponsePromociones> listaPromociones(ENPromociones paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ResponsePromociones>>(clients.Post<ENPromociones>("Promociones/listaPromociones", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ResponsePromociones eliminarPromociones(ENPromociones paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponsePromociones>(clients.Post<ENPromociones>("Promociones/eliminarPromociones", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResponsePromociones obtEditarPromo(ENPromociones paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponsePromociones>(clients.Post<ENPromociones>("Promociones/obtEditarPromo", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ResponsePromociones editarPromocion(ENPromociones paramss, string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponsePromociones>(clients.Post<ENPromociones>("Promociones/editarPromocion", paramss, token));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}
