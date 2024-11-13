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
    public class D_Tarjetas
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_tarjeta(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select A.ID_TARJETA_CREDITO," +
                    "A.FECHA_REGISTRO," +
                    "A.ID_CLIENTE," +
                    "C.NOM_CLIENTE," +
                    "C.APE_PATE_CLIENTE," +
                    "C.APE_MATE_CLIENTE," +
                    "A.ID_CUENTA," +
                    "T.NOM_TARJETA," +
                    "B.CODIGO_CUENTA," +
                    "A.ID_TP_TARJETA," +
                    "A.CODIGO_TARJETA," +
                    "A.SALDO_DISPONIBLE " +
                "from TB_TARJETA_CREDITO A " +
                "INNER JOIN TB_CLIENTE C ON A.ID_CLIENTE = C.ID_CLIENTE " +
                "INNER JOIN TB_TIPO_TARJETA_CREDITO T ON A.ID_TP_TARJETA = T.ID_TP_TARJETA " +
                "INNER JOIN TB_CUENTA B ON A.ID_CUENTA = B.ID_CUENTA " +
                "WHERE A.ESTADO = 'A' and ( A.SALDO_DISPONIBLE LIKE '%" + cTexto + "%' OR C.NOM_CLIENTE LIKE '%" + cTexto + "%' " +
                " OR C.APE_MATE_CLIENTE LIKE '%" + cTexto + "%' " +
                " OR C.APE_PATE_CLIENTE LIKE '%" + cTexto + "%' " +
                " OR C.ID_CLIENTE       LIKE '%" + cTexto + "%' " +
                " OR T.ID_TP_TARJETA    LIKE '%" + cTexto + "%' " +
                " OR B.ID_CUENTA        LIKE '%" + cTexto + "%' " +
                " OR B.CODIGO_CUENTA    LIKE '%" + cTexto + "%' " +
                ")" +
                "ORDER BY A.ID_TARJETA_CREDITO DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string Guardar_tarjeta(int nOpcion, E_Tarjetas oCl)
        {
            string Rpta = "";
            try
            {
                MySqlParameter param1 = new MySqlParameter("@nOpcion", MySqlDbType.Int32) { Value = nOpcion };
                MySqlParameter param2 = new MySqlParameter("@nID_TARJETA_CREDITO", MySqlDbType.Int32) { Value = oCl.ID_TARJETA_CREDITO };
                MySqlParameter param3 = new MySqlParameter("@nID_CLIENTE", MySqlDbType.Int32) { Value = oCl.ID_CLIENTE };
                MySqlParameter param4 = new MySqlParameter("@cID_CUENTA", MySqlDbType.Int32) { Value = oCl.ID_CUENTA };
                MySqlParameter param5 = new MySqlParameter("@cID_TP_TARJETA", MySqlDbType.Int32) { Value = oCl.ID_TP_TARJETA };
                MySqlParameter param6 = new MySqlParameter("@cSALDO_DISPONIBLE", MySqlDbType.Decimal) { Value = oCl.SALDO_DISPONIBLE };

                Rpta = conMysql.ExecuteProcedure("P_GuardarTarjetaCredito", param1, param2, param3, param4, param5, param6);
                Rpta = Convert.ToInt32(Rpta) > 0 ? "OK" : "No se pudieron registrar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tarjeta(int ID_TARJETA_CREDITO)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TARJETA_CREDITO where ID_TARJETA_CREDITO= '{0}'", ID_TARJETA_CREDITO);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
        

        public DataTable TARJETA_CLIENTE()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_CLIENTE, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE " +
                    "FROM TB_CLIENTE  WHERE  ESTADO = 'A' ORDER BY ID_CLIENTE DESC; ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable TARJETA_CUENTA(int ID_CLIENTE)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT A.ID_CUENTA, A.CODIGO_CUENTA, B.NOM_CLIENTE, B.APE_PATE_CLIENTE, " +
                    "B.APE_MATE_CLIENTE FROM TB_CUENTA A INNER JOIN TB_CLIENTE B ON A.ID_CLIENTE = B.ID_CLIENTE " +
                    "WHERE A.ESTADO = 'A' and B.ID_CLIENTE like '%" + ID_CLIENTE + "%' ORDER BY A.ID_CUENTA DESC ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public DataTable TIPO_TARJETA_CREDITO()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_TP_TARJETA, NOM_TARJETA FROM TB_TIPO_TARJETA_CREDITO " +
                    "WHERE ESTADO = 'A' ORDER BY ID_TP_TARJETA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
    }
}
