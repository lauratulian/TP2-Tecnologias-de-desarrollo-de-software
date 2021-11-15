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
    public partial class Docentes : Form
    {

        #region Constructores
        public Docentes()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos del formulario
        public void Listar()
        {
            DocenteLogic dl = new DocenteLogic();
            this.dgvDocentes.DataSource = dl.GetAll();
        }
        #endregion

        #region Eventos del formulario
        private void Docentes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        #endregion

        #region Eventos de controladores
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
            DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formDocente.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
            DocenteDesktop formDocente = new DocenteDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formDocente.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
            DocenteDesktop formDocente = new DocenteDesktop(id, ApplicationForm.ModoForm.Baja);
            formDocente.ShowDialog();
            this.Listar();
        }
        #endregion


    }
}
