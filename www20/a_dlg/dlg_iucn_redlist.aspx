<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dlg_iucn_redlist.aspx.cs" Inherits="testudines.a_dlg.dlg_iucn_redlist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="/Content/Site.css" rel="stylesheet" />
    <title>IUCN Red List criteria help</title>
     <style type="text/css">
        body, html, form, .fancybox.iframe
        {
            max-width:400px;
            height: auto;
            overflow: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel class="dlgMsgRound" runat="server" ID="sncPnlMsg" Visible="true">
  
      
        <input id="btnClose" type="button" class="xClose" onclick="javascript: parent.jQuery.fancybox.getInstance().close();" value="X" /> 
   <asp:Literal ID="scnHtml" Text ="fill on load" runat="server"></asp:Literal>
    </asp:Panel>
    </form>
</body>
</html>
