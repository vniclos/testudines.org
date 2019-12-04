using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsReg_tdoclng_testudines_geog_all
    //<//summary>
    public class ClsReg_tdoclng_testudines_geog_all
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
        private String m_AGeoPoliContinentKeys = "";
        private String m_AGeoPoliCountriestKeys = "";
        private String m_AGeoPoliLocationType = "";
        private String m_AGeoBioWWFRealmsKey = "";
        private String m_AGeoBioWWFRegionKeys = "";
        private String m_AGeoClimateKoppenGeigerKeys = "";
        private String m_AGeoClimateKoppenGeigerImage = "";
        private Int32 m_AGeoLocLatitudMax = 0;
        private Int32 m_AGeoLocLatitudMin = 0;
        private Int32 m_AGeoLocAltitudMax = 0;
        private Int32 m_AGeoLocAltitudMin = 0;
        private String m_AGeoClimateTableLocation = "";
        private String m_AGeoClimateTableUrlTitle = "";
        private String m_AGeoClimateTableUrl = "";
        private Byte m_AGeoDrawTempMin = 0;
        private Byte m_AGeoDrawTempMax = 0;
        private Byte m_AGeoDrawTempAvg = 0;
        private Byte m_AGeoDrawRainML = 0;
        private Byte m_AGeoDrawRainDays = 0;
        private Byte m_AGeoDrawSun = 0;
        private Int32 m_AGeoTmpAvg01 = 0;
        private Int32 m_AGeoTmpAvg02 = 0;
        private Int32 m_AGeoTmpAvg03 = 0;
        private Int32 m_AGeoTmpAvg04 = 0;
        private Int32 m_AGeoTmpAvg05 = 0;
        private Int32 m_AGeoTmpAvg06 = 0;
        private Int32 m_AGeoTmpAvg07 = 0;
        private Int32 m_AGeoTmpAvg08 = 0;
        private Int32 m_AGeoTmpAvg09 = 0;
        private Int32 m_AGeoTmpAvg10 = 0;
        private Int32 m_AGeoTmpAvg11 = 0;
        private Int32 m_AGeoTmpAvg12 = 0;
        private Int32 m_AGeoTmpMax01 = 0;
        private Int32 m_AGeoTmpMax02 = 0;
        private Int32 m_AGeoTmpMax03 = 0;
        private Int32 m_AGeoTmpMax04 = 0;
        private Int32 m_AGeoTmpMax05 = 0;
        private Int32 m_AGeoTmpMax06 = 0;
        private Int32 m_AGeoTmpMax07 = 0;
        private Int32 m_AGeoTmpMax08 = 0;
        private Int32 m_AGeoTmpMax09 = 0;
        private Int32 m_AGeoTmpMax10 = 0;
        private Int32 m_AGeoTmpMax11 = 0;
        private Int32 m_AGeoTmpMax12 = 0;
        private Int32 m_AGeoTmpMin01 = 0;
        private Int32 m_AGeoTmpMin02 = 0;
        private Int32 m_AGeoTmpMin03 = 0;
        private Int32 m_AGeoTmpMin04 = 0;
        private Int32 m_AGeoTmpMin05 = 0;
        private Int32 m_AGeoTmpMin06 = 0;
        private Int32 m_AGeoTmpMin07 = 0;
        private Int32 m_AGeoTmpMin08 = 0;
        private Int32 m_AGeoTmpMin09 = 0;
        private Int32 m_AGeoTmpMin10 = 0;
        private Int32 m_AGeoTmpMin11 = 0;
        private Int32 m_AGeoTmpMin12 = 0;
        private Int32 m_AGeoRainML01 = 0;
        private Int32 m_AGeoRainML02 = 0;
        private Int32 m_AGeoRainML03 = 0;
        private Int32 m_AGeoRainML04 = 0;
        private Int32 m_AGeoRainML05 = 0;
        private Int32 m_AGeoRainML06 = 0;
        private Int32 m_AGeoRainML07 = 0;
        private Int32 m_AGeoRainML08 = 0;
        private Int32 m_AGeoRainML09 = 0;
        private Int32 m_AGeoRainML10 = 0;
        private Int32 m_AGeoRainML11 = 0;
        private Int32 m_AGeoRainML12 = 0;
        private Int32 m_AGeoRainDays01 = 0;
        private Int32 m_AGeoRainDays02 = 0;
        private Int32 m_AGeoRainDays03 = 0;
        private Int32 m_AGeoRainDays04 = 0;
        private Int32 m_AGeoRainDays05 = 0;
        private Int32 m_AGeoRainDays06 = 0;
        private Int32 m_AGeoRainDays07 = 0;
        private Int32 m_AGeoRainDays08 = 0;
        private Int32 m_AGeoRainDays09 = 0;
        private Int32 m_AGeoRainDays10 = 0;
        private Int32 m_AGeoRainDays11 = 0;
        private Int32 m_AGeoRainDays12 = 0;
        private Double m_AGeoSunMax01 = 0;
        private Double m_AGeoSunMax02 = 0;
        private Double m_AGeoSunMax03 = 0;
        private Double m_AGeoSunMax04 = 0;
        private Double m_AGeoSunMax05 = 0;
        private Double m_AGeoSunMax06 = 0;
        private Double m_AGeoSunMax07 = 0;
        private Double m_AGeoSunMax08 = 0;
        private Double m_AGeoSunMax09 = 0;
        private Double m_AGeoSunMax10 = 0;
        private Double m_AGeoSunMax11 = 0;
        private Double m_AGeoSunMax12 = 0;
        private Double m_AGeoSunMin01 = 0;
        private Double m_AGeoSunMin02 = 0;
        private Double m_AGeoSunMin03 = 0;
        private Double m_AGeoSunMin04 = 0;
        private Double m_AGeoSunMin05 = 0;
        private Double m_AGeoSunMin06 = 0;
        private Double m_AGeoSunMin07 = 0;
        private Double m_AGeoSunMin08 = 0;
        private Double m_AGeoSunMin09 = 0;
        private Double m_AGeoSunMin10 = 0;
        private Double m_AGeoSunMin11 = 0;
        private Double m_AGeoSunMin12 = 0;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------
        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_geog_all()
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
            m_AGeoPoliContinentKeys = "";
            m_AGeoPoliCountriestKeys = "";
            m_AGeoPoliLocationType = "";
            m_AGeoBioWWFRealmsKey = "";
            m_AGeoBioWWFRegionKeys = "";
            m_AGeoClimateKoppenGeigerKeys = "";
            m_AGeoClimateKoppenGeigerImage = "";
            m_AGeoLocLatitudMax = 0;
            m_AGeoLocLatitudMin = 0;
            m_AGeoLocAltitudMax = 0;
            m_AGeoLocAltitudMin = 0;
            m_AGeoClimateTableLocation = "";
            m_AGeoClimateTableUrlTitle = "";
            m_AGeoClimateTableUrl = "";
            m_AGeoDrawTempMin = 0;
            m_AGeoDrawTempMax = 0;
            m_AGeoDrawTempAvg = 0;
            m_AGeoDrawRainML = 0;
            m_AGeoDrawRainDays = 0;
            m_AGeoDrawSun = 0;
            m_AGeoTmpAvg01 = 0;
            m_AGeoTmpAvg02 = 0;
            m_AGeoTmpAvg03 = 0;
            m_AGeoTmpAvg04 = 0;
            m_AGeoTmpAvg05 = 0;
            m_AGeoTmpAvg06 = 0;
            m_AGeoTmpAvg07 = 0;
            m_AGeoTmpAvg08 = 0;
            m_AGeoTmpAvg09 = 0;
            m_AGeoTmpAvg10 = 0;
            m_AGeoTmpAvg11 = 0;
            m_AGeoTmpAvg12 = 0;
            m_AGeoTmpMax01 = 0;
            m_AGeoTmpMax02 = 0;
            m_AGeoTmpMax03 = 0;
            m_AGeoTmpMax04 = 0;
            m_AGeoTmpMax05 = 0;
            m_AGeoTmpMax06 = 0;
            m_AGeoTmpMax07 = 0;
            m_AGeoTmpMax08 = 0;
            m_AGeoTmpMax09 = 0;
            m_AGeoTmpMax10 = 0;
            m_AGeoTmpMax11 = 0;
            m_AGeoTmpMax12 = 0;
            m_AGeoTmpMin01 = 0;
            m_AGeoTmpMin02 = 0;
            m_AGeoTmpMin03 = 0;
            m_AGeoTmpMin04 = 0;
            m_AGeoTmpMin05 = 0;
            m_AGeoTmpMin06 = 0;
            m_AGeoTmpMin07 = 0;
            m_AGeoTmpMin08 = 0;
            m_AGeoTmpMin09 = 0;
            m_AGeoTmpMin10 = 0;
            m_AGeoTmpMin11 = 0;
            m_AGeoTmpMin12 = 0;
            m_AGeoRainML01 = 0;
            m_AGeoRainML02 = 0;
            m_AGeoRainML03 = 0;
            m_AGeoRainML04 = 0;
            m_AGeoRainML05 = 0;
            m_AGeoRainML06 = 0;
            m_AGeoRainML07 = 0;
            m_AGeoRainML08 = 0;
            m_AGeoRainML09 = 0;
            m_AGeoRainML10 = 0;
            m_AGeoRainML11 = 0;
            m_AGeoRainML12 = 0;
            m_AGeoRainDays01 = 0;
            m_AGeoRainDays02 = 0;
            m_AGeoRainDays03 = 0;
            m_AGeoRainDays04 = 0;
            m_AGeoRainDays05 = 0;
            m_AGeoRainDays06 = 0;
            m_AGeoRainDays07 = 0;
            m_AGeoRainDays08 = 0;
            m_AGeoRainDays09 = 0;
            m_AGeoRainDays10 = 0;
            m_AGeoRainDays11 = 0;
            m_AGeoRainDays12 = 0;
            m_AGeoSunMax01 = 0;
            m_AGeoSunMax02 = 0;
            m_AGeoSunMax03 = 0;
            m_AGeoSunMax04 = 0;
            m_AGeoSunMax05 = 0;
            m_AGeoSunMax06 = 0;
            m_AGeoSunMax07 = 0;
            m_AGeoSunMax08 = 0;
            m_AGeoSunMax09 = 0;
            m_AGeoSunMax10 = 0;
            m_AGeoSunMax11 = 0;
            m_AGeoSunMax12 = 0;
            m_AGeoSunMin01 = 0;
            m_AGeoSunMin02 = 0;
            m_AGeoSunMin03 = 0;
            m_AGeoSunMin04 = 0;
            m_AGeoSunMin05 = 0;
            m_AGeoSunMin06 = 0;
            m_AGeoSunMin07 = 0;
            m_AGeoSunMin08 = 0;
            m_AGeoSunMin09 = 0;
            m_AGeoSunMin10 = 0;
            m_AGeoSunMin11 = 0;
            m_AGeoSunMin12 = 0;
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
            szSql = "SELECT * FROM tdoclng_testudines_geog_all  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_geog_all";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", AGeoPoliContinentKeys ";
            szSql += ", AGeoPoliCountriestKeys ";
            szSql += ", AGeoPoliLocationType ";
            szSql += ", AGeoBioWWFRealmsKey ";
            szSql += ", AGeoBioWWFRegionKeys ";
            szSql += ", AGeoClimateKoppenGeigerKeys ";
            szSql += ", AGeoClimateKoppenGeigerImage ";
            szSql += ", AGeoLocLatitudMax ";
            szSql += ", AGeoLocLatitudMin ";
            szSql += ", AGeoLocAltitudMax ";
            szSql += ", AGeoLocAltitudMin ";
            szSql += ", AGeoClimateTableLocation ";
            szSql += ", AGeoClimateTableUrlTitle ";
            szSql += ", AGeoClimateTableUrl ";
            szSql += ", AGeoDrawTempMin ";
            szSql += ", AGeoDrawTempMax ";
            szSql += ", AGeoDrawTempAvg ";
            szSql += ", AGeoDrawRainML ";
            szSql += ", AGeoDrawRainDays ";
            szSql += ", AGeoDrawSun ";
            szSql += ", AGeoTmpAvg01 ";
            szSql += ", AGeoTmpAvg02 ";
            szSql += ", AGeoTmpAvg03 ";
            szSql += ", AGeoTmpAvg04 ";
            szSql += ", AGeoTmpAvg05 ";
            szSql += ", AGeoTmpAvg06 ";
            szSql += ", AGeoTmpAvg07 ";
            szSql += ", AGeoTmpAvg08 ";
            szSql += ", AGeoTmpAvg09 ";
            szSql += ", AGeoTmpAvg10 ";
            szSql += ", AGeoTmpAvg11 ";
            szSql += ", AGeoTmpAvg12 ";
            szSql += ", AGeoTmpMax01 ";
            szSql += ", AGeoTmpMax02 ";
            szSql += ", AGeoTmpMax03 ";
            szSql += ", AGeoTmpMax04 ";
            szSql += ", AGeoTmpMax05 ";
            szSql += ", AGeoTmpMax06 ";
            szSql += ", AGeoTmpMax07 ";
            szSql += ", AGeoTmpMax08 ";
            szSql += ", AGeoTmpMax09 ";
            szSql += ", AGeoTmpMax10 ";
            szSql += ", AGeoTmpMax11 ";
            szSql += ", AGeoTmpMax12 ";
            szSql += ", AGeoTmpMin01 ";
            szSql += ", AGeoTmpMin02 ";
            szSql += ", AGeoTmpMin03 ";
            szSql += ", AGeoTmpMin04 ";
            szSql += ", AGeoTmpMin05 ";
            szSql += ", AGeoTmpMin06 ";
            szSql += ", AGeoTmpMin07 ";
            szSql += ", AGeoTmpMin08 ";
            szSql += ", AGeoTmpMin09 ";
            szSql += ", AGeoTmpMin10 ";
            szSql += ", AGeoTmpMin11 ";
            szSql += ", AGeoTmpMin12 ";
            szSql += ", AGeoRainML01 ";
            szSql += ", AGeoRainML02 ";
            szSql += ", AGeoRainML03 ";
            szSql += ", AGeoRainML04 ";
            szSql += ", AGeoRainML05 ";
            szSql += ", AGeoRainML06 ";
            szSql += ", AGeoRainML07 ";
            szSql += ", AGeoRainML08 ";
            szSql += ", AGeoRainML09 ";
            szSql += ", AGeoRainML10 ";
            szSql += ", AGeoRainML11 ";
            szSql += ", AGeoRainML12 ";
            szSql += ", AGeoRainDays01 ";
            szSql += ", AGeoRainDays02 ";
            szSql += ", AGeoRainDays03 ";
            szSql += ", AGeoRainDays04 ";
            szSql += ", AGeoRainDays05 ";
            szSql += ", AGeoRainDays06 ";
            szSql += ", AGeoRainDays07 ";
            szSql += ", AGeoRainDays08 ";
            szSql += ", AGeoRainDays09 ";
            szSql += ", AGeoRainDays10 ";
            szSql += ", AGeoRainDays11 ";
            szSql += ", AGeoRainDays12 ";
            szSql += ", AGeoSunMax01 ";
            szSql += ", AGeoSunMax02 ";
            szSql += ", AGeoSunMax03 ";
            szSql += ", AGeoSunMax04 ";
            szSql += ", AGeoSunMax05 ";
            szSql += ", AGeoSunMax06 ";
            szSql += ", AGeoSunMax07 ";
            szSql += ", AGeoSunMax08 ";
            szSql += ", AGeoSunMax09 ";
            szSql += ", AGeoSunMax10 ";
            szSql += ", AGeoSunMax11 ";
            szSql += ", AGeoSunMax12 ";
            szSql += ", AGeoSunMin01 ";
            szSql += ", AGeoSunMin02 ";
            szSql += ", AGeoSunMin03 ";
            szSql += ", AGeoSunMin04 ";
            szSql += ", AGeoSunMin05 ";
            szSql += ", AGeoSunMin06 ";
            szSql += ", AGeoSunMin07 ";
            szSql += ", AGeoSunMin08 ";
            szSql += ", AGeoSunMin09 ";
            szSql += ", AGeoSunMin10 ";
            szSql += ", AGeoSunMin11 ";
            szSql += ", AGeoSunMin12 ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @AGeoPoliContinentKeys ";
            szSql += ", @AGeoPoliCountriestKeys ";
            szSql += ", @AGeoPoliLocationType ";
            szSql += ", @AGeoBioWWFRealmsKey ";
            szSql += ", @AGeoBioWWFRegionKeys ";
            szSql += ", @AGeoClimateKoppenGeigerKeys ";
            szSql += ", @AGeoClimateKoppenGeigerImage ";
            szSql += ", @AGeoLocLatitudMax ";
            szSql += ", @AGeoLocLatitudMin ";
            szSql += ", @AGeoLocAltitudMax ";
            szSql += ", @AGeoLocAltitudMin ";
            szSql += ", @AGeoClimateTableLocation ";
            szSql += ", @AGeoClimateTableUrlTitle ";
            szSql += ", @AGeoClimateTableUrl ";
            szSql += ", @AGeoDrawTempMin ";
            szSql += ", @AGeoDrawTempMax ";
            szSql += ", @AGeoDrawTempAvg ";
            szSql += ", @AGeoDrawRainML ";
            szSql += ", @AGeoDrawRainDays ";
            szSql += ", @AGeoDrawSun ";
            szSql += ", @AGeoTmpAvg01 ";
            szSql += ", @AGeoTmpAvg02 ";
            szSql += ", @AGeoTmpAvg03 ";
            szSql += ", @AGeoTmpAvg04 ";
            szSql += ", @AGeoTmpAvg05 ";
            szSql += ", @AGeoTmpAvg06 ";
            szSql += ", @AGeoTmpAvg07 ";
            szSql += ", @AGeoTmpAvg08 ";
            szSql += ", @AGeoTmpAvg09 ";
            szSql += ", @AGeoTmpAvg10 ";
            szSql += ", @AGeoTmpAvg11 ";
            szSql += ", @AGeoTmpAvg12 ";
            szSql += ", @AGeoTmpMax01 ";
            szSql += ", @AGeoTmpMax02 ";
            szSql += ", @AGeoTmpMax03 ";
            szSql += ", @AGeoTmpMax04 ";
            szSql += ", @AGeoTmpMax05 ";
            szSql += ", @AGeoTmpMax06 ";
            szSql += ", @AGeoTmpMax07 ";
            szSql += ", @AGeoTmpMax08 ";
            szSql += ", @AGeoTmpMax09 ";
            szSql += ", @AGeoTmpMax10 ";
            szSql += ", @AGeoTmpMax11 ";
            szSql += ", @AGeoTmpMax12 ";
            szSql += ", @AGeoTmpMin01 ";
            szSql += ", @AGeoTmpMin02 ";
            szSql += ", @AGeoTmpMin03 ";
            szSql += ", @AGeoTmpMin04 ";
            szSql += ", @AGeoTmpMin05 ";
            szSql += ", @AGeoTmpMin06 ";
            szSql += ", @AGeoTmpMin07 ";
            szSql += ", @AGeoTmpMin08 ";
            szSql += ", @AGeoTmpMin09 ";
            szSql += ", @AGeoTmpMin10 ";
            szSql += ", @AGeoTmpMin11 ";
            szSql += ", @AGeoTmpMin12 ";
            szSql += ", @AGeoRainML01 ";
            szSql += ", @AGeoRainML02 ";
            szSql += ", @AGeoRainML03 ";
            szSql += ", @AGeoRainML04 ";
            szSql += ", @AGeoRainML05 ";
            szSql += ", @AGeoRainML06 ";
            szSql += ", @AGeoRainML07 ";
            szSql += ", @AGeoRainML08 ";
            szSql += ", @AGeoRainML09 ";
            szSql += ", @AGeoRainML10 ";
            szSql += ", @AGeoRainML11 ";
            szSql += ", @AGeoRainML12 ";
            szSql += ", @AGeoRainDays01 ";
            szSql += ", @AGeoRainDays02 ";
            szSql += ", @AGeoRainDays03 ";
            szSql += ", @AGeoRainDays04 ";
            szSql += ", @AGeoRainDays05 ";
            szSql += ", @AGeoRainDays06 ";
            szSql += ", @AGeoRainDays07 ";
            szSql += ", @AGeoRainDays08 ";
            szSql += ", @AGeoRainDays09 ";
            szSql += ", @AGeoRainDays10 ";
            szSql += ", @AGeoRainDays11 ";
            szSql += ", @AGeoRainDays12 ";
            szSql += ", @AGeoSunMax01 ";
            szSql += ", @AGeoSunMax02 ";
            szSql += ", @AGeoSunMax03 ";
            szSql += ", @AGeoSunMax04 ";
            szSql += ", @AGeoSunMax05 ";
            szSql += ", @AGeoSunMax06 ";
            szSql += ", @AGeoSunMax07 ";
            szSql += ", @AGeoSunMax08 ";
            szSql += ", @AGeoSunMax09 ";
            szSql += ", @AGeoSunMax10 ";
            szSql += ", @AGeoSunMax11 ";
            szSql += ", @AGeoSunMax12 ";
            szSql += ", @AGeoSunMin01 ";
            szSql += ", @AGeoSunMin02 ";
            szSql += ", @AGeoSunMin03 ";
            szSql += ", @AGeoSunMin04 ";
            szSql += ", @AGeoSunMin05 ";
            szSql += ", @AGeoSunMin06 ";
            szSql += ", @AGeoSunMin07 ";
            szSql += ", @AGeoSunMin08 ";
            szSql += ", @AGeoSunMin09 ";
            szSql += ", @AGeoSunMin10 ";
            szSql += ", @AGeoSunMin11 ";
            szSql += ", @AGeoSunMin12 ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@AGeoPoliContinentKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoPoliCountriestKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoPoliLocationType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoBioWWFRealmsKey", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoBioWWFRegionKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoClimateKoppenGeigerKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoClimateKoppenGeigerImage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoLocLatitudMax", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoLocLatitudMin", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoLocAltitudMax", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoLocAltitudMin", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoClimateTableLocation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoClimateTableUrlTitle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoClimateTableUrl", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawTempMin", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawTempMax", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawTempAvg", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawRainML", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawRainDays", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoDrawSun", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpAvg12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMax12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoTmpMin12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainML12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoRainDays12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax01", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax02", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax03", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax04", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax05", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax06", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax07", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax08", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax09", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax10", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax11", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMax12", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin01", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin02", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin03", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin04", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin05", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin06", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin07", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin08", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin09", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin10", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin11", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdInsert.Parameters.Add("@AGeoSunMin12", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_geog_all SET ";

            szSql += "AGeoPoliContinentKeys=@AGeoPoliContinentKeys ";
            szSql += ", AGeoPoliCountriestKeys=@AGeoPoliCountriestKeys ";
            szSql += ", AGeoPoliLocationType=@AGeoPoliLocationType ";
            szSql += ", AGeoBioWWFRealmsKey=@AGeoBioWWFRealmsKey ";
            szSql += ", AGeoBioWWFRegionKeys=@AGeoBioWWFRegionKeys ";
            szSql += ", AGeoClimateKoppenGeigerKeys=@AGeoClimateKoppenGeigerKeys ";
            szSql += ", AGeoClimateKoppenGeigerImage=@AGeoClimateKoppenGeigerImage ";
            szSql += ", AGeoLocLatitudMax=@AGeoLocLatitudMax ";
            szSql += ", AGeoLocLatitudMin=@AGeoLocLatitudMin ";
            szSql += ", AGeoLocAltitudMax=@AGeoLocAltitudMax ";
            szSql += ", AGeoLocAltitudMin=@AGeoLocAltitudMin ";
            szSql += ", AGeoClimateTableLocation=@AGeoClimateTableLocation ";
            szSql += ", AGeoClimateTableUrlTitle=@AGeoClimateTableUrlTitle ";
            szSql += ", AGeoClimateTableUrl=@AGeoClimateTableUrl ";
            szSql += ", AGeoDrawTempMin=@AGeoDrawTempMin ";
            szSql += ", AGeoDrawTempMax=@AGeoDrawTempMax ";
            szSql += ", AGeoDrawTempAvg=@AGeoDrawTempAvg ";
            szSql += ", AGeoDrawRainML=@AGeoDrawRainML ";
            szSql += ", AGeoDrawRainDays=@AGeoDrawRainDays ";
            szSql += ", AGeoDrawSun=@AGeoDrawSun ";
            szSql += ", AGeoTmpAvg01=@AGeoTmpAvg01 ";
            szSql += ", AGeoTmpAvg02=@AGeoTmpAvg02 ";
            szSql += ", AGeoTmpAvg03=@AGeoTmpAvg03 ";
            szSql += ", AGeoTmpAvg04=@AGeoTmpAvg04 ";
            szSql += ", AGeoTmpAvg05=@AGeoTmpAvg05 ";
            szSql += ", AGeoTmpAvg06=@AGeoTmpAvg06 ";
            szSql += ", AGeoTmpAvg07=@AGeoTmpAvg07 ";
            szSql += ", AGeoTmpAvg08=@AGeoTmpAvg08 ";
            szSql += ", AGeoTmpAvg09=@AGeoTmpAvg09 ";
            szSql += ", AGeoTmpAvg10=@AGeoTmpAvg10 ";
            szSql += ", AGeoTmpAvg11=@AGeoTmpAvg11 ";
            szSql += ", AGeoTmpAvg12=@AGeoTmpAvg12 ";
            szSql += ", AGeoTmpMax01=@AGeoTmpMax01 ";
            szSql += ", AGeoTmpMax02=@AGeoTmpMax02 ";
            szSql += ", AGeoTmpMax03=@AGeoTmpMax03 ";
            szSql += ", AGeoTmpMax04=@AGeoTmpMax04 ";
            szSql += ", AGeoTmpMax05=@AGeoTmpMax05 ";
            szSql += ", AGeoTmpMax06=@AGeoTmpMax06 ";
            szSql += ", AGeoTmpMax07=@AGeoTmpMax07 ";
            szSql += ", AGeoTmpMax08=@AGeoTmpMax08 ";
            szSql += ", AGeoTmpMax09=@AGeoTmpMax09 ";
            szSql += ", AGeoTmpMax10=@AGeoTmpMax10 ";
            szSql += ", AGeoTmpMax11=@AGeoTmpMax11 ";
            szSql += ", AGeoTmpMax12=@AGeoTmpMax12 ";
            szSql += ", AGeoTmpMin01=@AGeoTmpMin01 ";
            szSql += ", AGeoTmpMin02=@AGeoTmpMin02 ";
            szSql += ", AGeoTmpMin03=@AGeoTmpMin03 ";
            szSql += ", AGeoTmpMin04=@AGeoTmpMin04 ";
            szSql += ", AGeoTmpMin05=@AGeoTmpMin05 ";
            szSql += ", AGeoTmpMin06=@AGeoTmpMin06 ";
            szSql += ", AGeoTmpMin07=@AGeoTmpMin07 ";
            szSql += ", AGeoTmpMin08=@AGeoTmpMin08 ";
            szSql += ", AGeoTmpMin09=@AGeoTmpMin09 ";
            szSql += ", AGeoTmpMin10=@AGeoTmpMin10 ";
            szSql += ", AGeoTmpMin11=@AGeoTmpMin11 ";
            szSql += ", AGeoTmpMin12=@AGeoTmpMin12 ";
            szSql += ", AGeoRainML01=@AGeoRainML01 ";
            szSql += ", AGeoRainML02=@AGeoRainML02 ";
            szSql += ", AGeoRainML03=@AGeoRainML03 ";
            szSql += ", AGeoRainML04=@AGeoRainML04 ";
            szSql += ", AGeoRainML05=@AGeoRainML05 ";
            szSql += ", AGeoRainML06=@AGeoRainML06 ";
            szSql += ", AGeoRainML07=@AGeoRainML07 ";
            szSql += ", AGeoRainML08=@AGeoRainML08 ";
            szSql += ", AGeoRainML09=@AGeoRainML09 ";
            szSql += ", AGeoRainML10=@AGeoRainML10 ";
            szSql += ", AGeoRainML11=@AGeoRainML11 ";
            szSql += ", AGeoRainML12=@AGeoRainML12 ";
            szSql += ", AGeoRainDays01=@AGeoRainDays01 ";
            szSql += ", AGeoRainDays02=@AGeoRainDays02 ";
            szSql += ", AGeoRainDays03=@AGeoRainDays03 ";
            szSql += ", AGeoRainDays04=@AGeoRainDays04 ";
            szSql += ", AGeoRainDays05=@AGeoRainDays05 ";
            szSql += ", AGeoRainDays06=@AGeoRainDays06 ";
            szSql += ", AGeoRainDays07=@AGeoRainDays07 ";
            szSql += ", AGeoRainDays08=@AGeoRainDays08 ";
            szSql += ", AGeoRainDays09=@AGeoRainDays09 ";
            szSql += ", AGeoRainDays10=@AGeoRainDays10 ";
            szSql += ", AGeoRainDays11=@AGeoRainDays11 ";
            szSql += ", AGeoRainDays12=@AGeoRainDays12 ";
            szSql += ", AGeoSunMax01=@AGeoSunMax01 ";
            szSql += ", AGeoSunMax02=@AGeoSunMax02 ";
            szSql += ", AGeoSunMax03=@AGeoSunMax03 ";
            szSql += ", AGeoSunMax04=@AGeoSunMax04 ";
            szSql += ", AGeoSunMax05=@AGeoSunMax05 ";
            szSql += ", AGeoSunMax06=@AGeoSunMax06 ";
            szSql += ", AGeoSunMax07=@AGeoSunMax07 ";
            szSql += ", AGeoSunMax08=@AGeoSunMax08 ";
            szSql += ", AGeoSunMax09=@AGeoSunMax09 ";
            szSql += ", AGeoSunMax10=@AGeoSunMax10 ";
            szSql += ", AGeoSunMax11=@AGeoSunMax11 ";
            szSql += ", AGeoSunMax12=@AGeoSunMax12 ";
            szSql += ", AGeoSunMin01=@AGeoSunMin01 ";
            szSql += ", AGeoSunMin02=@AGeoSunMin02 ";
            szSql += ", AGeoSunMin03=@AGeoSunMin03 ";
            szSql += ", AGeoSunMin04=@AGeoSunMin04 ";
            szSql += ", AGeoSunMin05=@AGeoSunMin05 ";
            szSql += ", AGeoSunMin06=@AGeoSunMin06 ";
            szSql += ", AGeoSunMin07=@AGeoSunMin07 ";
            szSql += ", AGeoSunMin08=@AGeoSunMin08 ";
            szSql += ", AGeoSunMin09=@AGeoSunMin09 ";
            szSql += ", AGeoSunMin10=@AGeoSunMin10 ";
            szSql += ", AGeoSunMin11=@AGeoSunMin11 ";
            szSql += ", AGeoSunMin12=@AGeoSunMin12 ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@AGeoPoliContinentKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoPoliCountriestKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoPoliLocationType", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoBioWWFRealmsKey", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoBioWWFRegionKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoClimateKoppenGeigerKeys", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoClimateKoppenGeigerImage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoLocLatitudMax", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoLocLatitudMin", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoLocAltitudMax", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoLocAltitudMin", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoClimateTableLocation", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoClimateTableUrlTitle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoClimateTableUrl", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawTempMin", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawTempMax", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawTempAvg", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawRainML", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawRainDays", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoDrawSun", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpAvg12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMax12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoTmpMin12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainML12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays01", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays02", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays03", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays04", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays05", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays06", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays07", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays08", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays09", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays10", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays11", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoRainDays12", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax01", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax02", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax03", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax04", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax05", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax06", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax07", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax08", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax09", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax10", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax11", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMax12", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin01", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin02", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin03", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin04", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin05", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin06", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin07", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin08", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin09", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin10", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin11", MySql.Data.MySqlClient.MySqlDbType.Double);
            oSqlCmdUpdate.Parameters.Add("@AGeoSunMin12", MySql.Data.MySqlClient.MySqlDbType.Double);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_geog_all  ";
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
            szSql += " FROM tdoclng_testudines_geog_all  ";

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
            oSqlCmdUpdate.Parameters["@AGeoPoliContinentKeys"].Value = m_AGeoPoliContinentKeys;
            oSqlCmdUpdate.Parameters["@AGeoPoliCountriestKeys"].Value = m_AGeoPoliCountriestKeys;
            oSqlCmdUpdate.Parameters["@AGeoPoliLocationType"].Value = m_AGeoPoliLocationType;
            oSqlCmdUpdate.Parameters["@AGeoBioWWFRealmsKey"].Value = m_AGeoBioWWFRealmsKey;
            oSqlCmdUpdate.Parameters["@AGeoBioWWFRegionKeys"].Value = m_AGeoBioWWFRegionKeys;
            oSqlCmdUpdate.Parameters["@AGeoClimateKoppenGeigerKeys"].Value = m_AGeoClimateKoppenGeigerKeys;
            oSqlCmdUpdate.Parameters["@AGeoClimateKoppenGeigerImage"].Value = m_AGeoClimateKoppenGeigerImage;
            oSqlCmdUpdate.Parameters["@AGeoLocLatitudMax"].Value = m_AGeoLocLatitudMax;
            oSqlCmdUpdate.Parameters["@AGeoLocLatitudMin"].Value = m_AGeoLocLatitudMin;
            oSqlCmdUpdate.Parameters["@AGeoLocAltitudMax"].Value = m_AGeoLocAltitudMax;
            oSqlCmdUpdate.Parameters["@AGeoLocAltitudMin"].Value = m_AGeoLocAltitudMin;
            oSqlCmdUpdate.Parameters["@AGeoClimateTableLocation"].Value = m_AGeoClimateTableLocation;
            oSqlCmdUpdate.Parameters["@AGeoClimateTableUrlTitle"].Value = m_AGeoClimateTableUrlTitle;
            oSqlCmdUpdate.Parameters["@AGeoClimateTableUrl"].Value = m_AGeoClimateTableUrl;
            oSqlCmdUpdate.Parameters["@AGeoDrawTempMin"].Value = m_AGeoDrawTempMin;
            oSqlCmdUpdate.Parameters["@AGeoDrawTempMax"].Value = m_AGeoDrawTempMax;
            oSqlCmdUpdate.Parameters["@AGeoDrawTempAvg"].Value = m_AGeoDrawTempAvg;
            oSqlCmdUpdate.Parameters["@AGeoDrawRainML"].Value = m_AGeoDrawRainML;
            oSqlCmdUpdate.Parameters["@AGeoDrawRainDays"].Value = m_AGeoDrawRainDays;
            oSqlCmdUpdate.Parameters["@AGeoDrawSun"].Value = m_AGeoDrawSun;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg01"].Value = m_AGeoTmpAvg01;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg02"].Value = m_AGeoTmpAvg02;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg03"].Value = m_AGeoTmpAvg03;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg04"].Value = m_AGeoTmpAvg04;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg05"].Value = m_AGeoTmpAvg05;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg06"].Value = m_AGeoTmpAvg06;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg07"].Value = m_AGeoTmpAvg07;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg08"].Value = m_AGeoTmpAvg08;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg09"].Value = m_AGeoTmpAvg09;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg10"].Value = m_AGeoTmpAvg10;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg11"].Value = m_AGeoTmpAvg11;
            oSqlCmdUpdate.Parameters["@AGeoTmpAvg12"].Value = m_AGeoTmpAvg12;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax01"].Value = m_AGeoTmpMax01;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax02"].Value = m_AGeoTmpMax02;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax03"].Value = m_AGeoTmpMax03;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax04"].Value = m_AGeoTmpMax04;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax05"].Value = m_AGeoTmpMax05;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax06"].Value = m_AGeoTmpMax06;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax07"].Value = m_AGeoTmpMax07;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax08"].Value = m_AGeoTmpMax08;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax09"].Value = m_AGeoTmpMax09;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax10"].Value = m_AGeoTmpMax10;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax11"].Value = m_AGeoTmpMax11;
            oSqlCmdUpdate.Parameters["@AGeoTmpMax12"].Value = m_AGeoTmpMax12;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin01"].Value = m_AGeoTmpMin01;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin02"].Value = m_AGeoTmpMin02;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin03"].Value = m_AGeoTmpMin03;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin04"].Value = m_AGeoTmpMin04;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin05"].Value = m_AGeoTmpMin05;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin06"].Value = m_AGeoTmpMin06;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin07"].Value = m_AGeoTmpMin07;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin08"].Value = m_AGeoTmpMin08;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin09"].Value = m_AGeoTmpMin09;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin10"].Value = m_AGeoTmpMin10;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin11"].Value = m_AGeoTmpMin11;
            oSqlCmdUpdate.Parameters["@AGeoTmpMin12"].Value = m_AGeoTmpMin12;
            oSqlCmdUpdate.Parameters["@AGeoRainML01"].Value = m_AGeoRainML01;
            oSqlCmdUpdate.Parameters["@AGeoRainML02"].Value = m_AGeoRainML02;
            oSqlCmdUpdate.Parameters["@AGeoRainML03"].Value = m_AGeoRainML03;
            oSqlCmdUpdate.Parameters["@AGeoRainML04"].Value = m_AGeoRainML04;
            oSqlCmdUpdate.Parameters["@AGeoRainML05"].Value = m_AGeoRainML05;
            oSqlCmdUpdate.Parameters["@AGeoRainML06"].Value = m_AGeoRainML06;
            oSqlCmdUpdate.Parameters["@AGeoRainML07"].Value = m_AGeoRainML07;
            oSqlCmdUpdate.Parameters["@AGeoRainML08"].Value = m_AGeoRainML08;
            oSqlCmdUpdate.Parameters["@AGeoRainML09"].Value = m_AGeoRainML09;
            oSqlCmdUpdate.Parameters["@AGeoRainML10"].Value = m_AGeoRainML10;
            oSqlCmdUpdate.Parameters["@AGeoRainML11"].Value = m_AGeoRainML11;
            oSqlCmdUpdate.Parameters["@AGeoRainML12"].Value = m_AGeoRainML12;
            oSqlCmdUpdate.Parameters["@AGeoRainDays01"].Value = m_AGeoRainDays01;
            oSqlCmdUpdate.Parameters["@AGeoRainDays02"].Value = m_AGeoRainDays02;
            oSqlCmdUpdate.Parameters["@AGeoRainDays03"].Value = m_AGeoRainDays03;
            oSqlCmdUpdate.Parameters["@AGeoRainDays04"].Value = m_AGeoRainDays04;
            oSqlCmdUpdate.Parameters["@AGeoRainDays05"].Value = m_AGeoRainDays05;
            oSqlCmdUpdate.Parameters["@AGeoRainDays06"].Value = m_AGeoRainDays06;
            oSqlCmdUpdate.Parameters["@AGeoRainDays07"].Value = m_AGeoRainDays07;
            oSqlCmdUpdate.Parameters["@AGeoRainDays08"].Value = m_AGeoRainDays08;
            oSqlCmdUpdate.Parameters["@AGeoRainDays09"].Value = m_AGeoRainDays09;
            oSqlCmdUpdate.Parameters["@AGeoRainDays10"].Value = m_AGeoRainDays10;
            oSqlCmdUpdate.Parameters["@AGeoRainDays11"].Value = m_AGeoRainDays11;
            oSqlCmdUpdate.Parameters["@AGeoRainDays12"].Value = m_AGeoRainDays12;
            oSqlCmdUpdate.Parameters["@AGeoSunMax01"].Value = m_AGeoSunMax01;
            oSqlCmdUpdate.Parameters["@AGeoSunMax02"].Value = m_AGeoSunMax02;
            oSqlCmdUpdate.Parameters["@AGeoSunMax03"].Value = m_AGeoSunMax03;
            oSqlCmdUpdate.Parameters["@AGeoSunMax04"].Value = m_AGeoSunMax04;
            oSqlCmdUpdate.Parameters["@AGeoSunMax05"].Value = m_AGeoSunMax05;
            oSqlCmdUpdate.Parameters["@AGeoSunMax06"].Value = m_AGeoSunMax06;
            oSqlCmdUpdate.Parameters["@AGeoSunMax07"].Value = m_AGeoSunMax07;
            oSqlCmdUpdate.Parameters["@AGeoSunMax08"].Value = m_AGeoSunMax08;
            oSqlCmdUpdate.Parameters["@AGeoSunMax09"].Value = m_AGeoSunMax09;
            oSqlCmdUpdate.Parameters["@AGeoSunMax10"].Value = m_AGeoSunMax10;
            oSqlCmdUpdate.Parameters["@AGeoSunMax11"].Value = m_AGeoSunMax11;
            oSqlCmdUpdate.Parameters["@AGeoSunMax12"].Value = m_AGeoSunMax12;
            oSqlCmdUpdate.Parameters["@AGeoSunMin01"].Value = m_AGeoSunMin01;
            oSqlCmdUpdate.Parameters["@AGeoSunMin02"].Value = m_AGeoSunMin02;
            oSqlCmdUpdate.Parameters["@AGeoSunMin03"].Value = m_AGeoSunMin03;
            oSqlCmdUpdate.Parameters["@AGeoSunMin04"].Value = m_AGeoSunMin04;
            oSqlCmdUpdate.Parameters["@AGeoSunMin05"].Value = m_AGeoSunMin05;
            oSqlCmdUpdate.Parameters["@AGeoSunMin06"].Value = m_AGeoSunMin06;
            oSqlCmdUpdate.Parameters["@AGeoSunMin07"].Value = m_AGeoSunMin07;
            oSqlCmdUpdate.Parameters["@AGeoSunMin08"].Value = m_AGeoSunMin08;
            oSqlCmdUpdate.Parameters["@AGeoSunMin09"].Value = m_AGeoSunMin09;
            oSqlCmdUpdate.Parameters["@AGeoSunMin10"].Value = m_AGeoSunMin10;
            oSqlCmdUpdate.Parameters["@AGeoSunMin11"].Value = m_AGeoSunMin11;
            oSqlCmdUpdate.Parameters["@AGeoSunMin12"].Value = m_AGeoSunMin12;
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
            oSqlCmdInsert.Parameters["@AGeoPoliContinentKeys"].Value = m_AGeoPoliContinentKeys;
            oSqlCmdInsert.Parameters["@AGeoPoliCountriestKeys"].Value = m_AGeoPoliCountriestKeys;
            oSqlCmdInsert.Parameters["@AGeoPoliLocationType"].Value = m_AGeoPoliLocationType;
            oSqlCmdInsert.Parameters["@AGeoBioWWFRealmsKey"].Value = m_AGeoBioWWFRealmsKey;
            oSqlCmdInsert.Parameters["@AGeoBioWWFRegionKeys"].Value = m_AGeoBioWWFRegionKeys;
            oSqlCmdInsert.Parameters["@AGeoClimateKoppenGeigerKeys"].Value = m_AGeoClimateKoppenGeigerKeys;
            oSqlCmdInsert.Parameters["@AGeoClimateKoppenGeigerImage"].Value = m_AGeoClimateKoppenGeigerImage;
            oSqlCmdInsert.Parameters["@AGeoLocLatitudMax"].Value = m_AGeoLocLatitudMax;
            oSqlCmdInsert.Parameters["@AGeoLocLatitudMin"].Value = m_AGeoLocLatitudMin;
            oSqlCmdInsert.Parameters["@AGeoLocAltitudMax"].Value = m_AGeoLocAltitudMax;
            oSqlCmdInsert.Parameters["@AGeoLocAltitudMin"].Value = m_AGeoLocAltitudMin;
            oSqlCmdInsert.Parameters["@AGeoClimateTableLocation"].Value = m_AGeoClimateTableLocation;
            oSqlCmdInsert.Parameters["@AGeoClimateTableUrlTitle"].Value = m_AGeoClimateTableUrlTitle;
            oSqlCmdInsert.Parameters["@AGeoClimateTableUrl"].Value = m_AGeoClimateTableUrl;
            oSqlCmdInsert.Parameters["@AGeoDrawTempMin"].Value = m_AGeoDrawTempMin;
            oSqlCmdInsert.Parameters["@AGeoDrawTempMax"].Value = m_AGeoDrawTempMax;
            oSqlCmdInsert.Parameters["@AGeoDrawTempAvg"].Value = m_AGeoDrawTempAvg;
            oSqlCmdInsert.Parameters["@AGeoDrawRainML"].Value = m_AGeoDrawRainML;
            oSqlCmdInsert.Parameters["@AGeoDrawRainDays"].Value = m_AGeoDrawRainDays;
            oSqlCmdInsert.Parameters["@AGeoDrawSun"].Value = m_AGeoDrawSun;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg01"].Value = m_AGeoTmpAvg01;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg02"].Value = m_AGeoTmpAvg02;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg03"].Value = m_AGeoTmpAvg03;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg04"].Value = m_AGeoTmpAvg04;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg05"].Value = m_AGeoTmpAvg05;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg06"].Value = m_AGeoTmpAvg06;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg07"].Value = m_AGeoTmpAvg07;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg08"].Value = m_AGeoTmpAvg08;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg09"].Value = m_AGeoTmpAvg09;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg10"].Value = m_AGeoTmpAvg10;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg11"].Value = m_AGeoTmpAvg11;
            oSqlCmdInsert.Parameters["@AGeoTmpAvg12"].Value = m_AGeoTmpAvg12;
            oSqlCmdInsert.Parameters["@AGeoTmpMax01"].Value = m_AGeoTmpMax01;
            oSqlCmdInsert.Parameters["@AGeoTmpMax02"].Value = m_AGeoTmpMax02;
            oSqlCmdInsert.Parameters["@AGeoTmpMax03"].Value = m_AGeoTmpMax03;
            oSqlCmdInsert.Parameters["@AGeoTmpMax04"].Value = m_AGeoTmpMax04;
            oSqlCmdInsert.Parameters["@AGeoTmpMax05"].Value = m_AGeoTmpMax05;
            oSqlCmdInsert.Parameters["@AGeoTmpMax06"].Value = m_AGeoTmpMax06;
            oSqlCmdInsert.Parameters["@AGeoTmpMax07"].Value = m_AGeoTmpMax07;
            oSqlCmdInsert.Parameters["@AGeoTmpMax08"].Value = m_AGeoTmpMax08;
            oSqlCmdInsert.Parameters["@AGeoTmpMax09"].Value = m_AGeoTmpMax09;
            oSqlCmdInsert.Parameters["@AGeoTmpMax10"].Value = m_AGeoTmpMax10;
            oSqlCmdInsert.Parameters["@AGeoTmpMax11"].Value = m_AGeoTmpMax11;
            oSqlCmdInsert.Parameters["@AGeoTmpMax12"].Value = m_AGeoTmpMax12;
            oSqlCmdInsert.Parameters["@AGeoTmpMin01"].Value = m_AGeoTmpMin01;
            oSqlCmdInsert.Parameters["@AGeoTmpMin02"].Value = m_AGeoTmpMin02;
            oSqlCmdInsert.Parameters["@AGeoTmpMin03"].Value = m_AGeoTmpMin03;
            oSqlCmdInsert.Parameters["@AGeoTmpMin04"].Value = m_AGeoTmpMin04;
            oSqlCmdInsert.Parameters["@AGeoTmpMin05"].Value = m_AGeoTmpMin05;
            oSqlCmdInsert.Parameters["@AGeoTmpMin06"].Value = m_AGeoTmpMin06;
            oSqlCmdInsert.Parameters["@AGeoTmpMin07"].Value = m_AGeoTmpMin07;
            oSqlCmdInsert.Parameters["@AGeoTmpMin08"].Value = m_AGeoTmpMin08;
            oSqlCmdInsert.Parameters["@AGeoTmpMin09"].Value = m_AGeoTmpMin09;
            oSqlCmdInsert.Parameters["@AGeoTmpMin10"].Value = m_AGeoTmpMin10;
            oSqlCmdInsert.Parameters["@AGeoTmpMin11"].Value = m_AGeoTmpMin11;
            oSqlCmdInsert.Parameters["@AGeoTmpMin12"].Value = m_AGeoTmpMin12;
            oSqlCmdInsert.Parameters["@AGeoRainML01"].Value = m_AGeoRainML01;
            oSqlCmdInsert.Parameters["@AGeoRainML02"].Value = m_AGeoRainML02;
            oSqlCmdInsert.Parameters["@AGeoRainML03"].Value = m_AGeoRainML03;
            oSqlCmdInsert.Parameters["@AGeoRainML04"].Value = m_AGeoRainML04;
            oSqlCmdInsert.Parameters["@AGeoRainML05"].Value = m_AGeoRainML05;
            oSqlCmdInsert.Parameters["@AGeoRainML06"].Value = m_AGeoRainML06;
            oSqlCmdInsert.Parameters["@AGeoRainML07"].Value = m_AGeoRainML07;
            oSqlCmdInsert.Parameters["@AGeoRainML08"].Value = m_AGeoRainML08;
            oSqlCmdInsert.Parameters["@AGeoRainML09"].Value = m_AGeoRainML09;
            oSqlCmdInsert.Parameters["@AGeoRainML10"].Value = m_AGeoRainML10;
            oSqlCmdInsert.Parameters["@AGeoRainML11"].Value = m_AGeoRainML11;
            oSqlCmdInsert.Parameters["@AGeoRainML12"].Value = m_AGeoRainML12;
            oSqlCmdInsert.Parameters["@AGeoRainDays01"].Value = m_AGeoRainDays01;
            oSqlCmdInsert.Parameters["@AGeoRainDays02"].Value = m_AGeoRainDays02;
            oSqlCmdInsert.Parameters["@AGeoRainDays03"].Value = m_AGeoRainDays03;
            oSqlCmdInsert.Parameters["@AGeoRainDays04"].Value = m_AGeoRainDays04;
            oSqlCmdInsert.Parameters["@AGeoRainDays05"].Value = m_AGeoRainDays05;
            oSqlCmdInsert.Parameters["@AGeoRainDays06"].Value = m_AGeoRainDays06;
            oSqlCmdInsert.Parameters["@AGeoRainDays07"].Value = m_AGeoRainDays07;
            oSqlCmdInsert.Parameters["@AGeoRainDays08"].Value = m_AGeoRainDays08;
            oSqlCmdInsert.Parameters["@AGeoRainDays09"].Value = m_AGeoRainDays09;
            oSqlCmdInsert.Parameters["@AGeoRainDays10"].Value = m_AGeoRainDays10;
            oSqlCmdInsert.Parameters["@AGeoRainDays11"].Value = m_AGeoRainDays11;
            oSqlCmdInsert.Parameters["@AGeoRainDays12"].Value = m_AGeoRainDays12;
            oSqlCmdInsert.Parameters["@AGeoSunMax01"].Value = m_AGeoSunMax01;
            oSqlCmdInsert.Parameters["@AGeoSunMax02"].Value = m_AGeoSunMax02;
            oSqlCmdInsert.Parameters["@AGeoSunMax03"].Value = m_AGeoSunMax03;
            oSqlCmdInsert.Parameters["@AGeoSunMax04"].Value = m_AGeoSunMax04;
            oSqlCmdInsert.Parameters["@AGeoSunMax05"].Value = m_AGeoSunMax05;
            oSqlCmdInsert.Parameters["@AGeoSunMax06"].Value = m_AGeoSunMax06;
            oSqlCmdInsert.Parameters["@AGeoSunMax07"].Value = m_AGeoSunMax07;
            oSqlCmdInsert.Parameters["@AGeoSunMax08"].Value = m_AGeoSunMax08;
            oSqlCmdInsert.Parameters["@AGeoSunMax09"].Value = m_AGeoSunMax09;
            oSqlCmdInsert.Parameters["@AGeoSunMax10"].Value = m_AGeoSunMax10;
            oSqlCmdInsert.Parameters["@AGeoSunMax11"].Value = m_AGeoSunMax11;
            oSqlCmdInsert.Parameters["@AGeoSunMax12"].Value = m_AGeoSunMax12;
            oSqlCmdInsert.Parameters["@AGeoSunMin01"].Value = m_AGeoSunMin01;
            oSqlCmdInsert.Parameters["@AGeoSunMin02"].Value = m_AGeoSunMin02;
            oSqlCmdInsert.Parameters["@AGeoSunMin03"].Value = m_AGeoSunMin03;
            oSqlCmdInsert.Parameters["@AGeoSunMin04"].Value = m_AGeoSunMin04;
            oSqlCmdInsert.Parameters["@AGeoSunMin05"].Value = m_AGeoSunMin05;
            oSqlCmdInsert.Parameters["@AGeoSunMin06"].Value = m_AGeoSunMin06;
            oSqlCmdInsert.Parameters["@AGeoSunMin07"].Value = m_AGeoSunMin07;
            oSqlCmdInsert.Parameters["@AGeoSunMin08"].Value = m_AGeoSunMin08;
            oSqlCmdInsert.Parameters["@AGeoSunMin09"].Value = m_AGeoSunMin09;
            oSqlCmdInsert.Parameters["@AGeoSunMin10"].Value = m_AGeoSunMin10;
            oSqlCmdInsert.Parameters["@AGeoSunMin11"].Value = m_AGeoSunMin11;
            oSqlCmdInsert.Parameters["@AGeoSunMin12"].Value = m_AGeoSunMin12;
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
            MySqlDataReader oDR=null; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
               // if (!ClsMysql.FncOpen("")) { return false; }
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_AGeoPoliContinentKeys = oDR["AGeoPoliContinentKeys"].ToString();
                    m_AGeoPoliCountriestKeys = oDR["AGeoPoliCountriestKeys"].ToString();
                    m_AGeoPoliLocationType = oDR["AGeoPoliLocationType"].ToString();
                    m_AGeoBioWWFRealmsKey = oDR["AGeoBioWWFRealmsKey"].ToString();
                    m_AGeoBioWWFRegionKeys = oDR["AGeoBioWWFRegionKeys"].ToString();
                    m_AGeoClimateKoppenGeigerKeys = oDR["AGeoClimateKoppenGeigerKeys"].ToString();
                    m_AGeoClimateKoppenGeigerImage = oDR["AGeoClimateKoppenGeigerImage"].ToString();
                    m_AGeoLocLatitudMax = Convert.ToInt32(oDR["AGeoLocLatitudMax"].ToString());
                    m_AGeoLocLatitudMin = Convert.ToInt32(oDR["AGeoLocLatitudMin"].ToString());
                    m_AGeoLocAltitudMax = Convert.ToInt32(oDR["AGeoLocAltitudMax"].ToString());
                    m_AGeoLocAltitudMin = Convert.ToInt32(oDR["AGeoLocAltitudMin"].ToString());
                    m_AGeoClimateTableLocation = oDR["AGeoClimateTableLocation"].ToString();
                    m_AGeoClimateTableUrlTitle = oDR["AGeoClimateTableUrlTitle"].ToString();
                    m_AGeoClimateTableUrl = oDR["AGeoClimateTableUrl"].ToString();
                    m_AGeoDrawTempMin = Convert.ToByte(oDR["AGeoDrawTempMin"]);
                    m_AGeoDrawTempMax = Convert.ToByte(oDR["AGeoDrawTempMax"]);
                    m_AGeoDrawTempAvg = Convert.ToByte(oDR["AGeoDrawTempAvg"]);
                    m_AGeoDrawRainML = Convert.ToByte(oDR["AGeoDrawRainML"]);
                    m_AGeoDrawRainDays = Convert.ToByte(oDR["AGeoDrawRainDays"]);
                    m_AGeoDrawSun = Convert.ToByte(oDR["AGeoDrawSun"]);
                    m_AGeoTmpAvg01 = Convert.ToInt32(oDR["AGeoTmpAvg01"].ToString());
                    m_AGeoTmpAvg02 = Convert.ToInt32(oDR["AGeoTmpAvg02"].ToString());
                    m_AGeoTmpAvg03 = Convert.ToInt32(oDR["AGeoTmpAvg03"].ToString());
                    m_AGeoTmpAvg04 = Convert.ToInt32(oDR["AGeoTmpAvg04"].ToString());
                    m_AGeoTmpAvg05 = Convert.ToInt32(oDR["AGeoTmpAvg05"].ToString());
                    m_AGeoTmpAvg06 = Convert.ToInt32(oDR["AGeoTmpAvg06"].ToString());
                    m_AGeoTmpAvg07 = Convert.ToInt32(oDR["AGeoTmpAvg07"].ToString());
                    m_AGeoTmpAvg08 = Convert.ToInt32(oDR["AGeoTmpAvg08"].ToString());
                    m_AGeoTmpAvg09 = Convert.ToInt32(oDR["AGeoTmpAvg09"].ToString());
                    m_AGeoTmpAvg10 = Convert.ToInt32(oDR["AGeoTmpAvg10"].ToString());
                    m_AGeoTmpAvg11 = Convert.ToInt32(oDR["AGeoTmpAvg11"].ToString());
                    m_AGeoTmpAvg12 = Convert.ToInt32(oDR["AGeoTmpAvg12"].ToString());
                    m_AGeoTmpMax01 = Convert.ToInt32(oDR["AGeoTmpMax01"].ToString());
                    m_AGeoTmpMax02 = Convert.ToInt32(oDR["AGeoTmpMax02"].ToString());
                    m_AGeoTmpMax03 = Convert.ToInt32(oDR["AGeoTmpMax03"].ToString());
                    m_AGeoTmpMax04 = Convert.ToInt32(oDR["AGeoTmpMax04"].ToString());
                    m_AGeoTmpMax05 = Convert.ToInt32(oDR["AGeoTmpMax05"].ToString());
                    m_AGeoTmpMax06 = Convert.ToInt32(oDR["AGeoTmpMax06"].ToString());
                    m_AGeoTmpMax07 = Convert.ToInt32(oDR["AGeoTmpMax07"].ToString());
                    m_AGeoTmpMax08 = Convert.ToInt32(oDR["AGeoTmpMax08"].ToString());
                    m_AGeoTmpMax09 = Convert.ToInt32(oDR["AGeoTmpMax09"].ToString());
                    m_AGeoTmpMax10 = Convert.ToInt32(oDR["AGeoTmpMax10"].ToString());
                    m_AGeoTmpMax11 = Convert.ToInt32(oDR["AGeoTmpMax11"].ToString());
                    m_AGeoTmpMax12 = Convert.ToInt32(oDR["AGeoTmpMax12"].ToString());
                    m_AGeoTmpMin01 = Convert.ToInt32(oDR["AGeoTmpMin01"].ToString());
                    m_AGeoTmpMin02 = Convert.ToInt32(oDR["AGeoTmpMin02"].ToString());
                    m_AGeoTmpMin03 = Convert.ToInt32(oDR["AGeoTmpMin03"].ToString());
                    m_AGeoTmpMin04 = Convert.ToInt32(oDR["AGeoTmpMin04"].ToString());
                    m_AGeoTmpMin05 = Convert.ToInt32(oDR["AGeoTmpMin05"].ToString());
                    m_AGeoTmpMin06 = Convert.ToInt32(oDR["AGeoTmpMin06"].ToString());
                    m_AGeoTmpMin07 = Convert.ToInt32(oDR["AGeoTmpMin07"].ToString());
                    m_AGeoTmpMin08 = Convert.ToInt32(oDR["AGeoTmpMin08"].ToString());
                    m_AGeoTmpMin09 = Convert.ToInt32(oDR["AGeoTmpMin09"].ToString());
                    m_AGeoTmpMin10 = Convert.ToInt32(oDR["AGeoTmpMin10"].ToString());
                    m_AGeoTmpMin11 = Convert.ToInt32(oDR["AGeoTmpMin11"].ToString());
                    m_AGeoTmpMin12 = Convert.ToInt32(oDR["AGeoTmpMin12"].ToString());
                    m_AGeoRainML01 = Convert.ToInt32(oDR["AGeoRainML01"].ToString());
                    m_AGeoRainML02 = Convert.ToInt32(oDR["AGeoRainML02"].ToString());
                    m_AGeoRainML03 = Convert.ToInt32(oDR["AGeoRainML03"].ToString());
                    m_AGeoRainML04 = Convert.ToInt32(oDR["AGeoRainML04"].ToString());
                    m_AGeoRainML05 = Convert.ToInt32(oDR["AGeoRainML05"].ToString());
                    m_AGeoRainML06 = Convert.ToInt32(oDR["AGeoRainML06"].ToString());
                    m_AGeoRainML07 = Convert.ToInt32(oDR["AGeoRainML07"].ToString());
                    m_AGeoRainML08 = Convert.ToInt32(oDR["AGeoRainML08"].ToString());
                    m_AGeoRainML09 = Convert.ToInt32(oDR["AGeoRainML09"].ToString());
                    m_AGeoRainML10 = Convert.ToInt32(oDR["AGeoRainML10"].ToString());
                    m_AGeoRainML11 = Convert.ToInt32(oDR["AGeoRainML11"].ToString());
                    m_AGeoRainML12 = Convert.ToInt32(oDR["AGeoRainML12"].ToString());
                    m_AGeoRainDays01 = Convert.ToInt32(oDR["AGeoRainDays01"].ToString());
                    m_AGeoRainDays02 = Convert.ToInt32(oDR["AGeoRainDays02"].ToString());
                    m_AGeoRainDays03 = Convert.ToInt32(oDR["AGeoRainDays03"].ToString());
                    m_AGeoRainDays04 = Convert.ToInt32(oDR["AGeoRainDays04"].ToString());
                    m_AGeoRainDays05 = Convert.ToInt32(oDR["AGeoRainDays05"].ToString());
                    m_AGeoRainDays06 = Convert.ToInt32(oDR["AGeoRainDays06"].ToString());
                    m_AGeoRainDays07 = Convert.ToInt32(oDR["AGeoRainDays07"].ToString());
                    m_AGeoRainDays08 = Convert.ToInt32(oDR["AGeoRainDays08"].ToString());
                    m_AGeoRainDays09 = Convert.ToInt32(oDR["AGeoRainDays09"].ToString());
                    m_AGeoRainDays10 = Convert.ToInt32(oDR["AGeoRainDays10"].ToString());
                    m_AGeoRainDays11 = Convert.ToInt32(oDR["AGeoRainDays11"].ToString());
                    m_AGeoRainDays12 = Convert.ToInt32(oDR["AGeoRainDays12"].ToString());
                    m_AGeoSunMax01 = Convert.ToDouble(oDR["AGeoSunMax01"].ToString());
                    m_AGeoSunMax02 = Convert.ToDouble(oDR["AGeoSunMax02"].ToString());
                    m_AGeoSunMax03 = Convert.ToDouble(oDR["AGeoSunMax03"].ToString());
                    m_AGeoSunMax04 = Convert.ToDouble(oDR["AGeoSunMax04"].ToString());
                    m_AGeoSunMax05 = Convert.ToDouble(oDR["AGeoSunMax05"].ToString());
                    m_AGeoSunMax06 = Convert.ToDouble(oDR["AGeoSunMax06"].ToString());
                    m_AGeoSunMax07 = Convert.ToDouble(oDR["AGeoSunMax07"].ToString());
                    m_AGeoSunMax08 = Convert.ToDouble(oDR["AGeoSunMax08"].ToString());
                    m_AGeoSunMax09 = Convert.ToDouble(oDR["AGeoSunMax09"].ToString());
                    m_AGeoSunMax10 = Convert.ToDouble(oDR["AGeoSunMax10"].ToString());
                    m_AGeoSunMax11 = Convert.ToDouble(oDR["AGeoSunMax11"].ToString());
                    m_AGeoSunMax12 = Convert.ToDouble(oDR["AGeoSunMax12"].ToString());
                    m_AGeoSunMin01 = Convert.ToDouble(oDR["AGeoSunMin01"].ToString());
                    m_AGeoSunMin02 = Convert.ToDouble(oDR["AGeoSunMin02"].ToString());
                    m_AGeoSunMin03 = Convert.ToDouble(oDR["AGeoSunMin03"].ToString());
                    m_AGeoSunMin04 = Convert.ToDouble(oDR["AGeoSunMin04"].ToString());
                    m_AGeoSunMin05 = Convert.ToDouble(oDR["AGeoSunMin05"].ToString());
                    m_AGeoSunMin06 = Convert.ToDouble(oDR["AGeoSunMin06"].ToString());
                    m_AGeoSunMin07 = Convert.ToDouble(oDR["AGeoSunMin07"].ToString());
                    m_AGeoSunMin08 = Convert.ToDouble(oDR["AGeoSunMin08"].ToString());
                    m_AGeoSunMin09 = Convert.ToDouble(oDR["AGeoSunMin09"].ToString());
                    m_AGeoSunMin10 = Convert.ToDouble(oDR["AGeoSunMin10"].ToString());
                    m_AGeoSunMin11 = Convert.ToDouble(oDR["AGeoSunMin11"].ToString());
                    m_AGeoSunMin12 = Convert.ToDouble(oDR["AGeoSunMin12"].ToString());
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
            finally { if (oDR != null) oDR.Close(); }
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

        public String AGeoPoliContinentKeys
        {
            set
            {
                m_AGeoPoliContinentKeys = value;
            }
            get { return m_AGeoPoliContinentKeys; }
        }

        //................................

        public String AGeoPoliCountriestKeys
        {
            set
            {
                m_AGeoPoliCountriestKeys = value;
            }
            get { return m_AGeoPoliCountriestKeys; }
        }

        //................................

        public String AGeoPoliLocationType
        {
            set
            {
                m_AGeoPoliLocationType = value;
            }
            get { return m_AGeoPoliLocationType; }
        }

        //................................

        public String AGeoBioWWFRealmsKey
        {
            set
            {
                m_AGeoBioWWFRealmsKey = value;
            }
            get { return m_AGeoBioWWFRealmsKey; }
        }

        //................................

        public String AGeoBioWWFRegionKeys
        {
            set
            {
                m_AGeoBioWWFRegionKeys = value;
            }
            get { return m_AGeoBioWWFRegionKeys; }
        }

        //................................

        public String AGeoClimateKoppenGeigerKeys
        {
            set
            {
                m_AGeoClimateKoppenGeigerKeys = value;
            }
            get { return m_AGeoClimateKoppenGeigerKeys; }
        }

        //................................

        public String AGeoClimateKoppenGeigerImage
        {
            set
            {
                m_AGeoClimateKoppenGeigerImage = value;
            }
            get { return m_AGeoClimateKoppenGeigerImage; }
        }

        //................................

        public Int32 AGeoLocLatitudMax
        {
            set
            {
                m_AGeoLocLatitudMax = value;
            }
            get { return m_AGeoLocLatitudMax; }
        }

        //................................

        public Int32 AGeoLocLatitudMin
        {
            set
            {
                m_AGeoLocLatitudMin = value;
            }
            get { return m_AGeoLocLatitudMin; }
        }

        //................................

        public Int32 AGeoLocAltitudMax
        {
            set
            {
                m_AGeoLocAltitudMax = value;
            }
            get { return m_AGeoLocAltitudMax; }
        }

        //................................

        public Int32 AGeoLocAltitudMin
        {
            set
            {
                m_AGeoLocAltitudMin = value;
            }
            get { return m_AGeoLocAltitudMin; }
        }

        //................................

        public String AGeoClimateTableLocation
        {
            set
            {
                m_AGeoClimateTableLocation = value;
            }
            get { return m_AGeoClimateTableLocation; }
        }

        //................................

        public String AGeoClimateTableUrlTitle
        {
            set
            {
                m_AGeoClimateTableUrlTitle = value;
            }
            get { return m_AGeoClimateTableUrlTitle; }
        }

        //................................

        public String AGeoClimateTableUrl
        {
            set
            {
                m_AGeoClimateTableUrl = value;
            }
            get { return m_AGeoClimateTableUrl; }
        }

        //................................

        public Byte AGeoDrawTempMin
        {
            set
            {
                m_AGeoDrawTempMin = value;
            }
            get { return m_AGeoDrawTempMin; }
        }

        //................................

        public Byte AGeoDrawTempMax
        {
            set
            {
                m_AGeoDrawTempMax = value;
            }
            get { return m_AGeoDrawTempMax; }
        }

        //................................

        public Byte AGeoDrawTempAvg
        {
            set
            {
                m_AGeoDrawTempAvg = value;
            }
            get { return m_AGeoDrawTempAvg; }
        }

        //................................

        public Byte AGeoDrawRainML
        {
            set
            {
                m_AGeoDrawRainML = value;
            }
            get { return m_AGeoDrawRainML; }
        }

        //................................

        public Byte AGeoDrawRainDays
        {
            set
            {
                m_AGeoDrawRainDays = value;
            }
            get { return m_AGeoDrawRainDays; }
        }

        //................................

        public Byte AGeoDrawSun
        {
            set
            {
                m_AGeoDrawSun = value;
            }
            get { return m_AGeoDrawSun; }
        }

        //................................

        public Int32 AGeoTmpAvg01
        {
            set
            {
                m_AGeoTmpAvg01 = value;
            }
            get { return m_AGeoTmpAvg01; }
        }

        //................................

        public Int32 AGeoTmpAvg02
        {
            set
            {
                m_AGeoTmpAvg02 = value;
            }
            get { return m_AGeoTmpAvg02; }
        }

        //................................

        public Int32 AGeoTmpAvg03
        {
            set
            {
                m_AGeoTmpAvg03 = value;
            }
            get { return m_AGeoTmpAvg03; }
        }

        //................................

        public Int32 AGeoTmpAvg04
        {
            set
            {
                m_AGeoTmpAvg04 = value;
            }
            get { return m_AGeoTmpAvg04; }
        }

        //................................

        public Int32 AGeoTmpAvg05
        {
            set
            {
                m_AGeoTmpAvg05 = value;
            }
            get { return m_AGeoTmpAvg05; }
        }

        //................................

        public Int32 AGeoTmpAvg06
        {
            set
            {
                m_AGeoTmpAvg06 = value;
            }
            get { return m_AGeoTmpAvg06; }
        }

        //................................

        public Int32 AGeoTmpAvg07
        {
            set
            {
                m_AGeoTmpAvg07 = value;
            }
            get { return m_AGeoTmpAvg07; }
        }

        //................................

        public Int32 AGeoTmpAvg08
        {
            set
            {
                m_AGeoTmpAvg08 = value;
            }
            get { return m_AGeoTmpAvg08; }
        }

        //................................

        public Int32 AGeoTmpAvg09
        {
            set
            {
                m_AGeoTmpAvg09 = value;
            }
            get { return m_AGeoTmpAvg09; }
        }

        //................................

        public Int32 AGeoTmpAvg10
        {
            set
            {
                m_AGeoTmpAvg10 = value;
            }
            get { return m_AGeoTmpAvg10; }
        }

        //................................

        public Int32 AGeoTmpAvg11
        {
            set
            {
                m_AGeoTmpAvg11 = value;
            }
            get { return m_AGeoTmpAvg11; }
        }

        //................................

        public Int32 AGeoTmpAvg12
        {
            set
            {
                m_AGeoTmpAvg12 = value;
            }
            get { return m_AGeoTmpAvg12; }
        }

        //................................

        public Int32 AGeoTmpMax01
        {
            set
            {
                m_AGeoTmpMax01 = value;
            }
            get { return m_AGeoTmpMax01; }
        }

        //................................

        public Int32 AGeoTmpMax02
        {
            set
            {
                m_AGeoTmpMax02 = value;
            }
            get { return m_AGeoTmpMax02; }
        }

        //................................

        public Int32 AGeoTmpMax03
        {
            set
            {
                m_AGeoTmpMax03 = value;
            }
            get { return m_AGeoTmpMax03; }
        }

        //................................

        public Int32 AGeoTmpMax04
        {
            set
            {
                m_AGeoTmpMax04 = value;
            }
            get { return m_AGeoTmpMax04; }
        }

        //................................

        public Int32 AGeoTmpMax05
        {
            set
            {
                m_AGeoTmpMax05 = value;
            }
            get { return m_AGeoTmpMax05; }
        }

        //................................

        public Int32 AGeoTmpMax06
        {
            set
            {
                m_AGeoTmpMax06 = value;
            }
            get { return m_AGeoTmpMax06; }
        }

        //................................

        public Int32 AGeoTmpMax07
        {
            set
            {
                m_AGeoTmpMax07 = value;
            }
            get { return m_AGeoTmpMax07; }
        }

        //................................

        public Int32 AGeoTmpMax08
        {
            set
            {
                m_AGeoTmpMax08 = value;
            }
            get { return m_AGeoTmpMax08; }
        }

        //................................

        public Int32 AGeoTmpMax09
        {
            set
            {
                m_AGeoTmpMax09 = value;
            }
            get { return m_AGeoTmpMax09; }
        }

        //................................

        public Int32 AGeoTmpMax10
        {
            set
            {
                m_AGeoTmpMax10 = value;
            }
            get { return m_AGeoTmpMax10; }
        }

        //................................

        public Int32 AGeoTmpMax11
        {
            set
            {
                m_AGeoTmpMax11 = value;
            }
            get { return m_AGeoTmpMax11; }
        }

        //................................

        public Int32 AGeoTmpMax12
        {
            set
            {
                m_AGeoTmpMax12 = value;
            }
            get { return m_AGeoTmpMax12; }
        }

        //................................

        public Int32 AGeoTmpMin01
        {
            set
            {
                m_AGeoTmpMin01 = value;
            }
            get { return m_AGeoTmpMin01; }
        }

        //................................

        public Int32 AGeoTmpMin02
        {
            set
            {
                m_AGeoTmpMin02 = value;
            }
            get { return m_AGeoTmpMin02; }
        }

        //................................

        public Int32 AGeoTmpMin03
        {
            set
            {
                m_AGeoTmpMin03 = value;
            }
            get { return m_AGeoTmpMin03; }
        }

        //................................

        public Int32 AGeoTmpMin04
        {
            set
            {
                m_AGeoTmpMin04 = value;
            }
            get { return m_AGeoTmpMin04; }
        }

        //................................

        public Int32 AGeoTmpMin05
        {
            set
            {
                m_AGeoTmpMin05 = value;
            }
            get { return m_AGeoTmpMin05; }
        }

        //................................

        public Int32 AGeoTmpMin06
        {
            set
            {
                m_AGeoTmpMin06 = value;
            }
            get { return m_AGeoTmpMin06; }
        }

        //................................

        public Int32 AGeoTmpMin07
        {
            set
            {
                m_AGeoTmpMin07 = value;
            }
            get { return m_AGeoTmpMin07; }
        }

        //................................

        public Int32 AGeoTmpMin08
        {
            set
            {
                m_AGeoTmpMin08 = value;
            }
            get { return m_AGeoTmpMin08; }
        }

        //................................

        public Int32 AGeoTmpMin09
        {
            set
            {
                m_AGeoTmpMin09 = value;
            }
            get { return m_AGeoTmpMin09; }
        }

        //................................

        public Int32 AGeoTmpMin10
        {
            set
            {
                m_AGeoTmpMin10 = value;
            }
            get { return m_AGeoTmpMin10; }
        }

        //................................

        public Int32 AGeoTmpMin11
        {
            set
            {
                m_AGeoTmpMin11 = value;
            }
            get { return m_AGeoTmpMin11; }
        }

        //................................

        public Int32 AGeoTmpMin12
        {
            set
            {
                m_AGeoTmpMin12 = value;
            }
            get { return m_AGeoTmpMin12; }
        }

        //................................

        public Int32 AGeoRainML01
        {
            set
            {
                m_AGeoRainML01 = value;
            }
            get { return m_AGeoRainML01; }
        }

        //................................

        public Int32 AGeoRainML02
        {
            set
            {
                m_AGeoRainML02 = value;
            }
            get { return m_AGeoRainML02; }
        }

        //................................

        public Int32 AGeoRainML03
        {
            set
            {
                m_AGeoRainML03 = value;
            }
            get { return m_AGeoRainML03; }
        }

        //................................

        public Int32 AGeoRainML04
        {
            set
            {
                m_AGeoRainML04 = value;
            }
            get { return m_AGeoRainML04; }
        }

        //................................

        public Int32 AGeoRainML05
        {
            set
            {
                m_AGeoRainML05 = value;
            }
            get { return m_AGeoRainML05; }
        }

        //................................

        public Int32 AGeoRainML06
        {
            set
            {
                m_AGeoRainML06 = value;
            }
            get { return m_AGeoRainML06; }
        }

        //................................

        public Int32 AGeoRainML07
        {
            set
            {
                m_AGeoRainML07 = value;
            }
            get { return m_AGeoRainML07; }
        }

        //................................

        public Int32 AGeoRainML08
        {
            set
            {
                m_AGeoRainML08 = value;
            }
            get { return m_AGeoRainML08; }
        }

        //................................

        public Int32 AGeoRainML09
        {
            set
            {
                m_AGeoRainML09 = value;
            }
            get { return m_AGeoRainML09; }
        }

        //................................

        public Int32 AGeoRainML10
        {
            set
            {
                m_AGeoRainML10 = value;
            }
            get { return m_AGeoRainML10; }
        }

        //................................

        public Int32 AGeoRainML11
        {
            set
            {
                m_AGeoRainML11 = value;
            }
            get { return m_AGeoRainML11; }
        }

        //................................

        public Int32 AGeoRainML12
        {
            set
            {
                m_AGeoRainML12 = value;
            }
            get { return m_AGeoRainML12; }
        }

        //................................

        public Int32 AGeoRainDays01
        {
            set
            {
                m_AGeoRainDays01 = value;
            }
            get { return m_AGeoRainDays01; }
        }

        //................................

        public Int32 AGeoRainDays02
        {
            set
            {
                m_AGeoRainDays02 = value;
            }
            get { return m_AGeoRainDays02; }
        }

        //................................

        public Int32 AGeoRainDays03
        {
            set
            {
                m_AGeoRainDays03 = value;
            }
            get { return m_AGeoRainDays03; }
        }

        //................................

        public Int32 AGeoRainDays04
        {
            set
            {
                m_AGeoRainDays04 = value;
            }
            get { return m_AGeoRainDays04; }
        }

        //................................

        public Int32 AGeoRainDays05
        {
            set
            {
                m_AGeoRainDays05 = value;
            }
            get { return m_AGeoRainDays05; }
        }

        //................................

        public Int32 AGeoRainDays06
        {
            set
            {
                m_AGeoRainDays06 = value;
            }
            get { return m_AGeoRainDays06; }
        }

        //................................

        public Int32 AGeoRainDays07
        {
            set
            {
                m_AGeoRainDays07 = value;
            }
            get { return m_AGeoRainDays07; }
        }

        //................................

        public Int32 AGeoRainDays08
        {
            set
            {
                m_AGeoRainDays08 = value;
            }
            get { return m_AGeoRainDays08; }
        }

        //................................

        public Int32 AGeoRainDays09
        {
            set
            {
                m_AGeoRainDays09 = value;
            }
            get { return m_AGeoRainDays09; }
        }

        //................................

        public Int32 AGeoRainDays10
        {
            set
            {
                m_AGeoRainDays10 = value;
            }
            get { return m_AGeoRainDays10; }
        }

        //................................

        public Int32 AGeoRainDays11
        {
            set
            {
                m_AGeoRainDays11 = value;
            }
            get { return m_AGeoRainDays11; }
        }

        //................................

        public Int32 AGeoRainDays12
        {
            set
            {
                m_AGeoRainDays12 = value;
            }
            get { return m_AGeoRainDays12; }
        }

        //................................

        public Double AGeoSunMax01
        {
            set
            {
                m_AGeoSunMax01 = value;
            }
            get { return m_AGeoSunMax01; }
        }

        //................................

        public Double AGeoSunMax02
        {
            set
            {
                m_AGeoSunMax02 = value;
            }
            get { return m_AGeoSunMax02; }
        }

        //................................

        public Double AGeoSunMax03
        {
            set
            {
                m_AGeoSunMax03 = value;
            }
            get { return m_AGeoSunMax03; }
        }

        //................................

        public Double AGeoSunMax04
        {
            set
            {
                m_AGeoSunMax04 = value;
            }
            get { return m_AGeoSunMax04; }
        }

        //................................

        public Double AGeoSunMax05
        {
            set
            {
                m_AGeoSunMax05 = value;
            }
            get { return m_AGeoSunMax05; }
        }

        //................................

        public Double AGeoSunMax06
        {
            set
            {
                m_AGeoSunMax06 = value;
            }
            get { return m_AGeoSunMax06; }
        }

        //................................

        public Double AGeoSunMax07
        {
            set
            {
                m_AGeoSunMax07 = value;
            }
            get { return m_AGeoSunMax07; }
        }

        //................................

        public Double AGeoSunMax08
        {
            set
            {
                m_AGeoSunMax08 = value;
            }
            get { return m_AGeoSunMax08; }
        }

        //................................

        public Double AGeoSunMax09
        {
            set
            {
                m_AGeoSunMax09 = value;
            }
            get { return m_AGeoSunMax09; }
        }

        //................................

        public Double AGeoSunMax10
        {
            set
            {
                m_AGeoSunMax10 = value;
            }
            get { return m_AGeoSunMax10; }
        }

        //................................

        public Double AGeoSunMax11
        {
            set
            {
                m_AGeoSunMax11 = value;
            }
            get { return m_AGeoSunMax11; }
        }

        //................................

        public Double AGeoSunMax12
        {
            set
            {
                m_AGeoSunMax12 = value;
            }
            get { return m_AGeoSunMax12; }
        }

        //................................

        public Double AGeoSunMin01
        {
            set
            {
                m_AGeoSunMin01 = value;
            }
            get { return m_AGeoSunMin01; }
        }

        //................................

        public Double AGeoSunMin02
        {
            set
            {
                m_AGeoSunMin02 = value;
            }
            get { return m_AGeoSunMin02; }
        }

        //................................

        public Double AGeoSunMin03
        {
            set
            {
                m_AGeoSunMin03 = value;
            }
            get { return m_AGeoSunMin03; }
        }

        //................................

        public Double AGeoSunMin04
        {
            set
            {
                m_AGeoSunMin04 = value;
            }
            get { return m_AGeoSunMin04; }
        }

        //................................

        public Double AGeoSunMin05
        {
            set
            {
                m_AGeoSunMin05 = value;
            }
            get { return m_AGeoSunMin05; }
        }

        //................................

        public Double AGeoSunMin06
        {
            set
            {
                m_AGeoSunMin06 = value;
            }
            get { return m_AGeoSunMin06; }
        }

        //................................

        public Double AGeoSunMin07
        {
            set
            {
                m_AGeoSunMin07 = value;
            }
            get { return m_AGeoSunMin07; }
        }

        //................................

        public Double AGeoSunMin08
        {
            set
            {
                m_AGeoSunMin08 = value;
            }
            get { return m_AGeoSunMin08; }
        }

        //................................

        public Double AGeoSunMin09
        {
            set
            {
                m_AGeoSunMin09 = value;
            }
            get { return m_AGeoSunMin09; }
        }

        //................................

        public Double AGeoSunMin10
        {
            set
            {
                m_AGeoSunMin10 = value;
            }
            get { return m_AGeoSunMin10; }
        }

        //................................

        public Double AGeoSunMin11
        {
            set
            {
                m_AGeoSunMin11 = value;
            }
            get { return m_AGeoSunMin11; }
        }

        //................................

        public Double AGeoSunMin12
        {
            set
            {
                m_AGeoSunMin12 = value;
            }
            get { return m_AGeoSunMin12; }
        }

        #endregion VALORES_GETSET



        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        #region MOREFUNCTIONS

        //-----------------------------------------
        public Double AGeoTmpMax_YearMax
        {
            get
            {
                return FncMax(m_AGeoTmpMax01, m_AGeoTmpMax02, m_AGeoTmpMax03, m_AGeoTmpMax04, m_AGeoTmpMax05, m_AGeoTmpMax06,
               m_AGeoTmpMax07, m_AGeoTmpMax08, m_AGeoTmpMax09, m_AGeoTmpMax10, m_AGeoTmpMax11, m_AGeoTmpMax12);

            }
        }
        public Double AGeoTmpMax_YearMin
        {
            get
            {
                return FncMin(m_AGeoTmpMax01, m_AGeoTmpMax02, m_AGeoTmpMax03, m_AGeoTmpMax04, m_AGeoTmpMax05, m_AGeoTmpMax06,
               m_AGeoTmpMax07, m_AGeoTmpMax08, m_AGeoTmpMax09, m_AGeoTmpMax10, m_AGeoTmpMax11, m_AGeoTmpMax12);

            }
        }
        public Double AGeoTmpMax_YearAvg
        {
            get
            {
                return FncAvg(m_AGeoTmpMax01, m_AGeoTmpMax02, m_AGeoTmpMax03, m_AGeoTmpMax04, m_AGeoTmpMax05, m_AGeoTmpMax06,
               m_AGeoTmpMax07, m_AGeoTmpMax08, m_AGeoTmpMax09, m_AGeoTmpMax10, m_AGeoTmpMax11, m_AGeoTmpMax12);

            }
        }

        public Double AGeoTmpMin_YearMax
        {
            get
            {
                return FncMax(m_AGeoTmpMin01, m_AGeoTmpMin02, m_AGeoTmpMin03, m_AGeoTmpMin04, m_AGeoTmpMin05, m_AGeoTmpMin06,
               m_AGeoTmpMin07, m_AGeoTmpMin08, m_AGeoTmpMin09, m_AGeoTmpMin10, m_AGeoTmpMin11, m_AGeoTmpMin12);

            }
        }
        public Double AGeoTmpMin_YearMin
        {
            get
            {
                return FncMin(m_AGeoTmpMin01, m_AGeoTmpMin02, m_AGeoTmpMin03, m_AGeoTmpMin04, m_AGeoTmpMin05, m_AGeoTmpMin06,
               m_AGeoTmpMin07, m_AGeoTmpMin08, m_AGeoTmpMin09, m_AGeoTmpMin10, m_AGeoTmpMin11, m_AGeoTmpMin12);

            }
        }
        public Double AGeoTmpMin_YearAvg
        {
            get
            {
                return FncAvg(m_AGeoTmpMin01, m_AGeoTmpMin02, m_AGeoTmpMin03, m_AGeoTmpMin04, m_AGeoTmpMin05, m_AGeoTmpMin06,
               m_AGeoTmpMin07, m_AGeoTmpMin08, m_AGeoTmpMin09, m_AGeoTmpMin10, m_AGeoTmpMin11, m_AGeoTmpMin12);

            }
        }

        public Double AGeoTmpAvg_YearMax
        {
            get {
                return FncMax(AGeoTmp_Avg01, AGeoTmp_Avg02, AGeoTmp_Avg03, AGeoTmp_Avg04, AGeoTmp_Avg05, AGeoTmp_Avg06,
               AGeoTmp_Avg07, AGeoTmp_Avg08, AGeoTmp_Avg09, AGeoTmp_Avg10, AGeoTmp_Avg11, AGeoTmp_Avg12);
            }
        }
        public Double AGeoTmpAvg_YearMin
        {
            get
            {
                return FncMin(AGeoTmp_Avg01, AGeoTmp_Avg02, AGeoTmp_Avg03, AGeoTmp_Avg04, AGeoTmp_Avg05, AGeoTmp_Avg06,
               AGeoTmp_Avg07, AGeoTmp_Avg08, AGeoTmp_Avg09, AGeoTmp_Avg10, AGeoTmp_Avg11, AGeoTmp_Avg12);
            }
        }
        public Double AGeoTmpAvg_YearAvg
        {
            get
            {
                return FncAvg(AGeoTmp_Avg01, AGeoTmp_Avg02, AGeoTmp_Avg03, AGeoTmp_Avg04, AGeoTmp_Avg05, AGeoTmp_Avg06,
               AGeoTmp_Avg07, AGeoTmp_Avg08, AGeoTmp_Avg09, AGeoTmp_Avg10, AGeoTmp_Avg11, AGeoTmp_Avg12);
            }
        }

        //-----------------------------------------------
        //m_AGeoRainML12
        public Double AGeoRainML_YearMax
        {
            get
            {
                return FncMax(m_AGeoRainML01, m_AGeoRainML02, m_AGeoRainML03, m_AGeoRainML04, m_AGeoRainML05, m_AGeoRainML06,
               m_AGeoRainML07, m_AGeoRainML08, m_AGeoRainML09, m_AGeoRainML10, m_AGeoRainML11, m_AGeoRainML12);

            }
        }
        public Double AGeoRainML_YearMin
        {
            get
            {
                return FncMin(m_AGeoRainML01, m_AGeoRainML02, m_AGeoRainML03, m_AGeoRainML04, m_AGeoRainML05, m_AGeoRainML06,
               m_AGeoRainML07, m_AGeoRainML08, m_AGeoRainML09, m_AGeoRainML10, m_AGeoRainML11, m_AGeoRainML12);

            }
        }
        public Double AGeoRainML_YearAvg
        {
            get
            {
                return FncAvg(m_AGeoRainML01, m_AGeoRainML02, m_AGeoRainML03, m_AGeoRainML04, m_AGeoRainML05, m_AGeoRainML06,
               m_AGeoRainML07, m_AGeoRainML08, m_AGeoRainML09, m_AGeoRainML10, m_AGeoRainML11, m_AGeoRainML12);

            }
        }
        public Double AGeoRainML_YearSum
        {
            get
            {
                return FncSum(m_AGeoRainML01, m_AGeoRainML02, m_AGeoRainML03, m_AGeoRainML04, m_AGeoRainML05, m_AGeoRainML06,
               m_AGeoRainML07, m_AGeoRainML08, m_AGeoRainML09, m_AGeoRainML10, m_AGeoRainML11, m_AGeoRainML12);

            }
        }
        //-----------------------------------   
        public Double AGeoRainDays_YearMax
        {
            get
            {
                return FncMax(m_AGeoRainDays01, m_AGeoRainDays02, m_AGeoRainDays03, m_AGeoRainDays04, m_AGeoRainDays05, m_AGeoRainDays06,
               m_AGeoRainDays07, m_AGeoRainDays08, m_AGeoRainDays09, m_AGeoRainDays10, m_AGeoRainDays11, m_AGeoRainDays12);

            }
        }
        public Double AGeoRainDays_YearMin
        {
            get
            {
                return FncMin(m_AGeoRainDays01, m_AGeoRainDays02, m_AGeoRainDays03, m_AGeoRainDays04, m_AGeoRainDays05, m_AGeoRainDays06,
               m_AGeoRainDays07, m_AGeoRainDays08, m_AGeoRainDays09, m_AGeoRainDays10, m_AGeoRainDays11, m_AGeoRainDays12);

            }
        }
        public Double AGeoRainDays_YearAvg
        {
            get
            {
                return FncAvg(m_AGeoRainDays01, m_AGeoRainDays02, m_AGeoRainDays03, m_AGeoRainDays04, m_AGeoRainDays05, m_AGeoRainDays06,
               m_AGeoRainDays07, m_AGeoRainDays08, m_AGeoRainDays09, m_AGeoRainDays10, m_AGeoRainDays11, m_AGeoRainDays12);

            }
        }
        public Double AGeoRainDays_YearSum
        {
            get
            {
                return FncSum(m_AGeoRainDays01, m_AGeoRainDays02, m_AGeoRainDays03, m_AGeoRainDays04, m_AGeoRainDays05, m_AGeoRainDays06,
               m_AGeoRainDays07, m_AGeoRainDays08, m_AGeoRainDays09, m_AGeoRainDays10, m_AGeoRainDays11, m_AGeoRainDays12);

            }
        }
        //-----------------------------------   
        //------------------------------
        public Double AGeoTmp_Avg01 { get { double d = 0; try { d = (m_AGeoTmpMin01 + m_AGeoTmpMax01) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg02 { get { double d = 0; try { d = (m_AGeoTmpMin02 + m_AGeoTmpMax02) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg03 { get { double d = 0; try { d = (m_AGeoTmpMin03 + m_AGeoTmpMax03) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg04 { get { double d = 0; try { d = (m_AGeoTmpMin04 + m_AGeoTmpMax04) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg05 { get { double d = 0; try { d = (m_AGeoTmpMin05 + m_AGeoTmpMax05) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg06 { get { double d = 0; try { d = (m_AGeoTmpMin06 + m_AGeoTmpMax06) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg07 { get { double d = 0; try { d = (m_AGeoTmpMin07 + m_AGeoTmpMax07) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg08 { get { double d = 0; try { d = (m_AGeoTmpMin08 + m_AGeoTmpMax08) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg09 { get { double d = 0; try { d = (m_AGeoTmpMin09 + m_AGeoTmpMax09) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg10 { get { double d = 0; try { d = (m_AGeoTmpMin10 + m_AGeoTmpMax10) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg11 { get { double d = 0; try { d = (m_AGeoTmpMin11 + m_AGeoTmpMax11) / 2; } catch { } return d; } }
        public Double AGeoTmp_Avg12 { get { double d = 0; try { d = (m_AGeoTmpMin12 + m_AGeoTmpMax12) / 2; } catch { } return d; } }

        //------------------------------
        public Double AGeoSun_Avg01 { get { double d = 0; try { d = (m_AGeoSunMin01 + m_AGeoSunMax01) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg02 { get { double d = 0; try { d = (m_AGeoSunMin02 + m_AGeoSunMax02) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg03 { get { double d = 0; try { d = (m_AGeoSunMin03 + m_AGeoSunMax03) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg04 { get { double d = 0; try { d = (m_AGeoSunMin04 + m_AGeoSunMax04) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg05 { get { double d = 0; try { d = (m_AGeoSunMin05 + m_AGeoSunMax05) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg06 { get { double d = 0; try { d = (m_AGeoSunMin06 + m_AGeoSunMax06) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg07 { get { double d = 0; try { d = (m_AGeoSunMin07 + m_AGeoSunMax07) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg08 { get { double d = 0; try { d = (m_AGeoSunMin08 + m_AGeoSunMax08) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg09 { get { double d = 0; try { d = (m_AGeoSunMin09 + m_AGeoSunMax09) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg10 { get { double d = 0; try { d = (m_AGeoSunMin10 + m_AGeoSunMax10) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg11 { get { double d = 0; try { d = (m_AGeoSunMin11 + m_AGeoSunMax11) / 2; } catch { } return d; } }
        public Double AGeoSun_Avg12 { get { double d = 0; try { d = (m_AGeoSunMin12 + m_AGeoSunMax12) / 2; } catch { } return d; } }

        //------------------------------
        public double AGeoSunMax_YearMax
        {
            get
            {
                return FncMax(AGeoSunMax01, AGeoSunMax02, AGeoSunMax03, AGeoSunMax04, AGeoSunMax05, AGeoSunMax06,
               AGeoSunMax07, AGeoSunMax08, AGeoSunMax09, AGeoSunMax10, AGeoSunMax11, AGeoSunMax12);

            }
        }
        public double AGeoSunMax_YearMin
        {
            get
            {
                return FncMin(AGeoSunMax01, AGeoSunMax02, AGeoSunMax03, AGeoSunMax04, AGeoSunMax05, AGeoSunMax06,
               AGeoSunMax07, AGeoSunMax08, AGeoSunMax09, AGeoSunMax10, AGeoSunMax11, AGeoSunMax12);

            }
        }
        public double AGeoSunMax_YearSum
        {
            get
            {
                return FncSum(AGeoSunMax01, AGeoSunMax02, AGeoSunMax03, AGeoSunMax04, AGeoSunMax05, AGeoSunMax06,
               AGeoSunMax07, AGeoSunMax08, AGeoSunMax09, AGeoSunMax10, AGeoSunMax11, AGeoSunMax12);

            }
        }
        public double AGeoSunMax_YearAvg
        {
            get
            {
                return FncAvg(AGeoSunMax01, AGeoSunMax02, AGeoSunMax03, AGeoSunMax04, AGeoSunMax05, AGeoSunMax06,
               AGeoSunMax07, AGeoSunMax08, AGeoSunMax09, AGeoSunMax10, AGeoSunMax11, AGeoSunMax12);

            }
        }
           
        public double AGeoSunMin_YearMax
        {
            get
            {
                return FncMax(AGeoSunMin01, AGeoSunMin02, AGeoSunMin03, AGeoSunMin04, AGeoSunMin05, AGeoSunMin06,
               AGeoSunMin07, AGeoSunMin08, AGeoSunMin09, AGeoSunMin10, AGeoSunMin11, AGeoSunMin12);

            }
        }
        public double AGeoSunMin_YearMin
        {
            get
            {
                return FncMin(AGeoSunMin01, AGeoSunMin02, AGeoSunMin03, AGeoSunMin04, AGeoSunMin05, AGeoSunMin06,
               AGeoSunMin07, AGeoSunMin08, AGeoSunMin09, AGeoSunMin10, AGeoSunMin11, AGeoSunMin12);

            }
        }
        public double AGeoSunMin_YearSum
        {
            get
            {
                return FncMin(AGeoSunMin01, AGeoSunMin02, AGeoSunMin03, AGeoSunMin04, AGeoSunMin05, AGeoSunMin06,
               AGeoSunMin07, AGeoSunMin08, AGeoSunMin09, AGeoSunMin10, AGeoSunMin11, AGeoSunMin12);

            }
        }
        public double AGeoSunMin_YearAvg
        {
            get
            {
                return FncAvg(AGeoSunMin01, AGeoSunMin02, AGeoSunMin03, AGeoSunMin04, AGeoSunMin05, AGeoSunMin06,
               AGeoSunMin07, AGeoSunMin08, AGeoSunMin09, AGeoSunMin10, AGeoSunMin11, AGeoSunMin12);

            }
        }


      
        public double AGeoSunAvg_YearMax
        {
            get
            {
                return FncMax(AGeoSun_Avg01, AGeoSun_Avg02, AGeoSun_Avg03, AGeoSun_Avg04, AGeoSun_Avg05, AGeoSun_Avg06,
               AGeoSun_Avg07, AGeoSun_Avg08, AGeoSun_Avg09, AGeoSun_Avg10, AGeoSun_Avg11, AGeoSun_Avg12);

            }
        }
        public double AGeoSunAvg_YearMin
        {
            get
            {
                return FncMin(AGeoSun_Avg01, AGeoSun_Avg02, AGeoSun_Avg03, AGeoSun_Avg04, AGeoSun_Avg05, AGeoSun_Avg06,
               AGeoSun_Avg07, AGeoSun_Avg08, AGeoSun_Avg09, AGeoSun_Avg10, AGeoSun_Avg11, AGeoSun_Avg12);

            }
        }
        public double AGeoSunAvg_YearSum
        {
            get
            {
                return FncAvg(AGeoSun_Avg01, AGeoSun_Avg02, AGeoSun_Avg03, AGeoSun_Avg04, AGeoSun_Avg05, AGeoSun_Avg06,
               AGeoSun_Avg07, AGeoSun_Avg08, AGeoSun_Avg09, AGeoSun_Avg10, AGeoSun_Avg11, AGeoSun_Avg12);

            }
        }
        public double AGeoSunAvg_YearAvg
        {
            get
            {
                return FncAvg(AGeoSun_Avg01, AGeoSun_Avg02, AGeoSun_Avg03, AGeoSun_Avg04, AGeoSun_Avg05, AGeoSun_Avg06,
               AGeoSun_Avg07, AGeoSun_Avg08, AGeoSun_Avg09, AGeoSun_Avg10, AGeoSun_Avg11, AGeoSun_Avg12);

            }
        }
        //-----------------------------------

        private Double FncMin(Double m1, Double m2, Double m3, Double m4, Double m5, Double m6, Double m7, Double m8, Double m9, Double m10, Double m11, Double m12)
        {
            Double iMin = m1;
            if (iMin > m2) iMin = m2;
            if (iMin > m3) iMin = m3;
            if (iMin > m4) iMin = m4;
            if (iMin > m5) iMin = m5;
            if (iMin > m6) iMin = m6;
            if (iMin > m7) iMin = m7;
            if (iMin > m8) iMin = m8;
            if (iMin > m9) iMin = m9;
            if (iMin > m10) iMin = m10;
            if (iMin > m11) iMin = m11;
            if (iMin > m12) iMin = m12;
            iMin = Math.Round(iMin, 2);
            return iMin;

        }
        private Double FncMax(Double m1, Double m2, Double m3, Double m4, Double m5, Double m6, Double m7, Double m8, Double m9, Double m10, Double m11, Double m12)
        {
            Double iMax = m1;
            if (iMax < m2) iMax = m2;
            if (iMax < m3) iMax = m3;
            if (iMax < m4) iMax = m4;
            if (iMax < m5) iMax = m5;
            if (iMax < m6) iMax = m6;
            if (iMax < m7) iMax = m7;
            if (iMax < m8) iMax = m8;
            if (iMax < m9) iMax = m9;
            if (iMax < m10) iMax = m10;
            if (iMax < m11) iMax = m11;
            if (iMax < m12) iMax = m12;
            iMax = Math.Round(iMax, 2);
            return iMax;

        }
        private Double FncAvg(Double m1, Double m2, Double m3, Double m4, Double m5, Double m6, Double m7, Double m8, Double m9, Double m10, Double m11, Double m12)
        {
            Double D = (m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + m11 + m12) / 12;
            Double iAvg = Math.Round(D, 2);
            return iAvg;

        }
        private Double FncSum(Double m1, Double m2, Double m3, Double m4, Double m5, Double m6, Double m7, Double m8, Double m9, Double m10, Double m11, Double m12)
        {
            double dSum = m1 + m2 + m3 + m4 + m5 + m6 + m7 + m8 + m9 + m10 + m11 + m12;
            return Math.Round(dSum, 2);

        }

        #endregion MOREFUNCTIONS

    }
}