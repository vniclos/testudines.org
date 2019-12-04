<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dlgMsgDocId.aspx.cs" Inherits="testudines.a_dlg.dlgMsgDocId" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<link href="/Content/Site.css" rel="stylesheet" />
    <title>Mail about one specific image on site</title>
    <script type="text/javascript">
        function jsReadDialogArgs() {
            if (window.dialogArguments == "") {
                document.getElementById('scnpDocId').innerHTML = "No arguments";

            } else {
                document.getElementById('scnMsgImgURL').value = window.dialogArguments[0];
                document.getElementById('scnpMsgImgDocId').value = window.dialogArguments[1];
                document.getElementById('scnpMsgImgTit').value = window.dialogArguments[2];

            }
        }
         

    </script>
    <style type="text/css">
        body, html, form, .fancybox.iframe
        {
            width:400px;
            height: auto;
            overflow: auto;
        }
    </style>
</head>
<body onload="return jsReadDialogArgs();">
    <form id="form1" runat="server">
    <asp:Panel class="dlgMsgRound" runat="server" ID="sncPnlMsg" Visible="true">
        <div class="row" style="max-width: 95%">
            <input type="button" class="xClose" value="X" onclick="parent.jQuery.fancybox.close(); return false;"/>
            <fieldset>
                <legend>
                    <asp:Label ID="sncTit2" runat="server" Text="<%$ Resources:Strings, MSG_about_image_or_document %>"></asp:Label>
                </legend>
                <label>
                    Email:
                    <asp:TextBox runat="server" name="scnemail1" ID="scnemail1" type="email" placeholder="<%$ Resources:Strings, MSG_Your_email %>"
                        required Width="100%"></asp:TextBox>
                </label>
                <label>
                    Email:
                    <asp:TextBox runat="server" name="scnemail2" ID="scnemail2" type="email" placeholder="<%$ Resources:Strings, MSG_repeatemail %>"
                        required Width="100%"></asp:TextBox>
                </label>
                <label>
                    Subject:
                    <asp:TextBox runat="server" name="scnSubject" ID="scnSubject" type="text" placeholder="Subject."
                        required Width="100%"></asp:TextBox>
                </label>
                <label>
                    Message:
                    <asp:TextBox runat="server" name="scnMessage" ID="scnMessage" placeholder="Enter your message"
                        Rows="10" cols="20" required MaxLength="500" Height="80px" TextMode="MultiLine"
                        Width="100%"></asp:TextBox>
                </label>
                <input class="button right" type="submit" name="submit" id="submit" value="Send" />
                <hr />
                <h4>
                    Reference:</h4>
                 Doc-Sec:&nbsp;<asp:Label ID="scnpMsgImgSecLbl" style="font-weight:normal;"  runat="server" Text=""></asp:Label>
                <br /> Img. Id:&nbsp;<asp:Label ID="scnpMsgImgDocIdLbl" style="font-weight:normal;" runat="server" Text=""></asp:Label>
                <br />Tit.:&nbsp;<asp:Label ID="scnpMsgImgTitLbl" style="font-weight:normal;" runat="server" Text=""></asp:Label>
                <div style="visibility: hidden; height: 0; width: 0; overflow: hidden;">
                    <asp:Label ID="scnMsgImgURLLbl" runat="server" Text=""></asp:Label>
                </div>
            </fieldset>
        </div>
        <script lang='javascript' type='text/javascript'>
            function check(input) {
                if (input.value != document.getElementById('email1').value) {
                    input.setCustomValidity('Email Must be Matching.');
                } else {
                    // input is valid -- reset the error message
                    input.setCustomValidity('');
                }
            }
        </script>
    </asp:Panel>
    <asp:Panel runat="server" ID="sncPnlEndOk">
        <div class="row">
            <fieldset>
                <legend>Gracias - Thanks</legend>
                <div class="panel">
                    <h4>
                        Gracias por su colaboracíon</h4>
                    <br />
                    <p>
                        Cualquier corrección o aportación de contenido es muy bien recibida. Me pondre en
                        contacto con usted lo antes que pueda. Recibiras una copia de tu mensaje en tu buzon</p>
                </div>
                <div class="panel">
                    <h4>
                        Thanks you for your collaboration</h4>
                    <p>
                        Any corrections, or contributions of content are welcome. I will contact you as
                        soon as possible. You'll receive a copy of the message</p>
                </div>
                Vicente Niclós (www.testudines.org)
            </fieldset>
        </div>
    </asp:Panel>
    <asp:Panel ID="sncPnlEndNO" runat="server" Visible="false">
        <div class="row">
            <fieldset>
                <legend>Gracias - Thanks</legend>
                <div class="panel">
                    <h4>
                        ¡ Opss !</h4>
                    <br />
                    <p>
                        Lo siento no se ha podido enviar el mensaje.
                    </p>
                    <br />
                    <p>
                        Por favor intentelo mas tarde.
                    </p>
                </div>
                <div class="panel">
                    <h4>
                        Opss/<h4>
                    <p>
                        I'm Sorry i cant send the message</p>
                    <p>
                        Please, Could you try later</p>
                </div>
                Vicente Niclós (www.testudines.org)
            </fieldset>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
