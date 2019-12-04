using System;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.bbdd.itis
{
    //<summary>
    //Descripción breve de ClsRegTaxonomic_units
    //<//summary>
    public class ClsRegTaxonomic_units
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
        private int m_tsn = 0;
        private String m_unit_ind1 = "";
        private String m_unit_name1 = "";
        private String m_unit_ind2 = "";
        private String m_unit_name2 = "";
        private String m_unit_ind3 = "";
        private String m_unit_name3 = "";
        private String m_unit_ind4 = "";
        private String m_unit_name4 = "";
        private String m_unnamed_tortoise_ind = "";
        private String m_usage = "";
        private String m_unaccept_reason = "";
        private String m_credibility_rtng = "";
        private String m_completeness_rtng = "";
        private String m_currency_rating = "";
        private Int16 m_phylo_sort_seq = 0;
        private System.DateTime m_initial_time_stamp = System.DateTime.Now;
        private int m_parent_tsn = 0;
        private int m_tortoise_author_id = 0;
        private int m_hybrid_author_id = 0;
        private Int16 m_kingdom_id = 0;
        private Int16 m_rank_id = 0;
        private System.DateTime m_update_date = System.DateTime.Now.Date;
        private String m_uncertain_prnt_ind = "";
        private String m_name_usage = "";
        private String m_complete_name = "";
        #endregion SQLDEFINICION_VARIABLES
        //------------------------------

        //---------------------------------------------------
        public ClsRegTaxonomic_units(string szMySqlConnectionString)
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
            m_tsn = 0;
            m_unit_ind1 = "";
            m_unit_name1 = "";
            m_unit_ind2 = "";
            m_unit_name2 = "";
            m_unit_ind3 = "";
            m_unit_name3 = "";
            m_unit_ind4 = "";
            m_unit_name4 = "";
            m_unnamed_tortoise_ind = "";
            m_usage = "";
            m_unaccept_reason = "";
            m_credibility_rtng = "";
            m_completeness_rtng = "";
            m_currency_rating = "";
            m_phylo_sort_seq = 0;
            m_initial_time_stamp = System.DateTime.Now;
            m_parent_tsn = 0;
            m_tortoise_author_id = 0;
            m_hybrid_author_id = 0;
            m_kingdom_id = 0;
            m_rank_id = 0;
            m_update_date = System.DateTime.Now.Date;
            m_uncertain_prnt_ind = "";
            m_name_usage = "";
            m_complete_name = "";
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
            szSql = "SELECT * FROM taxonomic_units  ";
            szSql += " WHERE ";
            szSql += "(tsn=@tsn )";

            oSqlCmdSelect.CommandText = szSql;
            oSqlCmdSelect.Parameters.Add("@tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------

            //----------------------------------------------------------------------
            //-------------- COMANDO INSERT ----------------------------------------
            //----------------------------------------------------------------------
            szSql = "INSERT INTO taxonomic_units";

            szSql += "(";

            szSql += " tsn ";
            szSql += ", unit_ind1 ";
            szSql += ", unit_name1 ";
            szSql += ", unit_ind2 ";
            szSql += ", unit_name2 ";
            szSql += ", unit_ind3 ";
            szSql += ", unit_name3 ";
            szSql += ", unit_ind4 ";
            szSql += ", unit_name4 ";
            szSql += ", unnamed_tortoise_ind ";
            szSql += ", usage ";
            szSql += ", unaccept_reason ";
            szSql += ", credibility_rtng ";
            szSql += ", completeness_rtng ";
            szSql += ", currency_rating ";
            szSql += ", phylo_sort_seq ";
            szSql += ", initial_time_stamp ";
            szSql += ", parent_tsn ";
            szSql += ", taxon_author_id ";
            szSql += ", hybrid_author_id ";
            szSql += ", kingdom_id ";
            szSql += ", rank_id ";
            szSql += ", update_date ";
            szSql += ", uncertain_prnt_ind ";
            szSql += ", name_usage ";
            szSql += ", complete_name ";
            szSql += " ) VALUES     (";
            szSql += " @tsn ";
            szSql += ", @unit_ind1 ";
            szSql += ", @unit_name1 ";
            szSql += ", @unit_ind2 ";
            szSql += ", @unit_name2 ";
            szSql += ", @unit_ind3 ";
            szSql += ", @unit_name3 ";
            szSql += ", @unit_ind4 ";
            szSql += ", @unit_name4 ";
            szSql += ", @unnamed_tortoise_ind ";
            szSql += ", @usage ";
            szSql += ", @unaccept_reason ";
            szSql += ", @credibility_rtng ";
            szSql += ", @completeness_rtng ";
            szSql += ", @currency_rating ";
            szSql += ", @phylo_sort_seq ";
            szSql += ", @initial_time_stamp ";
            szSql += ", @parent_tsn ";
            szSql += ", @taxon_author_id ";
            szSql += ", @hybrid_author_id ";
            szSql += ", @kingdom_id ";
            szSql += ", @rank_id ";
            szSql += ", @update_date ";
            szSql += ", @uncertain_prnt_ind ";
            szSql += ", @name_usage ";
            szSql += ", @complete_name ";
            szSql += ")";

            oSqlCmdInsert.CommandText = szSql;
            oSqlCmdInsert.Parameters.Add("@tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@unit_ind1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_name1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_ind2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_name2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_ind3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_name3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_ind4", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unit_name4", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unnamed_tortoise_ind", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@usage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@unaccept_reason", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@credibility_rtng", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@completeness_rtng", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@currency_rating", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@phylo_sort_seq", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@initial_time_stamp", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@parent_tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@hybrid_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdInsert.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdInsert.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdInsert.Parameters.Add("@uncertain_prnt_ind", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@name_usage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdInsert.Parameters.Add("@complete_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO UPDATE ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "UPDATE taxonomic_units SET ";

            szSql += "unit_ind1=@unit_ind1 ";
            szSql += ", unit_name1=@unit_name1 ";
            szSql += ", unit_ind2=@unit_ind2 ";
            szSql += ", unit_name2=@unit_name2 ";
            szSql += ", unit_ind3=@unit_ind3 ";
            szSql += ", unit_name3=@unit_name3 ";
            szSql += ", unit_ind4=@unit_ind4 ";
            szSql += ", unit_name4=@unit_name4 ";
            szSql += ", unnamed_tortoise_ind=@unnamed_tortoise_ind ";
            szSql += ", usage=@usage ";
            szSql += ", unaccept_reason=@unaccept_reason ";
            szSql += ", credibility_rtng=@credibility_rtng ";
            szSql += ", completeness_rtng=@completeness_rtng ";
            szSql += ", currency_rating=@currency_rating ";
            szSql += ", phylo_sort_seq=@phylo_sort_seq ";
            szSql += ", initial_time_stamp=@initial_time_stamp ";
            szSql += ", parent_tsn=@parent_tsn ";
            szSql += ", taxon_author_id=@taxon_author_id ";
            szSql += ", hybrid_author_id=@hybrid_author_id ";
            szSql += ", kingdom_id=@kingdom_id ";
            szSql += ", rank_id=@rank_id ";
            szSql += ", update_date=@update_date ";
            szSql += ", uncertain_prnt_ind=@uncertain_prnt_ind ";
            szSql += ", name_usage=@name_usage ";
            szSql += ", complete_name=@complete_name ";
            szSql += " WHERE ";
            szSql += "(tsn=@tsn )";
            oSqlCmdUpdate.CommandText = szSql;


            oSqlCmdUpdate.Parameters.Add("@tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@unit_ind1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_name1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_ind2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_name2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_ind3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_name3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_ind4", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unit_name4", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unnamed_tortoise_ind", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@usage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@unaccept_reason", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@credibility_rtng", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@completeness_rtng", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@currency_rating", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@phylo_sort_seq", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@initial_time_stamp", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@parent_tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@taxon_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@hybrid_author_id", MySql.Data.MySqlClient.MySqlDbType.Int32);
            oSqlCmdUpdate.Parameters.Add("@kingdom_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@rank_id", MySql.Data.MySqlClient.MySqlDbType.Int16);
            oSqlCmdUpdate.Parameters.Add("@update_date", MySql.Data.MySqlClient.MySqlDbType.DateTime);
            oSqlCmdUpdate.Parameters.Add("@uncertain_prnt_ind", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@name_usage", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            oSqlCmdUpdate.Parameters.Add("@complete_name", MySql.Data.MySqlClient.MySqlDbType.VarChar);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO DELETE  ---------------------------------------
            //----------------------------------------------------------------------
            szSql = "DELETE FROM taxonomic_units  ";
            szSql += " WHERE ";
            szSql += "(tsn=@tsn )";

            oSqlCmdDelete.CommandText = szSql;
            oSqlCmdDelete.Parameters.Add("@tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //-------------- COMANDO SELECT  exist ---------------------------------
            //----------------------------------------------------------------------
            szSql = "SELECT ";
            szSql += " tsn";
            szSql += " FROM taxonomic_units  ";

            szSql += " WHERE ";
            szSql += "(tsn=@tsn )";
            oSqlCmdSelectExist.CommandText = szSql;
            oSqlCmdSelectExist.Parameters.Add("@tsn", MySql.Data.MySqlClient.MySqlDbType.Int32);
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
            oSqlCmdSelectExist.Parameters["@tsn"].Value = m_tsn;

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
            oSqlCmdUpdate.Parameters["@tsn"].Value = m_tsn;
            oSqlCmdUpdate.Parameters["@unit_ind1"].Value = m_unit_ind1;
            oSqlCmdUpdate.Parameters["@unit_name1"].Value = m_unit_name1;
            oSqlCmdUpdate.Parameters["@unit_ind2"].Value = m_unit_ind2;
            oSqlCmdUpdate.Parameters["@unit_name2"].Value = m_unit_name2;
            oSqlCmdUpdate.Parameters["@unit_ind3"].Value = m_unit_ind3;
            oSqlCmdUpdate.Parameters["@unit_name3"].Value = m_unit_name3;
            oSqlCmdUpdate.Parameters["@unit_ind4"].Value = m_unit_ind4;
            oSqlCmdUpdate.Parameters["@unit_name4"].Value = m_unit_name4;
            oSqlCmdUpdate.Parameters["@unnamed_tortoise_ind"].Value = m_unnamed_tortoise_ind;
            oSqlCmdUpdate.Parameters["@usage"].Value = m_usage;
            oSqlCmdUpdate.Parameters["@unaccept_reason"].Value = m_unaccept_reason;
            oSqlCmdUpdate.Parameters["@credibility_rtng"].Value = m_credibility_rtng;
            oSqlCmdUpdate.Parameters["@completeness_rtng"].Value = m_completeness_rtng;
            oSqlCmdUpdate.Parameters["@currency_rating"].Value = m_currency_rating;
            oSqlCmdUpdate.Parameters["@phylo_sort_seq"].Value = m_phylo_sort_seq;
            oSqlCmdUpdate.Parameters["@initial_time_stamp"].Value = m_initial_time_stamp;
            oSqlCmdUpdate.Parameters["@parent_tsn"].Value = m_parent_tsn;
            oSqlCmdUpdate.Parameters["@taxon_author_id"].Value = m_tortoise_author_id;
            oSqlCmdUpdate.Parameters["@hybrid_author_id"].Value = m_hybrid_author_id;
            oSqlCmdUpdate.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdUpdate.Parameters["@rank_id"].Value = m_rank_id;
            oSqlCmdUpdate.Parameters["@update_date"].Value = m_update_date;
            oSqlCmdUpdate.Parameters["@uncertain_prnt_ind"].Value = m_uncertain_prnt_ind;
            oSqlCmdUpdate.Parameters["@name_usage"].Value = m_name_usage;
            oSqlCmdUpdate.Parameters["@complete_name"].Value = m_complete_name;
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
            oSqlCmdInsert.Parameters["@tsn"].Value = m_tsn;
            oSqlCmdInsert.Parameters["@unit_ind1"].Value = m_unit_ind1;
            oSqlCmdInsert.Parameters["@unit_name1"].Value = m_unit_name1;
            oSqlCmdInsert.Parameters["@unit_ind2"].Value = m_unit_ind2;
            oSqlCmdInsert.Parameters["@unit_name2"].Value = m_unit_name2;
            oSqlCmdInsert.Parameters["@unit_ind3"].Value = m_unit_ind3;
            oSqlCmdInsert.Parameters["@unit_name3"].Value = m_unit_name3;
            oSqlCmdInsert.Parameters["@unit_ind4"].Value = m_unit_ind4;
            oSqlCmdInsert.Parameters["@unit_name4"].Value = m_unit_name4;
            oSqlCmdInsert.Parameters["@unnamed_tortoise_ind"].Value = m_unnamed_tortoise_ind;
            oSqlCmdInsert.Parameters["@usage"].Value = m_usage;
            oSqlCmdInsert.Parameters["@unaccept_reason"].Value = m_unaccept_reason;
            oSqlCmdInsert.Parameters["@credibility_rtng"].Value = m_credibility_rtng;
            oSqlCmdInsert.Parameters["@completeness_rtng"].Value = m_completeness_rtng;
            oSqlCmdInsert.Parameters["@currency_rating"].Value = m_currency_rating;
            oSqlCmdInsert.Parameters["@phylo_sort_seq"].Value = m_phylo_sort_seq;
            oSqlCmdInsert.Parameters["@initial_time_stamp"].Value = m_initial_time_stamp;
            oSqlCmdInsert.Parameters["@parent_tsn"].Value = m_parent_tsn;
            oSqlCmdInsert.Parameters["@taxon_author_id"].Value = m_tortoise_author_id;
            oSqlCmdInsert.Parameters["@hybrid_author_id"].Value = m_hybrid_author_id;
            oSqlCmdInsert.Parameters["@kingdom_id"].Value = m_kingdom_id;
            oSqlCmdInsert.Parameters["@rank_id"].Value = m_rank_id;
            oSqlCmdInsert.Parameters["@update_date"].Value = m_update_date;
            oSqlCmdInsert.Parameters["@uncertain_prnt_ind"].Value = m_uncertain_prnt_ind;
            oSqlCmdInsert.Parameters["@name_usage"].Value = m_name_usage;
            oSqlCmdInsert.Parameters["@complete_name"].Value = m_complete_name;
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
        public bool FncSqlFind(int tsn)
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
            oSqlCmdSelect.Parameters["@tsn"].Value = tsn;
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
                    m_tsn = Convert.ToInt32(oDR["tsn"].ToString());
                    m_unit_ind1 = oDR["unit_ind1"].ToString();
                    m_unit_name1 = oDR["unit_name1"].ToString();
                    m_unit_ind2 = oDR["unit_ind2"].ToString();
                    m_unit_name2 = oDR["unit_name2"].ToString();
                    m_unit_ind3 = oDR["unit_ind3"].ToString();
                    m_unit_name3 = oDR["unit_name3"].ToString();
                    m_unit_ind4 = oDR["unit_ind4"].ToString();
                    m_unit_name4 = oDR["unit_name4"].ToString();
                    m_unnamed_tortoise_ind = oDR["unnamed_tortoise_ind"].ToString();
                    m_usage = oDR["usage"].ToString();
                    m_unaccept_reason = oDR["unaccept_reason"].ToString();
                    m_credibility_rtng = oDR["credibility_rtng"].ToString();
                    m_completeness_rtng = oDR["completeness_rtng"].ToString();
                    m_currency_rating = oDR["currency_rating"].ToString();
                    m_phylo_sort_seq = Convert.ToInt16(oDR["phylo_sort_seq"].ToString());
                    m_initial_time_stamp = Convert.ToDateTime(oDR["initial_time_stamp"].ToString());
                    m_parent_tsn = Convert.ToInt32(oDR["parent_tsn"].ToString());
                    m_tortoise_author_id = Convert.ToInt32(oDR["taxon_author_id"].ToString());
                    m_hybrid_author_id = Convert.ToInt32(oDR["hybrid_author_id"].ToString());
                    m_kingdom_id = Convert.ToInt16(oDR["kingdom_id"].ToString());
                    m_rank_id = Convert.ToInt16(oDR["rank_id"].ToString());
                    m_update_date = Convert.ToDateTime(oDR["update_date"].ToString());
                    m_uncertain_prnt_ind = oDR["uncertain_prnt_ind"].ToString();
                    m_name_usage = oDR["name_usage"].ToString();
                    m_complete_name = oDR["complete_name"].ToString();
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
        public bool FncSqlDelete(int tsn)
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
                oSqlCmdDelete.Parameters["@tsn"].Value = tsn;
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

        public int tsn
        {
            set
            {
                m_tsn = value;
            }
            get { return m_tsn; }
        }

        //................................

        public String unit_ind1
        {
            set
            {
                m_unit_ind1 = value;
            }
            get { return m_unit_ind1; }
        }

        //................................

        public String unit_name1
        {
            set
            {
                m_unit_name1 = value;
            }
            get { return m_unit_name1; }
        }

        //................................

        public String unit_ind2
        {
            set
            {
                m_unit_ind2 = value;
            }
            get { return m_unit_ind2; }
        }

        //................................

        public String unit_name2
        {
            set
            {
                m_unit_name2 = value;
            }
            get { return m_unit_name2; }
        }

        //................................

        public String unit_ind3
        {
            set
            {
                m_unit_ind3 = value;
            }
            get { return m_unit_ind3; }
        }

        //................................

        public String unit_name3
        {
            set
            {
                m_unit_name3 = value;
            }
            get { return m_unit_name3; }
        }

        //................................

        public String unit_ind4
        {
            set
            {
                m_unit_ind4 = value;
            }
            get { return m_unit_ind4; }
        }

        //................................

        public String unit_name4
        {
            set
            {
                m_unit_name4 = value;
            }
            get { return m_unit_name4; }
        }

        //................................

        public String unnamed_tortoise_ind
        {
            set
            {
                m_unnamed_tortoise_ind = value;
            }
            get { return m_unnamed_tortoise_ind; }
        }

        //................................

        public String usage
        {
            set
            {
                m_usage = value;
            }
            get { return m_usage; }
        }

        //................................

        public String unaccept_reason
        {
            set
            {
                m_unaccept_reason = value;
            }
            get { return m_unaccept_reason; }
        }

        //................................

        public String credibility_rtng
        {
            set
            {
                m_credibility_rtng = value;
            }
            get { return m_credibility_rtng; }
        }

        //................................

        public String completeness_rtng
        {
            set
            {
                m_completeness_rtng = value;
            }
            get { return m_completeness_rtng; }
        }

        //................................

        public String currency_rating
        {
            set
            {
                m_currency_rating = value;
            }
            get { return m_currency_rating; }
        }

        //................................

        public Int16 phylo_sort_seq
        {
            set
            {
                m_phylo_sort_seq = value;
            }
            get { return m_phylo_sort_seq; }
        }

        //................................

        public System.DateTime initial_time_stamp
        {
            set
            {
                m_initial_time_stamp = value;
            }
            get { return m_initial_time_stamp; }
        }

        //................................

        public int parent_tsn
        {
            set
            {
                m_parent_tsn = value;
            }
            get { return m_parent_tsn; }
        }

        //................................

        public int taxon_author_id
        {
            set
            {
                m_tortoise_author_id = value;
            }
            get { return m_tortoise_author_id; }
        }

        //................................

        public int hybrid_author_id
        {
            set
            {
                m_hybrid_author_id = value;
            }
            get { return m_hybrid_author_id; }
        }

        //................................

        public Int16 kingdom_id
        {
            set
            {
                m_kingdom_id = value;
            }
            get { return m_kingdom_id; }
        }

        //................................

        public Int16 rank_id
        {
            set
            {
                m_rank_id = value;
            }
            get { return m_rank_id; }
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

        //................................

        public String uncertain_prnt_ind
        {
            set
            {
                m_uncertain_prnt_ind = value;
            }
            get { return m_uncertain_prnt_ind; }
        }

        //................................

        public String name_usage
        {
            set
            {
                m_name_usage = value;
            }
            get { return m_name_usage; }
        }

        //................................

        public String complete_name
        {
            set
            {
                m_complete_name = value;
            }
            get { return m_complete_name; }
        }

        #endregion VALORES_GETSET

    }
}
