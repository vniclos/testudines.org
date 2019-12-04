<%@Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="ecozones-list.aspx.cs" Inherits="testudines.others.ecozones.ecozone_list" EnableSessionState="True" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentTop" ContentPlaceHolderID="MainContent_Top" runat="server">
    <asp:Literal ID="scnContentTop" runat="server" Text="scnContentTop"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><asp:Literal ID="scnTitle" runat ="server" Text=""></asp:Literal></h1>
   <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="DocId,DocLngId" EmptyDataText="<%$ Resources:Strings, Opps_NoData %>"
        GridLines="None" BorderStyle="None" BorderWidth="0" OnPageIndexChanging="scnGridView_PageIndexChanging" CssClass="pagination-ys">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# "<h2><a href=\"/"+ Eval("doclngid")+"/others/ecozones/ecozone/"+Eval("docid")+"\">"+  Eval("Title") + "</a></h2>"%>'> </asp:Label>
                    <asp:Image ID="Thumbnail" CssClass="imgleft" runat="server" ToolTip="" ImageUrl='<%#  Bind("DocImgThumbnail") %>'>
                    </asp:Image>
                    <asp:Image ID="imgFlag" CssClass="imgright" runat="server" ToolTip="" ImageUrl='<%# "/a_img/a_site/ico16/flag16_"+Eval("doclngid")+ ".gif"  %>'>
                    </asp:Image>
                    <asp:Label ID="Label2" runat="server" Text='<%#   Eval("abstract")+ "<br/>[" +Resources.Strings.Updated+": "+ Eval("DocDateUpdate")+"]" %>'> </asp:Label>
                    <asp:Label ID="lblDocStdVisitCount" CssClass="text3m" runat="server" Text='<%# Resources.Strings.readed+Eval("DocStdVisitCount")%>'></asp:Label>
                    <asp:Label ID="Label4" CssClass="readmore" runat="server" Text='<%#"<a href=\"/"+ Eval("doclngid")+"/ecozones/ecozone/"+Eval("docid")+"\">"+Resources.Strings.readmore+"</a>"   %>' />
                    <hr />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        
        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
        <PagerStyle CssClass="GridPager" />
        
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentRight" runat="server">
    <asp:Literal ID="scnPanelRightLastDocs" runat="server" Text="scnPanelRightLastDocs"></asp:Literal>
</asp:Content>
