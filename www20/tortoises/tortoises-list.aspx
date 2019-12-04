<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="tortoises-list.aspx.cs" Inherits="testudines.tortoises.tortoises_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<!-- ------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------- -->
<!-- ------------------------------------------------------------------------- -->
    <h1><asp:Literal ID="scnPageTitle" Text="Page title" runat="server"></asp:Literal></h1>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="pannel">
            <asp:TextBox ID="sncSearch" type="text" CssClass="search-text" placeholder="<%$ Resources:Strings, SearchTortoise %>"  runat="server" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:Button ID="scnSearchBtn" type="button" CssClass="btn btn-primary btn-xs search-btn"  runat="server" Text="<%$ Resources:Strings, Search %>" OnClick="scnBtnSearch_Click" />
            <div class="scnSearcHelp"><asp:Label ID="scnSearcHelp2" CssClass="text-mini" runat ="server" Text=" <%$ Resources:Strings,SearchTortoiseHelp %>" ClientIDMode="Static"> </asp:Label></div>
           
        </div>
    <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="DocId,DocLngId" 
        PageSize="5" Width ="100%"  PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom" PagerSettings-PageButtonCount="10"  PagerSettings-Visible="True"  pagination-CssClass="pagination" PagerStyle-HorizontalAlign="Center" PagerStyle-BorderStyle="None" PagerStyle-BorderWidth="1" AlternatingRowStyle-BorderStyle="None" PagerStyle-CssClass="pagination-ys" GridLines="None" AlternatingRowStyle-BackColor="#EEEEEE" BorderStyle="None" HeaderStyle-CssClass="hide" OnPageIndexChanging="scnGridView_PageIndexChanging">
        <Columns>
       <asp:TemplateField>
       <ItemTemplate >
       <h1>
           <asp:Image ID="imgFlag" CssClass ="imgleft "  runat="server" ToolTip ="" ImageUrl ='<%# "/a_img/a_site/ico16/flag16_"+Eval("doclngid")+ ".gif"  %>'></asp:Image>
       <asp:Label ID="scnTitItem" runat="server" text='<%# "<a href=\""+ Eval("url")+"\">"+  Eval("Title") +"</a>"%>'> </asp:Label>
       
           <br /><asp:Literal ID="scnTitSubItem" runat="server" text='<%# "<span style=\"font-size:0.65rem;\">  "+ Eval("titlesub")%>'> </asp:Literal></span></h1>
       <span class ="h2_titlesub"/><asp:Literal ID="Literal1" runat="server" text='<%# "Subord.:  "+ Eval("suborder")+" Fam.:"+Eval("family") %>'> </asp:Literal></span>

       <asp:Literal ID="scnTitVulgar" runat="server" text='<%# "<h5>"+ Eval("ATaxNameVulgarES")+", ("+ Eval("ATaxNameVulgarEN") + "[en])</h5>"%>'> </asp:Literal>
       <asp:Literal ID="sncLink" runat="server" text='<%#"<a href=\"/"+ Eval("doclngid")+"/tortoises/"+Eval("docid")+"\">"   %>'> </asp:Literal>
      
 <asp:Image ID="Thumbnail" CssClass ="imgleft"  style="max-width:200px; max-height:200px;"   runat="server" ToolTip =""  ImageUrl ='<%#  Bind("DocImgThumbnail") %>'></asp:Image></a>
       <br/><asp:Label ID="Label4" CssClass ="text3m" runat="server" text='<%#"<b>"+ Resources.Strings.Abstract+"</b>" %>'></asp:Label>
       
       
       <br /><asp:Label ID="Label2" CssClass ="align_text_left " runat="server" text='<%#   Eval("abstract") %>'> </asp:Label>
       
       
       <span class="right">
       <br /><asp:Label ID="lblReadMore" runat="server" CssClass ="readmore"  text='<%#"<a href=\""+ Eval("url")+"\">"+Resources.Strings.readmore+"</a>"   %>' />  
       <br /><asp:Label ID="lblDocStdVisitCount" CssClass ="text3m" runat="server" text='<%# Resources.Strings.readed +"&nbsp;" +( Eval("DocStdVisitCount")) %>'></asp:Label>

           
       <br/><asp:Label ID="lblDocUpdated" CssClass ="text3m" runat="server" text='<%# Resources.Strings.Updated+": "+ Eval("DocDateUpdate")%>'></asp:Label>
       </span>
       </ItemTemplate>
       
      
       </asp:TemplateField>
        
         
        </Columns>
    </asp:GridView>
        </ContentTemplate></asp:UpdatePanel>

     </asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
      <asp:Literal ID="scnMainRight"  Text="scnMainRight" runat="server"></asp:Literal>
    <input id="BtnTree" type="button" class="btn btn-primary btn-xs" onclick ="FncLoadAjax('scnMainRightList2', '/a_cache/Tortoise_TreeULView.html');" value="tree" />
    <input id="BtnList" type="button" class="btn btn-primary btn-xs" onclick ="FncLoadAjax('scnMainRightList2', '/a_cache/Tortoise_List_DL_TT.html');" value="list" />
    
<asp:Label ID="scnMainRightList2"  Text="scnMainRight" runat="server" ClientIDMode="Static"></asp:Label>
</asp:Content>
