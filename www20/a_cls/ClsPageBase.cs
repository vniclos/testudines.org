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
    public class ClsPageBase : System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string sCulture = "en-us";

            if (HttpContext.Current.Request.Cookies["CulturesCookie"] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["CulturesCookie"];
                if (cookie != null)
                {
                    sCulture = cookie.Value.Split('=')[1];
                }
            }

            //Check if PostBack is caused by Language DropDownList.
            if (Request.Form["__EVENTTARGET"] != null && Request.Form["__EVENTTARGET"].Contains("scnCulturesCode"))
            {
                //Set the Language.
                sCulture = Request.Form[Request.Form["__EVENTTARGET"]];


                HttpCookie CulturesCookie = new HttpCookie("CulturesCookie");
                CulturesCookie.Values["CulturesCookie"] = sCulture;
                CulturesCookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(CulturesCookie);
                ((Mpg_Site)Page.Master).MpgscnCulturesCode(sCulture);
                //Set the Culture.

                
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(sCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(sCulture);
        }

        protected override void OnLoadComplete(EventArgs e)
    {
       

        base.OnLoadComplete(e);
    }
        public void Page_FncBreadCrumb(ref string BreadCrumb)
        {
            ((Mpg_Site)Page.Master).MPgBreadCrumb(ref BreadCrumb);
           
        }
        public String  Page_Title
        {
            set
            {
                ((Mpg_Site)Page.Master).MpgTitle(value);
                Page.Title = value;
            }
        }
        public string Page_Name
        {
            get
            {
                string sPath = Request.Url.AbsolutePath;
                System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
                string sRet = oInfo.Name;
                return sRet;
            }
        }
        public void Page_FncStadisticVisitAdd(UInt64 pDocId, String pDocLngId, String pDocSecction)
        {
            string szUrlReferrer = "null";
            if (Request.UrlReferrer != null)   { szUrlReferrer = Request.UrlReferrer.ToString(); }
            
                FncStdVisitAddCount( pDocId, pDocLngId, pDocSecction);
            
        }
        /// <summary>
        /// Añade registro a estadisticas de
        /// </summary>
        /// <param name="pDocId">Id del documento</param>
        /// <param name="pDocLngId">Idioma solicitado</param>
        /// <param name="pDocSecction">Seccion del documento, por ejemplo, en taxones Descripcion, resproduccion, distribucion...</param>
        private void FncStdVisitAddCount(UInt64 pDocId, String pDocLngId,String pDocSecction)
        {
         
            DateTime mNow = System.DateTime.Now;

      
            cls.bbdd.ClsReg_tstd_vistitlog oRegStd = new cls.bbdd.ClsReg_tstd_vistitlog();
           
           

            oRegStd.DocClass = Page_Name;
            oRegStd.stdDocId = pDocId;
            oRegStd.stdDocLngId = pDocLngId;
            oRegStd.stdIPFrom = "";
            oRegStd.stdDate = mNow;
            oRegStd.stdYear = mNow.Year;
            oRegStd.stdMonth = mNow.Month;
            oRegStd.stdDay = mNow.Day;
            oRegStd.stdHour = mNow.Hour;
            oRegStd.stdIPFrom = Request.UserHostAddress;
            oRegStd.stdCountryIP = "";  //FncCountryFromIp("peding develop");
            string sz = "";
            try
            {
                sz = Request.UrlReferrer.ToString();
            }
            catch { sz = "no UrlReferrer"; };
            oRegStd.stdReferer = sz;
            oRegStd.stdSession = Session.SessionID;
            oRegStd.stdUser = cls.ClsUtils.User_name();
            oRegStd.stdUserAgent = Request.UserAgent;
         
            oRegStd.stdUrl = Request.Url.ToString();
            oRegStd.stdDocSection = pDocSecction;
            oRegStd.FncSqlSave();

            if (pDocId == 0) return;

            cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            if (!oRegDoc.FncSqlFind(pDocId)) return;
            oRegDoc.DocStdVisitCount++;
            oRegDoc.DocStdVisitLast = mNow;
            oRegDoc.FncSqlSave();
            oRegDoc.Dispose();
        }


    }
}