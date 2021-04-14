<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditRecipe.aspx.cs" Inherits="bp2.Admin.Edit_Recipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Edit Recipe
        <asp:Label ID="lblTitle" runat="server" />
            <br />
            <asp:Label ID="lblResult" runat="server" />
        </h1>
        <asp:Panel ID="pnlSelectRecipe" runat="server">
            <asp:Repeater ID="rptRecipeList" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>

                    <li>
                        <h4>
                            <a href="EditRecipe.aspx?RecipeID=<%#Eval("RecipeID") %>">
                                <%#Eval("RecipeID") %> - <%#Eval("Name") %> - <%#Eval("Posted") %>
                            </a>
                        </h4>
                    </li>

                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>
        <asp:Panel ID="pnlForm" Visible="false" runat="server">
            <div class="form-horizontal">

                <h3>Basic Info</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="Name" ErrorMessage="Name field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Description" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Description" TextMode="MultiLine" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="Description" ErrorMessage="Description field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Tags" CssClass="col-md-4 control-label">Tags</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" Placeholder="Separate tags with comma" ID="Tags" TextMode="MultiLine" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="Description" ErrorMessage="Tags field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="PrepTime" CssClass="col-md-4 control-label">Prep Time</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="PrepTime" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="PrepTime" ErrorMessage="Prep time field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="CookTime" CssClass="col-md-4 control-label">Cook Time</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="CookTime" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="CookTime" ErrorMessage="Cook time field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Yield" CssClass="col-md-4 control-label">Yield</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Yield" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="Yield" ErrorMessage="Yield field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <hr />
                <h3>Directions</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step1" CssClass="col-md-4 control-label">Step 1</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step1" TextMode="MultiLine" CssClass="form-control" />
                        <asp:RequiredFieldValidator ControlToValidate="Step1" ErrorMessage="Step 1 field is required." CssClass="text-danger" Display="Dynamic" runat="server" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step2" CssClass="col-md-4 control-label">Step 2</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step2" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step3" CssClass="col-md-4 control-label">Step 3</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step3" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step4" CssClass="col-md-4 control-label">Step 4</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step4" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step5" CssClass="col-md-4 control-label">Step 5</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step5" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step6" CssClass="col-md-4 control-label">Step 6</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step6" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step7" CssClass="col-md-4 control-label">Step 7</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step7" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step8" CssClass="col-md-4 control-label">Step 8</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step8" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step9" CssClass="col-md-4 control-label">Step 9</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step9" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step10" CssClass="col-md-4 control-label">Step 10</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step10" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step11" CssClass="col-md-4 control-label">Step 11</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step11" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step12" CssClass="col-md-4 control-label">Step 12</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step12" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step13" CssClass="col-md-4 control-label">Step 13</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step13" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step14" CssClass="col-md-4 control-label">Step 14</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step14" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="Step15" CssClass="col-md-4 control-label">Step 15</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="Step15" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <h3>Ingredients</h3>

                <asp:Repeater ID="rptIngredients" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>

                            <asp:Repeater DataSource="<%#Container.DataItem %>" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <strong><%#Eval("Ingredient.Source") %></strong> - <%#Eval("Quantity") %> <%#Eval("Unit.Name")%> <%#Eval("Ingredient.Name") %> - <a href="EditIngredient.aspx?ID=<%#Eval("RecipeIngredientID") %>">edit</a> -
                                        <asp:LinkButton CommandArgument='<%#Eval("RecipeIngredientID") %>' Text="delete" OnCommand="DeleteIngredient" runat="server" />
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Button Text="Update Recipe" OnClick="UpdateRecipe" CssClass="btn btn-default" runat="server" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
