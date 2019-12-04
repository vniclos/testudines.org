using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsReg_tdoclng_testudines_natu_all
    //<//summary>
    public class ClsReg_tdoclng_testudines_natu_all
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
        private String m_ANatuKeyMedia = "";
        private String m_ANatDngLevelRedList = "";
        private String m_ANatDngLevelCites = "";
        private String m_ANatuKeyFood = "";
        private String m_ANatuKeyBreeding = "";
        private Double m_ANatIncubationTempMalesFrom = 0;
        private Double m_ANatuIncubationTempMalesTo = 0;
        private Double m_ANatuIncubationTempPivot = 0;
        private Double m_ANatuIncubationTempFemalesFrom = 0;
        private Double m_ANatuIncubationTempFemalesTo = 0;
        private Double m_ANatIncubationDaysMin = 0;
        private Double m_ANatIncubationDaysMax = 0;
        private Double m_ANatuIncubationHumidityFrom = 0;
        private Double m_ANatuIncubationHumidityTo = 0;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------
        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_natu_all()
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
            m_ANatuKeyMedia = "";
            m_ANatDngLevelRedList = "";
            m_ANatDngLevelCites = "";
            m_ANatuKeyFood = "";
            m_ANatuKeyBreeding = "";
            m_ANatIncubationTempMalesFrom = 0;
            m_ANatuIncubationTempMalesTo = 0;
            m_ANatuIncubationTempPivot = 0;
            m_ANatuIncubationTempFemalesFrom = 0;
            m_ANatuIncubationTempFemalesTo = 0;
            m_ANatIncubationDaysMin = 0;
            m_ANatIncubationDaysMax = 0;
            m_ANatuIncubationHumidityFrom = 0;
            m_ANatuIncubationHumidityTo = 0;
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
            szSql = "SELECT * FROM tdoclng_testudines_natu_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_natu_all";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", ANatuKeyMedia ";
            szSql += ", ANatDngLevelRedList ";
            szSql += ", ANatDngLevelCites ";
            szSql += ", ANatuKeyFood ";
            szSql += ", ANatuKeyBreeding ";
            szSql += ", ANatIncubationTempMalesFrom ";
            szSql += ", ANatuIncubationTempMalesTo ";
            szSql += ", ANatuIncubationTempPivot ";
            szSql += ", ANatuIncubationTempFemalesFrom ";
            szSql += ", ANatuIncubationTempFemalesTo ";
            szSql += ", ANatIncubationDaysMin ";
            szSql += ", ANatIncubationDaysMax ";
            szSql += ", ANatuIncubationHumidityFrom ";
            szSql += ", ANatuIncubationHumidityTo ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @ANatuKeyMedia ";
            szSql += ", @ANatDngLevelRedList ";
            szSql += ", @ANatDngLevelCites ";
            szSql += ", @ANatuKeyFood ";
            szSql += ", @ANatuKeyBreeding ";
            szSql += ", @ANatIncubationTempMalesFrom ";
            szSql += ", @ANatuIncubationTempMalesTo ";
            szSql += ", @ANatuIncubationTempPivot ";
            szSql += ", @ANatuIncubationTempFemalesFrom ";
            szSql += ", @ANatuIncubationTempFemalesTo ";
            szSql += ", @ANatIncubationDaysMin ";
            szSql += ", @ANatIncubationDaysMax ";
            szSql += ", @ANatuIncubationHumidityFrom ";
            szSql += ", @ANatuIncubationHumidityTo ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@ANatuKeyMedia", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ANatDngLevelRedList", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ANatDngLevelCites", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ANatuKeyFood", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ANatuKeyBreeding", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ANatIncubationTempMalesFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationTempMalesTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationTempPivot", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationTempFemalesFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationTempFemalesTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatIncubationDaysMin", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatIncubationDaysMax", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationHumidityFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@ANatuIncubationHumidityTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_natu_all SET ";

            szSql += "ANatuKeyMedia=@ANatuKeyMedia ";
            szSql += ", ANatDngLevelRedList=@ANatDngLevelRedList ";
            szSql += ", ANatDngLevelCites=@ANatDngLevelCites ";
            szSql += ", ANatuKeyFood=@ANatuKeyFood ";
            szSql += ", ANatuKeyBreeding=@ANatuKeyBreeding ";
            szSql += ", ANatIncubationTempMalesFrom=@ANatIncubationTempMalesFrom ";
            szSql += ", ANatuIncubationTempMalesTo=@ANatuIncubationTempMalesTo ";
            szSql += ", ANatuIncubationTempPivot=@ANatuIncubationTempPivot ";
            szSql += ", ANatuIncubationTempFemalesFrom=@ANatuIncubationTempFemalesFrom ";
            szSql += ", ANatuIncubationTempFemalesTo=@ANatuIncubationTempFemalesTo ";
            szSql += ", ANatIncubationDaysMin=@ANatIncubationDaysMin ";
            szSql += ", ANatIncubationDaysMax=@ANatIncubationDaysMax ";
            szSql += ", ANatuIncubationHumidityFrom=@ANatuIncubationHumidityFrom ";
            szSql += ", ANatuIncubationHumidityTo=@ANatuIncubationHumidityTo ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@ANatuKeyMedia", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ANatDngLevelRedList", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ANatDngLevelCites", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ANatuKeyFood", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ANatuKeyBreeding", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ANatIncubationTempMalesFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationTempMalesTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationTempPivot", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationTempFemalesFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationTempFemalesTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatIncubationDaysMin", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatIncubationDaysMax", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationHumidityFrom", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@ANatuIncubationHumidityTo", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_natu_all  ";
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
            szSql += " FROM tdoclng_testudines_natu_all  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            oSqlCmdUpdate.Parameters["@ANatuKeyMedia"].Value = m_ANatuKeyMedia;
            oSqlCmdUpdate.Parameters["@ANatDngLevelRedList"].Value = m_ANatDngLevelRedList;
            oSqlCmdUpdate.Parameters["@ANatDngLevelCites"].Value = m_ANatDngLevelCites;
            oSqlCmdUpdate.Parameters["@ANatuKeyFood"].Value = m_ANatuKeyFood;
            oSqlCmdUpdate.Parameters["@ANatuKeyBreeding"].Value = m_ANatuKeyBreeding;
            oSqlCmdUpdate.Parameters["@ANatIncubationTempMalesFrom"].Value = m_ANatIncubationTempMalesFrom;
            oSqlCmdUpdate.Parameters["@ANatuIncubationTempMalesTo"].Value = m_ANatuIncubationTempMalesTo;
            oSqlCmdUpdate.Parameters["@ANatuIncubationTempPivot"].Value = m_ANatuIncubationTempPivot;
            oSqlCmdUpdate.Parameters["@ANatuIncubationTempFemalesFrom"].Value = m_ANatuIncubationTempFemalesFrom;
            oSqlCmdUpdate.Parameters["@ANatuIncubationTempFemalesTo"].Value = m_ANatuIncubationTempFemalesTo;
            oSqlCmdUpdate.Parameters["@ANatIncubationDaysMin"].Value = m_ANatIncubationDaysMin;
            oSqlCmdUpdate.Parameters["@ANatIncubationDaysMax"].Value = m_ANatIncubationDaysMax;
            oSqlCmdUpdate.Parameters["@ANatuIncubationHumidityFrom"].Value = m_ANatuIncubationHumidityFrom;
            oSqlCmdUpdate.Parameters["@ANatuIncubationHumidityTo"].Value = m_ANatuIncubationHumidityTo;
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
            oSqlCmdInsert.Parameters["@ANatuKeyMedia"].Value = m_ANatuKeyMedia;
            oSqlCmdInsert.Parameters["@ANatDngLevelRedList"].Value = m_ANatDngLevelRedList;
            oSqlCmdInsert.Parameters["@ANatDngLevelCites"].Value = m_ANatDngLevelCites;
            oSqlCmdInsert.Parameters["@ANatuKeyFood"].Value = m_ANatuKeyFood;
            oSqlCmdInsert.Parameters["@ANatuKeyBreeding"].Value = m_ANatuKeyBreeding;
            oSqlCmdInsert.Parameters["@ANatIncubationTempMalesFrom"].Value = m_ANatIncubationTempMalesFrom;
            oSqlCmdInsert.Parameters["@ANatuIncubationTempMalesTo"].Value = m_ANatuIncubationTempMalesTo;
            oSqlCmdInsert.Parameters["@ANatuIncubationTempPivot"].Value = m_ANatuIncubationTempPivot;
            oSqlCmdInsert.Parameters["@ANatuIncubationTempFemalesFrom"].Value = m_ANatuIncubationTempFemalesFrom;
            oSqlCmdInsert.Parameters["@ANatuIncubationTempFemalesTo"].Value = m_ANatuIncubationTempFemalesTo;
            oSqlCmdInsert.Parameters["@ANatIncubationDaysMin"].Value = m_ANatIncubationDaysMin;
            oSqlCmdInsert.Parameters["@ANatIncubationDaysMax"].Value = m_ANatIncubationDaysMax;
            oSqlCmdInsert.Parameters["@ANatuIncubationHumidityFrom"].Value = m_ANatuIncubationHumidityFrom;
            oSqlCmdInsert.Parameters["@ANatuIncubationHumidityTo"].Value = m_ANatuIncubationHumidityTo;
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
            MySqlDataReader oDR = null; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_ANatuKeyMedia = oDR["ANatuKeyMedia"].ToString();
                    m_ANatDngLevelRedList = oDR["ANatDngLevelRedList"].ToString();
                    m_ANatDngLevelCites = oDR["ANatDngLevelCites"].ToString();
                    m_ANatuKeyFood = oDR["ANatuKeyFood"].ToString();
                    m_ANatuKeyBreeding = oDR["ANatuKeyBreeding"].ToString();
                    m_ANatIncubationTempMalesFrom = Convert.ToDouble(oDR["ANatIncubationTempMalesFrom"].ToString());
                    m_ANatuIncubationTempMalesTo = Convert.ToDouble(oDR["ANatuIncubationTempMalesTo"].ToString());
                    m_ANatuIncubationTempPivot = Convert.ToDouble(oDR["ANatuIncubationTempPivot"].ToString());
                    m_ANatuIncubationTempFemalesFrom = Convert.ToDouble(oDR["ANatuIncubationTempFemalesFrom"].ToString());
                    m_ANatuIncubationTempFemalesTo = Convert.ToDouble(oDR["ANatuIncubationTempFemalesTo"].ToString());
                    m_ANatIncubationDaysMin = Convert.ToDouble(oDR["ANatIncubationDaysMin"].ToString());
                    m_ANatIncubationDaysMax = Convert.ToDouble(oDR["ANatIncubationDaysMax"].ToString());
                    m_ANatuIncubationHumidityFrom = Convert.ToDouble(oDR["ANatuIncubationHumidityFrom"].ToString());
                    m_ANatuIncubationHumidityTo = Convert.ToDouble(oDR["ANatuIncubationHumidityTo"].ToString());
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
            finally
            {
                if (oDR != null) { oDR.Close(); }
            }
            //------------------------------------------------------
            // cierre.
            //-------------------------------------------------------
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

        public String ANatuKeyMedia
        {
            set
            {
                m_ANatuKeyMedia = value;
            }
            get { return m_ANatuKeyMedia; }
        }

        //................................

        public String ANatDngLevelRedList
        {
            set
            {
                m_ANatDngLevelRedList = value;
            }
            get { return m_ANatDngLevelRedList; }
        }

        //................................

        public String ANatDngLevelCites
        {
            set
            {
                m_ANatDngLevelCites = value;
            }
            get { return m_ANatDngLevelCites; }
        }

        //................................

        public String ANatuKeyFood
        {
            set
            {
                m_ANatuKeyFood = value;
            }
            get { return m_ANatuKeyFood; }
        }

        //................................

        public String ANatuKeyBreeding
        {
            set
            {
                m_ANatuKeyBreeding = value;
            }
            get { return m_ANatuKeyBreeding; }
        }

        //................................

        public Double ANatIncubationTempMalesFrom
        {
            set
            {
                m_ANatIncubationTempMalesFrom = value;
            }
            get { return m_ANatIncubationTempMalesFrom; }
        }

        //................................

        public Double ANatuIncubationTempMalesTo
        {
            set
            {
                m_ANatuIncubationTempMalesTo = value;
            }
            get { return m_ANatuIncubationTempMalesTo; }
        }

        //................................

        public Double ANatuIncubationTempPivot
        {
            set
            {
                m_ANatuIncubationTempPivot = value;
            }
            get { return m_ANatuIncubationTempPivot; }
        }

        //................................

        public Double ANatuIncubationTempFemalesFrom
        {
            set
            {
                m_ANatuIncubationTempFemalesFrom = value;
            }
            get { return m_ANatuIncubationTempFemalesFrom; }
        }

        //................................

        public Double ANatuIncubationTempFemalesTo
        {
            set
            {
                m_ANatuIncubationTempFemalesTo = value;
            }
            get { return m_ANatuIncubationTempFemalesTo; }
        }

        //................................

        public Double ANatIncubationDaysMin
        {
            set
            {
                m_ANatIncubationDaysMin = value;
            }
            get { return m_ANatIncubationDaysMin; }
        }

        //................................

        public Double ANatIncubationDaysMax
        {
            set
            {
                m_ANatIncubationDaysMax = value;
            }
            get { return m_ANatIncubationDaysMax; }
        }

        //................................

        public Double ANatuIncubationHumidityFrom
        {
            set
            {
                m_ANatuIncubationHumidityFrom = value;
            }
            get { return m_ANatuIncubationHumidityFrom; }
        }

        //................................

        public Double ANatuIncubationHumidityTo
        {
            set
            {
                m_ANatuIncubationHumidityTo = value;
            }
            get { return m_ANatuIncubationHumidityTo; }
        }

        #endregion VALORES_GETSET

    }
}