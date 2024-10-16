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
    public partial class ListaProductos : System.Web.UI.Page
    {
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            filtroAvanzado = chkFiltro.Checked;
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

        protected void chkFiltro_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado = chkFiltro.Checked;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(txtFiltro.Text == ""))
                {
                    articuloNegocio negocio = new articuloNegocio();
                    dgvListaProductos.DataSource = negocio.filtrar(ddlCampo.SelectedItem.ToString()
                        , ddlCriterio.SelectedItem.ToString(), txtFiltro.Text);
                    dgvListaProductos.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            List<articulo> lista = (List<articulo>)Session["listaArticulos"];
            dgvListaProductos.DataSource = lista;
            dgvListaProductos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCampo.SelectedItem.ToString() == "Nombre" || ddlCampo.SelectedItem.ToString() == "Marca" || ddlCampo.SelectedItem.ToString() == "Categoria")
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Termina con");
            }
        }

    }
}