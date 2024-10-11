using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class ListaCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                categoriaNegocio negocio = new categoriaNegocio();
                Session.Add("listaCategorias", negocio.listar());
                dgvCategorias.DataSource = Session["listaCategorias"];
                dgvCategorias.DataBind();
            }
        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategorias.aspx?id=" + id);
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;
            dgvCategorias.DataSource = Session["listaCategorias"];
            dgvCategorias.DataBind();
        }
    }
}