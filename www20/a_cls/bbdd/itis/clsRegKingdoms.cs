using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd.itis
{
    //<summary>
    //Descripción breve de ClsRegKingdoms
    //<//summary>
    public class ClsRegKingdoms
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
        private int m_kingdom_id = 0;
        private String m_kingdom_name = "";
        private System.DateTime m_update_date = System.DateTime.Now.Date;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegKingdoms(string szMySqlConnectionString)
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
            m_kingdom_id = 0;
            m_kingdom_name = "";
            m_update_date = System.DateTime.Now.Date;
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
            szSql = "SELECT * FROM kingdoms  ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO kingdoms";

            szSql += "(";

            szSql += " kingdom_id ";
            szSql += ", kingdom_name ";
            szSql += ", update_date ";
            szSql += " ) VALUES     (";
            szSql += " @kingdom_id ";
            szSql += ", @kingdom_name ";
            szSql += ", @update_date ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@kingdom_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE kingdoms SET ";

            szSql += "kingdom_name=@kingdom_name ";
            szSql += ", update_date=@update_date ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@kingdom_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM kingdoms  ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " kingdom_id";
            szSql += " FROM kingdoms  ";

            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
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
            oSqlCmdSelectExist.Parameters["@kingdom_id"].Value = m_kingdom_id;

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
            oSqlCmdUpdate.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdUpdate.Parameters["@kingdom_name"].Value = m_kingdom_name;
            oSqlCmdUpdate.Parameters["@update_date"].Value = m_update_date;
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
            oSqlCmdInsert.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdInsert.Parameters["@kingdom_name"].Value = m_kingdom_name;
            oSqlCmdInsert.Parameters["@update_date"].Value = m_update_date;
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
        public bool FncSqlFind(int kingdom_id)
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
            oSqlCmdSelect.Parameters["@kingdom_id"].Value = kingdom_id;
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
                    m_kingdom_id = Convert.ToInt32(oDR["kingdom_id"].ToString());
                    m_kingdom_name = oDR["kingdom_name"].ToString();
                    m_update_date = Convert.ToDateTime(oDR["update_date"].ToString());
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
        public bool FncSqlDelete(int kingdom_id)
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
                oSqlCmdDelete.Parameters["@kingdom_id"].Value = kingdom_id;
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

        public int kingdom_id
        {
            set
            {
                m_kingdom_id = value;
            }
            get { return m_kingdom_id; }
        }

        //................................

        public String kingdom_name
        {
            set
            {
                m_kingdom_name = value;
            }
            get { return m_kingdom_name; }
        }

        //................................

        public System.DateTime update_date
        {
            set
            {
                m_update_date = value;
            }
            get { return m_update_date; }
        }

        #endregion VALORES_GETSET

    }
}
