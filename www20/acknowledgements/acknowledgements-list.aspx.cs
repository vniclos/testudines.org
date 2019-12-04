using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testudines;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.acknowledgements
{
    public partial class acknowledgements_list : cls.ClsPageBase
    {

        private string m_SqlSelect = "SELECT  `tdoc_acknowledgment`.`DocId` as `DocId`,   `tdoc_acknowledgment`.`Title` as `Title`,  `tdoc_acknowledgment`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` ,   `tdoc`.`DocAuthors` ,  CONCAT( '/a_files/doc_docstore/', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail,   `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`,    `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoc_acknowledgment` LEFT JOIN `tdoc` ON `tdoc_acknowledgment`.`DocId` = `tdoc`.`DocId` ";
        private string m_SqlWhere = "where title like '%#filter#%'";
        private string m_filter = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Page_Title=Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list + " - testudines.org";
                FncFilTop();
                FncFillBread();
                FncFillGrid();
                FncFillPanelRight();

            }
        }
        private void FncFillPanelRight()
        {
            //cls.bbdd.ClsReg_tdoc_acknowledgment oAcknowledgement = new cls.bbdd.ClsReg_tdoc_acknowledgment();
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oAcknowledgement = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();

            scnPanelRightLastDocs.Text = oAcknowledgement.FncCache_GET_last(cls.ClsGlobal.LngIdThread, cls.ClsGlobal.CacheRebuid, 6);
        }
        private void FncFilTop()
        {
            scnContentTop.Text = "<h1>" + Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list + "</h1>";

        }
        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Acknowledgements, "/acknowledgements/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);


        }
        private String FncBldSqlCmd()
        {
            // m_SqlSelect = "SELECT `tdoclng_acknowledgements`.`DocId` as `DocId`, `tdoclng_acknowledgements`.`DocLngId` as `DocLngId`,  `tdoclng_acknowledgements`.`Title` as `Title`, `tdoclng_acknowledgements`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,";
            // m_SqlSelect += " CONCAT( '" + cls.ClsGlobal.DirDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoclng_acknowledgements` LEFT JOIN `tdoc` ON `tdoclng_acknowledgements`.`DocId` = `tdoc`.`DocId` ";
            String szSelect = "";
            scnFilterTxt.Text = scnFilterTxt.Text.Trim();
            szSelect = m_SqlSelect;
            m_filter = scnFilterTxt.Text;
            if (m_filter != "")
            {
                szSelect += m_SqlWhere.Replace("#filter#", m_filter);
            }
            return szSelect;
        }
        private void FncFillGrid()
        {
            String szSelect = FncBldSqlCmd();



            DataTable oTb = new DataTable("tbAcknowledgement");
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
            m_filter = scnFilterTxt.Text;
            FncFillGrid();
        }

        protected void scnFilterClear_Click(object sender, EventArgs e)
        {
            m_filter = "";
            scnFilterTxt.Text = "";
            FncFillGrid();
        }


    }
}
