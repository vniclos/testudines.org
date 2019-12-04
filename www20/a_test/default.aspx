<%@ page title="" language="C#" masterpagefile="~/Mpg_Site.Master" autoeventwireup="true" codebehind="default.aspx.cs" inherits="testudines.a_test._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent_Top" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel class="form-group" runat="server" ID="scnUpdtPannel1">
       <ContentTemplate>
            <h3>Test event button</h3>
            <asp:Label ID="scnTest1_lbl" for="scnTest1_btn" runat="server" Text="click"></asp:Label>
            <asp:Button ID="scnTest1_btn" class="btn btn-primary btn-sm" runat="server" Text="Click button" OnClick="scnTest1_btn_Click" />
            <asp:TextBox ID="scnTest1_Txt" CssClass="form-control" runat="server" Text=""></asp:TextBox>
           </ContentTemplate>
       
    </asp:UpdatePanel>

    <div class="pannel">
        <h2>Help bootstrap 4</h2>
        <ul>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/forms/" >forms</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/layout/" >Layout</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/content/" >Content</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/components/" >Components</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/alerts/" >Alerts</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/badge/" >Badge</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/breadcrumb/" >Breadcrumb</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/forms/" >Button_group</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/card/" >Card</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/carousel/" >Carousel</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/collapse/" >Collapse</a></li>

   
            <li> <a href="https://v4-alpha.getbootstrap.com/components/input-group/" >Input group</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/jumbotron/" >Jumbotron</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/list-group/" >List group</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/pagination/" >Pagination</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/navbar/" >Navbar</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/popovers/" >Popovers</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/progress/" >Progress</a></li>

            <li> <a href="https://v4-alpha.getbootstrap.com/components/scrollspy/" >Scrollspy</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/tooltips/" >Tooltips</a></li>
            <li> <a href="https://v4-alpha.getbootstrap.com/components/utilities/" >Utilities</a></li>
                 


        </ul>
        <h2>Breadcrumb</h2>
        <pre><code>


             </code></pre>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentRight" runat="server">
</asp:Content>
