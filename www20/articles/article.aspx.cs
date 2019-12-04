using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Web.Security;
namespace testudines
{
    public partial class article: cls.ClsPageBase
  
    {

        private cls.bbdd.ClsReg_tdoclng_articles oArticle = new cls.bbdd.ClsReg_tdoclng_articles();
        private cls.ClsUserContest oUsr = new cls.ClsUserContest();
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "es";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();
                FncFill();
                FncStadisticVisitAdd();
            }

        }

        private void FncGetParameters()
        {
            UInt64 DocId = 41395;
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

        private void FncFill()
        {
            cls.bbdd.ClsReg_tdoclng_articles oArticle = new testudines.cls.bbdd.ClsReg_tdoclng_articles();
            cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();

            bool bExist = true;
            bExist = oDoc.FncSqlFind(m_DocId);
            if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

            if (bExist)
            {
                FncFill(ref oDoc, ref oDocLng, ref oArticle);

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
            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
        }
        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {
                scnButtonBar.Text = "<a class=\"btn-tiny\" href=\"/es/articles/article-mng-edit/" + m_DocId.ToString() + "\">" + Resources.Strings.Edit + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/articles/articles-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/articles/article-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }
        private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_articles oArticle)
        {
            oArticle.FncSqlFind(m_DocId, m_DocLngId);
            Page_Title=(oArticle.Title + " - testudines.org");
            Page.Title = oArticle.Title;
            scnPanelTop.Text = "";
            FncFillPanelLeft(ref oDoc, ref oDocLng, ref oArticle);
            FncFillPanelRight(ref oDoc, ref oDocLng, ref oArticle);
            String BreadCrumb = oArticle.FncHtmlBreadCrumb();
            FncEditButtons();
            FncFillBread();
        }
        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, "/" + cls.ClsGlobal.LngIdThread + "/tortoises/tortoise/tortoises-list");

            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_keys_groups_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }
        private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_articles oArticle)
        {
            if (m_DocId == 0) m_DocId = 376;
            if (m_DocLngId == "") m_DocLngId = "es";

          
            string szFilename =cls.cache.ClsCache.FncCacheFilePath( m_DocId,  m_DocLngId, "article");

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFilename))
            {
                scnPanelLeft.Text = cls.cache.ClsCache.FncCacheFileRead(szFilename);
            }
            else
            {
                scnPanelLeft.Text = oArticle.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

            }
        }
        private void FncFillPanelRight(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_articles oArticle)
        { scnPanelRightLastDocs.Text = oArticle.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6); }
    }
}