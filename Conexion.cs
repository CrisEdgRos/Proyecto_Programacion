using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

/// <summary>
/// 
/// </summary>
namespace Clave3_Grupo4
{
    /// <summary>
    /// Clase para la coneccion a la base en MySql
    /// </summary>
    
    class Conexion
    {
        const string HOST = "localhost";
        const string USER = "root";
        const string PASS = "12345678";
        const string DB = "Clave3_Grupo4DBB";

        MySqlConnection Ocon = new MySqlConnection();

        public Conexion()
        {
            this.Connect();
        }

        public void Connect()
        {
            //Conexion a la Base por Medio del Host, User, Pass y DataBase
            if (Ocon.State == ConnectionState.Closed)
            {
                Ocon.ConnectionString = String.Format(@"Server={0}; Database={1}; User ID={2}; Password={3}; SslMode=none;", HOST, DB, USER, PASS);
                Ocon.Open();
            }

        }

        //Insert, Update, Delete
        public int Query(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Ocon);
            return command.ExecuteNonQuery();
        }

        //Select Data Table
        public DataTable getData(string sql)
        {
            this.Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, Ocon);
            adapter.Fill(table);
            return table;
        }

        //Obtener una fila de la tabla retornada por getData
        public DataRow getRow(string sql)
        {
            DataRow row = null;
            if (this.getData(sql).Rows.Count == 0)
            {
                return null;
            }
            row = this.getData(sql).Rows[0];
            return row;
        }

        // Método para ejecutar procedimientos almacenados con parámetros
        public string ExecuteProcedure(string procedureName, params MySqlParameter[] parameters)
        {
            try
            {
                // Crear el comando para ejecutar el procedimiento almacenado
                MySqlCommand cmd = new MySqlCommand(procedureName, Ocon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar los parámetros al comando
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                // Ejecutar el procedimiento almacenado
                int rowsAffected = cmd.ExecuteNonQuery();

                // Verificar si el procedimiento fue ejecutado correctamente
                return Convert.ToString(rowsAffected);
            }
            catch (Exception ex)
            {
                return ex.Message; // En caso de error, retornamos el mensaje de la excepción
            }
        }


        //Metodo para cargar comboBox
        public void CargarCombo(ComboBox cbo, String sql, String mostrar, String seleccionar)
        {
            this.Connect();
            DataTable datos = this.getData(sql);

            if (datos.Rows.Count > 0)
            {
                cbo.DataSource = null;
                cbo.DataSource = datos;
                cbo.DisplayMember = mostrar;
                cbo.ValueMember = seleccionar;
            }
            else
            {
                //Validacion 
                cbo.Text = "No hay registros";
                cbo.SelectedIndex = -1;
            }

        }
    }
}
