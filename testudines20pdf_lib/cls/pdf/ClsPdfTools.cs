using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using iText.IO.Font;

using iText.Kernel.Geom;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Colors;
using iText.Layout;
using iText.Layout.Element;
using iText.Svg;
using iText.IO.Image;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;
using System.Text.RegularExpressions;

namespace testudines.cls.pdf
{
    public class ClsPdfTools
    {
        public ClsPdfTools() { }
        ~ClsPdfTools() { }
        //https://fontawesome.com/cheatsheet

        ////Text tUnicode = new Text("\xf14d").SetFont(ClsPdfStyle.fontAwesomeUnicode);
        public static Text AddTeextIconLink2 { get { return new Text("\xf0c1").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTeextIconLink { get { return new Text("\xf14d").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconBug { get { return new Text("\xf188").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconAnexed { get { return new Text("\xf0c6").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconGoUp { get { return new Text("\xf35b").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconGoDown { get { return new Text("\xf358").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconGoLeft { get { return new Text("\xf359").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextIconGoRight { get { return new Text("\xf35a").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        public static Text AddTextPencil { get { return new Text("\xf303").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pText">if arrow then show litle arrow</param>
        /// <param name="pTarget"></param>
        /// <returns></returns>
        static public Link AddLinkUri(String pText, String pTarget)
        {
            //"http:// www.tutorialspoint.com/"

            Rectangle rect = new Rectangle(5, 5);


            iText.Kernel.Pdf.Annot.PdfLinkAnnotation annotation = new iText.Kernel.Pdf.Annot.PdfLinkAnnotation(rect);
            PdfAction action = PdfAction.CreateURI(pTarget);
            annotation.SetAction(action);

            bool bAwesomeUnicode = false;
            if (pText == "arrow") { pText = "\xf14d"; bAwesomeUnicode = true; }// arrow
            Link link = new Link(pText, annotation);
            if (bAwesomeUnicode)
            {
                //     public static Text BldLink { get { return new Text("\xf14d").SetFont(ClsPdfStyle.fontAwesomeUnicode); } }
                link.SetFont(ClsPdfStyle.fontAwesomeUnicode).SetFontSize(7).SetFontColor(ClsPdfStyle.ColorLinks).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
               
            }
            else
            {
                link.SetFont(ClsPdfStyle.fontPdf_Helv).SetFontSize(7).SetFontColor(ClsPdfStyle.ColorLinks).SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            }
            
            link.GetLinkAnnotation().SetBorder(new PdfAnnotationBorder(0, 0, 0));
            
            //link.SetUnderline();
            return link;
        }

        static public Link AddLinkInternal(String pText, String pTarget)
        {
            //"http:// www.tutorialspoint.com/"
            Rectangle rect = new Rectangle(5, 5);


            iText.Kernel.Pdf.Annot.PdfLinkAnnotation annotation = new iText.Kernel.Pdf.Annot.PdfLinkAnnotation(rect);
            PdfAction action = PdfAction.CreateGoTo(pTarget);
            annotation.SetAction(action);
            Link link = new Link(pText, annotation);
            link.SetFont(ClsPdfStyle.fontPdf_Helv).SetFontSize(7).SetFontColor(ClsPdfStyle.ColorLinks);
            link.GetLinkAnnotation().SetBorder(new PdfAnnotationBorder(0, 0, 0));
            link.SetUnderline();
            return link;
        }
        static public PdfPage AddPage(ref PdfDocument m_PdfDoc)
        {
            // m_Document.Flush();

            PdfPage pdfPage = m_PdfDoc.AddNewPage();

            return pdfPage;
            //m_Document.Add(new reaBreak());
        }
        static public void fncGetImgMed(ref String pImagePath)
        {
            try
            {
                pImagePath = pImagePath.Replace("_minx.jpg", "_med.jpg");
                pImagePath = pImagePath.Replace("_min.jpg", "_med.jpg");
            }
            catch { }

        }
        static public Image ImageFitToBox(String pImageFullPath, float pBoxMaxWidth, float pBoxMaxHeight, ref String pPathNoImage, bool bForceImageMed = true)
        {
            if (bForceImageMed)
            {
                fncGetImgMed(ref pImageFullPath);
                fncGetImgMed(ref pPathNoImage);


            }

            if (!System.IO.File.Exists(pImageFullPath) ) { pImageFullPath = pPathNoImage; }
            ImageData imgData = ImageDataFactory.Create(pImageFullPath);
            Image image = new Image(imgData);
            float factor = 1;
            float factorWidth = pBoxMaxWidth / image.GetImageWidth();
            float factorHeight = pBoxMaxHeight / image.GetImageHeight();
            if (factorWidth >= factorHeight) { factor = factorHeight; } else { factor = factorWidth; }
            image.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            image.Scale(factor, factor);
            float iMarginLeft = (pBoxMaxWidth - image.GetImageWidth() * factor) / 2;
            image.SetMarginLeft(iMarginLeft);
            return image;

        }


        public static String GetFileNameTempUnique(String pDirTemp, String pFileNamePdfShort)
        {
         
            String fileNameFullPath = "";
            pFileNamePdfShort = pFileNamePdfShort.Replace(".pdf", "");
            bool b = true;
            while (b)
            {
                fileNameFullPath = Guid.NewGuid().ToString();
                fileNameFullPath = pFileNamePdfShort + fileNameFullPath.Substring(1, 8) + ".pdf";
                fileNameFullPath = PathCombine(pDirTemp, fileNameFullPath);
                if (System.IO.File.Exists(fileNameFullPath) ){ b = true; } else { b = false; }
            }
            return fileNameFullPath;

        }

        /// <summary>
        ///  Build full file path, combine directory and filename short with 
        ///  some prevention of errors like // or not end in .pdf
        /// </summary>
        /// <param name="pDir"> Directory</param>
        /// <param name="pFilenameShort">File name short</param>
        /// <returns>Full file path</returns>
        static public String PathCombine(String pDir, String pFilenameShort)
        {
            String fullPath = pDir.Trim().Replace("\\", "/"); // normalization
            if (!fullPath.EndsWith("/")) { fullPath += "/"; }
            //  if (!pFilenameShort.ToLower().EndsWith(".pdf")) { pFilenameShort += ".pdf"; }
            fullPath += pFilenameShort;
            return fullPath;
        }
        static public String HtmToText(string htmlString)
        {


            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "\n", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }




    }
}
