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
    public class D_MovimientoTarjeta
    {
        Conexion conMysql = new Conexion();

        public DataTable ListadoMV_tarjetaGenerales(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_MV_TARJETA, B.ID_TARJETA_CREDITO, C.ID_CLIENTE, D.ID_EM, " +
                    "E.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, " +
                    "C.APE_MATE_CLIENTE, E.DIRECCION, B.CODIGO_TARJETA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_TARJETA A " +
                    "INNER JOIN TB_TARJETA_CREDITO B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO " +
                    "INNER JOIN TB_TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA = B.ID_TP_TARJETA " +
                    "INNER JOIN TB_CLIENTE              C ON C.ID_CLIENTE = A.ID_CLIENTE " +
                    "INNER JOIN TB_TIPO_CLIENTE         G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_EMPLEADO             D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL             E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_CARGO_EMPLEADO       H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' AND( " +
                    "C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%' ) " +
                    "ORDER BY A.ID_MV_TARJETA DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public DataTable Listado_MVtarjetasCaidas(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT SELECT A.ID_MV_TARJETA, B.ID_TARJETA_CREDITO, C.ID_CLIENTE, D.ID_EM, " +
                    "E.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, " +
                    "C.APE_MATE_CLIENTE, E.DIRECCION, B.CODIGO_TARJETA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_TARJETA A " +
                    "INNER JOIN TB_TARJETA_CREDITO B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO " +
                    "INNER JOIN TB_TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA = B.ID_TP_TARJETA " +
                    "INNER JOIN TB_CLIENTE              C ON C.ID_CLIENTE = A.ID_CLIENTE" +
                    "INNER JOIN TB_TIPO_CLIENTE         G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_EMPLEADO             D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL             E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_CARGO_EMPLEADO       H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'I' AND( " +
                    "C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%' ) " +
                    "ORDER BY A.ID_MV_TARJETA DESC;");
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
                Tabla = conMysql.getData("SELECT SELECT A.ID_MV_TARJETA, B.ID_TARJETA_CREDITO, C.ID_CLIENTE, D.ID_EM, " +
                    "E.ID_SUCURSAL, A.FECHA_REGISTRO, A.MONTO_SALIDA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, " +
                    "C.APE_MATE_CLIENTE, E.DIRECCION, B.CODIGO_TARJETA, D.NOM_EMPLEADO, D.APE_PATE, D.APE_MATE " +
                    "FROM TB_MOVIMIENTO_TARJETA A " +
                    "INNER JOIN TB_TARJETA_CREDITO B ON B.ID_TARJETA_CREDITO = A.ID_TARJETA_CREDITO " +
                    "INNER JOIN TB_TIPO_TARJETA_CREDITO F ON F.ID_TP_TARJETA = B.ID_TP_TARJETA " +
                    "INNER JOIN TB_CLIENTE              C ON C.ID_CLIENTE = A.ID_CLIENTE" +
                    "INNER JOIN TB_TIPO_CLIENTE         G ON G.ID_TP_PERSONA = C.ID_TP_PERSONA " +
                    "INNER JOIN TB_EMPLEADO             D ON D.ID_EM = A.ID_EM " +
                    "INNER JOIN TB_SUCURSAL             E ON E.ID_SUCURSAL = A.ID_SUCURSAL " +
                    "INNER JOIN TB_CARGO_EMPLEADO       H ON H.ID_CARGO_EM = D.ID_CARGO_EM " +
                    "WHERE A.ESTADO = 'A' AND( " +
                    "C.NOM_CLIENTE      LIKE '%" + cTexto + "%' OR " +
                    "C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' OR " +
                    "C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%' ) " +
                    "ORDER BY A.ID_MV_TARJETA DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string GuardarMV_tarjeta(int nOpcion, E_MovimientoTarjeta oCl)
        {
            string Rpta = "";
            try
            {
                MySqlParameter param1 = new MySqlParameter("@nOpcion", MySqlDbType.Int32) { Value = nOpcion };
                MySqlParameter param2 = new MySqlParameter("@cID_MV_TARJETA", MySqlDbType.Int32) { Value = oCl.ID_MV_TARJETA };
                MySqlParameter param3 = new MySqlParameter("@cID_TARJETA_CREDITO", MySqlDbType.Int32) { Value = oCl.ID_TARJETA_CREDITO };
                MySqlParameter param4 = new MySqlParameter("@cID_CLIENTE", MySqlDbType.Int32) { Value = oCl.ID_CLIENTE };
                MySqlParameter param5 = new MySqlParameter("@cID_EM", MySqlDbType.Int32) { Value = oCl.ID_EM };
                MySqlParameter param6 = new MySqlParameter("@cID_SUCURSAL", MySqlDbType.Int32) { Value = oCl.ID_SUCURSAL };
                MySqlParameter param7 = new MySqlParameter("@cMONTO_SALIDA", MySqlDbType.Decimal) { Value = oCl.MONTO_SALIDA };

                Rpta = conMysql.ExecuteProcedure("P_GuardarMovimientoTarjetas", param1, param2, param3, param4, param5, param6, param7);
                Rpta = Convert.ToInt32(Rpta) > 0 ? "OK" : "No se pudieron registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string EliminarMV_tarjeta(int ID_MV_TARJETA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("update TB_MOVIMIENTO_TARJETA set " +
                    "ESTADO = 'I' where ID_MV_TARJETA = {0} ", ID_MV_TARJETA);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        
        public string Levantar_MVtarjetasCaidas(int ID_MV_TARJETA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("update TB_MOVIMIENTO_TARJETA set " +
                    "ESTADO = 'A' where ID_MV_TARJETA = {0} ", ID_MV_TARJETA);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable MV_tarjetaTarjeta()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_TARJETA_CREDITO, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, B.APE_MATE_CLIENTE, " +
                    "A.CODIGO_TARJETA FROM   TB_TARJETA_CREDITO A " +
                    "INNER JOIN TB_CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE " +
                    "WHERE A.ESTADO = 'A' AND B.ESTADO = 'A' " +
                    "ORDER BY A.ID_TARJETA_CREDITO DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable MV_tarjetaCliente()
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

        public DataTable MV_tarjetaEmpleado()
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

        public DataTable MV_tarjetaSucursal()
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
