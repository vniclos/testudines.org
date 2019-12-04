// se usa ne menu derecha tree-list

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.cache
{
    public  class ClsCache_Tortoise_Tree_UL
    {
        MySqlConnection g_oCnn = new MySqlConnection();
        private string g_ConnectionStrign = ClsGlobal.Connection_MARIADB;
        private string m_IdLng = "";
        private String m_szHtmlView = "";
        private String m_szHtmlEdit = "";
        private  string m_FileCacheView;
        private string m_FileCacheEdit;
        public ClsCache_Tortoise_Tree_UL()
        {
            m_FileCacheView = ClsGlobal.DirCache + "Tortoise_TreeULView" + m_IdLng + ".html";
            m_FileCacheEdit = ClsGlobal.DirCache + "Tortoise_TreeULViewEdit" + m_IdLng + ".html";
        }
        public String fncCache_GET(bool bRebuildCache, String pIdLng)
        {
            m_szHtmlView = "";
            m_szHtmlEdit = "";
            m_IdLng = pIdLng;
          
            
             if (!System.IO.File.Exists(m_FileCacheView)) bRebuildCache = true;
             if (!System.IO.File.Exists(m_FileCacheEdit)) bRebuildCache = true;
             if (bRebuildCache)
             {
                
                 if (System.IO.File.Exists(m_FileCacheView)) System.IO.File.Delete(m_FileCacheView);
                 if (System.IO.File.Exists(m_FileCacheEdit)) System.IO.File.Delete(m_FileCacheEdit);
                 fncFillUlList();
                 System.IO.StreamWriter fileView = new System.IO.StreamWriter(m_FileCacheView);
                 fileView.Write(m_szHtmlView);
                 fileView.Close();
                 System.IO.StreamWriter fileEdit = new System.IO.StreamWriter(m_FileCacheEdit);
                 fileEdit.Write(m_szHtmlEdit);
                 fileEdit.Close();
             }
             else
             {
                 System.IO.StreamReader file = new System.IO.StreamReader(m_FileCacheView);
                 m_szHtmlView = file.ReadToEnd();
                 file.Close();
              }
             return m_szHtmlView;
        }
        public String fncCache__ULTaxonsViewEdit(bool bRebuildCache, string pIdLng)
        {
            m_szHtmlView = "";
            m_szHtmlEdit = "";
            m_IdLng = pIdLng;
            m_FileCacheView = ClsGlobal.DirCache + "ClsCache_Taxa_ULView"+m_IdLng+".html";
            m_FileCacheEdit = ClsGlobal.DirCache + "ClsCache_Taxa_ULEdit"+m_IdLng+".html";
        
          

            if (!System.IO.File.Exists(m_FileCacheView)) bRebuildCache = true;
            if (!System.IO.File.Exists(m_FileCacheEdit)) bRebuildCache = true;
            if (bRebuildCache)
            {
                fncFillUlList();
                if (System.IO.File.Exists(m_FileCacheView)) System.IO.File.Delete(m_FileCacheView);
                if (System.IO.File.Exists(m_FileCacheView)) System.IO.File.Delete(m_FileCacheEdit);
                System.IO.StreamWriter fileView = new System.IO.StreamWriter(m_FileCacheView);
                fileView.Write(m_szHtmlView);
                fileView.Close();
                System.IO.StreamWriter fileEdit = new System.IO.StreamWriter(m_FileCacheEdit);
                fileEdit.Write(m_szHtmlEdit);
                fileEdit.Close();
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(m_FileCacheEdit);
                m_FileCacheEdit = file.ReadToEnd();
                file.Close();
            }
            return m_FileCacheEdit;
        }
       // private String g_cmdSqlSelect = "select DocId, ATaxGrpL2220SubOrder, ATaxGrpL2230SupFamily, ATaxGrpL2240Family, ATaxNameRecomended, ATaxNameLngVulgarEN from tdoclng_taxon_all order by ATaxGrpL2220SubOrder, ATaxGrpL2230SupFamily, ATaxGrpL2240Family, ATaxNameRecomended";
        private void fncFillUlList()
        {

            
            //select ATaxGrpL2220SubOrder, ATaxGrpL2230SupFamily, ATaxGrpL2240Family, ATaxNameRecomended, ATaxNameLngVulgarEN from tdoclng_taxon_all
            //order by ATaxGrpL2220SubOrder, ATaxGrpL2230SupFamily, ATaxGrpL2240Family, ATaxNameRecomended

            String g_cmdSqlSelect = "select DISTINCT(ATaxGrpL2220SubOrder) from tdoclng_taxon_all  order by ATaxGrpL2220SubOrder";
            
            DataTable oTb = new DataTable();
            cls.clsMysql.fncFill_datatable(ref g_cmdSqlSelect, ref oTb);

           
            //m_szHtmlView = "<html>";
            //m_szHtmlView += "<head>";
            //m_szHtmlView += "\n  <link rel=\"stylesheet\" href=\"css/style.css\" />";
            //m_szHtmlView += "\n</head>";
            //m_szHtmlView += "\n<body>";

            m_szHtmlView =  "\n<ul class=\"litaxorder\">";
            m_szHtmlView = m_szHtmlView + "\n<li >"+Resources.Strings.ATaxGrpL2210Order+ "  Testudines";
            m_szHtmlView = m_szHtmlView + "\n<ul class=\"litaxsuborder\" > ";
            m_szHtmlEdit = m_szHtmlView;
            
            string L1ATaxGrpL2220SubOrder = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L1ATaxGrpL2220SubOrder = oRow["ATaxGrpL2220SubOrder"].ToString();
               
                m_szHtmlView = m_szHtmlView + "\n<li  class=\"litaxsuborder\"> "+Resources.Strings.ATaxGrpL2220SubOrder+ " "+ L1ATaxGrpL2220SubOrder +ClsHtml.fncFlagGroup(L1ATaxGrpL2220SubOrder) + "\n<<ul > ";
                m_szHtmlEdit = m_szHtmlEdit + "\n<li  class=\"litaxsuborder\"> " + Resources.Strings.ATaxGrpL2220SubOrder + " " + L1ATaxGrpL2220SubOrder +ClsHtml.fncFlagGroup(L1ATaxGrpL2220SubOrder) + "\n<<ul > ";
                fncFillL2_SupFamily(L1ATaxGrpL2220SubOrder);
                m_szHtmlView = m_szHtmlView + "\n</li>\n</ul>";
                m_szHtmlEdit = m_szHtmlEdit + "\n</li>\n</ul>";

            }

            m_szHtmlView = m_szHtmlView + "\n</li>";
            m_szHtmlView = m_szHtmlView + "\n</ul>";

            m_szHtmlEdit = m_szHtmlEdit + "\n</li>";
            m_szHtmlEdit = m_szHtmlEdit + "\n</ul>";

            //m_szHtmlEdit = m_szHtmlEdit + "\n</li>";
            //m_szHtmlEdit = m_szHtmlEdit + "\n</ul>";

            //m_szHtmlEdit = m_szHtmlEdit + "\n</li>";
            //m_szHtmlEdit = m_szHtmlEdit + "\n</ul>";

            //m_szHtmlView += "/n</body>";
            //m_szHtmlView += "/n</html>";

            return ;
        }
        private void fncFillL2_SupFamily(String L1ATaxGrpL2220SubOrder)
        {
            string SqlCmdString = "select DISTINCT(ATaxGrpL2230SupFamily) from tdoclng_taxon_all where ATaxGrpL2220SubOrder='" + L1ATaxGrpL2220SubOrder + "' order by ATaxGrpL2230SupFamily";
           
            DataTable oTb = new DataTable();

            cls.clsMysql.fncFill_datatable(ref SqlCmdString, ref oTb);

            string L2ATaxGrpL2230SupFamily = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L2ATaxGrpL2230SupFamily = oRow["ATaxGrpL2230SupFamily"].ToString();

                m_szHtmlView = m_szHtmlView + "\n\t\t<li class=\"litaxsuperfamily\">" + Resources.Strings.ATaxGrpL2230SupFamily + " " + L2ATaxGrpL2230SupFamily +ClsHtml.fncFlagGroup(L2ATaxGrpL2230SupFamily) + "\n\t\t<ul > ";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t<li class=\"litaxsuperfamily\">" + Resources.Strings.ATaxGrpL2230SupFamily + " " + L2ATaxGrpL2230SupFamily +ClsHtml.fncFlagGroup(L2ATaxGrpL2230SupFamily) + "\n\t\t<ul >";
                fncFillL3_ATaxGrpL2240Family(L2ATaxGrpL2230SupFamily);

                m_szHtmlView = m_szHtmlView + "\n\t\t</li>\n\t\t</ul>";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t</li>\n\t\t</ul>";

            }
            // m_szHtmlView =m_szHtmlView+"\n<ul>";
        }
        private void fncFillL3_ATaxGrpL2240Family(String L2ATaxGrpL2230SupFamily)
        {
            string SqlCmdString = "select  Distinct(ATaxGrpL2240Family) from tdoclng_taxon_all where ATaxGrpL2230SupFamily='" + L2ATaxGrpL2230SupFamily + "' order by ATaxGrpL2240Family";
           
            DataTable oTb = new DataTable();
            

            cls.clsMysql.fncFill_datatable(ref SqlCmdString, ref oTb);

            string L3ATaxGrpL2240Family = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L3ATaxGrpL2240Family = oRow["ATaxGrpL2240Family"].ToString();

                m_szHtmlView = m_szHtmlView + "\n\t\t\t<li  class=\"litaxfamily\">" + Resources.Strings.ATaxGrpL2240Family + " " + L3ATaxGrpL2240Family + "\n\t\t\t<ul >";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t\t<li  class=\"litaxfamily\">" + Resources.Strings.ATaxGrpL2240Family + " " + L3ATaxGrpL2240Family + "\n\t\t\t<ul >";
               
                fncFillL3_ATaxGrpL2270Genus(L3ATaxGrpL2240Family);
                m_szHtmlView = m_szHtmlView + "\n\t\t\t</li>\n\t\t\t</ul>";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t\t</li>\n\t\t\t</ul>";

            }
            // m_szHtmlView =m_szHtmlView+"\n</ul>";
        }
        private void fncFillL3_ATaxGrpL2270Genus(String L3ATaxGrpL2240Family)
        {
            string SqlCmdString = "select DISTINCT( ATaxGrpL2270Genus) from tdoclng_taxon_all where ATaxGrpL2240Family='" + L3ATaxGrpL2240Family + "' order by ATaxGrpL2270Genus";
           
            DataTable oTb = new DataTable();
            cls.clsMysql.fncFill_datatable(ref SqlCmdString, ref oTb);
            string L3ATaxGrpL2270Genus = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L3ATaxGrpL2270Genus = oRow["ATaxGrpL2270Genus"].ToString();
                m_szHtmlView = m_szHtmlView + "\n\t\t\t\t<li class=\"litaxgenus\">" + Resources.Strings.ATaxGrpL2270Genus + " " + L3ATaxGrpL2270Genus +ClsHtml.fncFlagGroup(L3ATaxGrpL2270Genus) + "\n\t\t\t\t<ul >";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t\t\t<li class=\"litaxgenus\">" + Resources.Strings.ATaxGrpL2270Genus + " " + L3ATaxGrpL2270Genus +ClsHtml.fncFlagGroup(L3ATaxGrpL2270Genus) + "\n\t\t\t\t<ul >";
             
                fncFillL3_ATaxGrpL4Specie(L3ATaxGrpL2270Genus);
                m_szHtmlView = m_szHtmlView + "\n\t\t\t\t</li>\n\t\t\t\t</ul>";
                m_szHtmlEdit = m_szHtmlEdit + "\n\t\t\t\t</li>\n\t\t\t\t</ul>";

            }
            //  m_szHtmlView = m_szHtmlView + "\n\t\t\t\t\t</ul>";
        }
        private void fncFillL3_ATaxGrpL4Specie(String L3ATaxGrpL2270Genus)
        {
            string szSql = "";
            szSql += "Select  tdoclng_taxon_lngabst.docid, tdoclng_taxon_lngabst.DocLngId, CONCAT('<a href=\"',  tdoclng_sitemap.loc_title  ,'\", title=\"', tdoclng_taxon_lngabst.Title ,'\"><img src=\"/a_img/a_site/ico16/flag16_',tdoclng_taxon_lngabst.DocLngId,'.gif\" class=\"litax_ImgFlag\"/></a>' ) as url";
            szSql += ", tdoclng_taxon_all.ATaxNameRecomended, tdoclng_taxon_all.AIsRewrited";
            szSql += " from   tdoclng_taxon_lngabst ";
            szSql += " inner join tdoclng_sitemap  on    tdoclng_taxon_lngabst.docid = tdoclng_sitemap.docid and tdoclng_taxon_lngabst.DocLngId = tdoclng_sitemap.DocLngId ";
            szSql += " inner join tdoclng_taxon_all on tdoclng_taxon_lngabst.docid = tdoclng_taxon_all.docid ";
            szSql += " where tdoclng_taxon_all.ATaxGrpL2270Genus='"+ L3ATaxGrpL2270Genus + "' and tdoclng_sitemap.DocCapituleId=''";
            szSql += " order by tdoclng_taxon_lngabst.DocLngId  DESC ";


            DataTable oTb = new DataTable();
            cls.clsMysql.fncFill_datatable(ref szSql, ref oTb);
            string L4ATaxGrpL2280Specie = "";
            string L4ATaxGrpL2280SpecieLink="";
            string sAIsRewrited = "";
            string sDocId="";
            foreach (DataRow oRow in oTb.Rows)
            {
                sDocId= oRow["DocId"].ToString();
                L4ATaxGrpL2280Specie = oRow["ATaxNameRecomended"].ToString();
                L4ATaxGrpL2280SpecieLink = "<a href=\""+ oRow["url"].ToString() + "\">" + L4ATaxGrpL2280Specie + "</a>";
                if ((oRow["AIsRewrited"].ToString()) == "1")
                {
                    sAIsRewrited = "&#x2611;&nbsp;"; // box checked
                }
                else
                {
                    sAIsRewrited = "&#x2610;&nbsp;";// box no checked
                }
                UInt64 DocId = Convert.ToUInt64(oRow["DocId"].ToString());
                String szFlagsView = cls.ClsHtml.fncHtmFlagLanguagesGalleryTortoise(DocId, false);
                
                m_szHtmlView = m_szHtmlView + "\n\t\t\t\t\t<li class=\"litaxspecie\">" + sAIsRewrited + "<i>" + L4ATaxGrpL2280SpecieLink + "</i>" + szFlagsView + "</li>";

            



            }
            //        m_szHtmlView = m_szHtmlView + "\n\t\t\t\t</ul>";
        }
       
      
   
       

    }
}