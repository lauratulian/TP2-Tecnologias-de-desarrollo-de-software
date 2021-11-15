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
    public partial class Materias : Form
    {
        private int _TipoPersona;

        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }


        #region Constructores
        public Materias()
        {
            InitializeComponent();
        }

        public Materias(int tipo_persona) : this()
        {
            TipoPersona = tipo_persona;
        }

        #endregion

        #region Metodos del formulario

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.DataSource = ml.GetAll();
        }
        #endregion

        #region Eventos del formulario

        private void Materias_Load(object sender, EventArgs e)
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(id, ApplicationForm.ModoForm.Baja);
            formMateria.ShowDialog();
            this.Listar();
        }

        #endregion
    }
}