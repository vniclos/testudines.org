using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines
{
    public partial class oops : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { FncFill(); }

        }
        private void FncFill()
        {
            scnMsg.Text = "";
            scnUrlPetition.Text = "";
            if (Request.QueryString["url"]!=null)
            {
                scnUrlPetition.Text = Request.QueryString["url"].ToString();
            }
            else
            {
                if (Request.UrlReferrer != null) { scnUrlPetition.Text = Request.UrlReferrer.ToString(); }
            }


            if (Request.QueryString["msg"] != null)
            {
                scnMsg.Text = Request.QueryString["msg"].ToString();
            }



            if (Request.UrlReferrer != null)
            {
                scnUrlReferer.Text = Request.UrlReferrer.ToString(); ;
            }
            if (User.Identity.IsAuthenticated)
            {
                scnYouName.Text = User.Identity.Name;
                    }
            else
            {
                scnYouName.Text = "Anonimous";
            }
            scnIpFrom.Text = Request.UserHostAddress;
            scnBrowser.Text = Request.UserAgent;
            scnRequestContext.Text = Request.RequestContext.ToString();
        }
    }
}