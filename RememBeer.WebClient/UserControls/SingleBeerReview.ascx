<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleBeerReview.ascx.cs" Inherits="RememBeer.WebClient.UserControls.SingleBeerReview" %>
<div class="container">
    <div class="well">
        <div class="media">
            <div class="col-lg-3 pull-left">
                <img class="pull-left media-object" src="http://lorempixel.com/200/200/">
                <br/>
            </div>
            <div class="col-lg-9">
                <h3 class="media-heading">
                    <%#: Review.Beer.Name %> <span><em>@<%#:Review.Place %></em></span></h3>
                <h5 class="media-heading"><%#: Review.Beer.Brewery.Name %></h5>
                <h5 class="text-right"><%#: Review.CreatedAt.ToShortDateString() %></h5>
                <p><%#: Review.Description %></p>
                <h6>
                    <em>Bottom line:</em>
                </h6>
                <ul class="list-inline">
                    <li>
                        Overall:
                        <span class="badge"><%#: Review.Overall %></span>
                    </li>
                    <li>|</li>
                    <li>
                        Taste:
                        <span class="badge"><%#: Review.Taste %></span>
                    </li>
                    <li>|</li>
                    <li>
                        Look:
                        <span class="badge"><%#: Review.Look %></span>
                    </li>
                    <li>|</li>
                    <li>
                        Aroma:
                        <span class="badge"><%#: Review.Smell %></span>
                    </li>
                </ul>
                <asp:Button runat="server" CssClass="btn btn-warning" ID="EditButton" CommandName="Edit" Text="Edit" Visible="False"/>
                <asp:PlaceHolder runat="server" ID="DeletePlaceholder" Visible="False">
                    <a type="button" class="btn btn-danger" data-toggle="modal" data-target="#confirm">Delete</a>
                    <div id="confirm" class="modal fade" role="dialog">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Delete review</h4>
                                </div>
                                <div class="modal-body">
                                    <p>Are you sure you want to delete this review?</p>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" CssClass="btn btn-danger pull-left" ID="DeleteButton" CommandName="Delete" Text="Delete"/>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</div>