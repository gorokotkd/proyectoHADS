<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Proyecto.CambiarPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" class="alert alert-info" id="emailInfoAlert" role="alert">
        Pantalla de recuperación de contraseña, introduce tus datos para continuar.
    </div>
    <div class="form-group" id="emailGroup" runat="server">
        <label for="emailL">Email address</label>
        <asp:TextBox ID="emailL" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="emailSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="emailSubmit_Click" />
    </div>
    <div runat="server" class="alert alert-success" role="alert" id="correctEmailAlert" visible="false">
        Email enviado correctamente, si este es correcto recibirá un mensaje en su bandeja de entrada.
    </div>

    <!-- FIN PARTE 1 DE RECUPERACION DE CONTRASEÑA. -->

    <div runat="server" class="alert alert-info" role="alert" id="passInfoAlert">
        Introduce tu nueva contraseña para continuar.
    </div>
    <div runat="server" class="form-row" id="passGroup">
        <div class="form-group col-md-6">
            <label for="passR">Contraseña</label>
            <asp:TextBox ID="passR" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="passR2">Repetir Contraseña</label>
            <asp:TextBox ID="passR2" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div runat="server" class="alert alert-danger" role="alert" id="alertPass" visible="false">
        Las contraseñas no coinciden!
    </div>
    <div class="form-group">
        <asp:Button ID="passSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="passSubmit_Click" />
    </div>
    <div runat="server" class="alert alert-success" role="alert" id="correctPassAlert" visible="false">
        ¡Contraseña actualizada correctamente.! Haz click  en el 
        <a href="Inicio.aspx" class="alert-link">enlace</a>
        para volver a la pagina principal.
    </div>
</asp:Content>
