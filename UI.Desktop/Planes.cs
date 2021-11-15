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

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        private int _TipoPersona;

        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }

        #region Constructores

        public Planes()
        {
            InitializeComponent();
        }

        public Planes(int tipo_persona) : this()
        {
            TipoPersona = tipo_persona;
        }

        #endregion

        #region Metodos del formulario

        public void Listar()
        {
            PlanLogic ul = new PlanLogic();
            this.dgvPlanes.DataSource = ul.GetAll();
        }
        #endregion

        #region Eventos del formulario

        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        #endregion

        #region Eventos de controles
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formPlan.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(id, ApplicationForm.ModoForm.Baja);
            formPlan.ShowDialog();
            this.Listar();
        }
        #endregion


    }
}
