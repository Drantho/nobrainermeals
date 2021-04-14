<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingList.aspx.cs" Inherits="bp2.ShoppingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">


        <h1 class="title">
            <asp:Label ID="lblStore" runat="server" />
            Shopping List</h1>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <label class="containerList" >
                    (<%#Eval("RecipeRequired") %>) -
                <%#Eval("Ingredient.Description") %>
                    <input type="checkbox">
                    <span class="checkmark"></span>
                </label>
            </ItemTemplate>
            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblResult" runat="server" />

    </div>

    <style>

        /* The container */
.containerList {
  display: block;
  position: relative;
  padding-left: 35px;
  margin-bottom: 12px;
  cursor: pointer;
  font-size: 22px;
  line-height: 1.7;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

/* Hide the browser's default checkbox */
.containerList input {
  position: absolute;
  opacity: 0;
  cursor: pointer;
  height: 0;
  width: 0;
}

/* Create a custom checkbox */
.checkmark {
  position: absolute;
  top: 6px;
  left: 0;
  height: 25px;
  width: 25px;
  background-color: #eee;
  border-style: solid;
}

/* On mouse-over, add a grey background color */
.container:hover input ~ .checkmark {
  background-color: #ccc;
}

/* When the checkbox is checked, add a blue background */
.containerList input:checked ~ .checkmark {
  background-color: #2196F3;
}

/* Create the checkmark/indicator (hidden when not checked) */
.checkmark:after {
  content: "";
  position: absolute;
  display: none;
}

/* Show the checkmark when checked */
.containerList input:checked ~ .checkmark:after {
  display: block;
}

/* Style the checkmark/indicator */
.containerList .checkmark:after {
  left: 9px;
  top: 5px;
  width: 5px;
  height: 10px;
  border: solid white;
  border-width: 0 3px 3px 0;
  -webkit-transform: rotate(45deg);
  -ms-transform: rotate(45deg);
  transform: rotate(45deg);
}

    </style>

</asp:Content>
