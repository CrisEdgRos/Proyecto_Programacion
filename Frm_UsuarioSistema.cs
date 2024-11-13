using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Clave3_Grupo4
{
    public partial class Frm_UsuarioSistema : Form
    {
        Conexion conMysql = new Conexion();
        DataTable lsttabla = new DataTable();

        public Frm_UsuarioSistema()
        {
            InitializeComponent();
        }

        int ID_USER      = 0;
        int Estadoguarda = 0; //Sin ninguna acción

        public object XMLWorkerHelper { get; private set; }

        private void Estado_texto(bool lestado)
        {
            Txt_contraseña.ReadOnly = !lestado;
            Txt_usuario.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_contraseña.Text    = "";
;           Txt_usuario.Text       = "";
            Chk_admin.Checked     = false;
            Chk_cuentas.Checked   = false;
            Chk_prestamos.Checked = false;
            Chk_tarjetas.Checked  = false;
        }

        private void Formato_us()
        {
            Dgv_principal.AutoGenerateColumns = true;
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Width = 120;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width = 90;
            Dgv_principal.Columns[2].HeaderText = "USUARIO";
            Dgv_principal.Columns[3].Width = 90;
            Dgv_principal.Columns[3].HeaderText = "ADMIN";
            Dgv_principal.Columns[4].Width = 80;
            Dgv_principal.Columns[4].HeaderText = "PRESTAMOS";
            Dgv_principal.Columns[5].Width = 80;
            Dgv_principal.Columns[5].HeaderText = "CUENTAS";
            Dgv_principal.Columns[6].Width = 100;
            Dgv_principal.Columns[6].HeaderText = "TARJETAS";
        }

        private void Listado_us(string cTexto)
        {
            try
            {
                lsttabla = conMysql.getData("select ID_USER, FECHA_REGISTRO, USUARIO, ADMIN, PRESTAMOS, CUENTAS, TARJETAS from tb_usuario where usuario like '%" + cTexto + "%'");
                Dgv_principal.Columns.Clear();
                Dgv_principal.DataSource = lsttabla;
                this.Formato_us();            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace + lsttabla + cTexto);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled = lEstado;
            this.Btn_actualizar.Enabled = lEstado;
            this.Btn_eliminar.Enabled = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                Txt_usuario.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["USUARIO"].Value);
                Chk_admin.Checked = Convert.ToBoolean(Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ADMIN"].Value));
                Chk_cuentas.Checked = Convert.ToBoolean(Convert.ToInt32(Dgv_principal.CurrentRow.Cells["CUENTAS"].Value));
                Chk_prestamos.Checked = Convert.ToBoolean(Convert.ToInt32(Dgv_principal.CurrentRow.Cells["PRESTAMOS"].Value));
                Chk_tarjetas.Checked = Convert.ToBoolean(Convert.ToInt32(Dgv_principal.CurrentRow.Cells["TARJETAS"].Value));
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro
            this.Estado_Botonesprincipales(false);
      //      this.Estado_restaurar(false);
            this.Estado_Botonesprocesos(true);
            Txt_usuario.Text = "";
            Txt_usuario.ReadOnly = false;
            Txt_contraseña.Text = "";
            Txt_contraseña.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1;
            Txt_usuario.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Chk_admin.Enabled = true;
            Chk_cuentas.Enabled = true;
            Chk_prestamos.Enabled = true;
            Chk_tarjetas.Enabled = true;
            Txt_usuario.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_USER"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                    String sql = String.Format("delete from tb_usuario where id_user= '{0}'", this.ID_USER);
                    try
                    {
                        if (conMysql.Query(sql) == 1)
                        {
                            this.Listado_us("%");
                    //        this.Estado_restaurar(false);
                            this.ID_USER = 0;
                            MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_us(Txt_buscar.Text.Trim());
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_usuario.Text    == String.Empty ||
                Txt_contraseña.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                String sql = null; 
                if (Estadoguarda == 1) { 
                    sql = String.Format("insert into tb_usuario(usuario,contraseña,admin,prestamos,cuentas,tarjetas,estado)" +
                          " values('{0}',aes_encrypt('{0}','{1}'),'{2}','{3}','{4}','{5}','A')",
                          Txt_usuario.Text.Trim(), Txt_contraseña.Text.Trim(), Convert.ToInt32(Chk_admin.Checked), Convert.ToInt32(Chk_cuentas.Checked), Convert.ToInt32(Chk_prestamos.Checked), Convert.ToInt32(Chk_tarjetas.Checked));
                    try
                    {
                        //Validacion de registro en la base de datos
                        if (conMysql.Query(sql) == 1)
                        {
                            this.Listado_us("%");
                            MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Estadoguarda = 0; // Sin nunguna acción
                            this.Estado_Botonesprincipales(true);
                            this.Estado_Botonesprocesos(false);
                            this.Estado_texto(false);

                            Txt_usuario.Text = "";
                            Txt_contraseña.Text = "";
                            Chk_admin.Checked = false;
                            Chk_cuentas.Checked = false;
                            Chk_prestamos.Checked = false;
                            Chk_tarjetas.Checked = false;

                            Txt_usuario.ReadOnly = true;
                            Txt_contraseña.ReadOnly = true;
                            Chk_admin.Enabled = false;
                            Chk_cuentas.Enabled = false;
                            Chk_prestamos.Enabled = false;
                            Chk_tarjetas.Enabled = false;

                            Tbc_principal.SelectedIndex = 0;
                            this.ID_USER = 0;
                            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
                        }
                        else
                        {
                            MessageBox.Show(sql, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (Estadoguarda == 2)
                {
                    this.ID_USER = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_USER"].Value);
                    sql = String.Format("update tb_usuario set usuario='{0}', contraseña=aes_encrypt('{0}','{1}'), admin='{2}',prestamos='{3}',cuentas='{4}',tarjetas='{5}' where id_user='{6}'",
                              Txt_usuario.Text.Trim(), Txt_contraseña.Text.Trim(), Convert.ToInt32(Chk_admin.Checked), Convert.ToInt32(Chk_cuentas.Checked), Convert.ToInt32(Chk_prestamos.Checked), Convert.ToInt32(Chk_tarjetas.Checked), this.ID_USER);
                    try
                    {
                        //Validacion de actualizacion de usuario
                        if (conMysql.Query(sql) == 1)
                        {
                            this.Listado_us("%");
                            MessageBox.Show("Los datos han sido actualizados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Estadoguarda = 0; // Sin nunguna acción
                            this.Estado_Botonesprincipales(true);
                            this.Estado_Botonesprocesos(false);
                            this.Estado_texto(false);

                            Txt_usuario.Text = "";
                            Txt_contraseña.Text = "";
                            Chk_admin.Checked = false;
                            Chk_cuentas.Checked = false;
                            Chk_prestamos.Checked = false;
                            Chk_tarjetas.Checked = false;

                            Txt_usuario.ReadOnly = true;
                            Txt_contraseña.ReadOnly = true;
                            Chk_admin.Enabled = false;
                            Chk_cuentas.Enabled = false;
                            Chk_prestamos.Enabled = false;
                            Chk_tarjetas.Enabled = false;

                            Tbc_principal.SelectedIndex = 0;
                            this.ID_USER = 0;
                            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
                        }
                        else
                        {
                            MessageBox.Show("!!!... ERROR, NO se pudo editar el registro ...!!!");
                        }
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_USER      = 0;
            this.Estadoguarda = 0;
            Chk_admin.Checked = false;
            Chk_cuentas.Checked = false;
            Chk_prestamos.Checked = false;
            Chk_tarjetas.Checked = false;

            Chk_admin.Enabled = false;
            Chk_cuentas.Enabled = false;
            Chk_prestamos.Enabled = false;
            Chk_tarjetas.Enabled = false;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Frm_UsuarioSistema_Load(object sender, EventArgs e)
        {
            Listado_us(Txt_buscar.Text.Trim());
            lbl_usuarios.Text = "USUARIOS DEL SISTEMA";
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

       
    }
}
