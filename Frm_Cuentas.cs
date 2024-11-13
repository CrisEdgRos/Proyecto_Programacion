﻿using System;
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
    public partial class Frm_Cuentas : Form
    {
        public Frm_Cuentas()
        {
            InitializeComponent();
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        int ID_CUENTA = 0;
        int ID_CLIENTE = 0;
        int ID_TIPO_CUENTA = 0;
        int Estadoguarda = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_saldo.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_tipoCuenta.Text = "";
            Txt_cliente.Text = "";
            Txt_saldo.Text = "";
        }

        private void Formato_cuentasGeneral()
        {
            Dgv_principal.Columns[0].Visible    = false;
            Dgv_principal.Columns[1].Width      = 70;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width      = 120;
            Dgv_principal.Columns[2].HeaderText = "CUENTA";
            Dgv_principal.Columns[3].Width      = 40;
            Dgv_principal.Columns[3].HeaderText = "SALDO";
            Dgv_principal.Columns[4].Visible    = false;
            Dgv_principal.Columns[5].Width      = 80;
            Dgv_principal.Columns[5].HeaderText = "TIPO DE CUENTA";
            Dgv_principal.Columns[6].Visible    = false;
            
            Dgv_principal.Columns[7].Width      = 120;
            Dgv_principal.Columns[7].HeaderText = "NOMBRE";
            Dgv_principal.Columns[8].Width      = 110;
            Dgv_principal.Columns[8].HeaderText = "1° APELLIDO";
            Dgv_principal.Columns[9].Width      = 180;
            Dgv_principal.Columns[9].HeaderText = "2° APELLIDO";
            Dgv_principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Listado_cuentasGeneral(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Cuentas.Listado_cuenta(cTexto);
                this.Formato_cuentasGeneral();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CUENTA      = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_CLIENTE     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_TIPO_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TIPO_CUENTA"].Value);

                string nomCliente     = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;

                Txt_tipoCuenta.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CUENTA"].Value);
                Txt_saldo.Text      = Convert.ToString(Dgv_principal.CurrentRow.Cells["SALDO_ACTUAL"].Value);
            }
        }

        private void Formato_ListadoTipoCuenta()
        {
            Dgv_tipoCuentas.Columns[0].Visible = false;
            Dgv_tipoCuentas.Columns[1].Width = 150;
            Dgv_tipoCuentas.Columns[1].HeaderText = "TIPO";
        }

        private void Listado_tipoCuentas()
        {
            try
            {
                Dgv_tipoCuentas.DataSource = N_Cuentas.CuentaTipoCuenta();
                this.Formato_ListadoTipoCuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato_ListadoCuentaCliente()
        {
            Dgv_personas.Columns[0].Visible = false;
            Dgv_personas.Columns[1].Width = 70;
            Dgv_personas.Columns[1].HeaderText = "NOMBRE";
            Dgv_personas.Columns[2].Width = 70;
            Dgv_personas.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_personas.Columns[3].Width = 130;
            Dgv_personas.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void Listado_tipoCuenta()
        {
            try
            {
                Dgv_personas.DataSource = N_Cuentas.CuentaCliente();
                this.Formato_ListadoCuentaCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionarTipoCuenta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipoCuentas.CurrentRow.Cells["ID_TIPO_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TIPO_CUENTA = Convert.ToInt32(Dgv_tipoCuentas.CurrentRow.Cells["ID_TIPO_CUENTA"].Value);
                Txt_tipoCuenta.Text = Convert.ToString(Dgv_tipoCuentas.CurrentRow.Cells["NOM_CUENTA"].Value);
            }
        }

        private void SeleccionarCliente()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_personas.CurrentRow.Cells["ID_CLIENTE"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CLIENTE = Convert.ToInt32(Dgv_personas.CurrentRow.Cells["ID_CLIENTE"].Value);
                string nomCliente = Convert.ToString(Dgv_personas.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_personas.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_personas.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible  = lEstado;
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
            Txt_saldo.Text = "0.00";
            lbl_cuentas.Text = "CUENTAS";
            Txt_saldo.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_saldo.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value)))
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
                    this.ID_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                    Rpta = N_Cuentas.Eliminar_cuenta(this.ID_CUENTA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_cuentasGeneral("%");
                        this.ID_CUENTA = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_tipoCuenta.Text == String.Empty ||
                Txt_cliente.Text    == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Cuentas oCl = new E_Cuentas();

                oCl.ID_CUENTA      = this.ID_CUENTA;
                oCl.ID_CLIENTE     = this.ID_CLIENTE;
                oCl.ID_TIPO_CUENTA = this.ID_TIPO_CUENTA;
                oCl.SALDO_ACTUAL   = Convert.ToDecimal(Txt_saldo.Text);

                Rpta = N_Cuentas.Guardar_cuenta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_cuentasGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_CUENTA = 0;
                    lbl_cuentas.Text = "CUENTAS";
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

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_CUENTA = 0;
            this.ID_CLIENTE = 0;
            this.ID_TIPO_CUENTA = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_cuentasGeneral(Txt_buscar.Text.Trim());
            lbl_cuentas.Text = "CUENTAS";
        }

        private void Frm_Cuentas_Load(object sender, EventArgs e)
        {
            Listado_tipoCuentas();
            Listado_tipoCuenta();
            lbl_cuentas.Text = "CUENTAS";
            Listado_cuentasGeneral(Txt_buscar.Text.Trim());
        }

        private void Dgv_personas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarCliente();
            Pnl_tipoCliente.Visible = false;
            Txt_cliente.Focus();
        }

        private void Btn_lupa_Click(object sender, EventArgs e)
        {
            this.Pnl_tipoCuenta.Location = Btn_lupaCuenta.Location;
            this.Pnl_tipoCuenta.Visible  = true;
            this.Pnl_tipoCliente.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Pnl_tipoCliente.Location = Btn_lupaCliente.Location;
            this.Pnl_tipoCliente.Visible  = true;
            this.Pnl_tipoCuenta.Visible   = false;
        }

        private void Dgv_tipoCuentas_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionarTipoCuenta();
            Pnl_tipoCuenta.Visible = false;
            Txt_tipoCuenta.Focus();
        }

        private void Btn_retorno_Click(object sender, EventArgs e)
        {
            Pnl_tipoCliente.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pnl_tipoCuenta.Visible = false;
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

    }
}
