using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class Home1 : System.Web.UI.Page
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
    }
}