using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clave3_Grupo4
{
    public class D_TipoPrestamo
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_tipoPrestamo(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT " +
                    "ID_TP_PRESTAMO," +
                    "FECHA_REGISTRO," +
                    "NOM_PRESTAMO " +
                    "FROM TB_TIPO_PRESTAMO " +
                    "WHERE ESTADO = 'A' " +
                    "AND( " +
                    "ID_TP_PRESTAMO LIKE '%" + cTexto + "%' " +
                    "OR NOM_PRESTAMO LIKE '%" + cTexto + "%') " +
                    "ORDER BY ID_TP_PRESTAMO DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }
        
        public string Guardar_tipoPrestamo(int nOpcion, E_TipoPrestamo oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_TIPO_PRESTAMO(NOM_PRESTAMO, ESTADO)" +
                    " values('{0}', 'A')", oCl.NOM_PRESTAMO);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_TIPO_PRESTAMO set NOM_PRESTAMO = '{0}' " +
                        "where ID_TP_PRESTAMO = {1} ",
                        oCl.NOM_PRESTAMO, Convert.ToInt32(oCl.ID_TP_PRESTAMO));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_tipoPrestamo(int ID_TP_PRESTAMO)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from TB_TIPO_PRESTAMO where ID_TP_PRESTAMO = {0}", Convert.ToInt32(ID_TP_PRESTAMO));
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