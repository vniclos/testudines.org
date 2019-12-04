<%@ Page Title="Images" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="images.aspx.cs" Inherits="testudines.images.images" %>

<%@ Register Assembly="Telerik.QuickStart" Namespace="Telerik.QuickStart" TagPrefix="cc1" %>
<%@ Register Assembly="RadTreeView.Net2" Namespace="Telerik.WebControls" TagPrefix="radT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style>
        .numbers {
            float: left;
            margin: 2px;
            padding: 2px;
            color: #999;
            font-size: 15px;
            font-size: 0.9em;
            font-size: 0.9rem;
        }

        .number {
            font-size: 0.9em;
            font-size: 0.9rem;
            font-weight: bold !important;
            padding-right: 4px;
            padding-left: 4px;
            margin: 1px;
            border-style: outset;
            border-width: 1px;
            border-color: #333;
            background: #efefef;
        }
        .th {
            border-radius: 3px;
            border: 1px solid #aaa;
            padding:5px;
            margin:5px;
        }

        a:hover {
            background: #cfcfcf;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>  <asp:Literal ID="scnTitle"  Text="<%$ Resources:Strings, images %>" runat="server"></asp:Literal></h2>
    <b>Gallery:</b>
    <asp:Literal ID="scnGalleryNodePath" Text="scnGalleryNode" runat="server"></asp:Literal>
    <div class="row">


        <asp:ListView ID="ListView2" runat="server">
            <LayoutTemplate>

                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>

            </LayoutTemplate>
            <ItemTemplate>
                <!-- "<a href=\"#mp_ImgTar#\" data-fancybox=\"images\" data-caption=\"#mp_ImgTitle#\" #data-fancybox-title#\"data-caption=\"#caption#\">	<img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>"; -->
                <a href='<%# DataBinder.Eval(Container.DataItem,"UrlFileTarget") %>' data-fancybox="images" title="www.testudines.org" data-group="set1">
                    <img src='<%# DataBinder.Eval(Container.DataItem,"UrlFile") %>' title='<%# DataBinder.Eval(Container.DataItem,"Title") %>'  class="th" alt="" />
                </a>

            </ItemTemplate>

            <EmptyItemTemplate>
                Sorry! No Item found found.

            </EmptyItemTemplate>
        </asp:ListView>

   </div>
    <div class="numbers">
        <asp:DataPager ID="DataPager2" PageSize="9" PagedControlID="ListView2"
            runat="server" OnPreRender="DataPager1_PreRender">
            <Fields>
                <asp:NumericPagerField NumericButtonCssClass="number" CurrentPageLabelCssClass="number" />
            </Fields>

        </asp:DataPager>
    </div>
    <asp:HiddenField ID="scnUrlRequest" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
    <h3 style="margin: 1px; border-bottom: 2px; border-bottom-style: solid; border-color: #666; color: #737357;">
        <asp:Label ID="scnLblFolder" runat="server" Text="Folders"></asp:Label>
    </h3>
    <asp:Label ID="scnMediaAlbun" runat="server" Text="<b>Image Album:</b>"></asp:Label>
    <asp:DropDownList ID="scnAlbumDirectoryList" runat="server" Style="width: 160px;" AutoPostBack="true"
        OnSelectedIndexChanged="scnAlbumDirectoryList_SelectedIndexChanged" />
    <hr style="background-color: #dedede; padding: 2px; height: 1px !important;" />
    <div id="divtree" class="column" style="float: left; padding: 0px; min-width: 260px; max-width: 100%; min-height: 400px; max-height: 400px; overflow: auto; border: 2px solid #333;">
        <radT:RadTreeView ID="scnTreeView" runat="server" Width="100%"
            OnNodeClick="scnTreeView_NodeClick" AutoPostBack="True">
        </radT:RadTreeView>

    </div>
</asp:Content>
