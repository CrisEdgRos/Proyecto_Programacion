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
    public partial class Frm_TipoCliente : Form
    {
        public Frm_TipoCliente()
        {
            InitializeComponent();
        }
                
        int ID_TP_PERSONA = 0;
        int Estadoguarda = 0; //Sin ninguna acción

        private void Estado_texto(bool lestado)
        {
            Txt_tipo_persona.ReadOnly      = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_tipo_persona.Text = "";
        }

        private void Formato_tp_cl()
        {
            Dgv_principal.Columns[0].Visible = false;
            Dgv_principal.Columns[1].Width = 100;
            Dgv_principal.Columns[1].HeaderText = "REGISTRO";
            Dgv_principal.Columns[2].Width = 350;
            Dgv_principal.Columns[2].HeaderText = "TIPO DE CLIENTE";
        }

        private void Listado_tp_cl(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_TipoClientes.Listado_tp_cl(cTexto);
                this.Formato_tp_cl();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TP_PERSONA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_PERSONA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PERSONA"].Value);
                Txt_tipo_persona.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["TIPO_PERSONA"].Value);
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
            lbl_tipoclientes.Text = "TIPOS DE CLIENTES";
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            Estadoguarda = 1; //Nuevo Registro
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Txt_tipo_persona.Text = "";
            Txt_tipo_persona.ReadOnly = false;
            Tbc_principal.SelectedIndex = 1;
            lbl_tipoclientes.Text = "TIPOS DE CLIENTES";
            Txt_tipo_persona.Focus();
        }

        private void Btn_eliminar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TP_PERSONA"].Value)))
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
                    this.ID_TP_PERSONA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PERSONA"].Value);
                    Rpta = N_TipoClientes.Eliminar_tp_cl(this.ID_TP_PERSONA);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tp_cl("%");
                        this.ID_TP_PERSONA = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_cancelar_Click_1(object sender, EventArgs e)
        {
            this.ID_TP_PERSONA = 0;
            this.Estadoguarda = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_actualizar_Click_1(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_tipo_persona.Focus();
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tp_cl(Txt_buscar.Text.Trim());
            lbl_tipoclientes.Text = "TIPOS DE CLIENTES";
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (Txt_tipo_persona.Text == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_TipoClientes oCl = new E_TipoClientes();

                oCl.ID_TP_PERSONA = this.ID_TP_PERSONA;
                oCl.TIPO_PERSONA  = Txt_tipo_persona.Text.Trim();

                Rpta = N_TipoClientes.Guardar_tp_cl(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tp_cl("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_TP_PERSONA = 0;
                    lbl_tipoclientes.Text = "TIPOS DE CLIENTES";
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

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Frm_TipoCliente_Load(object sender, EventArgs e)
        {
            Listado_tp_cl(Txt_buscar.Text.Trim());
            lbl_tipoclientes.Text = "TIPOS DE CLIENTES";
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

    }
}
