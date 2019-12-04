using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegTdoclng_testudines_care
    //<//summary>
    public class ClsReg_tdoclng_testudines_care
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
        private string m_LCareAbstract = "";
        private string m_LCareValues = "";
        private string m_LCareVivariumIndoor = "";
        private string m_LCareVivariumOutdoor = "";
        private string m_LCareFood = "";
        private string m_LCareBreeding = "";
        private string m_LCareNotes = "";
        private string m_LCareEspecialist = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_care()
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
            m_LCareAbstract = "";
            m_LCareValues = "";
            m_LCareVivariumIndoor = "";
            m_LCareVivariumOutdoor = "";
            m_LCareFood = "";
            m_LCareBreeding = "";
            m_LCareNotes = "";
            m_LCareEspecialist = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_care  ";
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
            szSql = "INSERT INTO tdoclng_testudines_care";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", LCareAbstract ";
            szSql += ", LCareValues ";
            szSql += ", LCareVivariumIndoor ";
            szSql += ", LCareVivariumOutdoor ";
            szSql += ", LCareFood ";
            szSql += ", LCareBreeding ";
            szSql += ", LCareNotes ";
            szSql += ", LCareEspecialist ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @LCareAbstract ";
            szSql += ", @LCareValues ";
            szSql += ", @LCareVivariumIndoor ";
            szSql += ", @LCareVivariumOutdoor ";
            szSql += ", @LCareFood ";
            szSql += ", @LCareBreeding ";
            szSql += ", @LCareNotes ";
            szSql += ", @LCareEspecialist ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LCareAbstract", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareValues", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareVivariumIndoor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareVivariumOutdoor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareFood", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareBreeding", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LCareEspecialist", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_care SET ";

            szSql += "LCareAbstract=@LCareAbstract ";
            szSql += ", LCareValues=@LCareValues ";
            szSql += ", LCareVivariumIndoor=@LCareVivariumIndoor ";
            szSql += ", LCareVivariumOutdoor=@LCareVivariumOutdoor ";
            szSql += ", LCareFood=@LCareFood ";
            szSql += ", LCareBreeding=@LCareBreeding ";
            szSql += ", LCareNotes=@LCareNotes ";
            szSql += ", LCareEspecialist=@LCareEspecialist ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LCareAbstract", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareValues", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareVivariumIndoor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareVivariumOutdoor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareFood", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareBreeding", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LCareEspecialist", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_care  ";
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
            szSql += " FROM tdoclng_testudines_care  ";

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
            oSqlCmdUpdate.Parameters["@LCareAbstract"].Value = m_LCareAbstract;
            oSqlCmdUpdate.Parameters["@LCareValues"].Value = m_LCareValues;
            oSqlCmdUpdate.Parameters["@LCareVivariumIndoor"].Value = m_LCareVivariumIndoor;
            oSqlCmdUpdate.Parameters["@LCareVivariumOutdoor"].Value = m_LCareVivariumOutdoor;
            oSqlCmdUpdate.Parameters["@LCareFood"].Value = m_LCareFood;
            oSqlCmdUpdate.Parameters["@LCareBreeding"].Value = m_LCareBreeding;
            oSqlCmdUpdate.Parameters["@LCareNotes"].Value = m_LCareNotes;
            oSqlCmdUpdate.Parameters["@LCareEspecialist"].Value = m_LCareEspecialist;
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
            oSqlCmdInsert.Parameters["@LCareAbstract"].Value = m_LCareAbstract;
            oSqlCmdInsert.Parameters["@LCareValues"].Value = m_LCareValues;
            oSqlCmdInsert.Parameters["@LCareVivariumIndoor"].Value = m_LCareVivariumIndoor;
            oSqlCmdInsert.Parameters["@LCareVivariumOutdoor"].Value = m_LCareVivariumOutdoor;
            oSqlCmdInsert.Parameters["@LCareFood"].Value = m_LCareFood;
            oSqlCmdInsert.Parameters["@LCareBreeding"].Value = m_LCareBreeding;
            oSqlCmdInsert.Parameters["@LCareNotes"].Value = m_LCareNotes;
            oSqlCmdInsert.Parameters["@LCareEspecialist"].Value = m_LCareEspecialist;
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
                    m_LCareAbstract = oDR["LCareAbstract"].ToString();
                    m_LCareValues = oDR["LCareValues"].ToString();
                    m_LCareVivariumIndoor = oDR["LCareVivariumIndoor"].ToString();
                    m_LCareVivariumOutdoor = oDR["LCareVivariumOutdoor"].ToString();
                    m_LCareFood = oDR["LCareFood"].ToString();
                    m_LCareBreeding = oDR["LCareBreeding"].ToString();
                    m_LCareNotes = oDR["LCareNotes"].ToString();
                    m_LCareEspecialist = oDR["LCareEspecialist"].ToString();
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

        public string LCareAbstract
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareAbstract because it is too long,MaxLength=65535";
                }
                m_LCareAbstract = sz;
            }
            get { return m_LCareAbstract; }
        }

        //................................

        public string LCareValues
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareValues because it is too long,MaxLength=65535";
                }
                m_LCareValues = sz;
            }
            get { return m_LCareValues; }
        }

        //................................

        public string LCareVivariumIndoor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareVivariumIndoor because it is too long,MaxLength=65535";
                }
                m_LCareVivariumIndoor = sz;
            }
            get { return m_LCareVivariumIndoor; }
        }

        //................................

        public string LCareVivariumOutdoor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareVivariumOutdoor because it is too long,MaxLength=65535";
                }
                m_LCareVivariumOutdoor = sz;
            }
            get { return m_LCareVivariumOutdoor; }
        }

        //................................

        public string LCareFood
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareFood because it is too long,MaxLength=65535";
                }
                m_LCareFood = sz;
            }
            get { return m_LCareFood; }
        }

        //................................

        public string LCareBreeding
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareBreeding because it is too long,MaxLength=65535";
                }
                m_LCareBreeding = sz;
            }
            get { return m_LCareBreeding; }
        }

        //................................

        public string LCareNotes
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareNotes because it is too long,MaxLength=65535";
                }
                m_LCareNotes = sz;
            }
            get { return m_LCareNotes; }
        }

        //................................

        public string LCareEspecialist
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LCareEspecialist because it is too long,MaxLength=65535";
                }
                m_LCareEspecialist = sz;
            }
            get { return m_LCareEspecialist; }
        }

        #endregion VALORES_GETSET

    }
}
