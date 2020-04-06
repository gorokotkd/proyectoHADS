<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label for="emailR">Email</label>

        <asp:TextBox runat="server" ID="emailR" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <small id="emaildHelpBlock" class="form-text text-muted">El email debe tener el formato de la UPV/EHU, ya sea de alumnos o profesores. Ej: galvarez024@ikasle.ehu.eus o gorka@ehu.eus
        </small>
    </div>
    <div class="alert alert-danger" style="display: none" role="alert" id="alert-email">
        El email no es del formato de la UPV/EHU!
    </div>
    <div class="alert alert-danger" style="display: none" role="alert" id="alert-email-repeat">
        Este email ya esta registrado!
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="passR">Contraseña</label>
            <asp:TextBox ID="passR" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="passR2">Repetir Contraseña</label>
            <asp:TextBox ID="passR2" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="alert alert-danger" style="display: none" role="alert" id="alert-pass">
        Las contraseñas no coinciden!
    </div>
    <div class="form-row">
        <div class="form-group col-md-6">
            <label for="nombre">Nombre</label>
            <asp:TextBox ID="nombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-6">
            <label for="apellido">Apellido(s)</label>
            <asp:TextBox ID="apellido" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="userType">Tipo de usuario:</label>
        <asp:DropDownList ID="userType" runat="server" CssClass="form-control">
            <asp:ListItem>Profesor</asp:ListItem>
            <asp:ListItem>Alumno</asp:ListItem>
        </asp:DropDownList>
    </div>


    <asp:Button ID="submit" runat="server" Text="Sign In" CssClass="btn btn-primary" OnClick="submit_Click" />
    <div class="alert alert-succsess" runat="server" visible="false" id="todoGuayAlert">
        Registro realizado correctamente, compruebe su correo electronico y siga las instrucciones del mismo.
    </div>
</asp:Content>
