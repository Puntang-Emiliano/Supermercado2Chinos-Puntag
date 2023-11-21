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
    public class CD_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder(); // los queryappendline permite los saltos de linea
                    query.AppendLine("select IdCategoria, Descripcion,Estado from CATEGORIA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // se encarga de ejecutar los comandos
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Categoria>();
                }
            }
            return lista;
        }

        // Procedimiento registrar Categoria
        public int Registrar(Categoria obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            int idCategoriagenerado = 0;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarCategoria", oconexion);                         //Parametros de entrada
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);                                 //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;        //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.CommandType = CommandType.StoredProcedure;                                               // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idCategoriagenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idCategoriagenerado = 0;
                Mensaje = ex.Message;
            }
            return idCategoriagenerado;
        }


        // Procedimiento editar Categoria

        public bool Editar(Categoria obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EditarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);                                 //Parametros de entrada                                                     
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);                                 //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;        //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;                                               // informa que el comando que se ejecuta es un procedimiento de almacenamoento

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


        // Procedimiento Eliminar Categoria


        public bool Eliminar(Categoria obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EiminarCategoria", oconexion);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.IdCategoria);                                    //Parametros de entrada  
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;           //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;    //Parametros de Salida del procedimieto de almacenamiento
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
