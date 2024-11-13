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
    public partial class Frm_TipoPagos : Form
    {
        public Frm_TipoPagos()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            lbl_tipoPago.Text = "TIPOS DE PAGOS";
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_TP_PAGO = 0;
        int Estadoguarda   = 0; //Sin ninguna acción

        private void Estado_texto(bool lestado)
        {
            Txt_tipoPago.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_tipoPago.Text = "";
        }

        private void Formato_tipoPago()
        {
            Dgv_principal.Columns[0].Visible    = false;
            Dgv_principal.Columns[1].Width      = 100;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width      = 350;
            Dgv_principal.Columns[2].HeaderText = "TIPO DE COBRO";
            Dgv_principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Listado_tipoPago(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_TipoPagos.Listado_tipoPago(cTexto);
                this.Formato_tipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TP_PAGO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_PAGO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PAGO"].Value);

                Txt_tipoPago.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["TIPO_COBRO"].Value);
            }
        }
        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            lbl_tipoPago.Text = "TIPOS DE PAGO";
            Txt_tipoPago.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_tipoPago.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TP_PAGO"].Value)))
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
                    this.ID_TP_PAGO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PAGO"].Value);
                    Rpta = N_TipoPagos.Eliminar_tipoPago(this.ID_TP_PAGO);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tipoPago("%");
                        this.ID_TP_PAGO = 0;
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
            this.Listado_tipoPago(Txt_buscar.Text.Trim());
            lbl_tipoPago.Text = "TIPOS DE PAGO";
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
            if (
                Txt_tipoPago.Text == String.Empty)
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_TipoPagos oCl = new E_TipoPagos();

                oCl.ID_TP_PAGO = this.ID_TP_PAGO;
                oCl.TIPO_COBRO     = Txt_tipoPago.Text.Trim();

                Rpta = N_TipoPagos.Guardar_tipoPago(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tipoPago("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_TP_PAGO = 0;
                    lbl_tipoPago.Text = "TIPOS DE PAGO";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_TP_PAGO = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Frm_TipoPagos_Load(object sender, EventArgs e)
        {
            Listado_tipoPago(Txt_buscar.Text.Trim());
            lbl_tipoPago.Text = "TIPOS DE PAGO";
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }    
}
