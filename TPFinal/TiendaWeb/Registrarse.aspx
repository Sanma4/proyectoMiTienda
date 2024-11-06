<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="TiendaWeb.Registrarse" %>

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
                        <h3 class="text-center font-weight-light my-4">Registrarse</h3>
                    </div>
                    <div class="card-body">
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtNombre" placeholder="Nombre" CssClass="form-control" />
                            <label for="inputEmail">Nombre *</label>
                            <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtApellido" placeholder="Apellido" CssClass="form-control" />
                            <label for="inputEmail">Apellido *</label>
                            <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />

                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtEmail" placeholder="tuemail@gmail.com" CssClass="form-control" />
                            <label for="inputEmail">Email *</label>
                            <asp:Label Text="" ID="lblError" CssClass="validacion" runat="server" />
                        </div>
                        <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
                        <div class="form-floating mb-3">
                            <asp:TextBox runat="server" ID="txtContraseña" type="password" placeholder="Contraseña" CssClass="form-control" />
                            <label for="inputPassword">Contraseña *</label>
                            <asp:RequiredFieldValidator ErrorMessage="Debes completar el campo" CssClass="validacion" ControlToValidate="txtContraseña" runat="server" />
                        </div>

                        <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                            <asp:Button Text="Registrarse" CssClass="btn btn-primary" runat="server" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" />
                        </div>
                    </div>
                    <div class="card-footer text-center py-3">
                        <div class="small"><a href="Login.aspx">¿Ya tienes cuenta?</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
