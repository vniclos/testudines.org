<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_imggallnk.ascx.cs" Inherits="testudines.a_ctl.ctl_imggallnk" %>
<asp:Label ID="scnLinkGalleryTit" CssClass="fieldtitall_inline" runat="server" Text ="Select Gallery"></asp:Label>
<asp:TextBox ID="scnAGalleryTxt"  runat="server"  ViewStateMode="Enabled" ClientIDMode="Static"></asp:TextBox>
<asp:Button ID="scnIDImgBtnOpen" CssClass ="aspButton" style="display:inline; "  runat="server" Text="+"  />
<asp:Button ID="scnIDImgBtnClear" CssClass ="aspButton" 
    style="display:inline; " runat="server" Text="X" 
    onclick="scnIDImgBtnClear_Click"  />
