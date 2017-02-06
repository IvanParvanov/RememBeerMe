<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView ID="ReviewsListView" runat="server"
                      ItemType="RememBeer.Models.BeerReview"
                      OnItemEditing="ReviewsListView_OnItemEditing">
            <ItemTemplate>
                <div class="container">
                    <h1>Your beers</h1>
                    <div class="well">
                        <div class="media">
                                <img class="pull-left media-object" src="http://lorempixel.com/150/150/">
                            <div class="media-body">
                                <h3 class="media-heading"><%#: Item.Beer.Name %> <span> <em>@ <%#:Item.Place %></em></span></h3>
                                <h5 class="text-right"><%#: Item.CreatedAt.ToShortDateString() %></h5>
                                <p><%#: Item.Description %>.</p>
                                <h6>
                                    <em>Bottom line:</em>
                                </h6>
                                <ul class="list-inline">
                                    <li>
                                        Overall:
                                        <span class="badge"><%#: Item.Overall %></span>
                                    </li>
                                    <li>|</li>
                                    <li>
                                        Taste:
                                        <span class="badge"><%#: Item.Taste %></span>
                                    </li>
                                    <li>|</li>
                                    <li>
                                        Look:
                                        <span class="badge"><%#: Item.Look %></span>
                                    </li>
                                    <li>|</li>
                                    <li>
                                        Aroma:
                                        <span class="badge"><%#: Item.Smell %></span>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
            <EditItemTemplate>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
                <h1> EDIT MEEEEEEEE</h1>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>