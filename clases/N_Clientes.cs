using System;
using System.Collections.Generic;
using System.Data;
using Clave3_Grupo4;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_Clientes
    {
        public static DataTable Listado_cl(string cTexto)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Listado_cl(cTexto);
        }

        public static string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            D_Clientes Datos = new D_Clientes(); ;
            return Datos.Guardar_cl(nOpcion, oCl);
        }

        public static string Eliminar_cl(int ID_CLIENTE)
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.Eliminar_cl(ID_CLIENTE);
        }

        public static DataTable TIPO_PERSONA()
        {
            D_Clientes Datos = new D_Clientes();
            return Datos.TIPO_PERSONA();
        }
    }
}
