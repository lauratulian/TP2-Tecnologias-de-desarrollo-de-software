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

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        private int _TipoPersona;

        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }


        #region Constructores
        public Comisiones()
        {
            InitializeComponent();
        }

        public Comisiones(int tipo_persona) : this()
        {
            TipoPersona = tipo_persona;
        }
        #endregion

        #region Metodos del formulario
        public void Listar()
        {
            ComisionLogic cl = new ComisionLogic();
            this.dgvComisiones.DataSource = cl.GetAll();
        }
        #endregion

        #region Eventos del formulario
        private void Comisiones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        #endregion

        #region Eventos de controles
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(id, ApplicationForm.ModoForm.Baja);
            formComision.ShowDialog();
            this.Listar();
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
    }
}
