
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mail;
using System.Net.Mime;

using System.Collections.Generic;
using System.Web.SessionState;

namespace testudines.cls.tools
{
    // enviar mails y guardar una copia de los envios en la base de datos
    // 

    public class ClsMailer
    {
        private bool   m_bEnviado = false ;
       private string m_UserId="";
        private string m_IdLoginName="";
        private string m_ReplaceDate="";
        private string m_NameFull="";
        private string m_LinkContact="http://www.testudines.org/contact.aspx";
        private string m_LinkConfirmation = "";
        public   enum eFieldsReplade {UserId, IdLoginName,NameFull};
        private string m_bEnviadoResult="";
        public enum eMailType {NewUserConfirm,ToWebManager,ToUser,ToFriend,ToOther}
        public ClsMailer()
        { 
        }

        public bool FncSendMail(eMailType pMailType, string pMailToAddress, string pMailSubject, string pMailBody, string pLinkConfirmation)

        {
            m_LinkConfirmation = pLinkConfirmation;
            return FncSendMail(pMailType, "", "", pMailToAddress, "", "", "", pMailSubject, pMailBody);
        }

        public bool FncSendMail(eMailType pMailType, string pMailToAddress, string pMailFromDisplayName, string pMailBC, string pMailSubject, string pMailBody, string pLinkConfirmation)
        {
            m_LinkConfirmation = pLinkConfirmation;
            return FncSendMail(pMailType, "", pMailFromDisplayName, pMailToAddress, "", "", "", pMailSubject, pMailBody);
        }
/// <summary>
/// Send mail in format html and utf-8
/// </summary>
/// <param name="MailType"></param>
        /// <param name="pMailFrom">Email for sender if empty ClsGlobal.eMailSmtpFromDefault</param>
        /// <param name="pMailFromDisplayName">Nic name por serder, if empty ClsGlobal.eMailSmtpFromDefaultDisplayName</param>
        /// <param name="pMailToAddress">Email adress like pp@pp.com</param>
        /// <param name="pMailDisplayName">Display name or nick name for pp@pp.com</param>
/// <param name="pMailCC">Emal copy</param>
/// <param name="pMailBC">Email Blind copy</param>
/// <param name="pMailSubject">Subject of email</param>
/// <param name="pMailBody">Email body message in html format</param>
/// <returns></returns>
        public bool FncSendMail ( eMailType MailType, string pMailFrom,string pMailFromDisplayName, string pMailToAddress,string pMailToDisplayName, string pMailCC, string pMailBC, string pMailSubject, string pMailBody )
        {
            //----------------------------------------------------------
            //----------------------------------------------------------
            // prevencion de errores.
            //----------------------------------------------------------
            //----------------------------------------------------------
            if (pMailToAddress.Trim () == "") return false;


            //----------------------------------------------------------
            //----------------------------------------------------------
            m_bEnviado = false;
            System.Net.NetworkCredential oSMTPUserInfo = new System.Net.NetworkCredential( ClsGlobal.eMailSmtpUser, ClsGlobal.eMailSmtpPasword );
            System.Net.Mail.SmtpClient oSmtpClient = new System.Net.Mail.SmtpClient();
            System.Net.Mail.MailMessage oMail = new System.Net.Mail.MailMessage();
            // config connection to mailserver            
            oSmtpClient.Port=25;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Host=ClsGlobal.eMailSmtpServer   ;
            oSmtpClient.Credentials = oSMTPUserInfo;

            //config email message object
            oMail.BodyEncoding =  System.Text.Encoding.UTF8;
            oMail.SubjectEncoding = System.Text.Encoding.UTF8;
            oMail.IsBodyHtml =true ;
            
            // fill email message object
            

            if (pMailFrom == "") {pMailFrom = ClsGlobal.eMailSmtpFromDefault;}
            if (pMailFromDisplayName == "") { pMailFromDisplayName = ClsGlobal.eMailSmtpFromDefaultDisplayName ; }
            
            oMail.From  =new System.Net.Mail.MailAddress(pMailFrom,pMailFromDisplayName,System.Text.Encoding.UTF8 );;
            oMail.To.Add (pMailToAddress);
            if (pMailCC!="")  oMail.CC.Add(pMailCC);
            if (pMailCC != "") oMail.Bcc.Add(pMailBC);



            FncReplaceFields(ref pMailSubject);
            FncReplaceFields(ref pMailBody);
            oMail.Subject = pMailSubject;
            oMail.Body = pMailBody ;

         
            

            
            // send message.
            try 
            {
                oSmtpClient.Send (oMail );
                m_bEnviado = true;

                m_bEnviadoResult = "Ok, Mail sended by " + oMail.From +" to "+ pMailToAddress;
            }
            catch (Exception xcpt)
            {
                m_bEnviado = false;
                m_bEnviadoResult = xcpt.Message;
            }

            /// TODO PENDIENTE DE PROGRAMAR
            // PENDIENTE DE PROGRAMAR
            return m_bEnviado; 
        }

        private void FncReplaceFields(ref string szText){
            // build message and replace fields
            // cls.clsSession oSession  = (cls.clsSession ) System.Web.HttpContext.Current.Session["oSession"];

            MembershipUser currentUser = Membership.GetUser();
            
            szText =szText.Replace ("#UserId#", currentUser.UserName.ToString ());
       // szText = szText.Replace("#IdLoginName#", currentUser.UserName.ToString());
        //szText = szText.Replace("#NameFull#", currentUser.NameFull .ToString());
        szText = szText.Replace("#Date#", m_ReplaceDate);
        szText = szText.Replace("#LinkContact#", m_LinkContact );
        string sz = "<a href=\"" + m_LinkConfirmation + "\"> " + m_LinkConfirmation + "</a>";


        szText = szText.Replace("#LinkConfirmation#", sz);

        }

      

        public string ReplaceUserId { 
            set { m_UserId = value; }
            get { return m_UserId; }
        
        }
        public string ReplaceIdLoginName { 
            set { m_IdLoginName = value; } 
            get { return m_IdLoginName; } 
        }
        public string ReplaceDate { 
            set { m_ReplaceDate = value; } 
            get { return m_ReplaceDate; } 
        
        }
        public string ReplaceNameFull {
            set { m_NameFull = value; }
            get { return m_NameFull; }
        }
        public string ReplaceLinkContact {
            set { m_LinkContact = value; }
            get { return m_LinkContact; }
        
        }
        public string ReplaceLinkConfirmation { 
            set { m_LinkConfirmation = value; }
            get { return m_LinkConfirmation; }
        
        }
        public bool enviado
        { get { return m_bEnviado; } }
     }
        
        
        
    }
       
  

