<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="bp2.Admin.Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1>Upload Photos</h1>
        <asp:Panel ID="pnlRecipe" runat="server">
            <asp:Repeater ID="rptRecipe" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <a href="Upload.aspx?PhotoType=Recipe&ID=<%# Eval("RecipeID") %>"><%#Eval("Name") %></a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </asp:Panel>

        <asp:Panel ID="pnlSelect" runat="server">

            <h3>
                <asp:Label ID="lblName" runat="server" /></h3>
            <asp:Repeater ID="rptPhotos" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <img src="<%#Eval("Thumb") %>" />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <label class="choose">
                <asp:FileUpload ID="fileUpload" CssClass="file" runat="server" />
            </label>
            <br />
            <asp:Button OnClientClick="if (!Page_ClientValidate()){ return false; } else{ if(this.value === 'Saving...') { return false; } else { this.value = 'Saving...'; }}" ID="btnSubmit" CssClass="btn btn-default" OnClick="UploadFile" Text="Upload" runat="server" />
        </asp:Panel>

        <asp:Panel ID="pnlResult" runat="server">
            <asp:Label ID="lblResult" runat="server" />
            <asp:Image ID="imgResult" runat="server" />
        </asp:Panel>
        <div class="padded-box">
            <style>
                label.choose:before {
                    align-items: flex-start;
                    background-color: rgb(255, 255, 255);
                    background-image: none;
                    border-bottom-color: rgb(204, 204, 204);
                    border-bottom-left-radius: 4px;
                    border-bottom-right-radius: 4px;
                    border-bottom-style: solid;
                    border-bottom-width: 1px;
                    border-image-outset: 0px;
                    border-image-repeat: stretch;
                    border-image-slice: 100%;
                    border-image-source: none;
                    border-image-width: 1;
                    border-left-color: rgb(204, 204, 204);
                    border-left-style: solid;
                    border-left-width: 1px;
                    border-right-color: rgb(204, 204, 204);
                    border-right-style: solid;
                    border-right-width: 1px;
                    border-top-color: rgb(204, 204, 204);
                    border-top-left-radius: 4px;
                    border-top-right-radius: 4px;
                    border-top-style: solid;
                    border-top-width: 1px;
                    box-sizing: border-box;
                    color: rgb(51, 51, 51);
                    cursor: pointer;
                    display: inline-block;
                    font-family: Verdana, sans-serif;
                    font-size: 14px;
                    font-stretch: 100%;
                    font-style: normal;
                    font-variant-caps: normal;
                    font-variant-east-asian: normal;
                    font-variant-ligatures: normal;
                    font-variant-numeric: normal;
                    font-weight: 400;
                    height: 34px;
                    letter-spacing: normal;
                    line-height: 20px;
                    margin-bottom: 0px;
                    margin-left: 0px;
                    margin-right: 0px;
                    margin-top: 0px;
                    overflow-x: visible;
                    overflow-y: visible;
                    padding-bottom: 6px;
                    padding-left: 12px;
                    padding-right: 12px;
                    padding-top: 6px;
                    text-align: center;
                    text-indent: 0px;
                    text-rendering: auto;
                    text-shadow: none;
                    text-size-adjust: 100%;
                    text-transform: none;
                    touch-action: manipulation;
                    user-select: none;
                    vertical-align: middle;
                    white-space: nowrap;
                    width: 74.45px;
                    word-spacing: 0px;
                    writing-mode: horizontal-tb;
                    -webkit-appearance: none;
                    -webkit-rtl-ordering: logical;
                    -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
                    -webkit-border-image: none;
                }

                label.choose:before {
                    content: 'Choose file';
                    padding: 6px 12px;
                    position: absolute;
                    width: 115px;
                }
            </style>
</asp:Content>
