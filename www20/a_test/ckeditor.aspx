<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="ckeditor.aspx.cs" Inherits="testudines.a_test.WebForm3" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRight" runat="server">
    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server">
</CKEditor:CKEditorControl>
</asp:Content>

