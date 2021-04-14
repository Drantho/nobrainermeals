<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditIngredient.aspx.cs" Inherits="bp2.Admin.EditIngredient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Edit Ingredient</h1>
        <h3>
            <asp:Label ID="lblRecipe" runat="server" />
        </h3>
        <h3>
            <asp:Label ID="lblResult" runat="server" />
        </h3>
        <div class="form-horizontal">
            <div class="form-group">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientName" CssClass="col-md-4 control-label">Name</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientName" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientDescription" CssClass="col-md-4 control-label">Description</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientDescription" TextMode="MultiLine" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientID" CssClass="col-md-4 control-label">ID</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientID" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientSource" CssClass="col-md-4 control-label">Source</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientSource" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPrice" CssClass="col-md-4 control-label">Price</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPrice" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientPhoto" CssClass="col-md-4 control-label">Photo</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientPhoto" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientInfoLink" CssClass="col-md-4 control-label">Info Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientInfoLink" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientCartLink" CssClass="col-md-4 control-label">Cart Link</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientCartLink" CssClass="form-control" />
                    </div>
                </div>

                <h5>Ingredient Amount(in package/container)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="IngredientQuantity" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="IngredientQuantity" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlIngredientUnit" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlIngredientUnit" runat="server" />
                    </div>
                </div>

                <h5>Ingredient Amount(in recipe)</h5>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="RecipeIngredientQuantity" CssClass="col-md-4 control-label">Quantity</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:TextBox runat="server" ID="RecipeIngredientQuantity" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="ddlRecipeIngredientUnit" CssClass="col-md-4 control-label">Unit</asp:Label>
                    <div class="col-md-8 inputGroupContainer">
                        <asp:DropDownList ID="ddlRecipeIngredientUnit" runat="server" />
                    </div>
                </div>

                <asp:Button Text="Update Ingredient" OnClick="UpdateIngredient" CssClass="btn btn-default" runat="server" />
            </div>

        </div>
    </div>
</asp:Content>
