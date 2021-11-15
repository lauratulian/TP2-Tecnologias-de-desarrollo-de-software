using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Runtime.InteropServices;

namespace UI.Desktop
{
    public partial class Login : Form
    {
        private int _IDPersona;

        public int IDPersona { get => _IDPersona; set => _IDPersona = value; }

        #region Metodos del formulario 

        public Persona GetPersona()
        {
            UsuarioLogic ul = new UsuarioLogic();
            return ul.GetPersona(IDPersona);
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }

        #endregion

        #region Constructores
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos de controles
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtNombreUsuario.Text != "Username" && txtNombreUsuario.TextLength > 2)
            {
                if (txtContrasenia.Text != "Password")
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    Usuario usu = ul.Login(txtNombreUsuario.Text, txtContrasenia.Text);
                    if (usu != null)
                    {

                        IDPersona = usu.IDPersona;
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        msgError("Incorrect username or password entered. \n   Please try again.");
                        txtContrasenia.Text = "Password";
                        txtContrasenia.UseSystemPasswordChar = false;
                        txtNombreUsuario.Focus();
                        txtContrasenia.Focus();
                    }
                }
                else msgError("Por favor ingrese la contraseña.");

            }
            else msgError("Por favor ingrese su usuario.");
        }

   
      
        #endregion

        #region Eventos del formulario
        private void Login_Load(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Eventos y metodos utilizados para el del diseño

        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "Usuario")
            {
                txtNombreUsuario.Text = "";
                txtNombreUsuario.ForeColor = Color.LightGray;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "")
            {
                txtNombreUsuario.Text = "Usuario";
                txtNombreUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "Contraseña")
            {
                txtContrasenia.Text = "";
                txtContrasenia.ForeColor = Color.LightGray;
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "Contraseña";
                txtContrasenia.ForeColor = Color.Silver;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion

    }
}
