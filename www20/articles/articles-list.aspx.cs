using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testudines;
using MySql.Data.MySqlClient;
using System.Data;


namespace testudines.articles

{
    public partial class article_list : cls.ClsPageBase
    {
        private string m_SqlSelect = "";

        private string m_DocLngId = "es";
        private string m_filter = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Page_Title=(Resources.Strings.mnArticles + " - testudines.org");
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
            }catch{; }
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
        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {

                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/articles/articles-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/articles/article-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }

        private void FncFillPanelRight()
        {
            FncEditButtons();
            cls.bbdd.ClsReg_tdoclng_articles oArticle = new cls.bbdd.ClsReg_tdoclng_articles();
        
            scnPanelRightLastDocs.Text = oArticle.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6);
        }
        private void FncFilTop()
        {
            scnPageTitle.Text = "<h1>" + Resources.Strings.Articles_clasifiated_list+" " +m_filter+ "</h1>";
            //scnContentTop.Text = "<h1>"+Resources.Strings.Articles_clasifiated_list+"</h1>";

        }
        private void FncFillBread()
        {
          
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Articles, "/articles/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.ArticlesList, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);


        }
        private void FncBldSqlCmd()
        {
            //m_SqlSelect = "SELECT `tdoclng_articles`.`DocId` as `DocId`, `tdoclng_articles`.`DocLngId` as `DocLngId`,  `tdoclng_articles`.`Title` as `Title`, `tdoclng_articles`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,";
            //m_SqlSelect += " CONCAT( '" + cls.ClsGlobal.DirDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoclng_articles` LEFT JOIN `tdoc` ON `tdoclng_articles`.`DocId` = `tdoc`.`DocId` ";
            m_SqlSelect = "SELECT loc_title as Url, `tdoclng_articles`.`DocId` as `DocId`, `tdoclng_articles`.`DocLngId` as `DocLngId`,  `tdoclng_articles`.`Title` as `Title`, `tdoclng_articles`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,  CONCAT( '" + cls.ClsGlobal.UrlDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`,  `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive`  FROM `tdoclng_articles` INNER JOIN `tdoc` ON `tdoclng_articles`.`DocId` = `tdoc`.`DocId` INNER JOIN tdoclng_sitemap  ON `tdoclng_articles`.`DocId` = `tdoclng_sitemap`.`DocId` AND   `tdoclng_articles`.`DocLngId` = `tdoclng_sitemap`.`DocLngId` ";
            String szFilter = "";
            if (m_filter != "")
            {
                szFilter += " where DocTypeGroup='"+ m_filter + "' ";
            }
            scnFilterTxt.Text = scnFilterTxt.Text.Trim();
            if (scnFilterTxt.Text != "")
                if (szFilter == "")
                {
                    szFilter +=  "where title like '%#filter#%' or abstract like '%#filter#%'".Replace("#filter#", scnFilterTxt.Text.Trim());
                }
                else
                {
                    szFilter += " and (title like '%#filter#%' or abstract like '%#filter#%')".Replace("#filter#", scnFilterTxt.Text.Trim());
                }
            m_SqlSelect += szFilter;
        }


        
        private void FncFillGrid()
        {
            FncBldSqlCmd();
            string szSelect = m_SqlSelect;
          
            DataTable oTb = new DataTable("tbArticle");
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
           if (scnFilterTxt.Text.Trim()!="")                FncFillGrid();
        }

        protected void scnFilterClear_Click(object sender, EventArgs e)
        {
            scnFilterTxt.Text = "";
            FncFillGrid();
        }
    }
}