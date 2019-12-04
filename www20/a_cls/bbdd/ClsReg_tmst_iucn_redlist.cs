using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tmst_iucn_redlist
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
        private UInt64 m_RL_levelID = 0;
        private String m_DocLngId = "";
        private String m_RL_Key = "";
        private String m_Title = "";
        private String m_Abstract = "";
        private String m_Body = "";
        private String m_URL_Ref = "";
        private String m_UrlImg = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tmst_iucn_redlist(string szSqlConnectionString)
        //{
        public ClsReg_tmst_iucn_redlist()
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
            m_RL_levelID = 0;
            m_DocLngId = "";
            m_RL_Key = "";
            m_Title = "";
            m_Abstract = "";
            m_Body = "";
            m_URL_Ref = "";
            m_UrlImg = "";
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
            szSql = "SELECT * FROM tmst_iucn_redlist  ";
            szSql += " WHERE ";
            szSql += "(RL_levelID=@RL_levelID )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@RL_levelID", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tmst_iucn_redlist";

            szSql += "(";

            szSql += " RL_levelID ";
            szSql += ", DocLngId ";
            szSql += ", RL_Key ";
            szSql += ", Title ";
            szSql += ", Abstract ";
            szSql += ", Body ";
            szSql += ", URL_Ref ";
            szSql += ", UrlImg ";
            szSql += " ) VALUES     (";
            szSql += " @RL_levelID ";
            szSql += ", @DocLngId ";
            szSql += ", @RL_Key ";
            szSql += ", @Title ";
            szSql += ", @Abstract ";
            szSql += ", @Body ";
            szSql += ", @URL_Ref ";
            szSql += ", @UrlImg ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@RL_levelID", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@RL_Key", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@URL_Ref", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@UrlImg", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tmst_iucn_redlist SET ";

            szSql += "RL_Key=@RL_Key ";
            szSql += ", Title=@Title ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", Body=@Body ";
            szSql += ", URL_Ref=@URL_Ref ";
            szSql += ", UrlImg=@UrlImg ";
            szSql += " WHERE ";
            szSql += "(RL_levelID=@RL_levelID )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@RL_levelID", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@RL_Key", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@URL_Ref", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@UrlImg", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tmst_iucn_redlist  ";
            szSql += " WHERE ";
            szSql += "(RL_levelID=@RL_levelID )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@RL_levelID", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " RL_levelID";

            szSql += ", DocLngId";
            szSql += " FROM tmst_iucn_redlist  ";

            szSql += " WHERE ";
            szSql += "(RL_levelID=@RL_levelID )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@RL_levelID", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
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

            oSqlCmdSelectExist.Parameters["@RL_levelID"].Value = m_RL_levelID;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;

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
            oSqlCmdUpdate.Parameters["@RL_levelID"].Value = m_RL_levelID;
            oSqlCmdUpdate.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdUpdate.Parameters["@RL_Key"].Value = m_RL_Key;
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;
            oSqlCmdUpdate.Parameters["@URL_Ref"].Value = m_URL_Ref;
            oSqlCmdUpdate.Parameters["@UrlImg"].Value = m_UrlImg;
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
            oSqlCmdInsert.Parameters["@RL_levelID"].Value = m_RL_levelID;
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@RL_Key"].Value = m_RL_Key;
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;
            oSqlCmdInsert.Parameters["@URL_Ref"].Value = m_URL_Ref;
            oSqlCmdInsert.Parameters["@UrlImg"].Value = m_UrlImg;
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
        public bool FncSqlFind(UInt64 RL_levelID, String DocLngId)
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
            oSqlCmdSelect.Parameters["@RL_levelID"].Value = RL_levelID;
            oSqlCmdSelect.Parameters["@DocLngId"].Value = DocLngId;
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
                    m_RL_levelID = Convert.ToUInt64(oDR["RL_levelID"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    m_RL_Key = oDR["RL_Key"].ToString().Trim();
                    m_Title = oDR["Title"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();
                    m_URL_Ref = oDR["URL_Ref"].ToString().Trim();
                    m_UrlImg = oDR["UrlImg"].ToString().Trim();
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
        public bool FncSqlDelete(UInt64 RL_levelID, String DocLngId)
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
                oSqlCmdDelete.Parameters["@RL_levelID"].Value = RL_levelID;
                oSqlCmdDelete.Parameters["@DocLngId"].Value = DocLngId;
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
        public bool FncSqlExist(UInt64 RL_levelID, String DocLngId)
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
            oSqlCmdSelectExist.Parameters["@RL_levelID"].Value = RL_levelID;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = DocLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }////--------------------------------------------------------r
        ////----------------FncSqlOpenCnn--------------------------
        ////--------------------------------------------------------

       
        public  string FncHtml()
        {
            StringBuilder sb = new StringBuilder();
        sb.Append ("<h2>"+Title + "</h2>");
        sb.Append ("<img src=\"" +m_UrlImg +"\"/>");
        sb.Append("<br/>"+ m_Abstract );
        sb.Append("<br/>" + m_Body);

        return sb.ToString();
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

        public UInt64 RL_levelID
        {
            set
            {
                m_RL_levelID = value;
            }
            get { return m_RL_levelID; }
        }

        //................................

        public String DocLngId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngId because is it too long,MaxLength=2";
                }
                m_DocLngId = sz.ToLower();

            }
            get { return m_DocLngId; }
        }

        //................................

        public String RL_Key
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_RL_Key because is it too long,MaxLength=2";
                }
                m_RL_Key = sz;

            }
            get { return m_RL_Key; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=50";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String Abstract
        {
            set
            {
                m_Abstract = value;
            }
            get { return m_Abstract; }
        }

        //................................

        public String Body
        {
            set
            {
                m_Body = value;
            }
            get { return m_Body; }
        }

        //................................

        public String URL_Ref
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_URL_Ref because is it too long,MaxLength=50";
                }
                m_URL_Ref = sz;

            }
            get { return m_URL_Ref; }
        }

        //................................

        public String UrlImg
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_UrlImg because is it too long,MaxLength=50";
                }
                m_UrlImg = sz;

            }
            get { return m_UrlImg; }
        }

        #endregion VALORES_GETSET

    }
}
