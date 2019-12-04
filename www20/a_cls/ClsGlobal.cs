using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Permissions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.IO;
using System.Configuration;


namespace testudines.cls
{
    static class ClsGlobal
    {

        /// <summary>
        /// Si existe el fichero CacheRebuid.txt
        /// fuerza el recrear el fichero cache
        /// cuando se pide una pagina
        /// </summary>
        public static bool CacheRebuid
        {

            get
            {

                bool bRebuid = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["bCacheRebuild"]);

                return bRebuid;
            }
        }
        public static Int32 imgAvatarWidth = 166;
        public static Int32 imgAvatarHeight = 100;

        // default language for new documents;
        public static String default_UICulture = "en-US";
        public static String default_DocLngId = "en";
        public static String defaultSiteName = "www.testudines.org";
        public static String defaultAuthorsite = "testudines.org";
        public static String defaultVNiclos = "V. Niclós";
        public static String LngIdThread
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.ToString().Substring(0, 2);
            }
        }
        //====================================================
        // Cadena de conexion a bases de datos
        //====================================================
        public static string Connection_MARIADB_ITIS = "server=localhost;user=root;pwd=22Algadins;database=itis-2018;  pooling=false; charset=utf8;SslMode=none ";
        public static String Connection_MARIADB = "server=localhost;user=root;pwd=22Algadins;database=testudines20B;  pooling=false; charset=utf8;SslMode=none ";
        //public static String Connection_MARIADB = ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString;
        //====================================================
        // configuracion del correo
        //====================================================
        public static String eMailSmtpServer = "mail.testudines.org";
        public static String eMailAddressContact = "vicente.niclos@testudines.org";
        public static String eMailAddressBcc = "vte.niclos@gmail.com";
        public static String eMailSmtpUser = "no-reply";
        public static String eMailSmtpPasword = "algadins";
        public static String eMailSmtpFromDefault = "no-reply@testudines.org";
        public static String eMailSmtpFromDefaultDisplayName = "www.testudines.org (No Reply)";
        //====================================================
        // directorios 
        //====================================================



        private static String m_UrlRoot = "http://www.testudines.org";
        private static String m_UrlCache = "/a_cache/";
        private static String m_UrlCacheTortoises = m_UrlCache + "taxon/";

        private static String m_UrlTmp = "/a_tmp/";
        private static String m_UrlMultimediaRootNode = "/";
        private static String m_UrlMMedia = "/mmedia/";
        private static String m_UrlMMediaPDF = "/mmedia/pdf/";
        private static String m_UrlAvatars = "/a_files/Avatars/";
        private static String m_UrlDocTypes = "/a_files/doc_types/";
        private static String m_UrlDocReferences = "/a_files/doc_references/";
        private static String m_UrlDocStore = "/a_files/doc_docstore/";
        private static String m_UrlPdfResources = "/a_ResourcesPdf/";


        private static String m_UrlRootFul = m_UrlRoot;
        private static String m_UrlCacheFul = "";
        private static String m_UrlTmpFul = "";
        private static String m_UrlMultimediaRootNodeFul = "/";
        private static String m_UrlMMediaFul = "";
        private static String m_UrlMMediaPDFFul = "";

        private static String m_UrlAvatarsFul = "";
        private static String m_UrlDocTypesFul = "";
        private static String m_UrlDocReferencesFul = "";
        private static String m_UrlDocStoreFul = "";



        // se calculan al arrancar la aplicacion en el servidor
        // llamando a la funcion FncDirBuidlGlobal que ademas si no existe el 
        // directorio lo creara
        private static String m_DirRoot = "";
        private static String m_DirCache = ConfigurationManager.AppSettings["fileCacheRoot"];

        private static String m_DirCacheTortoises = "";

        private static String m_DirTemp = "";
        private static String m_DirMMedia = "";
        private static String m_DirMMediaPdf = "";
        private static String m_DirAvatars = "";
        private static String m_DirDocTypes = "";
        private static String m_DirDocReference = "";
        private static String m_DirDocStore = "";

        private static String m_DirPdfResources = "";
        // si no existe el directorio los crea
        public static String DirRoot { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirRoot); return m_DirRoot.ToLower(); } }
        public static String DirCache { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirCache); return m_DirCache.ToLower(); } }
        public static String DirCacheTortoises { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirCacheTortoises); return m_DirCacheTortoises; } }

        public static String DirTemp { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp); return m_DirTemp.ToLower(); } }
        public static String DirMMedia { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp); return m_DirMMedia.ToLower(); } }

        public static String DirMmediaPdf { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp); return m_DirMMediaPdf.ToLower(); } }
        public static String DirPdfResources { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirPdfResources); return m_DirPdfResources.ToLower(); } }

        public static String DirAvatars { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp); return m_DirAvatars.ToLower(); } }
        public static String DirDocTypes { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp); return m_DirDocTypes.ToLower(); } }
        public static String DirDocReference { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirDocReference); return m_DirDocReference.ToLower(); } }
        public static String DirDocStore { get { cls.ClsUtils.FncPathDirectoryBuid(m_DirDocStore); return m_DirDocStore.ToLower(); } }



        public static string DirTempSession
        {
            get
            {
                string szDir = m_DirTemp + cls.ClsUtils.FncDateToAAAAMMDD(DateTime.Now) + "/" + HttpContext.Current.Session.SessionID + "/";


                if (!System.IO.Directory.Exists(szDir)) System.IO.Directory.CreateDirectory(szDir);
                return szDir;
            }
        }
        public static bool DirTempSessionDeleteToday()
        {
            string szDir = m_DirTemp + cls.ClsUtils.FncDateToAAAAMMDD(DateTime.Now) + "/" + HttpContext.Current.Session.SessionID + "/";
            if (System.IO.Directory.Exists(szDir))
            {
                try
                {
                    System.IO.Directory.Delete(szDir, true);

                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public static bool DirTempSessionDeleteOld()
        {
            string szDirTemp = m_DirTemp;

            string szDirTempToday = szDirTemp + cls.ClsUtils.FncDateToAAAAMMDD(DateTime.Now);
            if (!System.IO.Directory.Exists(szDirTemp)) return true;
            bool bOk = true;
            // erase old directory
            foreach (string szDir in System.IO.Directory.GetDirectories(szDirTemp))
            {
                if (szDir != szDirTempToday)
                {
                    try
                    {
                        System.IO.Directory.Delete(szDir, true);
                    }
                    catch { bOk = false; }
                }

            }

            // erase old files in root temp, by the fly
            foreach (string szFile in System.IO.Directory.GetFiles(szDirTemp))
            {

                try
                {
                    System.IO.File.Delete(szFile);
                }
                catch { bOk = false; }
            }
            return bOk;
        }

        //====================================================
        // URL 
        //====================================================
        public static String UrlRoot { get { return m_UrlRoot; } }
        public static String UrlCache { get { return m_UrlCache; } }
        public static String UrlCacheTortoises { get { return m_UrlCacheTortoises; } }

        public static String UrlMMedia { get { return m_UrlMMedia; } }
        public static String UrlMMediaPDF { get { return m_UrlMMediaPDF; } }
        public static String UrlDocReference { get { return m_UrlDocReferences; } }
        public static String UrlDocStore { get { return m_UrlDocStore; } }
        public static String UrlAvatars { get { return m_UrlAvatars; } }
        public static String UrlMultimediaRootNode { get { return m_UrlMultimediaRootNode; } }

        public static String UrlTmp { get { return m_UrlTmp; } }
        public static String UrlPdfResources { get { return m_UrlPdfResources; } }

        public static string ApiCitesKey { get { return "VCMZNfJoQm2YyvUnmnNqtQtt"; } }
        public static string ApiCitesUsr { get { return "vicente.niclos@testudines.org"; } }
        public static string ApiGbif { get { return "User V.Niclos facebook 2251 Algadins GBF"; } }

        //public static String UrlRootFul { get { return m_UrlRootFul; } }
        //public static String UrlCacheFul { get { return m_UrlCacheFul; } }
        //public static String UrlMMediaFul { get { return m_UrlMMediaFul; } }
        //public static String UrlDocReferenceFul { get { return m_UrlDocReferencesFul; } }
        //public static String UrlDocStoreFul { get { return m_UrlDocStoreFul; } }
        //public static String UrlAvatarsFul { get { return m_UrlAvatarsFul; } }
        //public static String UrlMultimediaRootNodeFul { get { return m_UrlMultimediaRootNodeFul; } }
        //public static String UrlTmpFul { get { return m_UrlTmpFul; } }


        public static void FncDirBuidlGlobal()
        {
            m_DirRoot = HttpContext.Current.Server.MapPath("~");
            m_DirRoot = HttpRuntime.AppDomainAppPath.ToString().Replace("\\", "/").ToLower();
            if (m_DirCache == "") { m_DirCache = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlCache.ToLower()); }

            m_DirCacheTortoises = m_DirCache.ToLower() + "tortoises\\";


            m_DirTemp = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlTmp.ToLower());
            m_DirMMedia = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlMMedia.ToLower());
            m_DirMMediaPdf = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlMMediaPDF.ToLower());
            m_DirAvatars = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlAvatars.ToLower());
            m_DirDocTypes = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlDocTypes.ToLower());
            m_DirDocReference = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlDocReferences.ToLower());
            m_DirDocStore = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlDocStore.ToLower());
            m_DirPdfResources = cls.ClsUtils.FncPathCombine(DirRoot, m_UrlPdfResources.ToLower());



            cls.ClsUtils.FncPathDirectoryBuid(m_DirCache);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirCacheTortoises);

            cls.ClsUtils.FncPathDirectoryBuid(m_DirTemp);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirMMedia);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirAvatars);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirDocTypes);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirDocStore);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirDocReference);
            cls.ClsUtils.FncPathDirectoryBuid(m_DirPdfResources);



            m_UrlCacheFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlCache);
            m_UrlTmpFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlTmp);
            m_UrlMultimediaRootNodeFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlMultimediaRootNode);
            m_UrlMMediaFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlMMedia);
            m_UrlMMediaPDFFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlMMediaPDF);
            m_UrlAvatarsFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlAvatars);
            m_UrlDocTypesFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlDocTypes);
            m_UrlDocReferencesFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlDocReferences);
            m_UrlDocStoreFul = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlDocStore);
            m_UrlPdfResources = cls.ClsUtils.FncUrlCombine(m_UrlRootFul, m_UrlPdfResources);

        }
        
        //====================================================
        // Enumerados globales de la aplicacion
        //====================================================

      //  public enum  { Abstracts, Description, Natural_history, Distribution, Care, Taxonony, Bibliography, Gallery, Nearspecies, Identificationkeys };
      
        public enum E_SiteMapFrecuency { always, hourly, daily, weekly, monthly, yearly, never }
        public enum E_MenuTab { home, articles, notices, species, taxonKeys, taxongroups, references, others, tools, foods, calculator, images, appendix, agreetmens, contact, about, todo, nearspecies, Ecozones }
        public enum E_MsgType { alert, success, warning }
        public enum E_AppendixesType { botanic, zoology, ecology, other, noselect }
        public enum E_AppendixesTypeSub { anathomy, ethimology, chemist, other, noselect }
        public enum E_OtherType { recipe, electronic, other, noselect }
        public enum E_OtherTypeSub { basic, expert, highrecomendable, noselect }
        public enum E_TaxonType { class_, subclass, order, suborder, superfamily, family, subfamily, genus, specie, noselect }
        public enum E_TaxonTypeSub { live, extinct_wild, extinct, extinct_fossil, error }
        public enum E_CssMsg_box { boxmsg_info, boxmsg_success, boxmsg_warning, boxmsg_error, boxmsg }
        public enum E_SecurityLevelsShow { Anonimous, Logged, Autor, Editor, Admin };
        public enum E_SecurityLevelsEdit { Anonimous, Logged, Autor, Editor, Admin };

        public enum E_EcozoneType { description, noselect };
        public enum E_EcozoneTypeSub { ecozone, noselect };


        public enum E_ReferenceType { veterinary, people, agrupation, institution, publication, multimedia, website, other, noselect };
        public enum E_ReferenceTypeSub { breader, education, cientific, zoo, conservationGroup, goverment, other, noselect };

        public enum E_ArticleType { caresheet, conservancy_project, biology, diseases, art_society, other, noselect }
        public enum E_ArticleTypeSub { basic, expert, highrecomendable, noselect }


        public enum E_FoodType { vegetable, animal, manufactured, medicines, supplements, other }
        public enum E_FoodTypeSub { very_good, good, occasionally, bad, prohibited, other, noselect }

        public enum E_NoticeType { conservancy_project, society, law, specie, other, noselect }
        public enum E_NoticeTypeSub { basic, expert, highrecomendable, other, noselect }

        public enum E_TodoType { waiting, doing, done, cancel, noselect }
        public enum E_TodoTypeSub { hight, medium, low, nothing, noselect }

        public enum E_AgreetmentType { people, organitatiton, other, noselect };
        public enum E_AgreetmentTypeSub { pictures, articles, both, other, noselect };

        public enum E_MediaGalType { media, noselect };
        public enum E_MediaGalTypeSub { images, noselect };
        //
        
        public enum E_TortoiseChapters { summary, description, natural_history, distribution, ecology ,care, taxonomy, bibliography, images, notes, nearspecies, identificationkeys };
        
    }
}
