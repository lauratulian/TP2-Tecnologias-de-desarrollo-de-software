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
    public partial class Comisiones : Default
    {
        ComisionLogic _logic;
        const int idModulo = 3;
        private ModuloUsuario moduloUsuario;

        public ModuloUsuario ModuloUsuario
        {
            get { return moduloUsuario; }
            set { moduloUsuario = value; }
        }

        #region Propiedades 
        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private Comision Entity
        {
            get;
            set;
        }
        #endregion

        #region Eventos de la Aplicacion Web
        protected new void Page_Load(object sender, EventArgs e)
        {
            this.TienePermiso();
            this.LoadGrid();
            if (!this.IsPostBack)
            {
                ComisionLogic cl = new ComisionLogic();


                ddlPlan.AppendDataBoundItems = true;
                ddlPlan.DataSource = cl.GetPlanes();
                ddlPlan.DataTextField = "Descripcion";
                ddlPlan.DataValueField = "id";
                ddlPlan.DataBind();
            }

        }
        #endregion

        #region Metodos de la Aplicacion Web 
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
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

        private void LoadGrid()
        {
            if (moduloUsuario.PermiteConsulta)
            {
                this.GridView.DataSource = this.Logic.GetAll();
                this.GridView.DataBind();
            }
           
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtAnioEspecialidad.Text = this.Entity.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlPlan.SelectedValue = this.Entity.IDPlan.ToString();
        }

        private void LoadEntity(Comision comision)
        {
            comision.AnioEspecialidad = int.Parse(this.txtAnioEspecialidad.Text);
            comision.Descripcion = this.txtDescripcion.Text;
            comision.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
        }

        private void SaveEntity(Comision comision)
        {
            this.Logic.Save(comision);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.txtAnioEspecialidad.Enabled = enable;
            this.txtDescripcion.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtAnioEspecialidad.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
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
        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            if (moduloUsuario.PermiteAlta)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Alta;
                this.ClearForm();
                this.EnableForm(true);
            }
            else
            {
                this.lbtnNuevo.Visible = false;
            }
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {
            if (moduloUsuario.PermiteModificacion)
            {
                if (this.isEntitySelected)
                {
                    this.formPanel.Visible = true;
                    this.FormMode = FormModes.Modificacion;
                    this.LoadForm(this.SelectedID);
                }
            }
            else
            {
                this.lbtnEditar.Visible = false;
            }
        }

        protected void lbtnEliminar_Click(object sender, EventArgs e)
        {
            if (moduloUsuario.PermiteBaja)
            {
                if (this.isEntitySelected)
                {
                    this.formPanel.Visible = true;
                    this.FormMode = FormModes.Baja;
                    this.EnableForm(false);
                    this.LoadForm(this.SelectedID);

                }
            }
            else
            {
                this.lbtnEliminar.Visible = false;
            }
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Comision();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
        #endregion

    }
}