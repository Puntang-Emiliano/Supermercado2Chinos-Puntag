using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // los queryappendline permite los saltos de linea
                    query.AppendLine("select IdProveedor,Documento,RazonSocial,Correo,Telefono,Estado from PROVEEDOR");
                 

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // se encarga de ejecutar los comandos
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                IdProveedor = Convert.ToInt32(dr["IdProveedor"]),
                                Documento = dr["Documento"].ToString(),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]) 
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Proveedor>();
                }
            }
            return lista;
        }

        // Procedimiento registrar Proveedor
        public int Registrar(Proveedor obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            int idProveedorgenerado = 0;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarProveedor", oconexion);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);                        //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idProveedorgenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProveedorgenerado = 0;
                Mensaje = ex.Message;
            }





            return idProveedorgenerado;
        }


        // Procedimiento editar Proveedor

        public bool Editar(Proveedor obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarProveedor", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);                //Parametros de entrada                                                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("RazonSocial", obj.RazonSocial);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);                        //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }





            return respuesta;
        }


        // Procedimiento eliminar Proveedor


        public bool Eliminar(Proveedor obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_EliminarProveedor", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.IdProveedor);                //Parametros de entrada                                                      //Parametros de entrada

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }

            return respuesta;
        }


    }
}
