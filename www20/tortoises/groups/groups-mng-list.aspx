<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="groups-mng-list.aspx.cs" Inherits="testudines.tortoises.groups.groups_mng_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <h2> <asp:Literal ID="scnTitlePage" runat ="server" Text="<%$ Resources:Strings, mnTortoises_groups_mng_list %>"></asp:Literal></h2>
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
           

               <asp:GridView ID="scnGridView" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="DocId,DocLngId" CellPadding="4" CellSpacing="2" 
        ForeColor="#333333" GridLines="None" Width="100%" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="15">
            <Columns>
              <asp:CommandField ShowSelectButton="True" ButtonType="Image" 
                    EditImageUrl="~/a_img/a_site/ico16/ico-write.png" 
                    SelectImageUrl="~/a_img/a_site/ico16/ico-write.png" ItemStyle-CssClass="td-top" />

                <asp:HyperLinkField DataNavigateUrlFields="DocId,DocLngId" 
                    DataNavigateUrlFormatString="/{1}/taxons/taxon_group/{0}" 
                    Text="<img src='/a_img/a_site/ico16/ico-sheet.png' alt='Show' border='0' >"  ItemStyle-CssClass="td-top"
                    HeaderText="View" />

                <asp:BoundField DataField="DocId" HeaderText="DocId" SortExpression="DocId" ReadOnly="True"  ItemStyle-CssClass="td-top" />
                <asp:BoundField DataField="DocLngId" HeaderText="DocLngId" 
                    SortExpression="DocLngId" HtmlEncode="False" ItemStyle-CssClass="td-top" />
                <asp:BoundField DataField="titlevu" HeaderText="Nombre" 
                    SortExpression="titlevu" HtmlEncode="False" ItemStyle-CssClass="td-top" />
                    <asp:BoundField DataField="ItisId" HeaderText="ItisId" 
                    SortExpression="ItisId" ItemStyle-CssClass="td-top" />
                     
                     
                <asp:BoundField DataField="ATaxLevel" HeaderText="Level" 
                    SortExpression="ATaxLevel" ItemStyle-CssClass="td-top" />
               
                 <asp:BoundField DataField="IsOk" HeaderText="IsOk" 
                    SortExpression="IsOk" HtmlEncodeFormatString="False" HtmlEncode="False" ItemStyle-CssClass="td-top" />
                   
                <asp:BoundField DataField="IsTaxa2014" HeaderText="IsTaxa2014" 
                    SortExpression="IsTaxa2014"  HtmlEncodeFormatString="False" HtmlEncode="False" ItemStyle-CssClass="td-top" />
              
 
            </Columns>
            
            <RowStyle CssClass="RowStyle" />
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />
    <PagerStyle CssClass="pagination" />
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
