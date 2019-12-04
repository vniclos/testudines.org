using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testudines;
using MySql.Data.MySqlClient;
using System.Data;


namespace testudines.others.ecozones

{
    public partial class ecozone_list : cls.ClsPageBase
    {
        private string m_SqlSelect = "";
        private string m_SqlWhere = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                scnTitle.Text = Resources.Strings.mnOthers_Ecozones;
                Page_Title=Resources.Strings.mnOthers_Ecozones + " - testudines.org";
                FncFilTop();
                FncFillBread();
                FncFillGrid();
                FncFillPanelRight();

            }
        }
        private void FncFillPanelRight()
        {
            cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oEcozone = new cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
        
            scnPanelRightLastDocs.Text = oEcozone.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6);
        }
        private void FncFilTop()
        {
            scnContentTop.Text = "<h1>"+Resources.Strings.mnOthers_ecozones_list+"</h1>";
            

        }
        private void FncFillBread()
        {
          
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Ecozones, "/ecozones/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_iucn_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);

        }
        private void FncBldSqlCmd()
        {
            m_SqlSelect = "SELECT  `tdoclng_geoclimate_koppengeigers`.`DocId` as `DocId`, `tdoclng_geoclimate_koppengeigers`.`DocLngId` as `DocLngId`,  `tdoclng_geoclimate_koppengeigers`.`Title` as `Title`, `tdoclng_geoclimate_koppengeigers`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors`   ,  `tdoclng_geoclimate_koppengeigers`.`ImgRainTemp`  as DocImgThumbnail,  `tdoc`.`DocDateCreation`, `tdoc`.`DocStdVisitCount`, `tdoc`.`DocStdVisitLast`, `tdoc`.`DocDateUpdate`, `tdoc`.`DocStdValLow`, `tdoc`.`DocStdValHig`, `tdoc`.`DocStdValMed`, `tdoc`.`DocIsActive` FROM `tdoclng_geoclimate_koppengeigers` LEFT JOIN `tdoc` ON `tdoclng_geoclimate_koppengeigers`.`DocId` = `tdoc`.`DocId`; ";

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

            if (scnFilterEcozoneType5.SelectedValue != "*")
            {

                szSelect += " and tdoc.DocTypeGroup ='" + scnFilterEcozoneType5.SelectedValue + "'";
            }

            if (scnFilterEcozoneTypeSub5.SelectedValue != "*")
            {
                //scnReferenceTypeSub
                szSelect += "and tdoc.DocTypeGroupSub like '%" + scnFilterEcozoneType5.SelectedValue + "%'";
            }


            if (scnFilterDocLngId.SelectedValue != "*")
            {

                //scnReferenceTypeSub
                szSelect += " and tdoclng_geoclimate_koppengeigers.DocLngId = '" + scnFilterDocLngId.SelectedValue + "'";
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

            DataTable oTb = new DataTable("tbEcozone");
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

    }
}