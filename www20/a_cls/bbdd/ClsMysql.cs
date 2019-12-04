using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;



namespace testudines.cls.bbdd
{
    public static class ClsMysql  
    {

        private static MySqlConnection m_MySqlConnection = new MySqlConnection()  ;
        private static bool   m_ErrorBoolean=false;
        private static String m_MySqlConnectionString = "";
        
        private static  string m_ErrorString="";
        public static string ErrorString { get { return m_ErrorString; } }
        public static MySqlConnection MySqlConnection { get { return m_MySqlConnection; } set { m_MySqlConnection = value; } }
        public static String MySqlConnectionString { get { return m_MySqlConnectionString; } set { m_MySqlConnectionString = value; } }

        /// <summary>
        /// Se conecta al servidor mysql mariadb
        /// </summary>
        /// <param name="pConnectionString">Por omission toma el valor cls.ClsGlobal.Connection_MARIADB</param>
        /// <returns></returns>
        public static bool FncOpen(String pConnectionString ="" )
        {
            m_MySqlConnectionString = cls.ClsGlobal.Connection_MARIADB;
            if (pConnectionString != "") { m_MySqlConnectionString = pConnectionString; }
            m_ErrorBoolean = false;
                m_ErrorString = "";
                //-----------------------------------------------------
                //            ABRIR CONEXION
                //-------------------------------------------------------
                if (m_MySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    return !m_ErrorBoolean;
                }
               m_MySqlConnection.ConnectionString = m_MySqlConnectionString;
                try
                {
                m_MySqlConnection.Open();
                }
                catch (SystemException ex)
                {
                    m_ErrorBoolean = true;
                    m_ErrorString = ex.ToString();
                m_MySqlConnection.Close();
                }

                return !m_ErrorBoolean;
            
        }
            
        public static bool FncClose()
        {
           
                 m_ErrorBoolean = false;
                 m_ErrorString = "";
                 if (m_MySqlConnection.State == System.Data.ConnectionState.Open)
                 {

                     try
                     {
                    m_MySqlConnection.Close();
                     }
                     catch (SystemException ex)
                     {
                         m_ErrorBoolean = true;
                         m_ErrorString = ex.ToString();
                     }
                 }
                return !m_ErrorBoolean ;
           
        }

        /// <summary>
        /// devuelve el estado de la coneion que puede ser:
        /// Open, Closed, Broken, Connecting, Executing, Fetching  ;
        /// </summary>
        public static string Status
        {

            get
            { 
                  return  (m_MySqlConnection.State.ToString ());
                //System.Data.ConnectionState.Open.;
               
            }
        }
        public static bool IsExist(String szTableName, UInt64 pDocId)
        {
            bool bOk = true;
            String szSqlCmd = "Select DocId from " + szTableName + " where DocId=" + pDocId.ToString() ;
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, ClsMysql.MySqlConnection);

            try
            {
                FncOpen();
                string getValue = oCmd.ExecuteScalar().ToString();
                if (getValue != null)
                {
                    bOk = true;
                }
                else
                { bOk = false; }
            }
            catch
            {
                bOk = false;
            }
            finally
            {
                oCmd.Dispose();

              
            }
            return bOk;
        }
        public static bool IsExist(String szTableName, UInt64 pDocId, String pLng)
        {
            bool bOk = true;
            //Select DocId from tdoclng_articles where DocId=0 and DocLngId=es
            String szSqlCmd = "Select DocId from " + szTableName + " where DocId=" + pDocId.ToString() + " and DocLngId='" + pLng+"'";
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, ClsMysql.MySqlConnection);
            try
            {
                FncOpen();
                string getValue = oCmd.ExecuteScalar().ToString();
                if (getValue != null)
                {
                    bOk = true;
                }
                else
                { bOk = false; }
            }
            catch
            {
                bOk = false;
            }
            finally
            {
                oCmd.Dispose();
               
                
            }
            return bOk;
        }
        
        public static MySqlDataReader FncFil_datareader (ref String szSqlCmd)
        {
            m_ErrorBoolean = false;
            m_ErrorString = "";
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, m_MySqlConnection);
            MySqlDataReader oRd = oCmd.ExecuteReader();
            try
            {
                FncOpen();
                oRd = oCmd.ExecuteReader();

            }
            catch (SystemException ex)
            {
                m_ErrorBoolean = true;
                m_ErrorString = ex.ToString();
                m_ErrorBoolean = true;
            }
            oCmd.Dispose();

            return oRd;
        }
        public static bool FncFill_datatable (ref String szSqlCmd, ref DataTable oTb)

        {
            m_ErrorBoolean = false;
            m_ErrorString = "";

            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, m_MySqlConnection);
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
            try
            {
                FncOpen();
                oDA.Fill(oTb);

            }
            catch (SystemException ex)
            {
                m_ErrorBoolean = true;
                m_ErrorString = ex.ToString();
                m_ErrorBoolean = true;
            }
            finally
            {
                oCmd.Dispose();
               
                oDA.Dispose();
                
            }

            return !m_ErrorBoolean; 
        }
        /// <summary>
        /// Return value firstcolumn as String
        /// </summary>
        /// <param name="szSqlCmd"></param>
        /// <returns>String value firs column o "" is not found</returns>
        public static String FncGet_ExecuteScalar(ref String szSqlCmd)
        {
            string sz = "";
            m_ErrorBoolean = false;
            m_ErrorString = "";

            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, m_MySqlConnection);
         
            try
            {
                FncOpen();
                sz=oCmd.ExecuteScalar().ToString(); ;

            }
            catch (SystemException ex)
            {
                m_ErrorBoolean = true;
                m_ErrorString = ex.ToString();
                m_ErrorBoolean = true;
            }
            finally
            {
                oCmd.Dispose();
             
               
            }

            return sz;

        }
        /// <summary>
        /// Execute non query, usually for insert, delete, or update
        /// </summary>
        /// <param name="szSqlCmd"></param>
        /// <returns>Number afecctd rows
        /// </returns>
        public static Int32 FncGet_ExecuteNonQuery(ref String szSqlCmd)
        {
            Int32 ICount = 0;
            m_ErrorBoolean = false;
            m_ErrorString = "";

            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, m_MySqlConnection);

            try
            {
                FncOpen();
                ICount = oCmd.ExecuteNonQuery() ;

            }
            catch (SystemException ex)
            {
                m_ErrorBoolean = true;
                m_ErrorString = ex.ToString();
                m_ErrorBoolean = true;
            }
            finally
            {
                oCmd.Dispose();

            }

            return ICount;

        }
    }
}