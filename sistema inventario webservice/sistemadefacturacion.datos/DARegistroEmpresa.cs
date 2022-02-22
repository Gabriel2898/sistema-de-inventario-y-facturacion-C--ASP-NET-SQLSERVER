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
   public class DARegistroEmpresa
    {
        public ResponseRegistroEmpresa validarRegistro(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseRegistroEmpresa>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_validarRegistroEmpresa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseRegistroEmpresa();
                            result.response = Convert.ToString(rdr["response"]);
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
        public ResponseRegistroEmpresa insertarEmpresa(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseRegistroEmpresa>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insertarEmpresa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@idpais", paramss.idpais));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@idmoneda", paramss.idmoneda));
                    cmd.Parameters.Add(new SqlParameter("@direccion", paramss.direccion));
                    cmd.Parameters.Add(new SqlParameter("@idimpuesto", paramss.idimpuesto));
                    cmd.Parameters.Add(new SqlParameter("@idporcentaje", paramss.idporcentaje));
                    cmd.Parameters.Add(new SqlParameter("@vendeimpuestos", paramss.vendeimpuestos));
                    cmd.Parameters.Add(new SqlParameter("@filename", paramss.filename));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseRegistroEmpresa();
                            result.response = Convert.ToString(rdr["response"]);
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
        public ResponseRegistroEmpresa insertarUserAdminEmpresa(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseRegistroEmpresa>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_insertarUserAdminEmpresa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@username", paramss.username));
                    cmd.Parameters.Add(new SqlParameter("@usuario", paramss.usuario));
                    cmd.Parameters.Add(new SqlParameter("@contrasena", paramss.contraseña));
                    cmd.Parameters.Add(new SqlParameter("@cargo", paramss.cargo));
                    cmd.Parameters.Add(new SqlParameter("@cantuser", paramss.cantuser));
                    cmd.Parameters.Add(new SqlParameter("@proyecto", paramss.proyecto));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseRegistroEmpresa();
                            result.response = Convert.ToString(rdr["response"]);
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
        public ResponseRegistroEmpresa activarCuenta(string ruc )
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseRegistroEmpresa>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_activarCuenta", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", ruc));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseRegistroEmpresa();
                            result.response = Convert.ToString(rdr["response"]);
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
    }
}
