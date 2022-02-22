using sistemadeinventario.entity.Parametros;
using sistemadeinventario.entity.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemadefacturacion.datos
{
    public class DALogin
    {
        public ResponseLogin Authenticate(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseLogin>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_validarUserToken", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usertoken", paramss.usertoken));
                    cmd.Parameters.Add(new SqlParameter("@passwordtoken", paramss.passwordtoken));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseLogin();
                            result.responsetoken = Convert.ToString(rdr["response"]);
                            lista.Add(result);

                        }
                    }
                }
                return lista.FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
          public ResponseLogin Acceder(ENLogin paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseLogin>();

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_ValidarAccesos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.pass));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseLogin();
                            resul.response = Convert.ToString(rdr["response"]);
                            resul.username = Convert.ToString(rdr["username"]);
                            resul.cargo = Convert.ToString(rdr["cargo"]);
                            resul.cantaccesos = Convert.ToInt32(rdr["cantaccesos"]);
                            resul.ruc = Convert.ToString(rdr["ruc"]);
                            resul.ventas = Convert.ToInt32(rdr["ventas"]);
                            resul.caja = Convert.ToInt32(rdr["caja"]);
                            resul.clientes = Convert.ToInt32(rdr["clientes"]);
                            resul.compras = Convert.ToInt32(rdr["compras"]);
                            resul.productos = Convert.ToInt32(rdr["productos"]);
                            resul.inventario = Convert.ToInt32(rdr["invetarios"]);
                            resul.proveedor = Convert.ToInt32(rdr["proveedores"]);
                            resul.dashboard = Convert.ToInt32(rdr["dashboard"]);
                            resul.usuarios = Convert.ToInt32(rdr["usuarios"]);
                            resul.empresa = Convert.ToInt32(rdr["empresa"]);
                            resul.configuraciones = Convert.ToInt32(rdr["configuraciones"]);
                          
                            lista.Add(resul);
                        }
                    }
                }
                return lista.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
