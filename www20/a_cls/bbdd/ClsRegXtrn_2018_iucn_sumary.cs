using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegXtrn_2018_iucn_sumary
    //<//summary>
    public class ClsRegXtrn_2018_iucn_sumary
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
        private UInt64 m_assessmentId = 0;
        private UInt64 m_internalTaxonId = 0;
        private String m_kingdomName = "";
        private String m_phylumName = "";
        private String m_orderName = "";
        private String m_className = "";
        private String m_familyName = "";
        private String m_genusName = "";
        private String m_speciesName = "";
        private String m_infraType = "";
        private String m_infraName = "";
        private String m_infraAuthority = "";
        private String m_authority = "";
        private String m_redlistCategory = "";
        private String m_redlistCriteria = "";
        private Decimal m_criteriaVersion = 0;
        private String m_populationTrend = "";
        private String m_scopes = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegXtrn_2018_iucn_sumary(string szMySqlConnectionString)
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
            m_assessmentId = 0;
            m_internalTaxonId = 0;
            m_kingdomName = "";
            m_phylumName = "";
            m_orderName = "";
            m_className = "";
            m_familyName = "";
            m_genusName = "";
            m_speciesName = "";
            m_infraType = "";
            m_infraName = "";
            m_infraAuthority = "";
            m_authority = "";
            m_redlistCategory = "";
            m_redlistCriteria = "";
            m_criteriaVersion = 0;
            m_populationTrend = "";
            m_scopes = "";
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
            szSql = "SELECT * FROM xtrn_2018_iucn_sumary  ";
            szSql += " WHERE ";
            szSql += "(assessmentId=@assessmentId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@assessmentId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO xtrn_2018_iucn_sumary";

            szSql += "(";

            szSql += " assessmentId ";
            szSql += ", internalTaxonId ";
            szSql += ", kingdomName ";
            szSql += ", phylumName ";
            szSql += ", orderName ";
            szSql += ", className ";
            szSql += ", familyName ";
            szSql += ", genusName ";
            szSql += ", speciesName ";
            szSql += ", infraType ";
            szSql += ", infraName ";
            szSql += ", infraAuthority ";
            szSql += ", authority ";
            szSql += ", redlistCategory ";
            szSql += ", redlistCriteria ";
            szSql += ", criteriaVersion ";
            szSql += ", populationTrend ";
            szSql += ", scopes ";
            szSql += " ) VALUES     (";
            szSql += " @assessmentId ";
            szSql += ", @internalTaxonId ";
            szSql += ", @kingdomName ";
            szSql += ", @phylumName ";
            szSql += ", @orderName ";
            szSql += ", @className ";
            szSql += ", @familyName ";
            szSql += ", @genusName ";
            szSql += ", @speciesName ";
            szSql += ", @infraType ";
            szSql += ", @infraName ";
            szSql += ", @infraAuthority ";
            szSql += ", @authority ";
            szSql += ", @redlistCategory ";
            szSql += ", @redlistCriteria ";
            szSql += ", @criteriaVersion ";
            szSql += ", @populationTrend ";
            szSql += ", @scopes ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@assessmentId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@internalTaxonId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@kingdomName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@phylumName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@orderName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@className", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@familyName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@genusName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@speciesName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@infraType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@infraName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@infraAuthority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@authority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@redlistCategory", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@redlistCriteria", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@criteriaVersion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
            oSqlCmdInsert.Parameters.Add("@populationTrend", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@scopes", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE xtrn_2018_iucn_sumary SET ";

            szSql += "internalTaxonId=@internalTaxonId ";
            szSql += ", kingdomName=@kingdomName ";
            szSql += ", phylumName=@phylumName ";
            szSql += ", orderName=@orderName ";
            szSql += ", className=@className ";
            szSql += ", familyName=@familyName ";
            szSql += ", genusName=@genusName ";
            szSql += ", speciesName=@speciesName ";
            szSql += ", infraType=@infraType ";
            szSql += ", infraName=@infraName ";
            szSql += ", infraAuthority=@infraAuthority ";
            szSql += ", authority=@authority ";
            szSql += ", redlistCategory=@redlistCategory ";
            szSql += ", redlistCriteria=@redlistCriteria ";
            szSql += ", criteriaVersion=@criteriaVersion ";
            szSql += ", populationTrend=@populationTrend ";
            szSql += ", scopes=@scopes ";
            szSql += " WHERE ";
            szSql += "(assessmentId=@assessmentId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@assessmentId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@internalTaxonId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@kingdomName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@phylumName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@orderName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@className", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@familyName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@genusName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@speciesName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@infraType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@infraName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@infraAuthority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@authority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@redlistCategory", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@redlistCriteria", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@criteriaVersion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
            oSqlCmdUpdate.Parameters.Add("@populationTrend", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@scopes", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM xtrn_2018_iucn_sumary  ";
            szSql += " WHERE ";
            szSql += "(assessmentId=@assessmentId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@assessmentId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " assessmentId";
            szSql += " FROM xtrn_2018_iucn_sumary  ";

            szSql += " WHERE ";
            szSql += "(assessmentId=@assessmentId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@assessmentId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;

            // comprobar si existe el id a añadir
            oSqlCmdSelectExist.Parameters["@assessmentId"].Value = m_assessmentId;

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
            oSqlCmdUpdate.Parameters["@assessmentId"].Value = m_assessmentId;
            oSqlCmdUpdate.Parameters["@internalTaxonId"].Value = m_internalTaxonId;
            oSqlCmdUpdate.Parameters["@kingdomName"].Value = m_kingdomName;
            oSqlCmdUpdate.Parameters["@phylumName"].Value = m_phylumName;
            oSqlCmdUpdate.Parameters["@orderName"].Value = m_orderName;
            oSqlCmdUpdate.Parameters["@className"].Value = m_className;
            oSqlCmdUpdate.Parameters["@familyName"].Value = m_familyName;
            oSqlCmdUpdate.Parameters["@genusName"].Value = m_genusName;
            oSqlCmdUpdate.Parameters["@speciesName"].Value = m_speciesName;
            oSqlCmdUpdate.Parameters["@infraType"].Value = m_infraType;
            oSqlCmdUpdate.Parameters["@infraName"].Value = m_infraName;
            oSqlCmdUpdate.Parameters["@infraAuthority"].Value = m_infraAuthority;
            oSqlCmdUpdate.Parameters["@authority"].Value = m_authority;
            oSqlCmdUpdate.Parameters["@redlistCategory"].Value = m_redlistCategory;
            oSqlCmdUpdate.Parameters["@redlistCriteria"].Value = m_redlistCriteria;
            oSqlCmdUpdate.Parameters["@criteriaVersion"].Value = m_criteriaVersion;
            oSqlCmdUpdate.Parameters["@populationTrend"].Value = m_populationTrend;
            oSqlCmdUpdate.Parameters["@scopes"].Value = m_scopes;
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
            oSqlCmdInsert.Parameters["@assessmentId"].Value = m_assessmentId;
            oSqlCmdInsert.Parameters["@internalTaxonId"].Value = m_internalTaxonId;
            oSqlCmdInsert.Parameters["@kingdomName"].Value = m_kingdomName;
            oSqlCmdInsert.Parameters["@phylumName"].Value = m_phylumName;
            oSqlCmdInsert.Parameters["@orderName"].Value = m_orderName;
            oSqlCmdInsert.Parameters["@className"].Value = m_className;
            oSqlCmdInsert.Parameters["@familyName"].Value = m_familyName;
            oSqlCmdInsert.Parameters["@genusName"].Value = m_genusName;
            oSqlCmdInsert.Parameters["@speciesName"].Value = m_speciesName;
            oSqlCmdInsert.Parameters["@infraType"].Value = m_infraType;
            oSqlCmdInsert.Parameters["@infraName"].Value = m_infraName;
            oSqlCmdInsert.Parameters["@infraAuthority"].Value = m_infraAuthority;
            oSqlCmdInsert.Parameters["@authority"].Value = m_authority;
            oSqlCmdInsert.Parameters["@redlistCategory"].Value = m_redlistCategory;
            oSqlCmdInsert.Parameters["@redlistCriteria"].Value = m_redlistCriteria;
            oSqlCmdInsert.Parameters["@criteriaVersion"].Value = m_criteriaVersion;
            oSqlCmdInsert.Parameters["@populationTrend"].Value = m_populationTrend;
            oSqlCmdInsert.Parameters["@scopes"].Value = m_scopes;
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
        public bool FncSqlFind(UInt64 assessmentId)
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
            oSqlCmdSelect.Parameters["@assessmentId"].Value = assessmentId;
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
                    m_assessmentId = Convert.ToUInt64(oDR["assessmentId"].ToString());
                    m_internalTaxonId = Convert.ToUInt64(oDR["internalTaxonId"].ToString());
                    m_kingdomName = oDR["kingdomName"].ToString();
                    m_phylumName = oDR["phylumName"].ToString();
                    m_orderName = oDR["orderName"].ToString();
                    m_className = oDR["className"].ToString();
                    m_familyName = oDR["familyName"].ToString();
                    m_genusName = oDR["genusName"].ToString();
                    m_speciesName = oDR["speciesName"].ToString();
                    m_infraType = oDR["infraType"].ToString();
                    m_infraName = oDR["infraName"].ToString();
                    m_infraAuthority = oDR["infraAuthority"].ToString();
                    m_authority = oDR["authority"].ToString();
                    m_redlistCategory = oDR["redlistCategory"].ToString();
                    m_redlistCriteria = oDR["redlistCriteria"].ToString();
                    m_criteriaVersion = Convert.ToDecimal(oDR["criteriaVersion"].ToString());
                    m_populationTrend = oDR["populationTrend"].ToString();
                    m_scopes = oDR["scopes"].ToString();
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
        public bool FncSqlDelete(UInt64 assessmentId)
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
                oSqlCmdDelete.Parameters["@assessmentId"].Value = assessmentId;
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

        public UInt64 assessmentId
        {
            set
            {
                m_assessmentId = value;
            }
            get { return m_assessmentId; }
        }

        //................................

        public UInt64 internalTaxonId
        {
            set
            {
                m_internalTaxonId = value;
            }
            get { return m_internalTaxonId; }
        }

        //................................

        public String kingdomName
        {
            set
            {
                m_kingdomName = value;
            }
            get { return m_kingdomName; }
        }

        //................................

        public String phylumName
        {
            set
            {
                m_phylumName = value;
            }
            get { return m_phylumName; }
        }

        //................................

        public String orderName
        {
            set
            {
                m_orderName = value;
            }
            get { return m_orderName; }
        }

        //................................

        public String className
        {
            set
            {
                m_className = value;
            }
            get { return m_className; }
        }

        //................................

        public String familyName
        {
            set
            {
                m_familyName = value;
            }
            get { return m_familyName; }
        }

        //................................

        public String genusName
        {
            set
            {
                m_genusName = value;
            }
            get { return m_genusName; }
        }

        //................................

        public String speciesName
        {
            set
            {
                m_speciesName = value;
            }
            get { return m_speciesName; }
        }

        //................................

        public String infraType
        {
            set
            {
                m_infraType = value;
            }
            get { return m_infraType; }
        }

        //................................

        public String infraName
        {
            set
            {
                m_infraName = value;
            }
            get { return m_infraName; }
        }

        //................................

        public String infraAuthority
        {
            set
            {
                m_infraAuthority = value;
            }
            get { return m_infraAuthority; }
        }

        //................................

        public String authority
        {
            set
            {
                m_authority = value;
            }
            get { return m_authority; }
        }

        //................................

        public String redlistCategory
        {
            set
            {
                m_redlistCategory = value;
            }
            get { return m_redlistCategory; }
        }

        //................................

        public String redlistCriteria
        {
            set
            {
                m_redlistCriteria = value;
            }
            get { return m_redlistCriteria; }
        }

        //................................

        public Decimal criteriaVersion
        {
            set
            {
                m_criteriaVersion = value;
            }
            get { return m_criteriaVersion; }
        }

        //................................

        public String populationTrend
        {
            set
            {
                m_populationTrend = value;
            }
            get { return m_populationTrend; }
        }

        //................................

        public String scopes
        {
            set
            {
                m_scopes = value;
            }
            get { return m_scopes; }
        }

        #endregion VALORES_GETSET

    }
}
