using System;
using MySql.Data.MySqlClient;
using System.Data;
using testudines.cls.bbdd;

namespace testudines
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_testudineskeys_turtelsoftheworld
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
        private String m_id = "";
        private String m_ParentId = "";
        private String m_NodekeyNum = "";
        private String m_Description = "";
        private String m_TaxaGroupLevel = "";
        private String m_TaxaGroupName = "";
        private String m_TaxaURL = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_testudineskeys_turtelsoftheworld(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_testudineskeys_turtelsoftheworld()
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
            m_id = "";
            m_ParentId = "";
            m_NodekeyNum = "";
            m_Description = "";
            m_TaxaGroupLevel = "";
            m_TaxaGroupName = "";
            m_TaxaURL = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_keys_turtelsoftheworld  ";
            szSql += " WHERE ";
            szSql += "(id=@id )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_keys_turtelsoftheworld";

            szSql += "(";

            szSql += " id ";
            szSql += ", ParentId ";
            szSql += ", NodekeyNum ";
            szSql += ", Description ";
            szSql += ", TaxaGroupLevel ";
            szSql += ", TaxaGroupName ";
            szSql += ", TaxaURL ";
            szSql += " ) VALUES     (";
            szSql += " @id ";
            szSql += ", @ParentId ";
            szSql += ", @NodekeyNum ";
            szSql += ", @Description ";
            szSql += ", @TaxaGroupLevel ";
            szSql += ", @TaxaGroupName ";
            szSql += ", @TaxaURL ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ParentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@NodekeyNum", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Description", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@TaxaGroupLevel", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@TaxaGroupName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@TaxaURL", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_keys_turtelsoftheworld SET ";

            szSql += "ParentId=@ParentId ";
            szSql += ", NodekeyNum=@NodekeyNum ";
            szSql += ", Description=@Description ";
            szSql += ", TaxaGroupLevel=@TaxaGroupLevel ";
            szSql += ", TaxaGroupName=@TaxaGroupName ";
            szSql += ", TaxaURL=@TaxaURL ";
            szSql += " WHERE ";
            szSql += "(id=@id )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ParentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@NodekeyNum", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Description", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@TaxaGroupLevel", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@TaxaGroupName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@TaxaURL", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_keys_turtelsoftheworld  ";
            szSql += " WHERE ";
            szSql += "(id=@id )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " id";
            szSql += " FROM tdoclng_testudines_keys_turtelsoftheworld  ";

            szSql += " WHERE ";
            szSql += "(id=@id )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@id", MySql.Data.MySqlClient.MySqlDbType.String);
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
            if (!cls.bbdd.ClsMysql.FncOpen())
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

            oSqlCmdSelectExist.Parameters["@id"].Value = m_id;

            oSqlCmdSelectExist.Connection = cls.bbdd.ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
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
            oSqlCmdUpdate.Parameters["@id"].Value = m_id;
            oSqlCmdUpdate.Parameters["@ParentId"].Value = m_ParentId;
            oSqlCmdUpdate.Parameters["@NodekeyNum"].Value = m_NodekeyNum;
            oSqlCmdUpdate.Parameters["@Description"].Value = m_Description;
            oSqlCmdUpdate.Parameters["@TaxaGroupLevel"].Value = m_TaxaGroupLevel;
            oSqlCmdUpdate.Parameters["@TaxaGroupName"].Value = m_TaxaGroupName;
            oSqlCmdUpdate.Parameters["@TaxaURL"].Value = m_TaxaURL;
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
            cls.bbdd.ClsMysql.FncClose();
            
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
            oSqlCmdInsert.Parameters["@id"].Value = m_id;
            oSqlCmdInsert.Parameters["@ParentId"].Value = m_ParentId;
            oSqlCmdInsert.Parameters["@NodekeyNum"].Value = m_NodekeyNum;
            oSqlCmdInsert.Parameters["@Description"].Value = m_Description;
            oSqlCmdInsert.Parameters["@TaxaGroupLevel"].Value = m_TaxaGroupLevel;
            oSqlCmdInsert.Parameters["@TaxaGroupName"].Value = m_TaxaGroupName;
            oSqlCmdInsert.Parameters["@TaxaURL"].Value = m_TaxaURL;
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
        public bool FncSqlFind(String id)
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
            oSqlCmdSelect.Parameters["@id"].Value = id;
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
                    m_id = oDR["id"].ToString().Trim();
                    m_ParentId = oDR["ParentId"].ToString().Trim();
                    m_NodekeyNum = oDR["NodekeyNum"].ToString().Trim();
                    m_Description = oDR["Description"].ToString().Trim();
                    m_TaxaGroupLevel = oDR["TaxaGroupLevel"].ToString().Trim();
                    m_TaxaGroupName = oDR["TaxaGroupName"].ToString().Trim();
                    m_TaxaURL = oDR["TaxaURL"].ToString().Trim();
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
        public bool FncSqlDelete(String id)
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
                oSqlCmdDelete.Parameters["@id"].Value = id;
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
        public bool FncSqlExist(String id)
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
            oSqlCmdSelectExist.Parameters["@id"].Value = id;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
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

        public String id
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 5)
                {
                    sz = sz.Substring(0, 4);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_id because is it too long,MaxLength=5";
                }
                m_id = sz;

            }
            get { return m_id; }
        }

        //................................

        public String ParentId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 5)
                {
                    sz = sz.Substring(0, 4);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ParentId because is it too long,MaxLength=5";
                }
                m_ParentId = sz;

            }
            get { return m_ParentId; }
        }

        //................................

        public String NodekeyNum
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 5)
                {
                    sz = sz.Substring(0, 4);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_NodekeyNum because is it too long,MaxLength=5";
                }
                m_NodekeyNum = sz;

            }
            get { return m_NodekeyNum; }
        }

        //................................

        public String Description
        {
            set
            {
                m_Description = value;
            }
            get { return m_Description; }
        }

        //................................

        public String TaxaGroupLevel
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_TaxaGroupLevel because is it too long,MaxLength=50";
                }
                m_TaxaGroupLevel = sz;

            }
            get { return m_TaxaGroupLevel; }
        }

        //................................

        public String TaxaGroupName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_TaxaGroupName because is it too long,MaxLength=50";
                }
                m_TaxaGroupName = sz;

            }
            get { return m_TaxaGroupName; }
        }

        //................................

        public String TaxaURL
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 255)
                {
                    sz = sz.Substring(0, 254);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_TaxaURL because is it too long,MaxLength=255";
                }
                m_TaxaURL = sz;

            }
            get { return m_TaxaURL; }
        }

        #endregion VALORES_GETSET

    }
}
