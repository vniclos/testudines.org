using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
namespace testudines.acknowledgements
{
    public partial class acknowledgement_mng_edit : cls.ClsPageBaseEdit
    {
        private string m_tableName = "tdoc_acknowledgment";
        private String m_MaskUrl = "acknowledgments/tdoc_acknowledgment"; // para crear url friendly, despues agregra idioma y titulo y barras automaticamente
        private string m_DocTypeId = "acknowledgment";
     
        private cls.bbdd.ClsReg_tdoc_acknowledgment m_oReg_ES = new cls.bbdd.ClsReg_tdoc_acknowledgment();
        

        UInt64 m_DocId = 0;
        String m_msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!cls.ClsUtils.User_isAdmin())
            {
                string szUrOops = cls.ClsUtils.Oops_Redirect(Request.Url.ToString(), "Not autorized to this page");
                Response.Redirect(szUrOops);

            }
            if (!IsPostBack)
            {

                FncGetParamenters();

                FncFillBreadCrumb();
                FncFillHead();
                FncFillMainContentLeft();
                FncFillMailContentRight();
           
            }
        }
       
 

        private void FncGetParamenters()
        {

            UInt64 DocId = 458;
            String DocLngId = "es";

            try
            {
                DocId = Convert.ToUInt64(Page.RouteData.Values["docid"].ToString());
                DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
            }
            catch {; }
            if (Request.QueryString["docid"] != null)
            {
                DocId = Convert.ToUInt64(Request.QueryString["docid"].ToString());
            }
            if (Request.QueryString["doclngid"] != null)
            {
                DocLngId = Request.QueryString["doclngid"].ToString();
            }
            m_DocId = DocId;
            // m_DocLngId = DocLngId;



        }
        private void FncFillBreadCrumb()
        {
            String szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "acknowledgements", "/" + cls.ClsGlobal.LngIdThread + "/acknowledgements/acknowledgements-list/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "acknowledgement Edit", "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Mpg_BreadCrumb(ref szBreadCrumb);
        }
        private void FncFillHead()
        {
            Page.Title = Resources.Strings.Edit + Resources.Strings.Acknowledgements + m_oReg_ES.Title;
        }
        private void FncFillMainContentLeft() { FncScreenFromReg(); }
        private void FncFillMailContentRight()
        {


        }



        private void FncScreenFromReg()
        {
            Mpg_SetDocumentId(m_DocId, "xx");


            scnDocId.Text = m_DocId.ToString();




          
            m_oReg_ES.FncSqlFind(m_DocId);
            scn_oDdoc_edit.FncFillDocId(m_DocId, m_DocTypeId);

            scnCiteName.Text = m_oReg_ES.CiteName;
            scnCiteFull.Text = m_oReg_ES.CiteFull;




          
            scnBody_ES.Text=m_oReg_ES.Body ;
            scnEmail.Text = m_oReg_ES.Email;
             scnIsAuthorizeAll.Checked= m_oReg_ES.IsAuthorizeAll ;
            scnIsColaborator.Checked = m_oReg_ES.IsColaborator;
          
            scnPubDateAutorization.Text = cls.ClsUtils.FncDateTo_DD_MM_YYY( m_oReg_ES.PubDateAutorization.Date);
            scnUrlExternal.Text = m_oReg_ES.UrlExternal;
            
          


        }

   

        private bool FncScreenValidateES()
        {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;
            String szError = "";
            scnMsbBoxES.Text = "";

            scnCiteFull.Text = scnCiteFull.Text.Trim();
            scnBody_ES.Text = scnBody_ES.Text.Trim();
            scnCiteName.Text = scnCiteName.Text.Trim();
           
            //pasar datos a tdoc
           
            if (scnCiteName.Text.Length < 8)
            {
                szError += "<br>Cite Name-Titulo demasiado corto minimo 8";
                bOk = false;
            }
            if (scnCiteFull.Text.Length < 20)
            {
                szError += "<br>Cite full  demasiado corto (20)";
                bOk = false;
            }
           
           
            if (!bOk)
            {
                scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
            }
                return bOk;
        }

     
        private void FncScreenToRegES()
        {
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.DocId = m_DocId;
            m_oReg_ES.Title = scnCiteName.Text;
            m_oReg_ES.CiteName = scnCiteName.Text;
            m_oReg_ES.CiteFull = scnCiteFull.Text;
            
            m_oReg_ES.Abstract = scnCiteFull.Text;
            m_oReg_ES.Body = scnBody_ES.Text;
            m_oReg_ES.Email = scnEmail.Text;
            m_oReg_ES.IsAuthorizeAll = scnIsAuthorizeAll.Checked;
            m_oReg_ES.IsColaborator = scnIsColaborator.Checked;
            m_oReg_ES.PubDateAutorization = Convert.ToDateTime( scnPubDateAutorization.Text);
            m_oReg_ES.UrlExternal = scnUrlExternal.Text;

        }
   
        protected void scnBtnSaveES_Click(object sender, EventArgs e)
        {
            if (!FncScreenValidateES()) { return; }

            FncScreenToRegES();
          
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            if (scn_oDdoc_edit.FncSave(m_DocId, m_DocTypeId))
            {
                m_DocId = scn_oDdoc_edit.DocId; // si es nuevo obtiene un nuevo id
                if (m_DocId != 0)
                {
                    m_oReg_ES.DocId = m_DocId;


                    if (m_oReg_ES.FncSqlSave())
                    {

                        scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("save", cls.ClsGlobal.E_MsgType.success.ToString());
                    }
                    else
                    { scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("Not Saved", cls.ClsGlobal.E_MsgType.alert.ToString()); }
                    FncScreenToRegES();
                }
            }
        }



        protected void scnBtnRbCacheES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.FncSqlFind(uiDocId );
            m_oReg_ES.FncGetCache_Html(true);
        }
     


        protected void scnBtnNew_Click(object sender, EventArgs e)
        {
            m_DocId = 0;
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.FncClear();
       

         
            // m_oRegLng_ES.FncClear();
            // m_oRegLng_EN.FncClear();
            FncScreenFromReg();
          
            scnMsbBoxES.Text = "";
        }

        protected void scnBtnListMng_Click(object sender, EventArgs e)
        {

            Response.Redirect("/es/others/acknowledgements/acknowledgements-mng-list");
        }

        protected void scnBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/others/acknowledgements/acknowledgements-list");
        }

        protected void scnBtnShowES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            if (cls.bbdd.ClsMysql.IsExist(m_tableName, uiDocId, "es"))
            {
                Response.Redirect("/es/others/acknowledgements/acknowledgement/" + uiDocId.ToString());
            }
            else
            {

                scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("Documento no guardado en español", cls.ClsGlobal.E_MsgType.warning.ToString());
            }

        }
      

        

        protected void scnBtnDeleteES_Click(object sender, EventArgs e)
        {
            m_oReg_ES.FncSqlDelete(Convert.ToUInt64(scnDocId.Text));
            m_oReg_ES.FncClear();
            FncScreenToRegES();
        }

        protected void scnBtnListCols_Click(object sender, EventArgs e)
        {
            Response.Redirect("/others/acknowledgements/acknowledgements/");
        }
    }
}