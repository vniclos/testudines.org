using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.tortoises.keys
{
    public partial class key_mng_edit : cls.ClsPageBaseEdit
    {
        private cls.bbdd.ClsReg_tdoclng_testudineskeys oRegKey = new cls.bbdd.ClsReg_tdoclng_testudineskeys();
        private cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oRegKeyLngEN = new cls.bbdd.ClsReg_tdoclng_testudineskeys_lng();
        private cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oRegKeyLngLNG = new cls.bbdd.ClsReg_tdoclng_testudineskeys_lng();

        private cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        private cls.bbdd.ClsReg_tdoclng oRegDocLngEN = new testudines.cls.bbdd.ClsReg_tdoclng();
        private cls.bbdd.ClsReg_tdoclng oRegDocLngLNG = new testudines.cls.bbdd.ClsReg_tdoclng();
        private String m_ErrorValidate = "";
        private UInt64 m_DocId = 0;
        private string m_DocLngId_en = "en";
        private string m_DocLngId_es = "es";
        private cls.ClsSession oSession;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            FncGetParamenters();
            FncFillBreadCrumb();
            FncFillHead();
            FncFillMainContent();
            
        }

        private void FncGetParamenters()
        {

            UInt64 DocId = 16642;
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
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Articles", "/" + cls.ClsGlobal.LngIdThread + "/articles/articles-list/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Article Edit", "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Mpg_BreadCrumb(ref szBreadCrumb);
        }
        private void FncFillHead()
        {
            Page.Title = Resources.Strings.Edit + Resources.Strings.Article + oRegDocLngEN.DocLngMetaTitle;
        }
        private void FncFillMainContent()
        { FncScreenFromReg(); }

        private bool FncScreenValidate()
        {
            bool bOk = true;
            m_ErrorValidate = "";
            scnMsg.Text="";
            
            scnLNGNotes.Text = scnLNGNotes.Text.Trim();
            scnLNGDescription.Text = scnLNGDescription.Text.Trim();
            scnENNotes.Text = scnENNotes.Text.Trim();
            scnENDescription.Text = scnENDescription.Text.Trim();

            if (scnENDescription.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>English Description empty";
            }
            if (scnENNotes.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>English Notes empty";
            }

            if (scnLNGDescription.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Spanish Description empty";
            }
            if (scnLNGNotes.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Spanish Notes empty";
            }
            //if (cls.clsUtil.FncChecbox_Get_StringValues(ref scnArticleTypeSub  ) == "")
            //{
            //    bOk = false;
            //    m_ErrorValidate += "<br/>Please select a subtype value";
            //}
            //if (cls.clsUtil.FncRadioButton_Get_StringValues (ref scnArticleType) == "")
            //{
            //    bOk = false;
            //    m_ErrorValidate += "<br/>Please select a type value";
            //}
            scnMsg.Text= m_ErrorValidate;

            return bOk;
        }
        private void FncScreenFromReg()
        {

            scnDocId.Text = m_DocId.ToString();
            //MPageDocLngId = m_DocLngId;
            oRegKey.FncSqlFind(m_DocId);
            oRegKeyLngEN.FncSqlFind(m_DocId, m_DocLngId_en);
            oRegKeyLngLNG.FncSqlFind(m_DocId, m_DocLngId_es);
            oRegDocLngLNG.FncSqlFind(m_DocId, m_DocLngId_es);
            oRegDocLngEN.FncSqlFind(m_DocId, m_DocLngId_en);

            // 1 tdoc
            // scnDocId.Text = oRegKeyLngEN.DocId.ToString();


            ctl_doc_edit1.FncFillDocId(oRegKeyLngEN.DocId, "taxon_keys");
            // cls.clsUtil.FncDropDownLngTranlatables(ref scnDocLngId, oRegKeyLng.DocLngId);
            ctl_docLng_edit1.FncFilldoclngidId(oRegKeyLngEN.DocId, "en");
       
      
            // 3 doctype document

            cls.ClsUtils.FncDropDownDocIdTaxaRelationValue(ref scnDocIdTaxaRelationValue, oRegKey.DocIdTaxaRelationValue, "");


            scnENTitle.Text = oRegKeyLngEN.Title;
            scnLNGTitle.Text = oRegKeyLngLNG.Title;

            scnENNotes.Text = oRegKeyLngEN.Notes;
            scnENDescription.Text = oRegKeyLngEN.Description;

            scnLNGNotes.Text = oRegKeyLngLNG.Notes;
            scnLNGDescription.Text = oRegKeyLngLNG.Description;

            //------------------------------------------------
            scnIdIsRevised.Checked = oRegKey.IsRevised;
            // scnDocId.Text = oRegKey.DocId.ToString();
            scnTOWNodeId.Text = oRegKey.TOWNodeId;
            scnTOWNodeParentId.Text = oRegKey.TOWNodeParentId;
            scnTOWNodekeyNum.Text = oRegKey.TOWNodekeyNum.ToString();
            scnTOWDescription.Text = oRegKey.TOWDescription;
            scnTOWTaxaGroupLevel.Text = oRegKey.TOWTaxaGroupLevel;
            scnTOWTaxaGroupName.Text = oRegKey.TOWTaxaGroupName;
            scnTOWTaxaURL.Text = oRegKey.TOWTaxaURL;
            scnImgHlpPath01.ImageUrl = oRegKey.ImgHlpPath01;
            scnImgHlpPath02.ImageUrl = oRegKey.ImgHlpPath02;
            scnImgHlpPath03.ImageUrl = oRegKey.ImgHlpPath03;
            scnTaxonDocId.Text = oRegKey.TaxonDocId.ToString();
            scnNodeFullPathListHtml.Text = oRegKey.NodeFullPathListHtml;
            scnNodeFullPathList.Text = oRegKey.NodeFullPathList;
            scnTOWATaxIdGroup.Text = oRegKey.TOWATaxIdGroup;
            scnTOWATaxGrpL2280Specie.Text = oRegKey.TOWATaxGrpL2280Specie;
            scnTOWATaxGrpL2280SpecieSub.Text = oRegKey.TOWATaxGrpL2280SpecieSub;
            // path para imagenes descriptivas de la clave
            oSession = (cls.ClsSession)Session["oSession"];
            string szUrl = cls.ClsGlobal.UrlMMedia + @"tortoise/taxons_keys/"  + oRegKey.TOWNodeId;
            string szDir = cls.ClsGlobal.DirMMedia + @"tortoise\taxons_keys\\"  + oRegKey.TOWNodeId;
            if (System.IO.Directory.Exists(szDir)) System.IO.Directory.CreateDirectory(szDir);
            oSession.AUrlImagesFilter = szUrl;
            Session["oSession"] = oSession;
            FncFillBtnDescends();
            //((mpg_main)Page.Master).MPageDocId = 1111;
        }
        private bool FncScreenToRegKey()
        {

            if (!FncScreenValidate()) return false; ;
  
            bool bSave = true;
            string szError = "";
            m_DocId = Convert.ToUInt64(scnDocId.Text.ToString());
            //scnMsgUpload.Text = "";
            oRegKey.DocId = m_DocId;
            oRegKey.TOWNodeId = scnTOWNodeId.Text.ToString();
            oRegKey.TOWNodeParentId = scnTOWNodeParentId.Text.ToString();
            oRegKey.TOWNodekeyNum = Convert.ToInt32(scnTOWNodekeyNum.Text.ToString());
            oRegKey.TOWDescription = scnTOWDescription.Text.ToString();
            oRegKey.TOWTaxaGroupLevel = scnTOWTaxaGroupLevel.Text.ToString();
            oRegKey.TOWTaxaGroupName = scnTOWTaxaGroupName.Text.ToString();
            oRegKey.TOWTaxaURL = scnTOWTaxaURL.Text.ToString();
            oRegKey.ImgHlpPath01 = scnImgHlpPath01.ImageUrl;
            oRegKey.ImgHlpPath02 = scnImgHlpPath02.ImageUrl;
            oRegKey.ImgHlpPath03 = scnImgHlpPath03.ImageUrl;
            oRegKey.TaxonDocId = Convert.ToUInt64(scnTaxonDocId.Text.ToString());

            cls.ClsUtils.FncDropDownDocIdTaxaRelationValue(ref scnDocIdTaxaRelationValue, m_DocId, "en");


            oRegKey.TOWATaxIdGroup = scnTOWATaxIdGroup.Text;
            oRegKey.TOWATaxGrpL2280Specie = scnTOWATaxGrpL2280Specie.Text;
            oRegKey.TOWATaxGrpL2280SpecieSub = scnTOWATaxGrpL2280SpecieSub.Text;

            oRegKey.DocIdTaxaRelationValue = Convert.ToUInt64(scnDocIdTaxaRelationValue.SelectedValue);
            oRegKey.DocIdTaxaRelationText = scnDocIdTaxaRelationValue.SelectedItem.Text;
            //oRegKey.NodeFullPathListHtml = scnNodeFullPathListHtml.Text;
            //oRegKey.NodeFullPathList = scnNodeFullPathList.Text;

            oRegKey.IsRevised = scnIdIsRevised.Checked;
            bSave = oRegKey.FncSqlSave();

            //string szPathTxt="";
            //string szPathUrlHtml="";


            if (!bSave)
            {
                //  scnMPageMsg.ForeColor = System.Drawing.Color.Red; ;
                szError = "<br/>Root document dont saved<br/>" + oRegKeyLngEN.ErrorString; ;
                bSave = false;
            }







            oRegKeyLngEN.DocId = m_DocId;
            oRegKeyLngEN.DocLngId = m_DocLngId_en;
            oRegKeyLngEN.Title = scnENTitle.Text;
            oRegKeyLngEN.Notes = scnENNotes.Text;
            oRegKeyLngEN.Description = scnENDescription.Text;


            oRegKeyLngLNG.DocId = m_DocId;
            oRegKeyLngLNG.DocLngId = m_DocLngId_es;
            oRegKeyLngLNG.Title = scnLNGTitle.Text;
            oRegKeyLngLNG.Notes = scnLNGNotes.Text;
            oRegKeyLngLNG.Description = scnLNGDescription.Text;


            oRegDocLngLNG.DocId = m_DocId;
            oRegDocLngLNG.DocLngId = m_DocLngId_es;
            oRegDocLngLNG.FncSqlSave();


            oRegDocLngEN.DocId = m_DocId;
            oRegDocLngEN.DocLngId = m_DocLngId_es;
            oRegDocLngEN.FncSqlSave();



            // oRegKeyLng.DatePublication= Convert.ToDateTime (ScnDatePublication.Text) ;   


            bSave = oRegKeyLngEN.FncSqlSave();
            if (!bSave)
            {
                //  scnMPageMsg.ForeColor = System.Drawing.Color.Red; ;
                szError = "<br/>English description Don't saved<br/>" + oRegKeyLngEN.ErrorString; ;
                bSave = false;
            }
            bSave = oRegKeyLngLNG.FncSqlSave();
            if (!bSave)
            {
                //  scnMPageMsg.ForeColor = System.Drawing.Color.Red; ;
              
                  
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert("<br />Spanish description Don't saved<br/>" ) ;
                bSave = false;
            }

            if (!bSave)
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert(szError);
            }
            else
            {

                scnMsg.Text = cls.ClsHtml.FncMsg_Success("Ok! Saved");
            }
            return bSave;
        }
        /// <summary>
        /// VALIDATION OF SCREEN FIELDS
        /// </summary>
        /// <returns>
        /// IF ERROR RETUR FALSE ELSE RETURN TRUE
        /// </returns>


        protected void scnBtnAddNew_Click(object sender, EventArgs e)
        {
            tbContainer.ActiveTabIndex = 0;
            
            oRegKeyLngEN.FncClear();
            oRegKeyLngLNG.FncClear();
            FncScreenFromReg();
            
        }
        protected void scnBtnSave_Click(object sender, EventArgs e)
        {
            // Logical errors
            if (!FncScreenValidate())
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert("Don't  saved" + "<br/>" + m_ErrorValidate);
               
                return;
            }

            // Sql save errors

            // Si DocId==0 1º save tdoc for get id number;
            // pasar valores de la clasificacion al documento principal

            ctl_doc_edit1.DocTypeGroup = "taxons";
            ctl_doc_edit1.DocTypeGroupSub = "keys";




            if (!ctl_doc_edit1.FncSave(Convert.ToUInt64(scnDocId.Text), "taxonkey"))
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert ( "Don't  saved" + "<br/>" + ctl_doc_edit1.ErrorString) ;
                return;
            }
            m_DocId = ctl_doc_edit1.DocId;
            //  scnDocId.Text = m_DocId.ToString();

            //Titulo por omision
            if (ctl_docLng_edit1.DocLngMetaTitle == "") ctl_docLng_edit1.DocLngMetaTitle = scnENTitle.Text;
            if (!ctl_docLng_edit1.FncSave(m_DocId, "en", "taxon/keys"))
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert("Don't  saved" + "<br/>" + ctl_docLng_edit1.ErrorString);
         
                return;
            }

            if (!FncScreenToRegKey())
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Alert("Don't  saved" + "<br/>" + oRegKeyLngEN.ErrorString);
               
                return;

            }
            else
            {
                scnMsg.Text = cls.ClsHtml.FncMsg_Success("saved");
                return;
            }

        }
        protected void scnBtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/tortoises/keys/keys-mng-list");
        }
        protected void scnBtnDelete_Click(object sender, EventArgs e)
        {
            UInt64 DocId = Convert.ToUInt64(scnDocId.Text);

            oRegKeyLngEN.FncSqlDelete(DocId, "en");
            oRegKeyLngLNG.FncSqlDelete(DocId, "es");
            oRegKeyLngEN.FncClear();
            oRegKeyLngLNG.FncClear();
            FncScreenFromReg();
        }
        protected void scnBtnGoList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/en/tortoises/keys/keys-list/");
        }
        protected void scnBtnShow_Click(object sender, EventArgs e)
        {
            string szUri = "/en/tortoises/keys/key/" + scnDocId.Text.ToString();
            // http://localhost:10559/es/notices/notice/13103
            Response.Redirect(szUri);
        }

        private void FncFillBtnDescends()
        {
            string szHtml = "";
            string szCmd = "select DocId,TOWNodeId from tdoclng_testudines_keys where TOWNodeParentId='" + scnTOWNodeId.Text + "' ";
            System.Data.DataTable oTb = new System.Data.DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szCmd, ref oTb);
            foreach (System.Data.DataRow oRow in oTb.Rows) {

                szHtml += "<a class=\"btn-tiny \" href=\"/es/tortoises/keys/key-mng-edit/" + oRow[0].ToString() + "\">Next " + oRow[1].ToString() + "</a>";
            }


            // previowus
            szCmd = "select DocId from tdoclng_testudines_keys where TOWNodeId='" + scnTOWNodeParentId.Text + "'";
            String result = cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd).ToString();
            if (result != "0")
            {
                szHtml += "<a class=\"btn-tiny \" href=\"/es/tortoises/keys/key-mng-edit/" + result + "\">Prev " + scnTOWNodeParentId.Text + "</a>";
            } 
                scnBtnDescend.Text = szHtml;

        }
      
      
        protected void scnBtnGoto_Click(object sender, EventArgs e)
        {

        }

        protected void scnBtnClose_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/en/tortoises/keys/key-mng-list/" );
        }

        protected void scnBtnGoto_Click1(object sender, EventArgs e)
        {
            Response.Redirect("/en/tortoises/keys/key/" + scnDocId);
        }
    }
}