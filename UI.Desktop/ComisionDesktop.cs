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
    public partial class ComisionDesktop : ApplicationForm
    {

        private Comision _ComisionActual;


        #region Propiedades

        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }
        #endregion

        #region Constructores
        public ComisionDesktop()
        {
            InitializeComponent();
            ComisionLogic cl = new ComisionLogic();

            cbPlan.DataSource = cl.GetPlanes();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "id";
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }


        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            this.MapearDeDatos();
        }

        #endregion

        #region Metodos de formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.cbPlan.SelectedValue = this.ComisionActual.IDPlan;
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
                        Comision com = new Comision();
                        ComisionActual = com;
                        this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                        this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                        this.ComisionActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        ComisionActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.ComisionActual.ID = int.Parse(txtID.Text);
                        this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                        this.ComisionActual.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
                        this.ComisionActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        ComisionActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.ComisionActual.ID = int.Parse(this.txtID.Text);
                        ComisionActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
            }
        }

        public override bool Validar()
        {
            String mensaje = null;
            if (String.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                mensaje = "Campo descripcion requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtAnioEspecialidad.Text))
            {
                mensaje += "Campo año especialidad requerido. \n";
            }
            else if (!Validaciones.EsNumeroValido(this.txtAnioEspecialidad.Text))
            {
                mensaje += "No se permiten letras en el campo de año especialidad. \n";
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

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }
        #endregion

        #region Eventos del formulario
        private void ComisionDesktop_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Eventos de controladores
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Eventos utilizados para el diseño
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void ComisionDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
