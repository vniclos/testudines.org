using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using System.Web.Security;
namespace testudines.others
{
    public partial class other: cls.ClsPageBase
    { 



      
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



    private void FncFill()
    {


        cls.bbdd.ClsReg_tdoclng_others oOther = new testudines.cls.bbdd.ClsReg_tdoclng_others();
        cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();

        bool bExist = true;
        bExist = oDoc.FncSqlFind(m_DocId);
        if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

        if (bExist)
        {
            FncFill(ref oDoc, ref oDocLng, ref oOther);

        }


        }
        private void FncFillBreadCrumbs(cls.bbdd.ClsReg_tdoclng_others oOther)
        {
            string sz = "";
            sz = oOther.FncHtmlBreadCrumb();
            Page_FncBreadCrumb(ref sz);
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
        //oRegDoc.FncStdVisitAddCount("other", oOther.DocLngId, Session.SessionID, System.Web.HttpContext.Current.User.Identity.ToString(), Request.UserHostAddress, szUrlReferrer, Request.Url.ToString(), "article ", Request.UserAgent);

    }
    private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_others oOther)
    {
        oOther.FncSqlFind(m_DocId, m_DocLngId);
        Page_Title = oOther.Title + " - testudines.org";
        //Page.Title = oOther.Title;
        scnPanelTop.Text = "";
        FncFillPanelLeft(ref oDoc, ref oDocLng, ref oOther);
        FncFillPanelRight(oOther);

            FncFillBreadCrumbs(oOther);

        }

    private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_others oOther)
    {
        if (m_DocId == 0) m_DocId = 376;
        if (m_DocLngId == "") m_DocLngId = "es";
        string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "other");
        if (cls.ClsGlobal.CacheRebuid) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }

        if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
        {
            scnPanelLeft.Text = cls.cache.ClsCache.FncCacheFileRead(szFileName);
        }
        else
        {


            scnPanelLeft.Text = oOther.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

        }

            FncFillBreadCrumbs(oOther);
        }
    private void FncFillPanelRight(cls.bbdd.ClsReg_tdoclng_others oOther)
    { scnPanelRightLastDocs.Text = oOther.FncCache_GET_last(false); }
}
}