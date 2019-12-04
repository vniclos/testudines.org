using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using testudines.cls;
using System.IO;
using Telerik.WebControls;

namespace testudines.ckeditor
{
    public partial class ImageBrowser : System.Web.UI.Page
    {
        private cls.bbdd.ClsReg_tdoclng_media oReg = new testudines.cls.bbdd.ClsReg_tdoclng_media();
        private string m_ServerRoot = "";
        private string m_AlbumsRootPath = "";
        private string m_img_ddbb_ok = "/a_img/a_site/ico16/ico-doc-ok-c.png";
        private string m_img_ddbb_false = "/a_img/a_site/ico16/ico-alert-yelow.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            m_ServerRoot = Server.MapPath("~");
            m_AlbumsRootPath = ClsGlobal.DirMMedia;

            if (!Page.IsPostBack)
            {
                scnMediaDocId.Text = "0";

                scnMsgUpload.Text = "";
                scnFolderNewName.Text = "";
                scnFolderSelected.Text = "";

                //  string m_AlbumsRootPath = Server.MapPath("~") + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();
                // clsConfigMMPaths.FncbldDirectories(m_AlbumsRootPath);

                FncBindAlbumDirectoryList();
                FncBindTreeToDirectoryRoot();

                FncFillImagesInNode();
                scnBtnNewAlbum.OnClientClick = "var name = prompt('Enter name of folder:'); if (name == null || name == '') return false; document.getElementById('" + scnNewAlbumName.ClientID + "').value = name;";
            }

            scnMsgBldTumbnail.Text = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "FocusImageList", "window.setTimeout(\"document.getElementById('" + scnImageList.ClientID + "').focus();\", 1);", true);
        }
        private void FncBindAlbumDirectoryList()
        {
            // string m_AlbumRoots = Server.MapPath("~") + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();

            DirectoryInfo di = new DirectoryInfo(m_AlbumsRootPath);
            scnAlbumDirectoryList.Items.Clear();
            foreach (DirectoryInfo diDir in di.GetDirectories())
            {
                scnAlbumDirectoryList.Items.Add(diDir.Name);


            }
            if (scnAlbumDirectoryList.Items.Count > 0) scnAlbumDirectoryList.SelectedIndex = 0;
            scnBtnDeleteAlbum.OnClientClick = "return confirm('Are you sure !\\n\\n Do you want to DELETE the Album\\n\\n" + scnAlbumDirectoryList.SelectedValue + "\\n\\n and all its contents?');";
            ;
        }
        protected void scnAlbumDirectoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FncBindTreeToDirectoryRoot();
            FncFillImagesInNode();
            scnBtnDeleteAlbum.OnClientClick = "return confirm('Are you sure !\\n Do you want to delete the Album\\n" + scnAlbumDirectoryList.SelectedValue + "\\n and all its contents?');";

        }
        private void FncBindTreeToDirectoryRoot()
        {
            scnMsgFolder.Text = "";
            scnFolderSelected.Text = "";
            scnTreeView.Nodes.Clear();
            if (scnAlbumDirectoryList.SelectedValue == null) return;
            RadTreeNode rootNode = new RadTreeNode(scnAlbumDirectoryList.SelectedValue);
            rootNode.Image = "Folder.gif";
            rootNode.Category = "Root";
            rootNode.Expanded = true;
            rootNode.Value = "\\" + scnAlbumDirectoryList.SelectedValue;
            oReg.FncClear();
            FncScrennFromReg();
            scnTreeView.AddNode(rootNode);

            FncBindTreeToDirectory(m_AlbumsRootPath + "\\" + scnAlbumDirectoryList.SelectedValue, rootNode);

            scnTreeView.Nodes[0].Selected = true;

        }
        private void FncBindTreeToDirectory(string dirPath, RadTreeNode parentNode)
        {

            string[] dirs = Directory.GetDirectories(dirPath);
            foreach (string s in dirs)
            {
                string[] parts = s.Split('\\');
                string name = parts[parts.Length - 1];
                if (name.Contains("thumbnails")) return;

                RadTreeNode node = new RadTreeNode(name);
                node.Image = "Folder.gif";
                node.Text = name;
                node.Value = dirPath.Replace(m_AlbumsRootPath, "") + "\\" + name;
                node.ContextMenuName = "ContextMenus.xml";
                node.Category = "Folder";

                string[] s2 = node.Value.Split('\\');
                if (s2.Length > 3)
                { node.Expanded = false; }
                else { node.Expanded = true; }
                parentNode.AddNode(node);
                FncBindTreeToDirectory(s, node);

            }


        }

        protected void scnTreeView_NodeClick(object o, RadTreeNodeEventArgs e)
        {

            FncFillImagesInNode();

        }

        private void FncFillImagesInNode()
        {
            scnMsgAlbums.Text = "";
            scnMsgFolder.Text = "";
            scnMsgUpload.Text = "";
            scnImage1.ImageUrl = "";
            scnMsgFolder.Text = "";
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir,"");
            if (scnImageList.Items.Count > 0) scnImageList.Items[0].Selected = true;
            FncSelectImage();
            string szDirName = scnTreeView.SelectedNode.Value.ToString();
            //OnClientClick="return confirm('Are you sure !!!\n Do you want to delete SUB-folder:\nxxx?');" 
            //  RenameImageButton.OnClientClick = "var name = prompt('Enter new filename:','" + scnImageList.SelectedItem.Text.Substring(0, pos) + "'); if (name == null || name == '') return false; document.getElementById('" + NewImageName.ClientID + "').value = name + '" + scnImageList.SelectedItem.Text.Substring(pos) + "';";
            scnFolderSelected.Text = szDirName.Substring(szDirName.LastIndexOf('\\') + 1);
            if (scnTreeView.SelectedNode.Category != "Root")
            {
                scnBtnFolderDelete.Enabled = true;
                scnBtnFolderDelete.OnClientClick = "return confirm('DELETE !!!     Are you sure ?\\n\\nDo you want to delete the Folder: \\n\\n" + scnFolderSelected.Text + "?');";
            }
            else
            {
                scnBtnFolderDelete.Enabled = false;
                scnBtnFolderDelete.OnClientClick = "This is the root, I can't delete.";
            }

        }
        protected void BindImageList(string szDir,string szFilter)
        {
          if (SearchTerms.Text=="")  SearchTerms.Text = szFilter.Trim();
          if (szFilter == "") szFilter = SearchTerms.Text.Trim();
          szFilter = "*" + SearchTerms.Text.Replace(" ", "*") + "*";

            scnImageList.Items.Clear();
         
            
            
            string[] files = Directory.GetFiles(szDir,szFilter );
            files = Array.FindAll(files, delegate(string f) { return FncIsImage(f); });
            string szFile = "";
            foreach (string file in files)
            {
                szFile = file.Replace('/', '\\');
                if (FncIsImage(szFile))
                {
                    szFile = szFile.Substring(szFile.LastIndexOf('\\') + 1);

                    scnImageList.Items.Add(szFile);
                }
            }

            if (files.Length > 0)
                scnImageList.SelectedIndex = 0;
        }

        protected void Search(object sender, EventArgs e)
        {
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir,"");
            FncSelectImage();
        }
        protected void scnBtnSearchReset_Click(object sender, EventArgs e)
        {
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            SearchTerms.Text = "";

            BindImageList(szDir,"");
            FncSelectImage();
        }
        protected void SelectImage(object sender, EventArgs e)
        {
            FncSelectImage();
        }
        protected void FncSelectImage()
        {


            scnBtnDeleteImage.Enabled = (scnImageList.Items.Count != 0);
            //ResizeImageButton.Enabled = (scnImageList.Items.Count != 0);
            //ResizeWidth.Enabled = (scnImageList.Items.Count != 0);
            //ResizeHeight.Enabled = (scnImageList.Items.Count != 0);

            if (scnImageList.Items.Count == 0)
            {
                scnImage1.ImageUrl = "";
                //ResizeWidth.Text = "";
                //ResizeHeight.Text = "";
                return;
            }
            string sz = scnTreeView.SelectedNode.Value.ToString();

            string szImgPath = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString() + "\\" + scnImageList.SelectedValue;
            //string szImgPath = ClsGlobal.DirMultimediaUrlRootNode + scnTreeView.SelectedNode.Value.ToString() + "\\" + scnImageList.SelectedValue;
            szImgPath=szImgPath.Replace("\\","/").Replace ("//","/");
            
            scnImage1.ImageUrl = szImgPath + "?" + new Random().Next(1000);
            // Image1.ImageUrl = ImageFolder + ImageList.SelectedValue + "?" + new Random().Next(1000);
            string Url = szImgPath.Replace(ClsGlobal.DirRoot, "");
            if (!Url.StartsWith ("/")) Url ="/"+Url ;
            if (FncIsImage(szImgPath))
            {
                //clsImageMedia img = clsImageMedia.Create(File.ReadAllBytes(szImgPath));
                //ResizeWidth.Text = img.Width.ToString();
                //ResizeHeight.Text = img.Height.ToString();
                //ImageAspectRatio.Value = "" + img.Width / (float)img.Height;

                scnImage1.ImageUrl = Url;
            }
            else
            {
                scnImage1.ImageUrl = "";
            }
            // rellenar datos de base de datos

            oReg.FncClear();
            oReg.FncSqlFindURL(scnImage1.ImageUrl);
            FncScrennFromReg();
            FncRegFieldsShow();
            scnMediaUrl2.Text = Url;
            //scnMediaAuthor.Text = oReg.Autor;
            //scnMediaNotes.Text = oReg.Notes;
            //scnMediaTitle.Text = oReg.Title;
            //scnMediaSource.Text = oReg.Source ;
            //scnMediaDocId.Text = oReg.DocId.ToString();
            //scnMediaDate.Text = oReg.CreateDate.ToShortDateString();

            int pos = scnImageList.SelectedItem.Text.LastIndexOf('.');
            if (pos == -1)
                return;
            //RenameImageButton.OnClientClick = "var name = prompt('Enter new filename:','" + scnImageList.SelectedItem.Text.Substring(0, pos) + "'); if (name == null || name == '') return false; document.getElementById('" + scnNewImageName.ClientID + "').value = name + '" + scnImageList.SelectedItem.Text.Substring(pos) + "';";
            string sz2 = ""; ;
            sz2 += "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('";
            sz2 += scnImage1.ImageUrl.Replace("../", "/");

            //  sz2 += scnImageList.SelectedValue.Replace("'", "\\'"); 
            sz2 += "')); window.top.close(); window.top.opener.focus();";
            OkButton.OnClientClick = sz2;
            // OkButton.OnClientClick = "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('" + szImgPath + scnImageList.SelectedValue.Replace("'", "\\'") + "')); window.top.close(); window.top.opener.focus();";
            //   OkButton.OnClientClick = "window.top.opener.CKEDITOR.dialog.getCurrent().setValueOf('info', 'txtUrl', encodeURI('" + ImageFolder + ImageList.SelectedValue.Replace("'", "\\'") + "')); window.top.close(); window.top.opener.focus();";

            //scnMediaFieldsPannel.Visible = true;
            //scnBtnImageNew.Visible = true;
            //scnBtnDeleteImage.Visible = true;

        }

        protected void RenameImage(object sender, EventArgs e)
        {
            string szFolder = m_AlbumsRootPath + scnTreeView.SelectedNode.Value + "/";
            string filename = UniqueFilename(scnNewImageName.Value);
            try
            {
                File.Move(szFolder + scnImageList.SelectedValue, szFolder + filename);
            }
            catch (Exception xcpt)
            {
                scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                scnMsgUpload.Text = "Opps!" + xcpt.Message;
                ;
            }
            BindImageList(szFolder,"");
            SelectImage(null, null);
        }

        protected void DeleteImage(object sender, EventArgs e)
        {
            UInt64 id = Convert.ToUInt64(scnMediaDocId.Text.ToString());
            string idLng = scnMediaDocLngId.Text;
            if (id != 0)
            {
                oReg.FncSqlDelete(id, idLng);
                FncScrennFromReg();
            }
            string szFolder = m_AlbumsRootPath + scnTreeView.SelectedNode.Value + "/";
            File.Delete(szFolder + scnImageList.SelectedValue);
            string szDir = scnTreeView.SelectedNode.ToString();
            BindImageList(szFolder,"");
            SelectImage(null, null);



        }

        //protected void ResizeWidthChanged(object sender, EventArgs e)
        //{
        //    float ratio = clsUtil.Parse<float>(ImageAspectRatio.Value);
        //    int width = clsUtil.Parse<int>(ResizeWidth.Text);

        //    ResizeHeight.Text = "" + (int)(width / ratio);
        //}

        //protected void ResizeHeightChanged(object sender, EventArgs e)
        //{
        //    float ratio = clsUtil.Parse<float>(ImageAspectRatio.Value);
        //    int height = clsUtil.Parse<int>(ResizeHeight.Text);

        //    ResizeWidth.Text = "" + (int)(height * ratio);
        //}

        //protected void ResizeImage(object sender, EventArgs e)
        //{
        //    int width = clsUtil.Parse<int>(ResizeWidth.Text);
        //    int height = clsUtil.Parse<int>(ResizeHeight.Text);

        //    clsImageMedia img = clsImageMedia.Create(File.ReadAllBytes(FileImageFolder + scnImageList.SelectedValue));
        //    img.Resize(width, height);
        //    File.Delete(FileImageFolder + scnImageList.SelectedValue);
        //    File.WriteAllBytes(FileImageFolder + scnImageList.SelectedValue, img.ToByteArray());

        //    ResizeMessage.Text = "Image successfully resized!";
        //    SelectImage(null, null);
        //}
        protected void scnBtnSave_Click(object sender, EventArgs e)
        {
            scnMsgUpload.Text = "";
            bool bError = false;
            string szError = "";
            // validar campos.
            // Eliminar blancos sobrantes.
            scnMediaUrl2.Text = scnMediaUrl2.Text.Trim();
            scnMediaTitle.Text = scnMediaTitle.Text.Trim();
            scnMediaAuthor.Text = scnMediaAuthor.Text.Trim();
            scnMediaSource.Text = scnMediaSource.Text.Trim();
            scnMediaNotes.Text = scnMediaNotes.Text.Trim();
            // UploadedImageFile.FileName = UploadedImageFile.FileName.Trim();
            // Comprobar campos.
            //
            if (scnMediaTitle.Text.Length < 5)
            {
                bError = true;
                szError += "Title is empty  or too short<br/>";
            }
            if (scnMediaAuthor.Text.Length < 5)
            {
                bError = true;
                szError += "Author is empty or too short<br/>";
            }
            if (scnMediaSource.Text.Length < 5)
            {
                bError = true;
                szError += "Source is empty or too short<br/>";
            }
            if (scnMediaDate.Text == "")
            {
                bError = true;
                szError += "Date is empty<br/>";
            }

            if (scnMediaUrl2.Text == "")
            {
                if (!FncIsImage(UploadedImageFile.FileName) || UploadedImageFile.FileName == "")
                {
                    bError = true;
                    szError += "Please select the file to upload<br/>";
                }
            }
            if (bError)
            {
                scnMsgUpload.Text = szError;
                scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                return;
            }
            // guardar
            // guardar en base de datos

            oReg.DocId = Convert.ToUInt64(scnMediaDocId.Text);

            oReg.Source = UploadedImageFile.FileName;
            oReg.URL = scnMediaUrl2.Text;
            oReg.DocLngId = scnMediaDocLngId.Text;

            oReg.Author = scnMediaAuthor.Text;
            oReg.Notes = scnMediaNotes.Text;

            oReg.Title = scnMediaTitle.Text;
            oReg.FileNameOnSource = scnMediaTitle.Text;
            oReg.CreateGeoGPS = "";


            oReg.IsDownloadable = true;
            oReg.IsGalleryVisible = true;
            oReg.IsVisible = true;
            oReg.CreateGeoLocation = "";
            oReg.LogFromDate = Convert.ToDateTime(scnMediaDate.Text);
            oReg.LogFromIp = Request.UserHostAddress;
            //  oReg.Type = "";
            oReg.Source = scnMediaSource.Text;
            if (!oReg.FncSqlSave("media"))
             
            {
                bError = true;
                szError += "Error, don't saved, <br/>"+oReg.ErrorString;
                return;
            }
            else
            {
                scnMediaDocId.Text = oReg.DocId.ToString();
                scnMediaFieldsPannel.Visible = true;
                scnBtnImageNew.Visible = true;
                scnBtnDeleteImage.Visible = true;
                scnMsgUpload.Text = "";
                scnImgDBStatus.ImageUrl = m_img_ddbb_ok;
                if (FncIsThumbnail(scnMediaUrl2.Text))
                {
                    scnBtnImageThumb.Visible = false;
                    scnBtnImageThumbOverwrite.Visible = false;
                }
                else
                {
                    scnBtnImageThumb.Visible = true;
                    scnBtnImageThumbOverwrite.Visible = true;
                }
            }
          
        }
        protected void scnBtnImageNew_Click(object sender, EventArgs e)
        {

            FncRegFieldsHide();
        }
        private void FncRegFieldsHide()
        { // Si hay seleccionada una imagen quitar
            oReg.FncClear();
            FncScrennFromReg();
            scnMsgUpload.Text = "";
            scnImageList.ClearSelection();
            scnImage1.ImageUrl = "";
            scnMediaFieldsPannel.Visible = false;
            scnBtnImageThumb.Visible = false;
             scnBtnImageThumbOverwrite.Visible = false;
           
            scnBtnDeleteImage.Visible = false;
            scnBtnImageNew.Visible = false;
            scnBtnSave.Visible = false;
            UploadButton.Visible = true;
            UploadedImageFile.Visible = true;
            scnPnlUpload.Visible = true;
        }
        private void FncRegFieldsShow()
        { // Si hay seleccionada una imagen quitar
            //oReg.FncClear();
            //FncScrennFromReg();
            scnMsgUpload.Text = "";
            scnMsgFolder.Text = "";
            scnMediaFieldsPannel.Visible = true;

            scnBtnDeleteImage.Visible = true;
            scnBtnImageNew.Visible = true;
            scnBtnSave.Visible = true;
            UploadButton.Visible = false;
            UploadedImageFile.Visible = false;
            scnPnlUpload.Visible = false;

        }
        private void FncScrennFromReg()
        {
            scnMediaDate.Text = oReg.CreateDate.ToShortDateString();
            scnMediaDocId.Text = oReg.DocId.ToString();
            scnMediaDocLngId.Text = oReg.DocLngId;
            scnMediaAuthor.Text = oReg.Author;
            scnMediaNotes.Text = oReg.Notes;
            scnMediaSource.Text = oReg.Source;
            scnMediaTitle.Text = oReg.Title;
            scnMediaUrl2.Text = oReg.URL;
            if (oReg.DocId != 0)
            {
                scnImgDBStatus.ImageUrl = m_img_ddbb_ok; // "/a_img/a_site/ico16/ico-doc-ok-c.png";
                scnImgDBStatus.ToolTip = "In database";
                if (FncIsThumbnail(scnMediaUrl2.Text))
                {
                    scnBtnImageThumb.Visible = false;
                    scnBtnImageThumbOverwrite.Visible = false;
                }
                else
                { scnBtnImageThumb.Visible = true;
                scnBtnImageThumbOverwrite.Visible = true;
                }
            }
            else
            {
                scnImgDBStatus.ImageUrl = m_img_ddbb_false;//=  "/a_img/a_site/ico16/ico-alert-yelow.png";
                scnImgDBStatus.ToolTip = "Not in database";
                scnBtnImageThumb.Visible = false;
                scnBtnImageThumbOverwrite.Visible = false;

            }


        }
        protected void scnBtnUpload(object sender, EventArgs e)
        {
            scnMsgUpload.Text = "";
            //bool bError = false;
            //string szError = "";
            if (!UploadedImageFile.HasFile || !FncIsImage(UploadedImageFile.FileName))
            {
                scnMsgUpload.ForeColor = System.Drawing.Color.Red;
                scnMsgUpload.Text = "Please, Select one image file (jpg,png,gif)";
                return;

            }

            // si existe un fichero con el mismo nombre le añadimos un numerador de version
            // para evitar sobreescribir.
            string filename = cls.ClsUtils.FncPathFileNameNormalice(UniqueFilename(UploadedImageFile.FileName));
            string szUrl = ClsGlobal.UrlMMedia + scnTreeView.SelectedNode.Value.Replace("\\", "/") + "/" + filename;
            string szDirTarget = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.Replace("/", "\\") + "/" + filename;
            oReg.URL = UploadedImageFile.FileName;
            // UploadedImageFile.SaveAs(FileImageFolder + filename);

            UploadedImageFile.SaveAs(szDirTarget);
            //byte[] data = clsImageMedia.Create(UploadedImageFile.FileBytes).Resize(960, null).ToByteArray();
            //FileStream file = File.Create(szDirTarget);
            //file.Write(data, 0, data.Length);
            //file.Close();
            string szDir = m_AlbumsRootPath + "/" + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir,"");




            //----------------
            scnMediaDocId.Text = oReg.DocId.ToString();
            try
            {
                scnImageList.SelectedValue = filename;

            }
            catch { ; }
            SelectImage(null, null);
        }

        protected void Clear(object sender, EventArgs e)
        {
            Session.Remove("viewstate");
        }

        //util methods
        //private bool IsValidfile(string file)
        //{
        //    return file.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
        //        file.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
        //        file.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase)||
        //    file.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase);
        //}
        private bool FncIsImage(string file)
        {
            return file.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase);

        }

        protected string UniqueFilename(string filename)
        {
            string newfilename = filename;

            for (int i = 1; File.Exists(m_AlbumsRootPath + "/" + scnTreeView.SelectedNode.Value + "\\" + newfilename); i++)
            {
                newfilename = filename.Insert(filename.LastIndexOf('.'), "(" + i + ")");
            }
            newfilename = cls.ClsUtils.FncPathFileNameNormalice(newfilename);
            return newfilename;
        }

        protected string UniqueDirectory(string directoryname)
        {
            string newdirectoryname = directoryname;

            for (int i = 1; Directory.Exists(FileImageFolderRoot + newdirectoryname); i++)
            {
                newdirectoryname = directoryname + "(" + i + ")";
            }

            return newdirectoryname;
        }

        //properties
        protected string PathMMediaRoot
        {
            get { return ClsGlobal.UrlMMedia; }
            // get { return ResolveUrl(ConfigurationManager.AppSettings["PathMMediaRoot"]); }
        }

        protected string FileImageFolderRoot
        {
            get { return ClsGlobal.UrlMMedia; }
            //get { return Server.MapPath(PathMMediaRoot); }
        }

        protected string ImageFolder
        {
            get { return PathMMediaRoot + ViewState["folder"]; }
            set { ViewState["folder"] = value; }
        }

        protected string FileImageFolder
        {
            get { return ClsGlobal.DirMMedia; }
            //  get { return Server.MapPath(ImageFolder); }
        }



        protected void scnBtnFolderNew_Click(object sender, EventArgs e)
        {
            scnFolderNewName.Text = cls.ClsUtils.FncPathFileNameNormalice(scnFolderNewName.Text);

            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value + "/" + scnFolderNewName.Text;
            if (!System.IO.Directory.Exists(szDir))
            {
                System.IO.Directory.CreateDirectory(szDir);
                //string szRootMM = Server.MapPath("~") + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();
                FncBindTreeToDirectoryRoot();
                scnFolderSelected.Text = "";
                scnFolderNewName.Text = "";
                oReg.FncClear();
                FncScrennFromReg();
                FncRegFieldsHide();
                scnMsgFolder.Text = "Folder created";
            }
        }
        protected void scnBtnFolderDelete_Click(object sender, EventArgs e)
        {
            scnMsgFolder.Visible = false;
            scnMsgFolder.Text = "";
            // evitar borrar desde aqui el nodo raiz del album
            if (scnTreeView.SelectedNode.Category == "Root")
            {
                scnMsgFolder.Text = "Can't delete Root Album";
                return;
            }

            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value;
            string szDirUrl = (ClsGlobal.UrlMMedia + scnTreeView.SelectedNode.Value).Replace("\\", "/");
            if (System.IO.Directory.Exists(szDir))
            {
                if (oReg.FncSqlDelete_URL(szDirUrl))
                {
                    System.IO.Directory.Delete(szDir, true);
                    oReg.FncSqlDelete_URL(szDirUrl);
                    //string szRootMM = m_AlbumsRootPath + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();
                    scnFolderSelected.Text = "";
                    FncBindTreeToDirectoryRoot();
                    FncFillImagesInNode();
                    oReg.FncClear();
                    FncScrennFromReg();
                    scnMsgFolder.Visible = true;
                    scnMsgFolder.Text = "Deleted";
                }
            }
        }

        protected void scnBtnNewAlbum_Click1(object sender, EventArgs e)
        {
            //        string szRootMM = m_AlbumsRootPath + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();

            string name = cls.ClsUtils.FncPathFileNameNormalice(scnNewAlbumName.Value);
            string szNewAlbum = ClsGlobal.DirMMedia + "\\" + name;
            if (!System.IO.Directory.Exists(szNewAlbum))
            {
                System.IO.Directory.CreateDirectory(szNewAlbum);
                scnAlbumDirectoryList.Items.Add(name);
                FncBindAlbumDirectoryList();
                scnAlbumDirectoryList.SelectedValue = name;
                FncBindTreeToDirectoryRoot();
                FncFillImagesInNode();
                oReg.FncClear();
                FncScrennFromReg();
                FncRegFieldsHide();
                scnBtnDeleteAlbum.OnClientClick = "return confirm('Are you sure !\\n Do you want to delete the Album\\n" + scnAlbumDirectoryList.SelectedValue + "\\n and all its contents?');";
            }

        }


        protected void scnBtnDeleteAlbum_Click(object sender, EventArgs e)
        {
            scnMsgAlbums.Visible = false;
            scnMsgAlbums.Text = "";
            //string szRootMM2 = 
            //string szRootMM = m_AlbumsRootPath + ConfigurationManager.AppSettings["PathMMediaRoot"].ToString();




            string szDir = ClsGlobal.DirMMedia + "\\" + scnAlbumDirectoryList.SelectedValue;
            string szAlbunUrl = ClsGlobal.UrlMMedia + scnAlbumDirectoryList.SelectedValue.Replace("\\", "/");
            try
            {
                if (oReg.FncSqlDelete_URL(szAlbunUrl))
                {
                    System.IO.Directory.Delete(szDir, true);
                    scnMsgAlbums.Visible = true;
                    scnMsgAlbums.Text = "Album Deleted";
                    oReg.FncClear();
                    FncScrennFromReg();
                    FncRegFieldsHide();
                }

            }
            catch (Exception xcpt)
            {
                scnMsgAlbums.Text = xcpt.Message;
            }
            FncBindAlbumDirectoryList();
            FncBindTreeToDirectoryRoot();


        }

        protected void scnBtnTestudinesAutor_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaAuthor.Text = ClsGlobal.defaultAuthorsite;
        }

        protected void scnBtnTestudinesSource_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaSource.Text = ClsGlobal.defaultSiteName;
        }

        protected void scnBtnTestudinesAutor0_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaTitle.Text = scnMediaUrl2.Text;
        }

        protected void scnBtnSourceWikipedia_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaSource.Text = "www.wikipedia.org";
        }

        protected void scnBtnSourceClear_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaSource.Text = "";
        }

        protected void scnBtnAutorClear_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaAuthor.Text = "";
        }

        protected void scnBtnTitleClear_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaTitle.Text = "";
        }


        private string FncUrlFromFullPath(string szFulPath)
        {

            szFulPath = szFulPath.Replace("\\", "/").ToLower(); ;
            string szRootPaht = ClsGlobal.UrlMMedia.ToLower().Replace("\\", "/");
            string sz = szFulPath.Replace(szRootPaht, "");
            if (!sz.StartsWith("/")) sz = "/" + sz;
            sz = sz.Replace("//", "/");
            return sz;
        }

        private bool FncIsThumbnail(string szFile)
        {
            bool bTnumbnail = false;
            if (scnMediaUrl2.Text.EndsWith("_min.jpg")) bTnumbnail = true;
            if (scnMediaUrl2.Text.EndsWith("_med.jpg")) bTnumbnail = true;
            if (scnMediaUrl2.Text.EndsWith("_minx.jpg")) bTnumbnail = true;
            if (scnMediaUrl2.Text.EndsWith("_ful.jpg")) bTnumbnail = true;
            return bTnumbnail;
        }
        protected void scnBtnTestudinesAutorVniclos_Click(object sender, ImageClickEventArgs e)
        {
            scnMediaAuthor.Text = ClsGlobal.defaultVNiclos;
        }
        protected void scnBtnDocCopy_Click(object sender, ImageClickEventArgs e)
        {
            FncClipCopy();
        }

        protected void scnBtnDocPaste_Click(object sender, ImageClickEventArgs e)
        {
            FncClipPaste();
        }
        private void FncClipCopy()
        {
            scnclipboard.Value = scnMediaTitle.Text.Trim() + "|" +
            scnMediaAuthor.Text.Trim() + "|" +
            scnMediaSource.Text.Trim() + "|" +
            scnMediaDate.Text.Trim() + "|" +
            scnMediaNotes.Text.Trim();
        }
        private void FncClipPaste()
        {
            string[] szValues = scnclipboard.Value.Split('|');
            scnMediaTitle.Text = szValues[0];
            scnMediaAuthor.Text = szValues[1];
            scnMediaSource.Text = szValues[2];
            scnMediaDate.Text = szValues[3];
            scnMediaNotes.Text = szValues[4];

        }

       
        protected void scnBtnImageThumb_Click1(object sender, EventArgs e)
        {
            string szMaskUrl = "media";
            string szUrl = "";
            scnMsgBldTumbnail.Visible = true; // false;
            scnMsgBldTumbnail.Text = "";
            string szItem = "";
            scnMediaUrl2.Text = scnMediaUrl2.Text.ToLower().Trim();
            string szLin1 = scnMediaTitle.Text.Trim();
            string szLin2 = scnMediaAuthor.Text.Trim();
            string szLin3 = scnMediaSource.Text.Trim();
            string szLoc = scnMediaNotes.Text.Trim();
            string szFileNameSrc = (ClsGlobal.DirMMedia + scnMediaUrl2.Text.Replace("/", "\\")).Replace("\\\\", "\\");


            string szPathTarget = (ClsGlobal.DirMMedia + "\\" + scnTreeView.SelectedNode.Value).Replace("/", "\\");

            //Debug logical errors

            bool bError = false;
            string szError = "<br/>";

            // no tratar una imagen ya tratada;

            if (FncIsThumbnail(scnMediaUrl2.Text))
            {
                bError = true;

                szError += "This image has been miniaturized<br/>";
            }

            if (scnMediaDocId.Text == "0")
            {
                bError = true;
                szError += "Please, save this image before built thumbnails<br />";

            }
            if (szLin1 == "")
            {
                bError = true;
                szError += "Title empty<br />";

            }
            if (szLin2 == "")
            {
                bError = true;
                szError += "Author empty<br />";

            }
            if (szLin3 == "")
            {
                bError = true;
                szError += "Source empty<br />";

            }
            if (szFileNameSrc == "")
            {
                bError = true;
                szError += "File don't select<br />";

            }
            if (!System.IO.File.Exists(szFileNameSrc))
            {
                bError = true;
                szError += "File don't exist<br />";

            }
            if (!System.IO.Directory.Exists(szPathTarget))
            {
                bError = true;
                szError += "Directory target not exist<br />";

            }
            if (bError)
            {
                scnMsgBldTumbnail.Visible = true;
                scnMsgBldTumbnail.Text = szError;
                return;
            }
            cls.clsImgTool oImgTool = new clsImgTool(ClsGlobal.DirRoot + "a_img\\a_app\\");

            oImgTool.FncBldImgs(szLin1, szLin2, szLin3,szLoc, "000", szItem, szFileNameSrc, szPathTarget,scnBtnImageThumbOverwrite.Checked );
            cls.bbdd.ClsReg_tdoclng_media oNewMedia = new testudines.cls.bbdd.ClsReg_tdoclng_media();

            szUrl = "" + FncUrlFromFullPath(oImgTool.FileFulnameFul);
            oReg.FncSqlFind(Convert.ToUInt64(scnMediaDocId.Text), scnMediaDocLngId.Text);
            oNewMedia = oReg;
            oNewMedia.DocId = 0;
            oNewMedia.URL = szUrl;
            oNewMedia.FncSqlSave(szMaskUrl);


            szUrl = "" + FncUrlFromFullPath(oImgTool.FileFulnameMed);
            oNewMedia.DocId = 0;
            oNewMedia.URL = szUrl;
            oNewMedia.FncSqlSave(szMaskUrl);

            szUrl = "" + FncUrlFromFullPath(oImgTool.FileFulnameMin);
            oNewMedia.DocId = 0;
            oNewMedia.URL = szUrl;
            oNewMedia.FncSqlSave(szMaskUrl);

            szUrl = "" + FncUrlFromFullPath(oImgTool.FileFulnameMinX);
            oNewMedia.DocId = 0;
            oNewMedia.URL = szUrl;
            oNewMedia.FncSqlSave(szMaskUrl);
            FncFillImagesInNode();
        }

        protected void SearchMinx(object sender, EventArgs e)
        {
            string szFilter = "minx.jpg";
            SearchTerms.Text = szFilter;
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir,szFilter);
            FncSelectImage();
        }

        protected void SearchMin(object sender, EventArgs e)
        {
            string szFilter = "min.jpg";
            SearchTerms.Text = szFilter;
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir, szFilter);
            FncSelectImage();
        }

        protected void SearchMed(object sender, EventArgs e)
        {
            string szFilter = "med.jpg";
            SearchTerms.Text = szFilter;
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir, szFilter);
            FncSelectImage();
        }

        protected void SearchFul(object sender, EventArgs e)
        {
            string szFilter = "ful.jpg";
            SearchTerms.Text = szFilter;
            string szDir = m_AlbumsRootPath + scnTreeView.SelectedNode.Value.ToString();
            BindImageList(szDir, szFilter);
            FncSelectImage();
        }



    }
}

