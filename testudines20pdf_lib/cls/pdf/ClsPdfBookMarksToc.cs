/*
 this clas is for to do Page Index capitule, section and anchor
 by creating in new page event
 protected List<ClsPDFToc> gg_TOC = new List<ClsPDFToc>();
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf.Action;
namespace testudines.cls.pdf
{
    public class ClsPdfBookMarksToc
    {
        public UInt32 NumItem { get; set; }
        public UInt32 NumChapter { get; set; }
        public UInt32 NumSecction { get; set; } // 0= is chapter
        public UInt32 NumPage { get; set; }
        public string TitleES { get; set; }
        public string TitleXX { get; set; } // other languaje
        public PdfAction PdfActionGoto { get; set; }
    }
}
