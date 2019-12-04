using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_dlg
{
    public partial class dlgMsgDocId : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                  string m_imgurl = "";
         string m_imgdocid = "";
         string m_imgname = "";
         string m_imgsec = "";

                sncPnlMsg.Visible = true;
               
                sncPnlEndNO.Visible = false;
                sncPnlEndOk.Visible = false;
                //private const string mc_OpenDlg_MsgDocid = "<a class=\"fancybox fancybox.iframe\" href=\"/a_dlg/dlgMsgDocId.aspx?'urlImg=#mp_ImgTh#&ImgDocId=#ImgDocId#%&name=#NameSpecieWithVulgar#&sec=#SectionFile#]\"><img class=\"right\" src=\"/app_themes/default/img/msg-warning.png\" title=\"Send msg about this image\"/></a>";
                //imgurl=#mp_ImgTh#
                //imgdocid=#ImgDocId#%
                //imgname=#NameSpecieWithVulgar#&
                //imgsec=#SectionFile#]\"><img class=\"right\" src=\"/app_themes/default/img/msg-warning.png\" title=\"Send msg about this image\"/></a>";
                try
                {

                    // http://localhost:61846/a_dlg/dlgMsgDocId.aspx?
                    // %27urlImg=/mmedia/testudines/or_testudines/so_cryptodiras/sf_testudinoidea/fa_geoemydidae/sf_geoemydinae/ge_rhinoclemmys/es_rhinoclemmys_pulcherrima/rinochelys_pucherrima_ran_v._niclos_www.testudines.org001_med.jpg
                    // &ImgDocId=10672%
                    // &name=Rhinoclemmys%20pulcherrima:%20%20Range%20distribution
                    // &sec=ind_Chapter01_03AbsRng]
                    if (Request.QueryString[0].ToString() != null) m_imgurl = Request.QueryString[0].ToString();
                    if (Request.QueryString[1].ToString() != null) m_imgdocid = Request.QueryString[1].ToString();
                    if (Request.QueryString[2].ToString() != null) m_imgname = Request.QueryString[2].ToString();
                    if (Request.QueryString[3].ToString() != null) m_imgsec = Request.QueryString[3].ToString();

                }
                catch (Exception xcpt)
                {
                    string sz = xcpt.Message; 
                }
                scnMsgImgURLLbl.Text  =m_imgurl;
                scnpMsgImgDocIdLbl.Text  =m_imgdocid.Replace ("%","");
                scnpMsgImgTitLbl.Text = m_imgname;
                scnpMsgImgSecLbl.Text = m_imgsec;
                    
                
            



            }
            else
            {
                sncPnlMsg.Visible = false;
              
                if (fndSendMessage())
                {
                   
                    sncPnlEndOk.Visible = true;
                   
                    sncPnlEndNO.Visible = false;
                   
                   
                }
                else
                {
                    sncPnlEndOk.Visible = false;
                   
                    sncPnlEndNO.Visible = true;
                   
                }
                
                
            }
        }
        private bool fndSendMessage()
        {
            bool bOk = false;
            cls.tools.ClsMailer oMailer = new cls.tools.ClsMailer();
       

            string pMailFrom = cls.ClsGlobal.eMailSmtpFromDefault ;
            string pMailFromDisplayName = cls.ClsGlobal.eMailSmtpFromDefaultDisplayName;
            string pMailToAddress = cls.ClsGlobal.eMailAddressContact ; // mensaje para el administrador
            string pMailToDisplayName = "";
            string pMailCc = scnemail1.Text  ; // copia para el remitente
            string pMailBcc = "vte.niclos@gmail.com"; // copia para cuenta gmail de administrador

            string pMailsubject ="testudines.org: Aviso en referente a la imagen: " +scnpMsgImgDocIdLbl.Text ;
            string pMailBody =  "<b>"+Resources.Strings.subject +":</b> " + scnSubject.Text.Trim() +"<br/>";
            pMailBody += "<b>"+Resources.Strings.Message+"</b><br/>" + scnMessage.Text.Trim();
            pMailBody += "<hr /><h5/>" + Resources.Strings.Reference + "</h5>";
            pMailBody += "<b>Mail from:</b><br /> " + scnemail1.Text;
            pMailBody += "<br /><b>Title:</b><br /> " + scnpMsgImgTitLbl.Text;
            pMailBody += "<br /><b>Img Id:</b><br />" + scnpMsgImgDocIdLbl.Text;
            pMailBody += "<br /><b>Img url:</b><br />" + scnMsgImgURLLbl.Text;
            pMailBody += "<br /><img src=\"" + cls.ClsGlobal.UrlRoot + scnMsgImgURLLbl.Text + "\"/>"; ;


            bOk=oMailer.FncSendMail(cls.tools.ClsMailer.eMailType.ToOther, pMailFrom, pMailFromDisplayName, pMailToAddress,
                pMailToDisplayName, pMailCc, pMailBcc, pMailsubject,pMailBody);
            return bOk;
        }
    }
}