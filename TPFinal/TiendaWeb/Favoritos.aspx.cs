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
    public partial class Favoritos : System.Web.UI.Page
    {
        public bool FavoritosAgregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                if (usuario != null)
                {
                    favoritoNegocio negocio = new favoritoNegocio();
                    repRepetidor.DataSource = negocio.ListarFavoritos(usuario.Id);
                    repRepetidor.DataBind();

                    if (negocio.ListarFavoritos(usuario.Id).Count > 0)
                        FavoritosAgregados = true;
                    else
                        FavoritosAgregados = false;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }


        }
        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("VerDetalle.aspx?id=" + id);
        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            if (Seguridad.SessionIniciada(Session["Usuario"]))
            {
                try
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    int id = int.Parse(((Button)sender).CommandArgument);


                    favoritoNegocio negocio = new favoritoNegocio();
                    negocio.EliminarFavorito(id);

                    repRepetidor.DataSource = negocio.ListarFavoritos(usuario.Id);
                    repRepetidor.DataBind();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {
                Session.Add("Error", "Debes iniciar sesión para poder añadir a favoritos");
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}