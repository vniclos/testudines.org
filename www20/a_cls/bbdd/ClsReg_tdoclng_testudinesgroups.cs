using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_testudinesgroups : IDisposable
    {
        private cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc();
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
       
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectATaxIdName = new MySqlCommand();
        cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";
        private String m_Title = "";
        private String m_ATaxIdName = "";
        private String m_ATaxGrpL2282Authority = "";
        private String m_ATaxGrpL2283Year = "";
        private String m_AtaxIdNameParent = "";
        private String m_ATaxLevel = "";
        private String m_NameVulgar = "";
        private String m_Abstract = "";
        private String m_DescriptionShort = "";
        private String m_Body = "";
        private String m_Notes = "";
        private Int32 m_Ref_ITIS_Number = 0;
        private bool m_IsOk = false;
        private bool m_IsTaxa2014 = false;

        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoclng_testudinesgroups(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_testudinesgroups()
        {
          
            FncSqlBuildCommands();
            FncClear();
        }
        //---------------------------------------------------



        //---------------------------------------------------
        //---------------------------------------------------
        //---------------------------------------------------
        #region IDisposable implementation
        private bool m_Disposed = false;

        //...............

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (cls.bbdd.ClsMysql.MySqlConnection.State == ConnectionState.Open) ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            oSqlCmdUpdate.Dispose();
            oSqlCmdUpdate.Dispose();
            oSqlCmdInsert.Dispose();
            oSqlCmdDelete.Dispose();
            oSqlCmdSelect.Dispose();
            oSqlCmdSelectExist.Dispose();
            m_Disposed = true;
        }

        //...............
        ~ClsReg_tdoclng_testudinesgroups()
        {
            Dispose(false);
        }
        #endregion
        //---------------------------------------------------
        //---------------------------------------------------

        //--------------------------------------------------
        #region CLEAR
        //--------------------------------------------------
        public void FncClear()
        {
            m_DocLngId = "";
            m_Title = "";
            m_ATaxIdName = "";
            m_ATaxGrpL2282Authority = "";
            m_ATaxGrpL2283Year = "";
            m_AtaxIdNameParent = "";
            m_ATaxLevel = "";
            m_NameVulgar = "";
            m_Abstract = "";
            m_DescriptionShort = "";
            m_Body = "";
            m_Notes = "";
            m_Ref_ITIS_Number = 0;
            m_IsOk = false;
            m_IsTaxa2014 = false;

        }
        #endregion CLEAR
        //------------------------------

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
            szSql = "SELECT * FROM tdoclng_testudines_groups  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_groups";

            szSql += "(";

            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", Title ";
            szSql += ", ATaxIdName ";
            szSql += ", ATaxGrpL2282Authority ";
            szSql += ", ATaxGrpL2283Year ";
            szSql += ", AtaxIdNameParent ";
            szSql += ", ATaxLevel ";
            szSql += ", NameVulgar ";
            szSql += ", Abstract ";
            szSql += ", DescriptionShort ";
            szSql += ", Body ";
            szSql += ", Notes ";
            szSql += ", Ref_ITIS_Number ";
            szSql += ", IsOk ";
            szSql += ", IsTaxa2014 ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @Title ";
            szSql += ", @ATaxIdName ";
            szSql += ", @ATaxGrpL2282Authority ";
            szSql += ", @ATaxGrpL2283Year ";
            szSql += ", @AtaxIdNameParent ";
            szSql += ", @ATaxLevel ";
            szSql += ", @NameVulgar ";
            szSql += ", @Abstract ";
            szSql += ", @DescriptionShort ";
            szSql += ", @Body ";
            szSql += ", @Notes ";
            szSql += ", @Ref_ITIS_Number ";
            szSql += ", @IsOk ";
            szSql += ", @IsTaxa2014 ";
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ATaxIdName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2282Authority", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2283Year", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@AtaxIdNameParent", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ATaxLevel", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@NameVulgar", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@DescriptionShort", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Ref_ITIS_Number", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            oSqlCmdInsert.Parameters.Add("@IsOk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsTaxa2014", MySql.Data.MySqlClient.MySqlDbType.Bit);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_groups SET ";

            szSql += "Title=@Title ";
            szSql += ", ATaxIdName=@ATaxIdName ";
            szSql += ", ATaxGrpL2282Authority=@ATaxGrpL2282Authority ";
            szSql += ", ATaxGrpL2283Year=@ATaxGrpL2283Year ";
            szSql += ", AtaxIdNameParent=@AtaxIdNameParent ";
            szSql += ", ATaxLevel=@ATaxLevel ";
            szSql += ", NameVulgar=@NameVulgar ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", DescriptionShort=@DescriptionShort ";
            szSql += ", Body=@Body ";
            szSql += ", Notes=@Notes ";
            szSql += ", Ref_ITIS_Number=@Ref_ITIS_Number ";
            szSql += ", IsOk=@IsOk ";
            szSql += ", IsTaxa2014=@IsTaxa2014 ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ATaxIdName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2282Authority", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2283Year", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@AtaxIdNameParent", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ATaxLevel", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@NameVulgar", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@DescriptionShort", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Ref_ITIS_Number", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            oSqlCmdUpdate.Parameters.Add("@IsOk", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsTaxa2014", MySql.Data.MySqlClient.MySqlDbType.Bit);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_groups  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", DocLngId";
            szSql += " FROM tdoclng_testudines_groups  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);
            //----------------------------------------------------------------------
            //------------------------------------------------
            szSql = "SELECT DocId FROM tdoclng_testudines_groups  ";
            szSql += " WHERE ";
            szSql += "(ATaxIdName=@ATaxIdName )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectATaxIdName.CommandText = szSql;
            oSqlCmdSelectATaxIdName.Parameters.Add("@ATaxIdName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdSelectATaxIdName.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.String);

        
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
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@ATaxIdName"].Value = m_ATaxIdName;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2282Authority"].Value = m_ATaxGrpL2282Authority;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2283Year"].Value = m_ATaxGrpL2283Year;
            oSqlCmdUpdate.Parameters["@AtaxIdNameParent"].Value = m_AtaxIdNameParent;
            oSqlCmdUpdate.Parameters["@ATaxLevel"].Value = m_ATaxLevel;
            oSqlCmdUpdate.Parameters["@NameVulgar"].Value = m_NameVulgar;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@DescriptionShort"].Value = m_DescriptionShort;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;
            oSqlCmdUpdate.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdUpdate.Parameters["@Ref_ITIS_Number"].Value = m_Ref_ITIS_Number;
            oSqlCmdUpdate.Parameters["@IsOk"].Value = m_IsOk;
            oSqlCmdUpdate.Parameters["@IsTaxa2014"].Value = m_IsTaxa2014;
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
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@ATaxIdName"].Value = m_ATaxIdName;
            oSqlCmdInsert.Parameters["@ATaxGrpL2282Authority"].Value = m_ATaxGrpL2282Authority;
            oSqlCmdInsert.Parameters["@ATaxGrpL2283Year"].Value = m_ATaxGrpL2283Year;
            oSqlCmdInsert.Parameters["@AtaxIdNameParent"].Value = m_AtaxIdNameParent;
            oSqlCmdInsert.Parameters["@ATaxLevel"].Value = m_ATaxLevel;
            oSqlCmdInsert.Parameters["@NameVulgar"].Value = m_NameVulgar;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@DescriptionShort"].Value = m_DescriptionShort;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;
            oSqlCmdInsert.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdInsert.Parameters["@Ref_ITIS_Number"].Value = m_Ref_ITIS_Number;
            oSqlCmdInsert.Parameters["@IsOk"].Value = m_IsOk;
            oSqlCmdInsert.Parameters["@IsTaxa2014"].Value = m_IsTaxa2014;
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
        public bool FncSqlFind(UInt64 DocId, String DocLngId)
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
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                    m_DocLngId = oDR["DocLngId"].ToString().Trim();
                    m_Title = oDR["Title"].ToString().Trim();
                    m_ATaxIdName = oDR["ATaxIdName"].ToString().Trim();
                    m_ATaxGrpL2282Authority = oDR["ATaxGrpL2282Authority"].ToString().Trim();
                    m_ATaxGrpL2283Year = oDR["ATaxGrpL2283Year"].ToString().Trim();
                    m_AtaxIdNameParent = oDR["AtaxIdNameParent"].ToString().Trim();
                    m_ATaxLevel = oDR["ATaxLevel"].ToString().Trim();
                    m_NameVulgar = oDR["NameVulgar"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_DescriptionShort = oDR["DescriptionShort"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();
                    m_Notes = oDR["Notes"].ToString().Trim();
                    m_Ref_ITIS_Number = Convert.ToInt32(oDR["Ref_ITIS_Number"].ToString().Trim());
                    if(oDR["IsOk"].ToString().Trim()=="1")
                    {
                    m_IsOk =true;
                    }
                    else {
                    m_IsOk =false;
                    }
                        
                        if (oDR["IsTaxa2014"].ToString().Trim() == "1")
                        {
                            m_IsTaxa2014 = true;
                        }
                        else
                        {
                            m_IsTaxa2014 = false;
                        }


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


        public bool FncSqlFind( String pDocLngId,string pATaxIdName)
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
                oSqlCmdSelectATaxIdName.Connection = ClsMysql.MySqlConnection;;
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
                string sz = value.Trim();
                if (sz.Length > 2)
                {
                    sz = sz.Substring(0, 1);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DocLngId because is it too long,MaxLength=2";
                }
                m_DocLngId = sz;

            }
            get { return m_DocLngId; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 256)
                {
                    sz = sz.Substring(0, 255);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=256";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String ATaxIdName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ATaxIdName because is it too long,MaxLength=50";
                }
                m_ATaxIdName = sz;

            }
            get { return m_ATaxIdName; }
        }

        //................................

        public String ATaxGrpL2282Authority
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ATaxGrpL2282Authority because is it too long,MaxLength=150";
                }
                m_ATaxGrpL2282Authority = sz;

            }
            get { return m_ATaxGrpL2282Authority; }
        }

        //................................

        public String ATaxGrpL2283Year
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 4)
                {
                    sz = sz.Substring(0, 3);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ATaxGrpL2283Year because is it too long,MaxLength=4";
                }
                m_ATaxGrpL2283Year = sz;

            }
            get { return m_ATaxGrpL2283Year; }
        }

        //................................

        public String AtaxIdNameParent
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_AtaxIdNameParent because is it too long,MaxLength=50";
                }
                m_AtaxIdNameParent = sz;

            }
            get { return m_AtaxIdNameParent; }
        }

        //................................

        public String ATaxLevel
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ATaxLevel because is it too long,MaxLength=50";
                }
                m_ATaxLevel = sz;

            }
            get { return m_ATaxLevel; }
        }

        //................................

        public String NameVulgar
        {
            set
            {
                m_NameVulgar = value;
            }
            get { return m_NameVulgar; }
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

        public String DescriptionShort
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_DescriptionShort because is it too long,MaxLength=150";
                }
                m_DescriptionShort = sz;

            }
            get { return m_DescriptionShort; }
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

        public String Notes
        {
            set
            {
                m_Notes = value;
            }
            get { return m_Notes; }
        }

        //................................

        public Int32 Ref_ITIS_Number
        {
            set
            {
                m_Ref_ITIS_Number = value;
            }
            get { return m_Ref_ITIS_Number; }
        }
        public bool IsOk
        {
            set
            {
                m_IsOk = value;
            }
            get { return m_IsOk; }
        }

        //................................

        public bool IsTaxa2014
        {
            set
            {
                m_IsTaxa2014 = value;
            }
            get { return m_IsTaxa2014; }
        }

        #endregion VALORES_GETSET

                //========================================================
        //==========================================================
        //===========================================================
        // devuelve el html del articulo
        // Si no existe el cache lo crea, 
        // si existe devuelve el fichero cache.
        public string FncGetCache_Html(bool bRebuild)
        {

            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, m_DocLngId, "tortoises_group");

            if (cls.ClsGlobal.CacheRebuid || bRebuild) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncGetCache_HtmlBld();

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
                return szHtml;
            }

        }
        private string FncGetCache_HtmlBld()
        {

            cls.bbdd.ClsReg_tdoclng_testudines_file_all oRegTaxonFiles = new ClsReg_tdoclng_testudines_file_all();

            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            StringBuilder sb = new StringBuilder();
            //szHtml+=("<H1 class=\"h1_title\">" + m_Title + "</h1>\n");
            // szHtml+=("<H2 class=\"h2_titlesub\">Ref.: " + m_DocId.ToString() + "-" + m_DocLngId + "</h1>\n");
            string szTitle = Resources.Strings.mnTortoises_group + ": " + m_ATaxLevel + " " + m_ATaxIdName;
            string szTitleSub = "";
            UInt64 id = Convert.ToUInt64(m_DocId);
            String szUrl = "/tortoises/groups/group/";
           
            szHtml += cls.ClsHtml.FncHtmlTitle(szTitle, szTitleSub, m_DocId, m_DocLngId, szUrl);
            //szHtml += "<h1>" + Resources.Strings.mnTortoises_group + ": " + m_ATaxLevel + " " + m_ATaxIdName+ "<span class=\"fld-boxId\">"+ oRegDoc.DocId.ToString()+"</span>";
            szHtml += "<div class=\"panel \"><h2>" + Resources.Strings.Abstract + "</h2>";
            if (m_NameVulgar != "") szHtml += Resources.Strings.ATaxVulgar_ + ": " + m_NameVulgar + ".</br>";
            if (oRegDoc.DocImgThumbnail != "")
            {
                szHtml += "<img class=\"imgright\"src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            

            szHtml += m_Abstract + "</div>\n";
            szHtml += "Revisada =";
            if (m_IsOk)
            { szHtml += "Si"; }
            else
            { szHtml += "No"; }

            szHtml += ". ITIS 2014  =";
            if (m_IsTaxa2014)
            { szHtml += "Si"; }
            else
            { szHtml += "No"; }
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg01");
            string szImg01 = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg02");
            string szImg02 = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg03");
            string szImg03 = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg04");
            string szImg04 = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg05");
            string szImg05 = oRegTaxonFiles.AFileURL;
            oRegTaxonFiles.FncSqlFind(m_DocId, "TaxonGroupsImg06");
            string szImg06 = oRegTaxonFiles.AFileURL;
            szHtml += FncBldHtmlPretyPhoto6("imageslist", szImg01, szImg02, szImg03, szImg04, szImg05, szImg06, m_DescriptionShort, m_Title, "Taxon groups description");



            szHtml += "<h2>" + Resources.Strings.Article + "</h2>" + m_Body;
            szHtml += "<h3>" + Resources.Strings.Notes + "</h3>" + m_Notes;
            //http://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=202119
            if (m_Ref_ITIS_Number != 0)
            {
                szHtml += "<br/>Ref. ITIS Number: <a href =\"http://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + m_Ref_ITIS_Number.ToString() + "\" target=\"_blank\">" + m_Ref_ITIS_Number.ToString() + "</a><br/>";
            }

            if (oRegDoc.DocDocUploaded != "")
            {
                if (System.IO.File.Exists(ClsGlobal.DirDocStore + oRegDoc.DocDocUploaded))
                {
                    szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Anexed_document + "</h2>\n";

                    szHtml += "<a href=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocDocUploaded + "\" ico =\"ico\">" + oRegDoc.DocDocUploaded + "</a>";


                    szHtml += "</div>";
                }

            }
            // string sz = "";
          
            cls.cache.ClsCache_Tortoise oRegTaxon = new cls.cache.ClsCache_Tortoise();
            oRegTaxon.FncHtmlNearSpecies(false);
            //szHtml += FncHtmlLastTaxongGroups(false);

            szHtml += FncBldTaxaGroupList(m_ATaxIdName);

            if (oRegDoc.DocAcknowledgements != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Acknowledgements + "</h2>" + oRegDoc.DocAcknowledgements + "</div>\n");
            }

            if (m_Ref_ITIS_Number != 0)
            {
                szHtml += "<br/>" + Resources.Strings.scniTISTaxonomic_Serial_No + "<a href=\"http://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + m_Ref_ITIS_Number.ToString() + " target=\"_blank\">" + m_Ref_ITIS_Number.ToString() + "</a>";
            }
            if (oRegDoc.DocBibliography != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Bibliography + "</h2>" + oRegDoc.DocBibliography + "</div>\n");
            }
            return szHtml;


        }
        private string FncBldTaxaGroupList(string szTaxaName)
        {
            string szHtml = "<h3> " + Resources.Strings.listspeciessheetofgroup + ": " + szTaxaName + "</h3>";



            string szSql = "SELECT tdoclng_testudines_taxa_all.DocId, tdoclng_testudines_abst.DocLngId , tdoclng_testudines_taxa_all.ATaxGrpL2220SubOrder, tdoclng_testudines_taxa_all.ATaxGrpL2240Family,  tdoclng_testudines_taxa_all.ATaxGrpL2270Genus,tdoclng_testudines_taxa_all.ATaxGrpL2280Specie,tdoclng_testudines_taxa_all.ATaxGrpL2282Authority,ATaxGrpL2283Year FROM tdoclng_testudines_taxa_all LEFT JOIN tdoclng_testudines_abst ON tdoclng_testudines_taxa_all.DocId = tdoclng_testudines_abst.DocId  ";
            szSql += " where  tdoclng_testudines_taxa_all.ATaxGrpL2270Genus='" + szTaxaName + "' ";
            szSql += " order by tdoclng_testudines_taxa_all.ATaxGrpL2220SubOrder, tdoclng_testudines_taxa_all.ATaxGrpL2240Family,  tdoclng_testudines_taxa_all.ATaxGrpL2270Genus,tdoclng_testudines_taxa_all.ATaxGrpL2280Specie";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oDa.Fill(oTb);
            oDa.Dispose();
            oCmd.Dispose();

            oCnn.Close();
            if (oTb.Rows.Count == 0) return "";
            szHtml += "</br>" + Resources.Strings.ATaxGrpL2220SubOrder + " " + oTb.Rows[0]["ATaxGrpL2220SubOrder"].ToString();
            szHtml += "</br>" + Resources.Strings.ATaxGrpL2240Family + " " + oTb.Rows[0]["ATaxGrpL2240Family"].ToString();


            szHtml += "\n<ul>";
            foreach (DataRow oRow in oTb.Rows)
            {
                szHtml += "\n<li>";
                szHtml += "<a href=\"\"" + oRow["DocLngId"].ToString() + "/tortoises/tortoise/" + oRow["DocId"].ToString() + "\">";
                szHtml += oRow["ATaxGrpL2270Genus"].ToString() + " " + oRow["ATaxGrpL2280Specie"].ToString() + " " + oRow["ATaxGrpL2283Year"].ToString() + "</a>";
                ;
                szHtml += "</li>";
            }
            szHtml += "\n</ul>";
            return szHtml;
        }
        private string FncBldHtmlPretyPhoto6(string szGalleryId, string pImgThun01, string pImgThun02, string pImgThun03, string pImgThun04, string pImgThun05, string pImgThun06, string pTitTop, string pTitBot, string pSectionFile)
        {
            oPP.FncGallery_New(szGalleryId, "imageslist");

            String pUrlThumbDefault = "";
            //--------------------------------------------------------
            string xpUrlThumb01 = pImgThun01;
            string xpUrlThumb02 = pImgThun02;
            string xpUrlThumb03 = pImgThun03;
            string xpUrlThumb04 = pImgThun04;
            string xpUrlThumb05 = pImgThun05;
            string xpUrlThumb06 = pImgThun06;
            string xUrlTarget01 = "";
            string xUrlTarget02 = "";
            string xUrlTarget03 = "";
            string xUrlTarget04 = "";
            string xUrlTarget05 = "";
            string xUrlTarget06 = "";
            pTitTop = m_ATaxIdName + ", " + m_ATaxGrpL2282Authority + " " + m_ATaxGrpL2283Year;
            FncBldUrlTest(ref  xUrlTarget01, ref  xpUrlThumb01, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget01, xpUrlThumb01, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref  xUrlTarget02, ref  xpUrlThumb02, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget02, xpUrlThumb02, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref  xUrlTarget03, ref  xpUrlThumb03, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget03, xpUrlThumb03, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref  xUrlTarget04, ref  xpUrlThumb04, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget04, xpUrlThumb04, pTitTop, pTitBot, pSectionFile);
            FncBldUrlTest(ref  xUrlTarget05, ref  xpUrlThumb05, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget05, xpUrlThumb05, pTitTop, pTitBot, pSectionFile);
            FncBldUrlTest(ref  xUrlTarget06, ref  xpUrlThumb06, pUrlThumbDefault);
            oPP.FncGallery_AddPictureFB(xUrlTarget06, xpUrlThumb06, pTitTop, pTitBot, pSectionFile);
            return oPP.HtmGalleryFB;
        }
        private void FncBldUrlTest(ref String pUrlTarget, ref String pUrlThumb, String pUrlThumbDefault)
        {
            pUrlThumb = pUrlThumb.Trim().ToLower();
            pUrlTarget = pUrlTarget.Trim().ToLower();
            pUrlThumbDefault = pUrlThumbDefault.Trim().ToLower();
            String szUrlTargetDefault = "/a_img/noimage600px.png";
            // Por si las fly miniatura por defecto
            if (pUrlThumbDefault == "") pUrlThumbDefault = "/a_img/noimage200px.png";

            // si no existe el fichero thumb poner miniatura por defecto
            String szUrlTumbPath = ((ClsGlobal.DirRoot + pUrlThumb).Replace("\\", "/")).Replace("//", "/");

            if (!System.IO.File.Exists(szUrlTumbPath) || pUrlThumb.Contains("noimage"))
            {
                pUrlThumb = pUrlThumbDefault;
            }
            else
            {
                pUrlThumb = pUrlThumb.Trim().ToLower();
            }
            // buscar la imagen ligada al thumbnail
            if (pUrlTarget == "")
            {
                pUrlTarget = pUrlThumb.Replace("min.jpg", "med.jpg");
                pUrlTarget = pUrlTarget.Replace("_minx.jpg", "_med.jpg");
            }
            // comprobar la existencia del la imagen target,si no exsite poner la de defecto
            String szUrlTargetPath = ((ClsGlobal.UrlMMedia + pUrlTarget).Replace("\\", "/")).Replace("//", "/");

            if (!System.IO.File.Exists(szUrlTargetPath))
            {
                pUrlTarget = szUrlTargetDefault;
            }


        }


        //---------------------------------------
        public String FncCache_GET_last(bool bRebuild, UInt16 iCount)
        {
            string szFileCache = cls.ClsGlobal.DirCache + "last_groups.html";
            if (bRebuild) { ClsUtils.FncPathFileDelete(szFileCache); }
            if (System.IO.File.Exists(szFileCache))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileCache);
            }
            else
            {
                String szHtml = FncHtmlLastTaxongGroups(iCount);

                cls.cache.ClsCache.FncCacheFileSave(ref szFileCache, ref szHtml);
                return szHtml;
            }
        }
        private string FncHtmlLastTaxongGroups(UInt16 iCount)
        {

            string szSqlSelect = ""; // "select `tdoclng_testudines_groups`.`DocId` AS `DocId`,`tdoclng_testudines_groups`.`DocLngId` AS `DocLngId`,`tdoclng_testudines_groups`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_thumbnails/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`,`tdoc`.`DocStdValLow` AS `DocStdValLow`,`tdoc`.`DocStdValHig` AS `DocStdValHig`,`tdoc`.`DocStdValMed` AS `DocStdValMed` from (`tdoclng_testudines_groups` left join `tdoc` on((`tdoclng_testudines_groups`.`DocId` = `tdoc`.`DocId`))) where (`tdoc`.`DocIsActive` = 1) order by `tdoclng_testudines_groups`.`DocId` desc limit 20";
            
             szSqlSelect+=" select tdoclng_sitemap.loc_title as url,  `tdoclng_testudines_groups`.`DocId` AS `DocId`,`tdoclng_testudines_groups`.`DocLngId` AS `DocLngId`,`tdoclng_testudines_groups`.`Title` AS `Title`,`tdoc`.`DocTypeGroup` AS `DocTypeGroup`,concat('/a_files/doc_thumbnails/',`tdoc`.`DocImgThumbnail`) AS `DocImgThumbnail`,`tdoc`.`DocDateUpdate` AS `DocDateUpdate`,`tdoc`.`DocStdValLow` AS `DocStdValLow`,`tdoc`.`DocStdValHig` AS `DocStdValHig`,`tdoc`.`DocStdValMed` AS `DocStdValMed` ";
szSqlSelect+=" from `tdoclng_testudines_groups` ";
            szSqlSelect += " inner join `tdoc` on(`tdoclng_testudines_groups`.`DocId` = `tdoc`.`DocId`) inner join  `tdoclng_sitemap` on (`tdoclng_testudines_groups`.`DocId` = `tdoclng_sitemap`.`DocId` and `tdoclng_testudines_groups`.`DocLngId` = `tdoclng_sitemap`.`DocLngId` ) ";
szSqlSelect+=" where (`tdoc`.`DocIsActive` = 1) order by `tdoclng_testudines_groups`.`DocId` desc limit "+iCount.ToString();
             
             

            //string szSqlSelect = "Select `DocId`,`DocLngId`,`Title`,`DocImgThumbnail`,`DocDateUpdate`,  `DocStdValLow`, `DocStdValHig`, `DocStdValMed` from `warticlelast20`";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlSelect, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oDt = new DataTable();
            oCnn.Open();
            oDa.Fill(oDt);
            oCnn.Close();
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Dispose();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<h2>" + Resources.Strings.Last_Update_tortoise_group + "</h2>");
            sb.Append("<ul>");
            string szUrl = "";
            foreach (DataRow oRow in oDt.Rows)
            {
                szUrl = "/" + oRow["DocLngId"].ToString() + "/tortoises/groups/group/" + oRow["DocId"].ToString();
                szUrl = oRow["url"].ToString();
                sb.Append("<li><b><a href=\"" + szUrl + "\">" + oRow["Title"].ToString() + "</a></b>");
                // DocImgThumbnail
                sb.Append("<br/ ><span class=\"mmin-x\">" + Resources.Strings.Updated + " " + oRow["DocDateUpdate"].ToString() + "\"</span>");
                sb.Append("<br/>" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(oRow["DocId"].ToString()), "/articles/article/"));
                sb.Append("<br/><br/></li>");
            }

            sb.Append("<li><b><a href=\"/" + ClsGlobal.LngIdThread + "/articles/articles\">" + Resources.Strings.Articles_clasifiated_list + "</a></b>");

            sb.Append("<ul>");

            return sb.ToString();
        }
    }
}
