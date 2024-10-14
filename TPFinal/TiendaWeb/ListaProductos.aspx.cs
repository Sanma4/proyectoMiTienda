using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using dominio;

namespace TiendaWeb
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articuloNegocio negocio = new articuloNegocio();
                Session.Add("listaArticulos", negocio.listar());
                dgvListaProductos.DataSource = Session["listaArticulos"];
                dgvListaProductos.DataBind();
            }

        }

        protected void dgvListaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProductos.aspx?id=" + id);
        }

        protected void dgvListaProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaProductos.PageIndex = e.NewPageIndex;
            dgvListaProductos.DataSource = Session["listaArticulos"];
            dgvListaProductos.DataBind();
        }
    }
}