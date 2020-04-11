<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Proyecto.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-group">
                <label for="emailR">Email</label>

                <asp:TextBox runat="server" ID="emailR" TextMode="Email" CssClass="form-control" OnTextChanged="emailR_TextChanged" AutoPostBack="True"></asp:TextBox>
                <small id="emaildHelpBlock" class="form-text text-muted">El email debe tener el formato de la UPV/EHU, ya sea de alumnos o profesores. Ej: galvarez024@ikasle.ehu.eus o gorka@ehu.eus
                </small>
            </div>
            <div class="alert alert-danger" role="alert" id="alertEmail" runat="server" visible="false">
                El email introducido no es VIP
            </div>
            <div class="alert alert-success" id="emailValido" runat="server" visible="false">
                Email VIP :D
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="alert alert-danger" runat="server" visible="false" id="alertEmailRepeat">
        Este email ya esta registrado!
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="passR">Contraseña</label>
                    <asp:TextBox ID="passR" TextMode="Password" CssClass="form-control" runat="server" OnTextChanged="passR_TextChanged" AutoPostBack="true"/>
                </div>
                <div class="form-group col-md-6">
                    <label for="passR2">Repetir Contraseña</label>
                    <asp:TextBox ID="passR2" TextMode="Password" CssClass="form-control" runat="server" OnTextChanged="passR2_TextChanged" AutoPostBack="true"/>
                </div>
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="alertPass">
                Las contraseñas no coinciden!
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="passBlank">
                La contraseña no puede ser vacia.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="passVeryWeak">
                Las contraseña es muy debil.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="passWeak">
                La contraseña es debil.
            </div>
            <div class="alert alert-warning" runat="server" visible="false" id="passMedium">
                La fuerza de la contraseña es media.
            </div>
            <div class="alert alert-success" runat="server" visible="false" id="passStrong">
                La contraseña es fuerte.
            </div>
            <div class="alert alert-danger" runat="server" visible="false" id="passVeryStrong">
                La contraseña es <strong>muy fuerte</strong>.
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

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
            <asp:ListItem Value="-1">-- Selecciona un tipo de usuario. --</asp:ListItem>
            <asp:ListItem Value="Profesor">Profesor</asp:ListItem>
            <asp:ListItem Value="Alumno">Alumno</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="alert alert-danger" runat="server" visible="false" id="alertUserType">
        Selecciona un tipo de usuario válido.
    </div>

    <asp:Button ID="submit" runat="server" Text="Sign In" CssClass="btn btn-primary" OnClick="submit_Click" /><br />
    <div class="alert alert-succsess" runat="server" visible="false" id="todoGuayAlert">
        Registro realizado correctamente, compruebe su correo electrónico y siga las instrucciones del mismo.
    </div>
    <div class="alert alert-danger" role="alert" id="emailNoVip" runat="server" visible="false">
        Introduce un email que sea VIP.
    </div>
</asp:Content>
