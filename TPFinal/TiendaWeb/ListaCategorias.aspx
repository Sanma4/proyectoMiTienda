<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListaCategorias.aspx.cs" Inherits="TiendaWeb.ListaCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:GridView ID="dgvCategorias" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="id" CssClass="table" OnSelectedIndexChanged="dgvCategorias_SelectedIndexChanged"
        OnPageIndexChanging="dgvCategorias_PageIndexChanging"
        runat="server">
        <columns>
            <asp:BoundField HeaderText="Categoría" DataField="Descripcion" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✏️" />
        </columns>
    </asp:GridView>
    <a href="FormularioCategorias.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
