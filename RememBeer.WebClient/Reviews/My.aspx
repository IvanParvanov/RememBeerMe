<%@ Page Title="My Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>

<%@ Register TagPrefix="uc" TagName="BeerRatingSelect" Src="~/UserControls/BeerRatingSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="Notifier" Src="~/UserControls/UserNotifications.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Notifier runat="server" ID="Notifier"/>
    <div class="container">
        <h1>Your beers</h1>
        <asp:ListView ID="ReviewsListView" runat="server"
                      ItemType="RememBeer.Models.BeerReview"
                      SelectMethod="Select"
                      UpdateMethod="UpdateReview"
                      DataKeyNames="BeerId, CreatedAt, Id, IsDeleted, IsPublic, ModifiedAt, UserId">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                <div class="text-center">
                    <asp:DataPager runat="server" PagedControlID="ReviewsListView" PageSize="10">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-success btn-xs"
                                                        ButtonType="Link"
                                                        ShowFirstPageButton="false"
                                                        ShowPreviousPageButton="true"
                                                        ShowNextPageButton="false"/>

                            <asp:NumericPagerField ButtonType="Link"
                                                   CurrentPageLabelCssClass="btn btn-primary btn-xs"
                                                   NumericButtonCssClass="btn btn-success btn-xs"/>
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-success btn-xs"
                                                        ButtonType="Link"
                                                        ShowNextPageButton="true"
                                                        ShowLastPageButton="false"
                                                        ShowPreviousPageButton="false"/>
                        </Fields>
                    </asp:DataPager>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="container">
                    <div class="well">
                        <div class="media">
                            <div class="col-lg-3 pull-left">
                                <img class="pull-left media-object" src="http://lorempixel.com/200/200/">
                                <br/>
                                <asp:Button runat="server" CssClass="btn btn-warning pull-left" ID="EditButton" CommandName="Edit" Text="Edit"/>
                            </div>
                            <div class="col-lg-9">
                                <h3 class="media-heading">
                                    <%#: Item.Beer.Name %> <span><em>@<%#:Item.Place %></em></span></h3>
                                <h5 class="media-heading"><%#: Item.Beer.Brewery.Name %></h5>
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
                <div class="form">
                    <div class="form-group">
                        <label>Description</label>
                        <asp:TextBox runat="server"
                                     ID="TbDescription"
                                     CssClass="form-control"
                                     TextMode="MultiLine"
                                     Rows="6"
                                     Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Place</label>
                        <asp:TextBox runat="server"
                                     ID="TbPlace"
                                     Text='<%#Bind("Place") %>'
                                     CssClass="form-control">
                        </asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Overall Score</label>
                        <uc:BeerRatingSelect ID="OverallSelect" runat="server" SelectedValue='<%#:Bind("Overall") %>'>
                        </uc:BeerRatingSelect>
                    </div>
                    <div class="form-group">
                        <label>Looks</label>
                        <uc:BeerRatingSelect ID="LookSelect" runat="server" SelectedValue='<%#:Bind("Look") %>'>
                        </uc:BeerRatingSelect>
                    </div>
                    <div class="form-group">
                        <label>Taste</label>
                        <uc:BeerRatingSelect ID="TasteSelect" runat="server" SelectedValue='<%#:Bind("Taste") %>'>
                        </uc:BeerRatingSelect>
                    </div>
                    <div class="form-group">
                        <label>Aroma</label>
                        <uc:BeerRatingSelect ID="SmellSelect" runat="server" SelectedValue='<%#:Bind("Smell") %>'>
                        </uc:BeerRatingSelect>
                    </div>
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="btn btn-success" CommandName="Update" Text="Save"/>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>