<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="groups-list.aspx.cs" Inherits="testudines.tortoises.groups.groups_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row_airboth"> 
    <asp:HiddenField ID="scnDocId" runat="server" />
    
    <asp:HiddenField ID="scnDocLngId" runat="server" />
  
         <h1 class="title"><asp:Literal ID="scnTitle"  runat="server" Text=" titulo"></asp:Literal>   </h1>
     <asp:Literal ID="scnLnk" runat="server" Text =""></asp:Literal>
    
     <asp:Literal ID="scnHtml" runat="server" Text =""></asp:Literal>
    
    <b>Referencias:</b>
      
    <ul>
    <li>
       
    Turtle Taxonomy Working Group [van Dijk, P. P., J. Iverson, A. Rhodin, H. Shaffer, and R. Bour]. 2014. Turtles of the World, 7th Edition: Annotated Checklist of Taxonomy, Synonymy, Distribution with maps, and Conservation Status. Chelonian Research Monographs, no. 5, v. 7. 329-479.
    <br /> <a href="http://www.itis.gov/servlet/SingleRpt/RefRpt?search_type=publication&search_id=pub_id&search_id_value=11628"> 
        <img src="../a_img/a_lnks/www_ITIS.jpg" title="ITIS database"/> </a>
     </li>
     <li>
        Peter Uetz. Reptile database< <a href="http://www.reptile-database.org/db-info/taxa.html"><img src="../a_img/a_lnks/www_repddbb.gif" /> /a></li>
     
     </ul>
  
   
      </div> 
     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
