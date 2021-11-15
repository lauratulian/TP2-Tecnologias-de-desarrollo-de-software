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
    public partial class Alumnos : Form
    {
        private Persona _PersonaActual;
        private int _TipoPersona;

        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        public int TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }



        #region Constructores
        public Alumnos()
        {
            InitializeComponent();
        }

        public Alumnos(Persona persona) : this()
        {
            PersonaActual = persona;
            AlumnoLogic al = new AlumnoLogic();
            if (PersonaActual.TipoPersona == Business.Entities.Cargos.Docente)
            {
                tscbCurso.Visible = true;
                tscbCurso.ComboBox.DataSource = al.GetCursoDocente(persona.ID);
                tscbCurso.ComboBox.DisplayMember = "Descripcion";
                tscbCurso.ComboBox.ValueMember = "id";
            }
        }

        public Alumnos(int tipo_persona) : this()
        {
            TipoPersona = tipo_persona;
        }

        #endregion

        #region Metodos del formulario

        public void Listar()
        {
            AlumnoLogic a1 = new AlumnoLogic();
            if (PersonaActual.TipoPersona == Business.Entities.Cargos.Alumno)
            {
                this.tsbEliminar.Visible = false;
                this.tsbEditar.Visible = false;
                this.tsbModificarNota.Visible = false;
                this.dgvAlumnos.DataSource = a1.GetInscripciones(PersonaActual.ID);
            }
            else if (PersonaActual.TipoPersona == Business.Entities.Cargos.Docente)
            {
                this.tsbEliminar.Visible = false;
                this.tsbEditar.Visible = false;
                this.tscbCurso.Visible = true;
                this.tslCurso.Visible = true;
                this.tsbFiltro.Visible = true;

                this.dgvAlumnos.DataSource = a1.GetAlumnosDocente(PersonaActual.ID);
            }
            else
            {
                tsbModificarNota.Visible = false;
                this.dgvAlumnos.DataSource = a1.GetAll();
            }

        }
        #endregion

        #region Eventos del formulario

        private void Alumnos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        #endregion

        #region Eventos de controles
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoDesktop formAlumnos = new AlumnoDesktop(ApplicationForm.ModoForm.Alta);
            formAlumnos.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.AlumnoInscripciones)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnoDesktop formAlumnos = new AlumnoDesktop(id, ApplicationForm.ModoForm.Modificacion);
            formAlumnos.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.AlumnoInscripciones)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnoDesktop formAlumnos = new AlumnoDesktop(id, ApplicationForm.ModoForm.Baja);
            formAlumnos.ShowDialog();
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void tsbModificarNota_Click(object sender, EventArgs e)
        {
            int id = ((AlumnoInscripciones)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnoDesktop formAlumnos = new AlumnoDesktop(id, ApplicationForm.ModoForm.ModificacionNota);
            formAlumnos.ShowDialog();
            this.Listar();
        }

        private void tsbFiltro_Click(object sender, EventArgs e)
        {
            AlumnoLogic a1 = new AlumnoLogic();
            this.dgvAlumnos.DataSource = a1.GetAlumnosDelCurso(int.Parse(tscbCurso.ComboBox.SelectedValue.ToString()));
        }
    }
}
