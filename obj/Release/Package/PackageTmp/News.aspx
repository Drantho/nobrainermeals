<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="bp2.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="padded-box">
        <h1 class="title">News</h1>
        <div class="narrow">
            <asp:Repeater ID="rptNews" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <h3><%#Eval("Title") %></h3>
                    <strong class="description">
                        Posted:
                        <%# DataBinder.Eval(Container.DataItem, "Posted", "{0:M/d/yyyy}") %>
                    </strong>
                    <p class="description">
                        <%#Eval("Body") %>
                    </p>
                    <hr />
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
