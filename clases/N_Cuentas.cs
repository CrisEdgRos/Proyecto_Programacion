using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_Cuentas
    {
        public static DataTable Listado_cuenta(string cTexto)
        {
            D_Cuentas Datos = new D_Cuentas();
            return Datos.Listado_cuenta(cTexto);
        }

        public static string Guardar_cuenta(int nOpcion, E_Cuentas oCl)
        {
            D_Cuentas Datos = new D_Cuentas(); 
            return Datos.Guardar_cuenta(nOpcion, oCl);
        }

        public static string Eliminar_cuenta(int ID_CUENTA)
        {
            D_Cuentas Datos = new D_Cuentas();
            return Datos.Eliminar_cuenta(ID_CUENTA);
        }

        public static DataTable CuentaCliente()
        {
            D_Cuentas Datos = new D_Cuentas();
            return Datos.CuentaCliente();
        }

        public static DataTable CuentaTipoCuenta()
        {
            D_Cuentas Datos = new D_Cuentas();
            return Datos.CuentaTipoCuenta();
        }
    }
}
