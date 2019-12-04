<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="tortoise.aspx.cs" Inherits="testudines.tortoises.tortoise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
     <asp:Literal ID="scnMainTop"  Text="scnMainTop" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Literal ID="scnButtonBar" Text="scnMain" runat="server"></asp:Literal>
    <asp:Literal ID="scnMain" Text="scnMain" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
    <h2><asp:Literal runat ="server" ID="scnTitle" Text="<%$ Resources:Strings, tortoise_datasheet %>"></asp:Literal></h2>
    
   
    <input id="BtnTree" type="button" class="btn-tiny" onclick ="FncLoadAjax('scnDivListTree', '/a_cache/Tortoise_TreeULView.html');" value="tree" />
    <input id="BtnList" type="button" class="btn-tiny" onclick ="FncLoadAjax('scnDivListTree', '/a_cache/Tortoise_List_DL.html');" value="list" />
<div id="scnDivListTree">     
      <asp:Literal ID="scnMainRight"  Text="scnMainRight" runat="server"></asp:Literal>
    </div>
     
  
  
</asp:Content>
