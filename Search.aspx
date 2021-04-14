<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="bp2.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="title">
        <asp:Label ID="lblTitle" runat="server" />
    </h1>
    <div class="padded-box">
        <asp:Repeater ID="rptRecipes" runat="server">
            <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-quarter">
                <div class="demo-card-wide mdl-card mdl-shadow--2dp">

                    <a href="ViewRecipe.aspx?RecipeID=<%# Eval("RecipeID") %>">                    
                        <div class="mdl-card__title" style="background: url('<%# Eval("Photos[0].Thumb") %>') no-repeat; box-sizing: border-box; height: 144px; width 232px;">                                                                                                                      
                        </div>
                    </a>

                    <div class="mdl-card__supporting-text">
                        <a href="ViewRecipe.aspx?RecipeID=<%# Eval("RecipeID") %>" style="color: #333333">
                            <strong><%# Eval("Name") %></strong>
                        </a><br>
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[0] %>
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[1] %>
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[2] %>
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[3] %>
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[4] %><br>
                        <%#Eval("DescriptionSummary") %>
                    </div>
                    <div class="mdl-card__actions mdl-card--border">
                        <a class="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" href="ViewRecipe.aspx?RecipeID=<%# Eval("RecipeID") %>">
                            View Recipe
                        </a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
        </asp:Repeater>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    </div>
</asp:Content>
