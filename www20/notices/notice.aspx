<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="notice.aspx.cs" Inherits="testudines.notices.notice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
     <asp:Literal ID="scnButtonBar" runat="server" Text=""></asp:Literal>
    <asp:Label ID="scnPanelTop" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="scnPanelLeft" runat="server" Text="Label"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
  
    <asp:Label ID="scnPanelRightLastDocs" runat="server" Text="Label"></asp:Label>
</asp:Content>
