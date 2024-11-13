using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Clave3_Grupo4
{
    public class D_MovimientoAbono
    {
        Conexion conMysql = new Conexion();
        public DataTable ListadoMV_abonoGenerales(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_ABONO, B.ID_CUENTA, C.ID_PRESTAMO, D.ID_CLIENTE, E.ID_EM, " +
                    "F.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, D.NOM_CLIENTE, D.APE_PATE_CLIENTE, D.APE_MATE_CLIENTE," +
                    "F.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, E.NOM_EMPLEADO, E.APE_PATE, E.APE_MATE, C.MONTO_PRESTADO " +
                    "FROM TB_MOVIMIENTO_ABONO A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO " +
                    "INNER JOIN TB_CLIENTE  D ON D.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO E ON E.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA G ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE H  ON H.ID_TP_PERSONA = D.ID_TP_PERSONA " +
                    "INNER JOIN TB_TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO " +
                    "INNER JOIN TB_TIPO_PAGO J ON J.ID_TP_PAGO = C.ID_TP_PAGO " +
                    "INNER JOIN TB_CARGO_EMPLEADO K ON K.ID_CARGO_EM = E.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' " +
                    "AND( D.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "D.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "D.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_ABONO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public DataTable Listado_AbonosCaidos(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_ABONO, B.ID_CUENTA, C.ID_PRESTAMO, D.ID_CLIENTE, E.ID_EM, " +
                    "F.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, D.NOM_CLIENTE, D.APE_PATE_CLIENTE, D.APE_MATE_CLIENTE," +
                    "F.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, E.NOM_EMPLEADO, E.APE_PATE, E.APE_MATE, C.MONTO_PRESTADO " +
                    "FROM TB_MOVIMIENTO_ABONO A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO " +
                    "INNER JOIN TB_CLIENTE  D ON D.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO E ON E.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA G ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE H  ON H.ID_TP_PERSONA = D.ID_TP_PERSONA " +
                    "INNER JOIN TB_TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO " +
                    "INNER JOIN TB_TIPO_PAGO J ON J.ID_TP_PAGO = C.ID_TP_PAGO " +
                    "INNER JOIN TB_CARGO_EMPLEADO K ON K.ID_CARGO_EM = E.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'I' " +
                    "AND( D.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "D.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "D.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_ABONO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        
        public DataTable Listado_ClientesPrincipales(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_ABONO, B.ID_CUENTA, C.ID_PRESTAMO, D.ID_CLIENTE, E.ID_EM, " +
                    "F.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, D.NOM_CLIENTE, D.APE_PATE_CLIENTE, D.APE_MATE_CLIENTE," +
                    "F.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, E.NOM_EMPLEADO, E.APE_PATE, E.APE_MATE, C.MONTO_PRESTADO " +
                    "FROM TB_MOVIMIENTO_ABONO A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_PRESTAMO C ON C.ID_PRESTAMO = A.ID_PRESTAMO " +
                    "INNER JOIN TB_CLIENTE  D ON D.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO E ON E.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL F ON F.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA G ON G.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE H  ON H.ID_TP_PERSONA = D.ID_TP_PERSONA " +
                    "INNER JOIN TB_TIPO_PRESTAMO I ON I.ID_TP_PRESTAMO = C.ID_TP_PRESTAMO " +
                    "INNER JOIN TB_TIPO_PAGO J ON J.ID_TP_PAGO = C.ID_TP_PAGO " +
                    "INNER JOIN TB_CARGO_EMPLEADO K ON K.ID_CARGO_EM = E.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' " +
                    "AND( D.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "D.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "D.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_ABONO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string GuardarMV_abono(int nOpcion, E_MovimientoAbono oCl)
        {
            string Rpta = "";
            try
            {
                MySqlParameter param1 = new MySqlParameter("@nOpcion", MySqlDbType.Int32) { Value = nOpcion };
                MySqlParameter param2 = new MySqlParameter("@cID_MV_ABONO", MySqlDbType.Int32) { Value = oCl.ID_MV_ABONO };
                MySqlParameter param3 = new MySqlParameter("@cID_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_CUENTA };
                MySqlParameter param4 = new MySqlParameter("@cID_PRESTAMO", MySqlDbType.Int32) { Value = oCl.ID_PRESTAMO };
                MySqlParameter param5 = new MySqlParameter("@cID_CLIENTE", MySqlDbType.Int32) { Value = oCl.ID_CLIENTE };
                MySqlParameter param6 = new MySqlParameter("@cID_EM", MySqlDbType.Int32) { Value = oCl.ID_EM };
                MySqlParameter param7 = new MySqlParameter("@cID_SUCURSAL", MySqlDbType.Int32) { Value = oCl.ID_SUCURSAL };
                MySqlParameter param8 = new MySqlParameter("@cMONTO_SALIDA", MySqlDbType.Decimal) { Value = oCl.MONTO_SALIDA };

                Rpta = conMysql.ExecuteProcedure("P_GuardarMovimientoAbono", param1, param2, param3, param4, param5, param6, param7, param8);
                Rpta = Convert.ToInt32(Rpta) > 0 ? "OK" : "No se pudieron registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string EliminarMV_abono(int ID_MV_ABONO)
        {
            string Rpta = "";
            try
            {
               Rpta = String.Format("update TB_MOVIMIENTO_ABONO set " +
                   "ESTADO = 'I' where ID_MV_ABONO = {0} ", ID_MV_ABONO);
               Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        
        public string Levantar_abonosCaidos(int ID_MV_ABONO)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("update TB_MOVIMIENTO_ABONO set " +
                    "ESTADO = 'A' where ID_MV_ABONO = {0} ", ID_MV_ABONO);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable MV_abonoCuenta()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT   A.ID_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, " +
                    "A.CODIGO_CUENTA FROM TB_CUENTA A, TB_CLIENTE B " +
                    "WHERE    A.ID_CLIENTE = B.ID_CLIENTE AND B.ESTADO = 'A' AND A.ESTADO = 'A'" +
                    " ORDER BY A.ID_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_abonoPrestamo()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_PRESTAMO, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, " +
                    "A.MONTO_PRESTADO, A.MTCN_PRESTAMO FROM TB_PRESTAMO A, TB_CLIENTE B " +
                    "WHERE B.ESTADO = 'A' AND A.ESTADO = 'A' AND A.ID_CLIENTE = B.ID_CLIENTE " +
                    "ORDER BY A.ID_PRESTAMO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_abonoCliente()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT   ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE " +
                    "FROM TB_CLIENTE WHERE ESTADO = 'A' ORDER BY ID_CLIENTE DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_abonoEmpleado()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_EM, NOM_EMPLEADO, APE_PATE, APE_MATE " +
                    "FROM TB_EMPLEADO " +
                    "WHERE    ESTADO = 'A' ORDER BY ID_EM DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_abonoSucursal()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_SUCURSAL, DIRECCION FROM TB_SUCURSAL WHERE ESTADO = 'A' " +
                    "ORDER BY ID_SUCURSAL DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
    }
}