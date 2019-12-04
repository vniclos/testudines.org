using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
// turtles of the wordl is now in 
//https://turtles.linnaeus.naturalis.nl/linnaeus_ng/app/views/key/?epi=11
namespace testudines.cls.bbdd
{
    public class ClsReg_tdoclng_testudines_all
    {
        private string m_errorstring = "";
        private bool m_error = false;
        private UInt64 m_DocId = 0;
        private String m_DocLngId = "";

        public cls.bbdd.ClsReg_tdoc oRegDoc = new ClsReg_tdoc();

        public cls.bbdd.ClsReg_tdoclng_testudines_care oRegCare = new ClsReg_tdoclng_testudines_care();

        public cls.bbdd.ClsReg_tdoclng_testudines_desc oRegDesc = new ClsReg_tdoclng_testudines_desc();

        public cls.bbdd.ClsReg_tdoclng_testudines_desc_all oRegDescAll = new ClsReg_tdoclng_testudines_desc_all();
        public cls.bbdd.ClsReg_tdoclng oRegDocLng = new cls.bbdd.ClsReg_tdoclng();
        public cls.bbdd.ClsReg_tdoclng_testudines_taxa oRegTaxa = new ClsReg_tdoclng_testudines_taxa();
        public cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oRegTaxaAll = new ClsReg_tdoclng_testudines_taxa_all();

        public cls.bbdd.ClsReg_tdoclng_testudines_file_all oRegTaxaAllFile = new ClsReg_tdoclng_testudines_file_all();
        
        public cls.bbdd.ClsReg_tdoclng_testudines_geog oRegGeo = new ClsReg_tdoclng_testudines_geog();
        public cls.bbdd.ClsReg_tdoclng_testudines_geog_all oRegGeoAll = new ClsReg_tdoclng_testudines_geog_all();
        

        public  ClsReg_tdoclng_testudines_othe_all oRegOthAll = new ClsReg_tdoclng_testudines_othe_all();
        public ClsReg_tdoclng_testudines_othe oRegOth = new ClsReg_tdoclng_testudines_othe();
        



        public cls.bbdd.ClsReg_tdoclng_testudines_natu oRegNatu = new ClsReg_tdoclng_testudines_natu();
        public cls.bbdd.ClsReg_tdoclng_testudines_natu_all oRegNatuAll = new ClsReg_tdoclng_testudines_natu_all();


        public ClsReg_tdoclng_testudines_all()
        { }
        public UInt64 DocId
        {
            get { return m_DocId; }
            set { m_DocId = value; }
        }
        public string DocLngId
        {
            get { return m_DocLngId; }
            set { m_DocLngId = value; }
        }
        public string errorstring
        {
            get { return m_errorstring; }
        }
        public bool error
        {
            get { return m_error; }
        }
        public void FncClear()
        {
            //oRegAbs.FncClear();
            m_errorstring = "";
            m_error = false;
            
            m_DocId = 0;
            m_DocLngId = ClsGlobal.default_DocLngId;
            oRegCare.FncClear();
            oRegDesc.FncClear();
            oRegDescAll.FncClear();
            oRegDoc.FncClear();
            oRegDocLng.FncClear();
            oRegGeo.FncClear();
            oRegGeoAll.FncClear();
            oRegNatu.FncClear();
            oRegNatuAll.FncClear();
            oRegTaxaAll.FncClear();
            oRegTaxaAllFile.FncClear();
            oRegOth.FncClear();
            oRegOthAll.FncClear();
            oRegTaxa.FncClear();


        }

        public void FncDuplicate()
        {
            // oRegAbs.DocId = 0;
            oRegCare.DocId = 0;
            oRegDesc.DocId = 0;
            oRegDescAll.DocId = 0;
            oRegDoc.DocId = 0;
            oRegDocLng.DocId = 0;
            oRegGeo.DocId = 0;
            oRegOth.DocId = 0;
            oRegGeoAll.DocId = 0;
            oRegNatu.DocId = 0;
            oRegNatuAll.DocId = 0;
            oRegTaxaAll.DocId = 0;
            oRegTaxa.DocId = 0;
            oRegTaxaAllFile.DocId = 0;
            oRegOthAll.DocId = 0;
            m_DocId = 0;
            m_DocLngId = ClsGlobal.default_DocLngId;
        }
        public bool FncSqlDelete(UInt64 DocId, string DocLngId)
        {

           
            oRegDocLng.FncSqlFind(DocId, DocLngId);

            // TODO MEJORAR CONTROL DE ERRORES
            bool b = true;

            oRegCare.FncSqlDelete(DocId, DocLngId);
            oRegDesc.FncSqlDelete(DocId, DocLngId);

            oRegDocLng.FncSqlDelete(DocId, DocLngId);
            oRegGeo.FncSqlDelete(DocId, DocLngId);
            oRegOth.FncSqlDelete(DocId, DocLngId);

            oRegNatu.FncSqlDelete(DocId, DocLngId);
            oRegTaxa.FncSqlDelete(DocId, DocLngId);

            cls.bbdd.ClsReg_tdoclng oRegMeta = new ClsReg_tdoclng();
            oRegMeta.FncSqlDelete(DocId, DocLngId);


            // Solo borrar los comunes a todos los idiomas, si no existe
            // ningun registro de otro idioma
            string szSql = "select DocId, doclngid from tdoclng where docid =" + DocId.ToString();
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            if (oCmd.ExecuteNonQuery() == 0)
            {
                oRegDescAll.FncSqlDelete(DocId);
                oRegGeoAll.FncSqlDelete(DocId);
                oRegNatuAll.FncSqlDelete(DocId);
                oRegTaxaAll.FncSqlDelete(DocId);
                oRegTaxaAllFile.FncSqlDeleteFiles(DocId);
                oRegOthAll.FncSqlDelete(DocId);
                oRegDoc.FncSqlDelete(DocId);

            }
            oCnn.Close();
            oCnn.Dispose();
            oCmd.Dispose();
            FncClear();
            return b;
        }
        public bool FncSqlFind(UInt64 pDocId, string pDocLngId)
        {
            FncClear();

            if (pDocId == 0) { return false; }
            m_DocId = pDocId;
            m_DocLngId = pDocLngId;
          
          
           
          
            if (!oRegDoc.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>0 oRegDoc:</b></br>" + oRegDoc.ErrorString; }
            if (!oRegDocLng.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>1 oRegDocLng:</b></br>" + oRegDocLng.ErrorString; }
            if (!oRegTaxa.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>2 oRegTaxa:</b></br>" + oRegTaxa.ErrorString; }
             if (!oRegCare.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>3 oRegCare:</b></br>" + oRegCare.ErrorString; }
            if (!oRegDesc.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>4 oRegDesc:</b></br>" + oRegDesc.ErrorString; }
            if (!oRegDescAll.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>5 oRegDescAll:</b></br>" + oRegDescAll.ErrorString; }
            if (!oRegGeo.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>6 oRegGeo:</b></br>" + oRegGeo.ErrorString; }
            if (!oRegOth.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>6 oRegOth:</b></br>" + oRegOth.ErrorString; }
            
            if (!oRegGeoAll.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>7 oRegGeoAll:</b></br>" + oRegGeo.ErrorString; }
            if (!oRegNatu.FncSqlFind(pDocId, pDocLngId)) { m_error = true; m_errorstring += "</br><b>8 oRegNatu:</b></br>" + oRegNatu.ErrorString; }
            if (!oRegNatuAll.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>9 oRegNatuAll:</b></br>" + oRegNatuAll.ErrorString; }
            if (!oRegTaxaAll.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>10 oRegTaxaAll:</b></br>" + oRegTaxaAll.ErrorString; }
            if (!oRegOthAll.FncSqlFind(pDocId)) { m_error = true; m_errorstring += "</br><b>10 oRegOthAll:</b></br>" + oRegOthAll.ErrorString; }
            
            oRegTaxaAllFile.FncGroupFilesGet(pDocId);
            
            return !m_error;
        }
        public bool FncSqlSave(UInt64 pDocId, string pDocLngId)
        {
            m_error = false;
            m_errorstring = "";

            m_DocId = oRegDoc.DocId;
            m_DocLngId = pDocLngId;

            oRegDoc.DocId = m_DocId;

            oRegDoc.FncSqlSave(); // if oRegDoc.DocId =0 save new new and get new Id.
            m_DocId = oRegDoc.DocId;
            oRegDocLng.DocId = oRegDoc.DocId;
            oRegDocLng.DocLngId = m_DocLngId;
            oRegDocLng.FncSqlSave();

            oRegTaxaAll.DocId = m_DocId;

            oRegTaxa.DocId = m_DocId;
            oRegTaxa.DocLngId = m_DocLngId;
            // Set same key for all records


            oRegCare.DocId = m_DocId;
            oRegCare.DocLngId = m_DocLngId;

            oRegDesc.DocId = m_DocId;
            oRegDesc.DocLngId = m_DocLngId;

            oRegGeo.DocId = m_DocId;
            oRegGeo.DocLngId = m_DocLngId;


            oRegOth.DocId = m_DocId;
            oRegOth.DocLngId = m_DocLngId;

            oRegGeoAll.DocId = m_DocId;

            oRegDocLng.DocId = m_DocId;
            oRegDocLng.DocLngId = m_DocLngId;

            oRegGeo.DocId = m_DocId;
            oRegGeo.DocLngId = m_DocLngId;

     

            oRegNatu.DocId = m_DocId;
            oRegNatu.DocLngId = m_DocLngId;

            oRegNatuAll.DocId = m_DocId;

            oRegTaxaAll.DocId = m_DocId;

            oRegTaxaAllFile.DocId = m_DocId;
            oRegOthAll.DocId = m_DocId;



            if (!oRegCare.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegCare: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }

            if (!oRegDesc.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegDesc: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }

            if (!oRegGeo.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegGeo: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }
            if (!oRegGeoAll.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegGeo: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }
            if (!oRegNatu.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegNatu: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }
            if (!oRegNatuAll.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegNatuAll: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }
            if (!oRegTaxa.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegTaxa: <br/>" + oRegTaxa.ErrorString + "</br>";
                return false;
            }

            if (!oRegTaxaAll.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegTaxaAll: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }
            if (!oRegTaxaAllFile.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegTaxaAllFile: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }

            if (!oRegOth.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegOth: <br/>" + oRegOth.ErrorString + "</br>";
                return false;
            }
            if (!oRegOthAll.FncSqlSave())
            {
                m_error = true;
                m_errorstring += "Error All oRegOthAll: <br/>" + oRegTaxaAll.ErrorString + "</br>";
                return false;
            }


            
            //.................
            //.................
            //.................
            //.................

            return m_error;
        }

        public string HtmlToolTipSubOrder
        {
            get
            {
                return FncHtmTOrderGroupToolTip(oRegTaxaAll.ATaxGrpL2220SubOrder, "Subord.:");
            }

        }
        public string HtmlToolTipFamily
        {
            get
            {
                return FncHtmTOrderGroupToolTip(oRegTaxaAll.ATaxGrpL2230SupFamily, "Fam.:");
            }

        }
        public string HtmlToolTipGenus
        {
            get
            {
                return FncHtmTOrderGroupToolTip(oRegTaxaAll.ATaxGrpL2260SupGenus, "Gen.:");
            }

        }

        private string FncHtmTOrderGroupToolTip(string pATaxIdName, String pszTitPrefij)
        {

            string szTooltip = "";
            string szLinkPre = "<a href=\"/" + m_DocLngId + "/tortoises/groups/group/";
            string szLink = szLinkPre + pATaxIdName + "\">" + pATaxIdName + "</a>\n";
            if (pATaxIdName == "") return pATaxIdName; // Evitar calculos inecesarios por falta de datos

            //- buscar datos en bbdd


            //------------------------------



            string szSqlCmdSelect = "select DocId,DocLngId, ATaxIdName,ATaxGrpL2282Authority,ATaxGrpL2283Year,Abstract,DescriptionShort from tdoclng_testudines_groups  ";
            string szSqlCmdSelectWhere = " where ATaxIdName='" + pATaxIdName.Trim() + "' and DocLngId='" + m_DocLngId + "'";
            string szSqlCmd = szSqlCmdSelect + szSqlCmdSelectWhere;

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSqlCmd, oCnn);
            DataTable oDT = new DataTable();
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);
            string szIdName = "";
            string szAbstract = "";
            string szReadMore = "";
            string szIdAuthority = "";
            string szIdYear = "";
            string szDescriptionShort = "";
            try
            {
                if (oCnn.State != System.Data.ConnectionState.Open) oCnn.Open();
                oDA.Fill(oDT);
                oDA.Dispose();

                string szHtml = "";
                if (oDT.Rows.Count > 0)
                {
                    szIdName = oDT.Rows[0]["ATaxIdName"].ToString().Trim();
                    szIdAuthority = oDT.Rows[0]["ATaxGrpL2282Authority"].ToString().Trim();
                    szIdYear = oDT.Rows[0]["ATaxGrpL2283Year"].ToString().Trim();


                    szDescriptionShort = oDT.Rows[0]["DescriptionShort"].ToString().Trim();
                    szAbstract = oDT.Rows[0]["Abstract"].ToString().Trim();
                    szHtml = pszTitPrefij + pATaxIdName + ", " + szIdAuthority + "(" + szIdYear + ")";

                    if (szDescriptionShort != "")
                    {
                        szHtml += "<br/>" + szDescriptionShort;
                    }

                    szAbstract = szHtml + szAbstract;
                    szLink = szLinkPre + pATaxIdName + "\">" + pszTitPrefij + pATaxIdName + ", (" + szIdAuthority + " " + szIdYear + ")</a>\n</span>";

                    szTooltip = cls.ClsHtml.FncHtmlToolTip(szLink, szAbstract);

                    szReadMore = "\n<span class=\"readmore\">" + szLinkPre + pATaxIdName + "\"  title=\"" + Resources.Strings.Click_ReadFullArticle + "\" >[" + Resources.Strings.readmore + "]</a>\n</span>";

                    szTooltip += szReadMore;
                }

                oDT.Dispose();
            }
            catch (Exception xcpt)
            {
                string sz = xcpt.Message;
                ;
            }
            // crear tool tips

            return szTooltip;

        }

        public string FncHtmlGetKeyIdentificationSumary
        {
            get { return "Opps! Pending of develop"; }
        }
    }
}