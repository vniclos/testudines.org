using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace testudines.tortoises.keys
{
    public partial class key : cls.ClsPageBase
    {
    
        private UInt64 m_DocId = 0;
        private string m_DocLngId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();

                Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
                FncFillContentLeft();
                FncBldBreadCrumb();
                FncEdit();



            }
        }

        private void FncGetParameters()
        {

            UInt64 DocId = 15869;
            String DocLngId = "en";



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
        }
      


        private void FncBldBreadCrumb()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, "/"+m_DocLngId+"/tortoises/tortoise/tortoises.list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Keys, "/" + m_DocLngId+"/tortoises/keys/keys-list/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.TaxonIdentificationKey, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);

        }
        private void FncEdit()
        {
            scnLnk.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {
                scnLnk.Text = "<a class=\"btn-tiny\" href=\"/" + m_DocLngId.ToString() + "/tortoises/keys/keys-mng-edit/" + m_DocId.ToString() + "\">" + Resources.Strings.Edit + "</a>";
                scnLnk.Text += "<a class=\"btn-tiny\" href=\"/" + m_DocLngId.ToString() + "/tortoises/keys/keys-mng-list/\">" + Resources.Strings.btn_list + "</a>";

            }
            else
            {
                scnLnk.Text += "<a class=\"btn-tiny\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxon_key/\">" + Resources.Strings.ListView + "</a>";

            }
        }
      
        private void FncFillContentLeft()
        {


            if (m_DocId == 0) m_DocId = 15869;
            if (m_DocLngId == "") m_DocLngId = "en";
            string m_TypeName = "taxon_key";


            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, m_TypeName);
            cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oTaxonKeyLng = new testudines.cls.bbdd.ClsReg_tdoclng_testudineskeys_lng();
            oTaxonKeyLng.FncSqlFind(m_DocId, m_DocLngId);

            if (cls.ClsGlobal.CacheRebuid) {
                cls.ClsUtils.FncPathFileDelete(szFileName);
            }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                scnPanelLeft.Text = Server.HtmlDecode(cls.cache.ClsCache.FncCacheFileRead(szFileName));
            }
            else
            {
              
                scnPanelLeft.Text = Server.HtmlDecode(oTaxonKeyLng.FncGetCache_Html(cls.ClsGlobal.CacheRebuid));
              
            }
            this.Title ="tortoise identification key "+ oTaxonKeyLng.Title;




        }
    }

}