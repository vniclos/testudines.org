using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.others.acknowledgements
{
    public partial class acknowledgement_mng_edit : System.Web.UI.Page
    {
        private string m_DocTypeId = "acknowledgement";
        private cls.bbdd.ClsReg_tdoc_acknowledgment m_oReg = new cls.bbdd.ClsReg_tdoc_acknowledgment();
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

                fncGetParamenters();
                fncFillBreadCrumb();
                fncFillHead();
                fncFillMainContent();
                fncFillMailContentRight();

            }
        }
        private void fncGetParamenters() {

            UInt64 DocId = 41448;
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
        private void fncFillBreadCrumb() { }
        private void fncFillHead() { }
        private void fncFillMainContent() { fncScreenFromReg(); }
        private void fncFillMailContentRight() { }


        private void fncScreenFromReg()
        {

            bool bExist = m_oReg.fncSqlFind(m_DocId);

            if (!bExist)
            {

                m_oReg.fncClear();

            }

            scn_Doc_edit.fncFillDocId(m_DocId, m_DocTypeId);
            scnAbstract.Text = m_oReg.Abstract;
        
            scnBody.Text = m_oReg.Body;
            scnCiteName.Text = m_oReg.CiteName;
            scnCiteFull.Text = m_oReg.CiteFull;
            scnDocId.Text = m_oReg.DocId.ToString(); ;
            scnEmail.Text = m_oReg.Email;
            cls.ClsUtils.fncFillCheckBox(ref scnIsAuthorizeAll2, m_oReg.IsColaborator);
            cls.ClsUtils.fncFillCheckBox(ref scnIsColaborator2, m_oReg.IsColaborator);
            //scnAuthorizeAll.Text = m_oReg.IsAuthorizeAll;
            //scnIsColaborator.Text = m_oReg.IsColaborator;
            //scnTitle.Text = m_oReg.Title;
          
            scnUrlExternal.Text = m_oReg.UrlExternal;
        }
       
        private bool fncScreenValidate()
        {
            String m_msg = "";
            scnMsbBox.Text = "";
            bool bOk = true;
            scnAbstract.Text = scnAbstract.Text.Trim();
            scnBody.Text = scnBody.Text.Trim();
            scnCiteFull.Text = scnCiteFull.Text.Trim();
            scnCiteName.Text = scnCiteName.Text.Trim();
            scnEmail.Text = scnEmail.Text.Trim();
            scnUrlExternal.Text = scnUrlExternal.Text.Trim();

            if (scnCiteName.Text.Length<10)
            {
                bOk = false;
                m_msg += "<br> name is too sort, min 10";
            }
            if (scnCiteFull.Text.Length  <30)
            {
                bOk = false;
                m_msg += "<br>Cite Full is too sort, min 30>";
            }
            if (scnEmail.Text != "" && !cls.ClsUtils.IsMail(scnEmail.Text.ToString()))
            {
                bOk = false;
                m_msg += "<br>Email not valid";
            }
            if (scnUrlExternal.Text != "" && !cls.ClsUtils.IsUrl(scnUrlExternal.Text.ToString()))
            {
                bOk = false;
                m_msg += "<br>Url not valid";
            }

            
            scnMsbBox.Text = cls.ClsHtml.fncMsgAlert(m_msg, cls.ClsGlobal.eMsgType.alert.ToString());
            return bOk;
        }

        private void fncScreenToReg()
        {
            m_oReg.Title = scnCiteName.Text;
            m_oReg.Abstract = scnAbstract.Text.Trim();
            m_oReg.Body = scnBody.Text;
            m_oReg.CiteName = scnCiteName.Text;
            m_oReg.CiteFull = scnCiteFull.Text;
            m_oReg.DocId = Convert.ToUInt64(scnDocId.Text.Trim());
            m_oReg.Email = scnEmail.Text.Trim();
            m_oReg.IsColaborator = scnIsAuthorizeAll2.Checked;
            m_oReg.IsAuthorizeAll = scnIsAuthorizeAll2.Checked;
            m_oReg.UrlExternal = scnUrlExternal.Text;
            if(scnDocId.Text=="0")
            { m_oReg.PubDateAutorization = System.DateTime.Now; }
    
    }

      

        protected void scnBtnSave_Click(object sender, EventArgs e)
        {
            bool bOk = fncScreenValidate();
            if (!fncScreenValidate()) { return; }
            fncScreenToReg();
            //____________________
            // salva el registro doc relecionado
            // y obtiene el docid que los relaciona.
            // si es 0 obtiene uno nuevo.
            m_DocId = Convert.ToUInt64(scnDocId.Text.ToString());
            if (scn_Doc_edit.fncSave(m_DocId, m_DocTypeId))
            {
                m_oReg.DocId = scn_Doc_edit.oReg_tdoc.DocId;
                scnDocId.Text = m_oReg.DocId.ToString();
            }
            else {
                scnMsbBox.Text = cls.ClsHtml.fncMsgAlert("Not saved, table tdoc" + m_oReg.ErrorString, cls.ClsGlobal.eMsgType.alert.ToString());
                return;
                    }
            //----------------------

            if (m_oReg.fncSqlSave())
            {
                scnMsbBox.Text = cls.ClsHtml.fncMsgAlert("saved", cls.ClsGlobal.eMsgType.success.ToString());
            }
            else
            { scnMsbBox.Text = cls.ClsHtml.fncMsgAlert("Not saved"+ m_oReg.ErrorString, cls.ClsGlobal.eMsgType.alert.ToString()); }
        }

        protected void scnBtnNew_Click(object sender, EventArgs e)
        {
            m_oReg.fncClear();
            fncScreenFromReg();
            scnMsbBox.Text = "";
        }

        protected void scnBtnListMng_Click(object sender, EventArgs e)
        {
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/others/acknowledgements/acknowledgements-mng-list";
            Response.Redirect(szUrl);
        }

        protected void scnBtnList_Click(object sender, EventArgs e)
        {
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/others/acknowledgements/acknowledgement-list";
            Response.Redirect(szUrl);
        }
        protected void scnBtnShow_Click(object sender, EventArgs e)
        {
            string szUrl = "/" + cls.ClsGlobal.LngIdThread + "/others/acknowledgements/acknowledgement/" + scnDocId.Text;
            Response.Redirect(szUrl);
        }

        protected void scnBtnDelete_Click(object sender, EventArgs e)
        {
            m_oReg.fncSqlDelete(Convert.ToUInt64( scnDocId.Text.ToString()));
            fncScreenToReg();
        }
    } }