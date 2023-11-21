using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd_Proveedor = new CD_Proveedor();
        public List<Proveedor> Listar()
        {
            return objcd_Proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Proveedors
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el Razon Social del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Proveedor\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Proveedor obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Proveedors
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del Proveedor\n";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario el Razon Social del Proveedor\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el Correo del Proveedor\n";
            }


            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje);
            }

        }


        public bool Eliminar(Proveedor obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Proveedors
        {
            return objcd_Proveedor.Eliminar(obj, out Mensaje);
        }

    }
}
