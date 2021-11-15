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
    public partial class Docentes : Default
    {
        DocenteLogic _logic;
        const int idModulo = 5;
        private ModuloUsuario moduloUsuario;

        public ModuloUsuario ModuloUsuario
        {
            get { return moduloUsuario; }
            set { moduloUsuario = value; }
        }

        #region Propiedades
        private DocenteLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteLogic();
                }
                return _logic;
            }
        }

        private DocenteCurso Entity
        {
            get;
            set;
        }
        #endregion

        #region Events de la Aplicacion Web
        protected new void Page_Load(object sender, EventArgs e)
        {
            this.TienePermiso();
            this.LoadGrid();
            if (this.IsPostBack)
            {
                DocenteLogic d1 = new DocenteLogic();

                ddlCurso.AppendDataBoundItems = true;
                ddlCurso.DataSource = d1.GetCursos();
                ddlCurso.DataTextField = "id";
                ddlCurso.DataValueField = "id";
                ddlCurso.DataBind();
                ddlCurso.SelectedIndex = 0;
            }
        }
        #endregion

        #region Metodos de la Aplicacion web
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
            this.txtCargo.Text = this.Entity.Cargo.ToString();
            this.txtIDDocente.Text = this.Entity.IDDocente.ToString();
            this.ddlCurso.SelectedValue = this.Entity.IDCurso.ToString();
        }

        private void LoadEntity(DocenteCurso doc)
        {
            doc.Cargo = int.Parse(this.txtCargo.Text);
            doc.IDCurso = int.Parse(ddlCurso.SelectedValue.ToString());
            doc.IDDocente = int.Parse(this.txtIDDocente.Text);
        }

        private void SaveEntity(DocenteCurso doc)
        {
            this.Logic.Save(doc);
        }

        private void EnableForm(bool enable)
        {
            this.txtCargo.Enabled = enable;
            this.txtIDDocente.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.txtCargo.Text = string.Empty;
            this.txtIDDocente.Text = string.Empty;
            this.ddlCurso.SelectedValue = "0";
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
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
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