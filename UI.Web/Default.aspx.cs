using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion,
            ModificacionNota
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected void lbtnSalir_Click(object sender, EventArgs e)
        {
            Session["Persona"] = null;
            Session["Usuario"] = null;
            this.verificarSession();
        }

        private void verificarSession()
        {
            if (Session["Persona"] == null)
            {
                Response.Redirect("~/Login1.aspx");
            }
        }
    }
}