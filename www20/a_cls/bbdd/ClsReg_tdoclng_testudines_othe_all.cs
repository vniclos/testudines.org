using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsReg_tdoclng_testudines_othe_all
    //<//summary>
    public class ClsReg_tdoclng_testudines_othe_all
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
        private Double m_DocId = 0;
        private Boolean m_AOth_WorkFlow_IsRewrited = false;
        private Boolean m_AOth_WorkFlow_Updating = false;
        private System.DateTime m_AOth_WorkFlow_LastUpdate = System.DateTime.Now.Date;
        private Double m_AOth_LnkId_EOL = 0;
        private Double m_AOth_LnkId_ITISTSN = 0;
        private Double m_AOth_LnkId_NCBI = 0;
        private Double m_AOth_LnkId_INaturalist = 0;
        private Double m_AOth_LnkId_GBIF = 0;
        private Double m_AOth_LnkId_EUNIS = 0;
        private String m_AOth_LnkId_WikiData = "";
        private String m_AOth_LnkUrl_TurtlesOfTheWorld = "";
        private String m_AOth_LnkUrl_ReptileDataBase = "";
        private String m_AOth_LnkUrl_IUCN = "";
        private String m_AOth_LnkUrl_IUCNRedLIst = "";
        private String m_AOth_LnkUrl_CITESDoc = "";
        private String m_AOth_LnkUrl_2000 = "";
        private String m_AOth_LnkUrl_Animaldiversity_org = "";
        private String m_AOth_LnkUrl_Other = "";
        private String m_AOth_UrlImages = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------
        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_othe_all()
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
            m_AOth_WorkFlow_IsRewrited = false;
            m_AOth_WorkFlow_Updating = false;
            m_AOth_WorkFlow_LastUpdate = System.DateTime.Now.Date;
            m_AOth_LnkId_EOL = 0;
            m_AOth_LnkId_ITISTSN = 0;
            m_AOth_LnkId_NCBI = 0;
            m_AOth_LnkId_INaturalist = 0;
            m_AOth_LnkId_GBIF = 0;
            m_AOth_LnkId_EUNIS = 0;
            m_AOth_LnkId_WikiData = "";
            m_AOth_LnkUrl_TurtlesOfTheWorld = "";
            m_AOth_LnkUrl_ReptileDataBase = "";
            m_AOth_LnkUrl_IUCN = "";
            m_AOth_LnkUrl_IUCNRedLIst = "";
            m_AOth_LnkUrl_CITESDoc = "";
            m_AOth_LnkUrl_2000 = "";
            m_AOth_LnkUrl_Animaldiversity_org = "";
            m_AOth_LnkUrl_Other = "";
            m_AOth_UrlImages = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_othe_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_othe_all";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", AOth_WorkFlow_IsRewrited ";
            szSql += ", AOth_WorkFlow_Updating ";
            szSql += ", AOth_WorkFlow_LastUpdate ";
            szSql += ", AOth_LnkId_EOL ";
            szSql += ", AOth_LnkId_ITISTSN ";
            szSql += ", AOth_LnkId_NCBI ";
            szSql += ", AOth_LnkId_INaturalist ";
            szSql += ", AOth_LnkId_GBIF ";
            szSql += ", AOth_LnkId_EUNIS ";
            szSql += ", AOth_LnkId_WikiData ";
            szSql += ", AOth_LnkUrl_TurtlesOfTheWorld ";
            szSql += ", AOth_LnkUrl_ReptileDataBase ";
            szSql += ", AOth_LnkUrl_IUCN ";
            szSql += ", AOth_LnkUrl_IUCNRedLIst ";
            szSql += ", AOth_LnkUrl_CITESDoc ";
            szSql += ", AOth_LnkUrl_2000 ";
            szSql += ", AOth_LnkUrl_Animaldiversity_org ";
            szSql += ", AOth_LnkUrl_Other ";
            szSql += ", AOth_UrlImages ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @AOth_WorkFlow_IsRewrited ";
            szSql += ", @AOth_WorkFlow_Updating ";
            szSql += ", @AOth_WorkFlow_LastUpdate ";
            szSql += ", @AOth_LnkId_EOL ";
            szSql += ", @AOth_LnkId_ITISTSN ";
            szSql += ", @AOth_LnkId_NCBI ";
            szSql += ", @AOth_LnkId_INaturalist ";
            szSql += ", @AOth_LnkId_GBIF ";
            szSql += ", @AOth_LnkId_EUNIS ";
            szSql += ", @AOth_LnkId_WikiData ";
            szSql += ", @AOth_LnkUrl_TurtlesOfTheWorld ";
            szSql += ", @AOth_LnkUrl_ReptileDataBase ";
            szSql += ", @AOth_LnkUrl_IUCN ";
            szSql += ", @AOth_LnkUrl_IUCNRedLIst ";
            szSql += ", @AOth_LnkUrl_CITESDoc ";
            szSql += ", @AOth_LnkUrl_2000 ";
            szSql += ", @AOth_LnkUrl_Animaldiversity_org ";
            szSql += ", @AOth_LnkUrl_Other ";
            szSql += ", @AOth_UrlImages ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_WorkFlow_IsRewrited", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AOth_WorkFlow_Updating", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AOth_WorkFlow_LastUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_EOL", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_ITISTSN", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_NCBI", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_INaturalist", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_GBIF", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_EUNIS", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkId_WikiData", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_TurtlesOfTheWorld", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_ReptileDataBase", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_IUCN", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_IUCNRedLIst", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_CITESDoc", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_2000", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_Animaldiversity_org", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AOth_LnkUrl_Other", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@AOth_UrlImages", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_othe_all SET ";

            szSql += "AOth_WorkFlow_IsRewrited=@AOth_WorkFlow_IsRewrited ";
            szSql += ", AOth_WorkFlow_Updating=@AOth_WorkFlow_Updating ";
            szSql += ", AOth_WorkFlow_LastUpdate=@AOth_WorkFlow_LastUpdate ";
            szSql += ", AOth_LnkId_EOL=@AOth_LnkId_EOL ";
            szSql += ", AOth_LnkId_ITISTSN=@AOth_LnkId_ITISTSN ";
            szSql += ", AOth_LnkId_NCBI=@AOth_LnkId_NCBI ";
            szSql += ", AOth_LnkId_INaturalist=@AOth_LnkId_INaturalist ";
            szSql += ", AOth_LnkId_GBIF=@AOth_LnkId_GBIF ";
            szSql += ", AOth_LnkId_EUNIS=@AOth_LnkId_EUNIS ";
            szSql += ", AOth_LnkId_WikiData=@AOth_LnkId_WikiData ";
            szSql += ", AOth_LnkUrl_TurtlesOfTheWorld=@AOth_LnkUrl_TurtlesOfTheWorld ";
            szSql += ", AOth_LnkUrl_ReptileDataBase=@AOth_LnkUrl_ReptileDataBase ";
            szSql += ", AOth_LnkUrl_IUCN=@AOth_LnkUrl_IUCN ";
            szSql += ", AOth_LnkUrl_IUCNRedLIst=@AOth_LnkUrl_IUCNRedLIst ";
            szSql += ", AOth_LnkUrl_CITESDoc=@AOth_LnkUrl_CITESDoc ";
            szSql += ", AOth_LnkUrl_2000=@AOth_LnkUrl_2000 ";
            szSql += ", AOth_LnkUrl_Animaldiversity_org=@AOth_LnkUrl_Animaldiversity_org ";
            szSql += ", AOth_LnkUrl_Other=@AOth_LnkUrl_Other ";
            szSql += ", AOth_UrlImages=@AOth_UrlImages ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_WorkFlow_IsRewrited", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AOth_WorkFlow_Updating", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AOth_WorkFlow_LastUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_EOL", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_ITISTSN", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_NCBI", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_INaturalist", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_GBIF", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_EUNIS", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkId_WikiData", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_TurtlesOfTheWorld", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_ReptileDataBase", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_IUCN", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_IUCNRedLIst", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_CITESDoc", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_2000", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_Animaldiversity_org", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AOth_LnkUrl_Other", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@AOth_UrlImages", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_othe_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";
            szSql += " FROM tdoclng_testudines_othe_all  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Double);
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
            oSqlCmdUpdate.Parameters["@AOth_WorkFlow_IsRewrited"].Value = m_AOth_WorkFlow_IsRewrited;
            oSqlCmdUpdate.Parameters["@AOth_WorkFlow_Updating"].Value = m_AOth_WorkFlow_Updating;
            oSqlCmdUpdate.Parameters["@AOth_WorkFlow_LastUpdate"].Value = m_AOth_WorkFlow_LastUpdate;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_EOL"].Value = m_AOth_LnkId_EOL;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_ITISTSN"].Value = m_AOth_LnkId_ITISTSN;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_NCBI"].Value = m_AOth_LnkId_NCBI;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_INaturalist"].Value = m_AOth_LnkId_INaturalist;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_GBIF"].Value = m_AOth_LnkId_GBIF;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_EUNIS"].Value = m_AOth_LnkId_EUNIS;
            oSqlCmdUpdate.Parameters["@AOth_LnkId_WikiData"].Value = m_AOth_LnkId_WikiData;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_TurtlesOfTheWorld"].Value = m_AOth_LnkUrl_TurtlesOfTheWorld;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_ReptileDataBase"].Value = m_AOth_LnkUrl_ReptileDataBase;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_IUCN"].Value = m_AOth_LnkUrl_IUCN;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_IUCNRedLIst"].Value = m_AOth_LnkUrl_IUCNRedLIst;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_CITESDoc"].Value = m_AOth_LnkUrl_CITESDoc;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_2000"].Value = m_AOth_LnkUrl_2000;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_Animaldiversity_org"].Value = m_AOth_LnkUrl_Animaldiversity_org;
            oSqlCmdUpdate.Parameters["@AOth_LnkUrl_Other"].Value = m_AOth_LnkUrl_Other;
            oSqlCmdUpdate.Parameters["@AOth_UrlImages"].Value = m_AOth_UrlImages;
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
            oSqlCmdInsert.Parameters["@AOth_WorkFlow_IsRewrited"].Value = m_AOth_WorkFlow_IsRewrited;
            oSqlCmdInsert.Parameters["@AOth_WorkFlow_Updating"].Value = m_AOth_WorkFlow_Updating;
            oSqlCmdInsert.Parameters["@AOth_WorkFlow_LastUpdate"].Value = m_AOth_WorkFlow_LastUpdate;
            oSqlCmdInsert.Parameters["@AOth_LnkId_EOL"].Value = m_AOth_LnkId_EOL;
            oSqlCmdInsert.Parameters["@AOth_LnkId_ITISTSN"].Value = m_AOth_LnkId_ITISTSN;
            oSqlCmdInsert.Parameters["@AOth_LnkId_NCBI"].Value = m_AOth_LnkId_NCBI;
            oSqlCmdInsert.Parameters["@AOth_LnkId_INaturalist"].Value = m_AOth_LnkId_INaturalist;
            oSqlCmdInsert.Parameters["@AOth_LnkId_GBIF"].Value = m_AOth_LnkId_GBIF;
            oSqlCmdInsert.Parameters["@AOth_LnkId_EUNIS"].Value = m_AOth_LnkId_EUNIS;
            oSqlCmdInsert.Parameters["@AOth_LnkId_WikiData"].Value = m_AOth_LnkId_WikiData;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_TurtlesOfTheWorld"].Value = m_AOth_LnkUrl_TurtlesOfTheWorld;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_ReptileDataBase"].Value = m_AOth_LnkUrl_ReptileDataBase;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_IUCN"].Value = m_AOth_LnkUrl_IUCN;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_IUCNRedLIst"].Value = m_AOth_LnkUrl_IUCNRedLIst;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_CITESDoc"].Value = m_AOth_LnkUrl_CITESDoc;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_2000"].Value = m_AOth_LnkUrl_2000;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_Animaldiversity_org"].Value = m_AOth_LnkUrl_Animaldiversity_org;
            oSqlCmdInsert.Parameters["@AOth_LnkUrl_Other"].Value = m_AOth_LnkUrl_Other;
            oSqlCmdInsert.Parameters["@AOth_UrlImages"].Value = m_AOth_UrlImages;
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
        public bool FncSqlFind(Double DocId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            if (!ClsMysql.FncOpen("")) { return false; }
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
            //----------------------------------------------------
            MySqlDataReader oDR = null; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToDouble(oDR["DocId"].ToString());
                    m_AOth_WorkFlow_IsRewrited = Convert.ToBoolean(oDR["AOth_WorkFlow_IsRewrited"].ToString());
                    m_AOth_WorkFlow_Updating = Convert.ToBoolean(oDR["AOth_WorkFlow_Updating"].ToString());
                    m_AOth_WorkFlow_LastUpdate = Convert.ToDateTime(oDR["AOth_WorkFlow_LastUpdate"].ToString());
                    m_AOth_LnkId_EOL = Convert.ToDouble(oDR["AOth_LnkId_EOL"].ToString());
                    m_AOth_LnkId_ITISTSN = Convert.ToDouble(oDR["AOth_LnkId_ITISTSN"].ToString());
                    m_AOth_LnkId_NCBI = Convert.ToDouble(oDR["AOth_LnkId_NCBI"].ToString());
                    m_AOth_LnkId_INaturalist = Convert.ToDouble(oDR["AOth_LnkId_INaturalist"].ToString());
                    m_AOth_LnkId_GBIF = Convert.ToDouble(oDR["AOth_LnkId_GBIF"].ToString());
                    m_AOth_LnkId_EUNIS = Convert.ToDouble(oDR["AOth_LnkId_EUNIS"].ToString());
                    m_AOth_LnkId_WikiData = oDR["AOth_LnkId_WikiData"].ToString();
                    m_AOth_LnkUrl_TurtlesOfTheWorld = oDR["AOth_LnkUrl_TurtlesOfTheWorld"].ToString();
                    m_AOth_LnkUrl_ReptileDataBase = oDR["AOth_LnkUrl_ReptileDataBase"].ToString();
                    m_AOth_LnkUrl_IUCN = oDR["AOth_LnkUrl_IUCN"].ToString();
                    m_AOth_LnkUrl_IUCNRedLIst = oDR["AOth_LnkUrl_IUCNRedLIst"].ToString();
                    m_AOth_LnkUrl_CITESDoc = oDR["AOth_LnkUrl_CITESDoc"].ToString();
                    m_AOth_LnkUrl_2000 = oDR["AOth_LnkUrl_2000"].ToString();
                    m_AOth_LnkUrl_Animaldiversity_org = oDR["AOth_LnkUrl_Animaldiversity_org"].ToString();
                    m_AOth_LnkUrl_Other = oDR["AOth_LnkUrl_Other"].ToString();
                    m_AOth_UrlImages = oDR["AOth_UrlImages"].ToString();
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
            finally
            {
                if (oDR != null) { oDR.Close(); }
            }
            //------------------------------------------------------
            // cierre.
            //-------------------------------------------------------
            return !_mErrorBoolean;
            //--------------------------------------------------------------------
        }
        //--------------------------------------------------------r
        //----------------FncSqlDelete--------------------------
        //--------------------------------------------------------
        public bool FncSqlDelete(Double DocId)
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

        public Double DocId
        {
            set
            {
                m_DocId = value;
            }
            get { return m_DocId; }
        }

        //................................

        public Boolean AOth_WorkFlow_IsRewrited
        {
            set
            {
                m_AOth_WorkFlow_IsRewrited = value;
            }
            get { return m_AOth_WorkFlow_IsRewrited; }
        }

        //................................

        public Boolean AOth_WorkFlow_Updating
        {
            set
            {
                m_AOth_WorkFlow_Updating = value;
            }
            get { return m_AOth_WorkFlow_Updating; }
        }

        //................................

        public System.DateTime AOth_WorkFlow_LastUpdate
        {
            set
            {
                m_AOth_WorkFlow_LastUpdate = value;
            }
            get { return m_AOth_WorkFlow_LastUpdate; }
        }

        //................................

        public Double AOth_LnkId_EOL
        {
            set
            {
                m_AOth_LnkId_EOL = value;
            }
            get { return m_AOth_LnkId_EOL; }
        }

        //................................

        public Double AOth_LnkId_ITISTSN
        {
            set
            {
                m_AOth_LnkId_ITISTSN = value;
            }
            get { return m_AOth_LnkId_ITISTSN; }
        }

        //................................

        public Double AOth_LnkId_NCBI
        {
            set
            {
                m_AOth_LnkId_NCBI = value;
            }
            get { return m_AOth_LnkId_NCBI; }
        }

        //................................

        public Double AOth_LnkId_INaturalist
        {
            set
            {
                m_AOth_LnkId_INaturalist = value;
            }
            get { return m_AOth_LnkId_INaturalist; }
        }

        //................................

        public Double AOth_LnkId_GBIF
        {
            set
            {
                m_AOth_LnkId_GBIF = value;
            }
            get { return m_AOth_LnkId_GBIF; }
        }

        //................................

        public Double AOth_LnkId_EUNIS
        {
            set
            {
                m_AOth_LnkId_EUNIS = value;
            }
            get { return m_AOth_LnkId_EUNIS; }
        }

        //................................

        public String AOth_LnkId_WikiData
        {
            set
            {
                m_AOth_LnkId_WikiData = value;
            }
            get { return m_AOth_LnkId_WikiData; }
        }

        //................................

        public String AOth_LnkUrl_TurtlesOfTheWorld
        {
            set
            {
                m_AOth_LnkUrl_TurtlesOfTheWorld = value;
            }
            get { return m_AOth_LnkUrl_TurtlesOfTheWorld; }
        }

        //................................

        public String AOth_LnkUrl_ReptileDataBase
        {
            set
            {
                m_AOth_LnkUrl_ReptileDataBase = value;
            }
            get { return m_AOth_LnkUrl_ReptileDataBase; }
        }

        //................................

        public String AOth_LnkUrl_IUCN
        {
            set
            {
                m_AOth_LnkUrl_IUCN = value;
            }
            get { return m_AOth_LnkUrl_IUCN; }
        }

        //................................

        public String AOth_LnkUrl_IUCNRedLIst
        {
            set
            {
                m_AOth_LnkUrl_IUCNRedLIst = value;
            }
            get { return m_AOth_LnkUrl_IUCNRedLIst; }
        }

        //................................

        public String AOth_LnkUrl_CITESDoc
        {
            set
            {
                m_AOth_LnkUrl_CITESDoc = value;
            }
            get { return m_AOth_LnkUrl_CITESDoc; }
        }

        //................................

        public String AOth_LnkUrl_2000
        {
            set
            {
                m_AOth_LnkUrl_2000 = value;
            }
            get { return m_AOth_LnkUrl_2000; }
        }

        //................................

        public String AOth_LnkUrl_Animaldiversity_org
        {
            set
            {
                m_AOth_LnkUrl_Animaldiversity_org = value;
            }
            get { return m_AOth_LnkUrl_Animaldiversity_org; }
        }

        //................................

        public String AOth_LnkUrl_Other
        {
            set
            {
                m_AOth_LnkUrl_Other = value;
            }
            get { return m_AOth_LnkUrl_Other; }
        }

        //................................

        public String AOth_UrlImages
        {
            set
            {
                m_AOth_UrlImages = value;
            }
            get { return m_AOth_UrlImages; }
        }

        #endregion VALORES_GETSET

    }
}