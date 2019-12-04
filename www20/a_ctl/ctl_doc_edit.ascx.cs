using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace testudines.a_ctl
{
    public partial class ctl_doc_edit : System.Web.UI.UserControl
    {
 
        public cls.bbdd.ClsReg_tdoc oReg_tdoc = new cls.bbdd.ClsReg_tdoc();   
        protected void Page_Load(object sender, EventArgs e)
        {
            scnImg100_Img.Width = cls.ClsGlobal.imgAvatarWidth;
            scnImg100_Img_size.Text = "Pixels="+ cls.ClsGlobal.imgAvatarWidth.ToString ()+" x " + cls.ClsGlobal.imgAvatarHeight.ToString ();
        }
       
        public void FncFillDocId(UInt64 iDocId, string szDocTypeId)
        {
            oReg_tdoc.FncClear();

            if (iDocId == 0)
            {
               
                oReg_tdoc.DocTypeId = szDocTypeId;
            }
            else
            {

                oReg_tdoc.FncSqlFind(iDocId);
               
            }
            FncScreenFromReg(); 
        }

        private void FncScreenFromReg()
        {
            scnDocId.Text = oReg_tdoc.DocId.ToString();
          
            scnDocTypeId.Text = oReg_tdoc.DocTypeId.ToString();
            cls.ClsUtils.FncDropDownLngTranlatables(ref  scnDocLngIdMain,oReg_tdoc.DocLngId_Main );
            // scnDocLngIdMain.Text = oReg_tdoc.DocLngIdMain;
          //  scnDocTypeId.Text = oReg_tdoc.DocLngIdMain;
                    //System.IO.File.Copy(szFileTmp, szFileTarget, true);
            
            scnBibliography.Text = oReg_tdoc.DocBibliography;
            scnDocAcknowledgements.Text = oReg_tdoc.DocAcknowledgements;
            scnDocAuthors.Text = oReg_tdoc.DocAuthors;
            scnDocCountriesCode.Text = oReg_tdoc.DocCountriesCode;
            scnDocDateCreation.Text = oReg_tdoc.DocDateCreation.ToShortDateString();
            scnDocDateUpdate.Text = oReg_tdoc.DocDateUpdate.ToShortDateString();
            scnDocUserIdCreator.Text = oReg_tdoc.DocUserId_creator .ToString ();
            scnImg100.Text=oReg_tdoc.DocImgThumbnail ; 
            if(oReg_tdoc.DocImgThumbnail=="")oReg_tdoc.DocImgThumbnail="_noimage.jpg";
            
            
            if (System.IO.File.Exists(cls.ClsGlobal.DirDocStore + oReg_tdoc.DocImgThumbnail))
            {
                scnImg100_Img.ImageUrl = cls.ClsGlobal.UrlDocStore + oReg_tdoc.DocImgThumbnail;
            }
            else
            {
                scnImg100_Img.ImageUrl = cls.ClsGlobal.UrlDocStore + "_noimage.jpg";
            
            }
            scnDocIsActive.Checked = oReg_tdoc.DocIsActive;
            scnDocIsEditable.Checked = oReg_tdoc.DocIsEditable;
            scnDocIsTraslatable.Checked = oReg_tdoc.DocIsTraslatable;
            scnDocNotes.Text = oReg_tdoc.DocNotes;
            scnDocStdValHig.Text = oReg_tdoc.DocStdValHig.ToString();
            scnDocStdValLow .Text = oReg_tdoc.DocStdValLow .ToString();
            scnDocStdValMed .Text = oReg_tdoc.DocStdValMed .ToString();
            scnDocStdVisitCount .Text = oReg_tdoc.DocStdVisitCount .ToString();
            scnDocStdVisitLast.Text = oReg_tdoc.DocStdVisitLast.ToString();
            scnAuthorizations.Text = oReg_tdoc.DocAuthorizations.Trim(); 
           // scnDocTypeId.Text = oReg_tdoc.DocTypeId.ToString();
            try
            {
                scnDocSiteMapChangefreq.SelectedValue = oReg_tdoc.DocSiteMapChangefreq;
            }
            catch
            { scnDocSiteMapChangefreq.SelectedIndex = 1; }
            try
            {
                scnDocSiteMapPriority.SelectedValue = oReg_tdoc.DocSiteMapPriority;
            }
            catch
            {
                scnDocSiteMapPriority.SelectedIndex = 1;
            }
            scnDocumentUploaded.Text = oReg_tdoc.DocDocUploaded; 
           if (oReg_tdoc.DocDocUploaded != "")
           {
              
           

           if (System.IO.File.Exists(cls.ClsGlobal.DirDocStore + oReg_tdoc.DocDocUploaded))
            {
                scnDocumentUploadedLink.Text = "<a href=\"" + cls.ClsGlobal.UrlDocStore + oReg_tdoc.DocDocUploaded + "\"><img src=\"/a_img/a_site/ico16/ico-linkin.png\"/></a>";
                scnDocumentUploadedLink.Visible = true; 
           }
            else
            {
                scnDocumentUploadedLink.Text = "";
                scnDocumentUploadedLink.Visible = false;

            }
           }

           if (scnDocId.Text != "0")
           {
               String szJS = "FncShowBiblioWind(" + scnDocId.Text + ", '.')";
               // scnBtnBibliography.NavigateUrl="/a_dlg/dlg_bibliography.aspx?p=" + scnDocId.Text; ;
               //scnBtnBibliography.NavigateUrl =  "javascript:void(0)";
               scnBtnBibliography.Enabled = true;
               scnBtnBibliography.Visible = true;
               scnBtnBibliography.OnClientClick = szJS;

           }
           else
           {
               scnBtnBibliography.OnClientClick = "javascript:void(0);";
               scnBtnBibliography.Enabled = false;
               scnBtnBibliography.Visible = false;

           }

        }
        private bool FncScreenValidate()
        { return true; }
        private void FncScrennToReg()
        { }
        public bool FncSave(UInt64 DocId, string szDocTypeId)
        {
            if (szDocTypeId != "") scnDocTypeId.Text = szDocTypeId;
            cls.ClsSession oSession = new testudines.cls.ClsSession();
             oSession = (cls.ClsSession)Session["oSession"];
            bool bOk = true;
            oReg_tdoc.DocId = DocId;
            oReg_tdoc.DocUserId_creator = 1;  //oSession.UserId;
            oReg_tdoc.DocLngId_Main = scnDocLngIdMain.Text; ;
            oReg_tdoc.DocTypeId = scnDocTypeId.Text; ;
            oReg_tdoc.DocIsActive = scnDocIsActive.Checked;
            oReg_tdoc.DocIsEditable = scnDocIsEditable.Checked;
            oReg_tdoc.DocIsTraslatable = scnDocIsTraslatable.Checked;
            oReg_tdoc.DocAcknowledgements = scnDocAcknowledgements.Text;
            oReg_tdoc.DocAuthors = scnDocAuthors.Text;
            oReg_tdoc.DocBibliography = scnBibliography.Text;
            oReg_tdoc.DocCountriesCode = scnDocCountriesCode.Text; ;
            oReg_tdoc.DocAuthorizations = scnAuthorizations.Text.Trim();
            oReg_tdoc.DocImgThumbnail = scnImg100.Text;
            oReg_tdoc.DocDocUploaded = scnDocumentUploaded.Text;
            oReg_tdoc.DocSiteMapChangefreq=scnDocSiteMapChangefreq.SelectedValue ;
            oReg_tdoc.DocSiteMapPriority=scnDocSiteMapPriority.SelectedValue ;

            
            bOk=oReg_tdoc.FncSqlSave(); 
            return bOk;
        }
        public void FncClear()
        {
            oReg_tdoc.FncClear();
            FncScreenFromReg();
        }

        protected void scnPnlBibliographyBtnOpen_Click(object sender, EventArgs e)
        {

        }
        protected void scnUploadBtn_Click(object sender, EventArgs e)
        {
            scnMsgUpload.Text = "";
            scnMsgUpload.Visible = false;
           
            string szdir = "";
            try
            {
                if (scnFileUpload.HasFile)
                {
                    string szType = scnFileUpload.PostedFile.ContentType.ToString();
                    int iSizeBytes = scnFileUpload.PostedFile.ContentLength;
                    // comprobar extensiones y bytes
                    if (szType != "image/png" && szType != "image/jpeg" && szType != "image/jpg" && szType != "image/gif" && szType != "image/gif")
                    {
                        scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                        scnMsgUpload.Text = "Only types: jpg,jpeg, gif and png files";
                        scnMsgUpload.Visible = true;
                        return;
                    }

                    szdir = cls.ClsGlobal.DirTempSession;
                    if (!szdir.EndsWith("/")) szdir = szdir + "/";
                    //  if (!System.IO.Directory.Exists(szdir ) ) System.IO.Directory.CreateDirectory(szdir );  
                    string szFileNameNormaliced=cls.ClsUtils.FncPathFileNameNormalice( scnFileUpload.FileName);
                    string szFileTmp = szdir + szFileNameNormaliced;

                    scnFileUpload.SaveAs(szFileTmp);
                    scnFileUpload.GetType();
                    scnMsgUpload.ForeColor = System.Drawing.Color.Blue;
                    scnMsgUpload.Text = "File uploaded";
                    scnImg100.Text = scnFileUpload.FileName;
                    scnMsgUpload.Visible = true;
                    // crear thumbnail
                    cls.clsImgTool oImgTool = new testudines.cls.clsImgTool("");
                    string szFileTarget =cls.ClsGlobal.DirDocStore +szFileNameNormaliced;
            
                    string szAvatarName = oImgTool.FncBldAvatar(szFileTmp, szFileTarget, cls.ClsGlobal.imgAvatarWidth, cls.ClsGlobal.imgAvatarHeight);
                    // copiar al direcctorio de avatars

                    scnImg100.Text = szAvatarName;

                    //System.IO.File.Copy(szFileTmp, szFileTarget, true);
                    scnImg100_Img.ImageUrl = cls.ClsGlobal.UrlDocStore + szAvatarName;
                    //scnFileNameSrc.Text = scnFileUpload.FileName;

                }
                else
                {
                    scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                    scnMsgUpload.Text = "Please, select the file";
                    scnMsgUpload.Visible = true;
                }
            }
            catch (Exception xcpt)
            {
                scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                scnMsgUpload.Text = xcpt.Message;
                scnMsgUpload.Visible = true;
            }
        }
        protected void scnBtnUploadDocc_Click(object sender, EventArgs e)
        {
            scnMsgUploadDoc.Text = "";
            scnMsgUploadDoc.Visible = false;


            string szdir = "";
            try
            {
                if (ScnFileUploadDoc.HasFile)
                {

                    string szType = cls.ClsUtils.FncPathFileGetExtensionType(ScnFileUploadDoc.FileName);
                    int iSizeBytes = ScnFileUploadDoc.PostedFile.ContentLength;
                    // comprobar extensiones y bytes

                    if (szType != ".pdf" && szType != ".mpeg" && szType != ".mpeg" && szType != ".mpg" && szType != ".jpg" && szType != ".jpeg" && szType != ".gif" && szType != ".png")
                    {
                        scnMsgUploadDoc.ForeColor = System.Drawing.Color.Red;
                        scnMsgUploadDoc.Text = "Only types: .pdf, mpeg, mpeg,jpg,png,gif";
                        scnMsgUploadDoc.Visible = true;
                        return;
                    }

                    szdir = cls.ClsGlobal.DirTempSession; 
                    if (!szdir.EndsWith("/") ){szdir=szdir+"/";}
                    //  if (!System.IO.Directory.Exists(szdir ) ) System.IO.Directory.CreateDirectory(szdir );  
                    string szFileTmp = szdir  + ScnFileUploadDoc.FileName;

                    ScnFileUploadDoc.SaveAs(szFileTmp);
                    //string szFileTarget =cls.clsUtil.FncFileNameUnique(ClsGlobal.DirDocReferencesFullPath + ScnFileUploadDoc.FileName);
                    string szFileNameUnique = cls.ClsUtils.FncPathFileCopyUnique(szFileTmp, cls.ClsGlobal.DirDocStore + ScnFileUploadDoc.FileName);
                    scnMsgUploadDoc.ForeColor = System.Drawing.Color.Blue;
                    scnMsgUploadDoc.Text = "File uploaded";
                    scnMsgUploadDoc.Visible = true;
                    scnDocumentUploaded.Text = szFileNameUnique;
                    scnDocumentUploaded.Visible = true;
                    scnDocumentUploadedLink.Visible = true;
                    scnDocumentUploadedLink.Text = "<a href=\"" + cls.ClsGlobal.UrlDocStore + szFileNameUnique + "\"><img src=\"/a_img/a_site/ico16/ico-linkin.png\"/></a>";
                }
                else
                {
                    scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                    scnMsgUpload.Text = "Please, select the file";
                    scnMsgUpload.Visible = true;
                }
            }
            catch (Exception xcpt)
            {
                scnMsgUploadDoc.ForeColor = System.Drawing.Color.Red;
                scnMsgUploadDoc.Text = xcpt.Message;
                scnMsgUploadDoc.Visible = true;
            }
        }

        protected void scnBtnUploadDocClear_Click(object sender, EventArgs e)
        {
            scnDocumentUploaded.Text = "";
            scnMsgUploadDoc.Text = "";
        }

        protected void scnUploadBtnClear_Click(object sender, EventArgs e)
        {
            scnImg100.Text = "";
            scnImg100_Img.ImageUrl = cls.ClsGlobal.UrlDocStore + "default.jpg";
            scnMsgUpload.Text = "";
        }
        public string DocTypeGroup
        {
            get{return oReg_tdoc.DocTypeGroup  ;}
            set { oReg_tdoc.DocTypeGroup = value; }
        }
        public string DocTypeGroupSub
        {
            get { return oReg_tdoc.DocTypeGroupSub; }
            set { oReg_tdoc.DocTypeGroupSub = value; }
        }

        protected void scnBtnBibliographyGet_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoc_biblio oBib = new cls.bbdd.ClsReg_tdoc_biblio();
            scnBibliography.Text = oBib.FncHtmlbyDocId_Parent(Convert.ToUInt64(scnDocId.Text));
        }
 

        public string Bibliography
        {
            get { return scnBibliography.Text; }
            set {  scnBibliography.Text=value.Trim(); }
        }
         public string Acknowledgements
        {
            get { return scnDocAcknowledgements.Text; }
            set { scnDocAcknowledgements.Text = value.Trim(); }
        }
        public string Authors
        {
            get { return scnDocAuthors.Text; }
            set {  scnDocAuthors.Text=value.Trim(); }
        }
        public UInt64 DocId
        {
            get { return oReg_tdoc.DocId; }
        }
        public string ErrorString
        {
            get { return oReg_tdoc.ErrorString; }
        }

    }
}

