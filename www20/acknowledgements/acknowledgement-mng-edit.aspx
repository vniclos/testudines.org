<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site_Edit.Master" AutoEventWireup="true" CodeBehind="acknowledgement-mng-edit.aspx.cs" Inherits="testudines.acknowledgements.acknowledgement_mng_edit" %>

<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ register src="~/a_ctl/ctl_doc_edit.ascx" tagprefix="uc1" tagname="ctl_doc_edit" %>


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
        <asp:Button ID="scnBtnListCols" class="btn btn-primary btn-sm" runat="server" Text="Ver columnas" OnClick="scnBtnListCols_Click"  />
    <a href="https://www.linguee.es/espanol-ingles"  class="btn btn-primary btn-sm"" target="_blank"> <span class="glyphicon glyphicon-random white" ></span> </a>

        <input type="button" class="btn btn-primary btn-sm" onclick="javascript: window.open('https://translate.google.com/', '_blank');" value="Translate" />

        <span class="fld-boxId ">Doc.Id.&nbsp; 
            <asp:Literal ID="scnDocId" runat="server" Text="0" ClientIDMode="Static"></asp:Literal></span>
    </div>

    <div class="container2">

        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" data-toggle="tab" href="#tabMain">Document</a>
            </li>
           
            <li class="nav-item">
                <a class="nav-link" data-toggle="tab" href="#tabDocid">All lng</a>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div id="tabMain" class="container tab-pane active">
                <div class="form-control">
                    <!-- -------- START ROW ---------- -->
                    <div class="row">
                        
                            <asp:Button ID="scnBtnSaveES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_save_ES %>" OnClick="scnBtnSaveES_Click" />
                            <asp:Button ID="scnBtnRbCacheES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_Rebuld_Cache_ES%>" OnClick="scnBtnRbCacheES_Click" />
                            <asp:Button ID="scnBtnShowES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, btn_show %>" OnClick="scnBtnShowES_Click" />
                            <asp:Button ID="scnBtnDeleteES" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, Delete %>" onclick="scnBtnDeleteES_Click" />
                          
                            <ajaxToolkit:ConfirmButtonExtender ID="scnBtnDeleteES_ConfirmButtonExtender" runat="server" BehaviorID="scnBtnDeleteES_ConfirmButtonExtender" ConfirmText="Do you want delete ES?" TargetControlID="scnBtnDeleteES" />
                          
                            <asp:Literal ID="scnMsbBoxES" runat="server" Text=""></asp:Literal>
                        
                        
                    </div>
              

                    <!-- -------- END  ROW ---------- -->
                    <br />
                  <div class="form-group row">
                    <asp:Label ID="scnCiteNameTit" CssClass="fld-title-inline" for="scnCiteName" runat="server"  Text="Cite Name" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnCiteName" CssClass="fld-textbox-inline" runat="server" Width="300px"  ClientIDMode="Static"></asp:TextBox>
                </div>
                  <div class="row">
                      <div class="col-3">
                    <asp:Label ID="scnIsColaboratorTit"  CssClass="fld-title-inline" for="scnIsColaborator" runat="server" Text="Is Collaborator"></asp:Label>
                    <asp:CheckBox ID="scnIsColaborator" class="fld-textbox-inline" runat="server" />
                    </div>
                      <div class="col-3">
                          <asp:Label ID="scnIsAuthorizeAllTit"  CssClass="fld-title-inline" for="scnIsAuthorizeAll" runat="server" Text="Autorize all" ClientIDMode="Static"></asp:Label>
                    <asp:CheckBox ID="scnIsAuthorizeAll" class="fld-textbox-inline" runat="server" />
                    </div>
                      <div class="col-3">
                  
                     <asp:Label ID="scnPubDateAutorizationTit" CssClass="fld-title-inline" for="scnEmail" runat="server"  Text="Date autorization" ClientIDMode="Static"></asp:Label>
                 <asp:TextBox ID="scnPubDateAutorization" runat="server"  CssClass="fld-title-inline" Text=""></asp:TextBox>
                          <ajaxToolkit:CalendarExtender ID="scnPubDateAutorization_CalendarExtender" runat="server" BehaviorID="scnPubDateAutorization_CalendarExtender" TargetControlID="scnPubDateAutorization" DaysModeTitleFormat="dd/mm/yyyy" TodaysDateFormat="dd/mm/yyy" />
                          </div>
                 </div>
                  
                 <div class="row">
                        
                            <div class="form-group">
                                <asp:Label ID="scnCiteFullTit" CssClass="fld-title-inline" for="scnAbstract_ES" runat="server" Text="CiteFull" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnCiteFull" BasePath="~/Scripts/ckeditor/" runat="server" Height="150px">   </CKEditor:CKEditorControl>
                            </div>
                      

                    </div>
                    
                <div class="form-group">
                    <asp:Label ID="scnEmailTit" CssClass="fld-title-inline" for="scnEmail" runat="server"  Text="Email" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnEmail" type="email" CssClass="fld-textbox-inline" runat="server" Width="300px"  ClientIDMode="Static"></asp:TextBox>
                
                    <asp:Label ID="scnUrlExternalTit"  CssClass="fld-title-inline" for="scnUrlExternal" runat="server" Text="URL" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnUrlExternal" type="text" CssClass="fld-textbox-inline" runat="server" Width="300px" ClientIDMode="Static"></asp:TextBox>
                   
                </div>
                



                   
                    <!-- -------- START ROW ---------- -->
                    <div class="row">
                        
                            <div class="form-group">
                                <asp:Label ID="scnBody_ES_tit" CssClass="fld-title-inline" for="scnBody_ES" runat="server" Text="Referencia autorizacion" ClientIDMode="Static"></asp:Label>
                                <CKEditor:CKEditorControl ID="scnBody_ES" BasePath="~/Scripts/ckeditor/" runat="server" Height="550px">   </CKEditor:CKEditorControl>
                            </div>
                        
                   

                    </div>
                    <!-- -------- END  ROW ---------- -->
                    <!-- ----------------------------------------- -->
                </div>

            </div>

            <!-- ----------------------------------------- -->
            <div id="tabDocId" class="container tab-pane fade">
                <uc1:ctl_doc_edit runat="server" ID="scn_oDdoc_edit" />
                ffffffffffffff
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
