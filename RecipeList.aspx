<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecipeList.aspx.cs" Inherits="bp2.RecipeList1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="padded-box">
        <h1 class="title">
            <asp:HyperLink runat="server" ID="btnPrevious">
                    <i class="material-icons nav-icon">navigate_before</i>
            </asp:HyperLink>
            Recipe List
                <asp:HyperLink ID="btnNext" runat="server">
                    <i class="material-icons nav-icon">navigate_next</i>
                </asp:HyperLink>
        </h1>
        <br />
        <div class="nav-box">
            <strong>Sort by:&nbsp;&nbsp; </strong>
            <asp:HyperLink ID="hlkName" NavigateUrl="~/RecipeList.aspx?Sort=Name&Page=1" runat="server">
                Name
            </asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hlkRating" NavigateUrl="~/RecipeList.aspx?Sort=Rating&Page=1" runat="server">
                Rating
            </asp:HyperLink>
            &nbsp;&nbsp;
            <asp:HyperLink ID="hlkPopular" NavigateUrl="~/RecipeList.aspx?Sort=Popular&Page=1" runat="server">
                Popular
            </asp:HyperLink>
        </div>

    </div>
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
    <div class="padded-box">
        <h4>
            <asp:PlaceHolder ID="plhPages" runat="server" />
        </h4>
    </div>
    <asp:HiddenField ID="hdnStartNumber" runat="server" />

</asp:Content>
