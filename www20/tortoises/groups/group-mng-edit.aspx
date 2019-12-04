<%@ page title="" language="C#" masterpagefile="~/Mpg_Site_Edit.Master" autoeventwireup="true" codebehind="group-mng-edit.aspx.cs" inherits="testudines.tortoises.groups.groups_mng_edit" %>



<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ register src="~/a_ctl/ctl_doc_edit.ascx" tagname="ctl_doc_edit" tagprefix="uc1" %>
<%@ register src="~/a_ctl/ctl_docLng_edit.ascx" tagname="ctl_docLng_edit" tagprefix="uc2" %>
<%@ register src="/a_ctl/ctl_imgfld.ascx" tagname="ctl_imgfld" tagprefix="uc_imgFld" %>
<%@ register src="/a_ctl/ctl_imggallnk.ascx" tagname="ctl_imggallnk" tagprefix="uc3" %>




<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style>
        .pad-left {
            padding-right: 5%;
            margin-bottom: 24px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContentBtns" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div class="row">
                <asp:Button ID="scnBtnNew" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_new %>" OnClick="scnBtnNew_Click" />
                <asp:Button ID="scnBtnListMng" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list_mng %>" OnClick="scnBtnListMng_Click" />

                <asp:Button ID="scnBtnList" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list %>" OnClick="scnBtnList_Click" />
                <a href="https://www.linguee.es/espanol-ingles" class="btn btn-primary btn-sm" target="_blank"><span class="glyphicon glyphicon-random white"></span></a>

                <input type="button" class="btn btn-primary btn-sm" onclick="javascript: window.open('https://translate.google.com/', '_blank');" value="Translate" />

                <span class="fld-boxId ">Doc.Id.&nbsp; 
                    <asp:Literal ID="scnDocId" runat="server" Text="0" ClientIDMode="Static"></asp:Literal></span>
            </div>
            <div class ="row">
           <asp:Label ID="scnTitle_XX_tit" for="scnTitle_XX" CssClass="fld-title" runat="server" Text="Title:"></asp:Label>
           <asp:Label ID="scnTitle_XX2" runat="server" Text="" ></asp:Label>


            </div>
            <div class="container2">

                <!-- Nav tabs -->
                <ul class="nav nav-tabs" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#tabMain">Document</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#tabMeta">Metas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#menu2">All lng</a>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <div id="tabMain" class="container tab-pane active">
                        <div class="form-control">
                            <!-- -------- START ROW ---------- -->
                            <div class="row">
                                <div class="col-6" id="document-1es">
                                    <asp:Button ID="scnBtnSaveES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_ES %>" OnClick="scnBtnSaveES_Click" />
                                    <asp:Button ID="scnBtnRbCacheES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_ES%>" OnClick="scnBtnRbCacheES_Click" />
                                    <asp:Button ID="scnBtnShowES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowES_Click" />
                                    <asp:Button ID="scnBtnDeleteES" runat="server" class="btn btn-primary btn-sm" Text="<%$ Resources:Strings, Delete %>" OnClick="scnBtnDeleteEN_Click" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="scnBtnDeleteExtenderES" runat="server" TargetControlID="scnBtnDeleteES" ConfirmText="<%$ Resources:Strings, DoYouWantDelete %>"></ajaxToolkit:ConfirmButtonExtender>
                        
                                </div>
                                <div class="col-6" id="document-1en">
                                    <asp:Button ID="scnBtnSaveEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_EN %>" OnClick="scnBtnSave_EN_Click" />
                                    <asp:Button ID="scnBtnRbCacheEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_EN%>" OnClick="scnBtnRbCacheEn_Click" />
                                    <asp:Button ID="scnBtnShowEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowEN_Click" />
                                    <asp:Button ID="scnBtnDeleteEN" runat="server" class="btn btn-primary btn-sm" Text="<%$ Resources:Strings, Delete %>" OnClick="scnBtnDeleteEN_Click" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="scnBtnDeleteExtenderEN" runat="server" TargetControlID="scnBtnDeleteEN" ConfirmText="<%$ Resources:Strings, DoYouWantDelete %>"></ajaxToolkit:ConfirmButtonExtender>
                               
                                </div>
                            </div>
                            <!-- ------------------------------------------- -->
                            <!-- ------------------------------------------- -->
                             <!-- ---------- START ROW -------- -->
                            <div class="row pannel">
                           <table style="width:100%; float:none;">
<tr>                              
            <td><b><asp:Label ID="scnATaxLevel_XX_tit" runat="server" Text="Tax. Level"></asp:Label> </b</td>
                                   <td><b><asp:Label ID="scnATaxIdNameXX_tit" runat="server" Text="Tax Id"></asp:Label></b</td>
                                   <td><b><asp:Label ID="scnATaxGrpL2282AuthorityXX_tit"     runat="server" Text="Authority"></asp:Label></b</td>
                                   <td><b><asp:Label ID="scnATaxGrpL2283YearXX_tit" runat="server" Text="Year" ></asp:Label></b</td>
                                    <td><b>><asp:Label ID="scnAtaxIdNameParent_XX_tit"   runat="server" Text="Tax Id Parent"></asp:Label></b</td>
</tr>
                               <tr>

                               <td>  <asp:DropDownList ID="scnAtaxLevel_XX" runat="server"></asp:DropDownList></td>
                               <td> <asp:TextBox ID="scnATaxIdName_XX" cssClass="fld-textbox-inline" runat="server" Text="" Columns="20" MaxLength="40"></asp:TextBox> </td>
                               <td><asp:TextBox ID="scnATaxGrpL2282Authority_XX" cssClass="fld-textbox-inline" runat="server" Text=""></asp:TextBox></td>
                               <td><asp:TextBox ID="scnATaxGrpL2283Year_XX"  type="number" Columns="4" MaxLength="4"      runat="server" Text=""></asp:TextBox> </td>
                              <td> <asp:TextBox ID="scnAtaxIdNameParent_XX"  runat="server" Text="c" ReadOnly="True"></asp:TextBox></td>
                                   </tr>
                               <tr>
                                   <td ><b> <asp:Label ID="scnIsOk_XX_tit" runat ="server" Text =" Revised from 2018"></asp:Label></b></td>
                                   <td ><b><asp:Label ID="scnRef_ITIS_Number_XX_tit" runat ="server" Text ="ITIS Nº."></asp:Label></b></td>
                                   
                                   <td colspan="4"><b> <asp:Label ID="scnIsTaxa2014_XX_tit" runat ="server"  Text ="ITIS valid 2014? "></asp:Label></b></td>

                               </tr>
                               <tr>
                                   <td ><asp:CheckBox ID="scnIsOk_XX" runat="server" Checked="false" /></td>
                                   
                                   <td > <asp:TextBox ID="scnRef_ITIS_Number_XX" type="number" Columns="6" MaxLength="6"  runat="server" Text="" ReadOnly="false"></asp:TextBox></td>
                                    <td colspan="4"><asp:CheckBox ID="scnIsTaxa2014_XX" runat="server" Checked="false" /></td>
                               </tr>
                           </table>
                               
                                <asp:Literal ID="scnMsgBox" runat="server" Text=""></asp:Literal>                        
                                
                               
                              
                                
                                 
                              
                                
                              
                              

                            </div>
                           
                            <hr />
                            <!-- ------------------------------------------- -->
                            <div class="row">
                                <div class="col-6" id="document-11es">
                                    <img src="/a_img/a_site/ico16/flag16_es.gif" />
                                    <div class="form-group">
                                        
                                           
                                        <b><asp:Label ID="scnNameVulgarES_tit" for="scnNameVulgar_ES"  runat="server" Text="Nombre vulgar"></asp:Label></b>
                                        <asp:TextBox ID="scnNameVulgar_ES" runat="server" Text="" Columns="60" Rows="2" TextMode="MultiLine" Width="100%"></asp:TextBox>

                                    </div>
                                    <div class="form-group">

                                        <b><asp:Label ID="scnDescriptionShort_ES_tit" for="scnDescriptionShort_ES"  runat="server" Text="Decripcion breve"></asp:Label></b>
                                        <asp:TextBox ID="scnDescriptionShort_ES" runat="server" Text="" Columns="60" Rows="4" Width="100%" EnableViewState="False" TextMode="MultiLine"></asp:TextBox>

                                    </div>


                                </div>
                                <div class="col-6" id="document-11en">
                                    <img src="/a_img/a_site/ico16/flag16_en.gif" />


                                    <div class="form-group">
                                        <b><asp:Label ID="scnNameVulgar_EN_tit" for="scnNameVulgar_EN"  runat="server" Text="Vulgar Name"></asp:Label></b>
                                        <asp:TextBox ID="scnNameVulgar_EN" runat="server" Columns="60" Rows="2" TextMode="MultiLine" Width="100%" Text=""></asp:TextBox>

                                    </div>
                                    <div class="form-group">
                                        <b><asp:Label ID="scnDescriptionShort_EN_tit" for="scnDescriptionShort_EN"  runat="server" Text="Short Description"></asp:Label></b>
                                        <asp:TextBox ID="scnDescriptionShort_EN" Columns="60" Rows="4" TextMode="MultiLine" Width="100%" runat="server" Text=""></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                             <hr />
                            <!-- -------- END  ROW ---------- -->
                            <!-- -------- START ROW ---------- -->
                            <div class="row">
                                <div class="col-6" id="document-2es">
                                    <img src="../../a_img/a_site/ico16/flag16_es.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnAbstract_ES_tit" CssClass="fld-title-inline" for="scnAbstract_ES" runat="server" Text="Abstract" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnAbstract_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px">   &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   </CKEditor:CKEditorControl>
                                    </div>
                                </div>
                                <div class="col-6" id="document-2en">
                                    <img src="../../a_img/a_site/ico16/flag16_en.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnAbstract_En_tit" CssClass="fld-title-inline" for="scnAbstract_EN" runat="server" Text="Abstract" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnAbstract_EN" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px">   &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   </CKEditor:CKEditorControl>
                                    </div>
                                </div>

                            </div>
                            <!-- -------- END  ROW ---------- -->
                            <!-- -------- START ROW ---------- -->
                             <hr />
                            <div class="row>">




                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg01" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>
                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg02" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>
                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg03" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>
                            </div>
                            <div class="row">
                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg04" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>
                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg05" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>
                                <span class="pad-left">
                                    <uc_imgFld:ctl_imgfld ID="scnImg06" runat="server" ImageNoImageUrl="/a_img/noimage200px.png" ID_Parents="ctl00_cphContent_tbContainer_tbReferences_" ClientIDMode="Static" Width="200px" />
                                </span>



                            </div>
                             <hr />
                            <!-- -------- END  ROW ---------- -->
                            <!-- -------- START ROW ---------- -->
                            <div class="row">
                                <div class="col-6" id="document-3es">
                                    <img src="/a_img/a_site/ico16/flag16_es.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnBody_ES_tit" CssClass="fld-title-inline" for="scnBody_ES" runat="server" Text="Articulo" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnBody_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
                                    </div>
                                </div>
                                <div class="col-6" id="document-3en">
                                    <img src="/a_img/a_site/ico16/flag16_en.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnBody_EN_tit" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="Article" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnBody_EN" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">     </CKEditor:CKEditorControl>
                                    </div>



                                </div>

                            </div>
                             <hr />
                            <!-- -------- END  ROW ---------- -->
                            <!-- -------- START ROW ---------- -->
                            <div class="row">
                                <div class="col-6" id="document-41es">
                                    <img src="/a_img/a_site/ico16/flag16_es.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnNotes_ES_tit" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="Notes" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnNotes_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">     </CKEditor:CKEditorControl>
                                    </div>
                                </div>
                                <div class="col-6" id="document-4e1s">
                                    <img src="/a_img/a_site/ico16/flag16_en.gif" />
                                    <div class="form-group">
                                        <asp:Label ID="scnNotes_EN_tit" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="Notes" ClientIDMode="Static"></asp:Label>
                                        <CKEditor:CKEditorControl ID="scnNotes_EN" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">     </CKEditor:CKEditorControl>
                                    </div>
                                </div>
                            </div>
                            <!-- -------- END  ROW ---------- -->
                            <!-- -------- START ROW ---------- -->
                            <h2>Same for all languages</h2>
                            <div class="row back-gray">

                                <div class="col-12" id="document-4es">

                                    <div class="form-group">
                                        <asp:Label ID="scnAutors_XXTit" CssClass="fld-title" for="scnIsAuthorizeAll2" runat="server" Text="Autors" ClientIDMode="Static"></asp:Label>
                                        <asp:TextBox ID="scnAutors_XX" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="500" ClientIDMode="Static" Columns="80" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-6" id="document-41en">
                                        <div class="form-group">
                                            <asp:Label ID="scnAcknoelegment_XX_Tit" CssClass="fld-title" runat="server" Text="Agradecimientos - Acknoelegment" ClientIDMode="Static"></asp:Label>
                                            <CKEditor:CKEditorControl ID="scnAcknoelegment_XX" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   </CKEditor:CKEditorControl>
                                        </div>
                                    </div>
                                    <div class="col-6" id="document-4en">
                                        <div class="form-group">
                                            <asp:Button ID="scnBtnBiblio_rebuild" runat="server" CssClass="btn btn-primary btn-sm" Text="Rebuild from table" OnClick="scnBtnBiblio_rebuild_Click" />
                                            <asp:Label ID="scnBibliography_XX_Tit" CssClass="fld-title" runat="server" Text="Bibliografia - Bibiliography" ClientIDMode="Static"></asp:Label>
                                            <CKEditor:CKEditorControl ID="scnBibliography_XX" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;   </CKEditor:CKEditorControl>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- -------- END  ROW ---------- -->

                            <!-- ----------------------------------------- -->
                        </div>

                    </div>

                    <!-- ----------------------------------------- -->
                    <div id="tabMeta" class="container tab-pane fade">
                        <uc1:ctl_doc_edit runat="server" ID="scn_oDoc_edit" />

                    </div>
                    <div id="menu2" class="container tab-pane fade">
                        <div class="col-6" id="document-5es">
                            <h3>Español</h3>
                            <uc2:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_ES" />
                        </div>
                        <div class="col-6" id="document-5EN">
                            <h3>English</h3>
                            <uc2:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_EN" />
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
