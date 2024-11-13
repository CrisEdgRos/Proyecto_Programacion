using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_TipoClientes
    {
        public static DataTable Listado_tp_cl(string cTexto)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Listado_tp_cl(cTexto);
        }

        public static string Guardar_tp_cl(int nOpcion, E_TipoClientes oCl)
        {
            D_TipoClientes Datos = new D_TipoClientes(); ;
            return Datos.Guardar_tp_cl(nOpcion, oCl);
        }
        
        public static string Eliminar_tp_cl(int ID_TP_PERSONA)
        {
            D_TipoClientes Datos = new D_TipoClientes();
            return Datos.Eliminar_tp_cl(ID_TP_PERSONA);
        }

    }
}
