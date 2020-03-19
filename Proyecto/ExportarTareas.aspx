<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="Proyecto.ExportarTareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" selected="True">
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h1 class="display-3">PROFESOR</h1>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <h1 class="display-3">EXPORTAR TAREAS GENÉRICAS</</h1>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:Label ID="asignaturasLabel" runat="server" Text="Selecciona una asignatura"></asp:Label>
                <asp:DropDownList ID="asignaturas" runat="server" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" OnSelectedIndexChanged="asignaturas_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                    <asp:ListItem Enabled="True" Text="-- Selecciona una asignatura. --" Selected="True" Value="-1"></asp:ListItem>
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
                <asp:Button ID="exportarXml" runat="server" Text="Exportar a XML" CssClass="btn btn-primary" OnClick="exportarXml_Click" />
            </div>
            <div class="form-group">
                <asp:Button ID="exportarJson" runat="server" Text="Exportar a JSON" Enabled="false" CssClass="btn btn-primar" />
            </div>
        </div>
        <div class="row">
            <div runat="server" class="alert alert-danger" role="alert" id="errorCrearArchivo" visible="false">
                Ha habido algún error al crear el fichero XML.
            </div>
            <div runat="server" class="alert alert-info" role="alert" id="infoSeleccionarAsig" visible="false">
                Selecciona una asigantura válida.
            </div>
            <div runat="server" class="alert alert-success" role="alert" id="archicoCreado" visible="false">
                El fichero XML se ha creado correctamente en la carpeta \\ App_Data //
            </div>
        </div>
        <div class="row">
            <div class="form-group">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
