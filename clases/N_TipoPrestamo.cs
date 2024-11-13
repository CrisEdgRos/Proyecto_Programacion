using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_TipoPrestamo
    {
        public static DataTable Listado_tipoPrestamo(string cTexto)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Listado_tipoPrestamo(cTexto);
        }

        public static string Guardar_tipoPrestamo(int nOpcion, E_TipoPrestamo oCl)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo(); ;
            return Datos.Guardar_tipoPrestamo(nOpcion, oCl);
        }

        public static string Eliminar_tipoPrestamo(int ID_TP_PRESTAMO)
        {
            D_TipoPrestamo Datos = new D_TipoPrestamo();
            return Datos.Eliminar_tipoPrestamo(ID_TP_PRESTAMO);
        }
        
    }
}
