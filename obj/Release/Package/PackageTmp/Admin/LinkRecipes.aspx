<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkRecipes.aspx.cs" Inherits="bp2.Admin.LinkRecipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Link Recipe<asp:Label ID="lblTitle" Text="s" runat="server" /></h1>
        <asp:Panel ID="pnlSelectRecipe" runat="server">
            <asp:Repeater ID="rptSelectRecipe" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <h4>
                        <a href="LinkRecipes.aspx?RecipeID=<%#Eval("RecipeID") %>">
                            <%#Eval("RecipeID") %> - <%#Eval("Name") %>
                        </a>
                    </h4>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Panel ID="pnlLink" Visible="false" runat="server">
            <asp:CheckBoxList ID="cblRecipes" runat="server" /><br />
            <asp:Button OnClick="SetLinks" Text="Link Recipes" CssClass="btn btn-default" runat="server" />
        </asp:Panel>
    </div>
</asp:Content>
