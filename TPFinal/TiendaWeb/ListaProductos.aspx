<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TiendaWeb.ListaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:GridView ID="dgvListaProductos" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="id" CssClass="table" OnSelectedIndexChanged="dgvListaProductos_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaProductos_PageIndexChanging"
         runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca"  DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✏️"/>
        </Columns>
    </asp:GridView>
    <a href="FormularioProductos.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
