using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testudines;
using MySql.Data.MySqlClient;
using System.Data;


namespace testudines.iucn

{
    public partial class iucn_list : cls.ClsPageBase
    {
        private string m_SqlSelect = "";
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                scnTitle.Text = Resources.Strings.mnOthers_iucn_list;
                Page_Title=Resources.Strings.mnOthers_Ecozones + " - testudines.org";
                FncFilTop();
                FncFillBread();
                FncFillGrid();
                FncFillPanelRight();

            }
        }
        private void FncFillPanelRight()
        {
            cls.bbdd.ClsReg_tmst_iucn_redlist oEcozone = new cls.bbdd.ClsReg_tmst_iucn_redlist();

            scnPanelRightLastDocs.Text ="<h3>"+ Resources.Strings.Tortoises+"</h3>" +cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_DL(cls.ClsGlobal.CacheRebuid);
        }
        private void FncFilTop()
        {
            scnContentTop.Text = "";
            

        }
        private void FncFillBread()
        {
          
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.others, "");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_iucn_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);

        }
        private void FncBldSqlCmd()
        {
            m_SqlSelect = "SELECT  `tmst_iucn_redlist`.`RL_levelID` as `DocId`, `tmst_iucn_redlist`.`DocLngId` as `DocLngId`, `tmst_iucn_redlist`.`RL_Key`,  `tmst_iucn_redlist`.`LR_DecriptionShort` as `Title`,  `tmst_iucn_redlist`.`abstract` as `abstract`, `tmst_iucn_redlist`.`UrlImg`  as DocImgThumbnail   FROM `tmst_iucn_redlist`;";

        }
        private void FncFillGrid()
        {
            FncBldSqlCmd();
            string szSelect = m_SqlSelect;
    
           

            DataTable oTb = new DataTable("tbIUCN");
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