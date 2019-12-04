<%@ page title="" language="C#" masterpagefile="~/Mpg_Site_Edit.Master" autoeventwireup="true" codebehind="food-mng-edit.aspx.cs" inherits="testudines.tortoises.foods.food_mng_edit" %>

<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ register src="~/a_ctl/ctl_doc_edit.ascx" tagprefix="uc1" tagname="ctl_doc_edit" %>
<%@ register src="~/a_ctl/ctl_docLng_edit.ascx" tagprefix="uc1" tagname="ctl_docLng_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentBtns" runat="server">



</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
        <asp:UpdatePanel runat="server" ID ="UpdatePanel1">
            <ContentTemplate>
                   <div class="btn-group" role="group" aria-label="Basic example">
        <asp:Button ID="scnBtnNew" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_new %>" OnClick="scnBtnNew_Click" />
        <asp:Button ID="scnBtnListMng" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list_mng %>" OnClick="scnBtnListMng_Click" />
        <asp:Button ID="scnBtnList" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list %>" OnClick="scnBtnList_Click" />
    <a href="https://www.linguee.es/espanol-ingles"  class="btn btn-primary btn-sm"" target="_blank"> <span class="glyphicon glyphicon-random white" ></span> </a>

        <input type="button" class="btn btn-primary btn-sm" onclick="javascript: window.open('https://translate.google.com/', '_blank');" value="Translate" />

        <span class="fld-boxId ">Doc.Id.&nbsp; 
            <asp:Literal ID="scnDocId" runat="server" Text="0" ClientIDMode="Static"></asp:Literal></span>
    </div>
    <div class="row">
        <div class="col-6">
            <br />
            <asp:Label ID="scnFilterfoodTypeTit" runat="server" CssClass="field-title-inline" Style="font-size: 9pt;" Text="<%$ Resources:Strings, foodType %>"></asp:Label>
            <asp:DropDownList ID="scnFilterfoodType" runat="server">
            </asp:DropDownList>
        </div>
        <div class="col-6">
            <br />
            <asp:Label ID="scnFilterfoodTypeSubTit" runat="server" CssClass="field-title-inline" Text="<%$ Resources:Strings, foodTypeSub %>"></asp:Label>
            <asp:DropDownList ID="scnFilterfoodTypeSub" runat="server">
            </asp:DropDownList>
        </div>
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
                            <asp:Literal ID="scnMsbBoxES" runat="server" Text=""></asp:Literal>
                        </div>
                        <div class="col-6" id="document-1en">
                            <asp:Button ID="scnBtnSaveEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_EN %>" OnClick="scnBtnSave_EN_Click" />
                            <asp:Button ID="scnBtnRbCacheEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_EN%>" OnClick="scnBtnRbCacheEn_Click" />
                            <asp:Button ID="scnBtnShowEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowEN_Click" />
                            <asp:Literal ID="scnMsbBoxEN" runat="server" Text=""></asp:Literal>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6" id="document-11es">
                            <div class="form-group">
                                <asp:Label ID="scnTitle_ES_tit" CssClass="fld-title" for="scnIsAuthorizeAll2" runat="server" Text="Titulo" ClientIDMode="Static"></asp:Label>
                                <asp:TextBox ID="scnTitle_ES" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="500" ClientIDMode="Static" Columns="80" Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6" id="document-11en">



                            <div class="form-group">
                                <asp:Label ID="scnTitle_EN_tit" CssClass="fld-title" for="scnTitle_EN" runat="server" Text="Title" ClientIDMode="Static"></asp:Label>
                                <asp:TextBox ID="scnTitle_EN" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="500" ClientIDMode="Static" Columns="80" Rows="2" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <!-- -------- END  ROW ---------- -->
                    <!-- -------- START ROW ---------- -->
                    <div class="row">
                        <div class="col-6" id="document-2es">
                            <div class="form-group">
                                <asp:Label ID="scnAbstract_ES_tit" CssClass="fld-title-inline" for="scnAbstract_ES" runat="server" Text="Abstract" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnAbstract_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px">   </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-6" id="document-2en">
                            <div class="form-group">
                                <asp:Label ID="scnAbstract_En_tit" CssClass="fld-title-inline" for="scnAbstract_EN" runat="server" Text="Abstract" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnAbstract_EN" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px">   </CKEditor:CKEditorControl>
                            </div>
                        </div>

                    </div>
                    <!-- -------- END  ROW ---------- -->
                    <!-- -------- START ROW ---------- -->
                    <div class="row">
                        <div class="col-6" id="document-3es">
                            <div class="form-group">
                                <asp:Label ID="scnBody_ES_tit" CssClass="fld-title-inline" for="scnBody_ES" runat="server" Text="Articulo" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnBody_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="col-6" id="document-3en">
                            <div class="form-group">
                                <asp:Label ID="scnBody_EN_tit" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="food" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnBody_EN" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
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
                                    <CKEditor:CKEditorControl ID="scnAcknoelegment_XX" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
                                </div>
                            </div>
                            <div class="col-6" id="document-4en">
                                <div class="form-group">
                                    <asp:Button ID="scnBtnBiblio_rebuild" runat ="server" CssClass="btn btn-primary btn-sm" Text="Rebuild from table" OnClick="scnBtnBiblio_rebuild_Click" />
                                    <asp:Label ID="scnBibliography_XX_Tit" CssClass="fld-title" runat="server" Text="Bibliografia - Bibiliography" ClientIDMode="Static"></asp:Label>
                                    <CKEditor:CKEditorControl ID="scnBibliography_XX" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
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
                <uc1:ctl_doc_edit runat="server" ID="scn_oDdoc_edit" />

            </div>
            <div id="menu2" class="container tab-pane fade">
                <div class="col-6" id="document-5es">
                    <h3>Español</h3>
                    <uc1:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_ES" />
                </div>
                <div class="col-6" id="document-5EN">
                    <h3>English</h3>
                    <uc1:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_EN" />
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
