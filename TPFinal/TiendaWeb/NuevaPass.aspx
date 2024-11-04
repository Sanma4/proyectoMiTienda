<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="NuevaPass.aspx.cs" Inherits="TiendaWeb.NuevaPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-5 mb-5">
                <div class="card shadow-lg border-0 rounded-lg mt-5">
                    <div class="card-header">
                        <h3 class="text-center font-weight-light my-4">Recuperar contraseña</h3>
                    </div>
                    <div class="card-body">
                        <div class="form-floating">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtEmail" placeholder="tuemail@gmail.com" CssClass="form-control" />
                                <label for="inputPassword">Email *</label>
                                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Debes completar el campo" ControlToValidate="txtEmail" runat="server" />

                            </div>
                            <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                                <a class="small" href="Login.aspx">Volver</a>
                                <asp:Button Text="Enviar" CssClass="btn btn-primary" runat="server" ID="btnEnviar" OnClick="btnEnviar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
