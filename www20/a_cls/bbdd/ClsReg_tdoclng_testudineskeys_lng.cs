using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_testudineskeys_lng : IDisposable
    {
        public const string m_TypeName = "taxon_key";
        private const string m_DivRow_Start = "\n\n\n\n <div class=\"twelve clearfix\">\n";
        private const string m_DivRow_End = "\n</div>\n";
        cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
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
        private String m_Description = "";
        private String m_Notes = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_testudineskeys_lng(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_testudineskeys_lng()
        {
          
            FncSqlBuildCommands();
            FncClear();
        }
        //---------------------------------------------------



        //---------------------------------------------------
        //---------------------------------------------------
        //---------------------------------------------------
        #region IDisposable implementation
        private bool m_Disposed = false;

        //...............

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (cls.bbdd.ClsMysql.MySqlConnection.State == ConnectionState.Open) ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            oSqlCmdUpdate.Dispose();
            oSqlCmdUpdate.Dispose();
            oSqlCmdInsert.Dispose();
            oSqlCmdDelete.Dispose();
            oSqlCmdSelect.Dispose();
            oSqlCmdSelectExist.Dispose();
            m_Disposed = true;
        }

        //...............
        ~ClsReg_tdoclng_testudineskeys_lng()
        {
            Dispose(false);
        }
        #endregion
        //---------------------------------------------------
        //---------------------------------------------------

        //--------------------------------------------------
        #region CLEAR
        //--------------------------------------------------
        public void FncClear()
        {
            m_DocId = 0;
            m_DocLngId = "";
            m_Title = "";
            m_Description = "";
            m_Notes = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_keys_lng  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_keys_lng";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", Title ";
            szSql += ", Description ";
            szSql += ", Notes ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @Title ";
            szSql += ", @Description ";
            szSql += ", @Notes ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Description", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_keys_lng SET ";

            szSql += "Title=@Title ";
            szSql += ", Description=@Description ";
            szSql += ", Notes=@Notes ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Description", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_keys_lng  ";
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
            szSql += " FROM tdoclng_testudines_keys_lng  ";

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
            oSqlCmdUpdate.Parameters["@Description"].Value = m_Description;
            oSqlCmdUpdate.Parameters["@Notes"].Value = m_Notes;
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
            oSqlCmdInsert.Parameters["@Description"].Value = m_Description;
            oSqlCmdInsert.Parameters["@Notes"].Value = m_Notes;
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
                    m_Description = oDR["Description"].ToString().Trim();
                    m_Notes = oDR["Notes"].ToString().Trim();
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
            get { return m_DocLngId; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=150";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String Description
        {
            set
            {
                m_Description = value;
            }
            get { return m_Description; }
        }

        //................................

        public String Notes
        {
            set
            {
                m_Notes = value;
            }
            get { return m_Notes; }
        }

        #endregion VALORES_GETSET

        public string TypeName { get { return m_TypeName; } }

        public string FncGetCache_Html(bool bRebuild)
        {


            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, m_TypeName);
            if (bRebuild) cls.cache.ClsCache.FncCacheFileDelete(szFileName);
            if (cls.ClsGlobal.CacheRebuid) { cls.ClsUtils.FncPathFileDelete(szFileName); }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncGetCache_Html_BLD();

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
                return szHtml;
            }
        }
            private string FncGetCache_Html_BLD()
        {
            string szHtml ="";
           
            cls.bbdd.ClsReg_tdoclng_testudineskeys oRegKeys = new ClsReg_tdoclng_testudineskeys();
            oRegKeys.FncSqlFind(m_DocId );


            szHtml = m_DivRow_Start;
            //szHtml +="title="+ m_Title ;
            szHtml += cls.ClsHtml.FncHtmlTitle(Resources.Strings.Key, "" ,m_DocId,m_DocLngId,"/tortoises/keys/key/");
            
            szHtml += "<h3>"+Resources.Strings.description+"</h3>" + m_Description;
            szHtml += m_DivRow_End;
            szHtml += m_DivRow_Start;
            string szPictureDes = "Descriptive images";
            string szPictureTit = "title";

            szHtml += FncBldHtmlPretyPhoto3(
              "imageslist",
              oRegKeys.ImgHlpPath01,
              oRegKeys.ImgHlpPath02,
              oRegKeys.ImgHlpPath03,
              szPictureDes,
            szPictureTit,"Taxon Keys description");

            szHtml += m_DivRow_End;
            szHtml += m_DivRow_Start;


            szHtml += "<h3>" + Resources.Strings.Notes  + "</h3>" + m_Notes;

            szHtml += "<h3>" +Resources.Strings.other+"</h3>";
            szHtml += "<ul>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.TOWNodeParentId +"</span>" + oRegKeys.TOWNodeParentId+"</li>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.TOWTaxaGroupLevel + "</span>" + oRegKeys.TOWTaxaGroupLevel + "</li>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.TOWTaxaGroupName + "</span>" + oRegKeys.TOWTaxaGroupName + "</li>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.TaxonDocId + "</span>" + oRegKeys.TaxonDocId + "</li>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.TOWNodeParentIdList + "</span>" + oRegKeys.NodeFullPathListHtml + "</li>";
            szHtml += "<li><span class=\"fld-title-inline200\">" + Resources.Strings.Bibliography + "</span>"  +"<br/><a href=\"" + oRegKeys.TOWTaxaURL + "\" target=\"_blank\">" + "C.H. Ernst, R.G.M. Altenburg & R.W. Barbour. Turtles of the world</a></li>";
            szHtml += "</ul>";
            szHtml += m_DivRow_End;
         

            return szHtml ;
        }
        private string FncBldHtmlPretyPhoto3(string szGalleryId, string pImgThun01, string pImgThun02, string pImgThun03, string pTitTop, string pTitBot, string pSectionFile)
        {
             oPP.FncGallery_New(szGalleryId, "imageslist");

            String pUrlThumbDefault = "";
            //--------------------------------------------------------
            string xpUrlThumb01 = pImgThun01;
            string xpUrlThumb02 = pImgThun02;
            string xpUrlThumb03 = pImgThun03;
            string xUrlTarget01 = "";
            string xUrlTarget02 = "";
            string xUrlTarget03 = "";
            FncBldUrlTest(ref  xUrlTarget01, ref  xpUrlThumb01, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget01, xpUrlThumb01, pTitTop, pTitBot,pSectionFile);

            FncBldUrlTest(ref  xUrlTarget02, ref  xpUrlThumb02, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget02, xpUrlThumb02, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref  xUrlTarget03, ref  xpUrlThumb03, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget03, xpUrlThumb03, pTitTop, pTitBot, pSectionFile);

            return oPP.HtmGalleryFB;
        }
        private void FncBldUrlTest(ref String pUrlTarget, ref String pUrlThumb, String pUrlThumbDefault)
        {
            pUrlThumb = pUrlThumb.Trim().ToLower();
            pUrlTarget = pUrlTarget.Trim().ToLower();
            pUrlThumbDefault = pUrlThumbDefault.Trim().ToLower();
            String szUrlTargetDefault = "/a_img/noimage600px.png";
            // Por si las fly miniatura por defecto
            if (pUrlThumbDefault == "") pUrlThumbDefault = "/a_img/noimage200px.png";

            // si no existe el fichero thumb poner miniatura por defecto
            String szUrlTumbPath = ((ClsGlobal.UrlMMedia + pUrlThumb).Replace("\\", "/")).Replace("//", "/");

            if (!System.IO.File.Exists(szUrlTumbPath) || pUrlThumb.Contains("noimage"))
            {
                pUrlThumb = pUrlThumbDefault;
            }
            else
            {
                pUrlThumb = pUrlThumb.Trim().ToLower();
            }
            // buscar la imagen ligada al thumbnail
            if (pUrlTarget == "")
            {
                pUrlTarget = pUrlThumb.Replace("min.jpg", "med.jpg");
                pUrlTarget = pUrlTarget.Replace("_minx.jpg", "_med.jpg");
            }
            // comprobar la existencia del la imagen target,si no exsite poner la de defecto
            String szUrlTargetPath = ((ClsGlobal.UrlMMedia + pUrlTarget).Replace("\\", "/")).Replace("//", "/");

            if (!System.IO.File.Exists(szUrlTargetPath))
            {
                pUrlTarget = szUrlTargetDefault;
            }


        }
    }
}
