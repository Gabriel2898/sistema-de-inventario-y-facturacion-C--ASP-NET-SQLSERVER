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
   public class DAProveedores
    {
        public ResponseProveedores registrarProv(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_registrarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));                   
                    cmd.Parameters.Add(new SqlParameter("@telefono", paramss.telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@direccion", paramss.direccion));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();
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
        public List<ResponseProveedores> listarProveedores(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarProveedores", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();
                            result.idprov = Convert.ToInt32(rdr["idproveedor"]);
                            result.ruc = Convert.ToString(rdr["ruc"]);
                            result.razonsocial = Convert.ToString(rdr["razonsocial"]);
                            result.telefono = Convert.ToString(rdr["telefono"]);
                            result.email = Convert.ToString(rdr["email"]);
                            result.direccion = Convert.ToString(rdr["direccion"]);
                            result.status = Convert.ToInt32(rdr["status"]);
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
        public ResponseProveedores activarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_activarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();
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
        public ResponseProveedores desactivarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_desactivarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();
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

        public ResponseProveedores eliminarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_eliminarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();
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
        public ResponseProveedores obteditarProveedor(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_obteditarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();

                            result.response = Convert.ToString(rdr["response"]);
                            if (result.response == "ok")
                            {


                                result.idprov = Convert.ToInt32(rdr["idproveedor"]);
                                result.response = Convert.ToString(rdr["response"]);
                                result.ruc = Convert.ToString(rdr["ruc"]);
                                result.razonsocial = Convert.ToString(rdr["razonsocial"]);
                                result.telefono = Convert.ToString(rdr["telefono"]);
                                result.email = Convert.ToString(rdr["email"]);
                                result.direccion = Convert.ToString(rdr["direccion"]);
                            }
                          
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
        public ResponseProveedores editarProv(ENProveedores paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                var lista = new List<ResponseProveedores>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarProveedor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idprov", paramss.idprov));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@razonsocial", paramss.razonsocial));
                    cmd.Parameters.Add(new SqlParameter("@telefono", paramss.telefono));
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@direccion", paramss.direccion));
                    cmd.Parameters.Add(new SqlParameter("@rucempresa", paramss.rucempresa));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseProveedores();

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
