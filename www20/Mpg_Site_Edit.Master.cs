
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
using MySql.Data.MySqlClient;
using System.Data;

namespace testudines
{


    public partial class Mpg_Site_Edit : System.Web.UI.MasterPage
    {
        private UInt64 m_DocId = 0;
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            FncFillNavBar();
            FncFillAdmin();
        }

        private void FncFillNavBar()
        {
            scnNavBar.Text = cls.cache.ClsCache_Menu.FncHtmlMenu(cls.ClsGlobal.CacheRebuid, CultureInfo.CurrentCulture.Name);
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
                    scnMenuAdmin.Text = sz;
                }
            }
            catch { }

        }

        public void FncBtnFilBiblio(int iOrder)
        {

            string szSql = "Select tdoc_biblio.DocId,  tdoc_biblio_rel.DocIdParent, tdoc_biblio.CiteHtmlToolTip from  tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid  where   tdoc_biblio_rel.DocIdParent=" + scnDocId.Text;
            if (iOrder == 0)
            { szSql += " order by CiteAutorYearABC"; }
            else
            { szSql += " order by DocId Desc"; };

            MySqlConnection oSqlCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);

            MySqlCommand oSqlCmd = new MySqlCommand(szSql, cls.bbdd.ClsMysql.MySqlConnection);
            MySqlDataAdapter oSqlDA = new MySqlDataAdapter(oSqlCmd);
            DataTable oDt = new DataTable();
            oSqlCnn.Open();
            oSqlDA.Fill(oDt);
            string szHtml = "";
            foreach (DataRow oRow in oDt.Rows)
            {
                szHtml += oRow["CiteHtmlToolTip"].ToString().Replace("<b>", "").Replace("</b>", "") + "<br/>";
            }
            scnBiblio.Text = szHtml;

            oSqlDA.Dispose();
            oSqlCmd.Dispose();
            cls.bbdd.ClsMysql.FncClose();
            //oSqlCnn.Dispose();
        }
        protected void scnBtnFilBiblio_Click(object sender, EventArgs e)
        {
            FncBtnFilBiblio(0);
        }

        protected void scnBtnvBibLIFO_Click(object sender, EventArgs e)
        {
            FncBtnFilBiblio(1);
        }
        public void FncSetDocumentIds(UInt64 pDocId, String pDocLngId)
        {
            scnDocId.Text = pDocId.ToString();
            scnDocLngId.Text = pDocLngId;
            FncBtnFilBiblio(1);
            // cls.ClsHtml.FncHtmlBibliographyBld(pDocId);
        }

    }
}