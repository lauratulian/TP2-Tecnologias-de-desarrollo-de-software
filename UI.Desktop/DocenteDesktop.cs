using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using System.Runtime.InteropServices;

namespace UI.Desktop
{
    public partial class DocenteDesktop : ApplicationForm
    {
        #region Variables
        private DocenteCurso _DocenteActual;
        private Persona _PersonaActual;
        #endregion

        #region Propiedades
        public DocenteCurso DocenteActual
        {
            get { return _DocenteActual; }
            set { _DocenteActual = value; }
        }

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        #endregion

        #region Constructores
        public DocenteDesktop()
        {
            InitializeComponent();
            DocenteLogic dl = new DocenteLogic();

            cbCurso.DataSource = dl.GetCursos();
            cbCurso.DisplayMember = "Descripcion";
            cbCurso.ValueMember = "id";
        }

        public DocenteDesktop(ModoForm modo, Persona persona) : this()
        {
            this.Modo = modo;
            PersonaActual = persona;
        }

        public DocenteDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            DocenteLogic dl = new DocenteLogic();
            DocenteActual = dl.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos del formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteActual.ID.ToString();
            this.txtCargo.Text = this.DocenteActual.Cargo.ToString();
            this.cbCurso.SelectedValue = this.DocenteActual.IDCurso;
            this.txtIDDocente.Text = this.DocenteActual.IDDocente.ToString();
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
                        DocenteCurso doc = new DocenteCurso();
                        DocenteActual = doc;
                        this.DocenteActual.Cargo = int.Parse(this.txtCargo.Text);
                        this.DocenteActual.IDCurso = int.Parse(this.cbCurso.SelectedValue.ToString());
                        this.DocenteActual.IDDocente = PersonaActual.ID;
                        DocenteActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.DocenteActual.ID = int.Parse(txtID.Text);
                        this.DocenteActual.Cargo = int.Parse(this.txtCargo.Text);
                        this.DocenteActual.IDCurso = int.Parse(this.cbCurso.SelectedValue.ToString());
                        DocenteActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.DocenteActual.ID = int.Parse(this.txtID.Text);
                        DocenteActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
            }
        }

        public override bool Validar()
        {
            String mensaje = null;
            if (String.IsNullOrEmpty(this.txtCargo.Text))
            {
                mensaje = "Campo cargo requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtIDDocente.Text))
            {
                mensaje += "Campo ID docente requerido. \n";
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
            DocenteLogic dl = new DocenteLogic();
            dl.Save(DocenteActual);
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

        private void DocenteDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
