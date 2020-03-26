<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Proyecto.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="emailL">Email address</label>
        <asp:TextBox ID="emailL" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>


    <div class="form-group">
        <label for="passL">Password</label>
        <asp:TextBox ID="passL" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>

    <div class="row">
        <div runat="server" class="alert alert-danger" role="alert" id="alert" visible="false">
            Usuario o contraseña incorrectos.
        </div>

        <div runat="server" class="alert alert-danger" role="alert" id="alert2" visible="false">
            Aun no se ha confirmado el correo electrónico.
        </div>

        <div runat="server" class="alert alert-danger" role="alert" id="errorEmailRegitrado" visible="false">
            El email introducido no esta registrado. Puedes registrarte a traves de este <a href="Registro.aspx" class="alert-link">enlace.</a>
        </div>
    </div>
</asp:Content>
