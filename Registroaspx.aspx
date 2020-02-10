<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registroaspx.aspx.cs" Inherits="proyectoHADS.Registroaspx" %>
<meta charset="utf-8" />
    <title></title>    
    <style type="text/css">
        .auto-style1 {
            margin-left: 203px;
        }
        .auto-style2 {
            margin-left: 183px;
        }
        .auto-style3 {
            margin-left: 177px;
        }
        .auto-style4 {
            margin-left: 125px;
        }
        .auto-style5 {
            margin-left: 173px;
            margin-top: 0px;
        }
        .auto-style6 {
            margin-left: 138px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">   
        REGISTRO DE USUARIOS<p>
            <asp:Label ID="Label1" runat="server" Text="Label">Email</asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo necesario." ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Label">Nombre</asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo necesario." ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Label">Apellidos</asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style3"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo necesario." ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Label">Password</asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" CssClass="auto-style5"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo necesario." ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Label">Repetir Password</asp:Label>
            <asp:TextBox ID="TextBox5" runat="server" CssClass="auto-style4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo necesario." ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        Rol:
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>Alumno</asp:ListItem>
            <asp:ListItem>Profesor</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrar" Width="148px" CssClass="auto-style6" />
        <p>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" enableclientscript="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Formato de Email incorrecto" ForeColor="Red"></asp:RegularExpressionValidator>
        </p>
        <p>            
        </p>
    </form>
</body>
</html>
