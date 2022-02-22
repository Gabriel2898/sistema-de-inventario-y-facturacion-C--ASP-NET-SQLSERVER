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
   public  class DAEmpleados
    {
        public ResponseEmpleados validarCantUsers(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_validarCantUsers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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
        public List<ResponseEmpleados> listaEmpleados(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_listarEmpleados", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@cargo", paramss.slcargo));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
                            result.iduser = Convert.ToInt32(rdr["idusuario"]);
                            result.username = Convert.ToString(rdr["username"]);
                            result.user = Convert.ToString(rdr["usuario"]);
                            result.dni = Convert.ToString(rdr["dni"]);
                            result.email = Convert.ToString(rdr["email"]);
                            result.cargo = Convert.ToString(rdr["cargo"]);
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

        public ResponseEmpleados activarEmpleado(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_activarEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iduser", paramss.iduser));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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
        public ResponseEmpleados desactivarEmpleado(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_desactivarEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iduser", paramss.iduser));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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

        public ResponseEmpleados eliminarEmpleado(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_eliminarEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iduser", paramss.iduser));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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
        public ResponseEmpleados obteditarEmpleado(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_obteditarEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iduser", paramss.iduser));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@cargosession", paramss.slcargo));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var resul = new ResponseEmpleados();
                            resul.response = Convert.ToString(rdr["response"]);
                            if (resul.response == "ok")
                            {
                                resul.iduser = Convert.ToInt32(rdr["idusuario"]);
                                resul.username = Convert.ToString(rdr["username"]);
                                resul.dni = Convert.ToString(rdr["dni"]);
                                resul.email = Convert.ToString(rdr["email"]);
                                resul.user = Convert.ToString(rdr["usuario"]);
                                resul.idcargo = Convert.ToInt32(rdr["idcargo"]);
                                resul.cargo = Convert.ToString(rdr["cargo"]);
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


                            }
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
        public List<ResponseEmpleados> listarCargos(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("ups_listarCargosEmpleado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
                            result.idcargo = Convert.ToInt32(rdr["idcargo"]);
                            result.cargo = Convert.ToString(rdr["cargo"]);
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

        public ResponseEmpleados registrarUsuario(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_registrarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc)); 
                    cmd.Parameters.Add(new SqlParameter("@nombre", paramss.nombre));
                    if (paramss.dni != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@dni", paramss.dni));

                    }
                    else
                    {

                        cmd.Parameters.Add(new SqlParameter("@dni", ""));
                    }
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.password));
                    cmd.Parameters.Add(new SqlParameter("@slcargo", paramss.slcargo));/*acceso*/  
                    cmd.Parameters.Add(new SqlParameter("@ventas", paramss.ventas));
                    cmd.Parameters.Add(new SqlParameter("@clientes", paramss.clientes));
                    cmd.Parameters.Add(new SqlParameter("@caja", paramss.caja));
                    cmd.Parameters.Add(new SqlParameter("@compras", paramss.compras));
                    cmd.Parameters.Add(new SqlParameter("@productos", paramss.productos));
                    cmd.Parameters.Add(new SqlParameter("@inventarios", paramss.inventario));
                    cmd.Parameters.Add(new SqlParameter("@proveedores", paramss.proveedor));
                    cmd.Parameters.Add(new SqlParameter("@dashboard", paramss.dashboard));
                    cmd.Parameters.Add(new SqlParameter("@usuarios", paramss.usuarios));
                    cmd.Parameters.Add(new SqlParameter("@empresa", paramss.empresa));
                    cmd.Parameters.Add(new SqlParameter("@configuraciones", paramss.configuraciones));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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


        public ResponseEmpleados editarEmpleado(ENEmpleados paramss)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                var lista = new List<ResponseEmpleados>();
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("usp_editarUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iduser", paramss.iduser));
                    cmd.Parameters.Add(new SqlParameter("@ruc", paramss.ruc));
                    cmd.Parameters.Add(new SqlParameter("@nombre", paramss.nombre));
                    if (paramss.dni != null)
                    {
                        cmd.Parameters.Add(new SqlParameter("@dni", paramss.dni));

                    }
                    else
                    {

                        cmd.Parameters.Add(new SqlParameter("@dni", ""));
                    }
                    cmd.Parameters.Add(new SqlParameter("@email", paramss.email));
                    cmd.Parameters.Add(new SqlParameter("@user", paramss.user));
                    cmd.Parameters.Add(new SqlParameter("@password", paramss.password));
                    cmd.Parameters.Add(new SqlParameter("@slcargo", paramss.slcargo));/*acceso*/
                    cmd.Parameters.Add(new SqlParameter("@ventas", paramss.ventas));
                    cmd.Parameters.Add(new SqlParameter("@clientes", paramss.clientes));
                    cmd.Parameters.Add(new SqlParameter("@caja", paramss.caja));
                    cmd.Parameters.Add(new SqlParameter("@compras", paramss.compras));
                    cmd.Parameters.Add(new SqlParameter("@productos", paramss.productos));
                    cmd.Parameters.Add(new SqlParameter("@inventario", paramss.inventario));
                    cmd.Parameters.Add(new SqlParameter("@proveedor", paramss.proveedor));
                    cmd.Parameters.Add(new SqlParameter("@dashboard", paramss.dashboard));
                    cmd.Parameters.Add(new SqlParameter("@usuarios", paramss.usuarios));
                    cmd.Parameters.Add(new SqlParameter("@empresa", paramss.empresa));
                    cmd.Parameters.Add(new SqlParameter("@configuraciones", paramss.configuraciones));
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var result = new ResponseEmpleados();
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
