using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd.itis
{
    //<summary>
    //Descripción breve de ClsRegTaxon_authors_lkp
    //<//summary>
    public class ClsRegTaxon_authors_lkp
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
        private int m_tortoise_author_id = 0;
        private String m_tortoise_author = "";
        private System.DateTime m_update_date = System.DateTime.Now.Date;
        private Int16 m_kingdom_id = 0;
        private String m_short_author = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegTaxon_authors_lkp(string szMySqlConnectionString)
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
            m_tortoise_author_id = 0;
            m_tortoise_author = "";
            m_update_date = System.DateTime.Now.Date;
            m_kingdom_id = 0;
            m_short_author = "";
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
            szSql = "SELECT * FROM taxon_authors_lkp  ";
            szSql += " WHERE ";
            szSql += "(taxon_author_id=@taxon_author_id )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO taxon_authors_lkp";

            szSql += "(";

            szSql += " taxon_author_id ";
            szSql += ", taxon_author ";
            szSql += ", update_date ";
            szSql += ", kingdom_id ";
            szSql += ", short_author ";
            szSql += " ) VALUES     (";
            szSql += " @taxon_author_id ";
            szSql += ", @taxon_author ";
            szSql += ", @update_date ";
            szSql += ", @kingdom_id ";
            szSql += ", @short_author ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@taxon_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@short_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE taxon_authors_lkp SET ";

            szSql += "taxon_author=@taxon_author ";
            szSql += ", update_date=@update_date ";
            szSql += ", kingdom_id=@kingdom_id ";
            szSql += ", short_author=@short_author ";
            szSql += " WHERE ";
            szSql += "(taxon_author_id=@taxon_author_id )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@taxon_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@short_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM taxon_authors_lkp  ";
            szSql += " WHERE ";
            szSql += "(taxon_author_id=@taxon_author_id )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " taxon_author_id";
            szSql += " FROM taxon_authors_lkp  ";

            szSql += " WHERE ";
            szSql += "(taxon_author_id=@taxon_author_id )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
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
            oSqlCmdSelectExist.Parameters["@taxon_author_id"].Value = m_tortoise_author_id;

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
            oSqlCmdUpdate.Parameters["@taxon_author_id"].Value = m_tortoise_author_id;
            oSqlCmdUpdate.Parameters["@taxon_author"].Value = m_tortoise_author;
            oSqlCmdUpdate.Parameters["@update_date"].Value = m_update_date;
            oSqlCmdUpdate.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdUpdate.Parameters["@short_author"].Value = m_short_author;
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
            oSqlCmdInsert.Parameters["@taxon_author_id"].Value = m_tortoise_author_id;
            oSqlCmdInsert.Parameters["@taxon_author"].Value = m_tortoise_author;
            oSqlCmdInsert.Parameters["@update_date"].Value = m_update_date;
            oSqlCmdInsert.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdInsert.Parameters["@short_author"].Value = m_short_author;
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
        public bool FncSqlFind(int taxon_author_id)
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
            oSqlCmdSelect.Parameters["@taxon_author_id"].Value = taxon_author_id;
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
                    m_tortoise_author_id = Convert.ToInt32(oDR["taxon_author_id"].ToString());
                    m_tortoise_author = oDR["taxon_author"].ToString();
                    m_update_date = Convert.ToDateTime(oDR["update_date"].ToString());
                    m_kingdom_id = Convert.ToInt16(oDR["kingdom_id"].ToString());
                    m_short_author = oDR["short_author"].ToString();
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
        public bool FncSqlDelete(int taxon_author_id)
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
                oSqlCmdDelete.Parameters["@taxon_author_id"].Value = taxon_author_id;
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

        public int taxon_author_id
        {
            set
            {
                m_tortoise_author_id = value;
            }
            get { return m_tortoise_author_id; }
        }

        //................................

        public String taxon_author
        {
            set
            {
                m_tortoise_author = value;
            }
            get { return m_tortoise_author; }
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

        //................................

        public Int16 kingdom_id
        {
            set
            {
                m_kingdom_id = value;
            }
            get { return m_kingdom_id; }
        }

        //................................

        public String short_author
        {
            set
            {
                m_short_author = value;
            }
            get { return m_short_author; }
        }

        #endregion VALORES_GETSET

    }
}
