using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace testudines.notices
{
    public partial class notices_list : cls.ClsPageBase
    {
        private string m_SqlSelect = "";
        private string m_SqlWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = Resources.Strings.mnNotices;

                FncFillPanelTop();
                FncEditButtons();
                FncFillBread();
                FncFillGrid();
                FncFillPanelRight();
            }
        }
        private void FncFillPanelRight()
        {
            cls.bbdd.ClsReg_tdoclng_notices oNotice = new cls.bbdd.ClsReg_tdoclng_notices();
            scnPanelRightLastDocs.Text = oNotice.FncCache_GET_lastImg(cls.ClsGlobal.CacheRebuid,6);
        }

        private void FncFillPanelTop()
        {
            scnPanelTop.Text ="<h1>"+ Resources.Strings.Notices_clasifiated_list+"</h1>";
        }
        private void FncEditButtons()
        {

            scnButtonBar.Text = "";
            if (cls.ClsUtils.User_isAdmin())
            {

                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/notices/notices-mng-list\">" + Resources.Strings.Administration + "</a>";
                scnButtonBar.Text += "<a class=\"btn-tiny\" href=\"/es/notices/notice-mng-edit/0\">" + Resources.Strings.New + "</a>";
            }
            //  scnLnk.Text += "<a class=\"tiny button\" href=\"/" + m_DocLngId.ToString() + "/taxons/taxons/\">" + Resources.Strings.ListView + "</a>";
        }
        private void FncFillBread()
        {
            String szDescrip = "";

            szDescrip += Resources.Strings.Notices_clasifiated_list;
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Notices, "/notices/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Notice + ": " + szDescrip, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);


        }

        private void FncBldSqlCmd()
        {
            //m_SqlSelect = "SELECT `tdoclng_notices`.`DocId` as `DocId`, `tdoclng_notices`.`DocLngId` as `DocLngId`,  `tdoclng_notices`.`Title` as `Title`, `tdoclng_notices`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,";
            //m_SqlSelect += " CONCAT( '" + cls.ClsGlobal.DirDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoclng_notices` LEFT JOIN `tdoc` ON `tdoclng_notices`.`DocId` = `tdoc`.`DocId` ";
            m_SqlSelect = "SELECT   loc_title as Url,`tdoclng_notices`.`DocId` as `DocId`, `tdoclng_notices`.`DocLngId` as `DocLngId`,  `tdoclng_notices`.`Title` as `Title`, `tdoclng_notices`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,  CONCAT( '" + cls.ClsGlobal.UrlDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive`  FROM `tdoclng_notices` LEFT JOIN `tdoc` ON `tdoclng_notices`.`DocId` = `tdoc`.`DocId` INNER JOIN tdoclng_sitemap  ON `tdoclng_notices`.`DocId` = `tdoclng_sitemap`.`DocId` AND   `tdoclng_notices`.`DocLngId` = `tdoclng_sitemap`.`DocLngId`; ";

            scnFilterTxt.Text = scnFilterTxt.Text.Trim();
            if (scnFilterTxt.Text != "")

                m_SqlSelect += " where title like '%#filter#%' or abstract like '%#filter#%'".Replace("#filter#", scnFilterTxt.Text.Trim());
                  
               
               
            
        }
        private void FncFillGrid()
        {
            FncBldSqlCmd();
            string szSelect = m_SqlSelect;
            /*
            if (scnFilter.Text.Trim() != "*")
            {
                //title like '%dario%'
                szSelect += "and ((title like '%" + scnFilter.Text + "%') or (abstract like '%" + scnFilter.Text + "%'))";
            }

            if (scnFilterArticleType5.SelectedValue != "*")
            {

                szSelect += " and tdoc.DocTypeGroup ='" + scnFilterArticleType5.SelectedValue + "'";
            }

            if (scnFilterArticleTypeSub5.SelectedValue != "*")
            {
                //scnReferenceTypeSub
                szSelect += "and tdoc.DocTypeGroupSub like '%" + scnFilterArticleType5.SelectedValue + "%'";
            }


            if (scnFilterDocLngId.SelectedValue != "*")
            {

                //scnReferenceTypeSub
                szSelect += " and tdoclng_notices.DocLngId = '" + scnFilterDocLngId.SelectedValue + "'";
            }



            if (szSelect != "")
            {
                szSelect = m_SqlSelect + " " + m_SqlSelectWhere + " " + szSelect;
            }
            else
            {
                szSelect = m_SqlSelect;
            }
            */
            szSelect = m_SqlSelect;

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
            if (scnFilterTxt.Text.Trim() != "") FncFillGrid();
        }

        protected void scnFilterClear_Click(object sender, EventArgs e)
        {
            scnFilterTxt.Text = "";
            FncFillGrid();
        }
    }
}