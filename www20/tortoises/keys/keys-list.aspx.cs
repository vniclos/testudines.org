using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.Threading;
namespace testudines.tortoises.keys
{
    public partial class keys_list :cls.ClsPageBase
    {
        
        private bool m_isAdmin = false;
        private string m_DocId = "0";
        private string m_DocLngId = "en";
        private cls.bbdd.ClsReg_tdoc oRegTaxaAll = new testudines.cls.bbdd.ClsReg_tdoc();
        protected void Page_PreRender(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Page_Title=(Resources.Strings.mnTortoises_keys_groups_list + " - testudines.org");
                FncStadisticVisitAdd();
                FncFillBread();
                FncFillContentLeft();



            }
        }
       private void FncGetParameters()
        { }
        private void FncFillContentLeft()
        {
            cls.cache.ClsCacheTortoise_TreeULView oTx = new cls.cache.ClsCacheTortoise_TreeULView();
            //cls.bbdd.ClsReg_tdoclng_testudines_full_html oTx = new cls.bbdd.ClsReg_tdoclng_testudines_full_html();

            // string szMPageTitle = "";
            cls.cache.ClsFillTreeViewULTaxonKey oFill = new cls.cache.ClsFillTreeViewULTaxonKey();

            // scnTaxonKeysList.Text = oFill.Fnc_HtmlULTreeView(true, "en",MpageSession.IsAdmin  );
            m_DocLngId = cls.ClsGlobal.LngIdThread;
            scnTaxonKeysList.Text = oFill.Fnc_HtmlULTreeView(cls.ClsGlobal.CacheRebuid, m_DocLngId, cls.ClsUtils.User_isAdmin());
        }
        public bool FncBindBool(int data)
        {
            if (data == 1)
                return true;
            else
                return false;
        }


        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, "/" + cls.ClsGlobal.LngIdThread + "/tortoises/tortoise/tortoises-list");

            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_keys_groups_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }
        private void FncStadisticVisitAdd()
        {
            Page_FncStadisticVisitAdd(0, cls.ClsGlobal.LngIdThread, "");
        }
    }
}