<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="pdf_bld_cites.aspx.cs" Inherits="testudines.a_cls.pdf.pdf_bld_cites" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="scnBtnBuildPdf" runat="server" Text="Build Pdf" OnClick="scnBtnBuildPdf_Click" /><br />
     <asp:Button ID="scnBtnCombine" runat="server" Text="Combine Cites, IUCN RL and doc files" OnClick="scnBtnCombine_Click" /><br />
     <asp:Label ID="scnDebugTitle" runat="server" Text="Debug"></asp:Label>
    <br />
     <asp:Label ID="scnDebug" Text="" runat="server"></asp:Label>
   <asp:Label ID="scnMsg" Text="" runat="server"></asp:Label> <hr />
<hr />
<asp:Literal ID="scnPdfEmbed" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
