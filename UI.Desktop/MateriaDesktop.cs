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
    public partial class MateriaDesktop : ApplicationForm
    {
        #region Variables
        private Materia _MateriaActual;
        #endregion

        #region Propiedades
        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }
        #endregion

        #region Constructores
        public MateriaDesktop()
        {
            InitializeComponent();
            MateriaLogic ml = new MateriaLogic();

            cbPlan.DataSource = ml.GetPlanes();
            cbPlan.DisplayMember = "Descripcion";
            cbPlan.ValueMember = "id";
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos del formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            cbPlan.SelectedValue = this.MateriaActual.IDPlan;
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
                        Materia mat = new Materia();
                        MateriaActual = mat;
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                        this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                        this.MateriaActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        MateriaActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.MateriaActual.ID = int.Parse(txtID.Text);
                        this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                        this.MateriaActual.HSSemanales = int.Parse(this.txtHSSemanales.Text);
                        this.MateriaActual.HSTotales = int.Parse(this.txtHSTotales.Text);
                        this.MateriaActual.IDPlan = int.Parse(this.cbPlan.SelectedValue.ToString());
                        MateriaActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.MateriaActual.ID = int.Parse(this.txtID.Text);
                        MateriaActual.State = BusinessEntity.States.Deleted;
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
            if (String.IsNullOrEmpty(this.txtHSSemanales.Text))
            {
                mensaje += "Campo Horas Semanales requerido. \n";
            }
            if (String.IsNullOrEmpty(this.txtHSTotales.Text))
            {
                mensaje += "Campo Horas Totales requerido. \n";
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
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
        }
        #endregion

        #region Eventos del formulario

        private void MateriaDesktop_Load(object sender, EventArgs e)
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

        private void MateriaDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        #endregion
    }
}
