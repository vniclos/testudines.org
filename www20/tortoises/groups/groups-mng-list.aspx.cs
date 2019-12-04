using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace testudines.tortoises.groups
{
    public partial class groups_mng_list : cls.ClsPageBase
    {
        string m_SqlSelect = "SELECT tdoclng_testudines_groups.DocId as DocId, tdoclng_testudines_groups.DocLngId as DocLngId,concat('<b>',ATaxIdName ,'</b><br/> ', NameVulgar) as titlevu , tdoclng_testudines_groups.Title as Title,tdoclng_testudines_groups.ATaxLevel, IF(1= tdoclng_testudines_groups.IsOk,'&#10003;','x') as IsOk,IF(1= tdoclng_testudines_groups.IsTaxa2014,'&#10003;','x')  as IsTaxa2014   , tdoc.DocTypeGroup, tdoc.DocTypeGroupSub, tdoclng_testudines_groups.Ref_ITIS_Number as ItisId    FROM tdoclng_testudines_groups LEFT JOIN tdoc ON tdoclng_testudines_groups.DocId = tdoc.DocId  ";
        string m_SqlSelectOrder = " order by ATaxIdName";


        String m_Select = "SELECT tdoclng_testudines_groups.DocId as DocId, tdoclng_testudines_groups.DocLngId as DocLngId,  concat( '/a_img/a_site/ico16/flag16_', doclngid,'.gif') as flag,  concat('<b>',ATaxIdName ,'</b><br/> ', NameVulgar) as titlevu , tdoclng_testudines_groups.Title as Title,tdoclng_testudines_groups.ATaxLevel, IF(1= tdoclng_testudines_groups.IsOk,'&#10003;','x') as IsOk,IF(1= tdoclng_testudines_groups.IsTaxa2014,'&#10003;','x')  as IsTaxa2014   , tdoc.DocTypeGroup, tdoc.DocTypeGroupSub, tdoclng_testudines_groups.Ref_ITIS_Number as ItisId , DATE_FORMAT(tdoc.DocDateUpdate, '%Y-%m-%d') as 'update',tdoc.DocAuthors    FROM tdoclng_testudines_groups LEFT JOIN tdoc ON tdoclng_testudines_groups.DocId = tdoc.DocId  ";
        String m_SelectWhere = " where title like '%#filter#%' or   tdoc.DocAcknowledgements like '%#filter#%' or tdoc.DocAuthors like '%#filter#%' ";
        String m_SelectOrderUpdate = " order by  update desc";
        String m_SelectOrderTitle = "  order by Title";
        String m_filter = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (!cls.ClsUtils.User_isAdmin())
                {
                    Response.Redirect("/OppNoAdmin.aspx");
                }
                else
                {

                    FncFillHead();
                    FncFillBreadCrumb();
                    FncFillMainContent();
                    FncFillMainContentRight();
                    FncStadisticVisitAdd();
                }


            }
        }
        private void FncFillHead()
        {
            Page_Title=(Resources.Strings.mnTortoises_groups_mng_list);
            //scnTitlePage.Text= Resources.Strings.mnTortoises_groups_mng_list;
        }

        private void FncFillMainContent()
        {

            FncFillGrid();
        }


        private void FncStadisticVisitAdd()
        {
        
            Page_FncStadisticVisitAdd(0, cls.ClsGlobal.LngIdThread, "");

        }

        private void FncFillBreadCrumb()
        {
            //acknowledgement

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises, cls.ClsGlobal.LngIdThread + "/tortoises/tortoises-list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_groups_mng_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }

        private void FncFillMainContentRight() { }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 szDocId = Convert.ToInt32(scnGridView.SelectedRow.Cells[2].Text);

        }

        private String FncBldSqlCmd()
        {
            String szFilter = scnFilterTxt.Text.Trim(); ;
            String szSelect = m_Select;
            if (szFilter != "")
            {
                szSelect += m_SelectWhere.Replace("#filter#", szFilter);
            }
            if (scnOrderby.SelectedValue == "title")
            {
                szSelect += m_SelectOrderTitle;
            }
            else if (scnOrderby.SelectedValue == "Updated")
            {
                szSelect += m_SelectOrderUpdate;
            }
            return szSelect;
        }
        private void FncFillGrid()
        {

            string szSelect = FncBldSqlCmd();

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

        protected void scnFilterNew_Click(object sender, EventArgs e)
        {
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/others/acknowledgements/acknowledgement_mng_edit/0";
            Response.Redirect(szUrl);
        }

        protected void scnGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridView.PageIndex = e.NewPageIndex;

            this.FncFillGrid();
        }
    }
}