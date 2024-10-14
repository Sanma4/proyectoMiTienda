<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FormularioMarcas.aspx.cs" Inherits="TiendaWeb.ListaMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" Enabled="false" CssClass="form-control" ReadOnly="true" placeholder="Se auto escribe..."></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion"" class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
            <asp:Button runat="server" text="Guardar" CssClass="btn btn-success" ID="btnGuardar"  OnClick="btnGuardar_Click" />
            <a href="ListaMarcas.aspx" class="btn btn-dark">Cancelar</a>
        </div>
    </div>
</asp:Content>
