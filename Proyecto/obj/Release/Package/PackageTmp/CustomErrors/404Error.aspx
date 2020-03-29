<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404Error.aspx.cs" Inherits="Proyecto.CustomErrors._404Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="error-template">
                <h1>
                    Oops!</h1>
                <h2>
                    404 Not Found</h2>
                <div class="error-details">
                    Sorry, an error has occured, Requested page not found!
                </div>
                <div class="error-actions">
                    <asp:HyperLink runat="server" CssClass="btn btn-primary btn-lg" NavigateUrl="~/Principal.aspx"><span class="glyphicon glyphicon-home"></span>Take Me Home</asp:HyperLink>
                    <asp:HyperLink runat="server" CssClass="btn btn-default btn-lg" NavigateUrl="mailto:galvarez024@ikasle.ehu.eus; igarcia361@ikasle.ehu.eus"><span class="glyphicon glyphicon-envelope"></span>Contact Support</asp:HyperLink>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
