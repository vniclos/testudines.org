using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace testudines.cls.cache
{
    public static class ClsCache_Tortoise_Last
    {

        public static String FncCache_GET(bool bRebuildCache, UInt16 iCount)
        {
            String szError = "";
            String r_szHtmlView = "";
            String r_FileCacheView = testudines.cls.ClsGlobal.DirCache + "Tortoise_LastUpdates.html";



            if (!System.IO.File.Exists(r_FileCacheView)) bRebuildCache = true;

             if (bRebuildCache)
            {
                try
                {
                    if (System.IO.File.Exists(r_FileCacheView)) System.IO.File.Delete(r_FileCacheView);
                    cls.ClsUtils.FncPathFileDelete(r_FileCacheView);
                    FncFillList(ref r_szHtmlView, ref iCount);
                    System.IO.StreamWriter fileView = new System.IO.StreamWriter(r_FileCacheView);
                    fileView.Write(r_szHtmlView);
                    fileView.Close();
                }
                catch (Exception xcpt) { szError = xcpt.Message; }
            ;
            }
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(r_FileCacheView);
                r_szHtmlView = file.ReadToEnd();
                file.Close();
            }
            catch (Exception xcpt)
            { r_szHtmlView = szError+"<br/>"+xcpt.Message; }

            return r_szHtmlView;
        }
        private static void FncFillList(ref string r_szHtmlList, ref UInt16 iCount)
        {
            // "select `tdoclng_testudines_abst`.`DocId` AS `DocId`, tdoclng_testudines_abst.LAbsDes AS abstract, `tdoclng_testudines_abst`.`DocLngId` AS `DocLngId`,`tdoclng_testudines_abst`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_docstore/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`  from (`tdoclng_testudines_abst` left join `tdoc` on((`tdoclng_testudines_abst`.`DocId` = `tdoc`.`DocId`))) where (`tdoc`.`DocIsActive` = 1) GROUP BY DocId order by `tdoclng_testudines_abst`.`DocId` desc limit " + iCount.ToString() + ";";
            string szSqlSelect = ""; 
            //szSqlSelect = "select  tdoclng_sitemap.loc_title as url, `tdoclng_testudines_abst`.`DocId` AS `DocId`,  `tdoclng_testudines_abst`.DocLngId, tdoclng_testudines_abst.LAbsDes AS abstract, `tdoclng_testudines_abst`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_docstore/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`  ";
            //szSqlSelect += " from  `tdoclng_testudines_abst` ";
            //szSqlSelect += " inner join `tdoc` on `tdoclng_testudines_abst`.`DocId` = `tdoc`.`DocId`";
            //szSqlSelect += " inner join tdoclng_sitemap on (`tdoclng_testudines_abst`.`DocId` = `tdoclng_sitemap`.`DocId` and  tdoclng_testudines_abst.DoclngId = tdoclng_sitemap.DoclngId) ";
            //szSqlSelect += " where (`tdoc`.`DocIsActive` = 1) GROUP BY tdoclng_testudines_abst.DocId order by `tdoclng_testudines_abst`.`DocId` desc limit "+ iCount.ToString() ;

            szSqlSelect = "select  tdoclng_sitemap.loc_title as url, `tdoclng_testudines_abst`.`DocId` AS `DocId`,  `tdoclng_testudines_abst`.DocLngId, tdoclng_testudines_abst.LAbsDes AS abstract ,";
            szSqlSelect += " concat( tdoclng_testudines_taxa_all.ATaxGrpL2260SupGenus,' ',tdoclng_testudines_taxa_all.ATaxGrpL2280Specie)  AS `Title` ,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_docstore/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,";
            szSqlSelect += " `tdoc`.`DocDateUpdate` AS `DocDateUpdate`   from  `tdoclng_testudines_abst`";
            szSqlSelect += " inner join `tdoc` on `tdoclng_testudines_abst`.`DocId` = `tdoc`.`DocId`";
            szSqlSelect += " left join tdoclng_testudines_taxa_all on `tdoclng_testudines_taxa_all`.`DocId` = `tdoc`.`DocId` ";
            szSqlSelect += " inner join tdoclng_sitemap on (`tdoclng_testudines_abst`.`DocId` = `tdoclng_sitemap`.`DocId` and  tdoclng_testudines_abst.DoclngId = tdoclng_sitemap.DoclngId)  where (`tdoc`.`DocIsActive` = 1) GROUP BY tdoclng_testudines_abst.DocId order by `tdoclng_testudines_abst`.`DocId` desc limit 4";


            //tdoclng_testudines_abst
            //string szSqlSelect = "Select `DocId`,`DocLngId`,`Title`,`DocImgThumbnail`,`DocDateUpdate`,  `DocStdValLow`, `DocStdValHig`, `DocStdValMed` from `warticlelast20`";
            MySqlConnection oCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlSelect, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oDt = new DataTable();
            oCnn.Open();
            oDa.Fill(oDt);
            oCnn.Close();
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Dispose();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<h2 class=\"h2_reverse\">" + Resources.Strings.Last_Update_taxons + "</h2>");
            //sb.Append("\n<div class=\"panelLast\">");

            sb.Append("\n");
            string szUrl = "";
            foreach (DataRow oRow in oDt.Rows)
            {
                szUrl =  oRow["url"].ToString();
                sb.Append("\n<h3 class=\"taxa bottom-min\"><a href=\"" + szUrl + "\">" + oRow["Title"].ToString() + "</a></h3>");

                //  sb.Append("");
                sb.Append("<img class=\"imgleft\" src=\" " + oRow["DocImgThumbnail"].ToString() + "\"/>");
                if (oRow["Abstract"].ToString().Length > 400)
                {
                    sb.Append(oRow["Abstract"].ToString().Substring(0, 399) + "...");
                }
                else
                {
                    sb.Append(oRow["Abstract"].ToString());
                }
                // DocImgThumbnail

                sb.Append("<br/><span class=\"mmin-x\">" + Resources.Strings.Updated + " " + oRow["DocDateUpdate"].ToString() + "</span>");
                sb.Append("<br/>" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(oRow["DocId"].ToString()), "/tortoises/tortoise/"));
                sb.Append("<br/><br/>");
            }

            sb.Append("\n<a href=\"/" + cls.ClsGlobal.LngIdThread + "/tortoises/tortoise/tortoises-list\">" + Resources.Strings.taxa_full_list + "</a>");

           // sb.Append("\n</div>");
            r_szHtmlList = sb.ToString();
           // return r_szHtmlList;

        }
    }
}