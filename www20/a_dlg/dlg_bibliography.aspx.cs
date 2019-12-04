using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using testudines;

 namespace testudines.a_dlg
{
    public partial class dlg_bibliography : System.Web.UI.Page
    {
        testudines.cls.bbdd.ClsReg_tdoc_biblio oRegBib = new testudines.cls.bbdd.ClsReg_tdoc_biblio();
        testudines.cls.bbdd.ClsReg_tdoc_biblio_rel oReg_tdoc_biblio_rel = new testudines.cls.bbdd.ClsReg_tdoc_biblio_rel();
         UInt64 m_docId_parent = 0;
        string m_ParentTitle = "No title";
        /*
          SELECT * FROM (
 Select tdoc_biblio.DocId,  tdoc_biblio_rel.DocIdParent, '1' as Tick, tdoc_biblio.CiteAutorYearABC, tdoc_biblio.Title
 from  tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid 
  where   tdoc_biblio_rel.DocIdParent=112
  UNION
 Select tdoc_biblio.DocId,  '' , '0' as Tick, tdoc_biblio.CiteAutorYearABC, tdoc_biblio.Title
 from  tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid
  WHERE NOT EXISTS ( SELECT * FROM  tdoc_biblio_rel WHERE DocIdParent =112 AND DocId=tdoc_biblio.DocId  )
  )
  AS tb order by CiteAutorYearABC
         
         */



        string m_sqlDefSelect = "SELECT * FROM ( " +
        " Select tdoc_biblio.DocId,  tdoc_biblio_rel.DocIdParent, '1' as Tick, tdoc_biblio.CiteAutorYearABC, tdoc_biblio.Title" +
        " from  tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid" +
        " where   tdoc_biblio_rel.DocIdParent=#num#" +
        " UNION" +
        " Select tdoc_biblio.DocId,  '' , '0' as Tick, tdoc_biblio.CiteAutorYearABC, tdoc_biblio.Title" +
        " from  tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid" +
        " WHERE NOT EXISTS ( SELECT * FROM  tdoc_biblio_rel WHERE DocIdParent =#num# AND DocId=tdoc_biblio.DocId )" +
        " ) AS tb ";


        string m_sqlDefOrder = " order by tdoc_biblio.CiteAutorYearABC, tdoc_biblio.Title";
        string m_sqlDefWhere = "";
        string m_sqlelect = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                scnPanelList.Visible = true;
                scnPanelEdit.Visible = false;
                scnPanelUpload.Visible = false;
                // leer parametros de entrada
                string test = Resources.Strings.Reset.ToString();

                m_docId_parent = 1;
                m_ParentTitle = "";
                try
                {
                    if (Request["p"] != null)
                    {
                        m_docId_parent = Convert.ToUInt64(Request["p"].ToString());

                    }
                    else
                    { m_docId_parent = 254; }


                }
                catch (Exception)
                {
                    m_docId_parent = 254;
                }
          
                scnFilterDocIdParent.Text = m_docId_parent.ToString();
                scnParentTitle.Text = FncGetTaxonTitle(m_docId_parent);
                // fin leer parametros de entrada

                m_sqlDefWhere = "";// where tdoc_biblio_rel.DocIdParent=" + scnDocIdParent.Text;
                FncFillGridView2();
            }
            else
            { //  FncFillGridView();
            }

        }
        private string FncGetTaxonTitle(UInt64 pDocId)
        {
            testudines.cls.bbdd.ClsReg_tdoclng oDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();
            
            if (oDocLng.FncSqlFind(pDocId, "es"))
            {
                m_ParentTitle = oDocLng.DocLngMetaTitle;
            }
            else if (oDocLng.FncSqlFind(pDocId, "en"))
            {
                m_ParentTitle = oDocLng.DocLngMetaTitle;

            }
            else { m_ParentTitle = ""; }
            return m_ParentTitle;
        }
        private void FncFillGridView2()
        {
            FncFillSelectComand();
            MySqlConnection con;
            DataSet ds;
            string CmdString;


            con = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            string sortDirection, sortExpression;

            CmdString = m_sqlelect.Replace("#num#", scnFilterDocIdParent.Text);
            ds = new DataSet();
            using (MySqlDataAdapter sda = new MySqlDataAdapter(CmdString, con))
            {
                sda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DataView dv = ds.Tables[0].DefaultView;
                    if (ViewState["SortDirection"] != null)
                    {
                        sortDirection = ViewState["SortDirection"].ToString();
                    }

                    if (ViewState["SortExpression"] != null)
                    {
                        sortExpression = ViewState["SortExpression"].ToString();
                        dv.Sort = string.Concat(sortExpression, " ", "ASC");
                    }
                    scnGridview.DataSource = dv;
                    scnGridview.DataBind();
                }
            }
        }
        private void FncFillSelectComand()
        {
            string szAnd = "";
            string szWhere = "";
            scnFilterDocIdParent.Text = scnFilterDocIdParent.Text.Trim();
            scnFilterText.Text = scnFilterText.Text.Trim();
            // if (scnFilterDocIdParent.Text != "")
            // {
            //     szWhere += " tdoc_biblio_rel.DocIdParent=" + scnFilterDocIdParent.Text;
            //     szAnd = " and ";
            // }
            if (scnFilterText.Text.Trim() != "")
            {
                szWhere += szAnd;
                szWhere += " (CiteAutorYearABC like '%" + scnFilterText.Text + "%' ";
                szWhere += " or Title like '%" + scnFilterText.Text + "%') ";
            }
            if (szWhere != "")
            {
                m_sqlDefWhere = " where " + szWhere;
            }
            string szOrder = "";
            int iOrder = Convert.ToInt32(scnRadOrder.SelectedItem.Value);
            switch (iOrder)
            {
                case 1: //FIFO
                    szOrder = " order by DocId";
                    break;

                case 2: //LIFO
                    szOrder = " order by DocId desc";
                    break;

                case 3: //Aut title
                    szOrder = " order by CiteAutorYearABC , Title";
                    break;
                default:
                    szOrder = " order byCiteAutorYearABC , Title";
                    break;
            }

            m_sqlDefOrder = szOrder;
            m_sqlelect = m_sqlDefSelect.Replace(" #num#", scnFilterDocIdParent.Text) + m_sqlDefWhere + m_sqlDefOrder;
        }


        protected void ColChkBox_CheckedChanged(object sender, EventArgs e)
        {


            UInt64 idDoc = 0;
            UInt64 idDocParent = 0;
            // get the checkbox reference
            CheckBox chk = (CheckBox)sender;
            // get the GridViewRow reference
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            int iNdx = row.DataItemIndex;
            int iNdxInPage = iNdx - scnGridview.PageIndex * scnGridview.PageSize;
            GridViewRow rowSelect = scnGridview.Rows[iNdxInPage];
            idDoc = Convert.ToUInt64(rowSelect.Cells[2].Text);
            try
            { idDocParent = Convert.ToUInt64(scnFilterDocIdParent.Text); }
            catch
            { idDocParent = 0; }
            if (chk.Checked)
            { rowSelect.Cells[3].Text = scnFilterDocIdParent.Text; }
            // else
            // { rowSelect.Cells[3].Text = ""; 

            // actualizar base de datos;
            // si esta checkeado añadir- o actualizar
            // si no borrarlo si existe.


            oReg_tdoc_biblio_rel.DocId = idDoc;
            oReg_tdoc_biblio_rel.DocIdParent = idDocParent;
            if (chk.Checked)
            {
                oReg_tdoc_biblio_rel.FncSqlSave();
            }
            else
            {
                oReg_tdoc_biblio_rel.FncSqlDelete(oReg_tdoc_biblio_rel.DocIdParent, oReg_tdoc_biblio_rel.DocId);

            }

            // UInt64
            // And you respective cell's value

            scnLOG.Text = idDoc.ToString() + "-" + idDocParent.ToString() + chk.Checked.ToString();


            // assuming the primary key value is stored in a hiddenfield with ID="HiddenID"
            HiddenField hiddenID = (HiddenField)row.FindControl("HiddenID");

            scnLOG.Text += " - Item:" + iNdx.ToString();
        }

        protected void scnGridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            scnGridview.PageIndex = e.NewPageIndex;
            FncFillGridView2();

        }

        protected void scnBtnFilter_Click(object sender, EventArgs e)
        {
            scnGridview.DataSource = null;
            scnGridview.DataBind();
            FncFillGridView2();
        }





        protected void scnBtnShowList_Click(object sender, EventArgs e)
        {
            scnPanelUpload.Visible = false;
            scnPanelEdit.Visible = false;
            scnPanelList.Visible = true;
        }

        protected void BtnShowNew_Click(object sender, EventArgs e)
        {
            oRegBib.FncClear();
            FncScreenFromReg();
            scnPanelUpload.Visible = true;
            scnPanelEdit.Visible = true;
            scnPanelList.Visible = false;
        }

        protected void scnRadOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            FncFillGridView2();
        }

        //---------------------------------------------------
        //---------------------------------------------------
        // Edit or Append New
        //---------------------------------------------------
        //---------------------------------------------------
        private void FncScreenFromReg()
        {
            scnMsg.Visible = false;
            scnMsg.Text = "";
            scnPanelUploadMsg.Text = "";

            //      scnRowSelect.Text = GridView1.SelectedValue.ToString() ; 
            // clear fields
            scnAuthorsTxt.Text = oRegBib.Authors;
            scnCiteAutorYearABCTxt.Text = oRegBib.CiteAutorYearABC;
            scnCiteHtmlFullTxt.Text = oRegBib.CiteHtmlFull + "<br/>Tooltip:" + oRegBib.CiteHtmlToolTip;
            scnDocIdTxt.Text = oRegBib.DocId.ToString();
            //scnDocId_ParentTxt.Text = m_docId_parent.ToString();
            scnPublicationDatePageTxt.Text = oRegBib.PublicationDatePage;
            scnFileUrl.Text= oRegBib.URLocalDownload ;
            scnPublicationNameTxt.Text = oRegBib.PublicationName;
            scnPublicationNotesTxt.Text = oRegBib.PublicationNotes;
            scnPublicationReadedTxt2.Text = oRegBib.PublicationReaded;
            try
            {
                scnPublicationTypeTxt.SelectedValue = oRegBib.PublicationType;
            }
            catch { ;}
            scnTitleTxt.Text = oRegBib.Title;

            scnURPublicationTxt2.Text = oRegBib.URPublication;
            // calcular el numero de documentos relaionados

            scnRelatedCount2.Text = oRegBib.FncCountParents().ToString ();
            if (scnRelatedCount2.Text!="0")
            {
                ConfirmButtonExtender1.ConfirmText = "Not posible delete<br/>This document has " + scnRelatedCount2.Text + "related documentx ";
        }
            else
            {
               ConfirmButtonExtender1.ConfirmText= "Do You want to delete this? ";
            }
        }
        private bool FncScreenToReg()
        {

            if (!FncScreenValidated())
            {
                return false;
            }

            bool bOk = true;

            oRegBib.DocId = Convert.ToUInt64(scnDocIdTxt.Text.ToString());

            oRegBib.DocId = Convert.ToUInt64(scnDocIdTxt.Text);

            oRegBib.Authors = scnAuthorsTxt.Text;
            oRegBib.CiteAutorYearABC = scnCiteAutorYearABCTxt.Text;
            //oRegBib.CiteHtmlFull = scnCiteHtmlFullTxt.Text;
            // oRegBib.DocId = Convert.ToInt64(scnDocIdTxt.Text);
            //oRegBib.DocId_Parent = Convert.ToInt64(scnDocId_ParentTxt.Text);
            oRegBib.PublicationDatePage = scnPublicationDatePageTxt.Text;
            oRegBib.PublicationName = scnPublicationNameTxt.Text;
            oRegBib.PublicationNotes = scnPublicationNotesTxt.Text;
            oRegBib.PublicationReaded = scnPublicationReadedTxt2.Text;
            oRegBib.PublicationType = scnPublicationTypeTxt.SelectedValue;
            oRegBib.Title = scnTitleTxt.Text;
            oRegBib.URLocalDownload = scnFileUrl.Text;
            oRegBib.URPublication = scnURPublicationTxt2.Text;
           

            if (oRegBib.FncSqlSave())
            {
                scnMsg.Text = "saved";
                scnMsg.ForeColor = System.Drawing.Color.Green;
                scnCiteHtmlFullTxt.Text = oRegBib.CiteHtmlFull + "<br/> Link tooltip: " + oRegBib.CiteHtmlToolTip;
                scnPublicationNotesTxt.Text = oRegBib.PublicationNotes;
                scnDocIdTxt.Text = oRegBib.DocId.ToString();
                
                return true;
            }

            else
            {
                scnMsg.ForeColor = System.Drawing.Color.Red;
                scnMsg.Text = "NOT SAVED";
                return false;
            }


        }

        /// <summary>
        /// VALIDATION OF SCREEN FIELDS
        /// </summary>
        /// <returns>
        /// IF ERROR RETUR FALSE ELSE RETURN TRUE
        /// </returns>
        private bool FncScreenValidated()
        {
            bool bOk = true;
            scnMsg.Text = "";
            scnMsg.Visible = false;

            // clear fields

            // scnShortDescription.Text = scnShortDescription.Text.ToString().Trim();

            // Find errors

            if (scnCiteAutorYearABCTxt.Text.Trim() == "")
            {
                bOk = false;
                scnMsg.Text += "<br/>scnCiteAutorYearABC empty";
            }

            if (scnAuthorsTxt.Text.Trim() == "")
            {
                bOk = false;
                scnMsg.Text += "<br/>Authors empty";
            }
            if (scnPublicationTypeTxt.Text.Trim() == "")
            {
                bOk = false;
                scnMsg.Text += "<br/>scnPublicationTypeTxt empty";
            }
            if (scnTitleTxt.Text.Trim() == "")
            {
                bOk = false;
                scnMsg.Text += "<br/>scnTitleTxt empty";
            }


            //if (scnURPublicationTxt.Text.Length > 1)
            //{
            //    if (!cls.clsUtil.FncUrlIsOk(scnURPublicationTxt.Text))
            //    {
            //        bOk = false;
            //        scnMsg.Text += "<br/>The scnURPublicationTxt has bad format";


            //    }
            //}

            if (!bOk)
            {
                scnMsg.Visible = true;
                scnMsg.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;
        }
        protected void scnRegGuardar_Click(object sender, EventArgs e)
        {
            
                FncScreenToReg();
                
        }
        protected void cnBtnReturn3_Click(object sender, EventArgs e)
        {

        }
        protected void scnBtnAddNewTaxaBib_Click(object sender, EventArgs e)
        {
            oRegBib.FncSetDefaultBibliographyTaxa(Convert.ToUInt64(scnFilterDocIdParent.Text));
            FncFillGridView2();
        }
        protected void scnRegDeleteBtn_Click(object sender, EventArgs e)
        {
            // calcular en numero de documentos relacioandos con el que se quiere borrar
             if (scnRelatedCount2.Text.Trim()!="0") return;
                
            oRegBib.FncSqlDelete(Convert.ToInt32(scnDocIdTxt.Text));
            scnGridview.DataBind();
            oRegBib.FncClear();
            FncScreenFromReg();
        }

        protected void scnBtnAddNew_Click(object sender, EventArgs e)
        {
            oRegBib.FncClear();
            //oRegBib.DocId_Parent = m_docId_parent;
            FncScreenFromReg();
            scnRegDeleteBtn.Visible = false;
            scnPanelList.Visible = false;
            scnPanelEdit.Visible = true;
            scnRegDeleteBtn.Visible = true;
            scnPanelList.Visible = false;
            scnPanelEdit.Visible = true;
            scnPanelUpload.Visible = true;
        }


        protected void scnBtnReturn_Click(object sender, EventArgs e)
        {
            scnPanelUpload.Visible = false;
            scnPanelEdit.Visible = false;
            scnPanelList.Visible = true;
            //FncFillGrid("");
        }

        protected void scnAjaxFileUpload_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string sz = e.FileName;
        }

        protected void scnAjaxFileUpload_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs e)
        {
            string sz = e.ToString();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oRegBib.FncSqlFind(Convert.ToUInt64(scnGridview.SelectedValue.ToString()));
        
            scnRegDeleteBtn.Visible = true;
            scnPanelList.Visible = false;
            scnPanelEdit.Visible = true;
            scnPanelUpload.Visible = true;
            //GridViewRow oRow =
            FncScreenFromReg();
            
        }


        //---------------------------------------------------
        //---------------------------------------------------
        //---------------------------------------------------
        //---------------------------------------------------
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            String sz = scnCiteAutorYearABCTxt.Text.Trim() + "-" + scnTitleTxt.Text.Trim();
            if (sz.Length > 80) sz = sz.Substring(0, 79);
            string szFileName = cls.ClsUtils.FncPathFileNameNormalice(sz + ".pdf");
            string szFilePath = cls.ClsGlobal.DirMMedia + "bibliography/";//Server.MapPath("~/mmedia/bibliography/");
            string szFilePathFul = szFilePath + szFileName;
            string szFileUrl = cls.ClsGlobal.UrlMMedia + szFileName; // "/mmedia/bibliography/" + szFileName;
            string szFilePrevious = (Server.MapPath("~/") + scnFileUrl.Text.Replace("/", "\\")).Replace("\\\\", "\\");
            string szFilePreviousBack = szFilePrevious.Replace (".pdf", "_back.pdf");
           
              

            if (!scnFileUpload1.FileName.ToLower().EndsWith(".pdf"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Only pdf files.');", true);
                scnPanelUploadMsg.Text = "Not uploaded. Only Pdf files";
                return;
            }
            bool bError = false;
            if (scnCiteAutorYearABCTxt.Text.Trim() == "") { bError = true; }
            if (scnTitleTxt.Text.Trim() == "") { bError = true; }
            if (bError)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Need fill Author year and title, before upload');", true);
                scnPanelUploadMsg.Text = "Need fill Author year and title, before upload";
                return;
            }

            if (!scnFileUpload1.HasFile)
            {
               ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Select a file before upload');", true);
                scnPanelUploadMsg.Text = "Select a file before upload";
                return;
            
            }

            if (System.IO.File.Exists(szFilePrevious))
            {
                if (System.IO.File.Exists(szFilePreviousBack)) { System.IO.File.Delete(szFilePreviousBack); }

                System.IO.File.Move(szFilePrevious, szFilePreviousBack);
            }
            
            // guardar en base de datos. Pues si no esta en bbdd no se debe guardar el pdf pues podria quedar sin enlace a la bbdd
            if (!FncScreenToReg())
            {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Fill fields before upload');", true);
                scnPanelUploadMsg.Text = "Not uploaded. Only Pdf files";
                return;
            }
                
   
                scnFileUrl.NavigateUrl = szFileUrl;
                scnFileUrl.Text = szFileUrl;
                // si ya se subio un fichero previamente, 
               

                if (!System.IO.Directory.Exists(szFilePath))
                {
                    System.IO.Directory.CreateDirectory(szFilePath);
                }
                
              
                //Guid.NewGuid() + FileUpload1.FileName);

                if (System.IO.File.Exists(szFilePathFul)) { System.IO.File.Delete(szFilePathFul); };

                scnFileUpload1.SaveAs(szFilePathFul);
                oRegBib.URLocalDownload = szFileUrl;
                //string ShowImgPath = ImgPath.Substring(ImgPath.LastIndexOf("\\"));
                //imgShow.ImageUrl = "~/Images" + ShowImgPath;
                scnPanelUploadMsg.Text ="Ok, Uploaded";
                FncScreenToReg(); // guarda con nuevo nonmbre
            
        }

        protected void scnBtnLinkToDocument_Click(object sender, EventArgs e)
        {
            if(m_docId_parent!=0)
                {
                oReg_tdoc_biblio_rel.DocId = Convert.ToUInt64(scnDocIdTxt.Text);
                oReg_tdoc_biblio_rel.DocIdParent = m_docId_parent;
                oReg_tdoc_biblio_rel.FncSqlSave();
                    }
        }
    }
};