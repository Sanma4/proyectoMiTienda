<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FormularioProductos.aspx.cs" Inherits="TiendaWeb.FormularioProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3" style="display: none;">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtDescripcion" runat="server" />

            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Este campo solo acepta números" ValidationExpression="^[0-9,$]*$" ControlToValidate="txtPrecio" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtUrlImg" class="form-label">Url Imagen</label>
                <asp:TextBox runat="server" ID="txtUrlImg" class="form-control" AutoPostBack="true" OnTextChanged="txtUrlImg_TextChanged"></asp:TextBox>
                <asp:Image ImageUrl="https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg" ID="UrlImg" runat="server" Width="52%" />
            </div>
        </div>
    </div>
    <asp:Button ID="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" runat="server" />
    <a class="btn btn-dark" href="ListaProductos.aspx">Cancelar</a>
    <%if (Eliminar)
        { %>
    <asp:Button Text="🗑️" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click" runat="server" />

    <%  }
    %>
    <%if (confirmarEliminar)
        { %>
    <asp:CheckBox Text="¿Esta seguro de eliminar este producto?" ID="chkConfirmarEliminacion" runat="server" />
    <asp:Button Text="✅" runat="server" ID="btnConfirmarEliminacion" CssClass="btn btn-" OnClick="btnConfirmarEliminacion_Click" />
    <asp:Button Text="❌" runat="server" CssClass="btn btn-dark" ID="btnCancelar" OnClick="btnCancelar_Click" />
    <%   } %>
</asp:Content>
