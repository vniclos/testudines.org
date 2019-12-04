using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.acknowledgements
{
    public partial class acknowledgements : cls.ClsPageBase
        
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncFilHead();
                FncFillBreadCrumb();
                FncFillMainContent();
                FncFillMainContentRight();
            }
        }
        
        private void FncFilHead()
        {

            Page_Title=Resources.Strings.Acknowledgements;
        }
           
        private void FncFillBreadCrumb() {
         
           
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, ("/"+cls.ClsGlobal.LngIdThread+ "/others/acknowledgements/acknowledgements_list"));
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegment,"" );
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }
        private void FncFillMainContent()
        {
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oRegCache = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();
            scnMainContent.Text = oRegCache.FncCache_GET(cls.ClsGlobal.CacheRebuid, cls.ClsGlobal.LngIdThread);
            scnMainContentRight.Text ="<h2 class=\"h2_reverse\">"+ Resources.Strings.Last_Updates+"</h2>"+ oRegCache.FncCache_GET_last(cls.ClsGlobal.LngIdThread, cls.ClsGlobal.CacheRebuid,10)                ;
        }
        private void FncFillMainContentRight()
        {
        
        }
    }
}