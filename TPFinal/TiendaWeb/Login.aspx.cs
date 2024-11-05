using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario persona = new Usuario();
            usuarioNegocio negocio = new usuarioNegocio();
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtContraseña.Text)) 
                {
                    Session.Add("Error", "Debes completar ambos campos para acceder.");
                    Response.Redirect("Error.aspx", false);
                }
                persona.Email = txtEmail.Text;
                persona.Pass = txtContraseña.Text;
                if (negocio.Loguear(persona))
                {
                    Session.Add("Usuario", persona);
                    Response.Redirect("MiPerfil.aspx",false);
                }
                else
                {
                    lblError.Text = "Email o contraseña incorrecta";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}