using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.tortoises.groups
{
    public partial class group : cls.ClsPageBase
    {



        private cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
        private cls.ClsUserContest oUsr = new cls.ClsUserContest();
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "es";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncGetParameters();
                FncFill();
                FncFillHead();
                FncStadisticVisitAdd();
                FncFillBreadCrumbs();
            }

        }


        private void FncGetParameters()
        {
            UInt64 DocId = 15274;
            String DocLngId = "es";



            try
            {
                DocId = Convert.ToUInt64(Page.RouteData.Values["docid"].ToString());
                DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
            }
            catch {; }
            if (Request.QueryString["docid"] != null)
            {
                DocId = Convert.ToUInt64(Request.QueryString["docid"].ToString());
            }
            if (Request.QueryString["doclngid"] != null)
            {
                DocLngId = Request.QueryString["doclngid"].ToString();
            }
            m_DocId = DocId;
            m_DocLngId = DocLngId;

        }
        private void FncFillHead()
        {
            
            Page_Title=(Resources.Strings.mnTortoises_group+" "+ oGroup.ATaxIdName);
        }
        private void FncFill()
        {
      
          
            cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup = new testudines.cls.bbdd.ClsReg_tdoclng_testudinesgroups();
            cls.bbdd.ClsReg_tdoc oDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();

            bool bExist = true;
            bExist = oDoc.FncSqlFind(m_DocId);
            if (bExist) bExist = oDocLng.FncSqlFind(m_DocId, m_DocLngId);

            if (bExist)
            {
                FncFill(ref oDoc, ref oDocLng, ref oGroup);

            }
            else
            {

                /*

                MPageDocId = DocId;
                MPageDocLngId = DocLngId;
                MPageTitle = "Opps !";
                MPageTitleSub = Resources.Strings.Im_Sorry_Document_Not_Availave;
                MPageDocLngFlags = "";
                MpageMetaTitle = Resources.Strings.Im_Sorry_Document_Not_Availave; ;
                MpageMetaAuthor = "";
                MpageMetaDescription = Resources.Strings.Im_Sorry_Document_Not_Availave;
                MpageMetaRobots = "never";
                MpageMetaKeywords = "error";
                MPagePnlVisible = false;
                scnHtml.Text = "<br/><br/>This document not is available at this moment..</br>Doc: " + DocId.ToString() + "-" + DocLngId + "</p>";
                return;
                */


            }

        }


        private void FncStadisticVisitAdd()
        {
        
            Page_FncStadisticVisitAdd(m_DocId, m_DocLngId, "");
        
        }
        private void FncFill(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup)
        {
            oGroup.FncSqlFind(m_DocId, m_DocLngId);
            Page_Title=(oGroup.Title + " - testudines.org");
            Page.Title = oGroup.Title;
            scnPanelTop.Text = "";
            FncFillPanelLeft(ref oDoc, ref oDocLng, ref oGroup);
            FncFillPanelRight(ref oDoc, ref oDocLng, ref oGroup);
           

        }
        private void FncFillBreadCrumbs()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises, cls.ClsGlobal.LngIdThread + "/tortoises/tortoises-list");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_groups_list, cls.ClsGlobal.LngIdThread + "");
            
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);



        }
        private void FncFillPanelLeft(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup)
        {
           
                scnPanelLeft.Text = oGroup.FncGetCache_Html(cls.ClsGlobal.CacheRebuid); // crea htm y guarda cache para la proxima vez

           
        }
        private void FncFillPanelRight(ref cls.bbdd.ClsReg_tdoc oDoc, ref cls.bbdd.ClsReg_tdoclng oDocLng, ref cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup)
        { //scnPanelRightLastDocs.Text = oGroup.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6); }
        }
    }
}