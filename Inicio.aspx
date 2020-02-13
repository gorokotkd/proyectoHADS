<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="proyectoHADS.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="E-Mail:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="loginEmail" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="loginEmail" ErrorMessage="Debes completar este campo" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="loginEmail" ErrorMessage="El email introducido no es valido" ForeColor="Red"> </asp:RegularExpressionValidator>
        <br />
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="loginPass" runat="server" UseSystemPasswordChar="True" OnTextChanged="loginPass_TextChanged" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="requieredPass" runat="server" ControlToValidate="loginPass" ErrorMessage="El campo no puede estar vacio." ForeColor="Red">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="LogIn" OnClick="Button1_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server">No tengo cuenta, registrarse.</asp:LinkButton>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server">He olvidado mi contraseña.</asp:LinkButton>
    </form>
</body>
</html>
