using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Supermercado
    {
        private CD_Supermercado objcd_negcio = new CD_Supermercado();
        public Supermercado Datos()
        {
            return objcd_negcio.Datos();
        }

        public bool GuardarDatos(Supermercado obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Usuarios
        {
            Mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario registrar el nombre\n";
            }

            if (obj.CUIT == "")
            {
                Mensaje += "Es necesario registrar el CUIT\n";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Es necesario registrar la direccion\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_negcio.GuardarDatos(obj, out Mensaje);
            }

        }
        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objcd_negcio.ObtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen ,out string mensaje)
        {
            return objcd_negcio.ActualizarLogo(imagen, out mensaje);
        }



    }
}
