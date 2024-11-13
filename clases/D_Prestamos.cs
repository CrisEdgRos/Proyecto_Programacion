using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_Prestamos
    {
        Conexion conMysql = new Conexion();
        public DataTable ListadoPrestamosGenerales(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select " +
                    "O.ID_PRESTAMO, " +
                    "O.FECHA_REGISTRO, " +
                    "M.NOM_CUENTA, " +
                    "E.CODIGO_CUENTA, " +
                    "Y.NOM_TARJETA, " +
                    "S.CODIGO_TARJETA, " +
                    "O.ID_CLIENTE, " +
                    "O.ID_CUENTA, " +
                    "O.ID_TARJETA_CREDITO, " +
                    "O.ID_TP_PRESTAMO, " +
                    "O.ID_TP_PAGO, " +
                    "O.MONTO_PRESTADO, " +
                    "O.MTCN_PRESTAMO, " +
                    "A.NOM_PRESTAMO, " +
                    "R.TIPO_COBRO, " +
                    "C.NOM_CLIENTE, " +
                    "C.APE_PATE_CLIENTE, " +
                    "C.APE_MATE_CLIENTE " +
                    "FROM TB_PRESTAMO O " +
                    "INNER JOIN TB_CLIENTE         C ON O.ID_CLIENTE = C.ID_CLIENTE " +
                    "INNER JOIN TB_CUENTA          E ON O.ID_CUENTA = E.ID_CUENTA " +
                    "INNER JOIN TB_TARJETA_CREDITO S ON O.ID_TARJETA_CREDITO = S.ID_TARJETA_CREDITO " +
                    "INNER JOIN TB_TIPO_PRESTAMO   A ON O.ID_TP_PRESTAMO = A.ID_TP_PRESTAMO " +
                    "INNER JOIN TB_TIPO_PAGO       R ON O.ID_TP_PAGO = R.ID_TP_PAGO " +
                    "INNER JOIN TB_TIPO_CUENTA     M ON M.ID_TIPO_CUENTA = E.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_TARJETA_CREDITO Y ON Y.ID_TP_TARJETA = S.ID_TP_TARJETA " +
                    "WHERE O.ESTADO = 'A' " +
                    "AND( " +
                    "C.NOM_CLIENTE       LIKE '%" + cTexto + "%' " +
                    "OR C.APE_PATE_CLIENTE  LIKE '%" + cTexto + "%' " +
                    "OR C.APE_MATE_CLIENTE  LIKE '%" + cTexto + "%' ) " +
                    "ORDER BY O.ID_PRESTAMO DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string GuardarPrestamos(int nOpcion, E_Prestamos oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_PRESTAMO (ID_CLIENTE, ID_CUENTA, ID_TARJETA_CREDITO, " +
                        "ID_TP_PRESTAMO, ID_TP_PAGO, MONTO_PRESTADO, MTCN_PRESTAMO, ESTADO)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}',0,'A')", oCl.ID_CLIENTE, oCl.ID_CUENTA, oCl.ID_TARJETA_CREDITO, oCl.ID_TP_PRESTAMO, oCl.ID_TP_PAGO, oCl.MONTO_PRESTADO);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_PRESTAMO set ID_CLIENTE = '{0}', ID_CUENTA = '{1}', ID_TARJETA_CREDITO = '{2}', " +
                        " ID_TP_PRESTAMO = '{3}', MONTO_PRESTADO = '{4}' where ID_PRESTAMO = {5} ",
                        oCl.ID_CLIENTE, oCl.ID_CUENTA, oCl.ID_TARJETA_CREDITO, oCl.ID_TP_PRESTAMO, oCl.MONTO_PRESTADO, oCl.ID_PRESTAMO);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string EliminarPrestamos(int ID_PRESTAMO)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_PRESTAMO where ID_PRESTAMO= '{0}'", ID_PRESTAMO);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable prestamoCliente()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData(" SELECT ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE " +
                    "FROM TB_CLIENTE WHERE ESTADO = 'A' ORDER BY ID_CLIENTE DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        
        public DataTable prestamoCuenta()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT B.ID_CUENTA, B.CODIGO_CUENTA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, " +
                    "C.APE_MATE_CLIENTE " +
                    "FROM TB_CUENTA B, TB_CLIENTE C " +
                    "WHERE C.ID_CLIENTE = B.ID_CLIENTE AND B.ESTADO = 'A' AND C.ESTADO = 'A' " +
                    "ORDER BY B.ID_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable prestamoTarjetaCredito()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT   A.ID_TARJETA_CREDITO, A.CODIGO_TARJETA, C.NOM_CLIENTE, " +
                    "C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE " +
                    "FROM     TB_TARJETA_CREDITO A, TB_CLIENTE C " +
                    "WHERE    A.ID_CLIENTE = C.ID_CLIENTE AND A.ESTADO = 'A' AND C.ESTADO = 'A' " +
                    "ORDER BY A.ID_TARJETA_CREDITO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable prestamoTipoPrestamo()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT   ID_TP_PRESTAMO, NOM_PRESTAMO " +
                    "FROM TB_TIPO_PRESTAMO " +
                    "WHERE ESTADO = 'A' ORDER BY ID_TP_PRESTAMO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable prestamoTipoPago()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_TP_PAGO, TIPO_COBRO " +
                    "FROM TB_TIPO_PAGO WHERE ESTADO = 'A' " +
                    "ORDER BY ID_TP_PAGO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
    }
}
