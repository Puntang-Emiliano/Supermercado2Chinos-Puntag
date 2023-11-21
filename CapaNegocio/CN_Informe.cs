using CapaDatos;
using CapaEntidad1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Informe
    {

        private CD_Imformes objcd_informe = new CD_Imformes();

        public List<InformeCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            return objcd_informe.Compra(fechainicio, fechafin, idproveedor);
        }

        public List<InformeVenta> Venta(string fechainicio, string fechafin)
        {
            return objcd_informe.Venta(fechainicio, fechafin);
        }
    }
}
