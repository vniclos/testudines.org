using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.WebControls;
using Telerik.RadTreeviewUtils;

namespace testudines.tortoises
{
    public partial class tortoises_taxonomy_list : cls.ClsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncFillPageTitle();
                FncBreadCrumb();
                FncFillMainContent();
                FncFillMainRight();
            }
        }
        private void FncBreadCrumb()
        {
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises, "");
            // cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Tortoises, cls.ClsGlobal.LngIdThread + "/tortoises/" + Resources.Strings.mnTortoises_Taxa_TortoisesList);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnTortoises_Taxa_TortoisesTaxonomy, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }
        private void FncFillPageTitle()
        {
            Page.Title = Resources.Strings.mnTortoises_Taxa_TortoisesTaxonomy;
            scnPageTitle.Text = Resources.Strings.mnTortoises_Taxa_TortoisesTaxonomy;
        }
        private void FncFillMainContent()
        {

            cls.cache.ClsCache_Tortoise_Tree_Bootstrap oTree = new cls.cache.ClsCache_Tortoise_Tree_Bootstrap();
            scnPageContent.Text = oTree.FncCache_GET(cls.ClsGlobal.CacheRebuid, cls.ClsGlobal.LngIdThread);
            //scnPageContent.Text = oTree.FncCache_GET(false, cls.ClsGlobal.LngIdThread);
        }
        private void FncFillMainRight()
        {
            scnPageRight.Text = cls.cache.ClsCache_Tortoise_Last.FncCache_GET(cls.ClsGlobal.CacheRebuid, 10); ;
        }



    }
}