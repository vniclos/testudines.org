<%@ page title="Home Page" language="C#" masterpagefile="~/Mpg_Site.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="testudines._Default" enablesessionstate="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12 col-md-6">
            <asp:Literal ID="scnBox11" Text="scnBox11" runat="server"></asp:Literal>
            <asp:Literal ID="scnBox12" Text="scnBox12" runat="server"></asp:Literal>
        </div>
  <hr />
        <div class="col-12 col-md-6">
            <asp:Literal ID="scnBox21" Text="scnBox21" runat="server"></asp:Literal>
            <asp:Literal ID="scnBox22" Text="scnBox22" runat="server"></asp:Literal>
        </div>
    </div>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentRight" runat="server">
    
      <h2><asp:Literal runat ="server" ID="scnTitle" Text="<%$ Resources:Strings, tortoise_datasheet %>"></asp:Literal></h2>
    
   
    <input id="BtnTree" type="button" class="btn-tiny" onclick ="FncLoadAjax('scnDivListTree', '/a_cache/Tortoise_TreeULView.html');" value="tree" />
    <input id="BtnList" type="button" class="btn-tiny" onclick ="FncLoadAjax('scnDivListTree', '/a_cache/Tortoise_List_DL.html');" value="list" />

    <div id="scnDivListTree">
            
   
            
            <asp:Literal ID="scnBoxRight" Text="scnBoxRight" runat="server" ClientIDMode="Static"></asp:Literal>   
         </div>
   
</asp:Content>





