<%@ Page Title="My Beers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>

<%@ Register TagPrefix="uc" TagName="BeerRatingSelect" Src="~/UserControls/BeerRatingSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="Notifier" Src="~/UserControls/UserNotifications.ascx" %>
<%@ Register TagPrefix="uc" TagName="BeerReview" Src="~/UserControls/SingleBeerReview.ascx" %>
<%@ Register TagPrefix="uc" Namespace="RememBeer.WebClient.UserControls" Assembly="RememBeer.WebClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <uc:Notifier runat="server" ID="Notifier"/>
    </ContentTemplate>
</asp:UpdatePanel>
<div class="container">

<asp:ListView ID="ReviewsListView" runat="server"
              InsertItemPosition="FirstItem"
              ItemType="RememBeer.Models.BeerReview"
              SelectMethod="Select"
              UpdateMethod="UpdateReview"
              InsertMethod="InsertReview"
              DeleteMethod="DeleteReview"
              DataKeyNames="BeerId, CreatedAt, Id, IsDeleted, IsPublic, ModifiedAt, UserId">
<LayoutTemplate>
    <asp:UpdatePanel runat="server" ID="UpdatePanel">
        <ContentTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            <div class="text-center">
                <asp:DataPager runat="server" PagedControlID="ReviewsListView" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-inverse btn-xs"
                                                    ButtonType="Link"
                                                    ShowFirstPageButton="false"
                                                    ShowPreviousPageButton="true"
                                                    ShowNextPageButton="false"/>
                        <asp:NumericPagerField ButtonType="Link"
                                               CurrentPageLabelCssClass="btn btn-primary btn-xs"
                                               NumericButtonCssClass="btn btn-inverse btn-xs"/>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-inverse btn-xs"
                                                    ButtonType="Link"
                                                    ShowNextPageButton="true"
                                                    ShowLastPageButton="false"
                                                    ShowPreviousPageButton="false"/>
                    </Fields>
                </asp:DataPager>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                </div>
                <div class="col-lg-9">
                    <h3 class="media-heading">
                        <%#: Item.Beer.Name %> @
                    </h3>
                    <asp:TextBox runat="server"
                                 ID="TextBox1"
                                 ValidationGroup="Edit"
                                 Text='<%#Bind("Place") %>'
                                 CssClass="form-control">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator runat="server"
                                                ControlToValidate="TextBox1"
                                                CssClass="text-danger"
                                                Display="Dynamic"
                                                ValidationGroup="Edit"
                                                ErrorMessage="Place is required">
                    </asp:RequiredFieldValidator>

                    <h5 class="media-heading"><%#: Item.Beer.Brewery.Name %></h5>
                    <h5 class="text-right"><%#: Item.CreatedAt.ToShortDateString() %></h5>
                    <h5 class="media-heading">Description: </h5>
                    <p>
                        <asp:TextBox runat="server"
                                     ID="TextBox2"
                                     CssClass="form-control"
                                     TextMode="MultiLine"
                                     ValidationGroup="Edit"
                                     Rows="6"
                                     Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                                                    ControlToValidate="TextBox2"
                                                    CssClass="text-danger"
                                                Display="Dynamic"

                                                    ValidationGroup="Edit"
                                                    ErrorMessage="Place is required">
                        </asp:RequiredFieldValidator>
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
                    <asp:Button runat="server" ID="SaveButton" ValidationGroup="Edit" CssClass="btn btn-success" CommandName="Update" Text="Save"/>
                    <asp:Button runat="server" ID="CancelButton" CssClass="btn btn-warning" CommandName="Cancel" Text="Cancel"/>
                </div>
            </div>
        </div>
    </div>
</EditItemTemplate>
<InsertItemTemplate>
    <div class="text-center spaced">
        <a type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#createNew">Create new</a>
    </div>
    <div id="createNew" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Create a new review</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBox4" Text="Beer: "></asp:Label>
                        <asp:TextBox runat="server"
                                     ID="TextBox4"
                                     ValidationGroup="Create"
                                     Text=''
                                     ClientIDMode="Predictable"
                                     CssClass="form-control">
                        </asp:TextBox>
                        <uc:ValidatedHiddenField
                            runat="server"
                            ID="HiddenBeerId"
                            ClientIDMode="Predictable"
                            Value='<%#Bind("BeerId") %>'>
                        </uc:ValidatedHiddenField>
                        <asp:RequiredFieldValidator runat="server"
                                                    ControlToValidate="HiddenBeerId"
                                                    CssClass="text-danger"
                                                Display="Dynamic"

                                                    ValidationGroup="Create"
                                                    ErrorMessage="Please select a beer from the dropdown">
                        </asp:RequiredFieldValidator>
                    </div>
                    <script src="/Scripts/devbridge-autocomplete.min.js"></script>
                    <script src="/Scripts/autocomplete.js"></script>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBox3" Text="Place: "></asp:Label>
                        <asp:TextBox runat="server"
                                     ID="TextBox3"
                                     ValidationGroup="Create"
                                     Text='<%#Bind("Place") %>'
                                     CssClass="form-control">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                                                    ControlToValidate="TextBox3"
                                                    CssClass="text-danger"
                                                Display="Dynamic"

                                                    ValidationGroup="Create"
                                                    ErrorMessage="Place is required">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="TextBox2" Text="Description: "></asp:Label>
                        <asp:TextBox runat="server"
                                     ID="TextBox2"
                                     CssClass="form-control"
                                     ValidationGroup="Create"
                                     TextMode="MultiLine"
                                     Rows="6"
                                     Text='<%#Bind("Description") %>'>
                        </asp:TextBox>
                        <asp:RequiredFieldValidator runat="server"
                                                    ValidationGroup="Create"
                                                    ControlToValidate="TextBox2"
                                                Display="Dynamic"

                                                    CssClass="text-danger"
                                                    ErrorMessage="Description is required">
                        </asp:RequiredFieldValidator>
                    </div>
                    <ul class="list-inline">
                        <li>
                            <label>
                                Overall:
                                <uc:BeerRatingSelect ID="BeerRatingSelect5" runat="server" SelectedValue='<%#:Bind("Overall") %>'>
                                </uc:BeerRatingSelect>
                            </label>
                        </li>
                        <li>
                            <label>
                                Taste:
                                <uc:BeerRatingSelect ID="BeerRatingSelect6" runat="server" SelectedValue='<%#:Bind("Taste") %>'>
                                </uc:BeerRatingSelect>
                            </label>
                        </li>
                        <li>
                            <label>
                                Look:
                                <uc:BeerRatingSelect ID="BeerRatingSelect7" runat="server" SelectedValue='<%#:Bind("Look") %>'>
                                </uc:BeerRatingSelect>
                            </label>
                        </li>
                        <li>
                            <label>
                                Aroma:
                                <uc:BeerRatingSelect ID="BeerRatingSelect8" runat="server" SelectedValue='<%#:Bind("Smell") %>'>
                                </uc:BeerRatingSelect>
                            </label>
                        </li>
                    </ul>
                    <div class="form-group">
                        <asp:Label runat="server"
                                   AssociatedControlID="IsPublicCheckBox"
                                   Text="Public: ">
                        </asp:Label>
                        <asp:CheckBox runat="server"
                                      ID="IsPublicCheckBox"
                                      Checked='<%# Bind("IsPublic") %>'/>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ImageUpload" Text="Image :">
                        </asp:Label>
                        <asp:FileUpload runat="server"
                                        ID="ImageUpload"
                                        CssClass="form-control-static"
                                        AllowMultiple="False"/>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server"
                                CssClass="btn btn-success pull-left"
                                ID="InsertButton"
                                CommandName="Insert"
                                ValidationGroup="Create"
                                Text="Save"/>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</InsertItemTemplate>
</asp:ListView>

</div>
</asp:Content>