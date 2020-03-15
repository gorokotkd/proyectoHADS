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
    <div class="form-row">
        <div runat="server" class="alert alert-danger" role="alert" id="horasNumero" visible="false">
            Las horas no se han introducido en formato correcto. Introduce un número válido.
        </div>

        <div runat="server" class="alert alert-danger" role="alert" id="errorInsertar" visible="false">
            Ha habido algún error al almacenar el registro, prueba de nuevo mas tarde.
        </div>

        <div runat="server" class="alert alert-success" role="alert" id="todoGuayAlert" visible="false">
            Registro almacenado correctamente.
        </div>
        <div runat="server" class="alert alert-danger" role="alert" id="tareaInstanciada" visible="false">
            La tarea seleccionada ya está instanciada.
        </div>
    </div>
    <div class="form-row">
        <div class="form-group">
            <asp:Button ID="crearTareaButton" runat="server" Text="Crear Tarea" CssClass="btn btn-primary" OnClick="crearTareaButton_Click" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-group ">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>
        </div>
    </div>
</asp:Content>
