using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Globalization;
using System.Threading;
namespace testudines.cls.bbdd
{
    //<summary>
    //Descripción breve de testudines.cls.bbdd
    //<//summary>
    public class ClsReg_tdoc_acknowledgment
    {

        private static String m_Culture_before = "";
        private static String m_Culture_Called = "";
        private cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc();
        private bool _mErrorBoolean = false;
        private string _mErrorString = "";

        private MySqlCommand oSqlCmdUpdate = new MySqlCommand();
        private MySqlCommand oSqlCmdInsert = new MySqlCommand();
        private MySqlCommand oSqlCmdDelete = new MySqlCommand();
        private MySqlCommand oSqlCmdSelect = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectTitle = new MySqlCommand();
        private MySqlCommand oSqlCmdSelectExist = new MySqlCommand();

        //-------------------------------------------------
        #region SQLDEFINICION_VARIABLES#
        //------------------------------------------------
        private UInt64 m_DocId = 0;
    
        private String m_Title = "";
        private String m_Abstract = "";
        private String m_Body = "";
   
        private String m_Email = "";
        private String m_UrlExternal = "";

        private bool m_IsColaborator = false;
        private bool m_IsAuthorizeAll = false;

        private String m_CiteName = "";
        private String m_CiteFull = "";
        private String m_PubTitle = "";
     
        private DateTime m_PubDateAutorization = DateTime.Now;
 
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        //public ClsReg_tdoc_acknowledgment(string szSqlConnectionString)
        //{
        public ClsReg_tdoc_acknowledgment()
        {
  
           ClsMysql.MySqlConnectionString= cls.ClsGlobal.Connection_MARIADB;
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
           
            m_Title = "";
            m_Abstract = "";
            m_Body = "";
         
            m_Email = "";
            m_UrlExternal = "";
          
            m_IsColaborator = true;
            m_IsAuthorizeAll = false;
            m_CiteName = "";
            m_CiteFull = "";
         
            m_PubDateAutorization = DateTime.Now;
           
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
            szSql = "SELECT * FROM tdoc_acknowledgment  ";
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
          

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
           
            //----------------------------------------------------------------------
            szSql = "SELECT DocId FROM tdoc_acknowledgment  ";
            szSql += " WHERE ";
            szSql += "Title like @Title ";
            oSqlCmdSelectTitle.CommandText = szSql;
            oSqlCmdSelectTitle.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);


            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO tdoc_acknowledgment";

            szSql += "(";

            szSql += " DocId ";
           
            szSql += ", Title ";
            szSql += ", Abstract ";
            szSql += ", Body ";
           
            szSql += ", Email ";
            szSql += ", UrlExternal ";
            
            szSql += ", IsColaborator ";
            szSql += ", IsAuthorizeAll ";


            szSql += ", CiteName ";
            szSql += ", CiteFull ";
            
            szSql += " ) VALUES     (";
            szSql += " @DocId ";
          
            szSql += ", @Title ";
            szSql += ", @Abstract ";
            szSql += ", @Body ";
            
            szSql += ", @Email ";
            szSql += ", @UrlExternal ";
            
            szSql += ", @IsColaborator ";
            szSql += ", @IsAuthorizeAll ";


            szSql += ", @CiteName ";
            szSql += ", @CiteFull ";
           
            szSql += ")";
            // szSql+= " ; SELECT LAST_INSERT_ID()"
            //-----------------------------------------------------
            // TODO Para configurar el comando Insert recuperando la identidad. 
            // descomentar la linea anterior  


            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
          
            oSqlCmdInsert.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
           
            oSqlCmdInsert.Parameters.Add("@Email", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@UrlExternal", MySql.Data.MySqlClient.MySqlDbType.String);
           
            oSqlCmdInsert.Parameters.Add("@IsColaborator", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdInsert.Parameters.Add("@IsAuthorizeAll", MySql.Data.MySqlClient.MySqlDbType.Bit);



            oSqlCmdInsert.Parameters.Add("@CiteName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdInsert.Parameters.Add("@CiteFull", MySql.Data.MySqlClient.MySqlDbType.String);
          
            oSqlCmdInsert.Parameters.Add("@PubDateAutorization", MySql.Data.MySqlClient.MySqlDbType.Date);
            
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE tdoc_acknowledgment SET ";

            szSql += "Title=@Title ";
            szSql += ", Abstract=@Abstract ";
            szSql += ", Body=@Body ";
          
            szSql += ", Email=@Email ";
            szSql += ", UrlExternal=@UrlExternal ";
           
            szSql += ", IsColaborator=@IsColaborator ";
            szSql += ", IsAuthorizeAll=@IsAuthorizeAll ";

            szSql += ", CiteName=@CiteName ";
            szSql += ", CiteFull=@CiteFull ";
           
            szSql += ", PubDateAutorization=@PubDateAutorization ";
          
            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
        
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
           
            oSqlCmdUpdate.Parameters.Add("@Title", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Abstract", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@Body", MySql.Data.MySqlClient.MySqlDbType.String);
            
            oSqlCmdUpdate.Parameters.Add("@Email", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@UrlExternal", MySql.Data.MySqlClient.MySqlDbType.String);
        
            oSqlCmdUpdate.Parameters.Add("@IsColaborator", MySql.Data.MySqlClient.MySqlDbType.Bit);
            oSqlCmdUpdate.Parameters.Add("@IsAuthorizeAll", MySql.Data.MySqlClient.MySqlDbType.Bit);

            oSqlCmdUpdate.Parameters.Add("@CiteName", MySql.Data.MySqlClient.MySqlDbType.String);
            oSqlCmdUpdate.Parameters.Add("@CiteFull", MySql.Data.MySqlClient.MySqlDbType.String);
           
            oSqlCmdUpdate.Parameters.Add("@PubDateAutorization", MySql.Data.MySqlClient.MySqlDbType.Date);
           
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM tdoc_acknowledgment  ";
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

          
            szSql += " FROM tdoc_acknowledgment  ";

            szSql += " WHERE ";
            szSql += "(DocId=@DocId )";
            
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@DocId", MySql.Data.MySqlClient.MySqlDbType.UInt64);
           
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
            
            oSqlCmdUpdate.Parameters["@Title"].Value = m_Title;
            oSqlCmdUpdate.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdUpdate.Parameters["@Body"].Value = m_Body;
           
            oSqlCmdUpdate.Parameters["@Email"].Value = m_Email;
            oSqlCmdUpdate.Parameters["@UrlExternal"].Value = m_UrlExternal;

            oSqlCmdUpdate.Parameters["@IsColaborator"].Value = m_IsColaborator;
            oSqlCmdUpdate.Parameters["@IsAuthorizeAll"].Value = m_IsAuthorizeAll;

            oSqlCmdUpdate.Parameters["@CiteName"].Value = m_CiteName;
            oSqlCmdUpdate.Parameters["@CiteFull"].Value = m_CiteFull;
          
            oSqlCmdUpdate.Parameters["@PubDateAutorization"].Value = m_PubDateAutorization;
            
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
            
            oSqlCmdInsert.Parameters["@Title"].Value = m_Title;
            oSqlCmdInsert.Parameters["@Abstract"].Value = m_Abstract;
            oSqlCmdInsert.Parameters["@Body"].Value = m_Body;
           
            oSqlCmdInsert.Parameters["@Email"].Value = m_Email;
            oSqlCmdInsert.Parameters["@UrlExternal"].Value = m_UrlExternal;
        
            oSqlCmdInsert.Parameters["@IsColaborator"].Value = m_IsColaborator;
            oSqlCmdInsert.Parameters["@IsAuthorizeAll"].Value = m_IsAuthorizeAll;


            oSqlCmdInsert.Parameters["@CiteName"].Value = m_CiteName;
            oSqlCmdInsert.Parameters["@CiteFull"].Value = m_CiteFull;
           
            oSqlCmdInsert.Parameters["@PubDateAutorization"].Value = m_PubDateAutorization;
           
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

        public bool FncSqlFindTitle(string Title)
        {
           
            _mErrorBoolean = false;
            _mErrorString = "";

            //-------------------------------------------------
            // abrir conexion
            //--------------------------------------------------
            if (!ClsMysql.FncOpen("")) return false;

            oSqlCmdSelectTitle.Parameters["@Title"].Value = "%" + Title + "%";
            //----------------------------------------------------
            MySqlDataReader oDR; //Para recoger el resultado de la búsqueda.
            try
            {
                oSqlCmdSelectTitle.Connection = ClsMysql.MySqlConnection;;
                     ClsMysql.FncOpen("");
                oDR = oSqlCmdSelectTitle.ExecuteReader();
                //----------------------------------------------------
                // recoger los datos leidos
                //----------------------------------------------------
                if ((oDR.HasRows) && (oDR.Read()))
                {
                    m_DocId = Convert.ToUInt64(oDR["DocId"].ToString().Trim());
                   
                    oDR.Close();
                    oDR.Dispose();
                    ClsMysql.FncClose();
                    FncSqlFind(m_DocId);
                }
            }
            catch (MySqlException xcpt)

            {
                _mErrorBoolean = true;
                _mErrorString = xcpt.ToString();

                return false;
            }

            return true;
            //----------------------------------------------------
        }
        public bool FncSqlFind(UInt64 DocId)
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
                  
                    m_Title = oDR["Title"].ToString().Trim();
                    m_Abstract = oDR["Abstract"].ToString().Trim();
                    m_Body = oDR["Body"].ToString().Trim();
                   
                    m_Email = oDR["Email"].ToString().Trim();
                    m_UrlExternal = oDR["UrlExternal"].ToString().Trim();
               
                    m_IsColaborator = Convert.ToBoolean(oDR["IsColaborator"].ToString().Trim());
                    m_IsAuthorizeAll = Convert.ToBoolean(oDR["IsAuthorizeAll"].ToString().Trim());
                    m_CiteName = oDR["CiteName"].ToString().Trim();

                    m_CiteFull = oDR["CiteFull"].ToString().Trim();
                   
                    m_PubDateAutorization = Convert.ToDateTime(oDR["PubDateAutorization"].ToString().Trim());
                    _mErrorBoolean = false;
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
        public bool FncSqlDelete(UInt64 DocId)
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
               
                int i = oSqlCmdDelete.ExecuteNonQuery();
              
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
        public bool FncSqlExist(Int64 DocId)
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
           

            oSqlCmdSelectExist.Connection = ClsMysql.MySqlConnection;;
            MySqlDataReader oDR = oSqlCmdSelectExist.ExecuteReader();
            b = oDR.HasRows;
            oDR.Close();
            ClsMysql.FncClose();
            return b;
        }////--------------------------------------------------------r

        /// <summary>
        /// Utiliza Server.HtmlDecode(string) para asignarlo a un label
        /// </summary>
        /// <returns></returns>
        /// 

            /*
        public string FncHtml(bool isAdmin)
        {
            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            StringBuilder sb = new StringBuilder();
            //szHtml+=("<H1 class=\"h1_title\">" + m_Title + "</h1>\n");
            // szHtml+=("<H2 class=\"h2_titlesub\">Ref.: " + m_DocId.ToString() + "-" + m_DocLngId + "</h1>\n");
            szHtml += "<div class=\"divbox \">";
            if (oRegDoc.DocImgThumbnail != "")
            {
                szHtml += "<img class=\"align_img_right\" src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            //szHtml += "<br/><b>" + Resources.Strings.Title + "</b><br />" + m_UrlExternal;
            szHtml += "<br/><b>" + Resources.Strings.CiteFull + "</b><br />" + m_CiteFull;
            szHtml += "<br/><b>" + Resources.Strings.CiteName + "</b><br />" + m_CiteName;
       
            if (m_UrlExternal != "")
            {
                szHtml += "<br/>" + Resources.Strings.URL + "</b>:  " + m_UrlExternal;
            }
            szHtml += "<hr>";
            if (m_PubTitle != "")
            {

                szHtml += "<br/><b>" + Resources.Strings.Title + "</b><br />" + m_PubTitle;
;
                szHtml += "<br/><b>" + Resources.Strings.Date_publication + "</b><br />" + m_PubDateAutorization;

          


            }
            if (m_IsColaborator)
            {
                szHtml += "<br/><b>" + Resources.Strings.IsColaborator + "</b><br />";
            }
            if (m_IsAuthorizeAll)
            {
                szHtml += "<br/><b>" + Resources.Strings.IsAuthorizeAll + "</b><br />";
            }


            if (isAdmin && m_Email != "")
            {
                szHtml += "<br/><b>" + Resources.Strings.email + "</b><br />" + m_Email;
            }
            else
            {
                szHtml += "<br/><b>" + Resources.Strings.email + "</b><br />Only for admin user";
            }
            szHtml += "</div>\n";

            if (m_Abstract != "")
            {
                szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Abstract + "</h2>";
                szHtml += m_Abstract + "</div>\n";
            }
            if (m_Body != "")
            {
                szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Article + "</h2>" + m_Body + "</div>\n";
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

            if (oRegDoc.DocAcknowledgements != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Acknowledgements + "</h2>" + oRegDoc.DocAcknowledgements + "</div>\n");
            }
            if (oRegDoc.DocBibliography != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Bibliography + "</h2>" + oRegDoc.DocBibliography + "</div>\n");
            }
            return szHtml;


        }

        public string FncHtmlDocuments(bool isAdmin)
        {
            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            StringBuilder sb = new StringBuilder();
            //szHtml+=("<H1 class=\"h1_title\">" + m_Title + "</h1>\n");
            // szHtml+=("<H2 class=\"h2_titlesub\">Ref.: " + m_DocId.ToString() + "-" + m_DocLngId + "</h1>\n");
            szHtml += "<div class=\"divbox \">";
            if (oRegDoc.DocImgThumbnail != "")
            {
                szHtml += "<img class=\"align_img_right\" src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            //szHtml += "<br/><b>" + Resources.Strings.Title + "</b><br />" + m_UrlExternal;

            szHtml += "<h2>" + Resources.Strings.CiteName + "</h2>" + m_CiteName;
            if (m_UrlExternal != "")
            {
                szHtml += "<br/>" + Resources.Strings.URL + "</b>:<a href=\"http://" + m_UrlExternal + "\">" + m_UrlExternal + "</a>";
            }



            if (isAdmin && m_Email.Trim() != "")
            {
                //<a href="mailto:mi@direccion.com">mi@direccion.com</a>
                szHtml += "<br/><b>" + Resources.Strings.email + "</b> <a href=\"mailto:" + m_Email + "\">" + m_Email + "</a>";
            }
            if (m_Body != "")
            {
                szHtml += "<h2>" + Resources.Strings.Notes + "</h2>";
                szHtml += m_Body;
            }
            szHtml += "</div>\n";


            //--------------------------------------------------
            // recoger los documentos en los que se cita
            if (!ClsMysql.FncOpen("")) return szHtml;
            string m_SqlSelectDocs = "SELECT tdoclng.DocLngId, tdoclng.DocLngUrlId, DocLngMetaTitle  FROM tdoc LEFT JOIN tdoclng ON tdoc.DocId = tdoclng.DocId where tdoc.DocAcknowledgements like '%##%'";
            m_SqlSelectDocs = m_SqlSelectDocs.Replace("##", m_Title);
            MySqlCommand oCmd = new MySqlCommand(m_SqlSelectDocs, oSqlCnn);

            MySqlDataReader oDR = oCmd.ExecuteReader();
            szHtml += "<h2>" + Resources.Strings.Listofdocumentscollaborates + "</h2>";
            szHtml += "<b>" + Resources.Strings.ExusemeRelationDocuments + "</b>";
            szHtml += "\n<ul class=\"square\">";
            while (oDR.HasRows && oDR.Read())
            {
                szHtml += "\n<li ><a href=\"" + oDR["DocLngUrlId"].ToString() + "\">" + oDR["DocLngMetaTitle"].ToString();
                szHtml += " <img src=\"/a_img/a_site/ico16/flag16_es.gif\"></a>";
                szHtml += "\n</li>";
            }
            szHtml += "\n</ul>";
            oDR.Close();
            oDR.Dispose();

            return szHtml;


        }
        */
        //-------------------------------------------------
       
        //--------------------------------------------------
        #region VALORES_GETSET
   
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
                    _mErrorString = "Trimmed m_Title because is it too long,MaxLength=100";
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

       

        //................................

        public String Email
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 150)
                {
                    sz = sz.Substring(0, 149);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_Email because is it too long,MaxLength=150";
                }
                m_Email = sz;

            }
            get { return m_Email; }
        }

        //................................

        public String UrlExternal
        {
            set
            {
                string sz = value.Trim();//.ToLower() ;
                if (sz.StartsWith("http://"))
                {
                    sz = sz.Replace("http://", "");
                }
                if (sz.Length > 250)
                {
                    sz = sz.Substring(0, 249);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_UrlExternal because is it too long,MaxLength=250";
                }
                m_UrlExternal = sz;

            }
            get { return m_UrlExternal; }
        }

        //................................

      

        //................................

        public bool IsColaborator
        {
            set
            {
                m_IsColaborator = value;
            }
            get { return m_IsColaborator; }
        }

        public bool IsAuthorizeAll
        {
            set
            {
                m_IsAuthorizeAll = value;
            }
            get { return m_IsAuthorizeAll; }
        }

        //................................

        public String CiteName
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 300)
                {
                    sz = sz.Substring(0, 2000);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CiteName because is it too long,MaxLength2000";
                }
                m_CiteName = sz;

            }
            get { return m_CiteName; }
        }

        //................................

        public String CiteFull
        {
            set
            {
                string sz = value.Trim();
                if (sz.Length > 160)
                {
                    sz = sz.Substring(0, 159);
                    _mErrorBoolean = true;
                    _mErrorString = "Trimmed m_CiteFull because is it too long,MaxLength=160";
                }
                m_CiteFull = sz;

            }
            get { return m_CiteFull; }
        }

        //................................

      
        //................................

      

        //................................

        public DateTime PubDateAutorization
        {
            set
            {
                m_PubDateAutorization = value;
            }
            get { return m_PubDateAutorization; }
        }




        #endregion VALORES_GETSET
        //=============================================================
        //==============================================================

        // si existe devuelve el fichero cache.
        public string FncGetCache_Html(bool bRebuild )
        {

            string szFileName = cls.cache.ClsCache.FncCacheFilePath(m_DocId, cls.ClsGlobal.LngIdThread, "acnoelegment");

            if (cls.ClsGlobal.CacheRebuid || bRebuild) { cls.cache.ClsCache.FncCacheFileDelete(szFileName); }

            if (cls.cache.ClsCache.FncCacheFilePathExist(szFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFileName);
            }
            else
            {
                String szHtml = FncHtmlBldCache();

                cls.cache.ClsCache.FncCacheFileSave(ref szFileName, ref szHtml);
                return szHtml;
            }

        }
        /// <summary>
        /// Utiliza Server.HtmlDecode(string) para asignarlo a un label
        /// </summary>
        /// <returns></returns>
        private string FncHtmlBldCache()

        {
            FncCulture_Set(cls.ClsGlobal.LngIdThread);
            oRegDoc.FncSqlFind(m_DocId);
            string szHtml = "";
            //StringBuilder sb = new StringBuilder ();


            szHtml += "<h1 class=\"doctitle\">" + m_Title + "</h1>";
            if (oRegDoc.DocAuthors != "") { szHtml += "<h3> class=\"doctitlesub\">" + oRegDoc.DocAuthors + "</h3>"; }

            szHtml += "<div class=\"divboxAbstract \"><h2>" + Resources.Strings.Abstract + "</h2>";
            if (oRegDoc.DocImgThumbnail != "")
            {
                szHtml += "<img class=\"imgright\"src=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocImgThumbnail + "\"/>";
            }
            szHtml += m_Abstract + "</div>\n";
            szHtml += "<div class=\"divboxArticle\"><h2>" + Resources.Strings.Article + "</h2>" + m_Body + "</div>\n";

            if (oRegDoc.DocDocUploaded != "")
            {
                if (System.IO.File.Exists(ClsGlobal.DirDocStore + oRegDoc.DocDocUploaded))
                {
                    szHtml += "<div class=\"divbox \"><h2>" + Resources.Strings.Anexed_document + "</h2>\n";

                    szHtml += "<a href=\"" + ClsGlobal.UrlDocStore + oRegDoc.DocDocUploaded + "\" ico =\"ico\">" + oRegDoc.DocDocUploaded + "</a>";


                    szHtml += "</div>";
                }

            }

            if (oRegDoc.DocAcknowledgements != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Acknowledgements + "</h2>" + oRegDoc.DocAcknowledgements + "</div>\n");
            }
            if (oRegDoc.DocBibliography != "")
            {
                szHtml += ("<div class=\"divbox \"><h2>" + Resources.Strings.Bibliography + "</h2>" + oRegDoc.DocBibliography + "</div>\n");
            }
            szHtml = cls.tools.ClsGalleryFBox.FncReplacePrettyPhoto(ref szHtml);
            FncCulture_restart();
            return szHtml;


        }

        private void FncCulture_Set(String pCulture)
        {
            String szCulture = "";
            if (pCulture.Length < 2) { pCulture = cls.ClsGlobal.LngIdThread; }

            if (pCulture.Length > 2) { szCulture = pCulture.Substring(0, 2).ToUpper(); }

            if (szCulture == "EN") { pCulture = "EN-us"; }
            else { pCulture = "ES-es"; }
            m_Culture_before = CultureInfo.CurrentCulture.Name;
            m_Culture_Called = pCulture;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(pCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(pCulture);

        }
        private void FncCulture_restart()
        {


            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(m_Culture_before);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(m_Culture_before);

        }
    }
}
