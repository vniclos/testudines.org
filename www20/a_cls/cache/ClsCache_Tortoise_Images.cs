
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
namespace testudines.cls.cache
{
    public class ClsCache_Tortoise_Images
    {
        public ClsCache_Tortoise_Images()
        {

        }

        private cls.bbdd.ClsReg_tdoclng_testudines_othe_all oReg_OtheALL = new cls.bbdd.ClsReg_tdoclng_testudines_othe_all();

        private cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oReg_TaxaALL = new cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();

        private const string m_Section = "images";

        private UInt64 m_IdDoc = 0;
        private string m_IdDocLng = "";

        private Int32 m_pages_count = 0;
        private Int32 m_pages_IndexInit = 0;
        private Int32 m_pages_IndexEnd = 0;
        private Int32 m_img_bypage = 9;

        private Int32 m_imgs_count = 0;
        private string m_imgs_url = "";
        private string m_imgs_path = "";
        private string[] m_ArrayImgs;
        private string m_html = "";

        private string m_FileCachetemplate_SortName = "";
        private string m_DirCacheTemplate = "";
        private string m_UrlCacheTemplate = "";
        private string m_DirImages = "";
        private string m_URLImages = "";
        private string m_File_Err_Page = "";
        private bool m_bUrlExist=false;
        /// <summary>
        /// Default is 9
        /// </summary>
        public Int32 img_byPage
        {
            set { m_img_bypage = value; }
            get { return m_img_bypage; }
        }
        /// <summary>
        /// Devueve el cache de la pagina pedida
        /// si no existe lo crea.
        /// por defecto 9 imagenes por pargina, si se quiere cambiar
        /// estableer img_byPage al numero deseado y luego
        /// llamar a esa funcion para que reconstruya el cache 
        /// (pbrebuild=true;
        /// </summary>
        /// <param name="pIdDoc"></param>
        /// <param name="pIdDocLng"></param>
        /// <param name="pPageNumber"></param>
        /// <param name="pbRebuild"></param>
        /// <returns></returns>
        public String FncCacheGet(UInt64 pIdDoc, String pIdDocLng, Int32 pPageNumber, bool pbRebuild)
        {
            // iniciar y guardar variables
            m_IdDoc = pIdDoc;
            m_IdDocLng = pIdDocLng;
            
            m_html = "";
            m_FileCachetemplate_SortName = pIdDocLng.ToLower() + "_" + pIdDoc.ToString().PadLeft(9, '0') + "_images_";
            m_DirCacheTemplate = cls.ClsGlobal.DirCacheTortoises + m_FileCachetemplate_SortName;
            m_UrlCacheTemplate = cls.ClsGlobal.UrlCacheTortoises + m_FileCachetemplate_SortName;
            
            String szFilePath = m_DirCacheTemplate + pPageNumber.ToString().PadLeft(3, '0') + ".html";

            m_File_Err_Page = szFilePath;
            // si se indica reconstruir cache, borrar si existe;
            if (pbRebuild) { cls.cache.ClsCache.FncCacheFileDelete(szFilePath); };

            // si no existe crearlo
            if (!cls.cache.ClsCache.FncCacheFilePathExist(szFilePath))
            {
                FncBldCacheImages();
            }

            try
            {
                 System.IO.StreamReader file = new System.IO.StreamReader(szFilePath);
                m_html = file.ReadToEnd();
                file.Close();
            }
            catch
            {
                m_html = FncMsgError()+"<br"+Resources.Strings.CantRead + " "+szFilePath;
            }
            


            return m_html;

        }
        private String FncMsgError()
        {
            string szMsgError = "";

            szMsgError = "\n<div class=\"pannel\"><h2>Specie: " + oReg_TaxaALL.ATaxGrpL0001lNameFullRecomeded + "</h2>";
            m_html += "<p>" + Resources.Strings.Opps_Images + "</p>\n</div>";

            szMsgError += "\n<div><a data-fancybox data-type=\"iframe\" data-src=\"/a_dlg/dlgmsgdocid.aspx?'imgurl=" + oReg_TaxaALL.ATaxGrpL0001lNameFullRecomeded + "&imgdocid=" + m_IdDoc.ToString().Trim() + "&imgname=&imgsec=titulo\" href=\"javascript:;\"><img class=\"icoMsgfoot\"src=\"/Content/img/mail.png\" title=\"Send msg about this specie e\"/>&nbspId.: " + Resources.Strings.contact + "</a></div>";
            szMsgError += "<br/>Images Gallery Id=" + m_IdDoc.ToString();
            szMsgError += "<br/>Images=" + m_URLImages;
            return szMsgError;

        }
       
        private bool FncBldCacheImages()
        {
            // si no existe la especie
            //  o no hay imagenes devolver false 
            //  y cancelar
            if (!FncImagesExist())
            {
                


                return false;
            }
            else
            {
                FncBldCacheImagesPages();
            }

            return true;
        }

        private bool FncImagesExist()
        {
            // si no existe la especie en bbdd cancelar
            if (!oReg_OtheALL.FncSqlFind(m_IdDoc))


            {
                m_html = "<h2>Error 2</h2>Oops, no  images <br/> : By not find in bbdd return false ";
                FncBldCacheImagesPageEmpty(m_html);
                return false;
              

            }
            m_URLImages = oReg_OtheALL.AOth_UrlImages.Trim().ToLower();
            m_DirImages =cls.ClsUtils.FncPathCombine  (cls.ClsGlobal.DirRoot ,m_URLImages);
            //
            // si no existen imagenes en el directorio de la especie cancelar
            if (!System.IO.Directory.Exists(m_DirImages))
            {
                m_html = "<h2>Error 3</h2>Oops,Opps, Not found images for this specie<br/>" + m_imgs_url;
                m_bUrlExist = false;
                FncBldCacheImagesPageEmpty(m_html);
                return false;
           
            }
            m_bUrlExist = true;
            m_ArrayImgs = null;
            m_ArrayImgs = System.IO.Directory.GetFiles(m_DirImages, "*_minx.jpg");
            m_imgs_count = Convert.ToInt32(m_ArrayImgs.Length);
            if (m_imgs_count < 1)
            {
                m_html = "<h2>Error 4</h2>Oops, No exist images on <br/>" + m_imgs_url;
                m_bUrlExist = false;
                FncBldCacheImagesPageEmpty(m_html);
                return false;
            }
            // calcular el numero de imagenes y de paginas a  mostrar

            Int32 iResto = m_imgs_count % m_img_bypage;
            Int32 iAddOne = 0;
            if (iResto > 0) iAddOne = 1;

            m_pages_count = ((m_imgs_count- iResto) / m_img_bypage) + iAddOne;
            m_pages_IndexInit = 1;
            m_pages_IndexEnd = m_pages_count;



            return true;

        }
        private void FncBldCacheImagesPageEmpty(String msg)
        {
              string szHtml = "";
            String szFileNameFull = "";
            string szHtmlPager = "<div class=\"row\">" + msg + "</div>";
            string szHtmlImg = "<div>"; ;
            szHtmlImg += "Please, if you have images, you can help to build this project<br/>";
            szHtmlImg += "Contact:<a href=\"https://www.facebook.com/groups/testudines.org\">Testudines.org on facebook</a>";
            szHtmlImg += "<img src=\"/a_img/noimage600px.png\" title=\" we need tortoise images of this specie\"/>";
            szHtmlImg += "Gallery:" + m_imgs_url + "</div/>";

            String szHtmlHead = FncBldGallHead();
            Int32 iPage = 1;
            szFileNameFull = m_DirCacheTemplate + iPage.ToString().PadLeft(3, '0') + ".html";
            szHtmlImg = "<img src=\"/a_img/noimage600px.png\">";
            szHtml = szHtmlHead + szHtmlPager + szHtmlImg + szHtmlPager;
            cls.cache.ClsCache.FncCacheFileSave(ref szFileNameFull, ref szHtml);
        }
      
        private void FncBldCacheImagesPages()
        {
            string szHtmlPager = "";
            string szHtmlImg = "";
            string szHtml = "";
            String szFileNameFull = "";
            String szHtmlHead = FncBldGallHead();
            Int32 Limit = m_pages_count;
            for (Int32 iPage = 1; iPage <= Limit; iPage++)
            {
                szFileNameFull = m_DirCacheTemplate + iPage.ToString().PadLeft(3, '0') + ".html";
                szHtmlPager = FncBldHtmlPager(iPage);
                szHtmlImg = FncBldHtmlGall(iPage, "titulo");
                szHtml = szHtmlHead + szHtmlPager + szHtmlImg + szHtmlPager;
                cls.cache.ClsCache.FncCacheFileSave(ref szFileNameFull, ref szHtml);
            }


        }

        private string FncBldGallHead()
        {
            string szHtml = "";

            szHtml = "<div class=\"pannel\">";
            szHtml += "<h1>" + Resources.Strings.images + " " + oReg_TaxaALL.ATaxGrpL2270Genus + " " + oReg_TaxaALL.ATaxGrpL2280Specie + "<span class=\"font-min\", [Id=" +m_IdDoc.ToString() +"]</span></h1>";
            szHtml += oReg_TaxaALL.ATaxNameVulgarEN + "; " + oReg_TaxaALL.ATaxNameVulgarES;
            szHtml += cls.ClsHtml.FncHtmFlagLanguages(m_IdDoc, "/tortoises/");
            szHtml += "</div>";
            return szHtml;
        }


        private string FncBldHtmlGall(Int32 pCurrentPage, string sztitleGallery)
        {
            string szHtml = "";
            cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
            Int32 iImgInit = 0;
            Int32 iImgEnd = 0;
            iImgInit = (pCurrentPage-1) * m_img_bypage;
            iImgEnd = iImgInit + m_img_bypage;
            if (iImgEnd > m_imgs_count) iImgEnd = m_imgs_count ;
            string szTarget = "";
            string szThumbnail = "";
            string szTitleTop = "";
            string szTitleBot = "";
            Int32 iL = m_ArrayImgs.Length;
            oPP.FncGallery_New("images id", "images title");
           
            for (Int32 i = iImgInit; i < iImgEnd; i++)
            {
                szTarget = "";
                szThumbnail = (m_ArrayImgs[i]).ToLower().Trim().Replace("\\", "/").Replace("//", "/");
                szThumbnail = szThumbnail.Replace(cls.ClsGlobal.DirRoot.ToLower().Replace("\\", "/"), "");
                if (!szThumbnail.StartsWith("/")) { szThumbnail = "/" + szThumbnail; }


                //szTarget = szThumbnail.Replace("_minx.jpg", "_big.jpg");
                szTarget = FncGetUrlTarget(szThumbnail);
                oPP.FncGallery_AddPictureFB(szTarget, szThumbnail, szTitleTop, szTitleBot, sztitleGallery);

            }
           
            szHtml = oPP.HtmGalleryFB;
            return szHtml;

        }
        // esto evita imagenes antiguas que no tenian tamaño big
        private String FncGetUrlTarget(string pUrlThumbNail)
        {
           
            string szFileTumbNail = (cls.ClsGlobal.DirRoot+ pUrlThumbNail).Replace("/", "\\");
            string szFileBig = szFileTumbNail.Replace("_minx.jpg", "_big.jpg");
            if (System.IO.File.Exists(szFileBig))  {return pUrlThumbNail.Replace("_minx.jpg", "_big.jpg"); }

            string szFileMed = szFileTumbNail.Replace("_minx.jpg", "_med.jpg");
            if (System.IO.File.Exists(szFileMed))  { return pUrlThumbNail.Replace("_minx.jpg", "_med.jpg"); }

            string szFileFul = szFileTumbNail.Replace("_minx.jpg", "_ful.jpg");
            if (System.IO.File.Exists(szFileMed))  { return pUrlThumbNail.Replace("_minx.jpg", "_ful.jpg"); }
            return "/a_img/noimg/noimage-camera.svg";

        }
        //=====================================00

        private string FncBldHtmlPager(Int32 pCurrentPage)
        {
            string szHtml = "";
            Int32 iStartPage = 0;
            Int32 iEndPage = 0;

            if (m_pages_IndexEnd > 0) { iStartPage = pCurrentPage - 5; }
            if (iStartPage < 1) iStartPage = 1;

            iEndPage = iStartPage + 10;
            if (iEndPage > m_pages_IndexEnd)
            {
                iEndPage = m_pages_IndexEnd;
                iStartPage = m_pages_IndexEnd - 10;
                if (iStartPage < 0) iStartPage = 0;
            }
            Int32 iPageBefo = iStartPage - 1;
            if (iPageBefo < 1) iPageBefo = -1;
            Int32 iPagerNext = iEndPage + 1;
            if (iPagerNext > m_pages_IndexEnd) iPagerNext = -1;


            //.................................
            szHtml = "\n<div class=\"pagination\">";
            // Hay que poner el enlace al grupo anterior
            string szP = "";
            //tax_id_en_215_images.txt
            //  string szCacheFile = "";
            string szUrlGalleryPage = "/" + cls.ClsGlobal.LngIdThread + "/tortoises/images/" + oReg_TaxaALL.ATaxGrpL2270Genus + "-" + oReg_TaxaALL.ATaxGrpL2280Specie+"/";
            //string szUrlGalleryPagePattern = "tax_id_" + m_IdDocLng + m_IdDoc.ToString() + "_images/";
            // poner link a before
            if (iPageBefo != -1)
            {
                szHtml += "\n<a href=\"" + szUrlGalleryPage   + iPageBefo + "\">" + "&laquo;" + " </a>";

            }
            if (iStartPage == 0) iStartPage = 1;
            for (int p = iStartPage; p < iEndPage + 1; p++)
            {

                szP = p.ToString();
                if (p != pCurrentPage)
                {
                    szHtml += "\n<a href=\"" + szUrlGalleryPage  + p.ToString() + "\">" + szP + "</a>";
                }
                else
                {
                    szHtml += "\n<span class=\"current\">" + szP + "</span>";

                }

            }
            // Hay que poner el enlace al grupo siguiente
            if (iPagerNext != -1)
            {
                szHtml += "\n<a href=\"" + szUrlGalleryPage  + iPagerNext.ToString() + "\">" + "&raquo;" + " </a>";

            }


            szHtml += "\n</div>";
            return szHtml;

        }

        public bool Images_PathExist()
        {
        
          
            return m_bUrlExist;
            
        }
        public Int32 Images_count_minx()
        {
       

            return m_imgs_count;
          

        }
        public String UrlGallery
        {
            get { return m_URLImages; }
        }
    }
}
