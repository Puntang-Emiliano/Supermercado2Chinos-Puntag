using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    



                    StringBuilder query = new StringBuilder(); // los queryappendline permite los saltos de linea
                    query.AppendLine("select IdProducto, Codigo, Nombre, p.Descripcion,c.IdCategoria,c.Descripcion" +
                        "[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta,p.Estado from PRODUCTO p");
                    query.AppendLine("Inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");

                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion); // se encarga de ejecutar los comandos
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() {IdCategoria = Convert.ToInt32(dr["IdCategoria"]), 
                                Descripcion = dr["DescripcionCategoria"].ToString() },
                                Stock = Convert.ToInt32( dr["Stock"].ToString() ),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                }) ;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Producto>();
                }
            }
            return lista;
        }

        // Procedimiento registrar Producto
        public int Registrar(Producto obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            int idProductogenerado = 0;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", oconexion);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);                        //Parametros de entrada
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);                      //Parametros de entrada
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idProductogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idProductogenerado = 0;
                Mensaje = ex.Message;
            }





            return idProductogenerado;
        }


        // Procedimiento editar Producto

        public bool Editar(Producto obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_ModificarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);                //Parametros de entrada                                                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Codigo", obj.Codigo);                //Parametros de entrada
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);      //Parametros de entrada
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);                      //Parametros de entrada
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);                   //Parametros de entrada
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


        // Procedimiento eliminar Producto


        public bool Eliminar(Producto obj, out string Mensaje) // recibe la entrada a traves de OBJ  y devuelve el msj del prcedimiento de almacenado
        {
            bool respuesta = false;
            Mensaje = string.Empty;// declaramos el mensaje de salida vacio.

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", oconexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);                //Parametros de entrada                                                      //Parametros de entrada
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output; //Parametros de Salida del procedimieto de almacenamiento

                    cmd.CommandType = CommandType.StoredProcedure;  // informa que el comando que se ejecuta es un procedimiento de almacenamoento

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
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
