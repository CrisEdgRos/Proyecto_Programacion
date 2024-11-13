using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_Tarjetas
    {
        public static DataTable Listado_tarjeta(string cTexto)
        {
            D_Tarjetas Datos = new D_Tarjetas();
            return Datos.Listado_tarjeta(cTexto);
        }
        
        public static string Guardar_tarjeta(int nOpcion, E_Tarjetas oCl)
        {
            D_Tarjetas Datos = new D_Tarjetas(); ;
            return Datos.Guardar_tarjeta(nOpcion, oCl);
        }

        public static string Eliminar_tarjeta(int ID_TARJETA_CREDITO)
        {
            D_Tarjetas Datos = new D_Tarjetas();
            return Datos.Eliminar_tarjeta(ID_TARJETA_CREDITO);
        }
        
        public static DataTable TARJETA_CLIENE()
        {
            D_Tarjetas Datos = new D_Tarjetas();
            return Datos.TARJETA_CLIENTE();
        }

        public static DataTable TARJETA_CUENTA(int ID_CLIENTE)
        {
            D_Tarjetas Datos = new D_Tarjetas();
            return Datos.TARJETA_CUENTA(ID_CLIENTE);
        }

        public static DataTable TARJETA_CREDITO()
        {
            D_Tarjetas Datos = new D_Tarjetas();
            return Datos.TIPO_TARJETA_CREDITO();
        }
    }
}
