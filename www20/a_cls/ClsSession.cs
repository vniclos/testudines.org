using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace testudines.cls
{
    public class ClsSession
    {
             
        
        private  bool m_IsLogged = false;
        private string m_pDocId ="" ;
        private string m_pDocIdImg ="";
        private string m_AUrlImagesFilter ="";
        private string m_pText ="";
       
         
        private cls.bbdd.ClsReg_tmst_user oUser = new testudines.cls.bbdd.ClsReg_tmst_user();
        public ClsSession() { ;}
        public void FncClear()
        {
            oUser.FncClear();
        }

        public bool FncUserActivateFromMail(Int32 pUserId)
        {
            m_IsLogged = false;
            if (!oUser.FncSqlFind(pUserId))
            {
                // esta intentando activar un usaurio que no existe
                return m_IsLogged;
            }
            
           if (oUser.IsBlocked  == false)
            {
                oUser.IsActive = true;
                m_IsLogged = true;
                oUser.FncSqlSave();
                System.Web.HttpContext.Current.Session["oSession"] = this;
            }
            return m_IsLogged;
        }

       
        public bool FncLogin(string szUserName, string szPasword)
        {
            oUser.FncClear(); 
            m_IsLogged = false;

            m_IsLogged = oUser.FncLogin(szUserName, szPasword);
            if(!m_IsLogged) m_IsLogged =oUser.FncFindIdEmailPwd(szUserName, szPasword);

            System.Web.HttpContext.Current.Session["oSession"] = this;
            return m_IsLogged ;
        }
        public  bool FncLogout()
        {
            oUser.FncClear();
            m_IsLogged = false;
            FncClear();
          //  m_IsLogged = oUser.FncLogin(szUserName, szPasword);


           
            System.Web.HttpContext.Current.Session["oSession"] = this;



            return true;
        }
        public string AUrlImagesFilter
        {
            get {
                return m_AUrlImagesFilter;
            }
            set {
                m_AUrlImagesFilter = value.Trim();
                System.Web.HttpContext.Current.Session["oSession"] = this;
            }
        }

        public string pDocId
        {
            get
            {
                return m_pDocId;
            }
            set
            {
                m_pDocId = value.Trim();
                System.Web.HttpContext.Current.Session["oSession"] = this;
            }
        }
        public string pDocIdImg
        {
            get
            {
                return m_pDocIdImg;
            }
            set
            {
                m_pDocIdImg = value.Trim();
                System.Web.HttpContext.Current.Session["oSession"] = this;
            }
        }
        public string pText
        {
            get
            {
                return m_pText;
            }
            set
            {
                m_pText = value.Trim();
                System.Web.HttpContext.Current.Session["oSession"] = this;
            }
        }
        
        
        public bool FncStdSave(){ return false;  ;}


        #region getset
        public bool IsLoged { get { return m_IsLogged; } set { m_IsLogged = value; } }
        public string IdLoginMail { get { return oUser.IdLoginMail; } }
        public string IdLoginName { get { return oUser.IdLoginName; } }
        public Int32  UserId { get { return oUser.UserId; } }
        public bool  IsActive { get { return oUser.IsActive; } }
        public bool IsAdmin { get { return oUser.IsAdmin; } }
        public bool IsEditor { get { return oUser.IsEditor; } }
        public bool IsTranslator { get { return oUser.IsTranslator; } }
        public string NameFull { get { return oUser.NameFull; } }
        public string AvatarURL    { get { return oUser.AvatarURL; } }
        public bool CanMailFromUser { get {return  oUser.CanMailFromUser; } }
       
       #endregion
  
            
        }


                }


