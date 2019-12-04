using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;
     
namespace testudines
{
    public class Global : HttpApplication
    {
       

        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Application["Sessions"] = Convert.ToInt32(Application["AppSessions"]) + 1;
      
            cls.ClsSession oSession = new testudines.cls.ClsSession();
            //cls.bbdd.ClsReg_tmst_user oSessionUser = new testudines.cls.bbdd.ClsReg_tmst_user();

            if (Request.UserHostName == "127.0.0.1" || Request.UserHostName == "192.168.2.5" || Request.UserHostAddress.ToString() == "::1")
            {
                oSession.FncLogin("Admin", "algadins");
                // oSession.FncLogout();
            }
            else
            {
                oSession.FncLogout();
            }
            Session.Add("oSession", oSession);
           
        }
    }
}