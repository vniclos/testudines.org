<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="keys-list.aspx.cs" Inherits="testudines.tortoises.keys.keys_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
    <style >
    .treenote{  -moz-border-bottom-colors: none;
    -moz-border-image: none;
    -moz-border-left-colors: none;
    -moz-border-right-colors: none;
    -moz-border-top-colors: none;
    background: -moz-linear-gradient(center top , #E3E3E3, #FFFFFF 85px) repeat scroll 0 0 transparent;
    border-color: #BFC0C2 #BFC0C2 #B6B7BA;
    border-radius: 3px 3px 3px 3px;
    border-style: solid;
    border-width: 1px;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.17), 0 -2px 0 rgba(0, 0, 0, 0.08) inset;
    display: inline-block;
    margin: 0 0 0px;
    width :100%;
    min-width: 300px;
    padding: 10px 15px 15px;}
.tree {
    -moz-border-bottom-colors: none;
    -moz-border-image: none;
    -moz-border-left-colors: none;
    -moz-border-right-colors: none;
    -moz-border-top-colors: none;
    background: -moz-linear-gradient(center top , #E3E3E3, #FFFFFF 85px) repeat scroll 0 0 transparent;
    border-color: #BFC0C2 #BFC0C2 #B6B7BA;
    border-radius: 3px 3px 3px 3px;
    border-style: solid;
    border-width: 1px;
    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.17), 0 -2px 0 rgba(0, 0, 0, 0.08) inset;
    display: inline-block;
    margin: 0 0 50px;
    min-width: 300px;
    padding: 10px 15px 15px;
     width :100%;
}
.tree ul {
    list-style: none outside none;
}
.tree li a {
    line-height: 25px;
}
.tree > ul > li > a {
    color: #3B4C56;
    display: block;
    font-weight: normal;
    position: relative;
    text-decoration: none;
}
.tree li.parent > a {
    padding: 0 0 0 28px;
}
.tree li.parent > a:before {
    background-image: url("/a_img/plus_minus_icons.png");
    background-position: 25px center;
    content: "";
    display: block;
    height: 21px;
    left: 0;
    position: absolute;
    top: 2px;
    vertical-align: middle;
    width: 23px;
}
.tree ul li.active > a:before {
    background-position: 0 center;
}
.tree ul li ul {
    border-left: 1px solid #D9DADB;
    display: none;
    margin: 0 0 0 12px;
    overflow: hidden;
    padding: 0 0 0 25px;
}
.tree ul li ul li {
    position: relative;
}
.tree ul li ul li:before {
    border-bottom: 1px dashed #E2E2E3;
    content: "";
    left: -20px;
    position: absolute;
    top: 12px;
    width: 15px;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="scnTaxonKeysList" runat= "server" Text ="taxon key list"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
     <script type="text/javascript">

        $(document).ready(function () {
            $('.tree li').each(function () {
                if ($(this).children('ul').length > 0) {
                    $(this).addClass('parent');
                }
            });

            $('.tree li.parent > a').click(function () {
                $(this).parent().toggleClass('active');
                $(this).parent().children('ul').slideToggle('fast');
                return false;
            });
        });

</script>
</asp:Content>
