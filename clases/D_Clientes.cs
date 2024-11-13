using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clave3_Grupo4;

namespace Clave3_Grupo4
{
    public class D_Clientes
    {
        Conexion conMysql = new Conexion();
        public DataTable Listado_cl(string cTexto)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("select C.ID_CLIENTE, C.FECHA_REGISTRO, T.TIPO_PERSONA, C.NOM_CLIENTE, C.APE_PATE_CLIENTE, C.APE_MATE_CLIENTE, " +
                "C.DIRECCION_CLIENTE, C.TEL_CEL_CLIENTE, C.TEL_FIJO_CLIENTE, C.DUI, C.NOM_CARGO_CLIENTE, C.SUELDO, C.ESTADO, T.ID_TP_PERSONA " +
                "from TB_CLIENTE C " +
                "INNER JOIN TB_TIPO_CLIENTE T ON C.ID_TP_PERSONA = T.ID_TP_PERSONA WHERE C.ESTADO = 'A' " +
                "and (" +
                " C.NOM_CLIENTE             LIKE '%"+ cTexto+"%' OR " +
                "C.APE_PATE_CLIENTE        LIKE '%" + cTexto + "%' OR " +
                "C.APE_MATE_CLIENTE        LIKE '%" + cTexto + "%' OR " +
                "C.DIRECCION_CLIENTE       LIKE '%" + cTexto + "%' OR " +
                "C.TEL_CEL_CLIENTE         LIKE '%" + cTexto + "%' OR " +
                "C.TEL_FIJO_CLIENTE        LIKE '%" + cTexto + "%' OR " +
                "C.DUI                     LIKE '%" + cTexto + "%' OR " +
                "C.NOM_CARGO_CLIENTE       LIKE '%" + cTexto + "%' OR " +
                "CAST(C.SUELDO AS CHAR)    LIKE '%" + cTexto + "%' OR " +
                "T.TIPO_PERSONA            LIKE '%" + cTexto + "%' ) " +
                " ORDER BY C.ID_CLIENTE DESC;");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Tabla;
        }

        public string Guardar_cl(int nOpcion, E_Clientes oCl)
        {
            string Rpta = "";
            try
            {
                if (nOpcion == 1)
                {
                    Rpta = String.Format("insert into TB_CLIENTE(ID_TP_PERSONA, NOM_CLIENTE, APE_PATE_CLIENTE, APE_MATE_CLIENTE, DIRECCION_CLIENTE, TEL_CEL_CLIENTE, " +
                    "TEL_FIJO_CLIENTE, DUI, NOM_CARGO_CLIENTE, ID_USER, SUELDO, ESTADO)" +
                    " values({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',null,{9},'A')",
                    Convert.ToInt32(oCl.ID_TP_PERSONA), oCl.NOM_CLIENTE, oCl.APE_PATE_CLIENTE, oCl.APE_MATE_CLIENTE, oCl.DIRECCION_CLIENTE, oCl.TEL_CEL_CLIENTE, oCl.TEL_FIJO_CLIENTE, oCl.DNI, oCl.NOM_CARGO_CLIENTE, Convert.ToDouble(oCl.SUELDO));
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron registrar los datos";
                }
                else
                {
                    Rpta = String.Format("update TB_CLIENTE set ID_TP_PERSONA={0}, NOM_CLIENTE='{1}', APE_PATE_CLIENTE='{2}', APE_MATE_CLIENTE='{3}', " +
                        "DIRECCION_CLIENTE='{4}', TEL_CEL_CLIENTE='{5}', TEL_FIJO_CLIENTE='{6}', DUI='{7}', NOM_CARGO_CLIENTE='{8}', ID_USER=null," +
                        " SUELDO={9}, ESTADO='A' where ID_CLIENTE={10}", Convert.ToInt32(oCl.ID_TP_PERSONA), oCl.NOM_CLIENTE, oCl.APE_PATE_CLIENTE, oCl.APE_MATE_CLIENTE, 
                    oCl.DIRECCION_CLIENTE, oCl.TEL_CEL_CLIENTE, oCl.TEL_FIJO_CLIENTE, oCl.DNI, oCl.NOM_CARGO_CLIENTE, Convert.ToDouble(oCl.SUELDO), oCl.ID_CLIENTE);
                    Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudieron actualizar los datos";
                }
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string Eliminar_cl(int ID_CLIENTE)
        {
            string Rpta = "";
            try
            {
                Rpta = String.Format("delete from tb_cliente where id_cliente= '{0}'", ID_CLIENTE);
                Rpta = conMysql.Query(Rpta) == 1 ? "OK" : "No se pudo eliminar los datos";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public DataTable TIPO_PERSONA()
        {
            DataTable Tabla = new DataTable();
            try
            {
                Tabla = conMysql.getData("SELECT ID_TP_PERSONA, TIPO_PERSONA FROM TB_TIPO_CLIENTE WHERE ESTADO = 'A' ORDER BY ID_TP_PERSONA DESC;");
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }
    }
}
