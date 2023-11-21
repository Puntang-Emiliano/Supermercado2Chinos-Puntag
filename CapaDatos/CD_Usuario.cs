using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaEntidad1;
using System.ComponentModel.Design;
using System.Reflection;
using System.Collections;
using System.Security.Claims;
using System.Xml.Linq;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // los queryappendline permite los saltos de linea
                    query.AppendLine("select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.descripcion from usuario u"); 
                    query.AppendLine("inner join ROL r on r.IdRol = u.IdRol");

                    //
                    


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // se encarga de ejecutar los comandos
                    cmd.CommandType= CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr= cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }
                } catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }             
            return lista;     
        }

        // Procedimiento registrar Usuario
        public int Registrar(Usuario obj , out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            int idusuariogenerado = 0;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                  
                    SqlCommand cmd = new SqlCommand("SP_REGISTRARUSUARIO", oconexion);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);                        //Parametros de entrada
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);                   //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada

                    cmd.Parameters.Add("IdUsuarioResultado",SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idusuariogenerado = Convert.ToInt32(cmd.Parameters["IdUsuarioResultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idusuariogenerado = 0;
                Mensaje= ex.Message;                
            }





            return idusuariogenerado;
        }


        // Procedimiento editar Usuario

        public bool Editar(Usuario obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EDITARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);                //Parametros de entrada                                                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);                        //Parametros de entrada
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);                   //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada

                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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


        // Procedimiento eliminar Usuario


        public bool Eliminar(Usuario obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ELIMINARUSUARIO", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);                //Parametros de entrada                                                      //Parametros de entrada
                    
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["respuesta"].Value);
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
