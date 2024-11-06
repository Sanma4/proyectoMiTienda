using System;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TiendaWeb
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    articuloNegocio negocio = new articuloNegocio();
                    repRepetidor.DataSource = negocio.listar(id);
                    repRepetidor.DataBind();
                }

            }
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
                    Session.Add("Error", Validaciones.validacionEx(ex));
                    Response.Redirect("Error.aspx");
                }

            }
            else
            {
                lblError.Text = "Debes iniciar sesión para agregar a favoritos";
            }
        }
    }
}