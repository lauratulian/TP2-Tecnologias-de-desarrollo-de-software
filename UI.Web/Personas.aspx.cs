using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Globalization;

namespace UI.Web
{
    public partial class Personas : Default
    {

        private PersonaLogic _logic;
        const int idModulo = 7;
        private ModuloUsuario moduloUsuario;

        public ModuloUsuario ModuloUsuario
        {
            get { return moduloUsuario; }
            set { moduloUsuario = value; }
        }
        #region Propiedades    
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }
        private Persona Entity
        {
            get;
            set;
        }
        #endregion

        #region Eventos de la aplicacion web
        protected new void Page_Load(object sender, EventArgs e)
        {
            this.TienePermiso();
            if (!this.IsPostBack)
            {
                PersonaLogic pl = new PersonaLogic();


                ddlPlan.AppendDataBoundItems = true;
                ddlPlan.DataSource = pl.GetPlanes();
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "id";
                ddlPlan.DataBind();
            }

        }
        #endregion

        #region Metodos de la Aplicacion web

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtNombre.Text = this.Entity.Nombre;
            this.txtApellido.Text = this.Entity.Apellido;
            this.txtLegajo.Text = this.Entity.Legajo.ToString();
            this.txtDireccion.Text = this.Entity.Direccion;
            this.txtTelefono.Text = this.Entity.Telefono;
            this.txtEmail.Text = this.Entity.Email;
            this.txtFechaNacimiento.Text = this.Entity.FechaNacimiento.ToString("dd/MM/yyyy");
            this.ddlPlan.SelectedValue = this.Entity.IDPlan.ToString();
        }

        private void LoadEntity(Persona per)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            per.Nombre = this.txtNombre.Text;
            per.Apellido = this.txtApellido.Text;
            per.Legajo = int.Parse(this.txtLegajo.Text);
            per.Direccion = this.txtDireccion.Text;
            per.FechaNacimiento = Convert.ToDateTime(this.txtFechaNacimiento.Text);
            per.Telefono = this.txtTelefono.Text;
            per.TipoPersona = int.Parse(this.txtTipoPersona.Text);
            per.Email = this.txtEmail.Text;
            per.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
        }

        private void SaveEntity(Persona persona)
        {
            this.Logic.Save(persona);
        }

        private void EnableForm(bool enable)
        {
            this.txtNombre.Enabled = enable;
            this.txtApellido.Enabled = enable;
            this.txtLegajo.Enabled = enable;
            this.txtDireccion.Enabled = enable;
            this.txtTelefono.Enabled = enable;
            this.txtEmail.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.ddlPlan.SelectedValue = "0";
        }
        #endregion

        #region Eventos de controles
        public void TienePermiso()
        {

            Usuario usu = new Usuario();
            usu = (Usuario)Session["Usuario"];
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            moduloUsuario = mul.GetOne(usu.ID, idModulo);
            if (moduloUsuario.PermiteAlta == false && moduloUsuario.PermiteBaja == false && moduloUsuario.PermiteConsulta == false && moduloUsuario.PermiteModificacion == false)
            {
                Response.Redirect("~/Default.aspx");
            }

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
           
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    Session["vuelta"] = "No vacio";
                    Session["Persona"] = this.Entity;
                    Response.Redirect("Usuarios.aspx");
                    
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}