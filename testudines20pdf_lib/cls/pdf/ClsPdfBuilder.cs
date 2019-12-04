/*
 CONVENTION 
 1 variables of classs start in m_
 2  get function of variables are like variables name without m_
 3 functions of class start with Fnc for diference of functions
   of other libraries
 4 
 // https://api.itextpdf.com/iText7/dotnet/7.1.8/
 // study samples
 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iText.IO.Font;

using iText.Svg;

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
using iText.Kernel.Pdf.Navigation;
using iText.Svg;
using iText.Kernel.Geom;
using iText.IO.Image;



namespace testudines.cls.pdf
{
    public class ClsPdfBuilder
    {
        private UInt16 m_Level_L1_Chapter = 0;    // 1.- Natural history
        private UInt16 m_Level_L2_Secction = 0;   //1.1 Reproducciont
        private UInt16 m_Level_L3_SecctionSub = 0; // 1.1.1  Incubation 
        private bool m_TableRowSwitchColor = false;

        public UInt32 gg_tocNumPage { get; set; }

        public String FileNameTarget { get { return m_FileNameTarget; } }


        private protected string m_DirRoot = "";
        private protected string m_DirResources = "";
        private protected String m_DirTemp = "";
        private protected String m_DirTarget = "";
        private protected String m_FileNameSort;
        private protected String m_FileNameTemp = "";
        private protected String m_FileNameTarget = "";

        private protected String m_DocPdfVersion = "";
        public String DocPdfVersion { get { return m_DocPdfVersion; } }

        protected string m_DocPdfURLShort = "";

        public String DocPdfURLShort { get { return m_DocPdfURLShort; } }

        private protected string m_DocMetaTitle = "";
        public String DocMetaTitle { get { return m_DocMetaTitle; } }
        private protected String m_DocMetaAuthor = "";
        private protected string m_DocMetaCreator = "";
        private protected String m_DocMetaKeyWords = "";
        private protected string m_DocMetaSubject = "";


        private protected String m_DocCiteTitle_Full = ""; //= m_CiteTitle_01_FontNormal+m_CiteTitle_02_FontItalic+m_CiteTitle_03_FontNormal
        private protected String m_DocCiteTitle_Subtitle = "";   // subtitle in header in other line and font size min


        private protected String m_DocCiteAuthor = "";
        private protected String m_DocCiteAuthors = "";
        private protected String m_DocCiteYear = "";
        private protected String m_DocCiteVersion = "";
        private protected String m_DocCiteDowloadFromText = "";
        private protected String m_DocCiteDowloadFromURL = "";
        private protected String m_DocCiteInText = "";
        private protected String m_DocCiteInURL = "";
        private protected String m_DocCiteDateCreation = "";
        private protected String m_DocCiteTranslators = "";
        private protected String m_DocCiteAcknoeleggment = "";


        public float m_MarginPageTop = 60f;
        public float m_MarginPageBottom = 80f;
        public float m_MarginPageLeft = 60f;
        public float m_MarginPageRight = 60f;
        public float m_PaddingColums = 5;

        private bool m_IsError = false;
        public bool IsError { get { return m_IsError; } }

        private protected String m_ErrorMsg = "";
        public String ErrorMsg { get { return m_ErrorMsg; } }

        private ClsPdfEventHandler m_ClsPdfEventHandler;
        private protected PdfWriter m_PdfWriter;
        private protected PdfDocument m_PdfDoc;
        private protected Document m_Document;
        private protected PdfDocumentInfo m_info;
        private protected PdfOutline m_PdfOutline;
        private String m_PathNoImage = "";
        public ClsPdfBuilder() { }



        ~ClsPdfBuilder() { }

        public void Set_00_Clear()
        {



            m_DirRoot = "";
            m_DirResources = "";
            m_DirTemp = "";
            m_DirTarget = "";
            m_FileNameSort = "";
            m_FileNameTemp = "";
            m_FileNameTarget = "";
            m_DocMetaTitle = "";
            m_DocMetaAuthor = "";
            m_DocMetaCreator = "";
            m_DocMetaKeyWords = "";
            m_DocMetaSubject = "";
            m_DocCiteTitle_Full = "";
            m_DocCiteTitle_Subtitle = "";
            m_DocCiteAuthor = "";
            m_DocCiteAuthors = "";
            m_DocCiteYear = "";
            m_DocCiteVersion = "";
            m_DocCiteDowloadFromText = "";
            m_DocCiteDowloadFromURL = "";
            m_DocCiteInText = "";
            m_DocCiteInURL = "";
            m_DocCiteDateCreation = "";
            m_DocCiteTranslators = "";
            m_DocCiteAcknoeleggment = "";
            m_MarginPageTop = 60f;
            m_MarginPageBottom = 80f;
            m_MarginPageLeft = 60f;
            m_MarginPageRight = 60f;
            m_PaddingColums = 5;
            m_IsError = false;
            m_ErrorMsg = "";
            m_Level_L1_Chapter = 0;    // 1.- Natural history
            m_Level_L2_Secction = 0;   //1.1 Reproducciont
            m_Level_L3_SecctionSub = 0; // 1.1.1  Incubation 
            m_PathNoImage = "";

        }

        


        public bool Set_02_SetDirAndFile(String pDirRoot, String pDirTemp, String pDirTarget, String pDirResources, String pFileNameSort, String pNoImageFileName)
        {

            m_PathNoImage = pDirResources+pNoImageFileName;
            m_DirRoot = pDirRoot;
            m_DirResources = pDirResources;

            m_DirTarget = pDirTarget;
            m_DirTemp = pDirTemp;
            try
            {
                m_FileNameSort = pFileNameSort;

                
                m_FileNameTemp = ClsPdfTools.GetFileNameTempUnique(m_DirTemp, pFileNameSort);
                m_FileNameTarget = ClsPdfTools.PathCombine(pDirTarget, pFileNameSort);


                System.IO.Directory.CreateDirectory(m_DirTemp);
                System.IO.Directory.CreateDirectory(pDirTarget);
                if (System.IO.File.Exists(m_FileNameTemp)) { System.IO.File.Delete(m_FileNameTemp); }
            }
            catch (Exception xcpt)
            {

                m_ErrorMsg += "\n" + xcpt.Message;
                m_IsError = true;
                return false;
            }
            return true;
        }
        public void Set_03_SetMetas(String pDocMetaTitle, String pDocMetaAuthor, String pDocMetaCreator, String pDocMetaKeyWords, String pDocMetaSubject)
        {
            m_DocMetaTitle = pDocMetaTitle;

            m_DocMetaAuthor = pDocMetaAuthor;
            m_DocMetaCreator = pDocMetaCreator;
            m_DocMetaKeyWords = pDocMetaKeyWords;
            m_DocMetaSubject = pDocMetaSubject;

        }
        public void Set_04_SetCite(String pDocCiteAuthor, String pDocCiteYear, String pDocCiteAuthors, String pDocCiteTitle_Full, String pDocCiteTitle_Subtitle, String pDocCiteversion, String pDocCiteInText, String pDocCiteInURL, String pDocCiteDowloadFromText, String pDocCiteDowloadFromURL, String pDocCiteTranslators, String pDocCiteAcknoeleggment)
        {
            if (pDocCiteAuthor != "") { m_DocCiteAuthor = pDocCiteAuthor.Trim(); }
            if (pDocCiteYear != "") { m_DocCiteYear = pDocCiteYear.Trim(); }
            if (pDocCiteAuthors != "") { m_DocCiteAuthors = pDocCiteAuthors.Trim(); }
            if (pDocCiteTitle_Full != "") { m_DocCiteTitle_Full = pDocCiteTitle_Full.Trim(); }
            if (pDocCiteTitle_Subtitle != "") { m_DocCiteTitle_Subtitle = pDocCiteTitle_Subtitle.Trim(); }
            if (pDocCiteversion != "") { m_DocCiteVersion = pDocCiteversion.Trim(); }
            if (pDocCiteInText != "") { m_DocCiteInText = pDocCiteInText.Trim().Trim(); } else { m_DocCiteInText = "www.testudines.org"; }
            if (pDocCiteInURL != "") { m_DocCiteInURL = pDocCiteInURL.Trim().Trim(); } else { m_DocCiteInURL = "http://www.testudines.org"; }
            if (pDocCiteDowloadFromText != "") { m_DocCiteDowloadFromText = pDocCiteDowloadFromText.Trim(); }
            if (pDocCiteDowloadFromURL != "") { m_DocCiteDowloadFromURL = pDocCiteDowloadFromURL.Trim(); }
            if (pDocCiteTranslators != "") { m_DocCiteTranslators = pDocCiteTranslators.Trim(); }
            if (pDocCiteAcknoeleggment != "") { m_DocCiteAcknoeleggment = pDocCiteAcknoeleggment.Trim(); }
            m_DocCiteDateCreation = System.DateTime.Now.Date.Year.ToString() + "/" + System.DateTime.Now.Date.Month.ToString() + "/" + System.DateTime.Now.Date.Day.ToString() + "(ymd).";

        }
        public void Set_05_SetSizes(float pMarginPageTop = 60, float pMarginPageBottom = 40, float pMarginPageLeft = 50, float pMarginPageRight = 50)
        {
            m_MarginPageTop = pMarginPageTop;
            m_MarginPageBottom = pMarginPageBottom;
            m_MarginPageLeft = pMarginPageLeft;
            m_MarginPageRight = pMarginPageRight;
        }



        public bool Fnc_Add_00_Start(String pPageHeaderTitle)
        {



            try
            {
                // PdfDocument pdfDoc = new PdfDocument(new PdfWriter(dest,  new WriterProperties().addUAXmpMetadata().setPdfVersion(PdfVersion.PDF_1_7)));
                m_PdfWriter = null;
                m_PdfDoc = null;
                m_ClsPdfEventHandler = null;
                m_Document = null;
                ClsPdfStyle.Beguin();

                m_PdfWriter = new PdfWriter(m_FileNameTemp, new WriterProperties().AddUAXmpMetadata().SetPdfVersion(PdfVersion.PDF_1_7));
                m_PdfDoc = new PdfDocument(m_PdfWriter);


            https://issue.life/questions/50445436


                m_info = m_PdfDoc.GetDocumentInfo();
                m_info.SetTitle(m_DocMetaTitle);
                m_info.SetAuthor(m_DocMetaAuthor);
                m_info.SetCreator(m_DocMetaCreator);
                m_info.SetKeywords(m_DocMetaKeyWords);
                m_info.SetSubject(m_DocMetaSubject);


                m_Document = new Document(m_PdfDoc, PageSize.A4);
                m_Document.SetTopMargin(m_MarginPageTop);
                m_Document.SetBottomMargin(m_MarginPageBottom);
                m_Document.SetLeftMargin(m_MarginPageLeft);
                m_Document.SetRightMargin(m_MarginPageRight);



                m_ClsPdfEventHandler = new ClsPdfEventHandler(m_Document);
                m_ClsPdfEventHandler.HeaderCenter = pPageHeaderTitle;
                m_ClsPdfEventHandler.FooterVisible = true;
                m_ClsPdfEventHandler.HeaderVisible = true;

            }
            catch (Exception xcpt)
            {
                m_IsError = true;
                m_ErrorMsg += "\n" + xcpt.Message;
            }

            return !m_IsError;
        }

        public void Fnc_Add_01_Cover(String pTitle_01_FontNormal, String pTitle_02_FontItalic, String pTitle_03_FontNormal, String pSubTitle, String pImageCoverPath, String pImageCoverLogoPath)
        {

            this.FncVisibleHeadherFooter(true, true);
            String space = "";
            m_DocCiteTitle_Full = pTitle_01_FontNormal;
            if (m_DocCiteTitle_Full != "") space = " ";
            m_DocCiteTitle_Full += space + pTitle_02_FontItalic;
            if (m_DocCiteTitle_Full != "") { space = " "; }
            else
            {
                space = "";
            }
            m_DocCiteTitle_Full += space + pTitle_03_FontNormal;
            m_PdfDoc.AddEventHandler(iText.Kernel.Events.PdfDocumentEvent.START_PAGE, m_ClsPdfEventHandler);
            m_ClsPdfEventHandler.HeaderVisible = false;
            m_ClsPdfEventHandler.FooterVisible = false;

            PdfPage pdfPageHead = m_PdfDoc.AddNewPage();
            ClsPdfBookMarks.Add_L0_Root(ref m_PdfDoc, m_DocCiteTitle_Full, "Index");
            ClsPdfBookMarks.Add_L1_Cover(ref m_PdfDoc, "Inicio", "Home");
            //------------------------------------------------------------------
            // book marks index root
            //--------------------------------------------------------------
            Paragraph p = new Paragraph();
            p.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            p.SetPadding(0);
            //.itextpdf.layout.property.Property
            p.SetDestination("AnchorTop");


            //ImageData imgDataLogo = ImageDataFactory.Create(pImageCoverLogoPath);
            Image imgLogo = ClsPdfTools.ImageFitToBox( pImageCoverLogoPath, 64, 64, ref m_PathNoImage);

            imgLogo.SetMarginTop(5);
            imgLogo.SetMarginBottom(5);
            imgLogo.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            p.Add(imgLogo);
            p.Add("\n");
            p.Add(ClsPdfStyle.BldTextTwoMinB(m_DocCiteInText.ToUpper() + "\n\n").SetFontColor(ClsPdfStyle.ColorGreen).SetCharacterSpacing(1));
            if (pTitle_01_FontNormal != "") { p.Add(ClsPdfStyle.BldTexDefaultBig(pTitle_01_FontNormal)); }
            if (pTitle_02_FontItalic != "") { p.Add(ClsPdfStyle.BldTexDefaultBigItalic(" " + pTitle_02_FontItalic)); }
            if (pTitle_03_FontNormal != "") { p.Add(ClsPdfStyle.BldTexDefaultBig(" " + pTitle_03_FontNormal)); }
            if (pSubTitle != "") { p.Add(ClsPdfStyle.BldTexDefault("\n" + pSubTitle)); }
            if (m_DocCiteAuthor != "") { p.Add(ClsPdfStyle.BldTexDefault("\n" + m_DocCiteAuthor)); }
            if (m_DocCiteVersion != "") { p.Add(ClsPdfStyle.BldTexDefaultMin("\nV. " + m_DocCiteVersion + " - " + m_DocCiteDateCreation)); }


            Int32 imgSize = Convert.ToInt32(pdfPageHead.GetPageSize().GetWidth() - m_MarginPageLeft - m_MarginPageRight);
          //  ImageData imgDataTape = ImageDataFactory.Create(pImageCoverPath);
          //  Image imgTape = new Image(imgDataTape);

            Image imgTape =ClsPdfTools.ImageFitToBox( pImageCoverPath, imgSize, imgSize, ref m_PathNoImage);
            imgTape.SetMarginTop(15);
            imgTape.SetMarginBottom(15);
            imgTape.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            p.Add(imgTape);
            p.Add("\n ");
            m_Document.Add(p);

            Text t0;
            t0 = ClsPdfStyle.BldTexDefaultMin("\nContact: ");
            Text t1 = testudines.cls.pdf.ClsPdfTools.AddLinkUri("Facebook testudines.org", "https://www.facebook.com/groups/testudines.org/").SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(testudines.cls.pdf.ClsPdfStyle.FontSizeMin);
            Text t3 = testudines.cls.pdf.ClsPdfTools.AddLinkUri("Facebook V. Niclos", "https://www.facebook.com/vicente.niclos").SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(testudines.cls.pdf.ClsPdfStyle.FontSizeMin);
            Text t2 = ClsPdfStyle.BldTexDefaultMin(" & ");
            Paragraph p2 = new Paragraph();
            p2.Add(t0);
            p2.Add(t1);
            p2.Add(t2);
            p2.Add(t3);
            m_Document.Add(p2);

            Fnc_Add_Cite(ref m_Document);

            m_Document.Flush();
            Fnc_Add_00_PageBlanck();
            Fnc_Add_00_PageBlanck();


        }
        public void FncVisibleHeadherFooter(bool bVisibleHeather, bool bVisibleFoother)
        {

            m_ClsPdfEventHandler.HeaderVisible = bVisibleHeather;
            m_ClsPdfEventHandler.FooterVisible = bVisibleFoother;
        }

        //-------------------------------------------------------------
        //-------------------------------------------------------------
        public Table FncTableNewTwoColumns()
        {
            PdfPage pdfPageText = m_PdfDoc.GetLastPage();
            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPageText.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPageText.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };
            Table oTb = new Table(fTableColumnsWidths);
            return oTb;
        }



        public void fnc_Add_0201_Chapter_Head(String pTitleLeft, String pTitleRight)
        {
            m_Level_L1_Chapter++;
            m_Level_L2_Secction = 0;
            m_Level_L3_SecctionSub = 0;
            m_Document.Add(new AreaBreak());
            PdfPage pdfPage = m_PdfDoc.AddNewPage();
            int iPageNum = pdfPage.GetDocument().GetPageNumber(m_PdfDoc.GetLastPage());
            int iModule = iPageNum % 2;
            if (iModule == 0)
            {
                pdfPage = m_PdfDoc.AddNewPage();
            }
            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());

            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };
            Table oTbTitles = new Table(fTableColumnsWidths);
            oTbTitles.SetWidth(fSizeInsideWidth);
            oTbTitles.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            String titleLeft = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleLeft;
            String titleRight = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleRight;
            FNC_AddRow_Titles(ref oTbTitles, ref titleLeft, ref titleRight, 1); // 1= chapter
            m_Document.Add(oTbTitles);
            ClsPdfBookMarks.Add_L2_Chapter(ref m_PdfDoc, pTitleLeft, pTitleRight);

            m_Document.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
        }
        public void fnc_Add_0201_Chapter_Cover(String pTitleLft, String pTitleRgh, String pImagePath_1)
        {
           

            m_Level_L1_Chapter++;
            m_Level_L2_Secction = 0;
            m_Level_L3_SecctionSub = 0;
            m_Document.Add(new AreaBreak());
            PdfPage pdfPage = m_PdfDoc.GetLastPage();
            int iPageNum = pdfPage.GetDocument().GetPageNumber(m_PdfDoc.GetLastPage());
            int iModule = iPageNum % 2;
            if (iModule == 0)
            {
                Fnc_Add_00_PageBlanck();

            }
            pdfPage = m_PdfDoc.AddNewPage();
            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());

            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };
            Table oTbTitles = new Table(fTableColumnsWidths);
            oTbTitles.SetWidth(fSizeInsideWidth);
            oTbTitles.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            String titleLeft = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleRgh;
            String titleRight = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleRgh;
            FNC_AddRow_Titles(ref oTbTitles, ref titleLeft, ref titleRight, 1); // 1= chapter
            m_Document.Add(oTbTitles);
            ClsPdfBookMarks.Add_L2_Chapter(ref m_PdfDoc, pTitleLft, pTitleRgh);


            float fImgMaxWidth = fSizeInsideWidth;
            float fImgMaxHeight = fSizeInsideWidth; // (fSizeInsideHeight / 2) - 30;
            ClsPdfTools.fncGetImgMed(ref pImagePath_1);
            Image img1 =  ClsPdfTools.ImageFitToBox(pImagePath_1, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
            img1.SetMarginTop(20);
            Paragraph pImg = new Paragraph();
            pImg.SetMargin(0f);
            pImg.Add(img1);

            m_Document.Add(pImg);
            m_Document.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
            pdfPage = m_PdfDoc.AddNewPage();
            Fnc_Add_00_PageBlanck();

        }
        public void fnc_Add_0202_ChapterSection_Head(String pTitleLeft, String pTitleRight, bool pForceNewImparPage = true)
        {
            //m_Level_L1_Chapter++;
            m_Level_L2_Secction++;
            m_Level_L3_SecctionSub = 0;
            PdfPage pdfPage = m_PdfDoc.GetLastPage();
           
            if (pForceNewImparPage) {
                pdfPage = m_PdfDoc.AddNewPage();
                m_Document.Add(new AreaBreak());
            }
           
            int iPageNum = pdfPage.GetDocument().GetPageNumber(m_PdfDoc.GetLastPage());
            int iModule = iPageNum % 2;
            if (pForceNewImparPage && iModule == 0)
            {
                pdfPage = m_PdfDoc.AddNewPage();

            }
            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());

            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };
            Table oTbTitles = new Table(fTableColumnsWidths);
            oTbTitles.SetWidth(fSizeInsideWidth);
            oTbTitles.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            String titleLeft = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleLeft;
            String titleRight = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleRight;
            FNC_AddRow_Titles(ref oTbTitles, ref titleLeft, ref titleRight, 2); // 1= chapter
            m_Document.Add(oTbTitles);
            ClsPdfBookMarks.Add_L3_ChapterSection(ref m_PdfDoc, pTitleLeft, pTitleRight);
        }

        public void fnc_Add_0203_ChapterSectionSub_Head(String pTitleLeft, String pTitleRight)
        {
            // m_Level_L1_Chapter++;
            // m_Level_L2_Secction = 0;
            m_Level_L3_SecctionSub++;
            PdfPage pdfPage = m_PdfDoc.GetLastPage();

            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());

            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };
            Table oTbTitles = new Table(fTableColumnsWidths);
            oTbTitles.SetWidth(fSizeInsideWidth);
            oTbTitles.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            String titleLeft = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleLeft;
            String titleRight = "[" + m_Level_L1_Chapter.ToString() + "] " + pTitleRight;
            FNC_AddRow_Titles(ref oTbTitles, ref titleLeft, ref titleRight, 3); // 1= chapter

        }

        public void Fnc_Add_0204_Body(String pImagePath_1, String pImagePath_2, Paragraph pParagraphLeft, Paragraph pParagraphRight, String pBothTitle = null, Paragraph pBothParagraph = null,bool pForceNewPage=true)
        {

         

            PdfPage pdfPageText = m_PdfDoc.GetLastPage();
            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());
            // if (gg_tocNumPage % 2 != 0) { gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages()); }

             float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPageText.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPageText.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
            float[] fTableColumnsWidths = new float[] { (fSizeInsideWidth / 2) - m_PaddingColums, (fSizeInsideWidth / 2) - m_PaddingColums };

            //---------------------------------------------------------------------------
            // build Page LEFT images
            //--------------------------------------------------------------------------
            if (pImagePath_1 != null)
            { 
            float fImgMaxWidth = fSizeInsideWidth;
            float fImgMaxHeight = (GetLayout_free_Y() / 2) - 30;
            Image img1 = ClsPdfTools.ImageFitToBox(pImagePath_1, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
            img1.SetMarginTop(2);
            Image img2 = ClsPdfTools.ImageFitToBox(pImagePath_2, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
            img2.SetMarginTop(15);

            Paragraph pImg = new Paragraph();
            pImg.SetMargin(0f);
            pImg.Add(img1);
            pImg.Add(img2);
            m_Document.Add(pImg);
        }
            //m_Document.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));
            //--------------------------------------------------------------------------
            // build page left with titles and text
            //-------------------------------------------------------------------------- 
            if (pForceNewPage)
            {
                m_Document.Add(new AreaBreak());
                PdfPage PdfPageImg = m_PdfDoc.AddNewPage();
            }
            Table oTbText = new Table(fTableColumnsWidths);
            oTbText.SetWidth(fSizeInsideWidth);
            oTbText.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            // One colum for two/**/ LANGUAGES
            if (pBothParagraph != null) { Fnc_AddRow_CellCollSpan(ref oTbText, ref pBothTitle, ref pBothParagraph); }
            // text diferent for two languages
            if (pParagraphLeft != null)
            {
                Fnc_AddRow_CellTwoColumns(ref oTbText, ref pParagraphLeft, ref pParagraphRight);
            }
            m_Document.Add(oTbText);

            m_Document.Flush();
        }


        //...............................................................

        public void Fnc_Add_05_ParagraphFree(Paragraph p)
        {
            //m_Level_L1_Chapter++;
            //m_Level_L2_Secction++;
            // m_Level_L3_SecctionSub++;
            m_Document.Add(new AreaBreak());

            m_Document.Add(p);


        }
        public void fnc_Add_ParagraphTitlesInline(ref Paragraph pParagraph, String pTitle, String pTextx)
        {
            if (pTitle != null) pParagraph.Add(ClsPdfStyle.BldTexDefaultBold(pTitle + ": "));
            pParagraph.Add(ClsPdfStyle.BldTexDefault(pTextx));
        }
        public void Fnc_Add_ParagraphTwoColumTitlesInline(String pTitleLeft, String pTitleRight, String pTextLeft = null, String pTexthRight = null)
        {
            PdfPage pdfPageText = m_PdfDoc.GetLastPage();
            float fSizeInsideWidth = pdfPageText.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            //float fSizeInsideHeight = pdfPageText.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;


            float[] fTableColumnsWidths = new float[] { fSizeInsideWidth / 2, fSizeInsideWidth / 2 };
            Table oTbText = new Table(fTableColumnsWidths);
            oTbText.SetWidth(fSizeInsideWidth);
            oTbText.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            Paragraph pParagraphLeft = new Paragraph();
            Paragraph pParagraphRight = new Paragraph();
            pParagraphRight.SetPadding(0);
            pParagraphLeft.SetPadding(0);
            pParagraphRight.SetMargin(0);
            pParagraphLeft.SetMargin(0);

            fnc_Add_ParagraphTitlesInline(ref pParagraphLeft, pTitleLeft, pTextLeft);
            fnc_Add_ParagraphTitlesInline(ref pParagraphRight, pTitleRight, pTexthRight);

            // pParagraphLeft.Add(ClsPdfStyle.BldTexDefault(pTextLeft));
            // pParagraphRight.Add(ClsPdfStyle.BldTexDefault(pTexthRight));


            Fnc_AddRow_CellTwoColumns(ref oTbText, ref pParagraphLeft, ref pParagraphRight);
            m_Document.Add(oTbText);
            m_Document.Flush();

        }


        public void Fnc_Add_ParagraphTwoColums(String pTitleLeft, String pTitleRight, Paragraph pParagraphLeft = null, Paragraph pParagraphRight = null)
        {
            PdfPage pdfPageText = m_PdfDoc.GetLastPage();
            float fSizeInsideWidth = pdfPageText.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float[] fTableColumnsWidths = new float[] { fSizeInsideWidth / 2, fSizeInsideWidth / 2 };
            Table oTbText = new Table(fTableColumnsWidths);
            FNC_AddRow_Titles(ref oTbText, ref pTitleLeft, ref pTitleLeft, 2);
            Fnc_AddRow_CellTwoColumns(ref oTbText, ref pParagraphLeft, ref pParagraphRight);
            m_Document.Add(oTbText);
            m_Document.Flush();

        }
        public void Fnc_Add_04_Paragraph(String pTitleLeft, String pTitleRight, Paragraph pParagraphLeft = null, Paragraph pParagraphRight = null, String pBothTitle = null, Paragraph pParagraphBoth = null, String pImagePath_1 = null, String pImagePath_2 = null)
        {
            //m_Level_L1_Chapter++;
            //m_Level_L2_Secction++;
            m_Level_L3_SecctionSub++;
            m_Document.Add(new AreaBreak());

            PdfPage pdfPageText = m_PdfDoc.AddNewPage();
            // managing toc for do index page of document at end.

            gg_tocNumPage = Convert.ToUInt16(m_PdfDoc.GetNumberOfPages());
            // gg_TocList.Add(new ClsPDFToc() { NumItem = gg_tocNumItems, NumChapter = gg_tocNumChapter, NumSecction = gg_tocNumSecction, NumPage = gg_tocNumPage, TitleES = pTitleLeft, TitleXX = pTitleRight, Target = gg_tocTarget });

            // manager size variables for position things 
            float fSizeTopMargin = m_Document.GetTopMargin();
            float fSizeBottomMargin = m_Document.GetBottomMargin();
            float fSizeLeftMargin = m_Document.GetLeftMargin();
            float fSizeRightMargin = m_Document.GetRightMargin();
            float fSizeInsideWidth = pdfPageText.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPageText.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;

            //---------------------------------------------------------------------------
            // build Page LEFT images
            //--------------------------------------------------------------------------
            float fImgMaxWidth = fSizeInsideWidth;
            float fImgMaxHeight = (fSizeInsideHeight / 2) - 10;

            if (pImagePath_1 != null)
            {
                Image img1 = ClsPdfTools.ImageFitToBox(pImagePath_1, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
                img1.SetMarginTop(2);
                Paragraph pImg1 = new Paragraph();
                pImg1.SetMargin(0f);
                pImg1.Add(img1);
                m_Document.Add(pImg1);
            }
            if (pImagePath_2 != null)
            {
                Image img2 = ClsPdfTools.ImageFitToBox(pImagePath_2, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
                img2.SetMarginTop(15);
                Paragraph pImg2 = new Paragraph();
                pImg2.SetMargin(0f);
                pImg2.Add(img2);
                m_Document.Add(pImg2);
            }


            //m_Document.Add(pImg);
            //m_Document.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));

            //ClsPdfBookMarks.Add_L3_ChapterSection(ref m_PdfDoc, pTitleLeft, pTitleRight);
            //--------------------------------------------------------------------------
            // build page left with titles and text
            //--------------------------------------------------------------------------         
            PdfPage PdfPageImg = m_PdfDoc.AddNewPage();
            float[] fTableColumnsWidths = new float[] { fSizeInsideWidth / 2, fSizeInsideWidth / 2 };
            Table oTbText = new Table(fTableColumnsWidths);
            oTbText.SetWidth(fSizeInsideWidth);
            oTbText.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            // TITLES

            FNC_AddRow_Titles(ref oTbText, ref pTitleLeft, ref pTitleLeft, 2);


            // TWO common tow LANGUAGES
            if (pParagraphBoth != null) { Fnc_AddRow_CellCollSpan(ref oTbText, ref pBothTitle, ref pParagraphBoth); }
            // text diferent for two languages

            Fnc_AddRow_CellTwoColumns(ref oTbText, ref pParagraphLeft, ref pParagraphRight);

            m_Document.Add(oTbText);

            m_Document.Flush();


        }



        /// <summary>
        /// Add page blanck with note 
        /// This page intentionally left blank... 
        /// </summary>
        public void Fnc_Add_00_PageBlanck()
        {
            m_Document.Add(new AreaBreak());
            m_PdfDoc.AddNewPage();
            Paragraph paragraph = new Paragraph();
            paragraph.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
            paragraph.Add(ClsPdfStyle.BldTexDefaultMinBold("This page intentionally left blank. Take your notes here\nPágina intencionadamente en blanco. toma aqui tus anotaciones"));

            paragraph.Add(testudines.cls.pdf.ClsPdfTools.AddLinkInternal("Top", "AnchorTop"));

            m_Document.Add(paragraph);
            //g_Doc_Document.NewPage();
        }


        public void Fnc_Add_10_PageIndex_table(String pTableTitleES, String pTableTitleXX)
        {
            m_Document.Add(new AreaBreak());
            PdfPage pdfPage = m_PdfDoc.AddNewPage();

            //p.SetDestination("AnchorTop");

            Paragraph pTitle = new Paragraph();
            pTitle.SetDestination("AnchorIndex");
            pTitle.Add(ClsPdfStyle.BldTex01_TitleChapterB(pTableTitleES.ToUpper() + "  -  " + pTableTitleXX.ToUpper()).SetHorizontalAlignment(HorizontalAlignment.CENTER));
            pTitle.SetWidth(pdfPage.GetPageSize().GetWidth());
            m_Document.Add(pTitle);
            m_Document.Flush();
            Paragraph pLines = new Paragraph(); ;



            float[] widths = new float[] { 8f, 35f, 35f, 20f };
            Table oTable = new Table(widths);
            oTable.SetWidth(UnitValue.CreatePercentValue(100));
            Fnc_Add_10_PageIndex_AddRowHeader_(pTableTitleES, pTableTitleXX, ref oTable);

            string item = "";
            List<ClsPdfBookMarksToc> ItemsTocs = ClsPdfBookMarks.GetTocList();
            foreach (ClsPdfBookMarksToc toc in ItemsTocs)
            {
                item = "";
                if (toc.NumSecction != 0)
                {
                    item += toc.NumChapter.ToString() + "." + toc.NumSecction.ToString();
                }
                else
                {
                    item += toc.NumChapter.ToString();
                }

                Fnc_Add_10_PageIndex_AddRow_(item, toc.TitleES, toc.TitleXX, toc.NumPage.ToString(), toc.PdfActionGoto, ref oTable);

            }
            m_Document.Add(oTable);
        }



        private void Fnc_Add_10_PageIndex_AddRowHeader_(String pTableTitleES, String pTableTitleXX, ref Table pTable)
        {
            Paragraph pCol1 = new Paragraph("");
            Paragraph pCol2 = new Paragraph(ClsPdfStyle.BldTexDefaultBold(pTableTitleES));
            Paragraph pCol3 = new Paragraph(ClsPdfStyle.BldTexDefaultBold(pTableTitleXX));
            Paragraph pCol4 = new Paragraph("");
            Cell OCellCol1 = new Cell().Add(pCol1);
            Cell OCellCol2 = new Cell().Add(pCol2);
            Cell OCellCol3 = new Cell().Add(pCol3);
            Cell OCellCol4 = new Cell().Add(pCol4);
            OCellCol1.SetBackgroundColor(ClsPdfStyle.ColorGray);
            OCellCol2.SetBackgroundColor(ClsPdfStyle.ColorGray);
            OCellCol3.SetBackgroundColor(ClsPdfStyle.ColorGray);
            OCellCol4.SetBackgroundColor(ClsPdfStyle.ColorGray);
            pTable.AddCell(OCellCol1);
            pTable.AddCell(OCellCol2);
            pTable.AddCell(OCellCol3);
            pTable.AddCell(OCellCol4);
            m_TableRowSwitchColor = !m_TableRowSwitchColor;
        }

        private void Fnc_Add_10_PageIndex_AddRow_(String col1, String col2, String col3, String col4, PdfAction pdfAction, ref Table pTable)
        {


            int iPaddingTop = 2;
            int iPaddingBottom = 2;

            Paragraph pCol1 = new Paragraph(ClsPdfStyle.BldTexDefault(col1));
            Paragraph pCol2 = new Paragraph(ClsPdfStyle.BldTexDefault(col2));
            Paragraph pCol3 = new Paragraph(ClsPdfStyle.BldTexDefault(col3));
            Paragraph pCol4 = new Paragraph(ClsPdfStyle.BldTexDefault(col4).SetAction(pdfAction));


            Cell OCellCol1 = new Cell().Add(pCol1);
            Cell OCellCol2 = new Cell().Add(pCol2);
            Cell OCellCol3 = new Cell().Add(pCol3);
            Cell OCellCol4 = new Cell().Add(pCol4);
            if (m_TableRowSwitchColor)
            {
                OCellCol1.SetBackgroundColor(ClsPdfStyle.ColorGrayLight);
                OCellCol2.SetBackgroundColor(ClsPdfStyle.ColorGrayLight);
                OCellCol3.SetBackgroundColor(ClsPdfStyle.ColorGrayLight);
                OCellCol4.SetBackgroundColor(ClsPdfStyle.ColorGrayLight);
            }
            else
            {
                OCellCol1.SetBackgroundColor(ClsPdfStyle.ColorGray);
                OCellCol2.SetBackgroundColor(ClsPdfStyle.ColorGray);
                OCellCol3.SetBackgroundColor(ClsPdfStyle.ColorGray);
                OCellCol4.SetBackgroundColor(ClsPdfStyle.ColorGray);
            }
            m_TableRowSwitchColor = !m_TableRowSwitchColor;

            OCellCol1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            OCellCol1.SetPadding(0);
            OCellCol1.SetPaddingBottom(iPaddingTop);
            OCellCol1.SetPaddingTop(iPaddingBottom);

            OCellCol1.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            OCellCol1.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            OCellCol2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            OCellCol2.SetPadding(0);

            OCellCol2.SetPaddingBottom(iPaddingTop);
            OCellCol2.SetPaddingTop(iPaddingBottom);
            OCellCol2.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            OCellCol2.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            OCellCol3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            OCellCol3.SetPadding(0);
            OCellCol3.SetPaddingBottom(iPaddingTop);
            OCellCol3.SetPaddingTop(iPaddingBottom);
            OCellCol3.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            OCellCol3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            OCellCol4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            OCellCol4.SetPadding(0);
            OCellCol4.SetPaddingBottom(iPaddingTop);
            OCellCol4.SetPaddingTop(iPaddingBottom);
            OCellCol4.SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            OCellCol4.SetVerticalAlignment(VerticalAlignment.MIDDLE);



            pTable.AddCell(OCellCol1);
            pTable.AddCell(OCellCol2);
            pTable.AddCell(OCellCol3);
            pTable.AddCell(OCellCol4);
        }

        /// <summary>
        /// Close temporal document and try to copy to 
        /// target , may be excption if target document 
        /// is in use, cant access...
        /// </summary>
        /// <returns>true if all is ok else false
        /// if error the mesage are saved in ErrorMsg
        /// </returns>
        public bool Fnc_99_Add_End()
        {




            try
            {
                m_Document.Flush();
                m_PdfWriter.Flush();
                m_Document.Close();
                m_PdfDoc.Close();
                m_PdfWriter.Close();
                m_PdfWriter.Dispose();
                System.IO.File.Copy(m_FileNameTemp, m_FileNameTarget, true);
          


            }
            catch (Exception xcpt)
            {
                m_IsError = true;
                m_ErrorMsg += "\n" + xcpt.Message;
            }

            return m_IsError;
        }

        //*********************************************************************************************
        //*********************************************************************************************
        //*********************************************************************************************
        //*********************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oTable"></param>
        /// <param name="pTitleLeft"></param>
        /// <param name="pTitleRight"></param>
        /// <param name="pTtitleLevel">1=Chapter, 2=Secction, 3=Subsecction and others
        private void FNC_AddRow_Titles(ref Table oTable, ref String pTitleLeft, ref String pTitleRight, uint pTtitleLevel = 1)
        {
            Paragraph pCol_1 = new Paragraph();
            Paragraph pCol_2 = new Paragraph();
            pCol_1.SetPaddingRight(m_PaddingColums);
            pCol_2.SetPaddingLeft(m_PaddingColums);
            if (pTtitleLevel == 1) // chapter
            {
                pCol_1.Add(ClsPdfStyle.BldTex01_TitleChapterB(pTitleLeft));
                pCol_2.Add(ClsPdfStyle.BldTex01_TitleChapterB(pTitleRight));

            }
            else if (pTtitleLevel == 2) // secction
            {
                pCol_1.Add(ClsPdfStyle.BldTex02_TitleSecctionB(pTitleLeft));
                pCol_2.Add(ClsPdfStyle.BldTex02_TitleSecctionB(pTitleRight));

            }
            else
            {
                pCol_1.Add(ClsPdfStyle.BldTex03_TitleSecctionSubB(pTitleLeft));
                pCol_2.Add(ClsPdfStyle.BldTex03_TitleSecctionSubB(pTitleRight));

            }




            pCol_1.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            pCol_1.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            Cell cellCol_1 = new Cell().SetPaddingRight(10).SetMarginBottom(14);
            Cell cellCol_2 = new Cell().SetPaddingLeft(10).SetMarginBottom(14); ;
            cellCol_1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cellCol_2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cellCol_1.Add(pCol_1);
            cellCol_2.Add(pCol_2);
            oTable.AddCell(cellCol_1);
            oTable.AddCell(cellCol_2);


        }
        //*********************************************************************************************
        //*********************************************************************************************

        private void Fnc_AddRow_CellTwoColumns(ref Table oTable, ref Paragraph pParagraphLeft, ref Paragraph pParagraphRight)
        {
            pParagraphLeft.SetPaddingRight(m_PaddingColums);
            pParagraphRight.SetPaddingLeft(m_PaddingColums);

            //float fMarginTop =10;
            float fMarginBottom = 0;

            float fPaddingTop = 0;
            //float fPaddingBottom = 14;

            Cell cellLeft = new Cell().Add(pParagraphLeft);
            Cell cellRight = new Cell().Add(pParagraphRight);

            cellLeft.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            cellLeft.SetPaddingTop(fPaddingTop).SetMarginBottom(fMarginBottom);
            cellLeft.SetPadding(0);
            cellLeft.SetMargin(0);
            cellLeft.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cellRight.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            cellRight.SetPadding(0);
            cellRight.SetMargin(0);
            cellRight.SetPaddingLeft(fPaddingTop).SetMarginBottom(fMarginBottom);
            cellRight.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            oTable.AddCell(cellLeft);
            oTable.AddCell(cellRight);
        }
        //*********************************************************************************************
        private void Fnc_AddRow_CellTwoColumns(ref Table oTable, ref String pTextLeft, ref String pTextRight)
        {

            Paragraph pLeft = new Paragraph(ClsPdfStyle.BldTexDefault(pTextLeft));
            Paragraph pRight = new Paragraph(ClsPdfStyle.BldTexDefault(pTextRight));

            pLeft.SetPaddingRight(m_PaddingColums);
            pRight.SetPaddingLeft(m_PaddingColums);

            float fMarginTop = 10;
            float fMarginBottom = 0;

            float fPaddingTop = 0;
            float fPaddingBottom = 14;

            Cell cellLeft = new Cell().Add(pLeft);
            Cell cellRight = new Cell().Add(pRight);

            cellLeft.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            cellLeft.SetPadding(0);
            cellLeft.SetMargin(0);
            cellLeft.SetPaddingTop(fPaddingTop).SetMarginBottom(fMarginBottom);
            cellLeft.SetBorder(iText.Layout.Borders.Border.NO_BORDER);



            cellRight.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            cellRight.SetPadding(0);
            cellRight.SetMargin(0);
            cellRight.SetPaddingTop(fPaddingTop).SetMarginBottom(fMarginBottom);
            cellRight.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            oTable.AddCell(cellLeft);
            oTable.AddCell(cellRight);
        }
        //*********************************************************************************************
        private void Fnc_AddRow_CellCollSpan(ref Table oTable, ref String pTitle, ref Paragraph pParagraph, TextAlignment alignment = TextAlignment.LEFT, int colspan = 2)
        {
            float fMarginTop = 10;
            float fMarginBottom = 0;

            float fPaddingTop = 0;
            float fPaddingBottom = 14;
            if (pTitle != "")
            {
                Paragraph pTitle2 = new Paragraph();
                pTitle2.Add(ClsPdfStyle.BldTexDefaultBold(pTitle));
                Cell cellRow1 = new Cell(1, colspan).Add(pTitle2);
                cellRow1.SetTextAlignment(alignment);
                cellRow1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                cellRow1.SetPadding(0);
                cellRow1.SetMargin(0);
                cellRow1.SetPaddingTop(fPaddingTop).SetMarginBottom(fMarginBottom);
                oTable.AddCell(cellRow1.SetBorder(iText.Layout.Borders.Border.NO_BORDER));
            }


            Cell CellRow2 = new Cell(1, colspan).Add(pParagraph);
            CellRow2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            CellRow2.SetPadding(0);
            CellRow2.SetMargin(0);
            CellRow2.SetPaddingTop(fPaddingTop).SetMarginBottom(fMarginBottom);
            oTable.AddCell(CellRow2);

        }
        /// <summary>
        /// Reset before errror flags saved in the variables
        /// m_IsError and m_ErrorMsg
        /// </summary>

        /*
                private void Fnc_AddLink_URL(ref Paragraph p, string pLinkText, String pLinkURL)
                {

                    Link link = new Link(pLinkText, PdfAction.CreateURI(pLinkURL));
                    link.SetFontColor(ClsPdfStyle.ColorLinks);
                    link.SetBorder(iText.Layout.Borders.SolidBorder.NO_BORDER);
                    //link.GetLinkAnnotation().SetBorder(new PdfAnnotationBorder(0, 0, 0)).SetColor (ClsPdfStyle.ColorLinks);
                    // p.Add(link).SetFontColor(ClsPdfStyle.ColorLinks).SetFontSize(ClsPdfStyle.FontSizeMin);
                    p.Add(link);

                }
                */
        private String m_CiteClearText = "";
        public String GetCiteClearText()
        {
            return m_CiteClearText;
        }

        public float GetLayout_free_Y()
        {
            iText.Layout.Layout.LayoutArea currentArea = m_Document.GetRenderer().GetCurrentArea();
            Rectangle rectangle = currentArea.GetBBox();
            float y = rectangle.GetHeight();
            return y;
        }


        // TODO PROBLEMA SUPERPONE IMAGENES 
        public void fnc_Add_Image_svg(String pImageSvgFullPath)
        {
            String sFileSvg = "";
            using (StreamReader sr = File.OpenText(pImageSvgFullPath))
            {
                String s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    sFileSvg = sFileSvg + s;

                }
            }
            iText.Svg.Converter.SvgConverter.DrawOnPage(sFileSvg, m_PdfDoc.GetLastPage().SetMediaBox(new Rectangle(300f, 200f)));

        }
        public String Fnc_Add_Cite(ref Document pDocument)
        {
            String m_CiteClearText = "";
            Paragraph p = new Paragraph();
            p.SetFontSize(ClsPdfStyle.FontSizeMin);
            p.SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT);
            p.SetPadding(0);


            m_CiteClearText += m_DocCiteAuthor + " " + "(" + m_DocCiteYear + "). " + m_DocCiteTitle_Full + ",  " + m_DocCiteTitle_Subtitle;
            p.Add(m_DocCiteAuthor + " " + "(" + m_DocCiteYear + "). " + m_DocCiteTitle_Full + ",  " + m_DocCiteTitle_Subtitle + ". ");

            if (m_DocCiteAuthors != "")
            {
                m_CiteClearText += ", " + m_DocCiteAuthors;
                p.Add(", " + m_DocCiteAuthors);
            }

            m_DocCiteAuthors += ".";
            p.Add(".");



            if (m_DocCiteTitle_Full != "")
            {
                m_CiteClearText += " " + m_DocCiteTitle_Full;
                p.Add(" " + m_DocCiteTitle_Full);
            }

            if (m_DocCiteTitle_Subtitle != "")
            {
                m_CiteClearText += ", " + m_DocCiteTitle_Subtitle;
                p.Add(" " + m_DocCiteTitle_Subtitle);
            }

            if (m_DocCiteVersion != "")
            {
                m_CiteClearText += " Version. " + m_DocCiteVersion;
                p.Add(" Version. " + m_DocCiteVersion);
            }
            //.............................

            if (m_DocCiteInText != "")
            {
                m_CiteClearText += " In " + m_DocCiteInText;

                p.Add(testudines.cls.pdf.ClsPdfTools.AddLinkUri(m_DocCiteInText, m_DocCiteInURL));
                //Fnc_AddLink_URL(ref p, " " + m_DocCiteInText + ".", m_DocCiteInURL);

            }

            if (m_DocCiteDowloadFromText != "")

            {
                m_CiteClearText += ", Downloaded from " + m_DocCiteDowloadFromText;
                p.Add("Download from ");
                //Fnc_AddLink_URL(ref p, m_DocCiteDowloadFromText + ".", m_DocCiteDowloadFromURL);
                p.Add(testudines.cls.pdf.ClsPdfTools.AddLinkUri(m_DocCiteDowloadFromText, m_DocCiteDowloadFromURL));
            }
            //.............................
            if (m_DocCiteDateCreation != "")
            {
                m_CiteClearText += ", Date " + m_DocCiteDateCreation;
                p.Add(", Date " + m_DocCiteDateCreation);
            }
            m_DocCiteAuthors += ".";
            //.............................
            if (m_DocCiteTranslators != "")
            {
                m_CiteClearText += ". Translators " + m_DocCiteTranslators;
                p.Add(". Translators " + m_DocCiteTranslators);
            }
            m_DocCiteAuthors += ".";

            // Fnc_AddLink_URL(ref p, " Build with ITEXT 7" + ".", "https://itextpdf.com");
            p.Add(testudines.cls.pdf.ClsPdfTools.AddLinkUri(" Build with ITEXT 7", "https://itextpdf.com"));
            pDocument.Add(p);

            return m_CiteClearText;
        }
        public void fnc_Add_image_bottom(ref Paragraph pParagraph, String pImageFullPath)
        {
            float yHeightFree = GetLayout_free_Y() - 15;
            Fnc_Add_image_free(ref pParagraph, pImageFullPath, yHeightFree);
        }
        public void Fnc_Add_image_free(ref Paragraph pParagraph, String PImageFullPath, float pMaxHeigth = 0f)
        {
            PdfPage pdfPage = m_PdfDoc.GetLastPage();
            float fSizeInsideWidth = pdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
            float fSizeInsideHeight = pdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;

            float fImgMaxWidth = fSizeInsideWidth;
            float fImgMaxHeight = 0;
            if (pMaxHeigth == 0)
            {
                fImgMaxHeight = (fSizeInsideHeight / 2) - 30;
            }
            else
            {
                fImgMaxHeight = pMaxHeigth;
            }
            Image img = ClsPdfTools.ImageFitToBox(PImageFullPath, fImgMaxWidth, fImgMaxHeight, ref m_PathNoImage);
                        img.SetMarginTop(2);
            pParagraph.Add(img);
            m_Document.Add(pParagraph);
        }
       

}
    }

