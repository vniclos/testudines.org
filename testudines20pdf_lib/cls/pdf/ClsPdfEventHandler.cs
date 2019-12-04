//https://dotnetcoretutorials.com/2019/07/02/creating-a-pdf-in-net-core/
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
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;

using iText.IO.Image;
using testudines;
//using System.Drawing;
using System.Resources;
using System.Resources;
using System.Reflection;

internal class ClsPdfEventHandler : IEventHandler
{





    private Document m_Document;
    private PdfDocument m_pdfDoc;
    private PdfPage m_PdfPage;

    private float m_SizeInsideWidth = 0;
    private float m_SizeInsideHeight = 0;

    private float m_SizeTopMargin = 0;
    private float m_SizeBottomMargin = 0;
    private float m_SizeLeftMargin = 0;
    private float m_SizeRightMargin = 0;

    private float m_SizeHeaderHeight = 30;
    private float m_SizeFooterHeight = 30;



    private bool m_HeaderVisible = true;
    private bool m_FooterVisible = true;
    public bool FooterVisible { set { m_FooterVisible = value; } }

    
           
    public bool HeaderVisible { set { m_HeaderVisible = value; } }

    private  String m_HeaderLeft = "";
   public String HeaderLeft { set { m_HeaderLeft = value; } }  

    private  String m_HeaderCenter = "";
    public String HeaderCenter { set { m_HeaderCenter = value; } }

    private  String m_HeaderURL = "";
    public String HeaderURL { set { m_HeaderURL = value; } }

    private  String m_HeaderRight = "";
    public String HeaderRight { set { m_HeaderRight = value; } }



 
    


    public ClsPdfEventHandler(Document pDocument)
    {
        m_Document       = pDocument;
      

    }





    //@Override


    //----------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------------
    public virtual void OnChapter(PdfWriter writer,
                      Document document,
                      float paragraphPosition,
                      Paragraph title)
    { }
    public virtual void HandleEvent(Event @event)
    {
        PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;



        m_pdfDoc = docEvent.GetDocument();
        m_PdfPage = docEvent.GetPage();
        m_SizeTopMargin = m_Document.GetTopMargin();
        m_SizeBottomMargin = m_Document.GetBottomMargin();
        m_SizeLeftMargin = m_Document.GetLeftMargin();
        m_SizeRightMargin = m_Document.GetRightMargin();
        m_SizeInsideWidth = m_PdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin(); ;
        m_SizeInsideHeight = m_PdfPage.GetPageSize().GetHeight() - m_Document.GetTopMargin() - m_Document.GetBottomMargin(); ;
       
        m_pdfDoc = docEvent.GetDocument(); ;
        m_PdfPage = docEvent.GetPage();


        iText.Kernel.Pdf.Canvas.PdfCanvas pdfCanvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(m_PdfPage.NewContentStreamBefore(), m_PdfPage.GetResources(), m_pdfDoc);
        FncAddHeader(ref pdfCanvas);
        Int32 pageNum = docEvent.GetDocument().GetPageNumber(m_PdfPage);
        FncAddFooter(ref pdfCanvas, pageNum);
        // footer

    }
    private void FncAddHeader(ref iText.Kernel.Pdf.Canvas.PdfCanvas pdfCanvas)

    {

       // if (!m_HeaderVisible) { return; }
        //https://stackoverflow.com/questions/38834055/itext-error-when-adding-link-onto-canvas

        float tX = m_pdfDoc.GetDefaultPageSize().GetX() + m_Document.GetLeftMargin();
        float tY = m_pdfDoc.GetDefaultPageSize().GetTop() - m_Document.GetTopMargin() + 1;
        float tW = m_PdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin();
        float ty2 = tY;
        float w2 = 20f;
        float h2 = m_SizeHeaderHeight;
        float fLeft = 0;
        float fBottom = 0;
        float fWidth = 0;




        ty2 = tY + 15;
        
        //..................................................................
        Text tLeft = testudines.cls.pdf.ClsPdfTools.AddLinkInternal("Top", "AnchorTop").SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).SetFontSize(testudines.cls.pdf.ClsPdfStyle.FontSizeMin); 
        Paragraph pLeft = new Paragraph(tLeft);
        float tx2 = m_Document.GetLeftMargin();
        pLeft.SetFixedPosition(tx2, ty2, 20).SetPadding(0);
        m_Document.Add(pLeft);

      
        //...................................................................................................................

        Text tRight = testudines.cls.pdf.ClsPdfTools.AddLinkInternal("Index", "AnchorIndex").SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT).SetFontSize(testudines.cls.pdf.ClsPdfStyle.FontSizeMin);
        Paragraph pRight = new Paragraph(tRight);
        w2 = 20;
         tx2 = m_Document.GetLeftMargin();
        tx2 = m_PdfPage.GetPageSize().GetWidth() - w2 - m_Document.GetRightMargin(); ;
        pRight.SetFixedPosition(tx2, ty2, w2).SetPadding(0);
        m_Document.Add(pRight);

        //................................................................
        Text tCenter = testudines.cls.pdf.ClsPdfStyle.BldTextTwoNormalBI(m_HeaderCenter).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER).SetFontColor(testudines.cls.pdf.ClsPdfStyle.ColorGrayDark2);
        //Text tCenter = new Text(m_HeaderCenter).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER).SetFontSize(testudines.cls.pdf.ClsPdfStyle.FontSizeMin);
        Paragraph pCenter = new Paragraph(tCenter);
        w2 = 400f;
        //tx2 = m_PdfPage.GetPageSize().GetWidth() / 2 - 200;
        tx2 = (m_PdfPage.GetPageSize().GetWidth()-w2) / 2 ;
        ty2 = tY;
        
         h2 = m_SizeHeaderHeight;
         fLeft = 0;
         fBottom = 0;
         fWidth = 0;
        Rectangle rCenter = new Rectangle(tx2, ty2, w2, h2);
        Canvas CCenter = new Canvas(pdfCanvas, m_pdfDoc, rCenter);
        CCenter.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        CCenter.SetFixedPosition(fLeft, fBottom, fWidth);
        CCenter.Add(pCenter);

        //Image img= System.Drawing.Imaging.BitmapData( testudines.pdf.Resource1.logo);
        //System.Drawing.Bitmap bmp =testudines.pdf.Resource1.logo ;
        
      

        //Image bmImage = new Image(testudines.pdf.Resource1.logo);

    }

    /*  
    private void FncAddHeader_old(ref iText.Kernel.Pdf.Canvas.PdfCanvas pdfCanvas)
    {
        Text tPLeft = new Text("left").SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);


        float[] widths = new float[] { 10, (m_SizeInsideWidth -20), 10 };
        Table tHeader = new Table(widths);
        tHeader.SetWidth(m_SizeInsideWidth);
        tHeader.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

        Paragraph pCell_Left = new Paragraph(testudines.cls.pdf.ClsPdfTools.AddLink("Top", "AnchorTop")).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT); ;

        Cell cCell_Left = new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER);
        Rectangle rect = new Rectangle(5, 5);
        iText.Kernel.Pdf.Annot.PdfLinkAnnotation annotation = new iText.Kernel.Pdf.Annot.PdfLinkAnnotation(rect);

        //annotation.SetAction(action);
        cCell_Left.Add(pCell_Left);
        cCell_Left.SetAction( PdfAction.CreateURI("AnchorTop"));
       tHeader.AddCell(cCell_Left);




        Text tCenter = new Text(m_HeaderCenter).SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
        Paragraph pCell_Center = new Paragraph(tCenter);
        pCell_Center.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        Cell OCellCol2 = new Cell();
        //OCellCol2.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
        OCellCol2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
        OCellCol2.Add(pCell_Center);
        tHeader.AddCell(OCellCol2);


        Paragraph pCell_Right = new Paragraph(testudines.cls.pdf.ClsPdfTools.AddLink("Index", "http://testudines.org/")).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT); ;
        Cell cCell_Right = new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER).Add(pCell_Right); ;
        tHeader.AddCell(cCell_Right);



        //Fnc_Table_Add_Row3(tPLeft, tCenter, tRight, ref tablaEncabezado);
        float tX = m_pdfDoc.GetDefaultPageSize().GetX() + m_Document.GetLeftMargin();
        float tY = m_pdfDoc.GetDefaultPageSize().GetTop() - m_Document.GetTopMargin() + 1;
        float tW = m_PdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin();

        Rectangle recHeader = new Rectangle(tX, tY, tW, m_SizeHeaderHeight);
        float pLeft = 0;
        float pBottom = 0;
        float pWidth = 0;
        Canvas canvasHeader = new Canvas(pdfCanvas, m_pdfDoc, recHeader);


        canvasHeader.SetFixedPosition(pLeft, pBottom, pWidth);
        canvasHeader.Add(tHeader);

    }

    */
    private void FncAddFooter(ref iText.Kernel.Pdf.Canvas.PdfCanvas pdfCanvas, Int32 pageNum)
    {
        //Int32 PageNumShow = pageNum - 1;
        Int32 PageNumShow = pageNum ;
        // if (!m_FooterVisible) { return; }
        float[] anchos = { 1F };
        Table tablaPie = new Table(anchos);
        tablaPie.SetWidth(m_SizeInsideWidth);
        tablaPie.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

        Paragraph pCol1 = new Paragraph("- " + PageNumShow + " -");
        pCol1.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
        Cell OCellCol1 = new Cell();
        //OCellCol1.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.Center);
        OCellCol1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
        OCellCol1.Add(pCol1);
        tablaPie.AddCell(OCellCol1);

        tablaPie.AddCell("Pagina " + pageNum);
      
        float xPie = m_pdfDoc.GetDefaultPageSize().GetX() + m_Document.GetLeftMargin();
        float yPie = m_pdfDoc.GetDefaultPageSize().GetBottom();
        float anchoPie = m_PdfPage.GetPageSize().GetWidth() - m_Document.GetLeftMargin() - m_Document.GetRightMargin();
        Rectangle rectanguloPie = new Rectangle(xPie, yPie, anchoPie, m_SizeFooterHeight);
        Canvas canvasPie = new Canvas(pdfCanvas, m_pdfDoc, rectanguloPie);
        canvasPie.Add(tablaPie);

    }
}
