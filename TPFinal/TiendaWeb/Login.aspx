<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <form>
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtEmail" placeholder="tuemail@gmail.com" CssClass="form-control"/>
                                <label for="inputEmail">Email</label>
                            </div>
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtContraseña" type="password" placeholder="Contraseña" CssClass="form-control"/>
                                <label for="inputPassword">Contraseña</label>
                            </div>
                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                <a class="small" href="password.html">¿Has olvidado tu contraseña?</a>
                                <asp:Button Text="Entrar" CssClass="btn btn-primary" runat="server" ID="btnEntrar" OnClick="btnEntrar_Click" />
                            </div>
                        </form>
                    </div>
                    <div class="card-footer text-center py-3">
                        <div class="small"><a href="Registrarse.aspx">¿Aún no tienes cuenta?</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
