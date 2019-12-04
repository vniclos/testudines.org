using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_ctl
{
    public partial class ctl_docLng_edit : System.Web.UI.UserControl
    {
        cls.bbdd.ClsReg_tdoclng oReg_DocLng = new cls.bbdd.ClsReg_tdoclng();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FncClear()
        {
            oReg_DocLng.FncClear();
            FncScreenFromReg();
        }
        public void FncFilldoclngidId(UInt64 iDocId, string szdoclngidId)
        {
          
            if (iDocId != 0)
            {
                oReg_DocLng.FncSqlFind(iDocId, szdoclngidId);
            }
            FncScreenFromReg();
        }

        private void FncScreenFromReg()
        {
         
            if (oReg_DocLng.DocLngMetaRobots == "")
            {
                scnDocLngMetaRobots.SelectedIndex = 0;
            }
            else
            {
                scnDocLngMetaRobots.Text = oReg_DocLng.DocLngMetaRobots;
            }

            if (oReg_DocLng.DocLngRevisit_after == "")
            {
            scnDocLngMetarevisit_after.SelectedIndex =0;
            }
            else
            {
              scnDocLngMetarevisit_after.Text = oReg_DocLng.DocLngRevisit_after;
            }

            //scnDocLngStatusRevision.Text = oReg_DocLng.DocLngStatusRevision;
            if (oReg_DocLng.DocLngStatusRevision == "")
            {
                scnDocLngStatusRevision.SelectedIndex = 0;
            }
            else
            {
                scnDocLngStatusRevision.Text = oReg_DocLng.DocLngStatusRevision;
            }
            //scnDocLngId2.Text = oReg_DocLng.DocId;
            scnDocLngId2.Text = oReg_DocLng.DocLngId;
            
            scnDocLngDateCreation.Text = oReg_DocLng.DocLngDateCreation.ToString() ;
            scnDocLngMetaAuthor.Text = oReg_DocLng.DocLngDateUpdate.ToString()  ;
            scnDocId_todo.Text = oReg_DocLng.DocId_tdoclng_Todo.ToString(); 
            scnDocLngMetaAuthor.Text = oReg_DocLng.DocLngMetaAuthor ;
            scnDocLngMetaTitle.Text = oReg_DocLng.DocLngMetaTitle;
            scnDocLngMetaDescription .Text = oReg_DocLng.DocLngMetaDescription ;
            scnDocLngMetaKeyWords.Text = oReg_DocLng.DocLngMetaKeyWords ;
            scnDocLngMetaLanguage.Text = oReg_DocLng.DocLngMetaLanguage ;
            scnDocLngUrlId2.Text = oReg_DocLng.DocLngUrlId;
            scnDocLngUrlTitle2.Text = oReg_DocLng.DocLngUrlTitle;
            
            scnDocLngMetaContent .Text = oReg_DocLng.DocLngMetaContentType;
            
            
            scnDocLngMetaTranslators .Text = oReg_DocLng.DocLngMetaTranslators ;
            scnDocLngNotes .Text = oReg_DocLng.DocLngNotes ;
          //
           
            
        }
        private bool FncScreenValidate()
        { return true; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iDocId"></param>
        /// <param name="szLngId"></param>
        /// <param name="szDocLngUrlType">Typeo de documento para crear url seo friendly, /{szLngId}/{}szDocLngUrlType/{iDocId}</param>
        /// <returns></returns>
        public bool FncSave(UInt64 iDocId, String szLngId, string szMaskUrl)
        {
            cls.ClsSession oSession = new testudines.cls.ClsSession();
            oSession = (cls.ClsSession)Session["oSession"];

       
            
           

            bool bOk = true;
            oReg_DocLng.DocId = iDocId;
            oReg_DocLng.DocLngId = szLngId;
            oReg_DocLng.DocLngMetaLanguage = scnDocLngMetaLanguage.Text;

           // oReg_DocLng.DocLngUrlId = ClsGlobal.DirRootUrl + "/" + szLngId + "/" + szMaskUrl + "/" + iDocId.ToString();
           // oReg_DocLng.DocLngUrlTitle = ClsGlobal.DirRootUrl + "/" + szLngId + "/" + szMaskUrl + "/" + scnDocLngUrlTitle.Text;
           // scnDocLngUrlIdTit2.Text  = oReg_DocLng.DocLngUrlTitle;
            scnDocLngUrlId2.Text = oReg_DocLng.DocLngUrlId;
            scnDocLngUrlTitle2.Text = oReg_DocLng.DocLngUrlTitle;
          //  oReg_DocLng.DocLngDateCreation = oSession.UserId;
          //  oReg_DocLng.DocLngDateUpdate = scnDocLngIdMain.Text; ;
            oReg_DocLng.DocId_tdoclng_Todo = Convert.ToInt32(scnDocId_todo.Text); 
            
            oReg_DocLng.DocLngMetaAuthor = scnDocLngMetaAuthor.Text;
            oReg_DocLng.DocLngMetaContentType = scnDocLngMetaContent.Text;
            oReg_DocLng.DocLngMetaDescription = scnDocLngMetaDescription.Text;
            oReg_DocLng.DocLngMetaKeyWords = scnDocLngMetaKeyWords.Text;
            
            oReg_DocLng.DocLngMetaRobots = scnDocLngMetaRobots.Text;
            oReg_DocLng.DocLngMetaTitle = scnDocLngMetaTitle.Text; ;
            oReg_DocLng.DocLngMetaTranslators = scnDocLngMetaTranslators.Text; ;
            oReg_DocLng.DocLngNotes = scnDocLngNotes.Text; ;
            oReg_DocLng.DocLngRevisit_after = scnDocLngMetarevisit_after.Text; ;
            oReg_DocLng.DocLngStatusRevision = scnDocLngStatusRevision.Text; ;
            bOk = oReg_DocLng.FncSqlSave(szMaskUrl);
            return bOk;
        }
        private void FncScrennToReg()
        {  
            //oReg_DocLng.DocId=scnDocId.text ;
            oReg_DocLng.DocLngId = scnDocLngId2.Text;

            //oReg_DocLng.DocLngDateCreation = scnDocLngDateCreation.Text; ;
            //oReg_DocLng.DocLngDateUpdate = scnDocLngDateCreation.text; ;

            oReg_DocLng.DocLngMetaAuthor = scnDocLngMetaAuthor.Text;
            oReg_DocLng.DocLngMetaTitle = scnDocLngMetaTitle.Text; ;
            oReg_DocLng.DocLngMetaDescription = scnDocLngMetaDescription.Text;
            oReg_DocLng.DocLngMetaKeyWords = scnDocLngMetaKeyWords.Text;
            oReg_DocLng.DocLngMetaLanguage = scnDocLngMetaLanguage.Text;

            oReg_DocLng.DocLngMetaContentType = scnDocLngMetaContent.Text;
            oReg_DocLng.DocLngMetaRobots = scnDocLngMetaRobots.Text;

            oReg_DocLng.DocLngMetaTranslators = scnDocLngMetaTranslators.Text;
            oReg_DocLng.DocLngNotes = scnDocLngNotes.Text;
            oReg_DocLng.DocLngRevisit_after = scnDocLngMetarevisit_after.Text;
            oReg_DocLng.DocLngStatusRevision = scnDocLngStatusRevision.Text;
            
        }
        
        
        public string ErrorString
        {
            get { return oReg_DocLng.ErrorString; }
        }
        public string DocLngMetaTitle
        { 
            get {return scnDocLngMetaTitle.Text.Trim ();}
            set {scnDocLngMetaTitle.Text=value ;}
        }
        public string DocLngMetaDescription
        {
            get { return scnDocLngMetaDescription .Text.Trim(); }
            set { scnDocLngMetaDescription.Text = value; }
        }
        public string  DocLngMetaKeyWords
        {
            get { return scnDocLngMetaKeyWords .Text.Trim(); }
            set { scnDocLngMetaKeyWords.Text = value; }
        }
        public string DocLngMetaContent
        {
            get { return scnDocLngMetaContent.Text.Trim(); }
            set { scnDocLngMetaContent.Text = value; }
        }
        public string DocLngUrlId
        {
            get { return scnDocLngUrlId2.Text.Trim(); }
            
        }
        public string DocLngUrlIdTitle
        {
            get { return scnDocLngUrlTitle2.Text.Trim(); }

        }
        public Int64 DocId_todo
        {
        
            get { return Convert.ToInt32 (scnDocId_todo.Text.Trim()); }
            set { scnDocId_todo.Text = value.ToString(); }
        }
    }
}
