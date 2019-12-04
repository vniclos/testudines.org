<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site_Edit.Master" AutoEventWireup="true" CodeBehind="key-mng-edit.aspx.cs" Inherits="testudines.tortoises.keys.key_mng_edit" %>

<%@ register src="~/a_ctl/ctl_imgfld.ascx" tagprefix="uc3" tagname="ctl_imgfld" %>

<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ register src="~/a_ctl/ctl_doc_edit.ascx" tagprefix="uc1" tagname="ctl_doc_edit" %>
<%@ register src="~/a_ctl/ctl_docLng_edit.ascx" tagprefix="uc2" tagname="ctl_docLng_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentBtns" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

 
    <div class="row">
        <h1>Identification keys<span class="fld-boxId"> DocId= <asp:Literal ID ="scnDocId" runat="server" Text="0"></asp:Literal></span></h1>
     </div>
            <div class="row">
          
                <asp:Button ID="scnBtnSave" runat="server" Text="<%$ Resources:Strings, Save %>"
                    OnClick="scnBtnSave_Click" CssClass="btn-tiny" />
                
             
             
                <asp:Button ID="scnBtnReturn" runat="server" Text="<%$ Resources:Strings, ReturnAdmin %>"
                    OnClick="scnBtnReturn_Click" CssClass="btn-tiny" />
                <asp:Button ID="scnBtnGoList" runat="server" Text="<%$ Resources:Strings, ListView %>"
                    OnClick="scnBtnGoList_Click" CssClass="btn-tiny" />
                <asp:Button ID="scnBtnDelete" runat="server" Text="<%$ Resources:Strings, Delete %>"
                    OnClick="scnBtnDelete_Click"  CssClass="btn-tiny" />
                <asp:Button ID="scnBtnShow" runat="server" Text="<%$ Resources:Strings, View %>"
                    OnClick="scnBtnShow_Click"  CssClass="btn-tiny" />
                <ajaxToolkit:ConfirmButtonExtender ID="scnBtnDeleteExtender" runat="server" TargetControlID="scnBtnDelete"
                    ConfirmText="<%$ Resources:Strings, DoYouWantDelete %>">
                </ajaxToolkit:ConfirmButtonExtender>
                <asp:Literal ID="scnBtnDescend" runat ="server" text=""></asp:Literal>
            
               
                <asp:Button ID="scnBtnGoto" runat="server" CssClass="btn-tiny"  Text="View" OnClick="scnBtnGoto_Click1" />
                <asp:Button ID="scnBtnClose" runat="server"  CssClass="btn-tiny" Text="Close" />

            </div>
         <asp:Literal ID="scnMsg" runat="server" Text=""></asp:Literal>
        
     
    

    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <div class="col-12">
        <div class="col-6">

        </div>
<div class="col-6">

        </div>

    </div>
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
        <table style="width: 100%">
            <tr>
                
                <td>
                    <asp:Label ID="scnTOWNodeIdTit2" Width="175px" CssClass="fld-title-inline" runat="server"
                        Text="Node Id"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="scnTOWNodeParentIdTit2" Width="175px" Text="NodeParent" CssClass="fld-title-inline"
                        runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="scnTOWNodekeyNumTit2" Width="175px" Text="Node key Nº" CssClass="fld-title-inline"
                        runat="server"></asp:Label>
                </td>
                <td> <asp:Label ID="scnDocIdTaxaRelationValueTit" Width="175px" Text="scnDocIdTaxaRelationValue" CssClass="fld-title-inline"
            runat="server"></asp:Label></td>
                <td>   <asp:Label ID="scnIdIsRevisedTit" runat="server" Text="Is Revised:"></asp:Label> </td>
            </tr>
            <tr>
                   
                <td>
                    <asp:TextBox ID="scnTOWNodeId"  Width="100px" runat="server"
                        Text="scnTOWNodeId"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="scnTOWNodeParentId" Text="TOW NodeId" 
                        Width="100px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="scnTOWNodekeyNum" Text="TOW Node Num. "
                        Width="100px" runat="server"></asp:TextBox>
                </td>
                <td> <asp:DropDownList ID="scnDocIdTaxaRelationValue" runat="server" ToolTip="Select relation to taxon or taxon group">   </asp:DropDownList></td>
                <td> <asp:CheckBox ID="scnIdIsRevised" runat="server" Checked="false" /></td>
            </tr>
       
        </table>
    <div> <br /><br /></div>
        <ajaxToolkit:TabContainer ID="tbContainer" runat="server" ActiveTabIndex="0" Width="100%">


            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="<%$ Resources:Strings, Edit_Root %>">
                <HeaderTemplate>
                    Edit turtles of the world TOW
                </HeaderTemplate>
                <ContentTemplate>
                    <br />
                    
                    <b><asp:Label ID="scnTOWDescriptionTit2" Width="250px" Text="TOW description" CssClass="fld-title-inline" runat="server"></asp:Label></b>
                    <asp:TextBox ID="scnTOWDescription" Text="TOW Description"  Width="100%" runat="server" TextMode="MultiLine"></asp:TextBox>


                    <br />
                    <asp:Label ID="scnTOWTaxaGroupLevelTit2" Width="250px" Text="Taxa Group" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTOWTaxaGroupLevel" Text="TOW Taxa Group Level"    Width="500px" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="scnTOWATaxIdGroupTit" Width="250px" Text="Tax Id Group" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTOWATaxIdGroup" Text="TOW Node Num. "  MaxLength="50" Width="500px" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="scnTOWATaxGrpL2280SpecieTit" Width="250px" Text="Tax GrpL2280 Specie" CssClass="fld-title-inline" runat="server"></asp:Label> 
                    <asp:TextBox ID="scnTOWATaxGrpL2280Specie" Text="TOW Node Num."  MaxLength="50" Width="500px" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="scnTOWATaxGrpL2280SpecieSubTit" Width="250px" Text="TaxGrpL2280 SpecieSub" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTOWATaxGrpL2280SpecieSub" Text="TOW Node Num. "  MaxLength="50" Width="500px" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="scnTOWTaxaGroupNameTit2" Width="250px" Text="Taxa Group Name" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTOWTaxaGroupName" Text="TOW Taxa Group Name"  Width="500px" runat="server"></asp:TextBox>
                    <br />2017 dejo de funcionar la web
                    <asp:Label ID="scnTOWTaxaURLTit2" Width="250px" Text="TOW URL" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTOWTaxaURL" Text="TOW URL"  Width="800px"  runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="scnTaxonDocIdTit2" Width="250px" Text="Taxon DocId" CssClass="fld-title-inline" runat="server"></asp:Label>
                    <asp:TextBox ID="scnTaxonDocId" Text="Taxon Doc Id"   Width="500px" runat="server"></asp:TextBox>
                   <h4>Autocalculate fields</h4>
                    <br /> 
                    <asp:Label ID="scnNodeFullPathListTit2" Width="250px" Text="Node Full Path List txt" CssClass="fld-title-inline"  runat="server"></asp:Label>
                    <asp:TextBox ID="scnNodeFullPathList" Text="Nodes Path List txt" Width="100%" runat="server" ReadOnly="true" TextMode="MultiLine"></asp:TextBox>
                     <br />
                    <asp:Label ID="scnNodeFullPathListHtmlTit2" Width="250px" Text="Node Full Path List Html" CssClass="fld-title-inline" runat="server"></asp:Label>
                    
                         <CKEditor:CKEditorControl ID="scnNodeFullPathListHtml" runat="server" TextMode="MultiLine"
                                    Toolbar="Basic" ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|Image|Format|Source|SpecialChar|RemoveFormat"
                                    Width="" ResizeMaxWidth="300" Height="15em" PasteFromWordRemoveStyles="True"
                                    FormatTags="h3;h4;h5;h6;pre;address;div" StartupMode="Wysiwyg" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css" ReadOnly="True">
                                </CKEditor:CKEditorControl>
                          

                </ContentTemplate>
            </ajaxToolkit:TabPanel>

    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
            <ajaxToolkit:TabPanel ID="tbEdit" runat="server" HeaderText="<%$ Resources:Strings, Edit_Root %>">
                <HeaderTemplate>
                    Edit
                </HeaderTemplate>
                <ContentTemplate>
                    <div class="row ">
                        <br />
                        
                            <h4>Imagenes representativas</h4>
                        </div>
                   <div class="row">
                            <div class="col-4">
                            <uc3:ctl_imgfld ID="scnImgHlpPath01" runat="server" ID_Parents="MainContent_tbContainer_tbEdit_"  ImageNoImageUrl="/a_img/noimage200px.png" ClientIDMode="Predictable" /> 
                            </div>
                            <div class="col-4">
                                <uc3:ctl_imgfld ID="scnImgHlpPath02" runat="server" ID_Parents="MainContent_tbContainer_tbEdit_"   ImageNoImageUrl="/a_img/noimage200px.png" ClientIDMode="Predictable" />
                            </div>
                            <div class="col-4">
                                <uc3:ctl_imgfld ID="scnImgHlpPath03" runat="server" ID_Parents="MainContent_tbContainer_tbEdit_"   ImageNoImageUrl="/a_img/noimage200px.png" ClientIDMode="Predictable" />
                        
                        </div>
                    </div>
                        <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
                    <div class="row">
                        <div class="col-6">
                            
                            <h3>English<img src="/a_img/a_site/ico16/flag16_en.gif" /></h3>
                              <asp:Label ID="scnESTituloTit2" runat="server" CssClass="fieldname" Text="<%$ Resources:Strings, Title %>"></asp:Label>EN<br />
                               <asp:TextBox ID="scnENTitle" runat="server" CssClass="fieldtext" Width="100%"></asp:TextBox>
                               <h4>Description</h4>
                             <CKEditor:CKEditorControl ID="scnENDescription" runat="server" TextMode="MultiLine"
                                    Toolbar="Basic" ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|Image|Format|Source|SpecialChar|RemoveFormat"
                                    Width="" ResizeMaxWidth="300" Height="15em" PasteFromWordRemoveStyles="True"
                                    FormatTags="h3;h4;h5;h6;pre;address;div" StartupMode="Wysiwyg" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css">
                                </CKEditor:CKEditorControl>
                           
                        </div>
                            <!-- -------------------------------------------------------- -->
                           <div class="col-6">
                               <h3>Spanish<img src="/a_img/a_site/ico16/flag16_es.gif" /></h3>
                              <asp:Label ID="Label5" runat="server" CssClass="fieldname" Text="<%$ Resources:Strings, Title %>"></asp:Label>ES<br />
                               <asp:TextBox ID="scnLNGTitle" runat="server" CssClass="fieldtext" Width="100%"></asp:TextBox>
                              <h4>Description</h4>
                                 <CKEditor:CKEditorControl ID="scnLNGDescription" runat="server" TextMode="MultiLine"
                                    Toolbar="Basic" ToolbarBasic="Bold|Italic|-|NumberedList|BulletedList|-|Link|Unlink|-|Image|Format|Source|SpecialChar|RemoveFormat"
                                    Width="" ResizeMaxWidth="300" Height="15em" PasteFromWordRemoveStyles="True"
                                    FormatTags="h3;h4;h5;h6;pre;address;div" StartupMode="Wysiwyg" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css">
                                </CKEditor:CKEditorControl>
                             </div>
                    </div>
                    <div class="row">
                           <div class="col-6">
                                <h4>Notes</h4>
                             <asp:Label ID="scnNotesTit" runat="server" CssClass="fieldname" Text="<%$ Resources:Strings, Notes %>"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnENNotes" runat="server" MaxLength="500" ResizeMaxWidth="300"
                                    TextMode="MultiLine" Toolbar="Basic" Width="" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css"></CKEditor:CKEditorControl>

                           </div>
                         <div class="col-6">
                              <h4>Notes</h4>
                             <asp:Label ID="Label4" runat="server" CssClass="fieldname" Text="<%$ Resources:Strings, Notes %>"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnLNGNotes" runat="server" MaxLength="500" ResizeMaxWidth="300"
                                    TextMode="MultiLine" Toolbar="Basic" Width="" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css"></CKEditor:CKEditorControl>
                      
                         </div>
                    </div>
                        <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
    <!-- -------------------------------------------------------- -->
           
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="<%$ Resources:Strings, Edit_Root %>">
                <HeaderTemplate>
                    Root Doc
                </HeaderTemplate>
                <ContentTemplate>
                    <uc1:ctl_doc_edit ID="ctl_doc_edit1" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="<%$ Resources:Strings, Edit_Metas %>">
                <HeaderTemplate>
                    Metas
                </HeaderTemplate>
                <ContentTemplate>
                    <uc2:ctl_docLng_edit ID="ctl_docLng_edit1" runat="server" />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="<%$ Resources:Strings, Preview %>">
                <ContentTemplate>
                    <asp:Label ID="scnView" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="<%$ Resources:Strings, Help %>">
                <ContentTemplate>
                    <b>Objective</b>:
                    <br />
                    Centralize the management of external references of the site, People, Institucinones,
                    associations, websites, bibliography, etc.
                    <br />
                    <br />
                    Each reference have assigned a numeric identifier unique, which is used on the site
                    for references,<br />
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
