using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.cache
{
    public class ClsCache_Tortoise_Tree_Bootstrap
    {
        MySqlConnection g_oCnn = new MySqlConnection();
        private string g_ConnectionStrign = ClsGlobal.Connection_MARIADB;
        private string m_IdLng = "";
        private String m_szHtmlView = "";
  
        private string m_FileCacheView;
       
        public ClsCache_Tortoise_Tree_Bootstrap()
        {
            m_FileCacheView = ClsGlobal.DirCache + "Tortoise_TreeULViewBoostrap" + m_IdLng + ".html";
           
        }
        public String FncCache_GET(bool bRebuildCache, String pIdLng)
        {
            m_szHtmlView = "";
  
            m_IdLng = pIdLng;


             if (!System.IO.File.Exists(m_FileCacheView)) bRebuildCache = true;
  
            if (bRebuildCache)
            {

                if (System.IO.File.Exists(m_FileCacheView)) System.IO.File.Delete(m_FileCacheView);
  
                FncFillUlList();
                System.IO.StreamWriter fileView = new System.IO.StreamWriter(m_FileCacheView);
                fileView.Write(m_szHtmlView);
                fileView.Close();
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(m_FileCacheView);
                m_szHtmlView = file.ReadToEnd();
                file.Close();
            }
            return m_szHtmlView;
        }
        public String FncCache__ULTaxonsViewEdit(bool bRebuildCache, string pIdLng)
        {
            m_szHtmlView = "";
  
            m_IdLng = pIdLng;
        



            if (!System.IO.File.Exists(m_FileCacheView)) bRebuildCache = true;
           
            if (bRebuildCache)
            {
                FncFillUlList();
                if (System.IO.File.Exists(m_FileCacheView)) System.IO.File.Delete(m_FileCacheView);
                System.IO.StreamWriter fileView = new System.IO.StreamWriter(m_FileCacheView);
                fileView.Write(m_szHtmlView);
                fileView.Close();
            }
            else
            {
                System.IO.StreamReader file = new System.IO.StreamReader(m_FileCacheView);
                m_FileCacheView = file.ReadToEnd();
                file.Close();
            }
            return m_FileCacheView;
        }
        private void FncFillUlList()
        {

            g_oCnn.ConnectionString = g_ConnectionStrign;
            g_oCnn.Open();
            
            m_szHtmlView = "<div><ul class=\"tree\"   style=\"max-height:none;\">";
            m_szHtmlView = m_szHtmlView + "<li><span><i class=\"halflings glyphicon-cloud\"></i> "+ Resources.Strings.ATaxGrpL2210Order + "  Testudines "+ FncFlagGroup("testudines")+"</span ><ul>";
            FncFillL1_SubOrder();
            m_szHtmlView = m_szHtmlView + "</ul></li></ul></div>";
            g_oCnn.Close();
            return;
        }
        private void FncFillL1_SubOrder()
        {
            String g_cmdSqlSelect = "select DISTINCT(ATaxGrpL2220SubOrder) from tdoclng_testudines_taxa_all  order by ATaxGrpL2220SubOrder";
            MySqlDataAdapter oDa = new MySqlDataAdapter(g_cmdSqlSelect, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string L1ATaxGrpL2220SubOrder = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L1ATaxGrpL2220SubOrder = oRow["ATaxGrpL2220SubOrder"].ToString();
                m_szHtmlView = m_szHtmlView + "<li><span><i class=\"halflings glyphicon-cloud\"></i>" + Resources.Strings.ATaxGrpL2220SubOrder + " " + L1ATaxGrpL2220SubOrder + " " + FncFlagGroup(L1ATaxGrpL2220SubOrder) + "</span><ul>";
                FncFillL2_SupFamily(L1ATaxGrpL2220SubOrder);
                m_szHtmlView = m_szHtmlView + "</ul></li>";
            }
            oTb.Dispose();

        }
        private void FncFillL2_SupFamily(String L1ATaxGrpL2220SubOrder)
        {
            string SqlCmdString = "select DISTINCT(ATaxGrpL2230SupFamily) from tdoclng_testudines_taxa_all where ATaxGrpL2220SubOrder='" + L1ATaxGrpL2220SubOrder + "' order by ATaxGrpL2230SupFamily";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string L2ATaxGrpL2230SupFamily = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L2ATaxGrpL2230SupFamily = oRow["ATaxGrpL2230SupFamily"].ToString();
                m_szHtmlView = m_szHtmlView + "<li><span><i class=\"icon-leaf\"></i>" + Resources.Strings.ATaxGrpL2230SupFamily + " " + L2ATaxGrpL2230SupFamily + FncFlagGroup(L2ATaxGrpL2230SupFamily) + "</span><ul> ";
                FncFillL3_ATaxGrpL2240Family(L2ATaxGrpL2230SupFamily);
                m_szHtmlView = m_szHtmlView + "</ul></li>";
            }
            oTb.Dispose();
            // m_szHtmlView =m_szHtmlView+ "</li></ul>";
        }
        private void FncFillL3_ATaxGrpL2240Family(String L2ATaxGrpL2230SupFamily)
        {
            string SqlCmdString = "select  Distinct(ATaxGrpL2240Family) from tdoclng_testudines_taxa_all where ATaxGrpL2230SupFamily='" + L2ATaxGrpL2230SupFamily + "' order by ATaxGrpL2240Family";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string L3ATaxGrpL2240Family = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L3ATaxGrpL2240Family = oRow["ATaxGrpL2240Family"].ToString();
                m_szHtmlView = m_szHtmlView + "<li><span><i class=\"icon-leaf\"></i>" + Resources.Strings.ATaxGrpL2240Family + " " + L3ATaxGrpL2240Family + FncFlagGroup(L3ATaxGrpL2240Family) + "</span><ul> ";
                FncFillL3_ATaxGrpL2270Genus(L3ATaxGrpL2240Family);
                m_szHtmlView = m_szHtmlView + "</ul></li>";
               
            }
            oTb.Dispose();
            // m_szHtmlView =m_szHtmlView+"</ul>";
        }
        private void FncFillL3_ATaxGrpL2270Genus(String L3ATaxGrpL2240Family)
        {
            string SqlCmdString = "select DISTINCT( ATaxGrpL2270Genus) from tdoclng_testudines_taxa_all where ATaxGrpL2240Family='" + L3ATaxGrpL2240Family + "' order by ATaxGrpL2270Genus";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string L3ATaxGrpL2270Genus = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                L3ATaxGrpL2270Genus = oRow["ATaxGrpL2270Genus"].ToString();
                m_szHtmlView = m_szHtmlView + "<li><span><i class=\"icon-leaf\"></i>" + Resources.Strings.ATaxGrpL2270Genus + " " + L3ATaxGrpL2270Genus + " "+ FncFlagGroup(L3ATaxGrpL2270Genus) + "</span><ul> ";
                FncFillL3_ATaxGrpL4Specie(L3ATaxGrpL2270Genus);
                m_szHtmlView = m_szHtmlView + "</ul></li>";
              

            }
            oTb.Dispose();
            // m_szHtmlView = m_szHtmlView + "</li></ul>";
        }
        private void FncFillL3_ATaxGrpL4Specie(String L3ATaxGrpL2270Genus)
        {
            string SqlCmdString = "select Distinct(DocId),  CONCAT (ATaxGrpL2270Genus ,' ',  ATaxGrpL2280Specie) as ATaxGrpL0001lNameFullRecomeded, AIsRewrited from tdoclng_testudines_taxa_all where ATaxGrpL2270Genus='" + L3ATaxGrpL2270Genus

                + "' order by ATaxGrpL2270Genus,ATaxGrpL2280Specie ";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string L4ATaxGrpL2280Specie = "";
            string L4ATaxGrpL2280SpecieLink = "";
            string sAIsRewrited = "";
            string sDocId = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                sDocId = oRow["DocId"].ToString();
                L4ATaxGrpL2280Specie = oRow["ATaxGrpL0001lNameFullRecomeded"].ToString();
                
                if ((oRow["AIsRewrited"].ToString()) == "1")
                {
                    sAIsRewrited = "&#9745;&nbsp;"; // box checked
                }
                else
                {
                    sAIsRewrited = " &#9744;&nbsp;";// box no checked
                }
                Int64 DocId = Convert.ToInt32(oRow["DocId"].ToString());
                String szFlagsView = FncFlagsSpecieView(L4ATaxGrpL2280Specie, DocId);
                m_szHtmlView = m_szHtmlView + "<li><span><i class=\"icon-leaf\"></i>" + sAIsRewrited +" " + L4ATaxGrpL2280Specie + " " + szFlagsView + "</span></li> ";




            }
            oTb.Dispose();
            // m_szHtmlView = m_szHtmlView + "</ul>";
        }
      
        private string FncFlagsSpecieView(string szTitle, Int64 pDocId)
        {

            string SqlCmdString = "Select  docid, DocLngId, CONCAT('<a href=\"/',DocLngId,'/tortoises/tortoise/' , docid,'\", title=\"xxx\"><img src=\"/a_img/a_site/ico16/flag16_',DocLngId,'.gif\" class=\"litax_ImgFlag\"/></a>' ) as url from tdoclng_testudines_abst  where docid=" + pDocId.ToString() + " order by DocLngId  DESC";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string szFlags = "";

            foreach (DataRow oRow in oTb.Rows)
            {
                szFlags += oRow["url"].ToString().Replace("xxx", szTitle) + "&nbsp;";



            }
            oTb.Dispose();
            return szFlags;
        }
        private string FncFlagGroup(String PATaxIdName)
        {
            //
            //http://www.testudines.org/es/taxons/taxon_group/Testudines
            //string szFlag = "";
            //Select DocId,DocLngId,    ATaxIdName from tdoclng_testudines_groups where ATaxIdName='chelidae'
            string SqlCmdString = "Select  docid, DocLngId,DescriptionShort, CONCAT('<a href=\"/',DocLngId,'/tortoises/groups/group',ATaxIdName , '\", title=\"',ATaxIdName,'\"><img src=\"/a_img/a_site/ico16/flag16_',DocLngId,'.gif\" class=\"litax_ImgFlag\"/></a>' ) as url from tdoclng_testudines_groups  where ATaxIdName='" + PATaxIdName + "' order by DocLngId  DESC";
            MySqlDataAdapter oDa = new MySqlDataAdapter(SqlCmdString, g_oCnn);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            string szFlags = "";
            string szDes = "";
            String szDesFull = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                szFlags += oRow["url"].ToString() + "&nbsp;";

                szDes = oRow["DescriptionShort"].ToString().Trim();
                if (szDes.Length > 15)
                {
                    szDesFull += "<br/>" + szDes;
                }
            }
            if (szDesFull.Length > 15) szFlags +="<br/>"+ szDesFull ;
            oTb.Dispose();
            return szFlags;
        }

    }
}