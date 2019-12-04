﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="acknowledgements-mng-list.aspx.cs" Inherits="testudines.acknowledgements.acknowledgements_mng_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Literal ID="scnTitle" runat="server" Text="<%$ Resources:Strings, mnOthers_Acknowledgements_Acknoelegment_mng_list %>"></asp:Literal></h2>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
            <asp:TextBox ID="scnFilterTxt" runat="server" placeholder="<%$ Resources:Strings, search %>" ClientIDMode="Static" ValidateRequestMode="Disabled"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Literal ID="scnOrderGrpTit" runat="server" Text="<%$ Resources:Strings, orderby %>"></asp:Literal>
                &nbsp;&nbsp;ABC
                <asp:RadioButton id="scnOrderGrpABC" runat="server" GroupName="scnOrderGrp" Checked="True"></asp:RadioButton>
                &nbsp;&nbsp;LIFO
                <asp:RadioButton id="scnOrderGrpLIFO" runat="server" GroupName="scnOrderGrp"></asp:RadioButton>
                &nbsp;&nbsp; Update Desc
                 <asp:RadioButton id="scnOrderGrpUpdate" runat="server" GroupName="scnOrderGrp"></asp:RadioButton>
                &nbsp;&nbsp;
                <asp:Button ID="scnFilterFilter" runat="server"  Text="<%$ Resources:Strings, filter %>" OnClick="scnFilterFilter_Click" CssClass="btn btn-primary btn-sm" />
           &nbsp;&nbsp;
                <asp:Button ID="scnFilterClear" runat="server"  Text="<%$ Resources:Strings, all %>" OnClick="scnFilterClear_Click"  CssClass="btn btn-primary btn-sm"/>
            <asp:Button ID="scnFilterNew" runat="server"  Text="<%$ Resources:Strings, new %>" OnClick="scnFilterNew_Click"  CssClass="btn btn-primary btn-sm"/>
             
            </div>
            <asp:GridView ID="scnGridView" runat="server" AllowPaging="True"  AutoGenerateColumns="False" DataKeyNames="DocId"  PageSize="20" Width ="100%"  PagerSettings-Mode="NumericFirstLast" PagerSettings-Position="Bottom" PagerSettings-PageButtonCount="10"  PagerSettings-Visible="True"  pagination-CssClass="pagination" PagerStyle-HorizontalAlign="Center" PagerStyle-BorderStyle="None" PagerStyle-BorderWidth="1" AlternatingRowStyle-BorderStyle="None" PagerStyle-CssClass="pagination-ys" GridLines="None" AlternatingRowStyle-BackColor="#EEEEEE" BorderStyle="None" HeaderStyle-CssClass="hide" OnPageIndexChanging="scnGridView_PageIndexChanging">
               <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="DocId " DataNavigateUrlFormatString="/es/others/acknowledgements/acknowledgement-mng-edit/{0}"
                        Text="<img src='/a_img/a_site/ico16/ico-write.png' alt='Edit' border='0'>" HeaderText="View" />
                    <asp:HyperLinkField DataNavigateUrlFields="DocId" DataNavigateUrlFormatString="/es/others/acknowledgements/acknowledgement/{0}"
                        Text="<img src='/a_img/a_site/ico16/ico-sheet.png' alt='Show' border='0'>" HeaderText="View" />
                    <asp:BoundField DataField="DocId" HeaderText="Doc" SortExpression="Id" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                </Columns>

            </asp:GridView>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="MainContent_Top">
</asp:Content>

