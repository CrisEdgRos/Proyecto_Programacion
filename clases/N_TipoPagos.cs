using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_TipoPagos
    {
        public static DataTable Listado_tipoPago(string cTexto)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Listado_tipoPago(cTexto);
        }
        
        public static string Guardar_tipoPago(int nOpcion, E_TipoPagos oCl)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Guardar_tipoPago(nOpcion, oCl);
        }

        public static string Eliminar_tipoPago(int ID_TP_PAGO)
        {
            D_TipoPagos Datos = new D_TipoPagos();
            return Datos.Eliminar_tipoPago(ID_TP_PAGO);
        }
        
    }
}
