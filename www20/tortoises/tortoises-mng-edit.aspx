<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site_Edit.Master" AutoEventWireup="true" CodeBehind="tortoises-mng-edit.aspx.cs" Inherits="testudines.tortoises.tortoise_mng_edit" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/a_ctl/ctl_imgfld.ascx" TagPrefix="uc1" TagName="ctl_imgfld" %>
<%@ Register Src="~/a_ctl/clt_scnAOth_UrlImages.ascx" TagPrefix="uc1" TagName="clt_scnAOth_UrlImages" %>

<%@ Register Src="~/a_ctl/ctl_doc_edit.ascx" TagPrefix="uc1" TagName="ctl_doc_edit" %>
<%@ Register Src="~/a_ctl/ctl_docLng_edit.ascx" TagPrefix="uc1" TagName="ctl_docLng_edit" %>


<%@ Register src="../a_ctl/clt_scnUrlGallery.ascx" tagname="clt_scnUrlGallery" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style>
        .tab-pane, .tab-content {
            margin: 0;
            width: 100%;
        }
        .fieldname { font-weight:bold; width: 140px;display:inline-block;
        }
        .field-title-inline {
            min-width: 160px;
        }

        .col-12 {
            padding: 0;
            margin: 0;
            width: 100%;
        }

        .img100pct {
            width: 100%;
            padding: 10px;
            border: 1px solid #aaa;
            border-radius: 5px;
            margin-left: 10px;
        }

        .tab-pane {
            margin: 0;
        }

        .tbWheather {
            width: 100%;
            border-spacing: 2px;
        }

            .tbWheather tr {
                background-color: #DDD;
            }

            .tbWheather th {
                text-align: center;
                font-weight: bold;
                background-color: #DDD;
            }
           
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContentBtns" runat="server">
    <asp:TextBox ID="scnIsPosBack" runat="server" Text="0" Visible="false" Enabled="false"></asp:TextBox>
    <div class="form-control">


        <div class="btn-group" role="group" aria-label="Basic example">
            <asp:Button ID="scnBtnNew" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_new %>" OnClick="scnBtnNew_Click" />
            <asp:Button ID="scnBtnListMng" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list_mng %>" OnClick="scnBtnListMng_Click" />
            <asp:Button ID="scnBtnList" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_list %>" OnClick="scnBtnList_Click" />
            &nbsp;|&nbsp;
                  <asp:Button ID="scnBtnSaveES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_ES %>" OnClick="scnBtnSaveES_Click" />
            <asp:Button ID="scnBtnRbCacheES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_ES%>" OnClick="scnBtnRbCacheES_Click" />
            <asp:Button ID="scnBtnShowES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowES_Click" />

            &nbsp;|&nbsp;   
                      <asp:Button ID="scnBtnHabClimateBldGraph" class="btn btn-primary btn-sm" runat="server" OnClick="scnBtnHabClimateBldGraph_Click"
                          Text="<%$ Resources:Strings, scnBtnHabClimateBldGraph %>" />
            <asp:Button ID="scnBtnSaveEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_EN %>" OnClick="scnBtnSave_EN_Click" />
            <asp:Button ID="scnBtnRbCacheEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_EN%>" OnClick="scnBtnRbCacheEn_Click" />
            <asp:Button ID="scnBtnShowEN" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowEN_Click" />

              <asp:Button ID="scnBtnBuildPdf" class="btn btn-primary btn-sm" runat="server" Text="Build Pdf" OnClick="scnBtnBuildPdf_Click" /><br />
               
            &nbsp;|&nbsp;
                <a href="https://www.linguee.es/espanol-ingles" class="btn btn-primary btn-sm" target="_blank"><span class="glyphicon glyphicon-random white"></span></a>

            &nbsp;<div class="row">
                <span class="fld-boxId ">Doc.Id.&nbsp;
                    <asp:Literal ID="scnDocId" runat="server" Text="0" ClientIDMode="Static"></asp:Literal></span>
                <asp:Literal ID="scnMsgBox" runat="server" Text=""></asp:Literal>
            </div>
        </div>


    </div>
    <!- ----------------- -->
     <!- MENU buttons end- -->
     <!- ----------------- -->
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
      
     <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False">
            <ContentTemplate>   
    <!- head fields -------------------->
    


             <div class="row">
                 <table>
                     <tr>
                         <td>
                             <asp:Label ID="scnATaxGrpL0001lNameFullRecomeded_XX_tit" CssClass="fld-title" for="scnTitle_XX" runat="server" Text="Titulo" ClientIDMode="Static"></asp:Label></td>
                         <td>
                             <asp:Label ID="scnXX_ATax_ItisTsn_Tit" CssClass="fld-title" for="scnXX_ATax_ItisTsn" runat="server" Text="ITIS tsn" ClientIDMode="Static"></asp:Label><asp:HyperLink ID="scnItisSearchBtn" runat="server" CssClass="ico-hlp" NavigateUrl="https://www.itis.gov/" Target="_blank"></asp:HyperLink></td>
                         <td>
                             <asp:Label ID="scnAOth_WorkFlow_IsRewrited_tit" CssClass="fld-title" for="scnAOth_WorkFlow_IsRewrited" runat="server" Text="Revised" ClientIDMode="Static"></asp:Label></td>
                         <td>
                             <asp:Label ID="Label18" CssClass="fld-title" for="scnXX_ATax_ItisTsn" runat="server" Text="Image Gallery" ClientIDMode="Static"></asp:Label>
                         </td>
                     </tr>


                     <tr>
                         <td>
                             <asp:TextBox ID="scnATaxGrpL0001lNameFullRecomeded_XX" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Style="max-width: 400px;" Width="400px" ClientIDMode="Static" Columns="120" Rows="1" TextMode="SingleLine"></asp:TextBox></td>
                         <td>
                             <asp:TextBox ID="scnXX_ATax_ItisTsn" CssClass="fld-textbox-inline" runat="server" MaxLength="150" placehoder="TSN ITIS" Width="80" ClientIDMode="Static" Columns="80" Rows="1" TextMode="Number"></asp:TextBox>
                         </td>
                         <td>
                             <asp:CheckBox ID="scnAOth_WorkFlow_IsRewrited" runat="server" CssClass="form-check-inline" Text="" /></td>
                         <td>
                             <uc2:clt_scnUrlGallery ID="scnAOth_UrlImages" runat="server" />
                         </td>
                     </tr>

                 </table>

                 <table>
                     <tr>
                         <td>
                             <asp:Label ID="scnTypeTit" for="scnType_" CssClass="fld-title" runat="server" Text="<%$ Resources:Strings, scnTypeTit %>"></asp:Label></td>
                         <td>
                             <asp:Label ID="scnTypeSubTit" runat="server" CssClass="fld-title" Text="<%$ Resources:Strings, scnTypeSubTit %>"></asp:Label></td>
                         <td>
                             <asp:Label ID="scnADngLevelCitesTit" CssClass="fld-title" runat="server" Text="<%$ Resources:Strings, scnADngLevelCitesTit %>"></asp:Label>
                             <a class="ico-hlp" href="http://checklist.cites.org/#/es/search/output_layout=alphabetical&level_of_listing=0&show_synonyms=1&show_author=1&show_english=1&show_spanish=1&show_french=1&scientific_name=testudines&page=1&per_page=20" title="Cites" target="_blank"></a></td>
                         <td>
                             <asp:Label ID="scnADngLevelRedListTit" runat="server" CssClass="fld-title" Text="<%$ Resources:Strings, scnADngLevelRedListTit %>"></asp:Label>
                             <a class="ico-hlp" href="http://www.iucnredlist.org/search" title="IUC RL" target="_blank"></a></td>
                     </tr>
                     <tr>
                         <td>
                             <asp:DropDownList ID="scnXX_DocTypeGroup" runat="server" CssClass="aspDropDownList" TabIndex="1" RepeatColumns="7" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="fil auto"></asp:ListItem>
                             </asp:DropDownList></td>
                         <td>
                             <asp:DropDownList ID="scnXX_DocTypeGroupSub" runat="server" CssClass="aspDropDownList" RepeatColumns="7" TabIndex="1" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="fill auto"></asp:ListItem>
                             </asp:DropDownList></td>
                         <td>
                             <asp:DropDownList ID="scnXX_ADngLevelCites" runat="server" CssClass="aspDropDownList">
                                 <asp:ListItem Value="No"></asp:ListItem>
                                 <asp:ListItem Value="I"></asp:ListItem>
                                 <asp:ListItem Value="II"></asp:ListItem>
                                 <asp:ListItem Value="III"></asp:ListItem>
                             </asp:DropDownList></td>

                         <td>
                             <asp:DropDownList ID="scnXX_ADngLevelRedList" runat="server" CssClass="aspDropDownList" AutoPostBack="True" OnSelectedIndexChanged="scnADngLevelRedList_SelectedIndexChanged">
                                 <asp:ListItem Value="scnDngLevelRedListTit">scnDngLevelRedListTit</asp:ListItem>
                             </asp:DropDownList>
                             <asp:Image runat="server" ID="scnXX_ADngLevelRedListImg" ImageUrl="/a_img/iucn/UICNRL_0es.png" /></td>
                     </tr>
                 </table>
             </div>



    <!- MENU TABS bar -------------------->
    <!- MENU TABS bar -------------------->
    <!- MENU TABS bar -------------------->
    <!- MENU TABS bar -------------------->     

    <div class="row">
    <ul class="nav nav-tabs" role="tablist" id="tabManager">
        <li class="nav-item active"><a class="nav-link" href="#tababst" role="tab" data-toggle="tab">Abstract</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabdesc" role="tab" data-toggle="tab">Descripcion</a></li>
        <li class="nav-item"><a class="nav-link" href="#tablive" role="tab" data-toggle="tab">Hist. Natural</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabcare" role="tab" data-toggle="tab">Cuidados</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabrange" role="tab" data-toggle="tab">Distribution</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabclima" role="tab" data-toggle="tab">Climate</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabtaxo" role="tab" data-toggle="tab">Taxonomy</a></li>
        <li class="nav-item"><a class="nav-link" href="#tabbibl" role="tab" data-toggle="tab">Bibl. Ackow </a></li>
        <li class="nav-item"><a class="nav-link" href="#tabdoc" role="tab" data-toggle="tab">Main Doc </a></li>
        <li class="nav-item"><a class="nav-link" href="#tabdocLng" role="tab" data-toggle="tab">Meta Lng </a></li>
        <li class="nav-item"><a class="nav-link" href="#tabPdf" role="tab" data-toggle="tab">Show PDF</a></li>
    </ul>
          </div>
            
    <!-- ----------------- -->
    <!-- Tab panes divs    -->
    <!-- ----------------- -->
    <div class="tab-content">
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- Tab panes  abstract-->
        <!-- ----------------- -->
        <div id="tababst" role="tabpanel" class="tab-pane active col-12" aria-selected="true">

            <div class="row">
                <div class="col-6">
                    <asp:Literal ID="scnES_LTaxNameVulgarTit" runat="server" Text="Nombre vulgar"></asp:Literal>
                    <asp:TextBox ID="scnES_LTaxNameVulgar" runat="server" Width="350px" Text="" Placeholder="Nombre vulgar" MaxLength="150" Rows="1"></asp:TextBox>
                </div>
                <div class="col-6">
                    <asp:Literal ID="Literal1" runat="server" Text="Vulgar Namer"></asp:Literal>
                    <asp:TextBox ID="scnEN_LTaxNameVulgar" runat="server" Width="350px" Text="" Placeholder="Vulgar Name" MaxLength="150" Rows="1"></asp:TextBox>
                </div>

            </div>

            <div class="row">
                <div class="col-6" id="document-2es">
                    <div class="form-group">
                        <asp:Label ID="scnXX_AAbsImg_Specie_ES_tit" CssClass="fld-title-inline" for="scnAbstract_ES" runat="server" Text="Descripcion " ClientIDMode="Static"></asp:Label>
                        <uc1:ctl_imgfld ID="scnXX_AAbsImg_Specie" runat="server" Width="600px" ClientIDMode="Static" />

                    </div>
                </div>
                <div class="col-6" id="document-2en">
                    <div class="form-group">
                        <asp:Label ID="scnXX_AAbsImg_Specie_En_tit" CssClass="fld-title-inline" for="scnAbstract_EN" runat="server" Text="Description" ClientIDMode="Static"></asp:Label><br />
                        <asp:Image ID="scnXX_AAbsImg_Specie2" ImageUrl="/a_img/noimage600px.png" Width="600px" runat="server" ClientIDMode="Static" />

                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LAbsDes" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LAbsDes" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- -------- END  ROW ---------- -->
            <!-- -------- START ROW ABS HISTORIA NATURAL -->
            <div class="row">
                <div class="col-6" id="document-3es">

                    <div class="form-group">

                        <asp:Label ID="scnBody_ES_tit" CssClass="fld-title-inline" for="scnBody_ES" runat="server" Text="Historia Natural" ClientIDMode="Static"></asp:Label>
                        <uc1:ctl_imgfld ID="scnXX_AAbsImg_HNatural" runat="server" Width="600px" ClientIDMode="Static" />


                    </div>
                </div>
                <div class="col-6" id="document-3en">

                    <div class="form-group">
                        <asp:Label ID="scnBody_EN_tit" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="Natural history" ClientIDMode="Static"></asp:Label>

                        <asp:Image ID="scnXX_AAbsImg_HNatural2" ImageUrl="/a_img/noimage600px.png" Width="600px" runat="server" ClientIDMode="Static" />

                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-6" id="document-33es">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LAbsHisNat" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>

                </div>
                <div class="col-6" id="document-33en">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LAbsHisNat" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>

                </div>

            </div>
            <!-- -------- END  ROW ---------- -->
            <!-- -------- START ROW ---------- -->
            <div class="row">
                <div class="col-6" id="document-32es">
                    <div class="form-group">

                        <asp:Label ID="Label1" CssClass="fld-title-inline" for="scnBody_ES" runat="server" Text="Rango distribucion" ClientIDMode="Static"></asp:Label>
                        <uc1:ctl_imgfld ID="scnXX_AAbsImg_Range" runat="server" Width="600px" ClientIDMode="Static" />

                    </div>
                </div>
                <div class="col-6" id="document-32en">
                    <div class="form-group">
                        <asp:Label ID="Label2" CssClass="fld-title-inline" for="scnBody_EN" runat="server" Text="Distribuion range" ClientIDMode="Static"></asp:Label>
                        <asp:Image ID="scnXX_AAbsImg_Range2" ImageUrl="/a_img/noimage600px.png" Width="600px" runat="server" ClientIDMode="Static" />


                    </div>
                </div>

            </div>
            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LAbsRngHab" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LAbsRngHab" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px" MaxLength="320">   </CKEditor:CKEditorControl>
                </div>
            </div>

        </div>
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- Tab desc  abstract-->
        <!-- ----------------- -->
        <div id="tabdesc" role="tabpanel" class="tab-pane   col-12">

            <div class="row">
                <h3>Imagenes type 45º</h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_DesType01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_DesType02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_DesType03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>
            <div class="row">
                <div class="form-group col-6">
                    <asp:Label ID="scnXX_ADesMeasureLenghtCmTit" runat="server" CssClass="fieldtitall_inline" Text="<%$ Resources:Strings, scnADesMeasureLenghtCmTit %>"> </asp:Label>
                    <asp:TextBox ID="scnXX_ADesMeasureLenghtCm" Style="display: inline;" runat="server" CssClass="taxfield" Width="5em" Rows="8" MaxLength="8" BorderStyle="Groove" BorderWidth="1px"></asp:TextBox>


                </div>
                <div class="form-group col-6">
                    <asp:Label ID="scnXX_ADesMeasureWeightGrmTit" runat="server" CssClass="fieldtitall_inline" Text="<%$ Resources:Strings, scnADesMeasureWeightGrmTit %>"> </asp:Label>
                    <asp:TextBox ID="scnXX_ADesMeasureWeightGrm" Style="display: inline;" runat="server" CssClass="taxfield" Width="5em" Rows="8" MaxLength="8"></asp:TextBox>
                </div>
            </div>



            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LDesAbstract" runat="server" MaxLength="500"
                        Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LDesAbstract" runat="server" MaxLength="500"
                        Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>

                </div>

                <!-- ------ -->
                <!--  DESCRIPCION dorsal  -------------------- -->
                <div class="row">
                    <h3>Vista dorsal</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyDorsal01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyDorsal02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyDorsal03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6" id="tabdesc-10ES">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewDorsal" runat="server" MaxLength="500"
                            Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6" id="tabdesc-10EN">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                        <CKEditor:CKEditorControl ID="scnEN_LDesViewDorsal" runat="server" MaxLength="500"
                            Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>

                    </div>
                </div>
                <!--  DESCRIPCION ventral  -------------------- -->
                <div class="row">
                    <h3>Vista ventral</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyVentral01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyVentral02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyVentral03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <h3>Vista puente</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyBridge01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyBridge02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyBridge03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">

                    <div class="col-6" id="tabdesc-20ES">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewVentralBridge" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6" id="tabdesc-20EN">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                        <CKEditor:CKEditorControl ID="scnEN_LDesViewVentralBridge" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  -------------------- -->
                <!--  DESCRIPCION lateral  -------------------- -->
                <div class="row">
                    <h3>Vista lateral</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyLateral01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyLateral02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyLateral03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewLateral" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesViewLateral" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  -------------------- -->
                <!--  DESCRIPCION frontal  -------------------- -->
                <div class="row">
                    <h3>Vista frontal</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyFrontal01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyFrontal02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyFrontal03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewFrontal" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesViewFrontal" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  -------------------- -->
                <!--  DESCRIPCION posterior  -------------------- -->
                <div class="row">
                    <h3>Vista posterior</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyRear01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyRear02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BodyRear03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewRear" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesViewRear" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  -------------------- -->
                <!--  DESCRIPCION cabeza y cuello  -------------------- -->
                <div class="row">
                    <h3>Vista cabeza y cuello</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherHead01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherHead02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherHead03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewHeadNeck" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesViewHeadNeck" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>

                <!--  -------------------- -->
                <!--  DESCRIPCION  patas y cola  -------------------- -->
                <div class="row">
                    <h3>Patas y cola</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherLegs01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherLegs02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherLegs03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherTail01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherTail02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_OtherTail03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesViewLegsTail" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesViewLegsTail" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  DESCRIPCION  interna  -------------------- -->
                <div class="row">
                    <h3>descripcion interna</h3>
                    <div class="row">
                        <h3>Descripcion interna</h3>
                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Internal01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Internal02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Internal03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                    </div>
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesInternal" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesInternal" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>

                <!--  -------------------- -->
                <!--  DESCRIPCION  babys  -------------------- -->
                <div class="row">
                    <h3>Crias y juveniles</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyDorsal01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyDorsal02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyDorsal03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyVentral01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyVentral02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_BabyVentral03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesBabys" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesBabys" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>

                <!--  DESCRIPCION  dimorfismo -------------------- -->
                <div class="row">
                    <h3>Dimorfismo</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Dimorphism01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Dimorphism02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Dimorphism03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>

                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesDimorphism" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesDimorphism" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!--  DESCRIPCION  diferenciacion de otras especies -------------------- -->
                <div class="row">
                    <h3>Diferenciacion de otras especies similares</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Diferentiation01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Diferentiation02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Diferentiation03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesDiferentiation" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">

                        <CKEditor:CKEditorControl ID="scnEN_LDesDiferentiation" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!-- -------------------------------- -->
                <!--  DESCRIPCION  claves de identificacion   -------------------- -->
                <div class="row">
                    <h3>Vista Claves para su identificacion</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_IdentKeys01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_IdentKeys02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_IdentKeys03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesKeys" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesKeys" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>



                <!-- -------------------------------- -->
                <!--  DESCRIPCION  HOLOTIPO  -------------------- -->
                <div class="row">
                    <h3>Vista Holotipo</h3>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Holotype01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Holotype02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                    <div class="col-4">
                        <uc1:ctl_imgfld runat="server" ID="scnXX_ADesImg_Holotype03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesHolotype" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesHolotype" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>
                <!-- -------------------------------- -->
                <!--  notas   -------------------- -->

                <div class="row">
                    <h3>Notas</h3>
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LDesNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LDesNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>




                <!--  -------------------- -->
            </div>

        </div>
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- Tab panes  live-->
        <!-- ----------------- -->
        <div id="tablive" role="tabpanel" class="tab-pane fade  col-12">
            <h3>Historia natural</h3>
            imagenes de su vida en habitat natural
                    <div class="row">

                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Live01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Live02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                        <div class="col-4">
                            <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Live03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                        </div>
                    </div>
            <div class="row">
                <h3>Descripcion de Medio natural </h3>
                <asp:Label ID="scnALiveMediaKeyTit" runat="server" CssClass="fieldtitall_inline " Text="<%$ Resources:Strings, scnALiveMediaTypeTit %>"> </asp:Label>
                <asp:DropDownList ID="scnXX_AKeyNaturalMedia" runat="server" CssClass="aspDropDownList">
                    <asp:ListItem Text="<%$ Resources:Strings, terrestrial %>" Value="Terrestrial"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, freshwater %>" Value="Freshwater">
                    </asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, sea %>" Value="Sea">
                    </asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, unknown %>" Value="unknown">
                    </asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, no_select %>" Value="no_select">
                    </asp:ListItem>
                </asp:DropDownList>

            </div>

            <div class="row">
                <h3>Habitat</h3>
                imagenes del paisaje del medio natural.
                            <div class="row">
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_AGeoImg_landscapes01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_AGeoImg_landscapes02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_AGeoImg_landscapes03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                            </div>
            </div>





            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuMediaType" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LNatuMediaType" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- -------------- -->
            <div class="row">

                <h3>
                    <asp:Label ID="scnLNatuLifestylesTit" CssClass="fieldtitall " runat="server" Text="<%$ Resources:Strings, scnLNatuLifestylesTit %>"></asp:Label></h3>
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuLifestyles" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>


                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LNatuLifestyles" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>

            <!-- ----- -->

            <div class="row">
                <h3>Alimentacion</h3>
                <asp:Label ID="Label4" runat="server" CssClass="fieldtitall_inline " Text="<%$ Resources:Strings, scnALiveFoodKeyTit %>"> </asp:Label>

                <asp:Label ID="scnALiveFoodKeyTit" runat="server" CssClass="fieldtitall_inline " Text="<%$ Resources:Strings, scnALiveFoodKeyTit %>"> </asp:Label>
                <asp:DropDownList ID="scnXX_AKeyNaturalFood" runat="server" CssClass="aspDropDownList">
                    <asp:ListItem Text="<%$ Resources:Strings, herbivore %>" Value="herbivore"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, omnivore %>" Value="omnivore"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, omnivore_dominant_hervivore %>" Value="omnivoredominanthervibore"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, omnivore__dominant_carnivore %>" Value="omnivoredominantcarnivore"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, carnivore %>" Value="carnivore"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, unknown %>" Value="unknown">
                    </asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:Strings, no_select %>" Value="no_select"></asp:ListItem>
                </asp:DropDownList>
            </div>



            <div class="row">
                <h3>Habitat</h3>
                imagenes Alimentacion o alimentos en la naturaleza
                            <div class="row">
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Food01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Food02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                                <div class="col-4">
                                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Food03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                                </div>
                            </div>
            </div>








            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuFoodChain" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LNatuFoodChain" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>





            </div>
            <!-- ---------------- resproduccion -->
            <div class="row">
                <h3>
                    <asp:Label ID="Label3" CssClass="fieldtitall " runat="server" Text="<%$ Resources:Strings, scnLNatuBreedingTit %>"></asp:Label></h3>

                <asp:Literal runat="server" ID="scnXX_ANatuKeyBreedingTit" Text="Reproduccion"></asp:Literal>
                <asp:TextBox ID="scnXX_ANatuKeyBreeding" runat="server" Enabled="false" Text="oviparous" Rows="1" Columns="30"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Breeding01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Breeding02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ANatImg_Breeding03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>
            <div class="row">

                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuBreeding" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>

                    <CKEditor:CKEditorControl ID="scnEN_LNatuBreeding" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- proteccion--------- -->
            <div class="row">
                <h3>
                    <asp:Label ID="scnLDnglProActionsTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLDangerProActionsTit %>"></asp:Label></h3>
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuProAction" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LNatuProAction" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- notes -->
            <div class="row">
                <h3>
                    <asp:Label ID="scnLNatuNotesTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLiveNotesTit %>"></asp:Label></h3>
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LNatuNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LNatuNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>

        </div>
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- Tab panes  tabcare-->
        <!-- ----------------- -->
        <div id="tabcare" role="tabpanel" class="tab-pane fade col-12">

            <h2>
                <asp:Label ID="scnLAbsCareTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLAbsCareTit %>"></asp:Label></h2>
            <!-- ----- -->
            <div class="row">
                <h3>Cuidados</h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_gral01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_gral02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_gral03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>


            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LAbsCare" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LAbsCare" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->
            <div class="row">
                <h3>
                    <asp:Label ID="scnLCareValuesTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLCareValuesTit %>"></asp:Label></h3>
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareValues" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareValues" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->
            <div class="row">
                <h3>
                    <asp:Label ID="scnLCareVivariumIndoorTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLCareVivariumIndoorTit %>"> </asp:Label></h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumIndoor01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumIndoor02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumIndoor03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>


            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareVivariumIndoor" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareVivariumIndoor" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- outdoor -->

            <div class="row">
                <h3>
                    <asp:Label ID="Label16" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLCareVivariumIndoorTit %>"> </asp:Label></h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumOutdoor01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumOutdoor02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_VivariumOutdoor03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>


            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareVivariumOutdoor" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareVivariumOutdoor" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->
            <!-- food -->

            <div class="row">
                <h3>
                    <asp:Label ID="scnLCareFoodTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLCareFoodTit %>"></asp:Label></h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Food01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Food02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Food03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>


            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareFood" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareFood" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>

            <!-- breding -->

            <div class="row">
                <h3>
                    <asp:Label ID="scnLCareBreedingTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLCareBreedingTit %>"></asp:Label></h3>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Breeding01" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Breeding02" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
                <div class="col-4">
                    <uc1:ctl_imgfld runat="server" ID="scnXX_ACareImg_Breeding03" ImageNoImageUrl="/a_img/noimage200px.png" Width="195px" />
                </div>
            </div>


            <div class="row">
                <h3>Breading</h3>
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareBreeding" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareBreeding" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->
            
                   <div class="row">
                       
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LCareEspecialist" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LCareEspecialist" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- notes -->

            <div class="row">
                <h3>
                    <asp:Label ID="scnLCareNotesTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnLCareNotesTit %>"></asp:Label></h3>

                <div class="row">
                    <div class="col-6">
                        <h3>Español</h3>
                        <CKEditor:CKEditorControl ID="scnES_LCareNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                    <div class="col-6">
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <CKEditor:CKEditorControl ID="scnEN_LCareNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                    </div>
                </div>

            </div>
        </div>
        <!-- ----------------- -->
        <!-- Tab panes  tabrange-->
        <!-- ----------------- -->
        <div id="tabrange" role="tabpanel" class="tab-pane fade col-12">
            <h3>Distribucion  y ecosistemas </h3>
            Localizacion tipo:
            <asp:TextBox ID="scnXX_AGeoLocation" runat="server" Text=""></asp:TextBox>
            <div class="row col-12">
                <div class="col-6">
                    <h3>Mapa mundi</h3>
                    <uc1:ctl_imgfld ID="scnXX_AGeoImg_GeoRangeMapStandardWorldFul" runat="server" Width="600px" ClientIDMode="Static" />
                </div>
                <div class="col-6">
                    <asp:Label ID="Label5" CssClass="fld-title-inline" for="scnAbstract_EN" runat="server" Text="Description" ClientIDMode="Static"></asp:Label><br />
                    <asp:Image ID="scnXX_AGeoImg_GeoRangeMapStandardWorldFul2" ImageUrl="/a_img/noimage600px.png" Width="496" runat="server" ClientIDMode="Static" />
                </div>
            </div>

            <div class="row">
                <h3>Mapa detallado</h3>
                <div class="row col-12">
                    <div class="col-6">
                        <uc1:ctl_imgfld ID="scnXX_AGeoImg_GeoRangeMapStandardDetailFul" runat="server" Width="600px" ClientIDMode="Static" />
                    </div>
                    <div class="col-6">
                        <asp:Image ID="scnXX_AGeoImg_GeoRangeMapStandardDetailFul2" ImageUrl="/a_img/noimage600px.png" Width="496" runat="server" ClientIDMode="Static" />
                    </div>
                </div>

                <asp:Label ID="scnTraLHabGeoEcoBiogeographicRegion" runat="server" Text="fill on load"></asp:Label>
                <div class="col-12">
                    <asp:Label ID="scnLHabGeoEcoRegionTit" CssClass="fieldtitlng" runat="server" Text="<%$ Resources:Strings, scnAGeoEcoBiogeographicRegionTit %>"></asp:Label>
                    <asp:Label runat="server" ID="Label17" Text="<%$ Resources:Strings, scnImgHisHabitatTit %>"></asp:Label>

                    <asp:Label ID="scnAGeoEcoBiogeographicRegionTit" runat="server" CssClass="fieldtitlng_inline  "
                        Style="width: 20em;" Text="<%$ Resources:Strings, scnAGeoEcoBiogeographicRegionTit %>"></asp:Label>
                    <asp:DropDownList ID="scnXX_AGeoKeyGeoBiogeographicRegion" runat="server" CssClass="aspDropDownList">
                        <asp:ListItem Text="Neartic" Value="Neartic"></asp:ListItem>
                        <asp:ListItem Text="Neotropical" Value="Neotropical"></asp:ListItem>
                        <asp:ListItem Text="Afrotropical" Value="Afrotropical"></asp:ListItem>
                        <asp:ListItem Text="Indo-Malayan" Value="Indo-Malayan"></asp:ListItem>
                        <asp:ListItem Text="Australasia" Value="Australasia"></asp:ListItem>
                        <asp:ListItem Text="Oceania" Value="Oceania"></asp:ListItem>
                        <asp:ListItem Text="Antartid" Value="Antartid"></asp:ListItem>
                        <asp:ListItem Text="Oceans*" Value="Oceans*"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--   --------------------   -->
            <div class="row">
                <h3>
                    <asp:Label ID="scnLHabEcozoneTit" CssClass="fieldtitlng " runat="server" Text="<%$ Resources:Strings, scnLHabEcozoneTit %>"></asp:Label></h3>

                <div class="col-6">
                    <h3>Español</h3>

                    <CKEditor:CKEditorControl ID="scnES_LHabEcozone" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LHabEcozone" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->
            <div class="row">
              <h3><asp:Label ID="scnLHabGeoEcoBiogeographicRegionTit" CssClass="fieldtitall " runat="server" Text="<%$ Resources:Strings, scnLHabGeoEcoBiogeographicRegion %>"></asp:Label></h3>

                <div class="col-6">
                    <h3>Español</h3>
                
                    <CKEditor:CKEditorControl ID="scnES_LHabGeoEcoBiogeographicRegion" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LHabGeoEcoBiogeographicRegion" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->



            <div class="row">

                <asp:Label ID="scnXX_AGeoKeyContinentTit" runat="server" CssClass="fieldtitall_inline "
                    Style="width: 20em;" Text="<%$ Resources:Strings, scnAGeoKeyContinentTit %>"></asp:Label>
                <asp:DropDownList runat="server" CssClass="aspDropDownList" ID="scnXX_AGeoKeyContinent">
                    <asp:ListItem Text="Europe" Value="Europe"></asp:ListItem>
                    <asp:ListItem Text="America North" Value="america_north"></asp:ListItem>
                    <asp:ListItem Text="America south" Value="america_south"></asp:ListItem>
                    <asp:ListItem Text="Africa" Value="africa"></asp:ListItem>
                    <asp:ListItem Text="Asia" Value="asia">
                    </asp:ListItem>
                    <asp:ListItem Text="Oceania" Value="oceania">
                    </asp:ListItem>
                    <asp:ListItem Text="Ocean" Value="ocean">
                    </asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="row">
                <h3>Claves de los paises</h3>

                <input type="button" class="btn-tiny" value="Set paises" onclick="OpenDlgChildCountries()" />
                <asp:TextBox ID="scnXX_AGeoCountriesNamesTxt" CssClass="taxfield" runat="server"
                    Height="50px" TextMode="MultiLine" ClientIDMode="Static" Columns="70"></asp:TextBox>
                <asp:TextBox ID="scnXX_AGeoKeyCountries" CssClass="taxfield" runat="server" Height="50px"
                    TextMode="MultiLine" ClientIDMode="Static" Columns="70"></asp:TextBox><br />



            </div>

            <div class="row">
                <h3>><asp:Label ID="scnTitEcologic" CssClass="fieldtitall" runat="server" Text="Notas distribucion en paises>"></asp:Label></h3>
            </div>
            <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl ID="scnES_LHabGeoCountryNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl ID="scnEN_LHabGeoCountryNotes" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical"></CKEditor:CKEditorControl>
                </div>
            </div>
            <!-- ---- -->

            <div class="row">
                <asp:Label ID="scnLDngDangerNotesTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLDngDangerNotesTit %>"></asp:Label>
                <div class="row">
                <div class="col-6">
                    <h3>Español</h3>
                    <CKEditor:CKEditorControl
                        ID="scnES_LNatuDangers" runat="server" MaxLength="500" Toolbar="Basic" Width=""
                        TextMode="MultiLine"></CKEditor:CKEditorControl><br />
                </div>
                <div class="col-6">
                    <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                    <CKEditor:CKEditorControl
                        ID="scnEN_LNatuDangers" runat="server" MaxLength="500" Toolbar="Basic" Width=""
                        TextMode="MultiLine"></CKEditor:CKEditorControl><br />
                </div>
                </div>
            </div>
        </div>
        <!-- ----------------- -->
        <!-- Tab panes  tabclima-->
        <!-- ----------------- -->
        <div id="tabclima" role="tabpanel" class="tab-pane fade col-12">

                 
                    <h3>Clima </h3>
                    <div class="row">
                        <h3>
                            <asp:Label ID="scnXX_AAbsHabClimateEcozoneKeyTit" CssClass="fieldtitall_inline" runat="server" Text="<%$ Resources:Strings, scnAGeoEcoZonesClimateKeyTit %>"></asp:Label></h3>

                        <div class="form-group row">
                            <asp:Label ID="Label13" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnAAbsEcozoneTit %>"> </asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="TextBox1" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox><br />
                            </div>
                        </div>

                        <div class="form-group row">
                            <div class="col-sm-6">
                                <asp:Image ID="scnXX_AGeoImg_ClimateEcozoneKey" runat="server" ImageUrl="/a_img/noimage200px.png" />
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="scnXX_AGeoKeyClimateEcozone" runat="server" AutoPostBack="True" CssClass="aspDropDownList " OnSelectedIndexChanged="scnEcozoneListCode_SelectedIndexChanged">
                                    <asp:ListItem>fill ecozones</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button CssClass="btn-tiny" runat="server" ID="scnXX_AAbsEcozone_BtnOverWrite" Text="<%$ Resources:Strings, scnAAbsEcozone_BtnOverWrite %>" OnClick="scnBtnsEcozoneListCodeOverWrite_Click" ClientIDMode="Static" />
                            </div>
                        </div>


                    </div>
                    <!-- ---           -->
                    <div class="row">

                        <table style="width: 450px;">
                            <tr>
                                <td colspan="2">Help
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 50%;">FAO
                                </td>
                                <td style="width: 50%;">R.Baley USGR
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <ul>
                                        <li><a href="/a_files/help_docs/Ecozones_FAO.pdf" target="_blank" ico="hlp">Fao Pdf</a>
                                        </li>
                                        <li><a href="/a_files/help_docs/fao_africa.jpg" title="Africa" target="_blank" ico="hlp">Africa</a> </li>
                                        <li><a href="/a_files/help_docs/fao_american.jpg" title="America N" target="_blank"
                                            ico="hlp">America N</a> </li>
                                        <li><a href="/a_files/help_docs/fao_americas.jpg" title="America N" target="_blank"
                                            ico="hlp">America S</a> </li>
                                        <li><a href="/a_files/help_docs/fao_asian.jpg" title="Asian N" target="_blank" ico="hlp">Asia N</a> </li>
                                        <li><a href="/a_files/help_docs/fao_asias.jpg" title="Asian S" target="_blank" ico="hlp">Asia S</a> </li>
                                        <li><a href="/a_files/help_docs/fao_europa.jpg" title="Europa" target="_blank" ico="hlp">Europe</a> </li>
                                        <li><a href="/a_files/help_docs/fao_oceania.jpg" title="Asian N" target="_blank"
                                            ico="hlp">Oceania</a></li>
                                    </ul>
                                </td>
                                <td>
                                    <ul>
                                        <li>
                                            <li><a href="/a_files/help_docs/Ecozones_USGR_01.jpg" target="_blank" ico="hlp">Wolrd</a></li>
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                        </table>

                    </div>

                    <!-- ------- -->
                    <div class="row">
                        <h3>
                            <asp:Label ID="titMapStandardKoppen" CssClass="fieldtitall" runat="server" Text="<%$ Resources:Strings, scnMapStandardKoppen %>"></asp:Label></h3>

                        <uc1:ctl_imgfld ID="scnXX_AGeoImg_GeoRangeMapStandardKoppenFul" runat="server" Width="600px" ImageNoImageUrl="/a_img/noimage600px.png"></uc1:ctl_imgfld>
                    </div>
                    <div class="row">
                        <h3>
                            <asp:Label ID="scnTraLAbsHabClimateEcozone" runat="server"></asp:Label></h3>
                        <div class="col-6">
                            <CKEditor:CKEditorControl ID="scnES_LAbsHabClimateEcozone" runat="server" MaxLength="250"
                                Toolbar="Basic" ResizeDir="Vertical" TextMode="MultiLine"></CKEditor:CKEditorControl>
                        </div>
                        <div class="col-6">
                            <CKEditor:CKEditorControl ID="scnEN_LAbsHabClimateEcozone" runat="server" MaxLength="250"
                                Toolbar="Basic" ResizeDir="Vertical" TextMode="MultiLine"></CKEditor:CKEditorControl>
                        </div>
                    </div>
                    <!-- ------- --->

                    <div class="form-group row">
                        <asp:Label ID="scnXX_AGeoClimateWheatherLocationTit" runat="server" CssClass="col-sm-2 col-form-label" Text="Location"> </asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="scnXX_AGeoClimateWheatherLocation" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox><br />
                        </div>
                    </div>
                    <!-- .. -->
                    <div class="row">
                        <h3>
                            <asp:Label ID="scnLHabClimateEcozoneTit" CssClass="fieldtitall " runat="server" Text="<%$ Resources:Strings, scnLHabClimateEcozoneTit %>"></asp:Label></h3>
                        <div class="col-6">
                            <CKEditor:CKEditorControl ID="scnES_LGeoClimate" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical" TextMode="MultiLine" Width=""></CKEditor:CKEditorControl>
                        </div>
                        <div class="col-6">
                            <CKEditor:CKEditorControl ID="scnEN_LGeoClimate" runat="server" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical" TextMode="MultiLine" Width=""></CKEditor:CKEditorControl>
                        </div>
                    </div>

                    <!-- ... -->
                    <div class="form-group row">
                        <asp:Label ID="scnXX_AGeoLatidudGeographic" runat="server" CssClass="col-sm-2 col-form-label" Text="Geographic coordinates"> </asp:Label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="TextBox2" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox><br />
                        </div>
                    </div>

                    <!-- ... -->
                    <div class="form-group row">
                        <asp:Label ID="scnXX_AGeoLocLatitudMinTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnAGeoLocLatitudMinTit %>"> </asp:Label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="scnXX_AGeoLocLatitudMin" Width="5em" Rows="5" MaxLength="5" CssClass="taxfield"  Text="0" runat="server" TextMode="Number"></asp:TextBox><br />
                        </div>
                        <asp:Label ID="scnXX_AGeoLocLatitudMaxTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnAGeoLocLatitudMaxTit %>"> </asp:Label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="scnXX_AGeoLocLatitudMax" Width="5em" Rows="5" MaxLength="5" CssClass="taxfield" Text="0" runat="server" TextMode="Number"></asp:TextBox><br />
                        </div>

                    </div>
                    <div class="row">
                        <img src="/a_img/hlp_descr/mapa-wold-lattituds.png" style="max-width: 100%" />

                    </div>
                    <!-- ----- -->

                    <div class="row">
                        <h3><asp:Label ID="scnscnAGeoClimateWheatherSectionTit" runat="server" Text="<%$ Resources:Strings, scnAGeoClimateWheatherSectionTit %>"></asp:Label></h3>

                        <div class="form-group row">
                            <asp:Label ID="scnXX_AGeoClimateTableLocationTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnAGeoClimateLocationTypeTit %>"></asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="scnXX_AGeoClimateTableLocation" CssClass="taxfield" Width="25em" MaxLength="50" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>

                    <div class="row">
                         <a href="http://www.weatherbase.com" title="www.weatherbase.com" target="_blank">www.weatherbase.com go</a>
                       
                        
                       Datasource Name <asp:TextBox ID="scnXX_AGeoClimateTableUrlTit" runat="server" Text="" Rows="1" placeholder="Name data source (wheaterbase"></asp:TextBox>
                       Datasource url  <asp:TextBox ID="scnXX_AGeoClimateTableUrlUrl" runat="server" Text="" Rows="1" placeholder="URL data source name"></asp:TextBox>
                    </div>
                    <table class="tbWheather">
                        <thead>
                            <tr>
                                <th colspan="2">titles</th>
                                <th colspan="12">month</th>
                                <th colspan="4">Year Average</th>
                                <tr>
                                    <th>Title</th>
                                    <th>Check</th>

                                    <th>01</th>
                                    <th>02</th>
                                    <th>03</th>
                                    <th>04</th>
                                    <th>05</th>
                                    <th>06</th>
                                    <th>07</th>
                                    <th>08</th>
                                    <th>09</th>
                                    <th>10</th>
                                    <th>11</th>
                                    <th>12</th>
                                    <th>Sum</th>
                                    <th>Min</th>
                                    <th>Avg</th>
                                    <th>Max</th>
                                </tr>
                        </thead>
                        <tr>
                            <td><b>Temp. Min Cº</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AGeoDrawTempMin" runat="server" Checked="false" />
                            </td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin01" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin02" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin03" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin04" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin05" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin06" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin07" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin08" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin09" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin10" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin11" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin12" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"></asp:TextBox></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin_YY_Min" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin_YY_Avg" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMin_YY_Max" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                        </tr>











                        <tr>
                            <td><b>Temp. Max Cº</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AGeoDrawTempMax" runat="server" Checked="false" /></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax01" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax02" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax03" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax04" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax05" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax06" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax07" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax08" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax09" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax10" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax11" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax12" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax_YY_Min" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax_YY_Avg" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpMax_YY_Max" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                        </tr>


                        <tr>
                            <td><b>Temp. Avg Cº</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AGeoDrawTempAvg" runat="server" Checked="false"   /></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg01" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg02" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg03" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg04" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg05" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg06" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg07" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg08" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg09" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg10" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg11" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg12" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" ></asp:TextBox></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg_YY_Min" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg_YY_Avg" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoTmpAvg_YY_Max" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Rain ML</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AGeoDrawRainML" runat="server" Checked="false" /></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML01" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML02" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML03" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML04" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML05" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML06" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML07" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML08" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML09" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML10" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML11" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML12" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainMLYear" runat="server" MaxLength="6" Width="4em" TextMode="Number"> Text ="0" Enabled="false"></asp:TextBox></td>

                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML_YY_Min" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML_YY_Avg" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainML_YY_Max" runat="server" MaxLength="6" Width="4em" TextMode="Number">  Text ="0" Enabled="false"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Rain days</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AGeoDrawRainDays" runat="server" Checked="false" /></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays01" runat="server" MaxLength="6"  Text ="0"  Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays02" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays03" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays04" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays05" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays06" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays07" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays08" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays09" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays10" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays11" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays12" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number">></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDaysYear" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays_YY_Min" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays_YY_Avg" runat="server" MaxLength="6"  Text ="0" Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoRainDays_YY_Max" runat="server" MaxLength="6" Text ="0"  Width="4em" TextMode="Number"> Enabled="false"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Sun hours Min</b></td>
                            <td>
                                <asp:CheckBox ID="scnXX_AAGeoDrawSun" runat="server" Checked="false" /></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin01" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin02" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin03" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin04" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin05" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin06" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin07" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin08" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin09" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin10" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin11" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin12" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin12Year" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin_YY_Min" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin_YY_Avg" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"  ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMin_YY_Max" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"  ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><b>Sun max hour</b></td>
                            <td>
                                    <asp:CheckBox ID="scnXX_AGeoSunMaxChk" runat="server" Checked="false" />
                               
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax01" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax02" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax03" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax04" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax05" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax06" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax07" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax08" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax09" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax10" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax11" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax12" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMaxYear" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax_YY_Min" runat="server" MaxLength="6"  Text ="0" Width="4em" ReadOnly="true" ></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax_YY_Avg" runat="server" MaxLength="6" Text ="0"  Width="4em" ReadOnly="true"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="scnXX_AGeoSunMax_YY_Max" runat="server" MaxLength="6" Text="0" Width="4em" ReadOnly="true"  ></asp:TextBox></td>
                        </tr>
                    </table>





                    <!-- ----- -->
                    <div class="row">

                        <h2>
                            <asp:Label ID="scnXX_AGeoClimateWeatherImgTit" runat="server" Text="<%$ Resources:Strings, scnAGeoClimateWeatherImgTit %>"></asp:Label></h2>



                        <div class="row col-12">
                            <div class="col-6">
                                <h4>temperature</h4>
                                <asp:Image ID="scnXX_AGeoImg_ClimateWheatherTemp" runat="server" ImageUrl="/a_img/noimage_WheatherTmp.jpg" CssClass="img100pct" />
                            </div>

                            <div class="col-6">
                                <h4>Rain</h4>
                                <asp:Image ID="scnXX_AGeoImg_ClimateWheatherRain" runat="server" ImageUrl="/a_img/noimage_WheatherRain.jpg" CssClass="img100pct" />
                            </div>
                        </div>
                        <div class="row col-12">
                            <div class="col-6">
                                <h4>biome</h4>
                                <asp:Image ID="scnXX_AGeoImg_ClimateWheatherBiome" runat="server" ImageUrl="/a_img/noimage_WheatherBiome.jpg" CssClass="img100pct" />
                            </div>

                            <div class="col-6">
                                <h4>Sun hours</h4>
                                <asp:Image ID="scnXX_AGeoImg_ClimateWheatherSun" runat="server" ImageUrl="/a_img/noimage_WheatherSun.jpg" CssClass="img100pct" />
                            </div>

                        </div>

                    </div>
                    <!-- fin tab clima -->



   
           

        </div>
        <!-- ----------------- -->
        <!-- Tab panes tabtaxo -->
        <!-- ----------------- -->
        <div id="tabtaxo" role="tabpanel" class="tab-pane fade col-12">
        
                    <div class="row">


                        <div class="form-group row">
                            <asp:Label ID="Label14" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL0001lNameFullRecomededTit %>"> </asp:Label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="scnXX_ATaxGrpL0001lNameFullRecomeded" CssClass="taxfield" Columns="80" runat="server" ReadOnly="true" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <h2>
                                <asp:Label ID="scnLTaxEtimologyTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLTaxEtimologyTit %>"> </asp:Label></h2>
                            <div class="col-6">
                                <h4>Español</h4>
                                <CKEditor:CKEditorControl ID="scnES_LTaxEtimology" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>
                            <div class="col-6">
                                <h4>English</h4>
                                <CKEditor:CKEditorControl ID="scnEN_LTaxEtimology" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>
                        </div>
                        <div class="form-group row">

                            <asp:Label ID="Label6" runat="server" CssClass="col-sm-2 col-form-label" Text="Linksinfo"> </asp:Label>
                            <div class="col-sm-10">
                                <a href="http://www.itis.gov/" class="glyphicon glyphicon-info-sign" target="_blank"></a>ITIS
                                <a href="http://reptile-database.reptarium.cz/" target="_blank" class="glyphicon glyphicon-info-sign" title="reptile-database.reptarium.cz"></a>Reptile database
                                <a href="http://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?name=testudines" class="glyphicon glyphicon-info-sign" target="_blank"></a>ncbi
                            </div>
                        </div>
                        <!-- ----- -->



                        <div class="pannel">

                            <h2>
                                <asp:Label ID="Label15" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings,     Taxonxomic_clasification %>"> </asp:Label></h2>



                            <div class="form-group row">
                                <asp:Label ID="scnXX_ATaxonGroupTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2000ClassTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2000Class" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox><br />
                                </div>
                            </div>
                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label7" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2210OrderTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2210Order" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label8" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2220SubOrderTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2220SubOrder" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label9" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2230SupFamilyTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2230SupFamily" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label10" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2240FamilyTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2240Family" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label11" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2250SubFamilyTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2250SubFamily" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- -- -->
                            <div class="form-group row">
                                <asp:Label ID="Label12" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGrpL2260SupGenusTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2260SupGenus" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- -- -->

                            <div class="form-group row">

                                <asp:Label ID="scnATaxGenusTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxGenusTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2270Genus" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ----- -->
                            <div class="form-group row">

                                <asp:Label ID="scnATaxEpitetTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxEpitetTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2280Specie" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ----- -->
                            <div class="form-group row">

                                <asp:Label ID="scnATaxAuthorityTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxAuthorityTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2282Authority" CssClass="taxfield" Width="350px" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ----- -->
                            <div class="form-group row">

                                <asp:Label ID="scnATaxYearTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxYearTit %>"> </asp:Label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="scnXX_ATaxGrpL2283Year" CssClass="taxfield" runat="server" Columns="4" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <!-- ----- -->
                            <div class="form-group row">
                                <h2>
                                    <asp:Label ID="scnATaxSinominsTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnATaxSinominsTit %>"> </asp:Label></h2>
                                <CKEditor:CKEditorControl ID="scnXX_ATaxSinonimous" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>

                            <div class="form-group row">
                                <h2>
                                    <asp:Label ID="scnATaxGrpL2281SubSpecieTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnATaxGrpL2281SubSpecieTit %>"> </asp:Label></h2>
                                <CKEditor:CKEditorControl ID="scnXX_ATaxGrpL2281SubSpecie" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>


                            <div class="form-group row">
                                <h2>
                                    <asp:Label ID="scnATaxNameVulgarTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnATaxNameVulgar %>"> </asp:Label></h2>
                                <div class="form-group row">
                                    <asp:Label ID="Label19" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxNameVulgarESTit %>"> </asp:Label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="scnXX_ATaxNameVulgarES" CssClass="taxfield" runat="server" Columns="80"></asp:TextBox><br />
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <asp:Label ID="scnATaxNameVulgarENTit" runat="server" CssClass="col-sm-2 col-form-label" Text="<%$ Resources:Strings, scnATaxNameVulgarENTit %>"> </asp:Label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="scnXX_ATaxNameVulgarEN" CssClass="taxfield" Columns="80" runat="server"></asp:TextBox><br />
                                    </div>
                                </div>
                                <CKEditor:CKEditorControl ID="scnXX_ATaxNameVulgarOthers" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>

                        </div>
                        <div class="row">
                            <h2>
                                <asp:Label ID="scnLTaxNotesTit" runat="server" CssClass="fieldtitlng" Text="<%$ Resources:Strings, scnLTaxNotesTit %>"> </asp:Label></h2>
                            <div class="col-6">
                                <CKEditor:CKEditorControl ID="scnES_LTaxNotes" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>
                            <div class="col-6">
                                <CKEditor:CKEditorControl ID="scnEN_LTaxNotes" runat="server" MaxLength="500" Toolbar="Basic" Width=""></CKEditor:CKEditorControl>
                            </div>

                        </div>
                        <!-- panel -->






                    </div>
                    <!-- fin tab taxo -->

  
         
        </div>



        <!-- ----------------- -->
        <!-- Tab panes  tabbibl-->
        <!-- ----------------- -->
        <div id="tabbibl" role="tabpanel" class="tab-pane fade">

            <h3>Bibl. Ack. Keys and links</h3>
            <h4>Same for all laguages</h4>
            <div class="row">

                <div class="col-12" id="document-4es">
                    <div class="form-group">
                        <asp:Label ID="scnAutors_XXTit" CssClass="field-title-inline" for="scnIsAuthorizeAll2" runat="server" Text="Autors" ClientIDMode="Static"></asp:Label>
                        <asp:TextBox ID="scnAutors_XX" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="300px" ClientIDMode="Static" Columns="300" Rows="1" TextMode="SingleLine"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <h2>Links to good sites</h2>

                    <div class="form-group col-12">
                        <asp:Label ID="scnXX_ALnkIUCN_tit" CssClass="field-title-inline" for="scnXX_ALnkIUCN" runat="server" Text="IUCN" ClientIDMode="Static"></asp:Label>
                        <asp:TextBox ID="scnXX_ALnkIUCN" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="200" ClientIDMode="Static" Columns="80" Rows="1" TextMode="SingleLine"></asp:TextBox>
                        <a class="ico-hlp" href="http://www.iucnredlist.org/search" target="_blank"></a>

                    </div>
                    <div class="form-group  col-12">
                        <asp:Label ID="scnXX_ALnkReptileDataBase_tit" CssClass="field-title-inline" for="scnXX_ALnkReptileDataBase" runat="server" Text="Reptile database" ClientIDMode="Static"></asp:Label>
                        <asp:TextBox ID="scnXX_ALnkReptileDataBase" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="500" ClientIDMode="Static" Columns="80" Rows="1" TextMode="SingleLine"></asp:TextBox>
                        <a class="ico-hlp" href="http://www.reptile-database.org/" title="www.reptiledatabse.com" target="_blank"></a>
                        &nbsp; <a href="http://reptile-database.reptarium.cz/" target="_blank" title="reptile-database.reptarium.cz"></a>
                    </div>
                    <div class="form-group  col-12">
                        <asp:Label ID="scnXX_ALnkTurtlesOfTheWorld_tit" CssClass="field-title-inline" for="scnXX_ALnkTurtlesOfTheWorld" runat="server" Text="Turtles of the world" ClientIDMode="Static"></asp:Label>
                        <asp:TextBox ID="scnXX_ALnkTurtlesOfTheWorld" CssClass="fld-textbox-inline" runat="server" MaxLength="150" Width="500" ClientIDMode="Static" Columns="80" Rows="1" TextMode="SingleLine"></asp:TextBox>
                        <a class="ico-hlp" href="http://wbd.etibioinformatics.nl/bis/turtles.php" target="_blank"></a>
                    </div>
                    <div class="form-group  col-12">
                        <asp:Label ID="scnXX_ALnkCITESDoc_tit" runat="server" CssClass="field-title-inline" Text="<%$ Resources:Strings, scnALnkCitesDocTit %>"></asp:Label>
                        <asp:TextBox ID="scnXX_ALnkCITESDoc" CssClass="fld-textbox-inline" runat="server" Width="300px" Rows="1" TextMode="SingleLine"></asp:TextBox>
                        <a class="ico-hlp" href="http://www.cites.org/" title="cites.org" target="_blank"></a>
                    </div>
                    <div class="form-group  col-12">
                        <asp:Label ID="scnALnk2000Tit" runat="server" CssClass="field-title-inline" Text="<%$ Resources:Strings, scnALnk2000Tit %>"></asp:Label>
                        <asp:TextBox ID="scnXX_ALnk2000" CssClass="fld-textbox-inline" runat="server" Width="300px" Rows="1" TextMode="SingleLine"></asp:TextBox>
                        <a href="http://www.sp2000.org/" class="ico-hlp" target="_blank"></a>
                    </div>


                    <div class="form-group  col-12">
                        <asp:Label ID="scnXX_ALnkOther_tit" CssClass="fld-title" runat="server" Text="<%$ Resources:Strings, scnALinkOtherTit %>"></asp:Label><br />
                        <CKEditor:CKEditorControl ID="scnXX_ALnkOther" runat="server" BasePath="~/Scripts/ckeditor/" MaxLength="500" Toolbar="Basic" ResizeDir="Vertical" TextMode="MultiLine" Width=""></CKEditor:CKEditorControl>


                    </div>
                </div>
                <div class="row col-12">
                    <div class="col-6" id="document-41en">

                        <asp:Label ID="scnXX_Acknoelegment_Tit" CssClass="fld-title" runat="server" Text="Agradecimientos" ClientIDMode="Static"></asp:Label><br />
                        <CKEditor:CKEditorControl ID="scnXX_Acknoelegment" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px" Width="600px">   </CKEditor:CKEditorControl>

                    </div>
                    <div class="col-6" id="document-4en">
                        <div class="form-group">
                            <asp:Button ID="scnXX_BtnBiblio_rebuild" runat="server" CssClass="btn btn-primary btn-sm" Text="Rebuild from table" OnClick="scnBtnBiblio_rebuild_Click" />
                            <asp:Label ID="scnXX_Bibliography_Ti3t" runat="server" Text="Bibliografia - Bibiliography" ClientIDMode="Static"></asp:Label><br />
                            <CKEditor:CKEditorControl ID="scnXX_Bibliography" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px" Width="600px">   </CKEditor:CKEditorControl>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- ----------------- -->
        <!-- Tab panes  tabdoc-->
        <!-- ----------------- -->
        <div id="tabdoc" role="tabpanel" class="tab-pane fade col-12">
               <uc1:ctl_doc_edit runat="server" ID="scn_oDdoc_edit" />

        </div>
        <!-- ----------------- -->
        <!-- Tab panes  tabdocLng-->
        <!-- ----------------- -->
        <div id="tabdocLng" role="tabpanel" class="tab-pane fade">
            <div class="row col-12">
                <h3>Metas searcher for languajes</h3>
              <div class="col-6" >
                        <h3>Español</h3>
                        <uc1:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_ES" />
                    </div>
                    <div class="col-6" >
                        <h3>English <a href="https://translate.google.com" class="glyphicon glyphicon-pencil" target="_black"></a><a href="https://www.linguee.es/espanol-ingles" class="glyphicon glyphicon-globe" target="_black"></a></h3>
                        <uc1:ctl_docLng_edit runat="server" ID="scn_oDocLng_edit_EN" />
                    </div>
                </div>
        </div>
        
           <div id="tabPdf" role="tabpanel" class="tab-pane fade">
               <div class="row col-12">
              <h3>PDF </h3>
                   
                   
                  
                  
               <div class="row">
                   <br />Title:&nbsp;<asp:Literal ID="scnXX_DocPdfTitle" Text="" runat="server"></asp:Literal>
                   &nbsp;Vers.:<asp:Literal ID="scnXX_DocPdfVersion" Text="" runat="server"></asp:Literal>
                   &nbsp;URL:<asp:Literal ID="scnXX_DocPdfUrl" runat="server" />
                  <asp:Literal ID="scnXX_DocPdfUrlEmbebed" runat="server" />
                  </div>
                   <asp:Label ID="scnXX_PdfMsg" Text="" runat="server"></asp:Label><br />

        </div>
       </div>
        
        <!-- Tab panes fin -->
        <!-- Tab panes fin divs-->
        <!-- ----------------- -->
        <!-- ----------------- -->
        <!-- ----------------- -->
    </div>
                <script>
                    $('#tabManager a').click(function (e) {
                        e.preventDefault();
                        $(this).tab('show');
                    });

                    // store the currently selected tab in the hash value
                    $("ul.nav-tabs > li > a").on("shown.bs.tab", function (e) {
                        var id = $(e.target).attr("href").substr(1);
                        window.location.hash = id;
                    });

                    // on load of the page: switch to the currently selected tab
                    var hash = window.location.hash;
                    $('#tabManager a[href="' + hash + '"]').tab('show');

                </script>
                </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
