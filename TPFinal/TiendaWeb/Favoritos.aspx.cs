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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                articuloNegocio negocio = new articuloNegocio(); 
                repRepetidor.DataSource = negocio.ListarFavoritos();
                repRepetidor.DataBind();
                Session.Add("ListaFavoritos", negocio.ListarFavoritos());

                Favoritos fav = new Favoritos();
            }
        }
    }
}