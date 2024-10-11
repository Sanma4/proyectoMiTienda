<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListaMarcas.aspx.cs" Inherits="TiendaWeb.FormularioMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:GridView ID="dgvMarcas" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="id" CssClass="table" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged"
        OnPageIndexChanging="dgvMarcas_PageIndexChanging"
        runat="server">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="Descripcion" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✏️" />
        </Columns>
    </asp:GridView>
    <a href="FormularioProductos.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
