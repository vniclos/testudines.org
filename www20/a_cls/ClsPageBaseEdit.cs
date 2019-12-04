using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Routing;
using testudines;
using System.Threading;
using System.Globalization;



using System.Collections.Generic;



namespace testudines.cls
{
    public class ClsPageBaseEdit : System.Web.UI.Page
    {

        public void PageHeadTitle(String Title)
        {
            //Page.Title = string.Format("Master Page Tutorials :: About :: {0:d}", DateTime.Now);
            Page.Title = Title;
            
        }

    protected override void OnLoadComplete(EventArgs e)
    {
       

        base.OnLoadComplete(e);
    }
        public void Mpg_BreadCrumb(ref string BreadCrumb)
        {
            ((Mpg_Site_Edit)Page.Master).MPgBreadCrumb(ref BreadCrumb);
           
        }
        public void Page_Title(string pTitle)
        {

            ((Mpg_Site_Edit)Page.Master).MpgTitle( pTitle);
        }
        public void Mpg_SetDocumentId(UInt64 pDocId, String pDocLngId)
        {
            ((Mpg_Site_Edit)Page.Master).FncSetDocumentIds(pDocId, pDocLngId);
            


        }
       
    }
}