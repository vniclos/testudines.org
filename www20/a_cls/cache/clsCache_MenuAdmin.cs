using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;

namespace testudines.cls.cache
{
    public static class clsCache_MenuAdmin

    {
        private static String m_Culture_before = "";
        private static String m_Culture_Called = "";
        private static String m_LngId = "";
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


        public static String FncHtmlMenu(bool bRebuild, String Culture)
        {
            // si noes admin // redlocal devuelve vacio.
            if (!cls.ClsUtils.User_isAdmin()) { return ""; }
            FncCulture(Culture);
            String szFulFileName = cls.cache.ClsCache.FncCacheFilePath(0, Culture, "menuAdmin");
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
        private static String FncHtmlBldMenu(String Culture)
        {
            String szMenuAdm = "";
        
            szMenuAdm+= "<button class=\"btn-tiny\" type=\"button\" data-toggle=\"collapse\" data-target=\"#divMenuAdmin\" aria-expanded=\"false\" aria-controls=\"collapseExample\">  Menu Admin  </button><div class=\"collapse\" id=\"divMenuAdmin\">";

            szMenuAdm += "\n<div class=\"menu_simple\">";
            szMenuAdm += "<h3>Menu Administration</h3>";
            szMenuAdm += "\n<ul>";
          
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnTortoises_taxa_mng_list, Culture, "/tortoises/tortoises-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnTortoises_keys_mng_list, Culture, "/tortoises/keys/keys-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnTortoises_groups_mng_list, Culture, "/tortoises/keys/groups-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnTortoises_foods_foods_mng_list, Culture, "/tortoises/foods/foods-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnTortoises_appendixes_appendixes_mng_list, Culture, "/tortoises/appendixes/appendixes-mng-list");
            szMenuAdm += "<li><span class=\"separator\"></li>";
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnArticles_mng_list, Culture, "/articles/articles-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnNotices_mng_list, Culture, "/notices/notices-mng-list");

            szMenuAdm += "<li><span class=\"separator\"></li>";
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnOthers_Acknowledgements_Acknoelegment_mng_list, Culture, "/others/acknowledgements/acknowledgements-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnOthers_ecozones_mng_list, Culture, "/others/ecozones/ecozones-mng-list");
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnOthers_iucn_mng_list, Culture, "/others/iucn/iucn-mng-list");
          
            szMenuAdm += FncHtmlBldMenuAddItem(Resources.Strings.mnothers_others_mng_list, Culture, "/others/others/Others-mng-list");

            szMenuAdm += FncHtmlBldMenuAddItem("Cache", Culture, "/cache/cache-mng/");
            
            szMenuAdm += "\n</ul>";
            szMenuAdm += "</div></div>";


            return szMenuAdm;
        }

        private static String FncHtmlBldMenuAddItem (String pTitle, String pCulture, String pUrl)
        {
            String szItem = "<li><a href=\"/" + pCulture + pUrl + "\">" + pTitle + "</a></li>";
            return szItem;
        }


            //   ----------------------------------- -->
            //   ----------------------------------- -->
            //   ----------------------------------- -->
            //   ----------------------------------- -->

        }
    }
//   ----------------------------------- -->
//   ----------------------------------- -->
//   ----------------------------------- -->
//   ----------------------------------- -->
/*
 //https://www.codeply.com/go/q0b6ILuRyx/bootstrap-4-vertical-sidebar-nav-with-submenu

body, html {
    height: 100%;
}

#sidebar {
    min-width: 130px;
}
.nav-link[data-toggle].collapsed:after {
    content: "?";
}
.nav-link[data-toggle]:not(.collapsed):after {
    content: "?";
}






<div class="container-fluid h-100">
    <div class="row h-100">
        <div class="col-2 collapse d-md-flex bg-light pt-2 h-100" id="sidebar">
            <ul class="nav flex-column flex-nowrap">
                <li class="nav-item"><a class="nav-link" href="#">Overview</a></li>
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#submenu1" data-toggle="collapse" data-target="#submenu1">Reports</a>
                    <div class="collapse" id="submenu1" aria-expanded="false">
                        <ul class="flex-column pl-2 nav">
                            <li class="nav-item"><a class="nav-link py-0" href="">Orders</a></li>
                            <li class="nav-item">
                                <a class="nav-link collapsed py-1" href="#submenu1sub1" data-toggle="collapse" data-target="#submenu1sub1">Customers</a>
                                <div class="collapse" id="submenu1sub1" aria-expanded="false">
                                    <ul class="flex-column nav pl-4">
                                        <li class="nav-item">
                                            <a class="nav-link p-1" href="">
                                                <i class="fa fa-fw fa-clock-o"></i> Daily
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link p-1" href="">
                                                <i class="fa fa-fw fa-dashboard"></i> Dashboard
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link p-1" href="">
                                                <i class="fa fa-fw fa-bar-chart"></i> Charts
                                            </a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link p-1" href="">
                                                <i class="fa fa-fw fa-compass"></i> Areas
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                        </ul>
                    </div>
                </li>
                <li class="nav-item"><a class="nav-link" href="#">Analytics</a></li>
                <li class="nav-item"><a class="nav-link" href="#">Export</a></li>
            </ul>
        </div>
        <div class="col pt-2">
            <h2>
                <a href="" data-target="#sidebar" data-toggle="collapse" class="d-md-none"><i class="fa fa-bars"></i></a>
                Content
            </h2>
            <h6 class="hidden-sm-down">Shrink page width to see sidebar collapse</h6>
            <p>3 wolf moon retro jean shorts chambray sustainable roof party. Shoreditch vegan artisan Helvetica. Tattooed Codeply Echo Park Godard kogi, next level irony ennui twee squid fap selvage. Meggings flannel Brooklyn literally small batch, mumblecore
                PBR try-hard kale chips. Brooklyn vinyl lumbersexual bicycle rights, viral fap cronut leggings squid chillwave pickled gentrify mustache. 3 wolf moon hashtag church-key Odd Future. Austin messenger bag normcore, Helvetica Williamsburg
                sartorial tote bag distillery Portland before they sold out gastropub taxidermy Vice.</p>
        </div>
    </div>
</div>

     
     
     */
