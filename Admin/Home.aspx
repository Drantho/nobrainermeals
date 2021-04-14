<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="bp2.Admin.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <a href="AddRecipe.aspx">
            <h3>Add a recipe
            </h3>
        </a>
        <a href="EditRecipe.aspx">
            <h3>Edit a recipe
            </h3>
        </a>
        <a href="AddIngredients.aspx">
            <h3>Add ingredients to existing recipe
            </h3>
        </a>
        <a href="Upload.aspx">
            <h3>Upload a photo
            </h3>
        </a>
        <a href="AddNews.aspx">
            <h3>Add a news item
            </h3>
        </a>
        <a href="LinkRecipes.aspx">
            <h3>Link Recipes
            </h3>
        </a>
    </div>
</asp:Content>
