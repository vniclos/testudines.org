<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="acknowledgements-list.aspx.cs" Inherits="testudines.acknowledgements.acknowledgements_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
        <asp:Literal ID="scnContentTop" runat="server" Text=""></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <h2>   <asp:Literal ID="scnTitle" runat="server" Text="<%$ Resources:Strings, mnOthers_Acknowledgements_Acknoelegments_list %>"></asp:Literal></h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="row">
            <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:Button ID="scnFilterFilter" runat="server" Text="<%$ Resources:Strings, filter %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="scnFilterClear" runat="server" Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click" CssClass="btn btn-primary btn-sm" />
         </div>
            <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="DocId" EmptyDataText="<%$ Resources:Strings, Opps_NoData %>"
                GridLines="None" BorderStyle="None" BorderWidth="0" OnPageIndexChanging="scnGridView_PageIndexChanging" CssClass="pagination-ys">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# "<h2><a href=\"/others/acknowledgements/acknowledgement/"+Eval("docid")+"\">"+  Eval("Title") + "</a></h2>"%>'> </asp:Label>
                            <asp:Image ID="Thumbnail" CssClass="imgleft" runat="server" ToolTip="" ImageUrl='<%#  Bind("DocImgThumbnail") %>' />

                            <asp:Label ID="Label2" runat="server" Text='<%#   Eval("abstract")+ "<br/>[" +Resources.Strings.Updated+": "+ Eval("DocDateUpdate")+"]" %>'> </asp:Label>
                            <asp:Label ID="lblDocStdVisitCount" CssClass="text3m" runat="server" Text='<%# Resources.Strings.readed+Eval("DocStdVisitCount")%>'></asp:Label>
                            <asp:Label ID="Label4" CssClass="readmore" runat="server" Text='<%#"<a href=\"/others/acknowledgements/acknowledgement/"+Eval("docid")+"\">"+Resources.Strings.readmore+"</a>"   %>' />
                            <hr />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                <PagerStyle CssClass="GridPager" />

            </asp:GridView>
            </ContentTemplate>
</asp:UpdatePanel>

    
 
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
    
     <asp:Literal ID="scnPanelRightLastDocs" runat="server" Text="scnPanelRightLastDocs"></asp:Literal>
    
</asp:Content>
