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
    public class D_MovimientoCuenta
    {
        Conexion conMysql = new Conexion();
        public DataTable ListadoMV_cuentaGenerales(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_CUENTA, B.ID_CUENTA, C.ID_CLIENTE, D.ID_EM, E.ID_SUCURSAL, " +
                    "A.FECHA_REGISTRO, A.MONTO_ENTRADA, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE," +
                    "E.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_CUENTA A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_CLIENTE  C ON C.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' " +
                    "AND( C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public DataTable Listado_MVcuentasCaidas(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_CUENTA, B.ID_CUENTA, C.ID_CLIENTE, D.ID_EM, E.ID_SUCURSAL, " +
                    "A.FECHA_REGISTRO, A.MONTO_ENTRADA, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE," +
                    "E.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_CUENTA A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_CLIENTE  C ON C.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'I' " +
                    "AND( C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_CUENTA DESC");
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
                Tabla = conMysql.getData("SELECT A.ID_MV_CUENTA, B.ID_CUENTA, C.ID_CLIENTE, D.ID_EM, E.ID_SUCURSAL, " +
                    "A.FECHA_REGISTRO, A.MONTO_ENTRADA, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE," +
                    "E.DIRECCION AS SUCURSAL, B.CODIGO_CUENTA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_CUENTA A " +
                    "INNER JOIN TB_CUENTA   B ON B.ID_CUENTA = A.ID_CUENTA " +
                    "INNER JOIN TB_CLIENTE  C ON C.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_EMPLEADO D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_TIPO_CUENTA F  ON F.ID_TIPO_CUENTA = B.ID_TIPO_CUENTA " +
                    "INNER JOIN TB_TIPO_CLIENTE G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_CARGO_EMPLEADO H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' " +
                    "AND( C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                    "ORDER BY A.ID_MV_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string GuardarMV_cuenta(int nOpcion, E_MovimientoCuenta oCl)
        {
            string Rpta = "";
            try
            {
                MySqlParameter param1 = new MySqlParameter("@nOpcion", MySqlDbType.Int32) { Value = nOpcion };
                MySqlParameter param2 = new MySqlParameter("@cID_MV_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_MV_CUENTA };
                MySqlParameter param3 = new MySqlParameter("@cID_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_CUENTA };
                MySqlParameter param4 = new MySqlParameter("@cID_CLIENTE", MySqlDbType.Int32) { Value = oCl.ID_CLIENTE };
                MySqlParameter param5 = new MySqlParameter("@cID_EM", MySqlDbType.Int32) { Value = oCl.ID_EM };
                MySqlParameter param6 = new MySqlParameter("@cID_SUCURSAL", MySqlDbType.Int32) { Value = oCl.ID_SUCURSAL };
                MySqlParameter param7 = new MySqlParameter("@cMONTO_ENTRADA", MySqlDbType.Decimal) { Value = oCl.MONTO_ENTRADA };
                MySqlParameter param8 = new MySqlParameter("@cMONTO_SALIDA", MySqlDbType.Decimal) { Value = oCl.MONTO_SALIDA };

                Rpta = conMysql.ExecuteProcedure("P_GuardarMovimientoCuenta", param1, param2, param3, param4, param5, param6, param7, param8);
                Rpta = Convert.ToInt32(Rpta) > 0 ? "OK" : "No se pudieron registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string EliminarMV_cuenta(int ID_MV_CUENTA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("update TB_MOVIMIENTO_CUENTA set " +
                    "ESTADO = 'I' where ID_MV_CUENTA = {0} ", ID_MV_CUENTA);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        
        public string Levantar_cuentasCaidas(int ID_MV_CUENTA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("update TB_MOVIMIENTO_CUENTA set " +
                    "ESTADO = 'A' where ID_MV_CUENTA = {0} ", ID_MV_CUENTA);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable MV_cuentaCuenta()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, " +
                    "A.CODIGO_CUENTA FROM TB_CUENTA A " +
                    "INNER JOIN TB_CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE WHERE A.ESTADO = 'A' AND B.ESTADO = 'A' " +
                    "ORDER BY A.ID_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_cuentaCliente()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE " +
                    "FROM TB_CLIENTE WHERE ESTADO = 'A' ORDER BY ID_CLIENTE DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_cuentaEmpleado()
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

        public DataTable MV_cuentaSucursal()
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
