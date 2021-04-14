<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewRecipe.aspx.cs" Inherits="bp2.ViewRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCalculate" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="lbnSetRating1" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="lbnSetRating2" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="lbnSetRating3" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="lbnSetRating4" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="lbnSetRating5" EventName="Command" />
            <asp:AsyncPostBackTrigger ControlID="btnAddComment" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnFavorite" EventName="Click" />
        </Triggers>
        <ContentTemplate>

            <!-- Title -->
            <div class="padded-box section-box">
                <h1 class="title">
                    <asp:Label ID="lblName" runat="server" />
                </h1>

                <div class="info-box">



                    <div class="mdl-tooltip" data-mdl-for="MainContent_lbnSetRating1">
                        Rate 1 Star
                    </div>
                    <asp:LinkButton ID="lbnSetRating1" CommandArgument="1" OnCommand="RateRecipe" runat="server">
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    </asp:LinkButton>
                    <div class="mdl-tooltip" data-mdl-for="MainContent_lbnSetRating2">
                        Rate 2 Stars
                    </div>
                    <asp:LinkButton ID="lbnSetRating2" CommandArgument="2" OnCommand="RateRecipe" runat="server">
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    </asp:LinkButton>
                    <div class="mdl-tooltip" data-mdl-for="MainContent_lbnSetRating3">
                        Rate 3 Stars
                    </div>
                    <asp:LinkButton ID="lbnSetRating3" CommandArgument="3" OnCommand="RateRecipe" runat="server">
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    </asp:LinkButton>
                    <div class="mdl-tooltip" data-mdl-for="MainContent_lbnSetRating4">
                        Rate 4 Stars
                    </div>
                    <asp:LinkButton ID="lbnSetRating4" CommandArgument="4" OnCommand="RateRecipe" runat="server">
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    </asp:LinkButton>
                    <div class="mdl-tooltip" data-mdl-for="MainContent_lbnSetRating5">
                        Rate 5 Stars
                    </div>
                    <asp:LinkButton ID="lbnSetRating5" CommandArgument="5" OnCommand="RateRecipe" runat="server">
                    <span class="glyphicon glyphicon-star" aria-hidden="true"></span>
                    </asp:LinkButton>

                    <asp:Label ID="lblRating" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    <div class="mdl-tooltip" data-mdl-for="MainContent_btnFavorite">
                        Add to Favorites
                    </div>
                    <asp:LinkButton ID="btnFavorite" OnCommand="AddFavorite" runat="server">
                        <i class="far fa-heart"></i>
                    </asp:LinkButton>

                    <div class="mdl-tooltip" data-mdl-for="MainContent_heart">
                        Your Favorite
                    </div>
                    <i id="heart" class="fas fa-heart" runat="server"></i>

                    <div class="mdl-tooltip" data-mdl-for="favorite">
                        Favorite Count
                    </div>
                    <i id="favorite" visible="false" class="fas fa-heart" runat="server"></i>

                    <asp:Label ID="lblFavoriteCount" runat="server" />
                    <div>
                        <asp:Label ID="lblRatingResult" runat="server" />
                    </div>


                </div>

                <asp:Repeater ID="rptTags" runat="server">
                    <HeaderTemplate>
                        <ul class="tags">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <a href="category.aspx?Category=<%#Container.DataItem %>">
                                <%#Container.DataItem %>
                            </a>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

            </div>

            <!-- Photos -->
            <div class="section-box">
                <asp:Image ID="imgTitle" CssClass="title-image" runat="server" />
                <div class="no-margin">
                    <asp:Repeater ID="rptPhotos" runat="server">
                        <HeaderTemplate>
                            <ul class="image-list">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <a onclick="switchImage('<%#Eval("Full") %>')">
                                    <img src="<%#Eval("Thumb") %>" />
                                </a>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <!-- Description -->
            <div class="padding-box section-box">
                <p class="narrow description">
                    <asp:Label ID="lblDescription" runat="server" />
                </p>
            </div>

            <!-- Time & Yield -->
            <div class="padded-box section-box">
                <div class="mdl-grid">
                    <div class="mdl-cell mdl-cell--4-col time-box">
                        <h3>Prep Time</h3>
                        <i class="far fa-clock fa-10x"></i>
                        <h3>
                            <asp:Label ID="lblPrepTime" runat="server" />
                            min.
                        </h3>
                    </div>
                    <div class="mdl-cell mdl-cell--4-col time-box">
                        <h3>Cook Time</h3>
                        <i class="far fa-clock fa-10x"></i>
                        <h3>
                            <asp:Label ID="lblCookTime" runat="server" />
                            min.
                        </h3>
                    </div>
                    <div class="mdl-cell mdl-cell--4-col time-box">
                        <h3>Yield</h3>
                        <i class="fas fa-users fa-10x"></i>
                        <h3>
                            <asp:Label ID="lblYield" runat="server" />
                            Servings
                        </h3>

                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label">
                            <asp:TextBox runat="server" TextMode="Number" ID="txtYield" CssClass="mdl-textfield__input" />
                            <asp:Label runat="server" AssociatedControlID="txtYield" CssClass="mdl-textfield__label">New Yield</asp:Label>
                            <asp:CompareValidator runat="server" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtYield" ErrorMessage="Value must be a whole number" />
                        </div>

                        <asp:Button ID="btnCalculate" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" OnClick="ProcessSubmit" Text="Update Yield" runat="server" />

                    </div>

                </div>
            </div>

            <!-- Ingredeients -->
            <div class="padded-box section-box">
                <div class="narrow">
                    <asp:Repeater ID="rptIngredients" runat="server">
                        <HeaderTemplate>
                            <h1 class="title">Ingredients</h1>
                            <ul class="two-columns">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <span class="list-text">
                                    <%#Eval("FractionQuantity") %> <%#Eval("Unit.Name") %><%#Eval("Plural") %> <%#Eval("Ingredient.Name") %>
                                </span>                                
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <!-- Directions -->
            <div class="padded-box section-box">
                <div class="narrow">
                    <h1 class="title">Directions</h1>
                    <asp:Repeater ID="rptDirections" runat="server">
                        <HeaderTemplate>
                            <ul class="directions">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <%# Container.DataItem %>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <!-- Shopping List -->
            <div class="padded-box section-box">

                <h1 class="title">Shopping List</h1>
                <asp:PlaceHolder ID="plhSupplierList" runat="server" />

                <div id="suppliers">
                    <asp:PlaceHolder ID="plhShoppingList" runat="server" />
                </div>

            </div>

            <!-- Equipment -->
            <div class="padded-box section-box">
                <h1 class="title">Recommended Equipment</h1>

                <asp:Repeater ID="rptEquipment" runat="server">
                    <HeaderTemplate>
                        <ul class="equipment">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <h5>
                                <a href="<%# Eval("Equipment.InfoLink") %>" target="_blank">
                                    <%# Eval("Equipment.Name") %>
                                </a>
                            </h5>
                            <img src="<%# Eval("Equipment.PhotoLink") %>" /><br />
                            <%#Eval("equipment.price", "{0:c}") %> at <%# Eval("Equipment.Source") %><br />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

            </div>

            <!-- Recommends -->
            <div class="section-box">
                <asp:Repeater ID="rptRecommends" runat="server">
                    <HeaderTemplate>
                        <h1 class="title">Recommended Recipes</h1>
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
                                    </a>
                                    <br>
                                    <i class="material-icons">grade</i>
                                    <i class="material-icons">grade</i>
                                    <i class="material-icons">grade</i>
                                    <i class="material-icons">grade</i>
                                    <i class="material-icons">grade</i><br>
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
                    </FooterTemplate>
                </asp:Repeater>
            </div>

            <!-- Comments -->
            <div class="padded-box section-box">
                <div class="narrow">
                    <div class="narrow">
                        <h1 class="title">Comments</h1>
                        <ul class="comments">
                            <asp:PlaceHolder ID="plhComments" runat="server" />
                        </ul>
                        <div style="width: 300px; margin: auto; text-align: center;">
                            <div class="mdl-textfield mdl-js-textfield">
                                <asp:Label runat="server" AssociatedControlID="txtComment" CssClass="mdl-textfield__label">Leave Your Comment</asp:Label>
                                <asp:TextBox runat="server" ID="txtComment" Rows="4" Columns="20" TextMode="MultiLine" CssClass="mdl-textfield__input" />
                            </div>
                            <br />

                            <asp:Button ID="btnAddComment" OnClick="AddComment" Text="Add Comment" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-button--colored" runat="server" /><br />
                            <asp:Label ID="lblCommentResult" runat="server" />
                        </div>


                    </div>

                </div>
            </div>

            <script>

                function showSupplier(supplier) {
                    $("#suppliers").children().hide();
                    $("#" + supplier).show();
                }

                function switchImage(url) {
                    $("#MainContent_imgTitle").attr("src", url);
                }
            </script>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
