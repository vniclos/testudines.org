using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Web.Security;
namespace testudines.iucn
{
    public partial class iucn : cls.ClsPageBase

    {

        private cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone = new cls.bbdd.ClsReg_tmst_iucn_redlist();
        private cls.ClsUserContest oUsr = new cls.ClsUserContest();
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "es";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FncFill();
                Page_FncBreadCrumb();
                FncStadisticVisitAdd();
            }

        }

        private void Page_FncBreadCrumb()
        { }

        private void FncFill()
        {
            UInt64 DocId = 41395;
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
            m_DocLngId = DocLngId;
            cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone = new testudines.cls.bbdd.ClsReg_tmst_iucn_redlist();
            cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();

            bool bExist = true;
            bExist = oDoc.FncSqlFind(DocId);
            if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

            if (bExist)
            {
                FncFill(ref oDoc, ref oDocLng, ref oEcozone);

            }
            else
            {

                /*

                MPageDocId = DocId;
                MPageDocLngId = DocLngId;
                MPageTitle = "Opps !";
                MPageTitleSub = Resources.Strings.Im_Sorry_Document_Not_Availave;
                MPageDocLngFlags = "";
                MpageMetaTitle = Resources.Strings.Im_Sorry_Document_Not_Availave; ;
                MpageMetaAuthor = "";
                MpageMetaDescription = Resources.Strings.Im_Sorry_Document_Not_Availave;
                MpageMetaRobots = "never";
                MpageMetaKeywords = "error";
                MPagePnlVisible = false;
                scnHtml.Text = "<br/><br/>This document not is available at this moment..</br>Doc: " + DocId.ToString() + "-" + DocLngId + "</p>";
                return;
                */


            }

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

            //oRegDoc.FncStdVisitAddCount("iucn", oEcozone.DocLngId, Session.SessionID, System.Web.HttpContext.Current.User.Identity.ToString(), Request.UserHostAddress, szUrlReferrer, Request.Url.ToString(), "iucn ", Request.UserAgent);
            //TODO verificar
            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
        }
        private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone)
        {
            oEcozone.FncSqlFind(m_DocId, m_DocLngId);
            Page_Title = oEcozone.Title + " - testudines.org";

            Page.Title = oEcozone.Title;
            scnPanelTop.Text = "";
            FncFillPanelLeft(ref oDoc, ref oDocLng, ref oEcozone);
            FncFillPanelRight(ref oDoc, ref oDocLng, ref oEcozone);


        }

        private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone)
        {
            if (m_DocId == 0) m_DocId = 376;
            if (m_DocLngId == "") m_DocLngId = "es";


            string szFilename = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "iucn");

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFilename))
            {
                scnPanelLeft.Text = cls.cache.ClsCache.FncCacheFileRead(szFilename);
            }
            else
            {
                //scnPanelLeft.Text = oEcozone.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

            }
        }
        private void FncFillPanelRight(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone)
        {// scnPanelRightLastDocs.Text = oEcozone.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6); }
        }
    }
}