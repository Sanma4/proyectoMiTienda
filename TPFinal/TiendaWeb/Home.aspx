<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TiendaWeb.Home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <h1 class="masthead-heading text-uppercase" style="position: absolute; z-index: 20; margin-top: 18%; margin-left: 36%; color: black;">¡Bienvenido a mi tienda!</h1>
    <img src="Imagenes/Fondo.jpg" style="width: 100%; height: 940px; position: relative;" class="img-fluid" alt="FONDO" />
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
                                <asp:button runat="server" class="btn btn-dark" Text="Ver Detalle" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" id="btnVerDetalle" OnClick="btnVerDetalle_Click"></asp:button>
                                <asp:button runat="server" class="btn btn-dark" Text="+"></asp:button> 
                            </div>
                         </div>
                     </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
</asp:Content>
