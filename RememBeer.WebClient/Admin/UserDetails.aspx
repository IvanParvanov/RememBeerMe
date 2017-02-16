<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="RememBeer.WebClient.Admin.UserDetails" %>
<%@ Register tagPrefix="uc" tagName="Notifier" src="../UserControls/UserNotifications.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Notifier runat="server" ID="Notifier" ViewStateMode="Disabled" ></uc:Notifier>
</asp:Content>
