<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="ClsGalleryFancybox.aspx.cs" Inherits="testudines.a_test.fancybox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <a href="img/img_001_Med.jpg" data-fancybox="group" data-caption="My caption"> <img src="img/img_001_Min.jpg" alt="" /></a>
    <a href="img/img_002_Med.jpg" data-fancybox="group" data-caption="My caption"> <img src="img/img_002_Min.jpg" alt="" /></a>
    <a href="img/img_003_Med.jpg" data-fancybox="group" data-caption="My caption"> <img src="img/img_003_Min.jpg" alt="" /></a>
    <hr />
    <asp:Label ID="scnGallery3" runat="server" Text="images fancybos fill on load"></asp:Label>
    <hr />
    <asp:Label ID="scnGallery6" runat="server" Text="images fancybos fill on load"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
