using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsReg_tdoclng_testudines_taxa_all
    //<//summary>
    public class ClsReg_tdoclng_testudines_taxa_all
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
        private UInt64 m_DocId = 0;
        private UInt64 m_Atax_DocId_validRedirect = 0;
        private String m_ATax_ItisTsn = "";
        private System.DateTime m_Atax_ItisUdatedDate = System.DateTime.Now.Date;
        private Boolean m_Atax_ItisIsValid = false;
        private String m_ATax_ItisInvalidateNote = "";
        private UInt64 m_Atax_ItisValidRedirect_Tsn = 0;
        private String m_ATaxNameVulgarEN = "";
        private String m_ATaxNameVulgarES = "";
        private String m_ATaxNameVulgarOthers = "";
        private String m_ATaxGrpL0000Level = "";
        private String m_ATaxGrpL0001lNameFullRecomeded = "";
        private String m_ATaxGrpL0002NameSinonimous = "";
        private String m_ATaxGrpL2000Class = "";
        private String m_ATaxGrpL2210Order = "";
        private String m_ATaxGrpL2220SubOrder = "";
        private String m_ATaxGrpL2230SupFamily = "";
        private String m_ATaxGrpL2240Family = "";
        private String m_ATaxGrpL2250SubFamily = "";
        private String m_ATaxGrpL2260SupGenus = "";
        private String m_ATaxGrpL2270Genus = "";
        private String m_ATaxGrpL2280Specie = "";
        private String m_ATaxGrpL2281SubSpecie = "";
        private String m_ATaxGrpL2282Authority = "";
        private String m_ATaxGrpL2283Year = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------
        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_taxa_all()
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
            m_Atax_DocId_validRedirect = 0;
            m_ATax_ItisTsn = "";
            m_Atax_ItisUdatedDate = System.DateTime.Now.Date;
            m_Atax_ItisIsValid = false;
            m_ATax_ItisInvalidateNote = "";
            m_Atax_ItisValidRedirect_Tsn = 0;
            m_ATaxNameVulgarEN = "";
            m_ATaxNameVulgarES = "";
            m_ATaxNameVulgarOthers = "";
            m_ATaxGrpL0000Level = "";
            m_ATaxGrpL0001lNameFullRecomeded = "";
            m_ATaxGrpL0002NameSinonimous = "";
            m_ATaxGrpL2000Class = "";
            m_ATaxGrpL2210Order = "";
            m_ATaxGrpL2220SubOrder = "";
            m_ATaxGrpL2230SupFamily = "";
            m_ATaxGrpL2240Family = "";
            m_ATaxGrpL2250SubFamily = "";
            m_ATaxGrpL2260SupGenus = "";
            m_ATaxGrpL2270Genus = "";
            m_ATaxGrpL2280Specie = "";
            m_ATaxGrpL2281SubSpecie = "";
            m_ATaxGrpL2282Authority = "";
            m_ATaxGrpL2283Year = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_taxa_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_taxa_all";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", Atax_DocId_validRedirect ";
            szSql += ", ATax_ItisTsn ";
            szSql += ", Atax_ItisUdatedDate ";
            szSql += ", Atax_ItisIsValid ";
            szSql += ", ATax_ItisInvalidateNote ";
            szSql += ", Atax_ItisValidRedirect_Tsn ";
            szSql += ", ATaxNameVulgarEN ";
            szSql += ", ATaxNameVulgarES ";
            szSql += ", ATaxNameVulgarOthers ";
            szSql += ", ATaxGrpL0000Level ";
            szSql += ", ATaxGrpL0001lNameFullRecomeded ";
            szSql += ", ATaxGrpL0002NameSinonimous ";
            szSql += ", ATaxGrpL2000Class ";
            szSql += ", ATaxGrpL2210Order ";
            szSql += ", ATaxGrpL2220SubOrder ";
            szSql += ", ATaxGrpL2230SupFamily ";
            szSql += ", ATaxGrpL2240Family ";
            szSql += ", ATaxGrpL2250SubFamily ";
            szSql += ", ATaxGrpL2260SupGenus ";
            szSql += ", ATaxGrpL2270Genus ";
            szSql += ", ATaxGrpL2280Specie ";
            szSql += ", ATaxGrpL2281SubSpecie ";
            szSql += ", ATaxGrpL2282Authority ";
            szSql += ", ATaxGrpL2283Year ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @Atax_DocId_validRedirect ";
            szSql += ", @ATax_ItisTsn ";
            szSql += ", @Atax_ItisUdatedDate ";
            szSql += ", @Atax_ItisIsValid ";
            szSql += ", @ATax_ItisInvalidateNote ";
            szSql += ", @Atax_ItisValidRedirect_Tsn ";
            szSql += ", @ATaxNameVulgarEN ";
            szSql += ", @ATaxNameVulgarES ";
            szSql += ", @ATaxNameVulgarOthers ";
            szSql += ", @ATaxGrpL0000Level ";
            szSql += ", @ATaxGrpL0001lNameFullRecomeded ";
            szSql += ", @ATaxGrpL0002NameSinonimous ";
            szSql += ", @ATaxGrpL2000Class ";
            szSql += ", @ATaxGrpL2210Order ";
            szSql += ", @ATaxGrpL2220SubOrder ";
            szSql += ", @ATaxGrpL2230SupFamily ";
            szSql += ", @ATaxGrpL2240Family ";
            szSql += ", @ATaxGrpL2250SubFamily ";
            szSql += ", @ATaxGrpL2260SupGenus ";
            szSql += ", @ATaxGrpL2270Genus ";
            szSql += ", @ATaxGrpL2280Specie ";
            szSql += ", @ATaxGrpL2281SubSpecie ";
            szSql += ", @ATaxGrpL2282Authority ";
            szSql += ", @ATaxGrpL2283Year ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@Atax_DocId_validRedirect", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@ATax_ItisTsn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@Atax_ItisUdatedDate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@Atax_ItisIsValid", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@ATax_ItisInvalidateNote", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@Atax_ItisValidRedirect_Tsn", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@ATaxNameVulgarEN", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxNameVulgarES", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxNameVulgarOthers", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL0000Level", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL0001lNameFullRecomeded", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL0002NameSinonimous", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2000Class", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2210Order", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2220SubOrder", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2230SupFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2240Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2250SubFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2260SupGenus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2270Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2280Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2281SubSpecie", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2282Authority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@ATaxGrpL2283Year", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_taxa_all SET ";

            szSql += "Atax_DocId_validRedirect=@Atax_DocId_validRedirect ";
            szSql += ", ATax_ItisTsn=@ATax_ItisTsn ";
            szSql += ", Atax_ItisUdatedDate=@Atax_ItisUdatedDate ";
            szSql += ", Atax_ItisIsValid=@Atax_ItisIsValid ";
            szSql += ", ATax_ItisInvalidateNote=@ATax_ItisInvalidateNote ";
            szSql += ", Atax_ItisValidRedirect_Tsn=@Atax_ItisValidRedirect_Tsn ";
            szSql += ", ATaxNameVulgarEN=@ATaxNameVulgarEN ";
            szSql += ", ATaxNameVulgarES=@ATaxNameVulgarES ";
            szSql += ", ATaxNameVulgarOthers=@ATaxNameVulgarOthers ";
            szSql += ", ATaxGrpL0000Level=@ATaxGrpL0000Level ";
            szSql += ", ATaxGrpL0001lNameFullRecomeded=@ATaxGrpL0001lNameFullRecomeded ";
            szSql += ", ATaxGrpL0002NameSinonimous=@ATaxGrpL0002NameSinonimous ";
            szSql += ", ATaxGrpL2000Class=@ATaxGrpL2000Class ";
            szSql += ", ATaxGrpL2210Order=@ATaxGrpL2210Order ";
            szSql += ", ATaxGrpL2220SubOrder=@ATaxGrpL2220SubOrder ";
            szSql += ", ATaxGrpL2230SupFamily=@ATaxGrpL2230SupFamily ";
            szSql += ", ATaxGrpL2240Family=@ATaxGrpL2240Family ";
            szSql += ", ATaxGrpL2250SubFamily=@ATaxGrpL2250SubFamily ";
            szSql += ", ATaxGrpL2260SupGenus=@ATaxGrpL2260SupGenus ";
            szSql += ", ATaxGrpL2270Genus=@ATaxGrpL2270Genus ";
            szSql += ", ATaxGrpL2280Specie=@ATaxGrpL2280Specie ";
            szSql += ", ATaxGrpL2281SubSpecie=@ATaxGrpL2281SubSpecie ";
            szSql += ", ATaxGrpL2282Authority=@ATaxGrpL2282Authority ";
            szSql += ", ATaxGrpL2283Year=@ATaxGrpL2283Year ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@Atax_DocId_validRedirect", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@ATax_ItisTsn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@Atax_ItisUdatedDate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@Atax_ItisIsValid", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@ATax_ItisInvalidateNote", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@Atax_ItisValidRedirect_Tsn", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@ATaxNameVulgarEN", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxNameVulgarES", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxNameVulgarOthers", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL0000Level", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL0001lNameFullRecomeded", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL0002NameSinonimous", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2000Class", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2210Order", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2220SubOrder", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2230SupFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2240Family", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2250SubFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2260SupGenus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2270Genus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2280Specie", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2281SubSpecie", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2282Authority", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@ATaxGrpL2283Year", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_taxa_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";
            szSql += " FROM tdoclng_testudines_taxa_all  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
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
            oSqlCmdUpdate.Parameters["@Atax_DocId_validRedirect"].Value = m_Atax_DocId_validRedirect;
            oSqlCmdUpdate.Parameters["@ATax_ItisTsn"].Value = m_ATax_ItisTsn;
            oSqlCmdUpdate.Parameters["@Atax_ItisUdatedDate"].Value = m_Atax_ItisUdatedDate;
            oSqlCmdUpdate.Parameters["@Atax_ItisIsValid"].Value = m_Atax_ItisIsValid;
            oSqlCmdUpdate.Parameters["@ATax_ItisInvalidateNote"].Value = m_ATax_ItisInvalidateNote;
            oSqlCmdUpdate.Parameters["@Atax_ItisValidRedirect_Tsn"].Value = m_Atax_ItisValidRedirect_Tsn;
            oSqlCmdUpdate.Parameters["@ATaxNameVulgarEN"].Value = m_ATaxNameVulgarEN;
            oSqlCmdUpdate.Parameters["@ATaxNameVulgarES"].Value = m_ATaxNameVulgarES;
            oSqlCmdUpdate.Parameters["@ATaxNameVulgarOthers"].Value = m_ATaxNameVulgarOthers;
            oSqlCmdUpdate.Parameters["@ATaxGrpL0000Level"].Value = m_ATaxGrpL0000Level;
            oSqlCmdUpdate.Parameters["@ATaxGrpL0001lNameFullRecomeded"].Value = m_ATaxGrpL0001lNameFullRecomeded;
            oSqlCmdUpdate.Parameters["@ATaxGrpL0002NameSinonimous"].Value = m_ATaxGrpL0002NameSinonimous;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2000Class"].Value = m_ATaxGrpL2000Class;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2210Order"].Value = m_ATaxGrpL2210Order;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2220SubOrder"].Value = m_ATaxGrpL2220SubOrder;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2230SupFamily"].Value = m_ATaxGrpL2230SupFamily;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2240Family"].Value = m_ATaxGrpL2240Family;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2250SubFamily"].Value = m_ATaxGrpL2250SubFamily;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2260SupGenus"].Value = m_ATaxGrpL2260SupGenus;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2270Genus"].Value = m_ATaxGrpL2270Genus;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2280Specie"].Value = m_ATaxGrpL2280Specie;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2281SubSpecie"].Value = m_ATaxGrpL2281SubSpecie;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2282Authority"].Value = m_ATaxGrpL2282Authority;
            oSqlCmdUpdate.Parameters["@ATaxGrpL2283Year"].Value = m_ATaxGrpL2283Year;
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
            oSqlCmdInsert.Parameters["@Atax_DocId_validRedirect"].Value = m_Atax_DocId_validRedirect;
            oSqlCmdInsert.Parameters["@ATax_ItisTsn"].Value = m_ATax_ItisTsn;
            oSqlCmdInsert.Parameters["@Atax_ItisUdatedDate"].Value = m_Atax_ItisUdatedDate;
            oSqlCmdInsert.Parameters["@Atax_ItisIsValid"].Value = m_Atax_ItisIsValid;
            oSqlCmdInsert.Parameters["@ATax_ItisInvalidateNote"].Value = m_ATax_ItisInvalidateNote;
            oSqlCmdInsert.Parameters["@Atax_ItisValidRedirect_Tsn"].Value = m_Atax_ItisValidRedirect_Tsn;
            oSqlCmdInsert.Parameters["@ATaxNameVulgarEN"].Value = m_ATaxNameVulgarEN;
            oSqlCmdInsert.Parameters["@ATaxNameVulgarES"].Value = m_ATaxNameVulgarES;
            oSqlCmdInsert.Parameters["@ATaxNameVulgarOthers"].Value = m_ATaxNameVulgarOthers;
            oSqlCmdInsert.Parameters["@ATaxGrpL0000Level"].Value = m_ATaxGrpL0000Level;
            oSqlCmdInsert.Parameters["@ATaxGrpL0001lNameFullRecomeded"].Value = m_ATaxGrpL0001lNameFullRecomeded;
            oSqlCmdInsert.Parameters["@ATaxGrpL0002NameSinonimous"].Value = m_ATaxGrpL0002NameSinonimous;
            oSqlCmdInsert.Parameters["@ATaxGrpL2000Class"].Value = m_ATaxGrpL2000Class;
            oSqlCmdInsert.Parameters["@ATaxGrpL2210Order"].Value = m_ATaxGrpL2210Order;
            oSqlCmdInsert.Parameters["@ATaxGrpL2220SubOrder"].Value = m_ATaxGrpL2220SubOrder;
            oSqlCmdInsert.Parameters["@ATaxGrpL2230SupFamily"].Value = m_ATaxGrpL2230SupFamily;
            oSqlCmdInsert.Parameters["@ATaxGrpL2240Family"].Value = m_ATaxGrpL2240Family;
            oSqlCmdInsert.Parameters["@ATaxGrpL2250SubFamily"].Value = m_ATaxGrpL2250SubFamily;
            oSqlCmdInsert.Parameters["@ATaxGrpL2260SupGenus"].Value = m_ATaxGrpL2260SupGenus;
            oSqlCmdInsert.Parameters["@ATaxGrpL2270Genus"].Value = m_ATaxGrpL2270Genus;
            oSqlCmdInsert.Parameters["@ATaxGrpL2280Specie"].Value = m_ATaxGrpL2280Specie;
            oSqlCmdInsert.Parameters["@ATaxGrpL2281SubSpecie"].Value = m_ATaxGrpL2281SubSpecie;
            oSqlCmdInsert.Parameters["@ATaxGrpL2282Authority"].Value = m_ATaxGrpL2282Authority;
            oSqlCmdInsert.Parameters["@ATaxGrpL2283Year"].Value = m_ATaxGrpL2283Year;
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
        public bool FncSqlFind(UInt64 DocId)
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
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_Atax_DocId_validRedirect = Convert.ToUInt64(oDR["Atax_DocId_validRedirect"].ToString());
                    m_ATax_ItisTsn = oDR["ATax_ItisTsn"].ToString();
                    m_Atax_ItisUdatedDate = Convert.ToDateTime(oDR["Atax_ItisUdatedDate"].ToString());
                    m_Atax_ItisIsValid = Convert.ToBoolean(oDR["Atax_ItisIsValid"].ToString());
                    m_ATax_ItisInvalidateNote = oDR["ATax_ItisInvalidateNote"].ToString();
                    m_Atax_ItisValidRedirect_Tsn = Convert.ToUInt64(oDR["Atax_ItisValidRedirect_Tsn"].ToString());
                    m_ATaxNameVulgarEN = oDR["ATaxNameVulgarEN"].ToString();
                    m_ATaxNameVulgarES = oDR["ATaxNameVulgarES"].ToString();
                    m_ATaxNameVulgarOthers = oDR["ATaxNameVulgarOthers"].ToString();
                    m_ATaxGrpL0000Level = oDR["ATaxGrpL0000Level"].ToString();
                    m_ATaxGrpL0001lNameFullRecomeded = oDR["ATaxGrpL0001lNameFullRecomeded"].ToString();
                    m_ATaxGrpL0002NameSinonimous = oDR["ATaxGrpL0002NameSinonimous"].ToString();
                    m_ATaxGrpL2000Class = oDR["ATaxGrpL2000Class"].ToString();
                    m_ATaxGrpL2210Order = oDR["ATaxGrpL2210Order"].ToString();
                    m_ATaxGrpL2220SubOrder = oDR["ATaxGrpL2220SubOrder"].ToString();
                    m_ATaxGrpL2230SupFamily = oDR["ATaxGrpL2230SupFamily"].ToString();
                    m_ATaxGrpL2240Family = oDR["ATaxGrpL2240Family"].ToString();
                    m_ATaxGrpL2250SubFamily = oDR["ATaxGrpL2250SubFamily"].ToString();
                    m_ATaxGrpL2260SupGenus = oDR["ATaxGrpL2260SupGenus"].ToString();
                    m_ATaxGrpL2270Genus = oDR["ATaxGrpL2270Genus"].ToString();
                    m_ATaxGrpL2280Specie = oDR["ATaxGrpL2280Specie"].ToString();
                    m_ATaxGrpL2281SubSpecie = oDR["ATaxGrpL2281SubSpecie"].ToString();
                    m_ATaxGrpL2282Authority = oDR["ATaxGrpL2282Authority"].ToString();
                    m_ATaxGrpL2283Year = oDR["ATaxGrpL2283Year"].ToString();
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
        public bool FncSqlDelete(UInt64 DocId)
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

        public UInt64 DocId
        {
            set
            {
                m_DocId = value;
            }
            get { return m_DocId; }
        }

        //................................

        public UInt64 Atax_DocId_validRedirect
        {
            set
            {
                m_Atax_DocId_validRedirect = value;
            }
            get { return m_Atax_DocId_validRedirect; }
        }

        //................................

        public String ATax_ItisTsn
        {
            set
            {
                m_ATax_ItisTsn = value;
            }
            get { return m_ATax_ItisTsn; }
        }

        //................................

        public System.DateTime Atax_ItisUdatedDate
        {
            set
            {
                m_Atax_ItisUdatedDate = value;
            }
            get { return m_Atax_ItisUdatedDate; }
        }

        //................................

        public Boolean Atax_ItisIsValid
        {
            set
            {
                m_Atax_ItisIsValid = value;
            }
            get { return m_Atax_ItisIsValid; }
        }

        //................................

        public String ATax_ItisInvalidateNote
        {
            set
            {
                m_ATax_ItisInvalidateNote = value;
            }
            get { return m_ATax_ItisInvalidateNote; }
        }

        //................................

        public UInt64 Atax_ItisValidRedirect_Tsn
        {
            set
            {
                m_Atax_ItisValidRedirect_Tsn = value;
            }
            get { return m_Atax_ItisValidRedirect_Tsn; }
        }

        //................................

        public String ATaxNameVulgarEN
        {
            set
            {
                m_ATaxNameVulgarEN = value;
            }
            get { return m_ATaxNameVulgarEN; }
        }

        //................................

        public String ATaxNameVulgarES
        {
            set
            {
                m_ATaxNameVulgarES = value;
            }
            get { return m_ATaxNameVulgarES; }
        }

        //................................

        public String ATaxNameVulgarOthers
        {
            set
            {
                m_ATaxNameVulgarOthers = value;
            }
            get { return m_ATaxNameVulgarOthers; }
        }

        //................................

        public String ATaxGrpL0000Level
        {
            set
            {
                m_ATaxGrpL0000Level = value;
            }
            get { return m_ATaxGrpL0000Level; }
        }

        //................................

        public String ATaxGrpL0001lNameFullRecomeded
        {
            set
            {
                m_ATaxGrpL0001lNameFullRecomeded = value;
            }
            get { return m_ATaxGrpL0001lNameFullRecomeded; }
        }

        //................................

        public String ATaxGrpL0002NameSinonimous
        {
            set
            {
                m_ATaxGrpL0002NameSinonimous = value;
            }
            get { return m_ATaxGrpL0002NameSinonimous; }
        }

        //................................

        public String ATaxGrpL2000Class
        {
            set
            {
                m_ATaxGrpL2000Class = value;
            }
            get { return m_ATaxGrpL2000Class; }
        }

        //................................

        public String ATaxGrpL2210Order
        {
            set
            {
                m_ATaxGrpL2210Order = value;
            }
            get { return m_ATaxGrpL2210Order; }
        }

        //................................

        public String ATaxGrpL2220SubOrder
        {
            set
            {
                m_ATaxGrpL2220SubOrder = value;
            }
            get { return m_ATaxGrpL2220SubOrder; }
        }

        //................................

        public String ATaxGrpL2230SupFamily
        {
            set
            {
                m_ATaxGrpL2230SupFamily = value;
            }
            get { return m_ATaxGrpL2230SupFamily; }
        }

        //................................

        public String ATaxGrpL2240Family
        {
            set
            {
                m_ATaxGrpL2240Family = value;
            }
            get { return m_ATaxGrpL2240Family; }
        }

        //................................

        public String ATaxGrpL2250SubFamily
        {
            set
            {
                m_ATaxGrpL2250SubFamily = value;
            }
            get { return m_ATaxGrpL2250SubFamily; }
        }

        //................................

        public String ATaxGrpL2260SupGenus
        {
            set
            {
                m_ATaxGrpL2260SupGenus = value;
            }
            get { return m_ATaxGrpL2260SupGenus; }
        }

        //................................

        public String ATaxGrpL2270Genus
        {
            set
            {
                m_ATaxGrpL2270Genus = value;
            }
            get { return m_ATaxGrpL2270Genus; }
        }

        //................................

        public String ATaxGrpL2280Specie
        {
            set
            {
                m_ATaxGrpL2280Specie = value;
            }
            get { return m_ATaxGrpL2280Specie; }
        }

        //................................

        public String ATaxGrpL2281SubSpecie
        {
            set
            {
                m_ATaxGrpL2281SubSpecie = value;
            }
            get { return m_ATaxGrpL2281SubSpecie; }
        }

        //................................

        public String ATaxGrpL2282Authority
        {
            set
            {
                m_ATaxGrpL2282Authority = value;
            }
            get { return m_ATaxGrpL2282Authority; }
        }

        //................................

        public String ATaxGrpL2283Year
        {
            set
            {
                m_ATaxGrpL2283Year = value;
            }
            get { return m_ATaxGrpL2283Year; }
        }

        #endregion VALORES_GETSET

    }
}