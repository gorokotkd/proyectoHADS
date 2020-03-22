<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarDataSet.aspx.cs" Inherits="Proyecto.ImportarDataSet" %>
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
                    <h1 class="display-3">IMPORTAR TAREAS GENÉRICAS vDataSet</</h1>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="form-group">
                <asp:Label ID="asignaturasLabel" runat="server" Text="Selecciona una asignatura"></asp:Label>
                <asp:DropDownList ID="asignaturas" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="asignaturas_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AppendDataBoundItems="True">
                    <asp:ListItem Enabled="true" Text="-- Selecciona una asignatura. --"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT Asignaturas.codigo FROM Asignaturas INNER JOIN GruposClase ON Asignaturas.codigo = GruposClase.codigoasig INNER JOIN ProfesoresGrupo ON GruposClase.codigo = ProfesoresGrupo.codigogrupo WHERE (ProfesoresGrupo.email = @email)">
                    <SelectParameters>
                        <asp:SessionParameter SessionField="email" Name="email"></asp:SessionParameter>
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Button ID="importar" runat="server" Text="Importar" CssClass="btn btn-primary" OnClick="importar_Click" />
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
        <div runat="server" class="alert alert-danger" role="alert" id="tareasYaImportadas" visible="false">
            Una o mas tareas del xml ya estan importadas en el xml.
        </div>
    </div>
</asp:Content>
