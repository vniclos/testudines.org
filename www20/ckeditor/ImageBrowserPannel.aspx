<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageBrowserPannel.aspx.cs" Theme="no"  Inherits="testudines.ckeditor.ImageBrowserPannel" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .handle {
            width: 8px;
            height: 600px;            
            background:steelblue repeat;
                cursor:col-resize;        
        }
    </style>
    <script type="text/javascript">
        function ResizeSplit(sender, eventargs) {
        }
   
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </cc1:ToolkitScriptManager>
        <div>
            <table id="tblRCExtContainer">
                <tbody>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" BorderWidth="2" BorderColor="black" runat="server" Width="300px"
                                Height="600px">
                                <asp:Calendar ID="Calendar1" BackColor="green" runat="server"></asp:Calendar>
                            </asp:Panel>
                            <cc1:ResizableControlExtender ID="extRCE1" TargetControlID="Panel1" runat="server"
                                MinimumWidth="0" MaximumWidth="930" MinimumHeight="600" MaximumHeight="600" HandleOffsetX="8"
                                HandleOffsetY="0" HandleCssClass="handle" OnClientResizing="ResizeSplit">
                            </cc1:ResizableControlExtender>
                        </td>
                        <td>
                            <asp:Panel BackColor="white" ID="Panel2" BorderWidth="2" BorderColor="black" runat="server"
                                Width="680px" Height="600px">
                           
                            </asp:Panel>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>