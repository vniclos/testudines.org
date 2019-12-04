using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegTdoc
    //<//summary>
    public class ClsRegTdocNew
    {
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
        private String m_DocLngId_Main = "";
        private String m_DocTypeId = "";
        private String m_DocTypeGroup = "";
        private String m_DoctypeGroupSub = "";
        private int m_DocIsTraslatable = 0;
        private String m_DocImgThumbnail = "";
        private String m_DocDocUploaded = "";
        private int m_DocIsEditable = 0;
        private int m_DocIsActive = 0;
        private Int32 m_DocUserId_Creator = 0;
        private String m_DocAuthor = "";
        private String m_DocAuthors = "";
        private String m_DocBibliography = "";
        private String m_DocAcknowledgements = "";
        private String m_DocAuthorizations = "";
        private String m_DocNotes = "";
        private System.DateTime m_DocDateCreation = System.DateTime.Now;
        private UInt64 m_DocDateUpdate = 0;
        private System.DateTime m_DocStdVisitLast = System.DateTime.Now;
        private Int32 m_DocStdVisitCount = 0;
        private Int32 m_DocStdValLow = 0;
        private Int32 m_DocStdValMed = 0;
        private Int32 m_DocStdValHig = 0;
        private String m_DocCountriesCode = "";
        private String m_DocSiteMapPriority = "";
        private String m_DocSiteMapChangefreq = "";
        private String m_DocPdfUrl = "";
        private UInt64 m_DocPdfVersion = 0;
        private String m_DocPdfTitle = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegTdocNew()
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
            m_DocLngId_Main = "";
            m_DocTypeId = "";
            m_DocTypeGroup = "";
            m_DoctypeGroupSub = "";
            m_DocIsTraslatable = 0;
            m_DocImgThumbnail = "";
            m_DocDocUploaded = "";
            m_DocIsEditable = 0;
            m_DocIsActive = 0;
            m_DocUserId_Creator = 0;
            m_DocAuthor = "";
            m_DocAuthors = "";
            m_DocBibliography = "";
            m_DocAcknowledgements = "";
            m_DocAuthorizations = "";
            m_DocNotes = "";
            m_DocDateCreation = System.DateTime.Now;
            m_DocDateUpdate = 0;
            m_DocStdVisitLast = System.DateTime.Now;
            m_DocStdVisitCount = 0;
            m_DocStdValLow = 0;
            m_DocStdValMed = 0;
            m_DocStdValHig = 0;
            m_DocCountriesCode = "";
            m_DocSiteMapPriority = "";
            m_DocSiteMapChangefreq = "";
            m_DocPdfUrl = "";
            m_DocPdfVersion = 0;
            m_DocPdfTitle = "";
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
            szSql = "SELECT * FROM tdoc  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoc";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId_Main ";
            szSql += ", DocTypeId ";
            szSql += ", DocTypeGroup ";
            szSql += ", DoctypeGroupSub ";
            szSql += ", DocIsTraslatable ";
            szSql += ", DocImgThumbnail ";
            szSql += ", DocDocUploaded ";
            szSql += ", DocIsEditable ";
            szSql += ", DocIsActive ";
            szSql += ", DocUserId_Creator ";
            szSql += ", DocAuthor ";
            szSql += ", DocAuthors ";
            szSql += ", DocBibliography ";
            szSql += ", DocAcknowledgements ";
            szSql += ", DocAuthorizations ";
            szSql += ", DocNotes ";
            szSql += ", DocDateCreation ";
            szSql += ", DocDateUpdate ";
            szSql += ", DocStdVisitLast ";
            szSql += ", DocStdVisitCount ";
            szSql += ", DocStdValLow ";
            szSql += ", DocStdValMed ";
            szSql += ", DocStdValHig ";
            szSql += ", DocCountriesCode ";
            szSql += ", DocSiteMapPriority ";
            szSql += ", DocSiteMapChangefreq ";
            szSql += ", DocPdfUrl ";
            szSql += ", DocPdfVersion ";
            szSql += ", DocPdfTitle ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId_Main ";
            szSql += ", @DocTypeId ";
            szSql += ", @DocTypeGroup ";
            szSql += ", @DoctypeGroupSub ";
            szSql += ", @DocIsTraslatable ";
            szSql += ", @DocImgThumbnail ";
            szSql += ", @DocDocUploaded ";
            szSql += ", @DocIsEditable ";
            szSql += ", @DocIsActive ";
            szSql += ", @DocUserId_Creator ";
            szSql += ", @DocAuthor ";
            szSql += ", @DocAuthors ";
            szSql += ", @DocBibliography ";
            szSql += ", @DocAcknowledgements ";
            szSql += ", @DocAuthorizations ";
            szSql += ", @DocNotes ";
            szSql += ", @DocDateCreation ";
            szSql += ", @DocDateUpdate ";
            szSql += ", @DocStdVisitLast ";
            szSql += ", @DocStdVisitCount ";
            szSql += ", @DocStdValLow ";
            szSql += ", @DocStdValMed ";
            szSql += ", @DocStdValHig ";
            szSql += ", @DocCountriesCode ";
            szSql += ", @DocSiteMapPriority ";
            szSql += ", @DocSiteMapChangefreq ";
            szSql += ", @DocPdfUrl ";
            szSql += ", @DocPdfVersion ";
            szSql += ", @DocPdfTitle ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int64);
            oSqlCmdInsert.Parameters.Add("@DocLngId_Main", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocTypeId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocTypeGroup", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DoctypeGroupSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocIsTraslatable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocImgThumbnail", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocDocUploaded", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocIsEditable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocIsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocUserId_Creator", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocAuthor", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocAuthors", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocBibliography", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@DocAcknowledgements", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@DocAuthorizations", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@DocNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@DocDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocDateUpdate", MySql.Data.MySqlClient.MySqlDbType.Timestamp);
            oSqlCmdInsert.Parameters.Add("@DocStdVisitLast", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocStdVisitCount", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValLow", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValMed", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValHig", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocCountriesCode", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocSiteMapPriority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocSiteMapChangefreq", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocPdfUrl", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocPdfVersion", MySql.Data.MySqlClient.MySqlDbType.Int64);
            oSqlCmdInsert.Parameters.Add("@DocPdfTitle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoc SET ";

            szSql += "DocLngId_Main=@DocLngId_Main ";
            szSql += ", DocTypeId=@DocTypeId ";
            szSql += ", DocTypeGroup=@DocTypeGroup ";
            szSql += ", DoctypeGroupSub=@DoctypeGroupSub ";
            szSql += ", DocIsTraslatable=@DocIsTraslatable ";
            szSql += ", DocImgThumbnail=@DocImgThumbnail ";
            szSql += ", DocDocUploaded=@DocDocUploaded ";
            szSql += ", DocIsEditable=@DocIsEditable ";
            szSql += ", DocIsActive=@DocIsActive ";
            szSql += ", DocUserId_Creator=@DocUserId_Creator ";
            szSql += ", DocAuthor=@DocAuthor ";
            szSql += ", DocAuthors=@DocAuthors ";
            szSql += ", DocBibliography=@DocBibliography ";
            szSql += ", DocAcknowledgements=@DocAcknowledgements ";
            szSql += ", DocAuthorizations=@DocAuthorizations ";
            szSql += ", DocNotes=@DocNotes ";
            szSql += ", DocDateCreation=@DocDateCreation ";
            szSql += ", DocDateUpdate=@DocDateUpdate ";
            szSql += ", DocStdVisitLast=@DocStdVisitLast ";
            szSql += ", DocStdVisitCount=@DocStdVisitCount ";
            szSql += ", DocStdValLow=@DocStdValLow ";
            szSql += ", DocStdValMed=@DocStdValMed ";
            szSql += ", DocStdValHig=@DocStdValHig ";
            szSql += ", DocCountriesCode=@DocCountriesCode ";
            szSql += ", DocSiteMapPriority=@DocSiteMapPriority ";
            szSql += ", DocSiteMapChangefreq=@DocSiteMapChangefreq ";
            szSql += ", DocPdfUrl=@DocPdfUrl ";
            szSql += ", DocPdfVersion=@DocPdfVersion ";
            szSql += ", DocPdfTitle=@DocPdfTitle ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId_Main", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocTypeId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocTypeGroup", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DoctypeGroupSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocIsTraslatable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocImgThumbnail", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocDocUploaded", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocIsEditable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocIsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocUserId_Creator", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocAuthor", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocAuthors", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocBibliography", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@DocAcknowledgements", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@DocAuthorizations", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@DocNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@DocDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocDateUpdate", MySql.Data.MySqlClient.MySqlDbType.Timestamp);
            oSqlCmdUpdate.Parameters.Add("@DocStdVisitLast", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocStdVisitCount", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValLow", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValMed", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValHig", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocCountriesCode", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocSiteMapPriority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocSiteMapChangefreq", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocPdfUrl", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocPdfVersion", MySql.Data.MySqlClient.MySqlDbType.Int64);
            oSqlCmdUpdate.Parameters.Add("@DocPdfTitle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoc  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int64);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";
            szSql += " FROM tdoc  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int64);
            //----------------------------------------------------------------------
        }
        //--------------------------------------------------------



        //	-------------------------------------------------
        //	-------------------------------------------------
        /// <summary>
        /// Validacion del registro antes de guardar. Definido
        /// a mano por el usuario.
        /// </summary>
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
        //------------------------------------------------------

        //	-------------------------------------------------
        /// <summary>
        /// Devuelve true ha sido correcto y false en caso de error.
        /// </summary>
        public bool FncSqlSave()

        {
            _mErrorBoolean = false;

            _mErrorString = "";

            //	------------------------------

            if (!FncSqlValidateRecord()) return false;
            if (!ClsMysql.FncOpen("")) { return false; }

            // comprobar si existe el id a añadir
            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
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
            if (!ClsMysql.FncOpen("")) { return false; }
            ////-----------------------------------------------------;
            //// Configurar comando update. 
            ////-------------------------------------------------------;
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DocLngId_Main"].Value = m_DocLngId_Main;
            oSqlCmdUpdate.Parameters["@DocTypeId"].Value = m_DocTypeId;
            oSqlCmdUpdate.Parameters["@DocTypeGroup"].Value = m_DocTypeGroup;
            oSqlCmdUpdate.Parameters["@DoctypeGroupSub"].Value = m_DoctypeGroupSub;
            oSqlCmdUpdate.Parameters["@DocIsTraslatable"].Value = m_DocIsTraslatable;
            oSqlCmdUpdate.Parameters["@DocImgThumbnail"].Value = m_DocImgThumbnail;
            oSqlCmdUpdate.Parameters["@DocDocUploaded"].Value = m_DocDocUploaded;
            oSqlCmdUpdate.Parameters["@DocIsEditable"].Value = m_DocIsEditable;
            oSqlCmdUpdate.Parameters["@DocIsActive"].Value = m_DocIsActive;
            oSqlCmdUpdate.Parameters["@DocUserId_Creator"].Value = m_DocUserId_Creator;
            oSqlCmdUpdate.Parameters["@DocAuthor"].Value = m_DocAuthor;
            oSqlCmdUpdate.Parameters["@DocAuthors"].Value = m_DocAuthors;
            oSqlCmdUpdate.Parameters["@DocBibliography"].Value = m_DocBibliography;
            oSqlCmdUpdate.Parameters["@DocAcknowledgements"].Value = m_DocAcknowledgements;
            oSqlCmdUpdate.Parameters["@DocAuthorizations"].Value = m_DocAuthorizations;
            oSqlCmdUpdate.Parameters["@DocNotes"].Value = m_DocNotes;
            oSqlCmdUpdate.Parameters["@DocDateCreation"].Value = m_DocDateCreation;
            oSqlCmdUpdate.Parameters["@DocDateUpdate"].Value = m_DocDateUpdate;
            oSqlCmdUpdate.Parameters["@DocStdVisitLast"].Value = m_DocStdVisitLast;
            oSqlCmdUpdate.Parameters["@DocStdVisitCount"].Value = m_DocStdVisitCount;
            oSqlCmdUpdate.Parameters["@DocStdValLow"].Value = m_DocStdValLow;
            oSqlCmdUpdate.Parameters["@DocStdValMed"].Value = m_DocStdValMed;
            oSqlCmdUpdate.Parameters["@DocStdValHig"].Value = m_DocStdValHig;
            oSqlCmdUpdate.Parameters["@DocCountriesCode"].Value = m_DocCountriesCode;
            oSqlCmdUpdate.Parameters["@DocSiteMapPriority"].Value = m_DocSiteMapPriority;
            oSqlCmdUpdate.Parameters["@DocSiteMapChangefreq"].Value = m_DocSiteMapChangefreq;
            oSqlCmdUpdate.Parameters["@DocPdfUrl"].Value = m_DocPdfUrl;
            oSqlCmdUpdate.Parameters["@DocPdfVersion"].Value = m_DocPdfVersion;
            oSqlCmdUpdate.Parameters["@DocPdfTitle"].Value = m_DocPdfTitle;
            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdUpdate.Connection = ClsMysql.MySqlConnection;
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
            if (!ClsMysql.FncOpen("")) { return false; }
            //-----------------------------------------------------
            // Configurar comando Insert recuperando la identidad. 
            //-----------------------------------------------------
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DocLngId_Main"].Value = m_DocLngId_Main;
            oSqlCmdInsert.Parameters["@DocTypeId"].Value = m_DocTypeId;
            oSqlCmdInsert.Parameters["@DocTypeGroup"].Value = m_DocTypeGroup;
            oSqlCmdInsert.Parameters["@DoctypeGroupSub"].Value = m_DoctypeGroupSub;
            oSqlCmdInsert.Parameters["@DocIsTraslatable"].Value = m_DocIsTraslatable;
            oSqlCmdInsert.Parameters["@DocImgThumbnail"].Value = m_DocImgThumbnail;
            oSqlCmdInsert.Parameters["@DocDocUploaded"].Value = m_DocDocUploaded;
            oSqlCmdInsert.Parameters["@DocIsEditable"].Value = m_DocIsEditable;
            oSqlCmdInsert.Parameters["@DocIsActive"].Value = m_DocIsActive;
            oSqlCmdInsert.Parameters["@DocUserId_Creator"].Value = m_DocUserId_Creator;
            oSqlCmdInsert.Parameters["@DocAuthor"].Value = m_DocAuthor;
            oSqlCmdInsert.Parameters["@DocAuthors"].Value = m_DocAuthors;
            oSqlCmdInsert.Parameters["@DocBibliography"].Value = m_DocBibliography;
            oSqlCmdInsert.Parameters["@DocAcknowledgements"].Value = m_DocAcknowledgements;
            oSqlCmdInsert.Parameters["@DocAuthorizations"].Value = m_DocAuthorizations;
            oSqlCmdInsert.Parameters["@DocNotes"].Value = m_DocNotes;
            oSqlCmdInsert.Parameters["@DocDateCreation"].Value = m_DocDateCreation;
            oSqlCmdInsert.Parameters["@DocDateUpdate"].Value = m_DocDateUpdate;
            oSqlCmdInsert.Parameters["@DocStdVisitLast"].Value = m_DocStdVisitLast;
            oSqlCmdInsert.Parameters["@DocStdVisitCount"].Value = m_DocStdVisitCount;
            oSqlCmdInsert.Parameters["@DocStdValLow"].Value = m_DocStdValLow;
            oSqlCmdInsert.Parameters["@DocStdValMed"].Value = m_DocStdValMed;
            oSqlCmdInsert.Parameters["@DocStdValHig"].Value = m_DocStdValHig;
            oSqlCmdInsert.Parameters["@DocCountriesCode"].Value = m_DocCountriesCode;
            oSqlCmdInsert.Parameters["@DocSiteMapPriority"].Value = m_DocSiteMapPriority;
            oSqlCmdInsert.Parameters["@DocSiteMapChangefreq"].Value = m_DocSiteMapChangefreq;
            oSqlCmdInsert.Parameters["@DocPdfUrl"].Value = m_DocPdfUrl;
            oSqlCmdInsert.Parameters["@DocPdfVersion"].Value = m_DocPdfVersion;
            oSqlCmdInsert.Parameters["@DocPdfTitle"].Value = m_DocPdfTitle;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;
                oSqlCmdInsert.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            return !_mErrorBoolean;
        }
        //--------------------------------------------------------
        //----------------FncSqlFind------------------------------
        //--------------------------------------------------------
        public bool FncSqlFind(UInt64 DocId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            if (!ClsMysql.FncOpen("")) { return false; }
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                if (!ClsMysql.FncOpen("")) { return false; }
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_DocLngId_Main = oDR["DocLngId_Main"].ToString();
                    m_DocTypeId = oDR["DocTypeId"].ToString();
                    m_DocTypeGroup = oDR["DocTypeGroup"].ToString();
                    m_DoctypeGroupSub = oDR["DoctypeGroupSub"].ToString();
                    m_DocIsTraslatable = Convert.ToInt16(oDR["DocIsTraslatable"].ToString());
                    m_DocImgThumbnail = oDR["DocImgThumbnail"].ToString();
                    m_DocDocUploaded = oDR["DocDocUploaded"].ToString();
                    m_DocIsEditable = Convert.ToInt16(oDR["DocIsEditable"].ToString());
                    m_DocIsActive = Convert.ToInt16(oDR["DocIsActive"].ToString());
                    m_DocUserId_Creator = Convert.ToInt32(oDR["DocUserId_Creator"].ToString());
                    m_DocAuthor = oDR["DocAuthor"].ToString();
                    m_DocAuthors = oDR["DocAuthors"].ToString();
                    m_DocBibliography = oDR["DocBibliography"].ToString();
                    m_DocAcknowledgements = oDR["DocAcknowledgements"].ToString();
                    m_DocAuthorizations = oDR["DocAuthorizations"].ToString();
                    m_DocNotes = oDR["DocNotes"].ToString();
                    m_DocDateCreation = Convert.ToDateTime(oDR["DocDateCreation"].ToString());
                    m_DocDateUpdate = Convert.ToUInt64(oDR["DocDateUpdate"].ToString());
                    m_DocStdVisitLast = Convert.ToDateTime(oDR["DocStdVisitLast"].ToString());
                    m_DocStdVisitCount = Convert.ToInt32(oDR["DocStdVisitCount"].ToString());
                    m_DocStdValLow = Convert.ToInt32(oDR["DocStdValLow"].ToString());
                    m_DocStdValMed = Convert.ToInt32(oDR["DocStdValMed"].ToString());
                    m_DocStdValHig = Convert.ToInt32(oDR["DocStdValHig"].ToString());
                    m_DocCountriesCode = oDR["DocCountriesCode"].ToString();
                    m_DocSiteMapPriority = oDR["DocSiteMapPriority"].ToString();
                    m_DocSiteMapChangefreq = oDR["DocSiteMapChangefreq"].ToString();
                    m_DocPdfUrl = oDR["DocPdfUrl"].ToString();
                    m_DocPdfVersion = Convert.ToUInt64(oDR["DocPdfVersion"].ToString());
                    m_DocPdfTitle = oDR["DocPdfTitle"].ToString();
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
        public bool FncSqlDelete(UInt64 DocId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            if (!ClsMysql.FncOpen("")) { return false; }
            //-----------------------------------------------------;
            // ELIMINAR REGISTRO. 
            //-------------------------------------------------------;
            oSqlCmdDelete.Connection = ClsMysql.MySqlConnection;
            try
            {
                oSqlCmdDelete.Parameters["@DocId"].Value = DocId;
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
            return !_mErrorBoolean;
        }
        //------------------------------------------------;



        //--------------------------------------------------
        #region VALORES_GETSET
        //--------------------------------------------------
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

        public String DocLngId_Main
        {
            set
            {
                m_DocLngId_Main = value;
            }
            get { return m_DocLngId_Main; }
        }

        //................................

        public String DocTypeId
        {
            set
            {
                m_DocTypeId = value;
            }
            get { return m_DocTypeId; }
        }

        //................................

        public String DocTypeGroup
        {
            set
            {
                m_DocTypeGroup = value;
            }
            get { return m_DocTypeGroup; }
        }

        //................................

        public String DoctypeGroupSub
        {
            set
            {
                m_DoctypeGroupSub = value;
            }
            get { return m_DoctypeGroupSub; }
        }

        //................................

        public int DocIsTraslatable
        {
            set
            {
                m_DocIsTraslatable = value;
            }
            get { return m_DocIsTraslatable; }
        }

        //................................

        public String DocImgThumbnail
        {
            set
            {
                m_DocImgThumbnail = value;
            }
            get { return m_DocImgThumbnail; }
        }

        //................................

        public String DocDocUploaded
        {
            set
            {
                m_DocDocUploaded = value;
            }
            get { return m_DocDocUploaded; }
        }

        //................................

        public int DocIsEditable
        {
            set
            {
                m_DocIsEditable = value;
            }
            get { return m_DocIsEditable; }
        }

        //................................

        public int DocIsActive
        {
            set
            {
                m_DocIsActive = value;
            }
            get { return m_DocIsActive; }
        }

        //................................

        public Int32 DocUserId_Creator
        {
            set
            {
                m_DocUserId_Creator = value;
            }
            get { return m_DocUserId_Creator; }
        }

        //................................

        public String DocAuthor
        {
            set
            {
                m_DocAuthor = value;
            }
            get { return m_DocAuthor; }
        }

        //................................

        public String DocAuthors
        {
            set
            {
                m_DocAuthors = value;
            }
            get { return m_DocAuthors; }
        }

        //................................

        public String DocBibliography
        {
            set
            {
                m_DocBibliography = value;
            }
            get { return m_DocBibliography; }
        }

        //................................

        public String DocAcknowledgements
        {
            set
            {
                m_DocAcknowledgements = value;
            }
            get { return m_DocAcknowledgements; }
        }

        //................................

        public String DocAuthorizations
        {
            set
            {
                m_DocAuthorizations = value;
            }
            get { return m_DocAuthorizations; }
        }

        //................................

        public String DocNotes
        {
            set
            {
                m_DocNotes = value;
            }
            get { return m_DocNotes; }
        }

        //................................

        public System.DateTime DocDateCreation
        {
            set
            {
                m_DocDateCreation = value;
            }
            get { return m_DocDateCreation; }
        }

        //................................

        public UInt64 DocDateUpdate
        {
            set
            {
                m_DocDateUpdate = value;
            }
            get { return m_DocDateUpdate; }
        }

        //................................

        public System.DateTime DocStdVisitLast
        {
            set
            {
                m_DocStdVisitLast = value;
            }
            get { return m_DocStdVisitLast; }
        }

        //................................

        public Int32 DocStdVisitCount
        {
            set
            {
                m_DocStdVisitCount = value;
            }
            get { return m_DocStdVisitCount; }
        }

        //................................

        public Int32 DocStdValLow
        {
            set
            {
                m_DocStdValLow = value;
            }
            get { return m_DocStdValLow; }
        }

        //................................

        public Int32 DocStdValMed
        {
            set
            {
                m_DocStdValMed = value;
            }
            get { return m_DocStdValMed; }
        }

        //................................

        public Int32 DocStdValHig
        {
            set
            {
                m_DocStdValHig = value;
            }
            get { return m_DocStdValHig; }
        }

        //................................

        public String DocCountriesCode
        {
            set
            {
                m_DocCountriesCode = value;
            }
            get { return m_DocCountriesCode; }
        }

        //................................

        public String DocSiteMapPriority
        {
            set
            {
                m_DocSiteMapPriority = value;
            }
            get { return m_DocSiteMapPriority; }
        }

        //................................

        public String DocSiteMapChangefreq
        {
            set
            {
                m_DocSiteMapChangefreq = value;
            }
            get { return m_DocSiteMapChangefreq; }
        }

        //................................

        public String DocPdfUrl
        {
            set
            {
                m_DocPdfUrl = value;
            }
            get { return m_DocPdfUrl; }
        }

        //................................

        public UInt64 DocPdfVersion
        {
            set
            {
                m_DocPdfVersion = value;
            }
            get { return m_DocPdfVersion; }
        }

        //................................

        public String DocPdfTitle
        {
            set
            {
                m_DocPdfTitle = value;
            }
            get { return m_DocPdfTitle; }
        }

        #endregion VALORES_GETSET

    }
}
