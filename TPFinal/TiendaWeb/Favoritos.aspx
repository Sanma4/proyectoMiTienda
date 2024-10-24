<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TiendaWeb.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <h2 class="mt-3">Artículos Favoritos</h2>
        <hr />
        <%if (FavoritosAgregados)
            {%>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col mb-3">
                        <div class="card h-100">
                            <img src="<%#Eval("UrlImagen") %>" style="height: 400px; width: auto;" class="card-img-top" alt="Imagen">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Marca") %></p>
                                <asp:Button runat="server" class="btn btn-dark" Text="Ver Detalle" CommandArgument='<%#Eval("IdArticulo")%>' CommandName="IdArticulo" ID="btnVerDetalle" OnClick="btnVerDetalle_Click"></asp:Button>
                                <asp:Button runat="server" class="btn btn-dark" Text="-" ID="btnEliminarFavorito" CommandArgument='<%#Eval("IdArticulo")%>' CommandName="Id" OnClick="btnEliminarFavorito_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <%}%>
        <%else
            {%>
        <asp:Label CssClass="mb-3 form-label" ID="lblNoFavs" runat="server" Text="Aún no has agregado artículos a favoritos. Dirígete al inicio y agrega tus artículos."></asp:Label>
        <%} %>
    </div>
</asp:Content>
