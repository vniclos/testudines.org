<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dlgLinkGallery_brw.aspx.cs"  Theme ="no" Inherits="testudines.ckeditor.dlgLinkGallery_brw" Debug="true" EnableSessionState="True" %>


<%@ Register assembly="Telerik.QuickStart" namespace="Telerik.QuickStart" tagprefix="cc1" %>
<%@ Register assembly="RadTreeView.Net2" namespace="Telerik.WebControls" tagprefix="radT" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server"><title>Image Manager</title>
<style type="text/css">
		body { background-color: #aaa;width:1024px;  height :800px;}
		form { width:1024px;  height :800px;}
		
		h1 { padding: 15px; margin: 0px;  font-family:Arial; font-size: 14pt; color: #737357; }
	   .aspTextBox   {font-size:3.2mm;  max-height:6em; max-width:300px; line-height:1em ;}
	
	</style>
	  <!-- <link type="text/css" href="/a_js/css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
     <script src="/a_js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
  
 <script src="/js/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
      <script src="/js/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
     -->
    <script type="text/javascript">
    
        $(function() {
            $("#txtDate").datepicker();
        });
	
	</script>
	
<script type="text/javascript"  language="javascript">

function FncDone_novale()
 {

    //devuleve los parametros al formulario anterior
        var MyArgs = new Array();
        MyArgs[0] = document.getElementById('scnFolderSelected').value;
        MyArgs[1] = document.getElementById('scnFolderSelected').value;
        window.returnValue = MyArgs;
        window.close();
        return true;
}
function FncDone() {
   
 
    var value = document.getElementById("scnFolderSelected").value
    if (window.opener != null && !window.opener.closed) {
       
        window.opener.document.getElementById("scnAUrlImagesTxt").value = value;
    

    }
    window.top.opener.focus();
    window.close();
}

</script>
	</head>
	<body>	   
	<form id="form1" runat="server">
	
<div id ="divManager" style =" background-color:#F1F1E3; text-align :left ; width:580px;  " >


<span style ="font-family:Arial; font-size: 14pt; color: #737357;">
   
<asp:Label ID="scnMediaAlbun" runat="server" Text="<b>Image Album:</b>"></asp:Label></span> 
<asp:DropDownList ID="scnAlbumDirectoryList" runat="server" 
        Style="width: 160px;" AutoPostBack="true" 
        onselectedindexchanged="scnAlbumDirectoryList_SelectedIndexChanged" />
					<asp:HiddenField ID="scnNewAlbumName" runat="server" />


<div id="divtree"  style ="float:none; padding :3px;   height:530px; overflow:auto ;  border:2px solid #333; "  >
    <span style=" margin:1px; border-bottom:2px; border-bottom-style:solid; border-color:#666; color: #737357; " >
        <asp:Label ID="scnLblFolder" runat="server" Text="Folders"></asp:Label>
    </span>
    <span class="align_right"> 
<button onclick="FncDone()" class="aspButton" type="button">Return</button>
   
    &nbsp;<asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClientClick="window.top.close(); window.top.opener.focus();"  />
    </span>
  
<asp:TextBox ID="scnFolderSelected" runat ="server" Text ="scnFolderSelected" Width="100%"></asp:TextBox>  
 	<hr style="background-color:#dedede;  padding:2px; height: 1px !important;" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <radT:RadTreeView ID="scnTreeView" runat="server" Height="470px"  onnodeclick="scnTreeView_NodeClick" AutoPostBack="True"></radT:RadTreeView>


</div>
</div>
</form>
</body>
</html>

