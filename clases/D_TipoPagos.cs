using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_TipoPagos
    {
        Conexion conMysql = new Conexion();

        public DataTable Listado_tipoPago(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT " +
                    "ID_TP_PAGO, " +
                    "FECHA_REGISTRO, " +
                    "TIPO_COBRO " +
                    "FROM TB_TIPO_PAGO " +
                    "WHERE ESTADO = 'A' " +
                    "AND(ID_TP_PAGO     LIKE '%" + cTexto + "%' " +
                    "OR TIPO_COBRO         LIKE '%" + cTexto + "%' ) " +
                    "ORDER BY ID_TP_PAGO DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string Guardar_tipoPago(int nOpcion, E_TipoPagos oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_TIPO_PAGO(TIPO_COBRO, ESTADO)" +
                    " values('{0}', 'A')", oCl.TIPO_COBRO);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_TIPO_PAGO set TIPO_COBRO = '{0}' " +
                        "where ID_TP_PAGO = {1} ",
                        oCl.TIPO_COBRO, Convert.ToInt32(oCl.ID_TP_PAGO));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tipoPago(int ID_TP_PAGO)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TIPO_PAGO where ID_TP_PAGO = {0}", Convert.ToInt32(ID_TP_PAGO));
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }
    }
}
