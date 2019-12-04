using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Routing;
namespace testudines.a_dlg
{
    public partial class dlg_iucn_redlist : System.Web.UI.Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //{doclngid}/dlg_iucn_redlist/{docid}", new clsRouteHandler("~/a_dlg/dlg_iucn_redlist.aspx")));
                //{doclngid}/dlg_iucn_redlist/{docid}", new clsRouteHandler("~/a_dlg/dlg_iucn_redlist.aspx")));
                UInt64 DocId = 0;
                string DocLngId = "";

                try
                {
                    DocId = Convert.ToUInt64(Page.RouteData.Values["docid"].ToString());
                    if(Page.RouteData.Values["doclngid"] != null)
                        { 
                    DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
                    }
                    else { DocLngId = "es"; }
                    cls.bbdd.ClsReg_tmst_iucn_redlist oReg = new testudines.cls.bbdd.ClsReg_tmst_iucn_redlist();
                    oReg.FncSqlFind(DocId, DocLngId);
                    scnHtml.Text = oReg.FncHtml();
                }
                catch
                {
                    scnHtml.Text = Resources.Strings.notfound;
                        }
               
            
           
          
            }
        }
        //==========================================
        //==========================================

 
      //======================================================
        //================================================================

    }
}