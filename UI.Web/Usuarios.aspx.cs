using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : Default
    {
        UsuarioLogic _logic;
        private Persona _PersonaActual;

        #region Propiedades 
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }

        private Usuario Entity
        {
            get;
            set;
        }

        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        #endregion

        #region Eventos de la Aplicacion Web
        protected new void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();

            if (Session["vuelta"] !=null)
            {
                if (Session["Persona"] != null)
                {
                    PersonaActual = (Persona)Session["Persona"];
                    txtApellido.Text = PersonaActual.Apellido;
                    txtNombre.Text = PersonaActual.Nombre;
                    txtEmail.Text = PersonaActual.Email;
                    this.NuevoUsuario();
                   
                }

                    
            }

        }
        #endregion

        #region Metodos de la Aplicacion Web 
        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }

        private int SelectedID
        {
            get
            {
                if(this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool isEntitySelected
        {
            get 
            {
                return (this.SelectedID != 0);
            }
        }

 
        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtEmail.Text = this.Entity.Email;
            this.cbHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.txtNombre.Text;
            usuario.Apellido = this.txtApellido.Text;
            usuario.Email = this.txtEmail.Text;
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.cbHabilitado.Checked;
            usuario.IDPersona = this.PersonaActual.ID;
        }

        protected void CancelarButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.cbHabilitado.Checked = false;
            this.txtNombreUsuario.Text = string.Empty;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtEmail.Enabled = enable;
            this.txtNombreUsuario.Enabled = enable;
            this.txtClave.Visible = enable;
            this.lblClave.Visible = enable;
            this.txtRepetirClave.Visible = enable;
            this.lblRepetirClave.Visible = enable;
        }

        #endregion

        public void NuevoUsuario()
        {
            this.gridPanel.Visible = false;
            this.gridActionPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.txtNombre.Enabled = true;
            this.txtApellido.Enabled = true;
            this.txtEmail.Enabled = true;
            
        
        }

        #region Eventos de controles
        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personas.aspx");
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            if (this.isEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);

            }
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.Logic.InsertPermisos(Entity.ID, PersonaActual.TipoPersona);
                    Session["vuelta"] = null;

                    break;
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
            }

            this.formPanel.Visible = false;
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.ClearForm();
            this.formPanel.Visible = false;
        }


        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
        #endregion
    }
}