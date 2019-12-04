using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.notices
{
    public partial class notice : cls.ClsPageBase
    {

        private cls.bbdd.ClsReg_tdoclng_notices oNotice = new cls.bbdd.ClsReg_tdoclng_notices();
        private cls.ClsUserContest oUsr = new cls.ClsUserContest();
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "es";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();
                FncFill();
                FncEditButtons();
                FncStadisticVisitAdd();
            }

        }
        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {

                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/notices/notices-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/notices/notice-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }


        private void FncFill()
        {
           

            cls.bbdd.ClsReg_tdoclng_notices oNotice = new testudines.cls.bbdd.ClsReg_tdoclng_notices();
            cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();

            bool bExist = true;
            bExist = oDoc.FncSqlFind(m_DocId);
            if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

            if (bExist)
            {
                FncFill(ref oDoc, ref oDocLng, ref oNotice);

            }
          

        }

        
            private void FncGetParameters()
            {
   
            UInt64 DocId = 10304;
                String szDocId = ""; //puede contener la url con titulo
                String DocLngId = "es";
                try
                {
                    szDocId = Page.RouteData.Values["docid"].ToString();
                    DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
                }
                catch {; }
                if (Request.QueryString["docid"] != null)
                {
                    szDocId = Request.QueryString["docid"].ToString();
                }
                if (Request.QueryString["doclngid"] != null)
                {
                    DocLngId = Request.QueryString["doclngid"].ToString();
                }
                //------- si docId es texto buscar su id
                try
                {
                    DocId = Convert.ToUInt64(szDocId);

                }
                catch
                {
                    DocId = cls.ClsHtml.FncUrl_DocId_from_URL();
                }


                m_DocId = DocId;
                m_DocLngId = DocLngId;

            }
        
        private void FncStadisticVisitAdd()
        {
            cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            oRegDoc.DocId = 0;

            string szUrlReferrer = "null";
            if (Request.UrlReferrer != null)
            {
                szUrlReferrer = Request.UrlReferrer.ToString();
            }
            //todo verficar
            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
            //oRegDoc.FncStdVisitAddCount("notice", oNotice.DocLngId, Session.SessionID, System.Web.HttpContext.Current.User.Identity.ToString(), Request.UserHostAddress, szUrlReferrer, Request.Url.ToString(), "article ", Request.UserAgent);

        }
        private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_notices oNotice)
        {
            oNotice.FncSqlFind(m_DocId, m_DocLngId);
           Page_Title=oNotice.Title+" - testudines.org";
            //Page.Title = oNotice.Title;
            scnPanelTop.Text = "";
            FncFillPanelLeft(ref oDoc, ref oDocLng, ref oNotice);
            FncFillPanelRight(ref oDoc, ref oDocLng, ref oNotice);
            String BreadCrumb = oNotice.FncHtmlBreadCrumb(cls.ClsGlobal.CacheRebuid);
           Page_FncBreadCrumb(ref BreadCrumb);

        }
    
        private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_notices oNotice)
        {
            if (m_DocId == 0) m_DocId = 376;
            if (m_DocLngId == "") m_DocLngId = "es";
            string szFileName =cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "notice");
            if (cls.ClsGlobal.CacheRebuid) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }
           
            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                scnPanelLeft.Text = cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {


                scnPanelLeft.Text = oNotice.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

            }
        }
        private void FncFillPanelRight(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_notices oNotice)
        { scnPanelRightLastDocs.Text = oNotice.FncHtmlLastnotices(false); }
    }
}