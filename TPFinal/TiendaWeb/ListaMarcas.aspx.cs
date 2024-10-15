using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace TiendaWeb
{
    public partial class FormularioMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                marcaNegocio negocio = new marcaNegocio();
                Session.Add("listaMarcas", negocio.listar());
                dgvMarcas.DataSource = Session["listaMarcas"];
                dgvMarcas.DataBind();
            }
        }

        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex = e.NewPageIndex;
            dgvMarcas.DataSource = Session["listaMarcas"];
            dgvMarcas.DataBind();
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarcas.aspx?id=" + id);
        }
    }
}