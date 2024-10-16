using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class Home : System.Web.UI.MasterPage
    {
        public bool cuentaIniciada { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SessionIniciada(Session["Usuario"]))
            {
                cuentaIniciada = true;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Home.aspx");
        }
    }
}