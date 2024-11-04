<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TiendaWeb.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-4 mb-3">
            <asp:Label Text="Filtro(TAB para buscar)" runat="server" />
            <asp:TextBox runat="server" ID="txtFiltroNormal" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroNormal_TextChanged"/>
        </div>
    </div>
    <div class="row">
        <div class="col-4 mb-3">
            <asp:CheckBox Text="Filtros" ID="chkFiltro" runat="server" AutoPostBack="true" OnCheckedChanged="chkFiltro_CheckedChanged" />
        </div>
    </div>

    <%if (filtroAvanzado)
        {%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Campo" CssClass="form-label" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio" CssClass="form-label" runat="server" />
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCriterio">
                    <asp:ListItem Text="Empieza con" />
                    <asp:ListItem Text="Contiene" />
                    <asp:ListItem Text="Termina con" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" CssClass="form-label" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" CssClass="btn btn-outline-dark" ID="btnBuscar" OnClick="btnBuscar_Click" runat="server" />
                <asp:Button Text="Restablecer lista" CssClass="btn btn-outline-danger" ID="btnCancelar" OnClick="btnCancelar_Click" runat="server" />
            </div>
        </div>
    </div>

    <% } %>

    <asp:GridView ID="dgvListaProductos" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
        DataKeyNames="id" CssClass="table" OnSelectedIndexChanged="dgvListaProductos_SelectedIndexChanged"
        OnPageIndexChanging="dgvListaProductos_PageIndexChanging"
        runat="server">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:F2}" />
            <asp:CommandField HeaderText="Acciones" ShowSelectButton="true" SelectText="✏️" />
        </Columns>
    </asp:GridView>
    <a href="FormularioProductos.aspx" class="btn btn-dark">Agregar</a>
</asp:Content>
