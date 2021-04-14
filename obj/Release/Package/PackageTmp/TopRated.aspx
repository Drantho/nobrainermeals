<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopRated.aspx.cs" Inherits="bp2.TopRated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Top Rated Recipes</h1>
    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPrevious" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNext" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
                <div class="col-xs-2">
                    <asp:Button ID="btnPrevious" OnClick="GetPrevious" Text="<" runat="server" />
                </div>
                <div class="col-xs-8">
                    <asp:Repeater ID="rptRecipes" runat="server">
                        <HeaderTemplate>
                            
                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <h3>
                                    <a href="ViewRecipe.aspx?RecipeID=<%#Eval("RecipeID") %>">
                                        <img src="<%# Eval("Photos[0].Thumb") %>" />
                                        <%#Eval("RecipeID") %>
                                        <%#Eval("Name") %> - <%#Eval("Posted") %> - Avg Rating: <%#Eval("AvgRating") %> - Fav Count: <%#Eval("FavoriteCount") %> 
                                    </a>
                                </h3>
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:HiddenField ID="hdnStartNumber" runat="server" />
                </div>
                <div class="col-xs-2">
                    <asp:Button ID="btnNext" OnClick="GetNext" Text=">" runat="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
