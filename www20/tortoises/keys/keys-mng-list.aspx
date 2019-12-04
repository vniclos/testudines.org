<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="keys-mng-list.aspx.cs" Inherits="testudines.tortoises.keys.keys_mng_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>(Node id)
            <asp:Button ID="scnFilterFilter" runat="server"  Text="<%$ Resources:Strings, filter %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
            <asp:Button ID="scnFilterClear" runat="server"  Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click"  CssClass="btn btn-primary btn-sm"/>
            <asp:Button ID="scnFilterNew" runat="server"  Text="<%$ Resources:Strings, new %>" OnClick="scnFilterNew_Click"  CssClass="btn btn-primary btn-sm"/>
           <br> <span> Order by</span>
            <asp:RadioButtonList ID="scnOrderby" runat="server" RepeatColumns="2" CellSpacing="25" RepeatLayout="Flow" CssClass="fld-radio">
                  <asp:ListItem Selected="True" Text="Node Parent" Value="TOWNodeParentId"></asp:ListItem>

                <asp:ListItem Text="Node ID" Value="TOWNodeId"></asp:ListItem>
            </asp:RadioButtonList>

            
     <asp:GridView ID="scnGridView1" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="DocId,DocLngId"  PageSize="20" Width ="100%"  PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom" PagerSettings-PageButtonCount="10"  PagerSettings-Visible="True"  pagination-CssClass="pagination" PagerStyle-HorizontalAlign="Center" PagerStyle-BorderStyle="None" PagerStyle-BorderWidth="1" AlternatingRowStyle-BorderStyle="None" PagerStyle-CssClass="pagination-ys" GridLines="None" AlternatingRowStyle-BackColor="#EEEEEE" BorderStyle="None" HeaderStyle-CssClass="hide" OnPageIndexChanging="scnGridView_PageIndexChanging" RowStyle-VerticalAlign="Top" RowStyle-CssClass="td-row" CssClass="td-row">
            <Columns>
         
                  <asp:HyperLinkField DataNavigateUrlFields="DocId,DocLngId" DataNavigateUrlFormatString="/{1}/tortoises/keys/key-mng-edit/{0}"
                    Text="<img src='/a_img/a_site/ico16/ico-write.png' alt='Edit' border='0'>" HeaderText="Edit" />

                <asp:HyperLinkField DataNavigateUrlFields="DocId,DocLngId" DataNavigateUrlFormatString="/{1}/tortoises/keys/key/{0}"
                    Text="<img src='/a_img/a_site/ico16/ico-sheet.png' alt='Show' border='0'>" HeaderText="View" />
              

                <asp:BoundField DataField="DocId" HeaderText="DocId" SortExpression="DocId" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="DocLngId" HeaderText="DocLngId" SortExpression="DocLngId"
                    HtmlEncode="False" Visible="False" />
                <asp:BoundField DataField="Title" HeaderText="Description of Turtles of the world"
                    SortExpression="Title" />
                <asp:BoundField DataField="TOWNodekeyNum" HeaderText="Nº" SortExpression="TOWNodekeyNum" />
                <asp:BoundField DataField="TOWNodeParentId" HeaderText="Node Parent" SortExpression="TOWNodeParentId" />
                <asp:BoundField DataField="TOWNodeId" HeaderText="Node Id" SortExpression="TOWNodeId" />
                <asp:BoundField DataField="IsRevised" HeaderText="IsRevised" SortExpression="IsRevised"
                    HtmlEncode="False" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BorderStyle="None" BorderWidth="1px" CssClass="pagination-ys" HorizontalAlign="Center" />
            <RowStyle CssClass="RowStyle" />
            <EmptyDataRowStyle CssClass="EmptyRowStyle" />
            <SelectedRowStyle CssClass="SelectedRowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />
            <EditRowStyle CssClass="EditRowStyle" />
            <AlternatingRowStyle CssClass="AltRowStyle" />
        </asp:GridView>
                </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
