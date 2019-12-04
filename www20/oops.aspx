<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="oops.aspx.cs" Inherits="testudines.oops" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pannel">
    <h1>Opps</h1>
    <p>Excuseme!, This page is not accesible</p>
        </div>
    <p>Referer:&nbsp;<asp:Literal ID="scnUrlReferer" runat="server"></asp:Literal></p>
    <p>Your Petition:&nbsp;<asp:Literal ID="scnUrlPetition" runat="server"></asp:Literal> </p>
    <p>Your Ip address:&nbsp;<asp:Literal ID="scnIpFrom" runat="server"></asp:Literal></p>
     <p>Your Id:&nbsp;<asp:Literal ID="scnYouName" runat="server"></asp:Literal></p>
   <p>Probably cause:&nbsp;<asp:Literal ID="scnMsg" runat="server"></asp:Literal></p>
    <p>Request Context:&nbsp;<asp:Literal ID="scnRequestContext" runat="server"></asp:Literal></p>
    <p>Browser:&nbsp;<asp:Literal ID="scnBrowser" runat="server"></asp:Literal></p>
    
    

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
     <h4>May be</h4>
    <ul>
        <li>You not are authized</li>
        <li>The page was deleted</li>
        <li>Or error not contolated</li>
    </ul>
</asp:Content>
