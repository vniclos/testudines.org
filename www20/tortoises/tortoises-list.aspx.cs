using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Web;
//using MySql.Data.Common;
using System.Data;
using System.Globalization;

namespace testudines.tortoises
{
    public partial class tortoises_list : cls.ClsPageBase
    {


        private String m_SqlSelect = "SELECT concat (Loc_title) AS url, CONCAT_WS(' ', ATaxGrpL2270Genus, ATaxGrpL2280Specie) as title,   tdoclng_testudines_abst.DocId,   tdoclng_testudines_abst.DocLngId,   tdoclng_testudines_file_all.FileSeccId,  tdoclng_testudines_file_all.AFileURL as DocImgThumbnail, UPPER(CONCAT_WS(' ', `ATaxGrpL2282Authority`,`ATaxGrpL2283Year` )) as titlesub,   tdoclng_testudines_taxa_all.ATaxGrpL2270Genus,   tdoclng_testudines_taxa_all.ATaxGrpL2220SubOrder as suborder,     tdoclng_testudines_taxa_all.ATaxGrpL2240Family as family,   tdoclng_testudines_taxa_all.ADngLevelRedList,     tdoclng_testudines_taxa_all.ATaxGrpL2220SubOrder,     tdoclng_testudines_taxa_all.ATaxGrpL2240Family,     tdoclng_testudines_taxa_all.ATaxNameVulgarEN,     tdoclng_testudines_taxa_all.ATaxNameVulgarES,   tdoclng_testudines_taxa_all.ATaxNameVulgarOthers,     CONCAT_WS('', tdoclng_testudines_abst.LAbsDes, tdoclng_testudines_abst.LAbsHisNat, tdoclng_testudines_abst.LAbsRngHab) as abstract,    tdoc.DocDateCreation,  	tdoc.DocDateUpdate,  `tdoc`.`DocStdVisitCount`      	FROM tdoclng_testudines_abst INNER JOIN tdoc ON tdoc.DocId = tdoclng_testudines_abst.DocId INNER JOIN tdoclng_testudines_taxa_all   ON tdoclng_testudines_taxa_all.DocId = tdoc.DocId INNER JOIN tdoclng_sitemap ON tdoclng_testudines_abst.DocId= tdoclng_sitemap.DocId AND tdoclng_sitemap.DocLngId= tdoclng_testudines_abst.DocLngId   INNER JOIN tdoclng_testudines_file_all ON tdoclng_testudines_file_all.DocId = tdoclng_testudines_abst.DocId   ";
        private String m_SqlSelectWhere = " Where `DocIsActive`='1' and tdoclng_testudines_file_all.FileSeccId= 'AAbsImg_Specie' ";
        private String m_SqlSelectOrder = " order by title";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncBreadCrumb();
                FncFillGridView();
                FncFillList();
                FncFillPageTitle();
                scnSearchBtn.Text = Resources.Strings.Search;
            }
        }
        private void FncFillPageTitle()
        {
            Page.Title = Resources.Strings.mnTortoises_Taxa_Tortoises;
            scnPageTitle.Text = Resources.Strings.mnTortoises_Taxa_Tortoises;
        }
        private String FncBuildSelect()
        {
            String szSelect = "";
            String szFilterWhere = "";
            String szSearch = sncSearch.Text.Trim().ToLower();
            if (szSearch != "")
            {
                szFilterWhere = " and title like '%" + szSearch + "%' or ATaxNameVulgarEN like '%" + szSearch + "%' or ATaxNameVulgarES like '%" + szSearch + "%'";
            }
            szSelect = m_SqlSelect + m_SqlSelectWhere + szFilterWhere + m_SqlSelectOrder;

            return szSelect;
        }
        private void FncBreadCrumb()
        {
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises, "");
            // cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, cls.ClsGlobal.LngIdThread + "/tortoises/" + Resources.Strings.mnTortoises_Taxa_TortoisesList);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_Taxa_TortoisesList, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }
        private void FncFillGridView()
        {
            MySqlConnection conn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            String szSelect = FncBuildSelect(); // m_SqlSelect + m_SqlSelectWhere + m_SqlSelectOrder;
            MySqlCommand cmd = new MySqlCommand(szSelect, conn);
            conn.Open();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dataTable);


            scnGridView.DataSource = dataTable;
            scnGridView.DataBind();
            conn.Close();
            conn.Dispose();
            da.Dispose();
            dataTable.Dispose();
        }
        private void FncFillList()
        {
            scnMainRight.Text = "<h2>" + Resources.Strings.Tortoises_List + "</h2>";
            scnMainRightList2.Text = cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_TT(cls.ClsGlobal.CacheRebuid); ;

        }

        protected void scnGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridView.PageIndex = e.NewPageIndex;

            this.FncFillGridView();

        }






        protected void scnBtnFillTree_Click(object sender, EventArgs e)
        {

            cls.cache.ClsCacheTortoise_TreeULView oTree = new testudines.cls.cache.ClsCacheTortoise_TreeULView();
            scnMainRight.Text = oTree.FncCache_GET(false, "es");
        }

        protected void scnBtnFillList_Click(object sender, EventArgs e)
        {
            scnMainRight.Text = cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_TT(false);
        }

        protected void scnBtnSearch_Click(object sender, EventArgs e)
        {
            FncFillGridView();
        }
    }
}

