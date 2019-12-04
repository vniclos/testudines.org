using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegTdoclng_testudines_natu
    //<//summary>
    public class ClsReg_tdoclng_testudines_natu
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
        private String m_DocLngId = "";
        private String m_LNatuAsbstract = "";
        private string m_LNatuLifestyles = "";
        private string m_LNatuMediaType = "";
        private string m_LNatuFoodChain = "";
        private string m_LNatuBreeding = "";
        private string m_LNatuDangers = "";
        private string m_LNatuProAction = "";
        private string m_LNatuNotes = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_natu()
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
            m_LNatuAsbstract = "";
            m_LNatuLifestyles = "";
            m_LNatuMediaType = "";
            m_LNatuFoodChain = "";
            m_LNatuBreeding = "";
            m_LNatuDangers = "";
            m_LNatuProAction = "";
            m_LNatuNotes = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_natu  ";
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
            szSql = "INSERT INTO tdoclng_testudines_natu";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", LNatuAsbstract ";
            szSql += ", LNatuLifestyles ";
            szSql += ", LNatuMediaType ";
            szSql += ", LNatuFoodChain ";
            szSql += ", LNatuBreeding ";
            szSql += ", LNatuDangers ";
            szSql += ", LNatuProAction ";
            szSql += ", LNatuNotes ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @LNatuAsbstract ";
            szSql += ", @LNatuLifestyles ";
            szSql += ", @LNatuMediaType ";
            szSql += ", @LNatuFoodChain ";
            szSql += ", @LNatuBreeding ";
            szSql += ", @LNatuDangers ";
            szSql += ", @LNatuProAction ";
            szSql += ", @LNatuNotes ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LNatuAsbstract", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LNatuLifestyles", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuMediaType", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuFoodChain", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuBreeding", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuDangers", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuProAction", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LNatuNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_natu SET ";

            szSql += "LNatuAsbstract=@LNatuAsbstract ";
            szSql += ", LNatuLifestyles=@LNatuLifestyles ";
            szSql += ", LNatuMediaType=@LNatuMediaType ";
            szSql += ", LNatuFoodChain=@LNatuFoodChain ";
            szSql += ", LNatuBreeding=@LNatuBreeding ";
            szSql += ", LNatuDangers=@LNatuDangers ";
            szSql += ", LNatuProAction=@LNatuProAction ";
            szSql += ", LNatuNotes=@LNatuNotes ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LNatuAsbstract", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LNatuLifestyles", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuMediaType", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuFoodChain", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuBreeding", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuDangers", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuProAction", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LNatuNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_natu  ";
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
            szSql += " FROM tdoclng_testudines_natu  ";

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
            oSqlCmdUpdate.Parameters["@LNatuAsbstract"].Value = m_LNatuAsbstract;
            oSqlCmdUpdate.Parameters["@LNatuLifestyles"].Value = m_LNatuLifestyles;
            oSqlCmdUpdate.Parameters["@LNatuMediaType"].Value = m_LNatuMediaType;
            oSqlCmdUpdate.Parameters["@LNatuFoodChain"].Value = m_LNatuFoodChain;
            oSqlCmdUpdate.Parameters["@LNatuBreeding"].Value = m_LNatuBreeding;
            oSqlCmdUpdate.Parameters["@LNatuDangers"].Value = m_LNatuDangers;
            oSqlCmdUpdate.Parameters["@LNatuProAction"].Value = m_LNatuProAction;
            oSqlCmdUpdate.Parameters["@LNatuNotes"].Value = m_LNatuNotes;
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
            oSqlCmdInsert.Parameters["@LNatuAsbstract"].Value = m_LNatuAsbstract;
            oSqlCmdInsert.Parameters["@LNatuLifestyles"].Value = m_LNatuLifestyles;
            oSqlCmdInsert.Parameters["@LNatuMediaType"].Value = m_LNatuMediaType;
            oSqlCmdInsert.Parameters["@LNatuFoodChain"].Value = m_LNatuFoodChain;
            oSqlCmdInsert.Parameters["@LNatuBreeding"].Value = m_LNatuBreeding;
            oSqlCmdInsert.Parameters["@LNatuDangers"].Value = m_LNatuDangers;
            oSqlCmdInsert.Parameters["@LNatuProAction"].Value = m_LNatuProAction;
            oSqlCmdInsert.Parameters["@LNatuNotes"].Value = m_LNatuNotes;
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
                    m_LNatuAsbstract = oDR["LNatuAsbstract"].ToString();
                    m_LNatuLifestyles = oDR["LNatuLifestyles"].ToString();
                    m_LNatuMediaType = oDR["LNatuMediaType"].ToString();
                    m_LNatuFoodChain = oDR["LNatuFoodChain"].ToString();
                    m_LNatuBreeding = oDR["LNatuBreeding"].ToString();
                    m_LNatuDangers = oDR["LNatuDangers"].ToString();
                    m_LNatuProAction = oDR["LNatuProAction"].ToString();
                    m_LNatuNotes = oDR["LNatuNotes"].ToString();
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

        public String LNatuAsbstract
        {
            set
            {
                m_LNatuAsbstract = value;
            }
            get { return m_LNatuAsbstract; }
        }

        //................................

        public string LNatuLifestyles
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuLifestyles because it is too long,MaxLength=65535";
                }
                m_LNatuLifestyles = sz;
            }
            get { return m_LNatuLifestyles; }
        }

        //................................

        public string LNatuMediaType
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuMediaType because it is too long,MaxLength=65535";
                }
                m_LNatuMediaType = sz;
            }
            get { return m_LNatuMediaType; }
        }

        //................................

        public string LNatuFoodChain
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuFoodChain because it is too long,MaxLength=65535";
                }
                m_LNatuFoodChain = sz;
            }
            get { return m_LNatuFoodChain; }
        }

        //................................

        public string LNatuBreeding
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuBreeding because it is too long,MaxLength=65535";
                }
                m_LNatuBreeding = sz;
            }
            get { return m_LNatuBreeding; }
        }

        //................................

        public string LNatuDangers
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuDangers because it is too long,MaxLength=65535";
                }
                m_LNatuDangers = sz;
            }
            get { return m_LNatuDangers; }
        }

        //................................

        public string LNatuProAction
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuProAction because it is too long,MaxLength=65535";
                }
                m_LNatuProAction = sz;
            }
            get { return m_LNatuProAction; }
        }

        //................................

        public string LNatuNotes
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LNatuNotes because it is too long,MaxLength=65535";
                }
                m_LNatuNotes = sz;
            }
            get { return m_LNatuNotes; }
        }

        #endregion VALORES_GETSET

    }
}
