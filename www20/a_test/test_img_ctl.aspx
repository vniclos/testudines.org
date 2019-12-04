<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="test_img_ctl.aspx.cs" Inherits="testudines.a_test.test_img_ctl" %>

<%@ register src="~/a_ctl/ctl_imgfld.ascx" tagprefix="uc2" tagname="ctl_imgfld" %>
<%@ register src="~/a_ctl/clt_scnAOth_UrlImages.ascx" tagprefix="uc1" tagname="clt_scnAOth_UrlImages" %>





<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
    <uc2:ctl_imgfld ID="ctl_imgfld3" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
        <uc1:clt_scnAOth_UrlImages runat="server" ID="scnAOth_UrlImages" />
         </div>
         <div class="row col-12" >
        <uc2:ctl_imgfld runat="server" ID="ctl_imgfld" ImageMax_Width="300px" Width="300px" />
        <uc2:ctl_imgfld runat="server" ID="ctl_imgfld1" ImageMax_Width="600px" Width="600px"/>
        <uc2:ctl_imgfld runat="server" ID="ctl_imgfld2" />

      
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
   
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
