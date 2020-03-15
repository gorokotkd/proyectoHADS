<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Proyecto.InstanciarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <div class="alert alert-info" role="alert">
            Instanciar tareas genéricas.
        </div>
    </div>

    <div class="form-row">
        <div class="form-group">
            <label for="emailT">Usuario</label>
            <asp:TextBox runat="server" ID="emailT" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group">
            <label for="tareaT">Tarea</label>
            <asp:TextBox runat="server" ID="tareaT" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group">
            <label for="hEstimadas">Horas Est.</label>
            <asp:TextBox runat="server" ID="hEstimadas" ReadOnly="true" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group">
            <label for="hReales">Horas Reales</label>
            <asp:TextBox runat="server" ID="hReales" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</asp:Content>
