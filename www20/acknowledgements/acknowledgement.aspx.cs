using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.acknowledgements
{
    public partial class acknowledgement : cls.ClsPageBase
    {
        private UInt64 m_DocId = 0;
      
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncFill();


            }
        }
        private void FncFill()
        {
          
            cls.bbdd.ClsReg_tdoc_acknowledgment OAckno = new testudines.cls.bbdd.ClsReg_tdoc_acknowledgment();
            FncGetParameters( ref OAckno);
            OAckno.FncSqlFind(m_DocId);
            FncFilHead( ref OAckno);
            FncFillBreadCrumb(ref OAckno);
            FncFillMainContent(ref  OAckno);
            FncEditButtons(ref OAckno);
            FncFillMainContentRight(ref OAckno);
        }

       
 
 private void FncEditButtons(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/others/acknowledgement-mng-edit/"+ OAckno.DocId.ToString()+"\">" + Resources.Strings.Edit + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/others/acknowledgements-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/others/acknowledgement-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }
        private void FncGetParameters(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
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
              
              
                bool bExist= OAckno.FncSqlFind(DocId);

                if (bExist)
                {
                
                FncFillMainContent( ref OAckno);

                }
                else
                {
                

                }

            }

   

        private void FncFilHead(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {

            Page_Title=Resources.Strings.Acknowledgements + " " + OAckno.Title;
        }

        private void FncFillBreadCrumb(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {


            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers, "/others/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, "/others/acknowledgements-list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegment + ": "+OAckno.Title,"");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }



        private void FncFillMainContent(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oCache = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();
            scnMainContet.Text = oCache.FncCache_GET_Reg(m_DocId, cls.ClsGlobal.LngIdThread, cls.ClsGlobal.CacheRebuid);
            if (!cls.ClsUtils.User_isAdmin())
            {
                /*szMailUrl="<a href=\"mailto:\"+email+ "?Subject=testudines.org \" target=\"_top\">Send Mail</a>"*/
                string szMailUrl = "<a href=\"mailto:\"" + OAckno.Email + "?Subject = testudines.org \" target=\"_top\"><span class=\"glyphicon glyphicon-envelope\"></span></a>";
                      scnMainContet.Text += "<br><b>Email</b>" + OAckno.Email+ szMailUrl;
            }
                scnMainContetRight.Text = oCache.FncCache_GET_SpeciesCollaborate(ref m_DocId);
            

            
        }
        private void FncFillMainContentRight(ref cls.bbdd.ClsReg_tdoc_acknowledgment OAckno)
        {
            scnMainContetRight.Text +="<h3>"+ Resources.Strings.Thanks+"</h3>"; 

        }
    }
}