<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="control-tdoc1.aspx.cs" Inherits="testudines.a_test.control_tdoc1" %>
<%@ Register src="../a_ctl/ctl_doc_edit.ascx" tagname="ctl_doc_edit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    sss<uc1:ctl_doc_edit ID="ctl_doc_edit1" runat="server" />
&nbsp;
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
