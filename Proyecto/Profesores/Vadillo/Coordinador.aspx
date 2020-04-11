<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Coordinador.aspx.cs" Inherits="Proyecto.Profesores.Vadillo.Coordinador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 class="display-3">COORDINADOR</h1>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <h1 class="display-3">VER DEDICACION MEDIA</</h1>
                </div>
            </div>
        </div>

        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="form-group">
                        <asp:Label ID="asignaturasLabel" runat="server" Text="Selecciona una asignatura"></asp:Label>
                        <asp:DropDownList CssClass="form-control" runat="server" AutoPostBack="true" ID="asignaturasList" OnSelectedIndexChanged="asignaturasList_SelectedIndexChanged" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="Nombre" DataValueField="codigo">
                            <asp:ListItem Value="-1">-- Selecciona una asignatura --</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT * FROM [Asignaturas]"></asp:SqlDataSource>
                    </div>
                </div>
                <div id="alert" class="alert alert-success" runat="server" visible="false">
                    La media de horas dedicada a la asignatura, <strong><%= asignaturasList.SelectedItem.Text%> </strong>, es de <asp:Label ID="horasLabel" runat="server"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
