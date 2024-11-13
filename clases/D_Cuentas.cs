using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_Cuentas
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_cuenta(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select " +
                    "A.ID_CUENTA, " +
                    "A.FECHA_REGISTRO, " +
                    "A.CODIGO_CUENTA, " +
                    "A.SALDO_ACTUAL, " +
                    "C.ID_TIPO_CUENTA, " +
                    "C.NOM_CUENTA, " +
                    "T.ID_CLIENTE, " +
                    "T.NOM_CLIENTE, " +
                    "T.APE_PATE_CLIENTE, " +
                    "T.APE_MATE_CLIENTE " +
                "FROM TB_CUENTA A " +
                "INNER JOIN TB_TIPO_CUENTA C ON A.ID_TIPO_CUENTA = C.ID_TIPO_CUENTA " +
                "INNER JOIN TB_CLIENTE T ON A.ID_CLIENTE = T.ID_CLIENTE " +
                "WHERE A.ESTADO = 'A' " +
                " AND(" +
                "A.ID_CUENTA        LIKE '%" + cTexto + "%' " +
                "OR A.CODIGO_CUENTA    LIKE '%" + cTexto + "%' " +
                "OR A.SALDO_ACTUAL     LIKE '%" + cTexto + "%' " +
                "OR T.NOM_CLIENTE      LIKE '%" + cTexto + "%' " +
                "OR T.APE_MATE_CLIENTE LIKE '%" + cTexto + "%') " +
                "ORDER BY A.ID_CUENTA DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string Guardar_cuenta(int nOpcion, E_Cuentas oCl)
        {
            string Rpta = "";
            try
            {
                MySqlParameter param1 = new MySqlParameter("@nOpcion", MySqlDbType.Int32) { Value = nOpcion };
                MySqlParameter param2 = new MySqlParameter("@cID_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_CUENTA };
                MySqlParameter param3 = new MySqlParameter("@cID_TIPO_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_TIPO_CUENTA };
                MySqlParameter param4 = new MySqlParameter("@cID_CLIENTE", MySqlDbType.Int32) { Value = oCl.ID_CLIENTE };
                MySqlParameter param5 = new MySqlParameter("@cSALDO_ACTUAL", MySqlDbType.Decimal) { Value = oCl.SALDO_ACTUAL };

                Rpta = conMysql.ExecuteProcedure("P_GuardarCuenta", param1, param2, param3, param4, param5);

                Rpta = Convert.ToInt32(Rpta) > 0 ? "OK" : "No se pudieron registrar los datos - 'POLITICAS CBANK: No se puede crear cuentas corrientes para clientes fisicos.";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_cuenta(int ID_CUENTA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_CUENTA where ID_CUENTA= '{0}'", ID_CUENTA);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable CuentaCliente()
        {
           DataTable Tabla = new DataTable();
           try
           {
              Tabla = conMysql.getData("SELECT ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE " +
                  "FROM TB_CLIENTE WHERE ESTADO = 'A' ORDER BY ID_CLIENTE DESC;");
            }
            catch (Exception ex)
            {
                    throw ex;
            }
            return Tabla;
        }

        public DataTable CuentaTipoCuenta()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_TIPO_CUENTA, NOM_CUENTA FROM TB_TIPO_CUENTA " +
                    "WHERE ESTADO = 'A' ORDER BY ID_TIPO_CUENTA DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
    }
}
