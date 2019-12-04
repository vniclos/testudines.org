<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_doc_edit.ascx.cs" Inherits="testudines.a_ctl.ctl_doc_edit" EnableTheming="True" ClientIDMode="Static" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>



<h2><asp:Label ID="scnMasterDocument" runat="server" Text="<%$ Resources:Strings, Master_Document %>"></asp:Label></h2>
<div class="form-group">
<asp:Label ID="scnDocIdTit" for="scnDocId" cssClass="col-2 col-form-label" runat="server"  Text= "<%$ Resources:Strings, scnDocId %>"></asp:Label>
<asp:TextBox ID="scnDocId" CssClass ="fieldtext" runat="server" ReadOnly="True"></asp:TextBox>
</div>
<div class="form-group">
<asp:Label ID="scnDocTypeIdTit"  for="scnDocTypeId" cssClass="col-2 col-form-label" runat="server" Text="<%$ Resources:Strings, scnDocTypeId %>"></asp:Label>
<asp:TextBox ID="scnDocTypeId" CssClass ="fieldtext"  ReadOnly ="true" runat="server"></asp:TextBox>
</div>

<div class="form-group">
<asp:Label ID="scnDocLngIdMainTit"   for="scnDocTypeId" cssClass="col-2 col-form-label"  runat="server" 
Text="<%$ Resources:Strings, scnDocLngIdMain %>"></asp:Label>
<asp:DropDownList ID="scnDocLngIdMain" CssClass ="fieldtext" runat="server"></asp:DropDownList>
</div>

<div class="form-group">
<asp:Label ID="scnImg100Tit" Text ="Upload thumbnail"   for="scnDocTypeId" cssClass="col-2 col-form-label"  runat="server" />
<br /><asp:Label runat ="server" ID="scnDocSiteMapPriorityTit"  Text="<%$ Resources:Strings, scnSiteMapPriorityTit %>" CssClass ="field-title-inline"></asp:Label>
<asp:DropDownList runat ="server" ID="scnDocSiteMapPriority"  >
<asp:ListItem Text ="1" Value ="1"></asp:ListItem>
<asp:ListItem Text ="0.9" Value ="0.9"></asp:ListItem>
<asp:ListItem Text ="0.8" Value ="0.8"></asp:ListItem>
<asp:ListItem Text ="0.7" Value ="0.7"></asp:ListItem>
<asp:ListItem Text ="0.6" Value ="0.6"></asp:ListItem>
<asp:ListItem Text ="0.1" Value ="0.1"></asp:ListItem>
</asp:DropDownList>

<br /><asp:Label runat ="server" ID="scnDocSiteMapChangefreqTit" Text="<%$ Resources:Strings, scnDocSiteMapChangefreqTit %>" CssClass ="field-title-inline"></asp:Label>

<asp:DropDownList  runat ="server" ID="scnDocSiteMapChangefreq" >
<asp:ListItem Text ="day" Value ="day"></asp:ListItem>
<asp:ListItem Text ="week" Value ="week"></asp:ListItem>
<asp:ListItem Text ="month" Value ="month"></asp:ListItem>
<asp:ListItem Text ="year" Value ="year"></asp:ListItem>
<asp:ListItem Text ="year" Value ="never"></asp:ListItem>
</asp:DropDownList>

</div>
<div class="form-group">
    

<asp:Image ID="scnImg100_Img"  CssClass="imgright"  
        sytle="width:168px; height=102px;" runat="server" 
        ImageUrl="/a_img/a_site/noimage100-166.jpg" Width="168px" Height="100px"  />
    <asp:Literal ID="scnImg100_Img_size" runat="server" Text ="166px × 100px"></asp:Literal>

<asp:FileUpload ID="scnFileUpload" runat="server" />
<asp:Button ID="scnUploadBtn" runat="server" OnClick="scnUploadBtn_Click" Text="Upload" />
<asp:Button ID="scnUploadBtnClear" runat="server" OnClick="scnUploadBtnClear_Click" Text="Clear Thumbnail" />

<br /><asp:Label ID="scnImg100" runat="server" ></asp:Label>
<asp:Label ID="scnMsgUpload" runat="server" Text="scnMsgUpload" Visible="False"></asp:Label>
</div>
<div class ="box600px" >
<asp:Label ID="ScnFileUploadDocTit" Text ="Upload document" CssClass ="fieldname" runat="server" />
<br /><asp:FileUpload ID="ScnFileUploadDoc" runat="server" />
<asp:Button ID="scnBtnUploadDocc" runat="server" OnClick="scnBtnUploadDocc_Click" Text="Upload" />
<asp:Button ID="scnBtnUploadDocClear" runat="server" OnClick="scnBtnUploadDocClear_Click" Text="Clear Doc." />
<br /> <asp:Label ID="scnMsgUploadDoc" runat="server" ></asp:Label>
<asp:Label ID="scnDocumentUploaded" runat="server" ></asp:Label>&nbsp;<asp:Label ID="scnDocumentUploadedLnk" runat="server" ></asp:Label>
<asp:Label ID="scnDocumentUploadedLink" visible="false"  runat="server" ></asp:Label>



</div>
<asp:Label ID="scnDocUserIdCreatorTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocUserIdCreator %>"></asp:Label>
<asp:TextBox ID="scnDocUserIdCreator" CssClass ="fieldtext" runat="server"  TextMode="SingleLine"></asp:TextBox>
<asp:Button ID="scnPnlBibliographyBtnOpen" runat="server" Text="Open references" 
        onclick="scnPnlBibliographyBtnOpen_Click" />

<br />
<asp:Label ID="scnLAutor" runat="server" CssClass="fieldname" Text="Autor"></asp:Label>
<br />
<CKEditor:CKEditorControl ID="scnDocAuthor" runat="server" 
toolbar="Basic" Width="" EnterMode="BR" TextMode="MultiLine" MaxLength="300"></CKEditor:CKEditorControl>

<br />

<br />
<asp:Label ID="scnDocAuthorsTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocAuthors %>"></asp:Label>
<CKEditor:CKEditorControl ID="scnDocAuthors" runat="server" 
toolbar="Basic" Width="" EnterMode="BR" TextMode="MultiLine" MaxLength="300"></CKEditor:CKEditorControl>

<br />
<asp:Label ID="scnDocAcknowledgementsTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocAcknowledgements %>"></asp:Label>
<CKEditor:CKEditorControl ID="scnDocAcknowledgements" runat="server" 
            toolbar="Basic" Width="" TextMode="MultiLine" MaxLength="300" 
        EnterMode="BR"></CKEditor:CKEditorControl>

<br />
<asp:Button ID="scnBtnBibliography" runat="server"   OnClientclick="javascript:void(0)" Text="Biblio." ToolTip="Bibliografia"></asp:Button>
&nbsp;<asp:Button ID="scnBtnBibliographyGet" runat="server"  Text="Rebuil from tb. Bibl.." ToolTip="Get Bibliografia" OnClick="scnBtnBibliographyGet_Click"></asp:Button>

<asp:Label ID="scnBibliographyTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnBibliography %>"></asp:Label>
<CKEditor:CKEditorControl ID="scnBibliography" runat="server" 
            toolbar="Basic" EnterMode="BR" Width="" TextMode="MultiLine" MaxLength="300"></CKEditor:CKEditorControl>

<br />
<asp:Label ID="scnAuthorizations" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnAutorizaionTit %>"></asp:Label>
<CKEditor:CKEditorControl ID="scnAutorizaion" runat="server" 
            toolbar="Basic" EnterMode="BR" Width="" TextMode="MultiLine" MaxLength="300"></CKEditor:CKEditorControl>


 

<p>
<asp:Label ID="scnDocNotesTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocNotes %>"></asp:Label>
<asp:TextBox ID="scnDocNotes" CssClass ="fieldtext" runat="server"  TextMode="MultiLine" Width="100%"></asp:TextBox>
</p>
<h2><asp:Label ID="scnSectionOptions" CssClass ="fieldname" runat="server" 
    Text="<%$ Resources:Strings, Options %>"></asp:Label> </h2>
<p>
<asp:Label ID="scnDocIsTraslatableTit" CssClass ="fieldname" runat="server" 
    Text="<%$ Resources:Strings, scnDocIsTraslatable %>"></asp:Label>
<asp:CheckBox ID="scnDocIsTraslatable" runat="server" />
<br />
<asp:Label ID="scnDocIsEditableTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocIsEditable %>"></asp:Label>
<asp:CheckBox ID="scnDocIsEditable" runat="server" />
<br />



<asp:Label ID="scnDocIsActiveTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocIsActive %>"></asp:Label>
<asp:CheckBox ID="scnDocIsActive" runat="server" />
</p>
<h2><asp:Label ID="scnTracking" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, Tracking %>"></asp:Label> </h2>
<p>
<asp:Label ID="scnDocDateCreationTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocDateCreation %>"></asp:Label>
<asp:TextBox ID="scnDocDateCreation" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />

<asp:Label ID="scnDocDateUpdateTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocDateUpdate %>"></asp:Label>
<asp:TextBox ID="scnDocDateUpdate" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />
<asp:Label ID="scnDocStdVisitLastTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocStdVisitLast %>"></asp:Label>
<asp:TextBox ID="scnDocStdVisitLast" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />

<asp:Label ID="scnDocStdVisitCountTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocStdVisitCount %>"></asp:Label>
<asp:TextBox ID="scnDocStdVisitCount" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />
<asp:Label ID="scnDocStdValLowTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocStdValLow %>"></asp:Label>
<asp:TextBox ID="scnDocStdValLow" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />
<asp:Label ID="scnDocStdValMedTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocStdValMed %>"></asp:Label>
<asp:TextBox ID="scnDocStdValMed" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />
<asp:Label ID="scnDocStdValHigTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocStdValHig %>"></asp:Label>
<asp:TextBox ID="scnDocStdValHig" CssClass ="fieldtext" runat="server"></asp:TextBox>
<br />
<asp:Label ID="scnDocCountriesCodeTit" CssClass ="fieldname" runat="server" Text="<%$ Resources:Strings, scnDocCountriesCode %>"></asp:Label>
<asp:TextBox ID="scnDocCountriesCode" CssClass ="fieldtext" runat="server"></asp:TextBox>
</p>


<!--
     * scnDocId = 0;
	 * scnDocLngIdMain = "";
	 * scnDocTypeId = "";
	 * scnIsDocTraslatable = false;
	 * scnIsDocEditable = false;
	 * scnIsDocActive = false;
	 * scnDocIdCreator = 0;
	 * scnDocAuthors = "";
	 * scnDocBibliography = "";
	 * scnDocAcknowledgements = "";
	 * scnDocNotes = "";
	 scnDocDateCreation = DateTime.Now;
	 scnDocDateUpdate = DateTime.Now;
	 scnDocStdVisitLast = DateTime.Now;
	 scnDocStdVisitCount = 0;
	 scnDocStdValLow = 0;
	 scnDocStdValMed = 0;
	 scnDocStdValHig = 0;
	 scnDocCountriesCode = "";

-->