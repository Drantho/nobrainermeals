<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" Inherits="bp2.Admin.AddNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Add News Item</h1>
        <div class="row">
            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                <asp:TextBox CssClass="mdl-textfield__input" ID="txtTitle" runat="server" />
                <asp:Label CssClass="mdl-textfield__label" AssociatedControlID="txtTitle" runat="server">Title</asp:Label>
            </div>
            <br />
            <div class="mdl-textfield mdl-js-textfield">
                <asp:TextBox CssClass="mdl-textfield__input" TextMode="MultiLine" Rows="4" Columns="25" ID="txtBody" runat="server" />
                <asp:Label CssClass="mdl-textfield__label" AssociatedControlID="txtBody" runat="server">Body</asp:Label>
            </div>
            <br />
            <asp:Button Text="Add News" CssClass="mdl-button mdl-js-button mdl-button--accent " OnClick="ProcessSubmit" runat="server" />

            <h1>
                <asp:Label ID="lblResult" runat="server" /></h1>

        </div>
    </div>
</asp:Content>
