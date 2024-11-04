<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TiendaWeb.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion {
            color: red;
            font-size: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Correo</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" Enabled="false" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Enabled="true" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" Enabled="true" />
                    <asp:RegularExpressionValidator ErrorMessage="Este campo solo acepta apellidos reales" ValidationExpression="[a-zA-Z ]{2,254}" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                </div>
                <div class="mb-3">
                    <label for="txtContraseña" class="form-label">Cambiar contraseña</label>
                    <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" Enabled="true" />
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Imagen Perfil</label>
                    <input type="file" id="txtImg" name="txtImgPerfil" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imgPerfil"
                    ImageUrl="https://ralfvanveen.com/wp-content/uploads/2021/06/Placeholder-_-Glossary.svg"
                    runat="server" CssClass="img-fluid mb-3" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Guardar" OnClick="btnGuardar_Click" ID="btnGuardar" CssClass="btn btn-success" runat="server" />
                <a href="Home.aspx" class="btn btn-dark">Cancelar</a>
            </div>
        </div>
    </div>



</asp:Content>
