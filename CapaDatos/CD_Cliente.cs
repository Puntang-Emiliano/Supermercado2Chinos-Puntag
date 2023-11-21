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
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // los queryappendline permite los saltos de linea
                    query.AppendLine("select IdCliente,Documento,NombreCompleto,Correo,Telefono,Estado from CLIENTE");
                 
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // se encarga de ejecutar los comandos
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }
            return lista;
        }

        //---------------------Procedimiento registrar Cliente--------------------------------------------------------
        public int Registrar(Cliente obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            int idClientegenerado = 0;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", oconexion);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);                  //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idClientegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idClientegenerado = 0;
                Mensaje = ex.Message;
            }





            return idClientegenerado;
        }


        // ----------------------------------------Procedimiento editar Cliente

        public bool Editar(Cliente obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_ModificarCliente", oconexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);                //Parametros de entrada                                                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Documento", obj.Documento);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("NombreCompleto", obj.NombreCompleto);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);                  //Parametros de entrada
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


        // ------------------------------------Procedimiento eliminar Cliente


        public bool Eliminar(Cliente obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", obj.IdCliente);        //Parametros de entrada     
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    respuesta = cmd.ExecuteNonQuery()> 0 ? true : false; // compara si el numero de filas afectas es mayor a 0 (elimino algo )devuelve true
                                     
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

