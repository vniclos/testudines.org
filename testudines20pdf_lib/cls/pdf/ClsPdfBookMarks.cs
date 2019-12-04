/*
 Managemente of Bookmark and keep data for do
 TOC More easy .
 Create formated Index page, calling before close document.
 page at end of document, with titles, links, actions .....
 */
// for add anchor to paragraf 
//   p.SetDestination("AnchorTop");
//https://itextpdf.com/en/resources/books/best-itext-7-questions-stackoverflow/how-create-hierarchical-bookmarks

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Geom;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;
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
    class ClsPdfBookMarks
    {
        private static PdfOutline m_PdfOutline_L0_Root;
        private static PdfOutline m_PdfOutline_L1_Cover;
        private static PdfOutline m_PdfOutline_L2_Chapter;
        private static PdfOutline m_PfOutline_L3_Chapter_Secction;
        private static PdfOutline m_PfOutline_L4_Biblio;
        private static PdfOutline m_PfOutline_L9_Index;
        private static UInt16 m_Count_Items = 0;
        private static UInt16 m_Count_Chapter=0;
        private static UInt16 m_Count_Section=0;

        protected static List<ClsPdfBookMarksToc> m_TocList = new List<ClsPdfBookMarksToc>();
        public static List<ClsPdfBookMarksToc> GetTocList() { return m_TocList; }
        /// <summary>
        /// Mananger of bookmark and build index pages
        /// </summary>
        /// <param name="pPdfDoc"></param>
        /// <param name="pTitleEN"></param>
        public static void Add_L0_Root(ref PdfDocument pPdfDoc, String pTitleES, String pTitleXX)
        {
            m_TocList.Clear();
            m_Count_Items = 0;
            m_Count_Chapter = 0;
            m_Count_Section = 0;
            UInt32 iPageNum = Convert.ToUInt16(pPdfDoc.GetPageNumber(pPdfDoc.GetLastPage()));
            String title =  pTitleES + " " + pTitleXX;
            m_PdfOutline_L0_Root = pPdfDoc.GetOutlines(false);
            //m_PdfOutline_L0_Root = pPdfDoc.GetOutlines(title);
            m_PdfOutline_L0_Root.AddOutline(title );
            PdfAction pdfActionGoto = PdfAction.CreateGoTo(PdfExplicitDestination.CreateFitH(pPdfDoc.GetLastPage(), pPdfDoc.GetLastPage().GetPageSize().GetTop()));
            m_PdfOutline_L0_Root.AddAction(PdfAction.CreateGoTo( PdfExplicitDestination.CreateFitH(pPdfDoc.GetLastPage(), pPdfDoc.GetLastPage().GetPageSize().GetTop())));
            m_TocList.Add(new ClsPdfBookMarksToc() { NumItem = m_Count_Items, NumChapter = m_Count_Chapter, NumSecction = 0, NumPage = iPageNum, TitleES = pTitleES, TitleXX = pTitleXX, PdfActionGoto = pdfActionGoto });
        }

        public static void Add_L1_Cover(ref PdfDocument pPdfDoc, String pTitleES, String pTitleXX)
        {
            m_TocList.Clear();
            m_Count_Items++;
            m_Count_Chapter = 0;
            m_Count_Section = 0;
            UInt32 iPageNum = Convert.ToUInt16(pPdfDoc.GetPageNumber(pPdfDoc.GetLastPage()));
            String title = pTitleES + " " + pTitleXX;
            m_PdfOutline_L2_Chapter = m_PdfOutline_L0_Root.AddOutline(title);
            PdfAction pdfActionGoto = PdfAction.CreateGoTo(PdfExplicitDestination.CreateFitH(pPdfDoc.GetLastPage(), pPdfDoc.GetLastPage().GetPageSize().GetTop()));
            m_PdfOutline_L2_Chapter.AddAction(pdfActionGoto);
            m_TocList.Add(new ClsPdfBookMarksToc() { NumItem = m_Count_Items, NumChapter = m_Count_Chapter, NumSecction = 0, NumPage = iPageNum, TitleES = pTitleES, TitleXX = pTitleXX, PdfActionGoto = pdfActionGoto });

        }

        // 
        /// <summary>
        /// call for add Captitule to bookmark and keep data for index 
        /// Remember add root node before add chapters
        /// </summary>
        /// <param name="pPdfDoc"></param>
        /// <param name="pTitleES">Title in Spanish</param>
        /// <param name="pTitleXX">Title in other language</param>
        public static void Add_L2_Chapter(ref PdfDocument pPdfDoc, String pTitleES, String pTitleXX)
        {
            m_Count_Items++;
            m_Count_Chapter++;
            m_Count_Section = 0;
            UInt32 iPageNum = Convert.ToUInt16(pPdfDoc.GetPageNumber(pPdfDoc.GetLastPage()));
            String title = m_Count_Chapter.ToString() + " " + pTitleES + " " + pTitleXX;
            m_PdfOutline_L2_Chapter = m_PdfOutline_L0_Root.AddOutline(title);
            PdfAction pdfActionGoto = PdfAction.CreateGoTo(PdfExplicitDestination.CreateFitH(pPdfDoc.GetLastPage(), pPdfDoc.GetLastPage().GetPageSize().GetTop()));
            m_PdfOutline_L2_Chapter.AddAction(pdfActionGoto);
            m_TocList.Add(new ClsPdfBookMarksToc() { NumItem = m_Count_Items, NumChapter = m_Count_Chapter, NumSecction = 0, NumPage = iPageNum, TitleES = pTitleES, TitleXX = pTitleXX, PdfActionGoto = pdfActionGoto });

        }
        
        /// <summary>
        /// Call for add section to bookmark and keep data for index 
        /// Remmeber add one chapter before add sections
        /// </summary>
        /// <param name="pPdfDoc"></param>
        /// <param name="pTitleES">Title in Spanish</param>
        /// <param name="pTitleXX">Title  in other language</param>
        public static void Add_L3_ChapterSection(ref PdfDocument pPdfDoc,String pTitleES, String pTitleXX)
        {

            m_Count_Items++;
            m_Count_Section ++;
            UInt32 iPageNum = Convert.ToUInt16(pPdfDoc.GetPageNumber(pPdfDoc.GetLastPage()));
            String title = m_Count_Chapter.ToString() + " " + pTitleES + " " + pTitleXX;
            m_PfOutline_L3_Chapter_Secction = m_PdfOutline_L2_Chapter.AddOutline(title);
            PdfAction pdfActionGoto = PdfAction.CreateGoTo(PdfExplicitDestination.CreateFitH(pPdfDoc.GetLastPage(), pPdfDoc.GetLastPage().GetPageSize().GetTop()));
            m_PfOutline_L3_Chapter_Secction.AddAction(pdfActionGoto);
            m_TocList.Add(new ClsPdfBookMarksToc() { NumItem = m_Count_Items, NumChapter = m_Count_Chapter, NumSecction = m_Count_Section, NumPage = iPageNum, TitleES = pTitleES, TitleXX = pTitleXX, PdfActionGoto = pdfActionGoto });
        }
       
  

    }
}
