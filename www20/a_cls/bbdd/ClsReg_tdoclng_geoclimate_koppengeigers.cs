using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_geoclimate_koppengeigers
    {
        private cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc(); 
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
       
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectListCode=new MySqlCommand ();


        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";
        private String m_Title = "";
        private String m_ImgRainTemp = "";
        private String m_Abstract = "";
        private String m_Body = "";
        private Int32 m_EcozoneListOrder = 0;
        private String m_EcozoneListCode = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_geoclimate_koppengeigers(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_geoclimate_koppengeigers()
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
            m_ImgRainTemp = "";
            m_Abstract = "";
            m_Body = "";
            m_EcozoneListOrder = 0;
            m_EcozoneListCode = "";
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
            szSql = "SELECT * FROM tdoclng_geoclimate_koppengeigers  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
                      
            szSql = "SELECT DocId FROM tdoclng_geoclimate_koppengeigers  ";
            szSql += " WHERE ";
            szSql += "(EcozoneListCode=@EcozoneListCode )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelectListCode.CommandText = szSql;
            oSqlCmdSelectListCode.Parameters.Add("@EcozoneListCode", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdSelectListCode.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
   
            
            


            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_geoclimate_koppengeigers";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", Title ";
            szSql += ", ImgRainTemp ";
            szSql += ", Abstract ";
            szSql += ", Body ";
            szSql += ", EcozoneListOrder ";
            szSql += ", EcozoneListCode ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @Title ";
            szSql += ", @ImgRainTemp ";
            szSql += ", @Abstract ";
            szSql += ", @Body ";
            szSql += ", @EcozoneListOrder ";
            szSql += ", @EcozoneListCode ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
           
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ImgRainTemp", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@EcozoneListOrder", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@EcozoneListCode", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_geoclimate_koppengeigers SET ";

            szSql += "Title=@Title ";
            szSql += ", ImgRainTemp=@ImgRainTemp ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", Body=@Body ";
            szSql += ", EcozoneListOrder=@EcozoneListOrder ";
            szSql += ", EcozoneListCode=@EcozoneListCode ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ImgRainTemp", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@EcozoneListOrder", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@EcozoneListCode", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_geoclimate_koppengeigers  ";
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
            szSql += " FROM tdoclng_geoclimate_koppengeigers  ";

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
            _mErrorBoolean = b;
            return b;
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
            oSqlCmdUpdate.Parameters["@ImgRainTemp"].Value = m_ImgRainTemp;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;
            oSqlCmdUpdate.Parameters["@EcozoneListOrder"].Value = m_EcozoneListOrder;
            oSqlCmdUpdate.Parameters["@EcozoneListCode"].Value = m_EcozoneListCode;
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
            oSqlCmdInsert.Parameters["@ImgRainTemp"].Value = m_ImgRainTemp;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;
            oSqlCmdInsert.Parameters["@EcozoneListOrder"].Value = m_EcozoneListOrder;
            oSqlCmdInsert.Parameters["@EcozoneListCode"].Value = m_EcozoneListCode;
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
                    m_ImgRainTemp = oDR["ImgRainTemp"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();
                    m_EcozoneListOrder = Convert.ToInt32(oDR["EcozoneListOrder"].ToString().Trim());
                    m_EcozoneListCode = oDR["EcozoneListCode"].ToString().Trim();
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
        public bool FncSqlDelete(Int64 DocId, String DocLngId)
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
        }
        //-------------------------------------------------------
        //-------------------------------------------------------
       public bool FncSqlFindListCode(string EcozoneListCode, string DocLngId  )
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
             oSqlCmdSelectListCode.Connection = ClsMysql.MySqlConnection;;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelectListCode.Parameters["@EcozoneListCode"].Value = EcozoneListCode;
            oSqlCmdSelectListCode.Parameters["@DocLngId"].Value = DocLngId;
           
           UInt64 IdDoc=Convert.ToUInt64(oSqlCmdSelectListCode.ExecuteScalar());
           if (IdDoc == 0)
           {
               FncClear();
               return false;
           }
           else
           {
               return FncSqlFind(IdDoc, DocLngId);
           }
        }
        
       
        public bool  FncSqlFindByEcozoneListCode( string pDocLngId, string pEcozoneListCode )
        {
            bool bFind = false;
            string szSql = "select DocId from `tdoclng_geoclimate_koppengeigers` where`DocLngId`='" + pDocLngId + "' and `EcozoneListCode`='" + pEcozoneListCode + "'";
             if (!ClsMysql.FncOpen(""))
                return false;
             MySqlCommand oCmd = new MySqlCommand(szSql, cls.bbdd.ClsMysql.MySqlConnection);
             try
             {
                 UInt64 uiId = Convert.ToUInt64(oCmd.ExecuteScalar().ToString());
                 bFind = FncSqlFind(uiId, pDocLngId);
             }
             catch
             { bFind = false; }
               return bFind;
        }


        /// Utiliza Server.HtmlDecode(string) para asignarlo a un label
        /// </summary>
        /// <returns></returns>
        /// 

   
        //--------------------------------------------------
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
                m_DocLngId = sz.ToLower ();

            }
            get { return m_DocLngId; }
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

        public String ImgRainTemp
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 256)
                {
                    sz = sz.Substring(0, 255);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ImgRainTemp because is it too long,MaxLength=256";
                }
                m_ImgRainTemp = sz;

            }
            get { return m_ImgRainTemp; }
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

        //................................

        public Int32 EcozoneListOrder
        {
            set
            {
                m_EcozoneListOrder = value;
            }
            get { return m_EcozoneListOrder; }
        }

        //................................

        public String EcozoneListCode
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 5)
                {
                    sz = sz.Substring(0, 4);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_EcozoneListCode because is it too long,MaxLength=5";
                }
                m_EcozoneListCode = sz;

            }
            get { return m_EcozoneListCode; }
        }

        #endregion VALORES_GETSET

        //========================================================
        //==========================================================
        //===========================================================
        // devuelve el html del articulo
        // Si no existe el cache lo crea, 
        // si existe devuelve el fichero cache.
        public string FncGetCache_Html(bool bRebuild)
        {

            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "ecozone");

            if (cls.ClsGlobal.CacheRebuid || bRebuild) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }

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


        public string FncHtmlBldCache()
        {
            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            StringBuilder sb = new StringBuilder();
            //szHtml+=("<H1 class=\"h1_title\">" + m_Title + "</h1>\n");
            // szHtml+=("<H2 class=\"h2_titlesub\">Ref.: " + m_DocId.ToString() + "-" + m_DocLngId + "</h1>\n");
            szHtml += "<div class=\"row \"><h2>" + Resources.Strings.Abstract + "</h2>";
            if (oRegDoc.DocImgThumbnail != "" && !oRegDoc.DocImgThumbnail.Contains("noimage"))
            {
                szHtml += "<img class=\"imgleft\"src=\"" + ClsGlobal.DirDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            //  /mmedia/ecobotedageo/ecobotedageo/habitats/ecobotedageo/zoogeograhyecozones_11b.png
            if (m_ImgRainTemp != "")
            {
                string path = ClsGlobal.DirRoot + m_ImgRainTemp;
                if (System.IO.File.Exists(path))
                {
                    szHtml += "<img class=\"imgright\"src=\"" + m_ImgRainTemp + "\"/>";

                }

            }

            szHtml += m_Abstract + "</div>\n";
            szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Ecozone + "</h2>" + m_Body + "</div>\n";

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
            return szHtml;


        }

        public String FncCache_GET_last(bool bRebuild, UInt16 iCount)
        {
            string szFileCache = cls.ClsGlobal.DirCache + "last_ecozones.html";
            if (bRebuild) { ClsUtils.FncPathFileDelete(szFileCache); }
            if (System.IO.File.Exists(szFileCache))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileCache);
            }
            else
            {
                String szHtml = FncHtmlBldLastEcozonesCache(iCount);

                cls.cache.ClsCache.FncCacheFileSave(ref szFileCache, ref szHtml);
                return szHtml;
            }
        }

        private string FncHtmlBldLastEcozonesCache(UInt16 iCount)
        {

            string szSqlSelect = "select `tdoclng_geoclimate_koppengeigers`.`DocId` AS `DocId`,`tdoclng_geoclimate_koppengeigers`.`DocLngId` AS `DocLngId`,`tdoclng_geoclimate_koppengeigers`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_thumbnails/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`,`tdoc`.`DocStdValLow` AS `DocStdValLow`,`tdoc`.`DocStdValHig` AS `DocStdValHig`,`tdoc`.`DocStdValMed` AS `DocStdValMed` from (`tdoclng_geoclimate_koppengeigers` left join `tdoc` on((`tdoclng_geoclimate_koppengeigers`.`DocId` = `tdoc`.`DocId`))) where (`tdoc`.`DocIsActive` = 1) order by `tdoclng_geoclimate_koppengeigers`.`DocId` desc limit " + iCount.ToString(); ;


            //string szSqlSelect = "Select `DocId`,`DocLngId`,`Title`,`DocImgThumbnail`,`DocDateUpdate`,  `DocStdValLow`, `DocStdValHig`, `DocStdValMed` from `wecozonelast20`";
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
            sb.Append("<h2>Last ecozones</h2>");
            sb.Append("<ul>");
            string szUrl = "";
            foreach (DataRow oRow in oDt.Rows)
            {
                szUrl = "/" + oRow["DocLngId"].ToString() + "/ecozones/ecozone/" + oRow["DocId"].ToString();

                sb.Append("<li><b><a href=\"" + szUrl + "\">" + oRow["Title"].ToString() + "</a></b>");
                // DocImgThumbnail
                sb.Append("<br/ ><span class=\"mmin-x\">" + Resources.Strings.Updated + " " + oRow["DocDateUpdate"].ToString() + "\"</span>");
                sb.Append("<br/>" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(oRow["DocId"].ToString()), "/ecozones/ecozone/"));
                sb.Append("<br/><br/></li>");
            }

            sb.Append("<li><b><a href=\"/" + ClsGlobal.LngIdThread + "/ecozones/ecozones\">" + Resources.Strings.mnOthers_ecozones_list + "</a></b>");

            sb.Append("<ul>");

            return sb.ToString();
        }
        //==============================================
        public String FncHtmlBreadCrumb()
        {

            String szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "ecozone_BC");
            if (cls.ClsGlobal.CacheRebuid) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }
            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncHtmlBldCacheBreadCrumb();

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
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

            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Ecozones, "/ecozones/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, Resources.Strings.Ecozone + ": " + szDescrip, "");

            return szBreadCrumb;
        }


    }
}
