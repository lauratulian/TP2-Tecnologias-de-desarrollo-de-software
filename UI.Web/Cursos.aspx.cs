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
    public partial class Cursos : Default
    {
        CursoLogic _logic;
        const int idModulo = 4;
        private ModuloUsuario moduloUsuario;

        public ModuloUsuario ModuloUsuario
        {
            get { return moduloUsuario; }
            set { moduloUsuario = value; }
        }
        #region Propiedades 
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        private Curso Entity
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
                CursoLogic cl = new CursoLogic();


                ddlComision.AppendDataBoundItems = true;
                ddlComision.DataSource = cl.GetComisiones();
                ddlComision.DataTextField = "Descripcion";
                ddlComision.DataValueField = "id";
                ddlComision.DataBind();

                ddlMateria.AppendDataBoundItems = true;
                ddlMateria.DataSource = cl.GetMaterias();
                ddlMateria.DataTextField = "Descripcion";
                ddlMateria.DataValueField = "id";
                ddlMateria.DataBind();
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
            this.txtAnioCalendario.Text = this.Entity.AnioCalendario.ToString();
            this.txtCupo.Text = this.Entity.Cupo.ToString();
            this.ddlMateria.SelectedValue = this.Entity.IDMateria.ToString();
        }


        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
            curso.Cupo = int.Parse(this.txtCupo.Text);
            curso.IDMateria = int.Parse(this.ddlMateria.SelectedValue.ToString());
            curso.IDComision = int.Parse(this.ddlComision.SelectedValue.ToString());
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void EnableForm(bool enable)
        {
            this.txtAnioCalendario.Enabled = enable;
            this.txtCupo.Enabled = enable;
        }

        private void ClearForm()
        {
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
            this.ddlComision.SelectedValue = "0";
            this.ddlMateria.SelectedValue = "0";
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
        protected void EditarButton_Click(object sender, EventArgs e)
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
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
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

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }
        #endregion
    }
}