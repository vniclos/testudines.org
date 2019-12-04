using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Windows;

using System.Collections ;
using System.Collections.ObjectModel;
using System.Windows.Media;





namespace testudines.cls
{
    public class ClsClimateDraw
    {
         
        private SolidBrush miBlushLightGray = new SolidBrush(System.Drawing.ColorTranslator.FromHtml("#EFEFEF"));

        private double[] m_dHourMonthMin = new double[13];
        private double[] m_dHourMonthMax = new double[13];
        private bool m_ErrorB = false;
        private string m_ErrorString = "";
        private string m_PathTarget = "";
        private string m_PathTemp = "";
        private string m_PathFileFullPath_target = "";
        private string m_PathFileFullPath_temp = "";
        private string m_ShortFileName = "";

        //private string m_PathFullTemp = "";
        //private string m_szTitle = "";
        private int m_ipLatMax = 0;
        //private int m_ipLatMin = 0;
        private int m_iZoneYear = 0;

        private int m_MinX = 350; // formato 4/3
        private int m_MinY = 210; // formato 4/3
        private int m_MinYpie = 40;
        //private int m_MedX = 600; // formato 4/3
        //private int m_MedY = 450;
        private System.Drawing.Color m_BackColor = System.Drawing.Color.LightGray;
        private System.Drawing.Color m_BackColorBlue = System.Drawing.Color.LightSteelBlue;
public ClsClimateDraw()
        {


        }
        //


private string  FncDoubleTime24ToHHMM(double dHour)
        {
            string sH = dHour.ToString().Replace (".",",");
            string[] aH = sH.Split(',');
           string  szhh = aH[0];
           string mtemp = "";
           if (aH.Length == 2)
           {
                mtemp = aH[1].Substring(0, 4);
           }
           else { mtemp = "0"; }
            Int32 mm = Convert.ToInt32(mtemp);
            mm = mm * 6 / 10;
            string szmm = mm.ToString();
            if (szmm.Length > 2) szmm = szmm.Substring(0, 2);
            if (szmm.Length == 1) szmm = "0" + szmm;
            if (szhh.Length > 2) szhh = szhh.Substring(0, 2);
            if (szhh.Length == 1) szhh = "0" + szhh;

            string szhhmm = szhh + ":" + szmm;
            return szhhmm;
        }

public string FncBldImgSunHours(int pWidth, int pHeight,  string pFileTargetFullPath, Int32 pLatMax, Int32 pLatMin, Int32 pYear, string pTitSpecie, string pTitAuthor)
        {
            // calculo de la matriz de las horas de sol de dia 15 de cada mes
            double[] dLatMax = new double[13];
            double[] dLatMin = new double[13];
            cls.ClsSunHourCalc oCalc = new ClsSunHourCalc();
            double dSunHoursMax = -999d;
            double dSunHoursMin = +999d;
            for (int n = 1; n < 13; n++)
            {
                dLatMax[n] = oCalc.FncCalAnoMes15(pLatMax, pYear, n);
                dLatMin[n] = oCalc.FncCalAnoMes15(pLatMin, pYear, n);
                if (dLatMax[n] > dSunHoursMax) dSunHoursMax = dLatMax[n];
                if (dLatMin[n] < dSunHoursMin) dSunHoursMin = dLatMin[n];

            }

            string szHHMMMax =FncDoubleTime24ToHHMM(dSunHoursMax);
            string szHHMMMin = FncDoubleTime24ToHHMM(dSunHoursMin);
            string szHHMMDif = FncDoubleTime24ToHHMM(dSunHoursMax-dSunHoursMin);
        

            //---------------------------------------------------
            // dibujo
            if (pWidth == 0) pWidth = 600;
            if (pHeight == 0) pWidth = 300;
            // creamos un dibujo en un fichero temporal
            // evitamos colisiones
            // Si todo hay ido bien sustituimos el szFileTargetFullPath por el temporal
            // borramos el temporal.
            string szFileTemp = "";

            szFileTemp = Path.GetTempPath() + Path.GetRandomFileName() + ".jpg"; ;
            
            Bitmap oBmpImage = new Bitmap(pWidth, pHeight);
            SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
            SolidBrush miBlueBrush = new SolidBrush(System.Drawing.Color.Blue);
            SolidBrush miBlushWhite = new SolidBrush(System.Drawing.Color.White);
            System.Drawing.Pen miPenGreyDot = new System.Drawing.Pen(System.Drawing.Color.DarkGray, 2f);
            miPenGreyDot.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            System.Drawing.Pen miPenGrey = new System.Drawing.Pen(System.Drawing.Color.DarkGray, 2f);
            System.Drawing.Pen miPenRed = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
            System.Drawing.Pen miPenBlack2 = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
            System.Drawing.Pen miPenBlue3 = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
            System.Drawing.Pen miPenRed3 = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
            System.Drawing.FontFamily fontCourier = new System.Drawing.FontFamily("Courier New");
            System.Drawing.FontFamily fontGeorgia = new System.Drawing.FontFamily("Georgia");

            System.Drawing.FontFamily fontVerdana = new System.Drawing.FontFamily("Verdana");
            Font oFont09R = new Font(fontCourier, 9, System.Drawing.FontStyle.Bold);
            Font oFont06R = new Font(fontVerdana, 7, System.Drawing.FontStyle.Regular);
            Font oFont10N = new Font(fontVerdana, 7, System.Drawing.FontStyle.Bold);
            Font oFontTitleItalic = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Italic);
            Font oFontTitleNormal = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Regular);
    
           // SolidBrush miBlushLightGray = new SolidBrush(System.Drawing.Color.LightGray);
            
            //1- crear rectangulo del fondo de la imagen
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            oG.PixelOffsetMode = PixelOffsetMode.HighQuality; 
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);
            oG.FillRectangle(miBlushLightGray, new Rectangle(0, 0, pWidth, pHeight));
            oG.Flush();
            int yHitMarkWidth = 10;
            int yMargintop = 20;
            int yMarginbotton = 40;
            int xMarginLeft = 40;
            int xMarginRight= 40;
            int xDrawWidth = pWidth - xMarginLeft - xMarginRight;
            int yDrawHeight =  pHeight - yMargintop - yMarginbotton;
            int xDrawWithMonth = xDrawWidth / 12;
            int xIni =0;
            int xFin = 0;
            int yIni = 0;
            int yFin = 0;

         
            // 7a.- regilla de 12 meses
            int iDrawWidt = pWidth - xMarginLeft - xMarginRight;
            for (int n = 1; n < 13; n++)
            {
                xIni = xMarginLeft + n * xDrawWithMonth;
                xFin = xIni;
                yIni = yMargintop;
                yFin = pHeight - yMarginbotton + yHitMarkWidth;
                if (n<12)  oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
                oG.Flush();
                oG.DrawString(n.ToString(), oFont10N, System.Drawing.Brushes.Black, xIni - xDrawWithMonth/2-10, yFin-8);
            }
            // 7b regilla de las horas
            
           // int iDrawHeight = pHeight  - yMarginbotton  - yMargintop  ;
            int iSlotHour = yDrawHeight / 24;
            xIni = xMarginLeft - yHitMarkWidth;
            xFin = xMarginLeft + xDrawWidth + yHitMarkWidth;
            int yBase = pHeight - yMarginbotton + yHitMarkWidth;
            int Ihoras = 24;
            bool bShow = true;
            for (int n = 0; n < 25; n++)
            {
                yIni = yMargintop + iSlotHour * n;
                yFin = yIni;
                if (n < 24) oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
                oG.Flush();
                if (bShow) oG.DrawString((Ihoras - n).ToString(), oFont06R, System.Drawing.Brushes.Black, xIni-20 , yFin - 8);
                bShow = !bShow;
            }



            // 2.- Eje de coordenadas y derecha
             xIni = pWidth - xMarginRight;
             xFin = xIni;
             yIni = yMargintop;
             yFin = pHeight - yMarginbotton + yHitMarkWidth;
            oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
            oG.Flush();
            // 3.- Eje de coordenadas y izquierda
            xIni = xMarginLeft;
            xFin = xMarginLeft;
            yIni = yMargintop;
            yFin = pHeight - yMarginbotton + yHitMarkWidth;
            oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
            oG.Flush();
            // 4.- Eje de coordenadas x abajo
            xIni = xMarginLeft - yHitMarkWidth;
            xFin = xMarginLeft + xDrawWidth + yHitMarkWidth;

            yIni = pHeight - yMarginbotton;
            yFin = yIni;
            oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
            oG.Flush();
      

            // 8 Dibujar linea de horas de sol en latitud maxima.
            PointF[] oPointsMax= new PointF[12];
            PointF[] oPointsMin = new PointF[12];  
            int fyMax=0;
            int fyMin = 0;
            int fx=0;
            float factorY = yDrawHeight / 24;
            int iDesplacamiento = xDrawWithMonth / 2;
            for (int n = 0; n < 12; n++)
            {
                fyMax = Convert.ToInt32(dLatMax[n + 1] * factorY) + yMargintop; // Convert.ToInt32(pdLatMax[n]); 
                fyMin = Convert.ToInt32(dLatMin[n + 1] * factorY) + yMargintop; // Convert.ToInt32(pdLatMax[n]); 
                fx = xMarginLeft + (n * xDrawWithMonth) + iDesplacamiento;
                oPointsMax[n] = new Point(fx, fyMax+1);
                oPointsMin[n] = new Point(fx, fyMin-1);
                
                
            }


            // 5a .- Titulos----------------------------------------------

            StringFormat drawFormat2 = new StringFormat();
            drawFormat2.Alignment = StringAlignment.Far;
            RectangleF drawRectLeft = new RectangleF(0, 0, pWidth / 2, 25);
            oG.DrawString(pTitSpecie, oFontTitleItalic, miBlackBrush, drawRectLeft, drawFormat2);
            oG.Flush();
            RectangleF drawRectRight = new RectangleF(pWidth / 2, 0, pWidth, 25);
            drawFormat2.Alignment = StringAlignment.Near;
            oG.DrawString(pTitAuthor, oFontTitleNormal, miBlackBrush, drawRectRight, drawFormat2);

            // 5b .- Titulos de ejes  verticales
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
            System.Drawing.StringFormat drawFormatVertical = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
            oG.DrawString("Horas de sol - Sun Hours", drawFont, miBlackBrush, pWidth - 30, 55, drawFormatVertical);

            // 5c dibujar titulos del pie
            System.Drawing.Font drawFontPie = new System.Drawing.Font("Arial", 8);
            Int32 iTitBoty = yDrawHeight + yMargintop + yHitMarkWidth + 10;
            Int32 iTitBotx = xMarginLeft;
            oG.DrawString("Lat. " + pLatMax.ToString() + "º", drawFontPie, miBlackBrush, iTitBotx, iTitBoty);
            oG.DrawLine(miPenBlue3, iTitBotx + 50, iTitBoty + 8, iTitBotx + 70, iTitBoty + 8);
            oG.DrawString("Lat. " + pLatMin.ToString() + "º", drawFontPie, miBlackBrush, iTitBotx + 80, iTitBoty);
            oG.DrawLine(miPenRed3, iTitBotx + 135, iTitBoty + 8, iTitBotx + 155, iTitBoty + 8);



            //- 6.- Poner Mosca
            Bitmap bmp = Properties.Resources.mosca24;

            //Bitmap bmp = (Bitmap)Bitmap.FromFile("d:/mosca24.jpg");

            oG.DrawImage(bmp, (pWidth - bmp.Width - 4), 4);


            string szLimits = "(HH:MM) Max=" + szHHMMMax + "  Min=" + szHHMMMin + "  Dif=" + szHHMMDif ;
            RectangleF drawRectRight2 = new RectangleF(pWidth - 400 - 20, pHeight - 20, 400, 28);
            drawFormat2.Alignment = StringAlignment.Far;
            oG.DrawString(szLimits, drawFontPie, miBlackBrush, drawRectRight2, drawFormat2);

    
            oG.DrawLines(miPenRed3, oPointsMin);
            oG.Flush();
            oG.DrawLines(miPenBlue3, oPointsMax);
            oG.Flush();

       
            
            

            //====================================
            // guardar
             

           // oBmpImage.Save(szFileTemp,System.Drawing.Imaging.ImageFormat.Jpeg)  ;
            oBmpImage.Save(szFileTemp, System.Drawing.Imaging.ImageFormat.Jpeg);
            if (System.IO.File.Exists(pFileTargetFullPath))
            {
                System.IO.File.Delete(pFileTargetFullPath);
            }
            System.IO.File.Copy(szFileTemp, pFileTargetFullPath);
            System.IO.File.Delete(szFileTemp);
   
            oBmpImage.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();




            return szFileTemp;
        }

public string FncBldImgTemp(int pWidth, int pHeight, string pFileTargetFullPath, string pTitSpecie, string pTitAuthor, string szTitLocation, bool bDrawMin, bool bDrawMed, bool bDrawMax, ref Int32[] pATemMin, ref Int32[] pATemMed, ref  Int32[] pATemMax)
{
    //// calculo de la matriz de las horas de sol de dia 15 de cada mes
    //double[] dLatMax = new double[13];
    //double[] dLatMin = new double[13];
    //cls.ClsSunHourCalc oCalc = new ClsSunHourCalc();
   
    //---------------------------------------------------
    // dibujo
    if (pWidth == 0) pWidth = 600;
    if (pHeight == 0) pWidth = 300;
    // creamos un dibujo en un fichero temporal
    // evitamos colisiones
    // Si todo hay ido bien sustituimos el szFileTargetFullPath por el temporal
    // borramos el temporal.
    string szFileTemp = "";

    szFileTemp = Path.GetTempPath() + Path.GetRandomFileName() + ".jpg"; ;
      


    Bitmap oBmpImage = new Bitmap(pWidth, pHeight);
    SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
    SolidBrush miBlueBrush = new SolidBrush(System.Drawing.Color.Blue);
    SolidBrush miBlushWhite = new SolidBrush(System.Drawing.Color.White);
    System.Drawing.ColorTranslator.FromHtml("#FFFFFF");


    System.Drawing.Pen miPenGreyDot = new System.Drawing.Pen(System.Drawing.Color.LightSlateGray, 1f);
    miPenGreyDot.DashStyle =  System.Drawing.Drawing2D.DashStyle.Dash;
    System.Drawing.Pen miPenGrey = new System.Drawing.Pen(System.Drawing.Color.DarkGray, 2f);
    System.Drawing.Pen miPenRed = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
    System.Drawing.Pen miPenBlack2 = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
    System.Drawing.Pen miPenBlue3 = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
    System.Drawing.Pen miPenTemMed = new System.Drawing.Pen(System.Drawing.Color.Green, 4);
    System.Drawing.Pen miPenTemMax = new System.Drawing.Pen(System.Drawing.Color.Red, 4);
    System.Drawing.Pen miPenTemMin = new System.Drawing.Pen(System.Drawing.Color.Blue , 4);
    System.Drawing.FontFamily fontCourier = new System.Drawing.FontFamily("Courier New");
    System.Drawing.FontFamily fontGeorgia = new System.Drawing.FontFamily("Georgia");


    System.Drawing.FontFamily fontVerdana = new System.Drawing.FontFamily("Verdana");
    Font oFont09R = new Font(fontCourier, 9, System.Drawing.FontStyle.Bold);
    Font oFont06R = new Font(fontVerdana, 7, System.Drawing.FontStyle.Regular );
    Font oFont08B =new Font(fontVerdana, 8, System.Drawing.FontStyle.Bold);
    Font oFont10N = new Font(fontVerdana, 7, System.Drawing.FontStyle.Bold);
    Font oFontTitleItalic = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Italic);
    Font oFontTitleNormal = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Regular);
    //1- crear rectangulo del fondo de la imagen
    Graphics oG = Graphics.FromImage(oBmpImage);
    oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    oG.PixelOffsetMode = PixelOffsetMode.HighQuality; 
    System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);
    oG.FillRectangle(miBlushLightGray, new Rectangle(0, 0, pWidth, pHeight));
    oG.Flush();
    int yHitMarkWidth = 5;
    int yMargintop = 22;
    int yMarginbotton = 40;
    int xMarginLeft = 30;
    int xMarginRight = 40;
    int xDrawWidth = pWidth - xMarginLeft - xMarginRight;
    int yDrawHeight = pHeight - yMargintop - yMarginbotton;
    int xDrawWithMonth = xDrawWidth / 12;
    int xIni = 0;
    int xFin = 0;
    int yIni = 0;
    int yFin = 0;

    // 5a .- Titulos----------------------------------------------

    StringFormat drawFormat2 = new StringFormat();
    drawFormat2.Alignment = StringAlignment.Far;
    RectangleF drawRectLeft = new RectangleF(0, 0, pWidth / 2, 28);
    oG.DrawString(pTitSpecie, oFontTitleItalic, miBlackBrush, drawRectLeft, drawFormat2);
    oG.Flush();
    RectangleF drawRectRight = new RectangleF(pWidth / 2, 0, pWidth, 28);
    drawFormat2.Alignment = StringAlignment.Near;
    oG.DrawString(pTitAuthor, oFontTitleNormal, miBlackBrush, drawRectRight, drawFormat2);

    // 5b .- Titulos de ejes  verticales
    //System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 10);
    //System.Drawing.StringFormat drawFormatVertical = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
    //oG.DrawString("Temp ºC", drawFont, miBlackBrush, pWidth - 30, 55, drawFormatVertical);

    // 5b .- Titulos de ejes  verticales


    oG.DrawString("ºC", oFont08B, miBlackBrush, 2, 1);
    oG.DrawString("ºF", oFont08B, miBlackBrush, pWidth - 23, 1);

    // 5c dibujar titulos del pie

    System.Drawing.Font drawFontPie = new System.Drawing.Font("Arial", 8);
    Int32 iTitBoty = yDrawHeight + yMargintop + yHitMarkWidth + 10;
    Int32 iTitBotx = xMarginLeft;
    if (bDrawMin)
    {
        oG.DrawLine(miPenTemMax, iTitBotx, iTitBoty + 8, iTitBotx + 20, iTitBoty + 8);
        oG.DrawString("Max", drawFontPie, miBlackBrush, iTitBotx + 20, iTitBoty);
    }
    if (bDrawMed)
    {
        oG.DrawString("Med", drawFontPie, miBlackBrush, iTitBotx + 82, iTitBoty);
        oG.DrawLine(miPenTemMed, iTitBotx + 60, iTitBoty + 8, iTitBotx + 80, iTitBoty + 8);
    }
    if (bDrawMin)
    {
        oG.DrawString("Min", drawFontPie, miBlackBrush, iTitBotx + 140, iTitBoty);
        oG.DrawLine(miPenTemMin, iTitBotx + 120, iTitBoty + 8, iTitBotx + 140, iTitBoty + 8);
    }
    
    //oG.DrawLine(miPenTemMin, iTitBotx + 120, iTitBoty + 8, iTitBotx + 135, iTitBoty + 8);
    //oG.DrawString("Min", drawFontPie, miBlackBrush, iTitBotx, iTitBoty);
    
    RectangleF drawRectRight2 = new RectangleF(iTitBotx + 160, iTitBoty, 380, 25);
    drawFormat2.Alignment = StringAlignment.Far;
    oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, drawRectRight2, drawFormat2);


    //oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, iTitBotx+150, iTitBoty);
    

    //- 6.- Poner Mosca
   // Bitmap bmp = (Bitmap)Bitmap.FromFile("d:/mosca24.jpg");
    Bitmap bmp = Properties.Resources.mosca24;
    //oG.DrawImage(bmp (pWidth - bmp.Width - 4), 4);
    oG.DrawImage(bmp,3,pHeight - bmp.Height-8 );

    // 7a.- regilla de 12 meses
    int iDrawWidt = pWidth - xMarginLeft - xMarginRight;
    for (int n = 1; n < 13; n++)
    {
        xIni = xMarginLeft + n * xDrawWithMonth;
        xFin = xIni;
        yIni = yMargintop;
        yFin = pHeight - yMarginbotton + yHitMarkWidth;
        if (n < 12) oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
        oG.Flush();
        oG.DrawString(n.ToString(), oFont10N, System.Drawing.Brushes.Black, xIni - xDrawWithMonth / 2 - 10, yFin - 3);
    }
    //----------------------------------
    // 7b regilla de la temperatura 
    // margen temperatura -20 a 60 =80; 
    //F=(C x 9/5) + 32 
    //dTempF=C x 9/5) + 32 
    //----------------------------------
    float dTempF = 0f;
    double ydDrawHeight = yDrawHeight;
    double slotGrad = ydDrawHeight / 70;
    xIni = xMarginLeft - yHitMarkWidth;
    xFin = xMarginLeft + xDrawWidth + yHitMarkWidth;
    int yBase = pHeight - yMarginbotton + yHitMarkWidth;
    int yIniInter = 0;
    int yFinInter = 0;
    Int32 iCelsius=0;
    string szF = "";

    for (int n = 0; n < 8; n++)
    {
        iCelsius = 50 - n * 10;
        dTempF = (iCelsius * 9 / 5) + 32;

        yIni = Convert.ToInt32(slotGrad * 10 * n) + yMargintop;
        yFin = yIni;
        
        // linea intermedia
        yIniInter = yIni +Convert.ToInt32( slotGrad * 15);
        yFinInter = yIni;
        miPenGrey.Width = 1;
        if (iCelsius != 0)
        {
            oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
        }
        else
        {
            oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
        
        }
       
        if (n<6)  oG.DrawLine(miPenGreyDot, xIni, yIniInter, xFin, yIniInter);
        if (n == 0)
        {
            yIniInter = yIni + Convert.ToInt32(slotGrad * 5);
            yFinInter = yIni;
            oG.DrawLine(miPenGreyDot, xIni, yIniInter, xFin, yIniInter);
        }

        oG.Flush();
        
        oG.DrawString(iCelsius.ToString(), oFont06R, System.Drawing.Brushes.Black, xIni - 20, yFin - 8);
       
       // szF = string.Format("{0:0.00}", dTempF);
        szF = string.Format("{0:0}", dTempF);
        oG.DrawString(szF, oFont06R, System.Drawing.Brushes.Black, xDrawWidth+xMarginLeft+10 , yFin - 8);
    }
    //...........................................
    // grafica de temperaturas
    // pATemMin, pATemMed, pATemMax 
    //...........................................
    
    int fx = 0;
    int iDesplacamientoX = xDrawWithMonth / 2;
    PointF[] oPointsMax = new PointF[12];
    PointF[] oPointsMed = new PointF[12];
    PointF[] oPointsMin = new PointF[12];
    int fyMax = 0;
    int fyMin = 0;
    int fyMed = 0;
    int factorInvert = yDrawHeight + yMargintop   ;
    Int32 iTemp = 0;
    double EvitarFalsosRedoneos=0d;
    double dyMarginTop = yMargintop;
 
    for (int n=0 ;n<12;n++)
    {
        fx = xMarginLeft + (n * xDrawWithMonth) + iDesplacamientoX;
         iTemp = pATemMax[n];
         EvitarFalsosRedoneos = pATemMax[n + 1];
         EvitarFalsosRedoneos = factorInvert - ((EvitarFalsosRedoneos+20) * slotGrad ); // Convert.ToInt32(pdLatMax[n]); 

         fyMax =Convert.ToInt32 ( System.Math.Round(EvitarFalsosRedoneos, 0)); 
        EvitarFalsosRedoneos = pATemMed[n + 1];
        fyMed = factorInvert - Convert.ToInt32((EvitarFalsosRedoneos+20) * slotGrad) ; // Convert.ToInt32(pdLatMax[n]); 

        EvitarFalsosRedoneos = pATemMin[n + 1];
        fyMin = factorInvert - Convert.ToInt32((EvitarFalsosRedoneos+20) * slotGrad ); // Convert.ToInt32(pdLatMax[n]); 
       
        
        oPointsMax[n] = new Point(fx, fyMax );
        oPointsMed[n] = new Point(fx, fyMed );
        oPointsMin[n] = new Point(fx, fyMin );


    }
    if (bDrawMin)
    {
        oG.DrawLines (miPenTemMin, oPointsMin);
        oG.Flush();
    }
    if (bDrawMed)
    {
        oG.DrawCurve(miPenTemMed, oPointsMed, 0.2f);
        oG.Flush();
    }
    if (bDrawMax)
    {
        oG.DrawCurve(miPenTemMax, oPointsMax, 0.2f);
        oG.Flush();
    }

    //...........................................
    // 2.- Eje de coordenadas y derecha
    //...........................................
    xIni = pWidth - xMarginRight;
    xFin = xIni;
    yIni = yMargintop;
    yFin = pHeight - yMarginbotton + yHitMarkWidth;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();
    //...........................................
    // 3.- Eje de coordenadas y izquierda
    //...........................................
    xIni = xMarginLeft;
    xFin = xMarginLeft;
    yIni = yMargintop;
    yFin = pHeight - yMarginbotton + yHitMarkWidth;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();
    //...........................................
    // 4.- Eje de coordenadas x abajo
    //...........................................
    xIni = xMarginLeft - yHitMarkWidth;
    xFin = xMarginLeft + xDrawWidth + yHitMarkWidth;

    yIni = pHeight - yMarginbotton;
    yFin = yIni;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();
    //...........................................
    // guardar
    //...........................................
   // oBmpImage.Save(szFileTemp,System.Drawing.Imaging.ImageFormat.Jpeg);
    oBmpImage.Save(szFileTemp);
    if (System.IO.File.Exists(pFileTargetFullPath))
    {
        System.IO.File.Delete(pFileTargetFullPath);
    }
    System.IO.File.Copy(szFileTemp, pFileTargetFullPath);
    System.IO.File.Delete(szFileTemp);
    oBmpImage.Dispose();
    miBlueBrush.Dispose();
    miBlackBrush.Dispose();
    myPen.Dispose();
    oG.Dispose();
    return pFileTargetFullPath;
}
private void FncBldImgNoImage(string pFileTargetFullPath, string pTitSpecie, string pTitAuthor,ref Bitmap oBmpImage )
{
    SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
    System.Drawing.FontFamily fontGeorgia = new System.Drawing.FontFamily("Georgia");
    Font oFontTitleNormal = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Regular);
    Font oFontTitleItalic = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Italic);
    Graphics oG = Graphics.FromImage(oBmpImage);

    StringFormat drawFormat2 = new StringFormat();
    drawFormat2.Alignment = StringAlignment.Far;
    RectangleF drawRectLeft = new RectangleF(0, 0, 300, 25);
    oG.DrawString(pTitSpecie, oFontTitleItalic, miBlackBrush, drawRectLeft, drawFormat2);
    oG.Flush();
    RectangleF drawRectRight = new RectangleF(300, 0, 300, 25);
    drawFormat2.Alignment = StringAlignment.Near;
    oG.DrawString(pTitAuthor, oFontTitleNormal, miBlackBrush, drawRectRight, drawFormat2);
    oBmpImage.Save(pFileTargetFullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
    
}

public void   FncBldImgBiomeNoImage(string pFileTargetFullPath, string pTitSpecie, string pTitAuthor)
{
    Bitmap oBmpImage = Properties.Resources.noimage_WheatherBiome;
    FncBldImgNoImage(pFileTargetFullPath, pTitSpecie, pTitAuthor, ref  oBmpImage);

}

public void   FncBldImgSunNoImage(string pFileTargetFullPath, string pTitSpecie, string pTitAuthor)
{
       Bitmap oBmpImage = Properties.Resources.noimage_WheatherSun;
       FncBldImgNoImage(pFileTargetFullPath, pTitSpecie, pTitAuthor, ref  oBmpImage);

}
public void   FncBldImgTmpNoImage(string pFileTargetFullPath, string pTitSpecie, string pTitAuthor)
{
    Bitmap oBmpImage = Properties.Resources.noimage_WheatherTmp;
    FncBldImgNoImage(pFileTargetFullPath, pTitSpecie, pTitAuthor, ref  oBmpImage);
}
public void   FncBldImgRainNoImage(string pFileTargetFullPath, string pTitSpecie, string pTitAuthor)
{
    Bitmap oBmpImage = Properties.Resources.noimage_WheatherRain;
    FncBldImgNoImage(pFileTargetFullPath, pTitSpecie, pTitAuthor, ref  oBmpImage);
}
public string FncBldImgRain(int pWidth, int pHeight, string pFileTargetFullPath, string pTitSpecie, string pTitAuthor, string szTitLocation, bool pbDrawMlMonth, bool pbDrawRainDaysMonth, ref Int32[] pARainMlMonth, ref Int32[] pARainDayMonth)
{
    // calculo de la matriz de las horas de sol de dia 15 de cada mes
    double[] dLatMax = new double[13];
    double[] dLatMin = new double[13];
  //  cls.ClsSunHourCalc oCalc = new ClsSunHourCalc();
    //double dSunHoursMax = -999d;
    //double dSunHoursMin = +999d;
    //for (int n = 1; n < 13; n++)
    //{
    //    dLatMax[n] = oCalc.FncCalAnoMes15(pLatMax, pYear, n);
    //    dLatMin[n] = oCalc.FncCalAnoMes15(pLatMin, pYear, n);
    //    if (dLatMax[n] > dSunHoursMax) dSunHoursMax = dLatMax[n];
    //    if (dLatMin[n] < dSunHoursMin) dSunHoursMin = dLatMin[n];

    //}

    //string szHHMMMax = FncDoubleTime24ToHHMM(dSunHoursMax);
    //string szHHMMMin = FncDoubleTime24ToHHMM(dSunHoursMin);

    //---------------------------------------------------
    // dibujo
    if (pWidth == 0) pWidth = 600;
    if (pHeight == 0) pWidth = 300;
    // creamos un dibujo en un fichero temporal
    // evitamos colisiones
    // Si todo hay ido bien sustituimos el szFileTargetFullPath por el temporal
    // borramos el temporal.
    string szFileTemp = "";

    szFileTemp = Path.GetTempPath() + Path.GetRandomFileName() + ".jpg"; ;

    Bitmap oBmpImage = new Bitmap(pWidth, pHeight);
    SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
    SolidBrush miBlueBrush = new SolidBrush(System.Drawing.Color.Blue);
    SolidBrush miBlushWhite = new SolidBrush(System.Drawing.Color.White);
    System.Drawing.ColorTranslator.FromHtml("#FFFFFF");


    System.Drawing.Pen miPenGreyDot = new System.Drawing.Pen(System.Drawing.Color.LightSlateGray, 1f);
    miPenGreyDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
    System.Drawing.Pen miPenGrey = new System.Drawing.Pen(System.Drawing.Color.DarkGray, 2f);
    System.Drawing.Pen miPenRed = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
    System.Drawing.Pen miPenBlack2 = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
    System.Drawing.Pen miPenBlue3 = new System.Drawing.Pen(System.Drawing.Color.Blue, 3);
    System.Drawing.Pen miPenRainDay = new System.Drawing.Pen(System.Drawing.Color.Navy , 3);
    System.Drawing.Pen miPenRainMl = new System.Drawing.Pen(System.Drawing.Color.Red, 3);
    System.Drawing.Pen miPenRanDayH = new System.Drawing.Pen(System.Drawing.Color.Navy  , 2);
    miPenRanDayH.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;  
    System.Drawing.FontFamily fontCourier = new System.Drawing.FontFamily("Courier New");
    System.Drawing.FontFamily fontGeorgia = new System.Drawing.FontFamily("Georgia");

    System.Drawing.FontFamily fontVerdana = new System.Drawing.FontFamily("Verdana");
    Font oFont09R = new Font(fontCourier, 9, System.Drawing.FontStyle.Regular);
    Font oFont09B = new Font(fontCourier, 9, System.Drawing.FontStyle.Bold);
    Font oFont06R = new Font(fontVerdana, 7, System.Drawing.FontStyle.Regular);
    Font oFont08B = new Font(fontVerdana, 8, System.Drawing.FontStyle.Bold);
    Font oFont10N = new Font(fontVerdana, 9, System.Drawing.FontStyle.Bold);
    Font oFontTitleItalic = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Italic);
    Font oFontTitleNormal = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Regular);
    //1- crear rectangulo del fondo de la imagen
    Graphics oG = Graphics.FromImage(oBmpImage);
    oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    oG.PixelOffsetMode = PixelOffsetMode.HighQuality; 
    System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);
    oG.FillRectangle(miBlushLightGray, new Rectangle(0, 0, pWidth, pHeight));
    oG.Flush();
    int yHitMarkWidth = 5;
    int yMargintop = 25;
    int yMarginbotton = 40;
    int xMarginLeft = 45;
    int xMarginRight = 45;
    int xDrawWidth = pWidth - xMarginLeft - xMarginRight;
    int yDrawHeight = pHeight - yMargintop - yMarginbotton;
    int xDrawWithMonth = xDrawWidth / 12;
    int xIni = 0;
    int xFin = 0;
    int yIni = 0;
    int yFin = 0;

    // 5a .- Titulos----------------------------------------------

    StringFormat drawFormat2 = new StringFormat();
    drawFormat2.Alignment = StringAlignment.Far;
    RectangleF drawRectLeft = new RectangleF(0, 0, pWidth / 2, 25);
    oG.DrawString(pTitSpecie, oFontTitleItalic, miBlackBrush, drawRectLeft, drawFormat2);
    oG.Flush();
    RectangleF drawRectRight = new RectangleF(pWidth / 2, 0, pWidth, 25);
    drawFormat2.Alignment = StringAlignment.Near;
    oG.DrawString(pTitAuthor, oFontTitleNormal, miBlackBrush, drawRectRight, drawFormat2);

   
    // 5b .- Titulos de ejes  verticales
   System.Drawing.Font drawFont = new System.Drawing.Font("Georgia", 9);
    System.Drawing.StringFormat drawFormatVertical = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
    oG.DrawString("Rain Days", drawFont, miBlackBrush, pWidth - 19, 85, drawFormatVertical);
    oG.DrawString("Ml x Month", drawFont, miBlackBrush, xMarginLeft - 50, 85, drawFormatVertical);


    // 5c dibujar titulos del pie

    System.Drawing.Font drawFontPie = new System.Drawing.Font("Arial", 8);
    Int32 iTitBoty = yDrawHeight + yMargintop + yHitMarkWidth + 10;
    Int32 iTitBotx = xMarginLeft;
    if (pbDrawMlMonth)
    {
        miPenRainMl.Color =System.Drawing.Color.LightBlue;
        oG.DrawLine(miPenRainMl, iTitBotx, iTitBoty + 8, iTitBotx + 20, iTitBoty + 8);
        oG.DrawString("Cm.", drawFontPie, miBlackBrush, iTitBotx + 23, iTitBoty);
    }
    if (pbDrawRainDaysMonth)
    {
        oG.DrawLine(miPenRainDay, iTitBotx + 63, iTitBoty + 8, iTitBotx + 83, iTitBoty + 8);
        oG.DrawString("Rain days ", drawFontPie, miBlackBrush, iTitBotx + 85, iTitBoty);
    }
    RectangleF drawRectRight2 = new RectangleF(iTitBotx + 140, iTitBoty, 400, 25);
    drawFormat2.Alignment = StringAlignment.Far;
    oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, drawRectRight2, drawFormat2);


    //oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, iTitBotx+150, iTitBoty);


    //- 6.- Poner Mosca
    //Bitmap bmp = (Bitmap)Bitmap.FromFile("d:/mosca24.jpg");
    Bitmap bmp = Properties.Resources.mosca24;
    //oG.DrawImage(bmp (pWidth - bmp.Width - 4), 4);
    oG.DrawImage(bmp, 3, pHeight - bmp.Height - 8);

    // 7a.- regilla de 12 meses
    int iDrawWidt = pWidth - xMarginLeft - xMarginRight;
    for (int n = 1; n < 13; n++)
    {
        xIni = xMarginLeft + n * xDrawWithMonth;
        xFin = xIni;
        yIni = yMargintop;
        yFin = pHeight - yMarginbotton + yHitMarkWidth;
        if (n < 12) oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
        oG.Flush();
        oG.DrawString(n.ToString(), oFont10N, System.Drawing.Brushes.Black, xIni - xDrawWithMonth / 2 - 10, yFin - 4);
    }
    //----------------------------------
    // 7b regilla de la lluvia mililistros 
    //----------------------------------
    
    double ydDrawHeight = yDrawHeight;
    double slotMililitros = ydDrawHeight / 500;
    xIni = xMarginLeft - yHitMarkWidth;
    xFin = xMarginLeft + xDrawWidth ;
    int yBase = pHeight - yMarginbotton + yHitMarkWidth;
    Int32 iMilitres = 0;
    //string szF = "";

    for (int n = 0; n < 501; n+=50)
    {
        iMilitres = n;
        yIni = Convert.ToInt32(slotMililitros  * n) + yMargintop;
        yFin = yIni;
        oG.DrawLine(miPenGrey, xIni, yIni, xFin, yFin);
        oG.Flush();
        iMilitres = 500 - iMilitres;
        oG.DrawString(iMilitres.ToString(), oFont06R, System.Drawing.Brushes.Black, xIni - 26, yFin - 8);
    }
    // 7c linea de dias de lluvia al mes de media
    double slotDias = ydDrawHeight / 31;
    Int32 iDays = 0;
    xIni = xMarginLeft ;
    xFin = xMarginLeft + xDrawWidth + yHitMarkWidth+3;
    if (pbDrawRainDaysMonth)
    {
        for (int n = 1; n < 32; n += 5)
        {


            yIni = Convert.ToInt32(slotDias * n) + yMargintop;
            yFin = yIni;
            if (pbDrawRainDaysMonth) oG.DrawLine(miPenRanDayH, xIni, yIni, xFin, yFin);
            oG.Flush();
            iDays = 31 - n;

            oG.DrawString(iDays.ToString(), oFont06R, System.Drawing.Brushes.Black, xDrawWidth + xMarginLeft + 10, yFin - 8);
        }
    }
    //...........................................
    // grafica de Luvia
    // pARainMlDay,  pARainMonthDay
    // double slotMililitros = ydDrawHeight / 500;
    // double slotDias = ydDrawHeight / 31;
    //...........................................

    int fx = 0;
    int iDesplacamientoX = xDrawWithMonth / 2;
    PointF[] oPointsML = new PointF[12];
    PointF[] oPointsDy = new PointF[12];
    //PointF[] oPointsMin = new PointF[12];
    int fyML = 0;
    int fyDay = 0;
    Rectangle[]  oRectangles = new Rectangle[12];
    int factorInvert = yDrawHeight + yMargintop;
    Int32 iTemp = 0;
    
    
        for (int n = 0; n < 12; n++)
        {
            fx = xMarginLeft + (n * xDrawWithMonth) + iDesplacamientoX;
            iTemp = pARainMlMonth[n];
            fyML = factorInvert - Convert.ToInt32(pARainMlMonth[n+1] * slotMililitros); // Convert.ToInt32(pdLatMax[n]); 
            fyDay = factorInvert - Convert.ToInt32(pARainDayMonth[n+1] * slotDias); // Convert.ToInt32(pdLatMax[n]); 
            oPointsML[n] = new Point(fx, fyML);
            oPointsDy[n] = new Point(fx, fyDay);
            int yHight = Convert.ToInt32(ydDrawHeight - fyML + yMargintop);
            oRectangles[n] = new Rectangle(fx - 10, fyML, 20, yHight);
        }

        System.Drawing.Brush oBrush = System.Drawing.Brushes.LightBlue;
    if (pbDrawMlMonth) oG.FillRectangles(oBrush, oRectangles);
    oG.Flush();
    if (pbDrawRainDaysMonth) oG.DrawCurve(miPenRainDay, oPointsDy, 0.2f); // se dibuja
    oG.Flush();
   
    

    //...........................................
    // 2.- Eje de coordenadas y derecha
    //...........................................
    xIni = pWidth - xMarginRight;
    xFin = xIni;
    yIni = yMargintop;
    yFin = pHeight - yMarginbotton + yHitMarkWidth;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();
    //...........................................
    // 3.- Eje de coordenadas y izquierda
    //...........................................
    xIni = xMarginLeft;
    xFin = xMarginLeft;
    yIni = yMargintop;
    yFin = pHeight - yMarginbotton + yHitMarkWidth;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();
    //...........................................
    // 4.- Eje de coordenadas x abajo
    //...........................................
    xIni = xMarginLeft - yHitMarkWidth;
    xFin = xMarginLeft + xDrawWidth + yHitMarkWidth;

    yIni = pHeight - yMarginbotton;
    yFin = yIni;
    oG.DrawLine(miPenBlack2, xIni, yIni, xFin, yFin);
    oG.Flush();

    RectangleF drawRectRight4 = new RectangleF(iTitBotx + 160, iTitBoty, 380, 25);
    drawFormat2.Alignment = StringAlignment.Far;
    oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, drawRectRight4, drawFormat2);

    //...........................................
    // guardar
    //...........................................
    oBmpImage.Save(szFileTemp);

    if (System.IO.File.Exists(pFileTargetFullPath))
    {
        System.IO.File.Delete(pFileTargetFullPath);
    }
    System.IO.File.Copy(szFileTemp, pFileTargetFullPath);
    System.IO.File.Delete(szFileTemp);
    oBmpImage.Dispose();
    miBlueBrush.Dispose();
    miBlackBrush.Dispose();
    myPen.Dispose();
    oG.Dispose();
    return pFileTargetFullPath;
}
public void   FncBldImgMin(int pLatMin, int pLatMax, int pAno, string pEspecie, string pPathTarget, bool bRebuildImage)
        {
            m_ErrorB = false;
            m_ErrorString = "";
            // preparar parametros
            m_ShortFileName = (pEspecie + pAno.ToString() + "_lmin" + pLatMin.ToString().PadLeft(2, '0') + "_lmax" + pLatMax.ToString().PadLeft(2, '0') + ".jpg").Trim().ToLower().Replace(" ", "_");
            m_ipLatMax = pLatMin;
            m_ipLatMax = pLatMax;
            m_iZoneYear = pAno;
            m_PathTarget = pPathTarget;
            m_PathTemp = m_PathTarget + "\\tmp";
            m_PathFileFullPath_target = m_PathTarget + "\\" + m_ShortFileName;
            string szId = Guid.NewGuid().ToString();
            m_PathFileFullPath_temp = m_PathTemp + "\\" + m_ShortFileName + szId + "_tmp.jpg";

            // borrar temporales si no estan en uso
            if (!System.IO.Directory.Exists(m_PathTemp)) System.IO.Directory.CreateDirectory(m_PathTemp);
            foreach (string szTemp in System.IO.Directory.GetFiles(m_PathTemp))
            {
                try
                {
                    System.IO.File.Delete(szTemp);
                }
                catch
                { ;}

            }
            // si ya existe la imagen no recalcularla
            if (System.IO.File.Exists(m_PathFileFullPath_target) && !bRebuildImage)
            {
                return;
            }
            {
                try
                {
                    System.IO.File.Delete(m_PathFileFullPath_target);
                }
                catch (Exception xcpt)
                {
                    m_ErrorB = true;
                    m_ErrorString = xcpt.Message;
                    return;
                }
            }
            //=======================================================================

            System.Drawing.Pen miPenMinRed = new System.Drawing.Pen(System.Drawing.Color.Red, 4);
            System.Drawing.Pen miPenMaxBlue = new System.Drawing.Pen(System.Drawing.Color.Blue, 4);
            System.Drawing.Pen miPenMinBlack = new System.Drawing.Pen(System.Drawing.Color.Black, 1);
            int iX = m_MinX + 2;
            int iY = m_MinY + m_MinYpie + 2;
            Bitmap oBmpImage = new Bitmap(iX, iY);


            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            SolidBrush miBlueBrush = new SolidBrush(m_BackColor);
            SolidBrush miBlushWhite = new SolidBrush(System.Drawing.Color.White);
            oG.FillRectangle(miBlushWhite, new Rectangle(0, 0, iX, iY));
            oG.Flush();
            SolidBrush miGreenBrush = new SolidBrush(System.Drawing.Color.DarkGreen);
            SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
            SolidBrush miDarkSlateGray = new SolidBrush(System.Drawing.Color.LightGray);

            oG.FillRectangle(miDarkSlateGray, new Rectangle(0, m_MinY, iX, 1));

            SolidBrush miBlackBrush3 = new SolidBrush(System.Drawing.Color.DarkGreen);
            oG.FillRectangle(miDarkSlateGray, new Rectangle(0, m_MinY, iX, m_MinYpie));

            oG.Flush();




            //-----------------------------------------------------
            // textos varios
            //-----------------------------------------------------
            // int iInterLineado = 14;
            float x = 3f;
            float y = m_MinY + 3f;
            System.Drawing.FontFamily fontCouNew = new System.Drawing.FontFamily("Courier New");
            System.Drawing.FontFamily fontArial = new System.Drawing.FontFamily("Verdana");
            Font oFontB = new Font(fontCouNew, 9, System.Drawing.FontStyle.Regular);
            Font oFontC = new Font(fontCouNew, 6.5f, System.Drawing.FontStyle.Bold);
            Font oFontN = new Font(fontArial, 10, System.Drawing.FontStyle.Bold);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.Blue);
            string szTitulo = pEspecie.Trim();
            StringFormat drawFormat2 = new StringFormat();
            drawFormat2.Alignment = StringAlignment.Center;
            string szLin2 = m_iZoneYear.ToString() + ". Latitud Min: " + pLatMin.ToString() + "º         Max:" + pLatMax.ToString() + "º";
            string szLin3 = "Sun hours day/Month  -  Horas de sol dia/Mes";
            RectangleF drawRect = new RectangleF(0, 0, m_MinX, 20);
            oG.DrawString(szTitulo, oFontN, miBlackBrush, drawRect, drawFormat2);
            oG.DrawString(szLin3, oFontB, System.Drawing.Brushes.Black, x, y);
            oG.DrawString(szLin2, oFontN, System.Drawing.Brushes.Black, x, y + 20);
            // horas en vertical

            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 9);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat(StringFormatFlags.DirectionVertical);
            oG.DrawString("Horas -Hours", drawFont, miBlackBrush, 3, 75, drawFormat);



            float LineY = 241;
            float lineX = 175;

            oG.DrawLine(miPenMinRed, lineX, LineY, lineX + 15, LineY);
            oG.DrawLine(miPenMaxBlue, lineX + 120, LineY, lineX + 135, LineY);

            //============================================================================
            // lineas Horizontales
            //=============================================================================
            int yn = 10;

            for (int n = 24; n > -2; n = n - 2)
            {
                szLin2 = n.ToString().PadLeft(2, '0');
                oG.DrawString(szLin2, oFontC, System.Drawing.Brushes.Black, 27, yn - 2);
                oG.DrawLine(miPenMinBlack, 42, yn + 8, m_MinX - 5, yn + 8);
                yn = yn + 15;
            }

            //============================================================================
            // lineas verticales
            //=============================================================================
            //x+28
            int xn = (int)x + 35;
            yn = (int)y - 15;

            for (int n = 1; n < 13; n++)
            {
                szLin2 = n.ToString().PadLeft(2, '0');
                oG.DrawString(szLin2, oFontC, System.Drawing.Brushes.Black, xn + 4, yn + 1);
                oG.DrawLine(miPenMinBlack, xn + 8, 15, xn + 8, yn);
                xn = xn + 27;
            }

            oG.FillRectangle(miBlackBrush, new Rectangle(36, yn, m_MinX - 36, 2));
            oG.Flush();
            double dMin = 24d;
            double dMax = 0d;
            ClsSunHourCalc oHorasSol = new ClsSunHourCalc();
            FncSunHoursCalc(pLatMin, pLatMax, pAno, ref dMin, ref dMax, ref  oHorasSol);

            // calculo del factor para situar los puntos
            // private int m_MinX = 350; // formato 4/3
            // private int m_MinY = 210; // formato 4/3
            // 24  ---- maxy (horas 
            // valor --- ptoY (meses)

            // 12  ---- maxX
            // valorx   -- ptoX
            // ptoX ) 210/12 * mes
            double ptoX1 = 0;
            double ptoY1Min = 0;
            double ptoY1Max = 0;
            double ptoX2 = 0;
            double ptoY2Min = 0;
            double ptoY2Max = 0;
            double factorX = 278 / 10;
            double factorY = (m_MinY - 25.99) / 24;

            int iDespX = 20;
            int iDespY = 16;
            for (int n = 2; n < 13; n++)
            {
                ptoX1 = ((n - 1) * factorX) + iDespX;
                ptoY1Min = (m_dHourMonthMin[n - 1] * factorY) + iDespY;
                ptoY1Max = (m_dHourMonthMax[n - 1] * factorY) + iDespY;
                ptoX2 = (n * factorX) + iDespX;
                ptoY2Min = (m_dHourMonthMin[n] * factorY) + iDespY;
                ptoY2Max = (m_dHourMonthMax[n] * factorY) + iDespY;
                // ajuste
                if (ptoY1Min > 197) ptoY1Min = 197;
                if (ptoY2Min > 197) ptoY2Min = 197;
                if (n > 1) // dibujar trazo desde n-1 a 1
                {
                    
                    oG.DrawLine(miPenMinRed, (float)ptoX1, (float)ptoY1Min, (float)ptoX2, (float)ptoY2Min);
                    oG.DrawLine(miPenMaxBlue, (float)ptoX1, (float)ptoY1Max, (float)ptoX2, (float)ptoY2Max);
                }

            }
            //------------------------------------- 
            // Calculo del maximo, minimo y diferencia
            for (int n = 1; n < 13; n++)
            {
                m_dHourMonthMin[n] = oHorasSol.FncCalAnoMes15(pLatMax, m_iZoneYear, n);
                if (dMin > m_dHourMonthMin[n]) dMin = m_dHourMonthMin[n];
                if (dMax < m_dHourMonthMin[n]) dMax = m_dHourMonthMin[n];
            }


            //============================================================
            //  poner la mosca
         
            //=====================================================
            // TODO CAMBIAR EL PAHT PARA RECOGER LA MOSCA
            //--------------------------------------------------------------------------
            // Bitmap bmp = (Bitmap)Bitmap.FromFile(ClsGlobal.DirRootFullPath + "a_img//a_app/mosca24.jpg");

            Bitmap bmp = (Bitmap)Bitmap.FromFile( "C:/mosca24.jpg");

            oG.DrawImage(bmp, m_MinX - 25, 2);
            //-----------------------------------------------------
            //-----------------------------------------------------
            //-----------------------------------------------------

            oBmpImage.Save(m_PathFileFullPath_temp,System.Drawing.Imaging.ImageFormat.Jpeg);
            if (System.IO.File.Exists(m_PathFileFullPath_target))
            {
                System.IO.File.Delete(m_PathFileFullPath_target);
            }
            System.IO.File.Copy(m_PathFileFullPath_temp, m_PathFileFullPath_target);

            oBmpImage.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }
public string FncBldImgBiome( string pFileTargetFullPath, string pTitSpecie, string pTitAuthor, string szTitLocation, ref Int32[] pATemMed, ref  Int32[] pARainMl)
{
  
    //---------------------------------------------------
    // dibujo
    // cargar la imagen de fondo desde el recurso
    string szFileTemp = Path.GetTempPath() + Path.GetRandomFileName() + ".jpg"; ;
    Image oBmpImage = Properties.Resources.Biome;
    Int32 pWidth = oBmpImage.Width;
    Int32 pHeight = oBmpImage.Height;
    Int32 iMedRain = 0;
    Int32 iSumRain = 0;
    Int32 iMedTemp = 0;


    SolidBrush miBlackBrush = new SolidBrush(System.Drawing.Color.Black);
    System.Drawing.FontFamily fontGeorgia = new System.Drawing.FontFamily("Georgia");
    System.Drawing.FontFamily oFontVerdana = new System.Drawing.FontFamily("Verdana");
    Font drawFontPie = new System.Drawing.Font("Arial", 8);
    Font oFontTitleItalic = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Italic);
    Font oFontTitleNormal = new Font(fontGeorgia, 11, System.Drawing.FontStyle.Regular);
    Font oFont10 = new Font(oFontVerdana, 8, System.Drawing.FontStyle.Regular);
    Font oFont7 = new Font(oFontVerdana, 7, System.Drawing.FontStyle.Regular);
    // calculo de la media
    for (int n=0; n<12;n++)
    {
    iSumRain+=pATemMed[n];
    iMedTemp += pARainMl[n];
    }
    if (iMedRain != 0) iMedRain = iSumRain / 12;
    if (iMedTemp != 0) iMedTemp = iMedTemp / 12;
    
    Graphics oG = Graphics.FromImage(oBmpImage);
    oG.PixelOffsetMode = PixelOffsetMode.HighQuality;
    oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
    oG.PixelOffsetMode = PixelOffsetMode.HighQuality; 
    
    // poner titulos
    StringFormat drawFormat2 = new StringFormat();
    drawFormat2.Alignment = StringAlignment.Far;
    RectangleF drawRectLeft = new RectangleF(0, 0, pWidth / 2, 25);
    oG.DrawString(pTitSpecie, oFontTitleItalic, miBlackBrush, drawRectLeft, drawFormat2);
    oG.Flush();
    RectangleF drawRectRight = new RectangleF(pWidth / 2, 0, pWidth, 25);
    drawFormat2.Alignment = StringAlignment.Near;
    oG.DrawString(pTitAuthor, oFontTitleNormal, miBlackBrush, drawRectRight, drawFormat2);
    oG.Flush();
    //---------------------------------------
    // poner medias
    RectangleF drawRectMed = new RectangleF(0, 15, pWidth-12 , 25);
    iSumRain = iSumRain / 10; //pasar a cm
    string szMed = iSumRain + " Cm,  " + iMedTemp + " ºC";
    float fx = 0f;
    float fy = 0f;
    fy =  14;
    fx = pWidth - 180;
    ////oG.DrawString(szMed, oFont10, miBlackBrush, fx, fy);
    //drawFormat2.Alignment = StringAlignment.Far;
    //oG.DrawString(szMed, oFont7, miBlackBrush, drawRectMed, drawFormat2);
    //oG.Flush();

  
    
    // poner un circulo rojo donde vive.

    System.Drawing.Pen miPenRed = new System.Drawing.Pen(System.Drawing.Color.Red, 4f);
    int iRad = 20;
    
    float fXCero = 48; //  
    float fYCero = 38;
    float fXAncho40 = 496 - fXCero; ;// 48=30ºC  447 distancia entre 30 y -10;
    float fYAlto400 = 276f - fYCero; // 276=0cc , 38 =400cc
    float fFactorX = (fXAncho40) / 40f;
    float fFactorY = (fYAlto400) / 400f;
    int iTem = iMedTemp;
    int iMl = iSumRain;
    int ix = Convert.ToInt32(fXCero +((30- iTem) * fFactorX))-iRad/2;
    int iy = Convert.ToInt32(fYAlto400 + fYCero - (iMl * fFactorY)) - iRad / 2;

    RectangleF drawRectRight2 = new RectangleF(pWidth - 390, pHeight-22, 380, 25);
    drawFormat2.Alignment = StringAlignment.Far;
    oG.DrawString(szTitLocation, drawFontPie, miBlackBrush, drawRectRight2, drawFormat2);
    
    Rectangle miRectangle = new Rectangle(ix, iy, iRad, iRad);
    oG.DrawEllipse(miPenRed, miRectangle);
    oG.Flush();
    
    //...........................................
    // guardar
    //...........................................
    oBmpImage.Save(szFileTemp,System.Drawing.Imaging.ImageFormat.Jpeg);

    if (System.IO.File.Exists(pFileTargetFullPath))
    {
        System.IO.File.Delete(pFileTargetFullPath);
    }
    System.IO.File.Copy(szFileTemp, pFileTargetFullPath);
    System.IO.File.Delete(szFileTemp);
    oBmpImage.Dispose();
    oG.Dispose();
    return pFileTargetFullPath;
}

private void FncSunHoursCalc(int pLatMin, int pLatMax, int pAno, ref double dMin, ref double dMax, ref ClsSunHourCalc oHorasSol)
        {
            //============================================================
            // calculo y dibujo de la grafica horas de sol
            //=============================================================


            dMin = 24d;
            dMax = 0d;
            for (int n = 1; n < 13; n++)
            {
                if (pLatMin == -99)
                {
                    m_dHourMonthMin[n] = 0;
                }
                else
                {
                    m_dHourMonthMin[n] = oHorasSol.FncCalAnoMes15(pLatMin, m_iZoneYear, n);
                }
                if (pLatMax == -99)
                {
                    m_dHourMonthMax[n] = 0;
                }
                else
                {
                    m_dHourMonthMax[n] = oHorasSol.FncCalAnoMes15(pLatMax, m_iZoneYear, n);
                }


                if (dMin > m_dHourMonthMin[n]) dMin = m_dHourMonthMin[n];
                if (dMax < m_dHourMonthMin[n]) dMax = m_dHourMonthMin[n];
            }
        }

private string FncAbrevia(string szTexto, int iLen, bool Mostrar3puntos, bool bLimpiar)
        {
            szTexto = szTexto.Trim();
            while (szTexto.Contains("  "))
            {
                szTexto.Replace("  ", " ");
            }
            if (Mostrar3puntos)
            {
                if (szTexto.Length > iLen && szTexto.Length > 3) szTexto = szTexto.Substring(0, iLen - 3) + "...";
            }
            else
            {
                if (szTexto.Length > iLen && szTexto.Length > 3) szTexto = szTexto.Substring(0, iLen);
            }
            return szTexto;
        }


        /// <summary>
        ///  zona de gets y sets
        /// </summary>
        /// 

    // open a filestream for the file we wish to look at
   
        #region

/// <summary>
/// return default no image for Wittaker Biome
/// </summary>
public Image WheatherBiome_NoImage
{
    get { return Properties.Resources.noimage_WheatherBiome; }
}
/// <summary>
/// return default no image for rain month
/// </summary>
public Image WheatherRain_NoImage
{
    get { return Properties.Resources.noimage_WheatherRain ; }
}
/// <summary>
/// return default no image for sun hours
/// </summary>
public Image WheatherSun_NoImage
{
    get { return Properties.Resources.noimage_WheatherSun ; }
}
        /// <summary>
        /// return default no image for temperatures
        /// </summary>
public Image WheatherTemp_NoImage
{
    get { return Properties.Resources.noimage_WheatherTmp; }
}

        public bool ErrorB
        {
            get { return m_ErrorB; }

        }
        public string Error
        {
            get { return m_ErrorString; }
        }
        public string FileShortName
        {
            get { return m_ShortFileName; }
        }
        /// <summary>
        /// Matriz de trece elementos con las horas de sol
        /// para la latitud mas al sur
        /// </summary>
        public double[] dHourMonthMin
        {
            get { return m_dHourMonthMin; }
        }
        /// <summary>
        /// Matriz de trece elementos con las horas de sol
        /// para la latitud mas al norte
        /// </summary>
        public double[] dHourMonthMax
        {
            get { return m_dHourMonthMax; }
        }
        public string PathFileFullPath_target
        {
            get { return m_PathFileFullPath_target; }
        }
        public string PathFileFullPath_temp
        {
            get { return m_PathFileFullPath_temp; }
        }
        #endregion
    }
}
