<%@ Page Title="" Language="C#" MasterPageFile="~/Mpg_Site.Master" AutoEventWireup="true" CodeBehind="test tabpanel.aspx.cs" Inherits="testudines.a_test.test_tabpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
        <style>


        .tab-content {
            border-color:#dddddd !important;
            border: solid ;
            border-top:none ;
          border-width:2px;
            padding: 10px;
            border-radius: 5px;
            
            margin:0 1rem 1rem 1rem;
        }

        .nav-tabs {
            margin-bottom: 0;
            margin: 1rem 1rem 0rem 1rem;
        }
        .nav-link{background-color:#efefef ; margin-left:3px;  line-height:1rem;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <ul class="nav nav-tabs" role="tablist">
        <li class="nav-item">
            <a class="nav-link active" href="#tab1" role="tab" data-toggle="tab">profile</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#tab2" role="tab" data-toggle="tab">buzz</a>
        </li>
        <li class="nav-item">
            <a class="nav-link" href="#tab3" role="tab" data-toggle="tab">references</a>
        </li>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
        <div role="tabpanel" class="tab-pane fade show active" id="tab1"> tab 1</div>
        <div role="tabpanel" class="tab-pane fade" id="tab2">tab 2</div>
        <div role="tabpanel" class="tab-pane fade" id="tab3">tab 3</div>
    </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentAdmin" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
