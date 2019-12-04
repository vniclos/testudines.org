using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
    namespace testudines.others.acknowledgements
{
    public partial class acknowledgements_mng_list : cls.ClsPageBase
    {
        String m_Select = "SELECT tdoc_acknowledgment.DocId as DocId, tdoc_acknowledgment.Title as Title  FROM tdoc_acknowledgment ";
        String m_SelectWhere = " where tdoc_acknowledgment.Title like '%#find#%'";
        String m_SelectOrder = " order by tdoc_acknowledgment.Title";
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

                    fncFillHead();
                    fncFillBreadCrumb();
                    fncFillMainContent();
                    fncFillMainContentRight();
                    Page_fncStadisticVisitAdd(0, cls.ClsGlobal.LngIdThread, "");

                }


            }
        }
        private void fncFillHead()
        {
            Page_Title=Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list;
            
        }

        private void fncFillMainContent()
        {

            fncFillGrid();
        }


       

        private void fncFillBreadCrumb()
        {
            //acknowledgement

            string szBreadCrumb = "";
            cls.ClsHtml.fncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.others, cls.ClsGlobal.LngIdThread+"/others/");
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, cls.ClsGlobal.LngIdThread+"/others/acknowledgements");
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegment_mng_list, "");
            cls.ClsHtml.fncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_fncBreadCrumb(ref szBreadCrumb);

        }

        private void fncFillMainContentRight() { }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Int32 szDocId = Convert.ToInt32(scnGridView.SelectedRow.Cells[2].Text);

        }

        private String fncBldSqlCmd()
        {
            String szFilter = scnFilterTxt.Text.Trim(); ;
            String szSelect = m_Select;
            if (szFilter != "")
            {
                szSelect += m_SelectWhere.Replace("#find#", szFilter);
            }
            szSelect += m_SelectOrder;
            return szSelect;
        }
        private void fncFillGrid()
        {

            string szSelect = fncBldSqlCmd();

            DataTable oTb = new DataTable("tbArticle");
            cls.clsMysql.fncFill_datatable(ref szSelect, ref oTb);


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
            fncFillGrid();
        }

        protected void scnFilterClear_Click(object sender, EventArgs e)
        {
            m_filter ="";
            scnFilterTxt.Text = "";
            fncFillGrid();
        }

        protected void scnFilterNew_Click(object sender, EventArgs e)
        {
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/others/acknowledgements/acknowledgement-mng-edit/0";
            Response.Redirect(szUrl);
        }

        protected void scnGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridView.PageIndex = e.NewPageIndex;

            this.fncFillGrid();
        }
    }
}