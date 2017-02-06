<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView ID="ReviewsListView" runat="server" ItemType="RememBeer.Models.BeerReview" OnItemEditing="ReviewsListView_OnItemEditing" DataSourceID="LinqDataSource1">
            <ItemTemplate>
                <div class="card">
                    <div class="container-fliud">
                        <div class="wrapper row">
                            <div class="preview col-md-4">
                                <div class="preview-pic tab-content">
                                    <div class="tab-pane active" id="pic-1">
                                        <img src="http://placekitten.com/400/252"/>
                                    </div>
                                </div>
                            </div>
                            <div class="details col-md-6">
                                <div class="container-fluid">
                                    <h3 class="product-title"><%#: Item.Beer.Name %></h3>
                                    <div class="rating">
                                        <div class="stars">
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star checked"></span>
                                            <span class="fa fa-star"></span>
                                            <span class="fa fa-star"></span>
                                        </div>
                                    </div>
                                    <p class="product-description"><%#: Item.Description %></p>
                                    <div class="action">
                                        <asp:Button ID="EditButton" CssClass="btn btn-warning btn-sm" runat="server" CommandName="Edit" Text="Edit"/>
                                    </div>
                                </div>
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
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"></asp:ObjectDataSource>
</asp:Content>