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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.SessionIniciada(Session["Usuario"]))
                {
                    Usuario user = (Usuario)Session["Usuario"];
                    txtEmail.Text = user.Email;
                    txtNombre.Text = user.Nombre;
                    txtApellido.Text = user.Apellido;
                    if(!string.IsNullOrEmpty(user.UrlImg))
                        imgPerfil.ImageUrl = "~/Imagenes/" + user.UrlImg;
                }
            }
        }

        protected void txtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                usuarioNegocio negocio = new usuarioNegocio();
                if (txtImg.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImg.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");
                    usuario.UrlImg = "Perfil-" + usuario.Id + ".jpg";
                }
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                negocio.Actualizar(usuario);

                Image img = (Image)Master.FindControl("ImgPerfil");
                img.ImageUrl = "~/Imagenes/" + usuario.UrlImg;

                imgPerfil.ImageUrl = "~/Imagenes/" + usuario.UrlImg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //Response.Redirect("Home.aspx", false);
            }
        }
    }
}