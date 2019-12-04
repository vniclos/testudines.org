using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.WebControls;
using System.IO;
using System.Data;

namespace testudines.images
{
    public partial class images : cls.ClsPageBase
    {

        private Int32 m_iTreeLevelNode = 0;
       
        private string m_SqlSelect = "";
        private string m_ServerRoot = "";
        private string m_AlbumsRootPath = "";
        private string m_AlbumSelected = "";
        //private string m_AlbumsRootPathRequest = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string sz = "";
            m_ServerRoot = Server.MapPath("~");
            m_AlbumsRootPath = cls.ClsGlobal.DirMMedia;

            //....... if (!IsPostBack) FncFillData();
            if (!IsPostBack)
            {

                //-------------------------
                // MPageBoxMsgClear();
                //MPagePnlVisible = false;
               String  szRequestGallery = "articles/biology/anatomy/diagrams";
                if (Request.QueryString["gal"] != null)
                {
                    szRequestGallery= Request.QueryString["gal"];
                }

                  
                    scnUrlRequest.Value = szRequestGallery ;
                  
                    string[] szDirs = scnUrlRequest.Value.Split('/');
                    m_AlbumSelected = szDirs[1];
                    m_AlbumsRootPath = m_AlbumsRootPath + "/" + sz + "/";
               
                
                fndBindAlbumDirectoryList();
                FncBindTreeToDirectoryRoot();
                FncFillData();
                FncStadisticVisitAdd("", "");
                FncBldBreadCrumb();

            }
        }


        private void fndBindAlbumDirectoryList()
        {
            string szAlbumsRoot = cls.ClsGlobal.DirMMedia;
            //DirectoryInfo di = new DirectoryInfo(m_AlbumsRootPath);
            DirectoryInfo di = new DirectoryInfo(szAlbumsRoot);

            scnAlbumDirectoryList.Items.Clear();
            string szName = "";
            foreach (DirectoryInfo diDir in di.GetDirectories())
            {
                scnAlbumDirectoryList.Items.Add(new ListItem(diDir.Name));
                szName = diDir.Name.ToLower().Trim();
                if (szName == m_SqlSelect)
                {
                    scnAlbumDirectoryList.Items[scnAlbumDirectoryList.Items.Count - 1].Selected = true;
                }
            }

            if (scnAlbumDirectoryList.Items.Count > 0) scnAlbumDirectoryList.SelectedIndex = 0;
            ;
        }
        private void FncStadisticVisitAdd(string szSelectedAlbum, string szSelectNode)
        {
            cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
            oRegDoc.DocId = 0;

            string szUrlReferrer = "null";
            if (Request.UrlReferrer != null)
            {
                szUrlReferrer = Request.UrlReferrer.ToString();
            }

           // oRegDoc.FncStdVisitAddCount("media", MPageDocLngId, Session.SessionID, oSession.IdLoginName, Request.UserHostAddress, szUrlReferrer, Request.Url.ToString(), "list " + szSelectNode, Request.UserAgent);

        }

        private void FncBldBreadCrumb()
        {
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.images, "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Page_FncBreadCrumb(ref szBreadCrumb);
        }

        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            FncFillData();
        }
        private void FncFillData()
        {
            string szDir = "";
            if (scnUrlRequest.Value != "")
            {

                szDir = cls.ClsGlobal.DirMMedia + scnUrlRequest.Value;
                scnGalleryNodePath.Text = scnUrlRequest.Value;
            }
            else
            {
                szDir = cls.ClsGlobal.DirMMedia + "/" + scnAlbumDirectoryList.SelectedValue;
            }

            DirectoryInfo oDi = new DirectoryInfo(szDir);
            DataTable oTb = new DataTable();
            oTb.Columns.Add("UrlFile");
            oTb.Columns.Add("UrlFileTarget");
            oTb.Columns.Add("Title");
            string szUrl = "";
            string szUrlFileTarget = "";
            string szTitle = "";
            string szDirWebRoot = cls.ClsGlobal.DirRoot.ToLower();
            string szPathBig = "";
            foreach (FileInfo oFi in oDi.GetFiles("*minx.jpg"))
            {
                DataRow oRow = oTb.NewRow();
                szUrl = oFi.FullName.ToLower().Replace("\\", "/");

                if (szUrl.EndsWith("minx.jpg"))
                {

                    szUrl = szUrl.Replace(szDirWebRoot, "");
                    if (!szUrl.StartsWith("/")) szUrl = "/" + szUrl;
                    szUrlFileTarget = szUrl.Replace("minx.jpg", "med.jpg");

                    szPathBig = oFi.FullName.Replace("minx.jpg","big.jpg");
                    /*
                    if (System.IO.File.Exists(szPathBig))
                    {
                        szUrlFileTarget = szUrl.Replace("minx.jpg", "big.jpg");
                    }
                    
                    */
                
                    szTitle = oFi.Name.Replace("_", " ").ToLower();
                    szTitle = szTitle.Replace("-", " ").ToLower();
                    szTitle = szTitle.Replace("minx.jpg", "");

                    oRow[0] = szUrl;
                    oRow[1] = szUrlFileTarget;
                    oRow[2] = szTitle;
                    oTb.Rows.Add(oRow);
                }
            }
            ListView2.DataSource = oTb;
            ListView2.DataBind();
        }
        protected void scnAlbumDirectoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FncBindTreeToDirectoryRoot();
            scnUrlRequest.Value = "/" + scnAlbumDirectoryList.SelectedValue;
            FncFillData();

        }
        private void FncBindTreeToDirectoryRoot()
        {
            scnTreeView.Nodes.Clear();
            if (scnAlbumDirectoryList.SelectedValue == null) return;
            RadTreeNode rootNode = new RadTreeNode(scnAlbumDirectoryList.SelectedValue);
            rootNode.Image = "Folder.gif";
            rootNode.Category = "Root";
            rootNode.Expanded = true;
            rootNode.Value = "\\" + scnAlbumDirectoryList.SelectedValue;

            scnTreeView.AddNode(rootNode);

            FncBindTreeToDirectory(m_AlbumsRootPath + "\\" + scnAlbumDirectoryList.SelectedValue, rootNode);
            scnTreeView.Nodes[0].Selected = true;

        }
        private void FncBindTreeToDirectory(string dirPath, RadTreeNode parentNode)
        {
            m_iTreeLevelNode++;
            bool bExpanded = true;
            if (m_iTreeLevelNode > 4) bExpanded = false;
            if (dirPath.Contains("_thumbna")) return;
            dirPath = dirPath.Replace("\\", "/");
            dirPath = dirPath.Replace("//", "/");
            string[] dirs = Directory.GetDirectories(dirPath);
            foreach (string s in dirs)
            {
                string[] parts = s.Split('\\');
                string name = parts[parts.Length - 1];
                RadTreeNode node = new RadTreeNode(name);
                if (name.Contains("_thumbna")) return;
                node.Image = "Folder.gif";
                node.Text = name;
                node.Value = dirPath.Replace(m_AlbumsRootPath, "") + "\\" + name;
                node.ContextMenuName = "ContextMenus.xml";
                node.Category = "Folder";
                parentNode.AddNode(node);
                node.Expanded = bExpanded;
                FncBindTreeToDirectory(s, node);
            }


        }
        protected void scnTreeView_NodeClick(object o, RadTreeNodeEventArgs e)
        {
            string sz = scnTreeView.SelectedNode.Value.ToString().ToLower();

            sz = sz.Replace("\\", "/");
            sz = sz.Replace("//", "/");
            string szRemove = cls.ClsGlobal.DirMMedia.ToLower().Replace("\\", "/");
            sz = sz.Replace(szRemove, "");
            string szUrl = "/images/images.aspx?gal=" + sz;
            Response.Redirect(szUrl);
            // FncFillGallery();
        }
        private bool FncIsImage(string file)
        {
            return file.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) ||
                file.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase);

        }

    }
}
