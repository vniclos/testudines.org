<%@ page title="" language="C#" masterpagefile="~/Mpg_Site.Master" autoeventwireup="true" codebehind="acknowledgement-mng-edit.aspx.cs" inherits="testudines.others.acknowledgements.acknowledgement_mng_edit" %>
<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<%@ register src="~/a_ctl/ctl_doc_edit.ascx" tagprefix="uc1" tagname="ctl_doc_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style>
        .btn-group btn {
            margin-right: 1rem;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="scnBtnSave" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, save %>" OnClick="scnBtnSave_Click" />
    <asp:Button ID="scnBtnNew" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, new %>" OnClick="scnBtnNew_Click" />
    <asp:Button ID="scnBtnListMng" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, mn_acknowledgement_mng_list %>" OnClick="scnBtnListMng_Click" />
    <asp:Button ID="scnBtnList" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, mn_acknowledgements %>" OnClick="scnBtnList_Click" />
        <asp:Button ID="scnBtnShow" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, show %>" OnClick="scnBtnShow_Click" />
        <asp:Button ID="scnBtnDelete" class="btn btn-primary btn-sm" runat="server" Text="<%$ Resources:Strings, delete %>" OnClick="scnBtnDelete_Click" />
    <asp:Literal ID="scnMsbBox" runat="server" Text=""></asp:Literal>


    <ul class="nav nav-tabs" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" data-toggle="tab" href="#tabMain" role="tab">Main</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="tab" href="#TabDoc" role="tab">Meta Doc </a>
        </li>
        <li class="nav-item">
            <a class="nav-link" data-toggle="tab" href="#tabDocLng" role="tab">Meta DocLng</a>
        </li>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
        <div class="tab-pane active" id="tabMain" role="tabpanel">
            <!-- -------------------------- -->
            <!-- ---TAB 1 MAIN REG -------- -->
            <!-- -------------------------- -->
            <h2>Acnoalegment sheet</h2>
            <div class="form-control">
                <div class="form-group">
                    <asp:Label ID="scnDocIdTit" CssClass="fld-title-inline" for="scnDocId" runat="server" Text="Doc.Id." ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnDocId" CssClass="fld-textbox-inline" runat="server" Enabled="false" ClientIDMode="Static"></asp:TextBox>
                </div>

               
                <div class="form-group row">
                    <asp:Label ID="scnCiteNameTit" CssClass="fld-title-inline" for="scnCiteName" runat="server"  Text="Cite Name" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnCiteName" CssClass="fld-textbox-inline" runat="server" Width="300px"  ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="scnCiteFullTit" CssClass="fld-title" for="scnCiteFull" runat="server" Text="Cite full" ClientIDMode="Static"></asp:Label>
                     <CKEditor:CKEditorControl ID="scnCiteFull" BasePath="/Scripts/ckeditor/" runat="server"        Toolbar="basic" Height="50"></CKEditor:CKEditorControl>
                </div>
                <div class="form-group">
                    <asp:Label ID="scnEmailTit" CssClass="fld-title-inline" for="scnEmail" runat="server"  Text="Email" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnEmail" type="email" CssClass="fld-textbox-inline" runat="server" Width="300px"  ClientIDMode="Static"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="scnUrlExternalTit"  CssClass="fld-title-inline" for="scnUrlExternal" runat="server" Text="URL" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="scnUrlExternal" type="text" CssClass="fld-textbox-inline" runat="server" Width="300px" ClientIDMode="Static"></asp:TextBox>
                </div>
            
                <div class="form-group">
                    <asp:Label ID="scnIsColaboratorTit"  CssClass="fld-title-inline" for="scnIsColaborator2" runat="server" Text="Is Collaborator"></asp:Label>

                    <asp:CheckBox ID="scnIsColaborator2" class="form-control" runat="server" />
                </div>
                <div class="form-group">
                    <asp:Label ID="scnIsAuthorizeAllTit"  CssClass="fld-title-inline" for="scnIsAuthorizeAll2" runat="server" Text="Autorize all" ClientIDMode="Static"></asp:Label>
                    <asp:CheckBox ID="scnIsAuthorizeAll2" class="form-control" runat="server" />
                </div>

                
                <div class="form-group">
                    <asp:Label ID="scnAbstractTit"  CssClass="fld-title" runat="server" Text="Abstract" ClientIDMode="Static"></asp:Label>
                 
             
                  <CKEditor:CKEditorControl ID="scnAbstract" BasePath="~/Scripts/ckeditor/"  Toolbar="basic"  runat="server" Height="300px" ResizeMaxHeight="100"></CKEditor:CKEditorControl>
                </div>

                <div class="form-group">
                    <asp:Label ID="scnBodyTit"  CssClass="fld-title"  runat="server" Text="Body" ClientIDMode="Static"></asp:Label>
                 <CKEditor:CKEditorControl ID="scnBody" BasePath="~/Scripts/ckeditor/"  Toolbar="basic"  runat="server" Height="550px">   </CKEditor:CKEditorControl>
                     
                </div>

             
                <div class="form-group">
                    <asp:Label ID="PubDateAutorizationTit" CssClass="fld-title-inline" runat="server" Text="PubDateAutorization" ClientIDMode="Static"></asp:Label>
                    <asp:TextBox ID="PubDateAutorization" type="date" CssClass="fld-textbox-inline"  runat="server" ClientIDMode="Static"  Enabled="False"></asp:TextBox>
                </div>
            </div>
    </div>
    <!-- -------------------------- -->
    <!-- ---TAB 2 MAIN DOC -------- -->
    <!-- -------------------------- -->
    <div class="tab-pane" id="TabDoc" role="tabpanel">
        <h2>Datos comunes a todos los lenguajes</h2>
        <uc1:ctl_doc_edit runat="server" ID="scn_Doc_edit" />

    </div>
    <!-- -------------------------- -->
    <!-- ---TAB 3 MAIN DOC -------- -->
    <!-- -------------------------- -->
    <div class="tab-pane" id="tabDocLng" role="tabpanel">
        pane 3
    </div>

    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
    <!-- -------------------------- -->
    <!-- ---CONTENTC RIGHT -------- -->
    <!-- -------------------------- -->
</asp:Content>
