using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de ClsRegTdoclng_testudines_desc
    //<//summary>
    public class ClsReg_tdoclng_testudines_desc
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
        private String m_DocLngId = "";
        private string m_LDesAbstract = "";
        private string m_LDesGeneralSize = "";
        private string m_LDesViewDorsalShape = "";
        private string m_LDesViewDorsalShields = "";
        private string m_LDesViewDorsalColor = "";
        private string m_LDesViewVentralBridgeShape = "";
        private string m_LDesViewVentralBridgeShields = "";
        private string m_LDesViewVentralBridgeColor = "";
        private string m_LDesViewLateral = "";
        private string m_LDesViewFrontal = "";
        private string m_LDesViewRear = "";
        private string m_LDesViewHeadNeckShape = "";
        private string m_LDesViewHeadNeckColor = "";
        private string m_LDesViewLegsTailShape = "";
        private string m_LDesViewLegsTailColor = "";
        private string m_LDesInternal = "";
        private string m_LDesDimorphism = "";
        private string m_LDesBabysShape = "";
        private string m_LDesBabysColor = "";
        private string m_LDesDiferentiation = "";
        private string m_LDesKeys = "";
        private string m_LDesHolotype = "";
        private string m_LDesNotes = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsReg_tdoclng_testudines_desc()
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
            m_DocLngId = "";
            m_LDesAbstract = "";
            m_LDesGeneralSize = "";
            m_LDesViewDorsalShape = "";
            m_LDesViewDorsalShields = "";
            m_LDesViewDorsalColor = "";
            m_LDesViewVentralBridgeShape = "";
            m_LDesViewVentralBridgeShields = "";
            m_LDesViewVentralBridgeColor = "";
            m_LDesViewLateral = "";
            m_LDesViewFrontal = "";
            m_LDesViewRear = "";
            m_LDesViewHeadNeckShape = "";
            m_LDesViewHeadNeckColor = "";
            m_LDesViewLegsTailShape = "";
            m_LDesViewLegsTailColor = "";
            m_LDesInternal = "";
            m_LDesDimorphism = "";
            m_LDesBabysShape = "";
            m_LDesBabysColor = "";
            m_LDesDiferentiation = "";
            m_LDesKeys = "";
            m_LDesHolotype = "";
            m_LDesNotes = "";
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
            szSql = "SELECT * FROM tdoclng_testudines_desc  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelect.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------// Configurar comando Insert recuperando la identidad. // CAMBIAR LINEA SqlCmdInsert.ExecuteNonQuery(). // Por: my_variable Id=Convert.ToInt(SqlCmdInsert.ExecuteNonQuery()); // ; SELECT @@IDENTITY	//-----------------------------------------------------//-----------------------------------------------------
            szSql = "INSERT INTO tdoclng_testudines_desc";
            szSql += "(";
            szSql += " DocId ";
            szSql += ", DocLngId ";
            szSql += ", LDesAbstract ";
            szSql += ", LDesGeneralSize ";
            szSql += ", LDesViewDorsalShape ";
            szSql += ", LDesViewDorsalShields ";
            szSql += ", LDesViewDorsalColor ";
            szSql += ", LDesViewVentralBridgeShape ";
            szSql += ", LDesViewVentralBridgeShields ";
            szSql += ", LDesViewVentralBridgeColor ";
            szSql += ", LDesViewLateral ";
            szSql += ", LDesViewFrontal ";
            szSql += ", LDesViewRear ";
            szSql += ", LDesViewHeadNeckShape ";
            szSql += ", LDesViewHeadNeckColor ";
            szSql += ", LDesViewLegsTailShape ";
            szSql += ", LDesViewLegsTailColor ";
            szSql += ", LDesInternal ";
            szSql += ", LDesDimorphism ";
            szSql += ", LDesBabysShape ";
            szSql += ", LDesBabysColor ";
            szSql += ", LDesDiferentiation ";
            szSql += ", LDesKeys ";
            szSql += ", LDesHolotype ";
            szSql += ", LDesNotes ";
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
            szSql += ", @DocLngId ";
            szSql += ", @LDesAbstract ";
            szSql += ", @LDesGeneralSize ";
            szSql += ", @LDesViewDorsalShape ";
            szSql += ", @LDesViewDorsalShields ";
            szSql += ", @LDesViewDorsalColor ";
            szSql += ", @LDesViewVentralBridgeShape ";
            szSql += ", @LDesViewVentralBridgeShields ";
            szSql += ", @LDesViewVentralBridgeColor ";
            szSql += ", @LDesViewLateral ";
            szSql += ", @LDesViewFrontal ";
            szSql += ", @LDesViewRear ";
            szSql += ", @LDesViewHeadNeckShape ";
            szSql += ", @LDesViewHeadNeckColor ";
            szSql += ", @LDesViewLegsTailShape ";
            szSql += ", @LDesViewLegsTailColor ";
            szSql += ", @LDesInternal ";
            szSql += ", @LDesDimorphism ";
            szSql += ", @LDesBabysShape ";
            szSql += ", @LDesBabysColor ";
            szSql += ", @LDesDiferentiation ";
            szSql += ", @LDesKeys ";
            szSql += ", @LDesHolotype ";
            szSql += ", @LDesNotes ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdInsert.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@LDesAbstract", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesGeneralSize", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewDorsalShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewDorsalShields", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewDorsalColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewVentralBridgeShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewVentralBridgeShields", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewVentralBridgeColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewLateral", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewFrontal", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewRear", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewHeadNeckShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewHeadNeckColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewLegsTailShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesViewLegsTailColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesInternal", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesDimorphism", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesBabysShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesBabysColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesDiferentiation", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesKeys", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesHolotype", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdInsert.Parameters.Add("@LDesNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoclng_testudines_desc SET ";

            szSql += "LDesAbstract=@LDesAbstract ";
            szSql += ", LDesGeneralSize=@LDesGeneralSize ";
            szSql += ", LDesViewDorsalShape=@LDesViewDorsalShape ";
            szSql += ", LDesViewDorsalShields=@LDesViewDorsalShields ";
            szSql += ", LDesViewDorsalColor=@LDesViewDorsalColor ";
            szSql += ", LDesViewVentralBridgeShape=@LDesViewVentralBridgeShape ";
            szSql += ", LDesViewVentralBridgeShields=@LDesViewVentralBridgeShields ";
            szSql += ", LDesViewVentralBridgeColor=@LDesViewVentralBridgeColor ";
            szSql += ", LDesViewLateral=@LDesViewLateral ";
            szSql += ", LDesViewFrontal=@LDesViewFrontal ";
            szSql += ", LDesViewRear=@LDesViewRear ";
            szSql += ", LDesViewHeadNeckShape=@LDesViewHeadNeckShape ";
            szSql += ", LDesViewHeadNeckColor=@LDesViewHeadNeckColor ";
            szSql += ", LDesViewLegsTailShape=@LDesViewLegsTailShape ";
            szSql += ", LDesViewLegsTailColor=@LDesViewLegsTailColor ";
            szSql += ", LDesInternal=@LDesInternal ";
            szSql += ", LDesDimorphism=@LDesDimorphism ";
            szSql += ", LDesBabysShape=@LDesBabysShape ";
            szSql += ", LDesBabysColor=@LDesBabysColor ";
            szSql += ", LDesDiferentiation=@LDesDiferentiation ";
            szSql += ", LDesKeys=@LDesKeys ";
            szSql += ", LDesHolotype=@LDesHolotype ";
            szSql += ", LDesNotes=@LDesNotes ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdUpdate.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@LDesAbstract", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesGeneralSize", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewDorsalShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewDorsalShields", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewDorsalColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewVentralBridgeShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewVentralBridgeShields", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewVentralBridgeColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewLateral", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewFrontal", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewRear", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewHeadNeckShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewHeadNeckColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewLegsTailShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesViewLegsTailColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesInternal", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesDimorphism", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesBabysShape", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesBabysColor", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesDiferentiation", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesKeys", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesHolotype", MySql.Data.MySqlClient.MySqlDbType.Text);
            oSqlCmdUpdate.Parameters.Add("@LDesNotes", MySql.Data.MySqlClient.MySqlDbType.Text);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoclng_testudines_desc  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdDelete.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " DocId";

            szSql += ", DocLngId";
            szSql += " FROM tdoclng_testudines_desc  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            szSql += " AND (DocLngId=@DocLngId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
            oSqlCmdSelectExist.Parameters.Add("@DocLngId", MySql.Data.MySqlClient.MySqlDbType.VarChar);
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
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId;

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
            oSqlCmdUpdate.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdUpdate.Parameters["@LDesAbstract"].Value = m_LDesAbstract;
            oSqlCmdUpdate.Parameters["@LDesGeneralSize"].Value = m_LDesGeneralSize;
            oSqlCmdUpdate.Parameters["@LDesViewDorsalShape"].Value = m_LDesViewDorsalShape;
            oSqlCmdUpdate.Parameters["@LDesViewDorsalShields"].Value = m_LDesViewDorsalShields;
            oSqlCmdUpdate.Parameters["@LDesViewDorsalColor"].Value = m_LDesViewDorsalColor;
            oSqlCmdUpdate.Parameters["@LDesViewVentralBridgeShape"].Value = m_LDesViewVentralBridgeShape;
            oSqlCmdUpdate.Parameters["@LDesViewVentralBridgeShields"].Value = m_LDesViewVentralBridgeShields;
            oSqlCmdUpdate.Parameters["@LDesViewVentralBridgeColor"].Value = m_LDesViewVentralBridgeColor;
            oSqlCmdUpdate.Parameters["@LDesViewLateral"].Value = m_LDesViewLateral;
            oSqlCmdUpdate.Parameters["@LDesViewFrontal"].Value = m_LDesViewFrontal;
            oSqlCmdUpdate.Parameters["@LDesViewRear"].Value = m_LDesViewRear;
            oSqlCmdUpdate.Parameters["@LDesViewHeadNeckShape"].Value = m_LDesViewHeadNeckShape;
            oSqlCmdUpdate.Parameters["@LDesViewHeadNeckColor"].Value = m_LDesViewHeadNeckColor;
            oSqlCmdUpdate.Parameters["@LDesViewLegsTailShape"].Value = m_LDesViewLegsTailShape;
            oSqlCmdUpdate.Parameters["@LDesViewLegsTailColor"].Value = m_LDesViewLegsTailColor;
            oSqlCmdUpdate.Parameters["@LDesInternal"].Value = m_LDesInternal;
            oSqlCmdUpdate.Parameters["@LDesDimorphism"].Value = m_LDesDimorphism;
            oSqlCmdUpdate.Parameters["@LDesBabysShape"].Value = m_LDesBabysShape;
            oSqlCmdUpdate.Parameters["@LDesBabysColor"].Value = m_LDesBabysColor;
            oSqlCmdUpdate.Parameters["@LDesDiferentiation"].Value = m_LDesDiferentiation;
            oSqlCmdUpdate.Parameters["@LDesKeys"].Value = m_LDesKeys;
            oSqlCmdUpdate.Parameters["@LDesHolotype"].Value = m_LDesHolotype;
            oSqlCmdUpdate.Parameters["@LDesNotes"].Value = m_LDesNotes;
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
            oSqlCmdInsert.Parameters["@DocLngId"].Value = m_DocLngId;
            oSqlCmdInsert.Parameters["@LDesAbstract"].Value = m_LDesAbstract;
            oSqlCmdInsert.Parameters["@LDesGeneralSize"].Value = m_LDesGeneralSize;
            oSqlCmdInsert.Parameters["@LDesViewDorsalShape"].Value = m_LDesViewDorsalShape;
            oSqlCmdInsert.Parameters["@LDesViewDorsalShields"].Value = m_LDesViewDorsalShields;
            oSqlCmdInsert.Parameters["@LDesViewDorsalColor"].Value = m_LDesViewDorsalColor;
            oSqlCmdInsert.Parameters["@LDesViewVentralBridgeShape"].Value = m_LDesViewVentralBridgeShape;
            oSqlCmdInsert.Parameters["@LDesViewVentralBridgeShields"].Value = m_LDesViewVentralBridgeShields;
            oSqlCmdInsert.Parameters["@LDesViewVentralBridgeColor"].Value = m_LDesViewVentralBridgeColor;
            oSqlCmdInsert.Parameters["@LDesViewLateral"].Value = m_LDesViewLateral;
            oSqlCmdInsert.Parameters["@LDesViewFrontal"].Value = m_LDesViewFrontal;
            oSqlCmdInsert.Parameters["@LDesViewRear"].Value = m_LDesViewRear;
            oSqlCmdInsert.Parameters["@LDesViewHeadNeckShape"].Value = m_LDesViewHeadNeckShape;
            oSqlCmdInsert.Parameters["@LDesViewHeadNeckColor"].Value = m_LDesViewHeadNeckColor;
            oSqlCmdInsert.Parameters["@LDesViewLegsTailShape"].Value = m_LDesViewLegsTailShape;
            oSqlCmdInsert.Parameters["@LDesViewLegsTailColor"].Value = m_LDesViewLegsTailColor;
            oSqlCmdInsert.Parameters["@LDesInternal"].Value = m_LDesInternal;
            oSqlCmdInsert.Parameters["@LDesDimorphism"].Value = m_LDesDimorphism;
            oSqlCmdInsert.Parameters["@LDesBabysShape"].Value = m_LDesBabysShape;
            oSqlCmdInsert.Parameters["@LDesBabysColor"].Value = m_LDesBabysColor;
            oSqlCmdInsert.Parameters["@LDesDiferentiation"].Value = m_LDesDiferentiation;
            oSqlCmdInsert.Parameters["@LDesKeys"].Value = m_LDesKeys;
            oSqlCmdInsert.Parameters["@LDesHolotype"].Value = m_LDesHolotype;
            oSqlCmdInsert.Parameters["@LDesNotes"].Value = m_LDesNotes;
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
        public bool FncSqlFind(UInt64 DocId, String DocLngId)
        {
            _mErrorBoolean = false;
            _mErrorString = "";
            if (!ClsMysql.FncOpen("")) { return false; }
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelect.Parameters["@DocId"].Value = DocId;
            oSqlCmdSelect.Parameters["@DocLngId"].Value = DocLngId;
            //----------------------------------------------------
            MySqlDataReader oDR=null; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelect.Connection = ClsMysql.MySqlConnection;
                if (!ClsMysql.FncOpen("")) { return false; }
                oDR = oSqlCmdSelect.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString());
                    m_DocLngId = oDR["DocLngId"].ToString();
                    m_LDesAbstract = oDR["LDesAbstract"].ToString();
                    m_LDesGeneralSize = oDR["LDesGeneralSize"].ToString();
                    m_LDesViewDorsalShape = oDR["LDesViewDorsalShape"].ToString();
                    m_LDesViewDorsalShields = oDR["LDesViewDorsalShields"].ToString();
                    m_LDesViewDorsalColor = oDR["LDesViewDorsalColor"].ToString();
                    m_LDesViewVentralBridgeShape = oDR["LDesViewVentralBridgeShape"].ToString();
                    m_LDesViewVentralBridgeShields = oDR["LDesViewVentralBridgeShields"].ToString();
                    m_LDesViewVentralBridgeColor = oDR["LDesViewVentralBridgeColor"].ToString();
                    m_LDesViewLateral = oDR["LDesViewLateral"].ToString();
                    m_LDesViewFrontal = oDR["LDesViewFrontal"].ToString();
                    m_LDesViewRear = oDR["LDesViewRear"].ToString();
                    m_LDesViewHeadNeckShape = oDR["LDesViewHeadNeckShape"].ToString();
                    m_LDesViewHeadNeckColor = oDR["LDesViewHeadNeckColor"].ToString();
                    m_LDesViewLegsTailShape = oDR["LDesViewLegsTailShape"].ToString();
                    m_LDesViewLegsTailColor = oDR["LDesViewLegsTailColor"].ToString();
                    m_LDesInternal = oDR["LDesInternal"].ToString();
                    m_LDesDimorphism = oDR["LDesDimorphism"].ToString();
                    m_LDesBabysShape = oDR["LDesBabysShape"].ToString();
                    m_LDesBabysColor = oDR["LDesBabysColor"].ToString();
                    m_LDesDiferentiation = oDR["LDesDiferentiation"].ToString();
                    m_LDesKeys = oDR["LDesKeys"].ToString();
                    m_LDesHolotype = oDR["LDesHolotype"].ToString();
                    m_LDesNotes = oDR["LDesNotes"].ToString();
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
        public bool FncSqlDelete(UInt64 DocId, String DocLngId)
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
                oSqlCmdDelete.Parameters["@DocLngId"].Value = DocLngId;
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

        public String DocLngId
        {
            set
            {
                m_DocLngId = value;
            }
            get { return m_DocLngId; }
        }

        //................................

        public string LDesAbstract
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesAbstract because it is too long,MaxLength=65535";
                }
                m_LDesAbstract = sz;
            }
            get { return m_LDesAbstract; }
        }

        //................................

        public string LDesGeneralSize
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesGeneralSize because it is too long,MaxLength=65535";
                }
                m_LDesGeneralSize = sz;
            }
            get { return m_LDesGeneralSize; }
        }

        //................................

        public string LDesViewDorsalShape
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewDorsalShape because it is too long,MaxLength=65535";
                }
                m_LDesViewDorsalShape = sz;
            }
            get { return m_LDesViewDorsalShape; }
        }

        //................................

        public string LDesViewDorsalShields
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewDorsalShields because it is too long,MaxLength=65535";
                }
                m_LDesViewDorsalShields = sz;
            }
            get { return m_LDesViewDorsalShields; }
        }

        //................................

        public string LDesViewDorsalColor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewDorsalColor because it is too long,MaxLength=65535";
                }
                m_LDesViewDorsalColor = sz;
            }
            get { return m_LDesViewDorsalColor; }
        }

        //................................

        public string LDesViewVentralBridgeShape
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewVentralBridgeShape because it is too long,MaxLength=65535";
                }
                m_LDesViewVentralBridgeShape = sz;
            }
            get { return m_LDesViewVentralBridgeShape; }
        }

        //................................

        public string LDesViewVentralBridgeShields
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewVentralBridgeShields because it is too long,MaxLength=65535";
                }
                m_LDesViewVentralBridgeShields = sz;
            }
            get { return m_LDesViewVentralBridgeShields; }
        }

        //................................

        public string LDesViewVentralBridgeColor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewVentralBridgeColor because it is too long,MaxLength=65535";
                }
                m_LDesViewVentralBridgeColor = sz;
            }
            get { return m_LDesViewVentralBridgeColor; }
        }

        //................................

        public string LDesViewLateral
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewLateral because it is too long,MaxLength=65535";
                }
                m_LDesViewLateral = sz;
            }
            get { return m_LDesViewLateral; }
        }

        //................................

        public string LDesViewFrontal
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewFrontal because it is too long,MaxLength=65535";
                }
                m_LDesViewFrontal = sz;
            }
            get { return m_LDesViewFrontal; }
        }

        //................................

        public string LDesViewRear
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewRear because it is too long,MaxLength=65535";
                }
                m_LDesViewRear = sz;
            }
            get { return m_LDesViewRear; }
        }

        //................................

        public string LDesViewHeadNeckShape
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewHeadNeckShape because it is too long,MaxLength=65535";
                }
                m_LDesViewHeadNeckShape = sz;
            }
            get { return m_LDesViewHeadNeckShape; }
        }

        //................................

        public string LDesViewHeadNeckColor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewHeadNeckColor because it is too long,MaxLength=65535";
                }
                m_LDesViewHeadNeckColor = sz;
            }
            get { return m_LDesViewHeadNeckColor; }
        }

        //................................

        public string LDesViewLegsTailShape
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewLegsTailShape because it is too long,MaxLength=65535";
                }
                m_LDesViewLegsTailShape = sz;
            }
            get { return m_LDesViewLegsTailShape; }
        }

        //................................

        public string LDesViewLegsTailColor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesViewLegsTailColor because it is too long,MaxLength=65535";
                }
                m_LDesViewLegsTailColor = sz;
            }
            get { return m_LDesViewLegsTailColor; }
        }

        //................................

        public string LDesInternal
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesInternal because it is too long,MaxLength=65535";
                }
                m_LDesInternal = sz;
            }
            get { return m_LDesInternal; }
        }

        //................................

        public string LDesDimorphism
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesDimorphism because it is too long,MaxLength=65535";
                }
                m_LDesDimorphism = sz;
            }
            get { return m_LDesDimorphism; }
        }

        //................................

        public string LDesBabysShape
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesBabysShape because it is too long,MaxLength=65535";
                }
                m_LDesBabysShape = sz;
            }
            get { return m_LDesBabysShape; }
        }

        //................................

        public string LDesBabysColor
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesBabysColor because it is too long,MaxLength=65535";
                }
                m_LDesBabysColor = sz;
            }
            get { return m_LDesBabysColor; }
        }

        //................................

        public string LDesDiferentiation
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesDiferentiation because it is too long,MaxLength=65535";
                }
                m_LDesDiferentiation = sz;
            }
            get { return m_LDesDiferentiation; }
        }

        //................................

        public string LDesKeys
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesKeys because it is too long,MaxLength=65535";
                }
                m_LDesKeys = sz;
            }
            get { return m_LDesKeys; }
        }

        //................................

        public string LDesHolotype
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesHolotype because it is too long,MaxLength=65535";
                }
                m_LDesHolotype = sz;
            }
            get { return m_LDesHolotype; }
        }

        //................................

        public string LDesNotes
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 65535)
                {
                    sz = sz.Substring(0, 65534);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LDesNotes because it is too long,MaxLength=65535";
                }
                m_LDesNotes = sz;
            }
            get { return m_LDesNotes; }
        }

        #endregion VALORES_GETSET

    }
}
