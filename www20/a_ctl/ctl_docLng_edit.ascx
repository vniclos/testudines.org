<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctl_docLng_edit.ascx.cs" Inherits="testudines.a_ctl.ctl_docLng_edit" %>
<h2>Metadata for each language</h2>

<br/><asp:Label ID="scnDocLngMetaTitleTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaTitle %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaTitle" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="250"></asp:TextBox>

<br/><asp:Label ID="scnDocLngMetaDescriptionTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaDescription %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaDescription" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="150"></asp:TextBox>

<br/><asp:Label ID="scnDocLngUrlIdTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngUrlId %>"></asp:Label>
<asp:Label ID="scnDocLngUrlId2" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="250" ReadOnly ="true" ></asp:Label>
<br /><asp:Label ID="scnDocLngUrlTitle2" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="250" ReadOnly ="true" ></asp:Label>

<br/><asp:Label ID="scnDocLngMetaKeyWordsTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaKeyWords %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaKeyWords" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="150"></asp:TextBox>




<br/><asp:Label ID="scnDocLngMetaAuthorTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaAuthor %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaAuthor" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="150"></asp:TextBox>

<br/><asp:Label ID="scnDocLngMetaTranslatorsTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaTranslators %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaTranslators" CssClass ="fieldtext" runat="server" 
        Width="100%" MaxLength="150"></asp:TextBox>


<br/><asp:Label ID="scnDocLngcopyrightTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, DocLngcopyright %>"></asp:Label>
<asp:TextBox ID="scnDocLngCopyright" CssClass ="fieldtext"  
        Text ="2012 Testudines.org  and others" runat="server" Width="100%" 
        MaxLength="150" Height="22px"></asp:TextBox>





<br/><asp:Label ID="scnDocLngIdTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngId %>"></asp:Label>
<asp:label ID="scnDocLngId2" CssClass ="fieldtext" text="Englisth" runat="server"></asp:label>

<br/><asp:Label ID="scnDocId_todoTit" CssClass ="fieldname" runat="server" 
Text="Todo"></asp:Label>
<asp:label ID="scnDocId_todo" CssClass ="fieldtext" text="0" runat="server"></asp:label>

<h2><asp:Label ID="scnH2SeoSpecialFields" runat="server" Text="<%$ Resources:Strings, scnH2SeoSpecialFields %>"></asp:Label></h2>
<p>
<br/><asp:Label ID="scnDocLngStatusRevisionTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, Status_Revision %>"></asp:Label>
<asp:DropDownList ID="scnDocLngStatusRevision" CssClass ="fieldtext"  runat="server" 
        Width="250px">
    <asp:ListItem>Revised</asp:ListItem>
    <asp:ListItem>Not revised</asp:ListItem>
    <asp:ListItem>Warning</asp:ListItem>
     </asp:DropDownList>



<br/><asp:Label ID="scnDocLngMetaLanguageTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaLanguage %>"></asp:Label>

    

    <asp:Label ID="scnDocLngMetaLanguage" runat="server" Text="scnDocLngMetaLanguage"></asp:Label>
<br/><asp:Label ID="scnDocLngMetaRobotsTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaRobots %>"></asp:Label>
   
    <asp:DropDownList ID="scnDocLngMetaRobots" CssClass ="fieldtext"  
        runat="server" Width="250px">
    <asp:ListItem>index, follow</asp:ListItem>
    <asp:ListItem>index, nofollow</asp:ListItem>
     <asp:ListItem>noindex, nofollow</asp:ListItem>

    </asp:DropDownList>
    
    
<br/><asp:Label ID="scnDocLngMetarevisit_afterTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, DocLngMetarevisit_after %>"></asp:Label>
<asp:DropDownList ID="scnDocLngMetarevisit_after" CssClass ="fieldtext"  
        runat="server" Width="250px">
    <asp:ListItem>1 Day</asp:ListItem>
    <asp:ListItem>7 Days</asp:ListItem>
    <asp:ListItem>15 Days</asp:ListItem>
    <asp:ListItem Selected="True">1 Month</asp:ListItem>
    <asp:ListItem>3 Month</asp:ListItem>
   
    <asp:ListItem>6 Month</asp:ListItem>
 <asp:ListItem Value="1 year"></asp:ListItem>
    </asp:DropDownList>
<br/><asp:Label ID="scnDocLngMetaContentTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, scnDocLngMetaContent %>"></asp:Label>
<asp:TextBox ID="scnDocLngMetaContent" CssClass ="fieldtext" text ="text/html; charset=iso-8859-1" runat="server"></asp:TextBox>

<br/><asp:Label ID="scnDocLngDateUpdateTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, Last_Update %>"></asp:Label>
<asp:Label ID="cnDocLngDateUpdate" CssClass ="fieldtext" Text ="12 Enero 1998" runat="server"></asp:Label>

<br/><asp:Label ID="scnDocLngDateCreationTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, Date_Creation %>"></asp:Label>

<asp:Label ID="scnDocLngDateCreation" CssClass ="fieldtext" runat="server"></asp:Label>

<br/><asp:Label ID="scnDocLngNotesTit" CssClass ="fieldname" runat="server" 
Text="<%$ Resources:Strings, Notes %>"></asp:Label>
<br /><asp:TextBox ID="scnDocLngNotes" CssClass ="fieldtext" runat="server" 
        TextMode="MultiLine" Width="100%"></asp:TextBox>
</p>