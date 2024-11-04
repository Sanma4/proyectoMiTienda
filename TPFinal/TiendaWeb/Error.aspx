<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TiendaWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .img {
            font-size: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <img class="mb-4 img-error" src="https://startbootstrap.com/assets/img/freepik/404-error-pana.svg" style="height: 750px; width: auto;" />
        <asp:Label Text="" runat="server" ID="lblError" CssClass="img" />
        <a href="Default.aspx" class="btn btn-dark ms-5">
            <i class="fas fa-arrow-left me-1"></i>

            Volver al inicio
        </a>
    </div>
</asp:Content>
