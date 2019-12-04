using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;

using Telerik.WebControls;

namespace testudines.cls.cache
{
    public class ClsCache_Tortoise_Tree_RadTreeView
    {


       
        private static String m_FileName = "";

        public ClsCache_Tortoise_Tree_RadTreeView()
        {
            m_FileName = ClsGlobal.DirCache+ "Taxa_TreeRadTreeView.htm";
        }

        public string FncCache_GET(ref Telerik.WebControls.RadTreeView scnTreeView, ref bool m_bNodeRoot, bool bRebuild)
        {
            if (bRebuild) { cls.ClsUtils.FncPathFileDelete(m_FileName); }

            if (System.IO.File.Exists (m_FileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(m_FileName); 

            }
            else
            {
                string szXml = "";
                szXml = FncCacheFillRadTreeViewBld(ref scnTreeView, ref m_bNodeRoot, bRebuild);

                cls.cache.ClsCache.FncCacheFileSave(ref m_FileName, ref szXml);
                return szXml;
            }

        }

        private String FncCacheFillRadTreeViewBld(ref Telerik.WebControls.RadTreeView scnTreeView, ref bool m_bNodeRoot, bool bClearCache)
        {
            m_bNodeRoot = true;
            string szSqlCmd = "select docId, CONCAT_WS (' ',ATaxGrpL2270Genus, ATaxGrpL2280Specie) as Text,ATaxNameVulgarOthers from tdoclng_testudines_taxa_all order by ATaxGrpL2270Genus,  ATaxGrpL2280Specie";
            //szSqlCmd="select docId, CONCAT ('<a href=\"/en/tortoises/', docId, '\">' ,ATaxGrpL2270Genus,' ', ATaxGrpL2280Specie, docId, '</a>') as Text,ATaxNameVulgarOthers from tdoclng_testudines_taxa_all order by text";

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, oCnn);
            DataTable oTb = new DataTable();
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);


            //-------------
            // numeracion

            DataColumn colIdNode = new DataColumn();
            colIdNode.DataType = System.Type.GetType(".System.String");
            colIdNode.AllowDBNull = true;
            colIdNode.Caption = "ID";
            colIdNode.ColumnName = "ID";
            colIdNode.DefaultValue = 0;
            oTb.Columns.Add(colIdNode);

            DataColumn colIdNodeParent = new DataColumn();
            colIdNodeParent.DataType = System.Type.GetType(".System.String");
            colIdNodeParent.AllowDBNull = true;
            colIdNodeParent.Caption = "ParentID";
            colIdNodeParent.ColumnName = "ParentID";
            colIdNodeParent.DefaultValue = 1;
            oTb.Columns.Add(colIdNodeParent);

            DataColumn colName = new DataColumn();
            colName.DataType = System.Type.GetType(".System.String");
            colName.AllowDBNull = true;
            colName.Caption = "Text";
            colName.ColumnName = "Text";
            colName.DefaultValue = 0;
            oTb.Columns.Add(colName);

            DataRow oNewRow = oTb.NewRow();
            oNewRow["ID"] = "0";
            oNewRow["ParentID"] = null;
            oNewRow["Text"] = "<b>Testudines: turtles and tortoises</b>";
            oTb.Rows.Add(oNewRow);

            oCnn.Open();
            oDa.Fill(oTb);
            int iCount = oTb.Rows.Count;
            oDa.Dispose();
            oCmd.Dispose();
            oCnn.Close();
            oCnn.Dispose();

            Int32 INum = 0;
            foreach (DataRow oRow in oTb.Rows)
            {
                INum++;
                oRow["ID"] = INum.ToString();

            }

            //foreach (DataRow oRow in oTb.Rows)
            //{


            //    scnLiteral.Text += oRow["ID"].ToString() + "-" + oRow["ParentID"].ToString() + "-" + oRow["Text"] + "</br>";
            //}

            //
            // asociar al tree view
            RadTreeNode rootNode = new RadTreeNode("Root");
            rootNode.Image = "Folder.gif";
            rootNode.Category = "Root";
            rootNode.Expanded = true;
            rootNode.Value = "\\";


            scnTreeView.AddNode(rootNode);

            scnTreeView.DataFieldID = "ID";
            scnTreeView.DataFieldParentID = "ParentID";
            scnTreeView.DataValueField = "docId";
            scnTreeView.DataTextField = "Text";
            scnTreeView.DataSource = oTb;
            scnTreeView.DataMember = oTb.TableName;
            scnTreeView.DataBind();
            scnTreeView.Nodes[0].Expanded = true; ;
            cls.ClsUtils.FncDateToAAAAMMDD(System.DateTime.Today);



            // guardar el xml para que la vez siguiente vaya mas rapido
            string szXml = scnTreeView.GetXml();


            return szXml;
        }
    }

}
