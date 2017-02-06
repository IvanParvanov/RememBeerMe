<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RememBeer.WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>sadasda</h2>
    <asp:Repeater ID="UserRepeater" runat="server" DataSourceID="UserDataSource" ItemType="RememBeer.Common.Identity.Models.ApplicationUser">
        <ItemTemplate>
            <ul class="list-group">
                <li class="list-group-item"><%#:Item.Id %></li>
                <li class="list-group-item"><%#:Item.Email %></li>
                <li class="list-group-item"><%#:Item.UserName %></li>
            </ul>
            <hr/>
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