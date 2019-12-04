using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Web.Security;
namespace testudines.tortoises.foods
{
    public partial class food: cls.ClsPageBase

    {

       


        private cls.bbdd.ClsReg_tdoclng_foods oFood = new cls.bbdd.ClsReg_tdoclng_foods();
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
        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {

                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/tortoises/foods/foods-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/tortoises/foods/food-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }
        private void FncFill()
        {
            //cls.bbdd.ClsReg_tdoclng_articles oFood = new testudines.cls.bbdd.ClsReg_tdoclng_articles();
            cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();
            FncEditButtons();
            bool bExist = true;
            bExist = oDoc.FncSqlFind(m_DocId);
            if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

            if (bExist)
            {
                FncFill(ref oDoc, ref oDocLng);

            }
            else
            {

              


            }

        }


        private void FncStadisticVisitAdd()
        {
            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
        }
        private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng)
        {
            oFood.FncSqlFind(m_DocId, m_DocLngId);
            Page_Title = (oFood.Title + " - testudines.org");
            Page.Title = oFood.Title;
            scnPanelTop.Text = "";
            FncFillPanelLeft(ref oDoc, ref oDocLng);
            FncFillPanelRight(ref oDoc, ref oDocLng);
            String BreadCrumb = oFood.FncHtmlBreadCrumb();
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
        private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng)
        {
            if (m_DocId == 0) m_DocId = 376;
            if (m_DocLngId == "") m_DocLngId = "es";


            string szFilename = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "food");

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFilename))
            {
                scnPanelLeft.Text = cls.cache.ClsCache.FncCacheFileRead(szFilename);
            }
            else
            {
                scnPanelLeft.Text = oFood.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

            }
        }
        private void FncFillPanelRight(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng)
        { scnPanelRightLastDocs.Text = oFood.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 10); }
    }
}