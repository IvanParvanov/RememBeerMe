<%@ Page Title="My Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>

<%@ Register TagPrefix="uc" TagName="BeerRatingSelect" Src="~/UserControls/BeerRatingSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="Notifier" Src="~/UserControls/UserNotifications.ascx" %>
<%@ Register TagPrefix="uc" TagName="BeerReview" Src="~/UserControls/SingleBeerReview.ascx" %>

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
                <uc:BeerReview runat="server" IsEdit="True" Review="<%# Item %>"/>
            </ItemTemplate>
            <EditItemTemplate>
                <div class="container">
                    <div class="well">
                        <div class="media">
                            <div class="col-lg-3 pull-left">
                                <img class="pull-left media-object" src="http://lorempixel.com/200/200/">
                                <br/>
                                <asp:Button runat="server" ID="SaveButton" CssClass="btn btn-success pull-left" CommandName="Update" Text="Save"/>
                            </div>
                            <div class="col-lg-9">
                                <h3 class="media-heading">
                                    <%#: Item.Beer.Name %> @
                                </h3>
                                <asp:TextBox runat="server"
                                             ID="TextBox1"
                                             Text='<%#Bind("Place") %>'
                                             CssClass="form-control">
                                </asp:TextBox>

                                <h5 class="media-heading"><%#: Item.Beer.Brewery.Name %></h5>
                                <h5 class="text-right"><%#: Item.CreatedAt.ToShortDateString() %></h5>
                                <h5 class="media-heading">Description: </h5>
                                <p>
                                    <asp:TextBox runat="server"
                                                 ID="TextBox2"
                                                 CssClass="form-control"
                                                 TextMode="MultiLine"
                                                 Rows="6"
                                                 Text='<%#Bind("Description") %>'>
                                    </asp:TextBox>
                                </p>
                                <h6>
                                    <em>Bottom line:</em>
                                </h6>
                                <ul class="list-inline">
                                    <li>
                                        Overall:
                                        <uc:BeerRatingSelect ID="BeerRatingSelect1" runat="server" SelectedValue='<%#:Bind("Overall") %>'>
                                        </uc:BeerRatingSelect>
                                    </li>
                                    <li>
                                        Taste:
                                        <uc:BeerRatingSelect ID="BeerRatingSelect3" runat="server" SelectedValue='<%#:Bind("Taste") %>'>
                                        </uc:BeerRatingSelect>
                                    </li>
                                    <li>
                                        Look:
                                        <uc:BeerRatingSelect ID="BeerRatingSelect2" runat="server" SelectedValue='<%#:Bind("Look") %>'>
                                        </uc:BeerRatingSelect>
                                    </li>
                                    <li>
                                        Aroma:
                                        <uc:BeerRatingSelect ID="BeerRatingSelect4" runat="server" SelectedValue='<%#:Bind("Smell") %>'>
                                        </uc:BeerRatingSelect>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>