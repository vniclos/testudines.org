using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace testudines.a_dlg
{
    public partial class dlg_Countries : System.Web.UI.Page
    {
        private string m_CountryListValues = "";
        private string m_CountryListNames = "";
        private int m_CountryListCount = 0;
        private int m_DocId=0;
        string m_ParentDocumentID_Names = "";
        string m_ParentDocumentID_Keys = "";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                //   var url = "/a_dlg/dlg_Countries.aspx?docid=" + docid + "&returnName="+returnName+"&returnkeys="+ returnkeys;

                try
                {
                    if (Request.QueryString != null)
                    {
                        m_DocId = Convert.ToInt32(Request.QueryString["id"].ToString());
                        scnDocId.Text = m_DocId.ToString();
                    }
                }
                catch { ; }

                try {
                    if (Request.QueryString["returnName"] != null)
                    {
                        m_ParentDocumentID_Names = Request.QueryString["returnName"];
                    }
                    }
                catch{ }

                try
                {
                    if (Request.QueryString["returnkeys"] != null)
                    {
                        m_ParentDocumentID_Keys = Request.QueryString["returnkeys"];
                    }
                }
                catch { }

            


                FncFill();
            }
          
        }
        public void FncFill()
        {
            string sz = cls.ClsGlobal.Connection_MARIADB;
            MySqlConnection oSqlCnn = new MySqlConnection(sz);
            MySqlCommand oSqlCmd = new MySqlCommand();
            string szSql = "";

            szSql = "SELECT IdGrpTypeGeo, IdContinent, ContinentName, ContinentRegion, CountryName , IdCoutryISO3Plus,IdGroupList, Id_Lng";
            szSql += " FROM  tmst_geo_country ";
            szSql += " WHERE (Id_Lng = 'en')";
            szSql += " ORDER BY IdGrpTypeGeo,IdGroupList, CountryName";
            oSqlCmd.CommandText = szSql;
            oSqlCmd.Connection = cls.bbdd.ClsMysql.MySqlConnection;

            string szidContinent = "";
            string szidContinentant = "";
            string szIdCountry = "";
            string szCountryName = "";
            string szContinentName = "";
            string szIdGrpTypeGeo = "";
            string szGrp = "";
            try
            {
                oSqlCnn.Open();

                MySqlDataReader oSqlRd = oSqlCmd.ExecuteReader();
                //   scnEuropeChk.Items.Clear();

                while (oSqlRd.HasRows & oSqlRd.Read())
                {
                    szIdGrpTypeGeo = oSqlRd["IdGrpTypeGeo"].ToString().Trim().ToUpper();
                    szidContinent = oSqlRd["IdGroupList"].ToString().Trim().ToUpper();


                    szIdCountry = oSqlRd["IdCoutryISO3Plus"].ToString().Trim().ToUpper();
                    szCountryName = oSqlRd["CountryName"].ToString().Trim();

                    szContinentName = "<b>" + oSqlRd["ContinentName"].ToString().Trim() + "</b>";
                    szContinentName += ", " + oSqlRd["ContinentRegion"].ToString().Trim();

                    Panel Panel1 = new Panel();
                    szGrp = szidContinent;


                    try
                    {

                        switch (szGrp)
                        {
                            case "AFR_CENTR":
                                scnAF_CENTRALbl.Text = szContinentName;
                                scnAF_CENTRAChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AFR_EASTE":
                                scnAF_EASTERLbl.Text = szContinentName;
                                scnAF_EASTERChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AFR_NORTH":
                                scnAF_NORTHELbl.Text = szContinentName;
                                scnAF_NORTHEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AFR_SOUTH":
                                scnAF_SOUTHELbl.Text = szContinentName;
                                scnAF_SOUTHEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AFR_WESTE":
                                scnAF_WESTELbl.Text = szContinentName;
                                scnAF_WESTEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AMC_CARIB":
                                scnAM_CARIBELbl.Text = szContinentName;
                                scnAM_CARIBEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AMC_CENTR":
                                scnAM_CENTRALbl.Text = szContinentName;
                                scnAM_CENTRAChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AMN_NORTH":
                                scnAM_NORTHELbl.Text = szContinentName;
                                scnAM_NORTHEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "AMS_SOUTH":
                                scnAM_SOUTHELbl.Text = szContinentName;
                                scnAM_SOUTHEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "EUR_WESTE":
                                scnEUR_WESTELbl.Text = szContinentName;
                                scnEUR_WESTEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "EUR_NORTH":
                                scnEUR_NORTHLbl.Text = szContinentName;
                                scnEUR_NORTHChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;

                            case "EUR_EASTE":
                                scnEUR_EASTELbl.Text = szContinentName;
                                scnEUR_EASTEChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "EUR_SOUTH":
                                scnEUR_SOUTHLbl.Text = szContinentName;
                                scnEUR_SOUTHChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;

                            case "OCN_AUSNZ":
                                scnOCN_AUSNZLbl.Text = szContinentName;
                                scnOCN_AUSNZChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;

                            case "OCN_MELAN":
                                scnOCN_MELANLbl.Text = szContinentName;
                                scnOCN_MELANChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "OCN_MICRO":
                                scnOCN_MICROLbl.Text = szContinentName;
                                scnOCN_MICROChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "OCN_POLYN":
                                scnOCN_POLYNLbl.Text = szContinentName;
                                scnOCN_POLYNChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "ANT_ANTAR":
                                scnANTARTLbl.Text = szContinentName;
                                scnANTARTChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "ASI_EASTE":
                                scnAS_EASTERLbl.Text = szContinentName;
                                scnAS_EASTERChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "ASI_MIDEA":
                                scnAS_MIDEASTLbl.Text = szContinentName;
                                scnAS_MIDEASTChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "ASI_SOCNT":
                                scnAS_SOUCNTLbl.Text = szContinentName;
                                scnAS_SOUCNTChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "ASI_SOEAS":
                                scnASI_SOEASLbl.Text = szContinentName;
                                scnASI_SOEASChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                            case "SEA_SEA":
                                scnSEALbl.Text = szContinentName;
                                scnSEAChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;


                            //EU-BALTIC EU-BRITAI EU-EASTER EU-NORTHE EU-SOUTHE, EU-WESTE, OC-AUSNZD
                            // OC-MICCA OC-MELANE OC-MICRON OC-POLINE OCEAN
                            default:
                                scnDEFLbl.Text = "No Id.";
                                scnDEFChk.Items.Add(new ListItem(szCountryName, szIdCountry));
                                break;
                        }

                    }
                    catch
                    {



                    }



                    // agregar al control
                    //   oChkLst.Items.Add(new ListItem(szCountryName, szIdCountry));
                    szidContinentant = szidContinent;

                }
            }
            catch (Exception xcpt)
            {
                scnAF_CENTRALbl.Text = xcpt.Message;
            }
        }
        private void FncCountryListSelected()
        {
            m_CountryListCount = 0;
            m_CountryListNames = "";
            m_CountryListValues = "";

            FncCountryListValue(scnAF_CENTRAChk);
            FncCountryListValue(scnAF_EASTERChk);
            FncCountryListValue(scnAF_SOUTHEChk);
            FncCountryListValue(scnAF_WESTEChk);
            FncCountryListValue(scnAF_NORTHEChk);

            FncCountryListValue(scnAM_CARIBEChk);
            FncCountryListValue(scnAM_CENTRAChk);
            FncCountryListValue(scnAM_NORTHEChk);
            FncCountryListValue(scnAM_SOUTHEChk);

            FncCountryListValue(scnAS_EASTERChk);
            FncCountryListValue(scnAS_MIDEASTChk);
            FncCountryListValue(scnAS_SOUCNTChk);
            FncCountryListValue(scnASI_SOEASChk);

            FncCountryListValue(scnEUR_EASTEChk);
            FncCountryListValue(scnEUR_NORTHChk);
            FncCountryListValue(scnEUR_SOUTHChk);
            FncCountryListValue(scnEUR_WESTEChk);

            FncCountryListValue(scnOCN_AUSNZChk);
            FncCountryListValue(scnOCN_MELANChk);
            FncCountryListValue(scnOCN_MICROChk);
            FncCountryListValue(scnOCN_POLYNChk);

            FncCountryListValue(scnSEAChk);
            FncCountryListValue(scnANTARTChk);

            FncCountryListValue(scnDEFChk);

            m_CountryListNames = m_CountryListNames.Trim ();
            m_CountryListValues = m_CountryListValues.Trim ();
            if (m_CountryListNames.EndsWith(","))
            {
                m_CountryListNames=m_CountryListNames.Remove(m_CountryListNames.Length - 1);  
            }
            if (m_CountryListValues.EndsWith(","))
            {
            m_CountryListValues=    m_CountryListValues.Remove(m_CountryListValues.Length - 1);
            }

        }
        private void FncCountryListValue(CheckBoxList oCheckBoxList)
        {
          //  scnPanContries.Visible = !scnPanContries.Visible;
            string szValues = "";
            string szNames = "";
            for (int i = 0; i < oCheckBoxList.Items.Count; i++)
            {
                if (oCheckBoxList.Items[i].Selected)
                {
                    szValues += oCheckBoxList.Items[i].Value.ToString().Trim().ToUpper() + ", ";
                    szNames += oCheckBoxList.Items[i].Text.ToString().Trim() + ", ";
                    m_CountryListCount++;
                }
            }
            m_CountryListValues += szValues;
            m_CountryListNames += szNames;

        }

        protected void scnBtnSelected_Click(object sender, EventArgs e)
        {
            //MyAccordion.Visible = !MyAccordion.Visible;
            FncCountryListSelected();

            scnCountriesNamesTxt.Text = CountryListNames;
            scnCountriesCodesTxt.Text = CountryListValues;
            clbSelectedItemCount.Text = CountryListCount.ToString();
        }
        #region getset

        public string CountryListValues
        {
            get { return m_CountryListValues; }
        }
        public string CountryListNames
        {
            get { return m_CountryListNames; }
        }
        public int CountryListCount
        {
            get { return m_CountryListCount; }
        }
        #endregion getset


    }

}