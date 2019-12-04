using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.others.acknowledgements
{
    public partial class acknowledgements : cls.ClsPageBase
        
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fncFilHead();
                fncFillBreadCrumb();
                fncFillMainContent();
                fncFillMainContentRight();
            }
        }
        
        private void fncFilHead()
        {

            Page_Title=Resources.Strings.Acknowledgements;
        }
           
        private void fncFillBreadCrumb() {
         
           
            string szBreadCrumb = "";
            cls.ClsHtml.fncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list, ("/"+cls.ClsGlobal.LngIdThread+ "/others/acknowledgements/acknowledgements_list"));
            cls.ClsHtml.fncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.mnOthers_Acknowledgements_Acknoelegment,"" );
            cls.ClsHtml.fncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_fncBreadCrumb(ref szBreadCrumb);
        }
        private void fncFillMainContent()
        {
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oRegCache = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();
            scnMainContent.Text = oRegCache.fncCache_GET(cls.ClsGlobal.CacheRebuid, cls.ClsGlobal.LngIdThread);
            scnMainContentRight.Text ="<h2 class=\"h2_reverse\">"+ Resources.Strings.Last_Updates+"</h2>"+ oRegCache.fncCache_GET_last(cls.ClsGlobal.LngIdThread, cls.ClsGlobal.CacheRebuid,10)                ;
        }
        private void fncFillMainContentRight()
        {
        
        }
    }
}