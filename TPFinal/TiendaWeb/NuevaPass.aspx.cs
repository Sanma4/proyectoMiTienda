using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TiendaWeb
{
    public partial class NuevaPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseña = Recursos.GenerarClave();
                if(Recursos.EnviarCorreo(txtEmail.Text, "Nueva contraseña","Aquí tienes tu nueva contraseña, cambiala cuando entres en tu cuenta: " + contraseña))
                {
                    Response.Redirect("Login.aspx", false);
                    usuarioNegocio negocio = new usuarioNegocio();
                    negocio.ActualizarContraseña(contraseña, txtEmail.Text);
                }
                else
                {
                    Session.Add("Error", "No podemos encontrar ninguna cuenta asociada a ese correo, intente nuevamente.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}