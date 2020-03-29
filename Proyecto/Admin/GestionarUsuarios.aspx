
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarUsuarios.aspx.cs" Inherits="Proyecto.Admin.GestionarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 class="display-3">ADMINISTRADOR</h1>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <h1 class="display-3">GESTIÓN DE USUARIOS</</h1>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-md-12 text-center">
                <h5 class="display-3">Usuarios de la aplicación</h5>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="email" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                    <Columns>
                        <asp:CommandField ShowEditButton="True"></asp:CommandField>
                        <asp:CommandField ShowDeleteButton="true" />
                        <asp:BoundField DataField="email" HeaderText="email" ReadOnly="True" SortExpression="email"></asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre"></asp:BoundField>
                        <asp:BoundField DataField="apellidos" HeaderText="apellidos" SortExpression="apellidos"></asp:BoundField>
                        <asp:CheckBoxField DataField="confirmado" HeaderText="confirmado" SortExpression="confirmado"></asp:CheckBoxField>
                        <asp:BoundField DataField="tipo" HeaderText="tipo" SortExpression="tipo"></asp:BoundField>
                        <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass"></asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                    <RowStyle BackColor="#EFF3FB"></RowStyle>

                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT [email], [nombre], [apellidos], [confirmado], [tipo], [pass] FROM [Usuarios] WHERE ([tipo] <> @tipo) ORDER BY [nombre], [email]" DeleteCommand="DELETE FROM [Usuarios] WHERE [email] = @email" InsertCommand="INSERT INTO [Usuarios] ([email], [nombre], [apellidos], [confirmado], [tipo], [pass]) VALUES (@email, @nombre, @apellidos, @confirmado, @tipo, @pass)" UpdateCommand="UPDATE [Usuarios] SET [nombre] = @nombre, [apellidos] = @apellidos, [confirmado] = @confirmado, [tipo] = @tipo, [pass] = @pass WHERE [email] = @email">
                    <DeleteParameters>
                        <asp:Parameter Name="email" Type="String"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="email" Type="String"></asp:Parameter>
                        <asp:Parameter Name="nombre" Type="String"></asp:Parameter>
                        <asp:Parameter Name="apellidos" Type="String"></asp:Parameter>
                        <asp:Parameter Name="confirmado" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="tipo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="pass" Type="String"></asp:Parameter>
                    </InsertParameters>
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Admin" Name="tipo" Type="String"></asp:Parameter>
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="nombre" Type="String"></asp:Parameter>
                        <asp:Parameter Name="apellidos" Type="String"></asp:Parameter>
                        <asp:Parameter Name="confirmado" Type="Boolean"></asp:Parameter>
                        <asp:Parameter Name="tipo" Type="String"></asp:Parameter>
                        <asp:Parameter Name="pass" Type="String"></asp:Parameter>
                        <asp:Parameter Name="email" Type="String"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>

    </div>
</asp:Content>
