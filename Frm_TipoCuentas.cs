using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clave3_Grupo4
{
    public partial class Frm_TipoCuentas : Form
    {
        public Frm_TipoCuentas()
        {
            InitializeComponent();
        }

        int ID_TIPO_CUENTA = 0;
        int Estadoguarda   = 0; //Sin ninguna acción

        private void Estado_texto(bool lestado)
        {
            Txt_tipoCuenta.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_tipoCuenta.Text = "";
        }

        private void Formato_tipoCuenta()
        {
            Dgv_principal.Columns[0].Visible    = false;
            Dgv_principal.Columns[1].Width      = 100;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width      = 350;
            Dgv_principal.Columns[2].HeaderText = "TIPO DE CUENTA";
        }

        private void Listado_tipoCuenta(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_TipoCuentas.Listado_tipoCuenta(cTexto);
                this.Formato_tipoCuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botonesprincipales(bool lEstado)
        {
            this.Btn_nuevo.Enabled         = lEstado;
            this.Btn_actualizar.Enabled    = lEstado;
            this.Btn_eliminar.Enabled      = lEstado;
            this.Btn_salir_cliente.Enabled = lEstado;
        }

        private void SeleccionaItem()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TIPO_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TIPO_CUENTA   = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TIPO_CUENTA"].Value);

                Txt_tipoCuenta.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CUENTA"].Value);
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
            lbl_tipoCuenta.Text = "TIPOS DE CUENTA";
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            lbl_tipoCuenta.Text = "TIPOS DE CUENTA";
            Tbc_principal.SelectedIndex = 1;
            Txt_tipoCuenta.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_tipoCuenta.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TIPO_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Opcion == DialogResult.Yes)
                {
                    string Rpta = "";
                    this.ID_TIPO_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TIPO_CUENTA"].Value);
                    Rpta = N_TipoCuentas.Eliminar_tipoCuenta(this.ID_TIPO_CUENTA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tipoCuenta("%");
                        this.ID_TIPO_CUENTA = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tipoCuenta(Txt_buscar.Text.Trim());
            lbl_tipoCuenta.Text = "TIPOS DE CUENTA";
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_TIPO_CUENTA = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_tipoCuenta.Text == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_TipoCuentas oCl = new E_TipoCuentas();

                oCl.ID_TIPO_CUENTA = this.ID_TIPO_CUENTA;
                oCl.NOM_CUENTA     = Txt_tipoCuenta.Text.Trim();

                Rpta = N_TipoCuentas.Guardar_tipoCuenta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tipoCuenta("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_TIPO_CUENTA = 0;
                    lbl_tipoCuenta.Text = "TIPOS DE CUENTA";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Frm_TipoCuentas_Load(object sender, EventArgs e)
        {
            Listado_tipoCuenta(Txt_buscar.Text.Trim());
            lbl_tipoCuenta.Text = "TIPOS DE CUENTA";
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}
