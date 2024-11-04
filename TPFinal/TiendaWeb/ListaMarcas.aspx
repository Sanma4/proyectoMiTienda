<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListaMarcas.aspx.cs" Inherits="TiendaWeb.FormularioMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:Label Text="Filtro(TAB para buscar)" runat="server" />
    <div class="col-2 mb-3">
        <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
    </div>
    <asp:GridView ID="dgvMarcas" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="id" CssClass="table" OnSelectedIndexChanged="dgvMarcas_SelectedIndexChanged"
        OnPageIndexChanging="dgvMarcas_PageIndexChanging"
        runat="server">
        <Columns>
            <asp:BoundField HeaderText="Marca" DataField="Descripcion" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✏️" />
        </Columns>
    </asp:GridView>
    <a href="FormularioMarcas.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
