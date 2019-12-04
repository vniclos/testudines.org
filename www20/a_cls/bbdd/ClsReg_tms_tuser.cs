using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tmst_user
    {  
        public enum  eUserNameReserved {admin,administrator,administrador,vte, niclos,vniclos,guest,susana,marga,eniclos,sniclos,ferreras,mferreras }
       
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";
       
        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdActivate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private Int32 m_UserId = 0;
        private String m_IdLoginPwd = "";
        private String m_IdLoginMail = "";
        private String m_IdLoginName = "";
        private String m_NameFull = "";
        private String m_ShortDescription = "";
        private String m_Organitation = "";
        private String m_Avatar = "default.png";
        private bool m_CanMailFromUser = true;
        private bool m_IsAdmin = false;
        private bool m_IsEditor = false;
        private bool m_IsTranslator = false;
        private bool m_IsActive = false;
        private bool m_IsBlocked = false;
        
        private String m_Notes = "";
        private String m_Country = "";
        private String m_Language = "English";
        private String m_URL = "";
        private DateTime m_CreationDate = DateTime.Now;
        private String m_CreationFromIP = "";
        // ActivationGUID
        // ActivationFromIP
        // ActivationDate
        private String m_ActivationGUID = System.Guid.NewGuid().ToString();
        private String m_ActivationFromIP = "";
        private DateTime m_ActivationDate = DateTime.Now.AddYears(-2000);

        private DateTime m_DateUpdate = DateTime.Now;
        private DateTime m_DateLastLogin = DateTime.Now;
       
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tmst_user(string szSqlConnectionString)
        //{
        public ClsReg_tmst_user()
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
            m_UserId = 0;
            m_IdLoginPwd = "";
            m_IdLoginMail = "";
            m_IdLoginName = "";
            m_NameFull = "";
            m_ShortDescription = "";
            m_Organitation = "";
            m_Avatar = "default.png";
            m_CanMailFromUser = true;
            m_IsAdmin = false;
            m_IsEditor = false;
            m_IsTranslator = false;
            m_IsActive = false  ;
            m_IsBlocked = false;
            m_Notes = "";
            m_Country = "";
            m_Language = "English";
            m_URL = "";
            m_CreationDate = DateTime.Now;
            m_CreationFromIP = "";
            m_DateUpdate = DateTime.Now;
            m_DateLastLogin = DateTime.Now;
        // ActivationGUID
        // ActivationFromIP
        // ActivationDate
            m_ActivationGUID = System.Guid.NewGuid().ToString(); ;
          m_ActivationFromIP = "";
          m_ActivationDate = DateTime.Now.AddYears(-2000);
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
            szSql = "SELECT * FROM tmst_user  ";
            szSql += " WHERE ";
            szSql += "(UserId=@UserId )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@UserId", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tmst_user";

            szSql += "(";

            szSql += " UserId ";
            szSql += ", IdLoginPwd ";
            szSql += ", IdLoginMail ";
            szSql += ", IdLoginName ";
            szSql += ", NameFull ";
            szSql += ", ShortDescription ";
            szSql += ", Organitation ";
            szSql += ", Avatar ";
            szSql += ", CanMailFromUser ";
            szSql += ", IsAdmin ";
            szSql += ", IsEditor ";
            szSql += ", IsTranslator ";
            szSql += ", IsActive ";
            szSql += ", IsBlocked ";
            
            szSql += ", Notes ";
            szSql += ", Country ";
            szSql += ", Language ";
            szSql += ", URL ";
            szSql += ", CreationDate ";
            szSql += ", CreationFromIP ";
            
            szSql += ", ActivationGUID ";
            szSql += ", ActivationFromIP ";
            szSql += ", ActivationDate ";

        
            szSql += ", DateUpdate ";
            szSql += ", DateLastLogin ";
            szSql += " ) VALUES     (";
            szSql += " @UserId ";
            szSql += ", @IdLoginPwd ";
            szSql += ", @IdLoginMail ";
            szSql += ", @IdLoginName ";
            szSql += ", @NameFull ";
            szSql += ", @ShortDescription ";
            szSql += ", @Organitation ";
            szSql += ", @Avatar ";
            szSql += ", @CanMailFromUser ";
            szSql += ", @IsAdmin ";
            szSql += ", @IsEditor ";
            szSql += ", @IsTranslator ";
            szSql += ", @IsActive ";
            szSql += ", @IsBlocked ";
            
            szSql += ", @Notes ";
            szSql += ", @Country ";
            szSql += ", @Language ";
            szSql += ", @URL ";
            szSql += ", @CreationDate ";
            szSql += ", @CreationFromIP ";
             szSql += ",@ActivationGUID ";
            szSql += ", @ActivationFromIP ";
            szSql += ", @ActivationDate ";
            szSql += ", @DateUpdate ";
            szSql += ", @DateLastLogin ";
            szSql += ")";
            szSql += "; SELECT LAST_INSERT_ID();";
        
            // szSql+= " ; SELECT @@IDENTITY"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@UserId", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            oSqlCmdInsert.Parameters.Add("@IdLoginPwd", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@IdLoginMail", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@IdLoginName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@NameFull", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ShortDescription", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Organitation", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Avatar", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@CanMailFromUser", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsAdmin", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsEditor", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsTranslator", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsBlocked", MySql.Data.MySqlClient.MySqlDbType.Bit);
            
            oSqlCmdInsert.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Country", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Language", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@URL", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Date);
            oSqlCmdInsert.Parameters.Add("@CreationFromIP", MySql.Data.MySqlClient.MySqlDbType.String);
            
            oSqlCmdInsert.Parameters.Add("@ActivationGUID", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ActivationFromIP", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@ActivationDate", MySql.Data.MySqlClient.MySqlDbType.Date);
            
            
           
            
            oSqlCmdInsert.Parameters.Add("@DateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@DateLastLogin", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tmst_user SET ";

            szSql += "IdLoginPwd=@IdLoginPwd ";
            szSql += ", IdLoginMail=@IdLoginMail ";
            szSql += ", IdLoginName=@IdLoginName ";
            szSql += ", NameFull=@NameFull ";
            szSql += ", ShortDescription=@ShortDescription ";
            szSql += ", Organitation=@Organitation ";
            szSql += ", Avatar=@Avatar ";
            szSql += ", CanMailFromUser=@CanMailFromUser ";
            szSql += ", IsAdmin=@IsAdmin ";
            szSql += ", IsEditor=@IsEditor ";
            szSql += ", IsTranslator=@IsTranslator ";
            szSql += ", IsActive=@IsActive ";
            szSql += ", IsBlocked=@IsBlocked ";
            
            szSql += ", Notes=@Notes ";
            szSql += ", Country=@Country ";
            szSql += ", Language=@Language ";
            szSql += ", URL=@URL ";
            szSql += ", CreationDate=@CreationDate ";
            szSql += ", CreationFromIP=@CreationFromIP ";

            szSql += ", ActivationGUID=@ActivationGUID ";
            szSql += ", ActivationFromIP=@ActivationFromIP ";
            szSql += ", ActivationDate=@ActivationDate ";

             
         
            szSql += ", DateUpdate=@DateUpdate ";
            szSql += ", DateLastLogin=@DateLastLogin ";
            szSql += " WHERE ";
            szSql += "(UserId=@UserId )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@UserId", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            oSqlCmdUpdate.Parameters.Add("@IdLoginPwd", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@IdLoginMail", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@IdLoginName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@NameFull", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ShortDescription", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Organitation", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Avatar", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@CanMailFromUser", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsAdmin", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsEditor", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsTranslator", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsBlocked", MySql.Data.MySqlClient.MySqlDbType.Bit);
            
            oSqlCmdUpdate.Parameters.Add("@Notes", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Country", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Language", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@URL", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@CreationDate", MySql.Data.MySqlClient.MySqlDbType.Date);
            oSqlCmdUpdate.Parameters.Add("@CreationFromIP", MySql.Data.MySqlClient.MySqlDbType.String);
          
            oSqlCmdUpdate.Parameters.Add("@ActivationGUID", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ActivationFromIP", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@ActivationDate", MySql.Data.MySqlClient.MySqlDbType.Date);
        
            
            oSqlCmdUpdate.Parameters.Add("@DateUpdate", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@DateLastLogin", MySql.Data.MySqlClient.MySqlDbType.DateTime);
           
            //---------------------------------------------
            //---------------------------------------------
            //------------- ACTIVATE FROM GUID ------------
            szSql = "UPDATE tmst_user SET ";
            szSql += " IsActive=@IsActive ";
            szSql += ", ActivationFromIP=@ActivationFromIP ";
            szSql += ", ActivationDate=@ActivationDate ";
            szSql += " WHERE ";
            szSql += "(ActivationGUID=@ActivationGUID )";
            oSqlCmdActivate.CommandText = szSql;

            oSqlCmdActivate .Parameters.Add("@IsActive", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdActivate.Parameters.Add("@ActivationGUID", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdActivate.Parameters.Add("@ActivationFromIP", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdActivate.Parameters.Add("@ActivationDate", MySql.Data.MySqlClient.MySqlDbType.Date);
       
            
            
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tmst_user  ";
            szSql += " WHERE ";
            szSql += "(UserId=@UserId )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@UserId", MySql.Data.MySqlClient.MySqlDbType.UInt32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " UserId";
            szSql += " FROM tmst_user  ";

            szSql += " WHERE ";
            szSql += "(UserId=@UserId )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@UserId", MySql.Data.MySqlClient.MySqlDbType.UInt32);
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
            // TODO CAMBIAR m_idKey por la clave adecuada..................
            //   if (m_IdKEY != 0)
            //   {
            //       b = false;
            //   }
            //   else
            //   {
            //............................................................
            //............................................................

            // comprobar si existe el id a añadir

            oSqlCmdSelectExist.Parameters["@UserId"].Value = m_UserId;

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
                m_CreationFromIP  = System.Web.HttpContext.Current.Request.UserHostAddress;
                m_CreationDate  = DateTime.Now;  
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
            oSqlCmdUpdate.Parameters["@UserId"].Value = m_UserId;
            oSqlCmdUpdate.Parameters["@IdLoginPwd"].Value = m_IdLoginPwd;
            oSqlCmdUpdate.Parameters["@IdLoginMail"].Value = m_IdLoginMail;
            oSqlCmdUpdate.Parameters["@IdLoginName"].Value = m_IdLoginName;
            oSqlCmdUpdate.Parameters["@NameFull"].Value = m_NameFull;
            oSqlCmdUpdate.Parameters["@ShortDescription"].Value = m_ShortDescription;
            oSqlCmdUpdate.Parameters["@Organitation"].Value = m_Organitation;
            oSqlCmdUpdate.Parameters["@Avatar"].Value = m_Avatar;
            oSqlCmdUpdate.Parameters["@CanMailFromUser"].Value = m_CanMailFromUser;
            oSqlCmdUpdate.Parameters["@IsAdmin"].Value = m_IsAdmin;
            oSqlCmdUpdate.Parameters["@IsEditor"].Value = m_IsEditor;
            oSqlCmdUpdate.Parameters["@IsTranslator"].Value = m_IsTranslator;
            oSqlCmdUpdate.Parameters["@IsActive"].Value = m_IsActive;
            oSqlCmdUpdate.Parameters["@IsBlocked"].Value = m_IsBlocked;
            
            oSqlCmdUpdate.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdUpdate.Parameters["@Country"].Value = m_Country;
            oSqlCmdUpdate.Parameters["@Language"].Value = m_Language;
            oSqlCmdUpdate.Parameters["@URL"].Value = m_URL;
            oSqlCmdUpdate.Parameters["@CreationDate"].Value = m_CreationDate;
            oSqlCmdUpdate.Parameters["@CreationFromIP"].Value = m_CreationFromIP;

            oSqlCmdUpdate.Parameters["@ActivationGUID"].Value = m_ActivationGUID;
            oSqlCmdUpdate.Parameters["@ActivationFromIP"].Value = m_ActivationFromIP;
            oSqlCmdUpdate.Parameters["@ActivationDate"].Value = m_ActivationDate;


            oSqlCmdUpdate.Parameters["@DateUpdate"].Value = m_DateUpdate;
            oSqlCmdUpdate.Parameters["@DateLastLogin"].Value = m_DateLastLogin;
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
        // ACTIVATE FROM GUID
        //-------------------------------------------------------
        public bool FncSqlActivateFromGUID(string szGUID, string szFromIp)
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
        
            oSqlCmdActivate.Parameters["@IsActive"].Value = true;
            oSqlCmdActivate.Parameters["@ActivationFromIP"].Value = m_ActivationFromIP;
            oSqlCmdActivate.Parameters["@ActivationDate"].Value = m_ActivationDate;
            oSqlCmdActivate.Parameters["@ActivationGUID"].Value = m_ActivationGUID;
            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdActivate.Connection = ClsMysql.MySqlConnection;;
            try
            {
                int i = oSqlCmdActivate.ExecuteNonQuery();
                // recupear datos del usario
                string szSelect="Select UserId  from  tmst_user where ActivationGUID='"+szGUID+"'";
                MySqlCommand oCmd = new MySqlCommand(szSelect,  ClsMysql.MySqlConnection);
                Int32 idUser=Convert.ToInt32(oCmd.ExecuteScalar().ToString ());
                oCmd.Dispose();

              _mErrorBoolean=! FncSqlFind(idUser); 
            
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
            oSqlCmdInsert.Parameters["@UserId"].Value = m_UserId;
            oSqlCmdInsert.Parameters["@IdLoginPwd"].Value = m_IdLoginPwd;
            oSqlCmdInsert.Parameters["@IdLoginMail"].Value = m_IdLoginMail;
            oSqlCmdInsert.Parameters["@IdLoginName"].Value = m_IdLoginName;
            oSqlCmdInsert.Parameters["@NameFull"].Value = m_NameFull;
            oSqlCmdInsert.Parameters["@ShortDescription"].Value = m_ShortDescription;
            oSqlCmdInsert.Parameters["@Organitation"].Value = m_Organitation;
            oSqlCmdInsert.Parameters["@Avatar"].Value = m_Avatar;
            oSqlCmdInsert.Parameters["@CanMailFromUser"].Value = m_CanMailFromUser;
            oSqlCmdInsert.Parameters["@IsAdmin"].Value = m_IsAdmin;
            oSqlCmdInsert.Parameters["@IsEditor"].Value = m_IsEditor;
            oSqlCmdInsert.Parameters["@IsTranslator"].Value = m_IsTranslator;
            oSqlCmdInsert.Parameters["@IsActive"].Value = m_IsActive;
            oSqlCmdInsert.Parameters["@IsBlocked"].Value = m_IsBlocked;
            
            oSqlCmdInsert.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdInsert.Parameters["@Country"].Value = m_Country;
            oSqlCmdInsert.Parameters["@Language"].Value = m_Language;
            oSqlCmdInsert.Parameters["@URL"].Value = m_URL;
            oSqlCmdInsert.Parameters["@CreationDate"].Value = m_CreationDate;
            oSqlCmdInsert.Parameters["@CreationFromIP"].Value = m_CreationFromIP;

            oSqlCmdInsert.Parameters["@ActivationGUID"].Value = m_ActivationGUID;
            oSqlCmdInsert.Parameters["@ActivationFromIP"].Value = m_ActivationFromIP;
            oSqlCmdInsert.Parameters["@ActivationDate"].Value = m_ActivationDate;


            oSqlCmdInsert.Parameters["@DateUpdate"].Value = m_DateUpdate;
            oSqlCmdInsert.Parameters["@DateLastLogin"].Value = m_DateLastLogin;
            try
            {
                oSqlCmdInsert.Connection = ClsMysql.MySqlConnection;;
              m_UserId =Convert.ToInt32( oSqlCmdInsert.ExecuteScalar ().ToString() );
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
        public bool FncSqlFind(Int32 UserId)
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
            oSqlCmdSelect.Parameters["@UserId"].Value = UserId;
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
                    m_UserId = Convert.ToInt32(oDR["UserId"].ToString().Trim());
                    m_IdLoginPwd = oDR["IdLoginPwd"].ToString().Trim();
                    m_IdLoginMail = oDR["IdLoginMail"].ToString().Trim();
                    m_IdLoginName = oDR["IdLoginName"].ToString().Trim();
                    m_NameFull = oDR["NameFull"].ToString().Trim();
                    m_ShortDescription = oDR["ShortDescription"].ToString().Trim();
                    m_Organitation = oDR["Organitation"].ToString().Trim();
                    m_Avatar = oDR["Avatar"].ToString().Trim();
                    m_CanMailFromUser = Convert.ToBoolean(oDR["CanMailFromUser"].ToString().Trim());
                    m_IsAdmin = Convert.ToBoolean(oDR["IsAdmin"].ToString().Trim());
                    m_IsEditor = Convert.ToBoolean(oDR["IsEditor"].ToString().Trim());
                    m_IsTranslator = Convert.ToBoolean(oDR["IsTranslator"].ToString().Trim());
                    m_IsActive = Convert.ToBoolean(oDR["IsActive"].ToString().Trim());
                    m_IsBlocked = Convert.ToBoolean(oDR["IsBlocked"].ToString().Trim());

                    
                    m_Notes = oDR["Notes"].ToString().Trim();
                    m_Country = oDR["Country"].ToString().Trim();
                    m_Language = oDR["Language"].ToString().Trim();
                    m_URL = oDR["URL"].ToString().Trim();
                    m_CreationDate = Convert.ToDateTime(oDR["CreationDate"].ToString().Trim());
                    m_CreationFromIP = oDR["CreationFromIP"].ToString().Trim();
                   
                    m_ActivationGUID  = oDR["ActivationGUID"].ToString().Trim();
                    m_ActivationFromIP  = oDR["ActivationFromIP"].ToString().Trim();
                    m_ActivationDate  = Convert.ToDateTime(oDR["ActivationDate"].ToString().Trim());
                  

                    
                    
                    
                    m_DateUpdate = Convert.ToDateTime(oDR["DateUpdate"].ToString().Trim());
                    m_DateLastLogin = Convert.ToDateTime(oDR["DateLastLogin"].ToString().Trim());
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
        public bool FncSqlDelete(Int32 UserId)
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
                oSqlCmdDelete.Parameters["@UserId"].Value = UserId;
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

        ////--------------------------------------------------------r
        
        // add functions
        public bool FncFindIdEmailPwd(string szIdLoginMail, string szIdLoginPwd)
    {
            if (szIdLoginMail=="") return false ;
            if (szIdLoginPwd == "") return false;
        if (!ClsMysql.FncOpen("")) return false;
        bool bOK = false;
        string szSql = "select UserId from tmst_user where idLoginMail='" + szIdLoginMail + "' and IdLoginPwd='" + szIdLoginPwd + "'";
        MySqlCommand oCmd = new MySqlCommand(szSql, ClsMysql.MySqlConnection);
        MySqlDataReader oRd =oCmd.ExecuteReader ();
        if (oRd.HasRows && oRd.Read ())
        {
            bOK = FncSqlFind(Convert.ToInt32(oRd["UserId"].ToString())); 
        }
        oRd.Close();
        oRd.Dispose(); 
        oCmd.Dispose();
        ClsMysql.FncClose(); 
        return bOK; 
        }
        public bool FncLogin(string szIdLoginName, string szIdLoginPwd)
    {
        if (szIdLoginName == "") return false;
        if (szIdLoginPwd == "") return false;

        if (!ClsMysql.FncOpen("")) return false;
        bool bOK = false;
        Int32 UserId = 0;
        string szSql = "select UserId from tmst_user where IdLoginName='" + szIdLoginName + "' and IdLoginPwd='" + szIdLoginPwd + "'";
        MySqlCommand oCmd = new MySqlCommand(szSql, ClsMysql.MySqlConnection);
        MySqlDataReader oRd = oCmd.ExecuteReader();
        if (oRd.HasRows && oRd.Read())
        {
            bOK = true;
            UserId = Convert.ToInt32(oRd["UserId"].ToString());
           
        }
        oRd.Close();
        oRd.Dispose();
        oCmd.Dispose();
        ClsMysql.FncClose();
        if (bOK)
        {
            FncSqlFind(UserId);
            m_DateLastLogin = System.DateTime.Now;
            FncSqlSave(); 
            
        }
        return bOK; 
      
        }
        /// <summary>
        /// Return DocId of User for this mail
        /// </summary>
        /// <param name="szEmailAdress">Email address</param>
        /// <returns>
        /// return if Id=-1,  nobody use this mail
        /// return if  DocId>0  Return DocId with this mail address </returns>
        public Int32 FncExistIdEmail(string szEmailAdress)
        {
            if (!ClsMysql.FncOpen("")) return -1;
            Int32  UserId=-1 ;

            string szSql = "select UserId from tmst_user where idLoginMail='" + szEmailAdress + "'";
            MySqlCommand oCmd=new MySqlCommand(szSql, ClsMysql.MySqlConnection);
            try
            {
              UserId = Convert.ToInt32 (  oCmd.ExecuteScalar().ToString ());
              
            }
            catch
            {
                UserId = -1;
            }

            ClsMysql.FncClose();
            oCmd.Dispose();
            return UserId;
        }
        /// <summary>
        /// Look for use IfName
        /// </summary>
        /// <param name="szUserName"></param>
        /// <returns>return -1 if not exist, or DocId if exist</returns>
        public Int32 FncExistUserIdName(string szUserName)
        {
            // reservedNames
            //----------------------------------
          
           // eUserNameReserved
        
            foreach (string val in Enum.GetNames(typeof(eUserNameReserved)))
	    {
            if (szUserName == val)
            {
                return 99999;
            }
                
        }
            //----------------------------------
            if (!ClsMysql.FncOpen(""))  return -1;
            Int32  UserId = -1;
            
            string szSql = "Select UserId from tmst_user where idLoginName='" + szUserName + "'";
            MySqlCommand oCmd = new MySqlCommand(szSql,  ClsMysql.MySqlConnection);
            try
            {
                UserId = Convert.ToInt32(oCmd.ExecuteScalar().ToString());
            }
            catch
            { UserId = -1; }
            ClsMysql.FncClose();
            oCmd.Dispose();
            return UserId;
        }

        public bool FncExistOtherUserSame(int pUserId, string pIdLoginName, string pIdLoginMail,ref bool pbExistSameUser, ref bool pbExistSameEmail )
        {
          bool bExistOther =   false;
          pbExistSameUser = false;
          pbExistSameEmail = false;
          
          Int32  m_UserId_IdLoginEmail = FncExistIdEmail(pIdLoginMail);
          Int32  m_UserId_IdLoginName = FncExistUserIdName(pIdLoginName);


          if (m_UserId_IdLoginEmail != pUserId && m_UserId_IdLoginEmail != -1)
            {
                pbExistSameEmail = true;
                pbExistSameUser = true;
                return false;
            }
           // mismo nombre en otro id 
          if (pUserId != m_UserId_IdLoginName && m_UserId_IdLoginName != -1)
            {
                pbExistSameUser = true;
                bExistOther = true;
            }
          // mismo nombre en otro id con mismo mail
          if (pUserId != m_UserId_IdLoginEmail  && m_UserId_IdLoginEmail  != -1)
          {
              pbExistSameEmail = true;
              bExistOther = true;
          }
          return bExistOther;

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

        public Int32 UserId
        {
            set
            {
                m_UserId = value;
            }
            get { return m_UserId; }
        }

        //................................

        public String IdLoginPwd
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_IdLoginPwd because is it too long,MaxLength=50";
                }
                m_IdLoginPwd = sz;

            }
            get { return m_IdLoginPwd; }
        }

        //................................

        public String IdLoginMail
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_IdLoginMail because is it too long,MaxLength=50";
                }
                m_IdLoginMail = sz;

            }
            get { return m_IdLoginMail; }
        }

        //................................

        public String IdLoginName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_IdLoginName because is it too long,MaxLength=50";
                }
                m_IdLoginName = sz;

            }
            get { return m_IdLoginName; }
        }

        //................................

        public String NameFull
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_NameFull because is it too long,MaxLength=50";
                }
                m_NameFull = sz;

            }
            get { return m_NameFull; }
        }

        //................................

        public String ShortDescription
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_ShortDescription because is it too long,MaxLength=50";
                }
                m_ShortDescription = sz;

            }
            get { return m_ShortDescription; }
        }

        //................................

        public String Organitation
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Organitation because is it too long,MaxLength=50";
                }
                m_Organitation = sz;

            }
            get { return m_Organitation; }
        }

        //................................
        public string AvatarURL
        {
         get{return  ClsGlobal.UrlAvatars + m_Avatar;}
        }
        public String Avatar
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Avatar because is it too long,MaxLength=50";
                }
                m_Avatar = sz;

            }
            get { return m_Avatar; }
        }

        //................................

        public bool CanMailFromUser
        {
            set
            {
                m_CanMailFromUser = value;
            }
            get { return m_CanMailFromUser; }
        }

        //................................

        public bool IsAdmin
        {
            set
            {
                m_IsAdmin = value;
            }
            get { return m_IsAdmin; }
        }

        //................................

        public bool IsEditor
        {
            set
            {
                m_IsEditor = value;
            }
            get { return m_IsEditor; }
        }

        //................................

        public bool IsTranslator
        {
            set
            {
                m_IsTranslator = value;
            }
            get { return m_IsTranslator; }
        }

        //................................

        public bool IsActive
        {
            set
            {
                m_IsActive = value;
            }
            get { return m_IsActive; }
        }
        public bool IsBlocked
        {
            set
            {
                m_IsBlocked = value;
            }
            get { return m_IsBlocked; }
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

        public String Country
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 3)
                {
                    sz = sz.Substring(0, 2);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Country because is it too long,MaxLength=3";
                }
                m_Country = sz;

            }
            get { return m_Country; }
        }

        //................................

        public String Language
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Language because is it too long,MaxLength=50";
                }
                m_Language = sz;

            }
            get { return m_Language; }
        }

        //................................

        public String URL
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_URL because is it too long,MaxLength=50";
                }
                m_URL = sz;

            }
            get { return m_URL; }
        }

        //................................

        public DateTime CreationDate
        {
            set
            {
                m_CreationDate = value;
            }
            get { return m_CreationDate; }
        }

        //................................

        public String CreationFromIP
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 20)
                {
                    sz = sz.Substring(0, 19);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CreationFromIP because is it too long,MaxLength=20";
                }
                m_CreationFromIP = sz;

            }
            get { return m_CreationFromIP; }
        }
        //-----------------------------------------
          public String ActivationGUID
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 80)
                {
                    sz = sz.Substring(0, 79);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed ActivationGUID because is it too long,MaxLength=79";
                }
                m_ActivationGUID = sz;

            }
            get { return m_ActivationGUID; }
        }
//-----------------------------------------
         public DateTime ActivationDate
        {
            set
            {
                m_ActivationDate = value;
            }
            get { return m_ActivationDate; }
        }

       
                   
          //-----------------------------------------
          public String ActivationFromIP
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 20)
                {
                    sz = sz.Substring(0, 19);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CreationFromIP because is it too long,MaxLength=20";
                }
                m_ActivationFromIP = sz;

            }
            get { return m_ActivationFromIP; }
        }
        //................................

        public DateTime DateUpdate
        {
            set
            {
                m_DateUpdate = value;
            }
            get { return m_DateUpdate; }
        }

        //................................

        public DateTime DateLastLogin
        {
            set
            {
                m_DateLastLogin = value;
            }
            get { return m_DateLastLogin; }
        }

        #endregion VALORES_GETSET

    }
}
