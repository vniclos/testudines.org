using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
// documentacion FANCYBOX 3
//2008 
//http://fancyapps.com/fancybox/3/docs/
namespace testudines.cls.tools
{
    public class ClsGalleryFBox
    {
      
        public ClsGalleryFBox() { }
        private static String m_Html = "";
        private bbdd.ClsReg_tdoclng_media oRegMedia = new bbdd.ClsReg_tdoclng_media();
        // Fancybox plantillaSe

        //            //data-fancybox-title=\"#data-fancybox-title#\" 

        private const String mc_FBimageThumb = "<a href=\"#imgful#\" title=\"#mp_ImgTitle#\" data-fancybox=\"#group#\" data-fancybox-title=\"#data-fancybox-title#\"   data-caption=\"#caption#\"><img src=\"#imgthb#\" class=\"thumbnail float-left\" title=\"#title#\" alt = \"#alt#\" /></a>";
        private const string mc_FBimage = "<a href=\"#mp_ImgTar#\" data-fancybox=\"images\" data-caption=\"#mp_ImgTitle#\" #data-fancybox-title#\"data-caption=\"#caption#\">	<img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
        private const string mc_FBIframe = "<a data-fancybox data-type=\"iframe\" data-src=\"#hrefURLDoc#\" href=\"javascript:;\">#TextLink#</a>";

        private const string mc_FBimage198 = "<a class=\"fancybox-mio\"  href=\"#mp_ImgTar#\" data-fancybox-group=\"#mp_ImgGalId#\" title=\"#mp_ImgTitle#\"><img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
        private const string mc_FBInlineDiv = "<a class=\"fancybox\" href=\"##boxIdline#\" title=\"#mp_ImgTitle#\">#textlink#</a>";
        private const string mc_FBInlineAjax = "<a class=\"fancybox fancybox.ajax\" href=\"#hrefURLDoc#\">#TextLink#</a>";

        private const string mc_FBinlineFlash = "<a class=\"fancybox\" href=\"http://www.adobe.com/jp/events/cs3_web_edition #UrlSwf#\">#TextLink#</a>";
        private const string mc_FBInlineMedia = "<a class=\"fancybox-media\" href=\"#hrefURLDoc#\" title=\"#mp_ImgTitle#\" alt=\"#mp_ImgAlt#\" >#TextLink#</a>";


        private const string mc_OpenDlg_MsgDocid = "<a class=\"fancybox fancybox.iframe\" href=\"/a_dlg/dlgMsgDocId.aspx?imgurl=#mp_ImgTh#&imgdocid=#ImgDocId#%&imgname=#NameSpecieWithVulgar#&imgsec=#SectionFile#]\"><img class=\"right\" src=\"/Content/img/msg-warning.png\" title=\"Send msg about this image\"/></a>";

        private string m_GalleryId = "";
        private string m_GalleryTit = "";

        private string m_HtmlImages = "";
        private string m_HtmlGal_star = "\n<div class=\"row\">\n";
        //  private string m_HtmlGal_img = mc_FBimage; // sustituir por la plantilla mc_FB* que corresponda.
        private string m_HtmlGal_end = "\n</div>\n";

        //private string mp_ImgDocId = "#mp_MsgDocIdt#";





        public static String FncReplacePrettyPhoto(ref String szHtml)
        {
            return szHtml.Replace("rel=\"prettyPhoto\"", "data-fancybox=\"group\"");
        }
        public void FncGallery_New(String GalleryId, string GalleryTit)
        {
            m_HtmlImages = "";
            m_GalleryId = GalleryId;
            m_GalleryTit = FncRemoveHtmTag(ref GalleryTit, 80);
        }

        /// <summary>
        /// Añade una imagen a la galeria, conservando su tamaño original
        /// </summary>
        /// <param name="pImgTar"> URL de la imagen grande</param>
        /// <param name="pImgThb">URL de la imagen pequeña</param>
        /// <param name="pImgTitle">Titulo para la imagen</param>
        /// <param name="pImgAlt">Texto alt para la imagen</param>
        public void FncGallery_AddPictureFB(string pImgTar, string pImgThb, string pImgTitle, string pImgAlt, string pSectionFile)
        {
            string szHtml = "";
            string szHtmlImg = "";
            pImgThb = pImgThb.ToLower();

            if (pImgThb.Contains("noimage"))
            {
                pImgTitle = Resources.Strings.noimage;
            }
            // si no esta la imagen en la base de datos la añade y recupera el id en base de datos de la imagen
            string szMediaDocId = FncSaveIsNotExistoRegMediaFB(pImgThb).ToString();

            //-------- nueva version
            //mc_FBimage = "<a class=\"fancybox-mi\" href=\"#mp_ImgTar#\" data-fancybox-group=\"#mp_ImgGalIdId#\" title=\"#mp_ImgTitle#\"><img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
            szHtmlImg = mc_FBimage.Replace("#mp_ImgTar#", pImgTar);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTh#", pImgThb);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgGalIdId#", m_GalleryId);
            szHtmlImg = szHtmlImg.Replace("#title#", pImgTitle);
            szHtmlImg = szHtmlImg.Replace("#data-fancybox-title#", pImgTitle);
            szHtmlImg = szHtmlImg.Replace("#data-fancybox-title#", pImgTitle);

            //data-fancybox-title=\"#data-fancybox-title#\"   data-caption=\"#caption#\"


            szHtmlImg = szHtmlImg.Replace("#mp_ImgAlt#", pImgAlt);


            szHtml = "\n<div class=\"thumbnail\">";
            szHtml += szHtmlImg;
            szHtml += FncHtmlFootImg(szMediaDocId, pImgThb, pImgTitle, pSectionFile);
            szHtml += "\n</div>";
            m_HtmlImages += szHtml;
        }

        //----------------------------------------------------
        /// <summary>
        /// Añade una imagen a la galeria, con max-width=198;
        /// </summary>
        /// <param name="pImgTar"> URL de la imagen grande</param>
        /// <param name="pImgThb">URL de la imagen pequeña</param>
        /// <param name="pImgTitle">Titulo para la imagen</param>
        /// <param name="pImgAlt">Texto alt para la imagen</param>
        public void FncGallery_AddPicture198FB(string pImgTar, string pImgThb, string pImgTitle, string pImgAlt, string pSectionFile)
        {


            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            // comprobar que existe la miniatura y el tamaño medio
            pImgThb = pImgThb.ToLower();
            string szImgMed = "";
            string szImgBig = "";
            string szImgFul = "";

            string szImgNoExist = "/a_img/noimage1024px.png";
            //prevenir que no hay foto de los tamaños adecuados,
            //o que no se haya pasado el tamaño adecuado
            pImgThb = pImgThb.Trim().ToLower();
            pImgThb = pImgThb.Replace("ful.jpg", "minx.jpg");
            pImgThb = pImgThb.Replace("big.jpg", "minx.jpg");
            pImgThb = pImgThb.Replace("min.jpg", "minx.jpg");
            pImgThb = pImgThb.Replace("med.jpg", "minx.jpg");

            szImgMed = pImgThb.Replace("minx.jpg", "med.jpg");
            szImgBig = szImgMed.Replace("minx.jpg", "big.jpg");
            szImgFul = szImgMed.Replace("minx.jpg", "ful.jpg");
            // path real a las imagenes
            string szPatMinX = ((ClsGlobal.DirRoot + pImgThb).Replace("\\", "/")).Replace("//", "/");
            string szPathMed = ((ClsGlobal.DirRoot + szImgMed).Replace("\\", "/")).Replace("//", "/");
            //string szPathbig = ((ClsGlobal.UrlMMedia + szImgBig).Replace("\\", "/")).Replace("//", "/");
            //string szPathFul = ((ClsGlobal.UrlMMedia + szImgFul).Replace("\\", "/")).Replace("//", "/");

            // depurar no image.
            if (pImgThb.Contains("noimage"))
            {
                pImgTitle = Resources.Strings.noimage;
                pImgThb = szImgNoExist;
                pImgTar = szImgNoExist;
            }
            // depurar que no exite la miniatura
            if (!System.IO.File.Exists(szPatMinX))
            {
                pImgTitle = Resources.Strings.noimage;
                pImgThb = szImgNoExist;

            }


            // depurar que  exite el tamaño medio
            string szUrlTarget = szImgNoExist;
            if (System.IO.File.Exists(szPathMed))
            {
                szUrlTarget = szImgMed;
            }
            // obtener el identificador o crearlo 
            // siempre y cuando no sea una no image
            string szMediaDocId = "-1";

            if (!pImgThb.Contains("noimage"))
            {
                szMediaDocId = FncSaveIsNotExistoRegMediaFB(pImgThb).ToString();
            }

            // 1 si no existe minx -> no image
            // 1 y si contiene no image -> no image
            // 1 ambos casos sin enlace.
            string szHtml = "";
            string szHtmlImg = "";



            // si no esta la imagen en la base de datos la añade y recupera el id en base de datos de la imagen

            //-------- nueva version
            //private const string mc_FBimage198 = "<a class=\"fancybox-mio img_min\"  href=\"#mp_ImgTar#\" data-fancybox-group=\"#mp_ImgGalId#\" title=\"#mp_ImgTitle#\"><img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
            szHtmlImg = mc_FBimage198.Replace("#mp_ImgTar#", szUrlTarget);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTh#", pImgThb);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgGalId#", m_GalleryId);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTitle#", pImgTitle);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgAlt#", pImgAlt);

            szHtml = "\n<div class=\"th img_min\">";
            szHtml += szHtmlImg;
            szHtml += FncHtmlFootImg(szMediaDocId, pImgThb, pImgTitle, pSectionFile);
            szHtml += "\n</div>";
            m_HtmlImages += szHtml;
        }

        //==============================================================================
        //==============================================================================
        //==============================================================================
        //==============================================================================
        //==============================================================================
        //----------
        //2008 
        //----------
        /// <summary>
        /// 2008 Agrega una imagen de tamaño medio y la enlaza a tamaño grande o completo si exite.
        /// si no existe hace lo que puede
        /// </summary>
        /// <param name="pImgThb">Imagen a enlazar</param>
        /// <param name="pTitle">Titulo y alt para la imagen</param>
        /// <param name="pSectionDoc">Identificador de la secion donde esta</param>
        /// <returns>Htm para agregar la imagen a la pagina </returns>
        public string FncHtmlAloneRowPhotoFB_med(string pImgThb, string pTitle, string pSectionDoc)
        {

            string szImgMed = "";
            string szImgBig = "";
            string szImgFul = "";
            string szHtml = "";
            string szImgNoExist = "/a_img/noimage1024px.png";
            //prevenir que no hay foto de los tamaños adecuados,
            //o que no se haya pasado el tamaño adecuado
            pImgThb = pImgThb.Trim().ToLower();
            szImgMed = pImgThb.Replace("ful.jpg", "med.jpg");
            szImgMed = pImgThb.Replace("big.jpg", "med.jpg");
            szImgMed = szImgMed.Replace("min.jpg", "med.jpg");
            szImgMed = szImgMed.Replace("minx.jpg", "med.jpg");

            szImgBig = szImgMed.Replace("med.jpg", "big.jpg");
            szImgFul = szImgMed.Replace("med.jpg", "ful.jpg");

            string szPathImg = ClsUtils.FncPathCombine(ClsGlobal.DirRoot, pImgThb);
            string szPathMed = ClsUtils.FncPathCombine(ClsGlobal.DirRoot, szImgMed);
            string szPathbig = ClsUtils.FncPathCombine(ClsGlobal.DirRoot, szImgBig);
            string szPathFul = ClsUtils.FncPathCombine(ClsGlobal.DirRoot, szImgFul);
            if (!System.IO.File.Exists(szPathMed))
            {
                szHtml = "<img  class=\"thumbnail\" src=\"" + szImgNoExist + "\" alt=\"" + pTitle + "\"  title=\"" + pTitle + "\" />";
                return szHtml;
            }

            if (System.IO.File.Exists(szPathFul))
            {
                szHtml = FncHtmlAloneRowPhotoFB_med2(szImgFul, szImgMed, pTitle, pTitle, pSectionDoc);
                return szHtml;
            }
            if (System.IO.File.Exists(szPathbig))
            {
                szHtml = FncHtmlAloneRowPhotoFB_med2(szPathbig, szImgMed, pTitle, pTitle, pSectionDoc);
                return szHtml;
            }

            // si no existe med pero no ful o big muestra med sin enlace ifrme

            szHtml = "<img  class=\"th\" src=\"" + szImgMed + "\" alt=\"" + pTitle + "\"  title=\"" + pTitle + "\" />";

            return szHtml;
        }

       
        //===================================================================================================
        //===================================================================================================
        /// <summary>
        ///  Crea enlace iframe para image med
        /// </summary>
        /// <param name="pImgTar"></param>
        /// <param name="pImgThb"></param>
        /// <param name="pImgTitle"></param>
        /// <param name="pImgAlt"></param>
        /// <param name="pSectionFile"></param>
        /// <returns></returns>
        private string FncHtmlAloneRowPhotoFB_med2(string pImgTar, string pImgThb, string pImgTitle, string pImgAlt, string pSectionFile)
        {
            FncRemoveHtmTag(ref pImgTitle, 80);

            string szHtml = "";
            string szHtmlImg = "";
            pImgThb = pImgThb.ToLower();

            if (pImgThb.Contains("noimage"))
            {
                pImgTitle = Resources.Strings.noimage;
            }
            // si no esta la imagen en la base de datos la añade y recupera el id en base de datos de la imagen
            string szMediaDocId = FncSaveIsNotExistoRegMediaFB(pImgThb).ToString();

            //-------- nueva version
            //mc_FBimage = "<a class=\"fancybox-mi\" href=\"#mp_ImgTar#\" data-fancybox-group=\"#mp_ImgGalIdId#\" title=\"#mp_ImgTitle#\"><img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
            szHtmlImg = mc_FBimage.Replace("#mp_ImgTar#", pImgTar);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTh#", pImgThb);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgGalIdId#", m_GalleryId);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTitle#", pImgTitle);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgAlt#", pImgAlt);


            szHtml = "\n<div class=\"row\">\n<div class=\"imgBoxMeddiv\">\n";
            szHtml += szHtmlImg;
            // agrega un pie con enlaces
            szHtml += FncHtmlFootImg(szMediaDocId, pImgThb, pImgTitle, pSectionFile);
            szHtml += "\n</div></div>\n";





            return szHtml;

        }
        //===================================================================================================
        //===================================================================================================

        /// <summary>
        /// 2008 agrega a pie de imagen un link con enlace a dialogo para enviar mensaje correo.
        /// </summary>
        /// <param name="pMediaDocId"></param>
        /// <param name="pImgThb"></param>
        /// <param name="pImgTitle"></param>
        /// <param name="pSectionFile"></param>
        /// <returns></returns>
        private string FncHtmlFootImg(String pMediaDocId, string pImgThb, string pImgTitle, string pSectionFile)
        {



            Int32 iID = Convert.ToInt32(pMediaDocId);
            string szNum = String.Format("{0: #,#}", iID);

            string szhrefURLDoc = "/a_dlg/dlgmsgdocid.aspx?'imgurl=#mp_ImgTh#&imgdocid=#ImgDocId#%&imgname=#pImgTitle#&imgsec=#SectionFile#";
            szhrefURLDoc = szhrefURLDoc.Replace("#mp_ImgTh#", pImgThb.Trim());
            szhrefURLDoc = szhrefURLDoc.Replace("#ImgDocId#", pMediaDocId.Trim());
            szhrefURLDoc = szhrefURLDoc.Replace("#pImgTitle#", pImgTitle.Trim());
            szhrefURLDoc = szhrefURLDoc.Replace("#SectionFile#", pSectionFile.Trim());
            String szTextLink = "<img class=\"icoMsgfoot\"src=\"/Content/img/mail.png\" title=\"Send msg about this image\"/>&nbspId.:" + szNum;
            String sz_FBIframe = mc_FBIframe;
            sz_FBIframe = sz_FBIframe.Replace("#hrefURLDoc#", szhrefURLDoc);
            sz_FBIframe = sz_FBIframe.Replace("#TextLink#", szTextLink);
            return "\n<div class=\"imgGalleryMsgfoot\">" + sz_FBIframe + "</div>";

        }

        //===================================================================================================
        //===================================================================================================

        /// <summary>
        /// Si el medio no existe en la base de datos
        /// lo crea con valores por defecto, en caso contrari
        /// lo lee 
        /// Devuelve El ID del medio.
        /// </summary>
        /// <param name="img_urltarget"></param>
        private UInt64 FncSaveIsNotExistoRegMediaFB(string img_urltarget)
        {
            oRegMedia.FncClear();
            if (!oRegMedia.FncSqlFindURL(img_urltarget))
            {
                // guardarlo
                oRegMedia.Title = "";
                oRegMedia.URL = img_urltarget;
                oRegMedia.Author = "";
                oRegMedia.CreateDate = System.DateTime.Now;
                //oRegMedia.FileNameShort = "";
                oRegMedia.IsGalleryVisible = true;
                oRegMedia.LogFromDate = System.DateTime.Now;
                oRegMedia.LogFromIp = "";
                oRegMedia.Notes = "Created automatic";
                //oRegMedia.Type  = "";
                // oRegMedia.UID = "";
                oRegMedia.FncSqlSave(img_urltarget);


            }

            return oRegMedia.DocId;
        }

        /// <summary>
        /// Si el medio no existe en la base de datos
        /// lo crea con valores por defecto, en caso contrari
        /// lo lee 
        /// Devuelve El ID del medio.
        /// </summary>
        /// <param name="img_urltarget"></param>






        //----------
        //SE USA
        //----------
        public string HtmGalleryFB
        {
            get
            {
                string html = "";
                html += m_HtmlGal_star;
                html += m_HtmlImages;
                html += m_HtmlGal_end;
                return html;
            }
        }
        private string FncRemoveHtmTag(ref string sz, int maxLenght)
        {
            sz = sz.Replace("<p>", "");
            sz = sz.Replace("</p>", ". ");
            sz = sz.Replace("</ p>", ". ");
            sz = sz.Replace("<br/>", ". ");
            sz = sz.Replace("<br />", ". ");
            if (sz.Length > maxLenght) sz = sz.Substring(0, maxLenght - 1) + "...";
            return sz;
        }
        //----------
        //SE USA
        //----------
        public string FncHtmlAloneInLinePhotoFB(string pImgTar, string pImgThb, string pImgTitle, string pImgAlt, string pSectionFile)
        {
            FncRemoveHtmTag(ref pImgTitle, 80);




            string szHtml = "";
            string szHtmlImg = "";
            pImgThb = pImgThb.ToLower();

            if (pImgThb.Contains("noimage"))
            {
                pImgTitle = Resources.Strings.noimage;
            }
            // si no esta la imagen en la base de datos la añade y recupera el id en base de datos de la imagen
            string szMediaDocId = FncSaveIsNotExistoRegMediaFB(pImgThb).ToString();

            //-------- nueva version
            //mc_FBimage = "<a class=\"fancybox-mi\" href=\"#mp_ImgTar#\" data-fancybox-group=\"#mp_ImgGalIdId#\" title=\"#mp_ImgTitle#\"><img src=\"#mp_ImgTh#\" alt=\"#mp_ImgAlt#\" /></a>";
            szHtmlImg = mc_FBimage.Replace("#mp_ImgTar#", pImgTar);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTh#", pImgThb);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgGalIdId#", m_GalleryId);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgTitle#", pImgTitle);
            szHtmlImg = szHtmlImg.Replace("#mp_ImgAlt#", pImgAlt);


            szHtml = "\n<div  class=\"th nospacetab\">";
            szHtml += szHtmlImg;
            szHtml += FncHtmlFootImg(szMediaDocId, pImgThb, pImgTitle, pSectionFile);

            szHtml += "\n</div>";
            return szHtml;
        }
        /// <summary>
        /// Abre un dialogo que contiene un iframe
        /// </summary>
        /// <param name="url_Iframe"></param>
        /// <param name="pHtmlShowLink">html sobre el que hacer click para abrir iframe, ejemplo
        /// <img src=pp.png/> o <span class=button >click para abrir</span></param>
        /// <param name="titlebot"></param>
        /// <param name="titletop"></param>
        /// <returns></returns>
        //----------
        //SE USA
        //----------
        public String FncHtmlAloneIframeInlineImageFB(String pHrefURLDoc, String pHtmlShowLink, String pTitle, String pAlt)
        {

            //mc_FBInlineIframe ="<a class=\"fancybox fancybox.iframe\" href=\"#hrefURLDoc#\">#TextLink#</a>";
            String szTextLink = "<img  class=\"imgleft\"  src=\"" + pHtmlShowLink + "\" title=\"" + pTitle + "\"  alt=\"" + pAlt + "\" />";
            String szHtml = "";
            szHtml = mc_FBIframe;
            szHtml = szHtml.Replace("#hrefURLDoc#", pHrefURLDoc);
            szHtml = szHtml.Replace("#TextLink#", szTextLink);
            szHtml = "\n<span  class=\"th nospacetab\">" + szHtml + "</a></span>\n";

            return szHtml;

        }
        /// <summary>
        /// Crea un modal popup para un contenido mutimedia alojado en
        /// youtube, vimeo, metacafe, dailymotion, instagram...
        /// </summary>
        /// <param name="pHrefURLDoc"></param>
        /// <param name="pTextLink"></param>
        /// <param name="p_ImgTitle"></param>
        /// <param name="p_ImgAlt"></param>
        /// <param name="pLinkImg_urlthumb"></param>
        /// <returns></returns>
        public string FncHtmlAloneMediaFB(string pHrefURLDoc, string pTextLink, string p_ImgTitle, string p_ImgAlt, string pLinkImg_urlthumb)
        {
            /*------------------------------------ 
        * <ul>
       * <li><a class="fancybox-media" href="http://www.youtube.com/watch?v=opj24KnzrWo">Youtube</a></li>
       * <li><a class="fancybox-media" href="http://vimeo.com/47480346">Vimeo</a></li>
       * <li><a class="fancybox-media" href="http://www.metacafe.com/watch/7635964/">Metacafe</a></li>
       * <li><a class="fancybox-media" href="http://www.dailymotion.com/video/xoeylt_electric-guest-this-head-i-hold_music">Dailymotion</a></li>
       * <li><a class="fancybox-media" href="http://twitvid.com/QY7MD">Twitvid</a></li>
       * <li><a class="fancybox-media" href="http://twitpic.com/7p93st">Twitpic</a></li>
       * <li><a class="fancybox-media" href="http://instagr.am/p/IejkuUGxQn">Instagram</a></li>
   </ul>
        * 
        * 
        * ---------------------------------*/
            //            private const string mc_FBinlineFlash = "<a class=\"fancybox\" href=\"http://www.adobe.com/jp/events/cs3_web_edition #UrlSwf#\">#TextLink#</a>";
            string szHtml = "";
            szHtml = mc_FBinlineFlash;
            szHtml = szHtml.Replace("#hrefURLDoc#", pHrefURLDoc);
            szHtml = szHtml.Replace("#TextLink#", pTextLink);
            szHtml = szHtml.Replace("#mp_ImgTitle#", p_ImgTitle);
            szHtml = szHtml.Replace("#mp_ImgAlt#", p_ImgAlt);
            if (pLinkImg_urlthumb != "")
            {
                pTextLink = "<img  class=\"imgleft\"  src=\"" + pLinkImg_urlthumb + "\" title=\"" + p_ImgTitle + "\"  alt=\"" + p_ImgAlt + "\" />";
            }
            szHtml = szHtml.Replace("#TextLink#", pTextLink);
            szHtml = "\n<span  class=\"th nospacetab\">" + szHtml + "</a></span>\n";

            return szHtml;

        }

        public string FncHtmlAloneFlashFB(string pUrlSwf, string pTextLink, string p_ImgTitle, string p_ImgAlt, string pLinkImg_urlthumb)
        {


            // private const string mc_FBInlineMedia = "<a class=\"fancybox-media\" href=\"#hrefURLDoc#\" title=\"#mp_ImgTitle#\" alt=\"#mp_ImgAlt#\" >#TextLink#</a>";

            string szHtml = "";
            szHtml = mc_FBInlineMedia;
            szHtml = szHtml.Replace("#UrlSwf#", pUrlSwf);
            szHtml = szHtml.Replace("#TextLink#", pTextLink);
            szHtml = szHtml.Replace("#mp_ImgTitle#", p_ImgTitle);
            szHtml = szHtml.Replace("#mp_ImgAlt#", p_ImgAlt);
            if (pLinkImg_urlthumb != "")
            {
                pTextLink = "<img  class=\"imgleft\"  src=\"" + pLinkImg_urlthumb + "\" title=\"" + p_ImgTitle + "\"  alt=\"" + p_ImgAlt + "\" />";
            }
            szHtml = szHtml.Replace("#TextLink#", pTextLink);
            szHtml = "\n<span  class=\"th nospacetab\">" + szHtml + "</a></span>\n";

            return szHtml;
        }
        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        /// <summary>
        /// 2008 Incializa el Html de un grupo con el codigo div class=\"images\">
        /// </summary>
        /// <returns></returns>
        public static String FncHtm_ImgGroup_Start()
        {
            String m_Html = "";
            m_Html = "\n<div class=\"images\">";
            return m_Html;
        }
        /// <summary>
        /// 2018 fincaliza el html con </div> y lo devuelve completo.
        /// </summary>
        /// <returns></returns>
        public static String FncHtml_ImgGroup_BoxEnd()
        {
            m_Html = "\n</div>\n";
            return m_Html;
        }

        /// <summary>
        ///  2008 Devuelve Html de una imagen thumbnai
        /// </summary>
        /// <param name="pUrlImg_min"></param>
        /// <param name="pCaption"></param>
        /// <returns></returns>
        public static String FncHtml_ImgGroup_ThuAdd_1(ref String pUrlImg_minx, ref String pCaption, ref String pAlt, ref String pGroup)
        {
            pUrlImg_minx = pUrlImg_minx.ToLower();
            pUrlImg_minx = pUrlImg_minx.Replace("_min.", "_minx.");
            String UrlImg_ful = pUrlImg_minx.Replace("_minx.", "_ful.");
            //private static String m_Img_template= "<a href=\"#imgthb#\" 
            //data-fancybox=\"#group#\" data-caption=\"#caption#\">
            //<img src=\"#imgful#\" alt = \"#alt#\" /></ a >"; 
            String html = mc_FBimageThumb.Replace("#imgthb#", pUrlImg_minx);
            html = html.Replace("#imgful#", UrlImg_ful);
            html = html.Replace("#caption#", pCaption);
            html = html.Replace("#group#", pGroup);
            html = html.Replace("#alt#", pGroup);
            html = html.Replace("#pAlt#", pGroup);

            return "\n" + html;
        }
        /// <summary>
        /// 2008 Devuelve Html con con grupo de 3 imagenes thumbnails
        /// </summary>
        /// <param name="pUrlImg_minx1"></param>
        /// <param name="pUrlImg_minx2"></param>
        /// <param name="pUrlImg_minx3"></param>
        /// <param name="pCaption"></param>
        /// <param name="pAlt"></param>
        /// <param name="pGroup"></param>
        /// <returns></returns>
        public static String FncHtm_ImgGroup_thuAdd_3(ref String pUrlImg_minx1, ref String pUrlImg_minx2, ref String pUrlImg_minx3, ref String pCaption, ref String pAlt, ref String pGroup)
        {
            m_Html = "";
            m_Html = FncHtm_ImgGroup_Start();
            string caption = pCaption + " 1";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx1, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 2";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx2, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 3";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx3, ref caption, ref pAlt, ref pGroup);
            m_Html += FncHtml_ImgGroup_BoxEnd();
            return m_Html;
        }
        /// <summary>
        /// 2008 Devuelve Html con con grupo de 6 imagenes thumbnails
        /// </summary>
        /// <param name="pUrlImg_minx1"></param>
        /// <param name="pUrlImg_minx2"></param>
        /// <param name="pUrlImg_minx3"></param>
        /// <param name="pUrlImg_minx4"></param>
        /// <param name="pUrlImg_minx5"></param>
        /// <param name="pUrlImg_minx6"></param>
        /// <param name="pCaption">Nombre de la imagen, agrega un numerador</param>
        /// <param name="pAlt">Alt de la imagen</param>
        /// <param name="pGroup">Nombre del grupo para galleria fancybox</param>
        /// <returns></returns>
        public static String FncHtm_ImgGroup_thuAdd_6(ref String pUrlImg_minx1, ref String pUrlImg_minx2, ref String pUrlImg_minx3, ref String pUrlImg_minx4, ref String pUrlImg_minx5, ref String pUrlImg_minx6, ref String pCaption, ref String pAlt, ref String pGroup)
        {
            m_Html = "";
            m_Html = FncHtm_ImgGroup_Start();
            string caption = pCaption + " 1";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx1, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 2";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx2, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 3";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx3, ref caption, ref pAlt, ref pGroup);
            caption += pCaption + " 4";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx1, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 5";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx2, ref caption, ref pAlt, ref pGroup);
            caption = pCaption + " 6";
            m_Html += FncHtml_ImgGroup_ThuAdd_1(ref pUrlImg_minx3, ref caption, ref pAlt, ref pGroup);

            m_Html += FncHtml_ImgGroup_BoxEnd();
            return m_Html;
        }
    }
}

