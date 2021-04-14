<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddRecipe.aspx.cs" Inherits="bp2.Admin.AddRecipe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Add Recipe</h1>

        <asp:Panel ID="pnlForm" runat="server">

            <div class="form-horizontal">

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

                <h3>Ingredients</h3>

                <h4>Ingredient 1</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName1" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription1" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription1" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID1" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource1" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice1" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto1" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink1" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink1" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink1" CssClass="form-control" />
                    </div>
                </div>

                <h5>Ingredient Amount(in package/container)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity1" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit1" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit1" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity1" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit1" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit1" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 2</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName2" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName2" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription2" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID2" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource2" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice2" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto2" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink2" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink2" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity2" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit2" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit2" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity2" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit2" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit2" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 3</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName3" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription3" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription3" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID3" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource3" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice3" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto3" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink3" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink3" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity3" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit3" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit3" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity3" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit3" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit3" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 4</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName4" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription4" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription4" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID4" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource4" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice4" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto4" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink4" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink4" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity4" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit4" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit4" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity4" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit4" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit4" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 5</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName5" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription5" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription5" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID5" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource5" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice5" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto5" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink5" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink5" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity5" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit5" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit5" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity5" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit5" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit5" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 6</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName6" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription6" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription6" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID6" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource6" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice6" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto6" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink6" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink6" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity6" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit6" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit6" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity6" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity6" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit6" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit6" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 7</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName7" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription7" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription7" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID7" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource7" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice7" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto7" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink7" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink7" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity7" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit7" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit7" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity7" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity7" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit7" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit7" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 8</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName8" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription8" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription8" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID8" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource8" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice8" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto8" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink8" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink8" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity8" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit8" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit8" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity8" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity8" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit8" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit8" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 9</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName9" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription9" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription9" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID9" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource9" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice9" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto9" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink9" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink9" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity9" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit9" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit9" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity9" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity9" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit9" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit9" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 10</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName10" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription10" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription10" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID10" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource10" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice10" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto10" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink10" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink10" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity10" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit10" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit10" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity10" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity10" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit10" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit10" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 11</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName11" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription11" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription11" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID11" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource11" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice11" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto11" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink11" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink11" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity11" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit11" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit11" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity11" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity11" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit11" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit11" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 12</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName12" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription12" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription12" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID12" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource12" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice12" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto12" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink12" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink12" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity12" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit12" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit12" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity12" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity12" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit12" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit12" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 13</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName13" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription13" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription13" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID13" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource13" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice13" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto13" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink13" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink13" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity13" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit13" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit13" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity13" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity13" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit13" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit13" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 14</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName14" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription14" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription14" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID14" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource14" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice14" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto14" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink14" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink14" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity14" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit14" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit14" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity14" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity14" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit14" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit14" runat="server" />
                    </div>
                </div>

                <h4>Ingredient 15</h4>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName15" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription15" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription15" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID15" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource15" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice15" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto15" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink15" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink15" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity15" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit15" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit15" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity15" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity15" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit15" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit15" runat="server" />
                    </div>
                </div>

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

                <hr />
                <h3>Equipment 1</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentName1" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentName1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentSource1" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentSource1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentExternalID1" CssClass="col-md-4 control-label">External ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentExternalID1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentInfoLink1" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentInfoLink1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentCartLink1" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentCartLink1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPhotoLink1" CssClass="col-md-4 control-label">Photo Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPhotoLink1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPrice1" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPrice1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentDescription1" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentDescription1" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentNotes1" CssClass="col-md-4 control-label">Notes</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentNotes1" CssClass="form-control" />
                    </div>
                </div>


                <h3>Equipment 2</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentName2" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentName2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentSource2" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentSource2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentExternalID2" CssClass="col-md-4 control-label">External ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentExternalID2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentInfoLink2" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentInfoLink2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentCartLink2" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentCartLink2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPhotoLink2" CssClass="col-md-4 control-label">Photo Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPhotoLink2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPrice2" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPrice2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentDescription2" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentDescription2" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentNotes2" CssClass="col-md-4 control-label">Notes</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentNotes2" CssClass="form-control" />
                    </div>
                </div>

                <h3>Equipment 3</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentName3" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentName3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentSource3" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentSource3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentExternalID3" CssClass="col-md-4 control-label">External ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentExternalID3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentInfoLink3" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentInfoLink3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentCartLink3" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentCartLink3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPhotoLink3" CssClass="col-md-4 control-label">Photo Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPhotoLink3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPrice3" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPrice3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentDescription3" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentDescription3" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentNotes3" CssClass="col-md-4 control-label">Notes</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentNotes3" CssClass="form-control" />
                    </div>
                </div>

                <h3>Equipment 4</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentName4" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentName4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentSource4" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentSource4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentExternalID4" CssClass="col-md-4 control-label">External ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentExternalID4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentInfoLink4" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentInfoLink4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentCartLink4" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentCartLink4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPhotoLink4" CssClass="col-md-4 control-label">Photo Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPhotoLink4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPrice4" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPrice4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentDescription4" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentDescription4" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentNotes4" CssClass="col-md-4 control-label">Notes</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentNotes4" CssClass="form-control" />
                    </div>
                </div>

                <h3>Equipment 5</h3>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentName5" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentName5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentSource5" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentSource5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentExternalID5" CssClass="col-md-4 control-label">External ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentExternalID5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentInfoLink5" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentInfoLink5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentCartLink5" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentCartLink5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPhotoLink5" CssClass="col-md-4 control-label">Photo Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPhotoLink5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentPrice5" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentPrice5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentDescription5" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentDescription5" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="EquipmentNotes5" CssClass="col-md-4 control-label">Notes</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="EquipmentNotes5" CssClass="form-control" />
                    </div>
                </div>


                <asp:Button Text="Add Recipe" OnClick="ProcessSubmit" CssClass="btn btn-default" runat="server" />

            </div>

        </asp:Panel>

        <asp:Panel ID="pnlResult" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
