﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageBrowser.aspx.cs" Inherits="testudines.ckeditor.ImageBrowser" Debug="true" EnableSessionState="True" Theme="no" StyleSheetTheme="no" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Telerik.QuickStart" namespace="Telerik.QuickStart" tagprefix="cc1" %>
<%@ Register assembly="RadTreeView.Net2" namespace="Telerik.WebControls" tagprefix="radT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server"><title>Image Manager</title>
<style type="text/css">
		body { background-color: #aaa;width:1024px;  height :400px;}
		form { width:1024px;  height :400px;}
		
		h1 { padding: 15px; margin: 0px;  font-family:Arial; font-size: 14pt; color: #737357; }
	   .aspTextBox   {font-size:3.2mm;  max-height:6em; max-width:300px; line-height:1em ;}
	
	</style>
	
     <script src="/a-js/jquery-ui-1.8.2.custom.min.js" type="text/javascript"></script>
  
    <script type="text/javascript">
    
        $(function() {
            $("#txtDate").datepicker();
        });
	
	</script>
	
	</head>
	<body>	   
	<form id="form1" runat="server">
	
		
<div id ="divManager" style ="border-left: 1px none #000; border-right: 1px none #000; border-top: 1px none #000; border-bottom: 1px solid #000; background-color:#F1F1E3; margin:0px; " >

<div style ="background-color:#efefef;" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<span style ="font-family:Arial; font-size: 14pt; color: #737357;">
   
<asp:Label ID="scnMediaAlbun" runat="server" Text="<b>Image Album:</b>"></asp:Label></span> 
<asp:DropDownList ID="scnAlbumDirectoryList" runat="server" 
        Style="width: 160px;" AutoPostBack="true" 
        onselectedindexchanged="scnAlbumDirectoryList_SelectedIndexChanged" />
<asp:Button ID="scnBtnDeleteAlbum" runat="server" 
        Text="Delete"  
        OnClientClick="return confirm('Are you sure you want to delete this folder and all its contents?');" 
        onclick="scnBtnDeleteAlbum_Click" />
					<asp:Label ID="scnMsgAlbums" runat="server" ForeColor="Red" />
					<asp:HiddenField ID="scnNewAlbumName" runat="server" />
					
					<asp:Button ID="scnBtnNewAlbum" runat="server" Text="New" 
        OnClick="scnBtnNewAlbum_Click1" Width="100px" />
</div>

<div style ="background-color: #E3E3C7; width:100%; "> 
<div style ="float:left; width :60%;">
<div id="divtree"  style ="float:none; padding :3px; width:100%;  height:250px; overflow:auto ;  border:2px solid #333; "  >
    <span style=" margin:1px; border-bottom:2px; border-bottom-style:solid; border-color:#666; color: #737357; " >
        <asp:Label ID="scnLblFolder" runat="server" Text="Folders"></asp:Label>
    </span>
    
    <asp:Button ID="scnBtnFolderNew2" runat="server" Text="New Subfolder" 
        Width="100px" onclick="scnBtnFolderNew_Click" Font-Bold="False" />&nbsp
    <asp:TextBox ID="scnFolderNewName" runat="server" Width="189px"></asp:TextBox>
    <br />
					<asp:Button ID="scnBtnFolderDelete" runat="server" 
        Text="Delete subfolder" OnClick="scnBtnFolderDelete_Click" 
        OnClientClick="return confirm('Are you sure you want to delete this folder?');" 
        Width="100px" />&nbsp;<asp:Label ID="scnFolderSelected" runat="server" 
        Font-Size="8pt" Text="Label"></asp:Label>
   
			<asp:Label ID="scnMsgFolder" runat="server" ForeColor="Red" />
					        <hr style="background-color:#dedede;  padding:2px; height: 1px !important;" />
    <radT:RadTreeView ID="scnTreeView" runat="server" Height="170px" Width="100%" 
        onnodeclick="scnTreeView_NodeClick" AutoPostBack="True"></radT:RadTreeView>

</div>
<div id ="divcmd"    style ="float:none; width:100%; height:260px;  padding:5px; overflow :auto;  border:2px solid #333; ">
<span style=" color: #737357; margin:1px; border-bottom:2px; border-bottom-style:solid; border-color:#666 " >

<asp:Label ID="scnLblDocument" runat="server" Text="Select image"></asp:Label>
</span>
<span class="align_right"> 
<asp:Button ID="OkButton" runat="server" Text="Return select" OnClick="Clear" />
&nbsp;<asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClientClick="window.top.close(); window.top.opener.focus();" OnClick="Clear" />
</span>		
<div id="divscroll" style="Z-INDEX: 102; border :solid 1px #efefef; overflow: auto; width:100%;" >
<asp:ListBox ID="scnImageList" runat="server" 
        Style="height: 189px; overflow:auto;  
            " OnSelectedIndexChanged="SelectImage"
        AutoPostBack="true" Height="100px" width="100%" />

</div>					
				
				

                          
	<asp:Panel ID="SearchBox" runat="server" DefaultButton="SearchButton">
						Find in folder:
                        <asp:TextBox ID="SearchTerms" runat="server" />
                        <asp:Button ID="SearchButton" runat="server" OnClick="Search" Text="Go" 
                            UseSubmitBehavior="false" />
                        <asp:Button ID="SearchButtonMinx" runat="server" OnClick="SearchMinx" Text="Minx" ToolTip="minx.jpg" UseSubmitBehavior="false" />
                        <asp:Button ID="SearchButtonMin" runat="server" OnClick="SearchMin" Text="Min" ToolTip="min.jpg" UseSubmitBehavior="false" />
                        <asp:Button ID="SearchButtonMed" runat="server" OnClick="SearchMed" Text="Med" ToolTip="med.jpg" UseSubmitBehavior="false" />
                        <asp:Button ID="SearchButtonFul" runat="server" OnClick="SearchFul" Text="Ful" ToolTip="ful..jpg" UseSubmitBehavior="false" />
                        <asp:Button ID="scnBtnSearchReset" runat="server" 
                            OnClick="scnBtnSearchReset_Click" Text="Reset" UseSubmitBehavior="false" />
                        <br />
					</asp:Panel>		

</div>
</div>



<div id="divimg" style ="float:right; width:37%; height:550px; padding :3px; border:2px; border-color:#333; border-style:solid ; "  >

<div id="divimgimg" style =" width:300px; overflow:auto ; ">
<span style=" color: #737357; margin:1px; border-bottom:2px; border-bottom-style:solid; border-color:#666 " >
    <asp:Label ID="snLblInformation" runat="server" Text="Doc Id= "></asp:Label>
</span>
<asp:Label ID="scnMediaDocId" runat="server" Text="Id"></asp:Label>
-<asp:Label ID="scnMediaDocLngId" runat="server" Text="lng"></asp:Label>

    &nbsp;<asp:Image ID="scnImgDBStatus" runat="server" CssClass="right" Height="16px" 
        ImageUrl="/a_img/a_site/ico16/ico-alert-yelow.png" ToolTip="Not in database" 
        Width="16px" />;
        <img class="right " src="/a_img/a_site/ico16/ico-space.png" />
        <asp:ImageButton ID="scnBtnDocPaste" runat="server" 
            BorderStyle="Groove" CssClass="right" 
            ImageUrl="~/a_img/a_site/ico16/ico-paste.png" 
            onclick="scnBtnDocPaste_Click" ToolTip="Paste fields" 
            Width="16px" />
            <img class="right " src="/a_img/a_site/ico16/ico-space.png" />
            <asp:ImageButton ID="scnBtnDocCopy" runat="server" 
            BorderStyle="Groove" CssClass="right" 
            ImageUrl="~/a_img/a_site/ico16/ico-copy.png" 
            onclick="scnBtnDocCopy_Click" ToolTip="Copy field" 
            Width="16px" />&nbsp;
   
    <span class="right">
<asp:Button ID="scnBtnImageThumb" runat="server" Text="Build thumbanils+" 
        OnClick="scnBtnImageThumb_Click1" />
          
&nbsp;<asp:Button ID="scnBtnDeleteImage" runat="server" Text="Delete" 
        OnClick="DeleteImage" 
        OnClientClick="return confirm('Are you sure you want to delete this image?');" />
&nbsp;<asp:Button ID="scnBtnImageNew" runat="server" Text="New" 
        Click="scnBtnNew2_Click" onclick="scnBtnImageNew_Click" />
&nbsp;<asp:Button ID="scnBtnSave" runat="server" Text="Save" OnClick="scnBtnSave_Click" />
    </span>
    <asp:CheckBox ID="scnBtnImageThumbOverwrite" Text="Overwrite"  
        runat="server" Checked="False" Visible="False" 
        ToolTip="If exist file the and numbre at end like _0001" /> 
    <asp:Label ID="scnMsgUpload" runat="server" Text="scnLblMsg"></asp:Label>
    
    
    <asp:Panel ID="scnMediaFieldsPannel" runat="server">
   
URL:
<br /> <asp:TextBox ID="scnMediaUrl2" Font-Size="12px"  runat="server" Width="100%" 
        Height="60px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>        

<asp:Label ID="scnMediaTitleLbl" runat="server" Text="Title"></asp:Label>
        <asp:ImageButton ID="scnBtnTestudinesAutor0" runat="server" 
            BorderStyle="Groove" CssClass="right" 
            ImageUrl="~/a_img/a_site/ico16/ico-sheet.png" 
            onclick="scnBtnTestudinesAutor0_Click" ToolTip="Copy file name" Width="16px" />
        <asp:ImageButton ID="scnBtnTitleClear" runat="server" BorderStyle="Groove" 
            CssClass="right" ImageUrl="~/a_img/a_site/ico16/ico-clear.png" 
            onclick="scnBtnTitleClear_Click" ToolTip="Clear" Width="16px" />
<br /><asp:TextBox ID="scnMediaTitle" Font-Size="12px"  runat="server" Width="100%" 
            MaxLength="254" TextMode="MultiLine"></asp:TextBox>

<asp:Label ID="scnMediaAutorLbl" runat="server" Text="Author"></asp:Label>
        <asp:ImageButton ID="scnBtnTestudinesAutor" runat="server" BorderStyle="Groove" 
            CssClass="right" ImageUrl="~/a_img/a_site/ico16/ico-testudines.png" 
            onclick="scnBtnTestudinesAutor_Click" ToolTip="Testudines" Width="16px" />
 <asp:ImageButton ID="scnBtnTestudinesAutorVniclos" runat="server" 
            BorderStyle="Groove" CssClass="right" 
            ImageUrl="~/a_img/a_site/ico16/ico-vniclos.png" 
            onclick="scnBtnTestudinesAutorVniclos_Click" ToolTip="Author V.Niclos" Width="16px" />       
        
        <asp:ImageButton ID="scnBtnAutorClear" runat="server" BorderStyle="Groove" 
            CssClass="right" ImageUrl="~/a_img/a_site/ico16/ico-clear.png" 
            onclick="scnBtnAutorClear_Click" ToolTip="Clear" Width="16px" />
<br /><asp:TextBox ID="scnMediaAuthor" Font-Size="12px" runat="server" Width="100%" 
            MaxLength="254"   TextMode ="MultiLine"></asp:TextBox>

<asp:Label ID="scnMediaSourceLbl" runat="server" Text="Source"></asp:Label>
        <asp:ImageButton ID="scnBtnTestudinesSource" runat="server" 
            BorderStyle="Groove" CssClass="right" 
            ImageUrl="~/a_img/a_site/ico16/ico-testudines.png" 
            onclick="scnBtnTestudinesSource_Click" ToolTip="Testudines" Width="16px" />
        <asp:ImageButton ID="scnBtnSourceWikipedia" runat="server" BorderStyle="Groove" 
            CssClass="right" ImageUrl="~/a_img/a_site/ico16/ico-wikipedia.png" 
            onclick="scnBtnSourceWikipedia_Click" ToolTip="Wikipedia" Width="16px" />
        <asp:ImageButton ID="scnBtnSourceClear" runat="server" BorderStyle="Groove" 
            CssClass="right" ImageUrl="~/a_img/a_site/ico16/ico-clear.png" 
            onclick="scnBtnSourceClear_Click" ToolTip="Clear source" Width="16px" />
<br /><asp:TextBox ID="scnMediaSource" Font-Size="12px"   runat="server" Width="100%" 
            MaxLength="254" TextMode="MultiLine"></asp:TextBox>

<asp:Label ID="scnMediaNotesLbl" runat="server" Text="Notes:" ></asp:Label>
<br /> <asp:TextBox ID="scnMediaNotes" Font-Size="12px"  runat="server" Width="100%" 
            TextMode="MultiLine"></asp:TextBox>        
<asp:Label ID="scnMediaDateLbl" runat="server" Text="Date:"></asp:Label>
<asp:TextBox ID="scnMediaDate" runat="server" Width="80px"></asp:TextBox><br />
    <asp:CalendarExtender ID="scnDateCalendarExtender1" runat="server" 
        TargetControlID="scnMediaDate">
    </asp:CalendarExtender>
      <asp:Image ID="scnImage1" class="align_img_center" runat="server" 
        Style=" max-width: 100%; max-height:150px; overflow:auto; display:inline-block;   padding:5px; border-color:#aaa; " 
          />
    </asp:Panel>
<asp:Panel ID ="scnPnlUpload" runat="server"  Visible ="false" >
<asp:Label ID="scnMediaSite" runat="server" Text="Select image to upload:"  ></asp:Label><br />  
<asp:FileUpload ID="UploadedImageFile" runat="server" Width="200" />&nbsp;
<br /><asp:Button ID="UploadButton" runat="server" Text="Upload " 
        OnClick="scnBtnUpload" />
	&nbsp;<asp:HiddenField ID="scnNewImageName" runat="server" />
					<asp:HiddenField ID="scnclipboard" runat="server" />
					<asp:HiddenField ID="ImageAspectRatio" runat="server" />
					<asp:Label ID="scnMsgBldTumbnail" runat="server" 
        ForeColor="Red" />
				</asp:Panel>	
</div>
</div>
</div>
<div style="clear:both ; text-align:center ; "> 

				</div>
		
    
		
</div>

</form>
</body>
</html>

