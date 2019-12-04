<%@ page language="C#" autoeventwireup="true" codebehind="dlgMsgMail.aspx.cs" inherits="testudines.a_dlg.dlgMsgMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Testudines Email contact form</title>

</head>

<body>
    <form id="formMail" runat="server">
        <div class="container">

            <asp:Panel ID="scnPanMail" runat="server">
                <fieldset>
                    <legend>Contact</legend>

                    <b>
                        <asp:Label ID="scnFromTit" runat="server" Text="<%$ Resources:Strings, mail_BoxTitle %>" Width="120px"></asp:Label></b>
                    <asp:TextBox ID="scnFrom" placeholder="<%$ Resources:Strings, MSG_Your_email %>" type="email" required Width="100%" runat="server"></asp:TextBox>

                    <br />
                    <b>
                        <asp:Label ID="scnFrom2Tit" Width="120px" runat="server" Text="<%$ Resources:Strings, mail_your_emailRepite %>"></asp:Label></b>
                    <asp:TextBox ID="scnFrom2" type="email"
                        placeholder="<%$ Resources:Strings, MSG_repeatemail %>" required Width="100%" runat="server"></asp:TextBox>

                    <hr />
                    <b>
                        <asp:Label ID="scnSubjectTit" Width="120px" runat="server" Text="<%$ Resources:Strings, mail_Subject %>"></asp:Label></b>
                    <br />
                    <asp:TextBox ID="scnSubject" type="text" placeholder="Subject." required Width="100%" runat="server"></asp:TextBox>
                    <hr />
                    <b>
                        <asp:Label ID="scnBodyTit" Width="120px" runat="server" Text="<%$ Resources:Strings, mail_message %>"></asp:Label></b>

                    <asp:TextBox runat="server" name="scnBodyMessage" ID="scnBodyMessage"
                        placeholder="Enter your message" Rows="10" cols="20" required MaxLength="500"
                        Height="80px" TextMode="MultiLine" Width="100%"></asp:TextBox>

                    <br />
                    <asp:Label ID="scnNumAsk" runat="server" Text="<%$ Resources:Strings, mail_ContactAsk %>"></asp:Label>
                    <asp:Label ID="scnNumA" runat="server" Text="1"></asp:Label>
                    <asp:Label ID="sncNumOp" runat="server" Text="+"></asp:Label>
                    <asp:Label ID="scnNumB" runat="server" Text="2"></asp:Label>
                    =
            <asp:TextBox ID="scnNumC" Width="20px" runat="server"></asp:TextBox>

                    <span class="right">
                        <asp:Button ID="scnBtnSnd" runat="server" Text="<%$ Resources:Strings, mail_ContactSend %>"
                            OnClick="scnBtnSnd_Click" />


                    </span>
                    <br />
                </fieldset>
            </asp:Panel>



            <asp:Label ID="scnMessage" Width="400px" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
