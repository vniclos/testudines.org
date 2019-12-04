using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_media_gal
    {
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
    
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExistUrlNodePath = new MySqlCommand();
        
        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private Int64 m_DocId = 0;
        private String m_DocLngId = ClsGlobal.default_DocLngId ;
        private String m_UrlNodePath = "";
        private String m_Title = "";
        private String m_Abstract = "";
        private String m_Body = "";
        private bool m_IsVisible_inlist = false;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_media_gal(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_media_gal()
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
            m_DocLngId = ClsGlobal.default_DocLngId;
            m_UrlNodePath = "";
            m_Title = "";
            m_Abstract = "";
            m_Body = "";
            m_IsVisible_inlist = false;
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
            szSql = "SELECT * FROM tdoclng_media_gal  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            
            szSql = "SELECT docid, doclngid  FROM tdoclng_media_gal  ";
            szSql += " WHERE ";
            szSql += "(UrlNodePath=@UrlNodePath )";
            oSqlCmdSelectExistUrlNodePath.CommandText = szSql;
            oSqlCmdSelectExistUrlNodePath.Parameters.Add("@UrlNodePath", MySql.Data.MySqlClient.MySqlDbType.String);
           
            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_media_gal";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", UrlNodePath ";
            szSql += ", Title ";
            szSql += ", Abstract ";
            szSql += ", Body ";
            szSql += ", IsVisible_inlist ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @UrlNodePath ";
            szSql += ", @Title ";
            szSql += ", @Abstract ";
            szSql += ", @Body ";
            szSql += ", @IsVisible_inlist ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@UrlNodePath", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@IsVisible_inlist", MySql.Data.MySqlClient.MySqlDbType.Bit);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_media_gal SET ";

            szSql += "UrlNodePath=@UrlNodePath ";
            szSql += ", Title=@Title ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", Body=@Body ";
            szSql += ", IsVisible_inlist=@IsVisible_inlist ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@UrlNodePath", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@IsVisible_inlist", MySql.Data.MySqlClient.MySqlDbType.Bit);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_media_gal  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", DocLngId";
            szSql += " FROM tdoclng_media_gal  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
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

            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
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
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdUpdate.Parameters["@UrlNodePath"].Value = m_UrlNodePath;
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;
            oSqlCmdUpdate.Parameters["@IsVisible_inlist"].Value = m_IsVisible_inlist;
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
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@UrlNodePath"].Value = m_UrlNodePath;
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;
            oSqlCmdInsert.Parameters["@IsVisible_inlist"].Value = m_IsVisible_inlist;
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
        public bool FncSqlFind(Int64 DocId, String DocLngId)
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
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
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
                    m_DocId = Convert.ToInt32(oDR["DocId"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    m_UrlNodePath = oDR["UrlNodePath"].ToString().Trim();
                    m_Title = oDR["Title"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();
                    m_IsVisible_inlist = Convert.ToBoolean(oDR["IsVisible_inlist"].ToString().Trim());
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

        //
        public bool FncSqlFindUrlNodePath(string  UrlNodePath)
        {
            bool b = false;
            //
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
            oSqlCmdSelectExistUrlNodePath.Parameters["@UrlNodePath"].Value = UrlNodePath;

            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelectExistUrlNodePath.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                oDR = oSqlCmdSelectExistUrlNodePath.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    b = true;
                    m_DocId = Convert.ToInt32(oDR["DocId"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    
                    
                }
                oDR.Close();
                if (b)
                {
                    b = FncSqlFind(m_DocId, m_DocLngId);
                }
                
            }catch (Exception xcpt)
            {
                ErrorBoolean = true;
                ErrorString = xcpt.Message;
                ; }

            return b;
        }
        //--------------------------------------------------------r
        //----------------FncSqlDelete--------------------------
        //--------------------------------------------------------
        public bool FncSqlDelete(Int64 DocId, String DocLngId)
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
                oSqlCmdDelete.Parameters["@DocId"].Value = DocId;
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
        public bool FncSqlExist(Int64 DocId, String DocLngId)
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
            oSqlCmdSelectExist.Parameters["@DocId"].Value = DocId;
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = DocLngId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }

        public string FncHtml()
        {
            return "Pendiente de programar";
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

        public Int64 DocId
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
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngId because is it too long,MaxLength=2";
                }
                m_DocLngId = sz.ToLower ();

            }
            get { return m_DocLngId; }
        }

        //................................

        public String UrlNodePath
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 249)
                {
                    sz = sz.Substring(0, 248);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_UrlNodePath because is it too long,MaxLength=249";
                }
                m_UrlNodePath = sz;

            }
            get { return m_UrlNodePath; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 249)
                {
                    sz = sz.Substring(0, 248);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=249";
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

        public bool IsVisible_inlist
        {
            set
            {
                m_IsVisible_inlist = value;
            }
            get { return m_IsVisible_inlist; }
        }

        #endregion VALORES_GETSET

    }
}
