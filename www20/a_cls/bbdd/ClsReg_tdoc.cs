using MySql.Data.MySqlClient;
using System;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoc : IDisposable
    {
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
        private String m_DocLngId_Main = "";
        private String m_DocTypeId = "";
        private String m_DocTypeGroup = "";
        private String m_DocTypeGroupSub = "";


        private bool m_DocIsTraslatable = true;
        private bool m_DocIsEditable = true;
        private bool m_DocIsActive = true;
        private Int32 m_DocUserId_creator = 0;
        private String m_DocAuthor = "";
        private String m_DocAuthors = "";
        private String m_DocBibliography = "";
        private String m_DocAcknowledgements = "";
        private String m_DocNotes = "";
        private String m_DocImgThumbnail = "_noimage.jpg";
        private string m_DocDocUploaded = "";


        private string m_DocAuthorizations = "";
        private DateTime m_DocDateCreation = DateTime.Now;
        private DateTime m_DocDateUpdate = DateTime.Now;
        private DateTime m_DocStdVisitLast = DateTime.Now;
        private Int32 m_DocStdVisitCount = 0;
        private Int32 m_DocStdValLow = 0;
        private Int32 m_DocStdValMed = 0;
        private Int32 m_DocStdValHig = 0;
        private String m_DocCountriesCode = "";
        private String m_DocSiteMapPriority = "0.6";
        private String m_DocSiteMapChangefreq = "month";


        private String m_DocPdfUrl = "";
        private UInt64 m_DocPdfVersion = 0;
        private String m_DocPdfTitle = "";

        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoc(string szSqlConnectionString)
        //{
        public ClsReg_tdoc()
        {
         

            FncSqlBuildCommands();
            FncClear();
        }
        //--------------------------------------------------
        //--------------------------------------------------
        #region IDisposable implementation
        private bool m_Disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        protected virtual void Dispose(bool disposing)
        {
            /*
            if (ClsMysql.MySqlConnection.State == ConnectionState.Open) ClsMysql.MySqlConnection.Close();
            ClsMysql.MySqlConnection.Dispose();
            oSqlCmdUpdate.Dispose();

            oSqlCmdUpdate.Dispose();
            oSqlCmdInsert.Dispose();
            oSqlCmdDelete.Dispose();
            oSqlCmdSelect.Dispose();
            oSqlCmdSelectExist.Dispose();

            m_Disposed = true;
            */
        }


        ~ClsReg_tdoc()
        {
          //  Dispose(false);
        }

        #endregion

        //--------------------------------------------------

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
            m_DocTypeGroupSub = "";
            m_DocIsTraslatable = true;
            m_DocIsEditable = true;
            m_DocIsActive = true;
            m_DocUserId_creator = 0;
            m_DocAuthor = "";
            m_DocAuthors = "";
            m_DocBibliography = "";
            m_DocAcknowledgements = "";
            m_DocNotes = "";
            m_DocImgThumbnail = "_noimage.jpg";
            m_DocDocUploaded = "";
            m_DocAuthorizations = "";
            m_DocDateCreation = DateTime.Now;
            m_DocDateUpdate = DateTime.Now;
            m_DocStdVisitLast = DateTime.Now;
            m_DocStdVisitCount = 0;
            m_DocStdValLow = 0;
            m_DocStdValMed = 0;
            m_DocStdValHig = 0;
            m_DocCountriesCode = "";
            m_DocSiteMapPriority = "0.6";
            m_DocSiteMapChangefreq = "month";
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
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            szSql += ", DocTypeGroupSub ";


            szSql += ", DocIsTraslatable ";
            szSql += ", DocIsEditable ";
            szSql += ", DocIsActive ";
            szSql += ", DocUserId_creator ";
            szSql += ", DocAuthor ";
            szSql += ", DocAuthors ";
            szSql += ", DocBibliography ";
            szSql += ", DocAcknowledgements ";
            szSql += ", DocNotes ";
            szSql += ", DocImgThumbnail ";
            szSql += ", DocDocUploaded ";


            szSql += ", DocAuthorizations ";

            szSql += ", DocDateCreation ";
            szSql += ", DocDateUpdate ";
            szSql += ", DocStdVisitLast ";
            szSql += ", DocStdVisitCount ";
            szSql += ", DocStdValLow ";
            szSql += ", DocStdValMed ";
            szSql += ", DocStdValHig ";
            szSql += ", DocCountriesCode ";
            szSql += ", DocSiteMapPriority ";
            szSql += ", DocSiteMapChangefreq, ";
            szSql += ", DocPdfUrl, ";
            szSql += ", DocPdfVersion, ";
            szSql += ", DocPdfTitle ";




            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId_Main ";
            szSql += ", @DocTypeId ";
            szSql += ", @DocTypeGroup ";
            szSql += ", @DocTypeGroupSub ";


            szSql += ", @DocIsTraslatable ";
            szSql += ", @DocIsEditable ";
            szSql += ", @DocIsActive ";
            szSql += ", @DocUserId_creator ";
            szSql += ", @DocAuthor ";
            szSql += ", @DocAuthors ";
            szSql += ", @DocBibliography ";
            szSql += ", @DocAcknowledgements ";
            szSql += ", @DocNotes ";
            szSql += ", @DocImgThumbnail ";
            szSql += ", @DocDocUploaded ";

            szSql += ", @DocAuthorizations ";

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
            szSql += " ; SELECT LAST_INSERT_ID()";
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId_Main", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocTypeId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocTypeGroup", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocTypeGroupSub", MySql.Data.MySqlClient.MySqlDbType.String);



            oSqlCmdInsert.Parameters.Add("@DocIsTraslatable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocIsEditable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocIsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocUserId_creator", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocAuthor", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocAuthors", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocBibliography", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocAcknowledgements", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocImgThumbnail", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocDocUploaded", MySql.Data.MySqlClient.MySqlDbType.String);


            oSqlCmdInsert.Parameters.Add("@DocAuthorizations", MySql.Data.MySqlClient.MySqlDbType.String);


            oSqlCmdInsert.Parameters.Add("@DocDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocDateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocStdVisitLast", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocStdVisitCount", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValLow", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValMed", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocStdValHig", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocCountriesCode", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocSiteMapPriority", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocSiteMapChangefreq", MySql.Data.MySqlClient.MySqlDbType.String);


            oSqlCmdInsert.Parameters.Add("@DocPdfUrl", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocPdfVersion", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocPdfTitle", MySql.Data.MySqlClient.MySqlDbType.String);


            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoc SET ";

            szSql += "DocLngId_Main=@DocLngId_Main ";
            szSql += ", DocTypeId=@DocTypeId ";
            szSql += ", DocTypeGroup=@DocTypeGroup ";
            szSql += ", DocTypeGroupSub=@DocTypeGroupSub ";



            szSql += ", DocIsTraslatable=@DocIsTraslatable ";
            szSql += ", DocIsEditable=@DocIsEditable ";
            szSql += ", DocIsActive=@DocIsActive ";
            szSql += ", DocUserId_creator=@DocUserId_creator ";
            szSql += ", DocAuthor=@DocAuthor ";
            szSql += ", DocAuthors=@DocAuthors ";
            szSql += ", DocBibliography=@DocBibliography ";
            szSql += ", DocAcknowledgements=@DocAcknowledgements ";
            szSql += ", DocNotes=@DocNotes ";
            szSql += ", DocImgThumbnail=@DocImgThumbnail ";
            szSql += ", DocDocUploaded=@DocDocUploaded ";


            szSql += ", DocAuthorizations=@DocAuthorizations ";


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


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId_Main", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocTypeId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocTypeGroup", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocTypeGroupSub", MySql.Data.MySqlClient.MySqlDbType.String);



            oSqlCmdUpdate.Parameters.Add("@DocIsTraslatable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocIsEditable", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocIsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocUserId_creator", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocAuthor", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocAuthors", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocBibliography", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocAcknowledgements", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocImgThumbnail", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocDocUploaded", MySql.Data.MySqlClient.MySqlDbType.String);


            oSqlCmdUpdate.Parameters.Add("@DocAuthorizations", MySql.Data.MySqlClient.MySqlDbType.String);


            oSqlCmdUpdate.Parameters.Add("@DocDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocDateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocStdVisitLast", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocStdVisitCount", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValLow", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValMed", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocStdValHig", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocCountriesCode", MySql.Data.MySqlClient.MySqlDbType.String);

            oSqlCmdUpdate.Parameters.Add("@DocSiteMapPriority", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocSiteMapChangefreq", MySql.Data.MySqlClient.MySqlDbType.String);

            oSqlCmdUpdate.Parameters.Add("@DocPdfUrl", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocPdfVersion", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocPdfTitle", MySql.Data.MySqlClient.MySqlDbType.String);


            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoc  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            // CAMBIAR m_idKey por la clave adecuada..................
            if (m_DocId == 0)
            {
                b = false;
            }
            else
            {
                //............................................................
                //............................................................

                // comprobar si existe el id a añadir

                oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;

                oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
                MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
                b = oDR.HasRows;
                oDR.Close();
                ClsMysql.FncClose();
                //.............................................................
                //........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
                //// } 
                //.............................................................
            }
            if (b)
            {
                b = FncSqlUpdate();
            }
            else
            {
                b = FncSqlInsert();
            }



            _mErrorBoolean = !b;
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
            if (!ClsMysql.FncOpen("")) { return false; }
            ////-----------------------------------------------------;
            //// Configurar comando update. 
            ////-------------------------------------------------------;
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DocLngId_Main"].Value = m_DocLngId_Main;
            oSqlCmdUpdate.Parameters["@DocTypeId"].Value = m_DocTypeId;
            oSqlCmdUpdate.Parameters["@DocTypeGroup"].Value = m_DocTypeGroup;
            oSqlCmdUpdate.Parameters["@DocTypeGroupSub"].Value = m_DocTypeGroupSub;


            oSqlCmdUpdate.Parameters["@DocIsTraslatable"].Value = m_DocIsTraslatable;
            oSqlCmdUpdate.Parameters["@DocIsEditable"].Value = m_DocIsEditable;
            oSqlCmdUpdate.Parameters["@DocIsActive"].Value = m_DocIsActive;
            oSqlCmdUpdate.Parameters["@DocUserId_creator"].Value = m_DocUserId_creator;
            oSqlCmdUpdate.Parameters["@DocAuthor"].Value = m_DocAuthor;
            oSqlCmdUpdate.Parameters["@DocAuthors"].Value = m_DocAuthors;
            oSqlCmdUpdate.Parameters["@DocBibliography"].Value = m_DocBibliography;
            oSqlCmdUpdate.Parameters["@DocAcknowledgements"].Value = m_DocAcknowledgements;
            oSqlCmdUpdate.Parameters["@DocNotes"].Value = m_DocNotes;
            oSqlCmdUpdate.Parameters["@DocImgThumbnail"].Value = m_DocImgThumbnail;
            oSqlCmdUpdate.Parameters["@DocDocUploaded"].Value = m_DocDocUploaded;


            oSqlCmdUpdate.Parameters["@DocAuthorizations"].Value = m_DocAuthorizations;


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
                //  MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //ClsMysql.MySqlConnection.Dispose();
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
            oSqlCmdInsert.Parameters["@DocLngId_Main"].Value = m_DocLngId_Main;
            oSqlCmdInsert.Parameters["@DocTypeId"].Value = m_DocTypeId;
            oSqlCmdInsert.Parameters["@DocTypeGroup"].Value = m_DocTypeGroup;
            oSqlCmdInsert.Parameters["@DocTypeGroupSub"].Value = m_DocTypeGroupSub;

            oSqlCmdInsert.Parameters["@DocIsTraslatable"].Value = m_DocIsTraslatable;
            oSqlCmdInsert.Parameters["@DocIsEditable"].Value = m_DocIsEditable;
            oSqlCmdInsert.Parameters["@DocIsActive"].Value = m_DocIsActive;
            oSqlCmdInsert.Parameters["@DocUserId_creator"].Value = m_DocUserId_creator;
            oSqlCmdInsert.Parameters["@DocAuthor"].Value = m_DocAuthor;
            oSqlCmdInsert.Parameters["@DocAuthors"].Value = m_DocAuthors;
            oSqlCmdInsert.Parameters["@DocBibliography"].Value = m_DocBibliography;
            oSqlCmdInsert.Parameters["@DocAcknowledgements"].Value = m_DocAcknowledgements;
            oSqlCmdInsert.Parameters["@DocNotes"].Value = m_DocNotes;
            oSqlCmdInsert.Parameters["@DocImgThumbnail"].Value = m_DocImgThumbnail;
            oSqlCmdInsert.Parameters["@DocDocUploaded"].Value = m_DocDocUploaded;


            oSqlCmdInsert.Parameters["@DocAuthorizations"].Value = m_DocAuthorizations;


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

            oSqlCmdUpdate.Parameters["@DocPdfUrl"].Value = m_DocPdfUrl;
            oSqlCmdUpdate.Parameters["@DocPdfVersion"].Value = m_DocPdfVersion;
            oSqlCmdUpdate.Parameters["@DocPdfTitle"].Value = m_DocPdfTitle;


            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;
                m_DocId = Convert.ToUInt64(oSqlCmdInsert.ExecuteScalar().ToString());
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //  MessageBox.Show (_mErrorString);
            }
            ClsMysql.FncClose();
            //ClsMysql.MySqlConnection.Dispose();
            return !_mErrorBoolean;
        }//--------------------------------------------------------
        //----------------FncSqlFind------------------------------
        //--------------------------------------------------------
        public bool FncSqlFind(UInt64 DocId)
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
            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                //      ClsMysql.FncOpen("");
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_DocLngId_Main = oDR["DocLngId_Main"].ToString().Trim();
                    m_DocTypeId = oDR["DocTypeId"].ToString().Trim();
                    m_DocTypeGroup = oDR["DocTypeGroup"].ToString().Trim();
                    m_DocTypeGroupSub = oDR["DocTypeGroupSub"].ToString().Trim();


                    m_DocIsTraslatable = Convert.ToBoolean(oDR["DocIsTraslatable"].ToString().Trim());
                    m_DocIsEditable = Convert.ToBoolean(oDR["DocIsEditable"].ToString().Trim());
                    m_DocIsActive = Convert.ToBoolean(oDR["DocIsActive"].ToString().Trim());
                    m_DocUserId_creator = Convert.ToInt32(oDR["DocUserId_creator"].ToString().Trim());
                    m_DocAuthor = oDR["DocAuthor"].ToString().Trim();
                    m_DocAuthors = oDR["DocAuthors"].ToString().Trim();
                    m_DocBibliography = oDR["DocBibliography"].ToString().Trim();
                    m_DocAcknowledgements = oDR["DocAcknowledgements"].ToString().Trim();
                    m_DocNotes = oDR["DocNotes"].ToString().Trim();
                    m_DocImgThumbnail = oDR["DocImgThumbnail"].ToString().Trim();
                    m_DocDocUploaded = oDR["DocDocUploaded"].ToString().Trim();


                    m_DocAuthorizations = oDR["DocAuthorizations"].ToString().Trim();


                    m_DocDateCreation = Convert.ToDateTime(oDR["DocDateCreation"].ToString().Trim());
                    m_DocDateUpdate = Convert.ToDateTime(oDR["DocDateUpdate"].ToString().Trim());
                    m_DocStdVisitLast = Convert.ToDateTime(oDR["DocStdVisitLast"].ToString().Trim());
                    m_DocStdVisitCount = Convert.ToInt32(oDR["DocStdVisitCount"].ToString().Trim());
                    m_DocStdValLow = Convert.ToInt32(oDR["DocStdValLow"].ToString().Trim());
                    m_DocStdValMed = Convert.ToInt32(oDR["DocStdValMed"].ToString().Trim());
                    m_DocStdValHig = Convert.ToInt32(oDR["DocStdValHig"].ToString().Trim());
                    m_DocCountriesCode = oDR["DocCountriesCode"].ToString().Trim();

                    m_DocSiteMapPriority = oDR["DocSiteMapPriority"].ToString().Trim();
                    m_DocSiteMapChangefreq = oDR["DocSiteMapChangefreq"].ToString().Trim();




                    m_DocPdfUrl = oDR["DocPdfUrl"].ToString().Trim();
                    m_DocPdfVersion = Convert.ToUInt64(oDR["DocPdfVersion"].ToString().Trim());
                    m_DocPdfTitle = oDR["DocPdfTitle"].ToString().Trim();




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
        public bool FncSqlDelete(UInt64 DocId)
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
            catch (MySqlException xcpt)
            {
                _mErrorString = xcpt.Message;
                _mErrorBoolean = true;
                //  MessageBox.Show (xcpt.Message );
            }
            ClsMysql.FncClose();
            //ClsMysql.MySqlConnection.Dispose();
            return !_mErrorBoolean;
        }
        //------------------------------------------------;

        //--------------------------------------------------------
        //----------------FncSqlExist------------------------------
        //--------------------------------------------------------
        public bool FncSqlExist(UInt64 DocId)
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

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
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

        public String DocLngId_Main
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngId_Main because is it too long,MaxLength=3";
                }
                m_DocLngId_Main = sz.ToLower();

            }
            get { return m_DocLngId_Main; }
        }

        //................................

        public String DocTypeGroup
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 50);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocTypeGroup because is it too long,MaxLength=50";
                }
                m_DocTypeGroup = sz;

            }
            get { return m_DocTypeGroup; }
        }
        public String DocTypeGroupSub
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 250);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocTypeId because is it too long,MaxLength=250";
                }
                m_DocTypeGroupSub = sz;

            }
            get { return m_DocTypeGroupSub; }
        }

        public String DocTypeId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 25)
                {
                    sz = sz.Substring(0, 24);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocTypeId because is it too long,MaxLength=25";
                }
                m_DocTypeId = sz;

            }
            get { return m_DocTypeId; }
        }

        //................................

        public bool DocIsTraslatable
        {
            set
            {
                m_DocIsTraslatable = value;
            }
            get { return m_DocIsTraslatable; }
        }

        //................................

        public bool DocIsEditable
        {
            set
            {
                m_DocIsEditable = value;
            }
            get { return m_DocIsEditable; }
        }

        //................................

        public bool DocIsActive
        {
            set
            {
                m_DocIsActive = value;
            }
            get { return m_DocIsActive; }
        }

        //................................

        public Int32 DocUserId_creator
        {
            set
            {
                m_DocUserId_creator = value;
            }
            get { return m_DocUserId_creator; }
        }

        public String DocAuthor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocAuthor because is it too long,MaxLength=150";
                }
                m_DocAuthor = sz;

            }
            get { return m_DocAuthor; }
        }

        //................................

        public String DocAuthors
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocAuthors because is it too long,MaxLength=150";
                }
                m_DocAuthors = sz;

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

        public string DocDocUploaded
        {
            set
            {
                m_DocDocUploaded = value;
            }
            get { return m_DocDocUploaded; }
        }
        //................................
        public string DocImgThumbnail
        {
            set
            {
                m_DocImgThumbnail = value;
            }
            get { return m_DocImgThumbnail; }
        }
        public String DocNotes
        {
            set
            {
                m_DocNotes = value;
            }
            get { return m_DocNotes; }
        }

        public String DocAuthorizations
        {
            set
            {
                m_DocAuthorizations = value;
            }
            get { return m_DocAuthorizations; }
        }
        //................................

        public DateTime DocDateCreation
        {
            set
            {
                m_DocDateCreation = value;
            }
            get { return m_DocDateCreation; }
        }

        //................................

        public DateTime DocDateUpdate
        {
            set
            {
                m_DocDateUpdate = value;
            }
            get { return m_DocDateUpdate; }
        }

        //................................

        public DateTime DocStdVisitLast
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
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocCountriesCode because is it too long,MaxLength=150";
                }
                m_DocCountriesCode = sz;

            }
            get { return m_DocCountriesCode; }
        }



        public String DocSiteMapPriority
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 4)
                {
                    sz = sz.Substring(0, 3);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocCountriesCode because is it too long,MaxLength=150";
                }
                m_DocSiteMapPriority = sz;

            }
            get { return m_DocSiteMapPriority; }
        }

        public String DocSiteMapChangefreq
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 10)
                {
                    sz = sz.Substring(0, 9);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocCountriesCode because is it too long,MaxLength=150";
                }
                m_DocSiteMapChangefreq = sz;

            }
            get { return m_DocSiteMapChangefreq; }
        }


        public String DocPdfUrl
        {
            get { return m_DocPdfUrl; }
            set
            {
                string sz = value.Trim();
                if (sz.Length > 249)
                {
                    sz = sz.Substring(0, 248);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocCountriesCode because is it too long,MaxLength=150";
                }



                m_DocPdfUrl = sz;
            }
        }

        public UInt64 DocPdfVersion
        {
            get { return m_DocPdfVersion; }
            set { m_DocPdfVersion = value; }
        }
        public String DocPdfTitle
        {
            get { return m_DocPdfTitle; }
            set
            {
                string sz = value.Trim();
                if (sz.Length > 249)
                {
                    sz = sz.Substring(0, 248);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocCountriesCode because is it too long,MaxLength=150";
                }



                m_DocPdfTitle = sz;
            }


            
        }


        #endregion VALORES_GETSET

    }
}
