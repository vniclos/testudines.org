<%@Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="foods-list.aspx.cs" Inherits="testudines.tortoises.foods.food_list" EnableSessionState="True" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentTop" ContentPlaceHolderID="MainContent_Top" runat="server">
    <asp:Literal ID="scnContentTop" runat="server" Text=""></asp:Literal>
   
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:Literal ID="scnButtonBar" runat="server" Text=""></asp:Literal>
   <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <asp:Literal ID="scnPageTitle" runat="server" Text=""></asp:Literal>
    <div class="pannel">
           <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:Button ID="scnFilterFilter" runat="server"  Text="<%$ Resources:Strings, go %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="scnFilterClear" runat="server"  Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click"  CssClass="btn btn-primary btn-sm"/>
        

    </div>

    <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="DocId,DocLngId" EmptyDataText="<%$ Resources:Strings, Opps_NoData %>"
        GridLines="None" BorderStyle="None" BorderWidth="0" OnPageIndexChanging="scnGridView_PageIndexChanging" CssClass="pagination-ys">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# "<h2><a href=\""+ Eval("Url")+"\">"+  Eval("Title") + "</a></h2>"%>'> </asp:Label>
                    <asp:Image ID="Thumbnail" CssClass="imgleft" runat="server" ToolTip="" ImageUrl='<%#  Bind("DocImgThumbnail") %>'>
                    </asp:Image>
                    <asp:Image ID="imgFlag" CssClass="imgright" runat="server" ToolTip="" ImageUrl='<%# "/a_img/a_site/ico16/flag16_"+Eval("doclngid")+ ".gif"  %>'>
                    </asp:Image>
                    <asp:Label ID="Label2" runat="server" Text='<%#   Eval("abstract")+ "<br/>[" +Resources.Strings.Updated+": "+ Eval("DocDateUpdate")+"]" %>'> </asp:Label>
                    <asp:Label ID="lblDocStdVisitCount" CssClass="text3m" runat="server" Text='<%# Resources.Strings.readed+Eval("DocStdVisitCount")%>'></asp:Label>
                    <asp:Label ID="Label4" CssClass="readmore" runat="server" Text='<%#"<a href=\""+ Eval("Url")+"\">"+Resources.Strings.readmore+"</a>"   %>' />
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
