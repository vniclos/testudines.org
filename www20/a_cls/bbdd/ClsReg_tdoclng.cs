using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng
    {
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectDocLngUrlTitle = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";
        private String m_DocLngUrlId = "";
        private String m_DocLngUrlTitle = "";
        private Int64 m_DocId_tdoclng_Todo = 0;
        private bool m_DocLngUrlIdChk = false;
        private bool m_DocLngUrlTitleChk = false;
        private String m_DocLngMetaTitle = "";
        private String m_DocLngMetaDescription = "";
        private String m_DocLngMetaKeyWords = "";
        private String m_DocLngMetaLanguage = "";
        private String m_DocLngRevisit_after = "";
        private String m_DocLngMetaAuthor = "";
        private String m_DocLngMetaTranslators = "";
        private String m_DocLngMetaRobots = "";
        private String m_DocLngMetaContentType = "";
        private DateTime m_DocLngDateUpdate = DateTime.Now;
        private DateTime m_DocLngDateCreation = DateTime.Now;
        private String m_DocLngStatusRevision = "";
        private String m_DocLngNotes = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng()
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
            m_DocLngUrlId = "";
            m_DocLngUrlTitle = "";
            m_DocId_tdoclng_Todo = 0;
            m_DocLngUrlIdChk = false;
            m_DocLngUrlTitleChk = false;
            m_DocLngMetaTitle = "";
            m_DocLngMetaDescription = "";
            m_DocLngMetaKeyWords = "";
            m_DocLngMetaLanguage = "";
            m_DocLngRevisit_after = "";
            m_DocLngMetaAuthor = "";
            m_DocLngMetaTranslators = "";
            m_DocLngMetaRobots = "";
            m_DocLngMetaContentType = "";
            DateTime oDate = System.DateTime.Now;
            m_DocLngDateUpdate = oDate;
            m_DocLngDateCreation = oDate;
            m_DocLngStatusRevision = "";
            m_DocLngNotes = "";
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
            szSql = "SELECT * FROM tdoclng  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  oSqlCmdSelectDocLngUrlTitle -----------
            //----------------------------------------------------------------------
            szSql = "SELECT";
            szSql += " DocId, DocLngId";
            szSql += " FROM tdoclng";
            szSql += " WHERE ";
            szSql += "(DocLngUrlTitle=@DocLngUrlTitle )";
            oSqlCmdSelectDocLngUrlTitle.CommandText = szSql;
            oSqlCmdSelectDocLngUrlTitle.Parameters.Add("@DocLngUrlTitle", MySql.Data.MySqlClient.MySqlDbType.String);

            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", DocLngUrlId ";
            szSql += ", DocLngUrlTitle ";
            szSql += ", DocId_tdoclng_Todo ";
            szSql += ", DocLngUrlIdChk ";
            szSql += ", DocLngUrlTitleChk ";
            szSql += ", DocLngMetaTitle ";
            szSql += ", DocLngMetaDescription ";
            szSql += ", DocLngMetaKeyWords ";
            szSql += ", DocLngMetaLanguage ";
            szSql += ", DocLngRevisit_after ";
            szSql += ", DocLngMetaAuthor ";
            szSql += ", DocLngMetaTranslators ";
            szSql += ", DocLngMetaRobots ";
            szSql += ", DocLngMetaContentType ";
            szSql += ", DocLngDateUpdate ";
            szSql += ", DocLngDateCreation ";
            szSql += ", DocLngStatusRevision ";
            szSql += ", DocLngNotes ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @DocLngUrlId ";
            szSql += ", @DocLngUrlTitle ";
            szSql += ", @DocId_tdoclng_Todo ";
            szSql += ", @DocLngUrlIdChk ";
            szSql += ", @DocLngUrlTitleChk ";
            szSql += ", @DocLngMetaTitle ";
            szSql += ", @DocLngMetaDescription ";
            szSql += ", @DocLngMetaKeyWords ";
            szSql += ", @DocLngMetaLanguage ";
            szSql += ", @DocLngRevisit_after ";
            szSql += ", @DocLngMetaAuthor ";
            szSql += ", @DocLngMetaTranslators ";
            szSql += ", @DocLngMetaRobots ";
            szSql += ", @DocLngMetaContentType ";
            szSql += ", @DocLngDateUpdate ";
            szSql += ", @DocLngDateCreation ";
            szSql += ", @DocLngStatusRevision ";
            szSql += ", @DocLngNotes ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngUrlId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngUrlTitle", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocId_tdoclng_Todo", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocLngUrlIdChk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocLngUrlTitleChk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaTitle", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaDescription", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaKeyWords", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaLanguage", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngRevisit_after", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaAuthor", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaTranslators", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaRobots", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngMetaContentType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngDateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocLngDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DocLngStatusRevision", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DocLngNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng SET ";

            szSql += "DocLngUrlId=@DocLngUrlId ";
            szSql += ", DocLngUrlTitle=@DocLngUrlTitle ";
            szSql += ", DocId_tdoclng_Todo=@DocId_tdoclng_Todo ";
            szSql += ", DocLngUrlIdChk=@DocLngUrlIdChk ";
            szSql += ", DocLngUrlTitleChk=@DocLngUrlTitleChk ";
            szSql += ", DocLngMetaTitle=@DocLngMetaTitle ";
            szSql += ", DocLngMetaDescription=@DocLngMetaDescription ";
            szSql += ", DocLngMetaKeyWords=@DocLngMetaKeyWords ";
            szSql += ", DocLngMetaLanguage=@DocLngMetaLanguage ";
            szSql += ", DocLngRevisit_after=@DocLngRevisit_after ";
            szSql += ", DocLngMetaAuthor=@DocLngMetaAuthor ";
            szSql += ", DocLngMetaTranslators=@DocLngMetaTranslators ";
            szSql += ", DocLngMetaRobots=@DocLngMetaRobots ";
            szSql += ", DocLngMetaContentType=@DocLngMetaContentType ";
            szSql += ", DocLngDateUpdate=@DocLngDateUpdate ";
            szSql += ", DocLngDateCreation=@DocLngDateCreation ";
            szSql += ", DocLngStatusRevision=@DocLngStatusRevision ";
            szSql += ", DocLngNotes=@DocLngNotes ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngUrlId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngUrlTitle", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocId_tdoclng_Todo", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocLngUrlIdChk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocLngUrlTitleChk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaTitle", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaDescription", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaKeyWords", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaLanguage", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngRevisit_after", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaAuthor", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaTranslators", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaRobots", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngMetaContentType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngDateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocLngDateCreation", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DocLngStatusRevision", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DocLngNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng  ";
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
            szSql += " FROM tdoclng  ";

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

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.MySqlConnection.Close();
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
        /// <summary>
        /// Salva los metas de documento, url friendly, y datos
        /// globales para el idioma
        /// </summary>
        /// <param name="szMaskUrl">mascara para contruire e path friendly
        /// segun patron /{DocLngId}/szMaskUrl/{DocId}
        /// ejem /tortoises/</param>
        /// <returns></returns>
        public bool FncSqlSave(string szMaskUrl)
        {
         
            FncNormalizeUrl(szMaskUrl);






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

            oSqlCmdSelectExist.Connection =  ClsMysql.MySqlConnection; ;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.MySqlConnection.Close();
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
            oSqlCmdUpdate.Parameters["@DocLngUrlId"].Value = m_DocLngUrlId;
            oSqlCmdUpdate.Parameters["@DocLngUrlTitle"].Value = m_DocLngUrlTitle;
            oSqlCmdUpdate.Parameters["@DocId_tdoclng_Todo"].Value = m_DocId_tdoclng_Todo;
            oSqlCmdUpdate.Parameters["@DocLngUrlIdChk"].Value = m_DocLngUrlIdChk;
            oSqlCmdUpdate.Parameters["@DocLngUrlTitleChk"].Value = m_DocLngUrlTitleChk;
            oSqlCmdUpdate.Parameters["@DocLngMetaTitle"].Value = m_DocLngMetaTitle;
            oSqlCmdUpdate.Parameters["@DocLngMetaDescription"].Value = m_DocLngMetaDescription;
            oSqlCmdUpdate.Parameters["@DocLngMetaKeyWords"].Value = m_DocLngMetaKeyWords;
            oSqlCmdUpdate.Parameters["@DocLngMetaLanguage"].Value = m_DocLngMetaLanguage;
            oSqlCmdUpdate.Parameters["@DocLngRevisit_after"].Value = m_DocLngRevisit_after;
            oSqlCmdUpdate.Parameters["@DocLngMetaAuthor"].Value = m_DocLngMetaAuthor;
            oSqlCmdUpdate.Parameters["@DocLngMetaTranslators"].Value = m_DocLngMetaTranslators;
            oSqlCmdUpdate.Parameters["@DocLngMetaRobots"].Value = m_DocLngMetaRobots;
            oSqlCmdUpdate.Parameters["@DocLngMetaContentType"].Value = m_DocLngMetaContentType;
            oSqlCmdUpdate.Parameters["@DocLngDateUpdate"].Value = m_DocLngDateUpdate;
            oSqlCmdUpdate.Parameters["@DocLngDateCreation"].Value = m_DocLngDateCreation;
            oSqlCmdUpdate.Parameters["@DocLngStatusRevision"].Value = m_DocLngStatusRevision;
            oSqlCmdUpdate.Parameters["@DocLngNotes"].Value = m_DocLngNotes;
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
            ClsMysql.MySqlConnection.Close();
            ClsMysql.MySqlConnection.Dispose();
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
            oSqlCmdInsert.Parameters["@DocLngUrlId"].Value = m_DocLngUrlId;
            oSqlCmdInsert.Parameters["@DocLngUrlTitle"].Value = m_DocLngUrlTitle;
            oSqlCmdInsert.Parameters["@DocId_tdoclng_Todo"].Value = m_DocId_tdoclng_Todo;
            oSqlCmdInsert.Parameters["@DocLngUrlIdChk"].Value = m_DocLngUrlIdChk;
            oSqlCmdInsert.Parameters["@DocLngUrlTitleChk"].Value = m_DocLngUrlTitleChk;
            oSqlCmdInsert.Parameters["@DocLngMetaTitle"].Value = m_DocLngMetaTitle;
            oSqlCmdInsert.Parameters["@DocLngMetaDescription"].Value = m_DocLngMetaDescription;
            oSqlCmdInsert.Parameters["@DocLngMetaKeyWords"].Value = m_DocLngMetaKeyWords;
            oSqlCmdInsert.Parameters["@DocLngMetaLanguage"].Value = m_DocLngMetaLanguage;
            oSqlCmdInsert.Parameters["@DocLngRevisit_after"].Value = m_DocLngRevisit_after;
            oSqlCmdInsert.Parameters["@DocLngMetaAuthor"].Value = m_DocLngMetaAuthor;
            oSqlCmdInsert.Parameters["@DocLngMetaTranslators"].Value = m_DocLngMetaTranslators;
            oSqlCmdInsert.Parameters["@DocLngMetaRobots"].Value = m_DocLngMetaRobots;
            oSqlCmdInsert.Parameters["@DocLngMetaContentType"].Value = m_DocLngMetaContentType;
            oSqlCmdInsert.Parameters["@DocLngDateUpdate"].Value = m_DocLngDateUpdate;
            oSqlCmdInsert.Parameters["@DocLngDateCreation"].Value = m_DocLngDateCreation;
            oSqlCmdInsert.Parameters["@DocLngStatusRevision"].Value = m_DocLngStatusRevision;
            oSqlCmdInsert.Parameters["@DocLngNotes"].Value = m_DocLngNotes;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;
                oSqlCmdInsert.ExecuteNonQuery();
            }
            catch (SystemException ex)
            {
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
                //  MessageBox.Show (_mErrorString);
            }
            ClsMysql.MySqlConnection.Close();
            ClsMysql.MySqlConnection.Dispose();
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
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                     ClsMysql.FncOpen("");
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    m_DocLngUrlId = oDR["DocLngUrlId"].ToString().Trim();
                    m_DocLngUrlTitle = oDR["DocLngUrlTitle"].ToString().Trim();
                    m_DocId_tdoclng_Todo = Convert.ToInt32(oDR["DocId_tdoclng_Todo"].ToString().Trim());
                    m_DocLngUrlIdChk = Convert.ToBoolean(oDR["DocLngUrlIdChk"].ToString().Trim());
                    m_DocLngUrlTitleChk = Convert.ToBoolean(oDR["DocLngUrlTitleChk"].ToString().Trim());
                    m_DocLngMetaTitle = oDR["DocLngMetaTitle"].ToString().Trim();
                    m_DocLngMetaDescription = oDR["DocLngMetaDescription"].ToString().Trim();
                    m_DocLngMetaKeyWords = oDR["DocLngMetaKeyWords"].ToString().Trim();
                    m_DocLngMetaLanguage = oDR["DocLngMetaLanguage"].ToString().Trim();
                    m_DocLngRevisit_after = oDR["DocLngRevisit_after"].ToString().Trim();
                    m_DocLngMetaAuthor = oDR["DocLngMetaAuthor"].ToString().Trim();
                    m_DocLngMetaTranslators = oDR["DocLngMetaTranslators"].ToString().Trim();
                    m_DocLngMetaRobots = oDR["DocLngMetaRobots"].ToString().Trim();
                    m_DocLngMetaContentType = oDR["DocLngMetaContentType"].ToString().Trim();
                    m_DocLngDateUpdate = Convert.ToDateTime(oDR["DocLngDateUpdate"].ToString().Trim());
                    m_DocLngDateCreation = Convert.ToDateTime(oDR["DocLngDateCreation"].ToString().Trim());
                    m_DocLngStatusRevision = oDR["DocLngStatusRevision"].ToString().Trim();
                    m_DocLngNotes = oDR["DocLngNotes"].ToString().Trim();
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
         
            //ClsMysql.MySqlConnection.Close();
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
            oSqlCmdDelete.Connection = ClsMysql.MySqlConnection;
            try
            {
                oSqlCmdDelete.Parameters["@DocId"].Value = DocId;
                oSqlCmdDelete.Parameters["@DocLngId"].Value = DocLngId;
                int i = oSqlCmdDelete.ExecuteNonQuery();
                if (i > 0)
                {
                    FncClear();

                    // si en la tabla tdocLng no existe otro con distinto idioma
                    // entonces borrar tambien el documento de tdoc
                    string szSql = "select count(docid) from tdoclng where DocLng=" + DocId.ToString();
                    MySqlCommand oCmdDel = new MySqlCommand (szSql,ClsMysql.MySqlConnection);
                    int iCount= Convert.ToInt32( oCmdDel.ExecuteScalar().ToString ())  ;
                    if (iCount==0)
                    {
                        szSql="delete tdoc where docId="+DocId.ToString();
                        oCmdDel.CommandText = szSql;
                        iCount = Convert.ToInt32(oCmdDel.ExecuteScalar().ToString());
                    
                    }
                    oCmdDel.Dispose();
                }
            }
            catch (MySqlException xcpt)
            {
                _mErrorString = xcpt.Message;
                _mErrorBoolean = true;
                //  MessageBox.Show (xcpt.Message );
            }
            
            ClsMysql.MySqlConnection.Close();
            ClsMysql.MySqlConnection.Dispose();
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

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.MySqlConnection.Close();
            return b;
        }////--------------------------------------------------------r
        ////----------------FncSqlOpenCnn--------------------------
        ////--------------------------------------------------------
      
        public UInt64 FncSqlExist_other_DocLngUrlTitle(String szDocLngUrlTitle)
        {

            _mErrorBoolean = false;
            _mErrorString = "";
            UInt64 i_DocId = 0;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return 0;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            string szSufig = "";
            string szFind = "";
            int i = 0;
            oSqlCmdSelectDocLngUrlTitle.Connection = ClsMysql.MySqlConnection;

            bool bRepite = true;
            while (bRepite == true)
            {
                szFind = szDocLngUrlTitle + szSufig;
                oSqlCmdSelectDocLngUrlTitle.Parameters["@DocLngUrlTitle"].Value = szFind;
                try
                {
                    i_DocId = Convert.ToUInt64(oSqlCmdSelectDocLngUrlTitle.ExecuteScalar());
                    if (i_DocId == 0) bRepite = false;
                    if (i_DocId == m_DocId) bRepite = false;

                }

                catch
                { bRepite = false; }
                if (bRepite)
                {
                    i++;
                    szSufig = "(" + i.ToString() + ")";
                }

            }
            ClsMysql.MySqlConnection.Close();
            m_DocLngUrlTitle = m_DocLngUrlTitle + szSufig;
            return i_DocId;
        }


        public bool FncSqlFind_DocLngUrlTitle(String szDocLngUrlTitle)
        {
            szDocLngUrlTitle = szDocLngUrlTitle.ToLower().Trim();
            _mErrorBoolean = false;
            _mErrorString = "";
            UInt64 i_DocId;
            string szDocLngId = szDocLngUrlTitle.Substring(1, 2).ToLower(); ;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen("")) return false;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelectDocLngUrlTitle.Connection = ClsMysql.MySqlConnection;
            oSqlCmdSelectDocLngUrlTitle.Parameters["@DocLngUrlTitle"].Value = szDocLngUrlTitle;
            try
            {
                i_DocId = Convert.ToUInt64(oSqlCmdSelectDocLngUrlTitle.ExecuteScalar());
                FncSqlFind(i_DocId, szDocLngId);
                _mErrorBoolean = false; ;
            }

            catch
            { _mErrorBoolean = true; }



            ClsMysql.MySqlConnection.Close();

            return !_mErrorBoolean;

        }

        /// <summary>
        /// Pasasa una cadena quita acentos, caraceres no validos 
        /// y sustituye blancos por -  gion medio
        /// </summary>
        /// <returns></returns>
        private void FncNormalizeUrl(string szMaskUrl)
        {
            //===============================
            // NO debe existir otro ID de documento con identicas url friendly
            // a) ni basadas en el docID
            // b) ni basadas en el titulo
            //===============================
            UInt64 id = FncSqlExist_other_DocLngUrlTitle(m_DocLngUrlTitle);



            m_DocLngUrlId = "/" + m_DocLngId + "/" + szMaskUrl + "/" + m_DocId.ToString();
            string sz = "/" + m_DocLngId + "/" + szMaskUrl + "/" + m_DocLngMetaTitle;
       
            sz =  ClsUtils.FncPathRemoveAccentsWithNormalization(sz).Trim().ToLower();
            sz = sz.Replace(" ", ".");
            sz = sz.Replace(".", ".");
            sz = sz.Replace(":", ".");
            sz = sz.Replace(";", ".");
            sz = sz.Replace(",", ".");
            sz = sz.Replace("#", ".");
            sz = sz.Replace("-", ".");
            sz = sz.Replace("(", ".");
            sz = sz.Replace(")", ".");
            sz = sz.Replace("[", ".");
            sz = sz.Replace("]", ".");
            sz = sz.Replace("{", ".");
            sz = sz.Replace("}", ".");
            sz = sz.Replace("*", ".");
            sz = sz.Replace("%", ".");
            sz = sz.Replace("!", ".");
            sz = sz.Replace("¡", ".");
            sz = sz.Replace("$", ".");
            sz = sz.Replace("&", ".");
            sz = sz.Replace("=", ".");
            while (sz.Contains(".."))
            {
                sz = sz.Replace("..", ".");
            }
            while (sz.Contains("//"))
            {
                sz = sz.Replace("//", "/");
            }
            m_DocLngUrlTitle = sz;




            //---------------------------------------------------
            // ahora ulr by id
            //------------------------------------------------------
            m_DocLngUrlId = "/" + m_DocLngId + "/" + szMaskUrl + "/" + m_DocId.ToString();
            while (m_DocLngUrlId.Contains("//"))
            {
                m_DocLngUrlId = m_DocLngUrlId.Replace("//", "/");
            }


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

        public String DocLngUrlId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngUrlId because is it too long,MaxLength=250";
                }
                m_DocLngUrlId = sz;

            }
            get { return m_DocLngUrlId; }
        }

        //................................

        public String DocLngUrlTitle
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngUrlTitle because is it too long,MaxLength=250";
                }
                m_DocLngUrlTitle = sz;

            }
            get { return m_DocLngUrlTitle; }
        }

        //................................

        public Int64 DocId_tdoclng_Todo
        {
            set
            {
                m_DocId_tdoclng_Todo = value;
            }
            get { return m_DocId_tdoclng_Todo; }
        }

        //................................

        public bool DocLngUrlIdChk
        {
            set
            {
                m_DocLngUrlIdChk = value;
            }
            get { return m_DocLngUrlIdChk; }
        }

        //................................

        public bool DocLngUrlTitleChk
        {
            set
            {
                m_DocLngUrlTitleChk = value;
            }
            get { return m_DocLngUrlTitleChk; }
        }

        //................................

        public String DocLngMetaTitle
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaTitle because is it too long,MaxLength=250";
                }
                m_DocLngMetaTitle = sz;

            }
            get { return m_DocLngMetaTitle; }
        }

        //................................

        public String DocLngMetaDescription
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaDescription because is it too long,MaxLength=250";
                }
                m_DocLngMetaDescription = sz;

            }
            get { return m_DocLngMetaDescription; }
        }

        //................................

        public String DocLngMetaKeyWords
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 100)
                {
                    sz = sz.Substring(0, 99);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaKeyWords because is it too long,MaxLength=100";
                }
                m_DocLngMetaKeyWords = sz;

            }
            get { return m_DocLngMetaKeyWords; }
        }

        //................................

        public String DocLngMetaLanguage
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 3)
                {
                    sz = sz.Substring(0, 2);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaLanguage because is it too long,MaxLength=3";
                }
                m_DocLngMetaLanguage = sz;

            }
            get { return m_DocLngMetaLanguage; }
        }

        //................................

        public String DocLngRevisit_after
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 10)
                {
                    sz = sz.Substring(0, 9);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngRevisit_after because is it too long,MaxLength=10";
                }
                m_DocLngRevisit_after = sz;

            }
            get { return m_DocLngRevisit_after; }
        }

        //................................

        public String DocLngMetaAuthor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 100)
                {
                    sz = sz.Substring(0, 99);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaAuthor because is it too long,MaxLength=100";
                }
                m_DocLngMetaAuthor = sz;

            }
            get { return m_DocLngMetaAuthor; }
        }

        //................................

        public String DocLngMetaTranslators
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaTranslators because is it too long,MaxLength=150";
                }
                m_DocLngMetaTranslators = sz;

            }
            get { return m_DocLngMetaTranslators; }
        }

        //................................

        public String DocLngMetaRobots
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 35)
                {
                    sz = sz.Substring(0, 34);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaRobots because is it too long,MaxLength=35";
                }
                m_DocLngMetaRobots = sz;

            }
            get { return m_DocLngMetaRobots; }
        }

        //................................

        public String DocLngMetaContentType
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 35)
                {
                    sz = sz.Substring(0, 34);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngMetaContentType because is it too long,MaxLength=35";
                }
                m_DocLngMetaContentType = sz;

            }
            get { return m_DocLngMetaContentType; }
        }

        //................................

        public DateTime DocLngDateUpdate
        {
            set
            {
                m_DocLngDateUpdate = value;
            }
            get { return m_DocLngDateUpdate; }
        }

        //................................

        public DateTime DocLngDateCreation
        {
            set
            {
                m_DocLngDateCreation = value;
            }
            get { return m_DocLngDateCreation; }
        }

        //................................

        public String DocLngStatusRevision
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngStatusRevision because is it too long,MaxLength=50";
                }
                m_DocLngStatusRevision = sz;

            }
            get { return m_DocLngStatusRevision; }
        }

        //................................

        public String DocLngNotes
        {
            set
            {
                m_DocLngNotes = value;
            }
            get { return m_DocLngNotes; }
        }

        #endregion VALORES_GETSET

    }
}
