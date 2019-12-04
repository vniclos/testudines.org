using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.notices
{
    public partial class notice_mng_edit : cls.ClsPageBaseEdit
    {
        private string m_tableName = "tdoclng_notices";
        private String  m_MaskUrl = "notices/artice"; // para crear url friendly, despues agregra idioma y titulo y barras automaticamente
        private string m_DocTypeId = "notice";
        private cls.bbdd.ClsReg_tdoclng_notices m_oReg_EN = new cls.bbdd.ClsReg_tdoclng_notices();
        private cls.bbdd.ClsReg_tdoclng_notices m_oReg_ES= new cls.bbdd.ClsReg_tdoclng_notices();
       // private cls.bbdd.ClsReg_tdoclng m_oRegLng_ES = new cls.bbdd.ClsReg_tdoclng();
       // private cls.bbdd.ClsReg_tdoclng m_oRegLng_EN = new cls.bbdd.ClsReg_tdoclng();
        

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
                FncFillMainContent();
                FncFillMailContentRight();

            }
        }
        private void FncGetParamenters()
        {

            UInt64 DocId = 9659;
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
        private void FncFillBreadCrumb() {
            String szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb,"Notices","/"+cls.ClsGlobal.LngIdThread+"/notices/notices-list/" );
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Notice Edit", "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Mpg_BreadCrumb(ref szBreadCrumb);
        }
        private void FncFillHead()
        {
            Page.Title = Resources.Strings.Edit + Resources.Strings.Notice + m_oReg_ES.Title;
        }
        private void FncFillMainContent() { FncScreenFromReg(); }
        private void FncFillMailContentRight() { }



        private void FncScreenFromReg() {
            Mpg_SetDocumentId(m_DocId, "xx");


            scnDocId.Text = m_DocId.ToString();
            
           // m_oRegLng_EN.FncSqlFind( m_DocId, "en");
           // m_oRegLng_ES.FncSqlFind(m_DocId, "esn");
                 m_oReg_EN.FncSqlFind(m_DocId, "en");
            m_oReg_ES.FncSqlFind(m_DocId, "es");
            scn_oDdoc_edit.FncFillDocId(m_DocId, m_DocTypeId);
            scn_oDocLng_edit_EN.FncFilldoclngidId(m_DocId, "en");
            scn_oDocLng_edit_ES.FncFilldoclngidId(m_DocId, "es");

            cls.ClsUtils.FncDropDownList_NoticeTypeFill(ref scnFilterNoticeType, scn_oDdoc_edit.DocTypeGroup);
            cls.ClsUtils.FncDropDownList_NoticeTypeSubFill(ref scnFilterNoticeTypeSub, scn_oDdoc_edit.DocTypeGroupSub);


            scnAbstract_EN.Text = m_oReg_EN.Abstract;
            scnBody_EN.Text = m_oReg_EN.Body;
            scnTitle_EN.Text = m_oReg_EN.Title;

            scnAbstract_ES.Text = m_oReg_ES.Abstract;
            scnBody_ES.Text = m_oReg_ES.Body;
            scnTitle_ES.Text = m_oReg_ES.Title;

            scnBibliography_XX.Text = scn_oDdoc_edit.Bibliography;
            scnAcknoelegment_XX.Text = scn_oDdoc_edit.Acknowledgements;


        }

        private bool FncScreenValidateEN()
        {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;
            String szError = "";
            scnMsbBoxEN.Text = "";
            scnAbstract_EN.Text = scnAbstract_EN.Text.Trim();
             scnBody_EN.Text = scnBody_EN.Text.Trim();
            scnTitle_EN.Text = scnTitle_EN.Text.Trim();
            scnAutors_XX.Text = scnAutors_XX.Text.Trim();
            scnAcknoelegment_XX.Text = scnAcknoelegment_XX.Text.Trim();
            scnBibliography_XX.Text = scnBibliography_XX.Text.Trim();

            if (scnTitle_EN.Text.Length < 10)
            { szError += "<br>Titulo demasiado corto";
                bOk = false;
            }
            if (scnAbstract_EN.Text.Length <80)
            {
                szError += "<br>Abstract demasiado corto (80)";
                bOk = false;
            }
            if (scnAbstract_EN.Text.Length < 100)
            {
                szError += "<br>Abstract demasiado corto (300)";
                bOk = false;
            }
            if (scnBody_EN.Text.Length < 300)
            {
                szError += "<br>Abstract demasiado corto (300)";
                bOk = false;
            }
            if (scnAutors_XX.Text == "") { scnAutors_XX.Text = "V. Niclos (Testudines.org)"; }
            scnMsbBoxEN.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
            return bOk;
            }
        
        private bool FncScreenValidateES() {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;
            String szError = "";
            scnMsbBoxES.Text = "";
            scnAbstract_ES.Text = scnAbstract_ES.Text.Trim();
          
            scnBody_ES.Text = scnBody_ES.Text.Trim();
            scnTitle_ES.Text = scnTitle_ES.Text.Trim();
            scnAutors_XX.Text = scnAutors_XX.Text.Trim();
            scnAcknoelegment_XX.Text = scnAcknoelegment_XX.Text.Trim();
            scnBibliography_XX.Text = scnBibliography_XX.Text.Trim();
            //pasar datos a tdoc
            scn_oDdoc_edit.Bibliography = scnBibliography_XX.Text;
            scn_oDdoc_edit.Acknowledgements = scnAcknoelegment_XX.Text;
            if (scnTitle_ES.Text.Length < 10)
            { szError += "<br>Titulo demasiado corto";
                bOk = false;
            }
            if (scnAbstract_ES.Text.Length <80)
            {
                szError += "<br>Abstract demasiado corto (80)";
                bOk = false;
            }
            if (scnAbstract_ES.Text.Length <100)
            {
                szError += "<br>Abstract demasiado corto (300)";
                bOk = false;
            }
            if (scnBody_ES.Text.Length < 300)
            {
                szError += "<br>Abstract demasiado corto (300)";
                bOk = false;
            }
            if (scnAutors_XX.Text == "") { scnAutors_XX.Text = "V. Niclos (Testudines.org)"; }
            scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
            return bOk;
        }

        private void FncScreenToRegXX()
        {


            scn_oDdoc_edit.DocTypeGroup = scnFilterNoticeType.SelectedValue;
            scn_oDdoc_edit.DocTypeGroupSub = scnFilterNoticeTypeSub.SelectedValue;
          
        }
        private void FncScreenToRegES() {
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.DocId = m_DocId;
            m_oReg_ES.DocLngId = "es";
            m_oReg_ES.Title = scnTitle_ES.Text;
            m_oReg_ES.Abstract = scnAbstract_ES.Text;
            m_oReg_ES.Body = scnBody_ES.Text;

            scn_oDocLng_edit_ES.DocLngMetaTitle = scnTitle_ES.Text;
            scn_oDocLng_edit_ES.DocLngMetaKeyWords = scnFilterNoticeType.SelectedValue + ", " + scnFilterNoticeTypeSub.SelectedValue;
            scn_oDocLng_edit_ES.DocLngMetaDescription =  m_oReg_ES.Title;

            FncScreenToRegXX();

        }
        private void FncScreenToRegEN()
        {
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_EN.DocId = m_DocId;
            m_oReg_EN.DocLngId = "en";
            m_oReg_EN.Title = scnTitle_EN.Text;
            m_oReg_EN.Abstract = scnAbstract_EN.Text;
            m_oReg_EN.Body = scnBody_EN.Text;

            scn_oDocLng_edit_EN.DocLngMetaTitle = scnTitle_EN.Text;
            scn_oDocLng_edit_EN.DocLngMetaKeyWords = scnFilterNoticeType.SelectedValue + ", " + scnFilterNoticeTypeSub.SelectedValue;
            scn_oDocLng_edit_EN.DocLngMetaDescription =  m_oReg_EN.Title;

            FncScreenToRegXX();

        }
        protected void scnBtnSaveES_Click(object sender, EventArgs e)
        {
            if (!FncScreenValidateES()) { return; }

            FncScreenToRegES();
            FncScreenToRegXX();
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            if (scn_oDdoc_edit.FncSave(m_DocId, m_DocTypeId))
            {
                m_DocId = scn_oDdoc_edit.DocId; // si es nuevo obtiene un nuevo id
                if (m_DocId != 0)
                {
                    scn_oDocLng_edit_ES.FncSave(m_DocId, "en",m_MaskUrl);
                    FncScreenToRegEN();
                    if (m_oReg_ES.FncSqlSave())
                    {

                        scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("save", cls.ClsGlobal.E_MsgType.success.ToString());
                    }
                    else
                    { scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("Not Saved", cls.ClsGlobal.E_MsgType.alert.ToString()); }
                }
            }
        }


        protected void scnBtnSave_EN_Click(object sender, EventArgs e)
        {
            if (!FncScreenValidateEN()) { return; }
            FncScreenToRegEN();
            FncScreenToRegXX();
            string szMaskUrl = "";
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            if (scn_oDdoc_edit.FncSave(m_DocId, m_DocTypeId))
            {
                m_DocId = scn_oDdoc_edit.DocId; // si es nuevo obtiene un nuevo id
                if (m_DocId != 0)
                {
                    scn_oDocLng_edit_EN.FncSave(m_DocId, "en", szMaskUrl);
                    FncScreenToRegEN();
                    if (m_oReg_EN.FncSqlSave())
                    { 
                
                    scnMsbBoxEN.Text = cls.ClsHtml.FncMsgAlert("save", cls.ClsGlobal.E_MsgType.success.ToString());
                }
                else
                { scnMsbBoxEN.Text = cls.ClsHtml.FncMsgAlert("Not Saved", cls.ClsGlobal.E_MsgType.alert.ToString()); }
                }
            }
        }
        protected void scnBtnRbCacheES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.FncSqlFind(uiDocId, "es");
            m_oReg_ES.FncGetCache_Html(true);
        }
        protected void scnBtnRbCacheEn_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_EN.FncSqlFind(uiDocId, "en");
            m_oReg_EN.FncGetCache_Html(true);
        }
        
      
        protected void scnBtnNew_Click(object sender, EventArgs e)
        {
            m_DocId = 0;
            Mpg_SetDocumentId(m_DocId, "xx");
            m_oReg_ES.FncClear();
            m_oReg_EN.FncClear();
    
            scn_oDocLng_edit_EN.FncClear();
            scn_oDocLng_edit_ES.FncClear();
            // m_oRegLng_ES.FncClear();
            // m_oRegLng_EN.FncClear();
            FncScreenFromReg();
            scnMsbBoxEN.Text = "";
            scnMsbBoxES.Text = "";
        }

        protected void scnBtnListMng_Click(object sender, EventArgs e)
        {

            Response.Redirect("/ES/notices/notices-mng-list");
        }

        protected void scnBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/notices/notices-list");
        }

        protected void scnBtnShowES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            if (cls.bbdd.ClsMysql.IsExist(m_tableName, uiDocId, "es"))
            {
                Response.Redirect("/es/notices/notice/" + uiDocId.ToString());
            }
            else
            {

                scnMsbBoxES.Text=  cls.ClsHtml.FncMsgAlert("Documento no guardado en español", cls.ClsGlobal.E_MsgType.warning.ToString());
            }

        }
        protected void scnBtnShowEN_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            if (cls.bbdd.ClsMysql.IsExist(m_tableName, uiDocId, "en"))
            {
                Response.Redirect("/en/notices/notice/" + uiDocId.ToString());
            }
            else
            {

                scnMsbBoxES.Text = cls.ClsHtml.FncMsgAlert("This document not saved in english", cls.ClsGlobal.E_MsgType.warning.ToString());
            }

        }

        protected void scnBtnBiblio_rebuild_Click(object sender, EventArgs e)
        {
            scnBibliography_XX.Text = cls.ClsHtml.FncHtmlBibliographyBld(Convert.ToUInt64(scnDocId.Text));
          
        }
    }
}