<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="TiendaWeb.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        function ImagenDefecto() {

            this.onerror = null;

            this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';

        }

    </script>
    <style>
        .validacion {
            color: red;
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <section class="py-5">
        <div class="container px-4 px-lg-5 my-5">
            <div class="row gx-4 gx-lg-5 align-items-center">
                <asp:Repeater runat="server" ID="repRepetidor">
                    <ItemTemplate>
                        <div class="col-md-6">
                            <img class="card-img-top mb-5 mb-md-0" src="<%#Eval("ImagenUrl") %>" alt="Imagen" onerror="this.onerror=null; this.src = 'https://www.nycourts.gov/courts/ad4/assets/Placeholder.png'" />
                        </div>
                        <div class="col-md-6">
                            <div class="small mb-1"><%#Eval("Codigo") %></div>
                            <h1 class="display-5 fw-bolder"><%#Eval("Nombre") %></h1>
                            <div class="fs-5 mb-5">
                                <span><%#Eval("Precio", "{0:F2}") %></span>
                            </div>
                            <p class="lead"><%#Eval("Descripcion") %></p>
                            <asp:Button runat="server" class="btn btn-dark" Text="Añadir a favoritos" ID="btnAgregarFavorito" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnAgregarFavorito_Click"></asp:Button>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label Text="" ID="lblError" CssClass="validacion" runat="server" />
            </div>
        </div>
    </section>
</asp:Content>
