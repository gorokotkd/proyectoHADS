<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IntervaloMedias.aspx.cs" Inherits="Proyecto.IntervaloMedias" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 class="display-3">INTERVALO DE HORAS</h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Elige email, solo se muestran aquellos que han realizado alguna tarea."></asp:Label>
            <asp:DropDownList ID="emailList" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="Email" DataValueField="Email"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT DISTINCT [Email] FROM [EstudiantesTareas]"></asp:SqlDataSource>
        </div>
        <div class="form-group">
            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Cargar diagrama" OnClick="Button1_Click" />
        </div>
    <div class="form-group">
        <asp:Chart ID="Chart1" runat="server" OnLoad="Chart1_Load" Palette="Berry">
            <Series>
                <asp:Series Name="Estimadas" BorderColor="Red" Color="Red"></asp:Series>
                <asp:Series BorderColor="Yellow" ChartArea="ChartArea1" Color="Yellow" Name="Totales">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>
    </div>
</asp:Content>
