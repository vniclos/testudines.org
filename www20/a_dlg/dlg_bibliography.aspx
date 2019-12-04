<%@ page language="C#" autoeventwireup="true" codebehind="dlg_bibliography.aspx.cs" inherits="testudines.a_dlg.dlg_bibliography" %>

<%@ register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<!DOCTYPE html>
<link href="../Content/bootstrap.css" rel="stylesheet" />
<link href="../Content/fields.css" rel="stylesheet" />
<link href="../Content/Site.css" rel="stylesheet" />
<link href="../Content/glyficons.css" rel="stylesheet" />
<script src="../Scripts/jquery-3.3.1.js"></script>
<script src="../Scripts/bootstrap.js"></script>
<script src="../Scripts/testudines.js"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bibliography manager</title>
    <script type="text/javascript">

        function FncClose() {
            window.close();
            return false;
        }

    </script>
</head>
<body style="background-color: #dfdfdf;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div style="margin: 0; padding-left: 16px; padding-right: 16px; border: 0; color: white; background: #333333;">

            <asp:Label runat="server" ID="scnParentTitle" Text="title" Style="font-weight: bold; display: inline-block; color: #ffffff; height: 32px">   </asp:Label>

            <asp:Label ID="scnFilterDocIdParentTit" runat="server" Text=" - Id. Parent:" Enabled="false"></asp:Label>
            <asp:Label ID="scnFilterDocIdParent" runat="server" Style="display: inline-block;" ReadOnly="true" Width="100px"></asp:Label>
            <span class="right" onclick="window.close();return false;"
                style="font-size: 0.8rem; background-color: #ff0000; color: #ffffff; display: inline-block; font-weight: bold; margin: 1px; padding: 1px; border: 0;">X</span>

        </div>
        <asp:Label ID="scnMsg" runat="server" Text="scnMsg" Visible="False"></asp:Label>



        <asp:UpdatePanel ID="scnPanelUpdate" runat="server">
            <ContentTemplate>
                <asp:Panel ID="scnPanelList" runat="server">
                    <div class="panel">
                        <asp:Label ID="scnFilterTextTit" runat="server" Text="Filter" Style="display: inline-block;"></asp:Label>
                        <asp:TextBox ID="scnFilterText" runat="server" Width="180px"></asp:TextBox>
                        <asp:Button ID="scnBtnFilter" runat="server" Text="Filter" CssClass="btn-tiny" OnClick="scnBtnFilter_Click" />

                        &nbsp;<asp:Button ID="scnBtnAddNewTaxa" runat="server" CssClass="btn-tiny" Text="Add AutoTaxa" OnClick="scnBtnAddNewTaxaBib_Click" />
                        &nbsp;<asp:Button ID="BtnShowNew" runat="server" Text="New" CssClass="btn-tiny" OnClick="BtnShowNew_Click" />

                        <asp:Label ID="scnRadOrderTit" runat="server" Text="&nbsp;Order by:&nbsp;" Style="display: inline; top: 0px;"></asp:Label>

                        <asp:RadioButtonList ID="scnRadOrder" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="scnRadOrder_SelectedIndexChanged" RepeatLayout="Flow">
                            <asp:ListItem Value="1"> &nbspFIFO &nbsp;</asp:ListItem>
                            <asp:ListItem Value="2">LIFO &nbsp;</asp:ListItem>
                            <asp:ListItem Selected="True" Value="3">Author</asp:ListItem>
                        </asp:RadioButtonList>

                        <%--</div>--%>
                        <asp:GridView ID="scnGridview" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False"
                            DataKeyNames="DocId"
                            BorderStyle="None" CaptionAlign="Top" CellSpacing="1" CellSpadding="3"
                            GridLines="None" Width="1024px"
                            OnPageIndexChanging="scnGridview_PageIndexChanging"
                            OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                            CellPadding="3" CssClass="pagination-ys">
                            <AlternatingRowStyle BackColor="White" BorderColor="#efefef" />
                            <Columns>
                                <asp:TemplateField HeaderText="Tick" SortExpression="Tick">
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="ColChkBox"
                                            AutoPostBack="true" OnCheckedChanged="ColChkBox_CheckedChanged"
                                            Checked='<%# (Eval("Tick").ToString ()=="1" ? true:false) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tick" HeaderText="Tick" ReadOnly="True" SortExpression="Tick" />

                                <asp:BoundField DataField="DocId" HeaderText="DocId" ReadOnly="True" SortExpression="DocId" />
                                <asp:BoundField DataField="DocIdParent" HeaderText="DocIdParent" SortExpression="DocIdParent" />
                                <asp:CommandField ButtonType="Image" CausesValidation="False" EditImageUrl="~/a_img/a_site/ico16/ico-write.png" EditText="" InsertVisible="False" SelectImageUrl="~/a_img/a_site/ico16/ico-write.png" SelectText="Edit" ShowSelectButton="True" />

                                <asp:BoundField DataField="CiteAutorYearABC" HeaderText="CiteAutorYearABC" SortExpression="CiteAutorYearABC" />
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />

                            </Columns>
                            <RowStyle BackColor="#E9E9E9" VerticalAlign="Top" />
                        </asp:GridView>

                        <asp:Label ID="scnLOG" runat="server" Text="Label"></asp:Label>
                </asp:Panel>

                <!- ------------------------------------------- ->
        <!- ------------------------------------------- ->
        <!- ------------------------------------------- ->

          <!-- EDIT START -->
                <asp:Panel ID="scnPanelEdit" runat="server">



                    <div>
                        <span style="float: right; font-weight: bold; display: inline;">
                            <asp:Button ID="scnBtnLinkToDocument" runat="server" CssClass="btn-tiny" Text="Link to Current" OnClick="scnBtnLinkToDocument_Click" />
                            <asp:Button ID="scnBtnAddNew" runat="server" CssClass="btn-tiny" OnClick="scnBtnAddNew_Click" Text="Add new" />
                            &nbsp;<asp:Button ID="scnRegDeleteBtn" runat="server" CssClass="btn-tiny" OnClick="scnRegDeleteBtn_Click" Text="<%$ Resources:Strings, Delete %>" />
                            &nbsp;
&nbsp;<asp:Button ID="scnRegSaveBtn" runat="server" CssClass="btn-tiny" Text="<%$ Resources:Strings, Save %>" OnClick="scnRegGuardar_Click" />
                            &nbsp;<asp:Button ID="scnBtnReturn" runat="server" CssClass="btn-tiny" Text="<%$ Resources:Strings, Return %>" OnClick="scnBtnReturn_Click" />
                    </div>

                    <b>
                        <asp:Label ID="scnDocIdlbl" runat="server" class="fld_inlineTit" Text="<%$ Resources:Strings, DocId %>" Width="180px"></asp:Label>
                    </b>
                    <asp:TextBox ID="scnDocIdTxt" runat="server" Style="display: inline;" ReadOnly="True" Width="100px"></asp:TextBox>&nbsp; 
     <b>
         <asp:Label ID="scnRelatedCountTit" runat="server" Style="display: inline;" Text="<%$ Resources:Strings, CitedOn %>"></asp:Label>&nbsp;
    <asp:Label ID="scnRelatedCount2" runat="server" Style="display: inline;" Text="0" ReadOnly="True"></asp:Label>
         &nbsp;
    <asp:Label ID="scnDocuments" runat="server" Style="display: inline;" Text="<%$ Resources:Strings, Documents %>"></asp:Label></b>
                    <br />

                    <b>
                        <asp:Label ID="scnCiteAutorYearABClbl" runat="server" Text="<%$ Resources:Strings, CiteAutorYearABC %>" Width="180px"></asp:Label>
                    </b>
                    <asp:TextBox ID="scnCiteAutorYearABCTxt" runat="server" Style="display: inline-block;" Width="50%"></asp:TextBox>
                    <br />
                    <b>
                        <asp:Label ID="sncAuthorsLbl" runat="server" Text="<%$ Resources:Strings, Authors_full %>" Width="180px"></asp:Label>
                    </b>
                    <asp:TextBox ID="scnAuthorsTxt" runat="server" class="fld_inlineFld" Text="." Rows="2"
                        Width="95%" TextMode="MultiLine"></asp:TextBox>

                    <b><asp:Label ID="scnTitleLbl" runat="server" class="fld_inlineTit" Text="<%$ Resources:Strings, Title %>" Width="180px"></asp:Label> </b>
                    <asp:TextBox ID="scnTitleTxt" runat="server" class="fld_inlineFld" Text="." Rows="2" Width="95%" TextMode="MultiLine" Height="50px"></asp:TextBox>

             <br />

                    <b><asp:Label ID="scnPublicationTypeLbl" Width="180px" runat="server" class="fld_inlineTit" Text="Publicacion tipe"></asp:Label></b>
                    <asp:DropDownList ID="scnPublicationTypeTxt" class="fld_inlineFld" runat="server" Width="180px">
                        <asp:ListItem>book</asp:ListItem>
                        <asp:ListItem>pdf</asp:ListItem>
                        <asp:ListItem>web</asp:ListItem>
                        <asp:ListItem>publication</asp:ListItem>
                        <asp:ListItem>personal</asp:ListItem>
                        <asp:ListItem>other</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <b><asp:Label ID="PublicationNameLbl"  Width="180px" runat="server" CssClass="fld_inlineTit" Text="<%$ Resources:Strings, Publication_Name %>" ></asp:Label></b>
                    <asp:TextBox ID="scnPublicationNameTxt" runat="server" CssClass="fld_inlineFld" Text="."></asp:TextBox>
                    <br />
                    <b><asp:Label ID="scnPublicationDatePageLbl"  Width="180px" runat="server" CssClass="fld_inlineTit" Text="<%$ Resources:Strings, Publication_Date_page %>"></asp:Label></b>
                    <asp:TextBox ID="scnPublicationDatePageTxt" runat="server" placeholder="yyyy-mm-dd P" class="fld_inlineFld" Text="."></asp:TextBox>
                    <br />
                    <b><asp:Label ID="scnPublicationReadedLbl"  Width="180px" runat="server" CssClass="fld_inlineTit" Text="<%$ Resources:Strings, PublicationReaded %>" ></asp:Label></b>
                    <asp:TextBox ID="scnPublicationReadedTxt2" runat="server" placeholder="yyyy-mm-dd" class="fld_inlineFld" Width="250px" MaxLength="10"></asp:TextBox>
                    <br />
                    <b><asp:Label ID="scnURPublicationLbl"  Width="180px" runat="server" CssClass="fld_inlineTit" Text="<%$ Resources:Strings, URPublication %>" ></asp:Label></b>
                    <br /><asp:TextBox ID="scnURPublicationTxt2" runat="server" placeholder="http://" class="fld_inlineFld" Text="." Columns="180" Width="95%"></asp:TextBox>
                    <br />
                     <b> <asp:Label ID="scnPublicationNotesLbl" runat="server" class="fld_inlineTit" Text="<%$ Resources:Strings, Notes %>" ></asp:Label></b>
                     <CKEditor:CKEditorControl ID="scnPublicationNotesTxt" runat="server"  Toolbar="Basic" ResizeDir="Vertical" Width="" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css" TemplatesFiles="~/scripts/ckeditor/plugins/templates/templates/default.js"></CKEditor:CKEditorControl>
                    <br />
                    <b><asp:Label ID="Label1" runat="server" class="fld_inlineTit" Text="Full cite" Width="180px"></asp:Label> </b>
                    <br />
                    <CKEditor:CKEditorControl ID="scnCiteHtmlFullTxt" runat="server" MaxLength="250" Toolbar="Basic" ResizeDir="Vertical" Width="" BasePath="~/scripts/ckeditor" ContentsCss="~/scripts/ckeditor/contents.css"></CKEditor:CKEditorControl>


                    <div>
                        <span style="float: right; font-weight: bold; display: inline;">
                            <asp:Button ID="scnBtnDelete3" runat="server" CssClass="btn-tiny" OnClick="scnRegDeleteBtn_Click" Text="<%$ Resources:Strings, Delete %>" />&nbsp;     
 &nbsp;<asp:Button ID="scnBtnSave3" runat="server" CssClass="btn-tiny" Text="<%$ Resources:Strings, Save %>" OnClick="scnRegGuardar_Click" />
                            &nbsp;<asp:Button ID="scnBtnReturn3" runat="server" CssClass="btn-tiny" OnClick="cnBtnReturn3_Click" Text="<%$ Resources:Strings, Return %>" />


                        </span>


                    </div>

                    <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Do You want to delete this? I think, better idea is inactivate this !" TargetControlID="scnRegDeleteBtn" Enabled="True"></asp:ConfirmButtonExtender>

                    </span>

                </asp:Panel>

                <asp:Panel ID="scnPanelUpload" CssClass="panel" runat="server">
                    <h3>Upload pdf original document</h3>
                    <asp:FileUpload ID="scnFileUpload1" runat="server" Width="200" />
                    <asp:Button ID="btnUpload" runat="server" CssClass="btn-tiny" Text="Upload" ToolTip="Upload file save automatic the field in database." OnClick="btnUpload_Click" /><br />
                    <asp:HyperLink ID="scnFileUrl" runat="server" ImageUrl="#"></asp:HyperLink>
                    <asp:Label ID="scnPanelUploadMsg" runat="server"></asp:Label>
                </asp:Panel>
            </ContentTemplate>


            <Triggers>
                <asp:PostBackTrigger ControlID="btnUpload" />
            </Triggers>

        </asp:UpdatePanel>

    </form>
</body>
</html>
