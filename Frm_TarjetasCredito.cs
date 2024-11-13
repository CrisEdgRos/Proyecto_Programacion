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
    public partial class Frm_TarjetasCredito : Form
    {
        public Frm_TarjetasCredito()
        {
            InitializeComponent();
        }

        int ID_TARJETA_CREDITO = 0;
        int ID_CLIENTE = 0;
        int ID_CUENTA = 0;
        int ID_TP_TARJETA = 0;
  //      int SALDO_DISPONIBLE = 0;
        int Estadoguarda = 0; //Sin ninguna acción


        private void Limpia_texto()
        {
            Txt_tarjetaCliente.Text = "";
            Txt_tarjetaCuenta.Text = "";
            Txt_tarjetaTipo.Text = "";
        }
        // ----------------------------------------- BLOQUE 1

        private void Formato_TARJETA()
        {
            Dgv_principal.Columns[0].Visible     = false;
            Dgv_principal.Columns[1].Width       = 100;
            Dgv_principal.Columns[1].HeaderText  = "REGISTRO";
            Dgv_principal.Columns[2].Visible     = false;
            Dgv_principal.Columns[3].Width       = 120;
            Dgv_principal.Columns[3].HeaderText  = "NOMBRE";
            Dgv_principal.Columns[4].Width       = 100;
            Dgv_principal.Columns[4].HeaderText  = "1° APELLIDO";
            Dgv_principal.Columns[5].Width       = 100;
            Dgv_principal.Columns[5].HeaderText  = "2° APELLIDO";
            Dgv_principal.Columns[6].Visible     = false;
            Dgv_principal.Columns[7].Width       = 80;
            Dgv_principal.Columns[7].HeaderText  = "TARJETA";
            Dgv_principal.Columns[8].Width       = 200;
            Dgv_principal.Columns[8].HeaderText  = "CUENTA";
            Dgv_principal.Columns[9].Visible     = false;
            Dgv_principal.Columns[10].Width      = 200;
            Dgv_principal.Columns[10].HeaderText = "TARJETA";
            Dgv_principal.Columns[11].Width      = 100;
            Dgv_principal.Columns[11].HeaderText = "SALDO";
            // Ajustar todas las columnas al tamaño del contenido
            Dgv_principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Listado_tarjeta(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Tarjetas.Listado_tarjeta(cTexto);
                this.Formato_TARJETA();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                this.ID_CLIENTE = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_CUENTA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_TP_TARJETA = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_TARJETA"].Value);

                Txt_tarjetaCuenta.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["CODIGO_CUENTA"].Value);
                Txt_tarjetaTipo.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_TARJETA"].Value);
            

                string nomCliente     = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_tarjetaCliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;
            }
        }
        
        private void Formato_TARJETA_CLIENTE()
        {            
            Dgv_tarjCliente.Columns[1].Width = 150;
            Dgv_tarjCliente.Columns[1].HeaderText = "NOMBRE";
            Dgv_tarjCliente.Columns[2].Width = 100;
            Dgv_tarjCliente.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_tarjCliente.Columns[3].Width = 100;
            Dgv_tarjCliente.Columns[3].HeaderText = "2° APELLIDO";
            Dgv_tarjCliente.Columns[0].Visible = false;
        }

        // ----------------------------------------- BLOQUE 2

        private void Listado_TarjCliente()
        {
            try
            {
                Dgv_tarjCliente.DataSource = N_Tarjetas.TARJETA_CLIENE();
                this.Formato_TARJETA_CLIENTE();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato_TARJETA_CUENTA()
        {
            Dgv_tarjCuenta.Columns[0].Visible    = false;
            Dgv_tarjCuenta.Columns[1].Visible    = false;
            Dgv_tarjCuenta.Columns[2].Width      = 60;
            Dgv_tarjCuenta.Columns[2].HeaderText = "NOMBRE";
            Dgv_tarjCuenta.Columns[3].Width      = 100;
            Dgv_tarjCuenta.Columns[3].HeaderText = "1° APELLIDO";
            Dgv_tarjCuenta.Columns[4].Width      = 100;
            Dgv_tarjCuenta.Columns[4].HeaderText = "2° APELLIDO";
        }

        private void Listado_TarjCUENTA()
        {
            try
            {
                Dgv_tarjCuenta.DataSource = N_Tarjetas.TARJETA_CUENTA(Convert.ToInt32(this.ID_CLIENTE));
                this.Formato_TARJETA_CUENTA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato_TP_TARJETA_CLIENTE()
        {            
            Dgv_tipo_tarjeta.Columns[1].Width = 50;
            Dgv_tipo_tarjeta.Columns[1].HeaderText = "TARJETA";
            Dgv_tipo_tarjeta.Columns[0].Visible = false;
        }

        private void Listado_Tarjetas()
        {
            try
            {
                Dgv_tipo_tarjeta.DataSource = N_Tarjetas.TARJETA_CREDITO();
                this.Formato_TP_TARJETA_CLIENTE();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaCliente()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tarjCliente.CurrentRow.Cells["ID_CLIENTE"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CLIENTE       = Convert.ToInt32(Dgv_tarjCliente.CurrentRow.Cells["ID_CLIENTE"].Value);
                string nomCliente     = Convert.ToString(Dgv_tarjCliente.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_tarjCliente.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_tarjCliente.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_tarjetaCliente.Text = nomCliente  + " " + apePateCliente + " " + apeMateCliente;
            }
        }

        // ----------------------------------------- BLOQUE 3

        private void SeleccionaCuenta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tarjCuenta.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CUENTA         = Convert.ToInt32(Dgv_tarjCuenta.CurrentRow.Cells["ID_CUENTA"].Value);
                Txt_tarjetaCuenta.Text = Convert.ToString(Dgv_tarjCuenta.CurrentRow.Cells["NOM_CLIENTE"].Value);
                Txt_tarjetaCuenta.Text = Convert.ToString(Dgv_tarjCuenta.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                Txt_tarjetaCuenta.Text = Convert.ToString(Dgv_tarjCuenta.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);
                Txt_tarjetaCuenta.Text = Convert.ToString(Dgv_tarjCuenta.CurrentRow.Cells["CODIGO_CUENTA"].Value);
            }
        }

        private void SeleccionaTarjeta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_tarjeta.CurrentRow.Cells["ID_TP_TARJETA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_TARJETA   = Convert.ToInt32(Dgv_tipo_tarjeta.CurrentRow.Cells["ID_TP_TARJETA"].Value);
                Txt_tarjetaTipo.Text = Convert.ToString(Dgv_tipo_tarjeta.CurrentRow.Cells["NOM_TARJETA"].Value);
            }
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            lbl_tarjetaCredito.Text = "TARJETAS DE CRÉDITO";
            Frm_Dashboard a = new Frm_Dashboard();
            a.panelDashboardIcono.Visible = true;
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
            Tbc_principal.SelectedIndex = 1;
            lbl_tarjetaCredito.Text = "TARJETAS DE CRÉDITO";
            Txt_tarjetaCliente.Focus();
        }

        // ----------------------------------------- BLOQUE 4

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value)))
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
                    this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                    Rpta = N_Tarjetas.Eliminar_tarjeta(this.ID_TARJETA_CREDITO);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_tarjeta("%");
                        this.ID_TARJETA_CREDITO = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_TARJETA_CREDITO = 0;
            this.ID_CLIENTE         = 0;
            this.ID_CUENTA          = 0;
            this.ID_TP_TARJETA      = 0;
            this.Estadoguarda       = 0;

            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        // ----------------------------------------- BLOQUE 5

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_tarjetaCliente.Text == String.Empty ||
                Txt_tarjetaCuenta.Text  == String.Empty ||
                Txt_tarjetaCliente.Text == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Tarjetas oCl = new E_Tarjetas();

                oCl.ID_TARJETA_CREDITO = this.ID_TARJETA_CREDITO;
                oCl.ID_CLIENTE         = this.ID_CLIENTE;
                oCl.ID_CUENTA          = this.ID_CUENTA;
                oCl.ID_TP_TARJETA      = this.ID_TP_TARJETA;

                Rpta = N_Tarjetas.Guardar_tarjeta(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_tarjeta("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_TARJETA_CREDITO     = 0;
                    lbl_tarjetaCredito.Text = "TARJETAS DE CRÉDITO";
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

        // ----------------------------------------- BLOQUE 6

        private void Frm_TarjetasCredito_Load(object sender, EventArgs e)
        {
            Listado_Tarjetas();
            Listado_TarjCUENTA();
            Listado_TarjCliente();
            lbl_tarjetaCredito.Text = "TARJETAS DE CRÉDITO";
            Listado_tarjeta(Txt_buscar.Text.Trim());
            Dgv_principal.Dock = DockStyle.Fill;
            Dgv_principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_principal.Width = this.ClientSize.Width;
            Dgv_principal.Height = this.ClientSize.Height;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_tarjeta(Txt_buscar.Text.Trim());
            lbl_tarjetaCredito.Text = "TARJETAS DE CRÉDITO";
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_lupa_Click(object sender, EventArgs e)
        {
            this.Pnl_TarjCliente.Location = Btn_buscarTarjCliente.Location;
            this.Pnl_TarjCliente.Visible = true;
            this.Pnl_TarjCuenta.Visible = false;
            this.Pnl_tarjTipo.Visible = false;
        }

        private void Btn_retorno_Click(object sender, EventArgs e)
        {
            Pnl_tarjTipo.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Pnl_TarjCuenta.Location = Btn_buscarTarjCuenta.Location;
            this.Pnl_TarjCuenta.Visible = true;
            this.Pnl_TarjCliente.Visible = false;
            this.Pnl_tarjTipo.Visible = false;
            Listado_TarjCUENTA();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Pnl_tarjTipo.Location = Btn_buscarTipoTarj.Location;
            this.Pnl_tarjTipo.Visible = true;
            this.Pnl_TarjCliente.Visible = false;
            this.Pnl_TarjCuenta.Visible = false;
        }

        // ----------------------------------------- BLOQUE 7

        private void button3_Click(object sender, EventArgs e)
        {
            Pnl_TarjCliente.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pnl_TarjCuenta.Visible = false;
        }

        private void Dgv_tipo_tarjeta_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaTarjeta();
            Pnl_tarjTipo.Visible = false;
            Txt_tarjetaTipo.Focus();
        }

        private void Dgv_tarjCliente_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaCliente();
            Pnl_TarjCliente.Visible = false;
            Txt_tarjetaCliente.Focus();
        }

        private void Dgv_tarjCuenta_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaCuenta();
            Pnl_TarjCuenta.Visible = false;
            Txt_tarjetaCuenta.Focus();
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }

    }
}
