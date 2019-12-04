using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsReg_tdoclng_testudines_geog
    //<//summary>
    public class ClsReg_tdoclng_testudines_geog
    {
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
        //private string _mMySqlConnectionString = "";
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
        private String m_LGeoAbstract = "";
        private String m_LGeoPoliContinentNames = "";
        private string m_LGeoPoliCountriesNames = "";
        private String m_lGeoPoliLocationTypeName = "";
        private string m_LGeoPoliNotes = "";
        private String m_LGeoBioWWFRealmsNames = "";
        private String m_LGeoBioWWFRegionNames = "";
        private string m_LGeoBioWWFNotes = "";
        private String m_LGeoClimateKoppenGeigerName = "";
        private String m_LGeoClimateKoppenGeigerNotes = "";
        private String m_LGeoClimateTableLocation = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------
        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_geog()
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
            m_LGeoAbstract = "";
            m_LGeoPoliContinentNames = "";
            m_LGeoPoliCountriesNames = "";
            m_lGeoPoliLocationTypeName = "";
            m_LGeoPoliNotes = "";
            m_LGeoBioWWFRealmsNames = "";
            m_LGeoBioWWFRegionNames = "";
            m_LGeoBioWWFNotes = "";
            m_LGeoClimateKoppenGeigerName = "";
            m_LGeoClimateKoppenGeigerNotes = "";
            m_LGeoClimateTableLocation = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_geog  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_geog";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", LGeoAbstract ";
            szSql += ", LGeoPoliContinentNames ";
            szSql += ", LGeoPoliCountriesNames ";
            szSql += ", lGeoPoliLocationTypeName ";
            szSql += ", LGeoPoliNotes ";
            szSql += ", LGeoBioWWFRealmsNames ";
            szSql += ", LGeoBioWWFRegionNames ";
            szSql += ", LGeoBioWWFNotes ";
            szSql += ", LGeoClimateKoppenGeigerName ";
            szSql += ", LGeoClimateKoppenGeigerNotes ";
            szSql += ", LGeoClimateTableLocation ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @LGeoAbstract ";
            szSql += ", @LGeoPoliContinentNames ";
            szSql += ", @LGeoPoliCountriesNames ";
            szSql += ", @lGeoPoliLocationTypeName ";
            szSql += ", @LGeoPoliNotes ";
            szSql += ", @LGeoBioWWFRealmsNames ";
            szSql += ", @LGeoBioWWFRegionNames ";
            szSql += ", @LGeoBioWWFNotes ";
            szSql += ", @LGeoClimateKoppenGeigerName ";
            szSql += ", @LGeoClimateKoppenGeigerNotes ";
            szSql += ", @LGeoClimateTableLocation ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoAbstract", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoPoliContinentNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoPoliCountriesNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@lGeoPoliLocationTypeName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoPoliNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LGeoBioWWFRealmsNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoBioWWFRegionNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoBioWWFNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LGeoClimateKoppenGeigerName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LGeoClimateKoppenGeigerNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LGeoClimateTableLocation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_geog SET ";

            szSql += "LGeoAbstract=@LGeoAbstract ";
            szSql += ", LGeoPoliContinentNames=@LGeoPoliContinentNames ";
            szSql += ", LGeoPoliCountriesNames=@LGeoPoliCountriesNames ";
            szSql += ", lGeoPoliLocationTypeName=@lGeoPoliLocationTypeName ";
            szSql += ", LGeoPoliNotes=@LGeoPoliNotes ";
            szSql += ", LGeoBioWWFRealmsNames=@LGeoBioWWFRealmsNames ";
            szSql += ", LGeoBioWWFRegionNames=@LGeoBioWWFRegionNames ";
            szSql += ", LGeoBioWWFNotes=@LGeoBioWWFNotes ";
            szSql += ", LGeoClimateKoppenGeigerName=@LGeoClimateKoppenGeigerName ";
            szSql += ", LGeoClimateKoppenGeigerNotes=@LGeoClimateKoppenGeigerNotes ";
            szSql += ", LGeoClimateTableLocation=@LGeoClimateTableLocation ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoAbstract", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoPoliContinentNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoPoliCountriesNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@lGeoPoliLocationTypeName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoPoliNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LGeoBioWWFRealmsNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoBioWWFRegionNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoBioWWFNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LGeoClimateKoppenGeigerName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LGeoClimateKoppenGeigerNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LGeoClimateTableLocation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_geog  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", DocLngId";
            szSql += " FROM tdoclng_testudines_geog  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
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
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;

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
            oSqlCmdUpdate.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdUpdate.Parameters["@LGeoAbstract"].Value = m_LGeoAbstract;
            oSqlCmdUpdate.Parameters["@LGeoPoliContinentNames"].Value = m_LGeoPoliContinentNames;
            oSqlCmdUpdate.Parameters["@LGeoPoliCountriesNames"].Value = m_LGeoPoliCountriesNames;
            oSqlCmdUpdate.Parameters["@lGeoPoliLocationTypeName"].Value = m_lGeoPoliLocationTypeName;
            oSqlCmdUpdate.Parameters["@LGeoPoliNotes"].Value = m_LGeoPoliNotes;
            oSqlCmdUpdate.Parameters["@LGeoBioWWFRealmsNames"].Value = m_LGeoBioWWFRealmsNames;
            oSqlCmdUpdate.Parameters["@LGeoBioWWFRegionNames"].Value = m_LGeoBioWWFRegionNames;
            oSqlCmdUpdate.Parameters["@LGeoBioWWFNotes"].Value = m_LGeoBioWWFNotes;
            oSqlCmdUpdate.Parameters["@LGeoClimateKoppenGeigerName"].Value = m_LGeoClimateKoppenGeigerName;
            oSqlCmdUpdate.Parameters["@LGeoClimateKoppenGeigerNotes"].Value = m_LGeoClimateKoppenGeigerNotes;
            oSqlCmdUpdate.Parameters["@LGeoClimateTableLocation"].Value = m_LGeoClimateTableLocation;
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
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@LGeoAbstract"].Value = m_LGeoAbstract;
            oSqlCmdInsert.Parameters["@LGeoPoliContinentNames"].Value = m_LGeoPoliContinentNames;
            oSqlCmdInsert.Parameters["@LGeoPoliCountriesNames"].Value = m_LGeoPoliCountriesNames;
            oSqlCmdInsert.Parameters["@lGeoPoliLocationTypeName"].Value = m_lGeoPoliLocationTypeName;
            oSqlCmdInsert.Parameters["@LGeoPoliNotes"].Value = m_LGeoPoliNotes;
            oSqlCmdInsert.Parameters["@LGeoBioWWFRealmsNames"].Value = m_LGeoBioWWFRealmsNames;
            oSqlCmdInsert.Parameters["@LGeoBioWWFRegionNames"].Value = m_LGeoBioWWFRegionNames;
            oSqlCmdInsert.Parameters["@LGeoBioWWFNotes"].Value = m_LGeoBioWWFNotes;
            oSqlCmdInsert.Parameters["@LGeoClimateKoppenGeigerName"].Value = m_LGeoClimateKoppenGeigerName;
            oSqlCmdInsert.Parameters["@LGeoClimateKoppenGeigerNotes"].Value = m_LGeoClimateKoppenGeigerNotes;
            oSqlCmdInsert.Parameters["@LGeoClimateTableLocation"].Value = m_LGeoClimateTableLocation;
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
        public bool FncSqlFind(UInt64 DocId, String DocLngId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            if (!ClsMysql.FncOpen("")) { return false; }
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
            oSqlCmdSelect.Parameters["@DocLngId"].Value = DocLngId;
            //----------------------------------------------------
            MySqlDataReader oDR=null; //Para recoger el resultado de la búsqueda.
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
                    m_DocLngId = oDR["DocLngId"].ToString();
                    m_LGeoAbstract = oDR["LGeoAbstract"].ToString();
                    m_LGeoPoliContinentNames = oDR["LGeoPoliContinentNames"].ToString();
                    m_LGeoPoliCountriesNames = oDR["LGeoPoliCountriesNames"].ToString();
                    m_lGeoPoliLocationTypeName = oDR["lGeoPoliLocationTypeName"].ToString();
                    m_LGeoPoliNotes = oDR["LGeoPoliNotes"].ToString();
                    m_LGeoBioWWFRealmsNames = oDR["LGeoBioWWFRealmsNames"].ToString();
                    m_LGeoBioWWFRegionNames = oDR["LGeoBioWWFRegionNames"].ToString();
                    m_LGeoBioWWFNotes = oDR["LGeoBioWWFNotes"].ToString();
                    m_LGeoClimateKoppenGeigerName = oDR["LGeoClimateKoppenGeigerName"].ToString();
                    m_LGeoClimateKoppenGeigerNotes = oDR["LGeoClimateKoppenGeigerNotes"].ToString();
                    m_LGeoClimateTableLocation = oDR["LGeoClimateTableLocation"].ToString();
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
            finally { if (oDR != null) oDR.Close(); }
            //------------------------------------------------------
            // cierre.
            //-------------------------------------------------------
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
            if (!ClsMysql.FncOpen("")) { return false; }
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

        public String DocLngId
        {
            set
            {
                m_DocLngId = value;
            }
            get { return m_DocLngId; }
        }

        //................................

        public String LGeoAbstract
        {
            set
            {
                m_LGeoAbstract = value;
            }
            get { return m_LGeoAbstract; }
        }

        //................................

        public String LGeoPoliContinentNames
        {
            set
            {
                m_LGeoPoliContinentNames = value;
            }
            get { return m_LGeoPoliContinentNames; }
        }

        //................................

        public string LGeoPoliCountriesNames
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LGeoPoliCountriesNames because it is too long,MaxLength=65535";
                }
                m_LGeoPoliCountriesNames = sz;
            }
            get { return m_LGeoPoliCountriesNames; }
        }

        //................................

        public String lGeoPoliLocationTypeName
        {
            set
            {
                m_lGeoPoliLocationTypeName = value;
            }
            get { return m_lGeoPoliLocationTypeName; }
        }

        //................................

        public string LGeoPoliNotes
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LGeoPoliNotes because it is too long,MaxLength=65535";
                }
                m_LGeoPoliNotes = sz;
            }
            get { return m_LGeoPoliNotes; }
        }

        //................................

        public String LGeoBioWWFRealmsNames
        {
            set
            {
                m_LGeoBioWWFRealmsNames = value;
            }
            get { return m_LGeoBioWWFRealmsNames; }
        }

        //................................

        public String LGeoBioWWFRegionNames
        {
            set
            {
                m_LGeoBioWWFRegionNames = value;
            }
            get { return m_LGeoBioWWFRegionNames; }
        }

        //................................

        public string LGeoBioWWFNotes
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LGeoBioWWFNotes because it is too long,MaxLength=65535";
                }
                m_LGeoBioWWFNotes = sz;
            }
            get { return m_LGeoBioWWFNotes; }
        }

        //................................

        public String LGeoClimateKoppenGeigerName
        {
            set
            {
                m_LGeoClimateKoppenGeigerName = value;
            }
            get { return m_LGeoClimateKoppenGeigerName; }
        }

        //................................

        public String LGeoClimateKoppenGeigerNotes
        {
            set
            {
                m_LGeoClimateKoppenGeigerNotes = value;
            }
            get { return m_LGeoClimateKoppenGeigerNotes; }
        }

        //................................

        public String LGeoClimateTableLocation
        {
            set
            {
                m_LGeoClimateTableLocation = value;
            }
            get { return m_LGeoClimateTableLocation; }
        }

        #endregion VALORES_GETSET

    }
}