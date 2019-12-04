using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.cache
{
    public class ClsCache_Reg_tdoc_acknowledgment
    {
        private String m_szHtmlView = "";
        private String m_FileCacheView = "";
        public ClsCache_Reg_tdoc_acknowledgment() { }
        public String FncCache_GET(bool bRebuildCache, String pIdLng)
        {
            m_szHtmlView = "";
            m_FileCacheView = ClsGlobal.DirCache + "acknowledgment.html";




            if (bRebuildCache) { cls.cache.ClsCache.FncCacheFileDelete(m_FileCacheView); }


            if (!cls.cache.ClsCache.FncCacheFilePathExist(m_FileCacheView))
            {
                FncBldCache();
                cls.cache.ClsCache.FncCacheFileSave(ref m_FileCacheView, ref m_szHtmlView);



            }


            try
            {
                m_szHtmlView = cls.cache.ClsCache.FncCacheFileRead(m_FileCacheView);
            }
            catch
            {; }
            return m_szHtmlView;
        }




        private void FncBldCache()
        {

            string szSqlSelect = "Select tdoc_acknowledgment.DocId, tdoc_acknowledgment.Title  as DocumentName, tdoc_acknowledgment.UrlExternal, tdoc_acknowledgment.IsAuthorizeAll, tdoc.DocIsActive  from  `tdoc_acknowledgment`   LEFT JOIN `tdoc` ON tdoc_acknowledgment.DocId = tdoc.DocId  order by tdoc_acknowledgment.Title";
            int iRows = 0;

            string[] szCols = new String[3];
            string szInicio = "\n<div class=\"col-sm-6 col-md-6\">\n<ul>";
            string szFin = "</ul>\n</div>\n\n\n";
            szCols[0] = szInicio;
            szCols[1] = szCols[0];

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();

            MySqlCommand oCmd = new MySqlCommand(szSqlSelect, oCnn);
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
            System.Data.DataSet oDS = new System.Data.DataSet();
            oDA.Fill(oDS);

            //D:\_Testudines\www\a_img\a_site\ico16

            iRows = oDS.Tables[0].Rows.Count;
            int iCol = 0;
            string szInitialBefore = "";
            string szInitialCurrent = "";
            string szName = "";
            string szIsAuthorizeAll = "";
            string szHtml = "";
            szCols[0] = "";
            szCols[1] = "";
            szHtml = "";
            string szUrlExternal = "";
            string szUrlDocsAuthor = "";
            string szAuthorizeAll = "";
            string szDocId = "";
            //string szTest = "";
            int iItemsLetra = 0;
            szHtml = "<div><img src=\"/a_img/a_site/ico16/ico-star.png\">" + "= Authorize the use all your pictures</div>";
            foreach (DataRow oRow in oDS.Tables[0].Rows)
            {
                szName = oRow["DocumentName"].ToString().Trim();
                szUrlExternal = oRow["UrlExternal"].ToString().Trim();
                szAuthorizeAll = oRow["IsAuthorizeAll"].ToString().Trim();
                szDocId=oRow["DocId"].ToString().Trim(); 
                if (szAuthorizeAll == "True")
                {
                    szIsAuthorizeAll = "&nbsp;<img src=\"/a_img/a_site/ico16/ico-star.png\" title=\"Thank's for Authorize the use all your pictures\">";
                }
                else
                {
                    szIsAuthorizeAll = "";
                }


                szInitialCurrent = cls.ClsUtils.RemoveAccentsWithNormalization(szName.Substring(0, 1).ToLower());
                szUrlDocsAuthor = "<a href=\"/es/others/acknowledgements/acknowledgement/"+szDocId+"?author=" + szName.Replace(" ", "_") + "\"> <img src=\"/a_img/a_site/ico16/ico-linkin2.png\" title=\"Documents\"/></a> ";
                if (szInitialCurrent != szInitialBefore)
                {
                    iItemsLetra = 0;
                    if (szInitialBefore != "")
                    {
                        szCols[0] += szFin;
                        szCols[1] += szFin;

                        szHtml += szHtml = "\n\n\n\n<div class=\"container-fluid\">\n<div class=\"row\">\n\n  <div class=\"col-12\"> <h2><b>" + szInitialBefore.ToUpper() + "</b></h2></div>";
                        szHtml += szCols[0] + szCols[1] + "\n\n</div><hr />\n</div>\n\n\n\n";


                    }
                    szCols[0] = szInicio;
                    szCols[1] = szInicio;

                    iCol = 0;

                }
                iItemsLetra++;
                szInitialBefore = szInitialCurrent;
                szCols[iCol] += "<li>" + szName;

                szCols[iCol] += szUrlDocsAuthor;
                if (szUrlExternal != "")
                {
                    if (szUrlExternal.StartsWith("http://"))
                    {

                        szCols[iCol] += "<a href=\"";
                    }
                    else
                    {
                        szCols[iCol] += "<a href=\"http://";
                    }

                    szCols[iCol] += szUrlExternal + "\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\" title=\"Web site\"/></a>";
                }
                szCols[iCol] += szIsAuthorizeAll + "</li>";
                iCol++;
                if (iCol == 2) iCol = 0;
            }
            szCols[0] += szFin;
            szCols[1] += szFin;

            // Si exite uno no escrito se agrega 
            if (iItemsLetra > 0)
            {
                szHtml += szHtml = "\n<div class=\"row\">\n\n <h2><b>" + szInitialBefore.ToUpper() + "</b></h2>";
                szHtml += szCols[0] + szCols[1] + "</hr>\n</div>\n";

                szCols[0] = szInicio;
                szCols[1] = szInicio;
                szCols[0] += szFin;
                szCols[1] += szFin;
            }


            oDS.Dispose();
            oDA.Dispose();
            oCnn.Close();
            oCnn.Dispose();
            szHtml += "<h2> " + Resources.Strings.others + "</h2>";
            szHtml += " \n<ul>";
            szHtml += " \n<li><b>" + Resources.Strings.SourcesUsuallyConsulted + "</b></li>";
            szHtml += " \n<li>IUCN Red List<a href=\"http://www.iucnredlist.org/\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"> </a></li>";
            szHtml += " \n<li>Peter Ueth, Reptile database<a href=\"http://www.reptile-database.org/\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Turtles of the world. C.H. Ernst, R.G.M. Altenburg & R.W. Barbou<a href=\"http://wbd.etibioinformatics.nl/bis/turtles.php\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>ITIS, the Integrated Taxonomic Information System!<a href=\"http://www.itis.gov/\">   <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>CITES<a href=\" http://www.cites.org/\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>USGR<a href=\" http://hydrosheds.cr.usgs.gov/dataavail.php/\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Kottek, M., J. Grieser, C. Beck, B. Rudolf, and F. Rubel, 2006: World Map of the Köppen-Geiger climate classification updated. Meteorol. Z., 15, 259-263. DOI: 10.1127/0941-2948/2006/0130.</a></li>";
            szHtml += " \n<li>Google<a href=\"http://www.google.com\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Flicrk<a href=\"http://www.flickr.com\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Calphotos Berkeley<a href=\"http://calphotos.berkeley.edu/\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li><b>" + Resources.Strings.TechnicalResouces + "</b></li>";
            szHtml += " \n<li>Maria DB, Michael Widenius<a href =\"https://mariadb.org/\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>QGIS, Sistema de Información Geográfica libre y de Código Abierto<a href =\" http://www.qgis.org/\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"><a href=\"http://koeppen-geiger.vu-wien.ac.at/present.htm\"><img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Foundation.css  made by ZURB<a href =\"http://foundation.zurb.com\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>JQuery<a href=\"http://jquery.com\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>Inkscape<a href=\"http://inkscape.org/\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n<li>fancybox.net<a href=\"http://http://fancybox.net/\"> <img src=\"/a_img/a_site/ico16/ico-linkout.png\"></a></li>";
            szHtml += " \n</ul>";
            m_szHtmlView = szHtml;
        }
        //===========================================
        //===========================================

        public String FncCache_GET_Reg(UInt64 pDocId, String pIdLng, bool pbRebuildCache)
        {
            String szHtml = "";


            string szFilename = cls.cache.ClsCache.FncCacheFilePath(pDocId, pIdLng, "acknowledgment");


            if (pbRebuildCache) { cls.cache.ClsCache.FncCacheFileDelete(szFilename); }


            if (!cls.cache.ClsCache.FncCacheFilePathExist(szFilename))
            {

                FncCache_GET_Reg_BLd(ref szHtml, ref pDocId);
                cls.cache.ClsCache.FncCacheFileSave(ref szFilename, ref szHtml);

            }


            try
            {
                szHtml = cls.cache.ClsCache.FncCacheFileRead(szFilename);
            }
            catch
            {; }
            return szHtml;
        }
        private void FncCache_GET_Reg_BLd(ref String szHtml, ref UInt64 pDocId)
        {

            cls.bbdd.ClsReg_tdoc oRegDoc = new bbdd.ClsReg_tdoc();
            cls.bbdd.ClsReg_tdoc_acknowledgment oReg = new bbdd.ClsReg_tdoc_acknowledgment();
            oReg.FncSqlFind(pDocId);
            oRegDoc.FncSqlFind(pDocId);
            szHtml = "\n<h1>" + Resources.Strings.Acknowledgements + " " + oReg.Title + "</h1>";
            szHtml += "\n<img class=\"imgright\"src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            if (oReg.Abstract != "") { szHtml += "\n<p><b>" + Resources.Strings.Abstract + "</b><br>" + oReg.Abstract + "</p>"; }
            if (oReg.Body != "") { szHtml += "\n<p><b>" + Resources.Strings.body + "</b><br>" + oReg.Body + "</p>"; }
            if (oReg.UrlExternal != "") {szHtml += "\n<p><b>" + Resources.Strings.URL + "</b><br>" + oReg.UrlExternal + "</p>"; }
            if (oReg.CiteName != "") { szHtml += "\n<p><b>" + Resources.Strings.CiteName + "</b><br>" + oReg.CiteName + "</p>"; };
            if (oReg.CiteFull != "") { szHtml += "\n<p><b>" + Resources.Strings.CiteFull + "</b><br>" + oReg.CiteFull + "</p>"; }


           // classify = (input > 0) ? "positive" : "negative";
            string zYesNo = (Convert.ToBoolean(oReg.IsColaborator.ToString())) ?cls.ClsHtml.spanYes: cls.ClsHtml.spanNo;

            szHtml += "\n<p><b>" + Resources.Strings.IsColaborator + "</b><br>" + zYesNo + "</p>";

            zYesNo = (Convert.ToBoolean(oReg.IsAuthorizeAll.ToString())) ? cls.ClsHtml.spanYes : cls.ClsHtml.spanNo;
            szHtml += "\n<p><b>" + Resources.Strings.IsAuthorizeAll + "</b><br>" + zYesNo + "</p>";
        
        }

        public String FncCache_GET_last(String pIdLng, bool pbRebuildCache, UInt32 pCount)
        {
            String szHtml = "";


            string szFilename = cls.cache.ClsCache.FncCacheFilePath(0, "", "acknowledgment_last");


            if (pbRebuildCache) { cls.cache.ClsCache.FncCacheFileDelete(szFilename); }


            if (!cls.cache.ClsCache.FncCacheFilePathExist(szFilename))
            {

                FncCache_GET_last_BLD(ref szHtml, pCount);
                cls.cache.ClsCache.FncCacheFileSave(ref szFilename, ref szHtml);

            }


            try
            {
                szHtml = cls.cache.ClsCache.FncCacheFileRead(szFilename);
            }
            catch
            {; }
            return szHtml;
        }
        private void FncCache_GET_last_BLD(ref String szHtml, UInt32 pCount)

        {

            String szSqlCmd = "select   tdoc_acknowledgment.DocId , tdoc_acknowledgment.Title as Name,  tdoc_acknowledgment.UrlExternal as url , tdoc_acknowledgment.UrlExternal, tdoc.DocDateCreation from tdoc_acknowledgment left join tdoc on tdoc_acknowledgment.DocId = tdoc.DocId order by tdoc.DocDateCreation desc  LIMIT "+ pCount.ToString();
            MySqlConnection oCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, oCnn);
            oCnn.Open();
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oDT = new DataTable();
            oDa.Fill(oDT);
            oCnn.Close();
            oDa.Dispose();
            oCmd.Dispose();
            szHtml = "";
            szHtml = "<ul>";
            foreach (DataRow oRow in oDT.Rows)
            {
                szHtml += "<li><b>" + oRow["Name"].ToString() + "</b> ";
                szHtml += oRow["url"].ToString()+"</li>";

            }
            szHtml += "</ul>";


        }
        public String FncCache_GET_SpeciesCollaborate(ref UInt64 pDocId)
        {
            cls.bbdd.ClsReg_tdoc_acknowledgment oReg = new bbdd.ClsReg_tdoc_acknowledgment();
            oReg.FncSqlFind(pDocId);
            string szCite = oReg.CiteName;

            String szHtml = "";
            String szSqlCmd = "select tdoc.docid, tdoc.DocAcknowledgements, concat(tdoclng_testudines_taxa_all.ATaxGrpL2270Genus, ' ', tdoclng_testudines_taxa_all.ATaxGrpL2280Specie) as specie from tdoc left join tdoclng_testudines_taxa_all on tdoc.docid = tdoclng_testudines_taxa_all.docid  ";
            szSqlCmd += "where DocAcknowledgements like '%" + szCite + "%' and tdoclng_testudines_taxa_all.ATaxGrpL2280Specie is not null";


            MySqlConnection oCnn = new MySqlConnection(cls.ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, oCnn);
            oCnn.Open();
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oDT = new DataTable();
            oDa.Fill(oDT);
            oCnn.Close();
            oDa.Dispose();
            oCmd.Dispose();
            szHtml += "\n<div class=\"cols-12\">\n<h2>" + Resources.Strings.Collaborate_on + "</h2";
            szHtml += "\n<ul>";
            foreach (DataRow oRow in oDT.Rows)
            {
                szHtml += "\n<li> " + oRow["specie"].ToString();
                
                szHtml += "&nbsp;<a href=\"/es/tortoises/" + oRow["docid"].ToString() + "\">" + Resources.Strings.Go + "</a>";
                szHtml += "\n</li>";
            }
            szHtml += "\n</ul>\n</div>";

            return szHtml;
        }

    }

}