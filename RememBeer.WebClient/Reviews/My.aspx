<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="RememBeer.WebClient.Reviews.My" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceholder" Visible="false">
        <div class="alert alert-dismissible alert-success">
            <button type="button" class="close" data-dismiss="alert">&times;</button>
            <asp:Label ID="SuccessMessage" runat="server" Text="asdkoasasldjaskldshkljashdjkashdkjashdjkashdasjklhda"></asp:Label>
        </div>
    </asp:PlaceHolder>
    <div class="container">
        <h1>Your beers</h1>
        <asp:ListView ID="ReviewsListView" runat="server"
                      ItemType="RememBeer.Models.BeerReview"
                      SelectMethod="Select"
                      UpdateMethod="UpdateReview"
            DataKeyNames="BeerId, CreatedAt, Id, IsDeleted, IsPublic, ModifiedAt, UserId">
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
                        <asp:DropDownList ID="OverallDropDown" CssClass="form-control" runat="server" SelectedValue='<%#Bind("Overall") %>'>
                            <Items>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Looks</label>
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server" SelectedValue='<%#Bind("Look") %>'>
                            <Items>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Taste</label>
                        <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" SelectedValue='<%#Bind("Taste") %>'>
                            <Items>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Aroma</label>
                        <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server" SelectedValue='<%#Bind("Smell") %>'>
                            <Items>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </div>


                    <div class="form-group">
                        <asp:Button runat="server" CssClass="form-control" CommandName="Update"/>
                    </div>
                </div>
            </EditItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>