using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_TipoCuentas
    {
        public static DataTable Listado_tipoCuenta(string cTexto)
        {
            D_TipoCuentas Datos = new D_TipoCuentas();
            return Datos.Listado_tipoCuenta(cTexto);
        }

        public static string Guardar_tipoCuenta(int nOpcion, E_TipoCuentas oCl)
        {
            D_TipoCuentas Datos = new D_TipoCuentas(); ;
            return Datos.Guardar_tipoCuenta(nOpcion, oCl);
        }

        public static string Eliminar_tipoCuenta(int Codigo_cl)
        {
            D_TipoCuentas Datos = new D_TipoCuentas();
            return Datos.Eliminar_tipoCuenta(Codigo_cl);
        }
    }
}
