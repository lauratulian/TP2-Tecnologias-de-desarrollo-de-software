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
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {

        #region Variables
        private Plan _PlanActual;
        #endregion

        #region Propiedades
        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }
        #endregion

        #region Constructores
        public PlanDesktop()
        {
            InitializeComponent();
            PlanLogic p = new PlanLogic();

            cbIDEspecialidad.DataSource = p.GetEspecialidades();
            cbIDEspecialidad.DisplayMember = "Descripcion";
            cbIDEspecialidad.ValueMember = "id";
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos de formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            cbIDEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
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
                        Plan esp = new Plan();
                        PlanActual = esp;
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = int.Parse(this.cbIDEspecialidad.SelectedValue.ToString());
                        PlanActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.PlanActual.ID = int.Parse(txtID.Text);
                        this.PlanActual.Descripcion = this.txtDescripcion.Text;
                        this.PlanActual.IDEspecialidad = int.Parse(this.cbIDEspecialidad.SelectedValue.ToString());
                        PlanActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.PlanActual.ID = int.Parse(this.txtID.Text);
                        PlanActual.State = BusinessEntity.States.Deleted;
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
            PlanLogic p1 = new PlanLogic();
            p1.Save(PlanActual);
        }


        #endregion

        #region Eventos del formulario
        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic p = new PlanLogic();

            //cbIDEspecialidad.DataSource = p.GetEspecialidades();
            //cbIDEspecialidad.DisplayMember = "Descripcion";
            //cbIDEspecialidad.ValueMember = "id";
        }
        #endregion

        #region Eventos de controles

        private void cbIDEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

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

        private void PlanDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
