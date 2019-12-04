using System;

using System.Data;
using MySql.Data.MySqlClient;

using System.Web;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoclng_media 
    {
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";

        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectURL = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
       
        private UInt64 m_DocId = 0;
        private String m_DocLngId = ClsGlobal.default_DocLngId;
        private String m_UID = Guid.NewGuid().ToString();
        private String m_URL = "";
        private String m_FileNameOnSource = "";
        private String m_FileNameShort = "";
        private String m_Type = "";
        private Int32 m_ImgWith = 0;
        private Int32 m_imgHeight = 0;
        private bool m_IsGalleryVisible = false;
        private bool m_IsDownloadable = false;
        private bool m_IsVisible = false;
        private String m_Title = "";
        private String m_Author = "";
        private String m_Source = "";
        private String m_Notes = "";
        private Int32 m_CreateYear = 0;
        private String m_CreateGeoLocation = "";
        private String m_CreateGeoGPS = "";
        private DateTime m_CreateDate = DateTime.Now;
        private String m_LogFromIp = "";
        private DateTime m_LogFromDate = DateTime.Now;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoc_media(string szSqlConnectionString)
        //{
        public ClsReg_tdoclng_media()
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
           
           {
	 m_DocId = 0;
     m_DocLngId = ClsGlobal.default_DocLngId; ;
     m_UID = Guid.NewGuid().ToString(); 
	 m_URL = "";
	 m_FileNameOnSource = "";
	 m_FileNameShort = "";
	 m_Type = "";
	 m_ImgWith = 0;
	 m_imgHeight = 0;
	 m_IsGalleryVisible = false;
	 m_IsDownloadable = false;
	 m_IsVisible = false;
	 m_Title = "";
	 m_Author = "";
	 m_Source = "";
	 m_Notes = "";
	 m_CreateYear = 0;
	 m_CreateGeoLocation = "";
	 m_CreateGeoGPS = "";
	 m_CreateDate = DateTime.Now;
     m_LogFromIp = "";
	 m_LogFromDate = DateTime.Now;
}
        }
        #endregion CLEAR
        //------------------------------
        //--------------------------------------------------------
        //----------------FncSqlBuildCommands-----------------------
        //--------------------------------------------------------
        public void FncSqlBuildCommands()
        {


            string szSql = "";


            //--------------------------------------------------------
            
	//----------------------------------------------------------------------
	//-------------- COMANDO SELECT  ---------------------------------------
	//----------------------------------------------------------------------
	szSql="SELECT * FROM tdoclng_media  ";
	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	 szSql+=" AND (DocLngId=@DocLngId )"; 

	oSqlCmdSelect.CommandText =szSql;
	 oSqlCmdSelect.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdSelect.Parameters.Add ("@DocLngId",MySql.Data.MySqlClient.MySqlDbType.String);
	//----------------------------------------------------------------------

	//----------------------------------------------------------------------
	//-------------- COMANDO INSERT ----------------------------------------
	//----------------------------------------------------------------------
	 szSql="INSERT INTO tdoclng_media";

	 szSql+="(";

	 szSql+=" DocId "; 
	 szSql+=", DocLngId "; 
	 szSql+=", UID "; 
	 szSql+=", URL "; 
	 szSql+=", FileNameOnSource "; 
	 szSql+=", FileNameShort "; 
	 szSql+=", Type "; 
	 szSql+=", ImgWith "; 
	 szSql+=", imgHeight "; 
	 szSql+=", IsGalleryVisible "; 
	 szSql+=", IsDownloadable "; 
	 szSql+=", IsVisible "; 
	 szSql+=", Title "; 
	 szSql+=", Author "; 
	 szSql+=", Source "; 
	 szSql+=", Notes "; 
	 szSql+=", CreateYear "; 
	 szSql+=", CreateGeoLocation "; 
	 szSql+=", CreateGeoGPS "; 
	 szSql+=", CreateDate "; 
	 szSql+=", LogFromIp "; 
	 szSql+=", LogFromDate ";
	 szSql+=" ) VALUES     (";
	 szSql+=" @DocId "; 
	 szSql+=", @DocLngId "; 
	 szSql+=", @UID "; 
	 szSql+=", @URL "; 
	 szSql+=", @FileNameOnSource "; 
	 szSql+=", @FileNameShort "; 
	 szSql+=", @Type "; 
	 szSql+=", @ImgWith "; 
	 szSql+=", @imgHeight "; 
	 szSql+=", @IsGalleryVisible "; 
	 szSql+=", @IsDownloadable "; 
	 szSql+=", @IsVisible "; 
	 szSql+=", @Title "; 
	 szSql+=", @Author "; 
	 szSql+=", @Source "; 
	 szSql+=", @Notes "; 
	 szSql+=", @CreateYear "; 
	 szSql+=", @CreateGeoLocation "; 
	 szSql+=", @CreateGeoGPS "; 
	 szSql+=", @CreateDate "; 
	 szSql+=", @LogFromIp "; 
	 szSql+=", @LogFromDate "; 
	 szSql+=")";
	 // szSql+= " ; SELECT LAST_INSERT_ID()"
	//-----------------------------------------------------
	// TODO Para configurar el comando Insert recuperando la identidad. 
	// descomentar la linea anterior  


	oSqlCmdInsert.CommandText =szSql;
	 oSqlCmdInsert.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdInsert.Parameters.Add ("@DocLngId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@UID",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@URL",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@FileNameOnSource",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@FileNameShort",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Type",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@ImgWith",MySql.Data.MySqlClient.MySqlDbType.UInt32);
	 oSqlCmdInsert.Parameters.Add ("@imgHeight",MySql.Data.MySqlClient.MySqlDbType.UInt32);
	 oSqlCmdInsert.Parameters.Add ("@IsGalleryVisible",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdInsert.Parameters.Add ("@IsDownloadable",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdInsert.Parameters.Add ("@IsVisible",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdInsert.Parameters.Add ("@Title",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Author",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Source",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@Notes",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@CreateYear",MySql.Data.MySqlClient.MySqlDbType.Int32);
	 oSqlCmdInsert.Parameters.Add ("@CreateGeoLocation",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@CreateGeoGPS",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@CreateDate",MySql.Data.MySqlClient.MySqlDbType.DateTime);
	 oSqlCmdInsert.Parameters.Add ("@LogFromIp",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdInsert.Parameters.Add ("@LogFromDate",MySql.Data.MySqlClient.MySqlDbType.Date);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO UPDATE ---------------------------------------
	//----------------------------------------------------------------------
	 szSql="UPDATE tdoclng_media SET " ;

	 szSql+="UID=@UID "; 
	 szSql+=", URL=@URL "; 
	 szSql+=", FileNameOnSource=@FileNameOnSource "; 
	 szSql+=", FileNameShort=@FileNameShort "; 
	 szSql+=", Type=@Type "; 
	 szSql+=", ImgWith=@ImgWith "; 
	 szSql+=", imgHeight=@imgHeight "; 
	 szSql+=", IsGalleryVisible=@IsGalleryVisible "; 
	 szSql+=", IsDownloadable=@IsDownloadable "; 
	 szSql+=", IsVisible=@IsVisible "; 
	 szSql+=", Title=@Title "; 
	 szSql+=", Author=@Author "; 
	 szSql+=", Source=@Source "; 
	 szSql+=", Notes=@Notes "; 
	 szSql+=", CreateYear=@CreateYear "; 
	 szSql+=", CreateGeoLocation=@CreateGeoLocation "; 
	 szSql+=", CreateGeoGPS=@CreateGeoGPS "; 
	 szSql+=", CreateDate=@CreateDate "; 
	 szSql+=", LogFromIp=@LogFromIp "; 
	 szSql+=", LogFromDate=@LogFromDate ";
	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	 szSql+=" AND (DocLngId=@DocLngId )"; 
	oSqlCmdUpdate.CommandText =szSql;


	 oSqlCmdUpdate.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdUpdate.Parameters.Add ("@DocLngId",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@UID",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@URL",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@FileNameOnSource",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@FileNameShort",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Type",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@ImgWith",MySql.Data.MySqlClient.MySqlDbType.UInt32);
	 oSqlCmdUpdate.Parameters.Add ("@imgHeight",MySql.Data.MySqlClient.MySqlDbType.UInt32);
	 oSqlCmdUpdate.Parameters.Add ("@IsGalleryVisible",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdUpdate.Parameters.Add ("@IsDownloadable",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdUpdate.Parameters.Add ("@IsVisible",MySql.Data.MySqlClient.MySqlDbType.Bit);
	 oSqlCmdUpdate.Parameters.Add ("@Title",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Author",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Source",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@Notes",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@CreateYear",MySql.Data.MySqlClient.MySqlDbType.Int32);
	 oSqlCmdUpdate.Parameters.Add ("@CreateGeoLocation",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@CreateGeoGPS",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@CreateDate",MySql.Data.MySqlClient.MySqlDbType.DateTime);
	 oSqlCmdUpdate.Parameters.Add ("@LogFromIp",MySql.Data.MySqlClient.MySqlDbType.String);
	 oSqlCmdUpdate.Parameters.Add ("@LogFromDate",MySql.Data.MySqlClient.MySqlDbType.Date);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO DELETE  ---------------------------------------
	//----------------------------------------------------------------------
	szSql="DELETE FROM tdoclng_media  ";
	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	 szSql+=" AND (DocLngId=@DocLngId )"; 

	oSqlCmdDelete.CommandText =szSql;
	 oSqlCmdDelete.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdDelete.Parameters.Add ("@DocLngId",MySql.Data.MySqlClient.MySqlDbType.String);
	//----------------------------------------------------------------------
	//----------------------------------------------------------------------
	//-------------- COMANDO SELECT  exist ---------------------------------
	//----------------------------------------------------------------------
	szSql="SELECT ";
	 szSql+=" DocId";

	 szSql+=", DocLngId";
	szSql+=" FROM tdoclng_media  ";

	 szSql+=" WHERE ";
	 szSql+="(DocId=@DocId )"; 
	 szSql+=" AND (DocLngId=@DocLngId )"; 
	oSqlCmdSelectExist.CommandText =szSql;
	 oSqlCmdSelectExist.Parameters.Add ("@DocId",MySql.Data.MySqlClient.MySqlDbType.UInt64);
	 oSqlCmdSelectExist.Parameters.Add ("@DocLngId",MySql.Data.MySqlClient.MySqlDbType.String);
	//----------------------------------------------------------------------

        
            //----------------------------------------------------------------------
            //-------------- COMANDO SqlCmdSelectURL -----------------------
            //----------------------------------------------------------------------

     szSql = "SELECT DocId, DocLngId FROM tdoclng_media  ";
            szSql += " WHERE ";
            szSql += "(URL=@URL )";

            oSqlCmdSelectURL.CommandText = szSql;
            oSqlCmdSelectURL.Parameters.Add("@URL", MySql.Data.MySqlClient.MySqlDbType.String );

        }
        //	-------------------------------------------------
        public bool FncSqlSave(string szMaskUrl)
        {
           // m_URL = szMaskUrl.Trim().ToLower ();
            if (m_URL == "")
            {
                ErrorBoolean = true;
                ErrorString = "the file is empty";
                return false;
            }
            else
            {
                // el fichero debe haberse subido y colocado en lugar adecuado.
                string szFile = ClsGlobal.DirRoot + m_URL;
                if (!System.IO.File.Exists(szFile))
                {
                    ErrorBoolean = true;
                    ErrorString = "the file is nost upladed to " + szFile;
                    return false;
                }



            }
            // si DocId==0 comprobar si existe un DocId Para   m_URL
            UInt64 iDocId = 0;
            string iDocLngId = "";
             FncFindIdDoc_ForUrl(m_URL, ref iDocId, ref iDocLngId);
            
            m_DocId = iDocId;
            m_DocLngId = iDocLngId;

            //===========================================================
            //===========================================================
            // SI DocId==0, 
            // crear un nuevo registro en tdoc
            // crear un nuevo registro en todoc_lng
            // tanto tdoc como tdoc_lng toma los valores por defecto
            // de esta imagen.
            // 
            // Si DocId!=0
            // actualizar tambien tdoc y tdoc_lng
            //===========================================================
            //===========================================================
            cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc();

            // Grabar el tdocid, y obtener docid si era cero.
            cls.bbdd.ClsReg_tdoclng oRegDocLng = new ClsReg_tdoclng();
            

            oRegDoc.DocId = m_DocId;
            oRegDoc.DocAuthors = m_Author;
            oRegDoc.DocIsActive = true;
            oRegDoc.DocIsEditable = true;
            oRegDoc.DocIsTraslatable = true;
            oRegDoc.DocNotes = m_Notes;
            oRegDoc.DocTypeGroup = "mmedia";
            oRegDoc.DocTypeGroupSub = m_Type;
            oRegDoc.DocLngId_Main = ClsGlobal.default_DocLngId;
            oRegDoc.FncSqlSave();
            m_DocId = oRegDoc.DocId;
            // grabar el tdocid_lng
            oRegDocLng.DocId = m_DocId;
            oRegDocLng.DocLngId = m_DocLngId;
            // oRegDocLng.DocLngUrlId = ClsGlobal.DirRootUrl +"/"+ ClsGlobal.default_DocLngId + "/media/" + m_DocId.ToString ();
            string szTitleClear = "";
            szTitleClear =m_Title.Replace ("_", " ").Replace("-"," ") ;
            oRegDocLng.DocLngMetaAuthor = m_Author;
            oRegDocLng.DocLngMetaDescription = m_Title +", "+ m_Author  + ", from " + m_Source;
            oRegDocLng.DocLngMetaKeyWords = szTitleClear;
            oRegDocLng.DocLngMetaLanguage = ClsGlobal.default_DocLngId;
            oRegDocLng.DocLngMetaTitle = szTitleClear ;
            oRegDocLng.FncSqlSave(szMaskUrl);


            //===========================================================
            //===========================================================
            //===========================================================
            //===========================================================
            //===========================================================

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
            oSqlCmdSelectExist.Parameters["@DocLngId"].Value = m_DocLngId ;

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
            oSqlCmdUpdate.Parameters["@UID"].Value = m_UID;
            oSqlCmdUpdate.Parameters["@URL"].Value = m_URL;
            oSqlCmdUpdate.Parameters["@FileNameOnSource"].Value = m_FileNameOnSource;
            oSqlCmdUpdate.Parameters["@FileNameShort"].Value = m_FileNameShort;
            oSqlCmdUpdate.Parameters["@Type"].Value = m_Type;
            oSqlCmdUpdate.Parameters["@ImgWith"].Value = m_ImgWith;
            oSqlCmdUpdate.Parameters["@imgHeight"].Value = m_imgHeight;
            oSqlCmdUpdate.Parameters["@IsGalleryVisible"].Value = m_IsGalleryVisible;
            oSqlCmdUpdate.Parameters["@IsDownloadable"].Value = m_IsDownloadable;
            oSqlCmdUpdate.Parameters["@IsVisible"].Value = m_IsVisible;
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@Author"].Value = m_Author;
            oSqlCmdUpdate.Parameters["@Source"].Value = m_Source;
            oSqlCmdUpdate.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdUpdate.Parameters["@CreateYear"].Value = m_CreateYear;
            oSqlCmdUpdate.Parameters["@CreateGeoLocation"].Value = m_CreateGeoLocation;
            oSqlCmdUpdate.Parameters["@CreateGeoGPS"].Value = m_CreateGeoGPS;
            oSqlCmdUpdate.Parameters["@CreateDate"].Value = m_CreateDate;
            oSqlCmdUpdate.Parameters["@LogFromIp"].Value = m_LogFromIp;
            oSqlCmdUpdate.Parameters["@LogFromDate"].Value = m_LogFromDate;
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
            oSqlCmdInsert.Parameters["@UID"].Value = m_UID;
            oSqlCmdInsert.Parameters["@URL"].Value = m_URL;
            oSqlCmdInsert.Parameters["@FileNameOnSource"].Value = m_FileNameOnSource;
            oSqlCmdInsert.Parameters["@FileNameShort"].Value = m_FileNameShort;
            oSqlCmdInsert.Parameters["@Type"].Value = m_Type;
            oSqlCmdInsert.Parameters["@ImgWith"].Value = m_ImgWith;
            oSqlCmdInsert.Parameters["@imgHeight"].Value = m_imgHeight;
            oSqlCmdInsert.Parameters["@IsGalleryVisible"].Value = m_IsGalleryVisible;
            oSqlCmdInsert.Parameters["@IsDownloadable"].Value = m_IsDownloadable;
            oSqlCmdInsert.Parameters["@IsVisible"].Value = m_IsVisible;
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@Author"].Value = m_Author;
            oSqlCmdInsert.Parameters["@Source"].Value = m_Source;
            oSqlCmdInsert.Parameters["@Notes"].Value = m_Notes;
            oSqlCmdInsert.Parameters["@CreateYear"].Value = m_CreateYear;
            oSqlCmdInsert.Parameters["@CreateGeoLocation"].Value = m_CreateGeoLocation;
            oSqlCmdInsert.Parameters["@CreateGeoGPS"].Value = m_CreateGeoGPS;
            oSqlCmdInsert.Parameters["@CreateDate"].Value = m_CreateDate;
            oSqlCmdInsert.Parameters["@LogFromIp"].Value = m_LogFromIp;
            oSqlCmdInsert.Parameters["@LogFromDate"].Value = m_LogFromDate;
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
                    m_UID = oDR["UID"].ToString().Trim();
                    m_URL = oDR["URL"].ToString().Trim();
                    m_FileNameOnSource = oDR["FileNameOnSource"].ToString().Trim();
                    m_FileNameShort = oDR["FileNameShort"].ToString().Trim();
                    m_Type = oDR["Type"].ToString().Trim();
                    m_ImgWith = Convert.ToInt32(oDR["ImgWith"].ToString().Trim());
                    m_imgHeight = Convert.ToInt32(oDR["imgHeight"].ToString().Trim());
                    m_IsGalleryVisible = Convert.ToBoolean(oDR["IsGalleryVisible"].ToString().Trim());
                    m_IsDownloadable = Convert.ToBoolean(oDR["IsDownloadable"].ToString().Trim());
                    m_IsVisible = Convert.ToBoolean(oDR["IsVisible"].ToString().Trim());
                    m_Title = oDR["Title"].ToString().Trim();
                    m_Author = oDR["Author"].ToString().Trim();
                    m_Source = oDR["Source"].ToString().Trim();
                    m_Notes = oDR["Notes"].ToString().Trim();
                    m_CreateYear = Convert.ToInt32(oDR["CreateYear"].ToString().Trim());
                    m_CreateGeoLocation = oDR["CreateGeoLocation"].ToString().Trim();
                    m_CreateGeoGPS = oDR["CreateGeoGPS"].ToString().Trim();
                    m_CreateDate = Convert.ToDateTime(oDR["CreateDate"].ToString().Trim());
                    m_LogFromIp = oDR["LogFromIp"].ToString().Trim();
                    m_LogFromDate = Convert.ToDateTime(oDR["LogFromDate"].ToString().Trim());
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
        public bool FncSqlDelete(UInt64 DocId, String DocLngId)
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
                    cls.bbdd.ClsReg_tdoclng oRegMeta = new ClsReg_tdoclng();
                    oRegMeta.FncSqlDelete(DocId, DocLngId);
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



        //--------------------------------------------------------r
        //***********************************************************
        //***********************************************************
        /// <summary>
        /// Return DocId for a this URL or 0 if not exist
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public bool FncFindIdDoc_ForUrl(string URL, ref UInt64 DocId, ref  string DocLngId)
        {
            bool bFind = false;
            DocId = 0;
            DocLngId = ClsGlobal.default_DocLngId; 
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen("")) return false ;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelectURL.Parameters["@URL"].Value = URL;
            //----------------------------------------------------


            try
            {

                oSqlCmdSelectURL.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                //string szSql = @"select docid from tdoc_media where URL='/Articles/figure02(1).jpg'";
                //MySqlCommand oCmd= new MySqlCommand (szSql , oSqlCnn);
                //DocIdr2 = oCmd.ExecuteScalar().ToString(); 
                MySqlDataReader oRd = oSqlCmdSelectURL.ExecuteReader();
                if (oRd.HasRows && oRd.Read())
                {
                    DocId = Convert.ToUInt64(oRd["DocId"].ToString());
                    DocLngId = oRd["DocLngId"].ToString().Trim().ToLower();
                    bFind = true;
                }
                oRd.Close();
                oRd.Dispose();
            }
            catch
            {
                FncClear();
                return false;
            }
            
            //bFind = FncSqlFind(DocId, DocLngId);
            return bFind;
        }
        public bool FncSqlFindURL(string URL)
        {
            bool bFind = false;
            _mErrorBoolean = false;
            _mErrorString = "";
            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen("")) return false;
            //---------------------------------------------------
            //Asignar parametros al commando para búsqueda       
            //----------------------------------------------------
            oSqlCmdSelectURL.Parameters["@URL"].Value = URL;
            //----------------------------------------------------
            UInt64 iDocId = 0;
            string iDocLngId = ClsGlobal.default_DocLngId;
            try
            {

                oSqlCmdSelectURL.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                //string szSql = @"select docid from tdoc_media where URL='/Articles/figure02(1).jpg'";
                //MySqlCommand oCmd= new MySqlCommand (szSql , oSqlCnn);
                //DocIdr2 = oCmd.ExecuteScalar().ToString(); 
                MySqlDataReader oRd= oSqlCmdSelectURL.ExecuteReader ();
                if (oRd.HasRows && oRd.Read())
                {
                     iDocId =Convert.ToUInt64 ( oRd["DocId"].ToString());
                     iDocLngId = oRd["DocLngId"].ToString().Trim().ToLower();

                     bFind = true;
                }
                oRd.Close();
                oRd.Dispose();
                if (bFind)
                {
                    // recuperadas las claves reales recupera los valores
                    bFind = FncSqlFind(iDocId, iDocLngId);
                }
               
            }//Cierre de try 
            catch (SystemException ex)
            {
                FncClear();
                _mErrorBoolean = true;
                _mErrorString = ex.ToString();
               
                //  MessageBox.Show (_mErrorString); 
            }
            //------------------------------------------------------
            // cierre.
            //-------------------------------------------------------
            ClsMysql.FncClose();
            
            //oSqlCnn.Dispose();
            return bFind ;
            //--------------------------------------------------------------------
        }
        
        
        
        public bool FncSqlDelete_URL(string URL)
        {
            _mErrorBoolean = false;
            _mErrorString = "";

            // string szSelect_tdocMedia="select DocId, URL from tdoc_media where URL LIKE '#URL#%' ESCAPE '|'";



            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen(""))
                return false;
            //-----------------------------------------------------;
            // ELIMINAR REGISTROs. 
            //-------------------------------------------------------;
            MySqlCommand oCmd_TdocMediaSelect = new MySqlCommand();
            DataTable oTdocMedia = new DataTable();
            MySqlCommand oCmd_delete = new MySqlCommand();
            oCmd_delete.Connection = ClsMysql.MySqlConnection;;
            oCmd_TdocMediaSelect.Connection = ClsMysql.MySqlConnection;;
            oCmd_TdocMediaSelect.CommandText = "select DocId, URL from tdoc_media where URL LIKE '" + URL + "%' ESCAPE '|'";
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd_TdocMediaSelect);
            try
            {

                oDA.Fill(oTdocMedia);
                foreach (DataRow oRow in oTdocMedia.Rows)
                {

                    oCmd_delete.CommandText = "Delete  from tdoc_media where Docid=" + oRow[0].ToString();
                    oCmd_delete.ExecuteNonQuery();

                    oCmd_delete.CommandText = "Delete  from tdoclng where Docid=" + oRow[0].ToString(); ;
                    oCmd_delete.ExecuteNonQuery();

                }
                oCmd_delete.CommandText = "select DocId, URL from tdoc_media where URL LIKE '" + URL + "%' ESCAPE '|'"; ;
                oCmd_delete.ExecuteNonQuery();
            }
            catch (MySqlException xcpt)
            {
                _mErrorString = xcpt.Message;
                _mErrorBoolean = true;
                //  MessageBox.Show (xcpt.Message );
            }
            ClsMysql.FncClose();
            //oSqlCnn.Dispose();
            oCmd_TdocMediaSelect.Dispose();
            oCmd_delete.Dispose();
            oDA.Dispose();

            return !_mErrorBoolean;

        }


     
//--------------------------------------------------
#region VALORES_GETSET
//--------------------------------------------------


        public String FileNameShort
        {

            get
            {
                return ClsUtils.FncFileNameShort(m_URL);



            }
        }

    
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
                if (sz == "") sz = ClsGlobal.default_DocLngId; 
                m_DocLngId = sz.ToLower ();

            }
            get { return m_DocLngId; }
        }

        //................................

        public String UID
        {
            //set
            //{
            //    string sz = value.Trim();
            //    //crear uid si esta en blanco
            //    if (sz == "")
            //    {
            //      //  Guid oUid = new Guid();
            //        sz = Guid.NewGuid().ToString();
            //    }
            //    if (sz.Length > 64)
            //    {
            //        sz = sz.Substring(0, 63);
            //        _mErrorBoolean = true;
            //        _mErrorString = "Trimmed m_UID because is it too long,MaxLength=32";
            //    }
            //    m_UID = sz;

            //}
            get { return m_UID; }
        }

        //................................

        public String URL
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 450)
                {
                    sz = sz.Substring(0, 449);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_URL because is it too long,MaxLength=450";
                }
                sz=sz.Replace ("\\","/");
                m_URL = sz.ToLower().Replace ("//","/") ;
                string szEnd = "";
                
                szEnd = m_URL.Substring(m_URL.Length - 4, 4);
                if (szEnd =="jpeg") szEnd =".jpg";
                if (szEnd == "mpeg") szEnd = ".mpg";
                
                switch (szEnd)
                {
                    case ".jpg":
                        m_Type  = "img";
                        break;
                    case ".png":
                        m_Type = "img";
                        break;
                    case ".gif":
                        m_Type = "img";
                        break;
                    case ".svg":
                        m_Type = "vec";
                        break;
                    case ".pdf":
                        m_Type = "doc";
                        break;
                    case ".mov":
                        m_Type = "vid";
                        break;
                    case ".mpg":
                        m_Type = "vid";
                        break;
                    default :
                        m_Type = "doc";
                        break;
                }
                m_FileNameShort = ClsUtils.FncFileNameShort(m_URL);  

            }
            get { return m_URL; }
        }

        //................................

        public String FileNameOnSource
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_FileNameOnSource because is it too long,MaxLength=250";
                }
                m_FileNameOnSource = sz;

            }
            get { return m_FileNameOnSource; }
        }

        //................................

      
        //................................

        public String Type
        {
            //set
            //{
            //    string sz = value.Trim();
            //    if (sz.Length > 25)
            //    {
            //        sz = sz.Substring(0, 24);
            //        _mErrorBoolean = true;
            //        _mErrorString = "Trimmed m_Type because is it too long,MaxLength=25";
            //    }
            //    m_Type = sz;

            //}
            get { return m_Type; }
        }

        //................................

        public Int32 ImgWith
        {
            set
            {
                m_ImgWith = value;
            }
            get { return m_ImgWith; }
        }

        //................................

        public Int32 imgHeight
        {
            set
            {
                m_imgHeight = value;
            }
            get { return m_imgHeight; }
        }

        //................................

        public bool IsGalleryVisible
        {
            set
            {
                m_IsGalleryVisible = value;
            }
            get { return m_IsGalleryVisible; }
        }

        //................................

        public bool IsDownloadable
        {
            set
            {
                m_IsDownloadable = value;
            }
            get { return m_IsDownloadable; }
        }

        //................................

        public bool IsVisible
        {
            set
            {
                m_IsVisible = value;
            }
            get { return m_IsVisible; }
        }

        //................................

        public String Title
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=250";
                }
                m_Title = sz;

            }
            get { return m_Title; }
        }

        //................................

        public String Author
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 80)
                {
                    sz = sz.Substring(0, 79);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Author because is it too long,MaxLength=80";
                }
                m_Author = sz;

            }
            get { return m_Author; }
        }

        //................................

        public String Source
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 80)
                {
                    sz = sz.Substring(0, 79);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Source because is it too long,MaxLength=80";
                }
                m_Source = sz;

            }
            get { return m_Source; }
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

        public Int32 CreateYear
        {
            set
            {
                m_CreateYear = value;
            }
            get { return m_CreateYear; }
        }

        //................................

        public String CreateGeoLocation
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 80)
                {
                    sz = sz.Substring(0, 79);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CreateGeoLocation because is it too long,MaxLength=80";
                }
                m_CreateGeoLocation = sz;

            }
            get { return m_CreateGeoLocation; }
        }

        //................................

        public String CreateGeoGPS
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CreateGeoGPS because is it too long,MaxLength=250";
                }
                m_CreateGeoGPS = sz;

            }
            get { return m_CreateGeoGPS; }
        }

        //................................

        public DateTime CreateDate
        {
            set
            {
                m_CreateDate = value;
            }
            get { return m_CreateDate; }
        }

        //................................

        public String LogFromIp
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 50)
                {
                    sz = sz.Substring(0, 49);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_LogFromIp because is it too long,MaxLength=50";
                }
                m_LogFromIp = sz;

            }
            get { return m_LogFromIp; }
        }

        //................................

        public DateTime LogFromDate
        {
            set
            {
                m_LogFromDate = value;
            }
            get { return m_LogFromDate; }
        }

#endregion VALORES_GETSET

    }
}
