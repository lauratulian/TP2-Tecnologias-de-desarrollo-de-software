using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class UsuarioDesktop : ApplicationForm
    {
        #region Variables
        private Usuario _UsuarioActual;
        private int _id_persona;

        
        #endregion

        #region Constructores
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo, int id, string nombre,string apellido, string email) : this()
        {
            this.Modo = modo;
            this.txtApellido.Text = apellido;
            this.txtNombre.Text = nombre;
            this.txtEmail.Text = email;
            id_persona = id;
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }


        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            this.MapearDeDatos();
        }

        #endregion

        #region Propiedades
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public int id_persona
        {
            get { return _id_persona; }
            set { _id_persona = value; }
        }

        #endregion

        #region Metodos del formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            String botonAceptar;
            switch (Modo)
            {
                case ModoForm.Alta:
                    {
                        botonAceptar = "Guardar";
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        botonAceptar = "Modificar";
                        break;
                    }
                case ModoForm.Baja:
                    {
                        botonAceptar = "Eliminar";
                        break;
                    }
                case ModoForm.Consulta:
                    {
                        botonAceptar = "Aceptar";
                        break;
                    }
                default:
                    {
                        botonAceptar = "Guardar";
                        break;
                    }
            }
            this.btnAceptar.Text = botonAceptar;
        }
        public override void MapearADatos()
        {
            switch (Modo)
            {
                case ModoForm.Alta:
                    {
                        Usuario usr = new Usuario();
                        UsuarioActual = usr;

                        this.UsuarioActual.Nombre = this.txtNombre.Text;
                        this.UsuarioActual.Apellido = this.txtApellido.Text;
                        this.UsuarioActual.Email = this.txtEmail.Text;
                        this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        this.UsuarioActual.Clave = this.txtClave.Text;
                        this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                        this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
                        this.UsuarioActual.IDPersona = id_persona;
                        UsuarioActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                        this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                        this.UsuarioActual.Nombre = this.txtNombre.Text;
                        this.UsuarioActual.Apellido = this.txtApellido.Text;
                        this.UsuarioActual.Clave = this.txtClave.Text;
                        this.UsuarioActual.Email = this.txtEmail.Text;
                        this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                        this.UsuarioActual.Clave = this.txtConfirmarClave.Text;
                        UsuarioActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.UsuarioActual.ID = int.Parse(this.txtID.Text);
                        UsuarioActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
            }
        }
        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }
        public override bool Validar()
        {
            {
                String mensaje = null;
                if (String.IsNullOrEmpty(this.txtApellido.Text))
                {
                    mensaje = "Campo Apellido requerido \n";

                }
                if (String.IsNullOrEmpty(this.txtNombre.Text))
                {
                    mensaje += "Campo Nombre requerido \n";
                }
                if (String.IsNullOrEmpty(this.txtClave.Text))
                {
                    mensaje += "Campo contraseña requerido \n";
                }
                else
                {
                    if (!Business.Logic.Validaciones.EsContraseniaValida(this.txtClave.Text))
                    {
                        mensaje += "Contraseña incorrecta. Debe contener mas de 8 caracteres.\n";
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(this.txtConfirmarClave.Text))
                        {
                            mensaje += "Campo confirmar contraseña requerido \n";

                        }
                        else
                        {
                            if (!Business.Logic.Validaciones.EsContraseniaValida(this.txtConfirmarClave.Text))
                            {
                                mensaje += "Confirmar contraseña incorrecta. Debe contener mas de 8 caracteres.\n";
                            }
                            else
                            {
                                if (!txtClave.Text.Equals(txtConfirmarClave.Text))
                                {
                                    mensaje += "Las contraseñas no coinciden \n";
                                }
                            }
                        }

                    }
                }
                if (String.IsNullOrEmpty(this.txtEmail.Text))
                {
                    mensaje += "Campo Email requerido \n";
                }
                else
                {
                    if (!Business.Logic.Validaciones.EsMailValido(this.txtEmail.Text))
                    {
                        mensaje += "Mail invalido \n";
                    }
                }
                if (String.IsNullOrEmpty(this.txtUsuario.Text))
                {
                    mensaje += "Campo Usuario requerido \n";
                }
                if (String.IsNullOrEmpty(mensaje))
                {
                    return true;
                }
                else
                {
                    this.Notificar("Error", mensaje, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public int devIDUsuario()
        {
            return int.Parse(this.txtID.Text);
        }
        #endregion

        #region Eventos del Formulario
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Eventos de controles
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Eventos utilizados para el diseño
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void UsuarioDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
