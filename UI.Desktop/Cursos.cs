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
    public partial class Cursos : Form
    {
        private Persona _PersonaActual;

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

        #region Constructores
        public Cursos()
        {
            InitializeComponent();
        }

        public Cursos(Persona pers) : this()
        {
            PersonaActual = pers;
        }

        #endregion

        #region Metodos del formulario
        public void Listar()
        {
            if (PersonaActual.TipoPersona == Cargos.Alumno)
            {
                this.tsbEditar.Visible = false;
                this.tsbEliminar.Visible = false;
                this.tsbNuevo.Visible = false;
                CursoLogic cl = new CursoLogic();
                this.dgvCursos.DataSource = cl.GetAllDisponibles();
            }
            else
            {
                CursoLogic cl = new CursoLogic();
                this.dgvCursos.DataSource = cl.GetAll();
            }

        }
        #endregion

        #region Eventos del formulario
        private void Cursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        #endregion

        #region Evento de controles
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop formCurso = new CursoDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoDesktop formCurso = new CursoDesktop(id, ApplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("No se puede eliminar un curso si tiene materias y comisiones asignadas.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Listar();
            }

        }
        private void tsbIncripcion_Click(object sender, EventArgs e)
        {
            AlumnoDesktop formAlumnos = new AlumnoDesktop(ApplicationForm.ModoForm.Alta, PersonaActual);
            formAlumnos.ShowDialog();
            this.Listar();
        }


        #endregion


    }
}