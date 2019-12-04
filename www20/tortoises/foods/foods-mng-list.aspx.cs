using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
namespace testudines.tortoises.foods
{
    public partial class foods_mng_list : cls.ClsPageBase
    {

        String m_Select= "select tdoclng_foods.DocId, tdoclng_foods.DocLngId,  concat( '/a_img/a_site/ico16/flag16_', doclngid,'.gif') as flag ,tdoclng_foods.Title, tdoclng_foods.Abstract,  tdoc.DocAcknowledgements, tdoc.DocAuthors,  DATE_FORMAT(tdoc.DocDateUpdate, '%Y-%m-%d') as 'update'  from tdoclng_foods LEFT join tdoc on tdoclng_foods.DocId = tdoc.DocId";
        String m_SelectWhere = " where title like '%#filter#%' or   tdoc.DocAcknowledgements like '%#filter#%' or tdoc.DocAuthors like '%#filter#%' or tdoclng_foods.Abstract like '%#filter#%' ";
        String m_SelectOrderUpdate = " order by  tdoc.DocDateUpdate desc";
        String m_SelectOrderTitle = " order by  tdoclng_foods.title";
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
            Page_Title=(Resources.Strings.mnToroises_foods_food_list);

        }

        private void FncFillMainContent()
        {

            FncFillGrid();
        }


        private void FncStadisticVisitAdd()
        {
            cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            oRegDoc.DocId = 0;
            Page_FncStadisticVisitAdd(0, cls.ClsGlobal.LngIdThread, "");

        }

        private void FncFillBreadCrumb()
        {
            //acknowledgement

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Foods, cls.ClsGlobal.LngIdThread + "/foods/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_foods_foods_mng_list, "");
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

            DataTable oTb = new DataTable("tbfood");
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