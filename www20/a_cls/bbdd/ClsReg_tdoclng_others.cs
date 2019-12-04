
    using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_others


    {

        private cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc();
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
 
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";
        private String m_Title = "";
        private String m_Abstract = "";
        private String m_Body = "";

        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_others(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_others()
        {
        
            FncSqlBuildCommands();
            FncClear();
        }
        //---------------------------------------------------



        //--------------------------------------------------
        #region CLEAR
        //--------------------------------------------------
        public void FncClear()
        {
            m_DocId = 0;
            m_DocLngId = "";
            m_Title = "";
            m_Abstract = "";
            m_Body = "";

        }
        #endregion CLEAR
        //------------------------------
        //--------------------------------------------------------
        //----------------FncSqlBuildCommands-----------------------
        //--------------------------------------------------------
        public void FncSqlBuildCommands()
        {


            string szSql = "";



            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT * FROM tdoclng_others  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_others";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", Title ";
            szSql += ", Abstract ";
            szSql += ", Body ";


            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @Title ";
            szSql += ", @Abstract ";
            szSql += ", @Body ";

            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);


            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_others SET ";

            szSql += "Title=@Title ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", Body=@Body ";


            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);


            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_others  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", DocLngId";
            szSql += " FROM tdoclng_others  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
        }
        //--------------------------------------------------------



        //	-------------------------------------------------

        public bool FncSqlSave()
        {
            _mErrorBoolean = false;

            _mErrorString = "";

            bool b = false;	//-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;

            //.............................................................
            //.............................................................
            //.TODO DESCOMENTAR LINEAS CON PUNTOS EN CASO DE AUTONUMERICOS
            //.............................................................
            // TODO CAMBIAR m_idKey por la clave autonumerica que proceda..
            //   if (m_IdKEY == 0)
            //   {
            //       b = false;
            //   }
            //   else
            //   {
            //............................................................
            //............................................................

            // comprobar si existe el id a añadir

            // TODO Atencion en caso de claves alternavas

            // Atencion en caso de claves alternativas

            // añadir una fucion que la controle

            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            //.............................................................
            //........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
            //// } 
            //.............................................................
            if (b)
            {
                b = FncSqlUpdate();
            }
            else
            {
                b = FncSqlInsert();
            }
            //----------------------------
            // agregar a sitempap
            FncSaveSiteMap();
            ///
            _mErrorBoolean = b;
            return b;
        }
        private void FncSaveSiteMap()
        {
            string m_urlTemplate = "/others/other/";
            string m_urlDocType = "other";
            cls.bbdd.ClsReg_TDoclng_sitemap oSiteMap = new cls.bbdd.ClsReg_TDoclng_sitemap(cls.ClsGlobal.Connection_MARIADB);
            oSiteMap.FncSqlSave(m_DocId, m_DocLngId,"", m_urlTemplate, "", m_urlDocType, m_Title);

        }
        //------------------------------------------------------


        //-------------------------------------------------------
        //----------------FncSqlUpdate)--------------------------
        //-------------------------------------------------------
        private bool FncSqlUpdate()
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            ////-----------------------------------------------------;
            //// Configurar comando update. 
            ////-------------------------------------------------------;
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;


            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdUpdate.Connection = ClsMysql.MySqlConnection;;
            try
            {
                int i = oSqlCmdUpdate.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //  MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }
        //-------------------------------------------------------;


        //--------------------------------------------------------
        //----------------FncSqlInsert--------------------------
        //--------------------------------------------------------
        private bool FncSqlInsert()
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            //-----------------------------------------------------
            // Configurar comando Insert recuperando la identidad. 
            // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). 
            // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); 
            // ; SELECT @@IDENTITY	//-----------------------------------------------------
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;


            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;;
                oSqlCmdInsert.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //  MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }//--------------------------------------------------------
        //----------------FncSqlFind------------------------------
        //--------------------------------------------------------
        public bool FncSqlFind(UInt64 DocId, String DocLngId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
            oSqlCmdSelect.Parameters["@DocLngId"].Value = DocLngId;
            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    m_Title = oDR["Title"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();

                    oDR.Close();
                } //Cierre de if 
                else
                {
                    _mErrorBoolean = true;
                    _mErrorString = "Not found.";
                }//Cierre de else 
            }//Cierre de try 
            catch (SystemException ex)
            {

                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //  MessageBox.Show (_mErrorString); 
            }
            //------------------------------------------------------
            // cierre.
            //-------------------------------------------------------
            ClsMysql.FncClose();
            return !_mErrorBoolean;
            //--------------------------------------------------------------------
        }
        //--------------------------------------------------------r
        //----------------FncSqlDelete--------------------------
        //--------------------------------------------------------
        public bool FncSqlDelete(UInt64 DocId, String DocLngId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            //-----------------------------------------------------;
            // ELIMINAR REGISTRO. 
            //-------------------------------------------------------;
            oSqlCmdDelete.Connection = ClsMysql.MySqlConnection;;
            try
            {
                oSqlCmdDelete.Parameters["@DocId"].Value = DocId;
                oSqlCmdDelete.Parameters["@DocLngId"].Value = DocLngId;
                int i = oSqlCmdDelete.ExecuteNonQuery();
                if (i > 0)
                {
                    cls.bbdd.ClsReg_tdoclng oRegMeta = new ClsReg_tdoclng();
                    oRegMeta.FncSqlDelete(DocId, DocLngId);
                    FncClear();
                }
            }
            catch (MySqlException xcpt)
            {
                _mErrorString = xcpt.Message;
                _mErrorBoolean = true;
                //  MessageBox.Show (xcpt.Message );
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }
        //------------------------------------------------;

        //--------------------------------------------------------
        //----------------FncSqlExist------------------------------
        //--------------------------------------------------------
        public bool FncSqlExist(UInt64 DocId, String DocLngId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            bool b = false;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelectExist.Parameters["@DocId"].Value = DocId;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = DocLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }////--------------------------------------------------------r
        ////----------------FncSqlOpenCnn--------------------------
        ////--------------------------------------------------------



        //--------------------------------------------------
        #region VALORES_GETSET
        //--------------------------------------------------
  
        //------------------------------
        public bool ErrorBoolean
        {
            get { return _mErrorBoolean; }
            set { _mErrorBoolean = value; }
        }
        //------------------------------
        public string ErrorString
        {
            get { return _mErrorString; }
            set { _mErrorString = value; }
        }
        //------------------------------
        //................................

        public UInt64 DocId
        {
            set
            {
                m_DocId = value;
            }
            get { return m_DocId; }
        }

        //................................

        public String DocLngId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngId because is it too long,MaxLength=2";
                }
                m_DocLngId = sz;

            }
            get { return m_DocLngId.ToLower(); }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 256)
                {
                    sz = sz.Substring(0, 255);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=256";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String Abstract
        {
            set
            {
                m_Abstract = value;
            }
            get { return m_Abstract; }
        }

        //................................

        public String Body
        {
            set
            {
                m_Body = value;
            }
            get { return m_Body; }
        }



        #endregion VALORES_GETSET
        //========================================================================
        //========================================================================
        // devuelve el html del articulo
        // Si no existe el cache lo crea, 
        // si existe devuelve el fichero cache.
        public string FncGetCache_Html(bool bRebuil)
        {
            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "other");
            if (bRebuil) cls.cache.ClsCache.FncCacheFileDelete(szFileName);
            if (cls.ClsGlobal.CacheRebuid) { cls.ClsUtils.FncPathFileDelete(szFileName); }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncHtmlBldCache();

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
                return szHtml;
            }

        }
        /// <summary>
        /// Utiliza Server.HtmlDecode(string) para asignarlo a un label
        /// </summary>
        /// <returns></returns>
        private string FncHtmlBldCache()

        {
            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            //StringBuilder sb = new StringBuilder ();


            szHtml += "<h1 class=\"doctitle\">" + m_Title + "</h1>";
            if (oRegDoc.DocAuthors != "") { szHtml += "<h3> class=\"doctitlesub\">" + oRegDoc.DocAuthors + "</h3>"; }

            szHtml += "<div class=\"divboxAbstract \"><h2>" + Resources.Strings.Abstract + "</h2>";
            if (oRegDoc.DocImgThumbnail != "")
            {
                szHtml += "<img class=\"float-right t\"src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            szHtml += m_Abstract + "</div>\n";
            szHtml += "<div class=\"divboxArticle \"><h2>" + Resources.Strings.other + "</h2>" + m_Body + "</div>\n";

            if (oRegDoc.DocDocUploaded != "")
            {
                if (System.IO.File.Exists(ClsGlobal.DirDocStore + oRegDoc.DocDocUploaded))
                {
                    szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Anexed_document + "</h2>\n";

                    szHtml += "<a href=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocDocUploaded + "\" ico =\"ico\">" + oRegDoc.DocDocUploaded + "</a>";


                    szHtml += "</div>";
                }

            }

            if (oRegDoc.DocAcknowledgements != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Acknowledgements + "</h2>" + oRegDoc.DocAcknowledgements + "</div>\n");
            }
            if (oRegDoc.DocBibliography != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Bibliography + "</h2>" + oRegDoc.DocBibliography + "</div>\n");
            }
            szHtml = cls.tools.ClsGalleryFBox.FncReplacePrettyPhoto(ref szHtml);
            return szHtml;


        }
        //-------------------------------------------------
        public String FncHtmlBreadCrumb()
        {
            string szFileShortName = "other_BC";
            if (cls.cache.ClsCache.FncCacheFilePathExist(m_DocId, m_DocLngId, szFileShortName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(m_DocId, m_DocLngId, szFileShortName);
            }
            else
            {
                String szHtml = FncHtmlBldCacheBreadCrumb();
                String szHtmlDocType = szFileShortName;
                cls.cache.ClsCache.FncCacheFileSave(ref m_DocId, ref m_DocLngId, ref szHtmlDocType, ref szHtml);
                return szHtml;
            }

        }
        private string FncHtmlBldCacheBreadCrumb()
        {
            String szDescrip = "";
            if (m_Title.Length > 50) { szDescrip = m_Title.Substring(0, 49) + "..."; } else { szDescrip = m_Title; }
            szDescrip += "<span class=\"docref\"[" + DocLngId + "-" + DocId.ToString() + "]</span>";
            string szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);

            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.others, "/others/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.other + ": " + szDescrip, "");

            return szBreadCrumb;
        }

        public String FncCache_GET_last(bool bRebuild, UInt16 iCount = 20)
        {
            string szFileCache = cls.ClsGlobal.DirCache + "last_others.html";
            if (bRebuild) cls.ClsUtils.FncPathFileDelete(szFileCache);
            if (System.IO.File.Exists(szFileCache))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileCache);
            }
            else
            {
                String szHtml = FncHtmlBldLastothersCache(iCount);

                cls.cache.ClsCache.FncCacheFileSave(ref szFileCache, ref szHtml);
                return szHtml;
            }
        }

        private string FncHtmlBldLastothersCache(UInt16 iCount)
        {

            string szSqlSelect = "select loc_title as Url, `tdoclng_others`.`DocId` AS `DocId`,`tdoclng_others`.`DocLngId` AS `DocLngId`,`tdoclng_others`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_thumbnails/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`,`tdoc`.`DocStdValLow` AS `DocStdValLow`,`tdoc`.`DocStdValHig` AS `DocStdValHig`,`tdoc`.`DocStdValMed` AS `DocStdValMed`  from (`tdoclng_others` left join `tdoc` on((`tdoclng_others`.`DocId` = `tdoc`.`DocId`))) INNER JOIN tdoclng_sitemap  ON `tdoclng_others`.`DocId` = `tdoclng_sitemap`.`DocId` AND   `tdoclng_others`.`DocLngId` = `tdoclng_sitemap`.`DocLngId`  where (`tdoc`.`DocIsActive` = 1) order by `tdoclng_others`.`DocId` desc limit " + iCount.ToString() + ";";


            //string szSqlSelect = "Select `DocId`,`DocLngId`,`Title`,`DocImgThumbnail`,`DocDateUpdate`,  `DocStdValLow`, `DocStdValHig`, `DocStdValMed` from `wotherlast20`";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
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
            sb.Append("<h2>Last others</h2>");
            sb.Append("<ul>");
            string szUrlDocId = "";
            string szUrlDocIdTitle = "";
            string szUrl = "";
            UInt64 pDocid = 0;
            string pszDocId = "";
            string pszDocLngId = "";
            foreach (DataRow oRow in oDt.Rows)
            {
                pszDocId = oRow["DocId"].ToString();
                pDocid = Convert.ToUInt64(pszDocId);
                pszDocLngId = oRow["DocLngId"].ToString();

                szUrlDocId = "/" + pszDocLngId + "/tortoises/others/other/" + pszDocId;

                szUrlDocIdTitle = ClsHtml.FncUrlTitle(ref pDocid, ref pszDocLngId);
                if (szUrlDocIdTitle != "") { szUrl = szUrlDocIdTitle; } else { szUrl = szUrlDocId; };

                sb.Append("<li><b><a href=\"" + szUrl + "\">" + oRow["Title"].ToString() + "</a></b>");
                // DocImgThumbnail
                sb.Append("<br/ ><span class=\"mmin-x\">" + Resources.Strings.Updated + " " + oRow["DocDateUpdate"].ToString() + "\"</span>");
                sb.Append("<br/>" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(oRow["DocId"].ToString()), "/tortoises/others/other/"));
                sb.Append("<br/><br/></li>");
            }

            sb.Append("<li><b><a href=\"/" + ClsGlobal.LngIdThread + "/tortoises/others/others-list\">" + Resources.Strings.others_last_updates + "</a></b>");

            sb.Append("<ul>");

            return sb.ToString();
        }
        //============================================================
        //==============================================================

        public String FncCache_GET_lastImg(bool bRebuild, UInt16 iCount)
        {
            string szFileCache = cls.ClsGlobal.DirCache + "last_others_img.html";
            if (bRebuild) { ClsUtils.FncPathFileDelete(szFileCache); }
            if (System.IO.File.Exists(szFileCache))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileCache);
            }
            else
            {
                String szHtml = FncCache_GET_lastImgBld(ref iCount);

                cls.cache.ClsCache.FncCacheFileSave(ref szFileCache, ref szHtml);
                return szHtml;
            }
        }

        private string FncCache_GET_lastImgBld(ref UInt16 iCount)
        {
            if (DocLngId.Length > 3) DocLngId = DocLngId.Substring(0, 2);
            string szSql = "";
            szSql += "SELECT `tdoclng_others`.`DocId` as `DocId`, `tdoclng_others`.`DocLngId` as `DocLngId`, `tdoclng_others`.`Abstract` as `Abstract`,  `tdoclng_others`.`Title` as `Title`, `tdoclng_others`.`abstract` as `abstract`, `tdoc`.`DocTypeGroup`, `tdoc`.`DocTypeGroupSub` , `tdoc`.`DocAuthors` ,";
            szSql += " CONCAT( '" + ClsGlobal.UrlDocStore + "', `tdoc`.`DocImgThumbnail`) as DocImgThumbnail, `tdoc`.`DocDateCreation`, `tdoc`.`DocDateUpdate`,  `tdoc`.`DocStdVisitCount` ";
            szSql += " FROM `tdoclng_others` LEFT JOIN `tdoc` ON `tdoclng_others`.`DocId` = `tdoc`.`DocId`  ";
            szSql += " Where `tdoc`.`DocIsActive`='1'     GROUP BY DOCID order by  tdoc.DocDateUpdate desc limit 5";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oDt = new DataTable();
            oCnn.Open();
            oDa.Fill(oDt);
            oCnn.Close();
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Dispose();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<h2 class=\"h2_reverse\">" + Resources.Strings.Last_Update_Articles + "</h2>");
            sb.Append("\n");
            string szUrl = "";
            string szUrlDocid = "";
            string szUrdDocTitle = "";
            string szDocLngId = "";
            UInt64 pDocid = 0;
            string pszDocid = "";
            string szUrlTemplate = "/tortoises/others/other/";
            foreach (DataRow oRow in oDt.Rows)
            {
                pszDocid = oRow["DocId"].ToString();
                pDocid = Convert.ToUInt64(pszDocid);
                szDocLngId = oRow["DocLngId"].ToString();
                szUrl = "";

                szUrlDocid = "/" + oRow["DocLngId"].ToString() + szUrlTemplate + oRow["DocId"].ToString();
                szUrdDocTitle = szUrdDocTitle = cls.ClsHtml.FncUrlTitle(ref pDocid, ref szDocLngId);
                if (szUrdDocTitle != "") { szUrl = szUrdDocTitle; } else { szUrl = szUrlDocid; }

                sb.Append("\n<h2><a href=\"" + szUrl + "\">" + oRow["Title"].ToString() + "</a></h2>");
                sb.Append("");
                sb.Append("<img class=\"imgleft\" src=\" " + oRow["DocImgThumbnail"].ToString() + "\"/>");
                sb.Append("<img class=\"\" src=\" " + oRow["DocImgThumbnail"].ToString() + "\"/>");
                sb.Append(oRow["Abstract"].ToString());
                // DocImgThumbnail
                sb.Append("<span class=\"mmin-x\">" + Resources.Strings.Updated + " " + oRow["DocDateUpdate"].ToString());
                sb.Append("<br/>" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(oRow["DocId"].ToString()), szUrlTemplate) + "\"</span>");
                sb.Append("<hr />");
            }

            //  sb.Append("<li><b><a href=\"/" + ClsGlobal.LngIdThread + "/taxons/taxon\">" + Resources.Strings.Articles_clasifiated_list + "</a></b>");

            sb.Append("\n");

            return sb.ToString();
        }

    }
}

//--------------------------------------------------