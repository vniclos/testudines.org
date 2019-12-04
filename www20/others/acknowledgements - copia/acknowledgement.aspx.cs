using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.others.acknowledgements
{
    public partial class acknowledgement : cls.ClsPageBase
    {
        private UInt64 m_DocId = 0;
      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fncFill();


            }
        }
        private void fncFill()
        {
          
            cls.bbdd.ClsReg_tdoc_acknowledgment OAckno = new testudines.cls.bbdd.ClsReg_tdoc_acknowledgment();
            fncGetParameters( ref OAckno);
            OAckno.fncSqlFind(m_DocId);
            fncFilHead( ref OAckno);
            fncFillBreadCrumb(ref OAckno);
            fncFillMainContent(ref  OAckno);

            fncFillMainContentRight(ref OAckno);
        }


        private void fncGetParameters(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {

            
                UInt64 DocId = 41448;
                String DocLngId = "es";



                try
                {
                    DocId = Convert.ToUInt64(Page.RouteData.Values["docid"].ToString());
                    DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
                }
                catch {; }
                if (Request.QueryString["docid"] != null)
                {
                    DocId = Convert.ToUInt64(Request.QueryString["docid"].ToString());
                }
                if (Request.QueryString["doclngid"] != null)
                {
                    DocLngId = Request.QueryString["doclngid"].ToString();
                }
                m_DocId = DocId;
               // m_DocLngId = DocLngId;
              
              
                bool bExist= OAckno.fncSqlFind(DocId);

                if (bExist)
                {
                
                fncFillMainContent( ref OAckno);

                }
                else
                {
                

                }

            }

   

        private void fncFilHead(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {

            Page_Title=Resources.Strings.Acknowledgements + " " + OAckno.Title;
        }

        private void fncFillBreadCrumb(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {


            string szBreadCrumb = "";
            cls.ClsHtml.fncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers, "/others/");
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, "/others/acknowledgements-list");
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegment + ": "+OAckno.Title,"");
            cls.ClsHtml.fncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_fncBreadCrumb(ref szBreadCrumb);
        }



        private void fncFillMainContent(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oCache = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();
            scnMainContet.Text = oCache.fncCache_GET_Reg(m_DocId, cls.ClsGlobal.LngIdThread, cls.ClsGlobal.CacheRebuid);
            if (!cls.ClsUtils.User_isAdmin())
            {
                /*szMailUrl="<a href=\"mailto:\"+email+ "?Subject=testudines.org \" target=\"_top\">Send Mail</a>"*/
                string szMailUrl = "<a href=\"mailto:\"" + OAckno.Email + "?Subject = testudines.org \" target=\"_top\"><span class=\"glyphicon glyphicon-envelope\"></span></a>";
                      scnMainContet.Text += "<br><b>Email</b>" + OAckno.Email+ szMailUrl;
            }
                scnMainContetRight.Text = oCache.fncCache_GET_SpeciesCollaborate(ref m_DocId);
            

            
        }
        private void fncFillMainContentRight(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {
            scnMainContetRight.Text +="<h3>"+ Resources.Strings.Thanks+"</h3>"; 

        }
    }
}