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
    public partial class dlg_ecozone_help : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string  EcozoneListCode = "";
                string DocLngId = "";

                cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oReg = new testudines.cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
                try
                {
                    EcozoneListCode = Page.RouteData.Values["EcozoneListCode"].ToString();
                    DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();

                    oReg.FncSqlFindByEcozoneListCode(DocLngId, EcozoneListCode);
                    scnHtml.Text = oReg.FncGetCache_Html(cls.ClsGlobal.CacheRebuid );
                    return;
                }
                catch
                {
                    scnHtml.Text = Resources.Strings.notfound;
                    return;
                }


               
               


            }
        }
        //==========================================
        //==========================================

 
      //======================================================
       
  
        //================================================================

    }
}