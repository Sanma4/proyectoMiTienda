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
                persona.Email = txtEmail.Text;
                persona.Pass = txtContraseña.Text;
                if (negocio.Loguear(persona))
                {
                    Session.Add("Usuario", persona);
                    Response.Redirect("MiPerfil.aspx",false);
                }
                else
                {
                    Session.Add("Error", "User o contraseña incorrecta");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Error");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}