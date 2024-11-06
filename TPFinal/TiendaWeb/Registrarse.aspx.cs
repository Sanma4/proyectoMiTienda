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
                    if (comprobarUsuario(usuario))
                    {
                        lblError.Text = "Este email ya se encuentra registrado";
                        return;
                    }
                    usuario.Id = negocio.agregarUsuario(usuario);
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("Error", "No has ingresado datos correctos o hubo un error, vuelve a intentarlo");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Error.aspx");
            }

        }

        private bool comprobarUsuario(Usuario nuevo)
        {
            usuarioNegocio negocio = new usuarioNegocio();
            List<Usuario> usuarioExistente = negocio.ListarUsuarios();

            foreach (Usuario usuario in usuarioExistente)
            {
                if(usuario.Email == nuevo.Email)
                {
                    return true; 
                }
            }
            return false;
        }
    }

    
}