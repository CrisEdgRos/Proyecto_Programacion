using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class N_Prestamos
    {
        public static DataTable ListadoPrestamoGeneral(string cTexto)
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.ListadoPrestamosGenerales(cTexto);
        }

        public static string Guardar_prestamos(int nOpcion, E_Prestamos oCl)
        {
            D_Prestamos Datos = new D_Prestamos(); ;
            return Datos.GuardarPrestamos(nOpcion, oCl);
        }

        public static string Eliminar_prestamos(int Codigo_cl)
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.EliminarPrestamos(Codigo_cl);
        }

        public static DataTable prestamoCliente()
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.prestamoCliente();
        }

        public static DataTable prestamoCuenta()
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.prestamoCuenta();
        }

        public static DataTable prestamoTarjetaCredito()
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.prestamoTarjetaCredito();
        }

        public static DataTable prestamoTipoPrestamo()
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.prestamoTipoPrestamo();
        }

        public static DataTable prestamoTipoPago()
        {
            D_Prestamos Datos = new D_Prestamos();
            return Datos.prestamoTipoPago();
        }
    }
}
