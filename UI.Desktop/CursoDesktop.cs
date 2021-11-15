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
    public partial class CursoDesktop : ApplicationForm
    {

        private Curso _CursoActual;
        private string _DescComision;
        private string _DescMateria;

        #region Propiedades

        public Curso CursoActual
        {
            get { return _CursoActual; }
            set { _CursoActual = value; }
        }

        public string DescComision
        {
            get { return _DescComision; }
            set { _DescComision = value; }
        }

        public string DescMateria
        {
            get { return _DescMateria; }
            set { _DescMateria = value; }
        }
        #endregion

        #region Constructores
        public CursoDesktop()
        {
            InitializeComponent();
            CursoLogic cl = new CursoLogic();

            cbComision.DataSource = cl.GetComisiones();
            cbComision.DisplayMember = "Descripcion";
            cbComision.ValueMember = "id";

            cbMateria.DataSource = cl.GetMaterias();
            cbMateria.DisplayMember = "Descripcion";
            cbMateria.ValueMember = "id";
        }


        public CursoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }


        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos de formualario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.cbMateria.SelectedValue = this.CursoActual.IDMateria;
            this.cbComision.SelectedValue = this.CursoActual.IDComision;
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
                        Curso cur = new Curso();
                        CursoActual = cur;
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.IDMateria = int.Parse(this.cbMateria.SelectedValue.ToString());
                        this.CursoActual.IDComision = int.Parse(this.cbComision.SelectedValue.ToString());
                        CursoActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.CursoActual.ID = int.Parse(txtID.Text);
                        this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                        this.CursoActual.Cupo = int.Parse(this.txtCupo.Text);
                        this.CursoActual.IDMateria = int.Parse(this.cbMateria.SelectedValue.ToString());
                        this.CursoActual.IDComision = int.Parse(this.cbComision.SelectedValue.ToString());
                        CursoActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.CursoActual.ID = int.Parse(this.txtID.Text);
                        CursoActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
            }
        }

        public override bool Validar()
        {
            String mensaje = null;
            if (String.IsNullOrEmpty(this.txtAnioCalendario.Text))
            {
                mensaje = "Campo año calendario requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtCupo.Text))
            {
                mensaje += "Campo cupo requerido. \n";
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
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
        }
        #endregion

        #region Eventos del formulario
        private void CursoDesktop_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Eventos de controladores
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
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

 
        private void CursoDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
   

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
