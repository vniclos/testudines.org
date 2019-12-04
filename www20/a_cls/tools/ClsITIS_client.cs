using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Net;
using System.IO;
using System.Text;

namespace testudines.cls.tools
{
 /// <summary>
 /// Consulta en la base de datos de itis 
 /// Para obtener la informacion a partir del tsn
 /// </summary>
    public static class ClsITIS_client
    {
        public static String m_DateConsulted = "";
        public static String m_Cite = "";
        public static String m_DateUpdated = "";
        public static String m_expert = "";
        public static String m_ind2 = "";
        public static String m_ind1 = "";
        public static String m_ind4 = "";
        public static String m_ind3 = "";
        public static String m_ValidIs = "";
        public static String m_jurisdiction = "";
        public static String m_TaxTree_Array = "";
        public static String m_TaxGenus = "";
        public static String m_completenessRating = "";
        public static String m_TaxSpecie = "";
        public static String m_TaxSpecieSub = "";
        public static String m_Tsn = "";
        public static String m_currencyRating = "";
        public static String m_TsnSinonims_Array = "";
        public static String m_unit4 = "";
        public static String m_rankID = "";
        public static String m_ValidUnacceptReason = "";
        public static String m_Publication = "";
        public static String m_TaxLevel = "";
        public static String m_OtherSource = "";
        public static String m_multiplyLinkedSynonyms = "";
        public static String m_DateCreated = "";
        public static String m_TaxAuthor = "";
        public static String m_TsnParent = "";
        public static String m_TaxNameFull = "";
        public static String m_ValidCredibility = "";
        public static String m_TaxSynonymsArray = "";
        public static String m_TaxNameVermaular_Array = "";
        public static String m_kingdom = "";
        public static String m_acceptedTSN = "";
        public static String m_hierarchySoFarWRanks = "";
        public static String m_GeograficRange = "";
        public static String m_TaxNameWOInd = "";
        public static String m__version_ = "";
        public static String m_Coment_Array = "";
        public static String m_TaxHierarchy_TSN_Array = "";
        public static String m_TaxHierarchy_ShortArray = "";

        /// <summary>
        /// Pide los datos a Itis
        /// Descompone la informacion en campos
        /// </summary>
        /// <param name="uiIitsTsn">Numero TSN de itis.gov</param>
        /// <returns></returns>
        public static DataTable FncGetData(UInt64 uiIitsTsn)
        {


            FncClear();
            string szUrl = "http://services.itis.gov/?q=tsn:" + uiIitsTsn.ToString() + "&rows=10&wt=csv";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(szUrl);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();


            DataTable oTb = new DataTable();
            DataColumn column;
            DataRow row;
            DataView view;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Id";
            oTb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name_itis";
            oTb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "name";
            oTb.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "value";
            oTb.Columns.Add(column);
            // descomponer csv
            string[] lines = FncCsv_SplitToLines(results);
            var cellsFieldTitle = FncCsv_SpliLineToCells(lines[0]);
            var cellsFieldValues = FncCsv_SpliLineToCells(lines[1]);
            String name = "";
            string value = "";
            row = oTb.NewRow();

            row["id"] = -1;
            row["name_itis"] = "";
            row["name"] = "DateConsulted";
            row["value"] = DateTime.Today.ToString();
            oTb.Rows.Add(row);

            string szCite = "Retrieve [" + DateTime.Now.Year.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + " (amd)], from ITIS, Integrated Taxonomic Information System on-line database, http://www.itis.gov.";
            row = oTb.NewRow();
            row["id"] = -2;
            row["name_itis"] = "";
            row["name"] = "Cite";
            row["value"] = szCite;
            oTb.Rows.Add(row);

            for (int i = 0; i < cellsFieldTitle.Length; i++)
            {
                try
                {
                    name = cellsFieldTitle[i].ToString();
                }
                catch
                {
                    name = "Not Found";
                }
                try
                {
                    value = cellsFieldValues[i].ToString();
                }
                catch
                {

                    value = "Empty";
                }
                row = oTb.NewRow();
                row["id"] = i;
                row["name_itis"] = name;
                row["name"] = FncGetName(i, name, value);
                row["value"] = value;
                oTb.Rows.Add(row);
            }


            // Set a DataGrid control's DataSource to the DataView.
            return oTb;
        }

        private static String FncGetName(int i, String itisName, String value)
        {
            string name = "";
            switch (i)
            {
                case 0:
                    name = "DateUpdated";
                    m_DateUpdated = value;
                    break;
                case 6:
                    name = "ValidIs";
                    m_ValidIs = value;
                    break;
                case 8:
                    name = "TaxTree_Array";
                    m_TaxTree_Array = value;
                    break;
                case 9:
                    name = "TaxGenus";
                    m_TaxGenus = value;
                    break;
                case 11:
                    name = "TaxSpecie";
                    m_TaxSpecie = value;
                    break;
                case 12:
                    name = "TaxSpecieSub";
                    m_TaxSpecieSub = value;
                    break;
                case 13:
                    name = "Tsn";
                    m_Tsn = value;

                    break;
                case 15:
                    name = "TsnSinonims_Array";
                    m_TsnSinonims_Array = value;
                    break;
                case 18:
                    name = "ValidUnacceptReason";
                    m_ValidUnacceptReason = value;
                    break;

                case 19:
                    name = "Publication";
                    m_Publication = value;
                    break;
                case 20:
                    name = "TaxLevel";
                    m_TaxLevel = value;
                    break;
                case 23:
                    name = "DateCreated";
                    m_DateCreated = value;
                    break;
                case 24:
                    name = "TaxAuthor";
                    m_TaxAuthor = value;
                    break;
                case 25:
                    name = "TsnParent";
                    m_TsnParent = value;
                    break;
                case 26:
                    name = "TaxNameFull";
                    m_TaxNameFull = value;
                    break;
                case 27:
                    name = "ValidCredibility";
                    m_ValidCredibility = value;
                    break;


                case 28:
                    name = "TaxSynonymsArray";
                    m_TaxSynonymsArray = value;
                    break;
                case 29:
                    name = "TaxNameVermaular_Array";
                    m_TaxNameVermaular_Array = value;
                    break;
                case 33:
                    name = "GeograficRange";
                    m_GeograficRange = value;
                    break;
                case 34:
                    name = "TaxNameWOInd";
                    m_TaxNameWOInd = value;
                    break;
                case 36:
                    name = "Coment_Array";
                    m_Coment_Array = value;
                    break;
                case 37:
                    name = "TaxHierarchy_TSN_Array";
                    m_TaxHierarchy_TSN_Array = value;
                    break;
                case 38:
                    name = "TaxHierarchy_ShortArray";
                    m_TaxHierarchy_ShortArray = value;
                    break;

                default:
                    name = itisName;
                    break;
            }
            return name;
        }


        public static void FncClear()
        {
            m_DateConsulted = "";
            m_Cite = "";
            m_DateUpdated = "";
            m_expert = "";
            m_ind2 = "";
            m_ind1 = "";
            m_ind4 = "";
            m_ind3 = "";
            m_ValidIs = "";
            m_jurisdiction = "";
            m_TaxTree_Array = "";
            m_TaxGenus = "";
            m_completenessRating = "";
            m_TaxSpecie = "";
            m_TaxSpecieSub = "";
            m_Tsn = "";
            m_currencyRating = "";
            m_TsnSinonims_Array = "";
            m_unit4 = "";
            m_rankID = "";
            m_ValidUnacceptReason = "";
            m_Publication = "";
            m_TaxLevel = "";
            m_OtherSource = "";
            m_multiplyLinkedSynonyms = "";
            m_DateCreated = "";
            m_TaxAuthor = "";
            m_TsnParent = "";
            m_TaxNameFull = "";
            m_ValidCredibility = "";
            m_TaxSynonymsArray = "";
            m_TaxNameVermaular_Array = "";
            m_kingdom = "";
            m_acceptedTSN = "";
            m_hierarchySoFarWRanks = "";
            m_GeograficRange = "";
            m_TaxNameWOInd = "";
            m__version_ = "";
            m_Coment_Array = "";
            m_TaxHierarchy_TSN_Array = "";
            m_TaxHierarchy_ShortArray = "";


        }
        private static string[] FncCsv_SplitToLines(string csv, char delimeter = '\n')
        {
            csv = csv.Replace("\r\n", "\n").Replace("\n\r", "\n");
            List<string> lines = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool isInsideACell = false;

            foreach (char ch in csv)
            {
                if (ch == delimeter)
                {
                    if (isInsideACell == false)
                    {
                        // nasli sme koniec riadka, vsetko co je teraz v StringBuilder-y je riadok
                        lines.Add(sb.ToString());
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                else
                {
                    sb.Append(ch);
                    if (ch == '"')
                    {
                        isInsideACell = !isInsideACell;
                    }
                }
            }

            if (sb.Length > 0)
            {
                lines.Add(sb.ToString());
            }

            return lines.ToArray();
        }

        private static string[] FncCsv_SpliLineToCells(string line, char delimeter = ',')
        {
            List<string> list = new List<string>();
            do
            {
                if (line.StartsWith("\""))
                {
                    line = line.Substring(1);
                    int idx = line.IndexOf("\"");
                    while (line.IndexOf("\"", idx) == line.IndexOf("\"\"", idx))
                    {
                        idx = line.IndexOf("\"\"", idx) + 2;
                    }
                    idx = line.IndexOf("\"", idx);
                    list.Add(line.Substring(0, idx).Replace("\"\"", "\""));
                    if (idx + 2 < line.Length)
                    {
                        line = line.Substring(idx + 2);
                    }
                    else
                    {
                        line = String.Empty;
                    }
                }
                else
                {
                    list.Add(line.Substring(0, Math.Max(line.IndexOf(delimeter), 0)).Replace("\"\"", "\""));
                    line = line.Substring(line.IndexOf(delimeter) + 1);
                }
            }
            while (line.IndexOf(delimeter) != -1);
            if (!String.IsNullOrEmpty(line))
            {
                if (line.StartsWith("\"") && line.EndsWith("\""))
                {
                    line = line.Substring(1, line.Length - 2);
                }
                list.Add(line.Replace("\"\"", "\""));
            }

            return list.ToArray();
        }

        public static String DateConsulted { get { return m_DateConsulted; } }
        public static String Cite { get { return m_Cite; } }
        public static String DateUpdated { get { return m_DateUpdated; } }
        public static String expert { get { return m_expert; } }
        public static String ind2 { get { return m_ind2; } }
        public static String ind1 { get { return m_ind1; } }
        public static String ind4 { get { return m_ind4; } }
        public static String ind3 { get { return m_ind3; } }
        public static String ValidIs { get { return m_ValidIs; } }
        public static String jurisdiction { get { return m_jurisdiction; } }
        public static String TaxTree_Array { get { return m_TaxTree_Array; } }
        public static String TaxGenus { get { return m_TaxGenus; } }
        public static String completenessRating { get { return m_completenessRating; } }
        public static String TaxSpecie { get { return m_TaxSpecie; } }
        public static String TaxSpecieSub { get { return m_TaxSpecieSub; } }
        public static String Tsn { get { return m_Tsn; } }
        public static String currencyRating { get { return m_currencyRating; } }
        public static String TsnSinonims_Array { get { return TsnSinonims_Array; } }
        public static String unit4 { get { return m_unit4; } }
        public static String rankID { get { return m_rankID; } }
        public static String ValidUnacceptReason { get { return m_ValidUnacceptReason; } }
        public static String Publication { get { return m_Publication; } }
        public static String TaxLevel { get { return m_TaxLevel; } }
        public static String OtherSource { get { return m_OtherSource; } }
        public static String multiplyLinkedSynonyms { get { return m_multiplyLinkedSynonyms; } }
        public static String DateCreated { get { return m_DateCreated; } }
        public static String TaxAuthor { get { return m_TaxAuthor; } }
        public static String TsnParent { get { return m_TsnParent; } }
        public static String TaxNameFull { get { return m_TaxNameFull; } }
        public static String ValidCredibility { get { return m_ValidCredibility; } }
        public static String TaxSynonymsArray { get { return m_TaxSynonymsArray; } }
        public static String TaxNameVermaular_Array { get { return m_TaxNameVermaular_Array; } }
        public static String kingdom { get { return m_kingdom; } }
        public static String acceptedTSN { get { return m_acceptedTSN; } }
        public static String hierarchySoFarWRanks { get { return m_hierarchySoFarWRanks; } }
        public static String GeograficRange { get { return m_GeograficRange; } }
        public static String TaxNameWOInd { get { return m_TaxNameWOInd; } }
        public static String _version_ { get { return m__version_; } }
        public static String Coment_Array { get { return m_Coment_Array; } }
        public static String TaxHierarchy_TSN_Array { get { return m_TaxHierarchy_TSN_Array; } }
        public static String TaxHierarchy_ShortArray { get { return m_TaxHierarchy_ShortArray; } }

        public static String GetCacheHtml { get { return GetHtml_Bld(); } }
        private static String GetHtml_Bld()
        {
            String szHtml = "";
            szHtml += "<h2>ITIS DATA</h2>";
            szHtml += "<br><b>Info:</b>" + m_TaxLevel + ": " + m_TaxNameFull + ", " + m_TaxAuthor + " " + m_ValidIs + " " + m_ValidCredibility + ". " + m_ValidUnacceptReason;
            szHtml += "<br><b>Taxa TaxHierarchy:</b>" + TaxHierarchy_ShortArrayClear;
            szHtml += "<br><b>More info:</b>" + m_Coment_Array;
            szHtml += "<br><b>cite:</b>" + m_Cite;
            return szHtml;
        }
        public static String TaxHierarchy_ShortArrayClear
        {
            get
            {
                String sz = "";
                String szComa = "";
                String[] szClear = m_TaxHierarchy_ShortArray.Split('-');
                for (int i = 0; i < szClear.Length; i++)
                {
                    sz += szComa;
                    szClear[i] = szClear[i].Remove(0, 4);
                    sz += szClear[i];
                    szComa = ",";
                }
                return sz;
            }
        }

    }
}