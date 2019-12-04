using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace testudines.tortoises
{

    public partial class tortoise : cls.ClsPageBase
    {

       
        UInt64 m_DocId = 0;
        String m_DocLngId = "es";
       
        String m_DocChapter = "";



       

        private cls.bbdd.ClsReg_tdoc oRegTDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        private cls.bbdd.ClsReg_tdoclng oRegLng = new testudines.cls.bbdd.ClsReg_tdoclng();
        private cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oRegTaxonFull = new testudines.cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();
        //private cls.bbdd.ClsReg_tdoclng_testudines_abst oRegTaxonLng = new testudines.cls.bbdd.ClsReg_tdoclng_testudines_abst();
        private cls.bbdd.ClsReg_tdoclng_testudines_all oRegTaxon = new testudines.cls.bbdd.ClsReg_tdoclng_testudines_all();
        cls.cache.ClsCache_Tortoise oHtml = new cls.cache.ClsCache_Tortoise();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();
                FncFillBread();
                if (FncFillMain())
                {
                    FncStadisticVisitAdd();
                }
            }
        }
        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, ("/" + m_DocLngId + "/tortoises/tortoise/tortoises-list"));
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoise + ": " + oRegTaxonFull.ATaxGrpL2270Genus + " " + oRegTaxonFull.ATaxGrpL2280Specie, "");

            Page_FncBreadCrumb(ref szBreadCrumb);

        }

        private void FncGetParameters()
        {
            // valores por defecto
            UInt64 DocId = 1;
            String szDocId = "1";
            String szDocChapter = cls.ClsGlobal.E_TortoiseChapters.summary.ToString(); ; //puede contener la url con titulo
            String DocLngId = "es";
            // recuperar valores de url
            try { szDocId = Page.RouteData.Values["docid"].ToString(); } catch { }
            try { DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower(); } catch {; }
            try { szDocChapter = Page.RouteData.Values["capitule"].ToString().ToLower(); } catch {; }

            if (Request.QueryString["docid"] != null) { szDocId = Request.QueryString["docid"].ToString(); }
            if (Request.QueryString["doclngid"] != null) { DocLngId = Request.QueryString["doclngid"].ToString(); }
            if (Page.RouteData.Values["capitule"] != null) { szDocChapter = Page.RouteData.Values["capitule"].ToString().ToLower().Trim(); }


            //------- si docId es texto buscar su id numerico
            try
            {
                DocId = Convert.ToUInt64(szDocId);
            }
            catch
            {
                DocId = cls.ClsHtml.FncUrl_DocId_from_URL();
            }

            // guardar valores obtenidos
            m_DocId = DocId;
            m_DocLngId = DocLngId;
            m_DocChapter = szDocChapter;
        }

        private bool FncFillMain()
        {
            scnMainTop.Text = "";
            if (m_DocId == 0)
            {
                m_DocId = 1;
                m_DocLngId = "es";

                m_DocChapter = cls.ClsGlobal.E_TortoiseChapters.summary.ToString();

            }
            bool bError = false;
            bError = !oRegTDoc.FncSqlFind(m_DocId);
            if (bError)
            {
                scnMain.Text = " Don't find this taxon";
                return false;
            }
            FncEditButtons();
            FncFillTreeView();
            // FncReadCookies();
            oHtml.FncSqlFindTaxon_ful_html(m_DocId, m_DocLngId);

            string szMPageTitleSub = "";
            // scnGalleryListView.Visible = false;

            //  string szBox= oHtml.FncHtmlBoxResumen(false);

            string szPageChapter = "";

            cls.ClsGlobal.E_TortoiseChapters capitule = (cls.ClsGlobal.E_TortoiseChapters)Enum.Parse(typeof(cls.ClsGlobal.E_TortoiseChapters), m_DocChapter);

            switch (capitule)
            {
                case cls.ClsGlobal.E_TortoiseChapters.summary: //  "abstract":
                    // MpageMetaTitle = Resources.Strings.ind_carintroduction +": "+ oRegTaxonFull.ATaxGrpL2270Genus + " " + oRegTaxonFull.ATaxGrpL2280Specie;
                    scnMain.Text = oHtml.FncHtmlSummary(cls.ClsGlobal.CacheRebuid);
                    szMPageTitleSub = Resources.Strings.mn_abstract;
                    // m_DocSectionLng = Resources.Strings.Abstract;



                    szPageChapter = Resources.Strings.ind_Chapter01_00Abs;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.description:
                    scnMain.Text = oHtml.FncHtmlDescription(cls.ClsGlobal.CacheRebuid);
                    szMPageTitleSub = Resources.Strings.mn_description;
                    // m_DocSectionLng = Resources.Strings.description;
                    szPageChapter = Resources.Strings.ind_Chapter02_00Des;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.natural_history:
                    scnMain.Text = oHtml.FncHtmLNatu_history(cls.ClsGlobal.CacheRebuid);
                    szMPageTitleSub = Resources.Strings.mn_natural_history;
                    //m_DocSectionLng = Resources.Strings.natural_history;
                    szPageChapter = Resources.Strings.ind_Chapter03_00Nat;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.distribution:
                    szMPageTitleSub = Resources.Strings.mn_distribution;
                    scnMain.Text = oHtml.FncHtmlRngHabitatRange(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.distribution;
                    szPageChapter = Resources.Strings.ind_Chapter04_00_00_BioGeographic;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.ecology:
                    szMPageTitleSub = Resources.Strings.mn_ecology;
                    scnMain.Text = oHtml.FncHtmlRngHabitatEcologyClimate(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.ecology;
                    szPageChapter = Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.care:
                    szMPageTitleSub = Resources.Strings.mn_care_sheet;
                    scnMain.Text = oHtml.FncHtmlCare(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.care;
                    szPageChapter = Resources.Strings.ind_Chapter06_00Car;
                    break;


                case cls.ClsGlobal.E_TortoiseChapters.taxonomy:
                    szMPageTitleSub = Resources.Strings.mn_taxonony_names;
                    scnMain.Text = oHtml.FncHtmlTaxonony(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.taxonony;
                    szPageChapter = Resources.Strings.ind_Chapter07_00Tax;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.bibliography:
                    szMPageTitleSub = Resources.Strings.mn_bibliography_Acknowledgements;
                    scnMain.Text = oHtml.FncHtmlbibliography(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.Bibliography;
                    szPageChapter = Resources.Strings.ind_Chapter11_00Bib;
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.images:
                    szMPageTitleSub = Resources.Strings.mn_images;
                    scnMain.Text = oHtml.FncHtmlGallery(cls.ClsGlobal.CacheRebuid, 1);
                    //m_DocSectionLng = Resources.Strings.images;
                    szPageChapter = Resources.Strings.ind_Chapter10_00Gal;
                    //FncFillGalleryData();
                    break;
                case cls.ClsGlobal.E_TortoiseChapters.notes:
                    szMPageTitleSub = Resources.Strings.mn_notes;
                    scnMain.Text = oHtml.FncHtmlNotes(cls.ClsGlobal.CacheRebuid);
                    //m_DocSectionLng = Resources.Strings.Notes;
                    szPageChapter = Resources.Strings.ind_Chapter12_00Notes;
                    break;


                case cls.ClsGlobal.E_TortoiseChapters.nearspecies:
                    szMPageTitleSub = Resources.Strings.mn_near_species;
                    //m_DocSectionLng = Resources.Strings.nearspecies;
                    scnMain.Text = oHtml.FncHtmlNearSpecies(cls.ClsGlobal.CacheRebuid);
                    szPageChapter = Resources.Strings.ind_Chapter09_00Near;
                    break;

                case cls.ClsGlobal.E_TortoiseChapters.identificationkeys:
                    szMPageTitleSub = Resources.Strings.mn_identificationkeys;
                    //m_DocSectionLng = Resources.Strings.identificationkeys;
                    scnMain.Text = oHtml.FncHtmlIdentificationKeys(cls.ClsGlobal.CacheRebuid);
                    szPageChapter = Resources.Strings.ind_Chapter08_00IdeKey;
                    break;

                default:
                    szMPageTitleSub = Resources.Strings.mn_abstract;
                    //m_DocSectionLng = Resources.Strings.Abstract;
                    scnMain.Text = oHtml.FncHtmlSummary(false) ;
                    szPageChapter = Resources.Strings.ind_Chapter01_00Abs;
                    break;
            }
            //string szMPageTitle = oRegTaxon.oRegAbs.LTaxNameVulgar + ", <br/>" + oRegTaxonFull.ATaxGrpL2270Genus + " " + oRegTaxonFull.ATaxGrpL2280Specie + ", " + m_DocChapter;

            return true;
        }

        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {
                scnButtonBar.Text = "<a class=\"btn-tiny\" href=\"/es/tortoises/taxon_mng.aspx?docid=" + m_DocId.ToString() + "&doclngid=" + m_DocLngId + "\">Edit</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/tortoises/taxon_mng.aspx\">" + Resources.Strings.Administration + "</a>";

            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }


        private void FncStadisticVisitAdd()
        {

            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, m_DocChapter);

        }
        private string FncBldBreadCrumb(string szChapter)
        {
            string sz = "";
            sz = "<span>" + Resources.Strings.You_are + "</span> <a href=\"/" + m_DocId + "\"/>" + Resources.Strings.Home + "</a>";
            sz += "  <a href=\"/" + m_DocLngId + "/testudines/testudines/\"/>" + Resources.Strings.mnTortoises_Taxa_Tortoises + "</a>";

            sz += "&nbsp;<i><span>" + oRegTaxonFull.ATaxGrpL2270Genus + " " + oRegTaxonFull.ATaxGrpL2280Specie + "</i>:&nbsp;" + Resources.Strings.Chapter + "&nbsp; " + szChapter + "</span>";
            return sz;
        }
        private string FncBldVulgarNamesENES()
        {
            string sz = "";
            if (oRegTaxon.oRegTaxaAll.ATaxNameVulgarES != "")
            {
                sz += "[ES] " + oRegTaxon.oRegTaxaAll.ATaxNameVulgarES;
            }
            if (oRegTaxon.oRegTaxaAll.ATaxNameVulgarEN != "")
            {
                sz += ". [EN] " + oRegTaxonFull.ATaxNameVulgarEN;
            }
            return sz;
        }






        #region treeview


        private void FncFillTreeView()
        {
            cls.cache.ClsCacheTortoise_TreeULView oTree = new testudines.cls.cache.ClsCacheTortoise_TreeULView();
            scnMainRight.Text = oTree.FncCache_GET(false, m_DocLngId);
        }



        #endregion treeview

        protected void scnBtnFillTree_Click(object sender, EventArgs e)
        {

            FncFillTreeView();
        }

        protected void scnBtnFillList_Click(object sender, EventArgs e)
        {
            scnMainRight.Text = cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_TT(false);
        }
    }

}
