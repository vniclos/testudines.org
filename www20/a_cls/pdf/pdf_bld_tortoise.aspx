<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="pdf_bld_tortoise.aspx.cs" Inherits="testudines.a_cls.pdf.pdf_bld_tortoise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
    top
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="scnSpecieIdTit" runat="server" Text="Id Specie"></asp:Label><asp:TextBox value="1" ID="scnSpecieId" runat="server" MaxLength="6" Rows="6" TextMode="Number"></asp:TextBox>
    <asp:Button ID="scnBtnBuildPdf" runat="server" Text="Build Pdf" OnClick="scnBtnBuildPdf_Click" /><br />
   

    <hr />
    <br />
   
    <asp:Label ID="scnDebugTitle" runat="server" Text="Debug"></asp:Label>
    <br />
     <asp:Label ID="scnDebug" Text="" runat="server"></asp:Label>
   <asp:Label ID="scnMsg" Text="" runat="server"></asp:Label>
&nbsp;
    <hr />
<hr />
<asp:Literal ID="scnPdfEmbed" runat="server" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
    MainContentAdmin
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
    MainContentRight
</asp:Content>
