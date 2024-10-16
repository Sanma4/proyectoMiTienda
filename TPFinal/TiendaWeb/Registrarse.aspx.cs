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
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuarioNegocio negocio = new usuarioNegocio();
            try
            {
                if (!(usuario.Email == ""))
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Pass = txtContraseña.Text;
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Id = negocio.agregarUsuario(usuario);
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx");
                }
                else
                {
                    Session.Add("Error", "No has ingresado datos correctos o hubo un error, vuelve a intentarlo");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Ha habido un error al crear tu cuenta");
                Response.Redirect("Error.aspx");
            }

        }
    }
}