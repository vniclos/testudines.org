using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Web;
using testudines.cls.bbdd;
using System.Data;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
using testudines.cls.pdf;
using System.Globalization;
namespace testudines.cls.pdf
{
    public partial class pdf_bld_cites : System.Web.UI.Page
    {


  //      private ClsPdfEvents evPdf = new ClsPdfEvents();

        private Int32 g_ChapterNumber = 0;
        private Int32 g_SecctionNumber = 0;
        private static float g_Size_Margin_T = 30f;
        private static float g_Size_Margin_B = 80f;
        private static float g_Size_Margin_L = 50f;
        private static float g_Size_Margin_R = 50f;
        private float g_Size_Width = 0;
        private float g_Size_Height = 0;
    //    private Document g_Doc_Document;//= new Document(PageSize.A4, g_Size_Margin_L, g_Size_Margin_R, g_Size_Margin_T, g_Size_Margin_B);
        private System.IO.FileStream g_doc_FS;
      //  private PdfWriter g_Doc_Writer;

        private DataTable oTb= new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void scnBtnBuildPdf_Click(object sender, EventArgs e)
        {
      //      cls.pdf.ClsPDFCites oPDF = new cls.pdf.ClsPDFCites();
        //    oPDF.Fnc_0000_Doc_Create(System.DateTime.Now);

            // FncDebug(ref oPDF);



           // scnMsg.Text = "done";

          //  scnPdfEmbed.Text = oPDF.Pdf_HtmlShow;
            // FncPdfShow(oPDF.Pdf_FileNameShort);

        }

        protected void scnBtnCombine_Click(object sender, EventArgs e)
        {
            String szSelectTaxonAll = "Select DocId, ATaxGrpL2240Family as TaxFamily, ATaxGrpL2270Genus as TaxGenus, ATaxGrpL2280Specie as TaxSpecies, ATaxGrpL2281SubSpecie as TaxSubSpecies order by TaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie,ATaxGrpL2281SubSpecie from tdoclng_testudines_taxa_all";
            String szSelectCites = "Select Cites_TaxonId as DocIdCites, TaxFamily,TaxGenus,TaxSpecies,TaxSubSpecies from xtern_2018_cites order by TaxFamily,TaxGenus,TaxSpecies";
            String szSelectIucnRL = "Select internalTaxonId as DocIdIucn, familyName as TaxFamily,genusName as TaxGenus,speciesName  as TaxSpecies, '' as TaxSubSpecies from xtrn_2018_iucn_sumary";

            String szSelectRelation = "Select Family,Genus,Specie,DocId,DocIdCites,DocIdIucn from xtern_2018_relation order by Family,Genus,Specie,DocId;";
            String szSelectRelationDelete = "DELETE FROM xtern_2018_relation;";
            UInt64 DocId = 0;
            UInt64 DocIdCites = 0;
            UInt64 DocIdIucn = 0;
            UInt64 DocIdItis = 0;
            String TaxFamily = "";
            String TaxGenus = "";
            String TaxSpecie = "";
            String TaxSpecieSub = "";


            DataTable oTb = new DataTable();
            cls.bbdd.ClsRegXtern_2018_relation oRelation = new ClsRegXtern_2018_relation(cls.ClsGlobal.Connection_MARIADB);
            // vaciar tabla
            cls.bbdd.ClsMysql.FncGet_ExecuteNonQuery(ref szSelectRelationDelete);

            //...........................................
            //insertar datos de taxones
            oTb.Clear();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelectTaxonAll, ref oTb);
            foreach (DataRow oRow in oTb.Rows)
            {

                DocId = Convert.ToUInt64(oRow["DocId"].ToString());
                DocIdCites = 0;
                TaxFamily = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxFamily"].ToString().Trim());
                TaxGenus = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxGenus"].ToString().Trim());
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSpecies"].ToString().Trim());
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSubSpecies"].ToString().Trim());
                TaxSpecieSub = (oRow["TaxSubSpecie"].ToString().Trim());

                oRelation.Family = TaxFamily.Trim().ToLower();
                oRelation.Genus = TaxGenus.Trim().ToLower();
                oRelation.Specie = TaxSpecie.Trim().ToLower();
                oRelation.SpecieSub = TaxSpecieSub.Trim().ToLower();
                oRelation.DocId = DocId;
                oRelation.DocIdCites = 0;
                oRelation.DocIdItis = 0;
                oRelation.DocIdIucn = 0;
                oRelation.FncSqlSave();


               

            }
            //...........................................
            //Insertar registros del cites
            oTb.Clear();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelectIucnRL, ref oTb);
            foreach (DataRow oRow in oTb.Rows)
            {
                DocIdCites = Convert.ToUInt64(oRow["DocIdCites"].ToString());
                TaxFamily = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxFamily"].ToString().Trim()).ToLower();
                TaxGenus = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxGenus"].ToString().Trim()).ToLower();
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSpecies"].ToString().Trim()).ToLower();
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSubSpecies"].ToString().Trim()).ToLower();
                TaxSpecieSub = (oRow["TaxSubSpecie"].ToString().Trim());
                if (!oRelation.FncSqlFind(TaxFamily, TaxGenus, TaxSpecie, TaxSpecieSub))
                { oRelation.DocId = 0; }
                oRelation.Family = TaxFamily.Trim().ToLower();
                oRelation.Genus = TaxGenus.Trim().ToLower();
                oRelation.Specie = TaxSpecie.Trim().ToLower();
                oRelation.SpecieSub = TaxSpecieSub.Trim().ToLower();
                oRelation.DocIdCites = 0;
                oRelation.DocIdItis = 0;
                oRelation.DocIdIucn = 0;
                oRelation.FncSqlSave();
            }
            //Insertar registros del IucnRedList
            oTb.Clear();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSelectCites, ref oTb);
            foreach (DataRow oRow in oTb.Rows)
            {
                DocIdIucn = Convert.ToUInt64(oRow["DocIdIucn"].ToString());
                TaxFamily = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxFamily"].ToString().Trim()).ToLower();
                TaxGenus = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxGenus"].ToString().Trim()).ToLower();
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSpecies"].ToString().Trim()).ToLower();
                TaxSpecie = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oRow["TaxSubSpecies"].ToString().Trim()).ToLower();
                TaxSpecieSub = (oRow["TaxSubSpecie"].ToString().Trim());
                if (!oRelation.FncSqlFind(TaxFamily, TaxGenus, TaxSpecie, TaxSpecieSub))
                {
                    oRelation.DocId = 0;
                    oRelation.DocIdCites = 0;
                }
                oRelation.DocIdIucn = DocIdIucn;
                oRelation.Family = TaxFamily.Trim().ToLower();
                oRelation.Genus = TaxGenus.Trim().ToLower();
                oRelation.Specie = TaxSpecie.Trim().ToLower();
                oRelation.SpecieSub = TaxSpecieSub.Trim().ToLower();
               
                oRelation.DocIdItis = 0;
                
                oRelation.FncSqlSave();
            }
        }
    }
}