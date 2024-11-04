using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TiendaWeb
{
    public partial class FormularioProductos : System.Web.UI.Page
    {
        public bool Eliminar { get; set; }
        public bool confirmarEliminar { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                confirmarEliminar = false;
                Eliminar = false;
                if (!Seguridad.Admin(Session["Usuario"]))
                {
                    Session.Add("Error", "No tienes permisos sufiencintes para acceder a este sitio");
                    Response.Redirect("Error.aspx", false);
                }
                else if (!IsPostBack)
                {
                    marcaNegocio negocio = new marcaNegocio();
                    List<marca> lista = negocio.listar();

                    categoriaNegocio oNegocio = new categoriaNegocio();
                    List<categoria> listaCat = oNegocio.listar();

                    ddlMarca.DataSource = lista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCat;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    Eliminar = true;
                    articuloNegocio negocio = new articuloNegocio();
                    articulo seleccionado = (negocio.listar(id))[0];

                    Session.Add("artSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.Precio.ToString("##,##");
                    txtUrlImg.Text = seleccionado.ImagenUrl;
                    txtUrlImg_TextChanged(sender, e);

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Erros.aspx");
            }
        }

        protected void txtUrlImg_TextChanged(object sender, EventArgs e)
        {
            UrlImg.ImageUrl = txtUrlImg.Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            articulo nuevo = new articulo();
            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtUrlImg.Text;

                nuevo.Marca = new marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.Categoria = new categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", Validaciones.validacionEx(ex));
                Response.Redirect("Erros.aspx");
            }
            finally
            {
                Response.Redirect("ListaProductos.aspx");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminar = true;
            Eliminar = true;
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmarEliminar = false;
            Eliminar = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmarEliminacion.Checked)
                {
                    articuloNegocio negocio = new articuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Response.Redirect("ListaProductos.aspx");
            }
        }
    }
}