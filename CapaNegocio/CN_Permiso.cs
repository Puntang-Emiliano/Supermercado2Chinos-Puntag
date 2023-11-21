using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad1;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        

        private CD_Permiso objcd_Permiso = new CD_Permiso();
        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_Permiso.Listar(IdUsuario);
        }




    }
}
