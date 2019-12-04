<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site_Edit.Master" AutoEventWireup="true" CodeBehind="cache-mng.aspx.cs" Inherits="testudines.cache.cache_mng" %>

<%@ Register Assembly="Telerik.QuickStart" Namespace="Telerik.QuickStart" TagPrefix="cc1" %>
<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="radT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
  
    <script>
        function FncMsgWait (addmsg) {
          
            document.getElementById('scnLoading').style.display = "block"
            document.getElementById('scnMsg').innerHTML = 'Please Wait...Doing :' + addmsg;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
    <asp:Label ID="scnLoading" runat="server" CssClass="loading" Text="Loading&#8230;" style="display:none;" ClientIDMode="Static"></asp:Label>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentBtns" runat="server">
    <div class="row btn-group">
        <h2>Primro siempre el sitemap</h2>
                <asp:button ID="scnBtnSiteMap" runat="server" CssClass="btn btn-sm" Text="Sitemap"   OnClientClick="FncMsgWait('Sitemap');" OnClick="scnBtnSiteMap_Click"  />

                <asp:button ID="scnBtnSiteMap0" runat="server" CssClass="btn btn-sm" Text="Send sitemap to google"   OnClientClick="FncMsgWait('Sitemap sending');" OnClick="scnBtnSiteMap0_Click"   />

    </div>
    <div class="row btn-group-sm">
        <h2>Rebuild cache files</h2>
        <div class="row"><span style="background-color:darkgreen; color:white"> <asp:Label runat="server" ID="scnMsg" Text="Click on button for do chache files" ClientIDMode="Static"></asp:Label></span></div>
    <asp:Button ID="scnBtnNotices" runat="server" CssClass="btn btn-sm" Text="Notices"  OnClientClick="FncMsgWait('Notices');" OnClick="scnBtnNotices_Click" /> 
    <asp:Button ID="scnBtnArticles" runat="server"  CssClass="btn btn-sm" Text="Articles"  OnClientClick="FncMsgWait('Articles');" OnClick="scnBtnArticles_Click" />
     <asp:Button ID="scnBtnFoods" runat="server"  CssClass="btn btn-sm" Text="Foods"   OnClientClick="FncMsgWait('Foods');" OnClick="scnBtnFoods_Click" />
        <asp:Button ID="scnBtnOthers" runat="server"  CssClass="btn btn-sm" Text="others"   OnClientClick="FncMsgWait('Others');" OnClick="scnBtnOthers_Click"  />
        &nbsp;<asp:Button ID="scnBtnLast" runat="server"  CssClass="btn btn-sm" Text="Tortoise las updates"   OnClientClick="FncMsgWait('Tortoise las updates');" OnClick="scnBtnLast_Click"  />
        </div>
    <div class="row btn-group-sm"">
      
       <asp:Button ID="scnBtnTortoisesKeys" runat="server"  CssClass="btn btn-sm" Text="Tortoises Keys"   OnClientClick="FncMsgWait('Keys');" OnClick="scnBtnTortoisesKeys_Click" />
     <asp:Button ID="scnBtnTortoisesGroups" runat="server"  CssClass="btn btn-sm" Text="Tortoises groups"   OnClientClick="FncMsgWait('Groups');" OnClick="scnBtnTortoisesGroups_Click" />
      <asp:Button ID="scnBtnTortoisesAppendix" runat="server"  CssClass="btn btn-sm" Text="Tortoises Appendix"   OnClientClick="FncMsgWait('Appendixes');" OnClick="scnBtnTortoisesAppendix_Click" />
        </div>
    <div class="row btn-group-sm">
        <asp:Button ID="scnBtnMenus" runat="server"  CssClass="btn btn-sm" Text="Menus"   OnClientClick="FncMsgWait('Menus');" OnClick="scnBtnMenus_Click" />
        <asp:button ID="scnBtnAck" runat="server" CssClass="btn btn-sm" Text="Acknoelegment"   OnClientClick="FncMsgWait('Acknoelegments');" OnClick="scnBtnAck_Click" />
        <asp:button ID="scnBtnBibl" runat="server" CssClass="btn btn-sm" Text="Bibliography"   OnClientClick="FncMsgWait('Bibiography');" OnClick="scnBtnBibl_Click" />
        <asp:button id="scnBtnTaxonomy" runat="server" CssClass="btn btn-sm" Text="Taxonomy tree"   OnClientClick="FncMsgWait('Taxonomy');" OnClick="scnBtnTaxonomy_Click" />

        
        
&nbsp;<asp:button id="scnBtnTtreeDLDT" runat="server" CssClass="btn btn-sm" Text="Tortoises tree dl dt"   OnClientClick="FncMsgWait(' Tree DL DT');" OnClick="scnBtnTtreeDLDT_Click" />

        
        
</div>
    <div class="pannel">
        <h2>Cache images of tortoises</h2>
                <asp:DropDownList ID="scnDropDocId" runat="server" ></asp:DropDownList>
       
            <asp:Button ID="scnBtnTortoisesGallery" runat="server"  CssClass="btn btn-sm" Text="Tortoises images rebuild all"   OnClientClick="FncMsgWait();"  OnClick="scnBtnTortoisesGallery_Click" />
        <asp:Button ID="scnBtnTotoiseGalleryOnlyOne" runat="server" CssClass="btn btn-sm" Text= "Tortoise images rebuil only selected"   OnClientClick="FncMsgWait();" OnClick="scnBtnTotoiseGalleryOnlyOne_Click" />
         <br />
        <br />
      <asp:Button ID="scnBtnTortoises0" runat="server"  CssClass="btn btn-sm" Text="Tortoise rebuild selected and images selected"   OnClientClick="FncMsgWait('Build one tortoise');" OnClick="scnBtnTortoises0_Click" />
          <asp:Button ID="scnBtnTortoises" runat="server"  CssClass="btn btn-sm" Text="Tortoises rebuild all sheets"   OnClientClick="FncMsgWait('Tortoises');" OnClick="scnBtnTortoises_Click" />
    
         &nbsp;with docid nayor que <asp:TextBox ID="scnIdUpperThan" runat="server" Text="0"></asp:TextBox>

    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Literal ID="scnLog" runat="server"></asp:Literal>
    <asp:GridView ID="scnGridView" runat="server">
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContentRight" runat="server">
    
    <div id="divtree" class="column" style="padding: 0px; min-width: 260px; max-width: 100%; min-height: 400px; max-height: 800px; overflow: auto; border: 2px solid #333;">
        <radT:RadTreeView ID="scnTreeView" runat="server" Width="100%"
           AutoPostBack="false">
        </radT:RadTreeView>

    </div>
</asp:Content>
