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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articuloNegocio negocio = new articuloNegocio();
                repRepetidor.DataSource = negocio.listar();
                repRepetidor.DataBind();
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Response.Redirect("VerDetalle.aspx?id=" + id);
        }

        protected void btnAgregarFavorito_Click(object sender, EventArgs e)
        {
            if (Seguridad.SessionIniciada(Session["Usuario"]))
            {
                try
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    articulo articulo = new articulo();
                    articulo.Id = int.Parse(((Button)sender).CommandArgument);


                    favoritoNegocio negocio = new favoritoNegocio();
                    negocio.AgregarFavorito(articulo, usuario);

                    Response.Redirect("Favoritos.aspx", false);
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