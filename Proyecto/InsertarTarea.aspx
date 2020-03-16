<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Proyecto.InsertarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 class="display-3">PROFESOR</h1>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <h1 class="display-3">GESTIÓN DE TAREAS GENÉRICAS</</h1>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" for="codigo" runat="server" Text="Código"></asp:Label>
            <asp:TextBox runat="server" ID="codigo" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" for="descripcion" runat="server" Text="Descripcion"></asp:Label>
            <asp:TextBox runat="server" ID="descripcion" CssClass="form-control" Columns="20" Rows="2"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" for="asignatura" runat="server" Text="Asignatura"></asp:Label>
            <asp:DropDownList ID="asignaturas" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" for="horasEstimadas" runat="server" Text="Horas Estimadas"></asp:Label>
            <asp:TextBox runat="server" ID="horasEstimadas" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label5" for="tipoTarea" runat="server" Text="Tipo Tarea"></asp:Label>
            <asp:DropDownList ID="tipoTarea" CssClass="form-control" runat="server" DataSourceID="SqlDataSource2" DataTextField="TipoTarea" DataValueField="TipoTarea"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT DISTINCT [TipoTarea] FROM [TareasGenericas]"></asp:SqlDataSource>
        </div>

        <div class="form-group">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-light" Text="Añadir Tarea" OnClick="Button1_Click" />
        </div>
        <div class="form-group">
            <div runat="server" class="alert alert-danger" role="alert" id="horasNumero" visible="false">
                Las horas no se han introducido en formato correcto. Introduce un número válido.
            </div>
            <div runat="server" class="alert alert-success" role="alert" id="todoGuayAlert" visible="false">
            Registro almacenado correctamente.
        </div>

    </div>
</asp:Content>
