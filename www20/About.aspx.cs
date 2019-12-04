using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines
{
    public partial class About :cls.ClsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) FncFill();
        }
        private void FncFill()
        {
            String szBreadCrumb = "";
         cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb,Resources.Strings.About, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);

            Page_FncBreadCrumb(ref szBreadCrumb);

        }
    }
}