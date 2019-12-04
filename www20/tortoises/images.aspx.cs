using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace testudines.tortoises
{

    public partial class images : cls.ClsPageBase
    {
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "es";
        private Int32 m_Page = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();
                FncFillBreadCrumb();
                FncFillMainContent();
                FncFillRightContent();

            }
        }
        private UInt64 FncSelectRandon_docId()
        {
            UInt64 docId = 0;
            try
            {
                MySqlConnection oCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
                String sqlCmd = "SELECT docid FROM tdoclng_testudines_taxa_all ORDER BY RAND() LIMIT 1;";
                MySqlCommand oCmd = new MySqlCommand(sqlCmd, oCnn);
                oCnn.Open();
                docId = Convert.ToUInt64(oCmd.ExecuteScalar().ToString());
            }
            catch
            { docId = 1; }

            return docId;
        }

        private void FncGetParameters()
        {
            // valores por defecto
            UInt64 DocId = 1;
            String szDocId = ""; //puede contener la url con titulo
            m_Page = 1;
            // leer valores de ur y prevenir errores
            try { szDocId = Page.RouteData.Values["docid"].ToString(); } catch {; }
            try { m_DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower(); } catch {; }
            try { m_Page = Convert.ToInt32(Page.RouteData.Values["page"].ToString()); } catch {; }
            if (szDocId == "") { szDocId = FncSelectRandon_docId().ToString(); }
            //------- si docId es texto buscar encontrar su id docid numerico
            try { DocId = Convert.ToUInt64(szDocId); }
            catch
            {
                DocId = cls.ClsHtml.FncUrl_DocId_from_URL();
                if (DocId == 0) // no encontrado
                {
                    // intentar buscar buscar por el mombre
                    DocId = FncDoId_FromTaxonName(szDocId);
                }
                if (DocId == 0)
                {
                    FncFillNotFound(szDocId);
                    return;
                }

            }
            m_DocId = DocId;


        }
        private void FncFillNotFound(String szDocId)
        {
            scnMainContent.Text = "<h2>Opps!, Gallery " + szDocId + " Not Found</h2>";
            scnMainContent.Text = "<p>Lo siente, Por favor contacta con el grupo testudines.org para advertirme sobre este error, Gracias</p>";
            scnMainContent.Text = "<p>I'm sorry, Please contact with testudines.org group on facebook form alert to me of this error. Tank you</p>";

        }
        private UInt64 FncDoId_FromTaxonName(String pDocId)
        {
            UInt64 DocId = 0;
            string szDocId = "";
            string[] aName = pDocId.Split('-');
            if (aName.Length == 2)
            {
                String szGenus = aName[0];
                String szSpecie = aName[1];
                string szCmd = "select docid  from tdoclng_testudines_taxa_all where  ATaxGrpL2270Genus='" + szGenus + "' and ATaxGrpL2280Specie='" + szSpecie + "'";
                szDocId = cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd);
                try { DocId = Convert.ToUInt64(szDocId); } catch { DocId = 0; }
            }
            return DocId;

        }

        private void FncFillBreadCrumb()
        {
            cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oDoc = new cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();
            oDoc.FncSqlFind(m_DocId);
            string szBreadCrumb = ""; cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises, ("/" + m_DocLngId + "/tortoises/tortoises-list"));
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_Taxa_TortoisesImages, "");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.specie + ": " + oDoc.ATaxGrpL2260SupGenus + " " + oDoc.ATaxGrpL2280Specie, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);

            Page_FncBreadCrumb(ref szBreadCrumb);
            Page_Title = (oDoc.ATaxGrpL2260SupGenus + "-" + oDoc.ATaxGrpL2280Specie + "_" + Resources.Strings.images + "_" + m_Page.ToString());

        }
        private void FncFillMainContent()
        {
            
            cls.cache.ClsCache_Tortoise_Images oGallery2 = new cls.cache.ClsCache_Tortoise_Images();
            scnMainContent.Text= oGallery2.FncCacheGet(m_DocId, m_DocLngId, m_Page, cls.ClsGlobal.CacheRebuid);
            //cls.ClsCache_Tortoise_Images oGallery = new cls.ClsCache_Tortoise_Images();
            //scnMainContent.Text = oGallery.FncCacheGet(m_DocId, m_DocLngId, m_Page, cls.ClsGlobal.CacheRebuid);
        }
        private void FncFillRightContent()
        {
            cls.cache.ClsCacheTortoise_TreeULView oUl = new cls.cache.ClsCacheTortoise_TreeULView();

            scnContentRight.Text = "<h2>" + Resources.Strings.images + "</h2>" + cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_DL(cls.ClsGlobal.CacheRebuid);
        }
    }


}
