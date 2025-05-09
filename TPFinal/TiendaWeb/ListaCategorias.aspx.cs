﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TiendaWeb
{
    public partial class ListaCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.Admin(Session["Usuario"]))
            {
                Session.Add("Error", "No tienes permisos sufiencintes para acceder a este sitio");
                Response.Redirect("Error.aspx", false);
            }else if (!IsPostBack)
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

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<categoria> lista = ((List<categoria>)Session["listaCategorias"]).FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvCategorias.DataSource = lista;
            dgvCategorias.DataBind();
        }
    }
}