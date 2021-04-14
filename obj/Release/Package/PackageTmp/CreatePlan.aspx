<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreatePlan.aspx.cs" Inherits="bp2.CreatePlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Plan</h1>

    <h1><asp:Label ID="lblResult" runat="server" /></h1>

    <h3>Recipes</h3>
    <asp:Repeater ID="rptAllRecipes" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <asp:LinkButton OnCommand="AddRecipe" CommandArgument=<%#Eval("RecipeID") %> runat="server"><%#Eval("Name") %></asp:LinkButton>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <h3>Ingredients</h3>
    <asp:PlaceHolder ID="plhIngredients" runat="server" />
</asp:Content>
