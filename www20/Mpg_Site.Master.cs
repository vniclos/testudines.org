
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Globalization;
using System.Threading;
namespace testudines
{
    public partial class Mpg_Site : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            //FncCultureInitialize();
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }


        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }

        }




        protected void InitComplete(object sender, EventArgs e)
        { }
      
        protected void Page_Load(object sender, EventArgs e)
        {
             
            FncCultureInitialize();
            FncFillNavBar();
            FncFillAdmin();
        
        }

        private void FncFillNavBar()
        {
            scnNavBar.Text = cls.cache.ClsCache_Menu.FncHtmlMenu(cls.ClsGlobal.CacheRebuid, CultureInfo.CurrentCulture.Name);
        }
        public void MpgscnCulturesCode(String sCulturesCode)
        {


            scnCulturesCode.ClearSelection(); //making sure the previous selection has been cleared
            scnCulturesCode.Items.FindByValue(sCulturesCode).Selected = true;



    }

        public void MPgBreadCrumb(ref String MpgBreadCrumb)
        {
            scnMpgBreadCrumb.Text = MpgBreadCrumb;
        }
        public void MpgTitle(String pTitle)
        {

            this.Page.Title = pTitle + "´- testudines.org";
        }
        protected void scnBtnLogin_Click(object sender, EventArgs e)
        {

        }
        private void FncFillAdmin()
        {
            String sz = cls.cache.clsCache_MenuAdmin.FncHtmlMenu(cls.ClsGlobal.CacheRebuid, cls.ClsGlobal.LngIdThread);
            try
            {

                if (cls.ClsUtils.User_isAdmin())
                {
                    scnMenuAdmin2.Text = sz;
                }
            }
            catch { }

        }

        protected void sncLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {



            HttpCookie CulturesCookie = new HttpCookie("CulturesCookie");
            CulturesCookie.Values["CulturesCookie"] = this.scnCulturesCode.SelectedValue;
            CulturesCookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Add(CulturesCookie);
            this.Response.Redirect(Request.Url.AbsoluteUri);
        }
        private void FncCultureInitialize()
        {
            if (IsPostBack) { return; }
            var  aCulturesCodeValid = new[] { "es-ES", "en-EN" };   // string[,]
            string sCultureDefault = "en-EN";
            String sCurrentCulture = Thread.CurrentThread.CurrentCulture.Name;
            String sCurrentUICulture = Thread.CurrentThread.CurrentUICulture.Name;
            String sCultureCookie = ""; ;

            bool bValid = false;

            // if exist read and validate.
            if (HttpContext.Current.Request.Cookies["CulturesCookie"] != null && HttpContext.Current.Request.Cookies["CulturesCookie"].Value.ToString() != "")
            {
                sCultureCookie = HttpContext.Current.Request.Cookies["CulturesCookie"].Value.ToString();
                sCultureCookie = sCultureCookie.Split('=')[1].ToString(); ;
                for (int i = 0; i < aCulturesCodeValid.Length; i++)
                {
                    if (aCulturesCodeValid[i] == sCultureCookie) {
                        bValid = true; }
                }
                if (!bValid) { sCultureCookie = sCultureDefault; }
            }
            else // if not exist create.
            {
               
                if (sCurrentCulture.StartsWith("en-")) { sCurrentCulture = "EN-en"; }
                else if (sCurrentCulture.StartsWith("es-")) { sCurrentCulture = "ES-es"; }
                else { sCurrentCulture = sCultureDefault; }

                sCultureCookie = sCurrentCulture;
                HttpCookie CulturesCookie = new HttpCookie("CulturesCookie");
                for (int i = 0; i < aCulturesCodeValid.Length; i++)
                {
                    if (aCulturesCodeValid[i] == sCultureCookie) { bValid = true; }
                }
                if (!bValid) { sCultureCookie = sCultureDefault; }
                CulturesCookie.Values["CulturesCode"] = sCultureCookie;
                CulturesCookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(CulturesCookie);
                //this.Response.Redirect(Request.Url.AbsoluteUri);
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(sCultureCookie);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(sCultureCookie);
            cls.ClsUtils.FncDropDownSetSelect(ref this.scnCulturesCode, sCultureCookie);
            }

        }


    }
