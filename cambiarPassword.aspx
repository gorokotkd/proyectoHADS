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
            <asp:RequiredFieldValidator ID="emailRequieredValidator" runat="server" ErrorMessage="El campo no puede ser vacio." ForeColor="Red">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Enviar" />
        </div>
    </form>
</body>
</html>
