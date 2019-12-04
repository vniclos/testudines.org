using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data;



namespace testudines.cls
{
    public static class ClsHtml
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMmsg"></param>
        /// <param name="ClsGlobal_E_MsgType">cls.ClsGlobal.E_MsgType.alert.ToString()</param>
        /// <returns></returns>
        /// 

        public static string FncMsg_Alert(string pMmsg)
        {
            return FncMsgAlert(pMmsg, cls.ClsGlobal.E_MsgType.alert.ToString());
        }
        public static string FncMsg_Success(string pMmsg)
        {
            
            return FncMsgAlert(pMmsg, cls.ClsGlobal.E_MsgType.success.ToString());
        }
        public static string FncMsg_Warning(string pMmsg)
        {
           
            return FncMsgAlert(pMmsg, cls.ClsGlobal.E_MsgType.warning.ToString());
        }

        public static string FncMsgAlert(string pMmsg, string ClsGlobal_E_MsgType)
        {
            //ClsGlobal.E_MsgType.alert;
            //ClsGlobal.E_MsgType.success;
            //ClsGlobal.E_MsgType.warning;
            string szMsg = "";
            string szMsgSuccess = "\n<div class=\"alert-box success\">#msg#</div>\n";
            string szMsgWarning = "\n<div class=\"alert-box warning\">#msg#</div>\n";

            string szMsgAlert = "\n<div class=\"alert-box alert\">#msg#</div>\n";
            if (ClsGlobal_E_MsgType == ClsGlobal.E_MsgType.alert.ToString())
            {
                szMsg = szMsgAlert.Replace("#msg#", pMmsg);
                return szMsg;
            }
            if (ClsGlobal_E_MsgType == ClsGlobal.E_MsgType.success.ToString())
            {
                szMsg = szMsgSuccess.Replace("#msg#", pMmsg);
                return szMsg;
            }
            if (ClsGlobal_E_MsgType == ClsGlobal.E_MsgType.warning.ToString())
            {
                szMsg = szMsgWarning.Replace("#msg#", pMmsg);

                return szMsg;
            }
            return szMsg;
        }
        public static String spanYes
        { get{return "<span class=\"glyphicon glyphicon-check\">&nbsp;" + Resources.Strings.Yes + "</span>";}
}
    public static String spanNo
    {
        get { return "<span class=\"glyphicon glyphicon-unchecked\">&nbsp;" + Resources.Strings.No + "</span>"; }
    }

        public static string FncHtmlTitle(String szTitle, String szSubTitle, UInt64 pDocId, String pDocLngId, String UrlFriendlyParcial )
        {
            String szHtml = "<h1>" +szTitle + "<span class=\"fld-boxId\">Id.:" + pDocId.ToString() + "</span>";
            szHtml += FncHtmFlagLanguages(pDocId, UrlFriendlyParcial, true);
            return szHtml;
        }

        private static string FncHtmlTooltip(string pToolTipHelpText, string pTooltipText)
        {
            string sz = "<span class=\"has-tip\" data-width=\"210\" 	title=\"#Help#\">\"#Text#\"</span>";
            sz.Replace("Help", pToolTipHelpText);
            sz.Replace("Text", pTooltipText);
            return sz;
        }
        private static string FncHtmlReadMoreUpdateFlag(int DocId, string DocLngId, string szUrlFriendlyPartial)

        {
            string szHtmlFlag = "";
            string szUpdate = "";
            string szSql = "";

            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);

            szSql += " select  `tdoclng`.DoclngId ,";
            szSql += "  CONCAT( '/a_img/a_site/ico16/flag16_',doclngid,'.gif') as flag,";
            szSql += " `tdoclng`.`DocLngMetaTitle` AS `Title`,";
            szSql += " `tdoc`.`DocTypeGroup` AS `DocTypeGroup`,";
            szSql += " `tdoc`.`DocDateUpdate` AS `DocDateUpdate`,";
            szSql += " `tdoc`.`DocStdValLow` AS `DocStdValLow`,";
            szSql += " `tdoc`.`DocStdValHig` AS `DocStdValHig`,";
            szSql += " `tdoc`.`DocStdValMed` AS `DocStdValMed`";
            szSql += " from (`tdoclng` left join `tdoc`";
            szSql += " on(`tdoclng`.`DocId` = `tdoc`.`DocId`))";
            szSql += " where (`tdoc`.`DocIsActive` = 1 and `tdoclng`.DocId=" + DocId.ToString() + ")";
            szSql += " order by `tdoclng`.`DoclngId` ";
            szSql += " desc limit 20 ";
            MySqlCommand oSqlCmd = new MySqlCommand(szSql, oSqlCnn);
            DataTable oDt = new DataTable();
            MySqlDataAdapter oSqlDa = new MySqlDataAdapter(oSqlCmd);
            oSqlCnn.Open();
            oSqlDa.Fill(oDt);



            foreach (DataRow oRow in oDt.Rows)
            {

                szUpdate = oRow["DocDateUpdate"].ToString();
                szHtmlFlag += "<a href=\"/" + oRow[0].ToString() + szUrlFriendlyPartial + DocId.ToString() + "\">";
                szHtmlFlag += " <img src=\"" + oRow[1].ToString() + "\" title=\"" + oRow[2].ToString() + "\"/></a>&nbsp;";

            }
            if (szHtmlFlag != "")
            {
                szHtmlFlag = Resources.Strings.available_in + szHtmlFlag;
            }

            string szHtmlRef = Resources.Strings.Ref + " [" + DocId.ToString() + "-" + DocLngId + "] " + Resources.Strings.Updated + " " + szUpdate;

            cls.bbdd.ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            oSqlDa.Dispose();
            oDt.Dispose();
            return szHtmlFlag + " " + szHtmlFlag;
        }

        /// <summary>
        /// Hace un tootltip span
        /// </summary>
        /// <param name="pText"> texto o htmml siemper visible</param>
        /// <param name="pTextTooltip">texto o html visible en tooltip</param>
        /// <returns></returns>
        public static string FncHtmlToolTip(string pText, string pTextTooltip)
        {

            pTextTooltip = pTextTooltip.Trim();
            if (pTextTooltip.Length > 400) pTextTooltip = pTextTooltip.Substring(0, 400) + "...";
            pTextTooltip = pTextTooltip.Replace("(", ",");
            pTextTooltip = pTextTooltip.Replace(")", ",");
            pText = pText.Trim();
            pTextTooltip = pTextTooltip.Trim();

        
            string szTooltip = "<span  data-toggle=\"tooltip\" data-html=\"true\" data-placement=\"bottom\" data-width=\"610\" title=\"" + pTextTooltip + "\">" + pText + "</span>";

            return szTooltip;
        }

        /// <summary>
        /// Return flags with links to language version of document
        /// same times you need:   object.Text= Server.HtmlDecode(szHtml);
        /// </summary>
        /// <param name="DocId">url friendly with out doclngid for show document like /articles/articles/</param>
        /// <param name="szUrlFriendlyPartial">ulr frindly  out docid and doclngid , Ejem /articles/articles/</param>
        /// <param name="bShowAvailable">show available text/</param>

        /// <returns>/[]/[szUrlFriendlyPartial]/DocId
        /// Page for write language icon with link</returns>
        public static string FncHtmFlagLanguages(UInt64 DocId, string szUrlFriendlyPartial)
        {
            return FncHtmFlagLanguages(DocId, szUrlFriendlyPartial, true);
        }
        /// <summary>
        /// Limpia el pazth eliminado las dobles barras y cambiandolas a /
        /// </summary>
        /// <param name="szPath">String path pasado por referencia</param>
        public static void FncPathClear(ref string szPath)
        {
            szPath = szPath.Replace("\\", "/");
            while (szPath.Contains("//"))
            {
                szPath = szPath.Replace("//", "/");
            }

        }

       

        public static string FncHtmFlagLanguagesGalleryTortoise(UInt64 pDocId, bool pbShowAvailable)
        {
            String szDocId = pDocId.ToString().Trim();
            //string szGallery = "";
            string szHtml = "";

            //string szSelect = "Select tdoclng_sitemap.loc_title as url, tdoclng_testudines_abst.doclngid, CONCAT( '/a_img/a_site/ico16/flag16_',tdoclng_testudines_abst.doclngid,'.gif') as flag, tdoclng_testudines_abst.Title  from tdoclng_testudines_abst INNER JOIN tdoclng_sitemap on tdoclng_sitemap.DocId =tdoclng_testudines_abst.docid  and tdoclng_sitemap.DocLngId =tdoclng_testudines_abst.DocLngId  where tdoclng_testudines_abst.docid="+ pDocId.ToString()+" and tdoclng_sitemap.DocChapterId=''";

            string szSelect = "Select tdoclng_sitemap.loc_title as url, tdoclng_testudines_abst.doclngid, CONCAT( '/a_img/a_site/ico16/flag16_',tdoclng_testudines_abst.doclngid,'.gif') as flag, ";
            szSelect += " CONCAT( tdoclng_testudines_taxa_all.ATaxGrpL2270Genus,' ',tdoclng_testudines_taxa_all.ATaxGrpL2280Specie) AS title  from tdoclng_testudines_abst ";
            szSelect += " INNER JOIN tdoclng_sitemap on tdoclng_sitemap.DocId =tdoclng_testudines_abst.docid  and tdoclng_sitemap.DocLngId =tdoclng_testudines_abst.DocLngId ";
            szSelect += " INNER JOIN tdoclng_testudines_taxa_all ON  tdoclng_sitemap.DocId  =tdoclng_testudines_taxa_all.DocId ";
            szSelect += " where tdoclng_testudines_abst.docid="+ pDocId.ToString() + "  and tdoclng_sitemap.DocCapituleId='' ";

            DataTable oDt = new DataTable();
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect, ref oDt);
            string szUri;
            string szUriGallery = "";
            String szSpecie = "";
            String szTitle = "";
      
            foreach (DataRow oRow in oDt.Rows)
            {
                ///es/tortoises/testudo-hermanni
                szUri = oRow[0].ToString(); //"0/1en /2 tortoises/3 tortoise/4 acanthochelys-macrocephala"
                string[] aSz = szUri.Split('/');
              
               
                szUriGallery = "/"+ aSz[1] +"/" +   "/tortoises/images/"+ aSz[3] + "/1";///0 es/1 tortoises/2 tortoise/3 acanthochelys-macrocephala/
                szSpecie = " "+ aSz[3];
                szTitle =  szSpecie.Replace("-"," ");
                szHtml += "<a href=\"" + szUri + "\">";
                szHtml += " <img class=\"inline\" src=\"" + oRow[2].ToString() + "\" title=\"" + szTitle + "\"/></a>&nbsp;";
              

            }
            if (szHtml != "")
            {
               
                szHtml += "<a href=\"" + szUriGallery +  "\"title=\"" + Resources.Strings.images + szSpecie+ "\">" + "<span class=\"glyphicon glyphicon-picture\"></span></a>";

                if (pbShowAvailable)
                {
                    szHtml = Resources.Strings.available_in + szHtml;
                }
            }
            oDt.Dispose();

         
            return szHtml;
        }


        public static string FncHtmFlagLanguages(UInt64 DocId, string szUrlFriendlyPartial, bool bShowAvailable)
        {
            string szHtml = "";
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            string szSelect = "SELECT doclngid, CONCAT( '/a_img/a_site/ico16/flag16_',doclngid,'.gif') as flag, DocLngMetaTitle  from  `tdoclng` where docid=" + DocId.ToString();
            
            DataTable oDt = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelect,ref oDt);
            foreach (DataRow oRow in oDt.Rows)
            {
                szHtml += "<a href=\"/" + oRow[0].ToString() + szUrlFriendlyPartial + DocId.ToString() + "\">";
                szHtml += " <img class=\"inline\" src=\"" + oRow[1].ToString() + "\" title=\"" + oRow[2].ToString() + "\"/></a>&nbsp;";

            }
            if (szHtml != "")
            {
                if (bShowAvailable)
                {
                    szHtml = Resources.Strings.available_in + szHtml;
                }
            }


           
            oDt.Dispose();
            return szHtml;
        }


        public static string FncFlagGroup(String PATaxIdName)
        {
            //
            //http://www.testudines.org/es/taxons/taxon_group/Testudines
            //string szFlag = "";
            //Select DocId,DocLngId,    ATaxIdName from tdoclng_testudines_groups where ATaxIdName='chelidae'
            string SqlCmdString = "Select  docid, DocLngId,DescriptionShort, CONCAT('<a href=\"/',DocLngId,'/taxons/taxon_group/',ATaxIdName , '\", title=\"',ATaxIdName,'\"><img src=\"/a_img/a_site/ico16/flag16_',DocLngId,'.gif\" class=\"litax_ImgFlag\"/></a>' ) as url from tdoclng_testudines_groups  where ATaxIdName='" + PATaxIdName + "' order by DocLngId  DESC";

            DataTable oTb = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref SqlCmdString, ref oTb);
            string szFlags = "";
            string szDes = "";
            String szDesFull = "<span class=\"litaxFontMin\">";
            foreach (DataRow oRow in oTb.Rows)
            {
                szFlags += oRow["url"].ToString() + "&nbsp;";

                szDes = oRow["DescriptionShort"].ToString().Trim();
                if (szDes.Length > 15)
                {
                    szDesFull += "<br/>" + szDes;
                }
            }
            if (szDesFull.Length > 15) szFlags += szDesFull + "</span>";
            return szFlags;
        }
        //=================================
        //=================================
        //=================================
        // breadcrumb
        public static void FncHtmlBreadcrumbStart(ref String szBreadCrumb)
        { szBreadCrumb = "<nav class=\"breadcrumb\"><a class=\"breadcrumb-item\" href = \"/\">" + Resources.Strings.Home + "</a>"; }

        public static void FncHtmlBreadcrumbAdd(ref String szBreadCrumb, string title, string pUrl)
        {
            string sz = "";
            if (pUrl != "")
            {
                sz = "<a class=\"breadcrumb-item\" href = \"" + pUrl + "\"> " + title + "</a>";
            }
            else
            { sz = "<a class=\"breadcrumb-item active\">&nbsp;" + title + "</a>"; }

            szBreadCrumb += sz;


        }

        public static void FncHtmlBreadcrumbEnd(ref String szBreadCrumb) { szBreadCrumb += "</nav>"; }
        // breadcrumb end
        //=================================
        //=================================
        //=================================
        // 
        /// <summary>
        /// Le pasas el iddoc y obtiene toda la bibiografia relacionada ul li
        /// </summary>
        /// <param name="pDocIdParent"></param>
        /// <returns></returns>
        public static String FncHtmlBibliographyBld(UInt64 pDocIdParent)
        {
            string szHtml = "";
            String szCmd = "select  tdoc_biblio.CiteHtmlFull as cite from tdoc_biblio left join tdoc_biblio_rel on  tdoc_biblio.DocId=tdoc_biblio_rel.DocId";
            szCmd += " where tdoc_biblio_rel.DocIdParent=" + pDocIdParent.ToString() + " order by tdoc_biblio.CiteAutorYearABC";

            DataTable oDT = new DataTable("work");
            cls.bbdd.ClsMysql.FncFill_datatable(ref szCmd, ref oDT);
            String szCite = "";
            if (oDT.Rows.Count > 0)
            {
                szHtml += "\n<ul>";
                foreach (DataRow oRow in oDT.Rows)
                {
                    szCite = oRow["cite"].ToString().Trim();
                    if (szCite.Length > 10)
                    {
                        szHtml += "\n <li>" + szCite + "</li>";
                    }
                }
                szHtml += "\n</ul>";
            }

            return szHtml;
        }

        /// <summary>
        /// Obtiene la url friedly 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pDocLngId"></param>
        /// <returns></returns>
        public static String FncUrlTitle(ref UInt64 pDocId, ref String pDocLngId)
        {
            String szUrlTitle = "";
            String szCmd = "Select loc_title from tdoclng_sitemap Where docid = " +pDocId.ToString()+ " and docLngId = '"+ pDocLngId + "' and DocChapterId=''";
            szUrlTitle= cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd);

            return szUrlTitle;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pDocLngId"></param>
        /// <param name="pUrlDocId"> url por defecto, por si no encuentra, ocurre en documentos antiguos que no estan en sitemap</param>
        /// <param name="pDocChapterId">Se utiliza para los catitulos de las tortugas del enumerado capitule</param>
        /// <returns></returns>
        public static String FncUrlTitle(ref UInt64 pDocId, ref String pDocLngId, String pUrlDocId, ref String pDocChapterId)
        {
            String szUrlTitle = "";
            String szCmd = "Select loc_title from tdoclng_sitemap Where docid = " + pDocId.ToString() + " and docLngId = '" + pDocLngId + "' and DocChapterId='"+ pDocChapterId+"'";
            szUrlTitle = cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd);
            if (szUrlTitle == "") {
                szUrlTitle = pUrlDocId;
                if (pDocChapterId != "") { szUrlTitle += "/" + pDocChapterId; } 
            }

            return szUrlTitle;
        }
        /// <summary>
        /// obtiene la url friendly a partir de docId y doclngid
        /// Si no exsite devuelve la url por defecto 
        /// 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pDocLngId"></param>
        /// <param name="pUrlDocId">Url por defecto, basada en docid</param>
        /// <returns></returns>
        public static String FncUrlTitle(ref UInt64 pDocId, ref String pDocLngId,ref String pUrlDocId)
        {
            String szUrlTitle = "";
            String szCmd = "Select DocId, DocLngId, loc_title from tdoclng_sitemap Where docid = " + pDocId.ToString() + " and docLngId = '" + pDocLngId + "'";
            szUrlTitle = cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd);
            if (szUrlTitle == "") { szUrlTitle = pUrlDocId; }
            return szUrlTitle;
        }
        /// <summary>
        /// Devulve el Doc id basandose en la Url tipo url titulo del documento
        /// Para obener absolute pat usa
        /// string path = HttpContext.Current.Request.Url.AbsolutePath;
        /// </summary>
        /// <param name="sitemap_loc_titlel"></param>
        /// <returns></returns>
        public static UInt64 FncUrl_DocId_from_URL()
        {
          String sitemap_loc_title=  HttpContext.Current.Request.Url.AbsolutePath;
            UInt64 DocId = 0;
            string szCmd = "select DocId from  tdoclng_sitemap where loc_title ='" + sitemap_loc_title + "'";
            String szDocId=cls.bbdd.ClsMysql.FncGet_ExecuteScalar(ref szCmd);
            try
            { DocId = Convert.ToUInt64(szDocId); }
            catch
            { }
            return DocId;

        }
    }
}