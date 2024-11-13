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
    public partial class Frm_DetallePrestamos : Form
    {
        public Frm_DetallePrestamos()
        {
            InitializeComponent();
        }

        int ID_PRESTAMO        = 0;
        int ID_CLIENTE         = 0;
        int ID_CUENTA          = 0;
        int ID_TARJETA_CREDITO = 0;   
        int ID_TP_PRESTAMO     = 0;
        int ID_TP_PAGO     = 0;
  //      int MONTO_PRESTADO     = 0;
  //      int SALDO_ABONADO      = 0;
        int Estadoguarda       = 0;

        private void Estado_texto(bool lestado)
        {
            Txt_montoPrestado.ReadOnly = !lestado;
        }

        private void Limpia_texto()
        {
            Txt_montoPrestado.Text  = "";
            Txt_cliente.Text        = "";
            Txt_cuenta.Text         = "";
            Txt_tarjetaCredito.Text = "";
            Txt_tipoPago.Text       = "";
            Txt_tipoPrestamo.Text   = "";
        }

        private void Formato_prestamoGeneral()
        {
            Dgv_principal.Columns[0].Visible     = false;
            Dgv_principal.Columns[1].Width       = 150;
            Dgv_principal.Columns[1].HeaderText  = "REGISTRO";
            Dgv_principal.Columns[2].Width       = 90;
            Dgv_principal.Columns[2].HeaderText  = "CUENTA";
            Dgv_principal.Columns[3].Visible     = false;
            Dgv_principal.Columns[4].Width       = 90;
            Dgv_principal.Columns[4].HeaderText  = "TARJETA";
            Dgv_principal.Columns[5].Visible     = false;
            Dgv_principal.Columns[6].Visible     = false;
            Dgv_principal.Columns[7].Visible     = false;
            Dgv_principal.Columns[8].Visible     = false;         
            Dgv_principal.Columns[9].Visible     = false; 
            Dgv_principal.Columns[10].Visible    = false;
            Dgv_principal.Columns[11].Width      = 100;
            Dgv_principal.Columns[11].HeaderText = "PRESTAMO";
            Dgv_principal.Columns[12].Visible    = false;
            Dgv_principal.Columns[13].Width      = 100;
            Dgv_principal.Columns[13].HeaderText = "TIPO";
            Dgv_principal.Columns[14].Width      = 120;
            Dgv_principal.Columns[14].HeaderText = "PAGO";
            Dgv_principal.Columns[15].Width      = 180;
            Dgv_principal.Columns[15].HeaderText = "NOMBRE";
            Dgv_principal.Columns[16].Width      = 180;
            Dgv_principal.Columns[16].HeaderText = "1° APELLIDO";
            Dgv_principal.Columns[17].Width      = 150;
            Dgv_principal.Columns[17].HeaderText = "2° APELLIDO";
            Dgv_principal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Listado_prestamoGeneral(string cTexto)
        {
            try
            {
                Dgv_principal.DataSource = N_Prestamos.ListadoPrestamoGeneral(cTexto);
                this.Formato_prestamoGeneral();
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
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_PRESTAMO        = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value);

                this.ID_CUENTA          = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CUENTA"].Value);
                this.ID_CLIENTE         = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_CLIENTE"].Value);
                this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                this.ID_TP_PRESTAMO     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PRESTAMO"].Value); 
                this.ID_TP_PAGO     = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_TP_PAGO"].Value);

                string nomCliente       = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente   = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente   = Convert.ToString(Dgv_principal.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text        = nomCliente + " " + apePateCliente + " " + apeMateCliente;

                Txt_cuenta.Text         = Convert.ToString(Dgv_principal.CurrentRow.Cells["CODIGO_CUENTA"].Value);
                Txt_tarjetaCredito.Text = Convert.ToString(Dgv_principal.CurrentRow.Cells["CODIGO_TARJETA"].Value);
                Txt_tipoPago.Text       = Convert.ToString(Dgv_principal.CurrentRow.Cells["TIPO_COBRO"].Value);
                Txt_tipoPrestamo.Text   = Convert.ToString(Dgv_principal.CurrentRow.Cells["NOM_PRESTAMO"].Value);

                Txt_montoPrestado.Text  = Convert.ToString(Dgv_principal.CurrentRow.Cells["MONTO_PRESTADO"].Value);
            }
        }

        private void FormatoPrestamo_Cliente()
        {
            Dgv_tipo_pers.Columns[0].Visible    = false;
            Dgv_tipo_pers.Columns[1].Width      = 150;
            Dgv_tipo_pers.Columns[1].HeaderText = "NOMBRE";
            Dgv_tipo_pers.Columns[2].Width      = 100;
            Dgv_tipo_pers.Columns[2].HeaderText = "1° APELLIDO";
            Dgv_tipo_pers.Columns[3].Width      = 100;
            Dgv_tipo_pers.Columns[3].HeaderText = "2° APELLIDO";
        }

        private void ListadoPrestamo_Cliente()
        {
            try
            {
                Dgv_tipo_pers.DataSource = N_Prestamos.prestamoCliente();
                this.FormatoPrestamo_Cliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoPrestamo_Cuenta()
        {
            Dgv_cuenta.Columns[0].Visible    = false;
            Dgv_cuenta.Columns[1].Visible    = false;
            Dgv_cuenta.Columns[2].Width      = 100;
            Dgv_cuenta.Columns[2].HeaderText = "NOMBRE";
            Dgv_cuenta.Columns[3].Width      = 100;
            Dgv_cuenta.Columns[3].HeaderText = "1° APELLIDO";
            Dgv_cuenta.Columns[4].Width      = 100;
            Dgv_cuenta.Columns[4].HeaderText = "2° APELLIDO";
        }

        private void ListadoPrestamo_Cuenta()
        {
            try
            {
                Dgv_cuenta.DataSource = N_Prestamos.prestamoCuenta();
                this.FormatoPrestamo_Cuenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoPrestamo_Tarjeta()
        {
            Dgv_tarjetaCredito.Columns[0].Visible    = false;
            Dgv_tarjetaCredito.Columns[1].Visible    = false;
            Dgv_tarjetaCredito.Columns[2].Width      = 100;
            Dgv_tarjetaCredito.Columns[2].HeaderText = "NOMBRE"; 
            Dgv_tarjetaCredito.Columns[3].Width      = 60;
            Dgv_tarjetaCredito.Columns[3].HeaderText = "1° APELLIDO";
            Dgv_tarjetaCredito.Columns[4].Width      = 60;
            Dgv_tarjetaCredito.Columns[4].HeaderText = "2° APELLIDO";
        }

        private void ListadoPrestamo_Tarjeta()
        {
            try
            {
                Dgv_tarjetaCredito.DataSource = N_Prestamos.prestamoTarjetaCredito();
                this.FormatoPrestamo_Tarjeta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoPrestamo_TipoPrestamo()
        {
            Dgv_tipoPrestamo.Columns[0].Visible    = false;
            Dgv_tipoPrestamo.Columns[1].Width      = 150;
            Dgv_tipoPrestamo.Columns[1].HeaderText = "TIPO";
        }

        private void ListadoPrestamo_TipoPrestamo()
        {
            try
            {
                Dgv_tipoPrestamo.DataSource = N_Prestamos.prestamoTipoPrestamo();
                this.FormatoPrestamo_TipoPrestamo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FormatoPrestamo_TipoPago()
        {
            Dgv_tipoPago.Columns[0].Visible    = false;
            Dgv_tipoPago.Columns[1].Width      = 80;
            Dgv_tipoPago.Columns[1].HeaderText = "TIPO";
        }


        private void ListadoPrestamo_TipoPago()
        {
            try
            {
                Dgv_tipoPago.DataSource = N_Prestamos.prestamoTipoPago();
                this.FormatoPrestamo_TipoPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SeleccionaPrestamo_Cliente()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["ID_CLIENTE"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CLIENTE       = Convert.ToInt32(Dgv_tipo_pers.CurrentRow.Cells["ID_CLIENTE"].Value);
                string nomCliente     = Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["NOM_CLIENTE"].Value);
                string apePateCliente = Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["APE_PATE_CLIENTE"].Value);
                string apeMateCliente = Convert.ToString(Dgv_tipo_pers.CurrentRow.Cells["APE_MATE_CLIENTE"].Value);

                Txt_cliente.Text = nomCliente + " " + apePateCliente + " " + apeMateCliente;
            }
        }

        private void SeleccionaPrestamo_Cuenta()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_cuenta.CurrentRow.Cells["ID_CUENTA"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_CUENTA        = Convert.ToInt32(Dgv_cuenta.CurrentRow.Cells["ID_CUENTA"].Value);
                Txt_cuenta.Text       = Convert.ToString(Dgv_cuenta.CurrentRow.Cells["CODIGO_CUENTA"].Value);
            }
        }

        private void SeleccionaPrestamo_TarjetaCredito()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tarjetaCredito.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TARJETA_CREDITO = Convert.ToInt32(Dgv_tarjetaCredito.CurrentRow.Cells["ID_TARJETA_CREDITO"].Value);
                Txt_tarjetaCredito.Text = Convert.ToString(Dgv_tarjetaCredito.CurrentRow.Cells["CODIGO_TARJETA"].Value);
            }
        }

        private void SeleccionaPrestamo_TipoPrestamo()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipoPrestamo.CurrentRow.Cells["ID_TP_PRESTAMO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_PRESTAMO   = Convert.ToInt32(Dgv_tipoPrestamo.CurrentRow.Cells["ID_TP_PRESTAMO"].Value);
                Txt_tipoPrestamo.Text = Convert.ToString(Dgv_tipoPrestamo.CurrentRow.Cells["NOM_PRESTAMO"].Value);
            }
        }

        private void SeleccionaPrestamo_TipoPago()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tipoPago.CurrentRow.Cells["ID_TP_PAGO"].Value)))
            {
                MessageBox.Show("No se tiene información para visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.ID_TP_PAGO = Convert.ToInt32(Dgv_tipoPago.CurrentRow.Cells["ID_TP_PAGO"].Value);
                Txt_tipoPago.Text   = Convert.ToString(Dgv_tipoPago.CurrentRow.Cells["TIPO_COBRO"].Value);
            }
        }

        private void Estado_Botonesprocesos(bool lEstado)
        {
            this.Btn_cancelar.Visible = lEstado;
            this.Btn_guardar.Visible  = lEstado;
            this.Btn_retornar.Visible = !lEstado;
        }

        private void Btn_salir_cliente_Click(object sender, EventArgs e)
        {
            this.Close();
            lbl_prestamos.Text = "PRESTAMOS";
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
            Tbc_principal.SelectedIndex = 1;
            Txt_montoPrestado.Text = "0.00";
            lbl_prestamos.Text = "PRESTAMOS";
            Txt_montoPrestado.Focus();
        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            Estadoguarda = 2; //Actualizar Registro
            this.SeleccionaItem();
            this.Estado_Botonesprincipales(false);
            this.Estado_Botonesprocesos(true);
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_montoPrestado.Focus();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value)))
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
                    this.ID_PRESTAMO = Convert.ToInt32(Dgv_principal.CurrentRow.Cells["ID_PRESTAMO"].Value);
                    Rpta = N_Prestamos.Eliminar_prestamos(this.ID_PRESTAMO);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_prestamoGeneral("%");
                        this.ID_PRESTAMO = 0;
                        MessageBox.Show("Registro Eliminado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Btn_retornar_Click(object sender, EventArgs e)
        {
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            if (
                Txt_cliente.Text        == String.Empty ||
                Txt_cuenta.Text         == String.Empty ||
                Txt_tarjetaCredito.Text == String.Empty ||
                Txt_tipoPago.Text       == String.Empty ||
                Txt_tipoPrestamo.Text   == String.Empty ||
                Txt_montoPrestado.Text  == String.Empty )
            {
                MessageBox.Show("Falta ingresa datos requeridos (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else //Se procedería a registrar la información
            {
                string Rpta = "";
                E_Prestamos oCl = new E_Prestamos();

                oCl.ID_PRESTAMO        = this.ID_PRESTAMO;
                oCl.ID_CLIENTE         = this.ID_CLIENTE;
                oCl.ID_CUENTA          = this.ID_CUENTA;
                oCl.ID_TARJETA_CREDITO = this.ID_TARJETA_CREDITO;
                oCl.ID_TP_PRESTAMO     = this.ID_TP_PRESTAMO;
                oCl.ID_TP_PAGO     = this.ID_TP_PAGO;
                oCl.MONTO_PRESTADO     = Convert.ToDecimal(Txt_montoPrestado.Text);

                Rpta = N_Prestamos.Guardar_prestamos(Estadoguarda, oCl);
                if (Rpta.Equals("OK"))
                {
                    this.Listado_prestamoGeneral("%");
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Estadoguarda = 0; // Sin nunguna acción
                    this.Estado_Botonesprincipales(true);
                    this.Estado_Botonesprocesos(false);
                    this.Estado_texto(false);
                    Tbc_principal.SelectedIndex = 0;
                    this.ID_PRESTAMO = 0;
                    lbl_prestamos.Text = "PRESTAMOS";
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.ID_PRESTAMO        = 0;
            this.ID_CLIENTE         = 0;
            this.ID_CUENTA          = 0;
            this.ID_TARJETA_CREDITO = 0;
            this.ID_TP_PRESTAMO     = 0;
            this.ID_TP_PAGO     = 0;
            this.Estadoguarda       = 0;

            this.Estado_texto(false);
            this.Limpia_texto();
            this.Estado_Botonesprincipales(true);
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_prestamoGeneral(Txt_buscar.Text.Trim());
            lbl_prestamos.Text = "PRESTAMOS";
        }

        private void Frm_DetallePrestamos_Load(object sender, EventArgs e)
        {
            
            ListadoPrestamo_Cliente();
            ListadoPrestamo_Tarjeta();
            ListadoPrestamo_TipoPago();
            ListadoPrestamo_TipoPrestamo();
            ListadoPrestamo_Cuenta();
            Listado_prestamoGeneral(Txt_buscar.Text.Trim());
            lbl_prestamos.Text = "PRESTAMOS";
        }

        private void Btn_lupaCliente_Click(object sender, EventArgs e)
        {
            this.Pnl_Tipo_personas.Location = Btn_lupaCliente.Location;
            this.Pnl_Tipo_personas.Visible  = true;
            this.Pnl_tarjeta.Visible        = false;
            this.Pnl_tipoPago.Visible       = false;
            this.Pnl_tipoPrestamo.Visible   = false;
            this.Pnl_cuenta.Visible         = false;
        }

        private void Btn_lupaCuenta_Click(object sender, EventArgs e)
        {
            this.Pnl_cuenta.Location = Btn_lupaCuenta.Location;
            this.Pnl_cuenta.Visible        = true;
            this.Pnl_tarjeta.Visible       = false;
            this.Pnl_tipoPago.Visible      = false;
            this.Pnl_tipoPrestamo.Visible  = false;
            this.Pnl_Tipo_personas.Visible = false;
        }

        private void Btn_lupaTarjeta_Click(object sender, EventArgs e)
        {
            this.Pnl_tarjeta.Location = Btn_lupaTarjeta.Location;
            this.Pnl_tarjeta.Visible       = true;
            this.Pnl_cuenta.Visible        = false;
            this.Pnl_tipoPago.Visible      = false;
            this.Pnl_tipoPrestamo.Visible  = false;
            this.Pnl_Tipo_personas.Visible = false;
        }

        private void Btn_lupaPrestamo_Click(object sender, EventArgs e)
        {
            this.Pnl_tipoPrestamo.Location = Btn_lupaPrestamo.Location;
            this.Pnl_tipoPrestamo.Visible  = true;
            this.Pnl_cuenta.Visible        = false;
            this.Pnl_tipoPago.Visible      = false;
            this.Pnl_tarjeta.Visible       = false;
            this.Pnl_Tipo_personas.Visible = false;
        }

        private void Btn_lupaPago_Click(object sender, EventArgs e)
        {
            this.Pnl_tipoPago.Location = Btn_lupaPago.Location;
            this.Pnl_tipoPago.Visible      = true;
            this.Pnl_cuenta.Visible        = false;
            this.Pnl_tipoPrestamo.Visible  = false;
            this.Pnl_tarjeta.Visible       = false;
            this.Pnl_Tipo_personas.Visible = false;
        }

        private void Btn_retorno_Click(object sender, EventArgs e)
        {
            Pnl_Tipo_personas.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pnl_tipoPago.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pnl_cuenta.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pnl_tarjeta.Visible = false;
        }

        private void Dgv_tipo_pers_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPrestamo_Cliente();
            Pnl_Tipo_personas.Visible = false;
            Txt_cliente.Focus();
        }

        private void Dgv_tipoPago_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPrestamo_TipoPago();
            Pnl_tipoPago.Visible = false;
            Txt_tipoPago.Focus();
        }

        private void Dgv_cuenta_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPrestamo_Cuenta();
            Pnl_cuenta.Visible = false;
            Txt_cuenta.Focus();
        }

        private void Dgv_tarjetaCredito_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPrestamo_TarjetaCredito();
            Pnl_tarjeta.Visible = false;
            Txt_tarjetaCredito.Focus();
        }

        private void Dgv_tipoPrestamo_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaPrestamo_TipoPrestamo();
            Pnl_tipoPrestamo.Visible = false;
            Txt_tipoPrestamo.Focus();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Pnl_tipoPrestamo.Visible = false;
        }

        private void Dgv_principal_DoubleClick(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
            Txt_montoPrestado.Focus();
        }

        private void Dgv_principal_DoubleClick_1(object sender, EventArgs e)
        {
            this.SeleccionaItem();
            this.Estado_Botonesprocesos(false);
            Tbc_principal.SelectedIndex = 1;
        }
    }
}