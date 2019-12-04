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

namespace testudines.cls.bbdd
{
    public class ClsReg_tdoclng_taxon_ful_html
    {
        private cls.tools.ClsGalleryFBox oPP = new cls.tools.ClsGalleryFBox();
        cls.bbdd.ClsReg_tdoclng_media oReg_Media = new ClsReg_tdoclng_media();
        //private ResourceManager m_RManagerTaxon = new ResourceManager("page_taxon",System.Reflection.Assembly.Load("App_LocalResources"));
//        System.Reflection.Assembly.Load("App_LocalResources")
        

        private string m_especiename = "";

        //private string m_HtmlBoxResumen = "";
       // private string m_HtmlBoxResumenShort = "";
        private string m_LastUpdate = "";
        private UInt64 m_IdDoc = 0;
        private string m_IdLng = "";
      //  string szHtmlIucnImg = "";
        enum eTortoisesCapitules { Abstract, Description, Natural_History, Distribution, Care, Ecology, KeysIdentification, Taxonomy, identification, Bibliography, Notes, Gallery, ToDo, Old, NearSpecies }
        private cls.cache.ClsCache_Reg_tdoclng_taxon oRegCache = new cls.cache.ClsCache_Reg_tdoclng_taxon();
        private cls.bbdd.ClsReg_tdoclng_taxon_ful oRegFul = new ClsReg_tdoclng_taxon_ful();
        private cls.bbdd.ClsReg_tdoc oRegDoc = new testudines.cls.bbdd.ClsReg_tdoc();
        private cls.bbdd.ClsReg_tdoclng oRegDocLng = new testudines.cls.bbdd.ClsReg_tdoclng();
      //  private string m_VulgarName = "";
        private cls.bbdd.ClsReg_tdoclng_taxon_all oRegTxAll = new ClsReg_tdoclng_taxon_all();
        private cls.bbdd.ClsReg_tdoclng_taxon_lngabst oRegTxLngAbs = new ClsReg_tdoclng_taxon_lngabst();
        private cls.bbdd.ClsReg_tdoclng_ecozones oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_ecozones();
        private cls.bbdd.ClsReg_tdoclng_taxon_groups oRegGrp = new ClsReg_tdoclng_taxon_groups();
        private cls.bbdd.ClsReg_tdoclng_taxon_keys_lng oRegKeyNode = new ClsReg_tdoclng_taxon_keys_lng();
      

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
      
        private string m_NameSpecieWithVulgar="";
        public ClsReg_tdoclng_taxon_ful_html()
        {
            //   m_DivRow_EndStart = m_DivRow_End + m_DivRow_Start;


        }
        public void fncRebuildCache()
        {
           
            fnc_calc_m_LastUpdate();

            fncHtmlGallery(true, 1);
            fncHtmlAbstract(true);
            fncHtmlbibliography(true);
            fncHtmlCare(true);
            fncHtmlRngHabitatEcologyClimate(true);
            fncHtmlDescription(true);
            //fncHtmlGallery(true, 1);
            fncHtmlRngHabitatRange(true);
            fncHtmlNatural_History(true);
            fncHtmlNearSpecies(true);
            fncHtmlNotes(true);
            fncHtmlTaxonony(true);
            fncHtmlIdentificationKeys(true);
           // fncHtmlToDo(true);

        }


        public bool fncSqlFindTaxon_ful_html(UInt64 IdDoc, string IdLng)
        {
            m_IdDoc = IdDoc;
            m_IdLng = IdLng;
            bool b = true;
            b = oRegDoc.fncSqlFind(IdDoc);
            b = oRegDocLng.fncSqlFind(IdDoc, IdLng);
            b = oRegFul.fncSqlFind(IdDoc, IdLng);
            m_especiename = oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ": ";
            m_NameSpecieWithVulgar = oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";

            return b;
        }
        private  string fncBldHtmlBoxIUCN()
        {
            string  szHtmlImgIucn ="";
            cls.bbdd.ClsReg_tmst_iucn_redlist oRegIucn = new testudines.cls.bbdd.ClsReg_tmst_iucn_redlist();
            try
            {
                if (oRegFul.oRegAll.ADngLevelRedList != "")
                {
                    oRegIucn.fncSqlFind(Convert.ToUInt64(oRegFul.oRegAll.ADngLevelRedList), oRegFul.DocLngId);
                    string szUrl = "/" + oRegFul.DocLngId + "/dlg_iucn_redlist/" + oRegFul.oRegAll.ADngLevelRedList;
                    szHtmlImgIucn = "\n" + fncBldHtmlPretyPhotoIframeAlone("iframeIucn", szUrl, oRegIucn.UrlImg, "Help", "IUN Red List");
                    //string szHtmlImgIucn =   fncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegIucn.UrlImg, "Help", "Climate") ;
                }
            }
            catch(Exception)
            {;}
             return szHtmlImgIucn;
         
        }
        //private void fncHtmlBoxResumen()
        //{
        //    m_HtmlBoxResumen = "";
        //    m_HtmlBoxResumenShort = "";

        //    string szHtmlSort = "";
        //    string szHtmlLong = "";
        //    string szImg = oRegFul.oRegAllFile.AAbsImg_Specie.ToLower().Replace("med.jpg", "minx.jpg");
        //    szImg=szImg.Replace("ful.jpg", "minx.jpg");
        //    string szHtmlImgEsp = "\n" + fncBldHtmlImgMedAlone(szImg, oRegFul.oRegAll.ATaxNameRecomended, "") + "\n";
        //    string szHtmlImgIucn = "";
        //        szHtmlImgIucn += fncHtmlBoxIUCN();
                
           

        //    szHtmlLong = szHtmlImgEsp +  szHtmlImgIucn;
        //    szHtmlSort +=   szHtmlImgIucn;
        //    m_HtmlBoxResumen = szHtmlLong;
        //    m_HtmlBoxResumenShort = szHtmlSort;
        //}

        private String fncBldReadMore(string pUrlSecction, string pTextSeccion)
        {
            string szHtml = "<br/><span class=\"readmore \"><a  href=\"/" + m_IdLng + "/taxons/taxon/" + m_IdDoc.ToString() + "/" + pUrlSecction + "\"> " + Resources.Strings.ind_Capitule_readfularticle + ": " + pTextSeccion + "</a></span>";
            return szHtml;
        }
       
        public string fncHtmlAbstract(bool bCacheRebuild)
        {
            string szHtmlTabs = "";
            string szHtml = "";
            string szSectionFile = "abstract";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            //
            //..............................................................
            // 
            m_oAccordion.Init("AccAbs"); 
            
            
           



            string szUrlIni = "<a href=\"/" + oRegDocLng.DocLngId + "/taxons/taxon/" + oRegDocLng.DocId.ToString() + "/";
            string szUrlMed = "";
            string szUrl = "";
            string szSecctionTit = "";
            string szSecction = "";
            // absabsDes -----------------------------
            /*
             scnAAbsImg_Specie.ImageUrl = oRegFull.oRegAllFile.AAbsImg_Specie;
            scnAAbsImg_HNatural.ImageUrl = oRegFull.oRegAllFile.AAbsImg_HNatural;
            scnAAbsImg_Range.ImageUrl = oRegFull.oRegAllFile.AAbsImg_Range;
             * 
             * oPP.fncHtmlAloneRowPhotoFB( pImgThun, pTitTop,  pSecction);
             */
            szUrlMed = szUrlIni + eTortoisesCapitules.Abstract.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule01_00Abs + "\">";
            szSecctionTit +=  Resources.Strings.ind_Capitule01_01AbsDes ;
            szSecction += oPP.fncHtmlAloneRowPhotoFB_med(oRegFul.oRegAllFile.AAbsImg_Specie, m_especiename, "ind_Capitule01_01AbsDes");

            string szImgIUCN = "<span class=\"imgright\">" + fncBldHtmlBoxIUCN() + "</span>";
            szSecction +=szImgIUCN+ oRegFul.oRegAbs.LAbsDes;
            szSecction += "<br/>" + Resources.Strings.ADesMeasureLenghtCm + "&#177;" + oRegFul.oRegAll.ADesMeasureLenghtCm.ToString();
            szSecction += "<br/>" + Resources.Strings.ADesMeasureWeightGrm + "&#177;" + oRegFul.oRegAll.ADesMeasureWeightGrm.ToString();
            
            m_oAccordion.addSecction(szSecctionTit, szSecction, true,true);
            
            
            // absabsHis -----------------------------
            szUrlMed = szUrlIni + eTortoisesCapitules.Natural_History.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule01_02AbsNat + "\">";
            szSecctionTit =  Resources.Strings.ind_Capitule01_02AbsNat ;
            szSecction = oPP.fncHtmlAloneRowPhotoFB_med(oRegFul.oRegAllFile.AAbsImg_HNatural, m_especiename + " Natural live", "ind_Capitule01_02AbsNat");
            //szSecction = fncBldHtmlImgMedAlone(oRegFul.oRegAllFile.AAbsImg_HNatural,m_NameSpecieWithVulgar, "bot");
            
            szSecction += oRegFul.oRegAbs.LAbsHisNat;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false,true);

          
               // absabsRangHabitat -----------------------------
               szUrlMed = szUrlIni + eTortoisesCapitules.Distribution.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule01_02AbsNat + "\">";
               szSecctionTit =  Resources.Strings.ind_Capitule01_03AbsRng ;
            //szSecction = fncBldHtmlImgMedAlone(oRegFul.oRegAllFile.AAbsImg_Range, m_NameSpecieWithVulgar, "bot");

            szSecction = oPP.fncHtmlAloneRowPhotoFB_med(oRegFul.oRegAllFile.AAbsImg_Range, m_especiename + " Range distribution", "ind_Capitule01_03AbsRng");
               //imagen de clima
               oRegEco.fncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegHabiAll.AHabClimateEcozoneKey);
               szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegHabiAll.AHabClimateEcozoneKey;
               szSecction +="<div class=\"row\">"+ m_DivImgRight200_start;
               szSecction += fncBldHtmlPretyPhotoIframeAlone("iframeClimate", szUrl, oRegEco.ImgRainTemp, "Help", "Climate rain temp");
               szSecction += m_DivImgRight200_end;

            
            
                szSecction += oRegFul.oRegAbs.LAbsRngHab+ "</div>";
               m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
          

               // - AbsRngclimate -----------------------------------

            
            
 
            //szUrlMed = szUrlIni + eTortoisesCapitules.Ecology.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule05_00RngEco + "\">";
            //   szSecctionTit = Resources.Strings.ind_Capitule01_05AbsClim  ;
            //   szSecction += oRegFul.oRegAbs.LAbsClimateEcozone;
            //  // szSecction += fncBldReadMore("ecology", Resources.Strings.ind_Capitule01_05AbsClim);
            //   m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
              
           // taxonomia -----------------------------------
          /*
            szUrlMed = szUrlIni + eTortoisesCapitules.Taxonomy.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule07_00Tax + "\">";
           szSecctionTit = Resources.Strings.ind_Capitule01_04AbsTax  ;
           szSecction = "\n<ul class=\"no-bullet\">";
           if ( oRegFul.HtmlToolTipSubOrder.Trim ().Length >5) szSecction += "\n<li>" + oRegFul.HtmlToolTipSubOrder + "</li>\n";
           if (oRegFul.HtmlToolTipFamily.Trim().Length > 5) szSecction += "\n<li>" + oRegFul.HtmlToolTipFamily + "</li>\n";
           if (oRegFul.HtmlToolTipGenus.Trim().Length > 5) szSecction += "\n<li>" + oRegFul.HtmlToolTipGenus + "</li>\n";
           szSecction += "\n<li>" + Resources.Strings.scnATaxNameRecomendedTit + ": " + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + " " + oRegFul.oRegAll.ATaxGrpL2282Authority + " " + oRegFul.oRegAll.ATaxGrpL2283Year + "</li>\n";
           szSecction += "\n</ul>\n";
           if (oRegFul.oRegAbs.LTaxEtimology != "")
           {
               szSecction += oRegFul.oRegAbs.LTaxEtimology;
           }
           if (oRegFul.oRegAll.ATaxGrpL2281SpecieSub != "")
           {
               szSecction += "<h3>" + Resources.Strings.ind_Capitule01_04AbsTax_subspecies + "</h3>" + oRegFul.oRegAll.ATaxGrpL2281SpecieSub;
           }
           szSecction += fncBldReadMore("taxonony", Resources.Strings.ind_Capitule01_04AbsTax);
           m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            */

          


               // Near species  ------------------------------------
                     
               szUrlMed = szUrlIni + eTortoisesCapitules.Gallery.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule09_00Near + "\">";
               szSecctionTit = Resources.Strings.ind_Capitule01_05AbsNear   ;
               //szHtmlszHtmlLeft += "<h2><a  class=\"anchor\" name=\"ind_absnear\">" + Resources.Strings.ind_Capitule01_09absNear + "</a>" + m_gotop + "</h2>";
               szSecction = fncBldHtmlFamilyListGenus();
               szSecction += fncBldReadMore("nearspecies", Resources.Strings.ind_Capitule01_05AbsNear);
               m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

               // Gallery------------------------------------
               szSecction = "";
                
              

               try
               {
                   string szPathImgs = ClsGlobal.DirRoot + oRegFul.oRegAll.AGallery;
              
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
                   string szText = Resources.Strings.ind_Capitule01_10absGalIntro.Replace("#999#", listFileCount.ToString());
                   szText = szText.Replace("#specie#", m_especiename);
                   string szgallerylink = szUrlIni + eTortoisesCapitules.Gallery.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule09_00Near + "\">" + Resources.Strings.gallery + " " + m_especiename + "</a>";
                   szText = szText.Replace("#gallerylink#", szgallerylink);





                   szUrlMed = szUrlIni + eTortoisesCapitules.Abstract.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule10_00Gal + "\">";

                   string pGallId = "IdGallAbst";
                   string pGallTit = oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie;
                   string pTitBot = pGallTit;
                   string pTitTop = pGallTit + "," + oRegFul.oRegAll.ATaxGrpL2282Authority + " " + oRegFul.oRegAll.ATaxGrpL2283Year;

                   szSecctionTit = Resources.Strings.ind_Capitule01_06AbsGal;
                   szSecction = szText;
                   szSecction += fncBldPhotoList(pGallId, pGallTit, pTitTop, pTitBot, ref pImgCollection, "Capitule01_10absGalIntro");
                   //szSecction += "</div>";
                   szUrl = oRegFul.oRegAll.AGallery;


                   szSecction += fncBldReadMore(eTortoisesCapitules.Gallery.ToString().ToLower(), Resources.Strings.ind_Capitule01_06AbsGal);
                   m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

               }
               catch { }
                  //---------------------------------------

                  

            //-- write cache and return -------------------
                  szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Abstract, Resources.Strings.ind_Capitule01_05AbsNear, szSectionFilePanel);
            szHtml = szHtmlTabs + m_oAccordion.html +m_LastUpdate+  szHtmlTabs ;
            
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return  szHtml;
        }
        //--------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------
        public string fncBldHtmlFamilyListGenus()
        {
            cls.bbdd.ClsReg_tdoclng_taxon_groups oGroup = new ClsReg_tdoclng_taxon_groups();
            string szText = "";
            if (oGroup.fncSqlFind(oRegFul.oRegAll.ATaxGrpL2240Family, m_IdLng))
            {
                szText = "<b>" + oGroup.DescriptionShort + "</b><br/>" + oGroup.Abstract;
            }
            string szHtml = "";
            string szSqlCmd = "select  ATaxGrpL2240Family, ATaxGrpL2270Genus, ATaxGrpL2280Specie, ATaxGrpL2282Authority, ATaxGrpL2283Year, DocId from tdoclng_taxon_all";
            szSqlCmd += " where ATaxGrpL2240Family='" + oRegFul.oRegAll.ATaxGrpL2240Family + "' order by ATaxGrpL2240Family, ATaxGrpL2270Genus";
            DataTable oTb = new DataTable();
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oSqlCmd = new MySqlCommand(szSqlCmd, oSqlCnn);
            MySqlDataAdapter oSqlDA = new MySqlDataAdapter(oSqlCmd);
            oSqlCnn.Open();
            oSqlDA.Fill(oTb);
            szHtml = "<h3>Fam: " + oRegFul.oRegAll.ATaxGrpL2240Family + " " + Resources.Strings.with + " " + oTb.Rows.Count.ToString() + " " + Resources.Strings.species + "</h3>";
            szHtml += szText;

            szHtml += "<h3>"+Resources.Strings.GenusList + " " +Resources.Strings.OfFamily +" "+oRegFul.oRegAll.ATaxGrpL2240Family +"</h3>";
            
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
                    if (iGenusCount>1) 
                    {
                        sz = Resources.Strings.species;
                    }
                    else
                    {
                        sz=Resources.Strings.specie;
                    
                    }
                        szHtml += "\n<li><i>" + szGenusAnt + "</i> ( " + iGenusCount.ToString()+" " + sz+")</li>";
                    iGenusCount=0;
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
            szHtml +=  "\n<li><i>" + szGenusAnt + "</i>( " + iGenusCount.ToString()+" " + sz+ ")</li>";
                    
            szHtml += "</ul>\n";
            oSqlDA.Dispose();
            oSqlCmd.Dispose();
            oSqlCnn.Close();
            oSqlCnn.Dispose();



            return szHtml;
 







        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public string fncBldHtmlFamilyList()
        {
            cls.bbdd.ClsReg_tdoclng_taxon_groups oGroup = new ClsReg_tdoclng_taxon_groups();
            string szText = "";
            if (oGroup.fncSqlFind(oRegFul.oRegAll.ATaxGrpL2240Family, m_IdLng))
            {
                szText = "<b>" + oGroup.DescriptionShort + "</b><br/>" + oGroup.Abstract;
            }
            string szHtml = "";
            string szSqlCmd = "select  ATaxGrpL2240Family, ATaxGrpL2270Genus, ATaxGrpL2280Specie, ATaxGrpL2282Authority, ATaxGrpL2283Year, DocId from tdoclng_taxon_all";
            szSqlCmd += " where ATaxGrpL2240Family='" + oRegFul.oRegAll.ATaxGrpL2240Family + "' order by ATaxGrpL2240Family, ATaxGrpL2270Genus";
            DataTable oTb = new DataTable();
            MySqlConnection oSqlCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oSqlCmd = new MySqlCommand(szSqlCmd, oSqlCnn);
            MySqlDataAdapter oSqlDA = new MySqlDataAdapter(oSqlCmd);
            oSqlCnn.Open();
            oSqlDA.Fill(oTb);
            szHtml = "<h4>Fam: " + oRegFul.oRegAll.ATaxGrpL2240Family + " " + Resources.Strings.with + " " + oTb.Rows.Count.ToString() + " " + Resources.Strings.species + "</h4>";
            szHtml += szText;
            szHtml += "\n<ul>";
            string szUrl = "";
            foreach (DataRow oRow in oTb.Rows)
            {
                szUrl = "<a href=\"/" + m_IdLng + "/taxons/taxon/" + oRow["DocId"].ToString() + "/descrition\">";
                szHtml += "\n<li><i>" + szUrl + oRow["ATaxGrpL2270Genus"].ToString() + " " + oRow["ATaxGrpL2280Specie"].ToString() + "</i> (" + oRow["ATaxGrpL2282Authority"].ToString() + ",  " + oRow["ATaxGrpL2283Year"].ToString() + ")</a></li>";
            }
            szHtml += "</ul>\n";
            oSqlDA.Dispose();
            oSqlCmd.Dispose();
            oSqlCnn.Close();
            oSqlCnn.Dispose();



            return szHtml;
        }

        public string fncHtmlDescription(bool bCacheRebuild)
        {
            m_oAccordion.Init("AcDesc");
             string szHtmlTabs="";
            string szImgHelpMin = "";
            string szImgHelpBig = "";

            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "description";


            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            string szHtmlszHtmlLeft = ""; ;
            //string szUrmMed = "";
            string szSecctionTit = "";
            string szSecction = "";
            szSecctionTit = Resources.Strings.ind_Capitule02_01desAbs;
            szSecction = fncBldHtmlPretyPhoto3(
            "gallerylist",
            oRegFul.oRegAllFile.ADesImg_DesType01,
            oRegFul.oRegAllFile.ADesImg_DesType02,
            oRegFul.oRegAllFile.ADesImg_DesType03,
            oRegFul.oRegAll.ATaxNameRecomended,
            oRegFul.oRegAbs.Title, "Capitule02_01desAbs");
            
            //szSecction = fncBldHtmlImgMedAlone(oRegFul.oRegAllFile.AAbsImg_HNatural, szName, "bot");
            szSecction += Resources.Strings.ADesMeasureLenghtCm + ": " + oRegFul.oRegAll.ADesMeasureLenghtCm.ToString() + "&equiv;";
            szSecction += "<br/>" + Resources.Strings.ADesMeasureWeightGrm + ": " + oRegFul.oRegAll.ADesMeasureWeightGrm.ToString() + "&equiv;";
            szSecction += "<br/>" + oRegFul.oRegDesc.LDesGeneralSize.ToString();

            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //--------------------------------------------------------
            /* DESCRIPCION DORSAL */
            szSecctionTit = Resources.Strings.ind_Capitule02_02DesDors;
            szSecction = fncBldHtmlPretyPhoto3(
            "gallerylist",
            oRegFul.oRegAllFile.ADesImg_BodyDorsal01,
            oRegFul.oRegAllFile.ADesImg_BodyDorsal02,
            oRegFul.oRegAllFile.ADesImg_BodyDorsal03,
            oRegFul.oRegAll.ATaxNameRecomended,
            oRegFul.oRegAbs.Title, "ind_Capitule02_02DesDors");
        

            szImgHelpMin = "/a_img/hlp_descr/view_dorsal_off.png";
            szImgHelpBig = "/a_img/hlp_descr/view_dorsal_on.png";
            szSecction += fncBldHtmlSectionImgHelp(szImgHelpMin, szImgHelpBig, "DivDorsalHlp", "", oRegFul.oRegDesc.LDesViewDorsal);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION FRONTAL */

           szSecctionTit =  Resources.Strings.ind_Capitule02_03DesFrontal;
           szSecction = fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ADesImg_BodyFrontal01,
              oRegFul.oRegAllFile.ADesImg_BodyFrontal02,
              oRegFul.oRegAllFile.ADesImg_BodyFrontal03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule02_03DesFrontal");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_frontal.png", oRegFul.oRegDesc.LDesViewFrontal);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION LATERAL */
            szSecctionTit =  Resources.Strings.ind_Capitule02_04DesLateral  ;
            szSecction = fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_BodyLateral01,
             oRegFul.oRegAllFile.ADesImg_BodyLateral02,
             oRegFul.oRegAllFile.ADesImg_BodyLateral03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_04DesLateral");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_lateral.png", oRegFul.oRegDesc.LDesViewLateral);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            
            //--------------------------------------------------------
            /* DESCRIPCION POSTERIOR */

              szSecctionTit =  Resources.Strings.ind_Capitule02_05DesRear;
            szSecction =fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_BodyRear01,
             oRegFul.oRegAllFile.ADesImg_BodyRear02,
             oRegFul.oRegAllFile.ADesImg_BodyRear03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_05DesRear");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_rear.png", oRegFul.oRegDesc.LDesViewRear);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION VENTRAL y puente */

            szSecctionTit = Resources.Strings.ind_Capitule02_06DesVentralBridge ;
            
            szSecction = fncBldHtmlPretyPhoto3(
            "gallerylist",
            oRegFul.oRegAllFile.ADesImg_BodyVentral01,
            oRegFul.oRegAllFile.ADesImg_BodyVentral02,
            oRegFul.oRegAllFile.ADesImg_BodyVentral03,
           oRegFul.oRegAll.ATaxNameRecomended,
            oRegFul.oRegAbs.Title, "ind_Capitule02_06DesVentral");
            szSecction += fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_BodyBridge01,
             oRegFul.oRegAllFile.ADesImg_BodyBridge02,
             oRegFul.oRegAllFile.ADesImg_BodyBridge03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_07DesBridge");
            

            szImgHelpMin = "/a_img/hlp_descr/view_ventral_off.png";
            szImgHelpBig = "/a_img/hlp_descr/view_ventral_on.png";
            szSecction += fncBldHtmlSectionImgHelp(szImgHelpMin, szImgHelpBig, "divIdVentralHlp", "", oRegFul.oRegDesc.LDesViewVentralBridge);

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION CABEZA Y CUELLO */
            szSecctionTit = Resources.Strings.ind_Capitule02_07DesHeadNeck;
            szSecction = fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_OtherHead01,
             oRegFul.oRegAllFile.ADesImg_OtherHead02,
             oRegFul.oRegAllFile.ADesImg_OtherHead03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_08DesHeadNeck");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_head.png", oRegFul.oRegDesc.LDesViewHeadNeck);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION PATAS  */
        
             szSecctionTit = Resources.Strings.ind_Capitule02_08DesLegsTail;

             szSecction = fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_OtherLegs01,
             oRegFul.oRegAllFile.ADesImg_OtherLegs02,
             oRegFul.oRegAllFile.ADesImg_OtherLegs03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_09DesLegs");
             szSecction += fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ADesImg_OtherTail01,
              oRegFul.oRegAllFile.ADesImg_OtherTail02,
              oRegFul.oRegAllFile.ADesImg_OtherTail03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule02_10DesTail");
   
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_legs.png", oRegFul.oRegDesc.LDesViewLegsTail);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            
            //--------------------------------------------------------
            /* DESCRIPCION CRIAS */

            szSecctionTit = Resources.Strings.ind_Capitule02_09DesBabies ;

            szSecction = fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_BabyDorsal01,
             oRegFul.oRegAllFile.ADesImg_BabyDorsal02,
             oRegFul.oRegAllFile.ADesImg_BabyDorsal03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_11DesBabies");
            szSecction += fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_BabyVentral01,
             oRegFul.oRegAllFile.ADesImg_BabyVentral02,
             oRegFul.oRegAllFile.ADesImg_BabyVentral03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule02_11DesBabies");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_babys.png", oRegFul.oRegDesc.LDesBabys);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //--------------------------------------------------------
            /* DESCRIPCION DIMORFISMO SEXUAL */

            szSecctionTit =  Resources.Strings.ind_Capitule02_10DesDimor ;
            szSecction= fncBldHtmlPretyPhoto3(
               "gallerylist",
               oRegFul.oRegAllFile.ADesImg_Dimorphism01,
               oRegFul.oRegAllFile.ADesImg_Dimorphism02,
               oRegFul.oRegAllFile.ADesImg_Dimorphism03,
               oRegFul.oRegAll.ATaxNameRecomended,
               oRegFul.oRegAbs.Title, "ind_Capitule02_12DesDimor");
            szSecction += fncBldHtmlSectionImgHelp("/a_img/hlp_descr/view_dimorphism.png", oRegFul.oRegDesc.LDesDimorphism);
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION DIFERECIAS  */
            szSecctionTit = Resources.Strings.ind_Capitule02_11DesDifer ;
            szSecction = oRegFul.oRegDesc.LDesDiferentiation;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //--------------------------------------------------------
            /* DESCRIPCION HOLOTIPO  */

            szSecctionTit = Resources.Strings.ind_Capitule02_12DesHoloty ;
            szHtmlszHtmlLeft += fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.ADesImg_Holotype01,
             oRegFul.oRegAllFile.ADesImg_Holotype02,
             oRegFul.oRegAllFile.ADesImg_Holotype03,
              oRegFul.oRegAll.ATaxNameRecomended + ". " + Resources.Strings.scnADesImg_Holotype,
             oRegFul.oRegAbs.Title, "ind_Capitule02_14DesHoloty");
            szSecction += oRegFul.oRegDesc.LDesHolotype;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //--------------------------------------------------------
            /* DESCRIPCION HOLOTIPO  */

           
            szSecctionTit = Resources.Strings.ind_Capitule02_13DesNotes ;
            szSecction += oRegFul.oRegDesc.LDesNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            //--------------------------------------------------------
            /* MENU CON OPCION SELECCIONADA */

            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Description, Resources.Strings.ind_Capitule02_00Des, szSectionFilePanel);
           
            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate+szHtmlTabs ;

            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);

            return szHtml;
        }
        
        public string fncHtmlNatural_History(bool bCacheRebuild)
        {
            m_oAccordion.Init("AcHisNat");
             string szHtmlTabs="";
            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "natural";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);

                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

        
            string szSecctionTit = "";
            string szSecction = "";

            //  ---------------------------------------------
            // - AbsNatural -----------------------------------
            szSecctionTit = Resources.Strings.ind_Capitule03_01Nattintro;
            szSecction = fncBldHtmlPretyPhoto3(
               "gallerylist",
               oRegFul.oRegAllFile.ANatImg_Live01,
               oRegFul.oRegAllFile.ANatImg_Live02,
               oRegFul.oRegAllFile.ANatImg_Live03,
               oRegFul.oRegAll.ATaxNameRecomended,
               oRegFul.oRegAbs.Title, "ind_Capitule03_01Nattintro");

           string szANaturalMediaKey= fncCultureGetString(oRegFul.oRegAll.ANaturalMediaKey);
           string szANaturalFoodKey = fncCultureGetString(oRegFul.oRegAll.ANaturalFoodKey);
           string szANaturalBreedingKey = fncCultureGetString(oRegFul.oRegAll.ANaturalBreedingKey);

           szSecction += fncBldHtmlTaxTitleValue(Resources.Strings.ANaturalMediaKey, szANaturalMediaKey);
           szSecction += fncBldHtmlTaxTitleValue(Resources.Strings.ANaturalFoodKey, szANaturalFoodKey);
           szSecction += fncBldHtmlTaxTitleValue(Resources.Strings.ANaturalBreedingKey, szANaturalBreedingKey);
            szSecction += oRegFul.oRegAbs.LAbsHisNat;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //  ---------------------------------------------
            // - Abs MEDIO -----------------------------------
            szSecctionTit =Resources.Strings.ind_Capitule03_02NaMedBio;

            szSecction = oRegFul.oRegNatu.LNaturalMediaType;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            
            //  ---------------------------------------------
            // - Abs HISTORIA NATURAL -----------------------------------
             szSecctionTit= Resources.Strings.ind_Capitule03_03NatLiv ;
             szSecction = oRegFul.oRegNatu.LNaturalLifestyles;
             m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

             //  ---------------------------------------------
             // - Abs HISTORIA NATURAL -----------------------------------
             szSecctionTit =  Resources.Strings.ind_Capitule03_04NatFoo ;
             szSecction = fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ANatImg_Food01,
              oRegFul.oRegAllFile.ANatImg_Food02,
              oRegFul.oRegAllFile.ANatImg_Live03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule03_04NatFoo");
             szSecction += oRegFul.oRegNatu.LNaturalFood;
             m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

             //  ---------------------------------------------
             // - Abs HISTORIA REPRODUCION -----------------------------------
             szSecctionTit = Resources.Strings.ind_Capitule03_05NatBree;
             szSecction = fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ANatImg_Breeding01,
              oRegFul.oRegAllFile.ANatImg_Breeding02,
              oRegFul.oRegAllFile.ANatImg_Breeding03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule03_05NatBree");
             szSecction += oRegFul.oRegNatu.LNaturalBreeding;
             m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

             ////  ---------------------------------------------
             //// - Abs range detail --------------------------------

             szSecctionTit = Resources.Strings.ind_Capitule03_06NatDngNot;
             szSecction = oRegFul.oRegNatu.LNaturalDngNotes;
             m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

             ////  ---------------------------------------------
             //// - Abs range detail --------------------------------

             szSecctionTit = Resources.Strings.ind_Capitule03_07NatDngProAcc;
             szSecction = oRegFul.oRegNatu.LNaturalDngProActions;
             m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

           /*
          
            //--------------------------
            szHtmlszHtmlLeft += m_DivRow_Start;
            szHtmlszHtmlLeft += "<h2>" + Resources.Strings.ind_Capitule03_07Natnot +  m_gotop + "</h2>";

            ;
            szHtmlszHtmlLeft += oRegFul.oRegNatu.LNaturalNotes;
            szHtmlszHtmlLeft += m_DivRow_End;
            */

            szHtmlTabs =fncBldHtmlTabs(eTortoisesCapitules.Natural_History, Resources.Strings.ind_Capitule03_00Nat, szSectionFilePanel);
            szHtml =  szHtmlTabs+ m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;
        }
        public string fncHtmlRngHabitatRange(bool bCacheRebuild)
        {
            m_oAccordion.Init("AcRange");
             string szHtmlTabs="";

            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "range";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            string szHtmlszHtmlLeft = ""; ;
            szHtmlszHtmlLeft += m_DivRow_Start;

            string szSecctionTit = "";
            string szSecction = "";

            //  ---------------------------------------------
            // - Abs range -----------------------------------
            szSecctionTit = Resources.Strings.ind_Capitule04_01RngDisGeo;
            szSecction = oRegFul.oRegAbs.LAbsRngHab;
            szSecction += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_GeoRangeMapStandardWorldFul, "World Map of " + m_especiename, "bot");
            szSecction += cls.ClsUtils.fncGetContinentNamesFromCodes(oRegFul.oRegHabiAll.AHabGeoContinentKey, oRegFul.DocLngId) + " (" + cls.ClsUtils.fncCountryFromCodes(oRegFul.oRegHabiAll.AHabGeoCountriesKeys, "en") + ")</br>";
             szSecction += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_GeoRangeMapStandardDetailFul, "Countyr  Map of " + m_especiename, "bot");
             szSecction += oRegFul.oRegHabi.LHabGeoCountryNotes; 
            m_oAccordion.addSecction(szSecctionTit, szSecction,true, true);

            //  ---------------------------------------------
            // - Abs range world-----------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule04_01RngDisGeo;
            


            //  ---------------------------------------------
            // - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule04_02RngEcoCliBioRegKey;
            szSecction = "";
          
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            //  ---------------------------------------------
            // - Abs range detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule04_03RngDisEco;
            szSecction = "";

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

       
            ////  ---------------------------------------------

            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Distribution, Resources.Strings.ind_Capitule04_00Rng, szSectionFilePanel);
            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
      


            //szSecctionTit = Resources.Strings.ind_Capitule04_05RngDisNotes;
            //szSecction = oRegFul.oRegHabi.LNaturalDngNotes;
            //m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            //szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Distribution, Resources.Strings.ind_Capitule04_00Rng, szSectionFilePanel);
            //szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate;
            //oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;


           

        }



        public string fncHtmlRngHabitatEcologyClimate(bool bCacheRebuild)
        {

             string szHtmlTabs="";
            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "climate";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);


            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------
            m_oAccordion.Init("AcClimate");
            string szSecctionTit = "";
            string szSecction = "";

            //string szHtmlszHtmlLeft = "";
            //szHtmlszHtmlLeft += m_DivRow_Start;

            //szHtmlszHtmlLeft += fncBldSubTitWithNames(Resources.Strings.ind_Capitule05_00RngEco, true, true);
            //string szUrl = "";
          
            //szHtmlszHtmlLeft += m_DivRow_End;
            ////--------------------------

            string sz = "";
            string szUrl = "";
            //cls.bbdd.ClsReg_tdoclng_ecozones oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_ecozones();
            oRegEco.fncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegHabiAll.AHabClimateEcozoneKey);


            //  ---------------------------------------------
            // - Abs climate detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_01RngEcoAbs;
            szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegHabiAll.AHabClimateEcozoneKey;

            szSecction = m_DivImgRight200_start + fncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone") + "</div>";
            szSecction += oRegFul.oRegAbs.LAbsClimateEcozone;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



            //  ---------------------------------------------
            // - Abs biotopo detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_02RngEcoBiotope;
           // szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegHabiAll.AHabClimateEcozoneKey;

           // szSecction = m_DivImgRight200_start + fncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone") + "</div>";
            szSecction =  fncBldHtmlPretyPhoto3(
             "gallerylist",
             oRegFul.oRegAllFile.AHabImg_landscapes01,
             oRegFul.oRegAllFile.AHabImg_landscapes02,
             oRegFul.oRegAllFile.AHabImg_landscapes03,
             oRegFul.oRegAll.ATaxNameRecomended,
             oRegFul.oRegAbs.Title, "ind_Capitule05_02RngEcoBiotope");
            string szImg = "<img src=\"" + oRegFul.oRegAllFile.AHabImg_GeoRangeMapStandardKoppenFul + "\" name=\"" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie +" Climate koppen" + "\">";
            szSecction += szImg;
            szSecction += oRegFul.oRegHabi.LHabGeoEcoBiogeographicRegion;
            sz = oRegFul.oRegHabiAll.AHabClimateEcozoneKey + ". " + oRegFul.oRegHabi.LHabEcozone;
            szSecction += sz; // fncBldHtmSecction(Resources.Strings.AHabEcozoneClimateKey, sz);

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



            //  ---------------------------------------------
            // - Abs climatetype detail --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_03RngEcoCliType;
            szSecction = oRegFul.oRegAllFile.AHabImg_GeoRangeMapStandardKoppenFul;
           
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //  ---------------------------------------------
            // - Abs climatetype temperatura --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_04RngEcoCliTemp;
            szSecction=fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherTemp, "Temp. " + oRegFul.oRegAbs.Title, "");
            
            sz = "";
            sz += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherTemp, "Temp. " + oRegFul.oRegAbs.Title, "");
            sz += "<br><table width=\"90%\">";
            sz += "\n <thead><tr><td colspan=\"7\">Temperaturas medias mensuales</td></tr></thead>";
            sz += "\n <thead><tr><td>MM</td><td>01</td><td>02</td><td>03</td><td>04</td><td>05</td><td>06</td></tr></thead>";
            sz += "<tr><td>ºC Max</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax01.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax02.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax03.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax04.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax05.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax06.ToString() + "</td></tr>";
            sz += "<tr><td>ºC Med</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed01.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed02.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed03.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed04.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed05.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed06.ToString() + "</td></tr>";
            sz += "<tr><td>ºC Min</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin01.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin02.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin03.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin04.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin05.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin06.ToString() + "</td></tr>";
            sz += "</tbody><thead><tr><td>MM</td><td>07</td><td>08</td><td>09</td><td>10</td><td>11</td><td>12</td></tr></thead>";
            sz += "<tbody><tr><td>ºC Max</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax07.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax08.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax09.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax10.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax11.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMax12.ToString() + "</td></tr>";
            sz += "<tr><td>ºC Med</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed07.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed08.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed09.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed10.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed11.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMed12.ToString() + "</td></tr>";
            sz += "<tr><td>ºC Min</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin07.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin08.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin09.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin10.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin11.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabTmpMin12.ToString() + "</td></tr>";
            sz += "</tbody></table>";
            szSecction = sz;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);



            //  ---------------------------------------------
            // - Abs climatetype temperatura --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_05RngEcoCliRain;
            szSecction = fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherTemp, "Temp. " + oRegFul.oRegAbs.Title, "");

            sz = "";
            sz += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherRain, "Rain " + oRegFul.oRegAbs.Title, "");
            sz += "<br><table width=\"90%\">";
            sz += "\n <thead><tr><td colspan=\"7\">Temperaturas medias mensuales</td></tr></thead>";
            sz += "<thead<tr><td>MM</td><td>01</td><td>02</td><td>03</td><td>04</td><td>05</td><td>06</td></tr></thead";
            sz += "<tbody><tr><td>ML</td><td>" + oRegFul.oRegHabiAll.AHabRainML01.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML02.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML03.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML04.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML05.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML06.ToString() + "</td></tr>";
            sz += "<tr><td>Days</td><td>" + oRegFul.oRegHabiAll.AHabRainDays01.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays02.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays03.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays04.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays05.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays06.ToString() + "</td></tr></tbody>";
            sz += "<thead><tr><td>MM</td><td>07</td><td>08</td><td>09</td><td>10</td><td>11</td><td>12</td></tr></thead>";
            sz += "<tbody><tr><td>ML</td><td>" + oRegFul.oRegHabiAll.AHabRainML07.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML08.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML09.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML10.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML11.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainML12.ToString() + "</td></tr>";
            sz += "<tr><td>Days</td><td>" + oRegFul.oRegHabiAll.AHabRainDays07.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays08.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays09.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays10.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays11.ToString() + "</td><td>" + oRegFul.oRegHabiAll.AHabRainDays12.ToString() + "</td></tr></tbody>";
            sz += "</table>";
            szSecction = sz;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //  ---------------------------------------------
            // - Abs climatetype insolacion  --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_06RngEcoCliSun;
            szSecction = fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherTemp, "Temp. " + oRegFul.oRegAbs.Title, "");

            sz = "";
            sz = Resources.Strings.AHabLatitudMax + "= " + oRegFul.oRegHabiAll.AHabLatitudMax.ToString() + "º " + Resources.Strings.AHabLatitudMin + "=" + oRegFul.oRegHabiAll.AHabLatitudMin.ToString() + "º<br/>";
            sz += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherSun, "Sun hours " + oRegFul.oRegAbs.Title, "");
            szSecction = sz;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //  ---------------------------------------------
            // - Abs climatetype biome  --------------------------------

            szSecctionTit = Resources.Strings.ind_Capitule05_07RngEcoCliBioRegKey;
            szSecction = fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherTemp, "Temp. " + oRegFul.oRegAbs.Title, "");

            sz = "";
            sz += fncBldHtmlImgCenter(oRegFul.oRegAllFile.AHabImg_ClimateWheatherBiome, "Biome. " + oRegFul.oRegAbs.Title, "");
            szSecction = sz;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Ecology, Resources.Strings.ind_Capitule06_04CarBreeding, szSectionFilePanel);
            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            
            return szHtml;

        }
        private string fncBldSubTitWithNames(string szTitSection, bool bShowHtmlBoxResumen)
        {
            return fncBldSubTitWithNames(szTitSection, bShowHtmlBoxResumen, false);
        }
        private string fncBldSubTitWithNames(string szTitSection, bool bShowHtmlBoxResumen, bool TagTop)
        {
            string szName = oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";
            string sz = "\n<h2 class=\"h2.titlesubdot\">" + szTitSection + ": \"" + szName + "\"" + "</h2>";
            if (TagTop) sz = "<a name=\"ind_gotop\" class=\"anchor\">" + sz + "</a>";
            //if (bShowHtmlBoxResumen) sz = sz+m_HtmlBoxResumen ;
            return sz;
        }
        public string fncHtmlCare(bool bCacheRebuild)
        {
            string szHtmlTabs="";
            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "care";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);


            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            
            string szUrl = "";
           
           m_oAccordion.Init("accare");
           string szSecctionTit="";
           string szSecction="";

           //........................................................................................
            // care abstract
            //..................
            //   szUrlMed = szUrlIni + eTortoisesCapitules.Care.ToString().ToLower() + "\"" + "title=\"" + Resources.Strings.Go + " " + Resources.Strings.ind_Capitule01_02AbsNat + "\">";
            szSecctionTit = Resources.Strings.ind_Capitule06_01CarIntro;
            szSecction = fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ACareImg_gral01,
              oRegFul.oRegAllFile.ACareImg_gral02,
              oRegFul.oRegAllFile.ACareImg_gral03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule06_01CarIntro");
            szSecction += oRegFul.oRegAbs.LAbsCare;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);
            //........................................................................................
            //.................. care values
            szSecctionTit = Resources.Strings.ind_Capitule06_02CarValues;
            oRegEco.fncSqlFindByEcozoneListCode(oRegFul.DocLngId, oRegFul.oRegHabiAll.AHabClimateEcozoneKey);
            szUrl = "/" + oRegFul.DocLngId + "/dlg_ecozone_help/" + oRegFul.oRegHabiAll.AHabClimateEcozoneKey;
            szSecction = fncBldHtmlPretyPhotoIframeAloneInline(szUrl, oRegEco.ImgRainTemp, "Help", "Ecozone");
            szSecction += oRegFul.oRegCare.LCareValues;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);
            
            //........................................................................................
            //.................. care food
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_03CarFoods;
            szSecction = fncBldHtmlPretyPhoto3(
            "gallerylist",
            oRegFul.oRegAllFile.ACareImg_Food01,
            oRegFul.oRegAllFile.ACareImg_Food02,
            oRegFul.oRegAllFile.ACareImg_Food03,
            oRegFul.oRegAll.ATaxNameRecomended,
            oRegFul.oRegAbs.Title, "ind_Capitule06_03CarFoods");
            szSecction += oRegFul.oRegCare.LCareFood;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care breeding
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_04CarBreeding;
            szSecction =  fncBldHtmlPretyPhoto3(
            "gallerylist",
            oRegFul.oRegAllFile.ACareImg_Breeding01,
            oRegFul.oRegAllFile.ACareImg_Breeding02,
            oRegFul.oRegAllFile.ACareImg_Breeding03,
            oRegFul.oRegAll.ATaxNameRecomended,
            oRegFul.oRegAbs.Title, "ind_Capitule06_04CarBreeding");
            szSecction += oRegFul.oRegCare.LCareBreeding;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //........................................................................................
            //.................. care vivarium indoor
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_05CarVivariumIndoor;
            szSecction = fncBldHtmlPretyPhoto3(
              "gallerylist",
              oRegFul.oRegAllFile.ACareImg_VivariumIndoor01,
              oRegFul.oRegAllFile.ACareImg_VivariumIndoor02,
              oRegFul.oRegAllFile.ACareImg_VivariumIndoor03,
              oRegFul.oRegAll.ATaxNameRecomended,
              oRegFul.oRegAbs.Title, "ind_Capitule06_05CarVivariumIndoor"); ;
            szSecction += oRegFul.oRegCare.LCareVivariumIndoor;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care vivarium outdoor
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_06CarVivariuminOut;
            szSecction = fncBldHtmlPretyPhoto3(
        "gallerylist",
           oRegFul.oRegAllFile.ACareImg_VivariumOutdoor01,
           oRegFul.oRegAllFile.ACareImg_VivariumOutdoor02,
           oRegFul.oRegAllFile.ACareImg_VivariumOutdoor03,
           oRegFul.oRegAll.ATaxNameRecomended,
           oRegFul.oRegAbs.Title, "ind_Capitule06_06CarVivariuminOut");
            szSecction += oRegFul.oRegCare.LCareVivariumOutdoor;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care care notes
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_07CarNotes;
            szSecction = oRegFul.oRegCare.LCareNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care vivarium specialist
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule06_08CarSpecialists;
            szSecction = oRegFul.oRegCare.LCareEspecialist;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //-------------------------------------------------------------------------
            // write and return
            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Care, Resources.Strings.ind_Capitule06_00Car, szSectionFilePanel);
            szHtml =szHtmlTabs + m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);

            return szHtml;
        }
        public string fncHtmlTaxonony(bool bCacheRebuild)
        {
             string szHtmlTabs="";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);

            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "taxonomy";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------


            m_oAccordion.Init("actaxo");
            string szSecctionTit = "";
            string szSecction = "";


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            //szSecctionTit = Resources.Strings.ind_Capitule07_00Tax;
            //szSecction += fncBldSubTitWithNames(Resources.Strings.ind_Capitule07_00Tax, true, true);
            //m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. care tax group
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_01TaxGroup;

            string szLinkPre = "<a href=\"/" + m_IdLng + "/taxons/taxon_group/";
            string szKeyTit = oRegFul.oRegAll.ATaxGrpL2210Order;
           // string szpATaxIdNameWithVu = "";
            string szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2210Order, szToolTip); // oRegFul.oRegAll.ATaxGrpL2210Order

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2220SubOrder;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit, ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2220SubOrder, szToolTip); // oRegFul.oRegAll.ATaxGrpL2220SubOrder

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2230SupFamily;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2230SupFamily, szToolTip); // oRegFul.oRegAll.ATaxGrpL2230SupFamily

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2240Family;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2240Family, szToolTip); // oRegFul.oRegAll.ATaxGrpL2240Family

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2250SubFamily;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2250SubFamily, szToolTip); // oRegFul.oRegAll.ATaxGrpL2250SubFamily

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2260SupGenus;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2260SupGenus, szToolTip); // oRegFul.oRegAll.ATaxGrpL2220SubOrder

            szKeyTit = oRegFul.oRegAll.ATaxGrpL2270Genus;
            szToolTip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKeyTit,  ref szLinkPre, ref oCnn);
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxGrpL2270Genus, szToolTip); // oRegFul.oRegAll.ATaxGrpL2220SubOrder
            szHtml += fncBldHtmlTaxTitleValue(Resources.Strings.ATaxFulName_, "<i>" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + "</i>, " + oRegFul.oRegAll.ATaxGrpL2282Authority + " " + oRegFul.oRegAll.ATaxGrpL2283Year);



            szSecction = szHtml;
            //szSecction += szHtml;

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_02TaxSubes;
            szSecction = oRegFul.oRegAll.ATaxGrpL2281SpecieSub;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_03TaxEtim;
            szSecction = oRegFul.oRegAbs.LTaxEtimology;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_04TaxSinon;
            szSecction = oRegFul.oRegAll.ATaxSinonims;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_05TaxVulg;

            szSecction = fncBldHtmlTaxTitleValue(Resources.Strings.ATaxNameLngVulgarEN, oRegFul.oRegAll.ATaxNameLngVulgarEN);
            szSecction += fncBldHtmlTaxTitleValue(Resources.Strings.LTaxNameVulgar, oRegFul.oRegAbs.LTaxNameVulgar + "[" + oRegFul.DocLngId + "]");
            szSecction += oRegFul.oRegAll.ATaxNameVulgarList;
                    
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule07_06TaxNote;
            szSecction = oRegFul.oRegAbs.LTaxNotes;
            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Taxonomy, Resources.Strings.ind_Capitule07_00Tax, szSectionFilePanel);

            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            
            return szHtml;
        }
        private string fncHtmlIdentificationKeysFill(bool bCacheRebuild)
        {
            string szHtmlTabs = "";
            string szHtml = "";
            string szSectionFile = "identkey";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                //szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);

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
            szSql += " from tdoclng_taxon_keys join tdoclng_taxon_keys_lng USING (DocId)";
            szSql += " where DocIdTaxaRelationValue="+oRegDoc.DocId.ToString () ;
            szSql += " Order by TOWNodeParentId,TOWNodeId";
            
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            oCnn.Open();
            MySqlDataAdapter oDA = new MySqlDataAdapter(szSql, oCnn);
            DataTable  oDS = new DataTable();
            oDA.Fill(oDS);
            //string szTaxa="";
            string szNodeFullPathList="";
            string szHtmlEnd ="";
            string szhtmNodes = "";
            string szNodeFullPathListMax = "";
            foreach (DataRow oRow in oDS.Rows)
            {
                szNodeFullPathList=oRow["NodeFullPathList"].ToString ();
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
            for (int i=0; i < sNodes.Length; i++)
            {
                szhtmNodes += fncBldHtmlIdentificationKeyNode(sNodes[i], m_IdLng,ref oCnn);
                
            }
            szHtml= szhtmNodes+szHtmlEnd;


            //........................................................................................
            //.................. Tax intro
            //...............................................................................................
            szSecctionTit = Resources.Strings.ind_Capitule08_01IdeKey;
            
            szSecction += szHtml;

            m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.KeysIdentification, Resources.Strings.ind_Capitule08_00IdeKey, szSectionFilePanel);

            szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate;

            return szHtml;                

        
        }
        public string fncBldHtmlIdentificationKeyNode(string TOWNodeId, string idDocLng, ref MySqlConnection oCnn)
        {

            string szHtm = "";
            string szSql = "select docid from tdoclng_taxon_keys where TOWNodeId='" + TOWNodeId + "'";
            try
            {
                TOWNodeId = TOWNodeId.Trim();
                string sz = "";
                MySqlCommand oCmd = new MySqlCommand(szSql, oCnn);


                sz = oCmd.ExecuteScalar().ToString();
                UInt64 DocId = Convert.ToUInt64(sz);
                oRegKeyNode.fncSqlFind(DocId, idDocLng);

                szHtm = oRegKeyNode.fncGetCache_Html(cls.ClsGlobal.CacheRebuid);
            }
            catch (Exception xcpt)
            {
                szHtm = "<br/><b>TOWNodeId= " + TOWNodeId+ " not found</b><br/>" ;
                szHtm +=xcpt.Message;
            }

            return szHtm;
        }
        public string fncHtmlIdentificationKeys(bool bCacheRebuild)
        {
             string szHtmlTabs="";
            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "IdentificationKeys";
            string szSectionFilePanel = szSectionFile + "_panel";

            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------
            string szHtmlszHtmlLeft = "";

            szHtmlszHtmlLeft = ""; ;
            szHtmlszHtmlLeft += m_DivRow_Start;
            cls.bbdd.ClsReg_tdoclng_taxon_keys_lng oReg = new ClsReg_tdoclng_taxon_keys_lng();


            szHtmlszHtmlLeft += "<h2>" + Resources.Strings.ind_Capitule08_00IdeKey + m_gotop + "</h2>";
            szHtmlszHtmlLeft += Resources.Strings.Experimental_developing_page;
            szHtmlszHtmlLeft += fncHtmlIdentificationKeysFill(true);
            // rellenar las claves de identificacion


            szHtmlszHtmlLeft += m_DivRow_End;





            szHtmlszHtmlLeft += fncImgLinks(oRegFul.oRegAll.ATaxGrpL2270Genus, oRegFul.oRegAll.ATaxGrpL2280Specie);
            szHtmlszHtmlLeft += "<br/>" + m_LastUpdate;
            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Bibliography, Resources.Strings.ind_Capitule11_00Bib, szSectionFilePanel);
            szHtml = szHtmlTabs +szHtmlszHtmlLeft+m_LastUpdate+m_LastUpdate+  szHtmlTabs ;

            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;
        }
        public string fncCache_HtmlTaxonULTree(bool bRebuild, string pDocLngId)
        {
            String szHtml = "";
          
            String szFileCache = cls.cache.ClsCache.fncCacheFilePath(0, cls.ClsGlobal.LngIdThread, "TaxonTree");

            if (bRebuild) { ClsUtils.fncPathFileDelete(szFileCache); }
            if (System.IO.File.Exists(szFileCache))
            {
                return cls.cache.ClsCache.fncCacheFileRead(szFileCache);
            }
            else
            {
                 szHtml = fncCache_HtmlTaxonULTree_BLD(pDocLngId);

                cls.cache.ClsCache.fncCacheFileSave(ref szFileCache, ref szHtml);
               
            }
            return szHtml;
        }
        private string fncCache_HtmlTaxonULTree_BLD(String pDocLngId)
        {

            string szHtml = "";
            // gestion del cache
         
      


            // si se indica rehacer cache
            // rehacerlo desde base de datos

            string szSql = "";
            szSql += " select";
            szSql += " ATaxGrpL2220SubOrder as L1_SO,";
            szSql += " ATaxGrpL2230SupFamily as L2_SF,ATaxGrpL2240Family as L3_FA,";
            szSql += " ATaxGrpL2270Genus as L4_GE, CONCAT_WS(' ',ATaxGrpL2270Genus, ATaxGrpL2280Specie)as specie,DocId";
            szSql += " from tdoclng_taxon_all order by";
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
            string szLinkPre = "<a href=\"/" + pDocLngId + "/taxons/taxon_group/";

            //string szOpen = "";
            //string szClose = "";
            string szTooltip = "";
            string szKey = "Testudines";

            string szLink = szLinkPre + szKey + "\">" + szKey + "</a>";
            string szReadMore = "";
            string szKeyTit = "Order:" + szKey + "<br/>";
            szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLinkPre, ref oCnn);
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

                    szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref   szLinkPre, ref oCnn);
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
                    // szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLink, ref oCnn);


                    szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref   szLinkPre, ref oCnn);


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
                    //szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref szLink, ref oCnn );
                    szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref   szLinkPre, ref oCnn);

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
                    // routes.Add("taxon_taxongroup", new Route("{doclngid}/taxons/taxon_group/{docid}", new clsRouteHandler("~/taxons/taxon_group.aspx")));


                    szTooltip = fncHtmlTaxonULTreeToolTips(ref szKeyTit, ref szKey, ref  szLinkPre, ref oCnn);




                    szHtml += szCloseL4open + "<b>Genus " + szTooltip + szReadMore + "</b>";

                    szL4_GEAnt = szL4_GE;
                    bL4 = true;
                }
                if (bL4)
                {
                    szHtml += szCloseL5open;
                }

                szHtml += "\n\t\t\t\t\t<li><b>" + Resources.Strings.specie + "</b> " + fncLinkSspecie(szspecie, szDocId, pDocLngId) + "</li>";

            }
            szHtml += szCloseL1;
            szHtml += "\n</li></ul>";

            oCnn.Close();
            oCnn.Dispose();
            // guardar en Cache el formato html
            //----------------------------------
          

            return szHtml;
        }
        private string fncHtmlTaxonULTreeToolTips(ref string pKeyTit, ref string pATaxIdName, ref string szLinkPre, ref    MySqlConnection oCnn)
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
            
            string szCmd = "select ATaxIdName,ATaxGrpL2282Authority,ATaxGrpL2283Year,  CONCAT(ATaxIdName ,'. ', NameVulgar) as titlevu,Abstract, DescriptionShort from tdoclng_taxon_groups where ATaxIdName='" + pATaxIdName.Trim() + "'";
            MySqlCommand oCmd = new MySqlCommand(szCmd, oCnn);
            DataTable oDT = new DataTable();
            MySqlDataAdapter oDA = new MySqlDataAdapter(oCmd);

            try
            {
                if (oCnn.State != System.Data.ConnectionState.Open) oCnn.Open();
                oDA.Fill(oDT);
                oDA.Dispose();

                string szIdName = "";
                string szAbstract = "";
                string szDescription = "";
                if (oDT.Rows.Count > 0)
                {
                    szIdName = oDT.Rows[0]["ATaxIdName"].ToString().Trim();
                    szAbstract = pKeyTit + oDT.Rows[0]["Abstract"].ToString().Trim();
                    szDescription = oDT.Rows[0]["DescriptionShort"].ToString().Trim();
                    szTooltip = cls.ClsHtml.fncHtmlToolTip(szLink, szAbstract);
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
        public string fncLinkSspecie(string pSpecie, string pDocId, string pDocLngId)
        {


            UInt64 iDocId = Convert.ToUInt64(pDocId);
            oRegTxAll.fncSqlFind(iDocId);

            if (pDocLngId == "") pDocLngId = ClsGlobal.default_DocLngId;
            oRegTxLngAbs.fncSqlFind(iDocId, pDocLngId);


            string szSpecie = "<b><i>" + oRegTxAll.ATaxGrpL2270Genus + " " + oRegTxAll.ATaxGrpL2280Specie + "</i></b>, " + oRegTxAll.ATaxGrpL2282Authority + " " + oRegTxAll.ATaxGrpL2283Year;
            string sz = "";
            sz = "<a href=\"/es/taxons/taxon/" + pDocId + "\">" + szSpecie + "</a>";
            if (oRegTxAll.ATaxNameLngVulgarEN != "") sz += "<br/>&nbsp;&nbsp;&nbsp;[EN] " + oRegTxAll.ATaxNameLngVulgarEN;
            if (pDocLngId.ToUpper() != "EN")
            {
                if (oRegTxLngAbs.fncSqlFind(iDocId, pDocLngId))
                {
                    if (oRegTxLngAbs.LTaxNameVulgar != "") sz += "<br/>&nbsp;&nbsp;&nbsp;[" + pDocLngId.ToUpper() + "] " + oRegTxLngAbs.LTaxNameVulgar;
                }

            }

            // sz +="<span class=\"inline\">"+cls.ClsHtml.fncHtmFlagLanguages(Convert.ToInt32(pDocId), "/taxons/taxons/",false )+"</span>";
            sz += "<br/>&nbsp;&nbsp" + cls.ClsHtml.fncHtmFlagLanguages(Convert.ToUInt64(pDocId), "/taxons/taxons/", false);

            Thread.Sleep(200);
            return sz;
        }
        public string fncHtmlbibliography(bool bCacheRebuild)
        {
             string szHtmlTabs="";
            string szHtml = "";
            string szSecctionTit = "";
            string szSecction = "";

            
            // -------------------------------------------------
            string szSectionFile = "bibliography";
            string szSectionFilePanel = szSectionFile + "_panel";

            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;

           m_oAccordion.Init ("acobibl");
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

           szSecctionTit = Resources.Strings.ind_Capitule11_01BibAck;
           szSecction = oRegDoc.DocAcknowledgements; ;
           m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

           szSecctionTit = Resources.Strings.ind_Capitule11_02BibBib;
           szSecction = oRegDoc.DocBibliography; ;
           m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);

           szSecctionTit = Resources.Strings.ind_Capitule11_03BibLinks;
           szSecction = fncImgLinks(oRegFul.oRegAll.ATaxGrpL2270Genus, oRegFul.oRegAll.ATaxGrpL2280Specie); ;
           m_oAccordion.addSecction(szSecctionTit, szSecction, false, true);


           szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Bibliography, Resources.Strings.ind_Capitule11_00Bib, szSectionFilePanel);
           szHtml = szHtmlTabs + m_oAccordion.html + m_LastUpdate + szHtmlTabs;

            

            
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;
        }
        public string fncHtmlGallery(bool bCacheRebuild, Int32 iPage)
        { string szHtmlTabs="";
            //8-oct-2012
            // la galeria es un caso muy espcial de cache, pues le he incorporado paginacion 
            string szSectionFile = "gallery_" + iPage.ToString();
            string szSectionFilePanel = "gallery_panel";
            string szHtml = "";
            // -------------------------------------------------

            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            // ---- para ello he creado una clase auxiliar con
            // ---- el fin de no enrredar mas esta, 
            // ---- Dado que esta paginacion contiene un pager
            // ---- en funcion del numero de imagenes de la galeria.
            //-------------------------------------------------

            cls.bbdd.ClsReg_tdoclng_taxon_ful_html_gallery oGal = new cls.bbdd.ClsReg_tdoclng_taxon_ful_html_gallery();
            string szTitleBot = "";
            if (oRegDocLng.DocLngId == "en")
            {
                szTitleBot = oRegFul.oRegAbs.LTaxNameVulgar;
            }
            else
            {
                szTitleBot = oRegFul.oRegAbs.LTaxNameVulgar + " [" + oRegDocLng.DocLngId + "] ,<br/> " + oRegFul.oRegAll.ATaxNameLngVulgarEN + "[en] ";
            }
            string szTitleTop = oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ", " + oRegFul.oRegAll.ATaxGrpL2282Authority + " " + oRegFul.oRegAll.ATaxGrpL2283Year.ToString();
            if (bCacheRebuild)
            {
                oGal.fncSetCacheGallery(bCacheRebuild, m_IdDoc, m_IdLng, 9, szTitleBot, szTitleTop);
                oGal.fncBldHtmlCache();
            }

            string szHtmlszHtmlLeft = "";
            string szHtmlszHtmlRight = "";
            szHtmlszHtmlLeft += fncBldSubTitWithNames(Resources.Strings.ind_Capitule10_00Gal, false);

            szHtmlszHtmlLeft += oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
            szHtmlszHtmlLeft += fncBldHtmSecction(Resources.Strings.Acknowledgements, oRegDoc.DocAcknowledgements + ".");
            szHtmlszHtmlLeft += fncImgLinks(oRegFul.oRegAll.ATaxGrpL2270Genus, oRegFul.oRegAll.ATaxGrpL2280Specie);

            szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.Gallery, Resources.Strings.ind_Capitule10_00Gal, szSectionFilePanel);
            szHtml = szHtmlszHtmlRight + szHtmlszHtmlLeft;
            szHtml += m_LastUpdate + szHtmlTabs;

            //  oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;
        }
        public string fncHtmlNotes(bool bCacheRebuild)
        { string szHtmlTabs="";

            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "notes";
            string szSectionFilePanel = szSectionFile + "_panel";
            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);


            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            string szHtmlszHtmlLeft = ""; ;
            string szHtmlszHtmlRight = "";
            string sz = szHtml = oRegDocLng.DocLngNotes.Trim();
            if (sz == "")
            {
                sz = Resources.Strings.NoDataSoFar;
            }
            szHtmlszHtmlLeft += fncBldHtmSecction(Resources.Strings.Notes, sz);
            string szTabs =fncBldHtmlTabs(eTortoisesCapitules.Notes, Resources.Strings.ind_Capitule12_00Notes, szSectionFile);
            szHtml +=szHtmlTabs + szHtmlszHtmlRight + szHtmlszHtmlLeft;
            szHtml += m_LastUpdate+szTabs;
            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
            return szHtml;

        }
        //public string fncHtmlToDo(bool bCacheRebuild)
        //{
        //     string szHtmlTabs="";
        //    string szHtml = "";
        //    // -------------------------------------------------
        //    string szSectionFile = "todo";
        //    string szSectionFilePanel = szSectionFile + "_panel";
        //    if (bCacheRebuild)
        //    {
        //        oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
        //        oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);
        //    }
        //    else
        //    {
        //        szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
        //        szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
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
        //    szHtmlszHtmlLeft += fncBldHtmSecction(Resources.Strings.Todo, sz);
        //    szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.ToDo, Resources.Strings.ind_Capitule12_00Notes, szSectionFilePanel);
        //    szHtml = szHtmlTabs+szHtmlszHtmlRight + szHtmlszHtmlLeft;
        //    szHtml += m_LastUpdate + szHtmlTabs;

        //    oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
        //    return szHtml;
        //}
        public string fncHtmlNearSpecies(bool bCacheRebuild)
        {
            string szHtmlTabs = "";
            string szHtml = "";
            // -------------------------------------------------
            string szSectionFile = "nearspecies";
            string szSectionFilePanel = szSectionFile + "_panel";

            if (bCacheRebuild)
            {
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFile);
                oRegCache.fncCacheFileDeleteSection(m_IdDoc, m_IdLng, szSectionFilePanel);

            }
            else
            {
                szHtml = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFile);
                szHtmlTabs = oRegCache.fncReadCache(m_IdDoc, m_IdLng, szSectionFilePanel);
            }
            if (szHtml != "") return szHtml;
            // -------------------------------------------------
            // ---- si no existe el cache o overwrite crearlo
            //-------------------------------------------------

            //string szHtmlLeft = "";


            string szSql = "select tdoclng_taxon_all.DocId as docid, ATaxNameRecomended, ATaxGrpL2270Genus ,LAbsDes, DocLngId, AFileURL, FileSeccId  from tdoclng_taxon_all left JOIN  tdoclng_taxon_lngabst on   tdoclng_taxon_all.DocId = tdoclng_taxon_lngabst.DocId left JOIN tdoclng_taxon_allfiles on   tdoclng_taxon_all.DocId = tdoclng_taxon_allfiles.DocId where FileSeccId='AAbsImg_Specie'  and tdoclng_taxon_all.ATaxGrpL2270Genus=";
            MySqlConnection oCnn = new MySqlConnection(ClsGlobal.Connection_MARIADB);
            MySqlCommand oCmd = new MySqlCommand(szSql + " '" + oRegFul.oRegAll.ATaxGrpL2270Genus + "'", oCnn);
            oCnn.Open();
            MySqlDataReader oRd = oCmd.ExecuteReader();

            string szName = "";
            string szDes = "";
            string szLng = "";

            string szUrl = "";
            string szSecctionTit="";
            string szSecction="";
            m_oAccordion.Init ("acNear");

            //string szInd = "";
            //szHtml = m_DivRow_Start;
            //szInd += fncBldSubTitWithNames(Resources.Strings.ind_Capitule09Near, true);
            //szInd += "\n<h2>" + Resources.Strings.ind_nearindex + "</h2>";

            //szInd += "\n<ul>";

            //szInd += "\n<li><a href=\"#ind_neargenus\">" + Resources.Strings.ind_neargenus + "</a></li>";
            //szInd += "\n<li><a href=\"#ind_nearfamily\">" + Resources.Strings.ind_nearfamily + "</a></li>";
            //szInd += "\n</ul>";
            //szHtml += szInd;




            //szHtml += m_HtmlBoxResumen;
            string szHtmlGenus = "";
            if (oRegGrp.fncSqlFind(oRegFul.oRegAll.ATaxGrpL2270Genus, oRegDocLng.DocLngId))
            {
                szHtmlGenus = "<div class=\"genus\">" + Resources.Strings.ATaxGrpL2270Genus + ": <i>" + oRegGrp.ATaxIdName + "</i> " + oRegGrp.ATaxGrpL2282Authority + " " + oRegGrp.ATaxGrpL2283Year + "</br>";
                szHtmlGenus += "</br>" + oRegGrp.DescriptionShort + "</br>";
                szHtmlGenus += oRegGrp.NameVulgar + "</br>";
                szHtmlGenus += oRegGrp.Abstract;
                szHtmlGenus += "</div>";
            }

            //szHtml += "<h2> " + Resources.Strings.ind_Capitule09_01NearGenus+" "+oRegFul.oRegAll.ATaxGrpL2270Genus    + m_gotop + "</h2>";
            szHtml += szHtmlGenus;
            string szImgSrc = "";
            while (oRd.HasRows && oRd.Read())
            {

                szHtml += "<div class=\"row \">";
                szName = oRd["ATaxNameRecomended"].ToString().Trim();
                szDes = oRd["LAbsDes"].ToString().Trim();
                szLng = oRd["DocLngId"].ToString().Trim();
                szUrl = "<a href=\"/" + szLng + "/taxons/taxon/" + oRd["docid"].ToString().Trim() + "\"/>";
                szImgSrc = oRd["AFileURL"].ToString().Trim().ToLower();
                szImgSrc = szImgSrc.Replace("_med.jpg", "_min.jpg").Replace("_ful.jpg", "_min.jpg").Replace("_big.jpg", "_min.jpg");
                szHtml += szUrl + "<h2>" + szName + "</h2>";
                szHtml += "<img class=\"imgright img_min \" src=\"" + szImgSrc + "\"/></a>";
                szHtml += "<br/>" + szDes;
                szHtml += "<span class=\"readmore\"/>" + szUrl + Resources.Strings.readmore + "</a>";
                szHtml += "</div>";
            }
            oRd.Dispose();
            oCnn.Close();
            oCmd.Dispose();

            szSecctionTit = Resources.Strings.ind_Capitule09_01NearGenus+" "+oRegFul.oRegAll.ATaxGrpL2270Genus  ; 
            szSecction = szHtml; ;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);
            // ------------------------------------------------- 

            szHtml = m_DivRow_Start;

            szHtml += fncBldHtmlFamilyList();
            szHtml += m_DivRow_End;
            szSecctionTit = Resources.Strings.ind_Capitule09_02NearFamily + " " + oRegFul.oRegAll.ATaxGrpL2240Family;
            szSecction = szHtml; ;
            m_oAccordion.addSecction(szSecctionTit, szSecction, true, true);

           

            
           szHtmlTabs = fncBldHtmlTabs(eTortoisesCapitules.NearSpecies, Resources.Strings.ind_Capitule09_00Near, szSectionFilePanel);
           szHtml = szHtmlTabs+ m_oAccordion.html + m_LastUpdate+szHtmlTabs ;
           oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFile, szHtml, true);
          
           return szHtml;
        }
        public string fncImgLinks(string pBuscarGen, string pBuscarEsp)
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
            sz = fncImglink(szUri, "www_repddbb.gif", "title", "Alt");
            szHtmImgLinks += sz;

            //2 ITIS
            szUri = "http://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=Scientific_Name&search_value=#find#&search_kingdom=every&search_span=containing&categories=All&source=html&search_credRating=All";
            szUri = szUri.Replace("#find#", pBuscarGenSpEsp);
            sz = fncImglink(szUri, "www_ITIS.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 6 IUCN RED LIST
            sz = oRegFul.oRegAll.ALnkIUCN;
            if (sz != "#" & sz != "")
            {
                sz = fncImglink(sz, "www_iucnredlist.jpg", "IUCN Red List", "Alt");
                szHtmImgLinks += sz;
            }

            //2 ITIS
            szUri = "http://fossilworks.org/";
            //szUri = szUri.Replace("#find#", pBuscarGenSpEsp);
            sz = fncImglink(szUri, "www_fossilworks_org.gif", "fossilworks.org", "Gateway to the paleobiology database");
            szHtmImgLinks += sz;

            //3 catalogueoflife species 2000
            szUri = "http://www.gbif.org/species/search?q#g#+#s";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = fncImglink(szUri, "www_gbif.gif", "GBIF.org Free and open access to biodiversity data", "GBIF.org Free and open access to biodiversity data");
            szHtmImgLinks += sz;


            //3 catalogueoflife species 2000
            szUri = "http://www.catalogueoflife.org/annual-checklist/2009/search_results.php?search_string=#g#+#s#";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = fncImglink(szUri, "www_catalogeoflife.gif", "title", "Alt");
            szHtmImgLinks += sz;


            //4 CITES
            szUri = "http://sea.unep-wcmc.org/isdb/CITES/Taxonomy/tax-species-result.cfm?Genus=#g#&Species=#s#&source=animals&displaylanguage=eng&tabname=all";
            szUri = szUri.Replace("#g#", pBuscarGen);
            szUri = szUri.Replace("#s#", pBuscarEsp);
            sz = fncImglink(szUri, "www_cites.org.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            //5 CITES APENDICES
            szUri = "http://www.cites.org/esp/app/Appendices-S.pdf";
            sz = fncImglink(szUri, "www_citesapp.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 5 turtles of the world
            //http:/http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=Lissemys%20punctata

            //http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=testudo
            //       http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=testudo%20graeca
            szUri = "http://wbd.etibioinformatics.nl/bis/turtles.php?selected=beschrijving&menuentry=zoeken&zoeknaam=##buscar##";
            sz = pBuscarGenSpEsp.Replace(" ", "%20");
            szUri = szUri.Replace("##buscar##", sz);
            sz = fncImglink(szUri, "www_turtlesworld.png", "title", "Alt");
            szHtmImgLinks += sz;


            // 7 UNEP
            szUri = "http://www.unep-wcmc.org/isdb/Taxonomy/tax-species-result.cfm?source=animals&genus=#gns#&species=#spc#&tabname=all";
            szUri = szUri.Replace("#gns#", pBuscarGen);
            szUri = szUri.Replace("#spc#", pBuscarEsp);
            sz = fncImglink(szUri, "www_unepwcmc.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 8 ncbi
            szUri = "http://www.ncbi.nlm.nih.gov/Taxonomy/Browser/wwwtax.cgi?name=#gns#+#spc#";
            szUri = szUri.Replace("#gns#", pBuscarGen);
            szUri = szUri.Replace("#spc#", pBuscarEsp);
            sz = fncImglink(szUri, "www_ncbi.png", "title", "Alt");
            szHtmImgLinks += sz;

            //9 www_zipcodezoo.jpg
            szUri = "http://zipcodezoo.com/Animals/T/#find#/";
            szUri = szUri.Replace("#find#", (pBuscarGen + "_" + pBuscarEsp));
            sz = fncImglink(szUri, "www_zipcodezoo.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            //9 www_wheatherbase.jpg
            szUri = "http://www.weatherbase.com";
            sz = fncImglink(szUri, "www_wheatherbase.jpg", "Wheaterbase", "Wheater database");
            szHtmImgLinks += sz;


            //=================================
            // 10 OTRAS WEBS GENERALISTAS
            //=================================
            szHtmImgLinks += "<hr/ ><h2 class=\"clearfix\"> Find in other generalistas sites</h2>";
            szUri = "http://www.flickr.com/search/?q=#find#";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = fncImglink(szUri, "www_Flicker.jpg", "title", "Alt");
            szHtmImgLinks += sz;

            // 11 google images
            szUri = "http://www.google.com/images?safe=yes&q=%22#find#%22";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = fncImglink(szUri, "www_google.gif", "title", "Alt");
            szHtmImgLinks += sz;

            //12 picsearch.co
            szUri = "http://www.picsearch.com/search.cgi?q=%22#find#%22&cols=5&thumbs=20";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = fncImglink(szUri, "www_picssearch.png", "title", "Alt");
            szHtmImgLinks += sz;

            //13 photobucket
            szUri = "http://photobucket.com/images/#find#";
            szUri = szUri.Replace("#find#", (pBuscarGen + "+" + pBuscarEsp)); // genero
            sz = fncImglink(szUri, "www_photobucket.com.jpg", "title", "Alt");
            szHtmImgLinks += sz;
            //string sz = m_Buscar.Replace(" ", "%20");

            // FIN
            return "<br/>" + szHtmImgLinks + "<br class=\"clearfix\" />";
        }
        private string fncImglink(string szUrl, string szImgPath, string szTitle, string szAlt)
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
        private string fncBldHtmlSectionImgHelp(string szMinImgUrl, string szBigImgUrl, string szIdDivShowHide, string szIdDivShowHideAlt, string szText)
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
        private string fncBldHtmlSectionImgHelp(string szMinImgUrl, string szText)
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
        #region regTools
        //public string fncHtmFull()
        //{
        //    string szHtmlFull = "";
        //    m_VulgarName = Resources.Strings.VulgarNames+ ": " + oRegFul.oRegAbs.LTaxNameVulgar  + " [" + oRegFul.DocLngId + "], " + oRegFul.oRegAll.ATaxNameLngVulgarEN + "[en]<br/>";
        //    szHtmlFull = m_VulgarName + fncHtmlAbstract();
        //    return szHtmlFull;
        //}
        private string fncBldHtmlImgThumbRight(string szUrl, string szAlt)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath))
            {
                szUrl = "/a_img/noimage200px.png";
            }

            szHtml += "<img  src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\" style=\"max-width:200px; display:block; \"><br />";

            return szHtml;
        }
        private string fncBldHtmlImgThumb(string szUrl, string szAlt)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";
            string szPath = ((ClsGlobal.UrlMMedia + szUrl).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath))
            {
                szUrl = "/a_img/noimage200px.png";
            }

            szHtml += "<img  src=\"" + szUrl + "\" alt=\"" + szDes + "\" title=\"" + szDes + "\" style=\"max-width:200px; display:block; \"><br />";

            return szHtml;
        }
        private string fncBldHtmlImgThumb_side(string szUrl, string szAlt, string szNoImage)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";
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
        private string fncBldHtmlImgCenter(string szUrl, string szAlt, string szNoImage)
        {
            string szHtml = "";
            string szDes = szAlt + " " + oRegFul.oRegAbs.LTaxNameVulgar + " (" + oRegFul.oRegAll.ATaxGrpL2270Genus + " " + oRegFul.oRegAll.ATaxGrpL2280Specie + ")";
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
        private string fncBldHtmSecction(string szSectionFileTitle, string szSecctionText)
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
        private string fncBldHtmlTaxTitleValue(string pTitle, string pValue)
        {
            if (pValue == "") pValue = Resources.Strings.Opps_Nodata;
            string szHtml = "";
            szHtml += "<span class=\"fieldtitall\">" + pTitle + ": ";
            szHtml += pValue+"</span>";

            return szHtml;
        }

        private string fncBldHtmlTabs( eTortoisesCapitules TabSelect, String szTitle, string szSectionFilePanel)
        {

            

            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("es-ES");
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            //szTitle = "<h4>" +"titulo" +"</h4>";
            string szSumary = "</hr><h4>" + m_especiename + Resources.Strings.Summary + "</h4>" + oRegFul.oRegAbs.LAbsDes;
            string szHtmlTab = "";
            string szTit = "";
            string szUrl = "/" + oRegFul.DocLngId + "/taxons/taxon/" + oRegFul.DocId.ToString() + "/";
            string szClass = "";
            //<nav class="contents">
       
	
            szHtmlTab += "";

            string szMenu = "";
           // szMenu += "\n<h4>" + m_especiename + Resources.Strings.chapters + ":</h4></hr>\n<contents>\n<ul class=\"contents\">";
            szMenu += "\n<div class=\"index\">\n<h2 class=\"index\">" + Resources.Strings.chapters  + "</h2>\n<ul>";
            szTit = Resources.Strings.ind_Capitule01_00Abs;
            if (TabSelect.ToString() == eTortoisesCapitules.Abstract.ToString())
            { szClass = " class=\"selected\" "; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "abstract\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule02_00Des;
            if (TabSelect.ToString() == eTortoisesCapitules.Description.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "description\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule03_00Nat;
            if (TabSelect.ToString() == eTortoisesCapitules.Natural_History.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "natural_history\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule04_00Rng;
            if (TabSelect.ToString() == eTortoisesCapitules.Distribution.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "distribution\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule05_00RngEco;
            if (TabSelect.ToString() == eTortoisesCapitules.Ecology.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "ecology\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule06_00Car;
            if (TabSelect.ToString() == eTortoisesCapitules.Care.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "care\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";
            szMenu += "\n</ul>\n<ul>";
            szTit = Resources.Strings.ind_Capitule07_00Tax;
            if (TabSelect.ToString() == eTortoisesCapitules.Taxonomy.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "taxonony\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            //------
            // ind_Capitule08Key

            szTit = Resources.Strings.ind_Capitule08_00IdeKey;
            if (TabSelect.ToString() == eTortoisesCapitules.KeysIdentification.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "IdentificationKeys\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";


            //--------------
            szTit = Resources.Strings.ind_Capitule09_00Near;
            if (TabSelect.ToString() == eTortoisesCapitules.NearSpecies.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "nearspecies\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule10_00Gal;
            if (TabSelect.ToString() == eTortoisesCapitules.Gallery.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "gallery\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";


            szTit = Resources.Strings.ind_Capitule11_00Bib;
            // szUrl = "#";
            if (TabSelect.ToString() == eTortoisesCapitules.Bibliography.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "bibliography\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";

            szTit = Resources.Strings.ind_Capitule12_00Notes;
            // szUrl = "#";
            if (TabSelect.ToString() == eTortoisesCapitules.Notes.ToString())
            { szClass = " class=\"selected\""; }
            else { szClass = ""; }
            szMenu += "\n<li" + szClass + "><a href=\"" + szUrl + "notes\" title=\"" + Resources.Strings.Go + " " + szTit + " " + m_especiename + "\">" + szTit + "</a>\n</li>";
            //-------fin
            szMenu += "\n</ul>\n</div>\n\n";
            szHtmlTab += szMenu;
            //szHtmlTab += m_HtmlBoxResumen;

            oRegCache.fncWriteCache(m_IdDoc, m_IdLng, szSectionFilePanel, szHtmlTab, true);
            return szHtmlTab;

        }
        // dltabs2 crea uno del estilo de la cabecera
        private string fncBldHtmlPretyPhoto3(string szGalleryId, string pImgThun01, string pImgThun02, string pImgThun03, string pTitTop, string pTitBot, string  pSectionFile)
        {
            oPP.fncGallery_New(szGalleryId, "gallerylist");
            
            String pUrlThumbDefault = "";
            //--------------------------------------------------------
            string xpUrlThumb01 = pImgThun01;
            string xpUrlThumb02 = pImgThun02;
            string xpUrlThumb03 = pImgThun03;
            string xUrlTarget01 = "";
            string xUrlTarget02 = "";
            string xUrlTarget03 = "";
            fncBldUrlTest(ref  xUrlTarget01, ref  xpUrlThumb01, pUrlThumbDefault);
            oPP.fncGallery_AddPictureFB(xUrlTarget01, xpUrlThumb01, pTitTop, pTitBot, pSectionFile);

            fncBldUrlTest(ref  xUrlTarget02, ref  xpUrlThumb02, pUrlThumbDefault);
            oPP.fncGallery_AddPictureFB(xUrlTarget02, xpUrlThumb02, pTitTop, pTitBot, pSectionFile);

            fncBldUrlTest(ref  xUrlTarget03, ref  xpUrlThumb03, pUrlThumbDefault);
            oPP.fncGallery_AddPictureFB(xUrlTarget03, xpUrlThumb03, pTitTop, pTitBot, pSectionFile);

            return oPP.HtmGalleryFB;
        }
        private string fncBldPhotoList(String szGalleryId, String pGalleryTit, String pTitTop, String pTitBot, ref  StringCollection pImgListPath, string pSectionFile)
        {
            string szHtml = "";
            string szUrlTarget = "";
            string szpUrlThumbDefault = "";
            string szImg = "";
             oPP.fncGallery_New(szGalleryId, pGalleryTit);
            int n = 0;
            foreach (string imgpath in pImgListPath)
            {
                n++;
                szImg = imgpath.ToLower ().Trim ();
                szUrlTarget = "";
               
                fncBldUrlTest(ref szUrlTarget, ref  szImg, szpUrlThumbDefault);
                
                oPP.fncGallery_AddPictureFB(szUrlTarget, szImg, pTitTop, pTitBot, pSectionFile );
            }
            szHtml = oPP.HtmGalleryFB;

            return szHtml;
        }
        private void fncBldUrlTest(ref String pUrlTarget, ref String pUrlThumb, String pUrlThumbDefault)
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
      
        private string fncBldHtmlPretyPhotoAlone(string pImgThun, string pTitTop, string pTitBot, string pSecction)
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

            szHtml = oPP.fncHtmlAloneRowPhotoFB_med( pImgThun, pTitTop,  pSecction);
            return szHtml;
        }
        ///// <summary>
        ///// Agrega una imagen de tamaño medio y la enlaza a tamaño grande.
        ///// si no existe hace lo que puede
        ///// </summary>
        ///// <param name="pImgThb">Imagen a enlazar</param>
        ///// <param name="pTitle">Titulo y alt para la imagen</param>
        ///// <param name="pSectionDoc">Identificador de la secion donde esta</param>
        ///// <returns>Htm para agregar la imagen a la pagina </returns>
        //private string fncBldHtmlImgMedAlone(string pImgThb, string pTitle, string pSectionDoc)
        //{
            
        //    string szImgMed = "";
        //    string szImgBig = "";
        //    string szImgFul = "";
        //    string szHtml = "";
        //    string szImgNoExist = "/a_img/noimage1024px.png";
        //    //prevenir que no hay foto de los tamaños adecuados,
        //    //o que no se haya pasado el tamaño adecuado
        //    pImgThb = pImgThb.Trim().ToLower();
        //    szImgMed = pImgThb.Replace("ful.jpg", "med.jpg");
        //    szImgMed = pImgThb.Replace("big.jpg", "med.jpg");
        //    szImgMed = szImgMed.Replace("min.jpg", "med.jpg");
        //    szImgMed = szImgMed.Replace("minx.jpg", "med.jpg");
        //    szImgBig = szImgMed.Replace("med.jpg", "big.jpg");
        //    szImgFul = szImgMed.Replace("med.jpg", "ful.jpg");

        //    string szPathImg = ((ClsGlobal.UrlMMedia + pImgThb).Replace("\\", "/")).Replace("//", "/");
        //    string szPathMed = ((ClsGlobal.UrlMMedia + szImgMed).Replace("\\", "/")).Replace("//", "/");
        //    string szPathbig = ((ClsGlobal.UrlMMedia + szImgBig).Replace("\\", "/")).Replace("//", "/");
        //    string szPathFul = ((ClsGlobal.UrlMMedia + szImgFul).Replace("\\", "/")).Replace("//", "/");
        //    if (!System.IO.File.Exists(szPathMed) )
        //    {   
        //        szHtml = "<img  class=\"th\" src=\"" + szImgNoExist + "\" alt=\"" + pTitle + "\"  title=\"" + pTitle + "\" />";
        //        return szHtml;
        //    }

        //    if (System.IO.File.Exists(szPathFul))
        //    {
        //        szHtml = oPP.fncHtmlAloneRowPhotoFB(szImgFul, szImgMed, pTitle, pTitle, pSectionDoc);
        //        return szHtml;
        //    }
        //    if (System.IO.File.Exists(szPathbig))
        //    {
        //        szHtml = oPP.fncHtmlAloneRowPhotoFB(szPathbig, szImgMed, pTitle, pTitle, pSectionDoc);
        //        return szHtml;
        //    }

        //    // si no existe ful ni big devuelve la imagen sin enlace
          
        //    szHtml = "<img  class=\"th\" src=\"" + szImgMed + "\" alt=\"" + pTitle + "\"  title=\"" + pTitle + "\" />";
          
        //    return szHtml;
        //}


        private string fncBldHtmlPretyPhotoAloneInLine(string pImgThun, string pTitTop, string pTitBot)
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
                szFileTargetPath = (ClsGlobal.UrlMMedia + szImgTarget).Replace("\\", "/").Replace("//", "/");
            }
             oPP.fncGallery_New("galleryId", "GalleryTit");
            szHtml = oPP.fncHtmlAloneIframeInlineImageFB(szImgTarget, pImgThun, pTitTop, pTitBot);
            return szHtml;
        }
        private string fncBldHtmlPretyPhotoIframeAlone(string pIdModal, string pUrlIframe, string pImgThun, string pTitTop, string pTitBot)
        {
            string szPath = ((ClsGlobal.UrlMMedia + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
            }
            string szHtml="";
          szHtml+="\n<a  href=\"#\" data-reveal-id=\""+pIdModal+"\"   data-reveal>";
          szHtml+="\n<img src=\""+pImgThun+"\" />";
          szHtml+="\n</a>";
          szHtml+="\n<div id=\""+  pIdModal +"\" class=\"reveal-modal\" data-reveal>";
          szHtml+= "\n<iframe src=\"" + pUrlIframe + "\" width =\"100%\"  height=\"300px\" ></iframe>";
          szHtml+="\n<a class=\"close-reveal-modal\">&#215;</a>";
          szHtml+="\n</div>";
            return szHtml;
        }
        private string fncBldHtmlPretyPhotoIframeAloneInline(string pUrlIframe, string pImgThun, string pTitTop, string pTitBot)
        {
            string szPath = ((ClsGlobal.UrlMMedia + pImgThun).Replace("\\", "/")).Replace("//", "/");
            if (!System.IO.File.Exists(szPath) || pImgThun.Contains("noimage1024px.png"))
            {
                pImgThun = "/a_img/noimage200px.png";
            }


            oPP.fncGallery_New("galleryId", "GalleryTit");
            string szHtml = oPP.fncHtmlAloneIframeInlineImageFB(pUrlIframe, pImgThun, pTitTop, pTitBot);
            return szHtml;
        }
        private string fncBldHtmlGallery(string scnFolder)
        {
            string szPath = ClsGlobal.DirMMedia + scnFolder;
            szPath = (szPath.Replace("\\", "/")).Replace("//", "/").Replace("//", "/");
            szPath = szPath.Replace("mmedia/mmedia", "mmedia");
            if (!System.IO.Directory.Exists(szPath))
            {
                return "Gallery not available";
            }
            szPath = szPath.ToLower();
            cls.bbdd.ClsReg_tdoclng_media oRegMedia = new testudines.cls.bbdd.ClsReg_tdoclng_media();
            string szImgTar = "";
            string szImgTarBig = "";
            string szImgThu = "";
            string szTitTop = "";
            string szTitBot = "";
           oPP.fncGallery_New("gallery3", "galeria 3");
            bool bExit = false;
            string szUrl = "";
            string doclngid = "";
            UInt64 DocId = 0;
            string szoFile = "";
            string szFilePathBig = "";
            string szFilePathMed = "";
            bool bAdd = false;
            foreach (string oFile in Directory.GetFiles(szPath))
            {
                szTitBot = "www.testudines.org";
                szTitTop = oRegFul.oRegAll.ATaxNameRecomended; ;

                szoFile = oFile.Trim().ToLower();
                bAdd = false;
                if (szoFile.EndsWith("min.jpg"))
                {
                    bAdd = false;
                    szFilePathMed = szoFile.Replace("min.jpg", "med.jpg").ToLower();
                    szFilePathBig = szoFile.Replace("min.jpg", "big.jpg").ToLower();
                    if (System.IO.File.Exists(szFilePathMed)) bAdd = true;
                    if (System.IO.File.Exists(szFilePathBig)) bAdd = true;
                    if (bAdd)
                    {
                        szUrl = szoFile.Replace(ClsGlobal.UrlMMedia, "");
                        bExit = true;
                        szImgThu = ("/" + szUrl).Replace("//", "/");
                        szImgTar = szImgThu.Replace("min.jpg", "med.jpg").ToLower();
                        szImgTarBig = szImgThu.Replace("min.jpg", "big.jpg").ToLower();

                        if (System.IO.File.Exists(szFilePathBig)) szImgTar = szImgTarBig;
                        if (oRegMedia.fncFindIdDoc_ForUrl(szImgThu, ref DocId, ref doclngid))
                        {
                            if (oRegMedia.fncSqlFind(DocId, doclngid))
                            {
                                szTitBot = oRegMedia.FileNameShort.Replace("_", " ");
                                szTitTop = oRegMedia.Title + ", by " + oRegMedia.Author;
                            }


                        }
                        oPP.fncGallery_AddPictureFB(szImgTar, szImgThu, szTitBot, szTitTop, "ind_Capitule06_06CarVivariuminOut");
                    }
                }
            }
            if (bExit)
            {
                return oPP.HtmGalleryFB + "<br/>";
            }
            else
            {
                return "No imagen in gallery";
            }
        }
        public void fnc_calc_m_LastUpdate()
        {
            
            m_LastUpdate= "<p class=\"align_text_right\">" + Resources.Strings.date_last_update + ": " + oRegFul.oRegAll.ADateUpdate.ToLongDateString() + "</p>";
           
        }
        //private string fncHtmlAuthors()
        //{
        //    string sz = "";
        //    if (oRegDoc.DocAuthors.Trim() != "")
        //    {
        //        sz += "<span class=\"Authors\">Aut.:" + oRegDoc.DocAuthors.Trim() + "</span>";
        //    }

        //    return sz;
        //}


        private  string fncCultureGetString(string szTranslate)
        {
            //TODO NO RECUPERA LOS STRING DE LOS RESOURCES

            //ResourceManager m_RManagerTaxon = new ResourceManager("page_taxon.resx", typeof(www).Assembly);  
           
           
            ResourceManager m_RManagerTaxon = new ResourceManager("www.page_taxon.resx", Assembly.GetExecutingAssembly());
            string szTranslated = "";
            string sz = szTranslate.ToLower();
            try
            {

                szTranslated = m_RManagerTaxon.GetString("terrestrial", CultureInfo.CurrentCulture);
                szTranslated = m_RManagerTaxon.GetString(sz, CultureInfo.CurrentCulture);
            }
            catch (Exception xcpt)

            {
                 sz= xcpt.Message;
                szTranslated = szTranslate + "*";
            }
            return szTranslated;
        }
        #endregion regtools
        //######################################################################
        //######################################################################
    }
}
