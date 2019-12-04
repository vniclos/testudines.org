<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="clt_scnUrlGallery.ascx.cs" Inherits="testudines.a_ctl.clt_scnUrlGallery" %>
<asp:Label ID="scnLinkGalleryTit" CssClass="field-title-inline" runat="server" Text ="Select Gallery" Font-Bold="True"></asp:Label>
<asp:TextBox ID="scnAGalleryTxt"  runat="server"  ViewStateMode="Enabled" ClientIDMode="Static" Columns="100" ReadOnly="True" Rows="1"></asp:TextBox>
<asp:Button ID="scnIDImgBtnOpen" CssClass ="aspButton" style="display:inline; "  runat="server" Text="+"  />
<asp:Button ID="scnIDImgBtnClear" CssClass ="aspButton" 
    style="display:inline; " runat="server" Text="X" 
    onclick="scnIDImgBtnClear_Click"  />
