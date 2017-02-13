<%@ Page Title="Brewery Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Brewery.aspx.cs" Inherits="RememBeer.WebClient.Admin.Brewery" %>
<%@ Import Namespace="RememBeer.WebClient.Utils" %>
<%@ Register tagPrefix="uc" tagName="Notifier" src="../UserControls/UserNotifications.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:Notifier runat="server" ID="Notifier"/>
    <div class="container">
        <div class="col-md-6 col-md-offset-3">
            <asp:DetailsView runat="server"
                             ID="BreweryDetails"
                             AutoGenerateEditButton="True"
                             AutoGenerateRows="False"
                             OnModeChanging="BreweryDetails_OnModeChanging"
                             OnItemUpdating="BreweryDetails_OnItemUpdating"
                             ItemType="RememBeer.Models.Contracts.IBrewery"
                             CssClass="table table-responsive table-bordered table-striped table-hover table-condensed">
                <Fields>
                    <asp:TemplateField HeaderText="Id" AccessibleHeaderText="Id">
                        <ItemTemplate>
                            <asp:Label ID="LabelId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="LabelId" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" AccessibleHeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="LabelName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="NameTb" CssClass="form-control" Text='<%# Bind("Name") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server"
                                                        CssClass="text-danger"
                                                        Display="Dynamic"
                                                        ErrorMessage="Name is required"
                                                        ControlToValidate="NameTb">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server"
                                                            Display="Dynamic"
                                                            ValidationExpression="^[\s\S]{1,512}$"
                                                            ControlToValidate="NameTb"
                                                            CssClass="text-danger"
                                                            ErrorMessage="Name must be between 1 and 512 characters long">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country" AccessibleHeaderText="Country">
                        <ItemTemplate>
                            <asp:Label ID="LabelCountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="CountryTb" CssClass="form-control" Text='<%# Bind("Country") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server"
                                                        CssClass="text-danger"
                                                        Display="Dynamic"
                                                        ErrorMessage="Country is required"
                                                        ControlToValidate="CountryTb">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server"
                                                            Display="Dynamic"
                                                            ValidationExpression="^[\s\S]{1,128}$"
                                                            ControlToValidate="CountryTb"
                                                            CssClass="text-danger"
                                                            ErrorMessage="Country must be between 1 and 128 characters long">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" AccessibleHeaderText="Description">
                        <ItemTemplate>
                            <asp:Label ID="LabelDescr" runat="server" Text='<%# this.Eval("Description").ToString().Truncate(200) %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox runat="server" ID="DescrTb" CssClass="form-control" TextMode="MultiLine" Rows="3" Text='<%# Bind("Description") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server"
                                                        CssClass="text-danger"
                                                        Display="Dynamic"
                                                        ErrorMessage="Description is required"
                                                        ControlToValidate="DescrTb">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server"
                                                            Display="Dynamic"
                                                            ValidationExpression="^[\s\S]{1,2048}$"
                                                            ControlToValidate="DescrTb"
                                                            CssClass="text-danger"
                                                            ErrorMessage="Description must be between 1 and 2048 characters long">
                            </asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </div>
    </div>
</asp:Content>