using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objcd_Categoria = new CD_Categoria();
        public List<Categoria> Listar()
        {
            return objcd_Categoria.Listar();
        }

        public int Registrar(Categoria obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Categorias
        {
            Mensaje = string.Empty;

          
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion de la  Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_Categoria.Registrar(obj, out Mensaje);
            }

        }

        public bool Editar(Categoria obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Categorias
        {
            Mensaje = string.Empty;
            if (obj.Descripcion == "")
            {
                Mensaje += "Es necesario la Descripcion de la  Categoria\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_Categoria.Editar(obj, out Mensaje);
            }

        }


        public bool Eliminar(Categoria obj, out string Mensaje) // LLAMAMOS EL METODO CREADO EN LA CAPA DE DATOS CD_Categorias
        {
            return objcd_Categoria.Eliminar(obj, out Mensaje);
        }


    }
}
