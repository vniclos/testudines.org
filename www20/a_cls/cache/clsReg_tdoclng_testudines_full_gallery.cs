using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
// TODO COMPROBAR NO SE USA
// TODO  revisar esta utilidad  y la carpeta en que se encuentra
// creo que debe in en cache
namespace testudines.cls.cache
{
    public class ClsCache_Tortoise_GalleryFull
    {
        public ClsCache_Tortoise_GalleryFull()
        {

        }
        private cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
        private cls.bbdd.ClsReg_tdoclng_testudines_othe_all oReg_OtheAll = new cls.bbdd.ClsReg_tdoclng_testudines_othe_all();
        private cls.cache.ClsCache_Reg_tdoclng_testudines oRegCache = new cls.cache.ClsCache_Reg_tdoclng_testudines();
        private const string c_Section="images";
        private string tax_id_en_215_images_p1;
        private UInt64 m_IdDoc = 0;
        private string m_IdDocLng = "";
            private string szSection="";
        private int    m_pages_count = 0;
        private int m_pages_IndexInit = 0;
        private int m_pages_IndexEnd = 0;
        private int    m_img_bypage = 0;
        
        private int    m_imgs_count = 0;
        private string m_imgs_url = "";
        private string m_imgs_path = "";
        private string[] m_ArrayImgs;
        private string m_html = "";
       
        public void FncBldCacheGallery( UInt64 idDocTaxon, string idDocLng,  int img_bypage)
        {
            m_IdDoc =idDocTaxon ;
            m_IdDocLng = idDocLng;
            m_img_bypage = img_bypage;
            m_html = "";
            m_imgs_path = "";
            m_imgs_url = "";
            m_pages_count = 0;
          
            m_ArrayImgs = null;
            FncInitVariables();
           
            //m_html += "</div><hr/>p=8</br>";
            //m_html+=FncBldHtmlPager(8);
            //m_html += FncBldHtmlGall(8, "titulo 1");
            //m_html += "p=18</br>";
            //m_html += FncBldHtmlPager(18);
            //m_html += FncBldHtmlGall(18, "titulo 1");

            
        }
        public string FncHtmlPage(int iPage)
        {
            m_html = "";
          
            m_html += "p=1</br>";
            string pager = FncBldHtmlPager(iPage);
            m_html += pager;
            m_html += FncBldHtmlGall(iPage, "titulo 1");
            m_html += pager;
          
            return m_html;
        }

            /// <summary>
        /// Comprueba la exitencia de imagenes para generar la galeria
        /// </summary>
        /// <returns>Devuelve false si no se puede crear la galeria</returns>
        private bool FncInitVariables()
    {
        
        if (!oReg_OtheAll.FncSqlFind(m_IdDoc) )return false ;;
        // comprobar la existencia de la galeria

        string szURLGal = oReg_OtheAll.AOth_UrlImages.Trim().ToLower();
        string szPathGal = (ClsGlobal.DirRoot + szURLGal).Replace("\\", "/").Replace("//", "/");
        m_imgs_path= szPathGal;
        m_imgs_url =szURLGal;
        // comprobar la existencia del directorio de la galeria
        if (szURLGal=="") return false;
        try
        {
            if (!System.IO.Directory.Exists (m_imgs_path ))
               {
                return false ;
               }
        }
        catch (Exception )
        {
            return false;
        }
            //--------------------------------------------------
            // contar el numero de miniaturas en el directorio
            // si es cero no hay nada que mostrar

        m_ArrayImgs=System.IO.Directory.GetFiles(m_imgs_path, "*_minx.jpg");
        if (m_ArrayImgs.Length <1)
        {
            return false;
        }
        // calcular el numero de imagenes y de paginas a  mostrar
        m_imgs_count = m_ArrayImgs.Length;
      
        m_pages_count = (m_imgs_count / m_img_bypage) + 1;
         m_pages_IndexInit = 0;
         m_pages_IndexEnd = m_pages_count;

         m_html += "<br/>m_pages_count=" + m_pages_count.ToString();
        m_html += "<br/>m_img_bypage=" + m_img_bypage.ToString();
       

        return true;
        }
        /// <summary>
        /// Crea un fichero chache para cada pagina 
        /// </summary>
        /// <returns></returns>
        private void FncBldHtmlCache()
        {
            string szHtml = "";
            string szHtmlImg = "";
            string szHtmlPager = "";
            for (int n = 0; n < m_pages_count; n++)
            { 
                //-------------------------
                // nombre del fichero cache
                //--------------------------
               // FncBldNameFileGalleryCache(n);
                
                szHtmlPager = FncBldHtmlPager(n);
                szHtmlImg = FncBldHtmlGall(n,"titulo");
                szHtml=szHtmlPager + szHtmlImg  +szHtmlPager; 
                oRegCache.FncWriteCache(m_IdDoc, m_IdDocLng, szSection+n.ToString(),szHtml,true);

            }
        }
        private string FncBldHtmlGall(int pCurrentPage, string sztitleGallery)
        {
            string szHtml = "";
             oPP.FncGallery_New( pCurrentPage.ToString(), sztitleGallery);
            Int32 iImgInit=0;
            Int32 iImgEnd=0;
            iImgInit =(pCurrentPage-1)*m_img_bypage;
            iImgEnd = iImgInit + m_img_bypage;
            if (iImgEnd >m_imgs_count ) iImgEnd=m_imgs_count;
            string szTarget="";
            string szThumbnail="";
            string szTitleTop="";
            string szTitleBot="";
            for (int i=iImgInit;i<iImgEnd;i++)
            {
                szTarget="";
                szThumbnail =(m_ArrayImgs[i]).ToLower().Trim ().Replace ("\\","/").Replace("//","/") ;
                szThumbnail = szThumbnail.Replace(ClsGlobal.DirRoot.ToLower().Replace("\\", "/"), "");
                szTarget=szThumbnail.Replace("_minx.jpg","_med.jpg");

                oPP.FncGallery_AddPictureFB(szTarget, szThumbnail, szTitleTop, szTitleBot, "Gallery pag:"+pCurrentPage.ToString () );

            }
            szHtml =oPP.HtmGalleryFB; 
            return szHtml;

        }
        private string FncBldHtmlPager(int pCurrentPage)
        {
            string szHtml = "";
            int iStartPage = 0;
            int iEndPage = 0;

            if (m_pages_IndexEnd > 0) { iStartPage = pCurrentPage - 5; }
            if (iStartPage < 1) iStartPage = 1;

            iEndPage = iStartPage + 10;
            if (iEndPage > m_pages_IndexEnd)
            {
                iEndPage = m_pages_IndexEnd;
                iStartPage = m_pages_IndexEnd - 10;
                if (iStartPage < 0) iStartPage = 0;
            }
            int iPageBefo = iStartPage - 1;
            if (iPageBefo < 1) iPageBefo = -1;
            int iPagerNext = iEndPage + 1;
            if (iPagerNext >m_pages_IndexEnd) iPagerNext =-1;

            
            //.................................
            szHtml = "\n<div class=\"pagination\">\n<ul class=\"pagination\">";
            // Hay que poner el enlace al grupo anterior
            string szP="";
            //tax_id_en_215_images.txt
            string szCacheFile = "";
            string szUrlGalleryPage = "";
            string szUrlGalleryPagePattern="tax_id_"+m_IdDocLng+m_IdDoc.ToString()+"_images/";
            // poner link a before
            if(iPageBefo!=-1)
            {
                //«Previous
                szHtml += "\n<li><a href=\"" + szUrlGalleryPage + "/" + iPageBefo + "\">" + "&laquo;" + Resources.Strings.Previous + " </a></li>";
            
            }
            for (int p = iStartPage; p < iEndPage + 1; p++)
            {
                szUrlGalleryPage = szUrlGalleryPagePattern + p.ToString();
                szP = p.ToString();
                if (p != pCurrentPage)
                {
                    szHtml += "\n<li><a href=\"" + szUrlGalleryPage + "\">" + szP + "</a></li>";
                }
                else
                {
                    szHtml += "\n<li class=\"active\">" + szP + "</li>";
                
                }

            }
            // Hay que poner el enlace al grupo siguiente
            if (iPagerNext !=-1)
            {
                szHtml += "\n<li><a href=\"" + szUrlGalleryPage + "/" + iPagerNext.ToString() + "\">" + "&raquo;" +Resources.Strings.Next+  " </a></li>";

            }


            szHtml += "\n</ul>\n</div><hr/>";
            return szHtml;
            
        }
        
    }
}