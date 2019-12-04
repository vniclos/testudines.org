<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KeepSessionAlive.aspx.cs" Inherits="testudines.KeepSessionAlive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta id="MetaRefresh" http-equiv="refresh" content="21600;url=/KeepSessionAlive.aspx" runat="server" />
<script >
   window.status = "<%=WindowStatusText%>";
</script>
</head>
<body>
    
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:updatepanel id="uptpanelkeepalive" runat="server">
           <ContentTemplate>
        <asp:Literal ID="scnKeepAlive" runat="server" Text=""></asp:Literal>
               </ContentTemplate>
            </asp:updatepanel>
        
    </form>
</body>
</html>
