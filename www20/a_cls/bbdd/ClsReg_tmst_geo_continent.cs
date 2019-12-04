using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tmst_geo_continent
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
        private String m_ContinentId = "";
        private String m_ContinetLngId = "";
        private String m_ContinentName = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tmst_geo_continent(string szSqlConnectionString)
        //{
        public ClsReg_tmst_geo_continent()
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
            m_ContinentId = "";
            m_ContinetLngId = "";
            m_ContinentName = "";
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
            szSql = "SELECT * FROM tmst_geo_continent  ";
            szSql += " WHERE ";
            szSql += "(ContinentId=@ContinentId )";
            szSql += " AND (ContinetLngId=@ContinetLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@ContinentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdSelect.Parameters.Add("@ContinetLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tmst_geo_continent";

            szSql += "(";

            szSql += " ContinentId ";
            szSql += ", ContinetLngId ";
            szSql += ", ContinentName ";
            szSql += " ) VALUES     (";
            szSql += " @ContinentId ";
            szSql += ", @ContinetLngId ";
            szSql += ", @ContinentName ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@ContinentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ContinetLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ContinentName", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tmst_geo_continent SET ";

            szSql += "ContinentName=@ContinentName ";
            szSql += " WHERE ";
            szSql += "(ContinentId=@ContinentId )";
            szSql += " AND (ContinetLngId=@ContinetLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@ContinentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ContinetLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ContinentName", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tmst_geo_continent  ";
            szSql += " WHERE ";
            szSql += "(ContinentId=@ContinentId )";
            szSql += " AND (ContinetLngId=@ContinetLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@ContinentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdDelete.Parameters.Add("@ContinetLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " ContinentId";

            szSql += ", ContinetLngId";
            szSql += " FROM tmst_geo_continent  ";

            szSql += " WHERE ";
            szSql += "(ContinentId=@ContinentId )";
            szSql += " AND (ContinetLngId=@ContinetLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@ContinentId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdSelectExist.Parameters.Add("@ContinetLngId", MySql.Data.MySqlClient.MySqlDbType.String);
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
            if (!ClsMysql.FncOpen(""))
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

            oSqlCmdSelectExist.Parameters["@ContinentId"].Value = m_ContinentId;
            oSqlCmdSelectExist.Parameters["@ContinetLngId"].Value = m_ContinetLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
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
            oSqlCmdUpdate.Parameters["@ContinentId"].Value = m_ContinentId;
            oSqlCmdUpdate.Parameters["@ContinetLngId"].Value = m_ContinetLngId;
            oSqlCmdUpdate.Parameters["@ContinentName"].Value = m_ContinentName;
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
            ClsMysql.FncClose();
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
            oSqlCmdInsert.Parameters["@ContinentId"].Value = m_ContinentId;
            oSqlCmdInsert.Parameters["@ContinetLngId"].Value = m_ContinetLngId;
            oSqlCmdInsert.Parameters["@ContinentName"].Value = m_ContinentName;
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
        public bool FncSqlFind(String ContinentId, String ContinetLngId)
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
            oSqlCmdSelect.Parameters["@ContinentId"].Value = ContinentId;
            oSqlCmdSelect.Parameters["@ContinetLngId"].Value = ContinetLngId;
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
                    m_ContinentId = oDR["ContinentId"].ToString().Trim();
                    m_ContinetLngId = oDR["ContinetLngId"].ToString().Trim();
                    m_ContinentName = oDR["ContinentName"].ToString().Trim();
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
        public bool FncSqlDelete(String ContinentId, String ContinetLngId)
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
                oSqlCmdDelete.Parameters["@ContinentId"].Value = ContinentId;
                oSqlCmdDelete.Parameters["@ContinetLngId"].Value = ContinetLngId;
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
        public bool FncSqlExist(String ContinentId, String ContinetLngId)
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
            oSqlCmdSelectExist.Parameters["@ContinentId"].Value = ContinentId;
            oSqlCmdSelectExist.Parameters["@ContinetLngId"].Value = ContinetLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }
        ////--------------------------------------------------------r
        


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

        public String ContinentId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ContinentId because is it too long,MaxLength=50";
                }
                m_ContinentId = sz;

            }
            get { return m_ContinentId; }
        }

        //................................

        public String ContinetLngId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ContinetLngId because is it too long,MaxLength=2";
                }
                m_ContinetLngId = sz;

            }
            get { return m_ContinetLngId; }
        }

        //................................

        public String ContinentName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ContinentName because is it too long,MaxLength=50";
                }
                m_ContinentName = sz;

            }
            get { return m_ContinentName; }
        }

        #endregion VALORES_GETSET

    }
}
