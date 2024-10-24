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
            if (!Seguridad.Admin(Session["Usuario"]))
            {
                Session.Add("Error", "No tienes permisos sufiencintes para acceder a este sitio");
                Response.Redirect("Error.aspx", false);
            }else if (!IsPostBack)
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<marca> lista = ((List<marca>)Session["listaMarcas"]).FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvMarcas.DataSource = lista;
            dgvMarcas.DataBind();
        }
    }
}