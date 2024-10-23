<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="carousel-inner">

        <div class="carousel-item active">
            <img src="Imagenes/fondo.jpg" class="img-fluid d-block w-100 h-50" alt="FONDO" />
        </div>
        <div class="carousel-caption  d-none d-md-block" style="margin-bottom: 20%;">
            <h2 class=" me-5">BIENVENIDO A MI TIENDA</h2>
        </div>
    </div>
    <div class="container">
        <hr />
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" style="height: 400px; width: auto;" alt="Imagen">
                            <div class="card-body">
                                <h4 class="card-title"><%#Eval("Nombre") %></h4>
                                <p class="card-text"><%#Eval("Marca") %></p>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button runat="server" class="btn btn-dark" Text="Ver Detalle" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" ID="btnVerDetalle" OnClick="btnVerDetalle_Click"></asp:Button>
                                        <asp:Button runat="server" class="btn btn-dark" Text="+" ID="btnAgregarFavorito" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnAgregarFavorito_Click"></asp:Button>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>
