using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines
{
    public partial class _Default : cls.ClsPageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }
        private void Page_Prerender(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {
                FncFill();
                Title = Resources.Strings.PageTitle_Home;
                FncBreadCrumbs();
            }
        }
        private void FncFill()
        {
            cls.bbdd.ClsReg_tdoclng_articles oArticle = new cls.bbdd.ClsReg_tdoclng_articles();
            cls.bbdd.ClsReg_tdoclng_notices oNotices = new cls.bbdd.ClsReg_tdoclng_notices();
            cls.bbdd.ClsReg_tdoclng_foods oFoods = new cls.bbdd.ClsReg_tdoclng_foods();
            cls.cache.ClsCacheTortoise_TreeULView oTaxaUl = new cls.cache.ClsCacheTortoise_TreeULView();


            scnBox11.Text = cls.cache.ClsCache_Tortoise_Last.FncCache_GET(cls.ClsGlobal.CacheRebuid,4);
            scnBox21.Text = oNotices.FncCache_GET_lastImg(cls.ClsGlobal.CacheRebuid, 4);
            scnBox12.Text = oArticle.FncCache_GET_last(cls.ClsGlobal.CacheRebuid,4);

            scnBox22.Text = oFoods.FncCache_GET_lastImg(cls.ClsGlobal.CacheRebuid, 4);
            scnBoxRight.Text = cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_DL(cls.ClsGlobal.CacheRebuid);
            
        }
        private void FncBreadCrumbs()
        {
            string szBC="";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBC);

            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBC);
            Page_FncBreadCrumb (ref szBC);
        }
       
    }
    }
