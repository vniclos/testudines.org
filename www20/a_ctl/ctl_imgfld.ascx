<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_imgfld.ascx.cs" Inherits="testudines.a_ctl.ctl_imgfld" %>
<span style="display:inline-block; max-width:600px;background-color:#efefef;  padding-right:1rem;"> 
<asp:Image ID="scnidimg" ImageUrl="/a_img/noimage600px.png" width="195" CssClass="ctl_imgfld"  runat="server" ClientIDMode="Static" />
<asp:HiddenField ID="scnidimgurl" runat="server" ClientIDMode="Static" />
<br /> <asp:Button ID="scnIDImgBtnOpen" CssClass ="button"  runat="server" Text="+"  />
<asp:Button ID="scnIDImgBtnOpenTaxon" CssClass ="button"  runat="server" Text="±"  />
<asp:Button ID="scnIDImgBtnClear" CssClass ="button" runat="server" Text="X"  />
 </span>