using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_TipoCuentas
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_tipoCuenta(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_TIPO_CUENTA, FECHA_REGISTRO, NOM_CUENTA " +
                    "FROM TB_TIPO_CUENTA WHERE ESTADO = 'A' AND " +
                    "NOM_CUENTA   LIKE '%" + cTexto + "%' " +
                    "ORDER BY ID_TIPO_CUENTA DESC");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string Guardar_tipoCuenta(int nOpcion, E_TipoCuentas oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_TIPO_CUENTA (NOM_CUENTA,ESTADO)" +
                    " values('{0}', 'A')", oCl.NOM_CUENTA);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_TIPO_CUENTA set NOM_CUENTA = '{0}' " +
                        "where ID_TIPO_CUENTA = {1} ",
                        oCl.NOM_CUENTA, Convert.ToInt32(oCl.ID_TIPO_CUENTA));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tipoCuenta(int ID_TIPO_CUENTA)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TIPO_CUENTA where ID_TIPO_CUENTA = {0}", ID_TIPO_CUENTA);
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
