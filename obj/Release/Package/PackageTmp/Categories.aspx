<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="bp2.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1 class="title">Categories</h1>
        <asp:Repeater ID="rptCategories" runat="server">
            <HeaderTemplate>
                <div class="narrow">
                    <ul class="tags">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="Category.aspx?Category=<%#Container.DataItem %>">
                        <%#Container.DataItem %>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                    </ul>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
