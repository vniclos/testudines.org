
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using iText.IO.Font;

using iText.Kernel.Geom;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Navigation;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Properties;
using iText.Layout.Element;

using iText.Svg;


//https://www.mikesdotnetting.com/article/80/create-pdfs-in-asp-net-getting-started-with-itextsharp
//https://www.mikesdotnetting.com/article/89/itextsharp-page-layout-with-columns
namespace testudines.cls.pdf
{
    class ClsPDFTaxon
    {
        private ClsTranslator oTranslator;
        private cls.bbdd.ClsReg_tdoclng_testudines_all oReg_Lft = new cls.bbdd.ClsReg_tdoclng_testudines_all();
        private cls.bbdd.ClsReg_tdoclng_testudines_all oReg_Rgh = new cls.bbdd.ClsReg_tdoclng_testudines_all();
        private cls.pdf.ClsPdfBuilder oPdfBld;
        #region global // objects
        //private MemoryStream m_Doc_MS = new MemoryStream();


        // String m_TranslateLft = "";
        //  String m_TranslateRgh = "";

        private String m_Dir_Root = "";
        private String m_Dir_Resources = "";
        private String m_Dir_Temp = "";
        private String m_Dir_Target = "";

        private String m_Pdf_FileNameShort = "";
        private String m_Pdf_FileNameFull = "";
        private String m_Pdf_URLFull = "";
        private String m_Pdf_URLShort = "";
        public String Pdf_URLShort { get { return m_Pdf_URLShort; } }
        // private float m_Pdf_MarginPageTop = 60f;
        //private float m_Pdf_MarginPageBottom = 60f;
        // private float m_Pdf_MarginPageLft = 40f;

        private String m_Pdf_HtmlShow = "";
        public String Pdf_HtmlShow { get { return m_Pdf_HtmlShow; } }
        private String m_Pdf_HtmlDownLoad = "";
        public String Pdf_HtmlDownLoad { get { return m_Pdf_HtmlDownLoad; } }


        private ulong m_Doc_DocId = 0;
        private String m_Doc_DocIdLng_Lft = "es";
        private String m_Doc_DocIdLng_Rgh = "en";


        private String m_Doc_Cite_Title = "";
        private String m_Doc_Cite_Title_Subtitle = "";
        private String m_Doc_Cite_Author = "";
        private String m_Doc_Cite_Year = System.DateTime.Now.Year.ToString();
        private String m_Doc_Cite_Authors = "";

        private String m_Doc_Cite_version = "";
        private String m_Doc_Cite_InURLText = "";
        private String m_Doc_Cite_InURL = "";
        private String m_Doc_Cite_DowloadFromURLText = "";
        private String m_Doc_Cite_DowloadFromURL = "";
        private String m_Doc_Cite_Translators = "";
        private String m_Doc_Cite_Acknoeleggment = "";
        private String m_Doc_Cite_ClearText = "";

        private String m_Doc_Meta_Title = "";
        public String Doc_Meta_Title { get { return m_Doc_Meta_Title; } }
        private String m_Doc_Meta_Author = "";
        private String m_Doc_Meta_Creator = "";
        private String m_Doc_Meta_KeyWords = "";
        private String m_Doc_Meta_Subject = "";

        private String m_Doc_Author = "";
        private String m_Doc_Authors = "";
        private String m_Doc_Acknowlegments = "";
        private String m_Doc_PdfVersion = "";
        public String Doc_PdfVersion { get { return m_Doc_PdfVersion; } }
        private String m_Doc_DateCreation = "";


        private String m_Doc_Title_Full = "";
        private String m_Doc_Title_WithOutAuthor = "";
        private String m_Doc_Title_Cover_01_FontNormal = "";
        private String m_Doc_Title_Cover_02_FontItalic = "";
        private String m_Doc_Title_Cover_03_FontNormal = "";
        private String m_Doc_Title_Cover_04_FontSubtitle = "";




        private Paragraph m_Doc_Paragraph_Title_Both = new Paragraph();
        private Paragraph m_Doc_Paragraph_Title_Lft = new Paragraph();
        private Paragraph m_Doc_Paragraph_Title_Rgh = new Paragraph();

        private Paragraph m_Doc_Paragraph_Text_Both = new Paragraph();
        private Paragraph m_Doc_Paragraph_Text_Lft = new Paragraph();
        private Paragraph m_Doc_Paragraph_Text_Rgh = new Paragraph();

        private Paragraph m_Doc_Paragraph_Img00 = new Paragraph();
        private Paragraph m_Doc_Paragraph_Img01_Lft = new Paragraph();
        private Paragraph m_Doc_Paragraph_Img02_Rgh = new Paragraph();


        //private String m_Doc_String_Title_Both = "";
        private String m_sTitle_Lft = "";
        private String m_sTitle_Rgh = "";
        private String m_sTitle_Both = "";

        private String m_sText_Lft = "";
        private String m_sText_Rgh = "";
        private String m_sText_Both = "";

        private String m_sImg_Path01_Lft = "";
        private String m_sImg_Path02_Lft = "";
        private String m_sImg_PathLogo = "";
        private String m_sImg_PathNoImage = "noimage.png";

        private String m_Msg = "";
        private String m_MsgError = "";
        public string MsgError { get { return m_MsgError; } }
        public string Msg { get { return m_Msg; } }




        #endregion global
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------
        //-------------------------------------------------------------------------

        public ClsPDFTaxon()
        {

        }
        public bool Fnc_01_01_Doc_Create(UInt64 pDocId, String pDocIdLng_Lft, String pDocIdLng_Rgh, String pCultureLft, String pCultureRgh)
        {
            oPdfBld = new cls.pdf.ClsPdfBuilder();
            oTranslator = new ClsTranslator(pCultureLft, pCultureRgh);
            bool bOk = true;
            Fnc_01_02_Doc_Clear();
            //............................
            bOk = Fnc_01_03_Doc_ReadData(ref pDocId, ref pDocIdLng_Lft, ref pDocIdLng_Rgh);
            if (!bOk)
            {
                m_Msg += "Fnc_01_02_Doc_ReadData return false";
                return false;
            }
            //............................
            //............................
            bOk = Fnc_01_04_Doc_CreatePDF();
            if (!bOk)
            {
                m_Msg += "Fnc_001_Doc_ReadDataBase return false";
                return false;
            }

            // build chapters 
            Fnc_C00_00_Add_Cover();
            Fnc_C01_00_Add_Abstract();
            Fnc_C02_00_Add_Description();
            Fnc_C03_00_Add_Natural();
            //Fnc_c004_00_Add_Taxa();
            // Fnc_C04_00_Add_Taxa();
            /*
        

            Fnc_0400_Add_taxa();
            Fnc_0500_Add_Care();
            Fnc_1000_Add_References();

            Fnc_012_Add_index();


            Fnc_999_Doc_End();


            m_Msg = "Acknowlegments=" + docAcknowlegments;
            m_Msg += "<br/> docCite=" + docCite;
            m_Msg += "<br/>docDateCreation = " + docDateCreation;
            m_Msg += "<br/>docMetaAuthor = " + docMetaAuthor;
            m_Msg += "<br/>docMetaCreator= " + docMetaCreator;
            m_Msg += "<br/>docMetaKeyWords= " + docMetaKeyWords;
            m_Msg += "<br/>docMetaSubject= " + docMetaSubject;
            m_Msg += "<br/>docMetaTitle= " + docMetaTitle;
            m_Msg += "<br/>DocPdfVersion= " + docPdfVersion;
            m_Msg += "<br/>docSubtitle = " + docSubtitle;

            m_Msg += "<br/>Pdf_FileNameShort= " + Pdf_FileNameShort;
            m_Msg += "<br/>Pdf_FileNameFull= " + Pdf_FileNameFull;
            m_Msg += "<br/>Pdf_URLFull= " + Pdf_URLFull;
            m_Msg += "<br/>Pdf_URLShort= " + Pdf_URLShort;

            */

            oPdfBld.Fnc_99_Add_End();
            //Fnc_999_Doc_End();
            return bOk;

        }
        private void Fnc_01_02_Doc_Clear()
        {
            oReg_Lft.FncClear();
            oReg_Rgh.FncClear();
            m_MsgError = "";
            m_Msg = "";
            oPdfBld.Set_00_Clear();
            m_Dir_Root = "";
            m_Dir_Resources = "";
            m_Dir_Temp = "";
            m_Dir_Target = "";

            m_Pdf_FileNameShort = "";
            m_Pdf_FileNameFull = "";
            m_Pdf_URLFull = "";
            m_Pdf_URLShort = "";
            //m_Pdf_MarginPageTop = 60f;
            //m_Pdf_MarginPageBottom = 60f;
            //m_Pdf_MarginPageLft = 40f;

            m_Pdf_HtmlShow = "";

            m_Pdf_HtmlDownLoad = "";


            m_Doc_DocId = 0;
            m_Doc_DocIdLng_Lft = "es";
            m_Doc_DocIdLng_Rgh = "en";

            m_Doc_Cite_Title = "";
            m_Doc_Cite_Title_Subtitle = "";
            m_Doc_Cite_Author = "";
            m_Doc_Cite_Year = System.DateTime.Now.Year.ToString();
            m_Doc_Cite_Authors = "";

            m_Doc_Cite_version = "";
            m_Doc_Cite_InURLText = "";
            m_Doc_Cite_InURL = "";
            m_Doc_Cite_DowloadFromURLText = "";
            m_Doc_Cite_DowloadFromURL = "";
            m_Doc_Cite_Translators = "";
            m_Doc_Cite_ClearText = "";

            m_Doc_Meta_Title = "";
            m_Doc_Meta_Author = "";
            m_Doc_Meta_Creator = "";
            m_Doc_Meta_KeyWords = "";
            m_Doc_Meta_Subject = "";

            m_Doc_Author = "";
            m_Doc_Authors = "";
            m_Doc_Acknowlegments = "";
            m_Doc_PdfVersion = "";
            m_Doc_DateCreation = "";

            m_Doc_Title_Full = "";
            m_Doc_Title_WithOutAuthor = "";
            m_Doc_Title_Cover_01_FontNormal = "";
            m_Doc_Title_Cover_02_FontItalic = "";
            m_Doc_Title_Cover_03_FontNormal = "";
            m_Doc_Title_Cover_04_FontSubtitle = "";

            //private String m_Doc_String_Title_Both = "";
            m_sTitle_Lft = "";
            m_sTitle_Rgh = "";
            m_sTitle_Both = "";

            m_sText_Lft = "";
            m_sText_Rgh = "";
            m_sText_Both = "";

            m_sImg_Path01_Lft = "";
            m_sImg_Path02_Lft = "";
            m_sImg_PathLogo = "";
            m_sImg_PathNoImage = "noimage.png";



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocId"></param>
        /// <param name="pFileNameShort"> for specie set gemus +" "+ Specie . for other set Taxa  level name</param>
        /// <param name="pDocIdLng_Lft"></param>
        /// <param name="pDocIdLng_Rgh"></param>
        /// <returns></returns>
        private bool Fnc_01_03_Doc_ReadData(ref ulong pDocId, ref String pDocIdLng_Lft, ref String pDocIdLng_Rgh)
        {
            oPdfBld.Set_00_Clear();
            bool bOk = true;
            m_Doc_DocId = pDocId;
            m_Doc_DocIdLng_Lft = pDocIdLng_Lft;
            m_Doc_DocIdLng_Rgh = pDocIdLng_Rgh;
            bOk = oReg_Lft.FncSqlFind(m_Doc_DocId, m_Doc_DocIdLng_Lft);
            m_Msg = oReg_Lft.errorstring;
            if (bOk) bOk = oReg_Rgh.FncSqlFind(m_Doc_DocId, m_Doc_DocIdLng_Rgh); ;
            if (!bOk) return false;
            //-------------------------------------------------------

            m_Doc_Title_Cover_01_FontNormal = "";
            m_Doc_Title_Cover_02_FontItalic = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            m_Doc_Title_Cover_03_FontNormal = oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year; ;

            if (m_Doc_Title_Cover_01_FontNormal != "") { m_Doc_Title_Full = m_Doc_Title_Cover_01_FontNormal; }
            if (m_Doc_Title_Cover_02_FontItalic != "" && m_Doc_Title_Full != "") { m_Doc_Title_Full += " " + m_Doc_Title_Cover_02_FontItalic; } else { m_Doc_Title_Full += m_Doc_Title_Cover_02_FontItalic; }
            if (m_Doc_Title_Cover_03_FontNormal != "" && m_Doc_Title_Full != "") { m_Doc_Title_Full += " " + m_Doc_Title_Cover_03_FontNormal; } else { m_Doc_Title_Full += m_Doc_Title_Cover_03_FontNormal; }

            m_Doc_Title_Cover_04_FontSubtitle = "";

            m_Doc_Title_WithOutAuthor = m_Doc_Title_Cover_02_FontItalic;

            m_Doc_Title_Full = m_Pdf_FileNameShort + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority + ", " + oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year;
            // todo nombre vulgar para resto de idiomas por si las fly
            if (oReg_Lft.oRegTaxaAll.ATaxNameVulgarEN != "") { m_Doc_Title_Cover_04_FontSubtitle = "[EN] " + oReg_Lft.oRegTaxaAll.ATaxNameVulgarEN + "."; }

            if (m_Doc_Title_Cover_04_FontSubtitle != "" && oReg_Lft.oRegTaxaAll.ATaxNameVulgarES != "") { m_Doc_Title_Cover_04_FontSubtitle += " "; }
            if (oReg_Lft.oRegTaxaAll.ATaxNameVulgarES != "") { m_Doc_Title_Cover_04_FontSubtitle += "[ES] " + oReg_Lft.oRegTaxaAll.ATaxNameVulgarES + "."; }

            if (m_Doc_DocIdLng_Lft != "es" && m_Doc_DocIdLng_Lft != "en")
            {
                if (m_Doc_Title_Cover_04_FontSubtitle != "" && oReg_Lft.oRegTaxa.LTaxNamesVulgar != "") { m_Doc_Title_Cover_04_FontSubtitle += " "; }
                if (oReg_Lft.oRegTaxa.LTaxNamesVulgar != "") { m_Doc_Title_Cover_04_FontSubtitle += "[" + m_Doc_DocIdLng_Lft.ToUpper() + "] " + oReg_Lft.oRegTaxa.LTaxNamesVulgar; }
            }


            if (m_Doc_DocIdLng_Rgh != "es" && m_Doc_DocIdLng_Rgh != "en")
            {
                if (m_Doc_Title_Cover_04_FontSubtitle != "" && oReg_Rgh.oRegTaxa.LTaxNamesVulgar != "") { m_Doc_Title_Cover_04_FontSubtitle += " "; }
                if (oReg_Rgh.oRegTaxa.LTaxNamesVulgar != "") { m_Doc_Title_Cover_04_FontSubtitle += "[" + m_Doc_DocIdLng_Lft.ToUpper() + "] " + oReg_Rgh.oRegTaxa.LTaxNamesVulgar; }
            }
            m_Doc_Author = oReg_Lft.oRegDoc.DocAuthor;
            m_Doc_Authors = oReg_Lft.oRegDoc.DocAuthors;
            m_Doc_Acknowlegments = oReg_Lft.oRegDoc.DocAcknowledgements;
            m_Doc_PdfVersion = oReg_Lft.oRegDoc.DocPdfVersion.ToString();
            m_Doc_DateCreation = cls.ClsUtils.FncDateToAAAA_MM_DD(System.DateTime.Today);
            m_Doc_Acknowlegments = oReg_Lft.oRegDoc.DocAcknowledgements;
            //..............................................
            m_Dir_Root = cls.ClsGlobal.DirRoot;
            m_Dir_Resources = cls.ClsGlobal.DirPdfResources;
            m_Dir_Temp = cls.ClsGlobal.DirTemp;
            m_Dir_Target = cls.ClsGlobal.DirMmediaPdf;
            m_sImg_PathLogo = m_Dir_Resources + "logo.jpg";
            m_sImg_PathNoImage = "noimage.png";

            m_Pdf_FileNameShort = cls.ClsUtils.FncPathFileNameNormalice((m_Doc_Title_WithOutAuthor.ToLower() + ".pdf"));
            m_Pdf_FileNameFull = cls.ClsUtils.FncPathCombine(m_Dir_Target, m_Pdf_FileNameShort);

            m_Pdf_URLShort = cls.ClsUtils.FncUrlCombine(cls.ClsGlobal.UrlMMediaPDF, m_Pdf_FileNameShort);
            m_Pdf_URLFull = cls.ClsUtils.FncUrlCombine(cls.ClsGlobal.UrlRoot, m_Pdf_URLShort);
            //-----------------------------------
            //m_Pdf_MarginPageTop = 60f;
            //m_Pdf_MarginPageBottom = 60f;
            //m_Pdf_MarginPageLft = 40f;
            //------------------------------

            m_Doc_Meta_Author = oReg_Lft.oRegDoc.DocAuthor;
            if (m_Doc_Meta_Author == "") m_Doc_Meta_Author = "V. Niclos";
            m_Doc_Meta_Creator = "testudines.org";
            m_Doc_Meta_KeyWords = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie.ToLower();
            m_Doc_Meta_KeyWords += ", " + oReg_Lft.oRegTaxaAll.ATaxNameVulgarEN + " " + oReg_Lft.oRegTaxaAll.ATaxNameVulgarES + ", " + oReg_Lft.oRegTaxaAll.ATaxGrpL2220SubOrder + ", " + oReg_Lft.oRegTaxaAll.ATaxGrpL2240Family;
            m_Doc_Meta_Subject = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie.ToLower() + ". In Testudines.org catalog  project: Include Description, Care, Taxonomy, Habitat ";
            m_Doc_Meta_Title = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;


            m_Doc_Cite_ClearText = "";


            m_Doc_Cite_Title = m_Pdf_FileNameFull;
            m_Doc_Cite_Title_Subtitle = "Description, Natural history, Care";
            m_Doc_Cite_Author = m_Doc_Author;
            m_Doc_Cite_Authors = m_Doc_Authors;
            m_Doc_Cite_Year = System.DateTime.Now.Year.ToString();

            m_Doc_Cite_version = m_Doc_PdfVersion;
            m_Doc_Cite_InURLText = "www.testudines.org Catalog project";
            m_Doc_Cite_InURL = "http://www.testudines.org";
            m_Doc_Cite_DowloadFromURLText = m_Pdf_URLFull;
            m_Doc_Cite_DowloadFromURL = m_Doc_Cite_DowloadFromURLText;//  m_Doc_Cite_DowloadFromURLText;






            //--------------------------------------------------------


            // add metas 




            Fnc_BLD_htmlpdfShow();




            return bOk;

        }

        private bool Fnc_01_04_Doc_CreatePDF()
        {
            oPdfBld.Set_02_SetDirAndFile(m_Dir_Root, m_Dir_Temp, m_Dir_Target, m_Dir_Resources, m_Pdf_FileNameShort, m_sImg_PathNoImage);
            oPdfBld.Set_03_SetMetas(m_Doc_Meta_Title, m_Doc_Meta_Author, m_Doc_Meta_Creator, m_Doc_Meta_KeyWords, m_Doc_Meta_Subject);
            oPdfBld.Set_04_SetCite(m_Doc_Cite_Author, m_Doc_Cite_Year, m_Doc_Cite_Authors, m_Doc_Cite_Title, m_Doc_Cite_Title_Subtitle, m_Doc_Cite_version,
            m_Doc_Cite_InURLText, m_Doc_Cite_InURL, m_Doc_Cite_DowloadFromURLText, m_Doc_Cite_DowloadFromURL, m_Doc_Cite_Translators, m_Doc_Acknowlegments);
            oPdfBld.Set_05_SetSizes(); // default values
            return oPdfBld.Fnc_Add_00_Start(m_Doc_Title_Cover_01_FontNormal + " " + m_Doc_Title_Cover_02_FontItalic);
        }
        //*****************************************************************************
        #region Fnc_C00_00_Add_Cover
        //*****************************************************************************
        private void Fnc_C00_00_Add_Cover()
        {
            String pImageCoverPath = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AAbsImg_Specie);
            oPdfBld.Fnc_Add_01_Cover(m_Doc_Title_Cover_01_FontNormal, m_Doc_Title_Cover_02_FontItalic, m_Doc_Title_Cover_03_FontNormal, m_Doc_Title_Cover_04_FontSubtitle, pImageCoverPath, m_sImg_PathLogo);
        }
        #endregion
        //*****************************************************************************
        #region Fnc_C01_00_Add_Abstract
        private void Fnc_C01_00_Add_Abstract()
        {
            String pBothTitle = "";
            string m_sTitle_Lft = "";
           

            String pImagePath_1 = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AAbsImg_Specie);
            String pImagePath_2 = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AAbsImg_HNatural);

            //String sz = "";
            Paragraph pBothParagraph = new Paragraph();
            pBothParagraph.SetBackgroundColor(ClsPdfStyle.ColorGray);
            pBothParagraph.SetPadding(10);

            String url = "";
            // link itis


            url = "https://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + oReg_Lft.oRegTaxaAll.ATax_ItisTsn.ToString() + "#null";
            pBothParagraph.Add(cls.pdf.ClsPdfTools.AddLinkUri("arrow", url).SetFontSize(ClsPdfStyle.FontSizeNormal).SetFontColor(ClsPdfStyle.ColorLinks));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(" ITIS TSN: " + oReg_Lft.oRegTaxaAll.ATax_ItisTsn.ToString() + ". "));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefaultItalic(oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(" " + oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(" " + oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year));
            pBothParagraph.Add(" (Valid " + oReg_Lft.oRegTaxaAll.Atax_ItisIsValid.ToString() + ") ");


            pBothParagraph.Add(ClsPdfStyle.BldTexDefault("\nClas.: "));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefaultItalic(oReg_Lft.oRegTaxaAll.ATaxGrpL2000Class));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(". Ord.: "));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefaultItalic(oReg_Lft.oRegTaxaAll.ATaxGrpL2210Order));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(". Subord. : "));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefaultItalic(oReg_Lft.oRegTaxaAll.ATaxGrpL2220SubOrder));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(". Fam.: "));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefaultItalic(oReg_Lft.oRegTaxaAll.ATaxGrpL2240Family));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault("\n" + oReg_Lft.DocLngId.ToUpper() + ": " + oReg_Lft.oRegTaxa.LTaxNamesVulgar + "." + oReg_Rgh.DocLngId.ToUpper() + ": " + oReg_Rgh.oRegTaxa.LTaxNamesVulgar));
            // link gbif
            url = "https://www.gbif.org/search?q=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "%20" + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pBothParagraph.Add("\n");
            pBothParagraph.Add(cls.pdf.ClsPdfTools.AddLinkUri("arrow", url).SetFontSize(ClsPdfStyle.FontSizeNormal));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(" GBIG. Global Biodiversity Information Facility. "));

            //  link cites
            url = "checklist.cites.org/#/es/search/scientific_name=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "+" + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pBothParagraph.Add("\n");
            pBothParagraph.Add(cls.pdf.ClsPdfTools.AddLinkUri("arrow", url).SetFontSize(ClsPdfStyle.FontSizeNormal));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault(" CITES. Convention on International Trade in Endangered Species. Apendix; " + oReg_Lft.oRegNatuAll.ANatDngLevelCites));
            //link iucn
            url = "https://www.iucnredlist.org/search/grid?query=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "%20" + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pBothParagraph.Add("\n");
            pBothParagraph.Add(cls.pdf.ClsPdfTools.AddLinkUri("arrow", url).SetFontSize(ClsPdfStyle.FontSizeNormal));
            pBothParagraph.Add(ClsPdfStyle.BldTexDefault("International Union for Conservation of Nature’s Red List. Level: " + oReg_Rgh.oRegNatuAll.ANatDngLevelRedList));
            pBothParagraph.SetMarginBottom(ClsPdfStyle.FontSizeNormal);

            String szLft = "";
            String szRgh = "";


            oTranslator.ind_Chapter01_00Abs(ref m_sTitle_Lft, ref m_sTitle_Rgh);

            oPdfBld.fnc_Add_0201_Chapter_Head(m_sTitle_Lft, m_sTitle_Rgh);
            oPdfBld.Fnc_Add_0204_Body(pImagePath_1, pImagePath_2, null, null, pBothTitle, pBothParagraph);

            oTranslator.description(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            szLft = oReg_Lft.oRegDesc.LDesAbstract + ".\n\n";
            szRgh = oReg_Lft.oRegDesc.LDesAbstract + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, szLft, szRgh);

            oTranslator.geography_distribution(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            szLft = oReg_Lft.oRegGeo.LGeoAbstract + ".\n\n";
            szRgh = oReg_Lft.oRegGeo.LGeoAbstract + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, szLft, szRgh);

            oTranslator.natural_history(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            szLft = oReg_Lft.oRegNatu.LNatuAsbstract + ".\n\n";
            szRgh = oReg_Lft.oRegNatu.LNatuAsbstract + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, szLft, szRgh);


            oTranslator.care(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            szLft = oReg_Lft.oRegCare.LCareAbstract + ".\n\n";
            szRgh = oReg_Lft.oRegCare.LCareAbstract + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, szLft, szRgh);
            /*
            oTranslator.distribution(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            szLft = oReg_Lft.oRegAbs.LAbsShortGeoCountries + ".\n\n";
            szRgh = oReg_Lft.oRegAbs.LAbsShortGeoCountries + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, szLft, szRgh);
            */

            String pImagePath_Range = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AAbsImg_Range);
            Paragraph p2 = new Paragraph();
            p2.SetHorizontalAlignment(HorizontalAlignment.CENTER);
            oPdfBld.fnc_Add_image_bottom(ref p2, pImagePath_Range);

            // poblemas superpone svg,
            //String szPath = @"C:\datos\_testudines20\www 20\mmedia\taxa\testudines\cryptodiras\testudinoidea\testudinidae\testudo\testudo_hermanni\tesutudo hermanni range 2.svg";
            //oPdfBld.fnc_Add_Image_svg(szPath);
        }
        #endregion // Fnc_C01_00_Add_Abstract
        //*****************************************************************************
        #region Fnc_C02_00_Add_Description
        //*****************************************************************************
        private void Fnc_C02_00_Add_Description()
        {
            String pBothTitle = "";
            string m_sTitle_Lft = "";
            string m_sTitle_Rgh = "";
            String pTextLft = "";
            String pTextRgh = "";

            //String sz = "";
            Paragraph pBothParagraph = new Paragraph();
            pBothParagraph.SetBackgroundColor(ClsPdfStyle.ColorGray);
            pBothParagraph.SetPadding(10);
            //..........................................................................
            // CHAPTER TITLE description
            oTranslator.ind_Chapter02_00description(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyVentral01);
            //m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_DesType02);
            oPdfBld.fnc_Add_0201_Chapter_Cover(m_sTitle_Lft, m_sTitle_Rgh, m_sImg_Path01_Lft);
            //.................................................................................
            // CHAPTER SECCTION TITLE Abstract
            oTranslator.ind_Chapter02_01desAbs(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false);
            // CHAPTER SECCTION BODY Abstract
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_DesType01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_DesType02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesAbstract));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesAbstract));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);
            //.................................................................................
            // CHAPTER SECCTION TITLE DORSAL 
            oTranslator.ind_Chapter02_02DesDors(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY DORSAL
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyDorsal01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyDorsal02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShape));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesViewDorsalShape));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, null, null, null, null);


            oTranslator.ind_Chapter02_02DesDorsShape(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShape) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShape) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_02DesDorsShields(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShields) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShields) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_02DesDorsColor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalColor) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalColor) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);
            //...............................................................               
            // SECCTION TITLE  Description Plastron
            //...............................................................
            oTranslator.ind_Chapter02_06DesVentralBridge(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY DORSAL
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyVentral01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyVentral02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeShape));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesViewVentralBridgeShape));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, null, null, null, null);

            oTranslator.ind_Chapter02_06DesVentralBridgeShape(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeShape) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeShape) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_06DesVentralBridgeShiedls(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShields) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShields) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_06DesVentralBridgeColor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeColor) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeColor) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);
            //...............................................................               
            // SECCTION TITLE  DESCRIPTION LATERAL 
            //...............................................................
            oTranslator.ind_Chapter02_06DesLateral(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY LATERAL
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyLateral01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyLateral02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewLateral));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesViewLateral));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);
            //...............................................................               
            // SECCTION TITLE  DESCRIPTION FRONTAL 
            //...............................................................
            oTranslator.ind_Chapter02_03DesFrontal(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY FRONTAL
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyFrontal01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyFrontal02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewFrontal));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesViewFrontal));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //...............................................................               
            // SECCTION TITLE  DESCRIPTION REAR 
            //...............................................................
            oTranslator.ind_Chapter02_05DesRear(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY REAR
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyRear01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyRear02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewRear));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesViewRear));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //.................................................................................
            // CHAPTER SECCTION TITLE HEADNECK 
            oTranslator.ind_Chapter02_07DesHeadNeck(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY HEADNECK
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_OtherHead01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_OtherHead01);
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, null, null, null, null);

            oTranslator.ind_Chapter02_07DesHeadNeckShape(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShape) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalShape) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_07DesHeadNeckColor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalColor) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewDorsalColor) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            //.................................................................................
            // CHAPTER SECCTION TITLE LEGSTAIL 
            oTranslator.ind_Chapter02_08DesLegsTail(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY LEGSTAIL
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_OtherLegs01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_OtherTail01);
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, null, null, null, null);

            oTranslator.ind_Chapter02_08DesLegsTailShape(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeShape) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeShape) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_08DesLegsTailColor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeColor) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesViewVentralBridgeColor) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            //...............................................................
            // SECCTION TITLE  DESCRIPTION DIMORPHISM 
            oTranslator.ind_Chapter02_10DesDimor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY DIMORPHISM
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Dimorphism01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Dimorphism01);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesDimorphism));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesDimorphism));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //.................................................................................
            // CHAPTER SECCTION TITLE BABYS 
            oTranslator.ind_Chapter02_09DesBabies(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY HEADNECK
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BabyDorsal01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_BodyVentral01);
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, null, null, null, null);

            oTranslator.ind_Chapter02_09DesBabiesShape(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesBabysShape) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesBabysShape) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            oTranslator.ind_Chapter02_09DesBabiesColor(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            pTextLft = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesBabysColor) + ".\n\n";
            pTextRgh = ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesBabysColor) + ".\n\n";
            oPdfBld.Fnc_Add_ParagraphTwoColumTitlesInline(m_sTitle_Lft, m_sTitle_Rgh, pTextLft, pTextRgh);

            //...............................................................
            // SECCTION TITLE  DESCRIPTION DIFERENTIATION 
            oTranslator.ind_Chapter02_11DesDifer(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY DIFERENTIATION
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Diferentiation01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Diferentiation02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesDiferentiation));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesDiferentiation));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //...............................................................
            // SECCTION TITLE  DESCRIPTION KEYS  
            if (oReg_Lft.oRegDesc.LDesKeys != "")
            {
                oTranslator.ind_Chapter02_12DesKeys(ref m_sTitle_Lft, ref m_sTitle_Rgh);
                oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
                                                                                      // CHAPTER SECCTION BODY KEYS
                m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_DesKeys01);
                m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_DesKeys02);
                m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesKeys));
                m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesKeys));
                oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);
            }
            //...............................................................
            // SECCTION TITLE  DESCRIPTION tYPES  
            if (oReg_Lft.oRegDesc.LDesHolotype != "")
            {
                oTranslator.ind_Chapter02_12DesHoloty(ref m_sTitle_Lft, ref m_sTitle_Rgh);
                oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
                                                                                      // CHAPTER SECCTION BODY tYPES
                m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Holotype01);
                m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ADesImg_Holotype02);
                m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesHolotype));
                m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesHolotype));
                oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);
            }
            //...............................................................
            // SECCTION TITLE  DESCRIPTION NOTES  
            if (oReg_Lft.oRegDesc.LDesNotes != "")
            {
                oTranslator.ind_Chapter02_13DesNotes(ref m_sTitle_Lft, ref m_sTitle_Rgh);
                oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
                m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegDesc.LDesNotes));
                m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegDesc.LDesNotes));
                oPdfBld.Fnc_Add_0204_Body(null, null, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);
            }
        }
        #endregion description
        //*****************************************************************************
        #region NATURAL HISTORY
        private void Fnc_C03_00_Add_Natural()
        {
            string m_sTitle_Lft = "";
            string m_sTitle_Rgh = "";


           // String sz = "";
            Paragraph pBothParagraph = new Paragraph();
            pBothParagraph.SetBackgroundColor(ClsPdfStyle.ColorGray);
            pBothParagraph.SetPadding(10);
            //..........................................................................
            // CHAPTER TITLE NATURAL
            oTranslator.ind_Chapter03_00Nat(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live01);
            oPdfBld.fnc_Add_0201_Chapter_Cover(m_sTitle_Lft, m_sTitle_Rgh, m_sImg_Path01_Lft);

            // CHAPTER SECCTION TITLE NATURAL LIVE STYLE
            oTranslator.ind_Chapter03_01NatLiveStyles(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false);
            // CHAPTER SECCTION BODY NATURAL LIVE STYLE
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuLifestyles));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuLifestyles));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);


            //...............................................................               
            // SECCTION TITLE  NATURAL MEDIA TYPE 
            //...............................................................
            oTranslator.ind_Chapter03_02NatMediaType(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY  MEDIA TYPE 
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AGeoImg_landscapes01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.AGeoImg_landscapes02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuMediaType));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuMediaType));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);


            //...............................................................               
            // SECCTION TITLE  NATURAL FOOD CHAIN
            //...............................................................
            oTranslator.ind_Chapter03_02NatMediaType(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY  FOOD CHAIN 
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Food01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Food02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuFoodChain));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuFoodChain));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //...............................................................               
            // SECCTION TITLE  NATURAL BREEDING
            //...............................................................
            oTranslator.ind_Chapter03_04NatBreeding(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true); // true = salto pagina
            // CHAPTER SECCTION BODY  BREEDING 
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuBreeding));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuBreeding));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

            //...............................................................               
            // SECCTION TITLE  NATURAL DANGER
            //...............................................................
            oTranslator.ind_Chapter03_05NatDanger(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false); // true = salto pagina
            // CHAPTER SECCTION BODY  DANGER 
            //m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            //m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuDangers));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuDangers));
            oPdfBld.Fnc_Add_0204_Body(null, null, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null, false);

            //...............................................................               
            // SECCTION TITLE  NATURAL PROTECCTION ACCTION 
            //...............................................................
            oTranslator.ind_Chapter03_06NatProActions(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false); // true = salto pagina
            // CHAPTER SECCTION BODY  DANGER 
            //m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            //m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuDangers));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuDangers));
            oPdfBld.Fnc_Add_0204_Body(null, null, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null, false);

            //...............................................................               
            // SECCTION TITLE  NATURAL NOTES  
            //...............................................................
            oTranslator.ind_Chapter03_07NatNotes(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false); // true = salto pagina
            // CHAPTER SECCTION BODY  NOTES 
            //m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            //m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Breeding01);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuNotes));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuNotes));
            oPdfBld.Fnc_Add_0204_Body(null, null, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null, false);




        }

        #endregion  NATURAL HISTORY
        #region BIO-GEOGRAPHY
        //=============================================================================
        //=============================================================================
        //=============================================================================
        //=============================================================================
        //=============================================================================
        //=============================================================================
        private void Fnc_C04_00_Add_BioGeography()
        {
            
            // CHAPTER SECCTION TITLE NATURAL LIVE STYLE
            oTranslator.ind_Chapter04_00_00_BioGeographic(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, true);
            // CHAPTER SECCTION BODY NATURAL LIVE STYLE
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuLifestyles));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuLifestyles));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);



        }
        #endregion

        //*****************************************************************************
        #region RANGE
        private void Fnc_C04_00_Geographic()
        {


            Paragraph pBothParagraph = new Paragraph();
            pBothParagraph.SetBackgroundColor(ClsPdfStyle.ColorGray);
            pBothParagraph.SetPadding(10);
            //..........................................................................
            // CHAPTER TITLE biogeography
            oTranslator.ind_Chapter04_00_00_Geo(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live01);
            oPdfBld.fnc_Add_0201_Chapter_Cover(m_sTitle_Lft, m_sTitle_Rgh, m_sImg_Path01_Lft);
            // CHAPTER SECCTION TITLE NATURAL GEOGRAPHICAL RANGE
            oTranslator.ind_Chapter03_01NatLiveStyles(ref m_sTitle_Lft, ref m_sTitle_Rgh);
            oPdfBld.fnc_Add_0202_ChapterSection_Head(m_sTitle_Lft, m_sTitle_Rgh, false);
            // CHAPTER SECCTION BODY NATURAL GEOGRAPHICAL RANGE
            m_sImg_Path01_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live01);
            m_sImg_Path02_Lft = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, oReg_Lft.oRegTaxaAllFile.ANatImg_Live02);
            m_Doc_Paragraph_Text_Lft = new Paragraph(ClsPdfTools.HtmToText(oReg_Lft.oRegNatu.LNatuLifestyles));
            m_Doc_Paragraph_Text_Rgh = new Paragraph(ClsPdfTools.HtmToText(oReg_Rgh.oRegNatu.LNatuLifestyles));
            oPdfBld.Fnc_Add_0204_Body(m_sImg_Path01_Lft, m_sImg_Path02_Lft, m_Doc_Paragraph_Text_Lft, m_Doc_Paragraph_Text_Rgh, null, null);

        }

        #endregion RANGE


        /*
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------


        #region climate
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0306_Add_life_MediaClimate(ref Chapter pChapter)
        {


            String pTitleES = "Clima";
            String pTitleEN = "wheather";
            string szitle = pTitleES + " - " + pTitleEN;


            Paragraph oPargraph = new Paragraph(szitle, ClsPdfStyles.Font_Title_ChapterSub);
            pChapter.Indentation = 0;
            m_SecctionNumber++;
            Section oSection = pChapter.AddSection(0, oPargraph);
            oSection.Indentation = 0;
            oSection.NumberStyle = Section.NUMBERSTYLE_DOTTED;

            String sz = "";
            sz += "AGeoKeyClimateEcozone:  " + oReg_Lft.oRegGeoAll.AGeoKeyClimateEcozone + ": " + oRegEcozone_ES.Title + " - " + oRegEcozone_EN.Title;
            sz += "\nAGeoKeyGeoBiogeographicRegion:  " + oReg_Lft.oRegGeoAll.AGeoKeyGeoBiogeographicRegion;
            sz += "\nAGeoKeyContinent:  " + oReg_Lft.oRegGeoAll.AGeoKeyContinent;
            sz += "\nAGeoKeyCountries Region:  " + oReg_Lft.oRegGeoAll.AGeoKeyCountries;
            sz += "\nAGeoLocLatitudMax Region:  " + oReg_Lft.oRegGeoAll.AGeoLocLatitudMax;
            sz += "\nAGeoLocLatitudMin Region:  " + oReg_Lft.oRegGeoAll.AGeoLocLatitudMin;
            sz += "\nAGeoLocation:  " + oReg_Lft.oRegGeoAll.AGeoLocation;
            sz += "\nAGeoClimateRefTit:  " + oReg_Lft.oRegGeoAll.AGeoClimateRefTit;
            sz += "\nurl:  " + oReg_Lft.oRegGeoAll.AGeoClimateRefUrl;
            sz += "\nLocation:  " + oReg_Lft.oRegGeoAll.AGeoClimateLocation;



            Paragraph oP = new Paragraph(sz, ClsPdfStyles.Font_Normal);
            oSection.Add(oP);
            oSection.Add(Fnc_0307_Add_life_MediaClimate());
        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private PdfPTable Fnc_0307_Add_life_MediaClimate()
        {

            string szES = Fnc_HtmToText(oReg_Lft.oRegGeo.LGeoClimate);
            string szEN = Fnc_HtmToText(oRegEN.oRegGeo.LGeoClimate);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateWheatherRain;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp;
            String pImg_3 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateWheatherSun;
            String pImg_4 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateWheatherSun;
            String pImg_5 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateWheatherBiome;
            String pImg_6 = oReg_Lft.oRegTaxaAllFile.AGeoImg_ClimateEcozoneKey;

            string sz = Fnc_HtmToText(oReg_Lft.oRegGeoAll.AGeoKeyClimateEcozone);
            sz += sz += Fnc_HtmToText(oReg_Lft.oRegGeoAll.AGeoKeyGeoBiogeographicRegion);
            int[] pTempMax = new int[18];
            int[] pTempMin = new int[18];
            int[] pTempAvg = new int[18];

            int[] pRainMLAvg = new int[18];
            int[] pRainDaysAvg = new int[18];
            Double[] pSunMin = new Double[18];
            Double[] pSunMax = new Double[18];
            Double[] pSunAvg = new Double[18];



            pTempMax[01] = oReg_Lft.oRegGeoAll.AGeoTmpMax01;
            pTempMax[02] = oReg_Lft.oRegGeoAll.AGeoTmpMax02;
            pTempMax[03] = oReg_Lft.oRegGeoAll.AGeoTmpMax03;
            pTempMax[04] = oReg_Lft.oRegGeoAll.AGeoTmpMax04;
            pTempMax[05] = oReg_Lft.oRegGeoAll.AGeoTmpMax05;
            pTempMax[06] = oReg_Lft.oRegGeoAll.AGeoTmpMax06;
            pTempMax[07] = oReg_Lft.oRegGeoAll.AGeoTmpMax07;
            pTempMax[08] = oReg_Lft.oRegGeoAll.AGeoTmpMax08;
            pTempMax[09] = oReg_Lft.oRegGeoAll.AGeoTmpMax09;
            pTempMax[10] = oReg_Lft.oRegGeoAll.AGeoTmpMax10;
            pTempMax[11] = oReg_Lft.oRegGeoAll.AGeoTmpMax11;
            pTempMax[12] = oReg_Lft.oRegGeoAll.AGeoTmpMax12;
            pTempMax[13] = oReg_Lft.oRegGeoAll.AGeoTmpMax_YearMin;
            pTempMax[14] = oReg_Lft.oRegGeoAll.AGeoTmpMax_YearAvg;
            pTempMax[15] = oReg_Lft.oRegGeoAll.AGeoTmpMax_YearMax;

            pTempMin[01] = oReg_Lft.oRegGeoAll.AGeoTmpMin01;
            pTempMin[02] = oReg_Lft.oRegGeoAll.AGeoTmpMin02;
            pTempMin[03] = oReg_Lft.oRegGeoAll.AGeoTmpMin03;
            pTempMin[04] = oReg_Lft.oRegGeoAll.AGeoTmpMin04;
            pTempMin[05] = oReg_Lft.oRegGeoAll.AGeoTmpMin05;
            pTempMin[06] = oReg_Lft.oRegGeoAll.AGeoTmpMin06;
            pTempMin[07] = oReg_Lft.oRegGeoAll.AGeoTmpMin07;
            pTempMin[08] = oReg_Lft.oRegGeoAll.AGeoTmpMin08;
            pTempMin[09] = oReg_Lft.oRegGeoAll.AGeoTmpMin09;
            pTempMin[10] = oReg_Lft.oRegGeoAll.AGeoTmpMin10;
            pTempMin[11] = oReg_Lft.oRegGeoAll.AGeoTmpMin11;
            pTempMin[12] = oReg_Lft.oRegGeoAll.AGeoTmpMin12;
            pTempMin[13] = oReg_Lft.oRegGeoAll.AGeoTmpMin_YearMin;
            pTempMin[14] = oReg_Lft.oRegGeoAll.AGeoTmpMin_YearAvg;
            pTempMin[15] = oReg_Lft.oRegGeoAll.AGeoTmpMin_YearMax;


            pTempAvg[01] = oReg_Lft.oRegGeoAll.AGeoTmpAvg01;
            pTempAvg[02] = oReg_Lft.oRegGeoAll.AGeoTmpAvg02;
            pTempAvg[03] = oReg_Lft.oRegGeoAll.AGeoTmpAvg03;
            pTempAvg[04] = oReg_Lft.oRegGeoAll.AGeoTmpAvg04;
            pTempAvg[05] = oReg_Lft.oRegGeoAll.AGeoTmpAvg05;
            pTempAvg[06] = oReg_Lft.oRegGeoAll.AGeoTmpAvg06;
            pTempAvg[07] = oReg_Lft.oRegGeoAll.AGeoTmpAvg07;
            pTempAvg[08] = oReg_Lft.oRegGeoAll.AGeoTmpAvg08;
            pTempAvg[09] = oReg_Lft.oRegGeoAll.AGeoTmpAvg09;
            pTempAvg[10] = oReg_Lft.oRegGeoAll.AGeoTmpAvg10;
            pTempAvg[11] = oReg_Lft.oRegGeoAll.AGeoTmpAvg11;
            pTempAvg[12] = oReg_Lft.oRegGeoAll.AGeoTmpAvg12;
            pTempAvg[13] = oReg_Lft.oRegGeoAll.AGeoTmpAvg_YearMin;
            pTempAvg[14] = oReg_Lft.oRegGeoAll.AGeoTmpAvg_YearAvg;
            pTempAvg[15] = oReg_Lft.oRegGeoAll.AGeoTmpAvg_YearMax;


            pRainMLAvg[01] = oReg_Lft.oRegGeoAll.AGeoRainML01;
            pRainMLAvg[02] = oReg_Lft.oRegGeoAll.AGeoRainML02;
            pRainMLAvg[03] = oReg_Lft.oRegGeoAll.AGeoRainML03;
            pRainMLAvg[04] = oReg_Lft.oRegGeoAll.AGeoRainML04;
            pRainMLAvg[05] = oReg_Lft.oRegGeoAll.AGeoRainML05;
            pRainMLAvg[06] = oReg_Lft.oRegGeoAll.AGeoRainML06;
            pRainMLAvg[07] = oReg_Lft.oRegGeoAll.AGeoRainML07;
            pRainMLAvg[08] = oReg_Lft.oRegGeoAll.AGeoRainML08;
            pRainMLAvg[09] = oReg_Lft.oRegGeoAll.AGeoRainML09;
            pRainMLAvg[10] = oReg_Lft.oRegGeoAll.AGeoRainML10;
            pRainMLAvg[11] = oReg_Lft.oRegGeoAll.AGeoRainML11;
            pRainMLAvg[12] = oReg_Lft.oRegGeoAll.AGeoRainML12;
            pRainMLAvg[13] = oReg_Lft.oRegGeoAll.AGeoRainML_YearMin;
            pRainMLAvg[14] = oReg_Lft.oRegGeoAll.AGeoRainML_YearAvg;
            pRainMLAvg[15] = oReg_Lft.oRegGeoAll.AGeoRainML_YearMax;
            pRainMLAvg[16] = oReg_Lft.oRegGeoAll.AGeoRainML_YearSum;


            pRainDaysAvg[01] = oReg_Lft.oRegGeoAll.AGeoRainDays01;
            pRainDaysAvg[02] = oReg_Lft.oRegGeoAll.AGeoRainDays02;
            pRainDaysAvg[03] = oReg_Lft.oRegGeoAll.AGeoRainDays03;
            pRainDaysAvg[04] = oReg_Lft.oRegGeoAll.AGeoRainDays04;
            pRainDaysAvg[05] = oReg_Lft.oRegGeoAll.AGeoRainDays05;
            pRainDaysAvg[06] = oReg_Lft.oRegGeoAll.AGeoRainDays06;
            pRainDaysAvg[07] = oReg_Lft.oRegGeoAll.AGeoRainDays07;
            pRainDaysAvg[08] = oReg_Lft.oRegGeoAll.AGeoRainDays08;
            pRainDaysAvg[09] = oReg_Lft.oRegGeoAll.AGeoRainDays09;
            pRainDaysAvg[10] = oReg_Lft.oRegGeoAll.AGeoRainDays10;
            pRainDaysAvg[11] = oReg_Lft.oRegGeoAll.AGeoRainDays11;
            pRainDaysAvg[12] = oReg_Lft.oRegGeoAll.AGeoRainDays12;
            pRainDaysAvg[13] = oReg_Lft.oRegGeoAll.AGeoRainDays_YearMin;
            pRainDaysAvg[14] = oReg_Lft.oRegGeoAll.AGeoRainDays_YearAvg;
            pRainDaysAvg[15] = oReg_Lft.oRegGeoAll.AGeoRainDays_YearMax;
            pRainDaysAvg[16] = oReg_Lft.oRegGeoAll.AGeoRainDays_YearSum;



            pSunMin[01] = oReg_Lft.oRegGeoAll.AGeoSunMin01;
            pSunMin[02] = oReg_Lft.oRegGeoAll.AGeoSunMin02;
            pSunMin[03] = oReg_Lft.oRegGeoAll.AGeoSunMin03;
            pSunMin[04] = oReg_Lft.oRegGeoAll.AGeoSunMin04;
            pSunMin[05] = oReg_Lft.oRegGeoAll.AGeoSunMin05;
            pSunMin[06] = oReg_Lft.oRegGeoAll.AGeoSunMin06;
            pSunMin[07] = oReg_Lft.oRegGeoAll.AGeoSunMin07;
            pSunMin[08] = oReg_Lft.oRegGeoAll.AGeoSunMin08;
            pSunMin[09] = oReg_Lft.oRegGeoAll.AGeoSunMin09;
            pSunMin[10] = oReg_Lft.oRegGeoAll.AGeoSunMin10;
            pSunMin[11] = oReg_Lft.oRegGeoAll.AGeoSunMin11;
            pSunMin[12] = oReg_Lft.oRegGeoAll.AGeoSunMin12;
            pSunMin[13] = oReg_Lft.oRegGeoAll.AGeoSunMin_YearMin;
            pSunMin[14] = oReg_Lft.oRegGeoAll.AGeoSunMin_YearAvg;
            pSunMin[15] = oReg_Lft.oRegGeoAll.AGeoSunMin_YearMax;



            pSunMax[01] = oReg_Lft.oRegGeoAll.AGeoSunMax01;
            pSunMax[02] = oReg_Lft.oRegGeoAll.AGeoSunMax02;
            pSunMax[03] = oReg_Lft.oRegGeoAll.AGeoSunMax03;
            pSunMax[04] = oReg_Lft.oRegGeoAll.AGeoSunMax04;
            pSunMax[05] = oReg_Lft.oRegGeoAll.AGeoSunMax05;
            pSunMax[06] = oReg_Lft.oRegGeoAll.AGeoSunMax06;
            pSunMax[07] = oReg_Lft.oRegGeoAll.AGeoSunMax07;
            pSunMax[08] = oReg_Lft.oRegGeoAll.AGeoSunMax08;
            pSunMax[09] = oReg_Lft.oRegGeoAll.AGeoSunMax09;
            pSunMax[10] = oReg_Lft.oRegGeoAll.AGeoSunMax10;
            pSunMax[11] = oReg_Lft.oRegGeoAll.AGeoSunMax11;
            pSunMax[12] = oReg_Lft.oRegGeoAll.AGeoSunMax12;
            pSunMax[13] = oReg_Lft.oRegGeoAll.AGeoSunMax_YearMin;
            pSunMax[14] = oReg_Lft.oRegGeoAll.AGeoSunMax_YearAvg;
            pSunMax[15] = oReg_Lft.oRegGeoAll.AGeoSunMax_YearMax;



            pSunAvg[01] = oReg_Lft.oRegGeoAll.AGeoSunAvg01;
            pSunAvg[02] = oReg_Lft.oRegGeoAll.AGeoSunAvg02;
            pSunAvg[03] = oReg_Lft.oRegGeoAll.AGeoSunAvg03;
            pSunAvg[04] = oReg_Lft.oRegGeoAll.AGeoSunAvg04;
            pSunAvg[05] = oReg_Lft.oRegGeoAll.AGeoSunAvg05;
            pSunAvg[06] = oReg_Lft.oRegGeoAll.AGeoSunAvg06;
            pSunAvg[07] = oReg_Lft.oRegGeoAll.AGeoSunAvg07;
            pSunAvg[08] = oReg_Lft.oRegGeoAll.AGeoSunAvg08;
            pSunAvg[09] = oReg_Lft.oRegGeoAll.AGeoSunAvg09;
            pSunAvg[10] = oReg_Lft.oRegGeoAll.AGeoSunAvg10;
            pSunAvg[11] = oReg_Lft.oRegGeoAll.AGeoSunAvg11;
            pSunAvg[12] = oReg_Lft.oRegGeoAll.AGeoSunAvg12;
            pSunAvg[13] = oReg_Lft.oRegGeoAll.AGeoSunAvg_YearMin;
            pSunAvg[14] = oReg_Lft.oRegGeoAll.AGeoSunAvg_YearAvg;
            pSunAvg[15] = oReg_Lft.oRegGeoAll.AGeoSunAvg_YearMax;



            PdfPTable pTable = new PdfPTable(10);
            pTable.WidthPercentage = 100;
            //float[] widths = new float[] {tmes, tempmax, tmin, tavg, rainML, rainDays, Sunmax, sunmin, Month };
            float[] widths = new float[] { 25f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 15f, 25f };
            pTable.SetWidths(widths);
            pTable.SpacingBefore = 40;
            Fnc_0307_Add_life_MediaClimate_RowTitle(ref pTable);
            // 1 first header

            for (int n = 1; n < 16; n++)
            {

                Fnc_0307_Add_life_MediaClimate_Row(n, ref pTempMax[n], ref pTempMin[n], ref pTempAvg[n], ref pRainMLAvg[n], ref pRainDaysAvg[n], ref pSunMin[n], ref pSunAvg[n], ref pSunMax[n], ref pTable);
            }

            return pTable;
            // 2 Month

        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0307_Add_life_MediaClimate_RowTitle(ref PdfPTable pTable)
        {

            int iCol = 6;
            PdfPCell[] OColCelT1 = new PdfPCell[iCol];
            //PdfPCell[] OColCelT2 = new PdfPCell[iCol];

            for (int i = 0; i < iCol; i++)
            {
                OColCelT1[i] = new PdfPCell();
                OColCelT1[i].Padding = 5;
                OColCelT1[i].HorizontalAlignment = Element.ALIGN_CENTER;
                OColCelT1[i].BorderWidth = 1;


            }
            Paragraph oP0 = new Paragraph("Mes", ClsPdfStyles.Font_Normal_B);
            oP0.Alignment = Element.ALIGN_CENTER;
            Paragraph oP1 = new Paragraph("Temperatura", ClsPdfStyles.Font_Normal_B);
            oP1.Alignment = Element.ALIGN_CENTER;
            Paragraph oP2 = new Paragraph("Lluvia", ClsPdfStyles.Font_Normal_B);
            oP2.Alignment = Element.ALIGN_CENTER;
            Paragraph oP3 = new Paragraph("Horas de sol", ClsPdfStyles.Font_Normal_B);
            oP3.Alignment = Element.ALIGN_CENTER;


            OColCelT1[0].AddElement(oP0);
            OColCelT1[1].AddElement(oP1);
            OColCelT1[1].Colspan = 3;
            OColCelT1[2].AddElement(oP2);
            OColCelT1[2].Colspan = 2;
            OColCelT1[3].AddElement(oP3);
            OColCelT1[3].Colspan = 3;
            OColCelT1[4].AddElement(oP0);
            OColCelT1[1].HorizontalAlignment = Element.ALIGN_CENTER;
            OColCelT1[2].HorizontalAlignment = Element.ALIGN_CENTER;
            OColCelT1[3].HorizontalAlignment = Element.ALIGN_CENTER;

            //..................................
            oP0.Clear();
            oP1.Clear();
            oP2.Clear();
            oP3.Clear();
            oP0.Add("Month");
            oP1.Add("Temperature");
            oP2.Add("Rain");
            oP3.Add("Hours of sun");
            OColCelT1[0].AddElement(oP0);
            OColCelT1[1].AddElement(oP1);
            OColCelT1[1].Colspan = 3;
            OColCelT1[2].AddElement(oP2);
            OColCelT1[2].Colspan = 2;
            OColCelT1[3].AddElement(oP3);
            OColCelT1[3].Colspan = 3;
            OColCelT1[4].AddElement(oP0);
            OColCelT1[1].HorizontalAlignment = Element.ALIGN_CENTER;
            OColCelT1[2].HorizontalAlignment = Element.ALIGN_CENTER;
            OColCelT1[3].HorizontalAlignment = Element.ALIGN_CENTER;
            pTable.AddCell(OColCelT1[0]);
            pTable.AddCell(OColCelT1[1]);
            pTable.AddCell(OColCelT1[2]);
            pTable.AddCell(OColCelT1[3]);
            pTable.AddCell(OColCelT1[4]);


            //-------------------

            int iCel = 10;
            Paragraph[] pText = new Paragraph[iCel];
            for (int i = 0; i < iCel; i++)
            {
                pText[i] = new Paragraph();
            }
            pText[0].Add(new Chunk("", ClsPdfStyles.Font_Normal));
            pText[1].Add(new Chunk("Min.", ClsPdfStyles.Font_Normal));
            pText[2].Add(new Chunk("Promedio\nAverage", ClsPdfStyles.Font_Normal));
            pText[3].Add(new Chunk("Max.", ClsPdfStyles.Font_Normal));
            pText[4].Add(new Chunk("ML/Dia\nML/Day", ClsPdfStyles.Font_Normal));
            pText[5].Add(new Chunk("Dias\nDays", ClsPdfStyles.Font_Normal));
            pText[6].Add(new Chunk("Min.", ClsPdfStyles.Font_Normal));
            pText[7].Add(new Chunk("Promedio\nAverage", ClsPdfStyles.Font_Normal));
            pText[8].Add(new Chunk("Max.", ClsPdfStyles.Font_Normal));
            pText[9].Add(new Chunk("", ClsPdfStyles.Font_Normal));

            PdfPCell[] OColCel = new PdfPCell[iCel];
            for (int i = 0; i < iCel; i++)
            {
                pText[i].PaddingTop = 0;

                OColCel[i] = new PdfPCell();
                OColCel[i].Padding = 2;
                OColCel[i].PaddingBottom = 3;

                OColCel[i].HorizontalAlignment = Element.ALIGN_CENTER;
                OColCel[i].BorderWidth = 1;
                OColCel[i].BorderWidthBottom = 1.5f;
                pText[i].Alignment = Element.ALIGN_CENTER;
                OColCel[i].AddElement(pText[i]);

                pTable.AddCell(OColCel[i]);
            }





        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0307_Add_life_MediaClimate_Row(int pN, ref int pTempMax, ref int pTempMin, ref int pTempAvg, ref int pRainMLAvg, ref int pRainDaysAvg, ref Double pSunMin, ref Double pSunAvg, ref Double pSunMax, ref PdfPTable pTable)
        {

            String[] aMonth_ES = new string[] { "", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", "Minimo", "Promedio", "Maximo", "Suma", "", "" };
            String[] aMonth_EN = new string[] { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December", "Minimun", "Average", "Maximun", "Sum", "", "" };
            int iCel = 10;

            Paragraph[] pText = new Paragraph[iCel];
            PdfPCell[] OColCel = new PdfPCell[iCel];
            for (int i = 0; i < iCel; i++)
            {
                pText[i] = new Paragraph();
                OColCel[i] = new PdfPCell();
            }

            //...............................
            //String.Format("{0:00.0}", 123.4567); ->123.4
            if (pN < 13)
            {
                pText[0].Add(new Phrase("  " + aMonth_ES[pN].ToString(), ClsPdfStyles.Font_Normal));
            }
            else
            {
                pText[0].Add(new Phrase("  " + aMonth_ES[pN].ToString(), ClsPdfStyles.Font_Normal_B));
            }

            pText[1].Add(new Phrase(String.Format("{0:0.0}", pTempMin), ClsPdfStyles.Font_Normal));
            pText[2].Add(new Phrase(String.Format("{0:0.0}", pTempAvg), ClsPdfStyles.Font_Normal));
            pText[3].Add(new Phrase(String.Format("{0:0.0}", pTempMax), ClsPdfStyles.Font_Normal));
            pText[4].Add(new Phrase(String.Format("{0:0.0}", pRainMLAvg), ClsPdfStyles.Font_Normal));
            pText[5].Add(new Phrase(String.Format("{0:0.0}", pRainDaysAvg), ClsPdfStyles.Font_Normal));
            pText[6].Add(new Phrase(String.Format("{0:0.0}", pSunMin), ClsPdfStyles.Font_Normal));
            pText[7].Add(new Phrase(String.Format("{0:0.0}", pSunAvg), ClsPdfStyles.Font_Normal));
            pText[8].Add(new Phrase(String.Format("{0:0.0}", pSunMax), ClsPdfStyles.Font_Normal));
            if (pN < 13)
            {
                pText[9].Add(new Phrase(aMonth_EN[pN] + "  ", ClsPdfStyles.Font_Normal));
            }
            else
            {
                pText[9].Add(new Phrase(aMonth_ES[pN].ToString(), ClsPdfStyles.Font_Normal_B));
            }

            // pText[1].Add(new Phrase(pTempMin.ToString()+ "  " , ClsPdfStyles.Font_Normal));
            //pText[2].Add(new Phrase(pTempAvg.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[3].Add(new Phrase(pTempMax.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[4].Add(new Phrase(pRainMLAvg.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[5].Add(new Phrase(pRainDaysAvg.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[6].Add(new Phrase(pSunMin.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[7].Add(new Phrase(pSunAvg.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[8].Add(new Phrase(pSunMax.ToString() + "  ", ClsPdfStyles.Font_Normal));
            //pText[9].Add(new Phrase("  "+aMonth_EN[pN] + "  ", ClsPdfStyles.Font_Normal));


            for (int i = 0; i < iCel; i++)
            {
                pText[i].Alignment = Element.ALIGN_MIDDLE;
                pText[i].PaddingTop = 5;

                OColCel[i].Padding = 0;
                OColCel[i].HorizontalAlignment = Element.ALIGN_RIGHT;
                OColCel[i].BorderWidth = 0.5f;
                if (i > 0)
                {
                    pText[i].Alignment = Element.ALIGN_RIGHT;
                    pText[i].IndentationRgh = 10f;
                }
                OColCel[i].AddElement(pText[i]);
                OColCel[i].MinimumHeight = 22f;
                if (pN > 12)
                {
                    OColCel[i].BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#eeeeee"));
                }
                pTable.AddCell(OColCel[i]);



            }



        }
        #endregion climate


        #region taxa
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0400_Add_taxa()
        {
            String pTitleES = "Taxonomia";
            String pTitleEN = "taxonomy";
            String pContentES = oReg_Lft.oRegDesc.LDesViewDorsal;
            String pContentEN = oRegEN.oRegDesc.LDesViewDorsal;
            String pChapterIndexTitle = pTitleES + " - " + pTitleEN;


            m_ChapterNumber++;
            m_SecctionNumber = 0;
            Chunk chunk = new Chunk(pChapterIndexTitle, ClsPdfStyles.Font_Title_Chapter_B);
            Chapter pChapter = new Chapter(new Paragraph(chunk), m_ChapterNumber);

            string ChapterNumber = m_ChapterNumber.ToString();
            //pChapterIndexTitle = ChapterNumber + " " + pChapterIndexTitle;


            PdfPTable oTable = new PdfPTable(3);
            oTable.WidthPercentage = 100;
            Fnc_0400_Add_taxa_Table(ref pChapter);
            Fnc_0401_Add_taxa_Sinonimous(ref pChapter);
            Fnc_0402_Add_taxa_Vulgar(ref pChapter);
            m_Doc_Document.Add(pChapter);


            pChapter.Clear();

        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0400_Add_taxa_Table(ref Chapter pChapter)
        {
            String sz = "";
            Paragraph oP = new Paragraph();
            //oF.Leading = 10;

            Chunk cTitle = new Chunk("\nNombre recomendado:\nrecommended name:\n", ClsPdfStyles.Font_Normal_B);
            oP.Add(cTitle);
            Chunk oSpecieGenus = new Chunk(oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie, ClsPdfStyles.Font_Normal_BI);
            oP.Add(oSpecieGenus);
            Chunk oAuthority = new Chunk((" (" + oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority + oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year + ")"), ClsPdfStyles.Font_Normal_B);
            oP.Add(oAuthority);
            pChapter.Add(oP);

            sz = "\nIntegrated Taxonomic Information System (ITIS) TSN.: " + oReg_Lft.oRegTaxaAll.ATax_ItisTsn.ToString() + " (Valid " + oReg_Lft.oRegTaxaAll.ATax_ItisIsValid.ToString() + ")";
            sz += " " + oReg_Lft.oRegTaxaAll.ATax_ItisInvalidateNote;
            Chunk cItsi = new Chunk(sz, ClsPdfStyles.Font_Normal_I);
            pChapter.Add(cItsi);







            PdfPTable oTable = new PdfPTable(3);

            oTable.WidthPercentage = 100;
            float[] widths = new float[] { 20f, 60f, 20f };
            oTable.SetWidths(widths);
            oTable.SpacingBefore = 10;
            Fnc_Table_Add_Row3("Nivel", "-", "Level", ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal_B, ref oTable);
            Fnc_Table_Add_Row3("Clase", oReg_Lft.oRegTaxaAll.ATaxGrpL2000Class, "Class", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Orden", oReg_Lft.oRegTaxaAll.ATaxGrpL2210Order, "Order", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Suborden", oReg_Lft.oRegTaxaAll.ATaxGrpL2220SubOrder, "Suborder", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Superfamilia", oReg_Lft.oRegTaxaAll.ATaxGrpL2230SupFamily, "Superfamily", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Familia", oReg_Lft.oRegTaxaAll.ATaxGrpL2240Family, "Family", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Familia", oReg_Lft.oRegTaxaAll.ATaxGrpL2250SubFamily, "Family", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Supergenero", oReg_Lft.oRegTaxaAll.ATaxGrpL2260SupGenus, "Supergenus", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Especie", oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie, "Specie", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);

            Fnc_Table_Add_Row3("Autoridad", oReg_Lft.oRegTaxaAll.ATaxGrpL2282Authority, "Authority", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal, ref oTable);
            Fnc_Table_Add_Row3("Año", oReg_Lft.oRegTaxaAll.ATaxGrpL2283Year, "Year", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal, ref oTable);

            Fnc_Table_Add_Row3("Subespecies", Fnc_HtmToText(oReg_Lft.oRegTaxaAll.ATaxGrpL2281SubSpecie), "Subspecies", ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_BI, ref ClsPdfStyles.Font_Normal, ref oTable);


            pChapter.Add(oTable);









        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0401_Add_taxa_Sinonimous(ref Chapter pChapter)
        {


            Fnc_Add_chapter_Section("Sinónimos", "Synonymous", Fnc_HtmToText(oReg_Lft.oRegTaxaAll.ATaxSinonimous), ref pChapter);



            Chunk chunkRead = new Chunk("\nRecomended read:\n", ClsPdfStyles.Font_Normal_B);
            pChapter.Add(chunkRead);
            String pTitle = " Turtles of the World: Annotated Checklist and Atlas of Taxonomy,";
            String pURL = "http://www.iucn-tftsg.org/checklist/";
            fnd_AddCiteURL_inChapter(pTitle, pURL, ref pChapter);

            pURL = "https://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + oReg_Lft.oRegTaxaAll.ATax_ItisTsn + "#null";
            pTitle = "ITIS ( Integrated Taxonomic Information System)";
            fnd_AddCiteURL_inChapter(pTitle, pURL, ref pChapter);

            pURL = "http://reptile-database.reptarium.cz/species?genus=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2260SupGenus + "&species=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2260SupGenus;
            pTitle = "The Reptile Database";
            fnd_AddCiteURL_inChapter(pTitle, pURL, ref pChapter);

            //https://www.biodiversitylibrary.org/search.aspx?SearchTerm=Testudo%20hermanni#/sections
            pURL = "www.biodiversitylibrary.org/search.aspx?SearchTerm=" + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "%20" + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "#/sections";
            pTitle = "biodiversitylibrary.org";
            fnd_AddCiteURL_inChapter(pTitle, pURL, ref pChapter);

        }
        private void Fnc_0402_Add_taxa_Vulgar(ref Chapter pChapter)
        {
            Fnc_Add_chapter_Section("Nombres vulgares", "Vulgar Names", Fnc_HtmToText(oReg_Lft.oRegTaxaAll.ATaxNameVulgarOthers), ref pChapter);


        }
        #endregion life

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************

        #region care
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_0500_Add_Care()
        {



            //pChapterIndexTitle = ChapterNumber + " " + pChapterIndexTitle;







            String pTitleES = "Cuidados en cautividad";
            String pTitleEN = "Care sheet";
            String pContentES = oReg_Lft.oRegAbs.LAbsCare;
            String pContentEN = oRegEN.oRegAbs.LAbsCare;
            String pChapterIndexTitle = pTitleES + " - " + pTitleEN;


            m_ChapterNumber++;
            m_SecctionNumber = 0;
            Chunk chunk = new Chunk(pChapterIndexTitle, ClsPdfStyles.Font_Title_Chapter_B);
            Chapter pChapter = new Chapter(new Paragraph(chunk), m_ChapterNumber);



            Fnc_0501_Add_Care_Abstract(ref pChapter);
            Fnc_0502_Add_Care_Values(ref pChapter);
            Fnc_0503_Add_Care_Food(ref pChapter);
            Fnc_0504_Add_Care_Indoor(ref pChapter);
            Fnc_0505_Add_Care_outdoor(ref pChapter);
            Fnc_0506_Add_Care_Breeding(ref pChapter);
            Fnc_0507_Add_Care_Notes(ref pChapter);


            m_Doc_Document.Add(pChapter);
            pChapter.Clear();

        }
        private void Fnc_0501_Add_Care_Abstract(ref Chapter pChapter)
        {
            string pTitleES = "Cuidados";
            String pTitleEN = "Care";
            string szES = Fnc_HtmToText(oReg_Lft.oRegAbs.LAbsCare);
            string szEN = Fnc_HtmToText(oRegEN.oRegAbs.LAbsCare);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }
        private void Fnc_0502_Add_Care_Values(ref Chapter pChapter)
        {
            string pTitleES = "Valores para su mantenimiento";
            String pTitleEN = "Values ​​for maintenance";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareValues);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareValues);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }
        private void Fnc_0503_Add_Care_Food(ref Chapter pChapter)
        {
            string pTitleES = "Alimentación";
            String pTitleEN = "Feeding";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareFood);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareFood);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }

        private void Fnc_0504_Add_Care_Indoor(ref Chapter pChapter)
        {
            string pTitleES = "Recintos interiores";
            String pTitleEN = "Indoor enclosures";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareVivariumIndoor);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareVivariumIndoor);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_VivariumIndoor01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_VivariumIndoor02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }
        private void Fnc_0505_Add_Care_outdoor(ref Chapter pChapter)
        {
            string pTitleES = "Recintos exteriores";
            String pTitleEN = "Outdoor enclosures";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareVivariumOutdoor);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareVivariumOutdoor);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_VivariumOutdoor01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_VivariumOutdoor02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }
        private void Fnc_0506_Add_Care_Breeding(ref Chapter pChapter)
        {
            string pTitleES = "Reproducción en cautividad";
            String pTitleEN = "Breeding in captivity";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareBreeding);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareBreeding);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_Breeding01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_Breeding02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }
        private void Fnc_0507_Add_Care_Notes(ref Chapter pChapter)
        {
            string pTitleES = "Notas";
            String pTitleEN = "Notes";
            string szES = Fnc_HtmToText(oReg_Lft.oRegCare.LCareNotes) + Fnc_HtmToText(oReg_Lft.oRegCare.LCareEspecialist);
            string szEN = Fnc_HtmToText(oRegEN.oRegCare.LCareNotes) + Fnc_HtmToText(oReg_Lft.oRegCare.LCareEspecialist);
            String pImg_1 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral01;
            String pImg_2 = oReg_Lft.oRegTaxaAllFile.ACareImg_gral02;

            Fnc_Add_chapter_Section(pImg_1, pImg_2, pTitleES, pTitleEN, szES, szEN, ref pChapter, null);
        }


        #endregion care

        #region References
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_1000_Add_References()
        {
            String pTitleES = "Referencias y agradecimientos";
            String pTitleEN = "References & Acknowledgement";
            String pContentES = oReg_Lft.oRegDesc.LDesViewDorsal;
            String pContentEN = oRegEN.oRegDesc.LDesViewDorsal;
            String pChapterIndexTitle = pTitleES + " - " + pTitleEN;


            m_ChapterNumber++;
            m_SecctionNumber = 0;
            Chunk chunk = new Chunk(pChapterIndexTitle, ClsPdfStyles.Font_Title_Chapter_B);
            Chapter pChapter = new Chapter(new Paragraph(chunk), m_ChapterNumber);

            string ChapterNumber = m_ChapterNumber.ToString();
            //pChapterIndexTitle = ChapterNumber + " " + pChapterIndexTitle;

            Fnc_1001_Add_Reference_ack(ref pChapter);
            Fnc_1002_add_ReferenceMain(ref pChapter);
            Fnc_1003_Add_References_Bibl(ref pChapter);
            m_Doc_Document.Add(pChapter);


            pChapter.Clear();
        }

        private void Fnc_1001_Add_Reference_ack(ref Chapter pChapter)
        {
            string pTitleES = "Agradecimientos";
            String pTitleEN = "Acknowledgement";
            string szTextAllLng = Fnc_HtmToText(oReg_Lft.oRegDoc.DocAcknowledgements);

            Fnc_Add_chapter_Section(pTitleES, pTitleEN, szTextAllLng, ref pChapter);
            m_Doc_Document.NewPage();

        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_1002_add_ReferenceMain(ref Chapter pChapter)
        {
            m_Doc_Document.NewPage();
            string pTituleES = "Principales fuentes";
            String pTituleEN = "Main sources";


            m_SecctionNumber++;
            string SecctionTitle = pTituleES + " - " + pTituleEN;

            string chapterNumber = m_ChapterNumber.ToString();
            string pChapterIndexTitle = chapterNumber + " " + SecctionTitle;


            Paragraph oPargraph = new Paragraph(SecctionTitle, ClsPdfStyles.Font_Title_Chapter_B);
            oPargraph.Leading = 20;
            pChapter.Indentation = 0;

            Section oSection = pChapter.AddSection(0, oPargraph);

            oSection.Indentation = 0;
            oSection.NumberStyle = Section.NUMBERSTYLE_DOTTED;



            Paragraph oP = new Paragraph();
            oP.Font = ClsPdfStyles.Font_Normal;





            Phrase pPhrase_1 = new Phrase();
            Phrase pPhrase_2 = new Phrase();
            Phrase pPhrase_3 = new Phrase();
            PdfPTable pTable = new PdfPTable(3);
            pTable.WidthPercentage = 100;
            float[] widths = new float[] { 20f, 80f, 60f };
            pTable.SetWidths(widths);
            pTable.SpacingBefore = 10;

            string pImgPath = "";
            string pLinkUrl = "";
            string pLinkTxt = "";
            string pText = "";

            // Facebook group
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/testudines-facebook.jpg");
            pLinkUrl = "https://www.facebook.com/groups/testudines.org/";
            pLinkTxt = "Go to testudines.org facebook group";
            pText = "Testudines.org facebook group";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            // ITIS
            String ItisTsn = oReg_Lft.oRegTaxaAll.ATax_ItisTsn.ToString();
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/64-125-itis.png");
            pLinkUrl = "https://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + ItisTsn + "#null";
            pLinkTxt = "Go ItisTsn=" + ItisTsn;
            pText = "Integrated Taxonomic Information System(ITIS)(http://www.itis.gov)";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            // Reptile database
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/reptile-database.jpg");
            pLinkUrl = oReg_Lft.oRegTaxaAll.ALnkReptileDataBase;
            pLinkTxt = "Go Reptile database " + oReg_Lft.oRegTaxaAll.ATaxGrpL2260SupGenus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pText = "Uetz, P., Freed, Hallermann J. The Reptile Database, http://www.reptile-database.org,  http://reptile-database.reptarium.cz/ ";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            // cites https://www.cites.org/esp/search/site/testudo%20hermanni
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/iucn red list.jpg");

            //"http://checklist.cites.org/#/es/search/output_layout=alphabetical&scientific_name=testudo+hermanni
            string szSearch2 = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "+" + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pLinkUrl = "http://checklist.cites.org/#/es/search/output_layout=alphabetical&scientific_name=" + szSearch2;
            pLinkTxt = "Go CITES " + oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + " " + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;

            pText = "The IUCN Red List of Threatened Species. http://www.iucnredlist.org ISSN 2307-8235 © International Union for Conservation of Nature and Natural Resources. ";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            ///
            //Turtles of the World: Annotated Checklist and Atlas of Taxonomy, Synonymy, Distribution, and Conservation Status (8th Ed.). In: Rhodin, A.G.J., Iverson, J.B., van Dijk, P.P., Saumure, R.A., Buhlmann, K.A., Pritchard, P.C.H., and Mittermeier, R.A. (Eds.). Conservation Biology of Freshwater Turtles and Tortoises: A Compilation Project of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group. Chelonian Research Monographs 7:1–292. doi: 10.3854/crm.7.checklist.atlas.v8.2017.
            if (oReg_Lft.oRegTaxaAll.ALnkIUCN != "")
            {
                pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/TurtlesoftheWorldChecklist.gif");


                pLinkUrl = "oReg_Lft.oRegTaxaAll.ALnkIUCN;";// 
                pLinkTxt = "Go to download document";
                pText = "IUCN";
                Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);
            }
            ///
            //Turtles of the World: Annotated Checklist and Atlas of Taxonomy, Synonymy, Distribution, and Conservation Status (8th Ed.). In: Rhodin, A.G.J., Iverson, J.B., van Dijk, P.P., Saumure, R.A., Buhlmann, K.A., Pritchard, P.C.H., and Mittermeier, R.A. (Eds.). Conservation Biology of Freshwater Turtles and Tortoises: A Compilation Project of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group. Chelonian Research Monographs 7:1–292. doi: 10.3854/crm.7.checklist.atlas.v8.2017.
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/TurtlesoftheWorldChecklist.gif");
            pLinkUrl = "http://www.iucn-tftsg.org/checklist";// 
            pLinkTxt = "Go to download document";
            pText = "Turtles of the World: Annotated Checklist and Atlas of Taxonomy, Synonymy, Distribution, and Conservation Status\nTurtle Taxonomy Working Group [Rhodin, A.G.J., Iverson, J.B., Bour, R. Fritz, U., Georges, A., Shaffer, H.B., and van Dijk, P.P.]. Turtles of the World: Annotated Checklist and Atlas of Taxonomy, Synonymy, Distribution, and Conservation Status (8th Ed.). In: Rhodin, A.G.J., Iverson, J.B., van Dijk, P.P., Saumure, R.A., Buhlmann, K.A., Pritchard, P.C.H., and Mittermeier, R.A. (Eds.). Project of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            //Turtles of the World: Annotated Checklist and Atlas of Taxonomy, Synonymy, Distribution, and Conservation Status (8th Ed.). In: Rhodin, A.G.J., Iverson, J.B., van Dijk, P.P., Saumure, R.A., Buhlmann, K.A., Pritchard, P.C.H., and Mittermeier, R.A. (Eds.). Conservation Biology of Freshwater Turtles and Tortoises: A Compilation Project of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group. Chelonian Research Monographs 7:1–292. doi: 10.3854/crm.7.checklist.atlas.v8.2017.
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/TurtlesoftheWorldChecklist.gif");
            pLinkUrl = "http://www.iucn-tftsg.org/taxonomic-literature-database/";
            pLinkTxt = "Go to download document";
            pText = "Turtles of the World: Online Turtle Taxonomic Literature Database and PDF Library compiled and collected by the Turtle Taxonomy Working Group of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group ";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);


            //
            //
            //
            // red list ok
            pImgPath = System.Web.HttpContext.Current.Server.MapPath("/a_cls/pdf/img/redlist-125.png");
            string szSearch = oReg_Lft.oRegTaxaAll.ATaxGrpL2270Genus + "%20" + oReg_Lft.oRegTaxaAll.ATaxGrpL2280Specie;
            pLinkUrl = "https://www.iucnredlist.org/search?query=" + szSearch + "&searchType=species";
            pLinkTxt = "Go to download document";
            pText = "Turtles of the World: Online Turtle Taxonomic Literature Database and PDF Library compiled and collected by the Turtle Taxonomy Working Group of the IUCN/SSC Tortoise and Freshwater Turtle Specialist Group ";
            Fnc_Table_Add_Row3RefereneMain(pImgPath, pLinkTxt, pLinkUrl, pText, ref pTable);

            //• IUCN Red List for Testudines
            oP.Add(pTable);
            oSection.Add(oP);



        }

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private void Fnc_1003_Add_References_Bibl(ref Chapter pChapter)
        {
            m_Doc_Document.NewPage();
            string pTitleES = "Referencias y notas";
            String pTitleEN = "References and Notes";









            string szTextAllLng = Fnc_HtmToText(oReg_Lft.oRegDoc.DocBibliography);



            Fnc_Add_chapter_Section(pTitleES, pTitleEN, szTextAllLng, ref pChapter);



        }



        #endregion References

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        #region index
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************

        private void Fnc_012_Add_index()
        {
            m_Doc_Document.NewPage();
            Anchor AnchorIndex = new Anchor(".");
            AnchorIndex.Name = "AnchorIndex";
            //g_Doc_Document.Add(AnchorIndex);
            // m_Doc_Document.Add(topAnchor);

            //doc.Add(target);

            Paragraph opTitle = new Paragraph("INDICE - INDEX", ClsPdfStyles.Font_Title_Chapter_B);
            opTitle.Add(AnchorIndex);
            opTitle.SpacingAfter = 30f;
            opTitle.Alignment = Element.ALIGN_CENTER;
            m_Doc_Document.Add(opTitle);


            PdfPTable oTable = new PdfPTable(3);
            oTable.WidthPercentage = 100;
            float[] widths = new float[] { 8f, 70f, 20f };
            oTable.SetWidths(widths);
            oTable.SpacingBefore = 10;



            List<ClsPDFToc> toc = evPdf.getTOC();
            int i = 0;
            Fnc_Table_Add_Row3(new Chunk("Id."), new Chunk("Capítulo - Chapter"), new Chunk("Pag."), ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal_B, ref ClsPdfStyles.Font_Normal_B, ref oTable);
            Chunk cBlanc = new Chunk("-");
            foreach (ClsPDFToc pageIndex in toc)
            {

                Chunk cPage = new Chunk(pageIndex.page.ToString(), ClsPdfStyles.Font_Normal);

                //   Chunk cIdNum = new Chunk(g_TOC[i].IdNum, ClsPdfStyles.Font_Normal);
                Chunk cIdNum = new Chunk(pageIndex.idNum.ToString(), ClsPdfStyles.Font_Normal);

                Chunk cTitle = new Chunk(pageIndex.title, ClsPdfStyles.Font_Normal);
                PdfAction pGoto = PdfAction.GotoLocalPage(pageIndex.target, false);
                cIdNum.SetAction(PdfAction.GotoLocalPage(pageIndex.target, false));
                cTitle.SetAction(PdfAction.GotoLocalPage(pageIndex.target, false));
                cPage.SetAction(PdfAction.GotoLocalPage(pageIndex.target, false));
                Fnc_Table_Add_Row3(cIdNum, cTitle, cPage, ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal, ref ClsPdfStyles.Font_Normal_Blue, ref oTable);
                i++;
            }
            m_Doc_Document.Add(oTable);

        }

        #endregion index

        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        #region tools
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        //*****************************************************************************
        private bool m_switchColor = true;
        private GrayColor gray = new GrayColor(0.9f);
        private GrayColor grayLight = new GrayColor(1f);

        private void Fnc_Table_Add_Row3(Chunk col1, Chunk col2, Chunk col3, ref Font pFont1, ref Font pFont2, ref Font pFont3, ref PdfPTable pTable)
        {

            int iPaddingTop = 2;
            int iPaddingBottom = 2;

            Paragraph pCol1 = new Paragraph(col1);
            Paragraph pCol2 = new Paragraph(col2);
            Paragraph pCol3 = new Paragraph(col3);

            col1.Font = pFont1;
            col2.Font = pFont2;
            col3.Font = pFont3;

            PdfPCell OCellCol1 = new PdfPCell(pCol1);
            PdfPCell OCellCol2 = new PdfPCell(pCol2);
            PdfPCell OCellCol3 = new PdfPCell(pCol3);
            if (g_switchColor)
            {
                OCellCol1.BackgroundColor = grayLight;
                OCellCol2.BackgroundColor = grayLight;
                OCellCol3.BackgroundColor = grayLight;
            }
            else
            {
                OCellCol1.BackgroundColor = gray;
                OCellCol2.BackgroundColor = gray;
                OCellCol3.BackgroundColor = gray;
            }
            m_switchColor = !g_switchColor;
            OCellCol1.BorderWidth = 0;
            OCellCol1.Padding = 0;
            OCellCol1.PaddingTop = iPaddingTop;
            OCellCol1.PaddingBottom = iPaddingBottom;
            OCellCol1.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol1.VerticalAlignment = Element.ALIGN_MIDDLE;

            OCellCol2.BorderWidth = 0;
            OCellCol1.Padding = 0;
            OCellCol2.PaddingTop = iPaddingTop;
            OCellCol2.PaddingBottom = iPaddingBottom;
            OCellCol2.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol2.VerticalAlignment = Element.ALIGN_MIDDLE;


            OCellCol3.BorderWidth = 0;
            OCellCol3.Padding = 0;
            OCellCol3.PaddingTop = iPaddingTop;
            OCellCol3.PaddingBottom = iPaddingBottom;
            OCellCol3.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol3.VerticalAlignment = Element.ALIGN_MIDDLE;



            pTable.AddCell(OCellCol1);
            pTable.AddCell(OCellCol2);
            pTable.AddCell(OCellCol3);
        }


        private void Fnc_Table_Add_Row3RefereneMain(String ImgUrl, String pLinkTxt, String pLinkUrl, String pText, ref PdfPTable pTable)
        {

            Image image = Image.GetInstance(ImgUrl);




            Anchor oAnchor = new Anchor(pLinkTxt, cls.pdf.ClsPdfStyles.Font_Normal_Blue);
            oAnchor.Reference = pLinkUrl;


            PdfPCell OCellCol1 = new PdfPCell(image, true);
            PdfPCell OCellCol2 = new PdfPCell(new Phrase(pText));
            PdfPCell OCellCol3 = new PdfPCell(oAnchor);



            OCellCol1.Padding = 0;
            OCellCol1.PaddingRgh = 10f;
            OCellCol1.PaddingTop = 6;
            OCellCol1.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol1.BorderWidth = 1f;


            OCellCol1.Padding = 0;
            // ocell.PaddingRgh = 10f;
            OCellCol2.PaddingTop = 6;
            OCellCol2.PaddingLft = 4;
            OCellCol2.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol2.BorderWidth = 1f;


            OCellCol3.Padding = 0;
            // ocell.PaddingRgh = 10f;
            OCellCol3.PaddingTop = 6;
            OCellCol3.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol3.BorderWidth = 1f;



            pTable.AddCell(OCellCol1);
            pTable.AddCell(OCellCol2);
            pTable.AddCell(OCellCol3);

        }
        private void Fnc_Table_Add_Row3(String col1, String col2, String col3, ref Font pFont1, ref Font pFont2, ref Font pFont3, ref PdfPTable pTable)
        {
            Paragraph pCol1 = new Paragraph();
            pCol1.Add(new Chunk(col1, pFont1));
            PdfPCell OCellCol1 = new PdfPCell(pCol1);

            Paragraph pCol2 = new Paragraph();
            pCol2.Add(new Chunk(col2, pFont2));
            PdfPCell OCellCol2 = new PdfPCell(pCol2);

            Paragraph pCol3 = new Paragraph();
            pCol3.Add(new Chunk(col3, pFont3));
            PdfPCell OCellCol3 = new PdfPCell(pCol3);


            OCellCol1.BorderWidth = 0;
            OCellCol1.Padding = 0;
            // ocell.PaddingRgh = 10f;
            OCellCol1.PaddingTop = 6;
            OCellCol1.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol1.BorderWidth = 1f;

            OCellCol2.BorderWidth = 0;
            OCellCol1.Padding = 0;
            // ocell.PaddingRgh = 10f;
            OCellCol2.PaddingTop = 6;
            OCellCol2.HorizontalAlignment = Element.ALIGN_CENTER;
            OCellCol2.BorderWidth = 1f;

            OCellCol3.BorderWidth = 0;
            OCellCol3.Padding = 0;
            // ocell.PaddingRgh = 10f;
            OCellCol3.PaddingTop = 6;
            OCellCol3.HorizontalAlignment = Element.ALIGN_LEFT;
            OCellCol3.BorderWidth = 1f;



            pTable.AddCell(OCellCol1);
            pTable.AddCell(OCellCol2);
            pTable.AddCell(OCellCol3);
        }



        private void Fnc_Add_chapter_Section(String pTituleES, String pTituleEN, Paragraph pParagraph_AllLng, ref Chapter pChapter)
        {
            m_SecctionNumber++;
            string SecctionTitle = pTituleES + " - " + pTituleEN;

            string chapterNumber = m_ChapterNumber.ToString();
            string pChapterIndexTitle = chapterNumber + " " + SecctionTitle;


            Paragraph oPargraph = new Paragraph(SecctionTitle, ClsPdfStyles.Font_Title_Chapter_B);
            oPargraph.Leading = 20;
            pChapter.Indentation = 0;

            Section oSection = pChapter.AddSection(0, oPargraph);

            oSection.Indentation = 0;
            oSection.NumberStyle = Section.NUMBERSTYLE_DOTTED;





            pParagraph_AllLng.SetLeading(0, 1);
            oSection.Add(pParagraph_AllLng);
        }

        private void Fnc_Add_chapter_Section(String pTituleES, String pTituleEN, String szTextAllLng, ref Chapter pChapter)
        {
            m_SecctionNumber++;
            string SecctionTitle = pTituleES + " - " + pTituleEN;

            string chapterNumber = m_ChapterNumber.ToString();
            string pChapterIndexTitle = chapterNumber + " " + SecctionTitle;






            Paragraph oPargraph = new Paragraph(SecctionTitle, ClsPdfStyles.Font_Title_ChapterSub);
            oPargraph.Leading = 25;
            pChapter.Indentation = 0;

            Section oSection = pChapter.AddSection(0, oPargraph);

            oSection.Indentation = 0;
            oSection.NumberStyle = Section.NUMBERSTYLE_DOTTED;





            Paragraph pAll = new Paragraph(szTextAllLng, ClsPdfStyles.Font_Normal);
            pAll.SetLeading(0, 1);
            oSection.Add(pAll);

        }
        private void Fnc_Add_chapter_Section(String pImgUrl_1, String pImgUrl_2, String pTituleES, String pTituleEN, String pTextES, String pTextEN, ref Chapter pChapter, Paragraph pParagragAllTop)
        {
            m_SecctionNumber++;
            string SecctionTitle = pTituleES + " - " + pTituleEN;

            string chapterNumber = m_ChapterNumber.ToString();
            string pChapterIndexTitle = chapterNumber + " " + SecctionTitle;

            Paragraph oPargraph = new Paragraph(SecctionTitle, ClsPdfStyles.Font_Title_Bigger_BI);
            oPargraph.Leading = 20;
            pChapter.Indentation = 0;

            Section oSection = pChapter.AddSection(0, oPargraph);

            oSection.Indentation = 0;
            oSection.NumberStyle = Section.NUMBERSTYLE_DOTTED;


            pImgUrl_1 = cls.ClsUtils.FncImg_GetMed(pImgUrl_1);
            pImgUrl_2 = cls.ClsUtils.FncImg_GetMed(pImgUrl_2);
            Paragraph paragraphImg = new Paragraph();
            paragraphImg.Add("\n");
            FncAddImage500(pImgUrl_1, ref paragraphImg);
            paragraphImg.Add("\n");
            FncAddImage500(pImgUrl_2, ref paragraphImg);
            oSection.Add(paragraphImg);



            oSection.NewPage();

            PdfPTable oTable = new PdfPTable(2);
            oTable.WidthPercentage = 100;
            oTable.HorizontalAlignment = Element.ALIGN_CENTER;

            // 
            if (pParagragAllTop != null)
            {
                PdfPCell oCellAllLng = new PdfPCell(pParagragAllTop);
                oCellAllLng.BorderWidth = 0;
                oCellAllLng.Colspan = 3;
                oTable.AddCell(oCellAllLng);
            }

            string[] stringSeparators = new string[] { "\r\n" };
            //....................................................................
            Paragraph oP_ES = new Paragraph();
            // oP_ES.SetLeading(0, 3);
            Phrase oPh_tit_ES = new Phrase(new Chunk(pTituleES, ClsPdfStyles.Font_Medium));

            string[] lines = pTextES.Split(stringSeparators, StringSplitOptions.None);
            Console.WriteLine("Nr. Of items in list: " + lines.Length); // 2 lines
            oP_ES.Add(oPh_tit_ES);

            foreach (string s in lines)
            {
                Console.WriteLine(s); //But will print 3 lines in total.
                Phrase oPh_tex_ES = new Phrase(new Chunk(s, ClsPdfStyles.Font_Normal));
                oP_ES.Add(oPh_tex_ES);
            }


            //,,,,,,,,,,,,,,,,,,,,,,,
            Paragraph oP_EN = new Paragraph();
            //oP_EN.SetLeading(0, 3);
            oP_EN.PaddingTop = 20;

            Phrase oPh_tit_EN = new Phrase(new Chunk(pTituleEN, ClsPdfStyles.Font_Normal));
            lines = pTextEN.Split(stringSeparators, StringSplitOptions.None);
            oP_EN.Add(oPh_tit_EN);
            foreach (string s in lines)
            {

                Phrase oPh_tex_EN = new Phrase(new Chunk(s, ClsPdfStyles.Font_Normal));
                oP_EN.Add(oPh_tex_EN);
            }


            //-------------------------------------------------





            PdfPCell OCellES = new PdfPCell(oP_ES);
            OCellES.SetLeading(0f, 1.5f);
            OCellES.BorderWidth = 0;
            OCellES.Padding = 0;
            OCellES.PaddingRgh = 5f;
            OCellES.PaddingTop = 12;
            OCellES.HorizontalAlignment = Element.ALIGN_LEFT;
            oTable.AddCell(OCellES);

            PdfPCell OCellEN = new PdfPCell(oP_EN);
            OCellEN.SetLeading(0f, 1.5f);
            OCellEN.BorderWidth = 0;
            OCellEN.Padding = 0;
            OCellEN.PaddingLft = 5f;
            OCellEN.PaddingTop = 12;
            OCellEN.HorizontalAlignment = Element.ALIGN_LEFT;
            oTable.AddCell(OCellEN);





            // oTable.SetWidthPercentage(new float[2] { 460f, 140f }, PageSize.A4);
            oTable.HorizontalAlignment = Element.ALIGN_CENTER;
            oSection.Add(oTable);
            oSection.NewPage();
            // pChapter.Add(oSection);




        }



        //-------------------------------------------------------------
        //-------------------------------------------------------------

        public void Fnc_999_Doc_End()
        {
            m_Doc_Document.Close();

            m_Doc_Writer.Close();
            oReg_Lft.oRegDoc.DocPdfUrl = m_Pdf_URLShort;
            oReg_Lft.oRegDoc.DocPdfTitle = m_Doc_Meta_Title;
            oReg_Lft.oRegDoc.DocPdfVersion = m_DocPdfVersion;
            oReg_Lft.oRegDoc.FncSqlSave();

        }

        private void Fnc_Add_chapterImages(String pImg_1, String pImg_2)
        {
            m_Doc_Document.NewPage();
            Paragraph paragraph = new Paragraph();
            FncAddImage600(pImg_1, ref paragraph);
            FncAddImage600(pImg_2, ref paragraph);
            m_Doc_Document.Add(paragraph);
        }



        public void FncAddLInk(String pURL, String pText, ref Paragraph paragraph)
        {
            try

            {



                // Font fFont = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, iTextSharp.text.BaseColor.BLUE);
                Anchor anchor = new Anchor(pText, ClsPdfStyles.Font_Normal_Blue);


                anchor.Reference = pURL;
                paragraph.Add(anchor);

            }

            catch (DocumentException dex)

            {

                //Response.Write(dex.Message);

            }

            catch (IOException ioex)

            {

                //Response.Write(ioex.Message);

            }

            finally

            {


            }
        }
        public void fnd_AddCiteURL_inChapter(String pText, string pUrl, ref Chapter pChapterIndexTitle)
        {
            Paragraph oPar = new Paragraph(pText, ClsPdfStyles.Font_Normal);
            Anchor anchor = new Anchor(pUrl, ClsPdfStyles.Font_Min);
            anchor.Reference = pUrl;
            oPar.Add(anchor);
            pChapterIndexTitle.Add(oPar);
        }
        public void fnd_AddCiteURL(String pAuthors, String YearOrDate, String pTitle, String pSource, String pDateRead, String pURL, ref Paragraph paragraph)
        {
            paragraph.Font = ClsPdfStyles.Font_Min;
            String CiteText = pAuthors + " (" + System.DateTime.Now.Year.ToString() + ")" + pTitle + pSource + " at " + pDateRead;
            paragraph.Add(CiteText);
            Anchor anchor = new Anchor(pURL, ClsPdfStyles.Font_Min);
            anchor.Reference = pURL;
            paragraph.Add(anchor);

        }

        public void FncAddImage500(String pURL_Image, ref Paragraph paragraph)
        {

            pURL_Image = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, pURL_Image);

            float iTamañoDeseado = m_Size_Width - 120;
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(pURL_Image);
            jpg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            jpg.ScaleToFit(140f, 120f);   //Resize image depend upon your need
            jpg.SpacingBefore = 15f; //Give space before image
            jpg.SpacingAfter = 15f; //Give some space after the image
            if (jpg.Width > iTamañoDeseado)
            {
                //Maximum height is 800 pixels.
                float percentage = 0.0f;
                percentage = ((iTamañoDeseado * 100) / jpg.Width);
                jpg.ScalePercent(percentage);
            }
            paragraph.Add(jpg);

        }


        public void FncAddImage600(String pURL_Image, ref Paragraph paragraph)
        {

            pURL_Image = cls.ClsUtils.FncPathCombine(cls.ClsGlobal.DirRoot, pURL_Image);

            float iTamañoDeseado = m_Size_Width;
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(pURL_Image);
            jpg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            jpg.ScaleToFit(140f, 120f);   //Resize image depend upon your need
            jpg.SpacingBefore = 30f; //Give space before image
            jpg.SpacingAfter = 30f; //Give some space after the image
            if (jpg.Width > iTamañoDeseado)
            {
                //Maximum height is 800 pixels.
                float percentage = 0.0f;
                percentage = ((iTamañoDeseado * 100) / jpg.Width);
                jpg.ScalePercent(percentage);
            }
            paragraph.Add(jpg);


        }




        public String html_download()
        {
            String sz = "<a href = \"" + m_Pdf_URLShort + "\" title=\"download" + m_Doc_Meta_Title + "\" class=\"btn btn-primary btn-sm\" >Dowload</a>";
            return sz;
        }

        */
        private void Fnc_BLD_htmlpdfShow()
        {
            String embed = "If you are unable to view file, you can download from <a href = \"" + m_Pdf_URLShort + "\">here</a>";
            embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
            embed += "<div class=\"embed-responsive embed-responsive-210by297\">";




            //embed += "<embed src = \"" + m_Pdf_URLShort+ "\" width=\"600\" height=\"500\" alt=\"pdf\" pluginspage=\"http://www.adobe.com/products/acrobat/readstep2.html \"/>";
            //<embed src="pdfFiles/interfaces.pdf" width="600" height="500" alt="pdf" pluginspage="http://www.adobe.com/products/acrobat/readstep2.html"
            embed += "<object data=\"" + m_Pdf_URLShort + "\" type=\"application/pdf\" >";



            //embed += "</object></div>";
            embed += "</div>";
            m_Pdf_HtmlShow = embed;

            //scnPdfEmbed.Text = string.Format(embed, ResolveUrl(PdfUrl));
        }


        private void Fnc_Bld_HtmlPdfDowload()
        {
            m_Pdf_HtmlDownLoad = "<a href=\"" + m_Pdf_URLFull + "\" download=\"" + m_Pdf_FileNameShort + "\" alt=\"" + m_Pdf_FileNameShort + "\"> Donwload </a>";

        }








    }


}

