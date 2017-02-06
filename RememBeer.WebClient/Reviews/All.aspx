<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All.aspx.cs" Inherits="RememBeer.WebClient.Reviews.All" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="BeerReviewRepeater">

    </asp:Repeater>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
</asp:Content>
