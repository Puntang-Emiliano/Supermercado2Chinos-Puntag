using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad1;
using System.Xml.Linq;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_usuario = new CD_Usuario();
        public List<Usuario> Listar()
        {
            return objcd_usuario.Listar();
        }

        public int Registrar(Usuario obj,out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Usuarios
        {
            Mensaje= string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }

            if (obj.NombreCompleto=="")
            {
                Mensaje += "Es necesario el Nombre Completo del Usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario el Clave del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else 
            {
                return objcd_usuario.Registrar(obj, out Mensaje);
            }
            
        }

        public bool Editar(Usuario obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Usuarios
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el Nombre Completo del Usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario el Clave del Usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_usuario.Editar(obj, out Mensaje);
            }
           
        }


        public bool Eliminar(Usuario obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Usuarios
        {
            return objcd_usuario.Eliminar(obj, out Mensaje);
        }

    }
}
