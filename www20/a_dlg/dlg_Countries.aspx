<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dlg_Countries.aspx.cs" Inherits="testudines.a_dlg.dlg_Countries"  EnableTheming="False" Theme="no" StylesheetTheme="no" %>
<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Country selector</title>

<script type="text/javascript"  language="javascript">

function FncDone()
 {

    //devuleve los parametros al formulario anterior
        var MyArgs = new Array();
        MyArgs[0] = document.getElementById('scnXX_CountriesNamesTxt').value;
        MyArgs[1] = document.getElementById('scnXX_CountriesCodesTxt').value;
        window.returnValue = MyArgs;
        window.close();
        return true;
}


</script>
</head>
<body  >
    <form id="form1" runat="server" target ="_self"  >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


<h1>Select countries tool</h1>
<span style ="float:right;"><br />Ref. Doc:<asp:Label ID="scnDocId" runat="server" Text="scnDocId"></asp:Label>
</span>

<asp:Label ID="scnCoutriesNameLbl" runat="server" Text="Countries Names" Width="25ex"></asp:Label>
<span style ="float:right; display :block; ">
<asp:Button ID="scnBtnSelectedCountries" PostBackUrl="#"  runat="server" onclick="scnBtnSelected_Click" Text="Update" BackColor="#CCCCCC" BorderStyle="Outset" EnableTheming="False" />
<button onclick="FncSetParentImage()" type="button">Return</button>
   </span>
        <ajaxToolkit:Accordion ID="MyAccordion" runat="server" SelectedIndex="0"
            HeaderCssClass="accordionHeader" 
            HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" 
            TransitionDuration="250" AutoSize="Limit" RequireOpenedPane="false" 
        SuppressHeaderPostbacks="true" Width="100%" Height="100%" >
           <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header><a href="" class="accordionLink">1. Africa</a></Header>
                <Content>

<div>

<div class ="chkBoxV2" >
    <asp:Label ID="scnAF_CENTRALbl" runat="server" Text="AMN"></asp:Label>
    <asp:CheckBoxList ID="scnAF_CENTRAChk" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow" Width="100%" CellPadding="5" CssClass="aspCheckBoxList">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2" >
    <asp:Label ID="scnAF_EASTERLbl" runat="server" Text="AMC"></asp:Label>
    <asp:CheckBoxList ID="scnAF_EASTERChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2" >
    <asp:Label ID="scnAF_NORTHELbl" runat="server" Text="AMS"></asp:Label>
    <asp:CheckBoxList ID="scnAF_NORTHEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2" >
    <asp:Label ID="scnAF_SOUTHELbl" runat="server" Text="EUR"></asp:Label>
    <asp:CheckBoxList ID="scnAF_SOUTHEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2" >
    <asp:Label ID="scnAF_WESTELbl" runat="server" Text="AFR"></asp:Label>
    <asp:CheckBoxList ID="scnAF_WESTEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
</div>

</Content>                  
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                <Header><a href="" class="accordionLink">2. Asia</a></Header>
                <Content>
             
<div class ="chkBoxV2">
    <asp:Label ID="scnAS_SOUCNTLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnAS_SOUCNTChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnAS_EASTERLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnAS_EASTERChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnAS_MIDEASTLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnAS_MIDEASTChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnASI_SOEASLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnASI_SOEASChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
       
                </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                <Header><a href="" class="accordionLink">3. America</a></Header>
                <Content>

<div class ="chkBoxV2">
    <asp:Label ID="scnAM_CARIBELbl" runat="server" Text="ASE"></asp:Label>
    <asp:CheckBoxList ID="scnAM_CARIBEChk" runat="server" RepeatDirection="Vertical"   >
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnAM_CENTRALbl" runat="server" Text="ASO"></asp:Label>
    <asp:CheckBoxList ID="scnAM_CENTRAChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnAM_SOUTHELbl" runat="server" Text="OCE"></asp:Label>
    <asp:CheckBoxList ID="scnAM_SOUTHEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnAM_NORTHELbl" runat="server" Text="SEA"></asp:Label>
    <asp:CheckBoxList ID="scnAM_NORTHEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>


             


   </Content>
            </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                <Header><a href="" class="accordionLink">4. Oceania</a></Header>
                <Content>
                   
<div class ="chkBoxV2">
    <asp:Label ID="scnOCN_AUSNZLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnOCN_AUSNZChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>

<div class ="chkBoxV2">
    <asp:Label ID="scnOCN_MELANLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnOCN_MELANChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>

<div class ="chkBoxV2">
    <asp:Label ID="scnOCN_MICROLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnOCN_MICROChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>

<div class ="chkBoxV2">
    <asp:Label ID="scnOCN_POLYNLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnOCN_POLYNChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>


                </Content>
            </ajaxToolkit:AccordionPane>

            <ajaxToolkit:AccordionPane ID="AccordionPane6" runat="server"  >
                <Header><a href="" class="accordionLink">4. Europe</a></Header>
                <Content>
            <div class ="chkBoxV2">
    <asp:Label ID="scnEUR_WESTELbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnEUR_WESTEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>

<div class ="chkBoxV2">
    <asp:Label ID="scnEUR_NORTHLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnEUR_NORTHChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnEUR_SOUTHLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnEUR_SOUTHChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
<div class ="chkBoxV2">
    <asp:Label ID="scnEUR_EASTELbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnEUR_EASTEChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>      
                </Content>
            </ajaxToolkit:AccordionPane>


<ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                <Header><a href="" class="accordionLink">4. Oceans and Sea</a></Header>
                <Content>
<div class ="chkBoxV2">
    <asp:Label ID="scnSEALbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnSEAChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
           
<div class ="chkBoxV2">
    <asp:Label ID="scnANTARTLbl" runat="server" Text="DEF"></asp:Label>
    <asp:CheckBoxList ID="scnANTARTChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>
 <div class ="chkBoxV2">
    <asp:Label ID="scnDEFLbl" runat="server" Text="Other"></asp:Label>
    <asp:CheckBoxList ID="scnDEFChk" runat="server" RepeatDirection="Vertical">
    </asp:CheckBoxList>
</div>      
                </Content>
            </ajaxToolkit:AccordionPane>


            </Panes>
        </ajaxToolkit:Accordion>

<br />
<asp:TextBox ID="scnCountriesNamesTxt" runat="server" TextMode="MultiLine" 
    Width="100%" Height="50px" ReadOnly="True"></asp:TextBox>
<br /><asp:Label ID="scnCountriesCodeLbl" runat="server" Text="Country Codes" 
    Width="25ex"></asp:Label>
<br />
<asp:TextBox ID="scnCountriesCodesTxt" runat="server" TextMode="MultiLine" 
    Width="100%" Height="50px" ReadOnly="True"></asp:TextBox>
<br />Count:<asp:Label ID="clbSelectedItemCount" runat="server" 
    Text="clbSelectedItemCount"></asp:Label>

       



    </form>
    <script>
       function FncSetParentImage() {
            var Names = document.getElementById('scnCountriesNamesTxt').value ;
            var Keys = document.getElementById('scnCountriesCodesTxt').value;
            alert(Names);
            alert(Keys);
             if (window.opener != null && !window.opener.closed)
                {
                    var oScnParentNames = window.opener.document.getElementById('scnXX_AGeoCountriesNamesTxt');
                    var oScnParentKeys = window.opener.document.getElementById('scnXX_AGeoKeyCountries');
                    oScnParentNames.value = Names;
                    oScnParentKeys.value = Keys;
                 alert('qui');
            }
           alert('aqui')
                window.top.opener.focus();
                window.close();
            }
            function FncClose() {
                window.top.opener.focus();
                window.close();
            }
        </script>
</body>
</html>
