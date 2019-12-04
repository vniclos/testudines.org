using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.tortoises.groups
{
    public partial class groups_list : cls.ClsPageBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Page_Title=(Resources.Strings.mnTortoises_groups_groups_list + " - testudines.org");
                FncFilTop();
                FncFillAdmin();
                FncFillBread();
                FncFillBody();
                FncFillPanelRight();

            }
        }
        private void FncFillAdmin()
        {
            if (!cls.ClsUtils.User_isAdmin())
            {
                scnLnk.Text = "";
            }
            else
            {
                scnLnk.Text = "<a class=\"btn-tiny\" href=\"/es/tortoises/groups/groups-mng-list\">" + Resources.Strings.Administration + "</a>";
            }

        }
        private void FncFillPanelRight()
        {
            // cls.bbdd.ClsReg_tdoclng_articles oArticle = new cls.bbdd.ClsReg_tdoclng_articles();

            //scnPanelRightLastDocs.Text = oArticle.FncCache_GET_last(cls.ClsGlobal.CacheRebuid, 6);
        }
        private void FncFilTop()
        {
            scnTitle.Text =  Resources.Strings.mnTortoises_groups_groups_list ;

        }
        private void FncFillBread()
        {

            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, "/"+ cls.ClsGlobal.LngIdThread +"/tortoises/tortoise/tortoises-list");

            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_groups_groups_list, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);

        }
        private void FncFillBody()
        {
            //cls.bbdd.ClsReg_tdoclng_testudines_full_html oTx = new cls.bbdd.ClsReg_tdoclng_testudines_full_html();

            cls.cache.ClsCacheTortoise_TreeULView oTx = new cls.cache.ClsCacheTortoise_TreeULView();

            scnHtml.Text = oTx.FncCache_GET(false, cls.ClsGlobal.LngIdThread);
        }

    }
}