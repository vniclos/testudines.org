using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Web;
using MySql.Data.Common;
using System.Data;

namespace testudines.cls.cache
{
    /// <summary>
    /// Crea fichero cache con la lista de especies, 
    /// con nombres cientificos, vulgares y link a ficha de la especie.
    /// </summary>
    public static class ClsCache_Tortoise_List_DL
    {




        /// <summary>
        /// LIsta todo visible
        /// </summary>
        /// <param name="bRebuildCache"></param>
        /// <returns></returns>
        public static String FncCache_GET_DL(bool bRebuildCache)
        {

            String r_szHtmlView = "";
            String r_FileCacheView =  ClsGlobal.DirCache + "Tortoise_List_DL.html";



            if (!System.IO.File.Exists(r_FileCacheView)) { bRebuildCache = true; }

            if (bRebuildCache)
            {
                try
                {
                    if (System.IO.File.Exists(r_FileCacheView)) { System.IO.File.Delete(r_FileCacheView); }
                    cls.ClsUtils.FncPathFileDelete(r_FileCacheView);
                    FncFillList_DL(ref r_szHtmlView);
                    System.IO.StreamWriter fileView = new System.IO.StreamWriter(r_FileCacheView);
                    fileView.Write(r_szHtmlView);
                    fileView.Close();
                }
                catch {; }
            ;
            }
            try
            {

                System.IO.StreamReader file = new System.IO.StreamReader(r_FileCacheView);
                r_szHtmlView = file.ReadToEnd();
                file.Close();
            }
            catch {; }
            
            return r_szHtmlView;
        }

        private static void FncFillList_DL(ref string r_FileCacheView)
        {
            MySqlConnection conn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            //String szSelect = "select CONCAT('<i><b>',ATaxGrpL2270Genus, ' ', ATaxGrpL2280Specie,'</b></i>, (', ATaxGrpL2220SubOrder, ', ', ATaxGrpL2240Family,')',', ITIS sn. ',ATax_ItisTsn) As html,   AKeyNaturalMedia, CONCAT('<a href=\"/es/tortoise/tortoise/', DocId,'\">go</a>') as link from tdoclng_testudines_taxa_all order by  ATaxGrpL2270Genus, ATaxGrpL2280Specie";
            //String szSelect = "select tdoclng_sitemap.loc_title as url, tdoclng_testudines_taxa_all.DocId,ATax_ItisTsn, ATaxGrpL2220SubOrder,ATaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie,AKeyNaturalMedia,ATaxNameVulgarEN,ATaxNameVulgarES from tdoclng_testudines_taxa_all inner join tdoclng_sitemap on tdoclng_testudines_taxa_all.DocId= tdoclng_sitemap.docid  order by  ATaxGrpL2270Genus, ATaxGrpL2280Specie";
            String szSelect = "select tdoclng.DocLngUrlTitle as url, tdoclng_testudines_taxa_all.DocId,ATax_ItisTsn, ATaxGrpL2220SubOrder,ATaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie,AKeyNaturalMedia,ATaxNameVulgarEN,ATaxNameVulgarES  from tdoclng_testudines_taxa_all inner join tdoclng on tdoclng_testudines_taxa_all.DocId = tdoclng.docid GROUP BY  tdoclng_testudines_taxa_all.DocId " +
                "order by ATaxGrpL2270Genus, ATaxGrpL2280Specie  ";
            DataTable dataTable = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect, ref dataTable);
         
            r_FileCacheView = "\n<dl>";
            String szES = "";
            String szEN = "";
            String szTitle = "";
           // String szGallery = "";
            UInt64 DocId = 0;
            string szDocId = "0";
            String szFlags = "";
            foreach (DataRow oRow in dataTable.Rows)
            {
                szTitle = oRow["ATaxGrpL2270Genus"].ToString() + " " + oRow["ATaxGrpL2280Specie"].ToString();
                szES = oRow["ATaxNameVulgarES"].ToString().Trim(); 
                szEN = oRow["ATaxNameVulgarEN"].ToString().Trim();
                szDocId= oRow["DocId"].ToString().Trim();
                DocId = Convert.ToUInt64(szDocId);
                szFlags = cls.ClsHtml.FncHtmFlagLanguagesGalleryTortoise(DocId,false);

                r_FileCacheView += "\n<dt><i><b>" + szTitle + "</b></i></dt>";
                r_FileCacheView += "\n\t<dd>(" + oRow["ATaxGrpL2220SubOrder"].ToString() + ", " + oRow["ATaxGrpL2240Family"].ToString() + ") ";

                if (szES != "") { r_FileCacheView += "<br/>ES: " + szES; }
                if (szEN != "") { r_FileCacheView += "<br/>EN:" + szEN; }
                //r_FileCacheView +="<br/>"+ szFlags + szGallery ;
                r_FileCacheView += "<br/>" + szFlags ;
                r_FileCacheView += "\n</dd>\n";
            }
            r_FileCacheView += "\n</dl>";
            dataTable.Dispose();
        }
        /*--------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------*/
        /*--------------------------------------------------------------------------------------------*/
        /// <summary>
        /// LIsta TOOLTIP (no todo visible)
        /// </summary>
        /// <param name="bRebuildCache"></param>
        /// <returns></returns>
        public static String FncCache_GET_TT(bool bRebuildCache)
        {

            String r_szHtmlViewTT = "";
            String r_FileCacheViewTT =  ClsGlobal.DirCache + "Tortoise_List_DL_TT.html";



            if (!System.IO.File.Exists(r_FileCacheViewTT)) bRebuildCache = true;

            if (bRebuildCache)
            {
                try
                {
                    if (System.IO.File.Exists(r_FileCacheViewTT)) System.IO.File.Delete(r_FileCacheViewTT);
                    cls.ClsUtils.FncPathFileDelete(r_FileCacheViewTT);
                    FncFillListTT(ref r_szHtmlViewTT);
                    System.IO.StreamWriter fileView = new System.IO.StreamWriter(r_FileCacheViewTT);
                    fileView.Write(r_szHtmlViewTT);
                    fileView.Close();
                }
                catch {; }
            ;
            }
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(r_FileCacheViewTT);
                r_szHtmlViewTT = file.ReadToEnd();
                file.Close();
            }
            catch {; }
            return r_szHtmlViewTT;
        }

        private static void FncFillListTT(ref string r_FileCacheViewTT)
        {
            MySqlConnection conn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            //String szSelect = "select CONCAT('<i><b>',ATaxGrpL2270Genus, ' ', ATaxGrpL2280Specie,'</b></i>, (', ATaxGrpL2220SubOrder, ', ', ATaxGrpL2240Family,')',', ITIS sn. ',ATax_ItisTsn) As html,   AKeyNaturalMedia, CONCAT('<a href=\"/es/tortoise/tortoise/', DocId,'\">go</a>') as link from tdoclng_testudines_taxa_all order by  ATaxGrpL2270Genus, ATaxGrpL2280Specie";
            //String szSelect = "select loc_title as url, tdoclng_testudines_taxa_all.DocId,ATax_ItisTsn, ATaxGrpL2220SubOrder,ATaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie,AKeyNaturalMedia,ATaxNameVulgarEN,ATaxNameVulgarES from tdoclng_testudines_taxa_all  inner join tdoclng_sitemap on tdoclng_testudines_taxa_all.DocId= tdoclng_sitemap.docid  order by  ATaxGrpL2270Genus, ATaxGrpL2280Specie";
            String szSelect = "select DocLngUrlTitle as url, tdoclng_testudines_taxa_all.DocId,ATax_ItisTsn, ATaxGrpL2220SubOrder,ATaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie,AKeyNaturalMedia,ATaxNameVulgarEN,ATaxNameVulgarES  from tdoclng_testudines_taxa_all  inner join tdoclng on tdoclng_testudines_taxa_all.DocId= tdoclng.docid   group by tdoclng_testudines_taxa_all.docid order by  ATaxGrpL2270Genus, ATaxGrpL2280Specie ";

            DataTable datatable = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect, ref datatable);
            r_FileCacheViewTT = "\n<ul >";
            String szES = "";
            String szEN = "";
            String szTitle = "";
            String szTooltip = "";
            String szItem = "";
            String pUrl_DocId = "";
            String szUrl_title = "";
            String pDocLngId = "";
            UInt64 pDocId = 0;

            foreach (DataRow oRow in datatable.Rows)
            {
                szTitle = oRow["ATaxGrpL2270Genus"].ToString() + " " + oRow["ATaxGrpL2280Specie"].ToString();
                szTooltip = "data-toggle=\"tooltip\" data-html=\"true\" title=\"";
                szTooltip += "(" + oRow["ATaxGrpL2220SubOrder"].ToString() + ", " + oRow["ATaxGrpL2240Family"].ToString() + ") ";
                szES = oRow["ATaxNameVulgarES"].ToString().Trim();
                szEN = oRow["ATaxNameVulgarEN"].ToString().Trim();
                szUrl_title = oRow["url"].ToString().Trim();
                if (szES != "") { szTooltip += "<br/>ES: " + szES; }
                if (szEN != "") { szTooltip += "<br/>EN:" + szEN; }

                //pUrl_DocId = "/" + cls.ClsGlobal.LngIdThread + "/tortoises/tortoise/" + oRow["DocId"].ToString();
                //szUrl_title = ClsHtml.FncUrlTitle(ref pDocId, ref pDocLngId, ref pUrl_DocId);

                szItem = "\n<li><a href =\""+ szUrl_title + "/" + oRow["DocId"].ToString() + "\" " + szTooltip + "\"><i class=\"txt-small\">" + szTitle + "</i></a>";
                szItem += cls.ClsHtml.FncHtmFlagLanguagesGalleryTortoise(Convert.ToUInt64(oRow["DocId"].ToString()), false)+"</li>";;
                //data-toggle="tooltip" data-html="true" title="<em>Tooltip</em> "
                r_FileCacheViewTT += szItem;
                
            }
            
            r_FileCacheViewTT += "\n</ul>";
            datatable.Dispose();
        }

    }
}