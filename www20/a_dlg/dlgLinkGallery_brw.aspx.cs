using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using testudines.cls;
using System.IO ;
using Telerik.WebControls; 
 
namespace testudines.ckeditor
{
    public partial class dlgLinkGallery_brw : System.Web.UI.Page
    {
        private cls.bbdd.ClsReg_tdoclng_media oReg = new testudines.cls.bbdd.ClsReg_tdoclng_media();
    private string m_ServerRoot = "";
    private string m_AlbumsRootPath = "";
      protected void Page_Load(object sender, EventArgs e)
        {
            m_ServerRoot = Server.MapPath("~");
            m_AlbumsRootPath = ClsGlobal.DirMMedia;

            if (!Page.IsPostBack)
            {
                 scnFolderSelected.Text = "";

                //scnReturToIdField.Text= Request.QueryString["scnAUrlImagesTxtId"];
                //dlgLinkGallery_brw.aspx?scnAUrlImagesTxtId=cphContent_tbContainer_scnTabDng_scnAUrlImagesTxt2_scnAUrlImagesTxt
                FncBindAlbumDirectoryList();
                FncBindTreeToDirectoryRoot();
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "FocusImageList", "window.setTimeout(\"document.getElementById('" + scnFolderSelected.ClientID + "').focus();\", 1);", true);
        }
    private void FncBindAlbumDirectoryList()
    {
        scnFolderSelected.Text = "";
        DirectoryInfo di = new DirectoryInfo(m_AlbumsRootPath );
        scnAlbumDirectoryList.Items.Clear(); 
        foreach (DirectoryInfo diDir in di.GetDirectories())
        {
            scnAlbumDirectoryList.Items.Add( diDir.Name);

           
        }
        if (scnAlbumDirectoryList.Items.Count > 0) scnAlbumDirectoryList.SelectedIndex = 0;
        ;}
    protected void scnAlbumDirectoryList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FncBindTreeToDirectoryRoot();
       // FncFillImagesInNode(); 
    
    }
    private void FncBindTreeToDirectoryRoot()
    {
        scnFolderSelected.Text = "";
        scnFolderSelected.Text = "";
        scnTreeView.Nodes.Clear();
        if (scnAlbumDirectoryList.SelectedValue == null) return;
        RadTreeNode rootNode = new RadTreeNode(scnAlbumDirectoryList.SelectedValue);
        rootNode.Image = "Folder.gif";
        rootNode.Category = "Root";
        rootNode.Expanded = true;
        rootNode.Value = "\\"+scnAlbumDirectoryList.SelectedValue;
        oReg.FncClear();
      
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
            parentNode.AddNode(node);
            if (parentNode.Nodes.Count>1)
            {node.Expanded =  false; }
            else {node.Expanded =  true ;}
            FncBindTreeToDirectory(s, node);
        }

       
    }

    protected void scnTreeView_NodeClick(object o, RadTreeNodeEventArgs e)
    {
        string szDir = (scnTreeView.SelectedNode.Value.ToString()).ToLower().Replace ("\\","/") ;
        scnFolderSelected.Text = szDir;
      
       // FncFillImagesInNode();

    }





   
   
    //properties
    protected string PathMMediaRoot
    {
        get { return ClsGlobal.UrlMMedia; }
       // get { return ResolveUrl(ConfigurationManager.AppSettings["PathMMediaRoot"]); }
    }

    protected string FileImageFolderRoot
    {
        get { return ClsGlobal.DirMMedia; }
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
  


           private string FncUrlFromFullPath(string szFulPath)
        {

            szFulPath = szFulPath.Replace("\\", "/").ToLower(); ;
            //string szRootPaht = ClsGlobal.DirMultimediaUrlRootPath.ToLower().Replace("\\", "/");
            string szRootPaht = ClsGlobal.UrlMMedia.ToLower().Replace("\\", "/");
            string sz = szFulPath.Replace(szRootPaht, "");
            if (!sz.StartsWith ("/")) sz="/"+sz;
            sz = sz.Replace("//", "/");
            return sz;
        }

   
        

   
}
    }

