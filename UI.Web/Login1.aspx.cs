using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;


namespace UI.Web
{
    public partial class Login1 : System.Web.UI.Page
    {
        private int _IDPersona;

        public int IDPersona { get => _IDPersona; set => _IDPersona = value; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BuscaPersona(int ID)
        {
            PersonaLogic pl = new PersonaLogic();
            Session["PersonaLogueada"] = pl.GetOne(ID);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            if (txtClave.Text != "Password")
            {
                UsuarioLogic ul = new UsuarioLogic();
                Usuario usu = ul.Login(txtUsuario.Text, txtClave.Text);
                if (usu != null)
                {
                    Session["Usuario"] = usu;
                    IDPersona = usu.IDPersona;
                    Response.Write("<script> alert(" + "'Bienvenido al sistema'" + ") </script>");
                    Response.Redirect("~/Default.aspx");
                    this.BuscaPersona(usu.IDPersona);
                }
                else
                {
                    Response.Write("<script> alert(" + "'Usuario o contraseña incorrectos'" + ") </script>");
                }
            }
        }
    }
}