using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Xml;
using System.Web.Services;
using System.Net;
using System.Data;
using System.IO;
using System.Xml.XPath;

namespace testudines.a_test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void scnBtn_Click(object sender, EventArgs e)
        {
            DataTable oTbRequest = new DataTable();
            DataColumn oCol2 = new DataColumn("NameField", System.Type.GetType("System.String"));
            DataColumn oCol1 = new DataColumn("URL", System.Type.GetType("System.String"));

            DataColumn oCol3 = new DataColumn("Numero", System.Type.GetType("System.Int32"));
            DataColumn oCol4 = new DataColumn("Found", System.Type.GetType("System.Boolean"));
            DataColumn oCol5 = new DataColumn("Date", System.Type.GetType("System.DateTime"));
            oTbRequest.Columns.Add(oCol1);
            oTbRequest.Columns.Add(oCol2);
            oTbRequest.Columns.Add(oCol3);
            oTbRequest.Columns.Add(oCol4);
            oTbRequest.Columns.Add(oCol5);

            string[,] aUrl = new string[23, 2];
            string szRootUrl = "http://www.itis.gov/ITISWebService/services/ITISService/";
            aUrl[0, 0] = "Get Accepted Names from TSN";
            aUrl[0, 1] = "getAcceptedNamesFromTSN?tsn= ";

            aUrl[1, 0] = "Get Comment Detail from TSN";
            aUrl[1, 1] = "getCommentDetailFromTSN?tsn=";

            aUrl[2, 0] = "Get Common Names from TSN";
            aUrl[2, 1] = "getCommonNamesFromTSN?tsn=";

            aUrl[3, 0] = "Get Core Metadata from TSN";
            aUrl[3, 1] = "getCoreMetadataFromTSN?tsn=";

            aUrl[4, 0] = "Get Coverage from TSN";
            aUrl[4, 1] = "getCoverageFromTSN?tsn= ";

            aUrl[5, 0] = "Get Coverage from TSN";
            aUrl[5, 1] = "getCoverageFromTSN?tsn=";

            aUrl[6, 0] = " Get Credibility Rating from TSN";
            aUrl[6, 1] = "getCredibilityRatingFromTSN?tsn=";

            aUrl[7, 0] = "Get Currency from TSN";
            aUrl[7, 1] = "getCurrencyFromTSN?tsn=";

            aUrl[8, 0] = "Get Date Data from TSN";
            aUrl[8, 1] = "getDateDataFromTSN?tsn=";


            aUrl[9, 0] = "Get Experts from TSN";
            aUrl[9, 1] = "getExpertsFromTSN?tsn=";

            aUrl[10, 0] = "Get Geographic Divisions from TSN";
            aUrl[10, 1] = "getGeographicDivisionsFromTSN?tsn=";


            aUrl[11, 0] = " Get Global Species Completeness from TSN";
            aUrl[11, 1] = "getGlobalSpeciesCompletenessFromTSN?tsn=";

            aUrl[12, 0] = "Get Jurisdictional Origin from TSN";
            aUrl[12, 1] = "getJurisdictionalOriginFromTSN?tsn=";

            aUrl[13, 0] = "Get Kingdom Name from TSN";
            aUrl[13, 1] = "getKingdomNameFromTSN?tsn=";

            aUrl[14, 0] = " Get Other Sources from TSN";
            aUrl[14, 1] = "getOtherSourcesFromTSN?tsn=";

            aUrl[15, 0] = "Get Parent TSN from TSN";
            aUrl[15, 1] = "getParentTSNFromTSN?tsn=";

            aUrl[16, 0] = "Get Publications from TSN";
            aUrl[16, 1] = "getPublicationsFromTSN?tsn=";

            aUrl[17, 0] = " Get Review Year from TSN";
            aUrl[17, 1] = "getReviewYearFromTSN?tsn=";

            aUrl[18, 0] = "Get Scientific Name from TSN";
            aUrl[18, 1] = "getScientificNameFromTSN?tsn=";

            aUrl[19, 0] = " Get Synonym Name from TSN";
            aUrl[19, 1] = "getSynonymNamesFromTSN?tsn=";

            aUrl[20, 0] = "Get Taxon Authorship from TSN";
            aUrl[20, 1] = "getTaxonAuthorshipFromTSN?tsn=";

            aUrl[21, 0] = "Get Taxonomic Usage from TSN";
            aUrl[21, 1] = "getTaxonomicUsageFromTSN?tsn=";

            aUrl[22, 0] = "Get Unacceptability Reason from TSN";
            aUrl[22, 1] = "getUnacceptabilityReasonFromTSN?tsn=";

            //aUrl[22, 0] = "Get Full Record";
            //aUrl[22, 1] = "getFullRecordFromTSN?tsn=";

            for (int n = 0; n < 23; n++)
            {
                FncFind(aUrl[n, 0], szRootUrl, aUrl[n, 1], "949973");
            }

        }

        public void FncFind(string Name, string UrlRoot, string Url, string ITIS_id)
        {
            scnLiteral.Text += "<h3>" + Name + "</h3>";
            try
            {
                HttpWebRequest request = WebRequest.Create(UrlRoot+Url + ITIS_id) as HttpWebRequest;
                request.Timeout = 145000;



                // Get response  
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Load data into a dataset  
                    DataSet ds = new DataSet();

                    ds.ReadXml(response.GetResponseStream());

                    // Print dataset information  
                    PrintDataSet(ds);
                }
            }
            catch (Exception xpt)
            {
                string sz = xpt.Message;
                //HttpWebRequest request2 = WebRequest.Create(Url + ITIS_id) as HttpWebRequest;
                //using (HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse) ;
                //System.IO.StreamReader oSR = response2.GetResponseStream();
            }
        }
        public void PrintDataSet(DataSet ds)
        {
            string sz = "<br/>";
            // Print out all tables and their columns  
            foreach (DataTable table in ds.Tables)
            {
                // sz= table.TableName;
                //sz+= "rows count "+table.Rows.Count;

                //foreach (DataColumn column in table.Columns)  
                //{
                //    sz += "<br/><b>" + column.ColumnName + "</b>   " + column.DataType.ToString() ;

                //}  // foreach column  

                foreach (DataRow oRow in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        sz += " | " + table.Columns[i].ColumnName + " = " + oRow[i].ToString();
                    }
                }

            }  // foreach table  

            // Print out table relations  
            foreach (DataRelation relation in ds.Relations)
            {
                sz += " relation.RelationName";

                sz += "<br/" + relation.ParentTable.TableName;
                sz += "<br/" + relation.ChildTable.TableName;
                sz += "<br/" + System.Environment.NewLine;
            }  // foreach relation  

            scnLiteral.Text += sz;
        }

        protected void scnBtnXmlAll_Click(object sender, EventArgs e)
        {

        }

        //private string FncSzRequest(string szUrl)
        //       { 
        //        Byte[]  data ;
        //        HttpWebRequest myRequest; ;
        // System.IO.Stream newStream ;
        // HttpWebResponse objResponse; 
        //System.IO.StreamReader  sr ;
        // String  Response ;
        // data = System.Text.Encoding.ASCII.GetBytes("Sample Test data") ;
        //       myRequest.u = HttpWebRequest.Create(szUrl) ;
        //       myRequest.Method = "POST";
        //       myRequest.ContentType = "text/xml";
        //       myRequest.ContentLength = data.Length;
        //       myRequest.Timeout = 145000;
        //       System.Net.ServicePointManager.Expect100Continue = False;
        //       myRequest.AllowWriteStreamBuffering = True        ;
        //       newStream = myRequest.GetRequestStream() ;       
        //       newStream.Write(data, 0, data.Length);
        //       newStream.Close();
        //       objResponse = myRequest.GetResponse();
        //       sr = new  System.IO.StreamReader(objResponse.GetResponseStream());
        //       Response = sr.ReadToEnd()  ;
        // sr.Close();
        // objResponse.Close();

        //       }
    }
}
