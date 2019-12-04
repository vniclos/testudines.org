<%@Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="iucn-list.aspx.cs" Inherits="testudines.iucn.iucn_list" EnableSessionState="True" %>
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
        GridLines="None" BorderStyle="None" BorderWidth="0" OnPageIndexChanging="scnGridView_PageIndexChanging" CssClass="pagination-ys" PageSize="30">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# "<h2><a href=\"/"+        Eval("doclngid")+"/others/iucn/iucn/"+Eval("docid")+"\">"+ Eval("RL_Key") +": "+ Eval("Title") + "</a></h2>"%>'> </asp:Label>
                    <asp:Image ID="Thumbnail" CssClass="imgleft" runat="server" ToolTip="" ImageUrl='<%#  Bind("DocImgThumbnail") %>'>
                    </asp:Image>
                    <asp:Image ID="imgFlag" CssClass="imgright" runat="server" ToolTip="" ImageUrl='<%# "/a_img/a_site/ico16/flag16_"+Eval("doclngid")+ ".gif"  %>'>
                    </asp:Image>
                    <asp:Label ID="Label2" runat="server" Text='<%#   Eval("abstract") %>'> </asp:Label>
                    <asp:Label ID="Label4" CssClass="readmore" runat="server" Text='<%#"<a href=\"/"+ Eval("doclngid")+"/others/iucn/iucn/"+Eval("docid")+"\">"+Resources.Strings.readmore+"</a>"   %>' />
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
