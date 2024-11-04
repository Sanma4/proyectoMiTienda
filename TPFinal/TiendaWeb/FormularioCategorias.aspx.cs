using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TiendaWeb
{
    public partial class FormularioCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.Admin(Session["Usuario"]))
            {
                Session.Add("Error", "No tienes permisos sufiencintes para acceder a este sitio");
                Response.Redirect("Error.aspx", false);
            }else if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "")
                {
                    categoriaNegocio negocio = new categoriaNegocio();
                    categoria seleccionada = (negocio.listar(id))[0];
                    txtId.Text = seleccionada.Id.ToString();
                    txtDescripcion.Text = seleccionada.Descripcion;

                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            categoriaNegocio negocio = new categoriaNegocio();
            categoria nuevo = new categoria();

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
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Erros.aspx");
            }
            finally
            {
                Response.Redirect("ListaCategorias.aspx", false);
            }

        }
    }
}