using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Principal : Form
    {
        private Persona _PersonaLogueada;

        public Persona PersonaLogueada { get => _PersonaLogueada; set => _PersonaLogueada = value; }

        public Principal()
        {
            InitializeComponent();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Usuarios());
        }


        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Alumnos(PersonaLogueada));
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Docentes());
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Especialidades());
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Planes());
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Materias());
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Cursos(PersonaLogueada));
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Comisiones());
        }

        private void Principal1_Load(object sender, EventArgs e)
        {
            Login formLogin = new Login();
            if (formLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                PersonaLogueada = formLogin.GetPersona();
                switch (PersonaLogueada.TipoPersona)
                {
                    case 1:
                        this.MostrarAlumnos();
                        break;
                    case 2:
                        this.MostrarProfesor();
                        break;
                    case 3:
                        this.MostrarAdmin();
                        break;
                }
            }

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelSubMenuReportes.Visible = true;
        }

        private void btnReporteCurso_Click(object sender, EventArgs e)
        {
            ReportesCursos formReportesCursos = new ReportesCursos();
            formReportesCursos.ShowDialog();
            panelSubMenuReportes.Visible = false;
        }

        private void btnReportePlanes_Click(object sender, EventArgs e)
        {
            ReportesPlanes formReportesPlanes = new ReportesPlanes();
            formReportesPlanes.ShowDialog();
            panelSubMenuReportes.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere cerrar sesion?", "Warning",
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Principal formPrincipal = new Principal();
                formPrincipal.ShowDialog();
                
            }
        }

        private void AbrirFormEnPanel(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form form = formhijo as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(form);
            this.panelContenedor.Tag = form;
            form.Show();

        }

        private void MostrarAlumnos()
        {
            btnAlumnos.Visible = true;
            btnInscripcion.Visible = true;
        }

        private void MostrarProfesor()
        {
            btnAlumnos.Visible = true;
        }

        private void MostrarAdmin()
        {
            btnAlumnos.Visible = true;
            btnProfesores.Visible = true;
            btnComisiones.Visible = true;
            btnMaterias.Visible = true;
            btnPlanes.Visible = true;
            btnEspecialidades.Visible = true;
            btnUsuarios.Visible = true;
            btnCursos.Visible = true;
            btnReportes.Visible = true;
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Cursos(PersonaLogueada));
        }
    }
}
