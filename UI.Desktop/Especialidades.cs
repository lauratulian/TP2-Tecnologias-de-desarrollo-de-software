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
    public partial class Especialidades : Form
    {
        private int _TipoPersona;

        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }


        #region Constructores
        public Especialidades()
        {
            InitializeComponent();
        }

        public Especialidades(int tipo_persona) : this()
        {
            TipoPersona = tipo_persona;
        }
        #endregion

        #region Metodos del formulario

        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }
        #endregion

        #region Eventos del formulario

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }
        #endregion

        #region Eventos de controles
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(id, ApplicationForm.ModoForm.Baja);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        #endregion



    }
}
