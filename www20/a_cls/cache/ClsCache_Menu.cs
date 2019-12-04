using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;
namespace testudines.cls.cache
{
    /// <summary>
    /// crea cache del menu 
    /// lee cache del menu si no existe lo crea
    /// </summary>
    public static class ClsCache_Menu
    {
        private static String m_Culture_before = "";
        private static String m_Culture_Called = "";
        private static String m_LngId = "";


        public static String FncHtmlMenu(bool bRebuild, String Culture)
        {
            FncCulture(Culture);
            String szFulFileName = cls.cache.ClsCache.FncCacheFilePath(0, Culture, "menu");
            if (bRebuild) cls.ClsUtils.FncPathFileDelete(szFulFileName);
            if (cls.ClsUtils.FncPathFileExist(szFulFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFulFileName);
            }
            else
            {
                String szHtml = FncHtmlBldMenu(Culture);

                cls.cache.ClsCache.FncCacheFileSave(ref szFulFileName, ref szHtml);
                return szHtml;
            }

        }
        private static String FncHtmlBldMenu(String szIdLng)
        {

            string szHtml = "";
            FncHtmlBldMenu_head(ref szHtml);
            FncHtmlBldMenu_Start(ref szHtml);
            FncHtmlBldMenu_Items(ref szHtml);
            FncHtmlBldMenu_End(ref szHtml);
            return szHtml;
        }
        /********* new */
        private static void FncCulture(String pCulture)
        {
            String szCulture = pCulture.Substring(0, 2).ToUpper();
            pCulture = "ES-es";
            if (szCulture == "ES") { pCulture = "ES-es"; }
            else if (szCulture == "EN") { pCulture = "EN-us"; }
            m_Culture_before = CultureInfo.CurrentCulture.Name;
            m_Culture_Called = pCulture;
            m_LngId = m_Culture_Called.Substring(0, 2).ToLower();
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.CreateSpecificCulture(pCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(pCulture);

        }
        /********* new */
        public static String fncHtmlMenu(bool bRebuild, String Culture)
        {
            FncCulture(Culture);
            String szFulFileName = cls.cache.ClsCache.FncCacheFilePath(0, Culture, "menu");
            if (bRebuild) cls.ClsUtils.FncPathFileDelete(szFulFileName);
            if (cls.ClsUtils.FncPathFileExist(szFulFileName))
            {
                return cls.cache.ClsCache.FncCacheFileRead(szFulFileName);
            }
            else
            {
                String szHtml = FncHtmlBldMenu(Culture);
                cls.cache.ClsCache.FncCacheFileSave(ref szFulFileName, ref szHtml);
                return szHtml;
            }

        }
        private static void FncHtmlBldMenu_head(ref string szHtml)
        {
            szHtml += "<div class=\"container-fluid white\"> <div class=\"row white justify-content-center\">";
            szHtml += "<img class=\"logo\" src=\"/a_img/a_logos/testudines-org.svg\"/>";
        
            
            szHtml += "<span class=\"logotext\">TESTUDINES.ORG<br /> <span class=\"logotext-min\">Turtles & tortoises <br />Catalog project</span></span>";
            szHtml += "</div></div> \n";
        }
        private static void FncHtmlBldMenu_Start(ref string szHtml)
        {
            szHtml += "<nav class=\"navbar navbar-expand-md navbar-dark bg-dark\">";
            szHtml += "    <a class=\"navbar-brand\" href=\"#\"><img  src=\"/a_img/a_logos/mosca24.svg\" width=\"24\"/></a>";
            szHtml += "     <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\"#navbarsExample04\" aria-controls=\"navbarsExample04\" aria-expanded=\"false\" aria-label=\"Toggle navigation\">";
            szHtml += "     <span class=\"navbar-toggler-icon\"></span>";
            szHtml += "        </button>";
            szHtml += "        <div class=\"collapse navbar-collapse\" id=\"navbarsExample04\">";
        }
        private static void FncHtmlBldMenu_End(ref string szHtml)
        {
            //szHtml += "  <input class=\"form-control\" type=\"text\" placeholder=\"Search\" width=\"15em\">";
            szHtml += "</div>";
            szHtml += "</nav>";
        }
        private static void FncHtmlBldMenu_Items(ref string szHtml)
        {
            szHtml += "<ul class=\"navbar-nav mr-auto\">";
           // szHtml += "   <li class=\"nav-item active\">";
           // szHtml += "     <a class=\"nav-link\" href=\"#\"><img class=\"logo\" src=\"/a_img/a_logos/mosca24.svg\"/>2 <span class=\"sr-only\">(current)</span></a>";
           // szHtml += "     </li>";
            FncHtmlBldMenu_Items_Add_Tortoises(ref  szHtml);
            FncHtmlBldMenu_Items_Add_Articles(ref szHtml);
            FncHtmlBldMenu_Items_Add_Notices(ref szHtml);
            FncHtmlBldMenu_Items_Add_Others(ref szHtml);
            szHtml += "</ul>";
            FncHtmlBldMenu_Items_Add_Icons(ref szHtml);

          
        }
        private static void FncHtmlBldMenu_Items_Add_Tortoises(ref string szHtml)
        {

            szHtml += "    <li class=\"nav-item dropdown\">";
            szHtml += "       <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"mnTortoises\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">"+ Resources.Strings.Tortoises + "</a>";
            szHtml += "       <div class=\"dropdown-menu\" aria-labelledby=\"mnTortoises\">";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/tortoises-list\">" + Resources.Strings.mnTortoises_taxa_List + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/tortoises-taxonomy-list\">" + Resources.Strings.mnTortoises_taxonomy_list + "</a>";
            // szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/keys/keys-list\">" + Resources.Strings.mnTortoises_keys_list + "</a>";
            //szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/groups/groups-list\">" + Resources.Strings.mnTortoises_groups_list + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/foods/foods-list\">" + Resources.Strings.mnTortoises_foods_List + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/tortoises/images\">" + Resources.Strings.mnTortoises_mmedia + "</a>";

            szHtml += "        </div>";
            szHtml += "     </li>";
        }

        private static void FncHtmlBldMenu_Items_Add_Articles(ref string szHtml)
        {

            szHtml += "    <li class=\"nav-item dropdown\">";
            szHtml += "       <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"mnArticles\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">" + Resources.Strings.Articles + "</a>";
            szHtml += "       <div class=\"dropdown-menu\" aria-labelledby=\"mnArticles\">";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/\">" + Resources.Strings.mnArticlesAll + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/diseases\">" + Resources.Strings.mnArticlesDiseases + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/biology/\">" + Resources.Strings.mnArticlesBiology + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/caresheet/\">" + Resources.Strings.mnArticlesCare + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/conservancy_project/\">" + Resources.Strings.mnArticlesConservationProjects + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/articles/articles-list/art_society/\">" + Resources.Strings.mnArticlesArtsSociety + "</a>";
            szHtml += "        </div>";
            szHtml += "     </li>";
        }

      

        private static void FncHtmlBldMenu_Items_Add_Notices(ref string szHtml)
        {

            szHtml += "\n  <li class=\"nav-item\">";
            szHtml += "\n  <a class=\"nav-link\"  href=\"/" + m_LngId + "/notices/notices-list\">" + Resources.Strings.Notices + "</a>";
            szHtml += "\n  </li>";
        }

             
 private static void FncHtmlBldMenu_Items_Add_Others(ref string szHtml)
        {

            szHtml += "    <li class=\"nav-item dropdown\">";
            szHtml += "       <a class=\"nav-link dropdown-toggle\" href=\"#\" id=\"mnOthers\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">" + Resources.Strings.others + "</a>";
            szHtml += "       <div class=\"dropdown-menu\" aria-labelledby=\"mnOthers\">";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/images/\">" + Resources.Strings.images + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/ecozones/ecozones-list\">" + Resources.Strings.mnOthers_Ecozones + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/bibliography/bibliography-list\">" + Resources.Strings.mnOthers_Bibliographys + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/iucn/iucn-list\">" + Resources.Strings.mnOthers_iucn_list + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/acknowledgements/acknowledgements-list\">" + Resources.Strings.mnOthers_Acknowledgements_Acknoelegments_list + "</a>";
            szHtml += "\n                        <a class=\"dropdown-item\" href=\"/" + m_LngId + "/others/others-list\">" + Resources.Strings.mnOthers_OthesNoChelonians + "</a>";


            szHtml += "        </div>";
            szHtml += "     </li>";
        }


        private static void FncHtmlBldMenu_Items_Add_Icons(ref String szHtml)
        {

            szHtml += "\n            <ul class=\"navbar-nav ml-auto\">";
            szHtml += "\n                <li class=\"nav-item\"><a class=\"nav-link\" href=\"/about\">" + Resources.Strings.About + "</a></li>";
            szHtml += "\n                <li class=\"nav-item\"><a id=\"btnShowSearch\" class=\"nav-link \" href=\"#\" title=\"" + Resources.Strings.Search + "\">  <span class=\"glyphicon glyphicon-search white\"></span><span class=\"hidden-sm-up\">&nbsp;</span></a></li>";
            szHtml += "\n                <li class=\"nav-item\"><a id=\"btnShowMail\" class=\"nav-link \" href=\"#\" title=\"" + Resources.Strings.email + "\" data-href=\"/a_dlg/dlgmsgmail\" > <span class=\"glyphicon glyphicon-envelope white\"></span><span class=\"hidden-sm-up\">&nbsp;</span></a></li>";
            szHtml += "\n                <li class=\"nav-item\"><a id=\"btnAck\" class=\"nav-link \" href=\"/others/acknowledgements/acknowledgements\" title=\"" + Resources.Strings.Acknowledgements + "\"> <span class=\"glyphicon glyphicon-star white\"></span><span class=\"hidden-sm-up\">&nbsp;</span></a></li>";
            szHtml += "\n                <li class=\"nav-item\"><a id=\"btnShowLogin\" class=\"nav-link \" href=\"#\" title=\"" + Resources.Strings.Login + "\"> <span class=\"glyphicon glyphicon-user white\"></span><span class=\"hidden-sm-up\">&nbsp</span></a></li>";
            szHtml += "\n            </ul>";
        }






        //=================================================================================
        //=================================================================================
        //=================================================================================
        //=================================================================================
        //=================================================================================




      
      

    }
}