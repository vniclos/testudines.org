using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;

namespace testudines.cls.cache
{
    public class ClsCache_Tortoise
    {
        private cls.tools.ClsGalleryFBox oFB = new cls.tools.ClsGalleryFBox();
        cls.bbdd.ClsReg_tdoclng_media oReg_Media = new cls.bbdd.ClsReg_tdoclng_media();
       

        private string m_EspecieName = "";

        //private string m_HtmlBoxResumen = "";
        // private string m_HtmlBoxResumenShort = "";
        private string m_LastUpdate = "";
        String m_UrlTemplate = "";
        private UInt64 m_IdDoc = 0;
        private string m_IdLng = "";
        //  string szHtmlIucnImg = "";
        // TODO QUITAR Y SUSTITUIR POR

        // enum cls.ClsGlobal.E_TortoiseChapters { Abstract, Description, natural_history, Distribution, Care, Ecology, KeysIdentification, Taxonomy, identification, Bibliography, Notes, Gallery, ToDo, Old, NearSpecies }
        private cls.cache.ClsCache_Reg_tdoclng_testudines oRegCache = new cls.cache.ClsCache_Reg_tdoclng_testudines();
        private cls.bbdd.ClsReg_tdoclng_testudines_all oRegFul = new cls.bbdd.ClsReg_tdoclng_testudines_all();
        private cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        private cls.bbdd.ClsReg_tdoclng oRegDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();
        //  private string m_VulgarName = "";
        private cls.bbdd.ClsReg_tdoclng_testudines_taxa_all oRegTxAll = new cls.bbdd.ClsReg_tdoclng_testudines_taxa_all();
        //private cls.bbdd.ClsReg_tdoclng_testudines_abst oRegTxLngAbs = new cls.bbdd.ClsReg_tdoclng_testudines_abst();
        private cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
        private cls.bbdd.ClsReg_tdoclng_testudinesgroups oRegGrp = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
        private cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oRegKeyNode = new cls.bbdd.ClsReg_tdoclng_testudineskeys_lng();


        private cls.tools.ClsAccordion_dl m_oAccordion = new cls.tools.ClsAccordion_dl();
        private const string m_DivImgRight200_start = "\n<div style=\"float:right;  width:200px ; min-width:200px; margin-left:1em; display:inline-block; \">\n ";
        private const string m_DivImgRight200_end = "\n</div>";

        private const string m_DivRow5_Start = "\n<div class=\"large-5 column\">\n";
        private const string m_DivRow7_Start = "\n<div class=\"large-7 column\">\n";
        private const string m_DivRow7_End = "\n</div>";
        private const string m_DivRow5_End = "\n</div>";

        private const string m_DivRow_Start = "\n\n\n<div class=\"row\">\n <div class=\"large-12 columns\">\n";
        private const string m_DivRow_End = "\n</div>\n</div>\n";
        private const string m_DivRow_EndStart = m_DivRow_End + m_DivRow_Start;
        private const string m_gotop = "<a href=\"#ind_gotop\" class=\"gotop\" alt=\"go top\" title=\"Go top\"><img src=\"/a_img/a_site/ico16/gotop.gif\" title=\"go top\" alt=\"gotop\"></a>";
        // private string m_DivRow_EndStart = "";

        private string m_NameSpecieWithVulgar = "";
        public ClsCache_Tortoise()
        {
            //   m_DivRow_EndStart = m_DivRow_End + m_DivRow_Start;


        }
        public void FncRebuildCache(bool bRebuildListLasUpdates)
        {
            Fnc_calc_m_LastUpdate();
            if (bRebuildListLasUpdates) { cls.cache.ClsCache_Tortoise_Last.FncCache_GET(true, 10); }

            FncHtmlSummary(true); // capitule 1
            FncHtmlDescription(true); // capitule 2
            FncHtmLNatu_history(true); // capitule 3 
            FncHtmlRngHabitatRange(true); // capitule 4
            FncHtmlRngHabitatEcologyClimate(true); // capitule 5
            FncHtmlCare(true);
            FncHtmlTaxonony(true); //  capitule 7
            FncHtmlIdentificationKeys(true); // Chapter 8
            FncHtmlNearSpecies(true); // capitule 9
            FncHtmlGallery(true, 1);
            FncHtmlbibliography(true);
            FncHtmlNotes(true);
            /*

      

            
            FncHtmlNotes(true);
            FncHtmlRngHabitatEcologyClimate(true);
          
            //FncHtmlGallery(true, 1);
          
           
           
         
            */

        }


        //====================================================================
        //====================================================================



        public bool FncSqlFindTaxon_ful_html(UInt64 IdDoc, String IdLng)
        {
            m_IdDoc = IdDoc;
            m_IdLng = IdLng;
            m_UrlTemplate = cls.ClsHtml.FncUrlTitle(ref m_IdDoc, ref m_IdLng);
            bool b = true;
            b = oRegDoc.FncSqlFind(IdDoc);
            b = oRegDocLng.FncSqlFind(IdDoc, IdLng);
            b = oRegFul.FncSqlFind(IdDoc, IdLng);
            m_EspecieName = oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ": ";
            m_NameSpecieWithVulgar = oRegFul.oRegTaxaAll.ATaxNameVulgarEN +", "+ oRegFul.oRegTaxaAll.ATaxNameVulgarEN + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";

            return b;
        }


        //================================================================
        //================================================================
        //            1 SUMARY
        //================================================================
        //================================================================


        public string FncHtmlSummary(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.summary.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlSummaryBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }
        private String FncHtmlSummaryBld()
        {
            // TODO REHCIENDO ABSTACT
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";
            string szUrlMed = "";

            // 1 Cabecera titulo
            //-----------------
         
            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter01_00Abs, oRegFul.oRegTaxaAllFile.ADesImg_DesType01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.summary);
            //-----------------
            // 3 Contenido
            //------------

            m_oAccordion.Init("AccAbs");
            szSecctionTit += Resources.Strings.ind_Chapter01_01AbsDes;
            string szImgIUCN = "<span class=\"imgright\">" + FncTool_BldHtmlBoxIUCN() + "</span>";
            szSecction += szImgIUCN + oRegFul.oRegDesc.LDesAbstract;
            
            szSecction += "<br/>" + Resources.Strings.ADesMeasureLenghtCm + "&#177;" + oRegFul.oRegDescAll.ADesMeasureLenghtCm.ToString();
            szSecction += "cm. Max: " + Resources.Strings.ADesMeasureLenghtCm + "&#177;" + oRegFul.oRegDescAll.ADesMeasureLenghtCmMax.ToString() + "cm."; ;
            szSecction += "<br/>" + Resources.Strings.ADesMeasureWeightGrm + "&#177;" + oRegFul.oRegDescAll.ADesMeasureWeightGrm.ToString();
            szSecction += "gr. Max: " + Resources.Strings.ADesMeasureWeightGrm + "&#177;" + oRegFul.oRegDescAll.ADesMeasureWeightGrmMax.ToString()+"gr.";
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            // absabsHis -----------------------------
            szUrlMed = m_UrlTemplate + cls.ClsGlobal.E_TortoiseChapters.natural_history.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Chapter01_02AbsNat + "\">";
            szSecctionTit = Resources.Strings.ind_Chapter01_02AbsNat;
            szSecction = oFB.FncHtmlAloneRowPhotoFB_med(oRegFul.oRegTaxaAllFile.AAbsImg_HNatural, m_EspecieName + " Natural live", "ind_Chapter01_02AbsNat");
            //szSecction = FncBldHtmlImgMedAlone(oRegFul.oRegTaxaAllFile.AAbsImg_HNatural,m_NameSpecieWithVulgar, "bot");

            szSecction += oRegFul.oRegNatu.LNatuAsbstract;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            // absabsRangHabitat -----------------------------
            szUrlMed = m_UrlTemplate + cls.ClsGlobal.E_TortoiseChapters.distribution.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Chapter01_02AbsNat + "\">";
            szSecctionTit = Resources.Strings.ind_Chapter01_03AbsRng;
            //szSecction = FncBldHtmlImgMedAlone(oRegFul.oRegTaxaAllFile.AAbsImg_Range, m_NameSpecieWithVulgar, "bot");

            szSecction = oFB.FncHtmlAloneRowPhotoFB_med(oRegFul.oRegTaxaAllFile.AAbsImg_Range, m_EspecieName + " Range distribution", "ind_Chapter01_03AbsRng");
            //imagen de clima
            oRegEco.FncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerKeys);
            szUrlMed = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerKeys;
            szSecction += "<div class=\"row\">" + m_DivImgRight200_start;
            szSecction += FncBldHtmlPretyPhotoIframeAlone("iframeClimate", szUrlMed, oRegEco.ImgRainTemp, "Help", "Climate rain temp");
            szSecction += m_DivImgRight200_end;
            szSecction += oRegFul.oRegGeo.LGeoAbstract + "</div>";
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            // Gallery------------------------------------
            szSecction = "";



            try
            {
                string szPathImgs = ClsGlobal.DirRoot + oRegFul.oRegOthAll.AOth_UrlImages;

                string[] ListFiles = System.IO.Directory.GetFiles(szPathImgs, "*minx.jpg");

                long listFileCount = ListFiles.LongLength;
                long iMax = 6;
                if (listFileCount < 6) iMax = listFileCount;
                string imgUrl = "";
                StringCollection pImgCollection = new StringCollection();

                // numeros al azar para seleccionar las imagenes
                Random oRandon = new Random(DateTime.Now.Millisecond);
                int iRandon = 0;
                int[] iItem = { -1, -1, -1, -1, -1, -1 };
                bool bRepite = true;
                int iLoopMaxCount = 9;
                int IloopCount = 0;
                if (iMax >= 0)
                {
                    for (long i = 0; i < iMax; i++)
                    {
                        // calcular entero no repetido en array iItem
                        bRepite = true;
                        while (bRepite)
                        {
                            IloopCount++;
                            iRandon = oRandon.Next(0, (int)listFileCount - 1);
                            for (int iRep = 0; iRep < i; iRep++)
                            {
                                if (iItem[iRep] == iRandon)
                                {
                                    bRepite = true;
                                }
                                else
                                {
                                    iItem[i] = iRandon;
                                    iRep = (int)iMax + 1;
                                }
                                if (iLoopMaxCount < IloopCount) bRepite = false;
                            }
                            bRepite = false;
                        }
                        imgUrl = ListFiles[iRandon].Replace(ClsGlobal.DirRoot, "").Replace("\\", "/");
                        pImgCollection.Add(imgUrl);
                    }
                }
                string szText = Resources.Strings.ind_Chapter01_10absGalIntro.Replace("#999#", listFileCount.ToString());
                szText = szText.Replace("#specie#", m_EspecieName);
                string szimageslink = m_UrlTemplate + cls.ClsGlobal.E_TortoiseChapters.images.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Chapter09_00Near + "\">" + Resources.Strings.images + " " + m_EspecieName + "</a>";
                szText = szText.Replace("#imageslink#", szimageslink);





                szUrlMed = m_UrlTemplate + cls.ClsGlobal.E_TortoiseChapters.summary.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Chapter10_00Gal + "\">";

                string pGallId = "IdGallAbst";
                string pGallTit = oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie;
                string pTitBot = pGallTit;
                string pTitTop = pGallTit + "," + oRegFul.oRegTaxaAll.ATaxGrpL2282Authority + " " + oRegFul.oRegTaxaAll.ATaxGrpL2283Year;

                szSecctionTit = Resources.Strings.ind_Chapter01_06AbsGal;
                szSecction = szText;
                szSecction += FncBldPhotoList(pGallId, pGallTit, pTitTop, pTitBot, ref pImgCollection, "Chapter01_10absGalIntro");
                //szSecction += "</div>";
                m_UrlTemplate = oRegFul.oRegOthAll.AOth_UrlImages;


                szSecction += FncTool_BldReadMore(cls.ClsGlobal.E_TortoiseChapters.images.ToString().ToLower(), Resources.Strings.ind_Chapter01_06AbsGal);
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            }
            catch { }
            //----------------- fin galleria
            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;


            return szHtml;
        }
        //================================================================
        //================================================================
        //             2 DESCRIPTION
        //================================================================
        //================================================================

        public string FncHtmlDescription(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.description.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlDescriptionBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        private String FncHtmlDescriptionBld()
        {
            // TODO REHCIENDO DESCRIPCION
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";
            string szUrlMed = "";

            // 1 Cabecera titulo
            //-----------------
            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter02_00Des, oRegFul.oRegTaxaAllFile.ADesImg_DesType02);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.description);
            //-----------------
            // 3 Contenido
            //------------

            m_oAccordion.Init("AcDesc");
            string szImgHelpMin = "";
            string szImgHelpBig = "";



            string szHtmlszHtmlLeft = "";


            szSecctionTit = Resources.Strings.ind_Chapter02_01desAbs;
            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ADesImg_DesType01,
            oRegFul.oRegTaxaAllFile.ADesImg_DesType02,
            oRegFul.oRegTaxaAllFile.ADesImg_DesType03,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "Chapter02_01desAbs");

            //szSecction = FncBldHtmlImgMedAlone(oRegFul.oRegTaxaAllFile.AAbsImg_HNatural, szName, "bot");
            szSecction += Resources.Strings.ADesMeasureLenghtCm + ": " + oRegFul.oRegDescAll.ADesMeasureLenghtCm.ToString() + "&equiv;";
            szSecction += " "+Resources.Strings.Max + ": " + oRegFul.oRegDescAll.ADesMeasureLenghtCmMax.ToString() + "&equiv;";

            szSecction += "<br/>" + Resources.Strings.ADesMeasureWeightGrm + ": " + oRegFul.oRegDescAll.ADesMeasureWeightGrm.ToString() + "&equiv;";
            szSecction += " " + Resources.Strings.Max + ": " + oRegFul.oRegDescAll.ADesMeasureWeightGrmMax.ToString() + "&equiv;";
            szSecction += "<br/>" + oRegFul.oRegDesc.LDesAbstract.ToString();

            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //--------------------------------------------------------
            /* DESCRIPCION DORSAL */
            szSecctionTit = Resources.Strings.ind_Chapter02_02DesDors;
            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ADesImg_BodyDorsal01,
            oRegFul.oRegTaxaAllFile.ADesImg_BodyDorsal02,
            oRegFul.oRegTaxaAllFile.ADesImg_BodyDorsal03,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_02DesDors");


            szImgHelpMin = "/a_img/hlp_descr/view_dorsal_off.png";
            szImgHelpBig = "/a_img/hlp_descr/view_dorsal_on.png";
            szSecction += FncBldHtmlSectionImgHelp(szImgHelpMin, szImgHelpBig, "DivDorsalHlp", "", oRegFul.oRegDesc.LDesViewDorsalShape);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION FRONTAL */

            szSecctionTit = Resources.Strings.ind_Chapter02_03DesFrontal;
            szSecction = FncBldHtmlPretyPhoto3(
               "imageslist",
               oRegFul.oRegTaxaAllFile.ADesImg_BodyFrontal01,
               oRegFul.oRegTaxaAllFile.ADesImg_BodyFrontal02,
               oRegFul.oRegTaxaAllFile.ADesImg_BodyFrontal03,
               oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
              oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_03DesFrontal");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_frontal.png", oRegFul.oRegDesc.LDesViewFrontal);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION LATERAL */
            szSecctionTit = Resources.Strings.ind_Chapter02_04DesLateral;
            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_BodyLateral01,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyLateral02,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyLateral03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_04DesLateral");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_lateral.png", oRegFul.oRegDesc.LDesViewLateral);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //--------------------------------------------------------
            /* DESCRIPCION POSTERIOR */

            szSecctionTit = Resources.Strings.ind_Chapter02_05DesRear;
            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_BodyRear01,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyRear02,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyRear03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_05DesRear");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_rear.png", oRegFul.oRegDesc.LDesViewRear);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION VENTRAL y puente */

            szSecctionTit = Resources.Strings.ind_Chapter02_06DesVentralBridge;

            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ADesImg_BodyVentral01,
            oRegFul.oRegTaxaAllFile.ADesImg_BodyVentral02,
            oRegFul.oRegTaxaAllFile.ADesImg_BodyVentral03,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_06DesVentral");
            szSecction += FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_BodyBridge01,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyBridge02,
             oRegFul.oRegTaxaAllFile.ADesImg_BodyBridge03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_07DesBridge");


            szImgHelpMin = "/a_img/hlp_descr/view_ventral_off.png";
            szImgHelpBig = "/a_img/hlp_descr/view_ventral_on.png";
            szSecction += FncBldHtmlSectionImgHelp(szImgHelpMin, szImgHelpBig, "divIdVentralHlp", "", oRegFul.oRegDesc.LDesViewVentralBridgeShape);

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION CABEZA Y CUELLO */
            szSecctionTit = Resources.Strings.ind_Chapter02_07DesHeadNeck;
            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_OtherHead01,
             oRegFul.oRegTaxaAllFile.ADesImg_OtherHead02,
             oRegFul.oRegTaxaAllFile.ADesImg_OtherHead03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_08DesHeadNeck");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_head.png", oRegFul.oRegDesc.LDesViewHeadNeckShape);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION PATAS  */

            szSecctionTit = Resources.Strings.ind_Chapter02_08DesLegsTail;

            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ADesImg_OtherLegs01,
            oRegFul.oRegTaxaAllFile.ADesImg_OtherLegs02,
            oRegFul.oRegTaxaAllFile.ADesImg_OtherLegs03,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_09DesLegs");
            szSecction += FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_OtherTail01,
             oRegFul.oRegTaxaAllFile.ADesImg_OtherTail02,
             oRegFul.oRegTaxaAllFile.ADesImg_OtherTail03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_10DesTail");

            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_legs.png", oRegFul.oRegDesc.LDesViewLegsTailShape);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION CRIAS */

            szSecctionTit = Resources.Strings.ind_Chapter02_09DesBabies;

            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_BabyDorsal01,
             oRegFul.oRegTaxaAllFile.ADesImg_BabyDorsal02,
             oRegFul.oRegTaxaAllFile.ADesImg_BabyDorsal03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_11DesBabies");
            szSecction += FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_BabyVentral01,
             oRegFul.oRegTaxaAllFile.ADesImg_BabyVentral02,
             oRegFul.oRegTaxaAllFile.ADesImg_BabyVentral03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_11DesBabies");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_babys.png", oRegFul.oRegDesc.LDesBabysShape);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //--------------------------------------------------------
            /* DESCRIPCION DIMORFISMO SEXUAL */

            szSecctionTit = Resources.Strings.ind_Chapter02_10DesDimor;
            szSecction = FncBldHtmlPretyPhoto3(
               "imageslist",
               oRegFul.oRegTaxaAllFile.ADesImg_Dimorphism01,
               oRegFul.oRegTaxaAllFile.ADesImg_Dimorphism02,
               oRegFul.oRegTaxaAllFile.ADesImg_Dimorphism03,
               oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
               oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_12DesDimor");
            szSecction += FncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_dimorphism.png", oRegFul.oRegDesc.LDesDimorphism);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION DIFERECIAS  */
            szSecctionTit = Resources.Strings.ind_Chapter02_11DesDifer;
            szSecction = oRegFul.oRegDesc.LDesDiferentiation;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //--------------------------------------------------------
            /* DESCRIPCION HOLOTIPO  */

            szSecctionTit = Resources.Strings.ind_Chapter02_12DesHoloty;
            szHtmlszHtmlLeft += FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ADesImg_Holotype01,
             oRegFul.oRegTaxaAllFile.ADesImg_Holotype02,
             oRegFul.oRegTaxaAllFile.ADesImg_Holotype03,
              oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded + ". " + Resources.Strings.scnADesImg_Holotype,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter02_14DesHoloty");
            szSecction += oRegFul.oRegDesc.LDesHolotype;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION HOLOTIPO  */


            szSecctionTit = Resources.Strings.ind_Chapter02_13DesNotes;
            szSecction += oRegFul.oRegDesc.LDesNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            //--------------------------------------------------------
            /* MENU CON OPCION SELECCIONADA */



            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;


            return szHtml;
        }

        //================================================================
        //================================================================
        //             3 HISTORIA NATURAL
        //================================================================
        //================================================================

        public string FncHtmLNatu_history(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.natural_history.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmLNatu_historyBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        private string FncHtmLNatu_historyBld()
        {
            // TODO REHCIENDO ABSTACT
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter03_00Nat, oRegFul.oRegTaxaAllFile.ANatImg_Live01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
            m_oAccordion.Init("AcHisNat");
         


            //  ---------------------------------------------
            // - AbsNatural -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter03_01NatLiveStyles;
            szSecction = FncBldHtmlPretyPhoto3(
               "imageslist",
               oRegFul.oRegTaxaAllFile.ANatImg_Live01,
               oRegFul.oRegTaxaAllFile.ANatImg_Live02,
               oRegFul.oRegTaxaAllFile.ANatImg_Live03,
               oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
               oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter03_01Nattintro");

            string szAKeyNaturalMedia = FncCultureGetString(oRegFul.oRegNatuAll.ANatuKeyMedia);
            string szAKeyNaturalFood = FncCultureGetString(oRegFul.oRegNatuAll.ANatuKeyFood);
            string szAKeyNaturalBreeding = FncCultureGetString(oRegFul.oRegNatuAll.ANatuKeyBreeding);

            szSecction += FncTool_BldHtmlTaxTitleValue(Resources.Strings.AKeyNaturalMedia, szAKeyNaturalMedia);
            szSecction += FncTool_BldHtmlTaxTitleValue(Resources.Strings.AKeyNaturalFood, szAKeyNaturalFood);
            szSecction += FncTool_BldHtmlTaxTitleValue(Resources.Strings.AKeyNaturalBreeding, szAKeyNaturalBreeding);
            szSecction += oRegFul.oRegNatu.LNatuAsbstract;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //  ---------------------------------------------
            // - Abs MEDIO -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter03_02NatMediaType;

            szSecction = oRegFul.oRegNatu.LNatuMediaType;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //  ---------------------------------------------
            // - Abs HISTORIA NATURAL -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter03_01NatLiveStyles;
            szSecction = oRegFul.oRegNatu.LNatuLifestyles;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //  ---------------------------------------------
            // - Abs HISTORIA NATURAL -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter03_03LNatFoodChain;
            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ANatImg_Food01,
             oRegFul.oRegTaxaAllFile.ANatImg_Food02,
             oRegFul.oRegTaxaAllFile.ANatImg_Live03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter03_04NatFoo");
            szSecction += oRegFul.oRegNatu.LNatuFoodChain;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //  ---------------------------------------------
            // - Abs HISTORIA REPRODUCCION -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter03_04NatBreeding;
            szSecction = FncBldHtmlPretyPhoto3(
             "imageslist",
             oRegFul.oRegTaxaAllFile.ANatImg_Breeding01,
             oRegFul.oRegTaxaAllFile.ANatImg_Breeding02,
             oRegFul.oRegTaxaAllFile.ANatImg_Breeding03,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter03_05NatBree");
            szSecction += oRegFul.oRegNatu.LNatuBreeding;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            ////  ---------------------------------------------
            //// - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter03_05NatDanger;
            szSecction = oRegFul.oRegNatu.LNatuDangers;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            ////  ---------------------------------------------
            //// - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter03_06NatProActions;
            szSecction = oRegFul.oRegNatu.LNatuProAction;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            /*

             //--------------------------
             szHtmlszHtmlLeft += m_DivRow_Start;
             szHtmlszHtmlLeft += "<h2>" + Resources.Strings.ind_Chapter03_07Natnot +  m_gotop + "</h2>";

             ;
             szHtmlszHtmlLeft += oRegFul.oRegNatu.LNatuNotes;
             szHtmlszHtmlLeft += m_DivRow_End;
             */

            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;
          
            return szHtml;
        }


        //================================================================
        //================================================================
        //            4 HISTORIA RANGE DISTRIBUTION
        //================================================================
        //================================================================

        public string FncHtmlRngHabitatRange(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.distribution.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlRngHabitatRangeBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }
        private string FncHtmlRngHabitatRangeBld()
        {
        

            // TODO REHCIENDO range
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter04_00_00_BioGeographic, oRegFul.oRegTaxaAllFile.ANatImg_Live01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
            m_oAccordion.Init("AcHisNat");

            m_oAccordion.Init("AcRange");
         

          
            // -------------------------------------------------
     
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            string szHtmlszHtmlLeft = ""; ;
            szHtmlszHtmlLeft += m_DivRow_Start;
;

            //  ---------------------------------------------
            // - Abs range -----------------------------------
            szSecctionTit = Resources.Strings.ind_Chapter04_00_00_BioGeographic;
            szSecction = oRegFul.oRegGeoAll.AGeoPoliContinentKeys + " ";
            szSecction += oRegFul.oRegGeo.LGeoPoliCountriesNames;
            
            szSecction += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFul, "World Map of " + m_EspecieName, "bot");
            szSecction += cls.ClsUtils.FncGetContinentNamesFromCodes(oRegFul.oRegGeoAll.AGeoPoliContinentKeys, oRegFul.DocLngId) + " (" + cls.ClsUtils.FncCountryFromCodes(oRegFul.oRegGeoAll.AGeoPoliCountriestKeys, "en") + ")</br>";
            szSecction += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardDetailFul, "Countyr  Map of " + m_EspecieName, "bot");
            szSecction += oRegFul.oRegGeo.LGeoPoliCountriesNames;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //  ---------------------------------------------
            // - Abs range world-----------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter04_00_00_BioGeographic;



            //  ---------------------------------------------
            // - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms;
            szSecction = "";

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            //  ---------------------------------------------
            // - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter04_00_00_BioGeographic;
            szSecction = "";

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


           
            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;
            
            return szHtml;







        }

        //================================================================
        //================================================================
        //            5 HISTORIA RANGE ecologia clima
        //================================================================
        //================================================================


        public string FncHtmlRngHabitatEcologyClimate(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.ecology.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlRngHabitatEcologyClimateBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }
        private string FncHtmlRngHabitatEcologyClimateBld()
        {


            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms, oRegFul.oRegTaxaAllFile.AGeoImg_landscapes01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
           

               
           
                m_oAccordion.Init("AcClimate");
               

       
                ////--------------------------

                string sz = "";
                string szUrl = "";
                //cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
                oRegEco.FncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerImage);


                //  ---------------------------------------------
                // - Abs climate detail --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_01_01_GeoRngWallace;
                szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerImage;

                szSecction = m_DivImgRight200_start + FncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone") + "</div>";
                szSecction += oRegFul.oRegGeo.LGeoClimateTableLocation;
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



                //  ---------------------------------------------
                // - Abs biotopo detail --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms;
                // szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegGeoAll.AGeoKeyClimateEcozone;

                // szSecction = m_DivImgRight200_start + FncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone") + "</div>";
                szSecction = FncBldHtmlPretyPhoto3(
                 "imageslist",
                 oRegFul.oRegTaxaAllFile.AGeoImg_landscapes01,
                 oRegFul.oRegTaxaAllFile.AGeoImg_landscapes02,
                 oRegFul.oRegTaxaAllFile.AGeoImg_landscapes03,
                 oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
                 oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter04_02_01_AGeoKeyBiogeographicRealms");
                string szImg = "<img src=\"" + oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerImage + "\" name=\"" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + " Climate koppen" + "\">";
                szSecction += szImg;
            szSecction += oRegFul.oRegGeo.LGeoBioWWFRealmsNames;
            if (oRegFul.oRegGeo.LGeoBioWWFRegionNames != "") { szSecction += oRegFul.oRegGeo.LGeoBioWWFRegionNames; }

            szSecction += sz; // FncBldHtmSecction(Resources.Strings.AGeoEcozoneClimateKey, sz);

                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



                //  ---------------------------------------------
                // - Abs climatetype detail --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_01_03_GeoRngLocationType;
                szSecction = oRegFul.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardKoppenFul;

                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

                //  ---------------------------------------------
                // - Abs climatetype temperatura --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_04_01_GeoClimateTableLocation;
            szSecction = FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp, "Temp. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");

                sz = "";
                sz += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp, "Temp. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");
                sz += "<br><table width=\"90%\">";
                sz += "\n <thead><tr><td colspan=\"7\">Temperaturas medias mensuales</td></tr></thead>";
                sz += "\n <thead><tr><td>MM</td><td>01</td><td>02</td><td>03</td><td>04</td><td>05</td><td>06</td></tr></thead>";
                sz += "<tr><td>ºC Max</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax01.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax02.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax03.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax04.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax05.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax06.ToString() + "</td></tr>";
                sz += "<tr><td>ºC Med</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg01.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg02.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg03.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg04.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg05.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg06.ToString() + "</td></tr>";
                sz += "<tr><td>ºC Min</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin01.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin02.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin03.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin04.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin05.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin06.ToString() + "</td></tr>";
                sz += "</tbody><thead><tr><td>MM</td><td>07</td><td>08</td><td>09</td><td>10</td><td>11</td><td>12</td></tr></thead>";
                sz += "<tbody><tr><td>ºC Max</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax07.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax08.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax09.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax10.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax11.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMax12.ToString() + "</td></tr>";
                sz += "<tr><td>ºC Med</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg07.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg08.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg09.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg10.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg11.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpAvg12.ToString() + "</td></tr>";
                sz += "<tr><td>ºC Min</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin07.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin08.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin09.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin10.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin11.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoTmpMin12.ToString() + "</td></tr>";
                sz += "</tbody></table>";
                szSecction = sz;
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



                //  ---------------------------------------------
                // - Abs climatetype temperatura --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_04_04_GeoTableRainML;
                szSecction = FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp, "Temp. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");

                sz = "";
                sz += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherRain, "Rain " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");
                sz += "<br><table width=\"90%\">";
                sz += "\n <thead><tr><td colspan=\"7\">Temperaturas medias mensuales</td></tr></thead>";
                sz += "<thead<tr><td>MM</td><td>01</td><td>02</td><td>03</td><td>04</td><td>05</td><td>06</td></tr></thead";
                sz += "<tbody><tr><td>ML</td><td>" + oRegFul.oRegGeoAll.AGeoRainML01.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML02.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML03.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML04.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML05.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML06.ToString() + "</td></tr>";
                sz += "<tr><td>Days</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays01.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays02.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays03.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays04.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays05.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays06.ToString() + "</td></tr></tbody>";
                sz += "<thead><tr><td>MM</td><td>07</td><td>08</td><td>09</td><td>10</td><td>11</td><td>12</td></tr></thead>";
                sz += "<tbody><tr><td>ML</td><td>" + oRegFul.oRegGeoAll.AGeoRainML07.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML08.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML09.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML10.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML11.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainML12.ToString() + "</td></tr>";
                sz += "<tr><td>Days</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays07.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays08.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays09.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays10.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays11.ToString() + "</td><td>" + oRegFul.oRegGeoAll.AGeoRainDays12.ToString() + "</td></tr></tbody>";
                sz += "</table>";
                szSecction = sz;
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


                //  ---------------------------------------------
                // - Abs climatetype insolacion  --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_04_04_GeoTableSun;
                szSecction = FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp, "Temp. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");

                sz = "";
                sz = Resources.Strings.AGeoLocLatitudMax + "= " + oRegFul.oRegGeoAll.AGeoLocLatitudMax.ToString() + "º " + Resources.Strings.AGeoLocLatitudMin + "=" + oRegFul.oRegGeoAll.AGeoLocLatitudMin.ToString() + "º<br/>";
                sz += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherSun, "Sun hours " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");
                szSecction = sz;
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


                //  ---------------------------------------------
                // - Abs climatetype biome  --------------------------------

                szSecctionTit = Resources.Strings.ind_Chapter04_03_01_GeoClimateFao;
                szSecction = FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp, "Temp. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");

                sz = "";
                sz += FncBldHtmlImgCenter(oRegFul.oRegTaxaAllFile.AGeoImg_ClimateWheatherBiome, "Biome. " +oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "");
                szSecction = sz;
                m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;
               

                return szHtml;

            



        }
        //================================================================
        //================================================================
        //            6 Cuidados
        //================================================================
        //================================================================

        public string FncHtmlCare(bool bCacheRebuild)
        {

            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.care.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlRngHabitatEcologyClimateBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlCareBld(bool bCacheRebuild)
        {

            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter06_00Car, oRegFul.oRegTaxaAllFile.ACareImg_Breeding01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------





            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------
            m_oAccordion.Init("accare");

            string szUrl = "";

       

            //........................................................................................
            // care abstract
            //..................
            //   szUrlMed = szUrlIni + cls.ClsGlobal.E_TortoiseChapters.care.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Chapter01_02AbsNat + "\">";
            szSecctionTit = Resources.Strings.ind_Chapter06_01CarIntro;
            szSecction = FncBldHtmlPretyPhoto3(
              "imageslist",
              oRegFul.oRegTaxaAllFile.ACareImg_gral01,
              oRegFul.oRegTaxaAllFile.ACareImg_gral02,
              oRegFul.oRegTaxaAllFile.ACareImg_gral03,
              oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter06_01CarIntro");
            szSecction += oRegFul.oRegDesc.LDesAbstract;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);
            //........................................................................................
            //.................. care values
            szSecctionTit = Resources.Strings.ind_Chapter06_02CarValues;
            oRegEco.FncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerKeys);
            szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegGeoAll.AGeoClimateKoppenGeigerKeys;
            szSecction = FncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone");
            szSecction += oRegFul.oRegCare.LCareValues;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care food
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_03CarFoods;
            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ACareImg_Food01,
            oRegFul.oRegTaxaAllFile.ACareImg_Food02,
            oRegFul.oRegTaxaAllFile.ACareImg_Food03,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter06_03CarFoods");
            szSecction += oRegFul.oRegCare.LCareFood;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care breeding
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_04CarBreeding;
            szSecction = FncBldHtmlPretyPhoto3(
            "imageslist",
            oRegFul.oRegTaxaAllFile.ACareImg_Breeding01,
            oRegFul.oRegTaxaAllFile.ACareImg_Breeding02,
            oRegFul.oRegTaxaAllFile.ACareImg_Breeding03,
            oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter06_04CarBreeding");
            szSecction += oRegFul.oRegCare.LCareBreeding;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //........................................................................................
            //.................. care vivarium indoor
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_05CarVivariumIndoor;
            szSecction = FncBldHtmlPretyPhoto3(
              "imageslist",
              oRegFul.oRegTaxaAllFile.ACareImg_VivariumIndoor01,
              oRegFul.oRegTaxaAllFile.ACareImg_VivariumIndoor02,
              oRegFul.oRegTaxaAllFile.ACareImg_VivariumIndoor03,
              oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
             oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter06_05CarVivariumIndoor"); ;
            szSecction += oRegFul.oRegCare.LCareVivariumIndoor;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care vivarium outdoor
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_06CarVivariuminOut;
            szSecction = FncBldHtmlPretyPhoto3(
        "imageslist",
           oRegFul.oRegTaxaAllFile.ACareImg_VivariumOutdoor01,
           oRegFul.oRegTaxaAllFile.ACareImg_VivariumOutdoor02,
           oRegFul.oRegTaxaAllFile.ACareImg_VivariumOutdoor03,
           oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded,
          oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter06_06CarVivariuminOut");
            szSecction += oRegFul.oRegCare.LCareVivariumOutdoor;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care care notes
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_07CarNotes;
            szSecction = oRegFul.oRegCare.LCareNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care vivarium specialist
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter06_08CarSpecialists;
            szSecction = oRegFul.oRegCare.LCareEspecialist;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //-------------------------------------------------------------------------
            // write and return
          
            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate ;
          

            return szHtml;
        }

        //================================================================
        //================================================================
        //            7 Taxonomy
        //================================================================
        //================================================================

        public string FncHtmlTaxonony(bool bCacheRebuild)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.taxonomy.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlTaxononyBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlTaxononyBld()
        {


            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter07_00Tax, oRegFul.oRegTaxaAllFile.AGeoImg_landscapes01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
            m_oAccordion.Init("actaxo");
         


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            //szSecctionTit = Resources.Strings.ind_Chapter07_00Tax;
            //szSecction += FncBldSubTitWithNames(Resources.Strings.ind_Chapter07_00Tax, true, true);
            //m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care tax group
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_01TaxGroup;

            string szLinkPre = "<a href=\"/" + m_IdLng + "/tortoise/groups/group/";
            string szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2210Order;
            string szpATaxIdNameWithVu = "";
            string szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2210Order, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2210Order

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2220SubOrder;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2220SubOrder, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2220SubOrder

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2230SupFamily;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2230SupFamily, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2230SupFamily

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2240Family;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2240Family, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2240Family

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2250SubFamily;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2250SubFamily, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2250SubFamily

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2260SupGenus;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2260SupGenus, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2220SubOrder

            szKeyTit = oRegFul.oRegTaxaAll.ATaxGrpL2270Genus;
            szToolTip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre);
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2270Genus, szToolTip); // oRegFul.oRegTaxaAll.ATaxGrpL2220SubOrder
            szHtml += FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxFulName_, "<i>" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + "</i>, " + oRegFul.oRegTaxaAll.ATaxGrpL2282Authority + " " + oRegFul.oRegTaxaAll.ATaxGrpL2283Year);



            szSecction = szHtml;
            //szSecction += szHtml;

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_02TaxSubes;
            szSecction = oRegFul.oRegTaxaAll.ATaxGrpL2281SubSpecie;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_03TaxEtim;
            szSecction = oRegFul.oRegTaxa.LTaxEtimology;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_04TaxSinon;
            szSecction = oRegFul.oRegTaxaAll.ATaxNameVulgarOthers;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_05TaxVulg;

            szSecction =  FncTool_BldHtmlTaxTitleValue(Resources.Strings.ATaxNameVulgarEN, oRegFul.oRegTaxaAll.ATaxNameVulgarEN);
            szSecction += FncTool_BldHtmlTaxTitleValue(Resources.Strings.LTaxNameVulgar, oRegFul.oRegTaxaAll.ATaxNameVulgarES + "[" + oRegFul.DocLngId + "]");
            szSecction += oRegFul.oRegTaxaAll.ATaxNameVulgarOthers;

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter07_06TaxNote;
            szSecction = oRegFul.oRegTaxa.LTaxNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);




            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;
            

            return szHtml;
        }

        //================================================================
        //================================================================
        //            8 Identificationkeys
        //================================================================
        //================================================================


        public string FncHtmlIdentificationKeys(bool bCacheRebuild)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.identificationkeys.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlIdentificationKeysBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlIdentificationKeysBld()
        {


            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter08_00IdeKey, oRegFul.oRegTaxaAllFile.AGeoImg_landscapes01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
            m_oAccordion.Init("acKeys");

            
      
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------
            string szHtmlszHtmlLeft = "";

            szHtmlszHtmlLeft = ""; ;
            szHtmlszHtmlLeft += m_DivRow_Start;
            cls.bbdd.ClsReg_tdoclng_testudineskeys_lng oReg = new cls.bbdd.ClsReg_tdoclng_testudineskeys_lng();


            szHtmlszHtmlLeft += "<h2>" + Resources.Strings.ind_Chapter08_00IdeKey + m_gotop + "</h2>";
            szHtmlszHtmlLeft += Resources.Strings.Experimental_developing_page;
            szHtmlszHtmlLeft += FncHtmlIdentificationKeysFill(true);
            // rellenar las claves de identificacion


            szHtmlszHtmlLeft += m_DivRow_End;





            szHtmlszHtmlLeft += FncTools_ImgLinks(oRegFul.oRegTaxaAll.ATaxGrpL2270Genus, oRegFul.oRegTaxaAll.ATaxGrpL2280Specie);
            szHtmlszHtmlLeft += "<br/>" + m_LastUpdate;

            szHtml = szHtml_head + szHtmlszHtmlLeft + m_LastUpdate + m_LastUpdate;

           
            return szHtml;
        }



        //================================================================
        //================================================================
        //           9 Near species
        //================================================================
        //================================================================

        public string FncHtmlNearSpecies(bool bCacheRebuild)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.nearspecies.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlNearSpeciesBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlNearSpeciesBld()
        {


            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter09_00Near, oRegFul.oRegTaxaAllFile.ADesImg_DesType03);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.nearspecies);
            //-----------------
            // 3 Contenido
            //------------
 

            m_oAccordion.Init("acNear");


            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------



          




            
                string szHtmlGenus = "";
                if (oRegGrp.FncSqlFind(oRegFul.oRegTaxaAll.ATaxGrpL2270Genus, oRegDocLng.DocLngId))
                {
                    szHtmlGenus = "<div class=\"genus\">" + Resources.Strings.ATaxGrpL2270Genus + ": <i>" + oRegGrp.ATaxIdName + "</i> " + oRegGrp.ATaxGrpL2282Authority + " " + oRegGrp.ATaxGrpL2283Year + "</br>";
                    szHtmlGenus += "</br>" + oRegGrp.DescriptionShort + "</br>";
                    szHtmlGenus += oRegGrp.NameVulgar + "</br>";
                    szHtmlGenus += oRegGrp.Abstract;
                    szHtmlGenus += "</div>";
                }

            string szSql = "select tdoclng_testudines_taxa_all.DocId as docid, ATaxGrpL0001lNameFullRecomeded, ATaxGrpL2270Genus ,LAbsDes, DocLngId, AFileURL, FileSeccId  from tdoclng_testudines_taxa_all left JOIN  tdoclng_testudines_abst on   tdoclng_testudines_taxa_all.DocId = tdoclng_testudines_abst.DocId left JOIN tdoclng_testudines_file_all on   tdoclng_testudines_taxa_all.DocId = tdoclng_testudines_file_all.DocId where FileSeccId='AAbsImg_Specie' ";
            szSql += " and tdoclng_testudines_taxa_all.ATaxGrpL2270Genus='"+ oRegFul.oRegTaxaAll.ATaxGrpL2260SupGenus+"'";

           MySqlDataReader oRd = cls.bbdd.ClsMysql.FncFil_datareader(ref szSql);
            string szName = "";
            string szDes = "";
            string szLng = "";

            string szUrl = "";

            //szHtml += "<h2> " + Resources.Strings.ind_Chapter09_01NearGenus+" "+oRegFul.oRegTaxaAll.ATaxGrpL2270Genus    + m_gotop + "</h2>";
            szHtml += szHtmlGenus;
                string szImgSrc = "";
                while (oRd.HasRows && oRd.Read())
                {

                    szHtml += "<div class=\"row \">";
                    szName = oRd["ATaxGrpL0001lNameFullRecomeded"].ToString().Trim();
                    szDes = oRd["LAbsDes"].ToString().Trim();
                    szLng = oRd["DocLngId"].ToString().Trim();
                    szUrl = "<a href=\"/" + szLng + "/tortoises/" + oRd["docid"].ToString().Trim() + "\"/>";
                    szImgSrc = oRd["AFileURL"].ToString().Trim().ToLower();
                    szImgSrc = szImgSrc.Replace("_med.jpg", "_min.jpg").Replace("_ful.jpg", "_min.jpg").Replace("_big.jpg", "_min.jpg");
                    szHtml += szUrl + "<h2>" + szName + "</h2>";
                    szHtml += "<img class=\"imgright img_min \" src=\"" + szImgSrc + "\"/></a>";
                    szHtml += "<br/>" + szDes;
                    szHtml += "<span class=\"readmore\"/>" + szUrl + Resources.Strings.readmore + "</a>";
                    szHtml += "</div>";
                }
                oRd.Dispose();
               

                szSecctionTit = Resources.Strings.ind_Chapter09_01NearGenus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus;
                szSecction = szHtml; ;
                m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);
                // ------------------------------------------------- 

                szHtml = m_DivRow_Start;

                szHtml += FncTools_BldHtmlFamilyListGenus();
                szHtml += m_DivRow_End;
                szSecctionTit = Resources.Strings.ind_Chapter09_02NearFamily + " " + oRegFul.oRegTaxaAll.ATaxGrpL2240Family;
                szSecction = szHtml; ;
                m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);





            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate;
                

                return szHtml;
            }


        //================================================================
        //================================================================
        //          10 Gallery
        //================================================================
        //================================================================
        public string FncHtmlGallery(bool bCacheRebuild, Int32 iPage)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.images.ToString() + "_"+iPage.ToString(); 
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;

            string szHtmlHead = FncHtmlGalleryBld_Head();
            String szHtmlFoot = FncHtmlGalleryBldFoot();
           FncHtmlGalleryBld(ref szHtmlHead, ref szHtmlFoot);
           
            szHtml = oRegCache.FncReadCache( szFileCache);
           
            return szHtml;
        }
        public String FncHtmlGalleryBldFoot()
        {

            string szFoot = "";
            szFoot += FncBldHtmSecction(Resources.Strings.Acknowledgements, oRegDoc.DocAcknowledgements + ".");
            szFoot += FncTools_ImgLinks(oRegFul.oRegTaxaAll.ATaxGrpL2270Genus, oRegFul.oRegTaxaAll.ATaxGrpL2280Specie);
            return szFoot;
        }
        public String FncHtmlGalleryBld_Head()
        {

            string szHtml_head = "";



            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter08_00IdeKey, oRegFul.oRegTaxaAllFile.AGeoImg_landscapes01);
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.natural_history);
            //-----------------
            // 3 Contenido
            //------------
            return szHtml_head;
        }
        //public void  FncHtmlGalleryBld( ref String pHtmlHead, ref String pHtmlFoot)
        public void  FncHtmlGalleryBld( ref String pHtmlHead, ref String pHtmlFoot)
        {

            // TODO REHCIENDO range ecologi
         

            cls.cache.ClsCache_Tortoise_Images  oGal = new cls.cache.ClsCache_Tortoise_Images();
          

            string szTitleBot = "";
            if (oRegDocLng.DocLngId == "en")
            {
                szTitleBot = oRegFul.oRegTaxaAll.ATaxNameVulgarEN;
            }
            else
            {
                szTitleBot = oRegFul.oRegTaxaAll.ATaxNameVulgarES;
            }
            string szTitleTop = oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ", " + oRegFul.oRegTaxaAll.ATaxGrpL2282Authority + " " + oRegFul.oRegTaxaAll.ATaxGrpL2283Year.ToString();

            oGal.FncCacheGet(m_IdDoc,m_IdLng,1,true);
              
           
        
        }

        //================================================================
        //================================================================
        //          12 BIBILIOGRAPHY
        //================================================================
        //================================================================





        public string FncHtmlbibliography(bool bCacheRebuild)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.bibliography.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlbibliographyBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlbibliographyBld()
        {

            // TODO REHCIENDO range ecologi
            String szHtml = "";
            string szHtml_head = "";
            string szSecctionTit = "";
            string szSecction = "";


            // 1 Cabecera titulo
            //-----------------

            szHtml_head = FncTool_BldHtmlChapter_title(Resources.Strings.ind_Chapter11_00Bib, "");
            // 2 Indice
            szHtml_head += FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.nearspecies);
            //-----------------
            // 3 Contenido
            //------------
            

            m_oAccordion.Init("acobibl");
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            szSecctionTit = Resources.Strings.ind_Chapter11_01BibAck;
            szSecction = oRegDoc.DocAcknowledgements; ;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            szSecctionTit = Resources.Strings.ind_Chapter11_02BibBib;
            szSecction = oRegDoc.DocBibliography; ;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            szSecctionTit = Resources.Strings.ind_Chapter11_03BibLinks;
            szSecction = FncTools_ImgLinks(oRegFul.oRegTaxaAll.ATaxGrpL2270Genus, oRegFul.oRegTaxaAll.ATaxGrpL2280Specie); ;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


          
            szHtml = szHtml_head + m_oAccordion.html + m_LastUpdate ;




          
            return szHtml;
        }


        //================================================================
        //================================================================
        //          12 NOTES
        //================================================================
        //================================================================
        public string FncHtmlNotes(bool bCacheRebuild)
        {
            string szFileCacheType = cls.ClsGlobal.E_TortoiseChapters.notes.ToString();
            string szFileCache = cls.cache.ClsCache.FncCacheFilePath(m_IdDoc, m_IdLng, szFileCacheType, "tortoise");
            string szHtml = "";
            if (bCacheRebuild)
            {

                oRegCache.FncCacheFileDelete(szFileCache);

            }
            szHtml = oRegCache.FncReadCache(szFileCache);

            if (szHtml != "") return szHtml;
            szHtml = FncHtmlNotesBld();
            oRegCache.FncWriteCache(ref szFileCache, ref szHtml);
            return szHtml;
        }

        public string FncHtmlNotesBld()
        {
           

            string szHtml = "";
            // -------------------------------------------------
            
     
      

            string szHtmlszHtmlLeft = ""; ;
            string szHtmlszHtmlRight = "";
            string sz = szHtml = oRegDocLng.DocLngNotes.Trim();
            if (sz == "")
            {
                sz = Resources.Strings.NoDataSoFar;
            }
            szHtmlszHtmlLeft += FncBldHtmSecction(Resources.Strings.Notes, sz);
  
            szHtml +=  szHtmlszHtmlRight + szHtmlszHtmlLeft + m_LastUpdate;
            
          
            return szHtml;

        }



        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public string FncBldHtmlFamilyList()
        {
            cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
            string szText = "";
            if (oGroup.FncSqlFind(oRegFul.oRegTaxaAll.ATaxGrpL2240Family, m_IdLng))
            {
                szText = "<b>" + oGroup.DescriptionShort + "</b><br/>" + oGroup.Abstract;
            }
            string szHtml = "";
            string szSqlCmd = "select  ATaxGrpL2240Family, ATaxGrpL2270Genus, ATaxGrpL2280Specie, ATaxGrpL2282Authority, ATaxGrpL2283Year, DocId from tdoclng_testudines_taxa_all";
            szSqlCmd += " where ATaxGrpL2240Family='" + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + "' order by ATaxGrpL2240Family, ATaxGrpL2270Genus";
            DataTable oTb = new DataTable();
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oSqlCmd = new MySqlCommand(szSqlCmd, oSqlCnn);
            MySqlDataAdapter oSqlDA = new MySqlDataAdapter(oSqlCmd);
            oSqlCnn.Open();
            oSqlDA.Fill(oTb);
            szHtml = "<h4>Fam: " + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + " " + Resources.Strings.with + " " + oTb.Rows.Count.ToString() + " " + Resources.Strings.species + "</h4>";
            szHtml += szText;
            szHtml += "\n<ul>";
            string szUrl = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                szUrl = "<a href=\"/" + m_IdLng + "/tortoises/" + oRow["DocId"].ToString() + "/descrition\">";
                szHtml += "\n<li><i>" + szUrl + oRow["ATaxGrpL2270Genus"].ToString() + " " + oRow["ATaxGrpL2280Specie"].ToString() + "</i> (" + oRow["ATaxGrpL2282Authority"].ToString() + ",  " + oRow["ATaxGrpL2283Year"].ToString() + ")</a></li>";
            }
            szHtml += "</ul>\n";
            oSqlDA.Dispose();
            oSqlCmd.Dispose();
            testudines.cls.bbdd.ClsMysql.FncClose();
         
            //oSqlCnn.Dispose();



            return szHtml;
        }

     

   
        private string FncBldSubTitWithNames(string szTitSection, bool bShowHtmlBoxResumen)
        {
            return FncBldSubTitWithNames(szTitSection, bShowHtmlBoxResumen, false);
        }
        private string FncBldSubTitWithNames(string szTitSection, bool bShowHtmlBoxResumen, bool TagTop)
        {
            string szName = "";
            if (oRegDoc.DocLngId_Main == "es")
            {
                 szName = oRegFul.oRegTaxaAll.ATaxNameVulgarES + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            }
            else
            {
                szName = oRegFul.oRegTaxaAll.ATaxNameVulgarEN + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            }
            string sz = "\n<h2 class=\"h2.titlesubdot\">" + szTitSection + ": \"" + szName + "\"" + "</h2>";
            if (TagTop) sz = "<a name=\"ind_gotop\" class=\"anchor\">" + sz + "</a>";
            //if (bShowHtmlBoxResumen) sz = sz+m_HtmlBoxResumen ;
            return sz;
        }
      
      
        private string FncHtmlIdentificationKeysFill(bool bCacheRebuild)
        {
            string szHtmlTabs = "";
            string szHtml = "";
            string szSectionFile = "identkey";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.FncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.FncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.FncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                //szHtmlTabs = oRegCache.FncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------
            m_oAccordion.Init("acidkeys");
            string szSecctionTit = "";
            string szSecction = "";
            //String szHtml = "";
            String szSql = "";
            szSql += " select DocId, DocLngId, TOWNodeParentId, TOWNodeId,NodeFullPathList,";
            szSql += " TOWATaxIdGroup,TOWATaxGrpL2280Specie,TOWATaxGrpL2280SpecieSub,";
            szSql += " TOWTaxaURL , NodeFullPathList,TOWTaxaGroupLevel,";
            szSql += " ImgHlpPath01,ImgHlpPath02,ImgHlpPath03,DocIdTaxaRelationValue,";
            szSql += " Title,Description,Notes";
            szSql += " from tdoclng_testudines_keys join tdoclng_testudines_keys_lng USING (DocId)";
            szSql += " where DocIdTaxaRelationValue=" + oRegDoc.DocId.ToString();
            szSql += " Order by TOWNodeParentId,TOWNodeId";

            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlDataAdapter oDA = new MySqlDataAdapter(szSql, oCnn);
            DataTable oDS = new DataTable();
            oDA.Fill(oDS);
            //string szTaxa="";
            string szNodeFullPathList = "";
            string szHtmlEnd = "";
            string szhtmNodes = "";
            string szNodeFullPathListMax = "";
            foreach (DataRow oRow in oDS.Rows)
            {
                szNodeFullPathList = oRow["NodeFullPathList"].ToString();
                if (szNodeFullPathList.Length > szNodeFullPathListMax.Length) szNodeFullPathListMax = szNodeFullPathList;
                szHtmlEnd += "</br>Key NodeId" + oRow["TOWNodeId"].ToString();
                szHtmlEnd += "</br>Taxon " + oRow["TOWATaxIdGroup"].ToString() + " " + oRow["TOWATaxGrpL2280Specie"].ToString() + " " + oRow["TOWATaxGrpL2280SpecieSub"].ToString();
                szHtmlEnd += "</br>NodeFullPathList" + oRow["NodeFullPathList"].ToString();
                szHtmlEnd += "</br>Title" + oRow["Title"].ToString();
                szHtmlEnd += "</br>Description" + oRow["Description"].ToString();
                szHtmlEnd += "</br>Notes" + oRow["Notes"].ToString();
                szHtmlEnd += "<hr/></br>";
                // ImgHlpPath01,ImgHlpPath02,ImgHlpPath03,
            }
            String[] sNodes = szNodeFullPathListMax.Split(',');
            for (int i = 0; i < sNodes.Length; i++)
            {
                szhtmNodes += FncBldHtmlIdentificationKeyNode(sNodes[i], m_IdLng, ref oCnn);

            }
            szHtml = szhtmNodes + szHtmlEnd;


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Chapter08_01IdeKey;

            szSecction += szHtml;

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            szHtmlTabs = FncBldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.identificationkeys, Resources.Strings.ind_Chapter08_00IdeKey, szSectionFilePanel);

            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate;

            return szHtml;


        }
        public string FncBldHtmlIdentificationKeyNode(string TOWNodeId, string idDocLng, ref MySqlConnection oCnn)
        {

            string szHtm = "";
            string szSql = "select docid from tdoclng_testudines_keys where TOWNodeId='" + TOWNodeId + "'";
            try
            {
                TOWNodeId = TOWNodeId.Trim();
                string sz = "";
                MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);


                sz = oCmd.ExecuteScalar().ToString();
                UInt64 DocId = Convert.ToUInt64(sz);
                oRegKeyNode.FncSqlFind(DocId, idDocLng);

                szHtm = oRegKeyNode.FncGetCache_Html(cls.ClsGlobal.CacheRebuid);
            }
            catch (Exception xcpt)
            {
                szHtm = "<br/><b>TOWNodeId= " + TOWNodeId + " not found</b><br/>";
                szHtm += xcpt.Message;
            }

            return szHtm;
        }
       
        public string FncHtmlTaxonULTree(bool bCacheRebuild, string pDocLngId)
        {

            string szHtml = "";
            // gestion del cache
            string szSectionFile = "TaxonTree";
            if (!bCacheRebuild)
            {

                szHtml = oRegCache.FncReadCache(0, pDocLngId, szSectionFile);

            }
            if (szHtml != "") return szHtml;


            // si se indica rehacer cache
            // rehacerlo desde base de datos

            string szSql = "";
            szSql += " select";
            szSql += " ATaxGrpL2220SubOrder as L1_SO,";
            szSql += " ATaxGrpL2230SupFamily as L2_SF,ATaxGrpL2240Family as L3_FA,";
            szSql += " ATaxGrpL2270Genus as L4_GE, CONCAT_WS(' ',ATaxGrpL2270Genus, ATaxGrpL2280Specie)as specie,DocId";
            szSql += " from tdoclng_testudines_taxa_all order by";
            szSql += " ATaxGrpL2220SubOrder,ATaxGrpL2230SupFamily,";
            szSql += " ATaxGrpL2240Family,ATaxGrpL2270Genus,ATaxGrpL2280Specie";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);
            MySqlDataAdapter oDa = new MySqlDataAdapter(oCmd);
            DataTable oTb = new DataTable();
            oCnn.Open();
            oDa.Fill(oTb);
            oCmd.Dispose();
            oDa.Dispose();
            //oCnn.Close();
            //oCnn.Dispose();

            //----------------------------------
            string szL1_SOAnt = "";
            string szL2_SFAnt = "";
            string szL3_FAAnt = "";
            string szL4_GEAnt = "";

            // <ul>
            //    <li>
            //        Orden
            //        <ul>
            //            <li>Suborden
            //                <ul>
            //                    <li>suborden</li>
            //                    <li>suborden</li>
            //                </ul>
            //            </li>
            //        </ul>
            //     </li>
            //</ul>

            string szCloseL5 = "\n\t\t\t\t\t</ul>"; //l4

            string szCloseL4 = szCloseL5 + "\n\t\t\t\t</li>\n\t\t\t\t</ul>"; //l4
            string szCloseL3 = szCloseL4 + "\n\t\t\t</li>\n\t\t\t</ul>"; //l3
            string szCloseL2 = szCloseL3 + "\n\t\t</li>\n\t\t</ul>";//l2
            string szCloseL1 = szCloseL2 + "\n\t</li>\n\t</ul>"; //l1

            string szCloseL1open = "\n\t<ul>\n\t<li>"; //l1
            string szCloseL2open = "\n\t\t<ul>\n\t\t<li>"; //l1
            string szCloseL3open = "\n\t\t\t<ul>\n\t\t\t<li>"; //l1
            string szCloseL4open = "\n\t\t\t\t<ul>\n\t\t\t\t<li>"; //l1
            string szCloseL5open = "\n\t\t\t\t\t<ul class=\"no-bullet\">\n"; //l1


            string szL1_SO = "";
            string szL2_SF = "";
            string szL3_FA = "";
            string szL4_GE = "";
            bool bL1 = false;
            bool bL2 = false;
            bool bL3 = false;
            bool bL4 = false;

            string szspecie = "";
            string szDocId = "";
            string szLinkPre = "<a href=\"/" + pDocLngId + "/tortoises/groups/group/";

            //string szOpen = "";
            //string szClose = "";
            string szTooltip = "";
            string szKey = "Testudines";

            string szLink = szLinkPre + szKey + "\">" + szKey + "</a>";
            string szReadMore = "";
            string szKeyTit = "Order:" + szKey + "<br/>";
            szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre);
            szHtml = "\n<ul><li>Order: <b>" + szTooltip + "</b>";

            foreach (DataRow oRow in oTb.Rows)
            {
                bL1 = false;
                bL2 = false;
                bL3 = false;
                bL4 = false;

                szL1_SO = oRow["L1_SO"].ToString().Trim();
                szL2_SF = oRow["L2_SF"].ToString().Trim();
                szL3_FA = oRow["L3_FA"].ToString().Trim();
                szL4_GE = oRow["L4_GE"].ToString().Trim();
                szspecie = oRow["specie"].ToString().Trim();
                szDocId = oRow["DocId"].ToString().Trim();


                //L1
                if (szL1_SOAnt != szL1_SO)
                {
                    if (szL1_SOAnt != "") { szHtml += szCloseL1; }
                    szKey = szL1_SO;
                    //String szTit= Resources.Strings.scnATaxGrpL2220SubOrderTit;
                    //String szTit = Resources.Strings.scnATaxGrpL2230SupFamilyTit;
                    //String szTit = Resources.Strings.scnATaxGrpL2240FamilyTit;
                    //String szTit = Resources.Strings.scnATaxGrpL2260SupGenusTit;
                    //String szTit = Resources.Strings.scnATaxGrpL2220SubOrderTit;
                    //String szTit = Resources.Strings.scnATaxGrpL2220SubOrderTit;

                    szKeyTit = "Suborder: " + szKey + "<br/>";
                    //szLink = szLinkPre + szKey + "\">" + szKey + "</a>";

                    szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre);
                    szHtml += szCloseL1open + "<b>Suborder " + szTooltip + "</b>";
                    szL1_SOAnt = szL1_SO;
                    bL1 = true;

                }

                //............................................
                //L2
                if (szL2_SFAnt != szL2_SF)
                {

                    if (szL2_SFAnt != "")
                    { if (!bL1) szHtml += szCloseL2; }
                    szKey = szL2_SF;
                    szKeyTit = "Superfamily: " + szKey + "<br/>";
                    //szLink = szLinkPre + szKey + "\">" + szKey + "</a>";
                    // szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLink, ref oCnn);


                    szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre);


                    szHtml += szCloseL2open + "<b>Superfamily " + szTooltip + "</b>";
                    szL2_SFAnt = szL2_SF;
                    bL2 = true;
                }
                //............................................
                //L3
                if (szL3_FAAnt != szL3_FA)
                {

                    if (szL3_FAAnt != "")
                    {
                        if (!bL2) szHtml += szCloseL3;
                    }
                    szKey = szL3_FA;
                    szKeyTit = "Familiy: " + szKey + "<br/>";
                    // szLink = szLinkPre + szKey + "\">" + szKey + "</a>";
                    //szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLink, ref oCnn );
                    szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre);

                    szHtml += szCloseL3open + "<b>Familiy " + szTooltip + "</b>";
                    szL3_FAAnt = szL3_FA;
                    bL3 = true;
                }
                //............................................
                //L4
                if (szL4_GE != szL4_GEAnt)
                {

                    if (szL4_GEAnt != "")
                    {
                        if (!bL3)
                        {
                            szHtml += szCloseL4;

                        }
                    }
                    szKey = szL4_GE;
                    szKeyTit = "Genus: " + szKey + "<br/>";
                  

                    szTooltip = FncTool_HtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre);




                    szHtml += szCloseL4open + "<b>Genus " + szTooltip + szReadMore + "</b>";

                    szL4_GEAnt = szL4_GE;
                    bL4 = true;
                }
                if (bL4)
                {
                    szHtml += szCloseL5open;
                }

                szHtml += "\n\t\t\t\t\t<li><b>" + Resources.Strings.specie + "</b> " + FncLinkSspecie(szspecie, szDocId, pDocLngId) + "</li>";

            }
            szHtml += szCloseL1;
            szHtml += "\n</li></ul>";

            oCnn.Close();
            oCnn.Dispose();
            // guardar en Cache el formato html
            //----------------------------------
            oRegCache.FncWriteCache(0, pDocLngId, szSectionFile, szHtml, true);

            return szHtml;
        }



      



        public string FncLinkSspecie(string pSpecie, string pDocId, string pDocLngId)
        {


            UInt64 iDocId = Convert.ToUInt64(pDocId);
            oRegTxAll.FncSqlFind(iDocId);

            if (pDocLngId == "") pDocLngId = ClsGlobal.default_DocLngId;
           // oRegTxLngAbs.FncSqlFind(iDocId, pDocLngId);


            string szSpecie = "<b><i>" + oRegTxAll.ATaxGrpL2270Genus + " " + oRegTxAll.ATaxGrpL2280Specie + "</i></b>, " + oRegTxAll.ATaxGrpL2282Authority + " " + oRegTxAll.ATaxGrpL2283Year;
            string sz = "";
            sz = "<a href=\"/es/tortoises/" + pDocId + "\">" + szSpecie + "</a>";

            if (oRegTxAll.ATaxNameVulgarEN != "") { sz += "<br/>&nbsp;&nbsp;&nbsp;[EN] " + oRegTxAll.ATaxNameVulgarEN; }
            if (oRegTxAll.ATaxNameVulgarES != "")  {  sz += "<br/>&nbsp;&nbsp;&nbsp;[ES] " + oRegTxAll.ATaxNameVulgarES; }
            
            // sz +="<span class=\"inline\">"+clsUtil.FncHtmFlagLanguages(Convert.ToInt32(pDocId), "/taxons/taxons/",false )+"</span>";
            sz += "<br/>&nbsp;&nbsp" + cls.ClsHtml.FncHtmFlagLanguages(Convert.ToUInt64(pDocId), "/tortoises/", false);

            Thread.Sleep(200);
            return sz;
        }
  
      

        //public string FncHtmlToDo(bool bCacheRebuild)
        //{
        //     string szHtmlTabs="";
        //    string szHtml = "";
        //    // -------------------------------------------------
        //    string szSectionFile = "todo";
        //    string szSectionFilePanel = szSectionFile + "_panel";
        //    if (bCacheRebuild)
        //    {
        //        oRegCache.FncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
        //        oRegCache.FncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
        //    }
        //    else
        //    {
        //        szHtml = oRegCache.FncReadCache(m_IdDoc, m_IdLng, szSectionFile);
        //        szHtmlTabs = oRegCache.FncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
        //    }
        //    if (szHtml != "") return szHtml;
        //    // -------------------------------------------------
        //    // ---- si no existe el cache o overwrite crearlo
        //    //-------------------------------------------------


        //    string szHtmlszHtmlLeft = ""; ;
        //    string szHtmlszHtmlRight = "";
        //    string sz = "";
        //    if (oRegFul.oRegTodo.Abstract != "")
        //    {
        //        sz = szHtml + "<b>" + oRegFul.oRegTodo.Title + "</b>";
        //        sz += "<h4>" + Resources.Strings.Abstract + "</h4>";
        //        sz += oRegFul.oRegTodo.Abstract;
        //        sz += "<h4>" + Resources.Strings.body + "</h4>";
        //        sz += oRegFul.oRegTodo.Body;
        //    }
        //    else
        //    {
        //        sz = szHtml + Resources.Strings.NoDataSoFar;
        //    }
        //    szHtmlszHtmlLeft += FncBldHtmSecction(Resources.Strings.Todo, sz);
        //    szHtmlTabs = FncBldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters.ToDo, Resources.Strings.ind_Chapter12_00Notes, szSectionFilePanel);
        //    szHtml = szHtmlTabs+szHtmlszHtmlRight + szHtmlszHtmlLeft;
        //    szHtml += m_LastUpdate + szHtmlTabs;

        //    oRegCache.FncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
        //    return szHtml;
        //}
       
       
        private string FncTool_Imglink(string szUrl, string szImgPath, string szTitle, string szAlt)
        {
            //~/App_Themes/CommunitySite/Images/Propias/wwwITIS.jpg
            string sz = "<a href=\"#szUrl#\" target=\"_new\"><img class=\"img_links\"  alt=\"\" src=\"/a_img/a_lnks/#szImgPath#\"  /></a>";
            sz = sz.Replace("#szUrl#", szUrl);
            sz = sz.Replace("#szImgPath#", szImgPath);
            return sz;

        }
        /// <summary>
        /// Crea una seccion con imagen descritiva de ayuda
        /// </summary>
        /// <param name="szMinImgUrl">Miniatura situada a la derecha del texto</param>
        /// <param name="szBigImgUrl">Imagen que aparecera cuando se pida ayuda</param>
        /// <param name="szIdDivShowHide">Id unico para javascript</param>
        /// <param name="szIdDivShowHideAlt">Texto que aparece como title al poner el cursor sobre una imagen
        /// si esta en blanco lo toma de resourtes.page_taxon</param>
        /// <param name="szFootText">Texto html de la seccion</param>
        /// <returns></returns>
        private string FncBldHtmlSectionImgHelp(string szMinImgUrl, string szBigImgUrl, string szIdDivShowHide, string szIdDivShowHideAlt, string szText)
        {
            szText = szText.Trim();
            if (szText == "" || szText == "szTex")
            { szText = Resources.Strings.Opps_Nodata; }

            szIdDivShowHideAlt = szIdDivShowHideAlt.Trim();
            if (szIdDivShowHideAlt == "") szIdDivShowHideAlt = Resources.Strings.ExpandhelpSection;
            string szHtm = "";//     
            string szAHrefToggle = "\n<a href=\"javascript:toggleDivId('" + szIdDivShowHide + "');\" >";
            szHtm += szAHrefToggle + "\n<img  style=\"float: right; padding:2px; cursor:help;\" src=\"/a_img/hlp_descr/view_help.png\" title=\"" + szIdDivShowHideAlt + "\" />\n</a>";
            szHtm += "\n<div id=\"" + szIdDivShowHide + "\" style=\"float:none; cursor:n-resize; display:none;\">";
            szHtm += szAHrefToggle + "\n<img  src=\"" + szBigImgUrl + "\" alt=\"" + szIdDivShowHideAlt + "\"/>\n</a>";

            szHtm += "\n" + "\n</div>";
            szHtm += "\n<span class=\"imgleft\">";
            szHtm += szAHrefToggle + "\n<img src=\"" + szMinImgUrl + "\"/>\n</a>";
            szHtm += "\n</span>";

            szHtm += "\n" + szText;
            return szHtm;
        }
        private string FncBldHtmlSectionImgHelp(string szMinImgUrl, string szText)
        {
            szText = szText.Trim();
            if (szText == "" || szText == "szTex")
            { szText = Resources.Strings.Opps_Nodata; }
            string szHtm = m_DivRow_Start;
            szHtm += "\n<span class=\"imgleft\">";
            szHtm += "\n<img src=\"" + szMinImgUrl + "\"/>";
            szHtm += "\n</span>";
            szHtm += szText;
            szHtm += m_DivRow_End;
            return szHtm;
        }


        //######################################################################
        //######################################################################
        //######################################################################
        //############################ tools start #############################
        //######################################################################
        //######################################################################
        //######################################################################
        //######################################################################


        private String FncTool_BldHtmlChapter_title(String szResource_CaptituleTitle, String szUrmImgMed)
        {
            string szImg = "";
            String szName = "<h1 class=\"taxTitleFullName\"><i>" + m_EspecieName + "</i> " + oRegFul.oRegTaxaAll.ATaxGrpL2282Authority + ", " + oRegFul.oRegTaxaAll.ATaxGrpL2283Year + "</h1>";
            String szChapter = "<h2 class=\"taxTitleFullName\">" + Resources.Strings.ind_Chapter + " " + szResource_CaptituleTitle + "</h2>";
            if (szUrmImgMed != "")
            {
                szImg = oFB.FncHtmlAloneRowPhotoFB_med(szUrmImgMed, oRegFul.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded, "ind_Chapter01_01AbsDes");
            }
            String szVulgar = "<span class=\"taxTitlevulgar\"> EN:" + oRegFul.oRegTaxaAll.ATaxNameVulgarEN + ",  ES:" + oRegFul.oRegTaxaAll.ATaxNameVulgarES + "</span>";
            String szTaxa = " <span class =\"taxTitleTax\">Subord. " + oRegFul.oRegTaxaAll.ATaxGrpL2220SubOrder + ", Supfam." + oRegFul.oRegTaxaAll.ATaxGrpL2230SupFamily + ", Fam." + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + "</span>";
            String szAutors = oRegDoc.DocAuthors = "";
            if (szAutors == "") szAutors = "V.Niclos";
            szAutors = " <span class =\"taxTitleTax\"> " + szAutors + "</span>";
            String szHtml = szName + szTaxa + szVulgar + szAutors + szChapter + szImg;

            return szHtml;

        }
        /// <summary>
        /// 2018 devuelve el menu con el tab seleccionado.
        /// </summary>
        /// <param name="TabSelect"></param>
        /// <param name="szTitle"></param>
        /// <returns></returns>
        private string FncTool_BldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters Chapter)
        {


            string szSelect = Chapter.ToString();
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            //szTitle = "<h4>" +"titulo" +"</h4>";


            string szTit = "";
            string szUrl = m_UrlTemplate + "/" + Chapter.ToString() + "/";
            string szClass = "";
            //<nav class="contents">




            string szMenu = "";
            // szMenu += "\n<h4>" + m_EspecieName + Resources.Strings.chapters + ":</h4></hr>\n<contents>\n<ul class=\"contents\">";
            szMenu += "\n<div class=\"index\">\n<h2 class=\"index\">" + Resources.Strings.chapters + "</h2>\n<ul>";
            szTit = Resources.Strings.ind_Chapter01_00Abs;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.summary.ToString())
            { szClass = " class=\"selected\" "; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "abstract\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter02_00Des;
            if (szSelect == ClsGlobal.E_TortoiseChapters.description.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "description\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter03_00Nat;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.natural_history.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "natural_history\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter04_00_00_BioGeographic;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.distribution.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "distribution\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.ecology.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "ecology\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter06_00Car;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.care.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "care\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";
            szMenu += "\n</ul>\n<ul>";
            szTit = Resources.Strings.ind_Chapter07_00Tax;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.taxonomy.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "taxonony\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            //------
            // ind_Chapter08Key

            szTit = Resources.Strings.ind_Chapter08_00IdeKey;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.identificationkeys.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "IdentificationKeys\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";


            //--------------
            szTit = Resources.Strings.ind_Chapter09_00Near;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.nearspecies.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "nearspecies\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter10_00Gal;
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.images.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "images\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";


            szTit = Resources.Strings.ind_Chapter11_00Bib;
            // szUrl = "#";
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.bibliography.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "bibliography\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter12_00Notes;
            // szUrl = "#";
            if (szSelect == cls.ClsGlobal.E_TortoiseChapters.notes.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "notes\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";
            //-------fin
            szMenu += "\n</ul>\n</div>\n\n";

            //szHtmlTab += m_HtmlBoxResumen;


            return szMenu;

        }

        private string FncTool_HtmlTaxonULTreeToolTips(ref string pKeyTit, ref string pATaxIdName, ref string szLinkPre)
        {
            string szLink = szLinkPre + pATaxIdName + "\">" + pATaxIdName + "</a>\n</span>";

            // string szReadMore = "\n<span class=\"has-readmore\">" + szLinkPre + pATaxIdName + "\" title=\""+ Resources.Strings.Click_ReadFullArticle + "\" >" + Resources.Strings.readmore + "</a>\n</span>";
            string szReadMore = "\n<span class=\"small\">" + szLinkPre + pATaxIdName + "\" title=\"" + Resources.Strings.Click_ReadFullArticle + "\" >[" + Resources.Strings.readmore + "]</a>\n</span>";

            if (pATaxIdName == "")
            {
                szLink = pKeyTit;
                szReadMore = "";
            }
            string szTooltip = pATaxIdName;
            // obtener informacion de base de datos

            string szCmd = "select ATaxIdName,ATaxGrpL2282Authority,ATaxGrpL2283Year,  CONCAT(ATaxIdName ,'. ', NameVulgar) as titlevu,Abstract, DescriptionShort from tdoclng_testudines_groups where ATaxIdName='" + pATaxIdName.Trim() + "'";

            DataTable oDT = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szCmd, ref oDT);

            try
            {


                string szIdName = "";
                string szAbstract = "";
                string szDescription = "";
                if (oDT.Rows.Count > 0)
                {
                    szIdName = oDT.Rows[0]["ATaxIdName"].ToString().Trim();
                    szAbstract = pKeyTit + oDT.Rows[0]["Abstract"].ToString().Trim();
                    szDescription = oDT.Rows[0]["DescriptionShort"].ToString().Trim();
                    szTooltip = cls.ClsHtml.FncHtmlToolTip(szLink, szAbstract);
                    //pATaxIdNameWithVu=oDT.Rows[0]["titlevu"].ToString().Trim();
                    szTooltip += szReadMore;
                }

                oDT.Dispose();
            }
            catch (Exception xcpt)
            {
                string sz = xcpt.Message;
                ;
            }
            // crear tool tips

            return szTooltip;

        }




        private String FncTool_BldReadMore(string pUrlSecction, string pTextSeccion)
        {
            string szHtml = "<br/><span class=\"readmore \"><a  href=\"/" + m_IdLng + "/tortoises/" + m_IdDoc.ToString() + "/" + pUrlSecction + "\"> " + Resources.Strings.ind_Chapter_readfularticle + ": " + pTextSeccion + "</a></span>";
            return szHtml;
        }


        private string FncTool_BldHtmlBoxIUCN()
        {
            string szHtmlImgIucn = "";
            cls.bbdd.ClsReg_tmst_iucn_redlist oRegIucn = new testudines.cls.bbdd.ClsReg_tmst_iucn_redlist();
            try
            {
                if (oRegFul.oRegNatuAll.ANatDngLevelRedList != "")
                {
                    oRegIucn.FncSqlFind(Convert.ToUInt64(oRegFul.oRegNatuAll.ANatDngLevelRedList), oRegFul.DocLngId);
                    string szUrl = "/" + oRegFul.DocLngId + "/dlg_iucn_redlist/" + oRegFul.oRegNatuAll.ANatDngLevelRedList;
                    // szHtmlImgIucn = "\n" + FncBldHtmlPretyPhotoIframeAlone("iframeIucn", szUrl, oRegIucn.UrlImg, "Help", "IUN Red List");
                    szHtmlImgIucn = "\n" + FncBldHtmlFancyBoxIframeAlone(szUrl, oRegIucn.UrlImg, "Help", "IUN Red List");
                    //string szHtmlImgIucn =   FncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegIucn.UrlImg, "Help", "Climate") ;
                }
            }
            catch (Exception)
            {; }
            return szHtmlImgIucn;

        }


        private string FncTool_BldHtmlTaxTitleValue(string pTitle, string pValue)
        {
            if (pValue == "") pValue = Resources.Strings.Opps_Nodata;
            string szHtml = "";
            szHtml += "<span class=\"fieldtitall\">" + pTitle + ": ";
            szHtml += pValue + "</span>";

            return szHtml;
        }
        public string FncTools_ImgLinks(string pBuscarGen, string pBuscarEsp)
        {
            string szHtmImgLinks = "";
            string szUri = "";
            string sz = "";
            string pBuscarGenSpEsp = pBuscarGen + " " + pBuscarEsp;
            // 1 reptile database peter ueth
            szHtmImgLinks += "<h2>" + Resources.Strings.SearchOtherSites + "</h2>";
            szUri = "http://reptile-database.reptarium.cz/species.php?genus=#g#&species=#s#";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_repddbb.gif", "title", "Alt");
            szHtmImgLinks += sz;

            //2 ITIS
            szUri = "http://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=Scientific_Name&search_value=#find#&search_kingdom=every&search_span=containing&categories=All&source=html&search_credRating=All";
            szUri = szUri.Replace("#find#", pBuscarGenSpEsp);
            sz = FncTool_Imglink(szUri, "www_ITIS.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 6 IUCN RED LIST
            sz = oRegFul.oRegOthAll.AOth_LnkUrl_IUCN;
            if (sz != "#" & sz != "")
            {
                sz = FncTool_Imglink(sz, "www_iucnredlist.jpg", "IUCN Red List", "Alt");
                szHtmImgLinks += sz;
            }

            //2 ITIS
            szUri = "http://fossilworks.org/";
            //szUri = szUri.Replace("#find#", pBuscarGenSpEsp);
            sz = FncTool_Imglink(szUri, "www_fossilworks_org.gif", "fossilworks.org", "Gateway to the paleobiology database");
            szHtmImgLinks += sz;

            //3 catalogueoflife species 2000
            szUri = "http://www.gbif.org/species/search?q#g#+#s";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_gbif.gif", "GBIF.org Free and open access to biodiversity data", "GBIF.org Free and open access to biodiversity data");
            szHtmImgLinks += sz;


            //3 catalogueoflife species 2000
            szUri = "http://www.catalogueoflife.org/annual-checklist/2009/search_results.php?search_string=#g#+#s#";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_catalogeoflife.gif", "title", "Alt");
            szHtmImgLinks += sz;


            //4 CITES
            szUri = "http://sea.unep-wcmc.org/isdb/CITES/Taxonomy/tax-species-result.cfm?Genus=#g#&Species=#s#&source=animals&displaylanguage=eng&tabname=all";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_cites.org.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            //5 CITES APENDICES
            szUri = "http://www.cites.org/esp/app/Appendices-S.pdf";
            sz = FncTool_Imglink(szUri, "www_citesapp.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 5 turtles of the world
            //http:/http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=Lissemys%20punctata

            //http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=testudo
            //       http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=testudo%20graeca
            szUri = "http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=##buscar##";
            sz = pBuscarGenSpEsp.Replace(" ", "%20");
            szUri = szUri.Replace("##buscar##", sz);
            sz = FncTool_Imglink(szUri, "www_turtlesworld.png", "title", "Alt");
            szHtmImgLinks += sz;


            // 7 UNEP
            szUri = "http://www.unep-wcmc.org/isdb/Taxonomy/tax-species-result.cfm?source=animals&genus=#gns#&species=#spc#&tabname=all";
            szUri = szUri.Replace("#gns#", pBuscarGen);
            szUri = szUri.Replace("#spc#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_unepwcmc.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 8 ncbi
            szUri = "http://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?name=#gns#+#spc#";
            szUri = szUri.Replace("#gns#", pBuscarGen);
            szUri = szUri.Replace("#spc#", pBuscarEsp);
            sz = FncTool_Imglink(szUri, "www_ncbi.png", "title", "Alt");
            szHtmImgLinks += sz;

            //9 www_zipcodezoo.jpg
            szUri = "http://zipcodezoo.com/Animals/T/#find#/";
            szUri = szUri.Replace("#find#", (pBuscarGen + "_" + pBuscarEsp));
            sz = FncTool_Imglink(szUri, "www_zipcodezoo.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            //9 www_wheatherbase.jpg
            szUri = "http://www.weatherbase.com";
            sz = FncTool_Imglink(szUri, "www_wheatherbase.jpg", "Wheaterbase", "Wheater database");
            szHtmImgLinks += sz;


            //=================================
            // 10 OTRAS WEBS GENERALISTAS
            //=================================
            szHtmImgLinks += "<hr/ ><h2 class=\"clearfix\"> Find in other generalistas sites</h2>";
            szUri = "http://www.flickr.com/search/?q=#find#";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = FncTool_Imglink(szUri, "www_Flicker.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 11 google images
            szUri = "http://www.google.com/images?safe=yes&q=%22#find#%22";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = FncTool_Imglink(szUri, "www_google.gif", "title", "Alt");
            szHtmImgLinks += sz;

            //12 picsearch.co
            szUri = "http://www.picsearch.com/search.cgi?q=%22#find#%22&cols=5&thumbs=20";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = FncTool_Imglink(szUri, "www_picssearch.png", "title", "Alt");
            szHtmImgLinks += sz;

            //13 photobucket
            szUri = "http://photobucket.com/images/#find#";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = FncTool_Imglink(szUri, "www_photobucket.com.jpg", "title", "Alt");
            szHtmImgLinks += sz;
            //string sz = m_Buscar.Replace(" ", "%20");

            // FIN
            return "<br/>" + szHtmImgLinks + "<br class=\"clearfix\" />";
        }


        public string FncTools_BldHtmlFamilyListGenus()
        {
            cls.bbdd.ClsReg_tdoclng_testudinesgroups oGroup = new cls.bbdd.ClsReg_tdoclng_testudinesgroups();
            string szText = "";
            if (oGroup.FncSqlFind(oRegFul.oRegTaxaAll.ATaxGrpL2240Family, m_IdLng))
            {
                szText = "<b>" + oGroup.DescriptionShort + "</b><br/>" + oGroup.Abstract;
            }
            string szHtml = "";
            string szSqlCmd = "select  ATaxGrpL2240Family, ATaxGrpL2270Genus, ATaxGrpL2280Specie, ATaxGrpL2282Authority, ATaxGrpL2283Year, DocId from tdoclng_testudines_taxa_all";
            szSqlCmd += " where ATaxGrpL2240Family='" + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + "' order by ATaxGrpL2240Family, ATaxGrpL2270Genus";

            DataTable oTb = new DataTable();
            cls.bbdd.ClsMysql.FncFill_datatable(ref szSqlCmd,ref oTb);
            
            
            
            szHtml = "<h3>Fam: " + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + " " + Resources.Strings.with + " " + oTb.Rows.Count.ToString() + " " + Resources.Strings.species + "</h3>";
            szHtml += szText;

            szHtml += "<h3>" + Resources.Strings.GenusList + " " + Resources.Strings.OfFamily + " " + oRegFul.oRegTaxaAll.ATaxGrpL2240Family + "</h3>";

            szHtml += "\n<ul>";
            string szGenusAnt = "";
            string szGenusAct = "";
            int iGenusCount = -1;
            string sz = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                szGenusAct = oRow["ATaxGrpL2270Genus"].ToString().Trim();

                if (iGenusCount == -1)
                {
                    szGenusAnt = szGenusAct;
                }
                if (szGenusAnt != szGenusAct)
                {
                    if (iGenusCount > 1)
                    {
                        sz = Resources.Strings.species;
                    }
                    else
                    {
                        sz = Resources.Strings.specie;

                    }
                    szHtml += "\n<li><i>" + szGenusAnt + "</i> ( " + iGenusCount.ToString() + " " + sz + ")</li>";
                    iGenusCount = 0;
                }
                iGenusCount++;
                szGenusAnt = szGenusAct;

            }
            if (iGenusCount >= 1)
            {
                sz = Resources.Strings.species;
            }
            else
            {
                sz = Resources.Strings.specie;

            }
            szHtml += "\n<li><i>" + szGenusAnt + "</i>( " + iGenusCount.ToString() + " " + sz + ")</li>";

            szHtml += "</ul>\n";
            oTb.Dispose();



            return szHtml;








        }

        //######################################################################
        //######################################################################
        //######################################################################
        //########################### toools end ###############################
        //######################################################################
        //######################################################################
        //######################################################################
        //######################################################################




        #region regTools
        //public string FncHtmFull()
        //{
        //    string szHtmlFull = "";
        //    m_VulgarName = Resources.Strings.VulgarNames+ ": " + oRegFul.oRegAbs.LTaxNameVulgar  + " [" + oRegFul.DocLngId + "], " + oRegFul.oRegTaxaAll.ATaxNameVulgarEN + "[en]<br/>";
        //    szHtmlFull = m_VulgarName + FncHtmlAbstract();
        //    return szHtmlFull;
        //}
        private string FncBldHtmlImgThumbRight(string szUrl, string szAlt)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegTaxaAll.ATaxNameVulgarEN + ", " + oRegFul.oRegTaxaAll.ATaxNameVulgarES+ " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath))
            {
                szUrl = "/a_img/noimage200px.png";
            }

            szHtml += "<img  src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\" style=\"max-width:200px; display:block; \"><br />";

            return szHtml;
        }
        private string FncBldHtmlImgThumb(string szUrl, string szAlt)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegTaxaAll.ATaxNameVulgarEN + ", " + oRegFul.oRegTaxaAll.ATaxNameVulgarES + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath))
            {
                szUrl = "/a_img/noimage200px.png";
            }

            szHtml += "<img  src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\" style=\"max-width:200px; display:block; \"><br />";

            return szHtml;
        }
        private string FncBldHtmlImgThumb_side(string szUrl, string szAlt, string szNoImage)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegTaxaAll.ATaxNameVulgarEN + ", " + oRegFul.oRegTaxaAll.ATaxNameVulgarES + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath))
            {
                if (szNoImage == "")
                {
                    szUrl = "/a_img/noimage200px.png";
                }
                else
                {
                    szUrl = szNoImage;
                }
            }

            szHtml += "<img class=\"imgleft\" style=\"max.height:180px; max-width:180px;\" src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\"  />";
            // szHtml += "<img style=\"float:right;max.height:180px; max-width:200px; display:inline-block;\" src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\"  />";

            return szHtml;
        }
        private string FncBldHtmlImgCenter(string szUrl, string szAlt, string szNoImage)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegTaxaAll.ATaxNameVulgarEN+" "+ oRegFul.oRegTaxaAll.ATaxNameVulgarES + " (" + oRegFul.oRegTaxaAll.ATaxGrpL2270Genus + " " + oRegFul.oRegTaxaAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || szPath.Contains("noimage"))
            {
                if (szNoImage == "")
                {
                    szUrl = "/a_img/noimage1024px.png";
                }
                else
                {
                    szUrl = szNoImage;
                }
            }

            szHtml += "<img src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\" class=\"align_img_center\" \">";

            return szHtml;
        }
        private string FncBldHtmSecction(string szSectionFileTitle, string szSecctionText)
        {
            if (szSecctionText == "") szSecctionText = Resources.Strings.Opps_Nodata;
            string szHtml = "";


            szHtml += m_DivRow_Start;
            szHtml += "<h2>" + szSectionFileTitle + "</h2>";
            szHtml += szSecctionText;
            // szSecctionText = HttpUtility.HtmlDecode(szSecctionText);
            //szHtml += szSecctionText.Replace("<p>", "").Replace("</p>", "");
            szHtml += m_DivRow_End;
            return szHtml;
        }
     
        /// <summary>
        /// 2008 return htm index of taxon sheets
        /// </summary>
        /// <param name="TabSelect"></param>
        /// <param name="szTitle"></param>
        /// <param name="szSectionFilePanel"></param>
        /// <returns></returns>
        private string FncBldHtmlIndex(cls.ClsGlobal.E_TortoiseChapters TabSelect, String szTitle, string szSectionFilePanel)
        {



            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            //szTitle = "<h4>" +"titulo" +"</h4>";
            string szSumary = "</hr><h4>" + m_EspecieName + Resources.Strings.Summary + "</h4>" + oRegFul.oRegDesc.LDesAbstract;
            string szHtmlTab = "";
            string szTit = "";
            string szUrl = "/" + oRegFul.DocLngId + "/tortoises/tortoise/" + oRegFul.DocId.ToString() + "/";
            string szClass = "";
            //<nav class="contents">


            szHtmlTab += "";

            string szMenu = "";
            // szMenu += "\n<h4>" + m_EspecieName + Resources.Strings.chapters + ":</h4></hr>\n<contents>\n<ul class=\"contents\">";
            szMenu += "\n<div class=\"index\">\n<h2 class=\"index\">" + Resources.Strings.chapters + "</h2>\n<ul>";
            szTit = Resources.Strings.ind_Chapter01_00Abs;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.summary.ToString())
            { szClass = " class=\"selected\" "; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "abstract\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter02_00Des;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.description.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "description\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter03_00Nat;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.natural_history.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "natural_history\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter04_00_00_BioGeographic;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.distribution.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "distribution\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter04_02_01_AGeoKeyBiogeographicRealms;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.ecology.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "ecology\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter06_00Car;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.care.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "care\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";
            szMenu += "\n</ul>\n<ul>";
            szTit = Resources.Strings.ind_Chapter07_00Tax;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.taxonomy.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "taxonony\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            //------
            // ind_Chapter08Key

            szTit = Resources.Strings.ind_Chapter08_00IdeKey;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.identificationkeys.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "IdentificationKeys\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";


            //--------------
            szTit = Resources.Strings.ind_Chapter09_00Near;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.nearspecies.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "nearspecies\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter10_00Gal;
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.images.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "images\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";


            szTit = Resources.Strings.ind_Chapter11_00Bib;
            // szUrl = "#";
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.bibliography.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "bibliography\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Chapter12_00Notes;
            // szUrl = "#";
            if (TabSelect.ToString() == cls.ClsGlobal.E_TortoiseChapters.notes.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "notes\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_EspecieName + "\">" + szTit + "</a>\n</li>";
            //-------fin
            szMenu += "\n</ul>\n</div>\n\n";
            szHtmlTab += szMenu;
            //szHtmlTab += m_HtmlBoxResumen;

            oRegCache.FncWriteCache(m_IdDoc, m_IdLng, szSectionFilePanel, szHtmlTab, true);
            return szHtmlTab;

        }
        // dltabs2 crea uno del estilo de la cabecera
        private string FncBldHtmlPretyPhoto3(string szGalleryId, string pImgThun01, string pImgThun02, string pImgThun03, string pTitTop, string pTitBot, string pSectionFile)
        {
            oFB.FncGallery_New(szGalleryId, "imageslist");

            String pUrlThumbDefault = "";
            //--------------------------------------------------------
            string xpUrlThumb01 = pImgThun01;
            string xpUrlThumb02 = pImgThun02;
            string xpUrlThumb03 = pImgThun03;
            string xUrlTarget01 = "";
            string xUrlTarget02 = "";
            string xUrlTarget03 = "";
            FncBldUrlTest(ref xUrlTarget01, ref xpUrlThumb01, pUrlThumbDefault);
            oFB.FncGallery_AddPictureFB(xUrlTarget01, xpUrlThumb01, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref xUrlTarget02, ref xpUrlThumb02, pUrlThumbDefault);
            oFB.FncGallery_AddPictureFB(xUrlTarget02, xpUrlThumb02, pTitTop, pTitBot, pSectionFile);

            FncBldUrlTest(ref xUrlTarget03, ref xpUrlThumb03, pUrlThumbDefault);
            oFB.FncGallery_AddPictureFB(xUrlTarget03, xpUrlThumb03, pTitTop, pTitBot, pSectionFile);

            return oFB.HtmGalleryFB;
        }
        private string FncBldPhotoList(String szGalleryId, String pGalleryTit, String pTitTop, String pTitBot, ref StringCollection pImgListPath, string pSectionFile)
        {
            string szHtml = "";
            string szUrlTarget = "";
            string szpUrlThumbDefault = "";
            string szImg = "";
            oFB.FncGallery_New(szGalleryId, pGalleryTit);
            int n = 0;
            foreach (string imgpath in pImgListPath)
            {
                n++;
                szImg = imgpath.ToLower().Trim();
                szUrlTarget = "";

                FncBldUrlTest(ref szUrlTarget, ref szImg, szpUrlThumbDefault);

                oFB.FncGallery_AddPictureFB(szUrlTarget, szImg, pTitTop, pTitBot, pSectionFile);
            }
            szHtml = oFB.HtmGalleryFB;

            return szHtml;
        }
        private void FncBldUrlTest(ref String pUrlTarget, ref String pUrlThumb, String pUrlThumbDefault)
        {
            pUrlThumb = pUrlThumb.Trim().ToLower();
            pUrlTarget = pUrlTarget.Trim().ToLower();
            pUrlThumbDefault = pUrlThumbDefault.Trim().ToLower();
            String szUrlTargetDefault = "/a_img/noimage600px.png";
            // Por si las fly miniatura por defecto
            if (pUrlThumbDefault == "") pUrlThumbDefault = "/a_img/noimage200px.png";

            // si no existe el fichero thumb poner miniatura por defecto
            String szUrlTumbPath = ((ClsGlobal.UrlMMedia + pUrlThumb).Replace("\\", "/")).Replace("//", "/");

            if (!System.IO.File.Exists(szUrlTumbPath) || pUrlThumb.Contains("noimage"))
            {
                pUrlThumb = pUrlThumbDefault;
            }
            else
            {
                pUrlThumb = pUrlThumb.Trim().ToLower();
            }
            // buscar la imagen ligada al thumbnail
            string szUrlTargetMed = "";
            string szUrlTargetBig = "";

            if (pUrlTarget == "")
            {
                szUrlTargetMed = pUrlThumb.Replace("min.jpg", "med.jpg");
                szUrlTargetMed = pUrlThumb.Replace("_minx.jpg", "_med.jpg");
                szUrlTargetBig = pUrlThumb.Replace("min.jpg", "big.jpg");
                szUrlTargetBig = pUrlThumb.Replace("_minx.jpg", "_big.jpg");

            }
            else
            {
                szUrlTargetMed = pUrlThumb.Replace("min.jpg", "med.jpg");
                szUrlTargetMed = pUrlThumb.Replace("_minx.jpg", "_med.jpg");
                szUrlTargetBig = pUrlThumb.Replace("min.jpg", "big.jpg");
                szUrlTargetBig = pUrlThumb.Replace("_minx.jpg", "_big.jpg");

            }


            // comprobar la existencia del la imagen target,si no exsite poner la de defecto
            String szUrlTargetPathMed = ((ClsGlobal.UrlMMedia + szUrlTargetMed).Replace("\\", "/")).Replace("//", "/");
            String szUrlTargetPathBig = ((ClsGlobal.UrlMMedia + szUrlTargetBig).Replace("\\", "/")).Replace("//", "/");

            // si la imagen destino de link no existe devolver  imagen por defercto

            pUrlTarget = szUrlTargetDefault;

            if (System.IO.File.Exists(szUrlTargetPathMed))
            {
                pUrlTarget = szUrlTargetMed;
            }
            if (System.IO.File.Exists(szUrlTargetPathBig))
            {
                pUrlTarget = szUrlTargetBig;
            }

        }

        private string FncBldHtmlPretyPhotoAlone(string pImgThun, string pTitTop, string pTitBot, string pSecction)
        {
            string szImgTarget = "";
            string szFileTargetPath = "";
            string szHtml = "";
            //prevenir que no hay foto
            string szPath = ((ClsGlobal.UrlMMedia + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
                szImgTarget = pImgThun;
            }
            else
            {
                pImgThun = pImgThun.Trim().ToLower();

                // buscar la imagen ligada al thumbnail
                szImgTarget = pImgThun.Replace("min.jpg", "med.jpg");
                szImgTarget = szImgTarget.Replace("minx.jpg", "med.jpg");
                szFileTargetPath = (ClsGlobal.DirMMedia + szImgTarget).Replace("\\", "/").Replace("//", "/");
            }

            szHtml = oFB.FncHtmlAloneRowPhotoFB_med(pImgThun, pTitTop, pSecction);
            return szHtml;
        }



        /// <summary>
        /// Nuevo 2018
        /// Fancybox iframe con imagen y titulo
        /// </summary>
        /// <param name="pUrlIframe">Url a abrir en ifrmae</param>
        /// <param name="pImgThun">Imagen sobre la que hacer click para abrir iframe</param>
        /// <param name="pTitle">Titulo</param>
        /// <param name="pCaption">Caption adicional</param>
        /// <returns></returns>
        private string FncBldHtmlFancyBoxIframeAlone(String pUrlIframe, String pImgThun, String pTitle, String pCaption)

        {

            // documentation
            //http://fancyapps.com/fancybox/3/docs/#iframe
            string szPath = cls.ClsUtils.FncPathCombine(ClsGlobal.DirRoot, pImgThun);
            //string szPath = ((ClsGlobal.DirRoot + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
            }

            String szHtml = oFB.FncHtmlAloneIframeInlineImageFB(pUrlIframe, pImgThun, pTitle, pCaption);


            return szHtml;
        }
        /// <summary>
        /// 2018 se llamaSustituido por  FncBldHtmlFancyBoxIframeAlone(string pUrlIframe, string pImgThun, string pTitle, string pCaption)
        /// </summary>
        /// <param name="pIdModal"></param>
        /// <param name="pUrlIframe"></param>
        /// <param name="pImgThun"></param>
        /// <param name="pTitTop"></param>
        /// <param name="pTitBot"></param>
        /// <returns></returns>
        private string FncBldHtmlPretyPhotoIframeAlone(string pIdModal, string pUrlIframe, string pImgThun, string pTitTop, string pTitBot)
        {
            string szPath = ((ClsGlobal.UrlMMedia + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
            }
            string szHtml = "";
            szHtml += "\n<a  href=\"#\" data-reveal-id=\"" + pIdModal + "\"   data-reveal>";
            szHtml += "\n<img src=\"" + pImgThun + "\" />";
            szHtml += "\n</a>";
            szHtml += "\n<div id=\"" + pIdModal + "\" class=\"reveal-modal\" data-reveal>";
            szHtml += "\n<iframe src=\"" + pUrlIframe + "\" width =\"100%\"  height=\"300px\" ></iframe>";
            szHtml += "\n<a class=\"close-reveal-modal\">&#215;</a>";
            szHtml += "\n</div>";
            return szHtml;
        }
        private string FncBldHtmlPretyPhotoIframeAloneInline(string pUrlIframe, string pImgThun, string pTitTop, string pTitBot)
        {
            string szPath = ((ClsGlobal.UrlMMedia + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
            }


            oFB.FncGallery_New("imagesId", "GalleryTit");
            string szHtml = oFB.FncHtmlAloneIframeInlineImageFB(pUrlIframe, pImgThun, pTitTop, pTitBot);
            return szHtml;
        }
        // 2008 se llama
        public void Fnc_calc_m_LastUpdate()
        {

            m_LastUpdate = "<p class=\"align_text_right\">" + Resources.Strings.date_last_update + ": " + oRegFul.oRegOthAll.AOth_WorkFlow_LastUpdate.ToLongDateString() + "</p>";

        }


        private string FncCultureGetString(string szTranslate)
        {


            //ResourceManager m_RManagerTaxon = new ResourceManager("page_taxon.resx", typeof(www).Assembly);  


            ResourceManager m_RManagerTaxon = new ResourceManager("www.page_taxon.resx", Assembly.GetExecutingAssembly());
            string szTranslated = "";
            string sz = szTranslate.ToLower();
            try
            {

                szTranslated = m_RManagerTaxon.GetString(szTranslate, CultureInfo.CurrentCulture);
                szTranslated = m_RManagerTaxon.GetString(sz, CultureInfo.CurrentCulture);
            }
            catch (Exception xcpt)

            {
                sz = xcpt.Message;
                szTranslated = szTranslate + "*";
            }
            return szTranslated;
        }
        #endregion regtools
        //######################################################################
        //######################################################################
    }
}
