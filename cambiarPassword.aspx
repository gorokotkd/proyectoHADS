<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="proyectoHADS.cambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Pantalla de recuperacion de contraseña, introduzca sus datos para continuar."></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Correo electronico:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="emailBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="emailRequieredValidator" runat="server" ErrorMessage="El campo no puede ser vacio." ForeColor="Red" ControlToValidate="emailBox">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enviar" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="InfoLabel" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="pass1Text" runat="server" Text="Nueva Contraseña:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="pass1Box" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="pass2Text" runat="server" Text="Repita la contraseña:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="pass2Box" runat="server" TextMode="Password" Visible="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="confirmarPassButton" runat="server" Text="Confirmar" Visible="False" />
        </div>
    </form>
</body>
</html>
