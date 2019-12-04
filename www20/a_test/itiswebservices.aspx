<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="itiswebservices.aspx.cs" Inherits="testudines.a_test.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="scnBtnXmlAll" runat="server" onclick="scnBtnXmlAll_Click" 
            Text="xml all" />
    
    </div>
    <asp:Button ID="scnBtn" runat="server" onclick="scnBtn_Click" Text="Button" />
    <asp:Literal ID="scnLiteral" runat="server"></asp:Literal>
    </form>
</body>
</html>
