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
    public partial class Materias : Default
    {
        MateriaLogic _logic;
        const int idModulo = 6;
        private ModuloUsuario moduloUsuario;

        public ModuloUsuario ModuloUsuario
        {
            get { return moduloUsuario; }
            set { moduloUsuario = value; }
        }

        #region Propiedades 
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }

        private Materia Entity
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
                MateriaLogic ml = new MateriaLogic();

                ddlPlan.AppendDataBoundItems = true;
                ddlPlan.DataSource = ml.GetPlanes();
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

        private bool IsEntitySelected
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
            this.txtHSSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txtHSTotales.Text = this.Entity.HSTotales.ToString();
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.ddlPlan.SelectedValue = this.Entity.IDPlan.ToString();
        }

        private void LoadEntity(Materia materia)
        {
            materia.HSSemanales = int.Parse(this.txtHSSemanales.Text);
            materia.HSTotales = int.Parse(this.txtHSTotales.Text);
            materia.Descripcion = this.txtDescripcion.Text;
            materia.IDPlan = int.Parse(this.ddlPlan.SelectedValue.ToString());
        }

        private void SaveEntity(Materia materia)
        {
            this.Logic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            this.txtHSSemanales.Enabled = enable;
            this.lblHSTotales.Enabled = enable;
            this.txtDescripcion.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.txtHSSemanales.Text = string.Empty;
            this.txtHSTotales.Text = string.Empty;
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
                if (this.IsEntitySelected)
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
                if (this.IsEntitySelected)
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
                    this.Entity = new Materia();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Materia();
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