using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_dlg
{
    public partial class dlgMsgMail : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Random rRamdom = new Random();
                scnNumA.Text = rRamdom.Next(0, 10).ToString();
                scnNumB.Text = rRamdom.Next(0, 10).ToString();
            }
        }
        private bool FncScrValidation()
        {
            bool bOk = true;
            string szError = "";
            scnFrom.Text = scnFrom.Text.Trim().ToLower();
            scnFrom2.Text = scnFrom2.Text.Trim().ToLower();
            scnSubject.Text = scnSubject.Text.Trim();
            scnBodyMessage.Text = scnBodyMessage.Text.Trim();
            //
            if (scnFrom.Text == "")
            {
                bOk = false;

                szError += "Email empty. ";
            }


            if (!cls.ClsUtils.FncIsMailOk(scnFrom.Text))
            {
                bOk = false;

                szError += "Email Incorrect. ";
            }

            if (scnFrom.Text != scnFrom2.Text)
            {
                bOk = false;

                szError += "Email not mach. ";
            }

            if (scnSubject.Text == "")
            {
                bOk = false;

                szError += "Subject empty. ";
            }
            if (scnBodyMessage.Text == "")
            {
                bOk = false;

                szError += "Message empty.";
            }

            try
            {
                int a = Convert.ToInt16(scnNumA.Text);
                int b = Convert.ToInt16(scnNumB.Text);
                int c = Convert.ToInt16(scnNumC.Text);
                if (c != a + b)
                {
                    bOk = false;
                    szError += "<br/>The verification sum not match";
                }

            }
            catch
            {
                bOk = false;
                szError += "The verification sum not match</br>";
            }

            if (!bOk)
            {
                scnMessage.ForeColor = System.Drawing.Color.Red;
                scnMessage.Text = szError;
            }
            else
            {
                scnMessage.ForeColor = System.Drawing.Color.Black;
                scnMessage.Text = "Ok, you are send message";

            }
            return bOk;
        }
        protected void scnBtnSnd_Click(object sender, EventArgs e)
        {
            bool bSend = false;
            cls.tools.ClsMailer oMailer = new testudines.cls.tools.ClsMailer();
            string emTo = scnFrom.Text.Trim();
            string emSubject = "Testudines.org Contact from " + scnFrom.Text;

            string emBody = "";
            emBody += "<h3>Testudines.org Contact form.</h3>";
            emBody += "<b>From:</b> " + scnFrom.Text.Trim() + "<br />";
            emBody += "<b>Date:</b> " + System.DateTime.Today.ToLongDateString() + "-" + System.DateTime.Now.ToShortTimeString() + "<br />";
            emBody += "<b>Subject:</b> " + scnSubject.Text.Trim() + "<br /><hr/>";
            emBody += "<b>Body:</b><br/> " + scnBodyMessage.Text.Trim() + "<br />";

            if (FncScrValidation())
            {
                bSend = oMailer.FncSendMail(testudines.cls.tools.ClsMailer.eMailType.ToWebManager, emTo, emSubject, emBody, "");

                if (bSend)
                {
                    scnPanMail.Visible = false;
                    scnMessage.Text = "<h3>Message sended</h3>" + "<br/>" + emBody; ;

                }
                else
                {
                    scnMessage.Text = "No enviado";
                }
            }
        }
    }
}
