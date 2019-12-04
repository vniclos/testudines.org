using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegXtern_2018_relation
    //<//summary>
    public class ClsRegXtern_2018_relation
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
        private String m_Family = "";
        private String m_Genus = "";
        private String m_Specie = "";
        private String m_SpecieSub = "";
        private UInt64 m_DocId = 0;
        private UInt64 m_DocIdCites = 0;
        private UInt64 m_DocIdIucn = 0;
        private UInt64 m_DocIdItis = 0;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegXtern_2018_relation(string szMySqlConnectionString)
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
            m_Family = "";
            m_Genus = "";
            m_Specie = "";
            m_SpecieSub = "";
            m_DocId = 0;
            m_DocIdCites = 0;
            m_DocIdIucn = 0;
            m_DocIdItis = 0;
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
            szSql = "SELECT * FROM xtern_2018_relation  ";
            szSql += " WHERE ";
            szSql += "(Family=@Family )";
            szSql += " AND (Genus=@Genus )";
            szSql += " AND (Specie=@Specie )";
            szSql += " AND (SpecieSub=@SpecieSub )";
            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelect.Parameters.Add("@Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelect.Parameters.Add("@Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelect.Parameters.Add("@SpecieSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO xtern_2018_relation";

            szSql += "(";

            szSql += " Family ";
            szSql += ", Genus ";
            szSql += ", Specie ";
            szSql += ", SpecieSub ";
            szSql += ", DocId ";
            szSql += ", DocIdCites ";
            szSql += ", DocIdIucn ";
            szSql += ", DocIdItis ";
            szSql += " ) VALUES     (";
            szSql += " @Family ";
            szSql += ", @Genus ";
            szSql += ", @Specie ";
            szSql += ", @SpecieSub ";
            szSql += ", @DocId ";
            szSql += ", @DocIdCites ";
            szSql += ", @DocIdIucn ";
            szSql += ", @DocIdItis ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@SpecieSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocIdCites", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocIdIucn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocIdItis", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE xtern_2018_relation SET ";

            szSql += "DocId=@DocId ";
            szSql += ", DocIdCites=@DocIdCites ";
            szSql += ", DocIdIucn=@DocIdIucn ";
            szSql += ", DocIdItis=@DocIdItis ";
            szSql += " WHERE ";
            szSql += "(Family=@Family )";
            szSql += " AND (Genus=@Genus )";
            szSql += " AND (Specie=@Specie )";
            szSql += " AND (Specie=@SpecieSub )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@SpecieSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocIdCites", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocIdIucn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocIdItis", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM xtern_2018_relation  ";
            szSql += " WHERE ";
            szSql += "(Family=@Family )";
            szSql += " AND (Genus=@Genus )";
            szSql += " AND (Specie=@Specie )";
            szSql += " AND (SpecieSub=@SpecieSub )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdDelete.Parameters.Add("@Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdDelete.Parameters.Add("@Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdDelete.Parameters.Add("@SpecieSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " Family";

            szSql += ", Genus";

            szSql += ", Specie";
            szSql += " FROM xtern_2018_relation  ";

            szSql += " WHERE ";
            szSql += "(Family=@Family )";
            szSql += " AND (Genus=@Genus )";
            szSql += " AND (Specie=@Specie )";
            szSql += " AND (SpecieSub=@SpecieSub )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelectExist.Parameters.Add("@Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelectExist.Parameters.Add("@Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdSelectExist.Parameters.Add("@SpecieSub", MySql.Data.MySqlClient.MySqlDbType.VarChar);
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
            oSqlCmdSelectExist.Parameters["@Family"].Value = m_Family;
            oSqlCmdSelectExist.Parameters["@Genus"].Value = m_Genus;
            oSqlCmdSelectExist.Parameters["@Specie"].Value = m_Specie;
            oSqlCmdSelectExist.Parameters["@SpecieSub"].Value = m_SpecieSub;
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
            oSqlCmdUpdate.Parameters["@Family"].Value = m_Family;
            oSqlCmdUpdate.Parameters["@Genus"].Value = m_Genus;
            oSqlCmdUpdate.Parameters["@Specie"].Value = m_Specie;
            oSqlCmdUpdate.Parameters["@SpecieSub"].Value = m_SpecieSub;
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DocIdCites"].Value = m_DocIdCites;
            oSqlCmdUpdate.Parameters["@DocIdIucn"].Value = m_DocIdIucn;
            oSqlCmdUpdate.Parameters["@DocIdItis"].Value = m_DocIdItis;
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
            oSqlCmdInsert.Parameters["@Family"].Value = m_Family;
            oSqlCmdInsert.Parameters["@Genus"].Value = m_Genus;
            oSqlCmdInsert.Parameters["@Specie"].Value = m_Specie;
            oSqlCmdInsert.Parameters["@SpecieSub"].Value = m_SpecieSub;
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DocIdCites"].Value = m_DocIdCites;
            oSqlCmdInsert.Parameters["@DocIdIucn"].Value = m_DocIdIucn;
            oSqlCmdInsert.Parameters["@DocIdItis"].Value = m_DocIdItis;
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
        public bool FncSqlFind(String Family, String Genus, String Specie, String SpecieSub)
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
            oSqlCmdSelect.Parameters["@Family"].Value = Family;
            oSqlCmdSelect.Parameters["@Genus"].Value = Genus;
            oSqlCmdSelect.Parameters["@Specie"].Value = Specie;
            oSqlCmdSelect.Parameters["@SpecieSub"].Value = SpecieSub;
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
                    m_Family = oDR["Family"].ToString();
                    m_Genus = oDR["Genus"].ToString();
                    m_Specie = oDR["Specie"].ToString();
                    m_SpecieSub = oDR["SpecieSub"].ToString();
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_DocIdCites = Convert.ToUInt64(oDR["DocIdCites"].ToString());
                    m_DocIdIucn = Convert.ToUInt64(oDR["DocIdIucn"].ToString());
                    m_DocIdItis = Convert.ToUInt64(oDR["DocIdItis"].ToString());
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
        public bool FncSqlDelete(String Family, String Genus, String Specie, String SpecieSub)
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
                oSqlCmdDelete.Parameters["@Family"].Value = Family;
                oSqlCmdDelete.Parameters["@Genus"].Value = Genus;
                oSqlCmdDelete.Parameters["@Specie"].Value = Specie;
                oSqlCmdDelete.Parameters["@SpecieSub"].Value = SpecieSub;
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
        ////--------------------------------------------------------
        ///
   


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

        public String Family
        {
            set
            {
                m_Family = value;
            }
            get { return m_Family; }
        }

        //................................

        public String Genus
        {
            set
            {
                m_Genus = value;
            }
            get { return m_Genus; }
        }

        //................................

        public String Specie
        {
            set
            {
                m_Specie = value;
            }
            get { return m_Specie; }
        }
        public String SpecieSub
        {
            set
            {
                m_Specie = value;
            }
            get { return m_Specie; }
        }

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

        public UInt64 DocIdCites
        {
            set
            {
                m_DocIdCites = value;
            }
            get { return m_DocIdCites; }
        }

        //................................

        public UInt64 DocIdIucn
        {
            set
            {
                m_DocIdIucn = value;
            }
            get { return m_DocIdIucn; }
        }

        //................................

        public UInt64 DocIdItis
        {
            set
            {
                m_DocIdItis = value;
            }
            get { return m_DocIdItis; }
        }

        #endregion VALORES_GETSET

    }
}