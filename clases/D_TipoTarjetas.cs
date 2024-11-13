using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_TipoTarjetas
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_tp_tj(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select ID_TP_TARJETA, FECHA_REGISTRO, NOM_TARJETA, LIMITE " +
                    "from TB_TIPO_TARJETA_CREDITO " +
                    "where ESTADO = 'A' and (" +
                    "NOM_TARJETA like '%" + cTexto + "%' " +
                    "OR LIMITE like '%" + cTexto + "%') " +
                    "order by ID_TP_TARJETA desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string Guardar_tp_tj(int nOpcion, E_TipoTarjetas oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_TIPO_TARJETA_CREDITO (NOM_TARJETA, LIMITE, ESTADO)" +
                    " values('{0}', '{1}', 'A')", oCl.NOM_TARJETA, Convert.ToDouble(oCl.LIMITE));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_TIPO_TARJETA_CREDITO set NOM_TARJETA = '{0}', LIMITE = '{1}' " +
                        "where ID_TP_TARJETA = {2} ",
                        oCl.NOM_TARJETA, Convert.ToDouble(oCl.LIMITE), Convert.ToInt32(oCl.ID_TP_TARJETA));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tp_tj(int ID_TP_TARJETA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TIPO_TARJETA_CREDITO where ID_TP_TARJETA = {0}", Convert.ToInt32(ID_TP_TARJETA));
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