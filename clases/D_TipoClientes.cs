using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_TipoClientes
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_tp_cl(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select ID_TP_PERSONA, FECHA_REGISTRO, TIPO_PERSONA " +
                    "from TB_TIPO_CLIENTE " +
                    "where ESTADO = 'A' and (" +
                    "TIPO_PERSONA like '%" + cTexto + "%') " +
                    "order by ID_TP_PERSONA desc");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string Guardar_tp_cl(int nOpcion, E_TipoClientes oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_TIPO_CLIENTE (TIPO_PERSONA, ESTADO)" +
                    " values('{0}','A')", oCl.TIPO_PERSONA);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_TIPO_CLIENTE set TIPO_PERSONA = '{0}' where ID_TP_PERSONA = {1} ", 
                        oCl.TIPO_PERSONA, Convert.ToInt32(oCl.ID_TP_PERSONA));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tp_cl(int ID_TP_PERSONA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TIPO_CLIENTE where ID_TP_PERSONA = {0}", Convert.ToInt32(ID_TP_PERSONA));
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
