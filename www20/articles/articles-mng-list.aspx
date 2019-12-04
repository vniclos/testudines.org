<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="articles_mng_list.aspx.cs" Inherits="testudines.articles.articles_mng_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
<asp:Literal ID="scnButtonBar" runat="server" Text=""></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <h2> <asp:Literal ID="scnTitlePage" runat ="server" Text="<%$ Resources:Strings, mnArticless_mng_list %>"></asp:Literal></h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            <asp:Button ID="scnFilterFilter" runat="server"  Text="<%$ Resources:Strings, filter %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="scnFilterClear" runat="server"  Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click"  CssClass="btn btn-primary btn-sm"/>
            <asp:Button ID="scnFilterNew" runat="server"  Text="<%$ Resources:Strings, new %>" OnClick="scnFilterNew_Click"  CssClass="btn btn-primary btn-sm"/>
           <br> <span> Order by</span>
            <asp:RadioButtonList ID="scnOrderby" runat="server" RepeatColumns="2" CellSpacing="25" RepeatLayout="Flow" CssClass="fld-radio">
                  <asp:ListItem Selected="True" Text="Title" Value="title"></asp:ListItem>
                <asp:ListItem Text="Updated" Value="Updated"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:GridView ID="scnGridView" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="DocId"  PageSize="20" Width ="100%"  PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom" PagerSettings-PageButtonCount="10"  PagerSettings-Visible="True"  pagination-CssClass="pagination" PagerStyle-HorizontalAlign="Center" PagerStyle-BorderStyle="None" PagerStyle-BorderWidth="1" AlternatingRowStyle-BorderStyle="None" PagerStyle-CssClass="pagination-ys" GridLines="None" AlternatingRowStyle-BackColor="#EEEEEE" BorderStyle="None" HeaderStyle-CssClass="hide" OnPageIndexChanging="scnGridView_PageIndexChanging" RowStyle-VerticalAlign="Top" RowStyle-CssClass="td-row" CssClass="td-row">
               <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="DocId, DocLngId" DataNavigateUrlFormatString="/{1}/articles/article-mng-edit/{0}"
                        Text="<img src='/a_img/a_site/ico16/ico-write.png' alt='Edit' border='0'>" HeaderText="View" ItemStyle-CssClass="td-top" />
                    <asp:HyperLinkField DataNavigateUrlFields="DocId, DocLngId" DataNavigateUrlFormatString="/{1}/articles/article/{0}"
                        Text="<img src='/a_img/a_site/ico16/ico-sheet.png' alt='Show' border='0'>" HeaderText="View" ItemStyle-CssClass="td-top"  />
                    <asp:BoundField DataField="DocId" HeaderText="Doc" SortExpression="Id" ReadOnly="True" ItemStyle-CssClass="td-top" />
                       <asp:ImageField DataImageUrlField="flag" HeaderText="Flag" ReadOnly="True" ItemStyle-CssClass="td-top" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" ItemStyle-CssClass="td-top" />
                   <asp:BoundField DataField="update" HeaderText="Updated" SortExpression="update" ItemStyle-CssClass="td-top" />
                   
                </Columns>

            </asp:GridView>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="MainContent_Top">
</asp:Content>

