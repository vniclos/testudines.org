   using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Resources;
 
namespace testudines.cls
{

    public class clsImgTool
    {
        
        private static FontFamily fontfml = new FontFamily("Helvetica");
        private Font oFontB = new Font(fontfml, 10, FontStyle.Bold,GraphicsUnit.Pixel);
        private Font oFontN = new Font(fontfml, 10, FontStyle.Regular, GraphicsUnit.Pixel);
        private int m_dpi_default = 150;
        private System.Drawing.Pen oPenWithe = new Pen(System.Drawing.Color.White);
        private System.Drawing.Pen oPenBlack = new Pen(System.Drawing.Color.Black);
        private System.Drawing.Pen oPenGray = new Pen(System.Drawing.Color.Gray);


        private string m_error = "";

        private bool m_BldMiniatura = true;
        private bool m_BldMinaturaLupa = true;
        private bool m_BldMedia = true;
        private bool m_BldBig = true;
        
        private bool m_BldFull = true;

        private string m_AppPathTemp = "";
        private string m_FileSrcFullName = "";
        private string m_PathTarget = "";
        private string m_FileFulnameMinBack_tmp = ""; // si moscas
        private string m_FileFulnameMinImg_tmp = ""; //miniatura imagen
        private string m_FileFulnameMin_tmp = ""; // con mosca
        private string m_FileFulnameMinX_tmp= ""; // con mosca y lupa
        private string m_FileFulnameMed_tmp = "";
        private string m_FileFulnameBig_tmp = "";
        private string m_FileFulnameMedImg_tmp = "";
        private string m_FileFulnameBigImg_tmp = "";
        private string m_FileFulnameFul_tmp = "";
        private string m_FileFulnameSrc_tmp = "";

        private string m_FileFulnameMin = "";
        private string m_FileFulnameMinX = "";
        private string m_FileFulnameMed = "";
        private string m_FileFulnameBig = "";
        private string m_FileFulnameFul = "";
        private string m_lin1 = "";
        private string m_lin2 = "";
        private string m_lin3 = "";
        private string m_lin4Loc = "";
        private string m_Item ="";
        public string m_ItemLot = "";
        private Color m_BackColor = Color.LightGray  ;
        // extensiones para los ficheros tratados a partir de la imagen
        // que tendran titulo, autor, y fuente original
        private string m_ImgMin = "_min.jpg"; // minatura
        private string m_ImgMinX = "_minx.jpg"; // miniatura con lupa
        private string m_ImgMed = "_med.jpg"; // Medio tamaño
        private string m_ImgBig = "_big.jpg"; // Medio tamaño
        private string m_ImgFul = "_ful.jpg"; // tamaño completo
        //private string m_FileMosca = "mosca.jpg"; 
        //private string m_FileLupa="lupa.jpg";

        // tamaño de la parte fotogramas creados
        // a esta parte se le añade 1px por cada lado de borde
        // mas un pie para el texto.
        private int m_MinX = 196; // formato 4/3
        private int m_MinY = 143; // formato 4/3
        private int m_MinYpie = 40;
        private int m_MedX = 600; // formato 4/3
        private int m_MedY = 450; // formato 4/3
        private int m_BigX= 1024; // formato 4/3
        private int m_BigY = 768; // formato 4/3
        
        //private int m_FulX = 0; // tamaño de la imagen se calcula al abrir la imagen original
        //private int m_FulY = 0; // tamaño de la imagen se calcula al abrir la imagen original
        bool m_bForzarRatio_4x3 = false;
        bool m_bForzarRatio_3x2 = false;
        //private int m_avtX = 100;
        //private int m_AvtY = 100;
        //private string m_FileFulnameAvtImg_tmp;
     
        public clsImgTool(string AppPathTemp)
        {
            m_AppPathTemp = AppPathTemp;
           // m_FileMosca = m_AppPath + m_FileMosca;
           // m_FileLupa = m_AppPath + m_FileLupa;
         

        }
        /// <summary>
        /// Crea a partir de una imagen, 2 thumbnails con y sin lupa, una imagen de tamaño reducido y otra de tamaño original, a las que agrega un pie descriptivo
        /// el nombre de los ficheros obtenidos se conforma con en nombre de las tres lineas y las extensiones
        /// minx.jpg, min.jpg, med.jpg, ful.jpg
        /// </summary>
        /// <param name="szLin1">Primera linea del pie, Normalmente la especie o nombre del objeto representado</param>
        /// <param name="szLin2">Normalmente el autor de la imagen</param>
        /// <param name="szLin3">Normalemnte la fuente de la imagen. o lugar</param>
        /// <param name="szItem">Numerador secuencial para ficheros del mismo titulo, autor,fuente (Lin1,Lin2,lin3) </param>
        /// <param name="FileSrcFullName">Ruta completa del fichero original, incluido el nombre del fichero</param>
        /// <param name="PathTarget">Ruta destino de las imagenes obtenidas sin el nombre del fichero</param>
        public void FncBldImgs(string szLin1, string szLin2, string szLin3, string lin4Loc, string szItemLot,string szItem, string FileSrcFullName, string PathTarget, bool bOverWrite)
        {
            m_error="";
            //==========================
            // guardar parametros
            //==========================
            m_lin1 = szLin1;
            m_lin2 = szLin2;
            m_lin3 = szLin3;
            m_lin4Loc = lin4Loc;
            szItemLot = szItemLot.Trim();
            if (szItemLot == "") szItemLot = "001";
            if (szItemLot.Length < 3) szItemLot = szItemLot.PadLeft(3, '0');
            if (szItem.Length < 3) szItem = szItem.PadLeft(3, '0');
            m_Item = szItem.Trim();
            m_ItemLot = szItemLot;
            m_FileSrcFullName = FileSrcFullName;
            m_PathTarget=PathTarget+"\\";
            //m_FileMosca = m_AppPath + ("\\mosca.jpg");
            //==================== 
            // Prepara directorios y nombres de fichero temporales,
            //==================== 

            string szDirTemporales = m_AppPathTemp; // System.IO.Path.GetTempPath()+"testudines\\"; //ClsGlobal.DirTempSessionFullPath; 
            if (!System.IO.Directory.Exists(szDirTemporales)) System.IO.Directory.CreateDirectory(szDirTemporales);
            if (!System.IO.Directory.Exists(m_PathTarget)) System.IO.Directory.CreateDirectory(m_PathTarget);
            // borrar basura de temporales por si las fly
            foreach (string oFile in System.IO.Directory.GetFiles( szDirTemporales))
            {
                try {
                    System.IO.File.Delete (oFile);
                }catch {;}
            }


            string szId = Guid.NewGuid().ToString();
            m_FileFulnameSrc_tmp = szDirTemporales + "\\" + szId + "_src_tmp.jpg";
        
            m_FileFulnameMinImg_tmp = szDirTemporales + "\\" + szId + "_minImg_tmp.jpg";
            m_FileFulnameMinBack_tmp=  szDirTemporales +"\\"+ szId + "_minBack_tmp.jpg";
            m_FileFulnameMin_tmp = szDirTemporales + "\\" + szId + m_ImgMin ;
            m_FileFulnameMinX_tmp = szDirTemporales + "\\" + szId + m_ImgMinX ;

            m_FileFulnameMed_tmp = szDirTemporales + "\\" + szId + m_ImgMed ;
            m_FileFulnameBig_tmp = szDirTemporales + "\\" + szId + m_ImgBig
                ;
            m_FileFulnameMedImg_tmp = szDirTemporales + "\\" + szId + "_medImg_tmp.jpg"; ;
            m_FileFulnameBigImg_tmp = szDirTemporales + "\\" + szId + "_BigImg_tmp.jpg"; ;
            

            m_FileFulnameFul_tmp = szDirTemporales + "\\" + szId + m_ImgFul;

            string  szFilePrefijoName = m_lin2 + m_lin2 + m_lin3;
            if (szFilePrefijoName.Length > 128)
            {

                szFilePrefijoName = FncAbrevia(szFilePrefijoName, 128, false);
            }

            string szFile = "";
            szFile += FncAbrevia(m_lin1, 25, false,true).Replace(" ", "-").ToLower ();
            szFile += "_" + FncAbrevia(m_lin2, 25, false,true).Replace(" ", "-").ToLower ();
            
            if (m_lin3.Length > 0)
            {
                szFile += "_" + FncAbrevia(m_lin3, 25, false).Replace(" ", "-").ToLower();
            }

            szFile += "_" + FncAbrevia(m_ItemLot, 5, false, true).Replace(" ", "-").ToLower();
            szFile += "_" + FncAbrevia(m_Item, 5, false, true).Replace(" ", "-").ToLower();
            // ELIMINAR CARACTERS NO VALIDOS EN NOMBRE DE FICHERO
           
           szFile = FncFileNameNormalice(szFile);
          
           
            //-----------------------------------------------------------
            // cambiar en nomre si si ya existe y overwrite pone a falso
            // esto agrega un numerador al final del nombre tipo 0001.jpg
            //-----------------------------------------------------------
           int iNum = 1;
           string sziNum = "001";
           m_FileFulnameMin = m_PathTarget + szFile + m_ImgMin;
           m_FileFulnameMinX = m_PathTarget + szFile + m_ImgMinX;
           m_FileFulnameMed = m_PathTarget + szFile + m_ImgMed;
           m_FileFulnameBig = m_PathTarget + szFile +  m_ImgBig;
           m_FileFulnameFul = m_PathTarget + szFile +  m_ImgFul;
           if (!bOverWrite)
           {
              while (System.IO.File.Exists(m_FileFulnameMin))
                {
                    sziNum = iNum.ToString().PadLeft(3, '0');
                    m_FileFulnameMin = m_PathTarget + szFile + sziNum + m_ImgMin;
                    m_FileFulnameMinX = m_PathTarget + szFile + sziNum + m_ImgMinX;
                    m_FileFulnameMed = m_PathTarget + szFile + sziNum + m_ImgMed;
                    m_FileFulnameBig = m_PathTarget + szFile + sziNum + m_ImgBig;
                    m_FileFulnameFul = m_PathTarget + szFile + sziNum + m_ImgFul;

                }
            }
           if (!System.IO.File.Exists(m_FileFulnameSrc_tmp)) System.IO.File.Delete(m_FileFulnameSrc_tmp);
        
            if (!System.IO.File.Exists(m_FileFulnameMinImg_tmp)) System.IO.File.Delete(m_FileFulnameMinImg_tmp);
            if (!System.IO.File.Exists(m_FileFulnameMinBack_tmp)) System.IO.File.Delete(m_FileFulnameMinBack_tmp);
            if (!System.IO.File.Exists(m_FileFulnameMin_tmp)) System.IO.File.Delete(m_FileFulnameMin_tmp);
            if (!System.IO.File.Exists(m_FileFulnameMinX_tmp)) System.IO.File.Delete(m_FileFulnameMinX_tmp);
            if (!System.IO.File.Exists(m_FileFulnameMed_tmp )) System.IO.File.Delete(m_FileFulnameMed_tmp );
            if (!System.IO.File.Exists(m_FileFulnameBig_tmp)) System.IO.File.Delete(m_FileFulnameBig_tmp);

            if (!System.IO.File.Exists(m_FileFulnameFul_tmp )) System.IO.File.Delete(m_FileFulnameFul_tmp );
            
            if (!System.IO.File.Exists(m_FileFulnameMin)) System.IO.File.Delete(m_FileFulnameMin);
            if (!System.IO.File.Exists(m_FileFulnameMinX)) System.IO.File.Delete(m_FileFulnameMinX);
            if (!System.IO.File.Exists(m_FileFulnameMed)) System.IO.File.Delete(m_FileFulnameMed);
            if (!System.IO.File.Exists(m_FileFulnameBig)) System.IO.File.Delete(m_FileFulnameBig);
            if (!System.IO.File.Exists(m_FileFulnameFul)) System.IO.File.Delete(m_FileFulnameFul);

            // ---------------------------------------
            // estandarizar el fichero de entrada dpi
            ///---------------------------------------
            //factXY = 196 / 800;
            // si la imagen ya es menor que el cuadrado donde va a ir
            // estandarizar dpi
            // System.IO.Path.GetTempPath();
            Bitmap bitmapSrcOld = (Bitmap)Image.FromFile(FileSrcFullName);
            Bitmap bitmapSrcNew = new Bitmap(bitmapSrcOld);
            bitmapSrcNew.SetResolution(m_dpi_default, m_dpi_default);
            bitmapSrcNew.Save(m_FileFulnameSrc_tmp, ImageFormat.Jpeg);
            bitmapSrcOld.Dispose();
            bitmapSrcNew.Dispose();
            // hacemos que el original sea el fichero temporal con dpi standarizado.
            m_FileSrcFullName = m_FileFulnameSrc_tmp;

           

            //#########################################################################
            //#########################################################################
            // crear las imagenes:
            //#########################################################################
            //#########################################################################
            // MINIATURA SIN LUPA
            if (m_BldMinaturaLupa || m_BldMiniatura)
            {
                FncBldFondoMin();
                FncBldFondoMinImg();
            }
            // MINIATURA CON LUPA
            if (m_BldMiniatura)  FncBldFondoMinMosca();
            if (m_BldMinaturaLupa) FncBldFondoMinLupaMosca();
            // TAMAÑO MEDIO
            if (m_BldMedia)
            {
                FncBldFondoMedImg();
                FncBldFondoMed();
            }
            if (m_BldBig)
            {
                Bitmap oBmp = (Bitmap) Bitmap.FromFile(m_FileFulnameSrc_tmp);
                int iX = oBmp.Width;
                int iY = oBmp.Height;

                if (m_BigX <= iX) iX = m_BigX;
                if (m_BigY <= iY) iY = m_BigY;
                FncBldFondoBigImg(iX, iY);
                FncBldFondoBig(iX, iY);
            }
            // tamaño grande

            // TAMAÑO COMPLETO.
            if (m_BldFull) FncBldFondoFul();

            // copiar imagenes de temporales a destino.
            try
            {
                // borrar temporales de trabajo
                if (System.IO.File.Exists (m_FileFulnameMin_tmp)) System.IO.File.Copy(m_FileFulnameMin_tmp, m_FileFulnameMin, true);
                if (System.IO.File.Exists(m_FileFulnameMinX_tmp)) System.IO.File.Copy(m_FileFulnameMinX_tmp, m_FileFulnameMinX, true);
                if (System.IO.File.Exists(m_FileFulnameMed_tmp))  System.IO.File.Copy(m_FileFulnameMed_tmp, m_FileFulnameMed, true);
                if (System.IO.File.Exists(m_FileFulnameFul_tmp))  System.IO.File.Copy(m_FileFulnameFul_tmp, m_FileFulnameFul, true);
                if (System.IO.File.Exists(m_FileFulnameBig_tmp))  System.IO.File.Copy(m_FileFulnameBig_tmp, m_FileFulnameBig, true);
            }
            catch (Exception xcpt)
            {
                m_error = xcpt.Message;
            
            }

        }
        //#########################################################################
        //#########################################################################
        //#########################################################################
        //=========================================================        
        //================= MINIATURAS FONDO   ====================
        //=========================================================
        // crea el fondo de las miniaturas con el texto
        // y lo guarda en un fichero temporal para tratarlo despues
        private void FncBldFondoMin()
        {



            int iX = m_MinX + 2;
            int iY = m_MinY + m_MinYpie + 2;
            //Bitmap oBmpImage = new Bitmap(iX, iY);
            Bitmap oBmpImage = new Bitmap(iX, iY,System.Drawing.Imaging.PixelFormat.Format24bppRgb) ;
            oBmpImage.SetResolution(m_dpi_default, m_dpi_default);
         
            //Image thumb = new Bitmap(200, 200,System.Drawing.Imaging.PixelFormat.Format24bppRgb) ;


            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            // System.Drawing.Color myOrangeColor = HexStringToColor("#006699");

            //            //  oG.FillRectangle(System.Drawing.Brushes.DarkGray , new Rectangle(0, 0, iX, iY));
            SolidBrush miBlueBrush = new SolidBrush(m_BackColor);
            oG.FillRectangle(miBlueBrush, new Rectangle(0, 0, iX, iY));
            oG.Flush();
            SolidBrush miBlackBrush = new SolidBrush(Color.Black);
            oG.FillRectangle(miBlackBrush, new Rectangle(0, m_MinY, iX, 1));
            oG.Flush();




            //-----------------------------------------------------
            // texto
            //-----------------------------------------------------
            int iInterLineado = 12;
            float x = 3f;
            float y = m_MinY + 3f;
            //FontFamily fontfmlv = new FontFamily("Arial");
            //FontFamily fontfml = new FontFamily("Arial");
            //Font oFontB = new Font(fontfmlv, 8, FontStyle.Bold);
            //Font oFontN = new Font(fontfml, 7, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Blue);
            // abreviar texto
            string szLin1 = FncAbrevia(m_lin1, 27, true);
            string szLin2 = FncAbrevia(m_lin2, 35, true);
            string szLin3 = FncAbrevia(m_lin3, 35, true);
            oG.DrawString(szLin1, oFontB, Brushes.Black, x, y);
            oG.DrawString(szLin2, oFontN, Brushes.Black, x, y + iInterLineado);
            oG.DrawString(szLin3, oFontN, Brushes.Black, x, y + iInterLineado * 2);
            oG.Flush();
          oBmpImage.Save(m_FileFulnameMinBack_tmp);
            oBmpImage.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }
        private void FncBldFondoMinMosca()
        {
            int iBackWidth, iBackHeight;
            int iMoscaWidth, iMoscaHeight;
            int iMiniaturaWidth, iMiniaturaHeight;
            int xPos, yPos;



            //Create una seguna imangen de minatura pero con moscas de lupa
            
        
            //Get Image objct
            System.Drawing.Image ImgBack = Bitmap.FromFile(m_FileFulnameMinBack_tmp);
            System.Drawing.Image ImgMiniatura = Bitmap.FromFile(m_FileFulnameMinImg_tmp );
            //System.Drawing.Image ImgMosca = Properties.Resources.mosca;           // Bitmap.FromFile(m_FileMosca);

            Bitmap ImgMosca = Properties.Resources.mosca;
            ImgMosca.SetResolution(m_dpi_default, m_dpi_default);
            Graphics objGraphics = Graphics.FromImage(ImgBack);
          
            //Retrieve the Height and Width of Images
            iBackWidth = ImgBack.Width;
            iBackHeight = ImgBack.Height;
            iMoscaWidth = ImgMosca.Width;
            iMoscaHeight = ImgMosca.Height;
            iMiniaturaWidth=ImgMiniatura.Width;
            iMiniaturaHeight=ImgMiniatura.Height;

            // calcular y colocar imagen niniatura
            xPos = 1+ (iBackWidth - iMiniaturaWidth )/2 ;
            yPos = 1 + m_MinY - iMiniaturaHeight;// 2 * iBackHeight - iMiniaturaHeight - 1;
            objGraphics.DrawImage(ImgMiniatura, new Point(xPos, yPos)); 

            // Calcular la posicion de la Segunda mosca
            xPos = (iBackWidth - iMoscaWidth - 4) ;
            yPos = (m_MinY + 4)  ;
            objGraphics.Flush();
            objGraphics.DrawImage(ImgMosca, new Point(xPos, yPos));


            // Guardar la imagen
           
            //-----------------------------------------------------------------------------------------         
            // codificar para bajar la resolucion de la miniatura y peso de imagen 6/3/2011
            //ImageCodecInfo myImageCodecInfo;
            //myImageCodecInfo = GetEncoderInfo("image/jpeg");
            //System.Drawing.Imaging.Encoder myEncoder;
            //System.Drawing.Imaging.EncoderParameter    myEncoderParameter;
            //System.Drawing.Imaging.EncoderParameters  myEncoderParameters;
            //myEncoder = System.Drawing.Imaging.Encoder.Quality;       
            //myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 100L);
            //myEncoderParameters = new EncoderParameters(1);
            //myEncoderParameters.Param[0] = myEncoderParameter;
            //ImgBack.Save(m_FileFulnameMin_tmp, myImageCodecInfo, myEncoderParameters);
            //---------------------------------------------------------------------------
             ImgBack.Save(m_FileFulnameMin_tmp);
            ImgBack.Dispose();
            objGraphics.Dispose();

        }
        private void FncBldFondoMinLupaMosca()
        {
            System.Drawing.Image ImgMinMosca = Bitmap.FromFile(m_FileFulnameMin_tmp);
            Bitmap ImgLupa = Properties.Resources.lupa;
            ImgLupa.SetResolution(m_dpi_default, m_dpi_default);
           //System.Drawing.Image ImgLupa = Bitmap.FromFile(m_FileLupa);
            Graphics objGraphics = Graphics.FromImage(ImgMinMosca);
            int iImgLupaWidth = ImgLupa.Width;
            int iImgLupaHeight = ImgLupa.Height;
            int iImgWidth = ImgMinMosca.Width; ;
            int iImgHeight = ImgMinMosca.Height;

            int xPos = (iImgWidth - iImgLupaWidth - 4);// / 2;
            int yPos = (iImgHeight- iImgLupaHeight - 2);//  / 2;
            objGraphics.DrawImage(ImgLupa, new Point(xPos, yPos));

            objGraphics.Flush();
            ImgMinMosca.Save(m_FileFulnameMinX_tmp);      
        }
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
        protected int HexStringToBase10Int(string hex)
        {
            int base10value = 0;

            try { base10value = System.Convert.ToInt32(hex, 16); }
            catch { base10value = 0; }

            return base10value;
        }
        private System.Drawing.Color HexStringToColor(string hex)
        {
            hex = hex.Replace("#", "");

            if (hex.Length != 6)
                throw new Exception(hex +
                    " is not a valid 6-place hexadecimal color code.");

            string r, g, b;

            r = hex.Substring(0, 2);
            g = hex.Substring(2, 2);
            b = hex.Substring(4, 2);

            return System.Drawing.Color.FromArgb(HexStringToBase10Int(r),
                                                 HexStringToBase10Int(g),
                                                 HexStringToBase10Int(b));
        }
        //=========================================================
        //=========================================================        
        //================= Medio FONDO   ====================
        //=========================================================
        
        private void FncBldFondoMed()
        {

            System.Drawing.Image oBmpImageSrc = Bitmap.FromFile(m_FileSrcFullName);

            int iXDSrc= oBmpImageSrc.Width ;
            int iYSrc = oBmpImageSrc.Height;
            m_MedY = (600*iYSrc) / iXDSrc;
            //Modificacion para eliminar espacio extra en eje Y.

            int iX = m_MedX + 2;
            int iY = m_MedY + m_MinYpie + 2;
            //Bitmap oBmpImage = new Bitmap(iX, iY);
            Bitmap oBmpImage = new Bitmap(iX, iY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            oBmpImage.SetResolution(m_dpi_default, m_dpi_default);

            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            // System.Drawing.Color myOrangeColor = HexStringToColor("#006699");

            //            //  oG.FillRectangle(System.Drawing.Brushes.DarkGray , new Rectangle(0, 0, iX, iY));
            SolidBrush miBlueBrush = new SolidBrush(m_BackColor);
            oG.FillRectangle(miBlueBrush, new Rectangle(0, 0, iX, iY));
            oG.Flush();
            SolidBrush miBlackBrush = new SolidBrush(Color.Black);
            oG.FillRectangle(miBlackBrush, new Rectangle(0, m_MedY, iX, 1));
            oG.Flush();




            //-----------------------------------------------------
            // texto
            //-----------------------------------------------------
            int iInterLineado = 12;
            float x = 3f;
            float y = m_MedY + 3f;
            //FontFamily fontfml = new FontFamily("Arial");
            //Font oFontB = new Font(fontfml, 8, FontStyle.Bold);
            //Font oFontN = new Font(fontfml, 7, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Blue);
            // abreviar texto
            string szLin1 = FncAbrevia(m_lin1, 53, true);
            string szLin2 = FncAbrevia(m_lin2, 53, true);
            string szLin3 = FncAbrevia(m_lin3, 53, true);
            string szLin4 = m_lin4Loc;

            oG.DrawString(szLin1, oFontB, Brushes.Black, x, y);
            StringFormat oFormat = new StringFormat();
            oFormat.Alignment = StringAlignment.Far;
            int iX2 = iX / 2;
            int iY2 = Convert.ToInt32(y);
            //REVISAR 28/11/2012
            //Rectangle oRecE = new Rectangle(iX2 + 10, iY2, iX2 - 40, 45);
            Rectangle oRecE = new Rectangle(iX2 + 10, iY2, iX2 - 35, 45);
            oG.DrawString(szLin4, oFontN, Brushes.Black, oRecE, oFormat);
            oG.DrawString(szLin2, oFontN, Brushes.Black, x, y + iInterLineado);
            oG.DrawString(szLin3, oFontN, Brushes.Black, x, y + iInterLineado * 2);

            oG.Flush();
            //=======================================================
            // agregar la imagen redimensionada
            //=======================================================
            System.Drawing.Image MiniaturaImage = Bitmap.FromFile(m_FileFulnameMedImg_tmp);
            int xd = (iX - MiniaturaImage.Width) / 2;
            int yd = (m_MedY - MiniaturaImage.Height + 2) / 2;
            oG.DrawImage(MiniaturaImage, new Point(xd, yd));
            oG.Flush();
            //=======================================================
            // agregar la mosca
            //=======================================================
            //System.Drawing.Image MoscaImage = Bitmap.FromFile(m_FileMosca );
            Bitmap MoscaImage = Properties.Resources.mosca;
            MoscaImage.SetResolution(m_dpi_default, m_dpi_default);

            xd = (iX - MoscaImage.Width - 2);
            yd = (iY - MoscaImage.Height - 2);
            oG.DrawImage(MoscaImage, new Point(xd, yd));
            oG.Flush();


            //-----------------------------------------------------
            //-----------------------------------------------------
            //-----------------------------------------------------
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters;
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 110L);
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            oBmpImage.Save(m_FileFulnameMed_tmp, myImageCodecInfo, myEncoderParameters);
            //------------------------------------------------------------------
            //oBmpImage.Save(m_FileFulnameMed_tmp );
            oBmpImage.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }


        //=========================================================        
        //================= grande FONDO   ====================
        //=========================================================
        
        private void FncBldFondoBig (Int32 iMaxWidth, Int32 iMaxHeight)
        {
            int iX = iMaxWidth + 2;
            int iY = iMaxHeight + m_MinYpie + 2;
            //Bitmap oBmpImage = new Bitmap(iX, iY);
            Bitmap oBmpImage = new Bitmap(iX, iY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            oBmpImage.SetResolution(m_dpi_default, m_dpi_default);
         
            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            // System.Drawing.Color myOrangeColor = HexStringToColor("#006699");

            //            //  oG.FillRectangle(System.Drawing.Brushes.DarkGray , new Rectangle(0, 0, iX, iY));
            SolidBrush miBlueBrush = new SolidBrush(m_BackColor);
            oG.FillRectangle(miBlueBrush, new Rectangle(0, 0, iX, iY));
            oG.Flush();
            SolidBrush miBlackBrush = new SolidBrush(Color.Black);
            oG.FillRectangle(miBlackBrush, new Rectangle(0, m_BigY, iX, 1));
            oG.Flush();




            //-----------------------------------------------------
            // texto
            //-----------------------------------------------------
            int iInterLineado = 12;
            float x = 3f;
            float y = iMaxHeight + 3f;
            //FontFamily fontfml = new FontFamily("Arial");
            //Font oFontB = new Font(fontfml, 8, FontStyle.Bold);
            //Font oFontN = new Font(fontfml, 7, FontStyle.Regular);
            SolidBrush brush = new SolidBrush(Color.Blue);
            // abreviar texto
            string szLin1 = FncAbrevia(m_lin1, 53, true);
            string szLin2 = FncAbrevia(m_lin2, 53, true);
            string szLin3 = FncAbrevia(m_lin3, 53, true);
            string szLin4 = m_lin4Loc;
            oG.DrawString(szLin1, oFontB, Brushes.Black, x, y);
            StringFormat oFormat = new StringFormat();
            oFormat.Alignment = StringAlignment.Far;
            int iX2 = iX / 2;
            int iY2 = Convert.ToInt32(y);
            // REVISAR 28/11/2012
            //  Rectangle oRecE = new Rectangle(iX2+10 , iY2, iX2-40, 45);
            Rectangle oRecE = new Rectangle(iX2 + 10, iY2, iX2 - 35, 45);
            oG.DrawString(szLin4, oFontN, Brushes.Black, oRecE, oFormat);

            oG.DrawString(szLin2, oFontN, Brushes.Black, x, y + iInterLineado);
            oG.DrawString(szLin3, oFontN, Brushes.Black, x, y + iInterLineado * 2);
            oG.Flush();
            //=======================================================
            // agregar la imagen redimensionada
            //=======================================================
            System.Drawing.Image MiniaturaImage = Bitmap.FromFile(m_FileFulnameBigImg_tmp);
            int xd = ((iX - MiniaturaImage.Width) / 2)-1;
            int yd = (iMaxHeight - MiniaturaImage.Height + 2) / 2;
            oG.DrawImage(MiniaturaImage, new Point(xd, yd));
            oG.Flush();
            //=======================================================
            // agregar la mosca
            //=======================================================
           // System.Drawing.Image MoscaImage = Bitmap.FromFile(m_FileMosca);
            Bitmap MoscaImage = Properties.Resources.mosca;
            MoscaImage.SetResolution(m_dpi_default, m_dpi_default);
  
            
            xd = (iX - MoscaImage.Width - 2);
            yd = (iY - MoscaImage.Height - 2);
            oG.DrawImage(MoscaImage, new Point(xd, yd));
            oG.Flush();


            //-----------------------------------------------------
            //-----------------------------------------------------
            //-----------------------------------------------------
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters;
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 110L);
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            oBmpImage.Save(m_FileFulnameBig_tmp, myImageCodecInfo, myEncoderParameters);
            //------------------------------------------------------------------
            //oBmpImage.Save(m_FileFulnameMed_tmp );
            oBmpImage.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }

        // obtiene la imagen a tamaño origina con texto
        private void FncBldFondoFul()
        {
          

            ///////////////////////////////
            //System.Drawing.Image oBmpImage = Bitmap.FromFile(m_FileSrcFullName);
            System.Drawing.Image oBmpImageSrc = Bitmap.FromFile(m_FileSrcFullName);

            int iX = oBmpImageSrc.Width + 2;
            int iY = oBmpImageSrc.Height + m_MinYpie + 2;
           //Bitmap oBmpImageFondo = new Bitmap(iX, iY);
            Bitmap oBmpImageFondo = new Bitmap(iX, iY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            oBmpImageFondo.SetResolution(m_dpi_default, m_dpi_default);
         
            oBmpImageFondo.SetResolution(oBmpImageSrc.HorizontalResolution, oBmpImageSrc.VerticalResolution);   
            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImageFondo);
            //oG.AddMetafileComment( 
            
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic ;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            // System.Drawing.Color myOrangeColor = HexStringToColor("#006699");

            // oG.FillRectangle(System.Drawing.Brushes.DarkGray , new Rectangle(0, 0, iX, iY));
            SolidBrush miBlueBrush = new SolidBrush(m_BackColor);
            oG.FillRectangle(miBlueBrush, new Rectangle(0, 0, iX, iY));
            oG.Flush();
            SolidBrush miBlackBrush = new SolidBrush(Color.Black);
            oG.FillRectangle(miBlackBrush, new Rectangle(0, oBmpImageFondo.Height - m_MinYpie, oBmpImageFondo.Width, 1));
            oG.Flush();
            oBmpImageFondo.Save(m_FileFulnameFul_tmp);
            ////-----------------------------------------------------
            //// texto
            ////-----------------------------------------------------
            int iInterLineado = 12;
            float x = 3f;
            float y = oBmpImageFondo.Height - m_MinYpie + 3f;
            //FontFamily fontfml = new FontFamily("Arial");
            //Font oFontB = new Font(fontfml,9, FontStyle.Bold,GraphicsUnit.Pixel   );
            //Font oFontN = new Font(fontfml, 9, FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Blue);
            // abreviar texto
            string szLin1 = FncAbrevia(m_lin1, 53, true );

            string szLin2 = FncAbrevia(m_lin2, 53, true);
            string szLin3 = FncAbrevia(m_lin3, 53, true);
            string szLin4 = m_lin4Loc;
            oG.DrawString(szLin1, oFontB, Brushes.Black, x, y);
            StringFormat oFormat = new StringFormat();
            oFormat.Alignment = StringAlignment.Far;
            int iX2 = iX / 2;
            int iY2 = Convert.ToInt32(y);
            // REVISAR 18/11/2012
            //  Rectangle oRecE = new Rectangle(iX2+10 , iY2, iX2-40, 45);
            Rectangle oRecE = new Rectangle(iX2 + 10, iY2, iX2 - 35, 45);
            oG.DrawString(szLin4, oFontN, Brushes.Black, oRecE, oFormat);
            oG.DrawString(szLin2, oFontN, Brushes.Black, x, y + iInterLineado);
            oG.DrawString(szLin3, oFontN, Brushes.Black, x, y + iInterLineado * 2);
            oG.Flush();
          
            ////=======================================================
            // agregar la mosca
            //=======================================================
            //System.Drawing.Image MoscaImage = Bitmap.FromFile(m_FileMosca );
            Bitmap MoscaImage = Properties.Resources.mosca ;
            MoscaImage.SetResolution(oBmpImageSrc.HorizontalResolution, oBmpImageSrc.VerticalResolution);
            int xd   = (iX - MoscaImage.Width-2) ;
            int yd   = (iY - MoscaImage.Height -2);
            oG.DrawImage(MoscaImage, new Point(xd, oBmpImageFondo.Height - 20));
            oG.Flush();
            //=======================================================
            // agregar la imagen redimensionada
            //=======================================================
            //System.Drawing.Image MiniaturaImage = Bitmap.FromFile(m_FileSrcFullName);
            
            oG.DrawImage(oBmpImageSrc, new Point(1, 1));
            oG.Flush();

            //-----------------------------------------------------
            //-----------------------------------------------------


            //-----------------------------------------------------------------------------------------         
            // codificar para bajar la resolucion de la miniatura y peso de imagen 6/3/2011
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters;
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 110L);
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            oBmpImageFondo.Save(m_FileFulnameFul_tmp, myImageCodecInfo, myEncoderParameters);
           // ---------------------------------------------------------------------------

            //-----------------------------------------------------
            //oBmpImageFondo.Save(m_FileFulnameFul_tmp);
            oBmpImageFondo.Dispose();
            miBlueBrush.Dispose();
            miBlackBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }
        private void FncBldFondoMinImg()
        {
            FncBldImageThumnail(m_MinX, m_MinY, m_FileFulnameMinImg_tmp);
        }
         private void FncBldFondoMedImg()
        {
            FncBldImageThumnail(m_MedX, m_MedY, m_FileFulnameMedImg_tmp);
        }
        private void FncBldFondoBigImg(Int32 iMaxWidth, Int32 iMaxHeight)
        {
            FncBldImageThumnail(iMaxWidth, iMaxHeight, m_FileFulnameBigImg_tmp);
        }
        private void FncBldImageThumnail(int MinX, int MinY, string FileFulnameImgSource, string FileFulnameImgMinTarget)
        {
            m_FileSrcFullName = FileFulnameImgSource;
            FncBldImageThumnail(MinX, MinY, FileFulnameImgMinTarget);
        }
        private void FncBldImageThumnail(int MinX, int MinY, string FileFulnameMin)

        {
            string src = m_FileSrcFullName;
            string dest = FileFulnameMin;
            System.Drawing.Image image = System.Drawing.Image.FromFile(src);
            int srcWidth = image.Width;
            int srcHeight = image.Height;

            float fMinX= 0f;
            float fMinY = 0f;

            float  factXY=0.9f;
            float factX = 0.9f;
            float factY = 0.9f;
            fMinX = MinX;
            fMinY = MinY; 
            // si es apaisada o cuadrada

            factX = (fMinX / srcWidth);
            factY = (fMinY / srcHeight);
            
            if (factX <factY )
            {
                factXY = factX;
            }
            else
            {
                factXY = factY; 
            }
            //factXY = 196 / 800;
            // si la imagen ya es menor que el cuadrado donde va a ir
            if (factXY >= 1)
            {
                System.IO.File.Copy(m_FileSrcFullName, dest, true);
                return; // imagen mas pequeña que el thubmanil
            }
                

            //thumbHeight
            int iImgHeight =Convert.ToInt32(  srcHeight * factXY);
            int iImgWith = Convert.ToInt32(srcWidth * factXY);

            // //Image thumb = new Bitmap(200, 200,System.Drawing.Imaging.PixelFormat.Format24bppRgb) ;
            // todo 24 bits
            Bitmap bmp = new Bitmap(iImgWith, iImgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmp.SetResolution(m_dpi_default, m_dpi_default);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, iImgWith, iImgHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth-1, srcHeight-1, GraphicsUnit.Pixel);
          
            gr.DrawRectangle(oPenGray , 0, 0, srcWidth-1, srcHeight-1);
            gr.DrawLine(oPenGray, 0, srcHeight - m_MinYpie, srcWidth, srcHeight - m_MinYpie);   
            bmp.Save(dest,System.Drawing.Imaging.ImageFormat.Jpeg  );

            bmp.Dispose();
            image.Dispose();

        }
        // redimensiona la imagen guardando las proporciones
        // si es mas pequeña que el maximo no la agranda para no perder calidad
        private string FncAbrevia(string szTexto, int iLen, bool Mostrar3puntos)
        {
            return FncAbrevia(szTexto, iLen, Mostrar3puntos, false);
        }
        private string FncAbrevia(string szTexto, int iLen,bool Mostrar3puntos, bool bLimpiar)
        {
            szTexto = szTexto.Trim();
            while (szTexto.Contains ("  "))
            {
                szTexto=szTexto.Replace("  ", " ");
            }
            if (Mostrar3puntos)
            {
                if (szTexto.Length > iLen && szTexto.Length > 3) szTexto = szTexto.Substring(0, iLen - 3) + "...";
            }
            else
            {
                if (szTexto.Length > iLen && szTexto.Length > 3) szTexto = szTexto.Substring(0, iLen) ;
            }
            return szTexto;  
        }
        /// <summary>
        /// Calcula el valor proporcional del eje x en funcion de ratio seleccionado
        /// o no aplica ninguno si no hemos forzado un ratio
        /// </summary>
        /// <param name="oValX">Valor establecido X </param>
        /// <param name="oValY">Valor establecido Y</param>
        /// <returns></returns>
        private void FncCalcY(ref int oValX, ref int oValY)
        {

            if (!m_bForzarRatio_4x3 && !m_bForzarRatio_3x2) return;


            if (m_bForzarRatio_4x3)
            {
                oValY = oValX * 3 / 4;
            }
            else
            {
                oValY = oValX * 2 / 3;
            }



        }
        private void FncCalcX(ref int oValX, ref int oValY)
        {

            if (!m_bForzarRatio_4x3 && !m_bForzarRatio_3x2) return;


            if (m_bForzarRatio_4x3)
            {
                oValX = oValY * 4 / 3;
            }
            else
            {
                oValX = oValY * 3 / 2;
            }



        }
        private string FncLimpiaString (string szFile)
        {
        szFile=szFile.Replace (":","");
           szFile = szFile.Replace(".", "-");
           szFile = szFile.Replace(",", "-");
           szFile = szFile.Replace("@", "-");
           szFile = szFile.Replace(";", "-");
           szFile = szFile.Replace("'", "");
           szFile = szFile.Replace("(", "");
           szFile = szFile.Replace(")", "");
           szFile = szFile.Replace("^)", "");
           szFile = szFile.Replace("!)", "");
           szFile = szFile.Replace("¡)", "");
           szFile = szFile.Replace("¿)", "");
           szFile = szFile.Replace("?)", "");
           szFile = szFile.Replace("&)", "");
           szFile = szFile.Replace("$)", "");
           szFile = szFile.Replace("#)", "");
           szFile = szFile.Replace("|)", "");
           szFile = szFile.Replace("/)", "");
           szFile = szFile.Replace("\\)", "");
           szFile = szFile.Replace("+)", "");
           szFile = szFile.Replace("=)", "");
        return szFile ;
        }
        public void FncMetatag(string szCadena)
        {

          
            ////Dim strm As FileStream = New FileStream("..\Picture 003.jpg", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)
            //FileStream strm = new FileStream("c:\\img.jpg", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            ////Dim decoder As JpegBitmapDecoder = New JpegBitmapDecoder(
            //FncMetatag decoder = new JpegBitmapDecoder(strm, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);

            ////Dim m as BitmapMetadata = CType(decoder.Frames(0).Metadata, BitmapMetadata)
            //BitmapMetadata m = new BitmapMetadata (decoder.Frames(0).Metadata, BitmapMetadata);

//Dim output_jpgStream as FileStream= New FileStream("output.jpg", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite)
//Dim jpgEncoder As JpegBitmapEncoder = New JpegBitmapEncoder()
//Dim jpgMetadata as BitmapMetadata= New BitmapMetadata("jpg")
//jpgMetadata.CameraManufacturer = m.CameraManufacturer
//Dim l() As String = {"foo", "bar"}
//Dim col As System.Collections.ObjectModel.ReadOnlyCollection(of String) = New System.Collections.ObjectModel.ReadOnlyCollection(Of String)(New List(Of String)(l))
//jpgMetadata.Keywords = col
//jpgMetadata.Comment = "this is my comment!!!!!"
//jpgEncoder.Frames.Add(BitmapFrame.Create(decoder.Frames(0), Nothing, jpgMetadata, Nothing))
//jpgEncoder.Save(output_jpgStream)
//output_jpgStream.Flush()
//output_jpgStream.Close()
//strm.Close()
        
        
        
        }

        //=========================================================
        //=============== avatars =================================
        //=========================================================
          
     /// <summary>
     ///  Si es correcto devuelve el nombre del thumbnail creado
     ///  si no devuelve vacio.
     ///  Si el fichero a crear existe, no lo sustituye, sino que crea uno con un numerador de tres digitos;
     /// </summary>
     /// <param name="szPathFullImgSource"></param>
     /// <param name="szPathFullImgTarget"></param>
     /// <param name="iWith"></param>
     /// <param name="iHeight"></param>
     /// <returns></returns>
        public string FncBldAvatar(string szPathFullImgSource, string szPathFullImgTarget, int iWith, int iHeight)
        {
            string szAvatarName="";
            szPathFullImgTarget=szPathFullImgTarget.Replace ('/','\\');
            szPathFullImgTarget = szPathFullImgTarget.Replace("\\\\", "\\");
           
            m_error = "";
            //1.- Crear nombres de ficheros temporales de trabajo.
            string szGuid = Guid.NewGuid().ToString() ;
            string szDirTemp= System.IO.Path.GetTempPath();
            if (!szDirTemp.EndsWith("\\") ){szDirTemp=szDirTemp+"\\";}
            if (!System.IO.Directory.Exists(szDirTemp)) System.IO.Directory.CreateDirectory(szDirTemp);
            string szFileTempPrefij=szDirTemp+szGuid; 
            string szImgSrcTmp = szFileTempPrefij + "_tmpsrc.jpg";
            string szImgBackTmp = szFileTempPrefij+ "_tmpbak.jpg";
            string szImgAvtTmp = szFileTempPrefij + "_tmpavt.jpg";
            
            //2.- Obtener una copia del origen para su manipulacion.
            System.IO.File.Copy(szPathFullImgSource, szImgSrcTmp,true );
            
            //3.- Reducir la imagen orignal al tamaño deseado conservando la proporcion
            //    en un avatar temporal
            FncBldImageThumnail(iWith, iHeight,szPathFullImgSource,szImgAvtTmp);
            //4.- Crear una imagen de fodo vacia con el tamaño solicitado
            //    y añadir sobre ella el thumbnail centrado
            FncBldFondoAvt(iWith, iHeight,szImgAvtTmp, szImgBackTmp);
            //5.- 

             szAvatarName = FncFileCopyUnique(szImgBackTmp, szPathFullImgTarget);
            
            
            
            try
            {
                System.IO.File.Delete(szImgSrcTmp);
                System.IO.File.Delete(szImgBackTmp);
                System.IO.File.Delete(szImgAvtTmp);
            }
            catch { ;}
            //7.- Borrar ficheros temporales
            return szAvatarName;
        }
        /// <summary>
        /// genera una una imagen del tamaño especificado, con fondo de un solo color
        /// que se utiliza de fondo para que los avatares tengan el mismo tamaño
        /// Una posible mejora serian thumnails en formato gif con fondo transparente
        /// </summary>
        /// <param name="iWith"></param>
        /// <param name="iHeigh"></param>
        /// <param name="szFileTarget"></param>
        private void FncBldFondoAvt(Int32 iWith, Int32 iHeigh,string szThumnailFile, string szFileTarget)
        {



            int iX = iWith + 2;
            int iY = iHeigh + 2;
            //Bitmap oBmpImage = new Bitmap(iX, iY);
            Bitmap oBmpImage = new Bitmap(iX, iY, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            System.Drawing.Image oImgThb = Bitmap.FromFile(szThumnailFile);
           
            //Igualar resoluciones dpi
            oBmpImage.SetResolution(oImgThb.HorizontalResolution , oImgThb.VerticalResolution );

            // crear rectangulo general
            Graphics oG = Graphics.FromImage(oBmpImage);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Color m_ColorWhite = Color.White  ;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_ColorWhite);
            //oG.FillRectangle(System.Drawing.Brushes.DarkGray , new Rectangle(0, 0, iX, iY));
            oG.FillRectangle(System.Drawing.Brushes.White , new Rectangle(0, 0, iX, iY));
            oG.Flush();
            // agregar la imagen al cuadrado
           
            // calcular tamaño del thumbnail, para calcular posicion centrada
            int xThb= oImgThb.Width;
            int yThb = oImgThb.Height ;
         
            int xd = (iX - oImgThb.Width)/2;
            int  yd = (iY - oImgThb.Height)/ 2;
            oG.DrawImage(oImgThb, new Point(xd, yd));

            oG.Flush();
            oG.DrawRectangle(myPen, 0, 0, iWith, iHeigh);
            oG.Flush();
          
            // guardar imagen

            oBmpImage.Save(szFileTarget);
            oBmpImage.Dispose();
            myPen.Dispose();
            oG.Dispose();

        }
        //=========================================================
        //=========================================================
        /*
        /*/
        public static string FncFileGetExtensionType(string szFilePath)
        {
            string szExtension = "";
            string szChar = "";
            bool bFindDot = false;
            for (int n = szFilePath.Length - 1; n > 0; n--)
            {
                szChar = szFilePath.Substring(n, 1);
                if (szChar == ".")
                {
                    bFindDot = true;
                    n = -1; // fuerza salida del bucle
                }
                szExtension = szChar + szExtension;

            }
            if (!bFindDot) szExtension = "";
            return szExtension.ToLower();
        }
        public static string FncFileNameUnique(string szFileFulPath)
        {
            string szFileNameUnique = "";
            string szFileType = FncFileGetExtensionType(szFileFulPath);
            string szFilePathNoType = "";
            //szFileFulPath = FncFileNameNormalice(szFileFulPath);

            string szI = "";
            string szFile = "";
            try
            {
                szFilePathNoType = szFileFulPath.Substring(0, szFileFulPath.Length - szFileType.Length);
                for (int i = 0; i < 9999; i++)
                {

                    szI = "_" + i.ToString().PadLeft(4, '0');
                    szFile = szFilePathNoType + szI + szFileType; ;
                    if (!System.IO.File.Exists(szFile))
                    {
                        szFileNameUnique = szFile;
                        i = 10000;

                    }

                }
            }
            catch { ;}
            return szFileNameUnique;

        }
        public static string FncFileCopyUnique(string szFileFullPathSrc, string szFileFulPathTarget)
        {
            string szError = "";
            string szFileName = "";
            try
            {
                szFileFulPathTarget = FncFileNameUnique(szFileFulPathTarget);
                System.IO.File.Copy(szFileFullPathSrc, szFileFulPathTarget, true);
                System.IO.FileInfo oInfo = new System.IO.FileInfo(szFileFulPathTarget);
                szFileName = oInfo.Name;
            }
            catch (Exception xcpt)
            { szError = xcpt.Message; ; }
            return szFileName;
        }
        public static string FncFileNameNormalice(string inputString)
        {
            inputString = inputString.Trim().ToLower();
            // remove doubles spaces
            while(inputString.Contains ("  "))
            {
                inputString = inputString.Replace("  ", " ");
            }
            inputString = inputString.Replace(".", "_");
            inputString = inputString.Replace(" ", "_");
            inputString = inputString.Replace("-", "_");
            inputString = inputString.Replace("|)", "");

            //inputString = szFile.Replace(":", "");
            //inputString = szFile.Replace(".", "-");
            //inputString = szFile.Replace(",", "-");
            //inputString = szFile.Replace("@", "");
            //inputString = szFile.Replace(";", "-");

            //szFile = szFile.Replace("'", "");
            //szFile = szFile.Replace("(", "");
            //szFile = szFile.Replace(")", "");
            //szFile = szFile.Replace("^)", "");
            //szFile = szFile.Replace("!)", "");
            //szFile = szFile.Replace("¡)", "");
            //szFile = szFile.Replace("¿)", "");
            //szFile = szFile.Replace("?)", "");
            //szFile = szFile.Replace("&)", "");
            //szFile = szFile.Replace("$)", "");
            //szFile = szFile.Replace("#)", "");
          
           // szFile = szFile.Replace(@"/", "");
            //szFile = szFile.Replace("\\)", "");
           // szFile = szFile.Replace("+)", "");
           // szFile = szFile.Replace("=)", "");



            Regex replace_a_Accents = new Regex("[á|à|ä|â|ä]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|ë]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î|ï]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô|ö]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|ü]", RegexOptions.Compiled);
            Regex replace_signs = new Regex("['|,|:|?|¿|$|+|&|!|¡|=|@|#|\\|^|´|¨|/|(|)|;]", RegexOptions.Compiled);      

            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
                
            inputString = inputString.Replace ("ñ", "n");
            inputString = replace_signs.Replace(inputString, "");

            inputString = RemoveAccentsWithNormalization(inputString);
            while (inputString.Contains("__"))
            {
                inputString = inputString.Replace("__", "_");
            }
            return inputString;
        }
        public static string RemoveAccentsWithNormalization(string inputString)
        {
            string normalizedString = inputString.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(normalizedString[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
        /// <summary>
        /// Modifica los pies de imagen de minx, min, med, big y ful
        /// </summary>
        /// <param name="szFileSrcFull">Fichero acabado minx.jpg</param>
        /// <param name="scnTxtTitulo"></param>
        /// <param name="scnTxtFichero"></param>
        /// <param name="scnTxtOrigen"></param>
        /// <param name="scnTxtLocation"></param>
        /// <returns></returns>
        public bool FncImagesChangeFoot(String szFileSrcFull,String pTitle, String pAuthor, String pSource, String pLocation, bool bDeletePreviousBak)
        {
            bool bOk = true;
            szFileSrcFull=szFileSrcFull.ToLower();
            if (!szFileSrcFull.EndsWith("minx.jpg")) return false;
            System.IO.FileInfo oFInfo = new System.IO.FileInfo(szFileSrcFull);

            string szDirBack=oFInfo.Directory+"\\back";
            string szDirTarg=oFInfo.Directory+"\\Targ";
           
            string szFileName=oFInfo.Name.ToLower(); 
           
            // Preparar directorio para ficheros destino
            if (System.IO.Directory.Exists(szDirBack))
            {
                if (bDeletePreviousBak)
                {
                    foreach (string oFile in System.IO.Directory.GetFiles(szDirBack))
                    {
                        try { System.IO.File.Delete(oFile); }
                        catch { ;}
                        ;
                    }
                }
            }
            else
            {
                if (!System.IO.Directory.Exists(szDirBack)) { System.IO.Directory.CreateDirectory(szDirBack); }

            }

            if (System.IO.Directory.Exists(szDirTarg))
            {
                if (bDeletePreviousBak)
                {
                    foreach (string oFile in System.IO.Directory.GetFiles(szDirTarg))
                    {
                        try
                        {
                            System.IO.File.Delete(oFile);
                        }
                        catch { ;}
                    }
                }
            }
            else
            {
            if (!System.IO.Directory.Exists(szDirTarg)) {System.IO.Directory.CreateDirectory(szDirTarg);}

            }
            
           
            // Chequear fichero valido

            if (".jpg"!=FncFileGetExtensionType(szFileSrcFull)) {return false;}
            if (!szFileSrcFull.EndsWith(m_ImgMinX.ToLower())) return false;
            
            // Nombres de los ficheros origen
            string szSrcMinX=szFileSrcFull;
            
            string szSrcMin = szFileSrcFull.Replace(m_ImgMinX, m_ImgMin);
            string szSrcMed = szFileSrcFull.Replace(m_ImgMinX, m_ImgMed);
            string szSrcBig = szFileSrcFull.Replace(m_ImgMinX, m_ImgBig);
            string szSrcFul = szFileSrcFull.Replace(m_ImgMinX, m_ImgFul);

            string szBakMinx=szDirBack+"\\"+szFileName;
            string szBakMin = szBakMinx.Replace(m_ImgMinX, m_ImgMin);
            string szBakMed = szBakMinx.Replace(m_ImgMinX, m_ImgMed);
            string szBakBig = szBakMinx.Replace(m_ImgMinX, m_ImgBig);
            string szBakFul = szBakMinx.Replace(m_ImgMinX, m_ImgFul);

            string szTarMinx=szDirTarg+"\\"+szFileName;
            string szTarMin = szTarMinx.Replace(m_ImgMinX, m_ImgMin);
            string szTarMed = szTarMinx.Replace(m_ImgMinX, m_ImgMed);
            string szTarBig  = szTarMinx.Replace(m_ImgMinX,m_ImgBig);
            string szTarFul  = szTarMinx.Replace(m_ImgMinX,m_ImgFul);

            
            // copiar los ficheros a directorio temporal para manipularlos
            if (System.IO.File.Exists(szSrcMinX))
            { 
                
                File.Copy(szSrcMinX, szBakMinx);
                FncImageRenameFootDo(szSrcMinX, szTarMinx, pTitle, pAuthor, pSource, pLocation);
            }
            if (System.IO.File.Exists(szSrcMin)) 
            {
                File.Copy(szSrcMin, szBakMin);
                FncImageRenameFootDo(szBakMin, szTarMin, pTitle, pAuthor, pSource, pLocation);
               
            }
            if (System.IO.File.Exists(szSrcMed)) 
            {
                File.Copy(szSrcMed, szBakMed);
                FncImageRenameFootDo(szBakMed, szTarMed, pTitle, pAuthor, pSource, pLocation);
            }
            if (System.IO.File.Exists(szSrcBig)) 
            {
                File.Copy(szSrcBig, szBakBig);
                FncImageRenameFootDo(szBakBig, szTarBig, pTitle, pAuthor, pSource, pLocation);
            }
            if (System.IO.File.Exists(szSrcFul)) 
            {
                File.Copy(szSrcFul, szBakFul);
                FncImageRenameFootDo(szBakFul, szTarFul, pTitle, pAuthor, pSource, pLocation);
               
            }
            
           
            // Abreviar titulos
           
            
            // modificar la miatura


            return bOk;
        }

        private bool FncImageRenameFootDo(string pImgPathBack, string pImgPathTarg, string plin1, string plin2, string plin3, string pLin4)
        {
            bool bMin = false;
            string szLin1 = plin1;
            string szLin2 = plin2;
            string szLin3 = plin3;
            string szLin4 = pLin4;
            
            if (pImgPathBack.EndsWith("minX.jpg")) { bMin=true;}
            if (pImgPathBack.EndsWith("min.jpg")) {bMin=true;}
            if (bMin)
            {
                szLin1 = FncAbrevia(plin1, 30, true);
                szLin2 = FncAbrevia(plin2, 30, true);
                szLin3 = FncAbrevia(plin3, 30, true);
                 szLin4 = "";

            }
            if (pImgPathBack.EndsWith("med.jpg"))
            {
                szLin1 = FncAbrevia(plin1, 80, true);
                szLin2 = FncAbrevia(plin2, 80, true);
                szLin3 = FncAbrevia(plin3, 80, true);
                szLin4 = "";

            }
            bool bOk=true;
            System.Drawing.Image oBmpImageSrc = Bitmap.FromFile(pImgPathBack);

            int iXSrcFul= oBmpImageSrc.Width ;
            int iYSrcFul = oBmpImageSrc.Height;
            int iYSrcFulSinPie = iYSrcFul - (m_MinYpie + 2);
                                
            Graphics oG = Graphics.FromImage(oBmpImageSrc);
            oG.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            oG.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            oG.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            System.Drawing.Pen myPen = new System.Drawing.Pen(m_BackColor);

            
            
            //-----------------------------------------------------
            // texto
            //-----------------------------------------------------
            SolidBrush miWhiteBrush = new SolidBrush(Color.White);
            SolidBrush miBackBrush = new SolidBrush(m_BackColor);
            float iTextX = 3f;
            float iTextY = iYSrcFulSinPie + 1f;
            int iTextInterLineado = 12;

            int iRecXIni = 0;
            int iRecYIni = iYSrcFulSinPie+3;

            int iRecXFin = iXSrcFul - 32;
            int iRecYFin = iTextInterLineado+1;
           
            if (szLin1.Length > 1)
            {
                //borrar primera linea
               
             iRecYIni = iYSrcFulSinPie+3;
             iTextY = iRecYIni + 1;
             oG.FillRectangle(miBackBrush, new Rectangle(iRecXIni, iRecYIni, iRecXFin, iRecYFin));
                oG.Flush();
                oG.DrawString(szLin1, oFontB, Brushes.Black, iTextX, iTextY);
                oG.Flush();
            }
            if (szLin2.Length > 1)
            {
                //borrar primera linea
                iRecYIni = iRecYIni + iTextInterLineado;
                iTextY = iRecYIni + 1;
                oG.FillRectangle(miBackBrush, new Rectangle(iRecXIni, iRecYIni, iRecXFin, iRecYFin));
                oG.Flush();
                oG.DrawString(szLin2, oFontB, Brushes.Black, iTextX, iTextY);
                oG.Flush();
            }
            if (szLin3.Length > 1)
            {
                //borrar primera linea
                iRecYIni = iRecYIni + iTextInterLineado;
                iTextY = iRecYIni + 1;
                oG.FillRectangle(miBackBrush, new Rectangle(iRecXIni, iRecYIni, iRecXFin, iRecYFin));
                oG.Flush();
                oG.DrawString(szLin3, oFontB, Brushes.Black, iTextX, iTextY);
                oG.Flush();
            }
            


            if (szLin4.Length > 1 && bMin==false)
            {
               

                StringFormat oFormat = new StringFormat();
                oFormat.Alignment = StringAlignment.Far;
                int iX2 = iXSrcFul / 2;
                int iY2 = iRecYIni = iYSrcFulSinPie + 1;

                oG.FillRectangle(miBackBrush, new Rectangle(iX2, iY2, iX2 - 35, m_MinYpie - 2));
                oG.Flush();
              

                // REVISAR 18/11/2012
                //  Rectangle oRecE = new Rectangle(iX2+10 , iY2, iX2-40, 45);
                Rectangle oRecE = new Rectangle(iX2, iY2, iX2 - 35, m_MinYpie - 2);
                oG.DrawString(szLin4, oFontN, Brushes.Black, oRecE, oFormat);
                oG.Flush();
            //     iRecYIni = iYSrcFulSinPie + 4 * iTextInterLineado;
            //    //borrar primera linea
            //     iTextX= 3f;
            //     iTextY = iRecYIni + 3;
            //    oG.FillRectangle(miBlueBrush, new Rectangle(iRecXIni,iRecYIni ,  iRecXFin, iRecYFin));
            //    oG.Flush();
               
            //    oG.DrawString(szLin4, oFontB, Brushes.Black, iTextX, iTextY);
            //    oG.Flush();
            }
 
            //-----------------------------------------------------
            //-----------------------------------------------------
            //-----------------------------------------------------
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder;
            System.Drawing.Imaging.EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.EncoderParameters myEncoderParameters;
            myEncoder = System.Drawing.Imaging.Encoder.Quality;
            myEncoderParameter = new System.Drawing.Imaging.EncoderParameter(myEncoder, 110L);
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;
            oBmpImageSrc.Save(pImgPathTarg, myImageCodecInfo, myEncoderParameters);
            //------------------------------------------------------------------
            //oBmpImage.Save(m_FileFulnameMed_tmp );
            oBmpImageSrc.Dispose();
            miWhiteBrush.Dispose();
            myPen.Dispose();
            oG.Dispose();
            return bOk;

    }
        //=========================================================        
        //=========================================================
        //============ GETS SETS                 ==================
        //=========================================================
        //=========================================================
        
        #region getset

        public bool BldMiniaturaLupa
        {
            get { return m_BldMinaturaLupa; }
            set { m_BldMinaturaLupa = value; }
        }
       public  bool BldMiniatura
        {
            get { return m_BldMiniatura; }
            set { m_BldMiniatura = value; }
        }
       public bool BldMedia
        {
            get { return m_BldMedia; }
            set { m_BldMedia = value; }
        }
       public bool BldFull
        {
            get { return m_BldFull; }
            set { m_BldFull = value; }
        }
       public bool BldBig
       {
           get { return m_BldBig; }
           set { m_BldBig = value; }
       }
        public string error
        {
        get {return m_error;}
    }
        public string FileSrcFullName
        {
            get { return m_FileSrcFullName; }
        }
        public string FileFulnameMinX
        {

            get { return m_FileFulnameMinX; }
        }
        public string FileFulnameMin
        { 
        
            get {return m_FileFulnameMin;}
        }
        public string FileFulnameMed
        {

            get { return m_FileFulnameMed; }
        }
        public string FileFulnameFul
        {

            get { return m_FileFulnameFul; }
        }

        public string PathTarget
        {
            get { return m_PathTarget; }
            set { m_PathTarget = value.Trim().ToLower(); }
        }
        public Color oColor
        {
            get { return m_BackColor; }
            set { m_BackColor = value; }
        }
        /// <summary>
        /// Tamaño de la miniatura eje x
        /// </summary>
        public int MinX
        {
            get { return m_MinX; }
            set
            {
                m_MinX = value;
                FncCalcY(ref m_MinX, ref m_MinY);
            }
        }
        /// <summary>
        /// Tamaño de la eje miniatura Y
        /// </summary>
        public int MinY
        {
            get { return m_MinY; }
            set
            {
                m_MinY = value;
                FncCalcY(ref m_MinX, ref m_MinY);
            }
        }
        /// <summary>
        /// tamaño de imagen medio tamaño x
        /// </summary>
        public int MedX
        {
            get { return m_MedX; }
            set
            {
                m_MedX = value;
                FncCalcY(ref m_MedX, ref m_MedY);
            }
        }
        /// <summary>
        /// tamaño de imagen medio tamaño x
        /// </summary>
        public int MedY
        {
            get { return m_MedY; }
            set
            {
                m_MedY = value;
                FncCalcY(ref m_MedX, ref m_MedY);
            }
        }


        // forzar ratio tamaño fotografia digital
        // si true: cuando fijemos x calcura y si fijamos y calculara x
        // y cambia ForzarRatio_3x2 a false;
        public bool ForzarRatio43
        {
            set
            {
                m_bForzarRatio_4x3 = value;
                if (m_bForzarRatio_4x3) ForzarRatio_3x2 = false;
            }
            get { return m_bForzarRatio_4x3; }
        }
        // forzar ratio tamaño fotografia de carrete de 35mm
        // si true: cuando fijemos x calcura y si fijamos y calculara x
        // y cambia m_bForzarRatio_4x3 a false;
        public bool ForzarRatio_3x2
        {
            set
            {
                m_bForzarRatio_3x2 = value;

                if (m_bForzarRatio_3x2) m_bForzarRatio_3x2 = false;
            }
            get { return m_bForzarRatio_3x2; }
        }

        #endregion getset

    }
}
