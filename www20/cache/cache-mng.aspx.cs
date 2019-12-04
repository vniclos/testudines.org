using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using Telerik.WebControls;
using System.Net;
using System.IO;
namespace testudines.cache
{
    public partial class cache_mng : System.Web.UI.Page
    {
        private string m_msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FncFillComboTortoises();
            }
        }

        protected void scnBtnNotices_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoclng_notices oNotice = new cls.bbdd.ClsReg_tdoclng_notices();
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_notices();
            scnLog.Text += "<h2>Last Notices</h2>";
            scnLog.Text += oNotice.FncHtmlLastnotices(true, 20);
            scnMsg.Text = "Done notices";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnArticles_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoclng_articles oArticle = new cls.bbdd.ClsReg_tdoclng_articles();
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_articles();
            scnLog.Text += "<h2>Last articles</h2>";
            scnLog.Text+= oArticle.FncCache_GET_last(true, 20);
            scnMsg.Text = "Done Articles";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnFoods_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoclng_foods oFoods= new cls.bbdd.ClsReg_tdoclng_foods();
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_foods();
            scnLog.Text += "<h2>Last Foods</h2>";
            scnLog.Text += oFoods.FncCache_GET_last(true, 10);
            scnMsg.Text = "Done Foods";
            scnLoading.Style["display"] = "none";
          
        }

        protected void scnBtnTortoises_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            UInt64 IdUpperThan = 0;
            IdUpperThan= Convert.ToUInt64(scnIdUpperThan.Text);
            scnLog.Text = FncCache_bld_tortoises(IdUpperThan);
            scnMsg.Text = "Done tortoises";
            scnLoading.Style["display"] = "none";

        }

        protected void scnBtnTortoisesKeys_Click(object sender, EventArgs e)
        {

            scnMsg.Text = "Pendiente de desarrollo";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnTortoisesAppendix_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "Pendiente de desarrollo";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnTortoisesGallery_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_Gallery();
            scnMsg.Text = "Done images";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnSiteMap_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            FncRebuidSiteMap();
            scnMsg.Text = "Done sitemap";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnTaxonomy_Click(object sender, EventArgs e)
        {
            FncTaxonomytrees();
           
        }

        protected void scnBtnTtreeDLDT_Click(object sender, EventArgs e)
        {
            FncTaxonomytreesDLDT();
                 scnMsg.Text = "done Trees taxonomy and species";
            scnLoading.Style["display"] = "none";
        }


        protected void scnBtnMenus_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            
            scnLog.Text = FncFncBldMenus();
            scnMsg.Text = "Done Menus";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnAck_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_acknowledgment();
            scnMsg.Text = "Done acknoelegments";
            scnLoading.Style["display"] = "none";
        }
        protected void scnBtnBibl_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_bibliography();
            scnMsg.Text = "Done Bibliography";
            scnLoading.Style["display"] = "none";
        }
        private String FncFncBldMenus()
        {
            cls.cache.ClsCache_Menu.FncHtmlMenu(true, "es");
            cls.cache.clsCache_MenuAdmin.FncHtmlMenu(true, "es");
            cls.cache.ClsCache_Menu.FncHtmlMenu(true, "en");
            cls.cache.clsCache_MenuAdmin.FncHtmlMenu(true, "en");
            return "<h2>Menus rebuilded</h2><ul><li>Menu es rebuided</li><li>Menu en rebuilded</li><li>Menu Admin rebuilded</li></ul>";
        }





        private String FncCache_bld_notices()
        {
            String szTable = "tdoclng_notices";
            cls.bbdd.ClsReg_tdoclng_notices oDocLng = new cls.bbdd.ClsReg_tdoclng_notices();

            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h2>Notices chache rebuilded<h2><ul>";
            UInt32 uiCount = 0;
            foreach (DataRow oRow in oTable.Rows)
            {
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();

                oDocLng.FncSqlFind(docId, docLngId);
                oDocLng.FncGetCache_Html(true);
                uiCount++;
                szHtml += "\n<li>" + uiCount.ToString() + "--" + docId.ToString() + "-" + docLngId + " " + oDocLng.Title + "</li>";


            }
            szHtml += "<ul>";
            oDocLng.FncCache_GET_lastImg(true, 20);
            return szHtml;
          


        }

        private String FncCache_bld_articles()
        {
            String szTable = "tdoclng_articles";
            cls.bbdd.ClsReg_tdoclng_articles oDocLng = new cls.bbdd.ClsReg_tdoclng_articles();

            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h2>Articles chache rebuilded<h2><ul>";
            UInt32 uiCount = 0;
            foreach (DataRow oRow in oTable.Rows)
            {
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();

                oDocLng.FncSqlFind(docId, docLngId);
                oDocLng.FncGetCache_Html(true);
                uiCount++;
                szHtml += "\n<li>" + uiCount.ToString() + "--" + docId.ToString() + "-" + docLngId + " " + oDocLng.Title + "</li>";


            }
            szHtml += "<ul>";
            oDocLng.FncCache_GET_last(true, 20);
            return szHtml;


        }
        private String FncCache_bld_foods()
        {
            String szTable = "tdoclng_foods";
            cls.bbdd.ClsReg_tdoclng_foods oDocLng = new cls.bbdd.ClsReg_tdoclng_foods();

            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h2>Foods chache rebuilded<h2><ul>";
            UInt32 uiCount = 0;
            foreach (DataRow oRow in oTable.Rows)
            {
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();

                oDocLng.FncSqlFind(docId, docLngId);
                oDocLng.FncGetCache_Html(true);
                uiCount++;
                szHtml += "\n<li>" + uiCount.ToString() + "--" + docId.ToString() + "-" + docLngId + " " + oDocLng.Title + "</li>";


            }
            szHtml += "<ul>";
            oDocLng.FncCache_GET_last(true,20);
            return szHtml;


        }
        // uperthan esta para contruir a partir de un id en adelante
        // esto esta para cuando da timeaut, no volver a repetir desde cero
        private String FncCache_bld_tortoises(UInt64 pIdUpperThan)
        {
            //public enum eTortoiseChapter{ Abstracts, Ddescription, Natural_history, Distribution, Ecology ,Care, Taxonony, Bibliography, Gallery, Notes, Nearspecies, Identificationkeys };
            String szTable = "tdoclng_testudines_taxa";
            //            cls.cache.ClsCache_Reg_tdoclng_testudines oDocCacheLng = new cls.cache.ClsCache_Reg_tdoclng_testudines();
            cls.bbdd.ClsReg_tdoclng_testudines_taxa oDocLng = new cls.bbdd.ClsReg_tdoclng_testudines_taxa();
            cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oDocTaxa = new cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();
            cls.cache.ClsCache_Tortoise oCache = new cls.cache.ClsCache_Tortoise();
            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + "  where docid >" + pIdUpperThan.ToString()+ " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h2Tortoises sheets rebuilded<h2><ul>";
            UInt32 uiCount = 0;
            foreach (DataRow oRow in oTable.Rows)
            {
                uiCount++;
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();
                oCache.FncSqlFindTaxon_ful_html(docId, docLngId);
                oDocLng.FncSqlFind(docId, docLngId);
                oDocTaxa.FncSqlFind(docId);

                oCache.FncRebuildCache(false);

                szHtml += "\n<li>" + uiCount.ToString() + "--" + docId.ToString() + "-" + docLngId + " " + oDocTaxa.ATaxGrpL0001lNameFullRecomeded + "</li>";
            }








            szHtml += "<ul>";
            return szHtml;


        }

        private String FncCache_bld_acknowledgment()
        {
            cls.cache.ClsCache_Reg_tdoc_acknowledgment oCache = new cls.cache.ClsCache_Reg_tdoc_acknowledgment();
            oCache.FncCache_GET(true, "en");
            oCache.FncCache_GET_last(cls.ClsGlobal.LngIdThread ,true,20);
            return oCache.FncCache_GET(true, "es");
        }

 
        private String FncCache_bld_bibliography()
        {
            cls.bbdd.ClsReg_tdoc_biblio oBibio = new cls.bbdd.ClsReg_tdoc_biblio();
            oBibio.FncGetCache_List_Html("en", true);
            return oBibio.FncGetCache_List_Html("es", true);

        }
        private String FncCache_bld_Gallery()
        {



            //public enum eTortoiseChapter{ Abstracts, Ddescription, Natural_history, Distribution, Ecology ,Care, Taxonony, Bibliography, Gallery, Notes, Nearspecies, Identificationkeys };
            String szTable = "tdoclng_testudines_abst";
            //            cls.cache.ClsCache_Reg_tdoclng_testudines oDocCacheLng = new cls.cache.ClsCache_Reg_tdoclng_testudines();
            cls.bbdd.ClsReg_tdoclng_testudines_taxa oDocLng = new cls.bbdd.ClsReg_tdoclng_testudines_taxa();
            cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oDocTaxa = new cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();
            cls.cache.ClsCache_Tortoise oCache = new cls.cache.ClsCache_Tortoise();
            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h1>Gallery of tortoises<h1>";
            String szHtmlYes = "<h2>Gallery of tortoises url Yes <h2><ul>";
            String szHtmlNo = "<h2>Gallery of tortoises url NO <h2><ul>";
            String szHtmlItem = "";
            String szHtmlItemTitle = "Num, flag, Count, id, title, url";
            UInt32 uiCount = 0;
            cls.cache.ClsCache_Tortoise_Images oGallery = new cls.cache.ClsCache_Tortoise_Images();
            bool imagesPathExist = false;
            Int32 imagesCount = 0;
            string imagesUrl = "";

            Int32 CountYes = 0;
            Int32 CountNo = 0;
            String szFlagNo = "<span style=\"color:#900;\">NO<span>, ";
            String szFlagYes = "<span style=\"color:#090;\">Yes<span>, ";
            String szFlag = "";

            foreach (DataRow oRow in oTable.Rows)
            {
                uiCount++;
                szHtmlItem = "";
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();
                oCache.FncSqlFindTaxon_ful_html(docId, docLngId);
                oDocLng.FncSqlFind(docId, docLngId);
                oDocTaxa.FncSqlFind(docId);

                oGallery.FncCacheGet(docId, docLngId, 1, true);


                imagesPathExist = oGallery.Images_PathExist();
                if (imagesPathExist)
                {
                    CountYes++;
                    szFlag = szFlagYes;
                    imagesCount = oGallery.Images_count_minx();
                }
                else {
                    CountNo++;
                    szFlag = szFlagNo;
                    imagesCount = 0;
                }
                imagesUrl = oGallery.UrlGallery;


                szHtmlItem += "\n<li>Count" + uiCount.ToString() + " , " + szFlag + ", " + imagesCount.ToString() + ", " + docId.ToString() + ", " + imagesUrl + ", " + oDocTaxa.ATaxGrpL2270Genus+" "+ oDocTaxa.ATaxGrpL2280Specie +"</li>";
                if (imagesPathExist)
                { szHtmlYes += szHtmlItem; }
                else { szHtmlNo += szHtmlItem; }

            }
            szHtmlYes += "</ul>";
            szHtmlNo += "</ul>";





            szHtmlNo = szHtmlItemTitle + "No count= " + CountNo.ToString() + "</br>" + szHtmlNo;
            szHtmlYes = szHtmlItemTitle + "Yes count= " + CountYes.ToString() + "</br>" + szHtmlYes;
            szHtml += szHtmlNo;
            szHtml += szHtmlYes;

            return szHtml;



        }

        protected void scnBtnTotoiseGalleryOnlyOne_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            try
            {

                UInt64 docId = Convert.ToUInt64(scnDropDocId.SelectedValue);

                cls.cache.ClsCache_Tortoise_Images oGallery = new cls.cache.ClsCache_Tortoise_Images();
                scnLog.Text = oGallery.FncCacheGet(docId, "es", 1, true);
                scnLog.Text = oGallery.FncCacheGet(docId, "es", 1, true);
               
            }
            catch { }
            scnMsg.Text = "Done Gallery";
        }


        private void FncFillComboTortoises()
        {
            string query = "Select DocId as value, Concat( ATaxGrpL0001lNameFullRecomeded, \"[\",DocId,\"]\")  as Title from tdoclng_testudines_taxa_all order by ATaxGrpL0001lNameFullRecomeded";

            MySqlConnection oCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);

            MySqlDataAdapter da = new MySqlDataAdapter(query, oCnn);
            DataSet ds = new DataSet();
            try
            {

                oCnn.Open();

                da.Fill(ds, "table");

                scnDropDocId.DataSource = ds;
                scnDropDocId.DataTextField = "Title";
                scnDropDocId.DataValueField = "value";
                scnDropDocId.DataBind();
                scnDropDocId.Items[0].Selected = true;


            }
            catch (Exception ex)
            {
                // write exception info to log or anything else

            }
            da.Dispose();
            ds.Dispose();
            oCnn.Close();
            oCnn.Dispose();

        }
  
        private void FncRebuidSiteMap()
        {
            cls.bbdd.ClsReg_TDoclng_sitemap oRegSite = new cls.bbdd.ClsReg_TDoclng_sitemap(cls.ClsGlobal.Connection_MARIADB);

            oRegSite.FncSitemapRebuidl();
            DataTable oTbTaxon = new DataTable();


        oTbTaxon.Rows.Clear();
            oTbTaxon.Columns.Clear();
            String szSql = "select * from tdoclng_sitemap";
        cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTbTaxon);
            scnGridView.DataSource = oTbTaxon;
            scnGridView.DataBind();
            }

        private void FncTaxonomytreesDLDT()
        {
            cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_DL(true);
            cls.cache.ClsCache_Tortoise_List_DL.FncCache_GET_TT(true);
        }
        private void FncTaxonomytrees()
        {
            cls.cache.ClsCacheTortoise_TreeULView oTreeUl = new cls.cache.ClsCacheTortoise_TreeULView();
            oTreeUl.FncCache_GET(true, "es");
            oTreeUl.FncCache_GET(true, "en");
            scnLog.Text = oTreeUl.FncCache__ULTaxonsViewEdit(true, "en");
            oTreeUl.FncCache__ULTaxonsViewEdit(true, "es");

    

            cls.cache.ClsCache_Tortoise_Tree_Bootstrap oTree1 = new cls.cache.ClsCache_Tortoise_Tree_Bootstrap();
            oTree1.FncCache_GET(true, "es");
            oTree1.FncCache_GET(true, "en");
            oTree1.FncCache__ULTaxonsViewEdit(true, "es");
            oTree1.FncCache__ULTaxonsViewEdit(true, "en");

            cls.cache.ClsCache_Tortoise_Tree_RadTreeView oTree2 = new cls.cache.ClsCache_Tortoise_Tree_RadTreeView();
            bool bNode = false;
            bool bRebuild = true;
            oTree2.FncCache_GET(ref scnTreeView, ref bNode, bRebuild);

           

        
        }

        protected void scnBtnTortoisesGroups_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";

            cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
            oGroup.FncCache_GET_last(true, 20);
            scnLog.Text = oGroup.FncGetCache_Html(true);
            scnMsg.Text = "Done Tortoises Groups";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnOthers_Click(object sender, EventArgs e)
        {
            scnMsg.Text = "";
            scnLog.Text = FncCache_bld_others();
            scnMsg.Text = "Done Others";
            scnLoading.Style["display"] = "none";
        }
        private String FncCache_bld_others()
        {
            String szTable = "tdoclng_others";
            cls.bbdd.ClsReg_tdoclng_others oDocLng = new cls.bbdd.ClsReg_tdoclng_others();

            UInt64 docId = 0;
            String docLngId = "";
            DataTable oTable = new DataTable();
            string szSql = "select docid ,doclngid from " + szTable + " order by  docid ,doclngid";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTable);
            String szHtml = "<h2>Others chache rebuilded<h2><ul>";
            UInt32 uiCount = 0;
            foreach (DataRow oRow in oTable.Rows)
            {
                docId = Convert.ToUInt64(oRow[0].ToString());
                docLngId = oRow[1].ToString();

                oDocLng.FncSqlFind(docId, docLngId);
                oDocLng.FncGetCache_Html(true);
                uiCount++;
                szHtml += "\n<li>" + uiCount.ToString() + "--" + docId.ToString() + "-" + docLngId + " " + oDocLng.Title + "</li>";


            }
            szHtml += "<ul>";
            oDocLng.FncCache_GET_last(true);
            return szHtml;


        }
       

        protected string FncWebRequest_Get(string url)
        {
            try
            {
                string rt;

                WebRequest request = WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                rt = reader.ReadToEnd();

                Console.WriteLine(rt);

                reader.Close();
                response.Close();

                return rt;
            }

            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string HttpGet(string URI)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the 
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(URI);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }

        protected void scnBtnSiteMap0_Click(object sender, EventArgs e)
        {
            //http://google.com/ping?sitemap=http://www.example.com/mi_sitemap.xml
            String szUrl = "http://google.com/ping?sitemap=http://www.testudines.org/sitemap.xml";
            scnLog.Text = FncWebRequest_Get(szUrl);
            scnMsg.Text = "Done send sitemap to google";
            scnLoading.Style["display"] = "none";
        }

        protected void scnBtnTortoises0_Click(object sender, EventArgs e)
        {


            //public enum eTortoiseChapter{ Abstracts, Ddescription, Natural_history, Distribution, Ecology ,Care, Taxonony, Bibliography, Gallery, Notes, Nearspecies, Identificationkeys };
        
            //            cls.cache.ClsCache_Reg_tdoclng_testudines oDocCacheLng = new cls.cache.ClsCache_Reg_tdoclng_testudines();
         
            cls.cache.ClsCache_Tortoise oCache = new cls.cache.ClsCache_Tortoise();
            

            UInt64 docId = Convert.ToUInt64(scnDropDocId.SelectedValue);
           
            oCache.FncSqlFindTaxon_ful_html(docId, "en");
                oCache.FncRebuildCache(false);
                oCache.FncSqlFindTaxon_ful_html(docId, "es");
                oCache.FncRebuildCache(false);
            scnMsg.Text = "Done tortoise cache for" + scnDropDocId.Text; ;
            scnLoading.Style["display"] = "none";

        }

        protected void scnBtnLast_Click(object sender, EventArgs e)
        {
            cls.cache.ClsCache_Tortoise_Last.FncCache_GET(true, 10);
            scnMsg.Text = "Done tortoise las updates" + scnDropDocId.Text; ;
            scnLoading.Style["display"] = "none";
        }

    
    }


    }

