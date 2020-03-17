<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MediaAsignaturasG18.aspx.cs" Inherits="Proyecto.MediaAsignaturasG18" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">

            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 cssclass="display-3">INTERVALO DE HORAS</h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" for="emailTextBox" runat="server" Text="Insertar email"></asp:Label>
            <asp:TextBox runat="server" ID="emailTextBox" CssClass="form-control"></asp:TextBox>
        </div>

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
