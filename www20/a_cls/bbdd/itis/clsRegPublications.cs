using System;
using MySql.Data.MySqlClient;
using System.Data;
using testudines.cls.bbdd;
namespace testudines.cls.bbdd.itis
{
    //<summary>
    //Descripción breve de ClsRegPublications
    //<//summary>
    public class ClsRegPublications
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
        private String m_pub_id_prefix = "";
        private int m_publication_id = 0;
        private String m_reference_author = "";
        private String m_title = "";
        private String m_publication_name = "";
        private System.DateTime m_listed_pub_date = System.DateTime.Now.Date;
        private System.DateTime m_actual_pub_date = System.DateTime.Now.Date;
        private String m_publisher = "";
        private String m_pub_place = "";
        private String m_isbn = "";
        private String m_issn = "";
        private String m_pages = "";
        private String m_pub_comment = "";
        private System.DateTime m_update_date = System.DateTime.Now.Date;
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegPublications(string szMySqlConnectionString)
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
            m_pub_id_prefix = "";
            m_publication_id = 0;
            m_reference_author = "";
            m_title = "";
            m_publication_name = "";
            m_listed_pub_date = System.DateTime.Now.Date;
            m_actual_pub_date = System.DateTime.Now.Date;
            m_publisher = "";
            m_pub_place = "";
            m_isbn = "";
            m_issn = "";
            m_pages = "";
            m_pub_comment = "";
            m_update_date = System.DateTime.Now.Date;
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
            szSql = "SELECT * FROM publications  ";
            szSql += " WHERE ";
            szSql += "(pub_id_prefix=@pub_id_prefix )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@pub_id_prefix", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO publications";

            szSql += "(";

            szSql += " pub_id_prefix ";
            szSql += ", publication_id ";
            szSql += ", reference_author ";
            szSql += ", title ";
            szSql += ", publication_name ";
            szSql += ", listed_pub_date ";
            szSql += ", actual_pub_date ";
            szSql += ", publisher ";
            szSql += ", pub_place ";
            szSql += ", isbn ";
            szSql += ", issn ";
            szSql += ", pages ";
            szSql += ", pub_comment ";
            szSql += ", update_date ";
            szSql += " ) VALUES     (";
            szSql += " @pub_id_prefix ";
            szSql += ", @publication_id ";
            szSql += ", @reference_author ";
            szSql += ", @title ";
            szSql += ", @publication_name ";
            szSql += ", @listed_pub_date ";
            szSql += ", @actual_pub_date ";
            szSql += ", @publisher ";
            szSql += ", @pub_place ";
            szSql += ", @isbn ";
            szSql += ", @issn ";
            szSql += ", @pages ";
            szSql += ", @pub_comment ";
            szSql += ", @update_date ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@pub_id_prefix", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@publication_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@reference_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@title", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@publication_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@listed_pub_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@actual_pub_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@publisher", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@pub_place", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@isbn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@issn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@pages", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@pub_comment", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE publications SET ";

            szSql += "publication_id=@publication_id ";
            szSql += ", reference_author=@reference_author ";
            szSql += ", title=@title ";
            szSql += ", publication_name=@publication_name ";
            szSql += ", listed_pub_date=@listed_pub_date ";
            szSql += ", actual_pub_date=@actual_pub_date ";
            szSql += ", publisher=@publisher ";
            szSql += ", pub_place=@pub_place ";
            szSql += ", isbn=@isbn ";
            szSql += ", issn=@issn ";
            szSql += ", pages=@pages ";
            szSql += ", pub_comment=@pub_comment ";
            szSql += ", update_date=@update_date ";
            szSql += " WHERE ";
            szSql += "(pub_id_prefix=@pub_id_prefix )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@pub_id_prefix", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@publication_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@reference_author", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@title", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@publication_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@listed_pub_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@actual_pub_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@publisher", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@pub_place", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@isbn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@issn", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@pages", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@pub_comment", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM publications  ";
            szSql += " WHERE ";
            szSql += "(pub_id_prefix=@pub_id_prefix )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@pub_id_prefix", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " pub_id_prefix";
            szSql += " FROM publications  ";

            szSql += " WHERE ";
            szSql += "(pub_id_prefix=@pub_id_prefix )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@pub_id_prefix", MySql.Data.MySqlClient.MySqlDbType.VarChar);
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
            if (!cls.bbdd.ClsMysql.FncOpen())
                return false;

            // comprobar si existe el id a añadir
            oSqlCmdSelectExist.Parameters["@pub_id_prefix"].Value = m_pub_id_prefix;

            oSqlCmdSelectExist.Connection = cls.bbdd.ClsMysql.MySqlConnection;
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
            oSqlCmdUpdate.Parameters["@pub_id_prefix"].Value = m_pub_id_prefix;
            oSqlCmdUpdate.Parameters["@publication_id"].Value = m_publication_id;
            oSqlCmdUpdate.Parameters["@reference_author"].Value = m_reference_author;
            oSqlCmdUpdate.Parameters["@title"].Value = m_title;
            oSqlCmdUpdate.Parameters["@publication_name"].Value = m_publication_name;
            oSqlCmdUpdate.Parameters["@listed_pub_date"].Value = m_listed_pub_date;
            oSqlCmdUpdate.Parameters["@actual_pub_date"].Value = m_actual_pub_date;
            oSqlCmdUpdate.Parameters["@publisher"].Value = m_publisher;
            oSqlCmdUpdate.Parameters["@pub_place"].Value = m_pub_place;
            oSqlCmdUpdate.Parameters["@isbn"].Value = m_isbn;
            oSqlCmdUpdate.Parameters["@issn"].Value = m_issn;
            oSqlCmdUpdate.Parameters["@pages"].Value = m_pages;
            oSqlCmdUpdate.Parameters["@pub_comment"].Value = m_pub_comment;
            oSqlCmdUpdate.Parameters["@update_date"].Value = m_update_date;
            //-----------------------------------------------------;
            //            ACTUALIZAR 
            //-------------------------------------------------------;
            oSqlCmdUpdate.Connection = cls.bbdd.ClsMysql.MySqlConnection;
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
            oSqlCmdInsert.Parameters["@pub_id_prefix"].Value = m_pub_id_prefix;
            oSqlCmdInsert.Parameters["@publication_id"].Value = m_publication_id;
            oSqlCmdInsert.Parameters["@reference_author"].Value = m_reference_author;
            oSqlCmdInsert.Parameters["@title"].Value = m_title;
            oSqlCmdInsert.Parameters["@publication_name"].Value = m_publication_name;
            oSqlCmdInsert.Parameters["@listed_pub_date"].Value = m_listed_pub_date;
            oSqlCmdInsert.Parameters["@actual_pub_date"].Value = m_actual_pub_date;
            oSqlCmdInsert.Parameters["@publisher"].Value = m_publisher;
            oSqlCmdInsert.Parameters["@pub_place"].Value = m_pub_place;
            oSqlCmdInsert.Parameters["@isbn"].Value = m_isbn;
            oSqlCmdInsert.Parameters["@issn"].Value = m_issn;
            oSqlCmdInsert.Parameters["@pages"].Value = m_pages;
            oSqlCmdInsert.Parameters["@pub_comment"].Value = m_pub_comment;
            oSqlCmdInsert.Parameters["@update_date"].Value = m_update_date;
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
        public bool FncSqlFind(String pub_id_prefix)
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
            oSqlCmdSelect.Parameters["@pub_id_prefix"].Value = pub_id_prefix;
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
                    m_pub_id_prefix = oDR["pub_id_prefix"].ToString();
                    m_publication_id = Convert.ToInt32(oDR["publication_id"].ToString());
                    m_reference_author = oDR["reference_author"].ToString();
                    m_title = oDR["title"].ToString();
                    m_publication_name = oDR["publication_name"].ToString();
                    m_listed_pub_date = Convert.ToDateTime(oDR["listed_pub_date"].ToString());
                    m_actual_pub_date = Convert.ToDateTime(oDR["actual_pub_date"].ToString());
                    m_publisher = oDR["publisher"].ToString();
                    m_pub_place = oDR["pub_place"].ToString();
                    m_isbn = oDR["isbn"].ToString();
                    m_issn = oDR["issn"].ToString();
                    m_pages = oDR["pages"].ToString();
                    m_pub_comment = oDR["pub_comment"].ToString();
                    m_update_date = Convert.ToDateTime(oDR["update_date"].ToString());
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
        public bool FncSqlDelete(String pub_id_prefix)
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
                oSqlCmdDelete.Parameters["@pub_id_prefix"].Value = pub_id_prefix;
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

        ////--------------------------------------------------------r
        ////----------------FncSqlOpenCnn--------------------------
        ////--------------------------------------------------------


        //--------------------------------------------------
        #region VALORES_GETSET
        //--------------------------------------------------
        public string MySqlConnectionString
        {
            set { _mMySqlConnectionString = value; }
            get { return _mMySqlConnectionString; }
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

        public String pub_id_prefix
        {
            set
            {
                m_pub_id_prefix = value;
            }
            get { return m_pub_id_prefix; }
        }

        //................................

        public int publication_id
        {
            set
            {
                m_publication_id = value;
            }
            get { return m_publication_id; }
        }

        //................................

        public String reference_author
        {
            set
            {
                m_reference_author = value;
            }
            get { return m_reference_author; }
        }

        //................................

        public String title
        {
            set
            {
                m_title = value;
            }
            get { return m_title; }
        }

        //................................

        public String publication_name
        {
            set
            {
                m_publication_name = value;
            }
            get { return m_publication_name; }
        }

        //................................

        public System.DateTime listed_pub_date
        {
            set
            {
                m_listed_pub_date = value;
            }
            get { return m_listed_pub_date; }
        }

        //................................

        public System.DateTime actual_pub_date
        {
            set
            {
                m_actual_pub_date = value;
            }
            get { return m_actual_pub_date; }
        }

        //................................

        public String publisher
        {
            set
            {
                m_publisher = value;
            }
            get { return m_publisher; }
        }

        //................................

        public String pub_place
        {
            set
            {
                m_pub_place = value;
            }
            get { return m_pub_place; }
        }

        //................................

        public String isbn
        {
            set
            {
                m_isbn = value;
            }
            get { return m_isbn; }
        }

        //................................

        public String issn
        {
            set
            {
                m_issn = value;
            }
            get { return m_issn; }
        }

        //................................

        public String pages
        {
            set
            {
                m_pages = value;
            }
            get { return m_pages; }
        }

        //................................

        public String pub_comment
        {
            set
            {
                m_pub_comment = value;
            }
            get { return m_pub_comment; }
        }

        //................................

        public System.DateTime update_date
        {
            set
            {
                m_update_date = value;
            }
            get { return m_update_date; }
        }

        #endregion VALORES_GETSET

    }
}
