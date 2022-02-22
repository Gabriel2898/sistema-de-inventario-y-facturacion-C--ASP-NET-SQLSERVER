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
    public class DAPaises
    {
        public List<ResponsePais> listarPaises(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePais>();
                using (SqlConnection conn=new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarPaises", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while(rdr.Read())
                        {
                            var result = new ResponsePais();
                            result.idpais = Convert.ToInt32(rdr["idpais"]);
                            result.pais = Convert.ToString(rdr["pais"]);
                            lista.Add(result);

                        }
                    }
                }
                return lista;

            }catch(Exception ex)
            {
                throw ex;
            }

        }
        public List<ResponseMoneda> listarMoneda (ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseMoneda>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarMoneda", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseMoneda();
                            result.idmoneda = Convert.ToInt32(rdr["idmoneda"]);
                            result.moneda = Convert.ToString(rdr["moneda"]);
                            lista.Add(result);

                        }
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<ResponseTipoImpuesto> listarTipoImpuesto(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseTipoImpuesto>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarTImpuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseTipoImpuesto();
                            result.idtimpuestos = Convert.ToInt32(rdr["idtimpuestos"]);
                            result.impuestos = Convert.ToString(rdr["impuestos"]);
                            lista.Add(result);

                        }
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<ResponsePorcentaje> listarPorcentaje(ENRegistroEmpresa paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponsePorcentaje>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarPImpuestos", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponsePorcentaje();
                            result.idpimpuestos = Convert.ToInt32(rdr["idpimpuestos"]);
                            result.pimpuestos = Convert.ToInt32(rdr["pimpuestos"]);
                            lista.Add(result);

                        }
                    }
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
