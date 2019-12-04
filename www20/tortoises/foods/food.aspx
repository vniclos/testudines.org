<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="food.aspx.cs" Inherits="testudines.tortoises.foods.food" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentTop" ContentPlaceHolderID="MainContent_Top" runat="server">

    <asp:Label ID="scnPanelTop" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <asp:Literal ID="scnButtonBar" runat="server" Text=""></asp:Literal>
    <asp:Label ID="scnPanelLeft" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRight" runat="server">
    <asp:Label ID="scnPanelRightLastDocs" runat="server" Text="Label"></asp:Label>
</asp:Content>
