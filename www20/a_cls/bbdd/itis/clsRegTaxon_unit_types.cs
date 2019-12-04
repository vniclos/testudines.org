using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd.itis
{
    //<summary>
    //Descripción breve de ClsRegTaxon_unit_types
    //<//summary>
    public class ClsRegTaxon_unit_types
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
        private Int16 m_rank_id = 0;
        private String m_rank_name = "";
        private Int16 m_dir_parent_rank_id = 0;
        private Int16 m_req_parent_rank_id = 0;
        private System.DateTime m_update_date = System.DateTime.Now.Date;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegTaxon_unit_types(string szMySqlConnectionString)
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
            m_rank_id = 0;
            m_rank_name = "";
            m_dir_parent_rank_id = 0;
            m_req_parent_rank_id = 0;
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
            szSql = "SELECT * FROM taxon_unit_types  ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            szSql += " AND (rank_id=@rank_id )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelect.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO taxon_unit_types";

            szSql += "(";

            szSql += " kingdom_id ";
            szSql += ", rank_id ";
            szSql += ", rank_name ";
            szSql += ", dir_parent_rank_id ";
            szSql += ", req_parent_rank_id ";
            szSql += ", update_date ";
            szSql += " ) VALUES     (";
            szSql += " @kingdom_id ";
            szSql += ", @rank_id ";
            szSql += ", @rank_name ";
            szSql += ", @dir_parent_rank_id ";
            szSql += ", @req_parent_rank_id ";
            szSql += ", @update_date ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@rank_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@dir_parent_rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@req_parent_rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE taxon_unit_types SET ";

            szSql += "rank_name=@rank_name ";
            szSql += ", dir_parent_rank_id=@dir_parent_rank_id ";
            szSql += ", req_parent_rank_id=@req_parent_rank_id ";
            szSql += ", update_date=@update_date ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            szSql += " AND (rank_id=@rank_id )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@rank_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@dir_parent_rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@req_parent_rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM taxon_unit_types  ";
            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            szSql += " AND (rank_id=@rank_id )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdDelete.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " kingdom_id";

            szSql += ", rank_id";
            szSql += " FROM taxon_unit_types  ";

            szSql += " WHERE ";
            szSql += "(kingdom_id=@kingdom_id )";
            szSql += " AND (rank_id=@rank_id )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelectExist.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
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
            oSqlCmdSelectExist.Parameters["@rank_id"].Value = m_rank_id;

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
            oSqlCmdUpdate.Parameters["@rank_id"].Value = m_rank_id;
            oSqlCmdUpdate.Parameters["@rank_name"].Value = m_rank_name;
            oSqlCmdUpdate.Parameters["@dir_parent_rank_id"].Value = m_dir_parent_rank_id;
            oSqlCmdUpdate.Parameters["@req_parent_rank_id"].Value = m_req_parent_rank_id;
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
            oSqlCmdInsert.Parameters["@rank_id"].Value = m_rank_id;
            oSqlCmdInsert.Parameters["@rank_name"].Value = m_rank_name;
            oSqlCmdInsert.Parameters["@dir_parent_rank_id"].Value = m_dir_parent_rank_id;
            oSqlCmdInsert.Parameters["@req_parent_rank_id"].Value = m_req_parent_rank_id;
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
        public bool FncSqlFind(int kingdom_id, Int16 rank_id)
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
            oSqlCmdSelect.Parameters["@rank_id"].Value = rank_id;
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
                    m_rank_id = Convert.ToInt16(oDR["rank_id"].ToString());
                    m_rank_name = oDR["rank_name"].ToString();
                    m_dir_parent_rank_id = Convert.ToInt16(oDR["dir_parent_rank_id"].ToString());
                    m_req_parent_rank_id = Convert.ToInt16(oDR["req_parent_rank_id"].ToString());
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
        public bool FncSqlDelete(int kingdom_id, Int16 rank_id)
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
                oSqlCmdDelete.Parameters["@rank_id"].Value = rank_id;
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

        public Int16 rank_id
        {
            set
            {
                m_rank_id = value;
            }
            get { return m_rank_id; }
        }

        //................................

        public String rank_name
        {
            set
            {
                m_rank_name = value;
            }
            get { return m_rank_name; }
        }

        //................................

        public Int16 dir_parent_rank_id
        {
            set
            {
                m_dir_parent_rank_id = value;
            }
            get { return m_dir_parent_rank_id; }
        }

        //................................

        public Int16 req_parent_rank_id
        {
            set
            {
                m_req_parent_rank_id = value;
            }
            get { return m_req_parent_rank_id; }
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
