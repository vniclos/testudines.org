using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tstd_vistitlog
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
        private UInt64 m_Id = 0;
        private String m_DocClass = "";
        private UInt64 m_stdDocId = 0;
        private String m_stdDocLngId = "";
        private String m_stdDocSection = "";
        private String m_stdSession = "";
        private DateTime m_stdDate = DateTime.Now;
        private Int32 m_stdYear = 0;
        private Int32 m_stdMonth = 0;
        private Int32 m_stdDay = 0;
        private Int32 m_stdHour = 0;
        private String m_stdCountryIP = "";
        private String m_stdUser = "";
        private String m_stdIPFrom = "";
        private String m_stdReferer = "";
        private String m_stdUserAgent = "";
        private String m_stdUrl = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tstd_vistitlog(string szSqlConnectionString)
        //{
        public ClsReg_tstd_vistitlog()
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
            m_Id = 0;
            m_DocClass = "";
            m_stdDocId = 0;
            m_stdDocLngId = "";
            m_stdDocSection = "";
            m_stdSession = "";
            m_stdDate = DateTime.Now;
            m_stdYear = 0;
            m_stdMonth = 0;
            m_stdDay = 0;
            m_stdHour = 0;
            m_stdCountryIP = "";
            m_stdUser = "";
            m_stdIPFrom = "";
            m_stdReferer = "";
            m_stdUserAgent = "";
            m_stdUrl = "";
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
            szSql = "SELECT * FROM tstd_vistitlog  ";
            szSql += " WHERE ";
            szSql += "(Id=@Id )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tstd_vistitlog";

            szSql += "(";

            //szSql += " Id ";
            szSql += " DocClass ";
            szSql += ", stdDocId ";
            szSql += ", stdDocLngId ";
            szSql += ", stdDocSection ";
            szSql += ", stdSession ";
            szSql += ", stdDate ";
            szSql += ", stdYear ";
            szSql += ", stdMonth ";
            szSql += ", stdDay ";
            szSql += ", stdHour ";
            szSql += ", stdCountryIP ";
            szSql += ", stdUser ";
            szSql += ", stdIPFrom ";
            szSql += ", stdReferer ";
            szSql += ", stdUserAgent ";
            szSql += ", stdUrl ";
            szSql += " ) VALUES     (";
           // szSql += " @Id ";
            szSql += " @DocClass ";
            szSql += ", @stdDocId ";
            szSql += ", @stdDocLngId ";
            szSql += ", @stdDocSection ";
            szSql += ", @stdSession ";
            szSql += ", @stdDate ";
            szSql += ", @stdYear ";
            szSql += ", @stdMonth ";
            szSql += ", @stdDay ";
            szSql += ", @stdHour ";
            szSql += ", @stdCountryIP ";
            szSql += ", @stdUser ";
            szSql += ", @stdIPFrom ";
            szSql += ", @stdReferer ";
            szSql += ", @stdUserAgent ";
            szSql += ", @stdUrl ";
            szSql += ")";
            szSql += " ; SELECT LAST_INSERT_ID()";
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocClass", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdDocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@stdDocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdDocSection", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdSession", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdDate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@stdYear", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@stdMonth", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@stdDay", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@stdHour", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@stdCountryIP", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdUser", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdIPFrom", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdReferer", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdUserAgent", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@stdUrl", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tstd_vistitlog SET ";

            szSql += "DocClass=@DocClass ";
            szSql += ", stdDocId=@stdDocId ";
            szSql += ", stdDocLngId=@stdDocLngId ";
            szSql += ", stdDocSection=@stdDocSection ";
            szSql += ", stdSession=@stdSession ";
            szSql += ", stdDate=@stdDate ";
            szSql += ", stdYear=@stdYear ";
            szSql += ", stdMonth=@stdMonth ";
            szSql += ", stdDay=@stdDay ";
            szSql += ", stdHour=@stdHour ";
            szSql += ", stdCountryIP=@stdCountryIP ";
            szSql += ", stdUser=@stdUser ";
            szSql += ", stdIPFrom=@stdIPFrom ";
            szSql += ", stdReferer=@stdReferer ";
            szSql += ", stdUserAgent=@stdUserAgent ";
            szSql += ", stdUrl=@stdUrl ";
            szSql += " WHERE ";
            szSql += "(Id=@Id )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocClass", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdDocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@stdDocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdDocSection", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdSession", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdDate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@stdYear", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@stdMonth", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@stdDay", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@stdHour", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@stdCountryIP", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdUser", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdIPFrom", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdReferer", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdUserAgent", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@stdUrl", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tstd_vistitlog  ";
            szSql += " WHERE ";
            szSql += "(Id=@Id )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " Id";
            szSql += " FROM tstd_vistitlog  ";

            szSql += " WHERE ";
            szSql += "(Id=@Id )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
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
               if (m_Id == 0)
               {
                   b = false;
               }
               else
               {
            //............................................................
            //............................................................

            // comprobar si existe el id a añadir

            // TODO Atencion en caso de claves alternavas

            // Atencion en caso de claves alternativas

            // añadir una fucion que la controle

            oSqlCmdSelectExist.Parameters["@Id"].Value = m_Id;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            //.............................................................
            //........ EL BLOQUE DE CLAVES AUTONUMERICA ACABA AQUI ........
            } 
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
            oSqlCmdUpdate.Parameters["@Id"].Value = m_Id;
            oSqlCmdUpdate.Parameters["@DocClass"].Value = m_DocClass;
            oSqlCmdUpdate.Parameters["@stdDocId"].Value = m_stdDocId;
            oSqlCmdUpdate.Parameters["@stdDocLngId"].Value = m_stdDocLngId;
            oSqlCmdUpdate.Parameters["@stdDocSection"].Value = m_stdDocSection;
            oSqlCmdUpdate.Parameters["@stdSession"].Value = m_stdSession;
            oSqlCmdUpdate.Parameters["@stdDate"].Value = m_stdDate;
            oSqlCmdUpdate.Parameters["@stdYear"].Value = m_stdYear;
            oSqlCmdUpdate.Parameters["@stdMonth"].Value = m_stdMonth;
            oSqlCmdUpdate.Parameters["@stdDay"].Value = m_stdDay;
            oSqlCmdUpdate.Parameters["@stdHour"].Value = m_stdHour;
            oSqlCmdUpdate.Parameters["@stdCountryIP"].Value = m_stdCountryIP;
            oSqlCmdUpdate.Parameters["@stdUser"].Value = m_stdUser;
            oSqlCmdUpdate.Parameters["@stdIPFrom"].Value = m_stdIPFrom;
            oSqlCmdUpdate.Parameters["@stdReferer"].Value = m_stdReferer;
            oSqlCmdUpdate.Parameters["@stdUserAgent"].Value = m_stdUserAgent;
            oSqlCmdUpdate.Parameters["@stdUrl"].Value = m_stdUrl;
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
            //oSqlCmdInsert.Parameters["@Id"].Value = m_Id;
            oSqlCmdInsert.Parameters["@DocClass"].Value = m_DocClass;
            oSqlCmdInsert.Parameters["@stdDocId"].Value = m_stdDocId;
            oSqlCmdInsert.Parameters["@stdDocLngId"].Value = m_stdDocLngId;
            oSqlCmdInsert.Parameters["@stdDocSection"].Value = m_stdDocSection;
            oSqlCmdInsert.Parameters["@stdSession"].Value = m_stdSession;
            oSqlCmdInsert.Parameters["@stdDate"].Value = m_stdDate;
            oSqlCmdInsert.Parameters["@stdYear"].Value = m_stdYear;
            oSqlCmdInsert.Parameters["@stdMonth"].Value = m_stdMonth;
            oSqlCmdInsert.Parameters["@stdDay"].Value = m_stdDay;
            oSqlCmdInsert.Parameters["@stdHour"].Value = m_stdHour;
            oSqlCmdInsert.Parameters["@stdCountryIP"].Value = m_stdCountryIP;
            oSqlCmdInsert.Parameters["@stdUser"].Value = m_stdUser;
            oSqlCmdInsert.Parameters["@stdIPFrom"].Value = m_stdIPFrom;
            oSqlCmdInsert.Parameters["@stdReferer"].Value = m_stdReferer;
            oSqlCmdInsert.Parameters["@stdUserAgent"].Value = m_stdUserAgent;
            oSqlCmdInsert.Parameters["@stdUrl"].Value = m_stdUrl;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;;

                m_Id = Convert.ToUInt64(oSqlCmdInsert.ExecuteNonQuery());
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
        public bool FncSqlFind(Int32 Id)
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
            oSqlCmdSelect.Parameters["@Id"].Value = Id;
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
                    m_Id = Convert.ToUInt64(oDR["Id"].ToString().Trim());
                    m_DocClass = oDR["DocClass"].ToString().Trim();
                    m_stdDocId = Convert.ToUInt64(oDR["stdDocId"].ToString().Trim());
                    m_stdDocLngId = oDR["stdDocLngId"].ToString().Trim();
                    m_stdDocSection = oDR["stdDocSection"].ToString().Trim();
                    m_stdSession = oDR["stdSession"].ToString().Trim();
                    m_stdDate = Convert.ToDateTime(oDR["stdDate"].ToString().Trim());
                    m_stdYear = Convert.ToInt32(oDR["stdYear"].ToString().Trim());
                    m_stdMonth = Convert.ToInt32(oDR["stdMonth"].ToString().Trim());
                    m_stdDay = Convert.ToInt32(oDR["stdDay"].ToString().Trim());
                    m_stdHour = Convert.ToInt32(oDR["stdHour"].ToString().Trim());
                    m_stdCountryIP = oDR["stdCountryIP"].ToString().Trim();
                    m_stdUser = oDR["stdUser"].ToString().Trim();
                    m_stdIPFrom = oDR["stdIPFrom"].ToString().Trim();
                    m_stdReferer = oDR["stdReferer"].ToString().Trim();
                    m_stdUserAgent = oDR["stdUserAgent"].ToString().Trim();
                    m_stdUrl = oDR["stdUrl"].ToString().Trim();
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
        public bool FncSqlDelete(UInt64 Id)
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
                oSqlCmdDelete.Parameters["@Id"].Value = Id;
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
        public bool FncSqlExist(UInt64 Id)
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
            oSqlCmdSelectExist.Parameters["@Id"].Value = Id;

            
            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;
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

        public UInt64 Id
        {
            set
            {
                m_Id = value;
            }
            get { return m_Id; }
        }

        //................................

        public String DocClass
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 25)
                {
                    sz = sz.Substring(0, 24);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocClass because is it too long,MaxLength=25";
                }
                m_DocClass = sz;

            }
            get { return m_DocClass; }
        }

        //................................

        public UInt64 stdDocId
        {
            set
            {
                m_stdDocId = value;
            }
            get { return m_stdDocId; }
        }

        //................................

        public String stdDocLngId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 3)
                {
                    sz = sz.Substring(0, 2);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdDocLngId because is it too long,MaxLength=3";
                }
                m_stdDocLngId = sz;

            }
            get { return m_stdDocLngId; }
        }

        //................................

        public String stdDocSection
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdDocSection because is it too long,MaxLength=250";
                }
                m_stdDocSection = sz;

            }
            get { return m_stdDocSection; }
        }

        //................................

        public String stdSession
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdSession because is it too long,MaxLength=50";
                }
                m_stdSession = sz;

            }
            get { return m_stdSession; }
        }

        //................................

        public DateTime stdDate
        {
            set
            {
                m_stdDate = value;
            }
            get { return m_stdDate; }
        }

        //................................

        public Int32 stdYear
        {
            set
            {
                m_stdYear = value;
            }
            get { return m_stdYear; }
        }

        //................................

        public Int32 stdMonth
        {
            set
            {
                m_stdMonth = value;
            }
            get { return m_stdMonth; }
        }

        //................................

        public Int32 stdDay
        {
            set
            {
                m_stdDay = value;
            }
            get { return m_stdDay; }
        }

        //................................

        public Int32 stdHour
        {
            set
            {
                m_stdHour = value;
            }
            get { return m_stdHour; }
        }

        //................................

        public String stdCountryIP
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 35)
                {
                    sz = sz.Substring(0, 34);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdCountryIP because is it too long,MaxLength=35";
                }
                m_stdCountryIP = sz;

            }
            get { return m_stdCountryIP; }
        }

        //................................

        public String stdUser
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdUser because is it too long,MaxLength=50";
                }
                m_stdUser = sz;

            }
            get { return m_stdUser; }
        }

        //................................

        public String stdIPFrom
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdIPFrom because is it too long,MaxLength=50";
                }
                m_stdIPFrom = sz;

            }
            get { return m_stdIPFrom; }
        }

        //................................

        public String stdReferer
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdReferer because is it too long,MaxLength=250";
                }
                m_stdReferer = sz;

            }
            get { return m_stdReferer; }
        }

        //................................

        public String stdUserAgent
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdUserAgent because is it too long,MaxLength=250";
                }
                m_stdUserAgent = sz;

            }
            get { return m_stdUserAgent; }
        }

        //................................

        public String stdUrl
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_stdUrl because is it too long,MaxLength=250";
                }
                m_stdUrl = sz;

            }
            get { return m_stdUrl; }
        }

        #endregion VALORES_GETSET

    }
}
