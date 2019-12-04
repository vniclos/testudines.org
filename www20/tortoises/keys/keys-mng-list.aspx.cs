using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
namespace testudines.tortoises.keys
{
    public partial class keys_mng_list : cls.ClsPageBase
    {
        private string m_DocLngId_en = "en";
        private string m_DocLngId_lng = "es";
        private Int64 m_DocId = 0;
        private string m_SqlSelect = "SELECT tdoclng_testudines_keys_lng.DocId as DocId, tdoclng_testudines_keys_lng.DocLngId as DocLngId, tdoclng_testudines_keys.TOWDescription as Title, tdoc.DocTypeGroup, tdoc.DocTypeGroupSub ,tdoclng_testudines_keys.TOWNodekeyNum, tdoclng_testudines_keys.TOWNodeId,tdoclng_testudines_keys.TOWNodeParentId, tdoclng_testudines_keys.IsRevised  FROM tdoclng_testudines_keys_lng  LEFT JOIN tdoc ON tdoclng_testudines_keys_lng.DocId = tdoc.DocId   LEFT JOIN tdoclng_testudines_keys ON tdoclng_testudines_keys_lng.DocId = tdoclng_testudines_keys.DocId ";
        private string m_SqlSelectOrder = " order by TOWNodeId";
        private string m_SelectWhere = " where TOWNodeId='#filter' or TOWNodeParentId=='#filter'";
        private String m_filter = "";
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
            Page_Title = Resources.Strings.Articles_managment;

        }

        private void FncFillMainContent()
        {

            FncFillGrid();
        }


        private void FncStadisticVisitAdd()
        {
            Page_FncStadisticVisitAdd(0, cls.ClsGlobal.LngIdThread, "");
        }
        private void FncFillMainContentRight() { }

        private void FncFillBreadCrumb()
        {
            //acknowledgement

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, cls.ClsGlobal.LngIdThread + "/tortoises/tortoise/tortoises-list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Keys, cls.ClsGlobal.LngIdThread + "/tortoises/keys/keys-list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnToroises_keys_mng_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);

        }
        private String FncBldSqlCmd()
        {
            String szFilter = scnFilterTxt.Text.Trim(); ;
            String szSelect = m_SqlSelect;
            if (szFilter != "")
            {
                szSelect += m_SelectWhere.Replace("#filter#", szFilter);
            }
            if (scnOrderby.SelectedValue == "TOWNodeParentId")
            {
                szSelect += " order by TOWNodeParentId";
            }
            else if (scnOrderby.SelectedValue == "TOWNodeId")
            {
                szSelect += " order by TOWNodeId";
            }
            return szSelect;
        }
        private void FncFillGrid()
        {

            string szSelect = FncBldSqlCmd();

            DataTable oTb = new DataTable("tbKeys");
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect, ref oTb);


            scnGridView1.DataSource = oTb;
            scnGridView1.DataBind();





            if (scnGridView1.Rows.Count == 0)
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
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/tortoises/keys/key-mng-edit/0";
            Response.Redirect(szUrl);
        }
        protected void GridView1_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            scnGridView1.PageIndex = e.NewPageIndex;

            this.FncFillGrid();
        }

       
        protected void scnGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridView1.PageIndex = e.NewPageIndex;

            this.FncFillGrid();
        }
    }
    }
