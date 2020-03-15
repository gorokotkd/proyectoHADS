<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="Proyecto.TareasProfesor" %>

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
            <asp:Label ID="Label1" for="Select1" runat="server" Text="Seleccionar Asignaturas"></asp:Label>
            <select id="Select1" cssclass="form-control">
                <option></option>
            </select>
        </div>

        <div class="form-group">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-light" Text="Insertar nueva tarea" />
        </div>

        <div class="form-group">
            <asp:SqlDataSource ID="TareasGenericas" runat="server"></asp:SqlDataSource>
        </div>

    </div>
    </div>

</asp:Content>
