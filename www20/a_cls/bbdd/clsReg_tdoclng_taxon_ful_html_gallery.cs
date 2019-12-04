using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace testudines.cls.bbdd
{
    /// <summary>
    /// Crea un cache de paginas correspondientes a la galeria de un taxon
    /// y a un lenguage. 
    /// Si no existe la crea.
    /// Si existe la remplaza en funcion de que m_bRebuildCache sea verda o falso
    /// </summary>
    public class ClsReg_tdoclng_taxon_ful_html_gallery 
    {

        public ClsReg_tdoclng_taxon_ful_html_gallery()
        {

        }
        private cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
        private cls.bbdd.ClsReg_tdoclng_taxon_all m_oTaxon = new cls.bbdd.ClsReg_tdoclng_taxon_all();
        private cls.cache.ClsCache_Reg_tdoclng_taxon oRegCache = new cls.cache.ClsCache_Reg_tdoclng_taxon();
        private const string c_Section="gallery_";
        private UInt64 m_IdDoc = 0;
        private string m_IdDocLng = "";
        private int    m_pages_count = 0;
        private int m_pages_IndexEnd = 0;
        //private int m_pages_IndexInit = 0;
        private int    m_img_bypage = 0;
        private int    m_imgs_count = 0;
        private string m_imgs_url = "";
        private string m_imgs_path = "";
        private string[] m_ArrayImgs;
        private string m_html = "";
        private string m_szTitleTop="";
        private string m_szTitleBot = "";
        private bool m_bRebuildCache = true;
        public void fncSetCacheGallery(bool bRebuildCache, UInt64 idDocTaxon, string idDocLng,  int img_bypage, string szTitleTop, string szTitleBot)
        {
            m_szTitleTop = szTitleTop;
            m_szTitleBot=szTitleBot;
            m_IdDoc =idDocTaxon ;
            m_IdDocLng = idDocLng;
            m_img_bypage = img_bypage;
            m_html = "";
            m_imgs_path = "";
            m_imgs_url = "";
            m_pages_count = 0;
          
            m_ArrayImgs = null;
            fncBldGalInitVariables();
           
            
        }
        /// <summary>
        /// Comprueba la exitencia de imagenes para generar la galeria
        /// </summary>
        /// <returns>Devuelve false si no se puede crear la galeria</returns>
       
        /// <summary>
        /// Crea un fichero chache para cada pagina 
        /// </summary>
        /// <returns></returns>
        public void fncBldHtmlCache()
        {
            if (!m_bRebuildCache) return;
            string szHtml = "";
            string szHtmlImg = "";
            string szHtmlPager = "";
            for (int n = 1; n < m_pages_count+1; n++)
            { 
                szHtmlPager = fncBldGalSecHtmlPager(n);
                szHtmlImg = fncBldGalSecHtmlPage(n,"Pag.: "+n.ToString ());
                szHtml=szHtmlPager + szHtmlImg  +szHtmlPager;
                oRegCache.fncWriteCache(m_IdDoc, m_IdDocLng, c_Section + n.ToString(), szHtml, m_bRebuildCache);  
            }
        }
        private bool fncBldGalInitVariables()
        {

            if (!m_oTaxon.fncSqlFind(m_IdDoc)) return false; ;
            // comprobar la existencia de la galeria
            string szURLGal = m_oTaxon.AGallery.Trim().ToLower();
            string szPathGal = (ClsGlobal.DirRoot + szURLGal).Replace("\\", "/").Replace("//", "/");
            m_imgs_path = szPathGal;
            m_imgs_url = szURLGal;
            // comprobar la existencia del directorio de la galeria
            if (szURLGal == "")
            {
                fncBldGalSecHtmlCacheEmpty();
                return false;
            }
            try
            {
                if (!System.IO.Directory.Exists(m_imgs_path))
                {
                    fncBldGalSecHtmlCacheEmpty();
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            //--------------------------------------------------
            // contar el numero de miniaturas en el directorio
            // si es cero no hay nada que mostrar


            // comprobar la existencia del album de imagenes
            m_ArrayImgs = System.IO.Directory.GetFiles(m_imgs_path, "*_minx.jpg");
            if (m_ArrayImgs.Length < 1)
            {
                fncBldGalSecHtmlCacheEmpty();
                return false;
            }
            // calcular el numero de imagenes y de paginas a  mostrar
            m_imgs_count = m_ArrayImgs.Length;

            m_pages_count = (m_imgs_count / m_img_bypage) + 1;
           // m_pages_IndexInit = 0;
            m_pages_IndexEnd = m_pages_count;

            m_html += "<br/>m_pages_count=" + m_pages_count.ToString();
            m_html += "<br/>m_img_bypage=" + m_img_bypage.ToString();


            return true;
        }
        private string fncBldGalSecHtmlPage(int pCurrentPage, string sztitleGallery)
        {
            string szHtml = "";
            oPP.fncGallery_New ( pCurrentPage.ToString(), sztitleGallery);
            Int32 iImgInit=0;
            Int32 iImgEnd=0;
            iImgInit =(pCurrentPage-1)*m_img_bypage;
            iImgEnd = iImgInit + m_img_bypage;
            if (iImgEnd >m_imgs_count ) iImgEnd=m_imgs_count;
            string szTarget="";
            string szThumbnail="";
            //string szTop = "";
            string szIdOrder = "";
            string szIdOrderNoSpan = "";
            Int32 iImgNum=0;
            for (int i=iImgInit;i<iImgEnd;i++)
            {
                iImgNum++;
                szTarget="";
                szThumbnail =(m_ArrayImgs[i]).ToLower().Trim ().Replace ("\\","/").Replace("//","/") ;
                szThumbnail = szThumbnail.Replace(ClsGlobal.DirRoot.ToLower().Replace("\\", "/"), "");
                if (!szThumbnail.StartsWith("/")) szThumbnail = "/" + szThumbnail;
                szTarget=szThumbnail.Replace("_minx.jpg","_med.jpg");
                szIdOrderNoSpan = " [" + pCurrentPage.ToString() + "-" + (iImgNum).ToString() + "]";
                szIdOrder = "<span style='float:right;'>"+ szIdOrderNoSpan+ "</span>";
                
                //szTop = m_szTitleTop + szIdOrder;

                oPP.fncGallery_AddPicture198FB(szTarget, szThumbnail, m_szTitleBot + szIdOrderNoSpan, m_szTitleTop + szIdOrder, "gallery pg:" + pCurrentPage.ToString ());

            }
            szHtml = "\n<div>\n" + oPP.HtmGalleryFB + "\n</div>"; 
            return szHtml;

        }
        private string fncBldGalSecHtmlPager(int pCurrentPage)
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
                if (iStartPage < 1) iStartPage = 1;
            }
            int iPageBefo = iStartPage - 1;
            if (iPageBefo < 1) iPageBefo = -1;
            int iPagerNext = iEndPage + 1;
            if (iPagerNext >m_pages_IndexEnd) iPagerNext =-1;

            
            //.................................
            szHtml = "\n<div>\n<ul class=\"pagination\">";
            // Hay que poner el enlace al grupo anterior
            string szP="";
            //tax_id_en_215_gallery.txt
            string szCacheFile = "";
            string szUrlGalleryPage = "";
            string szUrlGalleryPagePattern="tax_id_"+m_IdDocLng+m_IdDoc.ToString()+"_gallery/";
            // poner link a before
            szHtml += "\n<li><a href=\"?p=1\" title=\"" + Resources.Strings.First + "\">|&laquo;&laquo; </a></li>";
            if(iPageBefo!=-1)
            {
                //«Previous
                szHtml += "\n<li><a href=\"?p=" + iPageBefo + "title=\"" + Resources.Strings.First + "\">" + "&laquo </a></li>";
            
            }
            for (int p = iStartPage; p < iEndPage + 1; p++)
            {
                szUrlGalleryPage = szUrlGalleryPagePattern + p.ToString();
                szP = p.ToString();
                if (p != pCurrentPage)
                {
                    szHtml += "\n<li><a href=\"?p=" + szP .ToString ()+ "\">" + szP + "</a></li>";
                }
                else
                {
                    szHtml += "\n<li class=\"current\">" + szP + "</li>";
                
                }

            }
            // Hay que poner el enlace al grupo siguiente
            if (iPagerNext !=-1)
            {
                szHtml += "\n<li><a href=\"?p=" + iPagerNext.ToString() + "\" title=\""+Resources.Strings.Next  +"\">&raquo;</a></li>";

            }
            szHtml += "\n<li><a href=\"?p=" + m_pages_count.ToString() + "\"  title=\"" + Resources.Strings.Last + "\">&raquo;&raquo;| </a></li>";

            szHtml += "\n</ul>\n</div>";
            return szHtml;
            
        }
        private string fncBldGalSecHtmlCacheEmpty()
        {
            string szHtml = "<h3>" + Resources.Strings.NoImagenInthisAlbumTitle + "</h3>";
            szHtml = "<p>" + Resources.Strings.NoImagenInthisAlbumTitle + "</p>";

            ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdDocLng, c_Section + "1", szHtml, true);

            return szHtml;
        }  
    }
}