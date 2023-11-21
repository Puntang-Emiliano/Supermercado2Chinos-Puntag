using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {    
            private CD_Cliente objcd_Cliente = new CD_Cliente();
            public List<Cliente> Listar()
            {
                return objcd_Cliente.Listar();
            }

            public int Registrar(Cliente obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Clientes
            {
                Mensaje = string.Empty;

                if (obj.Documento == "")
                {
                    Mensaje += "Es necesario el Documento del Cliente\n";
                }

                if (obj.NombreCompleto == "")
                {
                    Mensaje += "Es necesario el Nombre Completo del Cliente\n";
                }

                if (obj.Correo == "")
                {
                    Mensaje += "Es necesario el Correo del Cliente\n";
                }

                if (Mensaje != string.Empty)
                {
                    return 0;
                }
                else
                {
                    return objcd_Cliente.Registrar(obj, out Mensaje);
                }

            }

            public bool Editar(Cliente obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Clientes
            {
                Mensaje = string.Empty;

                if (obj.Documento == "")
                {
                    Mensaje += "Es necesario el Documento del Cliente\n";
    }

                if (obj.NombreCompleto == "")
                {
                     Mensaje += "Es necesario el Nombre Completo del Cliente\n";
                }

                if (obj.Correo == "")
                {
                    Mensaje += "Es necesario el Correo del Cliente\n";
                }

                if (Mensaje != string.Empty)
                {
                    return false;
                }
                else
                {
                    return objcd_Cliente.Editar(obj, out Mensaje);
                }

            }


            public bool Eliminar(Cliente obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Clientes
            {
                return objcd_Cliente.Eliminar(obj, out Mensaje);
            }

        }

 
}
