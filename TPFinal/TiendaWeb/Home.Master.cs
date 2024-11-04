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
    public partial class Home : System.Web.UI.MasterPage
    {
        public bool cuentaIniciada { get; set; }
        public bool Admin { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ImgPerfil.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_640.png";
                if (Seguridad.SessionIniciada(Session["Usuario"]))
                {
                    if ((Page is Login || Page is Registrarse || Page is Error))
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Usuario user = (Usuario)Session["Usuario"];
                        if (!string.IsNullOrEmpty(user.UrlImg))
                            ImgPerfil.ImageUrl = "~/Imagenes/" + user.UrlImg;

                        if (Seguridad.Admin(Session["Usuario"]))
                            Admin = true;

                        lblNombre.Text = user.Email;
                        cuentaIniciada = true;
                    }

                }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}