﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarXmlDoc.aspx.cs" Inherits="Proyecto.ImportarXmlDoc" %>
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
                    <h1 class="display-3">IMPORTAR TAREAS GENÉRICAS</</h1>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <asp:Label ID="asignaturasLabel" runat="server" Text="Selecciona una asignatura"></asp:Label>
                <asp:DropDownList ID="asignaturas" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="asignaturas_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo"></asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Button ID="importar" runat="server" Text="Button" CssClass="btn btn-primary" OnClick="importar_Click" />
            </div>
        </div>
        <div class="row">
            <div runat="server" class="alert alert-danger" role="alert" id="errorArchivo" visible="false">
           No existe ningun fichero para esa asignatura.
        </div>
            <div runat="server" class="alert alert-danger" role="alert" id="errorGeneral" visible="false">
            Ha habido algun error al cargar los archivos.
        </div>
        </div>
        <div class="row">
            <asp:Xml ID="Xml1" runat="server"></asp:Xml>
        </div>
    </div>
    <div class="form-row">
        <div runat="server" class="alert alert-danger" role="alert" id="errorImportar" visible="false">
            Ha habido un error al importar las tareas, prueba de nuevo mas tarde.
        </div>
        <div runat="server" class="alert alert-success" role="alert" id="todoGuayAlert" visible="false">
            Tarea almacenada correctamente.
        </div>
    </div>

</asp:Content>