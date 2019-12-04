<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="tortoises-taxonomy-list.aspx.cs" Inherits="testudines.tortoises.tortoises_taxonomy_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style>.tree {max-height:none;}</style>
    <link href="/Content/bootstrap-tree.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Literal ID="scnPageTitle" Text="Page title" runat="server"></asp:Literal></h1>
    <asp:Literal ID="scnPageContent" runat="server" Text= "<%# Resources.Strings.mnTortoises_Taxa_TortoisesTaxonomy %>"></asp:Literal>

   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
    <asp:Literal ID="scnPageRight" runat="server" Text=""></asp:Literal>


       
</asp:Content>
