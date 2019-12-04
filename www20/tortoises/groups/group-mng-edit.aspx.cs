using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.tortoises.groups
{
    public partial class groups_mng_edit : cls.ClsPageBaseEdit
    {
        private string m_tableName = "tdoclng_testudines_groups";
        private String m_MaskUrl = "tortoises/group/group"; // para crear url friendly, despues agregra idioma y titulo y barras automaticamente
        private string m_DocTypeId = "tortoises/group";
        private cls.bbdd.ClsReg_tdoclng_testudines_file_all oRegTaxonFiles = new cls.bbdd.ClsReg_tdoclng_testudines_file_all();
        private cls.bbdd.ClsReg_tdoclng_testudinesgroups oReg_groupsES = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
        private cls.bbdd.ClsReg_tdoclng_testudinesgroups oReg_groupsEN = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
        private cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        UInt64 m_DocId = 0;
        String m_msg = "";
        private string m_ErrorValidate = "";
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

            UInt64 DocId = 15274;
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
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Group", "/" + cls.ClsGlobal.LngIdThread + "/tortoises/groups/group-list/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Group Edit", "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Mpg_BreadCrumb(ref szBreadCrumb);
        }
        private void FncFillHead()
        {
            Page.Title = Resources.Strings.Edit + Resources.Strings.mnTortoises_group + oReg_groupsES.Title;
        }
        private void FncFillMainContent() { FncScreenFromReg(); }
        private void FncFillMailContentRight() { }
        // todos los idiomas
        private bool FncScreenValidate_XX()
        {
           
            bool bOk = true;
            scnATaxIdName_XX.Text = scnATaxIdName_XX.Text.Trim();
            scnATaxGrpL2282Authority_XX.Text = scnATaxGrpL2282Authority_XX.Text.Trim();
            scnATaxGrpL2283Year_XX.Text = scnATaxGrpL2283Year_XX.Text.Trim();
            scnAtaxIdNameParent_XX.Text = scnAtaxIdNameParent_XX.Text.Trim();

            if (scnATaxIdName_XX.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnATaxIdName empty";
            }

            if (scnATaxGrpL2282Authority_XX.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnATaxGrpL2282Authority empty";
            }
            if (scnATaxGrpL2283Year_XX.Text == "")
            {

                bOk = false;
                m_ErrorValidate += "<br/>scnATaxGrpL2283Year empty";
            }
            else
            {
                if (scnATaxGrpL2283Year_XX.Text.Length < 4)
                {
                    bOk = false;
                    m_ErrorValidate += "<br/>scnATaxGrpL2283Year need 4 digits";
                }
                else
                {
                    try
                    { Convert.ToInt32(scnATaxGrpL2283Year_XX.Text); }
                    catch (Exception)
                    {
                        bOk = false;
                        m_ErrorValidate += "<br/>scnATaxGrpL2283Year year in four digits";
                    }
                }
            }


            
            if (scnAtaxLevel_XX.SelectedValue == "*")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnATaxLevel not valid selecction";
            }

            if (scnAtaxIdNameParent_XX.Text == "*")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnAtaxIdNameParent not select";
                // TODO no permitir parientes que no existan
            }
            return bOk;
        }

        private bool FncScreenValidate_ES()
        {
            bool bOk = true;
            scnAbstract_ES.Text = scnAbstract_ES.Text.Trim();
            scnNameVulgar_ES.Text = scnNameVulgar_ES.Text.Trim();
            scnTitle_XX2.Text = scnATaxIdName_XX.Text + " " + scnATaxGrpL2282Authority_XX.Text + " " + scnATaxGrpL2283Year_XX.Text;
            scnBody_ES.Text = scnBody_ES.Text.Trim();
            scnDescriptionShort_ES.Text = scnDescriptionShort_ES.Text.Trim();
            if (scnNameVulgar_ES.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Name Vulgar ES empty";
            }

            if (scnDescriptionShort_ES.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnDescriptionShort empty";
            }
            if (scnTitle_XX2.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Title empty";
            }
            if (scnAbstract_ES.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Abstract empty";
            }

            if (scnBody_ES.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Group empty";
            }


            return bOk;
        }

        private bool FncScreenValidate_EN()
        {
            bool bOk = true;
            scnAbstract_EN.Text = scnAbstract_EN.Text.Trim();
            scnNameVulgar_EN.Text = scnNameVulgar_EN.Text.Trim();
            scnTitle_XX2.Text = scnATaxIdName_XX.Text + " " + scnATaxGrpL2282Authority_XX.Text + " " + scnATaxGrpL2283Year_XX.Text;
            scnBody_EN.Text = scnBody_EN.Text.Trim();
            scnDescriptionShort_EN.Text = scnDescriptionShort_EN.Text.Trim();
            if (scnNameVulgar_EN.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Name Vulgar ES empty";
            }
            if (scnDescriptionShort_EN.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>scnDescriptionShort empty";
            }
            if (scnTitle_XX2.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Title empty";
            }
            if (scnAbstract_EN.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Abstract empty";
            }

            if (scnBody_EN.Text == "")
            {
                bOk = false;
                m_ErrorValidate += "<br/>Group empty";
            }


            return bOk;
        }
        private void FncScreenFromReg()
        {

            // 1 tdoc
          
            scnDocId.Text = m_DocId.ToString();
            oRegDoc.FncSqlFind(m_DocId);
            scn_oDoc_edit.FncFillDocId(m_DocId, m_DocTypeId);
            scn_oDocLng_edit_EN.FncFilldoclngidId(m_DocId, "en");
            scn_oDocLng_edit_ES.FncFilldoclngidId(m_DocId, "es");
            
          // 3 doctype document
      

            // 4 Group document
            oReg_groupsEN.FncSqlFind(m_DocId, "en");
            oReg_groupsES.FncSqlFind(m_DocId, "es");

            scnTitle_XX2.Text = oReg_groupsES.Title;
            scnAbstract_ES.Text = oReg_groupsES.Abstract;
            scnATaxGrpL2282Authority_XX.Text = oReg_groupsES.ATaxGrpL2282Authority;
            scnATaxGrpL2283Year_XX.Text = oReg_groupsES.ATaxGrpL2283Year;
            scnATaxIdName_XX.Text = oReg_groupsES.ATaxIdName;
            scnAtaxIdNameParent_XX.Text = oReg_groupsES.AtaxIdNameParent;
            
          
            cls.ClsUtils.FncDropDownList_scnATaxLevel(ref scnAtaxLevel_XX, oReg_groupsES.ATaxLevel);
            scnIsOk_XX.Checked = oReg_groupsES.IsOk;
            scnIsTaxa2014_XX.Checked = oReg_groupsES.IsTaxa2014;
            scnRef_ITIS_Number_XX.Text = oReg_groupsES.Ref_ITIS_Number.ToString();



            scnBody_ES.Text = oReg_groupsES.Body;
            scnDescriptionShort_ES.Text = oReg_groupsES.DescriptionShort;
            scnNameVulgar_ES.Text = oReg_groupsES.NameVulgar;
            scnNotes_ES.Text = oReg_groupsES.Notes;

            scnBody_EN.Text = oReg_groupsEN.Body;
            scnDescriptionShort_EN.Text = oReg_groupsEN.DescriptionShort;
            scnNameVulgar_EN.Text = oReg_groupsEN.NameVulgar;
            scnNotes_EN.Text = oReg_groupsEN.Notes;

            scnBibliography_XX.Text = oRegDoc.DocBibliography;
            scnAcknoelegment_XX.Text = oRegDoc.DocAcknowledgements;


            
          

            //------- leer  imagenes
            UInt64 DocId = oReg_groupsES.DocId;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg01");
            scnImg01.ImageUrl = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg02");
            scnImg02.ImageUrl = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg03");
            scnImg03.ImageUrl = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg04");
            scnImg04.ImageUrl = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg05");
            scnImg05.ImageUrl = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(DocId, "TaxonGroupsImg06");
            scnImg06.ImageUrl = oRegTaxonFiles.AFileURL;


        }
        private void FncScreenToReg_groupsES()
        {
            m_DocId = Convert.ToUInt64(scnDocId.Text);


         
            UInt64 DocId = Convert.ToUInt64(scnDocId.Text);
            oReg_groupsES.DocId = m_DocId;
            oReg_groupsES.DocLngId = "es";
            oReg_groupsES.IsOk = scnIsOk_XX.Checked;
            oReg_groupsES.IsTaxa2014 = scnIsTaxa2014_XX.Checked;
            oReg_groupsES.Ref_ITIS_Number = Convert.ToInt32(scnRef_ITIS_Number_XX.Text.Trim());

            oReg_groupsES.ATaxIdName = scnATaxIdName_XX.Text;
            oReg_groupsES.AtaxIdNameParent = scnAtaxIdNameParent_XX.Text;
            oReg_groupsES.ATaxLevel = scnAtaxLevel_XX.SelectedValue;
            oReg_groupsES.ATaxGrpL2283Year = scnATaxGrpL2283Year_XX.Text;
            oReg_groupsES.ATaxGrpL2282Authority = scnATaxGrpL2282Authority_XX.Text;
            
            oReg_groupsES.Title = scnATaxIdName_XX.Text + " " + scnATaxGrpL2282Authority_XX.Text + " " + scnATaxGrpL2283Year_XX.Text;
            oReg_groupsES.Abstract = scnAbstract_ES.Text;
            oReg_groupsES.Body = scnBody_ES.Text;
            oReg_groupsES.NameVulgar = scnNameVulgar_ES.Text;
            oReg_groupsES.DescriptionShort = scnDescriptionShort_ES.Text;
            
        
            
           
            //cls.clsUtil.FncDropDownList_scnATaxLevel(ref scnATaxLevel, oReg_groupsES.ATaxLevel);

            oReg_groupsES.Notes = scnNotes_ES.Text.Trim();

            //------- guardar imagenes
            oRegTaxonFiles.DocId = DocId;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg01";
            oRegTaxonFiles.AFileURL = scnImg01.ImageUrl;
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg02.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg02";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg03.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg03";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg04.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg04";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();
            oRegTaxonFiles.AFileURL = scnImg05.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg05";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();
            oRegTaxonFiles.AFileURL = scnImg06.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg06";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();
           
        }
        private void FncScreenToReg_groupsEN()
        {
            m_DocId = Convert.ToUInt64(scnDocId.Text);
            m_ErrorValidate = "";

            //scnMsgUpload.Text = "";
            UInt64 DocId = Convert.ToUInt64(scnDocId.Text);
            oReg_groupsEN.DocId = m_DocId;
            oReg_groupsEN.DocLngId = "EN";
            oReg_groupsEN.IsOk = scnIsOk_XX.Checked;
            oReg_groupsEN.IsTaxa2014 = scnIsTaxa2014_XX.Checked;
            oReg_groupsEN.Ref_ITIS_Number = Convert.ToInt32(scnRef_ITIS_Number_XX.Text.Trim());

            oReg_groupsEN.ATaxIdName = scnATaxIdName_XX.Text;
            oReg_groupsEN.AtaxIdNameParent = scnAtaxIdNameParent_XX.Text;
            oReg_groupsEN.ATaxLevel = scnAtaxLevel_XX.SelectedValue;
            oReg_groupsEN.ATaxGrpL2283Year = scnATaxGrpL2283Year_XX.Text;
            oReg_groupsEN.ATaxGrpL2282Authority = scnATaxGrpL2282Authority_XX.Text;

            oReg_groupsEN.Title = scnATaxIdName_XX.Text + " " + scnATaxGrpL2282Authority_XX.Text + " " + scnATaxGrpL2283Year_XX.Text;
            oReg_groupsEN.Abstract = scnAbstract_EN.Text;
            oReg_groupsEN.Body = scnBody_EN.Text;
            oReg_groupsEN.NameVulgar = scnNameVulgar_EN.Text;
            oReg_groupsEN.DescriptionShort = scnDescriptionShort_EN.Text;




            //cls.clsUtil.FncDropDownList_scnATaxLevel(ref scnATaxLevel, oReg_groupsEN.ATaxLevel);

            oReg_groupsEN.Notes = scnNotes_EN.Text.Trim();

            //------- guardar imagenEN
            oRegTaxonFiles.DocId = DocId;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg01";
            oRegTaxonFiles.AFileURL = scnImg01.ImageUrl;
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg02.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg02";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg03.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg03";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();

            oRegTaxonFiles.AFileURL = scnImg04.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg04";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();
            oRegTaxonFiles.AFileURL = scnImg05.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg05";
            oRegTaxonFiles.AFileType = "image";
            oRegTaxonFiles.FncSqlSave();
            oRegTaxonFiles.AFileURL = scnImg06.ImageUrl;
            oRegTaxonFiles.FileSeccId = "TaxonGroupsImg06";
            oRegTaxonFiles.AFileType = "image";
           
        }
        private bool FncSaveES()
        {
            // Logical errors
            scnMsgBox.Text = "";
            m_ErrorValidate = "";
            if (!FncScreenValidate_XX() || !FncScreenValidate_ES())
            {
                string sz =
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert("Don't  saved" + "<br/>" + m_ErrorValidate, cls.ClsGlobal.E_MsgType.alert.ToString());
                return false;
            }

            // Sql save errors

            // Si DocId==0 1º save tdoc for get id number;
            // pasar valores de la clasificacion al documento principal
            scn_oDoc_edit.DocTypeGroup = "taxons_groups";
            scn_oDoc_edit.DocTypeGroupSub = "taxons_groups";



            if (!scn_oDoc_edit.FncSave(Convert.ToUInt64(scnDocId.Text), "taxons_groups"))
            {
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert("Don't  saved" + "<br/>" + scn_oDoc_edit.ErrorString, cls.ClsGlobal.E_MsgType.alert.ToString());
            
                return false;
            }
            scnDocId.Text = scn_oDoc_edit.DocId.ToString();

            //Titulo por omision
            if (scn_oDocLng_edit_ES.DocLngMetaTitle == "") scn_oDocLng_edit_ES.DocLngMetaTitle = scnTitle_XX2.Text;
            if (!scn_oDocLng_edit_ES.FncSave(Convert.ToUInt64(scnDocId.Text), "es", "taxons/taxons_groups/"))
            {
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert("Don't  saved" + "<br/>" + scn_oDocLng_edit_ES.ErrorString, cls.ClsGlobal.E_MsgType.alert.ToString());

                
                return false;
            }

            FncScreenToReg_groupsES();

            if (!oReg_groupsES.FncSqlSave())
            {
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert("Don't  saved" + "<br/>" + oReg_groupsES.ErrorString, cls.ClsGlobal.E_MsgType.alert.ToString());

              
                return false;

            }
            else
            {
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert("Saved ES" + "<br/>" , cls.ClsGlobal.E_MsgType.success.ToString());

               
                return true;
            }

        }

        private bool FncSaveEN()
        {
            // Logical errors
            
            if (!FncScreenValidate_XX() || !FncScreenValidate_EN())
            {
                scnMsgBox.Text = "Don't  saved" + "<br/>" + m_ErrorValidate;
                return false;
            }

            // Sql save errors

            // Si DocId==0 1º save tdoc for get id number;
            // pasar valorEN de la clasificacion al documento principal
            scn_oDoc_edit.DocTypeGroup = "taxons_groups";
            scn_oDoc_edit.DocTypeGroupSub = "taxons_groups";



            if (!scn_oDoc_edit.FncSave(Convert.ToUInt64(scnDocId.Text), "taxons_groups"))
            {
                scnMsgBox.Text = "Don't  saved" + "<br/>" + scn_oDoc_edit.ErrorString; ;
                return false;
            }
            scnDocId.Text = scn_oDoc_edit.DocId.ToString();

            //Titulo por omision
            if (scn_oDocLng_edit_EN.DocLngMetaTitle == "") scn_oDocLng_edit_EN.DocLngMetaTitle = scnTitle_XX2.Text;
            if (!scn_oDocLng_edit_EN.FncSave(Convert.ToUInt64(scnDocId.Text), "EN", "taxons/taxons_groups/"))
            {
                scnMsgBox.Text = "Don't  saved" + "<br/>" + scn_oDocLng_edit_EN.ErrorString; ;
                return false;
            }

            FncScreenToReg_groupsEN();

            if (!oReg_groupsEN.FncSqlSave())
            {
                scnMsgBox.Text = "Don't  saved" + "<br/>" + oReg_groupsEN.ErrorString; ;
                return false;

            }
            else
            {
                scnMsgBox.Text = "saved";
                return true;
            }

        }
        protected void scnBtnNew_Click(object sender, EventArgs e)
        {
            m_DocId = 0;
            scnDocId.Text = m_DocId.ToString();
            oRegDoc.FncClear();
            oReg_groupsES.FncClear();
            oReg_groupsEN.FncClear();
            FncScreenFromReg();

        }

        protected void scnBtnListMng_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/tortoises/groups/groups-mng-list");
        }

        protected void scnBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/tortoises/groups/groups-list");
        }

       

      

        protected void scnBtnShowES_Click(object sender, EventArgs e)
        {
            if (scnDocId.Text != "0")
            {
                Response.Redirect("/es/tortoises/groups/group/" + scnDocId.Text);
            }
            else
            { scnMsgBox.Text = "This document is not saved"; }
        }
        protected void scnBtnSaveES_Click(object sender, EventArgs e)
        {
           
                FncSaveES();
           

        }
        protected void scnBtnSave_EN_Click(object sender, EventArgs e)
        {

            FncSaveEN();
        }

        protected void scnBtnRbCacheEn_Click(object sender, EventArgs e)
        {
            oReg_groupsEN.FncGetCache_Html(cls.ClsGlobal.CacheRebuid);
        }

        protected void scnBtnShowEN_Click(object sender, EventArgs e)
        {
            oReg_groupsEN.FncGetCache_Html(cls.ClsGlobal.CacheRebuid);
        }
        protected void scnBtnRbCacheES_Click(object sender, EventArgs e)
        {
            oReg_groupsES.FncGetCache_Html(cls.ClsGlobal.CacheRebuid);
        }
        protected void scnBtnBiblio_rebuild_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoc_biblio oBiblio = new cls.bbdd.ClsReg_tdoc_biblio();
            if (scnDocId.Text != "0")
            {
                scnBibliography_XX.Text = oBiblio.FncHtmlbyDocId_Parent(m_DocId);
            }
            else
            { scnMsgBox.Text = "This document is not saved before"; }
        }

        protected void scnBtnDeleteEN_Click(object sender, EventArgs e)
        {

        }
    }
}