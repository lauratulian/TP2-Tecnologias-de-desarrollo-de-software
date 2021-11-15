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
using System.Globalization;
using System.Runtime.InteropServices;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        #region Variables
        private Persona _PersonaActual;
        #endregion

        #region Propiedades
        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }
        #endregion

        #region Constructores
        public PersonaDesktop()
        {
            InitializeComponent();
            PersonaLogic dl = new PersonaLogic();

            cbPlan.DataSource = dl.GetPlanes();
            cbPlan.DisplayMember = "descripcion";
            cbPlan.ValueMember = "id";
            cbbTipoPersona.Items.Add("Alumno");
            cbbTipoPersona.Items.Add("Docente");
            cbbTipoPersona.Items.Add("Administrador");

        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic dl = new PersonaLogic();
            PersonaActual = dl.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos del formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtApellido.Text = this.PersonaActual.Apellido.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre.ToString();
            this.txtDireccion.Text = this.PersonaActual.Direccion.ToString();
            this.txtEmail.Text = this.PersonaActual.Email.ToString();
            this.txtFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.cbPlan.SelectedValue = this.PersonaActual.IDPlan.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono.ToString();
            this.cbbTipoPersona.Text = this.PersonaActual.TipoPersona.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
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
            CultureInfo provider = CultureInfo.InvariantCulture;
            switch (Modo)
            {
                case ModoForm.Alta:
                    {
                        Persona per = new Persona();
                        PersonaActual = per;
                        this.PersonaActual.Apellido = this.txtApellido.Text;
                        this.PersonaActual.Nombre = this.txtNombre.Text;
                        this.PersonaActual.Direccion = this.txtDireccion.Text;
                        this.PersonaActual.Email = this.txtEmail.Text;
                        this.PersonaActual.FechaNacimiento = DateTime.ParseExact(this.txtFechaNacimiento.Text, "dd/MM/yyyy", provider);
                        this.PersonaActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        this.PersonaActual.Telefono = this.txtTelefono.Text;
                        this.PersonaActual.TipoPersona = this.AsignarTipo(cbbTipoPersona.SelectedItem.ToString());
                        this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                        PersonaActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.PersonaActual.ID = int.Parse(this.txtID.Text); ;
                        this.PersonaActual.Apellido = this.txtApellido.Text;
                        this.PersonaActual.Nombre = this.txtNombre.Text;
                        this.PersonaActual.Direccion = this.txtDireccion.Text;
                        this.PersonaActual.Email = this.txtEmail.Text;
                        this.PersonaActual.FechaNacimiento = DateTime.Parse(this.txtFechaNacimiento.Text);
                        this.PersonaActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        this.PersonaActual.Telefono = this.txtTelefono.Text;
                        this.PersonaActual.TipoPersona = int.Parse(this.cbPlan.SelectedValue.ToString());
                        this.PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                        PersonaActual.State = BusinessEntity.States.Modified;
                        
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.PersonaActual.ID = int.Parse(this.txtID.Text);
                        PersonaActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
            }
        }

        public override bool Validar()
        {
            String mensaje = null;
            if (String.IsNullOrEmpty(this.txtApellido.Text))
            {
                mensaje = "Campo Apellido requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtNombre.Text))
            {
                mensaje += "Campo Nombre requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtDireccion.Text))
            {
                mensaje += "Campo Direccion requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtEmail.Text))
            {
                mensaje += "Campo Email requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtFechaNacimiento.Text))
            {
                mensaje += "Campo Fecha De Nacimiento requerido. \n";
            }
            else if (!Validaciones.EsMailValido(this.txtEmail.Text))
            {
                mensaje += "El Mail ingresado no es valido. \n";
            }
            if (String.IsNullOrEmpty(this.txtTelefono.Text))
            {
                mensaje += "Campo Telefono requerido. \n";
            }
            else if (!Validaciones.EsNumeroValido(this.txtTelefono.Text))
            {
                mensaje += "No se pueden agregar letras en el nro de telefono. \n";
            }
            {

            }
            if (String.IsNullOrEmpty(this.txtLegajo.Text))
            {
                mensaje += "Campo Legajo requerido. \n";
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

        public int AsignarTipo(string tipo)
        {
            if (tipo.Equals("Administrador"))
            {
                return 3;
            }
            else if (tipo.Equals("Docente"))
            {
                return 2;
            }
            return 1;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic dl = new PersonaLogic();
            dl.Save(PersonaActual);
        }

        public int devIDPersona()
        {

            return int.Parse(txtID.ToString());

        }
        #endregion

        #region Eventos del formulario
        private void DocenteDesktop_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Eventos del controladores
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            { 
                this.GuardarCambios();
                UsuarioDesktop formUsuarios = new UsuarioDesktop(ApplicationForm.ModoForm.Alta, this.PersonaActual.ID, this.PersonaActual.Nombre, this.PersonaActual.Apellido, this.PersonaActual.Email);
                formUsuarios.ShowDialog();
                if (this.PersonaActual.TipoPersona == Cargos.Docente)
                {
                    DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta, this.PersonaActual);
                    formDocente.ShowDialog();
                }
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void PersonaDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
