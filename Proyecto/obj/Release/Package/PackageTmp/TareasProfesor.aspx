<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TareasProfesor.aspx.cs" Inherits="Proyecto.TareasProfesor" %>
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
                    <h1 class="display-3">GESTIÓN DE TAREAS GENÉRICAS</</h1>
                </div>
            </div>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" for="Select1" runat="server" Text="Seleccionar Asignaturas"></asp:Label>
            <asp:DropDownList ID="asignaturas" CssClass="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True"></asp:DropDownList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' SelectCommand="SELECT [codigo] FROM [Asignaturas]"></asp:SqlDataSource>
        </div>

        <div class="form-group">
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Insertar nueva tarea" OnClick="Button1_Click" />
        </div>

        <div class="form-group">
            <asp:SqlDataSource ID="TareasGenericas" runat="server"></asp:SqlDataSource>
        </div>
        <div id="tareasView" class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="Codigo" DataSourceID="SqlDataSource2" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:CommandField ShowEditButton="True"></asp:CommandField>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo" ReadOnly="True" SortExpression="Codigo"></asp:BoundField>
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion"></asp:BoundField>
                    <asp:BoundField DataField="CodAsig" HeaderText="CodAsig" SortExpression="CodAsig"></asp:BoundField>
                    <asp:BoundField DataField="HEstimadas" HeaderText="HEstimadas" SortExpression="HEstimadas"></asp:BoundField>
                    <asp:CheckBoxField DataField="Explotacion" HeaderText="Explotacion" SortExpression="Explotacion"></asp:CheckBoxField>
                    <asp:BoundField DataField="TipoTarea" HeaderText="TipoTarea" SortExpression="TipoTarea"></asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#EFF3FB"></RowStyle>

                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:AmigosConnectionString %>' DeleteCommand="DELETE FROM [TareasGenericas] WHERE [Codigo] = @Codigo" InsertCommand="INSERT INTO [TareasGenericas] ([Codigo], [Descripcion], [CodAsig], [HEstimadas], [Explotacion], [TipoTarea]) VALUES (@Codigo, @Descripcion, @CodAsig, @HEstimadas, @Explotacion, @TipoTarea)" SelectCommand="SELECT * FROM [TareasGenericas] WHERE ([CodAsig] = @CodAsig)" UpdateCommand="UPDATE [TareasGenericas] SET [Descripcion] = @Descripcion, [CodAsig] = @CodAsig, [HEstimadas] = @HEstimadas, [Explotacion] = @Explotacion, [TipoTarea] = @TipoTarea WHERE [Codigo] = @Codigo">
                <DeleteParameters>
                    <asp:Parameter Name="Codigo" Type="String"></asp:Parameter>
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Codigo" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Descripcion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="CodAsig" Type="String"></asp:Parameter>
                    <asp:Parameter Name="HEstimadas" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Explotacion" Type="Boolean"></asp:Parameter>
                    <asp:Parameter Name="TipoTarea" Type="String"></asp:Parameter>
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="asignaturas" PropertyName="SelectedValue" Name="CodAsig" Type="String"></asp:ControlParameter>
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Descripcion" Type="String"></asp:Parameter>
                    <asp:Parameter Name="CodAsig" Type="String"></asp:Parameter>
                    <asp:Parameter Name="HEstimadas" Type="Int32"></asp:Parameter>
                    <asp:Parameter Name="Explotacion" Type="Boolean"></asp:Parameter>
                    <asp:Parameter Name="TipoTarea" Type="String"></asp:Parameter>
                    <asp:Parameter Name="Codigo" Type="String"></asp:Parameter>
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>

    </div>

</asp:Content>