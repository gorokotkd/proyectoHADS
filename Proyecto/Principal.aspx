<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Proyecto.Principal" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Optimizar-tareas-1024x682.jpg" />

    <footer>
        <!--     <div class="list-group">
            <asp:ListBox ID="profesoresList" runat="server" Height="200" Width="200"></asp:ListBox>
            <asp:ListBox ID="alumnosList" runat="server" Height="200" Width="200"></asp:ListBox>
        </div-->
        <asp:Timer ID="Timer1" runat="server" Interval="8000" OnTick="Timer1_Tick"></asp:Timer>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <div runat="server" id="contProfesores" visible="false">
                     <h2>Profesores Conectados: <asp:Label runat="server" ID="profContLabel"/></h2>
                </div>
                <asp:ListView runat="server" ID="profesoresListView">
                    <LayoutTemplate>
                       
                        <ul class="list-group">
                            <li id="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="list-group-item"><%#: Eval("EmailList") %></li>
                    </ItemTemplate>
                </asp:ListView>


                 <div runat="server" id="contAlumnos" visible="false">
                     <h2>Alumnos Conectados: <asp:Label runat="server" ID="aluContLabel"/></h2>
                </div>
                <asp:ListView runat="server" ID="alumnosListView">
                    <LayoutTemplate>
                        <ul class="list-group">
                            <li id="itemPlaceholder" runat="server" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <li class="list-group-item"><%#: Eval("EmailList") %></li>
                    </ItemTemplate>
                </asp:ListView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </footer>
</asp:Content>
