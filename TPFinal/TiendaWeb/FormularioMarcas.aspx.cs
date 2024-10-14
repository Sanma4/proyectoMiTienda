using AccesoDatos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaWeb
{
    public partial class ListaMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    marcaNegocio negocio = new marcaNegocio();
                    marca seleccionada = (negocio.listar(id))[0];
                    txtId.Text = seleccionada.Id.ToString();
                    txtDescripcion.Text = seleccionada.Descripcion;

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            marcaNegocio negocio = new marcaNegocio();
            marca nuevo = new marca();

            try
            {
                nuevo.Descripcion = txtDescripcion.Text;
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nuevo);
                }
                else
                {
                    negocio.Agregar(nuevo);
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                Response.Redirect("ListaMarcas.aspx", false);
            }
        }
    }
}