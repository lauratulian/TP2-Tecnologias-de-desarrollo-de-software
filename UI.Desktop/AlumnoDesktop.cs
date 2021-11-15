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
    public partial class AlumnoDesktop : ApplicationForm
    {
        private AlumnoInscripciones _AlumnoActual;
        private Persona _PersonaActual;


        #region Propiedades

        public AlumnoInscripciones AlumnoActual
        {
            get { return _AlumnoActual; }
            set { _AlumnoActual = value; }
        }

     
        public Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        #endregion

        #region Constructores

        public AlumnoDesktop()
        {
            InitializeComponent();
        }

        public AlumnoDesktop(ModoForm modo, Persona pers) : this()
        {
            this.Modo = modo;
            PersonaActual = pers;
        }

        public AlumnoDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }


        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            AlumnoLogic a1 = new AlumnoLogic();
            AlumnoActual = a1.GetOne(ID);
            this.MapearDeDatos();
        }
        #endregion

        #region Metodos de formulario
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.AlumnoActual.ID.ToString();
            this.txtIDCurso.Text = this.AlumnoActual.IDCurso.ToString();
            this.txtCondicion.Text = this.AlumnoActual.Condicion;
            this.txtNota.Text = this.AlumnoActual.Nota.ToString();
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
                case ModoForm.ModificacionNota:
                    {
                        this.txtID.ReadOnly = true;
                        this.txtIDCurso.ReadOnly = true;

                        botonAceptar = "Modificar Nota";
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
                        AlumnoInscripciones alum = new AlumnoInscripciones();
                        AlumnoActual = alum;
                        this.AlumnoActual.IDAlumno = PersonaActual.ID;
                        this.AlumnoActual.IDCurso = int.Parse(txtIDCurso.Text);
                        this.AlumnoActual.Condicion = "Inscripto";
                        this.AlumnoActual.Nota = 0;
                        AlumnoActual.State = BusinessEntity.States.New;
                        break;
                    }
                case ModoForm.Modificacion:
                    {
                        this.AlumnoActual.ID = int.Parse(txtID.Text);
                        this.AlumnoActual.IDCurso = int.Parse(txtIDCurso.Text);
                        this.AlumnoActual.Condicion = this.txtCondicion.Text;
                        this.AlumnoActual.Nota = int.Parse(this.txtNota.Text);
                        AlumnoActual.State = BusinessEntity.States.Modified;
                        break;
                    }
                case ModoForm.Baja:
                    {
                        this.AlumnoActual.ID = int.Parse(this.txtID.Text);
                        AlumnoActual.State = BusinessEntity.States.Deleted;
                        break;
                    }
                case ModoForm.ModificacionNota:
                    {
                        this.AlumnoActual.ID = this.AlumnoActual.ID;
                        this.AlumnoActual.IDCurso = this.AlumnoActual.IDCurso;
                        this.AlumnoActual.Condicion = this.txtCondicion.Text;
                        this.AlumnoActual.Nota = int.Parse(this.txtNota.Text);
                        AlumnoActual.State = BusinessEntity.States.Modified;
                        break;
                    }
            }
        }

        public override bool Validar()
        {
            switch (Modo)
            {
                case ModoForm.Alta:

                    String mensaje1 = null;
                    if (String.IsNullOrEmpty(this.txtIDCurso.Text))
                    {
                        mensaje1 = "Campo ID Curso requerido. \n";
                    }
                    if (String.IsNullOrEmpty(mensaje1))
                    {
                        return true;
                    }
                    else
                    {
                        this.Notificar("Error", mensaje1, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return false;
                    }
                    break;

                default:

                    String mensaje = null;
                    if (String.IsNullOrEmpty(this.txtIDCurso.Text))
                    {
                        mensaje = "Campo ID Curso requerido. \n";
                    }

                    if (String.IsNullOrEmpty(this.txtNota.Text))
                    {
                        mensaje += "Campo Nota requerido. \n";
                    }
                    else
                    {
                        if (!Business.Logic.Validaciones.EsNotaValida(this.txtNota.Text))
                        {
                            mensaje += "Error. La nota debe ser un numero entre 1 y 10. \n";
                        }
                    }

                    if (String.IsNullOrEmpty(this.txtCondicion.Text))
                    {
                        mensaje += "Campo condicion requerido. \n";

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

        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoLogic a1 = new AlumnoLogic();
            a1.Save(AlumnoActual);
        }
        #endregion

        #region Eventos del formulario

        private void AlumnoDesktop_Load(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta)
            {
                txtCondicion.ReadOnly = true;
                txtNota.ReadOnly = true;
                txtCondicion.BackColor = Color.FromArgb(181, 178, 178);
                txtNota.BackColor = Color.FromArgb(181, 178, 178);
            }
        }
        #endregion

        #region Eventos de controles
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

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AlumnoDesktop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
