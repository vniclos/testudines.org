using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web;
namespace testudines.cls.bbdd
{
    public enum E_SiteMapFrecuency { always, hourly, daily, weekly, monthly, yearly, never }
     //<summary>
    //Descripción breve de ClsReg_TDoclng_sitemap
    //<//summary>
    public class ClsReg_TDoclng_sitemap
    {
        private DateTime dAyer = System.DateTime.Today.AddDays(-1);
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
        private string _mMySqlConnectionString = "";
        private MySqlConnection oSqlCnn = new MySqlConnection();
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";
        private String m_DocChapterId = "";
        private String m_loc_docid = "";
        private String m_loc_title = "";
        private String m_changefreq = "";
        private String m_lastmod = "";
        private String m_priority = "";
     
        private String m_urltemplate = "";
        private String m_DocClass = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsReg_TDoclng_sitemap(string szMySqlConnectionString)
        {
            _mMySqlConnectionString = szMySqlConnectionString;
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
            m_DocChapterId = "";
            m_loc_docid = "";
            m_loc_title = "";
            m_changefreq = "";
            m_lastmod = "";
            m_priority = "";
          //  m_LastUpdate = 0;
            m_urltemplate = "";
            m_DocClass = "";
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
            szSql = "SELECT * FROM tdoclng_sitemap  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            szSql += " AND (DocChapterId=@DocChapterId )";
        

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelect.Parameters.Add("@DocChapterId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_sitemap";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", DocChapterId ";
            
        szSql += ", loc_docid ";
            szSql += ", loc_title ";
            szSql += ", changefreq ";
            szSql += ", lastmod ";
            szSql += ", priority ";
           // szSql += ", LastUpdate ";
            szSql += ", urltemplate ";
            szSql += ", DocClass ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @DocChapterId ";
            
            szSql += ", @loc_docid ";
            szSql += ", @loc_title ";
            szSql += ", @changefreq ";
            szSql += ", @lastmod ";
            szSql += ", @priority ";
           // szSql += ", @LastUpdate ";
            szSql += ", @urltemplate ";
            szSql += ", @DocClass ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocChapterId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            
            oSqlCmdInsert.Parameters.Add("@loc_docid", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@loc_title", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@changefreq", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@lastmod", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@priority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
           // oSqlCmdInsert.Parameters.Add("@LastUpdate", MySql.Data.MySqlClient.MySqlDbType.Timestamp);
            oSqlCmdInsert.Parameters.Add("@urltemplate", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocClass", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_sitemap SET ";

            szSql += "loc_docid=@loc_docid ";
            szSql += ", loc_title=@loc_title ";
            szSql += ", changefreq=@changefreq ";
            szSql += ", lastmod=@lastmod ";
            szSql += ", priority=@priority ";
            //szSql += ", LastUpdate=@LastUpdate ";
            szSql += ", urltemplate=@urltemplate ";
            szSql += ", DocClass=@DocClass ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            szSql += " AND (DocChapterId=@DocChapterId )";
         

            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocChapterId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            
            oSqlCmdUpdate.Parameters.Add("@loc_docid", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@loc_title", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@changefreq", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@lastmod", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@priority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //oSqlCmdUpdate.Parameters.Add("@LastUpdate", MySql.Data.MySqlClient.MySqlDbType.Timestamp);
            oSqlCmdUpdate.Parameters.Add("@urltemplate", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocClass", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_sitemap  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            szSql += " AND (DocChapterId=@DocChapterId )";

            

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdDelete.Parameters.Add("@DocChapterId", MySql.Data.MySqlClient.MySqlDbType.VarChar);

           
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";
            szSql += ", DocLngId";
            szSql += ", DocChapterId";
            szSql += " FROM tdoclng_sitemap  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            szSql += " AND (DocChapterId=@DocChapterId )";


            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelectExist.Parameters.Add("@DocChapterId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
        }
        //--------------------------------------------------------



        //	-------------------------------------------------
        //	-------------------------------------------------
        /// <summary>
        /// Validacion del registro antes de guardar. Definido
        /// a mano por el usuario.
        /// </summary>
        /*
        public bool FncSqlValidateRecord()
        {
            bool bValid = true;
            string szError = "";
            ////------------------------------------------
            ////TODO PON TU CODIGO DE VALIDACION AQUI
            ////------------------------------------------


            //-------------------------------------
            _mErrorBoolean = !bValid;
            _mErrorString = szError;
            return bValid;
        }
        */
        //------------------------------------------------------

        //	-------------------------------------------------
        /// <summary>
        /// Devuelve true ha sido correcto y false en caso de error.
        /// </summary>
        /// 
        /*
        public bool FncSqlSave()

        {
            _mErrorBoolean = false;

            _mErrorString = "";

            //	------------------------------

            if (!FncSqlValidateRecord()) return false;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;

            // comprobar si existe el id a añadir
            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            bool b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            if (b)
            {
                b = FncSqlUpdate();
            }
            else
            {
                b = FncSqlInsert();
            }
            _mErrorBoolean = !b;
            return !_mErrorBoolean;
        }
        */
        //------------------------------------------------------


        //-------------------------------------------------------
        //----------------FncSqlUpdate --------------------------
        //-------------------------------------------------------
        /// <summary>
        /// Devuelve true ha sido correcto y false en caso de error.
        /// </summary>
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
            oSqlCmdUpdate.Parameters["@DocChapterId"].Value = m_DocChapterId;
            

            oSqlCmdUpdate.Parameters["@loc_docid"].Value = m_loc_docid;
            oSqlCmdUpdate.Parameters["@loc_title"].Value = m_loc_title;
            oSqlCmdUpdate.Parameters["@changefreq"].Value = m_changefreq;
            oSqlCmdUpdate.Parameters["@lastmod"].Value = m_lastmod;
            oSqlCmdUpdate.Parameters["@priority"].Value = m_priority;
           // oSqlCmdUpdate.Parameters["@LastUpdate"].Value = m_LastUpdate;
            oSqlCmdUpdate.Parameters["@urltemplate"].Value = m_urltemplate;
            oSqlCmdUpdate.Parameters["@DocClass"].Value = m_DocClass;
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
                //MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }
        //-------------------------------------------------------;


        //-------------------------------------------------------
        //----------------FncSqlInsert --------------------------
        //-------------------------------------------------------
        /// <summary>
        /// Devuelve true ha sido correcto y false en caso de error.
        /// </summary>
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
            //-----------------------------------------------------
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@DocChapterId"].Value = m_DocChapterId;

            
            oSqlCmdInsert.Parameters["@loc_docid"].Value = m_loc_docid;
            oSqlCmdInsert.Parameters["@loc_title"].Value = m_loc_title;
            oSqlCmdInsert.Parameters["@changefreq"].Value = m_changefreq;
            oSqlCmdInsert.Parameters["@lastmod"].Value = m_lastmod;
            oSqlCmdInsert.Parameters["@priority"].Value = m_priority;
            //oSqlCmdInsert.Parameters["@LastUpdate"].Value = m_LastUpdate;
            oSqlCmdInsert.Parameters["@urltemplate"].Value = m_urltemplate;
            oSqlCmdInsert.Parameters["@DocClass"].Value = m_DocClass;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;;
                oSqlCmdInsert.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }
        //--------------------------------------------------------
        //----------------FncSqlFind------------------------------
        //--------------------------------------------------------
        public bool FncSqlFind(UInt64 DocId, String DocLngId, String DocChapterId)
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
            oSqlCmdSelect.Parameters["@DocChapterId"].Value = DocChapterId;
    
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
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_DocLngId = oDR["DocLngId"].ToString();
                    m_DocChapterId = oDR["DocChapterId"].ToString();

                    m_loc_docid = oDR["loc_docid"].ToString();
                    m_loc_title = oDR["loc_title"].ToString();
                    m_changefreq = oDR["changefreq"].ToString();
                    m_lastmod = oDR["lastmod"].ToString();
                    m_priority = oDR["priority"].ToString();
                    //m_LastUpdate = Convert.ToUInt64(oDR["LastUpdate"].ToString());
                    m_urltemplate = oDR["urltemplate"].ToString();
                    m_DocClass = oDR["DocClass"].ToString();
                } //Cierre de if 
                else
                {
                    _mErrorBoolean = true;
                    _mErrorString = "Not found.";
                }//Cierre de else 
                oDR.Close();
            }//Cierre de try 
            catch (SystemException ex)
            {

                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //MessageBox.Show (_mErrorString); 
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
        public bool FncSqlDelete(UInt64 DocId, String DocLngId, String DocChapterId)
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
                oSqlCmdDelete.Parameters["@DocChapterId"].Value = DocChapterId;
              
                int i = oSqlCmdDelete.ExecuteNonQuery();
                if (i > 0)
                {
                    FncClear();
                }
            }
            catch (Exception xcpt)
            {
                _mErrorString = xcpt.Message;
                _mErrorBoolean = true;
                //MessageBox.Show (xcpt.Message );
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return !_mErrorBoolean;
        }
        //------------------------------------------------;

        ////--------------------------------------------------------r
        ////----------------FncSqlOpenCnn--------------------------



        //--------------------------------------------------
        #region VALORES_GETSET
        //--------------------------------------------------
        public string MySqlConnectionString
        {
            set { _mMySqlConnectionString = value; }
            get { return _mMySqlConnectionString; }
        }
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
                m_DocLngId = value;
            }
            get { return m_DocLngId; }
        }

        public String DocChapterId
        {
            set
            {
                m_DocChapterId = value;
            }
            get { return m_DocChapterId; }
        }


        
        //................................

        public String loc_docid
        {
            set
            {
                m_loc_docid = value;
            }
            get { return m_loc_docid; }
        }

        //................................

        public String loc_title
        {
            set
            {
                m_loc_title = value;
            }
            get { return m_loc_title; }
        }

        //................................

        public String changefreq
        {
            set
            {
                m_changefreq = value;
            }
            get { return m_changefreq; }
        }

        //................................

        public String lastmod
        {
            set
            {
                m_lastmod = value;
            }
            get { return m_lastmod; }
        }

        //................................

        public String priority
        {
            set
            {
                m_priority = value;
            }
            get { return m_priority; }
        }

        //................................

      

        //................................

        public String urltemplate
        {
            set
            {
                m_urltemplate = value;
            }
            get { return m_urltemplate; }
        }

        //................................

        public String DocClass
        {
            set
            {
                m_DocClass = value;
            }
            get { return m_DocClass; }
        }

        #endregion VALORES_GETSET



        //-------------------------------------------------------------------
        //-------------------------------------------------------------------
        // ADAPTACION 
        //-------------------------------------------------------------------
        //-------------------------------------------------------------------
        //--------------------------------------------------------





        //------------------------------------------------------


        //	-------------------------------------------------
        /// <summary>
        /// Devuelve true ha sido correcto y false en caso de error.
        /// </summary>
        /// ui64DocId, szDocLngId, szUrlTemplate, szDocClass 
        public bool FncSqlSave(UInt64 pDocId, String pDocLng, string pDocChapterId, String pUrlTemplate, String pUrlAddToEnd, String pDocClass, string pTile)

        {
            dAyer = System.DateTime.Today.AddDays(-1);

            _mErrorBoolean = false;

            _mErrorString = "";

            //	------------------------------
            //String pUrlTemplate, String pDocClass
            if (!FncSaveValidate(pDocId, pDocLng,  pDocChapterId, pUrlTemplate, pUrlAddToEnd, pDocClass, pTile, E_SiteMapFrecuency.monthly)) { return false; }
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;

            // comprobar si existe el id a añadir
            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdSelectExist.Parameters["@DocChapterId"].Value = m_DocChapterId;
       

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            bool b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            if (b)
            {
                b = FncSqlUpdate();
            }
            else
            {
                b = FncSqlInsert();
            }
            _mErrorBoolean = !b;
            return !_mErrorBoolean;
        }

        //------------------------------------------------------
        //------------------------------------------------------
        //------------------------------------------------------
        //(pDocId, pDocLng, pUrlTemplate, pUrlAddToEnd, pDocClass, pTitle
        private bool FncSaveValidate(UInt64 pDocId, String pDocLng,String pDocChapterId, String pUrlTemplate, String pUrlAddToEnd, String pDocClass, String pTitle, E_SiteMapFrecuency eFrecuency)
        {
            bool bOk = true;


            if (pDocId == 0) { bOk = false; }
            if (pDocLng != "es" && pDocLng != "en") { bOk = false; }

            if (bOk) FncFillFields(pDocId, pDocLng, pDocChapterId, pUrlTemplate, pUrlAddToEnd, pDocClass, pTitle, eFrecuency);
            return bOk;
        }
       
        private bool FncFillFields(UInt64 pDocId, String pDocLng, String pDocChapterId, String pUrlTemplate, String pUrlAddToEnd, String pDocClass, String pTitle, E_SiteMapFrecuency eFrecuency)
        {
            

            String szUrlTitle = FncUrlTitle(pTitle);
            m_DocId = pDocId;
            m_DocLngId = pDocLng;
            m_DocChapterId =  pDocChapterId;
            m_urltemplate = pUrlTemplate;
            m_DocClass = pDocClass;
            m_lastmod = dAyer.Year.ToString() + "-" + dAyer.Month.ToString() + "-" + dAyer.Day.ToString();
            // m_LastUpdate = 0;
            m_priority = "0.5";
            m_changefreq = eFrecuency.ToString();
            // verificar que no exista otro documento con la misma url de texto();
            m_loc_title = "/" + pDocLng + pUrlTemplate + szUrlTitle;
            if (!FncEvitarDuplicados(pDocId, m_loc_title)) { return false; };
            m_loc_docid = "/" + pDocLng + pUrlTemplate + pDocId.ToString();

            if (pDocChapterId != "")
            {
                m_loc_title += "/" + pDocChapterId;
                m_loc_docid += "/" + pDocChapterId;
                
            }


            if (pUrlAddToEnd != "")
            {
                
                m_loc_title += "/" + pUrlAddToEnd;
                m_loc_docid += "/" + pUrlAddToEnd;
            }
           





            return true;
        }
        private String FncUrlTitle(String pTitle)
        {
            string szUrlTitle = pTitle.Trim().ToLower();
            string[] titleDiv = szUrlTitle.Split(',');
            szUrlTitle = titleDiv[0];

            while (szUrlTitle.Contains("  "))
            {
                szUrlTitle = szUrlTitle.Replace("  ", " ");
            }

            szUrlTitle = cls.ClsUtils.RemoveAccentsWithNormalization(szUrlTitle);
            szUrlTitle = szUrlTitle.Replace(".", "");
            szUrlTitle = szUrlTitle.Replace(",", "");
            szUrlTitle = szUrlTitle.Replace("/", " ");
            szUrlTitle = szUrlTitle.Replace("\\", " ");
            szUrlTitle = szUrlTitle.Replace("!", " ");
            szUrlTitle = szUrlTitle.Replace(" ", "-");


            szUrlTitle = HttpContext.Current.Server.UrlEncode(szUrlTitle);

            return szUrlTitle;
        }

        private bool FncEvitarDuplicados(UInt64 pDocId, String szUrlTitle)
        {

            string szCmd = "select docid from tdoclng_sitemap where loc_title='" + szUrlTitle + "'";
            DataTable oTb = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szCmd, ref oTb);
            if (oTb.Rows.Count == 0) return true; // es nuevo no hay problema con duplicados

            if (oTb.Rows.Count > 1) return false; // existen duplicados
            if (pDocId != Convert.ToUInt64(oTb.Rows[0][0].ToString()))
            {
                // existe otro documento con el mimsmo titulo y del mismo tipo
                return false;
            }
            // existe pero no hay problema pues el mismo


            return true;

        }
        /*
         * 
         * //-------------------------------------
        <?xml version="1.0" encoding="UTF-8"?><
       <urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9"
          <url
             <loc>http://www.example.com/</loc>
             <lastmod>2005-01-01</lastmod>
             <changefreq>monthly</changefreq>
             <priority>0.5</priority>
          </url>
            <url
             <loc>http://www.example.com/</loc>
             <lastmod>2005-01-01</lastmod>
             <changefreq>monthly</changefreq>
             <priority>0.5</priority>
          </url>

        </urlset> 
        //-------------------------------------
        */
        private String m_SitemapContent = "";
        private void FncSiteMapBldFillDatatable()
        {
            string szSql = "";
            szSql += " select tdoclng_testudines_abst.DocId, tdoclng_testudines_abst.DocLngId, Concat(ATaxGrpL2270Genus,'-',ATaxGrpL2280Specie) as Title  , 'tdoclng_testudines_abst' as tablename ,'tortoise' as DocClass, '/tortoises/' as urltemplate";
            szSql += " from tdoclng_testudines_abst  inner join tdoclng_testudines_taxa_all on tdoclng_testudines_abst.DocId=tdoclng_testudines_taxa_all.DocId";
            szSql += " union  select DocId, DocLngId,Title, 'tdoclng_notices' as tablename, 'notice' as DocClass, '/notices/notice/' as urltemplate from tdoclng_notices";
            szSql += " union  select DocId, DocLngId,Title, 'tdoclng_articles' as tablename ,'article' as DocClass, '/articles/article/' as urltemplate from tdoclng_articles";
            szSql += " union  select DocId, DocLngId,Title, 'tdoclng_others' as tablename ,'other' as DocClass, '/others/others/other/' as urltemplate from tdoclng_others";
            szSql += " union  select DocId, DocLngId,Title, 'tdoclng_foods' as tablename ,'food' as DocClass, '/tortoises/foods/food/' as urltemplate from tdoclng_foods";
            szSql += " union select DocId, DocLngId,Title, 'tdoclng_testudines_groups' as tablename ,'groups' as DocClass, '/tortoises/groups/group/' as urltemplate from tdoclng_testudines_groups";
            szSql += " order by  docid, doclngid"; //urltemplate
            DataTable oTb = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTb);

            // todo agregar las funciones para taxon descripcion, ditribucion, cuidados ... y galeria
            // string[] aSz = szUri.Split('/');
            //  szUriGallery = "/"+ aSz[0] +"/" + aSz[1] + "/" + aSz[2] +   "/tortoise-images/"+ aSz[3] + "/1";///es/tortoises/tortoise/acanthochelys-macrocephala/tortoise-images/
            String szDocLngId = "";
            String szTitle = "";
            UInt64 ui64DocId = 0;
            String szUrlTemplate = "";
            String szDocClass = "";
            String szTablename = "";
            String DocChapterId = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                ui64DocId = Convert.ToUInt64(oRow[0].ToString());
                szDocLngId = oRow[1].ToString();
                szTitle = oRow[2].ToString();
                szTablename = oRow[3].ToString();
                szDocClass = oRow[4].ToString();
                szUrlTemplate = oRow[5].ToString();
                DocChapterId = "";


                FncSqlSave(ui64DocId, szDocLngId, DocChapterId, szUrlTemplate, "", szDocClass, szTitle);

                if (szTablename.Contains("tdoclng_testudines_abst"))
                {
                    
                    foreach (var capitule in Enum.GetNames(typeof(cls.ClsGlobal.E_TortoiseChapters)))
                    {
                        DocChapterId = capitule.ToString();
                        FncSqlSave(ui64DocId, szDocLngId, DocChapterId, szUrlTemplate, "", szDocClass, szTitle);
                    }




                }



            }
        }
        /// <summary>
        /// Actualiza la tabla sitemap y luego llama a salvar el fichero de texto
        /// sitemap.xml
        /// </summary>
        public void FncSitemapRebuidl()
        {

            FncSiteMapBldFillDatatable();
            FncSitemapBldFile();
        }
        /// <summary>
        /// Crea el fichero de texto sitemap a partir de la base de datos
        /// </summary>
        private void FncSitemapBldFile()
        {
            String szFileName = cls.ClsGlobal.DirRoot + "sitemap.xml";
            DataTable oTb = new DataTable();
            String szSql = "select loc_docid, loc_title, changefreq, lastmod from tdoclng_sitemap order by loc_title";
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTb);
            string szLoc_docid = "";
            string szLoc_title = "";
            string szChangefreq = "";
            string szLastmod = "";

            FncSitemap_BldAddStart();
            foreach (DataRow oRow in oTb.Rows)
            {

                szLoc_docid = oRow[0].ToString();
                szLoc_title = oRow[1].ToString();
                szChangefreq = oRow[2].ToString();
                szLastmod = oRow[3].ToString();
                FncSitemap_BldAddItem(szLoc_docid, szLoc_title, szChangefreq, szLastmod);
               
            }
            FncSitemap_BldAddEnd();

            cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref m_SitemapContent);

        }

        private void FncSitemap_BldAddStart()
        {
            m_SitemapContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n";
            m_SitemapContent += "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">\n";
            FncSitemap_BldAddStatics();

        }
        private void FncSitemap_BldAddEnd()
        {
            m_SitemapContent += "</urlset> ";

        }



        private void FncSitemap_BldAddStatics()
        {
            /*
             * 
             
             */


            ;
            FncSitemap_BldAddStaticsItem("/", E_SiteMapFrecuency.monthly);
            FncSitemap_BldAddStaticsItem("/es/tortoises/tortoise-images/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/es/tortoises/tortoise-images/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/es/tortoises/tortoises-list/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/en/tortoises/tortoises-list/", E_SiteMapFrecuency.yearly); ;
            FncSitemap_BldAddStaticsItem("/es/tortoises/tortoises-taxonomy-list/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/es/tortoises/tortoises-taxonomy-list/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/es/tortoises/foods/foods-list", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/en/tortoises/foods/foods-list", E_SiteMapFrecuency.yearly);
            //{doclngid}/tortoises/appendixes/appendixes-list
            FncSitemap_BldAddStaticsItem("/es/tortoises/appendixes/appendixes-list/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/en/tortoises/appendixes/appendixes-list/", E_SiteMapFrecuency.yearly);

            FncSitemap_BldAddStaticsItem("/es/tortoises/groups/groups-list", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/en/tortoises/groups/groups-list", E_SiteMapFrecuency.yearly);


            FncSitemap_BldAddStaticsItem("/es/others/acknowledgements/acknowledgements-list/", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/others/acknowledgements/acknowledgements", E_SiteMapFrecuency.monthly);

            FncSitemap_BldAddStaticsItem("/es/others/ecozones/ecozones-list", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/en/others/ecozones/ecozones-list", E_SiteMapFrecuency.yearly);

            FncSitemap_BldAddStaticsItem("/es/others/others/others-list", E_SiteMapFrecuency.monthly);
            FncSitemap_BldAddStaticsItem("/en/others/others/others-list", E_SiteMapFrecuency.monthly);

            FncSitemap_BldAddStaticsItem("/es/others/bibliography/bibliography-list", E_SiteMapFrecuency.monthly);
            FncSitemap_BldAddStaticsItem("/en/others/bibliography/bibliography-list", E_SiteMapFrecuency.monthly);


            FncSitemap_BldAddStaticsItem("/en/articles/articles-list", E_SiteMapFrecuency.yearly);
            FncSitemap_BldAddStaticsItem("/es/articles/articles-list", E_SiteMapFrecuency.yearly);

            FncSitemap_BldAddStaticsItem("/en/notices/notices-list", E_SiteMapFrecuency.monthly);
            FncSitemap_BldAddStaticsItem("/es/notices/notices-list", E_SiteMapFrecuency.monthly);


        }
    
        private void FncSitemap_BldAddStaticsItem(string szLoc, E_SiteMapFrecuency eFrecuency)
        {
            String szFrecuency = eFrecuency.ToString();

            String sz = "";
            String szLastMod = dAyer.Year.ToString() + "-" + dAyer.Month.ToString() + "-" + dAyer.Day.ToString();
            sz += "  <url>\n";
            string szLocCombine = cls.ClsUtils.FncUrlCombine("http://www.testudines.org", szLoc);
            sz += "   <loc>" + szLocCombine + "</loc>\n";
            sz += "   <lastmod>" + szLastMod + "</lastmod>\n";
            sz += "  <changefreq>" + szFrecuency + "</changefreq>\n";
            sz += "   <priority>0.5</priority>\n";
            sz += "</url>\n";

            m_SitemapContent += sz;
        }

        private void FncSitemap_BldAddItem(String szLoc_docid, String szLoc_title, String szChangefreq, String szLastmod)
        {
            /*
               <url
             <loc>http://www.example.com/</loc>
             <lastmod>2005-01-01</lastmod>
             <changefreq>monthly</changefreq>
             <priority>0.5</priority>
          </url>
             */
            string szLocCombine = cls.ClsUtils.FncUrlCombine("http://www.testudines.org", szLoc_docid);
            String sz = "";
            sz += "  <url>\n";
            sz += "   <loc>" + szLocCombine + "</loc>\n";
             sz += "   <lastmod>" + szLastmod + "</lastmod>\n";
            sz += "  <changefreq>" + szChangefreq + "</changefreq>\n";
            sz += "   <priority>0.5</priority>\n";
            sz += "</url>\"\n";

            szLocCombine = cls.ClsUtils.FncUrlCombine("http://www.testudines.org", szLoc_title);
            sz += "  <url>";
            sz += "   <loc>" + szLocCombine + "</loc>\n";
            sz += "   <lastmod>" + szLastmod + "</lastmod>\n";
            sz += "  <changefreq>" + szChangefreq + "</changefreq>\n";
            sz += "   <priority>0.5</priority>\n";
            sz += "</url>\n";

            m_SitemapContent += sz;

        }

        /*
    * Documentacion
 https://support.google.com/webmasters/answer/2620865?hl=es&ref_topic=6080646  

    enviar
    envia site map
http://www.google.com/webmasters/tools/ping?sitemap=<url_del_sitemap>
http://search.yahooapis.com/SiteExplorerService/V1/ping?sitemap=<url_del_sitemap>
http://www.bing.com/webmaster/ping.aspx?siteMap=<url_del_sitemap>

url_del_sitemap
http://www.google.com/webmasters
http://siteexplorer.search.yahoo.com/mysites
http://www.bing.com/webmaster


*/

    }
}
