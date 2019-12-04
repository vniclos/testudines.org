using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.bibliography
{
    public partial class bibliography_list : cls.ClsPageBase
    {

        
        private string m_DocLngId = "es";
        private string m_filter = "";
        private string m_SqlSelect = " select `tdoc_biblio`.`DocId` as `DocId`, CiteAutorYearABC, Title,CiteHtmlFull as 'abstract', Authors  from tdoc_biblio ";
        private string m_Sql_where = " where CiteHtmlFull like '%#filter#%'";
        private string m_sqlOrder = " order by CiteAutorYearABC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Page_Title = (Resources.Strings.mnOthers_Bibliographys + " - testudines.org");
                FncGetParameters();
                FncFilTop();
                FncFillBread();
                FncFillGrid();
                FncFillPanelRight();

            }
        }
        private void FncGetParameters()
        {

            String DocLngId = "es";
            String filter = "";
            try
            {
                DocLngId = Page.RouteData.Values["doclngid"].ToString();
                filter = Page.RouteData.Values["filter"].ToString().ToLower();
            }
            catch {; }
            if (Request.QueryString["doclngid"] != null)
            {
                DocLngId = Request.QueryString["doclngid"].ToString();
            }

            //...............

            if (Request.QueryString["filter"] != null)
            {
                filter = Request.QueryString["filter"].ToString();
            }
            m_filter = filter;
            m_DocLngId = DocLngId;

        }

        private void FncFillPanelRight()
        {
            scnPanelRightLastDocs.Text= cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_DL(cls.ClsGlobal.CacheRebuid);

            //scnPanelRightLastDocs.Text = oBibliography.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6);
        }
        private void FncFilTop()
        {
            scnPageTitle.Text = "<h1>" + Resources.Strings.mnBibliography + " " + m_filter + "</h1>";
            //scnContentTop.Text = "<h1>"+Resources.Strings.Bibliographys_clasifiated_list+"</h1>";

        }
        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
           cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Bibliography, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);


        }
        private String FncBldSqlCmd()
        {

            String szSqlCmd = m_SqlSelect;
            //m_SqlSelect = "SELECT `tdoclng_bibliographys`.`DocId` as `DocId`, `tdoclng_bibliographys`.`DocLngId` as `DocLngId`,  `tdoclng_bibliographys`.`Title` as `Title`, `tdoclng_bibliographys`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,";
            //m_SqlSelect += " CONCAT( '" + cls.ClsGlobal.DirDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoclng_bibliographys` LEFT JOIN `tdoc` ON `tdoclng_bibliographys`.`DocId` = `tdoc`.`DocId` ";
           
            String szFilter = "";
            if (m_filter != "")
            {
                szFilter += " where DocTypeGroup='" + m_filter + "' ";
            }
            scnFilterTxt.Text = scnFilterTxt.Text.Trim();
            if (scnFilterTxt.Text != "")
                if (szFilter == "")
                {
                    szFilter += m_Sql_where.Replace("#filter#", scnFilterTxt.Text);
                }
            szSqlCmd += szFilter +m_sqlOrder;
            return szSqlCmd;
        }



        private void FncFillGrid()
        {
           
            string szSelect = FncBldSqlCmd();

            DataTable oTb = new DataTable("tbBibliography");
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect, ref oTb);


            scnGridView.DataSource = oTb;
            scnGridView.DataBind();





            if (scnGridView.Rows.Count == 0)
            {
                //  MPageBoxMsgInfo = Resources.Strings.msg_Im_sorry_havenotdocs;
                //  MPagePnlVisible = true;

            }
            else
            {
                //   MPageBoxMsgInfo = "";
                //   MPagePnlVisible = false; ;

            }
        }



        protected void scnGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridView.PageIndex = e.NewPageIndex;

            this.FncFillGrid();

        }

        protected void scnFilterFilter_Click(object sender, EventArgs e)
        {
            if (scnFilterTxt.Text.Trim() != "") FncFillGrid();
        }

        protected void scnFilterClear_Click(object sender, EventArgs e)
        {
            scnFilterTxt.Text = "";
            FncFillGrid();
        }
    }
}