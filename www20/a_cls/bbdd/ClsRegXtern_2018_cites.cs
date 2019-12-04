using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegXtern_2018_cites
    //<//summary>
    public class ClsRegXtern_2018_cites
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
        private UInt64 m_Cites_TaxonId = 0;
        private UInt64 m_Iucn_Id = 0;
        private UInt64 m_DocId = 0;
        private DateTime m_DateConsulted = System.DateTime.Now;
	 private String m_TaxKingdom = "";
        private String m_TaxPhylum = "";
        private String m_TaxClass = "";
        private String m_TaxOrder = "";
        private String m_TaxFamily = "";
        private String m_TaxGenus = "";
        private String m_TaxSpecies = "";
        private String m_TaxSubspecies = "";
        private String m_TaxFullName = "";
        private String m_TaxAuthorYear = "";
        private String m_TaxRankName = "";
        private String m_CurrentListing = "";
        private String m_FullAnnotationEnglish = "";
        private String m_AnnotationEnglish = "";
        private String m_AnnotationSpanish = "";
        private String m_AnnotationFrench = "";
        private String m_AnnotationSymbol = "";
        private String m_Annotation = "";
        private String m_SynonymsWithAuthors = "";
        private String m_EnglishNames = "";
        private String m_SpanishNames = "";
        private String m_FrenchNames = "";
        private String m_CitesAccepted = "";
        private String m_All_DistributionISOCodes = "";
        private String m_All_DistributionTaxFullNames = "";
        private String m_NativeDistributionTaxFullNames = "";
        private String m_Introduced_Distribution = "";
        private String m_Introduced_Distribution2 = "";
        private String m_Reintroduced_Distribution = "";
        private String m_Extinct_Distribution = "";
        private String m_Extinct_Distribution2 = "";
        private String m_Distribution_Uncertain = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegXtern_2018_cites(string szMySqlConnectionString)
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
            m_Cites_TaxonId = 0;
            m_Iucn_Id = 0;
            m_DocId = 0;
            m_DateConsulted = System.DateTime.Now;
	 m_TaxKingdom = "";
            m_TaxPhylum = "";
            m_TaxClass = "";
            m_TaxOrder = "";
            m_TaxFamily = "";
            m_TaxGenus = "";
            m_TaxSpecies = "";
            m_TaxSubspecies = "";
            m_TaxFullName = "";
            m_TaxAuthorYear = "";
            m_TaxRankName = "";
            m_CurrentListing = "";
            m_FullAnnotationEnglish = "";
            m_AnnotationEnglish = "";
            m_AnnotationSpanish = "";
            m_AnnotationFrench = "";
            m_AnnotationSymbol = "";
            m_Annotation = "";
            m_SynonymsWithAuthors = "";
            m_EnglishNames = "";
            m_SpanishNames = "";
            m_FrenchNames = "";
            m_CitesAccepted = "";
            m_All_DistributionISOCodes = "";
            m_All_DistributionTaxFullNames = "";
            m_NativeDistributionTaxFullNames = "";
            m_Introduced_Distribution = "";
            m_Introduced_Distribution2 = "";
            m_Reintroduced_Distribution = "";
            m_Extinct_Distribution = "";
            m_Extinct_Distribution2 = "";
            m_Distribution_Uncertain = "";
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
            szSql = "SELECT * FROM xtern_2018_cites  ";
            szSql += " WHERE ";
            szSql += "(Cites_TaxonId=@Cites_TaxonId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@Cites_TaxonId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO xtern_2018_cites";

            szSql += "(";

            szSql += " Cites_TaxonId ";
            szSql += ", Iucn_Id ";
            szSql += ", DocId ";
            szSql += ", DateConsulted ";
            szSql += ", TaxKingdom ";
            szSql += ", TaxPhylum ";
            szSql += ", TaxClass ";
            szSql += ", TaxOrder ";
            szSql += ", TaxFamily ";
            szSql += ", TaxGenus ";
            szSql += ", TaxSpecies ";
            szSql += ", TaxSubspecies ";
            szSql += ", TaxFullName ";
            szSql += ", TaxAuthorYear ";
            szSql += ", TaxRankName ";
            szSql += ", CurrentListing ";
            szSql += ", FullAnnotationEnglish ";
            szSql += ", AnnotationEnglish ";
            szSql += ", AnnotationSpanish ";
            szSql += ", AnnotationFrench ";
            szSql += ", AnnotationSymbol ";
            szSql += ", Annotation ";
            szSql += ", SynonymsWithAuthors ";
            szSql += ", EnglishNames ";
            szSql += ", SpanishNames ";
            szSql += ", FrenchNames ";
            szSql += ", CitesAccepted ";
            szSql += ", All_DistributionISOCodes ";
            szSql += ", All_DistributionTaxFullNames ";
            szSql += ", NativeDistributionTaxFullNames ";
            szSql += ", Introduced_Distribution ";
            szSql += ", Introduced_Distribution2 ";
            szSql += ", Reintroduced_Distribution ";
            szSql += ", Extinct_Distribution ";
            szSql += ", Extinct_Distribution2 ";
            szSql += ", Distribution_Uncertain ";
            szSql += " ) VALUES     (";
            szSql += " @Cites_TaxonId ";
            szSql += ", @Iucn_Id ";
            szSql += ", @DocId ";
            szSql += ", @DateConsulted ";
            szSql += ", @TaxKingdom ";
            szSql += ", @TaxPhylum ";
            szSql += ", @TaxClass ";
            szSql += ", @TaxOrder ";
            szSql += ", @TaxFamily ";
            szSql += ", @TaxGenus ";
            szSql += ", @TaxSpecies ";
            szSql += ", @TaxSubspecies ";
            szSql += ", @TaxFullName ";
            szSql += ", @TaxAuthorYear ";
            szSql += ", @TaxRankName ";
            szSql += ", @CurrentListing ";
            szSql += ", @FullAnnotationEnglish ";
            szSql += ", @AnnotationEnglish ";
            szSql += ", @AnnotationSpanish ";
            szSql += ", @AnnotationFrench ";
            szSql += ", @AnnotationSymbol ";
            szSql += ", @Annotation ";
            szSql += ", @SynonymsWithAuthors ";
            szSql += ", @EnglishNames ";
            szSql += ", @SpanishNames ";
            szSql += ", @FrenchNames ";
            szSql += ", @CitesAccepted ";
            szSql += ", @All_DistributionISOCodes ";
            szSql += ", @All_DistributionTaxFullNames ";
            szSql += ", @NativeDistributionTaxFullNames ";
            szSql += ", @Introduced_Distribution ";
            szSql += ", @Introduced_Distribution2 ";
            szSql += ", @Reintroduced_Distribution ";
            szSql += ", @Extinct_Distribution ";
            szSql += ", @Extinct_Distribution2 ";
            szSql += ", @Distribution_Uncertain ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@Cites_TaxonId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@Iucn_Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@DateConsulted", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@TaxKingdom", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxPhylum", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxClass", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxOrder", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxGenus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxSpecies", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxSubspecies", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxFullName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxAuthorYear", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@TaxRankName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@CurrentListing", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@FullAnnotationEnglish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AnnotationEnglish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AnnotationSpanish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AnnotationFrench", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AnnotationSymbol", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@Annotation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@SynonymsWithAuthors", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@EnglishNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@SpanishNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@FrenchNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@CitesAccepted", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@All_DistributionISOCodes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@All_DistributionTaxFullNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@NativeDistributionTaxFullNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Introduced_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Introduced_Distribution2", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Reintroduced_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Extinct_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Extinct_Distribution2", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@Distribution_Uncertain", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE xtern_2018_cites SET ";

            szSql += "Iucn_Id=@Iucn_Id ";
            szSql += ", DocId=@DocId ";
            szSql += ", DateConsulted=@DateConsulted ";
            szSql += ", TaxKingdom=@TaxKingdom ";
            szSql += ", TaxPhylum=@TaxPhylum ";
            szSql += ", TaxClass=@TaxClass ";
            szSql += ", TaxOrder=@TaxOrder ";
            szSql += ", TaxFamily=@TaxFamily ";
            szSql += ", TaxGenus=@TaxGenus ";
            szSql += ", TaxSpecies=@TaxSpecies ";
            szSql += ", TaxSubspecies=@TaxSubspecies ";
            szSql += ", TaxFullName=@TaxFullName ";
            szSql += ", TaxAuthorYear=@TaxAuthorYear ";
            szSql += ", TaxRankName=@TaxRankName ";
            szSql += ", CurrentListing=@CurrentListing ";
            szSql += ", FullAnnotationEnglish=@FullAnnotationEnglish ";
            szSql += ", AnnotationEnglish=@AnnotationEnglish ";
            szSql += ", AnnotationSpanish=@AnnotationSpanish ";
            szSql += ", AnnotationFrench=@AnnotationFrench ";
            szSql += ", AnnotationSymbol=@AnnotationSymbol ";
            szSql += ", Annotation=@Annotation ";
            szSql += ", SynonymsWithAuthors=@SynonymsWithAuthors ";
            szSql += ", EnglishNames=@EnglishNames ";
            szSql += ", SpanishNames=@SpanishNames ";
            szSql += ", FrenchNames=@FrenchNames ";
            szSql += ", CitesAccepted=@CitesAccepted ";
            szSql += ", All_DistributionISOCodes=@All_DistributionISOCodes ";
            szSql += ", All_DistributionTaxFullNames=@All_DistributionTaxFullNames ";
            szSql += ", NativeDistributionTaxFullNames=@NativeDistributionTaxFullNames ";
            szSql += ", Introduced_Distribution=@Introduced_Distribution ";
            szSql += ", Introduced_Distribution2=@Introduced_Distribution2 ";
            szSql += ", Reintroduced_Distribution=@Reintroduced_Distribution ";
            szSql += ", Extinct_Distribution=@Extinct_Distribution ";
            szSql += ", Extinct_Distribution2=@Extinct_Distribution2 ";
            szSql += ", Distribution_Uncertain=@Distribution_Uncertain ";
            szSql += " WHERE ";
            szSql += "(Cites_TaxonId=@Cites_TaxonId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@Cites_TaxonId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@Iucn_Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@DateConsulted", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@TaxKingdom", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxPhylum", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxClass", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxOrder", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxFamily", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxGenus", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxSpecies", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxSubspecies", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxFullName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxAuthorYear", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@TaxRankName", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@CurrentListing", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@FullAnnotationEnglish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AnnotationEnglish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AnnotationSpanish", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AnnotationFrench", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AnnotationSymbol", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@Annotation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@SynonymsWithAuthors", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@EnglishNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@SpanishNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@FrenchNames", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@CitesAccepted", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@All_DistributionISOCodes", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@All_DistributionTaxFullNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@NativeDistributionTaxFullNames", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Introduced_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Introduced_Distribution2", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Reintroduced_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Extinct_Distribution", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Extinct_Distribution2", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@Distribution_Uncertain", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM xtern_2018_cites  ";
            szSql += " WHERE ";
            szSql += "(Cites_TaxonId=@Cites_TaxonId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@Cites_TaxonId", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " Cites_TaxonId";
            szSql += " FROM xtern_2018_cites  ";

            szSql += " WHERE ";
            szSql += "(Cites_TaxonId=@Cites_TaxonId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@Cites_TaxonId", MySql.Data.MySqlClient.MySqlDbType.Int32);
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
            oSqlCmdSelectExist.Parameters["@Cites_TaxonId"].Value = m_Cites_TaxonId;

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
            oSqlCmdUpdate.Parameters["@Cites_TaxonId"].Value = m_Cites_TaxonId;
            oSqlCmdUpdate.Parameters["@Iucn_Id"].Value = m_Iucn_Id;
            oSqlCmdUpdate.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdUpdate.Parameters["@DateConsulted"].Value = m_DateConsulted;
            oSqlCmdUpdate.Parameters["@TaxKingdom"].Value = m_TaxKingdom;
            oSqlCmdUpdate.Parameters["@TaxPhylum"].Value = m_TaxPhylum;
            oSqlCmdUpdate.Parameters["@TaxClass"].Value = m_TaxClass;
            oSqlCmdUpdate.Parameters["@TaxOrder"].Value = m_TaxOrder;
            oSqlCmdUpdate.Parameters["@TaxFamily"].Value = m_TaxFamily;
            oSqlCmdUpdate.Parameters["@TaxGenus"].Value = m_TaxGenus;
            oSqlCmdUpdate.Parameters["@TaxSpecies"].Value = m_TaxSpecies;
            oSqlCmdUpdate.Parameters["@TaxSubspecies"].Value = m_TaxSubspecies;
            oSqlCmdUpdate.Parameters["@TaxFullName"].Value = m_TaxFullName;
            oSqlCmdUpdate.Parameters["@TaxAuthorYear"].Value = m_TaxAuthorYear;
            oSqlCmdUpdate.Parameters["@TaxRankName"].Value = m_TaxRankName;
            oSqlCmdUpdate.Parameters["@CurrentListing"].Value = m_CurrentListing;
            oSqlCmdUpdate.Parameters["@FullAnnotationEnglish"].Value = m_FullAnnotationEnglish;
            oSqlCmdUpdate.Parameters["@AnnotationEnglish"].Value = m_AnnotationEnglish;
            oSqlCmdUpdate.Parameters["@AnnotationSpanish"].Value = m_AnnotationSpanish;
            oSqlCmdUpdate.Parameters["@AnnotationFrench"].Value = m_AnnotationFrench;
            oSqlCmdUpdate.Parameters["@AnnotationSymbol"].Value = m_AnnotationSymbol;
            oSqlCmdUpdate.Parameters["@Annotation"].Value = m_Annotation;
            oSqlCmdUpdate.Parameters["@SynonymsWithAuthors"].Value = m_SynonymsWithAuthors;
            oSqlCmdUpdate.Parameters["@EnglishNames"].Value = m_EnglishNames;
            oSqlCmdUpdate.Parameters["@SpanishNames"].Value = m_SpanishNames;
            oSqlCmdUpdate.Parameters["@FrenchNames"].Value = m_FrenchNames;
            oSqlCmdUpdate.Parameters["@CitesAccepted"].Value = m_CitesAccepted;
            oSqlCmdUpdate.Parameters["@All_DistributionISOCodes"].Value = m_All_DistributionISOCodes;
            oSqlCmdUpdate.Parameters["@All_DistributionTaxFullNames"].Value = m_All_DistributionTaxFullNames;
            oSqlCmdUpdate.Parameters["@NativeDistributionTaxFullNames"].Value = m_NativeDistributionTaxFullNames;
            oSqlCmdUpdate.Parameters["@Introduced_Distribution"].Value = m_Introduced_Distribution;
            oSqlCmdUpdate.Parameters["@Introduced_Distribution2"].Value = m_Introduced_Distribution2;
            oSqlCmdUpdate.Parameters["@Reintroduced_Distribution"].Value = m_Reintroduced_Distribution;
            oSqlCmdUpdate.Parameters["@Extinct_Distribution"].Value = m_Extinct_Distribution;
            oSqlCmdUpdate.Parameters["@Extinct_Distribution2"].Value = m_Extinct_Distribution2;
            oSqlCmdUpdate.Parameters["@Distribution_Uncertain"].Value = m_Distribution_Uncertain;
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
            oSqlCmdInsert.Parameters["@Cites_TaxonId"].Value = m_Cites_TaxonId;
            oSqlCmdInsert.Parameters["@Iucn_Id"].Value = m_Iucn_Id;
            oSqlCmdInsert.Parameters["@DocId"].Value = m_DocId;
            oSqlCmdInsert.Parameters["@DateConsulted"].Value = m_DateConsulted;
            oSqlCmdInsert.Parameters["@TaxKingdom"].Value = m_TaxKingdom;
            oSqlCmdInsert.Parameters["@TaxPhylum"].Value = m_TaxPhylum;
            oSqlCmdInsert.Parameters["@TaxClass"].Value = m_TaxClass;
            oSqlCmdInsert.Parameters["@TaxOrder"].Value = m_TaxOrder;
            oSqlCmdInsert.Parameters["@TaxFamily"].Value = m_TaxFamily;
            oSqlCmdInsert.Parameters["@TaxGenus"].Value = m_TaxGenus;
            oSqlCmdInsert.Parameters["@TaxSpecies"].Value = m_TaxSpecies;
            oSqlCmdInsert.Parameters["@TaxSubspecies"].Value = m_TaxSubspecies;
            oSqlCmdInsert.Parameters["@TaxFullName"].Value = m_TaxFullName;
            oSqlCmdInsert.Parameters["@TaxAuthorYear"].Value = m_TaxAuthorYear;
            oSqlCmdInsert.Parameters["@TaxRankName"].Value = m_TaxRankName;
            oSqlCmdInsert.Parameters["@CurrentListing"].Value = m_CurrentListing;
            oSqlCmdInsert.Parameters["@FullAnnotationEnglish"].Value = m_FullAnnotationEnglish;
            oSqlCmdInsert.Parameters["@AnnotationEnglish"].Value = m_AnnotationEnglish;
            oSqlCmdInsert.Parameters["@AnnotationSpanish"].Value = m_AnnotationSpanish;
            oSqlCmdInsert.Parameters["@AnnotationFrench"].Value = m_AnnotationFrench;
            oSqlCmdInsert.Parameters["@AnnotationSymbol"].Value = m_AnnotationSymbol;
            oSqlCmdInsert.Parameters["@Annotation"].Value = m_Annotation;
            oSqlCmdInsert.Parameters["@SynonymsWithAuthors"].Value = m_SynonymsWithAuthors;
            oSqlCmdInsert.Parameters["@EnglishNames"].Value = m_EnglishNames;
            oSqlCmdInsert.Parameters["@SpanishNames"].Value = m_SpanishNames;
            oSqlCmdInsert.Parameters["@FrenchNames"].Value = m_FrenchNames;
            oSqlCmdInsert.Parameters["@CitesAccepted"].Value = m_CitesAccepted;
            oSqlCmdInsert.Parameters["@All_DistributionISOCodes"].Value = m_All_DistributionISOCodes;
            oSqlCmdInsert.Parameters["@All_DistributionTaxFullNames"].Value = m_All_DistributionTaxFullNames;
            oSqlCmdInsert.Parameters["@NativeDistributionTaxFullNames"].Value = m_NativeDistributionTaxFullNames;
            oSqlCmdInsert.Parameters["@Introduced_Distribution"].Value = m_Introduced_Distribution;
            oSqlCmdInsert.Parameters["@Introduced_Distribution2"].Value = m_Introduced_Distribution2;
            oSqlCmdInsert.Parameters["@Reintroduced_Distribution"].Value = m_Reintroduced_Distribution;
            oSqlCmdInsert.Parameters["@Extinct_Distribution"].Value = m_Extinct_Distribution;
            oSqlCmdInsert.Parameters["@Extinct_Distribution2"].Value = m_Extinct_Distribution2;
            oSqlCmdInsert.Parameters["@Distribution_Uncertain"].Value = m_Distribution_Uncertain;
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
        public bool FncSqlFind(UInt64 Cites_TaxonId)
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
            oSqlCmdSelect.Parameters["@Cites_TaxonId"].Value = Cites_TaxonId;
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
                    m_Cites_TaxonId = Convert.ToUInt64(oDR["Cites_TaxonId"].ToString());
                    m_Iucn_Id = Convert.ToUInt64(oDR["Iucn_Id"].ToString());
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_DateConsulted =Convert.ToDateTime(oDR["DateConsulted"].ToString());
                    m_TaxKingdom = oDR["TaxKingdom"].ToString();
                    m_TaxPhylum = oDR["TaxPhylum"].ToString();
                    m_TaxClass = oDR["TaxClass"].ToString();
                    m_TaxOrder = oDR["TaxOrder"].ToString();
                    m_TaxFamily = oDR["TaxFamily"].ToString();
                    m_TaxGenus = oDR["TaxGenus"].ToString();
                    m_TaxSpecies = oDR["TaxSpecies"].ToString();
                    m_TaxSubspecies = oDR["TaxSubspecies"].ToString();
                    m_TaxFullName = oDR["TaxFullName"].ToString();
                    m_TaxAuthorYear = oDR["TaxAuthorYear"].ToString();
                    m_TaxRankName = oDR["TaxRankName"].ToString();
                    m_CurrentListing = oDR["CurrentListing"].ToString();
                    m_FullAnnotationEnglish = oDR["FullAnnotationEnglish"].ToString();
                    m_AnnotationEnglish = oDR["AnnotationEnglish"].ToString();
                    m_AnnotationSpanish = oDR["AnnotationSpanish"].ToString();
                    m_AnnotationFrench = oDR["AnnotationFrench"].ToString();
                    m_AnnotationSymbol = oDR["AnnotationSymbol"].ToString();
                    m_Annotation = oDR["Annotation"].ToString();
                    m_SynonymsWithAuthors = oDR["SynonymsWithAuthors"].ToString();
                    m_EnglishNames = oDR["EnglishNames"].ToString();
                    m_SpanishNames = oDR["SpanishNames"].ToString();
                    m_FrenchNames = oDR["FrenchNames"].ToString();
                    m_CitesAccepted = oDR["CitesAccepted"].ToString();
                    m_All_DistributionISOCodes = oDR["All_DistributionISOCodes"].ToString();
                    m_All_DistributionTaxFullNames = oDR["All_DistributionTaxFullNames"].ToString();
                    m_NativeDistributionTaxFullNames = oDR["NativeDistributionTaxFullNames"].ToString();
                    m_Introduced_Distribution = oDR["Introduced_Distribution"].ToString();
                    m_Introduced_Distribution2 = oDR["Introduced_Distribution2"].ToString();
                    m_Reintroduced_Distribution = oDR["Reintroduced_Distribution"].ToString();
                    m_Extinct_Distribution = oDR["Extinct_Distribution"].ToString();
                    m_Extinct_Distribution2 = oDR["Extinct_Distribution2"].ToString();
                    m_Distribution_Uncertain = oDR["Distribution_Uncertain"].ToString();
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
        public bool FncSqlDelete(UInt64 Cites_TaxonId)
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
                oSqlCmdDelete.Parameters["@Cites_TaxonId"].Value = Cites_TaxonId;
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

        public UInt64 Cites_TaxonId
        {
            set
            {
                m_Cites_TaxonId = value;
            }
            get { return m_Cites_TaxonId; }
        }

        //................................

        public UInt64 Iucn_Id
        {
            set
            {
                m_Iucn_Id = value;
            }
            get { return m_Iucn_Id; }
        }

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

        public DateTime DateConsulted
{
	set {
m_DateConsulted=value;}
    get {return m_DateConsulted;}
}
        public String DateConsulted_s
        {
           
            get { return m_DateConsulted.ToShortDateString(); }
        }

        //................................

        public String TaxKingdom
{
    set
    {
        m_TaxKingdom = value;
    }
    get { return m_TaxKingdom; }
}

//................................

public String TaxPhylum
{
    set
    {
        m_TaxPhylum = value;
    }
    get { return m_TaxPhylum; }
}

//................................

public String TaxClass
{
    set
    {
        m_TaxClass = value;
    }
    get { return m_TaxClass; }
}

//................................

public String TaxOrder
{
    set
    {
        m_TaxOrder = value;
    }
    get { return m_TaxOrder; }
}

//................................

public String TaxFamily
{
    set
    {
        m_TaxFamily = value;
    }
    get { return m_TaxFamily; }
}

//................................

public String TaxGenus
{
    set
    {
        m_TaxGenus = value;
    }
    get { return m_TaxGenus; }
}

//................................

public String TaxSpecies
{
    set
    {
        m_TaxSpecies = value;
    }
    get { return m_TaxSpecies; }
}

//................................

public String TaxSubspecies
{
    set
    {
        m_TaxSubspecies = value;
    }
    get { return m_TaxSubspecies; }
}

//................................

public String TaxFullName
{
    set
    {
        m_TaxFullName = value;
    }
    get { return m_TaxFullName; }
}

//................................

public String TaxAuthorYear
{
    set
    {
        m_TaxAuthorYear = value;
    }
    get { return m_TaxAuthorYear; }
}

//................................

public String TaxRankName
{
    set
    {
        m_TaxRankName = value;
    }
    get { return m_TaxRankName; }
}

//................................

public String CurrentListing
{
    set
    {
        m_CurrentListing = value;
    }
    get { return m_CurrentListing; }
}

//................................

public String FullAnnotationEnglish
{
    set
    {
        m_FullAnnotationEnglish = value;
    }
    get { return m_FullAnnotationEnglish; }
}

//................................

public String AnnotationEnglish
{
    set
    {
        m_AnnotationEnglish = value;
    }
    get { return m_AnnotationEnglish; }
}

//................................

public String AnnotationSpanish
{
    set
    {
        m_AnnotationSpanish = value;
    }
    get { return m_AnnotationSpanish; }
}

//................................

public String AnnotationFrench
{
    set
    {
        m_AnnotationFrench = value;
    }
    get { return m_AnnotationFrench; }
}

//................................

public String AnnotationSymbol
{
    set
    {
        m_AnnotationSymbol = value;
    }
    get { return m_AnnotationSymbol; }
}

//................................

public String Annotation
{
    set
    {
        m_Annotation = value;
    }
    get { return m_Annotation; }
}

//................................

public String SynonymsWithAuthors
{
    set
    {
        m_SynonymsWithAuthors = value;
    }
    get { return m_SynonymsWithAuthors; }
}

//................................

public String EnglishNames
{
    set
    {
        m_EnglishNames = value;
    }
    get { return m_EnglishNames; }
}

//................................

public String SpanishNames
{
    set
    {
        m_SpanishNames = value;
    }
    get { return m_SpanishNames; }
}

//................................

public String FrenchNames
{
    set
    {
        m_FrenchNames = value;
    }
    get { return m_FrenchNames; }
}

//................................

public String CitesAccepted
{
    set
    {
        m_CitesAccepted = value;
    }
    get { return m_CitesAccepted; }
}

//................................

public String All_DistributionISOCodes
{
    set
    {
        m_All_DistributionISOCodes = value;
    }
    get { return m_All_DistributionISOCodes; }
}

//................................

public String All_DistributionTaxFullNames
{
    set
    {
        m_All_DistributionTaxFullNames = value;
    }
    get { return m_All_DistributionTaxFullNames; }
}

//................................

public String NativeDistributionTaxFullNames
{
    set
    {
        m_NativeDistributionTaxFullNames = value;
    }
    get { return m_NativeDistributionTaxFullNames; }
}

//................................

public String Introduced_Distribution
{
    set
    {
        m_Introduced_Distribution = value;
    }
    get { return m_Introduced_Distribution; }
}

//................................

public String Introduced_Distribution2
{
    set
    {
        m_Introduced_Distribution2 = value;
    }
    get { return m_Introduced_Distribution2; }
}

//................................

public String Reintroduced_Distribution
{
    set
    {
        m_Reintroduced_Distribution = value;
    }
    get { return m_Reintroduced_Distribution; }
}

//................................

public String Extinct_Distribution
{
    set
    {
        m_Extinct_Distribution = value;
    }
    get { return m_Extinct_Distribution; }
}

//................................

public String Extinct_Distribution2
{
    set
    {
        m_Extinct_Distribution2 = value;
    }
    get { return m_Extinct_Distribution2; }
}

//................................

public String Distribution_Uncertain
{
    set
    {
        m_Distribution_Uncertain = value;
    }
    get { return m_Distribution_Uncertain; }
}

#endregion VALORES_GETSET

}
}