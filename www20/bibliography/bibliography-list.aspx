<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="bibliography-list.aspx.cs" Inherits="testudines.bibliography.bibliography_list" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="ContentTop" ContentPlaceHolderID="MainContent_Top" runat="server">
    <asp:Literal ID="scnContentTop" runat="server" Text=""></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
   <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <!---  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx -->
    <asp:Literal ID="scnPageTitle" runat="server" Text=""></asp:Literal>
    <div class="pannel">
           <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:Button ID="scnFilterFilter" runat="server"  Text="<%$ Resources:Strings, go %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="scnFilterClear" runat="server"  Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click"  CssClass="btn btn-primary btn-sm"/>
        

    </div>

    <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="DocId" EmptyDataText="<%$ Resources:Strings, Opps_NoData %>"
        GridLines="None" BorderStyle="None" BorderWidth="0" OnPageIndexChanging="scnGridView_PageIndexChanging" 
        CssClass="pagination-ys" PageSize="30">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>

                    
                    <b><asp:Label ID="Label3" runat="server" Text='<%#   Eval("CiteAutorYearABC") %>'> </asp:Label></b><br />
                    <asp:Label ID="Label1" runat="server" Text='<%# "<b><a href=\"/"+ "/es/others/bibliography/bibliography/"+Eval("docid")+"\">"+  Eval("Title") + "</a></b>"%>'> </asp:Label>
                  
                  
                    <asp:Label ID="Label2" runat="server" Text='<%#   Eval("abstract") %>'> </asp:Label>
                  
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
