<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FormularioProductos.aspx.cs" Inherits="TiendaWeb.FormularioProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
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
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Url Imagen</label>
                <asp:TextBox runat="server" Id="txtUrlImg" class="form-control" AutoPostBack="true"  OnTextChanged="txtUrlImg_TextChanged"/>
            </div>
            <asp:Image ImageUrl="https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg" ID="UrlImg" runat="server" Width="52%"  />
        </div>
    </div>
    <asp:Button id="btnGuardar" CssClass="btn btn-success" Text="Guardar" OnClick="btnGuardar_Click" runat="server"/>
    <a class="btn btn-dark" href="ListaProductos.aspx">Cancelar</a>
</asp:Content>
