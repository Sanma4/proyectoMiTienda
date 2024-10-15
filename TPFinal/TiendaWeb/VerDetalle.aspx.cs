using System;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class VerDetalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if(id != "")
                {
                    articuloNegocio negocio = new articuloNegocio();
                    repRepetidor.DataSource = negocio.listar(id);
                    repRepetidor.DataBind();
                }

            }
        }
    }
}