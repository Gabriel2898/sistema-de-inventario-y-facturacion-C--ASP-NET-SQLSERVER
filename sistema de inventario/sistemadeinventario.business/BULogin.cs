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
    public class BULogin
    {
        private Client clients;
        public BULogin()
        {
            clients = new Client();
        }
        public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                return JsonConvert.DeserializeObject<ResponseLogin>(clients.Post<ENLogin>("Login/Acceder", paramss));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
