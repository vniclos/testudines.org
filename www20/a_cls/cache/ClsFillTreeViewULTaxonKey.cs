using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient ;
using System.IO ;
namespace  testudines.cls.cache
{
    public class ClsFillTreeViewULTaxonKey
    {
        private string m_htmlEN="";
        private string m_htmlENAdmin = "";
        private string m_htmlLNG = "";
        private string m_htmlLNGAdmin = "";
        private cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oRegKeysLng = new cls.bbdd.ClsReg_tdoclng_testudineskeys_lng(); 
        
        private int    m_iLevel = 0;
        private string m_iLevelTab="";
        private string m_szFileEN="";
        private string m_szFileENAdmin = "";
        private string m_szFileLNG = "";
        private string m_szFileLNGAdmin = "";

        private bool  m_IsAdmin = false;
        private string m_SqlCmdSelect = "select tdoclng_testudines_keys.DocId as DocId, TOWNodeId,  TOWNodeParentId ,TOWDescription, tdoclng_testudines_keys_lng.Description, '' as tag, '' as NodePath, '' as NodeFullPathList,  TOWTaxaGroupLevel,TOWTaxaGroupName,TOWTaxaURL from  tdoclng_testudines_keys  LEFT JOIN tdoclng_testudines_keys_lng  ON tdoclng_testudines_keys.DocId = tdoclng_testudines_keys_lng.DocId ";
        private string m_SqlCmdWhere =" where tdoclng_testudines_keys_lng.DocLngId='en'";
        private string m_SqlCmdOrder = " order by  TOWNodeParentId, TOWNodeId ";
        private string m_SqlCmdWhereLng = "en";
        MySqlDataAdapter m_oSqlDA = new MySqlDataAdapter();

        MySqlConnection m_oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB); //providerName= MySql.Data.MySqlClient; CharSet=UTF8;
        MySqlCommand m_oSqlCmd = new MySqlCommand();
        DataTable m_DT = new DataTable();
        public ClsFillTreeViewULTaxonKey()
        {
           
            
        }

        #region RegFnc_HtmlULTreeView
        public string  Fnc_HtmlULTreeView(bool bRewriteCache, string szIdLng,bool IsAdmin)
        {
            m_SqlCmdWhereLng = szIdLng;
            m_IsAdmin = IsAdmin;
            m_oSqlCmd.Connection = m_oSqlCnn;
          
           m_szFileEN = cls.ClsGlobal.DirCache + "EN_tortoise_keys.html";
           m_szFileLNG = cls.ClsGlobal.DirCache + szIdLng + "_tortoise_keys.html";
           m_szFileLNGAdmin = cls.ClsGlobal.DirCache + szIdLng + "_tortoise_keys_admin.html";
           m_szFileENAdmin = cls.ClsGlobal.DirCache + "EN_tortoise_keys_admin.html";
           m_htmlLNG = "";
           m_htmlEN = "";
           m_htmlENAdmin = "";
           m_htmlLNGAdmin = "";
           // controlar cache, leer de fichero o rehacer

              try
            {
                if (bRewriteCache)
                {
                    System.IO.File.Delete(m_szFileEN);
                    System.IO.File.Delete(m_szFileENAdmin);
                    System.IO.File.Delete(m_szFileLNG);
                    System.IO.File.Delete(m_szFileLNGAdmin);
           
                }
                else
                {
                    // si existe el cache lo carga sino sigue el proceso creando uno nuevo.
                    if (System.IO.File.Exists(m_szFileLNG) && !m_IsAdmin)
                    {
                        StreamReader oSReader = new StreamReader(m_szFileLNG);
                        m_htmlLNG = oSReader.ReadToEnd();
                        oSReader.Dispose();
                        return m_htmlLNG;
                    }
                    if (System.IO.File.Exists(m_szFileLNGAdmin) && m_IsAdmin)
                    {
                        StreamReader oSReader = new StreamReader(m_szFileLNGAdmin);
                        m_htmlLNG = oSReader.ReadToEnd();
                        oSReader.Dispose();
                        return m_htmlLNG;
                    }

                
                }
            }
            catch { }

            //--------------------------------------------



              DataTable PrSet = Fnc_HtmlULTreeViewChildsFromDDBB("", szIdLng);// rellenar rooo
            //TreeNode tnRoot = new TreeNode("Testudines");
            //tnRoot.Expand();
            //scnBtnUlFill.Nodes.Add(tnRoot);
            
            string szDescription="";
            string szDescriptionTow = "";
            string szId = "";
            string szDocId = "";
            string szParentId = "";
            string szTaxaGroupLevel = "";
            string szTaxaGroupName = "";
            string szTaxaURL = "";
            
            m_htmlEN = "";
            m_htmlEN += "<div class=\"panel\">\n<a href=\"" + szTaxaURL + "\"><b>" + "Derrivado de Turtles of the World. C.H. Ernst, R.G.M. Altenburg & R.W. Barbour. CITES Identification Guide – Turtles & Tortoises. y otros documentos</b></a>\n";
            m_htmlEN += "\n<p><b>¡Atencion !</b> Estoy desarrollando esta pagina, y no es fiable del todo por el momento.</p>\n";
            m_htmlEN += "\n<p><b>Falta</b>, Traducir, adaptar, crear imagenes descriptivas, crear herramienta de guia para la identificacion, Ligar a los documentos CITES.... etc</p>\n";
            m_htmlEN += "\n</div>";
            //m_htmlEN += "\n<div id=\"sidetreecontrol\">";
            //m_htmlEN += "\n<a href=\"?#\">Collapse All</a> | <a href=\"?#\">Expand All</a></div>";
            
            m_iLevel = 0;
            m_htmlEN += "\n<div class=\"tree\">";
            m_htmlEN += "\n<ul>\n";
            m_htmlEN += "\n<li><a>Testudines Level-S" + m_iLevel.ToString() + "</a>\n<ul>";
            string szAdmin= "<a class=\"button tiny\"  href=\"tortoises/keys/keys-mng-list.aspx\">" + Resources.Strings.Administration + "</a>";
            m_htmlENAdmin =szAdmin+ m_htmlEN;
            m_htmlLNG = m_htmlEN;
            m_htmlLNGAdmin = szAdmin + m_htmlEN;
            
            //--------------------------------------------------------------------
            string szTmpNode = "";
            foreach (DataRow dr in PrSet.Rows)
            {
                string sz = dr["TOWNodeParentId"].ToString();
               
                if (sz == "00000")
                {
                    m_iLevel++;
       
                    szDescriptionTow = dr["TOWDescription"].ToString();
                    szDescription = dr["Description"].ToString();

                    szDocId = dr["DocId"].ToString();
                    szId = dr["TOWNodeId"].ToString();
                    szParentId = dr["TOWNodeParentId"].ToString();
                    szTaxaGroupLevel = dr["TOWTaxaGroupLevel"].ToString();
                    szTaxaGroupName = dr["TOWTaxaGroupName"].ToString();
                    szTaxaURL = dr["TOWTaxaURL"].ToString();
                    Fnc_HtmlULTreeViewLiFill(szDocId,szParentId, szId, szDescription, szTaxaGroupLevel, szTaxaGroupName, szTaxaURL);
                    Fnc_HtmlULTreeViewChilds(szId,szIdLng);
                    szTmpNode = "\n<span style=\"color:red\">Level-E000-" + m_iLevel.ToString() + " x</span></li>\n";
                    m_htmlEN += szTmpNode;
                    m_htmlENAdmin += szTmpNode;
                    m_htmlLNG += szTmpNode;
                    m_htmlLNGAdmin += szTmpNode;
                    m_iLevel--;
                }
                
            }

            szTmpNode = "\n<span style=\"color:red\">Level-E" + m_iLevel.ToString() + " y</span></li></ul></div>\n<h1>END</h1>";
            m_htmlEN += szTmpNode;
            m_htmlENAdmin += szTmpNode;
          
          
           // guardar cache de ul list generada
            if (System.IO.File.Exists(m_szFileEN)) System.IO.File.Delete(m_szFileEN);
            if (System.IO.File.Exists(m_szFileENAdmin)) System.IO.File.Delete(m_szFileENAdmin);

            using (StreamWriter myFile = new StreamWriter(m_szFileEN))
            {
                myFile.Write(m_htmlEN + m_szFileEN);
                myFile.Close();
                myFile.Dispose (); 
            }

            using (StreamWriter myFile2 = new StreamWriter(m_szFileENAdmin))
            {
                myFile2.Write(m_htmlENAdmin + m_szFileENAdmin);
                myFile2.Close();
                myFile2.Dispose();
            }
            if (m_SqlCmdWhereLng != "en")
            {
                using (StreamWriter myFile3 = new StreamWriter(m_szFileLNG))
                {
                    myFile3.Write(m_htmlLNG + m_szFileLNG);
                    myFile3.Close();
                    myFile3.Dispose();
                }

                using (StreamWriter myFile4 = new StreamWriter(m_szFileLNGAdmin))
                {
                    myFile4.Write(m_htmlLNGAdmin + m_szFileLNGAdmin);
                    myFile4.Close();
                    myFile4.Dispose();
                }
            }
            m_oSqlCmd.Dispose();
            cls.bbdd.ClsMysql.FncClose();
          
            //oSqlCnn.Dispose();

            if (m_IsAdmin & m_SqlCmdWhereLng =="en") return m_htmlENAdmin; 
            if (!m_IsAdmin & m_SqlCmdWhereLng =="en") return m_htmlEN;
            if (m_IsAdmin ) return m_htmlLNGAdmin; 
            if (!m_IsAdmin)  return m_htmlLNG;
            return m_htmlEN;
        }
        private void  Fnc_HtmlULTreeViewLiFill(string szDocId, string szParentId, string szId, string szDescriptionEN, string szTaxaGroupLevel, string szTaxaGroupName, string szTaxaURL)
        {
            string szLi1 = "";
            string szLi2 = "";
            szDescriptionEN = szDescriptionEN.Replace(",", ",<br/>").Replace(";", ";<br/>");
            string szDescriptionLNG = "";
            if (m_SqlCmdWhereLng != "en")
            {
                if (oRegKeysLng.FncSqlFind(Convert.ToUInt64(szDocId), m_SqlCmdWhereLng))
                {
                    szDescriptionLNG = oRegKeysLng.Description.Replace(",", ",<br/>").Replace(";", ";<br/>");
                }
                else
                {
                    szDescriptionLNG ="<span style=\"color:red\"><img src=\"/a_img/a_site/ico16/warning.gif\">Oops!, Not tranlated yet </span><br/>"+ szDescriptionEN;
                }

            }

            szLi1 += "\n" + m_iLevelTab + "<li><a><b>[" + Resources.Strings.Key + ": " + szId + "]</b><span style=\"color:blue\">" + "Level-S" + m_iLevel.ToString() + "</span>" + " [" + szParentId + "-" + szId + "]</a><br/> ";
            szLi1 += "<div class=\"treenote\">";
            
           if (szTaxaGroupName != "")
           {
               szLi2 += "<b><i>" + szTaxaGroupName + "</i></b>";
            
           }
           if (szTaxaURL != "")
           {
               szLi2 += "<br/><a href=\"" + szTaxaURL + "\" class=\"small\">" + "Go turtles of the workd key</a>\n";
           }
           m_htmlEN += szLi1 + szDescriptionEN + szLi2 + "\n</div>";
         
           m_htmlENAdmin += szLi1 + szDescriptionEN + szLi2;
           m_htmlENAdmin += "<br/><a class=\"button tiny\" href=\"/" + m_SqlCmdWhereLng + "/tortoises/keys/key-mng.edit/" + szDocId + "</a></div>"; 

           m_htmlLNG += szLi1 + szDescriptionLNG + szLi2 + "\n</div>";
           m_htmlLNGAdmin += szLi1 + szDescriptionLNG + szLi2;
           m_htmlLNGAdmin += "<br/><a class=\"button tiny\" href=\"/" + m_SqlCmdWhereLng + "/tortoises/keys/key-mng.edit/" + szDocId + "</a></div>"; 

        }
        //-----------------------------------------------
        public int Fnc_HtmlULTreeViewChilds(string IID, string szIdLng)
        {
            string sz = "";
            string szDocId = "";
            string szDescription = "";
            string szId = "";
            string szParentId = "";
            string szTaxaGroupLevel = "";
            string szTaxaGroupName="";
            string szDescriptionTow = "";
            string szTaxaURL="";
            m_iLevel++;
            m_iLevelTab = "";
            for (int n = 0; n < m_iLevel;n++ )
            {
                m_iLevelTab = "\t" + m_iLevelTab;
            }


            DataTable ds = Fnc_HtmlULTreeViewChildsFromDDBB(" and TOWNodeParentId  ='" + IID + "'", szIdLng);
            if (ds.Rows.Count > 0)
            {
                sz = "\n" + m_iLevelTab + "<ul>";
                m_htmlEN += sz;
                m_htmlENAdmin += sz;
                m_htmlLNG += sz;
                m_htmlLNGAdmin += sz;
                
                foreach (DataRow dr in ds.Rows)
                {
                    //TreeNode child = new TreeNode();
                    //child.Text = dr["description"].ToString().Trim();
                    //TOWNodeId,  TOWNodeParentId ,TOWDescription,' NodeFullPathList,  TOWTaxaGroupLevel,TOWTaxaGroupName,TOWTaxaURL 
                    //szDescription = dr["TOWDescription"].ToString();
                    szDocId = dr["DocId"].ToString();
                    szDescriptionTow = dr["TOWDescription"].ToString();
                    szDescription = dr["Description"].ToString();
                    szId = dr["TOWNodeId"].ToString();
                    szParentId = dr["TOWNodeParentId"].ToString();
                    szTaxaGroupLevel = dr["TOWTaxaGroupLevel"].ToString();
                    szTaxaGroupName = dr["TOWTaxaGroupName"].ToString();
                    szTaxaURL = dr["TOWTaxaURL"].ToString();

                    Fnc_HtmlULTreeViewLiFill(szDocId, szParentId, szId, szDescription, szTaxaGroupLevel, szTaxaGroupName, szTaxaURL);
                    
                    Fnc_HtmlULTreeViewChilds(szId, szIdLng);

                    sz = "\n" + m_iLevelTab + "</li>";
                    m_htmlEN += sz;
                    m_htmlENAdmin += sz;
                    m_htmlLNG += sz;
                    m_htmlLNGAdmin += sz;
                }
                m_iLevel--;
                sz = "\n" + m_iLevelTab + "<li><span style=\"color:red\">Level-E" + m_iLevel.ToString() + " z</span></li>\n";
                m_htmlEN += sz;
                m_htmlENAdmin += sz;
                m_htmlLNG += sz;
                m_htmlLNGAdmin += sz;

                sz = "\n" + m_iLevelTab + "</ul>";
                m_htmlEN += sz;
                m_htmlENAdmin += sz;
                m_htmlLNG += sz;
                m_htmlLNGAdmin += sz;
                
                return 0;
            }
            else
            {
                m_iLevel--;
                sz = "\n<li><span style=\"color:red\">Level-E" + m_iLevel.ToString() + " zz</span></li>\n";
                m_htmlEN += sz;
                m_htmlENAdmin += sz;
                m_htmlLNG += sz;
                m_htmlLNGAdmin += sz; 
                return 0;
            }
         
        }
        
        //----------------------------------------------
        private DataTable Fnc_HtmlULTreeViewChildsFromDDBB(string szWhereAnd, string szIdLng)
        {
            
            //string szCmd = "select  TOWNodeId,  TOWNodeParentId ,TOWDescription,'' as tag, '' as NodePath, '' as NodeFullPathList,  TOWTaxaGroupLevel,TOWTaxaGroupName,TOWTaxaURL from tdoclng_testudines_keys  " + szWhere + " order by  TOWNodeParentId, TOWNodeId ";
            string szCmd = m_SqlCmdSelect + m_SqlCmdWhere+ szWhereAnd + m_SqlCmdOrder;
       
            m_oSqlCmd.CommandText= szCmd;
             
            MySqlDataAdapter oSqlDA = new MySqlDataAdapter(m_oSqlCmd);
            DataTable oDT = new DataTable("data");
            if (m_oSqlCnn.State != ConnectionState.Open) { m_oSqlCnn.Open(); }
            oSqlDA.Fill(oDT);
            return oDT;
        }
        #endregion RegFnc_HtmlULTreeView
      
       
      
    }
    }
   

