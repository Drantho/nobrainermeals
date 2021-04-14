<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bp2.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <img src="images/banner.jpg" style="width: 100%">

    <div class="padded-box">
        
        <div class="feature-box">
            <img src="Images/icon_faster.png" />
            <h1>Faster</h1>
            <p>
                You can use our great<br />
                recipes to plan your<br />
                weekly shopping list.
            </p>
            <a href="/Help">FIND OUT MORE <i class="fas fa-angle-right"></i>
            </a>

        </div>

        <div class="feature-box">
            <img src="Images/icon_easier.png" />
            <h1>Easier</h1>
            <p>
                Many grocery stores let you<br />
                order online and pickup at<br />
                your convenience.
            </p>
            <a href="/Help">FIND OUT MORE <i class="fas fa-angle-right"></i>
            </a>
        </div>

        <div class="feature-box">
            <img src="Images/icon_cheaper.png" />
            <h1>Cheaper</h1>
            <p>
                You compare prices, pick<br />
                the local store you like,<br />
                and save!
            </p>
            <a href="/Help">FIND OUT MORE <i class="fas fa-angle-right"></i>
            </a>
        </div>
    </div>
    

    <div class="padded-box">
        <div class="narrow">
            <h1 class="info-header">What we do for you</h1>
                <ul class="mainList">
                    <li>Easily adjust our recipes to your family size and appetite.
                    </li>
                    <li>Search recipes by name, ingredient, cooking style, or dietary restriction.
                    </li>
                    <li>Compare food prices at your stores.
                    </li>
                    <li>Let someone else shop for you.
                    </li>
                    <li>Choose from organic and locally sourced food.
                    </li>
                    <li>Many more exciting features coming soon!
                    </li>
                </ul>
            
        </div>
    </div>
    

    <div class="padded-box">
        <a href="RecipeList.aspx">
            <h1 class="info-header" style="text-align: center; z-index: 10;">
                Go to the recipe list!
            </h1>            
            <img src="images/recipes.jpg" style="width: 100%; position: relative; z-index: 2" />
        </a>
    </div>

    <div class="padded-box">
        <h1 class="info-header">Recent Recipes</h1>
    </div>

    <asp:Repeater ID="rptRecent" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col-quarter">
                <div class="demo-card-wide mdl-card mdl-shadow--2dp">

                    <a href="ViewRecipe.aspx?RecipeID=<%# Eval("RecipeID") %>">                    
                        <div class="mdl-card__title" style="background: url('<%# Eval("Photos[0].Thumb") %>') no-repeat; box-sizing: border-box; height: 144px; width: 232px;">                                                                                                                      
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
                        <%# bp2.Models.Rating.RatingStars(Convert.ToInt32(Eval("AvgRating")))[4] %>
                        <%#Eval("DescriptionSummary") %>
                    </div>
                    <div class="mdl-card__actions mdl-card--border">
                        <a class="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" href="ViewRecipe.aspx?RecipeID=<%# Eval("RecipeID") %>">View Recipe
                        </a>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>
                      
    

</asp:Content>
