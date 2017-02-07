<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleBeerReview.ascx.cs" Inherits="RememBeer.WebClient.UserControls.SingleBeerReview" %>

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
                    <%#: Review.Beer.Name %> <span><em>@<%#:Review.Place %></em></span></h3>
                <h5 class="media-heading"><%#: Review.Beer.Brewery.Name %></h5>
                <h5 class="text-right"><%#: Review.CreatedAt.ToShortDateString() %></h5>
                <p><%#: Review.Description %>.</p>
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
            </div>
        </div>
    </div>
</div>