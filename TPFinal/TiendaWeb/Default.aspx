<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TiendaWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

    function ImagenDefecto()
    {

        this.onerror=null; 

        this.src = 'https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740';

    }

    </script>

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
        <div style="font-size: 30px" class="text-center mb-3 mt-3">ARTICULOS</div>
        <hr />
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100" style="box-shadow: 0px 5px 5px grey;" >
                            <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" style="max-height: 350px; max-width: 400px; padding: 30px; display:flex;" alt="Imagen" id="imgArticulo" onerror="this.onerror=null; this.src = 'https://www.nycourts.gov/courts/ad4/assets/Placeholder.png'">
                            <div class="card-body">
                                <h4 class="card-title align-content-end"><%#Eval("Nombre") %></h4>
                                <p class="card-text"><%#Eval("Marca") %></p>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:Button runat="server" class="btn btn-dark align-bottom" Text="Ver Detalle" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" ID="btnVerDetalle" OnClick="btnVerDetalle_Click"></asp:Button>
                                        <asp:Button runat="server" class="btn btn-dark align-bottom" Text="+" ID="btnAgregarFavorito" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnAgregarFavorito_Click"></asp:Button>
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
