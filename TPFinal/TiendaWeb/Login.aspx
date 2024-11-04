<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaWeb.Login" %>

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
        <div class="row justify-content-center">
            <div class="col-lg-5 mb-5">
                <div class="card shadow-lg border-0 rounded-lg mt-5">
                    <div class="card-header">
                        <h3 class="text-center font-weight-light my-4">Login</h3>
                    </div>
                    <div class="card-body">
                        <div class="form-floating">
                            <asp:TextBox runat="server" ID="txtEmail" placeholder="tuemail@gmail.com *" CssClass="form-control" />
                            <label for="inputEmail">Email *</label>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Debes completar el campo" ControlToValidate="txtEmail" runat="server" />
                        </div>
                        <%--<asp:RegularExpressionValidator ErrorMessage="El texto debe ser un email" ControlToValidate="txtEmail" CssClass="validacion" ValidationExpression="^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$" runat="server" />--%>
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtContraseña" type="password" placeholder="Contraseña" CssClass="form-control" />
                            <label for="inputPassword">Contraseña *</label>
                            <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Debes completar el campo" ControlToValidate="txtContraseña" runat="server" />

                        </div>
                        <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                            <a class="small" href="NuevaPass.aspx">¿Has olvidado tu contraseña?</a>
                            <asp:Button Text="Entrar" CssClass="btn btn-primary" runat="server" ID="btnEntrar" OnClick="btnEntrar_Click" />
                        </div>
                    </div>
                    <div class="card-footer text-center py-3">
                        <div class="small"><a href="Registrarse.aspx">¿Aún no tienes cuenta?</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
