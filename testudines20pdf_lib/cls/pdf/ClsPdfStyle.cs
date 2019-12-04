//https://itextpdf.com/en/resources/books/itext-7-building-blocks/chapter-4-adding-abstractelement-objects-part-1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iText.IO.Font;
using iText.Kernel.Geom;

using iText.Kernel.Events;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;
// Chunks, Phrases. Paragraphs
namespace testudines.cls.pdf
{
    public class ClsPdfStyle
    {
        static float m_FontSizeBigBig = 16f;


        public static float FontSizeBigBig { get { return m_FontSizeBigBig; } }

        static float m_FontSizeBig = 14f;
        public static float FontSizeBig { get { return m_FontSizeBig; } }

        static float m_FontSizeNormal = 11f;
        public static float FontSizeNormal { get { return m_FontSizeNormal; } }

        static float m_FontSizeMin = 8f;
        public static float FontSizeMin { get { return m_FontSizeMin; } }

        private static iText.Kernel.Colors.Color m_ColorLinks = new iText.Kernel.Colors.DeviceRgb(6, 69, 173);

        private static iText.Kernel.Colors.Color m_ColorGreen = new iText.Kernel.Colors.DeviceRgb(0, 65, 36);
        private static iText.Kernel.Colors.Color m_ColorGrayLight = new iText.Kernel.Colors.DeviceRgb(250, 250, 250);
        private static iText.Kernel.Colors.Color m_ColorGray = new iText.Kernel.Colors.DeviceRgb(240, 240, 240);
        private static iText.Kernel.Colors.Color m_ColorGrayDark = new iText.Kernel.Colors.DeviceRgb(128, 128, 128);
        private static iText.Kernel.Colors.Color m_ColorGrayDark2 = new iText.Kernel.Colors.DeviceRgb(64, 64, 64);
        public static iText.Kernel.Colors.Color ColorLinks { get { return m_ColorLinks; } }
        public static iText.Kernel.Colors.Color ColorGreen { get { return m_ColorGreen; } }
        public static iText.Kernel.Colors.Color ColorGrayLight { get { return m_ColorGrayLight; } }
        public static iText.Kernel.Colors.Color ColorGray { get { return m_ColorGray; } }
        public static iText.Kernel.Colors.Color ColorGrayDark { get { return m_ColorGrayDark; } }
        public static iText.Kernel.Colors.Color ColorGrayDark2 { get { return m_ColorGrayDark2; } }
        //https://fontawesome.com/icons?d=gallery
        // georgia 
        //PdfFont f = PdfFontFactory.createFont(FONT, PdfEncodings.IDENTITY_H);
        //Paragraph p = new Paragraph("H\u2082SO\u2074").setFont(f).setFontSize(10);


        private static FontProgram fontPrgGeorgia = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\georgia.ttf"); // georgia normal
        private static FontProgram fontPrgGeorgiaB = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\georgiab.ttf"); //georgia bold
        private static FontProgram fontPrgGeorgiaI = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\georgiai.ttf"); // georgia italic
        private static FontProgram fontPrgGeorgiaBI = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\georgiaz.ttf"); // georbia bold italic
        private static FontProgram fontPrgAwesomeUnicode = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\Font Awesome 5 Free-Solid-900.otf");




        public static PdfFont fontPdfGeorgia ;
        public static PdfFont fontPdfGeorgiaB ;
        public static PdfFont fontPdfGeorgiaI ;
        public static PdfFont fontPdfGeorgiaBI;
        public static PdfFont fontPdf_Helv ;
        public static PdfFont fontPdf_HelvB;
        public static PdfFont fontAwesomeUnicode;
        //Font Awesome 5 Free-Regular-400.otf
        //private static FontProgram fontPrgAwesomeUnicode = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\Font Awesome 5 Brands-Regular-400.otf"); // exadecimal
        //private static FontProgram fontPrgAwesomeUnicode = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\Font Awesome 5 Brands-Regular-400.otf");   // exadecimal






        public static void Beguin()
        {
            fontPdfGeorgia = PdfFontFactory.CreateFont(fontPrgGeorgia, PdfEncodings.WINANSI, true);
            fontPdfGeorgiaB = PdfFontFactory.CreateFont(fontPrgGeorgiaB, PdfEncodings.WINANSI, true);
            fontPdfGeorgiaI = PdfFontFactory.CreateFont(fontPrgGeorgiaI, PdfEncodings.WINANSI, true);
            fontPdfGeorgiaBI = PdfFontFactory.CreateFont(fontPrgGeorgiaBI, PdfEncodings.WINANSI, true);
            fontPdf_Helv = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA, PdfEncodings.WINANSI, true);
            fontPdf_HelvB = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD, PdfEncodings.WINANSI, true);
            fontAwesomeUnicode = PdfFontFactory.CreateFont(fontPrgAwesomeUnicode, PdfEncodings.IDENTITY_H, true);
            //Font Awesome 5 Free-Regular-400.otf
            //private static FontProgram fontPrgAwesomeUnicode = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\Font Awesome 5 Brands-Regular-400.otf"); // exadecimal
            //private static FontProgram fontPrgAwesomeUnicode = FontProgramFactory.CreateFont("C:\\Windows\\Fonts\\Font Awesome 5 Brands-Regular-400.otf");   // exadecimal
        }


        public static Text BldTex00_TitleBigBigBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeBigBig);
            t.SetFontColor(ColorGreen);
            return t;


        }

        public static Text BldTex00_TitleBigBigB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeBigBig);
            t.SetFontColor(ColorGreen);
            return t;


        }


        public static Text BldTex01_TitleChapterBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeBig);
            t.SetFontColor(ColorGreen);
            return t;


        }

        public static Text BldTex01_TitleChapterB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeBig);
            t.SetFontColor(ColorGreen);
            return t;


        }






        public static Text BldTex02_TitleSecctionBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeNormal);
            return t;


        }

        public static Text BldTex02_TitleSecctionB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeNormal);
            t.SetFontColor(ColorGreen);
            return t;


        }

        public static Text BldTex03_TitleSecctionSubBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaI);
            t.SetFontSize(m_FontSizeNormal);
            t.SetFontColor(ColorGreen);
            return t;


        }

        public static Text BldTex03_TitleSecctionSubB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgia);
            t.SetFontSize(m_FontSizeNormal);
            t.SetFontColor(ColorGreen);
            return t;


        }

        //-----------------------------------------------------------------
        public static Text BldTextTwoNormal(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgia);
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTextTwoNormalB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTextTwoNormalI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaI);
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTextTwoNormalBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        //-----------------------------------------------------------
        public static Text BldTextTwoMin(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgia);
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTextTwoMinB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTextTwoMinI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaI);
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTextTwoMinBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeMin);
            return t;
        }

        //-----------------------------------------------------------
        public static Text BldTextTwoBig(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgia);
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        public static Text BldTextTwoBigB(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaB);
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        public static Text BldTextTwoBigI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaI);
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        public static Text BldTextTwoBigBI(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdfGeorgiaBI);
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        //-----------------------------------------------------------
        //-----------------------------------------------------------
        public static Text BldTexDefault(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_Helv);
            t.SetFontSize(m_FontSizeNormal);
            return t;


        }
        public static Text BldTexDefaultMin(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTexDefaultBig(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_Helv);
            t.SetFontSize(m_FontSizeBig);
            return t;
        }

        public static Text BldTexDefaultBold(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetBold();
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTexDefaultMinBold(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetBold();
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTexDefaultBigBold(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetBold();
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        public static Text BldTexDefaultItalic(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_Helv);
            t.SetItalic();
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTexDefaultMinItalic(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_Helv);
            t.SetItalic();
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldTexDefaultBigItalic(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_Helv);
            t.SetItalic();
            t.SetFontSize(m_FontSizeBig);
            return t;
        }
        //-----------------
        public static Text BldTexDefaultItalicBold(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetItalic();
            //t.SetBold();
            t.SetFontSize(m_FontSizeNormal);
            return t;
        }
        public static Text BldTexDefaultMinItalicBold(String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetItalic();
            //t.SetBold();
            t.SetFontSize(m_FontSizeMin);
            return t;
        }
        public static Text BldDefaultBigItalicBold(ref String pText)
        {
            if (pText == null) { pText = ""; }
            Text t = new Text(pText);
            t.SetFont(fontPdf_HelvB);
            t.SetItalic();
            t.SetBold();
            t.SetFontSize(m_FontSizeBig);
            return t;
        }



    }
}