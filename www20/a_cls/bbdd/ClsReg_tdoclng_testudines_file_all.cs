using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_testudines_file_all
    {
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";

        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdIdDocByUrl = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectATaxIdName = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_FileSeccId = "";
        private String m_AFileType = "";
        private String m_AFileURL = "";
        private String m_AFileNote = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_testudines_file_all(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_testudines_file_all()
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
            m_FileSeccId = "";
            m_AFileType = "";
            m_AFileURL = "";
            m_AFileNote = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_file_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (FileSeccId=@FileSeccId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@FileSeccId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_file_all";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", FileSeccId ";
            szSql += ", AFileType ";
            szSql += ", AFileURL ";
            szSql += ", AFileNote ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @FileSeccId ";
            szSql += ", @AFileType ";
            szSql += ", @AFileURL ";
            szSql += ", @AFileNote ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@FileSeccId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@AFileType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@AFileURL", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@AFileNote", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_file_all SET ";

            szSql += "AFileType=@AFileType ";
            szSql += ", AFileURL=@AFileURL ";
            szSql += ", AFileNote=@AFileNote ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (FileSeccId=@FileSeccId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@FileSeccId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@AFileType", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@AFileURL", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@AFileNote", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_file_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (FileSeccId=@FileSeccId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdDelete.Parameters.Add("@FileSeccId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", FileSeccId";
            szSql += " FROM tdoclng_testudines_file_all  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (FileSeccId=@FileSeccId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelectExist.Parameters.Add("@FileSeccId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  AFileURL ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";
            szSql += " FROM tdoclng_testudines_file_all  ";
            szSql += " WHERE ";
            szSql += " AFileURL=@AFileURL ";
            oSqlCmdIdDocByUrl.CommandText = szSql;

            oSqlCmdIdDocByUrl.Parameters.Add("@AFileURL", MySql.Data.MySqlClient.MySqlDbType.String);

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



            // Atencion en caso de claves alternativas

            // añadir una fucion que la controle

            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdSelectExist.Parameters["@FileSeccId"].Value = m_FileSeccId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection; ;
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
            oSqlCmdUpdate.Parameters["@FileSeccId"].Value = m_FileSeccId;
            oSqlCmdUpdate.Parameters["@AFileType"].Value = m_AFileType;
            oSqlCmdUpdate.Parameters["@AFileURL"].Value = m_AFileURL;
            oSqlCmdUpdate.Parameters["@AFileNote"].Value = m_AFileNote;
            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdUpdate.Connection = ClsMysql.MySqlConnection; ;
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
            oSqlCmdInsert.Parameters["@FileSeccId"].Value = m_FileSeccId;
            oSqlCmdInsert.Parameters["@AFileType"].Value = m_AFileType;
            oSqlCmdInsert.Parameters["@AFileURL"].Value = m_AFileURL;
            oSqlCmdInsert.Parameters["@AFileNote"].Value = m_AFileNote;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection; ;
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
        public UInt64 FncSqlFindIdDocByUrl(string pAFileURL)
        {
            UInt64 iDocId = 0;
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------

            if (!ClsMysql.FncOpen(""))
                return 0;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdIdDocByUrl.Parameters["@AFileURL"].Value = pAFileURL;
            //----------------------------------------------------

            try
            {
                oSqlCmdIdDocByUrl.Connection = ClsMysql.MySqlConnection; ;
                ClsMysql.FncOpen("");

                iDocId = Convert.ToUInt64(oSqlCmdIdDocByUrl.ExecuteScalar().ToString());
            }
            catch
            {
                return 0;
            }


            return iDocId;
        }
        public bool FncSqlFind(UInt64 DocId, String FileSeccId)
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
            oSqlCmdSelect.Parameters["@FileSeccId"].Value = FileSeccId;
            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection; ;
                ClsMysql.FncOpen("");
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_FileSeccId = oDR["FileSeccId"].ToString().Trim();
                    m_AFileType = oDR["AFileType"].ToString().Trim();
                    m_AFileURL = oDR["AFileURL"].ToString().Trim();
                    m_AFileNote = oDR["AFileNote"].ToString().Trim();
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

        public bool FncSqlFind(string pATaxIdName, String pDocLngId)
        {
            //szSql = "SELECT DocId FROM tdoclng_testudines_groups  ";                                             
            //szSql += " WHERE ";                                                                            
            //szSql += "(ATaxIdName=@ATaxIdName )";                                                          
            //szSql += " AND (DocLngId=@DocLngId )";                                                         
            //oSqlCmdSelectATaxIdName.CommandText = szSql;                                                   
            //oSqlCmdSelectATaxIdName.Parameters.Add("@ATaxIdName", MySql.Data.MySqlClient.MySqlDbType.String);
            //oSqlCmdSelectATaxIdName.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);

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

            //----------------------------------------------------
            string szDocId = "";
            UInt64 iDocId = 0;
            try
            {
                oSqlCmdSelectATaxIdName.Connection = ClsMysql.MySqlConnection; ;
                oSqlCmdSelectATaxIdName.Parameters["@DocLngId"].Value = pDocLngId;
                oSqlCmdSelectATaxIdName.Parameters["@ATaxIdName"].Value = pATaxIdName;

                ClsMysql.FncOpen("");
                szDocId = oSqlCmdSelectATaxIdName.ExecuteScalar().ToString();
                iDocId = Convert.ToUInt64(szDocId);
                _mErrorBoolean = !FncSqlFind(iDocId, pDocLngId);
            }
            catch (Exception xcpt)
            {
                _mErrorBoolean = false;
                _mErrorString = xcpt.Message;

            }
            return !_mErrorBoolean;



        }
        //--------------------------------------------------------r
        //----------------FncSqlDelete--------------------------
        //--------------------------------------------------------
        public bool FncSqlDelete(UInt64 DocId, String FileSeccId)
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
            oSqlCmdDelete.Connection = ClsMysql.MySqlConnection; ;
            try
            {
                oSqlCmdDelete.Parameters["@DocId"].Value = DocId;
                oSqlCmdDelete.Parameters["@FileSeccId"].Value = FileSeccId;
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
        public bool FncSqlDeleteFiles(UInt64 DocId)
        {

            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen("")) return false;
            //-----------------------------------------------------;
            // ELIMINAR REGISTRO. 
            //-------------------------------------------------------;
            string szSql = "Delete from tdoclng_testudines_file_all where docid=" + DocId.ToString();
            MySqlCommand oCmdDelete = new MySqlCommand(szSql, ClsMysql.MySqlConnection);
            oSqlCmdDelete.Connection = ClsMysql.MySqlConnection; ;
            try
            {
                oCmdDelete.ExecuteNonQuery();

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
        public bool FncSqlExist(UInt64 DocId, String FileSeccId)
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
            oSqlCmdSelectExist.Parameters["@FileSeccId"].Value = FileSeccId;

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection; ;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }


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

        public String FileSeccId
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 30)
                {
                    sz = sz.Substring(0, 29);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_FileSeccId because is it too long,MaxLength=30";
                }
                m_FileSeccId = sz;

            }
            get { return m_FileSeccId; }
        }

        //................................

        public String AFileType
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 3)
                {
                    sz = sz.Substring(0, 2);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_AFileType because is it too long,MaxLength=3";
                }
                m_AFileType = sz;

            }
            get { return m_AFileType; }
        }

        //................................

        public String AFileURL
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_AFileURL because is it too long,MaxLength=250";
                }
                m_AFileURL = sz;

            }
            get { return m_AFileURL; }
        }

        //................................

        public String AFileNote
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 80)
                {
                    sz = sz.Substring(0, 79);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_AFileNote because is it too long,MaxLength=80";
                }
                m_AFileNote = sz;

            }
            get { return m_AFileNote; }
        }

        #endregion VALORES_GETSET
        //##############################################################333
        //##############################################################333
        //##############################################################333
        //##############################################################333
        //##############################################################333
        #region  valores de un taxon
        private UInt64 m_DocIdGroup = 0;
        private string m_AAbsImg_Specie = "";
        private string m_AAbsImg_HNatural = "";
        private string m_AAbsImg_Range = "";

        private string m_ACareImg_Breeding01 = "";
        private string m_ACareImg_Breeding02 = "";
        private string m_ACareImg_Breeding03 = "";
        private string m_ACareImg_Food01 = "";
        private string m_ACareImg_Food02 = "";
        private string m_ACareImg_Food03 = "";
        private string m_ACareImg_VivariumIndoor01 = "";
        private string m_ACareImg_VivariumIndoor02 = "";
        private string m_ACareImg_VivariumIndoor03 = "";
        private string m_ACareImg_VivariumOutdoor01 = "";
        private string m_ACareImg_VivariumOutdoor02 = "";
        private string m_ACareImg_VivariumOutdoor03 = "";

        private string m_ADesImg_DesKeys01 = "";
        private string m_ADesImg_DesKeys02 = "";
        private string m_ADesImg_DesKeys03 = "";

        private string m_ADesImg_DesType01 = "";
        private string m_ADesImg_DesType02 = "";
        private string m_ADesImg_DesType03 = "";
        private string m_ADesImg_BabyDorsal01 = "";
        private string m_ADesImg_BabyDorsal02 = "";
        private string m_ADesImg_BabyDorsal03 = "";
        private string m_ADesImg_BabyVentral01 = "";
        private string m_ADesImg_BabyVentral02 = "";
        private string m_ADesImg_BabyVentral03 = "";

        private string m_ADesImg_BodyBridge01 = "";
        private string m_ADesImg_BodyBridge02 = "";
        private string m_ADesImg_BodyBridge03 = "";
        private string m_ADesImg_BodyDorsal01 = "";
        private string m_ADesImg_BodyDorsal02 = "";
        private string m_ADesImg_BodyDorsal03 = "";
        private string m_ADesImg_BodyFrontal01 = "";
        private string m_ADesImg_BodyFrontal02 = "";
        private string m_ADesImg_BodyFrontal03 = "";
        private string m_ADesImg_BodyLateral01 = "";
        private string m_ADesImg_BodyLateral02 = "";
        private string m_ADesImg_BodyLateral03 = "";
        private string m_ADesImg_BodyRear01 = "";
        private string m_ADesImg_BodyRear02 = "";
        private string m_ADesImg_BodyRear03 = "";
        private string m_ADesImg_BodyVentral01 = "";
        private string m_ADesImg_BodyVentral02 = "";
        private string m_ADesImg_BodyVentral03 = "";
        private string m_ADesImg_Dimorphism01 = "";
        private string m_ADesImg_Dimorphism02 = "";
        private string m_ADesImg_Dimorphism03 = "";
        private string m_ADesImg_Holotype01 = "";
        private string m_ADesImg_Holotype02 = "";
        private string m_ADesImg_Holotype03 = "";

        private string m_ADesImg_OtherHead01 = "";
        private string m_ADesImg_OtherHead02 = "";
        private string m_ADesImg_OtherHead03 = "";
        private string m_ADesImg_OtherLegs01 = "";
        private string m_ADesImg_OtherLegs02 = "";
        private string m_ADesImg_OtherLegs03 = "";
        private string m_ADesImg_OtherTail01 = "";
        private string m_ADesImg_OtherTail02 = "";
        private string m_ADesImg_OtherTail03 = "";

        private string m_ADesImg_Diferentiation01 = "";
        private string m_ADesImg_Diferentiation02 = "";
        private string m_ADesImg_Diferentiation03 = "";
        private string m_AGeoImg_ClimateEcozoneKey = "";
        private string m_AGeoImg_ClimateWheatherBiome = "";
        private string m_AGeoImg_ClimateWheatherRain = "";
        private string m_AGeoImg_ClimateWheatherSun = "";
        private string m_AGeoImg_ClimateWheatherTemp = "";
        private string m_AGeoImg_GeoRangeMapStandardDetailMin = "";
        private string m_AGeoImg_GeoRangeMapStandardDetailFul = "";
        private string m_AGeoImg_GeoRangeMapStandardWorldFul = "";
        private string m_AGeoImg_GeoRangeMapStandardWorldFull = "";
        private string m_AGeoImg_GeoRangeMapStandardKoppenFul = "";
        private string m_AGeoImg_GeoRangeMapStandardKoppenMin = "";

        private string m_AGeoImg_landscapes01 = "";
        private string m_AGeoImg_landscapes02 = "";
        private string m_AGeoImg_landscapes03 = "";
        private string m_ANatImg_Breeding01 = "";
        private string m_ANatImg_Breeding02 = "";
        private string m_ANatImg_Breeding03 = "";
        private string m_ANatImg_Food01 = "";
        private string m_ANatImg_Food02 = "";
        private string m_ANatImg_Food03 = "";
        private string m_ANatImg_Live01 = "";
        private string m_ANatImg_Live02 = "";
        private string m_ANatImg_Live03 = "";
        private string m_ACareImg_gral01 = "";
        private string m_ACareImg_gral02 = "";
        private string m_ACareImg_gral03 = "";


        public void FncGroupFilesClear()
        {



            m_AAbsImg_HNatural = "";
            m_AAbsImg_Range = "";
            m_ACareImg_Breeding01 = "";
            m_ACareImg_Breeding02 = "";
            m_ACareImg_Breeding03 = "";
            m_ACareImg_Food01 = "";
            m_ACareImg_Food02 = "";
            m_ACareImg_Food03 = "";
            m_ACareImg_VivariumIndoor01 = "";
            m_ACareImg_VivariumIndoor02 = "";
            m_ACareImg_VivariumIndoor03 = "";
            m_ACareImg_VivariumOutdoor01 = "";
            m_ACareImg_VivariumOutdoor02 = "";
            m_ACareImg_VivariumOutdoor03 = "";
            m_ADesImg_DesKeys01 = "";
            m_ADesImg_DesKeys02= "";
                m_ADesImg_DesKeys03 = "";
            m_ADesImg_DesType01 = "";
            m_ADesImg_DesType02 = "";
            m_ADesImg_DesType03 = "";
            m_ADesImg_BabyDorsal01 = "";
            m_ADesImg_BabyDorsal02 = "";
            m_ADesImg_BabyDorsal03 = "";
            m_ADesImg_BabyVentral01 = "";
            m_ADesImg_BabyVentral02 = "";
            m_ADesImg_BabyVentral03 = "";
            m_ADesImg_BodyBridge01 = "";
            m_ADesImg_BodyBridge02 = "";
            m_ADesImg_BodyBridge03 = "";
            m_ADesImg_BodyDorsal01 = "";
            m_ADesImg_BodyDorsal02 = "";
            m_ADesImg_BodyDorsal03 = "";
            m_ADesImg_BodyFrontal01 = "";
            m_ADesImg_BodyFrontal02 = "";
            m_ADesImg_BodyFrontal03 = "";
            m_ADesImg_BodyLateral01 = "";
            m_ADesImg_BodyLateral02 = "";
            m_ADesImg_BodyLateral03 = "";
            m_ADesImg_BodyRear01 = "";
            m_ADesImg_BodyRear02 = "";
            m_ADesImg_BodyRear03 = "";
            m_ADesImg_BodyVentral01 = "";
            m_ADesImg_BodyVentral02 = "";
            m_ADesImg_BodyVentral03 = "";
            m_ADesImg_Dimorphism01 = "";
            m_ADesImg_Dimorphism02 = "";
            m_ADesImg_Dimorphism03 = "";
            m_ADesImg_Holotype01 = "";
            m_ADesImg_Holotype02 = "";
            m_ADesImg_Holotype03 = "";
            m_ADesImg_OtherHead01 = "";
            m_ADesImg_OtherHead02 = "";
            m_ADesImg_OtherHead03 = "";
            m_ADesImg_OtherLegs01 = "";
            m_ADesImg_OtherLegs02 = "";
            m_ADesImg_OtherLegs03 = "";
            m_ADesImg_OtherTail01 = "";
            m_ADesImg_OtherTail02 = "";
            m_ADesImg_OtherTail03 = "";
            m_AGeoImg_ClimateEcozoneKey = "";
            m_AGeoImg_ClimateWheatherBiome = "";
            m_AGeoImg_ClimateWheatherRain = "";
            m_AGeoImg_ClimateWheatherSun = "";
            m_AGeoImg_ClimateWheatherTemp = "";
            m_AGeoImg_GeoRangeMapStandardDetailFul = "";
            m_AGeoImg_GeoRangeMapStandardDetailMin = "";
            m_AGeoImg_GeoRangeMapStandardWorldFul = "";
            m_AGeoImg_GeoRangeMapStandardWorldFull = "";
            m_AGeoImg_GeoRangeMapStandardKoppenFul = "";
            m_AGeoImg_GeoRangeMapStandardKoppenMin = "";

            m_AGeoImg_landscapes01 = "";
            m_AGeoImg_landscapes02 = "";
            m_AGeoImg_landscapes03 = "";
            m_ANatImg_Breeding01 = "";
            m_ANatImg_Breeding02 = "";
            m_ANatImg_Breeding03 = "";
            m_ANatImg_Food01 = "";
            m_ANatImg_Food02 = "";
            m_ANatImg_Food03 = "";
            m_ANatImg_Live01 = "";
            m_ANatImg_Live02 = "";
            m_ANatImg_Live03 = "";
            m_ADesImg_Diferentiation01 = "";
            m_ADesImg_Diferentiation02 = "";
            m_ADesImg_Diferentiation03 = "";
            m_ACareImg_gral01 = "";
            m_ACareImg_gral02 = "";
            m_ACareImg_gral03 = "";


            m_DocIdGroup = 0;

        }

        public void FncGroupFilesGet(UInt64 DocIdGroup)
        {
     

            string szSql = "select  FileSeccId, AFileURL from tdoclng_testudines_file_all where docid=" + DocIdGroup.ToString() + " order by FileSeccId";
            DataTable oTb = new DataTable();
            FncGroupFilesClear();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSql, ref oTb);


    
            string szOption = "";
            string szUrl = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                szOption = oRow["FileSeccId"].ToString().Trim();
                szUrl = oRow["AFileURL"].ToString().Trim();
                switch (szOption)
                {
                    case "AAbsImg_Specie":
                        m_AAbsImg_Specie = szUrl;
                        break;
                    case "AAbsImg_HNatural":
                        m_AAbsImg_HNatural = szUrl;
                        break;
                    case "AAbsImg_Range":
                        m_AAbsImg_Range = szUrl;
                        break;

                    case "ACareImg_Breeding01":
                        m_ACareImg_Breeding01 = szUrl;
                        break;
                    case "ACareImg_Breeding02":
                        m_ACareImg_Breeding02 = szUrl;
                        break;
                    case "ACareImg_Breeding03":
                        m_ACareImg_Breeding03 = szUrl;
                        break;
                    case "ACareImg_Food01":
                        m_ACareImg_Food01 = szUrl;
                        break;
                    case "ACareImg_Food02":
                        m_ACareImg_Food02 = szUrl;
                        break;
                    case "ACareImg_Food03":
                        m_ACareImg_Food03 = szUrl;
                        break;
                    case "ACareImg_VivariumIndoor01":
                        m_ACareImg_VivariumIndoor01 = szUrl;
                        break;
                    case "ACareImg_VivariumIndoor02":
                        m_ACareImg_VivariumIndoor02 = szUrl;
                        break;
                    case "ACareImg_VivariumIndoor03":
                        m_ACareImg_VivariumIndoor03 = szUrl;
                        break;
                    case "ACareImg_VivariumOutdoor01":
                        m_ACareImg_VivariumOutdoor01 = szUrl;
                        break;
                    case "ACareImg_VivariumOutdoor02":
                        m_ACareImg_VivariumOutdoor02 = szUrl;
                        break;
                    case "ACareImg_VivariumOutdoor03":
                        m_ACareImg_VivariumOutdoor03 = szUrl;
                        break;

                        
                        case "ADesImg_DesKeys01":
                        m_ADesImg_DesKeys01 = szUrl;
                        break;
                    case "ADesImg_DesKeys02":
                        m_ADesImg_DesKeys02 = szUrl;
                        break;
                    case "ADesImg_DesKeys03":
                        m_ADesImg_DesKeys03 = szUrl;
                        break;

                    case "ADesImg_DesType01":
                        m_ADesImg_DesType01 = szUrl;
                        break;
                    case "ADesImg_DesType02":
                        m_ADesImg_DesType02 = szUrl;
                        break;
                    case "ADesImg_DesType03":
                        m_ADesImg_DesType03 = szUrl;
                        break;

                    case "ADesImg_BabyDorsal01":
                        m_ADesImg_BabyDorsal01 = szUrl;
                        break;
                    case "ADesImg_BabyDorsal02":
                        m_ADesImg_BabyDorsal02 = szUrl;
                        break;
                    case "ADesImg_BabyDorsal03":
                        m_ADesImg_BabyDorsal03 = szUrl;
                        break;
                    case "ADesImg_BabyVentral01":
                        m_ADesImg_BabyVentral01 = szUrl;
                        break;
                    case "ADesImg_BabyVentral02":
                        m_ADesImg_BabyVentral02 = szUrl;
                        break;
                    case "ADesImg_BabyVentral03":
                        m_ADesImg_BabyVentral03 = szUrl;
                        break;
                    case "ADesImg_BodyBridge01":
                        m_ADesImg_BodyBridge01 = szUrl;
                        break;
                    case "ADesImg_BodyBridge02":
                        m_ADesImg_BodyBridge02 = szUrl;
                        break;
                    case "ADesImg_BodyBridge03":
                        m_ADesImg_BodyBridge03 = szUrl;
                        break;
                    case "ADesImg_BodyDorsal01":
                        m_ADesImg_BodyDorsal01 = szUrl;
                        break;
                    case "ADesImg_BodyDorsal02":
                        m_ADesImg_BodyDorsal02 = szUrl;
                        break;
                    case "ADesImg_BodyDorsal03":
                        m_ADesImg_BodyDorsal03 = szUrl;
                        break;
                    case "ADesImg_BodyFrontal01":
                        m_ADesImg_BodyFrontal01 = szUrl;
                        break;
                    case "ADesImg_BodyFrontal02":
                        m_ADesImg_BodyFrontal02 = szUrl;
                        break;
                    case "ADesImg_BodyFrontal03":
                        m_ADesImg_BodyFrontal03 = szUrl;
                        break;
                    case "ADesImg_BodyLateral01":
                        m_ADesImg_BodyLateral01 = szUrl;
                        break;
                    case "ADesImg_BodyLateral02":
                        m_ADesImg_BodyLateral02 = szUrl;
                        break;
                    case "ADesImg_BodyLateral03":
                        m_ADesImg_BodyLateral03 = szUrl;
                        break;
                    case "ADesImg_BodyRear01":
                        m_ADesImg_BodyRear01 = szUrl;
                        break;
                    case "ADesImg_BodyRear02":
                        m_ADesImg_BodyRear02 = szUrl;
                        break;
                    case "ADesImg_BodyRear03":
                        m_ADesImg_BodyRear03 = szUrl;
                        break;
                    case "ADesImg_BodyVentral01":
                        m_ADesImg_BodyVentral01 = szUrl;
                        break;
                    case "ADesImg_BodyVentral02":
                        m_ADesImg_BodyVentral02 = szUrl;
                        break;
                    case "ADesImg_BodyVentral03":
                        m_ADesImg_BodyVentral03 = szUrl;
                        break;
                    case "ADesImg_Dimorphism01":
                        m_ADesImg_Dimorphism01 = szUrl;
                        break;
                    case "ADesImg_Dimorphism02":
                        m_ADesImg_Dimorphism02 = szUrl;
                        break;
                    case "ADesImg_Dimorphism03":
                        m_ADesImg_Dimorphism03 = szUrl;
                        break;
                    case "ADesImg_Holotype01":
                        m_ADesImg_Holotype01 = szUrl;
                        break;
                    case "ADesImg_Holotype02":
                        m_ADesImg_Holotype02 = szUrl;
                        break;
                    case "ADesImg_Holotype03":
                        m_ADesImg_Holotype03 = szUrl;
                        break;
                    case "ADesImg_OtherHead01":
                        m_ADesImg_OtherHead01 = szUrl;
                        break;
                    case "ADesImg_OtherHead02":
                        m_ADesImg_OtherHead02 = szUrl;
                        break;
                    case "ADesImg_OtherHead03":
                        m_ADesImg_OtherHead03 = szUrl;
                        break;
                    case "ADesImg_OtherLegs01":
                        m_ADesImg_OtherLegs01 = szUrl;
                        break;
                    case "ADesImg_OtherLegs02":
                        m_ADesImg_OtherLegs02 = szUrl;
                        break;
                    case "ADesImg_OtherLegs03":
                        m_ADesImg_OtherLegs03 = szUrl;
                        break;
                    case "ADesImg_OtherTail01":
                        m_ADesImg_OtherTail01 = szUrl;
                        break;
                    case "ADesImg_OtherTail02":
                        m_ADesImg_OtherTail02 = szUrl;
                        break;
                    case "ADesImg_OtherTail03":
                        m_ADesImg_OtherTail03 = szUrl;
                        break;
                    case "ADesImg_Diferentiation01":
                        m_ADesImg_Diferentiation01 = szUrl;
                        break;
                    case "ADesImg_Diferentiation02":
                        m_ADesImg_Diferentiation02 = szUrl;
                        break;
                    case "ADesImg_Diferentiation03":
                        m_ADesImg_Diferentiation03 = szUrl;
                        break;
                    case "AGeoImg_ClimateEcozoneKey":
                        m_AGeoImg_ClimateEcozoneKey = szUrl;
                        break;
                    case "AGeoImg_ClimateWheatherBiome":
                        m_AGeoImg_ClimateWheatherBiome = szUrl;
                        break;
                    case "AGeoImg_ClimateWheatherRain":
                        m_AGeoImg_ClimateWheatherRain = szUrl;
                        break;
                    case "AGeoImg_ClimateWheatherSun":
                        m_AGeoImg_ClimateWheatherSun = szUrl;
                        break;

                    case "AGeoImg_ClimateWheatherTemp":
                        m_AGeoImg_ClimateWheatherTemp = szUrl;
                        break;

                    case "AGeoImg_GeoRangeMapStandardWorldFul":
                        m_AGeoImg_GeoRangeMapStandardWorldFul = szUrl;
                        break;
                    case "AGeoImg_GeoRangeMapStandardWorldFull":
                        m_AGeoImg_GeoRangeMapStandardWorldFull = szUrl;
                        break;

                    case "AGeoImg_GeoRangeMapStandardDetailFul":
                        m_AGeoImg_GeoRangeMapStandardDetailFul = szUrl;
                        break;
                    case "AGeoImg_GeoRangeMapStandardDetailMin":
                        m_AGeoImg_GeoRangeMapStandardDetailMin = szUrl;
                        break;
                    case "AGeoImg_GeoRangeMapStandardKoppenMin":
                        m_AGeoImg_GeoRangeMapStandardKoppenMin = szUrl;
                        break;

                    case "AGeoImg_GeoRangeMapStandardKoppenFul":
                        m_AGeoImg_GeoRangeMapStandardKoppenFul = szUrl;
                        break;



                    case "AGeoImg_landscapes01":
                        m_AGeoImg_landscapes01 = szUrl;
                        break;
                    case "AGeoImg_landscapes02":
                        m_AGeoImg_landscapes02 = szUrl;
                        break;
                    case "AGeoImg_landscapes03":
                        m_AGeoImg_landscapes03 = szUrl;
                        break;
                    case "ANatImg_Breeding01":
                        m_ANatImg_Breeding01 = szUrl;
                        break;
                    case "ANatImg_Breeding02":
                        m_ANatImg_Breeding02 = szUrl;
                        break;
                    case "ANatImg_Breeding03":
                        m_ANatImg_Breeding03 = szUrl;
                        break;
                    case "ANatImg_Food01":
                        m_ANatImg_Food01 = szUrl;
                        break;
                    case "ANatImg_Food02":
                        m_ANatImg_Food02 = szUrl;
                        break;
                    case "ANatImg_Food03":
                        m_ANatImg_Food03 = szUrl;
                        break;
                    case "ANatImg_Live01":
                        m_ANatImg_Live01 = szUrl;
                        break;
                    case "ANatImg_Live02":
                        m_ANatImg_Live02 = szUrl;
                        break;
                    case "ANatImg_Live03":
                        m_ANatImg_Live03 = szUrl;
                        break;

                    case "ACareImg_gral01":
                        m_ACareImg_gral01 = szUrl;
                        break;
                    case "ACareImg_gral02":
                        m_ACareImg_gral02 = szUrl;
                        break;
                    case "ACareImg_gral03":
                        m_ACareImg_gral03 = szUrl;

                        break;
                    default:
                        break;
                }
            }

        }
        public bool FncGroupFilesSet(UInt64 DocIdGroup)
        {
            //FncSqlDeleteFiles(DocIdGroup);
            ClsMysql.FncOpen("");
            //------------------------
            // Eliminar por si hubiera cambios
            // esto esta comentado pues si estan viendo la web, a ojos de visitante
            //hace que incomprensiblemente las imagenes aparezcan y desaparecan durante la actualizacion.
            // la ventaja descomentarlo es que deja el registro limpio
            //-----------------------------------
            //string szSqlDelete="Delete from tdoclng_testudines_file_all where docid="+ DocIdGroup.ToString()
            //MySqlCommand oCmdDeleteFile = new MySqlCommand(szSqlDelete, oSqlCnn);
            //oCmdDeleteFile.ExecuteNonQuery();
            //oCmdDeleteFile.Dispose ();
            //-------------------
            ClsMysql.FncOpen("");
            oSqlCmdUpdate.Connection = ClsMysql.MySqlConnection; ;
            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection; ;
            oSqlCmdInsert.Connection = ClsMysql.MySqlConnection; ;

            m_AFileType = "image";
            m_DocId = DocIdGroup;
            m_AFileNote = "";

            FncGroupFileSet("AAbsImg_Specie", m_AAbsImg_Specie);
            FncGroupFileSet("AAbsImg_HNatural", m_AAbsImg_HNatural);
            FncGroupFileSet("AAbsImg_Range", m_AAbsImg_Range);
            FncGroupFileSet("ACareImg_Breeding01", m_ACareImg_Breeding01);
            FncGroupFileSet("ACareImg_Breeding02", m_ACareImg_Breeding02);
            FncGroupFileSet("ACareImg_Breeding03", m_ACareImg_Breeding03);
            FncGroupFileSet("ACareImg_Food01", m_ACareImg_Food01);
            FncGroupFileSet("ACareImg_Food02", m_ACareImg_Food02);
            FncGroupFileSet("ACareImg_Food03", m_ACareImg_Food03);
            FncGroupFileSet("ACareImg_VivariumIndoor01", m_ACareImg_VivariumIndoor01);
            FncGroupFileSet("ACareImg_VivariumIndoor02", m_ACareImg_VivariumIndoor02);
            FncGroupFileSet("ACareImg_VivariumIndoor03", m_ACareImg_VivariumIndoor03);
            FncGroupFileSet("ACareImg_VivariumOutdoor01", m_ACareImg_VivariumOutdoor01);
            FncGroupFileSet("ACareImg_VivariumOutdoor02", m_ACareImg_VivariumOutdoor02);
            FncGroupFileSet("ACareImg_VivariumOutdoor03", m_ACareImg_VivariumOutdoor03);

            FncGroupFileSet("ADesImg_DesKeys01", m_ADesImg_DesKeys01);
            FncGroupFileSet("ADesImg_DesKeys02", m_ADesImg_DesKeys02);
            FncGroupFileSet("ADesImg_DesKeys03", m_ADesImg_DesKeys03);

            FncGroupFileSet("ADesImg_DesType01", m_ADesImg_DesType01);
            FncGroupFileSet("ADesImg_DesType02", m_ADesImg_DesType02);
            FncGroupFileSet("ADesImg_DesType03", m_ADesImg_DesType03);

  



            FncGroupFileSet("ADesImg_BabyDorsal01", m_ADesImg_BabyDorsal01);
            FncGroupFileSet("ADesImg_BabyDorsal02", m_ADesImg_BabyDorsal02);
            FncGroupFileSet("ADesImg_BabyDorsal03", m_ADesImg_BabyDorsal03);
            FncGroupFileSet("ADesImg_BabyVentral01", m_ADesImg_BabyVentral01);
            FncGroupFileSet("ADesImg_BabyVentral02", m_ADesImg_BabyVentral02);
            FncGroupFileSet("ADesImg_BabyVentral03", m_ADesImg_BabyVentral03);
            FncGroupFileSet("ADesImg_BodyBridge01", m_ADesImg_BodyBridge01);
            FncGroupFileSet("ADesImg_BodyBridge02", m_ADesImg_BodyBridge02);
            FncGroupFileSet("ADesImg_BodyBridge03", m_ADesImg_BodyBridge03);
            FncGroupFileSet("ADesImg_BodyDorsal01", m_ADesImg_BodyDorsal01);
            FncGroupFileSet("ADesImg_BodyDorsal02", m_ADesImg_BodyDorsal02);
            FncGroupFileSet("ADesImg_BodyDorsal03", m_ADesImg_BodyDorsal03);
            FncGroupFileSet("ADesImg_BodyFrontal01", m_ADesImg_BodyFrontal01);
            FncGroupFileSet("ADesImg_BodyFrontal02", m_ADesImg_BodyFrontal02);
            FncGroupFileSet("ADesImg_BodyFrontal03", m_ADesImg_BodyFrontal03);
            FncGroupFileSet("ADesImg_BodyLateral01", m_ADesImg_BodyLateral01);
            FncGroupFileSet("ADesImg_BodyLateral02", m_ADesImg_BodyLateral02);
            FncGroupFileSet("ADesImg_BodyLateral03", m_ADesImg_BodyLateral03);
            FncGroupFileSet("ADesImg_BodyRear01", m_ADesImg_BodyRear01);
            FncGroupFileSet("ADesImg_BodyRear02", m_ADesImg_BodyRear02);
            FncGroupFileSet("ADesImg_BodyRear03", m_ADesImg_BodyRear03);
            FncGroupFileSet("ADesImg_BodyVentral01", m_ADesImg_BodyVentral01);
            FncGroupFileSet("ADesImg_BodyVentral02", m_ADesImg_BodyVentral02);
            FncGroupFileSet("ADesImg_BodyVentral03", m_ADesImg_BodyVentral03);
            FncGroupFileSet("ADesImg_Dimorphism01", m_ADesImg_Dimorphism01);
            FncGroupFileSet("ADesImg_Dimorphism02", m_ADesImg_Dimorphism02);
            FncGroupFileSet("ADesImg_Dimorphism03", m_ADesImg_Dimorphism03);
            FncGroupFileSet("ADesImg_Holotype01", m_ADesImg_Holotype01);
            FncGroupFileSet("ADesImg_Holotype02", m_ADesImg_Holotype02);
            FncGroupFileSet("ADesImg_Holotype03", m_ADesImg_Holotype03);
            FncGroupFileSet("ADesImg_OtherHead01", m_ADesImg_OtherHead01);
            FncGroupFileSet("ADesImg_OtherHead02", m_ADesImg_OtherHead02);
            FncGroupFileSet("ADesImg_OtherHead03", m_ADesImg_OtherHead03);
            FncGroupFileSet("ADesImg_OtherLegs01", m_ADesImg_OtherLegs01);
            FncGroupFileSet("ADesImg_OtherLegs02", m_ADesImg_OtherLegs02);
            FncGroupFileSet("ADesImg_OtherLegs03", m_ADesImg_OtherLegs03);
            FncGroupFileSet("ADesImg_OtherTail01", m_ADesImg_OtherTail01);
            FncGroupFileSet("ADesImg_OtherTail02", m_ADesImg_OtherTail02);
            FncGroupFileSet("ADesImg_OtherTail03", m_ADesImg_OtherTail03);
            FncGroupFileSet("AGeoImg_ClimateEcozoneKey", m_AGeoImg_ClimateEcozoneKey);
            FncGroupFileSet("AGeoImg_ClimateWheatherBiome", m_AGeoImg_ClimateWheatherBiome);
            FncGroupFileSet("AGeoImg_ClimateWheatherRain", m_AGeoImg_ClimateWheatherRain);
            FncGroupFileSet("AGeoImg_ClimateWheatherSun", m_AGeoImg_ClimateWheatherSun);
            FncGroupFileSet("AGeoImg_ClimateWheatherTemp", m_AGeoImg_ClimateWheatherTemp);
            FncGroupFileSet("AGeoImg_GeoRangeMapStandardWorldFul", m_AGeoImg_GeoRangeMapStandardWorldFul);
            FncGroupFileSet("AGeoImg_GeoRangeMapStandardWorldFull", m_AGeoImg_GeoRangeMapStandardWorldFull);
            FncGroupFileSet("AGeoImg_GeoRangeMapStandardDetailMin", m_AGeoImg_GeoRangeMapStandardDetailMin);
            FncGroupFileSet("AGeoImg_GeoRangeMapStandardDetailFul", m_AGeoImg_GeoRangeMapStandardDetailFul);

            FncGroupFileSet("AGeoImg_GeoRangeMapStandardKoppenMin", m_AGeoImg_GeoRangeMapStandardKoppenMin);
            FncGroupFileSet("AGeoImg_GeoRangeMapStandardKoppenFul", m_AGeoImg_GeoRangeMapStandardKoppenFul);


            FncGroupFileSet("AGeoImg_landscapes01", m_AGeoImg_landscapes01);
            FncGroupFileSet("AGeoImg_landscapes02", m_AGeoImg_landscapes02);
            FncGroupFileSet("AGeoImg_landscapes03", m_AGeoImg_landscapes03);
            FncGroupFileSet("ANatImg_Breeding01", m_ANatImg_Breeding01);
            FncGroupFileSet("ANatImg_Breeding02", m_ANatImg_Breeding02);
            FncGroupFileSet("ANatImg_Breeding03", m_ANatImg_Breeding03);
            FncGroupFileSet("ANatImg_Food01", m_ANatImg_Food01);
            FncGroupFileSet("ANatImg_Food02", m_ANatImg_Food02);
            FncGroupFileSet("ANatImg_Food03", m_ANatImg_Food03);
            FncGroupFileSet("ANatImg_Live01", m_ANatImg_Live01);
            FncGroupFileSet("ANatImg_Live02", m_ANatImg_Live02);
            FncGroupFileSet("ANatImg_Live03", m_ANatImg_Live03);
            FncGroupFileSet("ADesImg_Diferentiation01", m_ADesImg_Diferentiation01);
            FncGroupFileSet("ADesImg_Diferentiation02", m_ADesImg_Diferentiation02);
            FncGroupFileSet("ADesImg_Diferentiation03", m_ADesImg_Diferentiation03);

            FncGroupFileSet("ACareImg_gral01", m_ACareImg_gral01);
            FncGroupFileSet("ACareImg_gral02", m_ACareImg_gral02);
            FncGroupFileSet("ACareImg_gral03", m_ACareImg_gral03);
            FncGroupFileSet("ACareImg_Breeding01", m_ACareImg_Breeding01);
            FncGroupFileSet("ACareImg_Breeding02", m_ACareImg_Breeding02);
            FncGroupFileSet("ACareImg_Breeding03", m_ACareImg_Breeding03);

            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            return true;

        }
        /// <summary>
        /// Inserta o actualiza los valores de un fichero
        /// Ojo la variable DocId  se toma globalmente.
        /// Ojo actulamente solo imagenes.
        /// </summary>
        /// <param name="m_FileSeccId">Nombre clave del fichero</param>
        /// <param name="m_AFileURL">urlr de aceso al fichero</param>
        /// <returns></returns>

        private bool FncGroupFileSet(string m_FileSeccId, string m_AFileURL)
        {
            //   bool bFlag = true;
            //oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            int iCount = 0;
            oSqlCmdSelectExist.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdSelectExist.Parameters["@FileSeccId"].Value = m_FileSeccId;

            try
            {
                iCount = Convert.ToInt32(oSqlCmdSelectExist.ExecuteScalar().ToString());

            }
            catch

            { iCount = 0; }
            if (iCount != 0)
            {

                oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
                oSqlCmdUpdate.Parameters["@FileSeccId"].Value = m_FileSeccId;
                oSqlCmdUpdate.Parameters["@AFileType"].Value = m_AFileType;
                oSqlCmdUpdate.Parameters["@AFileURL"].Value = m_AFileURL;
                oSqlCmdUpdate.Parameters["@AFileNote"].Value = m_AFileNote;
                //-----------------------------------------------------;
                //            ACTUALIZAR 
                //-------------------------------------------------------;

                try
                {
                    int i = oSqlCmdUpdate.ExecuteNonQuery();
                    return true;
                }
                catch (SystemException ex)
                {
                    _mErrorBoolean = true;
                    _mErrorString = ex.ToString();
                    //  MessageBox.Show (_mErrorString);
                    //bFlag = false;
                }
            }
            else
            {

                oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
                oSqlCmdInsert.Parameters["@FileSeccId"].Value = m_FileSeccId;
                oSqlCmdInsert.Parameters["@AFileType"].Value = m_AFileType;
                oSqlCmdInsert.Parameters["@AFileURL"].Value = m_AFileURL;
                oSqlCmdInsert.Parameters["@AFileNote"].Value = m_AFileNote;
                try
                {

                    oSqlCmdInsert.ExecuteNonQuery();
                    return true;
                }
                catch (SystemException ex)
                {
                    _mErrorBoolean = true;
                    _mErrorString = ex.ToString();
                    //  MessageBox.Show (_mErrorString);
                }
            }
            return false;
        }
        //---------------------------------------------------------------

        public UInt64 DocIdGroup
        {
            get { return m_DocIdGroup; }
            set { m_DocIdGroup = value; }
        }

        public string AAbsImg_Specie
        {
            get { return m_AAbsImg_Specie; }
            set { m_AAbsImg_Specie = value.Trim(); }
        }

        public string AAbsImg_HNatural
        {
            get { return m_AAbsImg_HNatural; }
            set { m_AAbsImg_HNatural = value.Trim(); }
        }

        public string AAbsImg_Range
        {
            get { return m_AAbsImg_Range; }
            set { m_AAbsImg_Range = value.Trim(); }
        }

        public string ACareImg_Breeding01
        {
            get { return m_ACareImg_Breeding01; }
            set { m_ACareImg_Breeding01 = value.Trim(); }
        }

        public string ACareImg_Breeding02
        {
            get { return m_ACareImg_Breeding02; }
            set { m_ACareImg_Breeding02 = value.Trim(); }
        }

        public string ACareImg_Breeding03
        {
            get { return m_ACareImg_Breeding03; }
            set { m_ACareImg_Breeding03 = value.Trim(); }
        }

        public string ACareImg_Food01
        {
            get { return m_ACareImg_Food01; }
            set { m_ACareImg_Food01 = value.Trim(); }
        }

        public string ACareImg_Food02
        {
            get { return m_ACareImg_Food02; }
            set { m_ACareImg_Food02 = value.Trim(); }
        }

        public string ACareImg_Food03
        {
            get { return m_ACareImg_Food03; }
            set { m_ACareImg_Food03 = value.Trim(); }
        }

        public string ACareImg_VivariumIndoor01
        {
            get { return m_ACareImg_VivariumIndoor01; }
            set { m_ACareImg_VivariumIndoor01 = value.Trim(); }
        }

        public string ACareImg_VivariumIndoor02
        {
            get { return m_ACareImg_VivariumIndoor02; }
            set { m_ACareImg_VivariumIndoor02 = value.Trim(); }
        }

        public string ACareImg_VivariumIndoor03
        {
            get { return m_ACareImg_VivariumIndoor03; }
            set { m_ACareImg_VivariumIndoor03 = value.Trim(); }
        }

        public string ACareImg_VivariumOutdoor01
        {
            get { return m_ACareImg_VivariumOutdoor01; }
            set { m_ACareImg_VivariumOutdoor01 = value.Trim(); }
        }

        public string ACareImg_VivariumOutdoor02
        {
            get { return m_ACareImg_VivariumOutdoor02; }
            set { m_ACareImg_VivariumOutdoor02 = value.Trim(); }
        }

        public string ACareImg_VivariumOutdoor03
        {
            get { return m_ACareImg_VivariumOutdoor03; }
            set { m_ACareImg_VivariumOutdoor03 = value.Trim(); }
        }

        public string ADesImg_BabyDorsal01
        {
            get { return m_ADesImg_BabyDorsal01; }
            set { m_ADesImg_BabyDorsal01 = value.Trim(); }
        }

        public string ADesImg_BabyDorsal02
        {
            get { return m_ADesImg_BabyDorsal02; }
            set { m_ADesImg_BabyDorsal02 = value.Trim(); }
        }

        public string ADesImg_BabyDorsal03
        {
            get { return m_ADesImg_BabyDorsal03; }
            set { m_ADesImg_BabyDorsal03 = value.Trim(); }
        }

        public string ADesImg_BabyVentral01
        {
            get { return m_ADesImg_BabyVentral01; }
            set { m_ADesImg_BabyVentral01 = value.Trim(); }
        }

        public string ADesImg_BabyVentral02
        {
            get { return m_ADesImg_BabyVentral02; }
            set { m_ADesImg_BabyVentral02 = value.Trim(); }
        }

        public string ADesImg_BabyVentral03
        {
            get { return m_ADesImg_BabyVentral03; }
            set { m_ADesImg_BabyVentral03 = value.Trim(); }
        }

        public string ADesImg_BodyBridge01
        {
            get { return m_ADesImg_BodyBridge01; }
            set { m_ADesImg_BodyBridge01 = value.Trim(); }
        }

        public string ADesImg_BodyBridge02
        {
            get { return m_ADesImg_BodyBridge02; }
            set { m_ADesImg_BodyBridge02 = value.Trim(); }
        }

        public string ADesImg_BodyBridge03
        {
            get { return m_ADesImg_BodyBridge03; }
            set { m_ADesImg_BodyBridge03 = value.Trim(); }
        }

        public string ADesImg_BodyDorsal01
        {
            get { return m_ADesImg_BodyDorsal01; }
            set { m_ADesImg_BodyDorsal01 = value.Trim(); }
        }

        public string ADesImg_BodyDorsal02
        {
            get { return m_ADesImg_BodyDorsal02; }
            set { m_ADesImg_BodyDorsal02 = value.Trim(); }
        }

        public string ADesImg_BodyDorsal03
        {
            get { return m_ADesImg_BodyDorsal03; }
            set { m_ADesImg_BodyDorsal03 = value.Trim(); }
        }

        public string ADesImg_BodyFrontal01
        {
            get { return m_ADesImg_BodyFrontal01; }
            set { m_ADesImg_BodyFrontal01 = value.Trim(); }
        }

        public string ADesImg_BodyFrontal02
        {
            get { return m_ADesImg_BodyFrontal02; }
            set { m_ADesImg_BodyFrontal02 = value.Trim(); }
        }

        public string ADesImg_BodyFrontal03
        {
            get { return m_ADesImg_BodyFrontal03; }
            set { m_ADesImg_BodyFrontal03 = value.Trim(); }
        }

        public string ADesImg_BodyLateral01
        {
            get { return m_ADesImg_BodyLateral01; }
            set { m_ADesImg_BodyLateral01 = value.Trim(); }
        }

        public string ADesImg_BodyLateral02
        {
            get { return m_ADesImg_BodyLateral02; }
            set { m_ADesImg_BodyLateral02 = value.Trim(); }
        }

        public string ADesImg_BodyLateral03
        {
            get { return m_ADesImg_BodyLateral03; }
            set { m_ADesImg_BodyLateral03 = value.Trim(); }
        }

        public string ADesImg_BodyRear01
        {
            get { return m_ADesImg_BodyRear01; }
            set { m_ADesImg_BodyRear01 = value.Trim(); }
        }

        public string ADesImg_BodyRear02
        {
            get { return m_ADesImg_BodyRear02; }
            set { m_ADesImg_BodyRear02 = value.Trim(); }
        }

        public string ADesImg_BodyRear03
        {
            get { return m_ADesImg_BodyRear03; }
            set { m_ADesImg_BodyRear03 = value.Trim(); }
        }

        public string ADesImg_BodyVentral01
        {
            get { return m_ADesImg_BodyVentral01; }
            set { m_ADesImg_BodyVentral01 = value.Trim(); }
        }

        public string ADesImg_BodyVentral02
        {
            get { return m_ADesImg_BodyVentral02; }
            set { m_ADesImg_BodyVentral02 = value.Trim(); }
        }

        public string ADesImg_BodyVentral03
        {
            get { return m_ADesImg_BodyVentral03; }
            set { m_ADesImg_BodyVentral03 = value.Trim(); }
        }

        public string ADesImg_Dimorphism01
        {
            get { return m_ADesImg_Dimorphism01; }
            set { m_ADesImg_Dimorphism01 = value.Trim(); }
        }

        public string ADesImg_Dimorphism02
        {
            get { return m_ADesImg_Dimorphism02; }
            set { m_ADesImg_Dimorphism02 = value.Trim(); }
        }

        public string ADesImg_Dimorphism03
        {
            get { return m_ADesImg_Dimorphism03; }
            set { m_ADesImg_Dimorphism03 = value.Trim(); }
        }

        public string ADesImg_Holotype01
        {
            get { return m_ADesImg_Holotype01; }
            set { m_ADesImg_Holotype01 = value.Trim(); }
        }

        public string ADesImg_Holotype02
        {
            get { return m_ADesImg_Holotype02; }
            set { m_ADesImg_Holotype02 = value.Trim(); }
        }

        public string ADesImg_Holotype03
        {
            get { return m_ADesImg_Holotype03; }
            set { m_ADesImg_Holotype03 = value.Trim(); }
        }

        public string ADesImg_OtherHead01
        {
            get { return m_ADesImg_OtherHead01; }
            set { m_ADesImg_OtherHead01 = value.Trim(); }
        }

        public string ADesImg_OtherHead02
        {
            get { return m_ADesImg_OtherHead02; }
            set { m_ADesImg_OtherHead02 = value.Trim(); }
        }

        public string ADesImg_OtherHead03
        {
            get { return m_ADesImg_OtherHead03; }
            set { m_ADesImg_OtherHead03 = value.Trim(); }
        }

        public string ADesImg_OtherLegs01
        {
            get { return m_ADesImg_OtherLegs01; }
            set { m_ADesImg_OtherLegs01 = value.Trim(); }
        }

        public string ADesImg_OtherLegs02
        {
            get { return m_ADesImg_OtherLegs02; }
            set { m_ADesImg_OtherLegs02 = value.Trim(); }
        }

        public string ADesImg_OtherLegs03
        {
            get { return m_ADesImg_OtherLegs03; }
            set { m_ADesImg_OtherLegs03 = value.Trim(); }
        }

        public string ADesImg_OtherTail01
        {
            get { return m_ADesImg_OtherTail01; }
            set { m_ADesImg_OtherTail01 = value.Trim(); }
        }

        public string ADesImg_OtherTail02
        {
            get { return m_ADesImg_OtherTail02; }
            set { m_ADesImg_OtherTail02 = value.Trim(); }
        }

        public string ADesImg_OtherTail03
        {
            get { return m_ADesImg_OtherTail03; }
            set { m_ADesImg_OtherTail03 = value.Trim(); }
        }

        public string AGeoImg_ClimateEcozoneKey
        {
            get { return m_AGeoImg_ClimateEcozoneKey; }
            set { m_AGeoImg_ClimateEcozoneKey = value.Trim(); }
        }

        public string AGeoImg_ClimateWheatherBiome
        {
            get { return m_AGeoImg_ClimateWheatherBiome; }
            set { m_AGeoImg_ClimateWheatherBiome = value.Trim(); }
        }

        public string AGeoImg_ClimateWheatherRain
        {
            get { return m_AGeoImg_ClimateWheatherRain; }
            set { m_AGeoImg_ClimateWheatherRain = value.Trim(); }
        }

        public string AGeoImg_ClimateWheatherSun
        {
            get { return m_AGeoImg_ClimateWheatherSun; }
            set { m_AGeoImg_ClimateWheatherSun = value.Trim(); }
        }

        public string AGeoImg_ClimateWheatherTemp
        {
            get { return m_AGeoImg_ClimateWheatherTemp; }
            set { m_AGeoImg_ClimateWheatherTemp = value.Trim(); }
        }


        private string FncImmageChangetoFull(string szUrlImage)
        {

            szUrlImage = szUrlImage.ToLower();
            String szUrlChanged = szUrlImage.Replace("min.jpg", "ful.jpg");
            szUrlChanged = szUrlChanged.Replace("minx.jpg", "ful.jpg");
            szUrlChanged = szUrlChanged.Replace("med.jpg", "ful.jpg");
            szUrlChanged = szUrlChanged.Replace("big.jpg", "ful.jpg");
            // comporbar que exite el fichero
            string szPath = "";
            bool bExist = false;
            szPath = ((ClsGlobal.DirRoot + szUrlChanged).Replace("/", "\\")).Replace("\\\\", "\\");
            if (System.IO.File.Exists(szPath))
            {
                bExist = true;
            }
            else
            {
                szPath = szPath.Replace("ful.jpg", "med.jpg");
                if (System.IO.File.Exists(szPath))
                {
                    szUrlChanged = szUrlChanged.Replace("ful.jpg", "med.jpg");
                    bExist = true;
                }

            }
            if (bExist) { return szUrlChanged; }
            else
            { return szUrlImage; }

        }

        private string FncImmageChangetoMin(string szUrlImage)
        {

            szUrlImage = szUrlImage.ToLower();
            String szUrlChanged = szUrlImage.Replace("ful.jpg", "min.jpg");
            szUrlChanged = szUrlChanged.Replace("minx.jpg", "min.jpg");
            szUrlChanged = szUrlChanged.Replace("med.jpg", "min.jpg");
            szUrlChanged = szUrlChanged.Replace("big.jpg", "min.jpg");
            // comporbar que exite el fichero
            string szPath = "";
            bool bExist = false;
            szPath = ((ClsGlobal.DirRoot + szUrlChanged).Replace("/", "\\")).Replace("\\\\", "\\");
            if (System.IO.File.Exists(szPath))
            {
                bExist = true;
            }
            else
            {
                szPath = szPath.Replace("ful.jpg", "med.jpg");
                if (System.IO.File.Exists(szPath))
                {
                    szUrlChanged = szUrlChanged.Replace("ful.jpg", "med.jpg");
                    bExist = true;
                }

            }
            if (bExist) { return szUrlChanged; }
            else
            { return szUrlImage; }

        }

        public string AGeoImg_GeoRangeMapStandardDetailFul
        {
            get { return FncImmageChangetoFull(FncImmageChangetoFull(m_AGeoImg_GeoRangeMapStandardDetailFul)); }
            set
            {
                m_AGeoImg_GeoRangeMapStandardDetailFul = FncImmageChangetoFull(value.Trim());
                m_AGeoImg_GeoRangeMapStandardDetailMin = FncImmageChangetoMin(m_AGeoImg_GeoRangeMapStandardDetailFul);
            }
        }

        public string AGeoImg_GeoRangeMapStandardDetailMin
        {
            get { return FncImmageChangetoMin(m_AGeoImg_GeoRangeMapStandardDetailMin); }

        }

        public string AGeoImg_GeoRangeMapStandardWorldFul
        {
            get
            {

                return FncImmageChangetoFull(FncImmageChangetoFull(m_AGeoImg_GeoRangeMapStandardWorldFul));
            }


            set
            {
                m_AGeoImg_GeoRangeMapStandardWorldFul = FncImmageChangetoFull(value.Trim());
                m_AGeoImg_GeoRangeMapStandardWorldFull = FncImmageChangetoMin(m_AGeoImg_GeoRangeMapStandardWorldFul);
            }
        }

        public string AGeoImg_GeoRangeMapStandardWorldFull
        {
            get { return FncImmageChangetoFull(m_AGeoImg_GeoRangeMapStandardWorldFull); }

        }


        public string AGeoImg_GeoRangeMapStandardKoppenMin
        {
            get { return FncImmageChangetoFull(m_AGeoImg_GeoRangeMapStandardKoppenMin); }

        }

        public string AGeoImg_GeoRangeMapStandardKoppenFul
        {
            get { return FncImmageChangetoFull(FncImmageChangetoFull(m_AGeoImg_GeoRangeMapStandardKoppenFul)); }
            set
            {
                m_AGeoImg_GeoRangeMapStandardKoppenFul = FncImmageChangetoFull(value.Trim());
                m_AGeoImg_GeoRangeMapStandardKoppenMin = FncImmageChangetoMin(m_AGeoImg_GeoRangeMapStandardKoppenFul);
            }
        }




        public string AGeoImg_landscapes01
        {
            get { return m_AGeoImg_landscapes01; }
            set { m_AGeoImg_landscapes01 = value.Trim(); }
        }

        public string AGeoImg_landscapes02
        {
            get { return m_AGeoImg_landscapes02; }
            set { m_AGeoImg_landscapes02 = value.Trim(); }
        }

        public string AGeoImg_landscapes03
        {
            get { return m_AGeoImg_landscapes03; }
            set { m_AGeoImg_landscapes03 = value.Trim(); }
        }

        public string ANatImg_Breeding01
        {
            get { return m_ANatImg_Breeding01; }
            set { m_ANatImg_Breeding01 = value.Trim(); }
        }

        public string ANatImg_Breeding02
        {
            get { return m_ANatImg_Breeding02; }
            set { m_ANatImg_Breeding02 = value.Trim(); }
        }

        public string ANatImg_Breeding03
        {
            get { return m_ANatImg_Breeding03; }
            set { m_ANatImg_Breeding03 = value.Trim(); }
        }

        public string ANatImg_Food01
        {
            get { return m_ANatImg_Food01; }
            set { m_ANatImg_Food01 = value.Trim(); }
        }

        public string ANatImg_Food02
        {
            get { return m_ANatImg_Food02; }
            set { m_ANatImg_Food02 = value.Trim(); }
        }

        public string ANatImg_Food03
        {
            get { return m_ANatImg_Food03; }
            set { m_ANatImg_Food03 = value.Trim(); }
        }

        public string ANatImg_Live01
        {
            get { return m_ANatImg_Live01; }
            set { m_ANatImg_Live01 = value.Trim(); }
        }

        public string ANatImg_Live02
        {
            get { return m_ANatImg_Live02; }
            set { m_ANatImg_Live02 = value.Trim(); }
        }

        public string ANatImg_Live03
        {
            get { return m_ANatImg_Live03; }
            set { m_ANatImg_Live03 = value.Trim(); }
        }

        public string ADesImg_Diferentiation01
        {
            get { return m_ADesImg_Diferentiation01; }
            set { m_ADesImg_Diferentiation01 = value.Trim(); }
        }
        public string ADesImg_Diferentiation02
        {
            get { return m_ADesImg_Diferentiation02; }
            set { m_ADesImg_Diferentiation02 = value.Trim(); }
        }
        public string ADesImg_Diferentiation03
        {
            get { return m_ADesImg_Diferentiation03; }
            set { m_ADesImg_Diferentiation03 = value.Trim(); }
        }

        public string ACareImg_gral01
        {
            get { return m_ACareImg_gral01; }
            set { m_ACareImg_gral01 = value.Trim(); }
        }
        public string ACareImg_gral02
        {
            get { return m_ACareImg_gral02; }
            set { m_ACareImg_gral02 = value.Trim(); }
        }
        public string ACareImg_gral03
        {
            get { return m_ACareImg_gral03; }
            set { m_ACareImg_gral03 = value.Trim(); }
        }

        public string ADesImg_DesKeys01
        {
            get { return m_ADesImg_DesKeys01; }
            set { m_ADesImg_DesKeys01 = value.Trim(); }
        }
        public string ADesImg_DesKeys02
        {
            get { return m_ADesImg_DesKeys02; }
            set { m_ADesImg_DesKeys02 = value.Trim(); }
        }
        public string ADesImg_DesKeys03
        {
            get { return m_ADesImg_DesKeys03; }
            set { m_ADesImg_DesKeys03 = value.Trim(); }
        }

        public string ADesImg_DesType01
        {
            get { return m_ADesImg_DesType01; }
            set { m_ADesImg_DesType01 = value.Trim(); }
        }

        public string ADesImg_DesType02
        {
            get { return m_ADesImg_DesType02; }
            set { m_ADesImg_DesType02 = value.Trim(); }
        }

        public string ADesImg_DesType03
        {
            get { return m_ADesImg_DesType03; }
            set { m_ADesImg_DesType03 = value.Trim(); }
        }

        #endregion


    }
}