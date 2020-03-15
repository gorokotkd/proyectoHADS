<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TareasAlumno.aspx.cs" Inherits="Proyecto.TareasAlumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
    <div class="alert alert-info" role="alert">
 Gestión de tareas genéricas.
</div>
</div>
    <div class="form-group">
        <label for="userType">Seleccionar Asignatura (Solo se muestran aquellas en las que está matriculado):</label>
        <asp:DropDownList ID="asignaturas" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="Grupo" DataValueField="Grupo" AutoPostBack="True">
            <asp:ListItem>-- Selecciona una Asignatura --</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT [Grupo] FROM [EstudiantesGrupo] WHERE ([Email] = @Email)">
            <SelectParameters>
                <asp:SessionParameter SessionField="email" Name="Email" Type="String"></asp:SessionParameter>
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <label id="valor" runat="server"></label>

    <div id="tareasView" class="table-responsive">
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:ButtonField CommandName="Select" Text="Instanciar" />
            </Columns>

        </asp:GridView>
    </div>
</asp:Content>

