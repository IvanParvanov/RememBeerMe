<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RememBeer.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>sadasda</h2>
    <asp:Repeater ID="UserRepeater" runat="server" DataSourceID="UserDataSource" ItemType="RememBeer.Data.ApplicationUser">
        <ItemTemplate>
            <ul>
                <li><%#:Item.Email %></li>
                <li><%#:Item.Id %></li>
                <li><%#:Item.UserName %></li>
            </ul>
        </ItemTemplate>
    </asp:Repeater>
    <asp:LinqDataSource OnContextCreating="UserDataSource_OnContextCreating"
                        ID="UserDataSource"
                        runat="server"
                        ContextTypeName="RememBeer.Data.Repositories.RememBeerData"
                        EntityTypeName="ApplicationUser"
                        TableName="Users">
    </asp:LinqDataSource>

</asp:Content>