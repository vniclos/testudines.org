using System;
using MySql.Data.MySqlClient;
using System.Data;

    using System.Globalization;
using System.Threading;
namespace testudines.cls.bbdd
{ 

    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoc_biblio : IDisposable
    {
        private static String m_Culture_before = "";
        private static String m_Culture_Called = "";


        cls.bbdd.ClsReg_tdoc oRegDoc = new cls.bbdd.ClsReg_tdoc();
        cls.bbdd.ClsReg_tdoc_biblio_rel oRegBiblioRel = new cls.bbdd.ClsReg_tdoc_biblio_rel();
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
       
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExistCiteAutorYearABC = new MySqlCommand();
        private MySqlCommand oSqlCmdCountParents = new MySqlCommand();
        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_CiteAutorYearABC = "";
        private String m_CiteHtmlToolTip = "";
        private String m_CiteHtmlFull = "";
        private String m_Authors = "";
        private String m_Title = "";
        private String m_PublicationType = "";
        private String m_PublicationName = "";
        private String m_PublicationDatePage = "";
        private String m_PublicationNotes = "";
        private String m_PublicationReaded = "";
        private String m_URPublication = "";
        private String m_URLocalDownload = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoc_biblio(string szSqlConnectionString)
        //{
        public ClsReg_tdoc_biblio()
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
        ~ClsReg_tdoc_biblio()
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
            m_CiteAutorYearABC = "";
            m_CiteHtmlToolTip = "";
            m_CiteHtmlFull = "";
            m_Authors = "";
            m_Title = "";
            m_PublicationType = "";
            m_PublicationName = "";
            m_PublicationDatePage = "";
            m_PublicationNotes = "";
            m_PublicationReaded = "";
            m_URPublication = "";
            m_URLocalDownload = "";
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
            szSql = "SELECT * FROM tdoc_biblio  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoc_biblio";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", CiteAutorYearABC ";
            szSql += ", CiteHtmlToolTip ";
            szSql += ", CiteHtmlFull ";
            szSql += ", Authors ";
            szSql += ", Title ";
            szSql += ", PublicationType ";
            szSql += ", PublicationName ";
            szSql += ", PublicationDatePage ";
            szSql += ", PublicationNotes ";
            szSql += ", PublicationReaded ";
            szSql += ", URPublication ";
            szSql += ", URLocalDownload ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @CiteAutorYearABC ";
            szSql += ", @CiteHtmlToolTip ";
            szSql += ", @CiteHtmlFull ";
            szSql += ", @Authors ";
            szSql += ", @Title ";
            szSql += ", @PublicationType ";
            szSql += ", @PublicationName ";
            szSql += ", @PublicationDatePage ";
            szSql += ", @PublicationNotes ";
            szSql += ", @PublicationReaded ";
            szSql += ", @URPublication ";
            szSql += ", @URLocalDownload ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@CiteAutorYearABC", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@CiteHtmlToolTip", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@CiteHtmlFull", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Authors", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@PublicationType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@PublicationName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@PublicationDatePage", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@PublicationNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@PublicationReaded", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@URPublication", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@URLocalDownload", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoc_biblio SET ";

            szSql += "CiteAutorYearABC=@CiteAutorYearABC ";
            szSql += ", CiteHtmlToolTip=@CiteHtmlToolTip ";
            szSql += ", CiteHtmlFull=@CiteHtmlFull ";
            szSql += ", Authors=@Authors ";
            szSql += ", Title=@Title ";
            szSql += ", PublicationType=@PublicationType ";
            szSql += ", PublicationName=@PublicationName ";
            szSql += ", PublicationDatePage=@PublicationDatePage ";
            szSql += ", PublicationNotes=@PublicationNotes ";
            szSql += ", PublicationReaded=@PublicationReaded ";
            szSql += ", URPublication=@URPublication ";
            szSql += ", URLocalDownload=@URLocalDownload ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@CiteAutorYearABC", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@CiteHtmlToolTip", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@CiteHtmlFull", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Authors", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@PublicationType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@PublicationName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@PublicationDatePage", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@PublicationNotes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@PublicationReaded", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@URPublication", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@URLocalDownload", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoc_biblio  ";
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
            szSql += " FROM tdoc_biblio  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT DocId FROM tdoc_biblio WHERE CiteAutorYearABC=@CiteAutorYearABC";
            oSqlCmdSelectExistCiteAutorYearABC.CommandText = szSql;
            oSqlCmdSelectExistCiteAutorYearABC.Parameters.Add("@CiteAutorYearABC", MySql.Data.MySqlClient.MySqlDbType.String);
        //-----------------------------------------------------------------
            //----------------------------------------------------------
            szSql = "SELECT count(DocIdParent) FROM tdoc_biblio_rel WHERE DocId=@DocId";
            oSqlCmdCountParents.CommandText = szSql;
            oSqlCmdCountParents.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
        

           
        
        }
        //--------------------------------------------------------



        //	-------------------------------------------------

        public bool FncSqlSave()
        {
            if (m_DocId == 0)
            {
                // evitar cita abreviada duplicada en el caso de adicion;
                oRegDoc.DocId = FncSqlExistCiteAutorYearABC(m_CiteAutorYearABC);
                if (oRegDoc.DocId == 0)
                {
                    oRegDoc.DocTypeId = "bibliography";
                    oRegDoc.DocTypeGroup = "bibliography";
                    oRegDoc.DocTypeGroupSub = "Taxa";
                    if (!oRegDoc.FncSqlSave())
                    {
                        return false;
                    }
                }
                m_DocId = oRegDoc.DocId;
                
            }
         

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

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            //.............................................................
            //........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
            //// } 
            //.............................................................
            FncFieldCalcCiteHtmlToolTip();
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
            oSqlCmdUpdate.Parameters["@CiteAutorYearABC"].Value = m_CiteAutorYearABC;
            oSqlCmdUpdate.Parameters["@CiteHtmlToolTip"].Value = m_CiteHtmlToolTip;
            oSqlCmdUpdate.Parameters["@CiteHtmlFull"].Value = m_CiteHtmlFull;
            oSqlCmdUpdate.Parameters["@Authors"].Value = m_Authors;
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@PublicationType"].Value = m_PublicationType;
            oSqlCmdUpdate.Parameters["@PublicationName"].Value = m_PublicationName;
            oSqlCmdUpdate.Parameters["@PublicationDatePage"].Value = m_PublicationDatePage;
            oSqlCmdUpdate.Parameters["@PublicationNotes"].Value = m_PublicationNotes;
            oSqlCmdUpdate.Parameters["@PublicationReaded"].Value = m_PublicationReaded;
            oSqlCmdUpdate.Parameters["@URPublication"].Value = m_URPublication;
            oSqlCmdUpdate.Parameters["@URLocalDownload"].Value = m_URLocalDownload;
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
            oSqlCmdInsert.Parameters["@CiteAutorYearABC"].Value = m_CiteAutorYearABC;
            oSqlCmdInsert.Parameters["@CiteHtmlToolTip"].Value = m_CiteHtmlToolTip;
            oSqlCmdInsert.Parameters["@CiteHtmlFull"].Value = m_CiteHtmlFull;
            oSqlCmdInsert.Parameters["@Authors"].Value = m_Authors;
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@PublicationType"].Value = m_PublicationType;
            oSqlCmdInsert.Parameters["@PublicationName"].Value = m_PublicationName;
            oSqlCmdInsert.Parameters["@PublicationDatePage"].Value = m_PublicationDatePage;
            oSqlCmdInsert.Parameters["@PublicationNotes"].Value = m_PublicationNotes;
            oSqlCmdInsert.Parameters["@PublicationReaded"].Value = m_PublicationReaded;
            oSqlCmdInsert.Parameters["@URPublication"].Value = m_URPublication;
            oSqlCmdInsert.Parameters["@URLocalDownload"].Value = m_URLocalDownload;
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
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_CiteAutorYearABC = oDR["CiteAutorYearABC"].ToString().Trim();
                    m_CiteHtmlToolTip = oDR["CiteHtmlToolTip"].ToString().Trim();
                    m_CiteHtmlFull = oDR["CiteHtmlFull"].ToString().Trim();
                    m_Authors = oDR["Authors"].ToString().Trim();
                    m_Title = oDR["Title"].ToString().Trim();
                    m_PublicationType = oDR["PublicationType"].ToString().Trim();
                    m_PublicationName = oDR["PublicationName"].ToString().Trim();
                    m_PublicationDatePage = oDR["PublicationDatePage"].ToString().Trim();
                    m_PublicationNotes = oDR["PublicationNotes"].ToString().Trim();
                    m_PublicationReaded = oDR["PublicationReaded"].ToString().Trim();
                    m_URPublication = oDR["URPublication"].ToString().Trim();
                    m_URLocalDownload = oDR["URLocalDownload"].ToString().Trim();
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
        public bool FncSqlDelete(Int64 DocId)
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
        public bool FncSqlExist(Int64 DocId)
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

        public String CiteAutorYearABC
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CiteAutorYearABC because is it too long,MaxLength=250";
                }
                m_CiteAutorYearABC = sz;

            }
            get { return m_CiteAutorYearABC; }
        }

        //................................

        public String CiteHtmlToolTip
        {
            //set
            //{
            //    m_CiteHtmlToolTip = value;
            //}
            get
            {

                FncFieldCalcCiteHtmlToolTip();
                return m_CiteHtmlToolTip;
            }
        }

        //................................

        public String CiteHtmlFull
        {
            set
            {
                m_CiteHtmlFull = value;
            }
            get { return m_CiteHtmlFull; }
        }

        //................................

        public String Authors
        {
            set
            {
                m_Authors = value;
            }
            get { return m_Authors; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=250";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String PublicationType
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_PublicationType because is it too long,MaxLength=50";
                }
                m_PublicationType = sz;

            }
            get { return m_PublicationType; }
        }

        //................................

        public String PublicationName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_PublicationName because is it too long,MaxLength=250";
                }
                m_PublicationName = sz;

            }
            get { return m_PublicationName; }
        }

        //................................

        public String PublicationDatePage
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_PublicationDatePage because is it too long,MaxLength=50";
                }
                m_PublicationDatePage = sz;

            }
            get { return m_PublicationDatePage; }
        }

        //................................

        public String PublicationNotes
        {
            set
            {
                m_PublicationNotes = value;
            }
            get { return m_PublicationNotes; }
        }

        //................................

        public String PublicationReaded
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 10)
                {
                    sz = sz.Substring(0, 9);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_PublicationReaded because is it too long,MaxLength=10";
                }
                m_PublicationReaded = sz;

            }
            get { return m_PublicationReaded; }
        }

        //................................

        public String URPublication
        {
            set
            {
                m_URPublication = value;
            }
            get { return m_URPublication; }
        }

        //................................

        public String URLocalDownload
        {
            set
            {
                m_URLocalDownload = value;
            }
            get { return m_URLocalDownload; }
        }

        #endregion VALORES_GETSET

    




//-----------------------------------------------------
//-----------------------------------------------------
        public String FncHtmlbyDocId_Parent(UInt64 docId_Parent)
        {


            _mErrorBoolean = false;
            _mErrorString = "";
            bool b = false;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return "";
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            string szHtml = "";
            string szSql = "Select  tdoc_biblio_rel.DocIdParent, tdoc_biblio.CiteHtmlFull from tdoc_biblio left join tdoc_biblio_rel ON tdoc_biblio.docid = tdoc_biblio_rel.docid  	where   tdoc_biblio_rel.DocIdParent=" + docId_Parent.ToString() + " order by tdoc_biblio.CiteAutorYearABC";
            MySqlCommand oSqlCmd = new MySqlCommand(szSql, cls.bbdd.ClsMysql.MySqlConnection);
            MySqlDataReader oDR = oSqlCmd.ExecuteReader();
            szHtml += "\n<ul class =\"ulbiliograpy\">";
            while (oDR.HasRows && oDR.Read())
            {
                szHtml += "\n<li>" + oDR[1].ToString() + "</li>";
            }
            szHtml += "\n</ul>";
            oDR.Close();
            oDR.Dispose();
            ClsMysql.FncClose();

            return szHtml;

        }
        public void FncSetDefaultBibliographyTaxa(UInt64 pDOcId_Parent)
        {
            cls.bbdd.ClsReg_tdoc_biblio oNew = new ClsReg_tdoc_biblio();
            oNew.DocId =0;
            oRegBiblioRel.DocIdParent = pDOcId_Parent;

            //oNew.DocId_Parent = pDOcId_Parent;
            oNew.PublicationReaded=cls.ClsUtils.FncDateToAAAA_MM_DD(DateTime.Now);
            /*
              (Uetz, P.) Aut.: Peter Uetz, Jakob Hallermann, Jiri Hosek. Tit.: The Reptile Database. Pub.:. web. www.reptile-database.org.; 2015-03-14.   14/03/2015. 
            Links: http://www.c/
                http://reptile-database.reptarium.cz/
            */
            oNew.DocId = 0;
            oNew.Title="The Reptile Database";
            oNew.CiteAutorYearABC="Uetz, P.";
            oNew.Authors = ": Peter Uetz, Jakob Hallermann, Jiri Hosek. ";
            oNew.PublicationName = "The Reptile Database";
            oNew.PublicationType ="web";
            oNew.PublicationDatePage="";
            oNew.PublicationNotes="";
            oNew.URPublication=FncHtmBldLink("http://www.reptile-database.org");
            oNew.URPublication+="<br/>"+FncHtmBldLink("http://reptile-database.reptarium.cz");
            oNew.URLocalDownload="";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId =oNew.DocId;
            oRegBiblioRel.FncSqlSave ();
            /*
             http://www.itis.gov/
Retrieved [month, day, year], from the Integrated Taxonomic Information System on-line database, http://www.itis.gov.
            
             */
            oNew.CiteAutorYearABC = "ITIS";
            oNew.DocId = 0;
            oNew.Title="Integrated Taxonomic Information System database";
            oNew.Authors = "U.S., Canadian, and Mexican agencies (ITIS-North America); other organizations; and taxonomic specialists";
            oNew.PublicationName = "www.itis.gov";
            oNew.PublicationType ="web";
            oNew.PublicationDatePage="";
            oNew.PublicationNotes="Welcome to ITIS, the Integrated Taxonomic Information System! Here you will find authoritative taxonomic information on plants, animals, fungi, and microbes of North America and the world. We are a partnership of U.S., Canadian, and Mexican agencies (ITIS-North America); other organizations; and taxonomic specialists. ITIS is also a partner of Species 2000 and the Global Biodiversity Information Facility (GBIF). The ITIS and Species 2000 Catalogue of Life (CoL) partnership is proud to provide the taxonomic backbone to the Encyclopedia of Life (EOL).";
            oNew.URPublication=FncHtmBldLink(" http://www.itis.gov/");
            oNew.URLocalDownload="";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
            
            oNew.CiteAutorYearABC = "IUCN Red List";
            oNew.DocId = 0;
            oNew.Title="Tortoise & Freshwater Turtle Specialist Group 1996. Testudo graeca. The IUCN Red List of Threatened Species";
            oNew.Authors = "U.S., Canadian, and Mexican agencies (ITIS-North America); other organizations; and taxonomic specialists";
            oNew.PublicationName = "www.iucnredlist.org";
            oNew.PublicationType ="web";
            oNew.PublicationDatePage="Version 2014.3";
            oNew.PublicationNotes="W";
            oNew.URPublication=FncHtmBldLink(" http://www.iucnredlist.org/");
            oNew.URLocalDownload="";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 
            oNew.CiteAutorYearABC = "CITES 1999";
            oNew.DocId = 0;
            oNew.Title = "CITES Identification Guide - Turtles and Tortoises Version 2014.3";
            oNew.Authors = "[va n Dijk, P.P., Iverson, J.B.,Rhodin, A.G.J., Shaff er, H.B., and Bour, R.]. 2014";
            oNew.PublicationName = "Wildlife Division Office of Enforcement Environment Canada Ottawa, Ontario Canada K1A 0H3 ";
            oNew.PublicationType = "pdf";
            oNew.PublicationDatePage = "ISBN 0-662-64169-8 ";
            oNew.PublicationNotes = "";
            oNew.URPublication = FncHtmBldLink(" https://www.ec.gc.ca/Publications/0B562840-A798-4C3E-896B-CD1C6477937D%5CCITESIdentificationGuideTurtlesAndTortoises.pdf");
            oNew.URPublication += "<br>" + FncHtmBldLink("https://cites.unia.es/cites/file.php/1/files/CAN-CITES_Turtle_Guide.pdf");
            oNew.URLocalDownload = "";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 

            oNew.CiteAutorYearABC = "TTFWG 2014";
            oNew.DocId = 0;
            oNew.Title = "Turtles of the World, 7th Edition: Annotated Checklist of Taxonomy, Synonymy, Distribution with Maps, and Conservation Status. 2014";
            oNew.Authors = "An initiative of Environment Canada and PROFEPA (SEMARNAP)";
            oNew.PublicationName = "crm.5.000.checklist.v7.2014 ";
            oNew.PublicationType = "pdf";
            oNew.PublicationDatePage = "ISBN 0-662-64169-8 ";
            oNew.URPublication = FncHtmBldLink("http://www.iucn-tftsg.org/checklist/");
            oNew.URLocalDownload = "";
            oNew.PublicationNotes = "http://www.iucn-tftsg.org/wp-content/uploads/file/Accounts/crm_5_000_checklist_v7_2014.pdf Turtle Taxonomy Working Group [va n Dijk, P.P., Iverson, J.B.,Rhodin, A.G.J., Shaff er, H.B., and Bour, R.]. 2014. Turtles of the world, 7th edition: annotated checklist of taxonomy, synonymy,distribution with maps, and conservation status.  In: Rhodin, A.G.J., Pritchard, P.C.H., van Dijk, P.P., Saumure, R.A., Buhlmann, K.A., Iverson, J.B., and Mittermeier, R.A. (Eds.). Conservation Biology of Freshwater Turtles and Tortoises: A Compilation Project of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group. Chelonian Research Monographs 5(7):000.329–479, doi:10.3854/ crm.5.000.checklist.v7.2014.";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 
            oNew.CiteAutorYearABC = "Kottek, et al. (koeppen-geiger) 2006";
            oNew.DocId = 0;
            oNew.Title = "World Map of the Köppen-Geiger climate classification updated.";
            oNew.Authors = "Kottek, M., J. Grieser, C. Beck, B. Rudolf, and F. Rubel:";
            oNew.PublicationName = "Gland, Switzerland : IUCN--the World Conservation Union, c1989. ";
            oNew.PublicationType = "pdf";
            oNew.PublicationDatePage = "ISBN 0-662-64169-8 ";
            oNew.URPublication = FncHtmBldLink("http://koeppen-geiger.vu-wien.ac.at/");
            oNew.URLocalDownload = "";
            oNew.PublicationNotes = "Kottek, M., J. Grieser, C. Beck, B. Rudolf, and F. Rubel, 2006: World Map of the Köppen-Geiger climate classification updated. Meteorol. Z., 15, 259-263. DOI: 10.1127/0941-2948/2006/0130.";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 
            /*
             Klemens, Michael W & Swingland, Ian R. (Ian Richard), 1946- & IUCN/SSC Tortoise and Freshwater * Turtle Specialist Group & Swingland, Ian R & Durrell Institute of Conservation and Ecology et al. (1989). The Conservation biology of tortoises. IUCN--the World Conservation Union, Gland, Switzerland
             
             */
            oNew.CiteAutorYearABC = "K Klemens, Michael W & Swingland, Ian R. (Ian Richard), 1946";
            oNew.DocId = 0;
            oNew.Title = "The Conservation biology of tortoises /? edited by Ian R. Swingland and Michael W. Klemens.";
            oNew.Authors = "Klemens, Michael W. Swingland, Ian R. (Ian Richard) - IUCN/?SSC Tortoise and Freshwater Turtle Specialist Group. Durrell Institute of Conservation and Ecology.International Union for Conservation of Nature and Natural Resources.";
            oNew.PublicationName = "Gland, Switzerland : IUCN--the World Conservation Union, c1989.";
            oNew.PublicationType = "pdf";
            oNew.PublicationDatePage = "ISBN 2880329868";
            oNew.URPublication = FncHtmBldLink("http://trove.nla.gov.au/work/9709558?q&versionId=20938815");
            oNew.URLocalDownload = "";
            oNew.PublicationNotes = "";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 
            /*
            Identification manual for the conservation of turtles in china
Encyclopedia of China Publishing House
https://cites.unia.es/cites/file.php/1/files/Identification_manual_conservation_turtles-china1.pdf
Identification Manual for the Conservation of Turtles in China(Link)
Encyclopedia of China Publishing House
September 2013
             
             */
            oNew.CiteAutorYearABC = "Hai-Tao Shi et al 2013";
            oNew.DocId = 0;
            oNew.Title = "Identification manual for the conservation of turtles in china";
            oNew.Authors = "Mian Hou, Peter Pritchard, Michael Lau, Ji-Chao Wang, Yu-Xiang Liu,Frederick Yeh, Jian-Jun Peng, Zhi-Yong Fan, Feng Yin, Tien-Hsi Chen, Peter Paul van Dijk, James Parham, Jonathan Fong, Brian Horne, Henk Zwartepoorte, Chuck Schaffer, John Tucker, Bernard Devaux, Antoine Cadi, Shi-Ping Gong, Kwok Shing Lee";
            oNew.PublicationName = "Encyclopedia of China Publishing House.";
            oNew.PublicationType = "pdf";
            oNew.PublicationDatePage = "2013";
            oNew.URPublication = FncHtmBldLink("https://cites.unia.es/cites/file.php/1/files/Identification_manual_conservation_turtles-china1.pdf");
            oNew.URLocalDownload = "";
            oNew.PublicationNotes = "";
            oNew.FncSqlSave();
            oRegBiblioRel.DocId = oNew.DocId;
            oRegBiblioRel.FncSqlSave();
 



        }
        private string FncHtmBldLink(string pUrl)
        {
            return ("<a href=\"" + pUrl + "\">" + pUrl + "</a>");


        }
        public UInt64 FncCountParents()
        {
          
            _mErrorBoolean = false;
            _mErrorString = "";
            UInt64 iCount = 0;
            bool b = false;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return 0;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------

            oSqlCmdCountParents.Connection = ClsMysql.MySqlConnection;;
            try
            {
                oSqlCmdCountParents.Parameters["@DocId"].Value = m_DocId.ToString ();
                iCount = Convert.ToUInt64(oSqlCmdCountParents.ExecuteScalar());
            }
            catch (Exception xcpt)
            {
                _mErrorBoolean = true;
                _mErrorString = xcpt.ToString();
                ;
            }

            ClsMysql.FncClose();
            return iCount;
 
        }

        public UInt64 FncSqlExistCiteAutorYearABC(String pCiteAutorYearABC)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            UInt64 DocId = 0;
            bool b = false;
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return 0;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------

            oSqlCmdSelectExistCiteAutorYearABC.Connection = ClsMysql.MySqlConnection;;
            try
            {
                oSqlCmdSelectExistCiteAutorYearABC.Parameters["@CiteAutorYearABC"].Value = pCiteAutorYearABC;
                DocId = Convert.ToUInt64(oSqlCmdSelectExistCiteAutorYearABC.ExecuteScalar());
            }
            catch (Exception xcpt)
            {
                _mErrorBoolean = true;
                _mErrorString = xcpt.ToString();
                ;
            }

            ClsMysql.FncClose();
            return DocId;
        }

        private void FncFieldCalcCiteHtmlToolTip()
        {

            m_CiteHtmlToolTip = "";
            //"<a href="#" data-toggle="tooltip" title="Some tooltip text!">Hover over me</a>"
         //   string szTemplate = "<a href=\"#\" data-toggle=\"tooltip\" title=\"#szToolTip#\">#szCite#</a>";
            string szToolTip = "";
            string szCite = m_CiteAutorYearABC.Replace(" ", "_").Replace(",", "_");


            // para tooltip
           
            if (m_Authors != "") { szToolTip += " Aut. " + m_Authors + "."; }
            if (m_Title != "") { szToolTip += " Tit. " + m_Title + "."; }
            if (m_PublicationType != "") { szToolTip += " Published: " + m_PublicationType + "."; }
            if (m_PublicationName != "") { szToolTip += " " + m_PublicationName + "."; }
            if (m_PublicationDatePage != "") { szToolTip += " " + m_PublicationDatePage + "."; }

            m_CiteHtmlToolTip= "<a href=\"#\" data-toggle=\"tooltip\" title=\""+ szToolTip+"\">"+ szCite+"</a>";

            // para base de datos
            m_CiteHtmlFull = "<a name=\"" + szCite + "\">(" + m_CiteAutorYearABC + ")</a> ";
            if (m_Authors != "") { m_CiteHtmlFull += " Aut.: " + m_Authors + "."; }
            if (m_Title != "") { m_CiteHtmlFull += ". Tit.: " + m_Title + "."; }
            if (m_PublicationType != "") { m_CiteHtmlFull += ". Pub.: " + m_PublicationType + "."; }
            if (m_PublicationName != "") { m_CiteHtmlFull += " " + m_PublicationName + "."; }
            if (m_PublicationDatePage != "") { m_CiteHtmlFull += "; " + m_PublicationDatePage + ". "; }
            if (m_PublicationReaded != null) { m_CiteHtmlFull += " <img src=\"/a_img/a_site/ico16/ico-readed.png\"/> " + m_PublicationReaded + ". "; }
            if (m_URPublication != "") { m_CiteHtmlFull += "<br/> Links: " + m_URPublication; }


        }
        private void FncFieldCalcCiteHtmlToolTip_NoUSO()
        {
            m_CiteHtmlToolTip = "";
            string szLink = m_CiteAutorYearABC.Replace(" ", "_").Replace(",", "_");
        



            m_CiteHtmlFull = "<a name=\"" + szLink + "\">(" + m_CiteAutorYearABC + ")</a> ";
            if (m_Authors != "") { m_CiteHtmlFull += " Aut.: " + m_Authors + "."; }
            if (m_Title != "") { m_CiteHtmlFull += ". Tit.: " + m_Title + "."; }
            if (m_PublicationType != "") { m_CiteHtmlFull += ". Pub.: " + m_PublicationType + "."; }
            if (m_PublicationName != "") { m_CiteHtmlFull += " " + m_PublicationName + "."; }
            if (m_PublicationDatePage != "") { m_CiteHtmlFull += "; " + m_PublicationDatePage + ". "; }
            if (m_PublicationReaded != null) { m_CiteHtmlFull += " <img src=\"/a_img/a_site/ico16/ico-readed.png\"/> " + m_PublicationReaded + ". "; }
            if (m_URPublication != "") { m_CiteHtmlFull += "<br/> Links: " + m_URPublication; }



            string szaTitle = "";
            if (m_Authors != "") { szaTitle += " Aut. " + m_Authors + "."; }
            if (m_Title != "") { szaTitle += " Tit. " + m_Title + "."; }
            if (m_PublicationType != "") { szaTitle += " Published: " + m_PublicationType + "."; }
            if (m_PublicationName != "") { szaTitle += " " + m_PublicationName + "."; }
            if (m_PublicationDatePage != "") { szaTitle += " " + m_PublicationDatePage + "."; }
            m_CiteHtmlToolTip = "<a data-tooltip aria-haspopup=\"true\" class=\"has-tip\"  href=\"#" + szLink + "\" title=\"" + szaTitle + "\"><b>(" + m_CiteAutorYearABC + ")</b></a> ";


        }

       /// <summary>
       /// Devuelve lista simple de bibliografia, <ul></ul> con disstinct
       /// </summary>
       /// <param name="docLng"></param>
       /// <param name="bRebuild"></param>
       /// <returns></returns>
        public string FncGetCache_List_Html(String docLng, bool bRebuild)
        {

            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, docLng, "bibbliography-list");

            if (cls.ClsGlobal.CacheRebuid || bRebuild) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncHtmlBldCache_List(docLng);

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
                return szHtml;
            }

        }
        /// <summary>
        /// Utiliza Server.HtmlDecode(string) para asignarlo a un label
        /// </summary>
        /// <returns></returns>
        private string FncHtmlBldCache_List(string docLng)

        {
            FncCulture_Set(docLng);
        
        DataTable oTb=new DataTable ();
        String szSqlCmd = "select  DISTINCT  CiteAutorYearABC,concat ('<b>', CiteAutorYearABC,'.</b> ', Title)  as cite from tdoc_biblio order by CiteAutorYearABC,Title ";
        cls.bbdd.ClsMysql.FncFill_datatable(ref szSqlCmd, ref oTb);
        string szHtml = "<h2>"+ Resources.Strings.bibliography1+"</h2><ul>";
        foreach (DataRow oRow in oTb.Rows)
        {
            szHtml += "<li>" + oRow[1].ToString()+"</li>";
        }
        szHtml += "</ul>";
        return szHtml;

        }

        private void FncCulture_Set(String pCulture)
        {
            String szCulture = "";
            if (pCulture.Length < 2) { pCulture = cls.ClsGlobal.LngIdThread; }

            if (pCulture.Length > 2) { szCulture = pCulture.Substring(0, 2).ToUpper(); }

            if (szCulture == "EN") { pCulture = "EN-us"; }
            else { pCulture = "ES-es"; }
            m_Culture_before = CultureInfo.CurrentCulture.Name;
            m_Culture_Called = pCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(pCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(pCulture);

        }
        private void FncCulture_restart()
        {


            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(m_Culture_before);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(m_Culture_before);

        }

    }
}