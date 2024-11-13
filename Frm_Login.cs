using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Clave3_Grupo4
{
    public partial class Frm_Login : Form
    {
        Conexion conMysql = new Conexion();
        public Frm_Login()
        {
            InitializeComponent();
            try
            {
                conMysql.Connect();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Login_us(txtUsuario.Text, txtContraseña.Text);
        }

        private void Login_us(string USUARIO, string CONTRASEÑA)
        {
            try
            {
                DataTable data_login = new DataTable();
                DataTable dataTable = conMysql.getData("select ID_USER, USUARIO, ADMIN, PRESTAMOS, CUENTAS, TARJETAS from tb_usuario where usuario='" + USUARIO + "' and contraseña=aes_encrypt(usuario,'" + CONTRASEÑA + "') ");
                data_login = dataTable;
                if (data_login.Rows.Count > 0)
                {
                    string cNombres  = "";
                    string cCargo    = "";
                    bool   bAdmin    = false;
                    bool   bPrestamo = false;
                    bool   bCuentas  = false;
                    bool   bTarjetas = false;

                    bAdmin    = Convert.ToBoolean(Convert.ToInt32(data_login.Rows[0][2]));
                    bPrestamo = Convert.ToBoolean(Convert.ToInt32(data_login.Rows[0][3]));
                    bCuentas  = Convert.ToBoolean(Convert.ToInt32(data_login.Rows[0][4]));
                    bTarjetas = Convert.ToBoolean(Convert.ToInt32(data_login.Rows[0][5]));

                    if (bAdmin == false && bPrestamo == false && bCuentas == false && bTarjetas == false)
                    {
                        DataTable data_login1 = new DataTable();
                        DataTable dataTable1 = conMysql.getData("SELECT E.NOM_CLIENTE, E.APE_PATE_CLIENTE, E.APE_MATE_CLIENTE, U.USUARIO, " +
                            "U.CONTRASEÑA, U.ADMIN, U.PRESTAMOS, U.CUENTAS, U.TARJETAS " +
                            "FROM TB_CLIENTE E " +
                            "INNER JOIN TB_USUARIO AS U ON E.ID_USER = U.ID_USER where U.USUARIO='" + USUARIO + "' and U.CONTRASEÑA=aes_encrypt(U.USUARIO,'" + CONTRASEÑA + "')");
                        data_login1 = dataTable1;
                        if (data_login1.Rows.Count > 0)
                        {
                            cCargo = "Cliente" ;
                            cNombres = Convert.ToString(data_login1.Rows[0][0]) + " " + Convert.ToString(data_login1.Rows[0][1]) + " " + Convert.ToString(data_login1.Rows[0][2]);
                        }
                    }
                    else
                    {
                        DataTable data_login1 = new DataTable();
                        DataTable dataTable1 = conMysql.getData("SELECT E.NOM_EMPLEADO, E.APE_PATE, E.APE_MATE, + " +
                            "CE.NOM_CARGO, U.USUARIO, U.CONTRASEÑA, U.ADMIN, U.PRESTAMOS, U.CUENTAS, U.TARJETAS, U.ESTADO ESTADO_US " +
                            "FROM TB_EMPLEADO E " +
                            "INNER JOIN TB_CARGO_EMPLEADO CE ON E.ID_CARGO_EM = CE.ID_CARGO_EM " +
                            "INNER JOIN TB_USUARIO AS U ON E.ID_USER = U.ID_USER where U.USUARIO='" + USUARIO + "' and U.CONTRASEÑA=aes_encrypt(U.USUARIO,'" + CONTRASEÑA + "')");
                        data_login1 = dataTable1;
                        if (data_login1.Rows.Count > 0)
                        {
                            cCargo = Convert.ToString(data_login1.Rows[0][3]);
                            cNombres = Convert.ToString(data_login1.Rows[0][0]) + " " + Convert.ToString(data_login1.Rows[0][1]) + " " + Convert.ToString(data_login1.Rows[0][2]);
                        }
                    }

                    Frm_Dashboard oDashBoard       = new Frm_Dashboard();
                    oDashBoard.Lbl_nombres_us.Text = "Nombres: " + cNombres ;
                    oDashBoard.Lbl_cargo.Text      = "Cargo: "   + cCargo;
                    oDashBoard.Chk_admin.Checked   = bAdmin;

                    if (bAdmin == true) // Usuario Administrador
                    {
                        oDashBoard.btn_empleados.Enabled           = true;
                        oDashBoard.btn_cliente.Enabled             = true;
                        oDashBoard.btn_cuentasBanco.Enabled        = true;
                        oDashBoard.btn_tarjetasCredito.Enabled     = true;
                        oDashBoard.btn_prestamos.Enabled           = true;
                    }

                    else if (bPrestamo == true) // Usuario Víctor Martínez
                    {
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_prestamos.Enabled           = true;

                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_empleados.Enabled           = true;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;
                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                    }

                    else if (bCuentas == true) // Usuario Héctor Mérino
                    {
                        oDashBoard.btn_cuentasBanco.Enabled        = true;
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_MV_cuentas.Enabled          = true;

                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;

                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                    }

                    else if (bTarjetas == true) // Usuario Miguel Ayala
                    {
                        oDashBoard.btn_movimientos.Enabled         = true;
                        oDashBoard.btn_MV_tarjetas.Enabled         = true;
                        oDashBoard.btn_tarjetasCredito.Enabled     = true;
                        oDashBoard.btn_detalleTarjetasCred.Enabled = true;

                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        
                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = false;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;

                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;
                    }

                    else if (bAdmin == false) // Usuario Melvin Esteven
                    {
                        oDashBoard.btn_movimientos.Enabled         = false;
                        oDashBoard.btn_MV_cuentas.Enabled          = false;
                        oDashBoard.btn_MV_tarjetas.Enabled         = false;
                        oDashBoard.btn_MV_abono.Enabled            = false;

                        oDashBoard.btn_prestamos.Enabled           = false;
                        oDashBoard.btn_cuentasBanco.Enabled        = false;
                        oDashBoard.btn_tarjetasCredito.Enabled     = false;
                        oDashBoard.btn_empleados.Enabled           = false;
                        oDashBoard.btn_cliente.Enabled             = true;

                        oDashBoard.btn_tipoCliente.Enabled         = false;
                        oDashBoard.btn_tipoCuentas.Enabled         = false;
                        oDashBoard.btn_tipoTarjetas.Enabled        = false;
                        oDashBoard.btn_tipoPrestamo.Enabled        = false;
                        oDashBoard.btn_tipoPagoPrestamo.Enabled    = false;
                    }
                    oDashBoard.Show();
                    oDashBoard.FormClosed += Logout;
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Acceso denegado", "Aviso del Sistema");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text    = "";
            txtContraseña.Text = "";
            this.Close();
            txtUsuario.Focus();
        }
    }
}