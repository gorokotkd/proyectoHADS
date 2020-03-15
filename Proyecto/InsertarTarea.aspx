<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Proyecto.InsertarTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">

            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 cssclass="display-3">PROFESOR</h1>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <h1 cssclass="display-3">GESTIÓN DE TAREAS GENÉRICAS</</h1>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" for="codigo" runat="server" Text="Código"></asp:Label>
            <asp:TextBox runat="server" ID="codigo" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label2" for="descripcion" runat="server" Text="Descripcion"></asp:Label>
            <textarea id="descripcion" cssclass="form-control" cols="20" rows="2"></textarea>
        </div>

        <div class="form-group">
            <asp:Label ID="Label3" for="asignatura" runat="server" Text="Asignatura"></asp:Label>
            <select id="asignatura" cssclass="form-control">
                <option></option>
            </select>
        </div>

        <div class="form-group">
            <asp:Label ID="Label4" for="horasEstimadas" runat="server" Text="Horas Estimadas"></asp:Label>
            <asp:TextBox runat="server" ID="horasEstimadas" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label5" for="tipoTarea" runat="server" Text="Tipo Tarea"></asp:Label>
            <select id="tipoTarea" cssclass="form-control">
                <option></option>
            </select>
        </div>

        <div class="form-group">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-light" Text="Añadir Tarea" />
        </div>

    </div>
    </div>
</asp:Content>
