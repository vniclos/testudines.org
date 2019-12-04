using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.tortoises
{
    
    public partial class tortoise_mng_edit :  cls.ClsPageBaseEdit
    {
        //------------------------
        private cls.bbdd.ClsReg_tdoclng_testudines_all oRegES = new cls.bbdd.ClsReg_tdoclng_testudines_all();
        private cls.bbdd.ClsReg_tdoclng_testudines_all oRegEN = new cls.bbdd.ClsReg_tdoclng_testudines_all();
        private cls.cache.ClsCache_Tortoise oCache = new cls.cache.ClsCache_Tortoise();
        private UInt64 m_DocId = 0;
        private  String m_DocLngId = "";
        private String m_msg = "";
        private string m_tableName = "tdoclng_testudines_ful";
        private String m_MaskUrl = "tortoises/tortoise/tortoise"; // para crear url friendly, despues agregra idioma y titulo y barras automaticamente
        private string m_DocTypeId = "tortoise";
        //------------------------

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!cls.ClsUtils.User_isAdmin())
            {
                string szUrOops = cls.ClsUtils.Oops_Redirect(Request.Url.ToString(), "Not autorized to this page");
                Response.Redirect(szUrOops);

            }
            if (!IsPostBack )
            {
                FncFillBreadCrumb();
                FncGetParamenters();
                FncFillBreadCrumb();
                
                FncFillMainContentLeft();
                FncFillMailContentRight();
                FncFillHead();

            }
        }
        private void FncGetParamenters()
        {

            UInt64 DocId = 1;
            String DocLngId = "es";

            try
            {
                DocId = Convert.ToUInt64(Page.RouteData.Values["docid"].ToString());
                DocLngId = Page.RouteData.Values["doclngid"].ToString().ToLower();
            }
            catch {; }
            if (Request.QueryString["docid"] != null)
            {
                DocId = Convert.ToUInt64(Request.QueryString["docid"].ToString());
            }
            if (Request.QueryString["doclngid"] != null)
            {
                DocLngId = Request.QueryString["doclngid"].ToString();
            }
            m_DocId = DocId;
            scnDocId.Text = m_DocId.ToString();
            // m_DocLngId = DocLngId;



        }
        private void FncFillBreadCrumb()
        {
            String szBreadCrumb = "";
            cls.ClsHtml.FncHtmlBreadcrumbStart(ref szBreadCrumb);
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Articles", "/" + cls.ClsGlobal.LngIdThread + "/articles/articles-list/");
            cls.ClsHtml.FncHtmlBreadcrumbAdd(ref szBreadCrumb, "Article Edit", "");
            cls.ClsHtml.FncHtmlBreadcrumbEnd(ref szBreadCrumb);
            Mpg_BreadCrumb(ref szBreadCrumb);
        }
        private void FncFillHead()
        {
            Page.Title = Resources.Strings.Edit + Resources.Strings.mnTortoises_taxa_mng_edit + " " + oRegES.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;
        }
        //----------------------------
        //----------------------------
        //----------------------------
        private void FncFillMainContentLeft() { FncScreenFromReg(); }
        //----------------------------
        //----------------------------
        //----------------------------

        private void FncFillMailContentRight()
        {
            

        }
        //----------------------------
        //--------SCREEN FROM REG ----
        //----------------------------

        private void FncScreenFromReg()
        {
            scnDocId.Text = m_DocId.ToString();
            Mpg_SetDocumentId(m_DocId, "xx");
           
            
            scn_oDocLng_edit_ES.FncFilldoclngidId(m_DocId, "es");
            scn_oDocLng_edit_EN.FncFilldoclngidId(m_DocId, "en");
            scn_oDdoc_edit.FncFillDocId(m_DocId, "taxon");
            FncScreenFromReg_ES();
            FncScreenFromReg_EN();
            FncScreenFromReg_XX(ref oRegES);
        }
        private void FncScreenFromReg_ES()
        {
            oRegES.FncSqlFind(m_DocId, "es");
            // EXCEPCIONES 
            // scnES_Title.Text = oRegEN.oRegAbs.Title; (Excepcion es el mismo para los dos idiomas)

            scnATaxGrpL0001lNameFullRecomeded_XX.Text = oRegES.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;
            // ...........................................................

            // ...........................................................

            scnES_LAbsCare.Text = oRegES.oRegCare.LCareAbstract;
           //todo new  scnES_LAbsHabClimateEcozone.Text = oRegES.oRegAbs.LAbsClimateEcozone;

            scnES_LAbsDes.Text = oRegES.oRegDesc.LDesAbstract;
            scnES_LAbsHisNat.Text = oRegES.oRegNatu.LNatuAsbstract;
            scnES_LAbsRngHab.Text = oRegES.oRegGeo.LGeoAbstract;
            scnES_LTaxEtimology.Text = oRegES.oRegTaxa.LTaxEtimology;
            scnES_LTaxNameVulgar.Text = oRegES.oRegTaxaAll.ATaxNameVulgarES;
            scnEN_LTaxNameVulgar.Text = oRegES.oRegTaxaAll.ATaxNameVulgarEN;
            scnES_LTaxNotes.Text = oRegES.oRegTaxa.LTaxNotes;


            scnES_LCareBreeding.Text = oRegES.oRegCare.LCareBreeding;// ();
            scnES_LCareEspecialist.Text = oRegES.oRegCare.LCareEspecialist;// ();
            scnES_LCareFood.Text = oRegES.oRegCare.LCareFood;// ();
            scnES_LCareNotes.Text = oRegES.oRegCare.LCareNotes;// ();
            scnES_LCareValues.Text = oRegES.oRegCare.LCareValues;// ();
            scnES_LCareVivariumIndoor.Text = oRegES.oRegCare.LCareVivariumIndoor;// ();
            scnES_LCareVivariumOutdoor.Text = oRegES.oRegCare.LCareVivariumOutdoor;// ();

            scnES_LDesBabys.Text = oRegES.oRegDesc.LDesBabysShape;// ();
            scnES_LDesDiferentiation.Text = oRegES.oRegDesc.LDesDiferentiation;// ();
            scnES_LDesDimorphism.Text = oRegES.oRegDesc.LDesDimorphism;// ();
            scnES_LDesAbstract.Text = oRegES.oRegDesc.LDesAbstract;// ();
            scnES_LDesHolotype.Text = oRegES.oRegDesc.LDesHolotype;// ();
            scnES_LDesInternal.Text = oRegES.oRegDesc.LDesInternal;// ();
            scnES_LDesKeys.Text = oRegES.oRegDesc.LDesKeys;// ();
            scnES_LDesNotes.Text = oRegES.oRegDesc.LDesNotes;// ();
            scnES_LDesViewDorsal.Text = oRegES.oRegDesc.LDesViewDorsalShape;// ();
            scnES_LDesViewFrontal.Text = oRegES.oRegDesc.LDesViewFrontal;// ();
            scnES_LDesViewHeadNeck.Text = oRegES.oRegDesc.LDesViewHeadNeckShape;// ();
            scnES_LDesViewLateral.Text = oRegES.oRegDesc.LDesViewLateral;// ();
            scnES_LDesViewLegsTail.Text = oRegES.oRegDesc.LDesViewLegsTailShape;// ();
            scnES_LDesViewRear.Text = oRegES.oRegDesc.LDesViewRear;// ();
            scnES_LDesViewVentralBridge.Text = oRegES.oRegDesc.LDesViewVentralBridgeShape;// ();

            scnES_LGeoClimate.Text = oRegES.oRegGeo.LGeoClimateKoppenGeigerName;// ();

            scnES_LHabGeoCountryNotes.Text = oRegES.oRegGeo.LGeoPoliNotes;// ();
            scnES_LHabGeoEcoBiogeographicRegion.Text = oRegES.oRegGeo.LGeoBioWWFRegionNames;// ();


            scnES_LNatuBreeding.Text = oRegES.oRegNatu.LNatuBreeding;// ();
            scnES_LNatuDangers.Text = oRegES.oRegNatu.LNatuDangers;// ();
            scnES_LNatuProAction.Text = oRegES.oRegNatu.LNatuProAction;// ();
            scnES_LNatuFoodChain.Text = oRegES.oRegNatu.LNatuFoodChain;// ();
            scnES_LNatuLifestyles.Text = oRegES.oRegNatu.LNatuLifestyles;// ();
            scnES_LNatuMediaType.Text = oRegES.oRegNatu.LNatuMediaType;// ();
            scnES_LNatuNotes.Text = oRegES.oRegNatu.LNatuNotes;// ();

            //scnES_DocLngMetaAuthor.Text = oRegES.oRegLng.DocLngMetaAuthor;// ();

            //.............................................................................


        }

        private void FncScreenFromReg_EN()
        {
            oRegEN.FncSqlFind(m_DocId, "en");
            // EXCEPCIONEN 
            // scnEN_Title.Text = oRegEN.oRegAbs.Title; (Excepcion es el mismo para los dos idiomas)

            scnATaxGrpL0001lNameFullRecomeded_XX.Text = oRegEN.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;
            // ...........................................................

            // ...........................................................

            scnEN_LAbsCare.Text = oRegEN.oRegCare.LCareAbstract;
            //todo new   scnEN_LAbsHabClimateEcozone.Text = oRegEN.oRegAbs.LAbsClimateEcozone;

            scnEN_LAbsDes.Text = oRegEN.oRegDesc.LDesAbstract;
            scnES_LAbsHisNat.Text = oRegEN.oRegNatu.LNatuAsbstract;
            scnEN_LAbsRngHab.Text = oRegEN.oRegGeo.LGeoAbstract;
            scnEN_LTaxEtimology.Text = oRegEN.oRegTaxa.LTaxEtimology;
            scnEN_LTaxNameVulgar.Text = oRegEN.oRegTaxaAll.ATaxNameVulgarEN;
            scnEN_LTaxNameVulgar.Text = oRegEN.oRegTaxaAll.ATaxNameVulgarEN;
            scnEN_LTaxNotes.Text = oRegEN.oRegTaxa.LTaxNotes;


            scnEN_LCareBreeding.Text = oRegEN.oRegCare.LCareBreeding;// ();
            scnEN_LCareEspecialist.Text = oRegEN.oRegCare.LCareEspecialist;// ();
            scnEN_LCareFood.Text = oRegEN.oRegCare.LCareFood;// ();
            scnEN_LCareNotes.Text = oRegEN.oRegCare.LCareNotes;// ();
            scnEN_LCareValues.Text = oRegEN.oRegCare.LCareValues;// ();
            scnEN_LCareVivariumIndoor.Text = oRegEN.oRegCare.LCareVivariumIndoor;// ();
            scnEN_LCareVivariumOutdoor.Text = oRegEN.oRegCare.LCareVivariumOutdoor;// ();

            scnEN_LDesBabys.Text = oRegEN.oRegDesc.LDesBabysShape;// ();
            scnEN_LDesDiferentiation.Text = oRegEN.oRegDesc.LDesDiferentiation;// ();
            scnEN_LDesDimorphism.Text = oRegEN.oRegDesc.LDesDimorphism;// ();
            scnEN_LDesAbstract.Text = oRegEN.oRegDesc.LDesAbstract;// ();
            scnEN_LDesHolotype.Text = oRegEN.oRegDesc.LDesHolotype;// ();
            scnEN_LDesInternal.Text = oRegEN.oRegDesc.LDesInternal;// ();
            scnEN_LDesKeys.Text = oRegEN.oRegDesc.LDesKeys;// ();
            scnEN_LDesNotes.Text = oRegEN.oRegDesc.LDesNotes;// ();
            scnEN_LDesViewDorsal.Text = oRegEN.oRegDesc.LDesViewDorsalShape;// ();
            scnEN_LDesViewFrontal.Text = oRegEN.oRegDesc.LDesViewFrontal;// ();
            scnEN_LDesViewHeadNeck.Text = oRegEN.oRegDesc.LDesViewHeadNeckShape;// ();
            scnEN_LDesViewLateral.Text = oRegEN.oRegDesc.LDesViewLateral;// ();
            scnEN_LDesViewLegsTail.Text = oRegEN.oRegDesc.LDesViewLegsTailShape;// ();
            scnEN_LDesViewRear.Text = oRegEN.oRegDesc.LDesViewRear;// ();
            scnEN_LDesViewVentralBridge.Text = oRegEN.oRegDesc.LDesViewVentralBridgeShape;// ();

            scnEN_LGeoClimate.Text = oRegEN.oRegGeo.LGeoClimateKoppenGeigerNotes;// ();

            scnEN_LHabGeoCountryNotes.Text = oRegEN.oRegGeo.LGeoPoliNotes;// ();
            scnEN_LHabGeoEcoBiogeographicRegion.Text = oRegEN.oRegGeo.LGeoBioWWFNotes;// ();


            scnEN_LNatuBreeding.Text = oRegEN.oRegNatu.LNatuBreeding;// ();
            scnEN_LNatuDangers.Text = oRegEN.oRegNatu.LNatuDangers;// ();
            scnEN_LNatuProAction.Text = oRegEN.oRegNatu.LNatuProAction;// ();
            scnEN_LNatuFoodChain.Text = oRegEN.oRegNatu.LNatuFoodChain;// ();
            scnEN_LNatuLifestyles.Text = oRegEN.oRegNatu.LNatuLifestyles;// ();
            scnEN_LNatuMediaType.Text = oRegEN.oRegNatu.LNatuMediaType;// ();
            scnEN_LNatuNotes.Text = oRegEN.oRegNatu.LNatuNotes;// ();

            //scnEN_DocLngMetaAuthor.Text = oRegEN.oRegLng.DocLngMetaAuthor;// ();

            //.............................................................................


        }
        //---------------------------------
        //------------- SCREEN FROM REG XX
        //---------------------------------
        private void FncScreenFromReg_XX(ref cls.bbdd.ClsReg_tdoclng_testudines_all pRegXX)
        {
            // desde tdoc.

            scnXX_DocPdfUrl.Text = oRegES.oRegDoc.DocPdfUrl;
            scnXX_DocPdfVersion.Text= oRegES.oRegDoc.DocPdfVersion.ToString();
            scnXX_DocPdfTitle.Text = oRegES.oRegDoc.DocPdfTitle;
            scnXX_PdfMsg.Text = "";
            
            scnXX_DocPdfUrlEmbebed.Text=cls.ClsUtils.Fnc_BldHtmPdf(oRegES.oRegDoc.DocPdfUrl);
            if (scnXX_DocPdfUrlEmbebed.Text == "")
            {
                scnXX_DocPdfUrl.Text += " [No exist]";
            }
            scnAutors_XX.Text = scn_oDdoc_edit.Authors;
            scnXX_Bibliography.Text = scn_oDdoc_edit.Bibliography;
            scnXX_Acknoelegment.Text = scn_oDdoc_edit.Acknowledgements;
              scnXX_ADesMeasureLenghtCm.Text = oRegEN.oRegDescAll.ADesMeasureLenghtCm.ToString();// ();
              scnXX_ADesMeasureWeightGrm.Text = oRegEN.oRegDescAll.ADesMeasureWeightGrm.ToString();// ();
           
            scnAOth_UrlImages.Text = pRegXX.oRegOthAll.AOth_UrlImages; // ();
            scnAOth_WorkFlow_IsRewrited.Checked =Convert.ToBoolean( pRegXX.oRegOthAll.AOth_WorkFlow_IsRewrited); // ();


            cls.ClsUtils.FncDropDownList_TaxonTypeFill(ref scnXX_DocTypeGroup, scn_oDdoc_edit.DocTypeGroup);
            cls.ClsUtils.FncDropDownList_TaxonTypeSubFill(ref scnXX_DocTypeGroupSub, scn_oDdoc_edit.DocTypeGroupSub);

            scnXX_ADngLevelCites.SelectedValue = pRegXX.oRegNatuAll.ANatDngLevelCites;
            cls.ClsUtils.FncDropDownRedList(ref scnXX_ADngLevelRedList, ref scnXX_ADngLevelRedListImg, "es", pRegXX.oRegNatuAll.ANatDngLevelRedList);

          
             scnXX_ALnk2000.Text = oRegEN.oRegOthAll.AOth_LnkUrl_2000;// ();
            scnXX_ALnkCITESDoc.Text = pRegXX.oRegOthAll.AOth_LnkUrl_CITESDoc;// ();

            scnXX_ATax_ItisTsn.Text = pRegXX.oRegTaxaAll.ATax_ItisTsn.ToString();// ();
            if (scnXX_ATax_ItisTsn.Text.Length > 0)
            {
                scnItisSearchBtn.NavigateUrl = "https://www.itis.gov/servlet/SingleRpt/SingleRpt?search_topic=TSN&search_value=" + scnXX_ATax_ItisTsn.Text + "#null";
            }
            scnXX_ALnkIUCN.Text = pRegXX.oRegOthAll.AOth_LnkUrl_IUCN;// ();
                                                          //  scnXX_ALnkOther.Text = oRegEN.oRegTaxaAll.ALnkOther;// ();
            scnXX_ALnkReptileDataBase.Text = pRegXX.oRegOthAll.AOth_LnkUrl_ReptileDataBase;// ();
            scnXX_ALnkTurtlesOfTheWorld.Text = pRegXX.oRegOthAll.AOth_LnkUrl_TurtlesOfTheWorld;// ();
            scnXX_ALnkOther.Text = pRegXX.oRegOthAll.AOth_LnkUrl_Other;
            scnXX_ANatuKeyBreeding.Text = pRegXX.oRegNatuAll.ANatuKeyBreeding;// ();
            scnXX_AKeyNaturalFood.Text = pRegXX.oRegNatuAll.ANatuKeyFood;// ();
            scnXX_AKeyNaturalMedia.Text = pRegXX.oRegNatuAll.ANatuKeyMedia;// ();
            scnXX_ATaxGrpL2000Class.Text = pRegXX.oRegTaxaAll.ATaxGrpL2000Class;// ();
            scnXX_ATaxGrpL2210Order.Text = pRegXX.oRegTaxaAll.ATaxGrpL2210Order;// ();
            scnXX_ATaxGrpL2210Order.Text = pRegXX.oRegTaxaAll.ATaxGrpL2220SubOrder;// ();
            scnXX_ATaxGrpL2230SupFamily.Text = pRegXX.oRegTaxaAll.ATaxGrpL2230SupFamily;// ();
            scnXX_ATaxGrpL2240Family.Text = pRegXX.oRegTaxaAll.ATaxGrpL2240Family;// ();
            scnXX_ATaxGrpL2250SubFamily.Text = pRegXX.oRegTaxaAll.ATaxGrpL2250SubFamily;// ();
            scnXX_ATaxGrpL2260SupGenus.Text = pRegXX.oRegTaxaAll.ATaxGrpL2260SupGenus;// ();
            scnXX_ATaxGrpL2270Genus.Text = pRegXX.oRegTaxaAll.ATaxGrpL2270Genus;// ();
            scnXX_ATaxGrpL2280Specie.Text = pRegXX.oRegTaxaAll.ATaxGrpL2280Specie;// ();
            scnXX_ATaxGrpL2281SubSpecie.Text = pRegXX.oRegTaxaAll.ATaxGrpL2281SubSpecie;// ();
            scnXX_ATaxGrpL2282Authority.Text = pRegXX.oRegTaxaAll.ATaxGrpL2282Authority;// ();
            scnXX_ATaxGrpL2283Year.Text = pRegXX.oRegTaxaAll.ATaxGrpL2283Year;// ();
            scnXX_ATaxNameVulgarEN.Text = pRegXX.oRegTaxaAll.ATaxNameVulgarEN;// ();
            scnXX_ATaxNameVulgarES.Text = pRegXX.oRegTaxaAll.ATaxNameVulgarES;// ();
            scnXX_ATaxGrpL0001lNameFullRecomeded.Text = pRegXX.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;// ();
            scnXX_ATaxNameVulgarOthers.Text = pRegXX.oRegTaxaAll.ATaxNameVulgarOthers;// ();
            scnXX_ATaxSinonimous.Text = pRegXX.oRegTaxaAll.ATaxNameVulgarOthers;// ();

            // pRegXX.oRegGeoAll.AGeoKeyClimateEcozone
            cls.ClsUtils.FncDropDownEcozones(ref scnXX_AGeoKeyClimateEcozone, oRegES.oRegGeoAll.AGeoClimateKoppenGeigerKeys, "es");
            // scnXX_AGeoKeyClimateEcozone.SelectedValue = pRegXX.oRegGeoAll.AGeoKeyClimateEcozone;// ();
            scnXX_AGeoClimateTableLocation.Text = pRegXX.oRegGeoAll.AGeoClimateTableLocation;// ();



            scnXX_AGeoDrawRainML.Checked = Convert.ToBoolean(pRegXX.oRegGeoAll.AGeoDrawRainML);// ();
            scnXX_AAGeoDrawSun.Checked = Convert.ToBoolean(pRegXX.oRegGeoAll.AGeoDrawSun);// ();

            scnXX_AGeoDrawTempMax.Checked = Convert.ToBoolean(pRegXX.oRegGeoAll.AGeoDrawTempMax);// ();
            scnXX_AGeoDrawTempAvg.Checked = Convert.ToBoolean(pRegXX.oRegGeoAll.AGeoDrawTempAvg);// ();
            scnXX_AGeoDrawTempMin.Checked = Convert.ToBoolean(pRegXX.oRegGeoAll.AGeoDrawTempMin);// ();

            
            scnXX_AGeoKeyGeoBiogeographicRegion.SelectedValue = pRegXX.oRegGeoAll.AGeoBioWWFRegionKeys;// ();
            scnXX_AGeoKeyContinent.SelectedValue = pRegXX.oRegGeoAll.AGeoPoliContinentKeys;// ();
            scnXX_AGeoKeyCountries.Text = pRegXX.oRegGeoAll.AGeoPoliCountriestKeys;// ();
            scnXX_AGeoLocLatitudMax.Text = pRegXX.oRegGeoAll.AGeoLocLatitudMax.ToString();// ();
            scnXX_AGeoLocLatitudMin.Text = pRegXX.oRegGeoAll.AGeoLocLatitudMin.ToString();// ();
            scnXX_AGeoLocation.Text = pRegXX.oRegGeoAll.AGeoPoliLocationType;// ();


            scnXX_AGeoRainDays01.Text = pRegXX.oRegGeoAll.AGeoRainDays01.ToString();// ();
            scnXX_AGeoRainDays02.Text = pRegXX.oRegGeoAll.AGeoRainDays02.ToString();// ();
            scnXX_AGeoRainDays03.Text = pRegXX.oRegGeoAll.AGeoRainDays03.ToString();// ();
            scnXX_AGeoRainDays04.Text = pRegXX.oRegGeoAll.AGeoRainDays04.ToString();// ();
            scnXX_AGeoRainDays05.Text = pRegXX.oRegGeoAll.AGeoRainDays05.ToString();// ();
            scnXX_AGeoRainDays06.Text = pRegXX.oRegGeoAll.AGeoRainDays06.ToString();// ();
            scnXX_AGeoRainDays07.Text = pRegXX.oRegGeoAll.AGeoRainDays07.ToString();// ();
            scnXX_AGeoRainDays08.Text = pRegXX.oRegGeoAll.AGeoRainDays08.ToString();// ();
            scnXX_AGeoRainDays09.Text = pRegXX.oRegGeoAll.AGeoRainDays09.ToString();// ();
            scnXX_AGeoRainDays10.Text = pRegXX.oRegGeoAll.AGeoRainDays10.ToString();// ();
            scnXX_AGeoRainDays11.Text = pRegXX.oRegGeoAll.AGeoRainDays11.ToString();// ();
            scnXX_AGeoRainDays12.Text = pRegXX.oRegGeoAll.AGeoRainDays12.ToString();// ();
            scnXX_AGeoRainDaysYear.Text = pRegXX.oRegGeoAll.AGeoRainDays_YearSum.ToString();// ();

            scnXX_AGeoRainML01.Text = pRegXX.oRegGeoAll.AGeoRainML01.ToString();// ();
            scnXX_AGeoRainML02.Text = pRegXX.oRegGeoAll.AGeoRainML02.ToString();// ();
            scnXX_AGeoRainML03.Text = pRegXX.oRegGeoAll.AGeoRainML03.ToString();// ();
            scnXX_AGeoRainML04.Text = pRegXX.oRegGeoAll.AGeoRainML04.ToString();// ();
            scnXX_AGeoRainML05.Text = pRegXX.oRegGeoAll.AGeoRainML05.ToString();// ();
            scnXX_AGeoRainML06.Text = pRegXX.oRegGeoAll.AGeoRainML06.ToString();// ();
            scnXX_AGeoRainML07.Text = pRegXX.oRegGeoAll.AGeoRainML07.ToString();// ();
            scnXX_AGeoRainML08.Text = pRegXX.oRegGeoAll.AGeoRainML08.ToString();// ();
            scnXX_AGeoRainML09.Text = pRegXX.oRegGeoAll.AGeoRainML09.ToString();// ();
            scnXX_AGeoRainML10.Text = pRegXX.oRegGeoAll.AGeoRainML10.ToString();// ();
            scnXX_AGeoRainML11.Text = pRegXX.oRegGeoAll.AGeoRainML11.ToString();// ();
            scnXX_AGeoRainML12.Text = pRegXX.oRegGeoAll.AGeoRainML12.ToString();// ();
            scnXX_AGeoRainMLYear.Text = pRegXX.oRegGeoAll.AGeoRainML_YearSum.ToString();// ();

            scnXX_AGeoSunMax01.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax01);
            scnXX_AGeoSunMax02.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax02);
            scnXX_AGeoSunMax03.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax03);
            scnXX_AGeoSunMax04.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax04);
            scnXX_AGeoSunMax05.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax05);
            scnXX_AGeoSunMax06.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax06);
            scnXX_AGeoSunMax07.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax07);
            scnXX_AGeoSunMax08.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax08);
            scnXX_AGeoSunMax09.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax09);
            scnXX_AGeoSunMax11.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax11);
            scnXX_AGeoSunMax12.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMax12);

            //String.Format("{0:0.00}", 123.4567);
            scnXX_AGeoSunMin01.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin01);
            scnXX_AGeoSunMin02.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin02);
            scnXX_AGeoSunMin03.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin03);
            scnXX_AGeoSunMin04.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin04);
            scnXX_AGeoSunMin05.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin05);
            scnXX_AGeoSunMin06.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin06);
            scnXX_AGeoSunMin07.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin07);
            scnXX_AGeoSunMin08.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin08);
            scnXX_AGeoSunMin09.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin09);
            scnXX_AGeoSunMin10.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin10);
            scnXX_AGeoSunMin11.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin11);
            scnXX_AGeoSunMin12.Text = String.Format("{0:0.00}", pRegXX.oRegGeoAll.AGeoSunMin12);

            scnXX_AGeoTmpMax01.Text = pRegXX.oRegGeoAll.AGeoTmpMax01.ToString();
            scnXX_AGeoTmpMax02.Text = pRegXX.oRegGeoAll.AGeoTmpMax02.ToString();
            scnXX_AGeoTmpMax03.Text = pRegXX.oRegGeoAll.AGeoTmpMax03.ToString();
            scnXX_AGeoTmpMax04.Text = pRegXX.oRegGeoAll.AGeoTmpMax04.ToString();
            scnXX_AGeoTmpMax05.Text = pRegXX.oRegGeoAll.AGeoTmpMax05.ToString();
            scnXX_AGeoTmpMax06.Text = pRegXX.oRegGeoAll.AGeoTmpMax06.ToString();
            scnXX_AGeoTmpMax07.Text = pRegXX.oRegGeoAll.AGeoTmpMax07.ToString();
            scnXX_AGeoTmpMax08.Text = pRegXX.oRegGeoAll.AGeoTmpMax08.ToString();
            scnXX_AGeoTmpMax09.Text = pRegXX.oRegGeoAll.AGeoTmpMax09.ToString();
            scnXX_AGeoTmpMax10.Text = pRegXX.oRegGeoAll.AGeoTmpMax10.ToString();
            scnXX_AGeoTmpMax11.Text = pRegXX.oRegGeoAll.AGeoTmpMax11.ToString();
            scnXX_AGeoTmpMax12.Text = pRegXX.oRegGeoAll.AGeoTmpMax12.ToString();

        
            scnXX_AGeoTmpMax_YY_Min.Text = pRegXX.oRegGeoAll.AGeoTmpMax_YearMin.ToString();
            scnXX_AGeoTmpMax_YY_Avg.Text = pRegXX.oRegGeoAll.AGeoTmpMax_YearAvg.ToString();
            scnXX_AGeoTmpMax_YY_Max.Text = pRegXX.oRegGeoAll.AGeoTmpMax_YearMax.ToString();



            scnXX_AGeoTmpAvg01.Text = pRegXX.oRegGeoAll.AGeoTmpAvg01.ToString();
            scnXX_AGeoTmpAvg02.Text = pRegXX.oRegGeoAll.AGeoTmpAvg02.ToString();
            scnXX_AGeoTmpAvg03.Text = pRegXX.oRegGeoAll.AGeoTmpAvg03.ToString();
            scnXX_AGeoTmpAvg04.Text = pRegXX.oRegGeoAll.AGeoTmpAvg04.ToString();
            scnXX_AGeoTmpAvg05.Text = pRegXX.oRegGeoAll.AGeoTmpAvg05.ToString();
            scnXX_AGeoTmpAvg06.Text = pRegXX.oRegGeoAll.AGeoTmpAvg06.ToString();
            scnXX_AGeoTmpAvg07.Text = pRegXX.oRegGeoAll.AGeoTmpAvg07.ToString();
            scnXX_AGeoTmpAvg08.Text = pRegXX.oRegGeoAll.AGeoTmpAvg08.ToString();
            scnXX_AGeoTmpAvg09.Text = pRegXX.oRegGeoAll.AGeoTmpAvg09.ToString();
            scnXX_AGeoTmpAvg10.Text = pRegXX.oRegGeoAll.AGeoTmpAvg10.ToString();
            scnXX_AGeoTmpAvg11.Text = pRegXX.oRegGeoAll.AGeoTmpAvg11.ToString();
            scnXX_AGeoTmpAvg12.Text = pRegXX.oRegGeoAll.AGeoTmpAvg12.ToString();

            scnXX_AGeoTmpAvg_YY_Min.Text = pRegXX.oRegGeoAll.AGeoTmpMin_YearAvg.ToString();
            scnXX_AGeoTmpAvg_YY_Avg.Text = pRegXX.oRegGeoAll.AGeoTmpAvg_YearAvg.ToString();
            scnXX_AGeoTmpAvg_YY_Max.Text = pRegXX.oRegGeoAll.AGeoTmpMax_YearMax.ToString();



            scnXX_AGeoTmpMin01.Text = pRegXX.oRegGeoAll.AGeoTmpMin01.ToString();
            scnXX_AGeoTmpMin02.Text = pRegXX.oRegGeoAll.AGeoTmpMin02.ToString();
            scnXX_AGeoTmpMin03.Text = pRegXX.oRegGeoAll.AGeoTmpMin03.ToString();
            scnXX_AGeoTmpMin04.Text = pRegXX.oRegGeoAll.AGeoTmpMin04.ToString();
            scnXX_AGeoTmpMin05.Text = pRegXX.oRegGeoAll.AGeoTmpMin05.ToString();
            scnXX_AGeoTmpMin06.Text = pRegXX.oRegGeoAll.AGeoTmpMin06.ToString();
            scnXX_AGeoTmpMin07.Text = pRegXX.oRegGeoAll.AGeoTmpMin07.ToString();
            scnXX_AGeoTmpMin08.Text = pRegXX.oRegGeoAll.AGeoTmpMin08.ToString();
            scnXX_AGeoTmpMin09.Text = pRegXX.oRegGeoAll.AGeoTmpMin09.ToString();
            scnXX_AGeoTmpMin10.Text = pRegXX.oRegGeoAll.AGeoTmpMin10.ToString();
            scnXX_AGeoTmpMin11.Text = pRegXX.oRegGeoAll.AGeoTmpMin11.ToString();
            scnXX_AGeoTmpMin12.Text = pRegXX.oRegGeoAll.AGeoTmpMin12.ToString();

            scnXX_AGeoTmpMin_YY_Min.Text = pRegXX.oRegGeoAll.AGeoTmpMin_YearMin.ToString();
            scnXX_AGeoTmpMin_YY_Avg.Text = pRegXX.oRegGeoAll.AGeoTmpMin_YearAvg.ToString();
            scnXX_AGeoTmpMin_YY_Max.Text = pRegXX.oRegGeoAll.AGeoTmpMin_YearMax.ToString();


            scnXX_AGeoClimateTableUrlTit.Text = pRegXX.oRegGeoAll.AGeoClimateTableUrlTitle;// ();
            scnXX_AGeoClimateTableUrlUrl.Text = pRegXX.oRegGeoAll.AGeoClimateTableUrl;// ();




            //------------------------------------------
            //IMAGENES
            //----------------------------------------------------------------------
        

            scnXX_AAbsImg_Range.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_Range;
            scnXX_AAbsImg_Range2.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_Range;

            scnXX_AAbsImg_Specie.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_Specie;
            scnXX_AAbsImg_Specie2.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_Specie;
            

            scnXX_AAbsImg_HNatural.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_HNatural;
            scnXX_AAbsImg_HNatural2.ImageUrl = pRegXX.oRegTaxaAllFile.AAbsImg_HNatural;

            scnXX_ACareImg_Breeding01.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Breeding01;
            scnXX_ACareImg_Breeding02.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Breeding02;
            scnXX_ACareImg_Breeding03.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Breeding03;
            scnXX_ACareImg_Food01.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Food01;
            scnXX_ACareImg_Food02.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Food02;
            scnXX_ACareImg_Food03.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_Food03;
            scnXX_ACareImg_gral01.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_gral01;
            scnXX_ACareImg_gral02.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_gral02;
            scnXX_ACareImg_gral03.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_gral03;
            scnXX_ACareImg_VivariumIndoor01.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor01;
            scnXX_ACareImg_VivariumIndoor02.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor02;
            scnXX_ACareImg_VivariumIndoor03.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor03;
            scnXX_ACareImg_VivariumOutdoor01.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor01;
            scnXX_ACareImg_VivariumOutdoor02.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor02;
            scnXX_ACareImg_VivariumOutdoor03.ImageUrl=pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor03;
            scnXX_ADesImg_BabyDorsal01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal01;
            scnXX_ADesImg_BabyDorsal02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal02;
            scnXX_ADesImg_BabyDorsal03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal03;
            scnXX_ADesImg_BabyVentral01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral01;
            scnXX_ADesImg_BabyVentral02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral02;
            scnXX_ADesImg_BabyVentral03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral03;

            scnXX_ADesImg_BodyBridge01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge01;
            scnXX_ADesImg_BodyBridge02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge02;
            scnXX_ADesImg_BodyBridge03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge03;
            scnXX_ADesImg_BodyDorsal01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal01;
            scnXX_ADesImg_BodyDorsal02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal02;
            scnXX_ADesImg_BodyDorsal03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal03;

            scnXX_ADesImg_BodyFrontal01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal01;
            scnXX_ADesImg_BodyFrontal02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal02;
            scnXX_ADesImg_BodyFrontal03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal03;

            scnXX_ADesImg_BodyLateral01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral01;
            scnXX_ADesImg_BodyLateral02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral02;
            scnXX_ADesImg_BodyLateral03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral03;
            scnXX_ADesImg_BodyRear01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyRear01;
            scnXX_ADesImg_BodyRear02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyRear02;
            scnXX_ADesImg_BodyRear03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyRear03;
            scnXX_ADesImg_BodyVentral01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral01;
            scnXX_ADesImg_BodyVentral02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral02;
            scnXX_ADesImg_BodyVentral03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral03;
            scnXX_ADesImg_DesType01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_DesType01;
            scnXX_ADesImg_DesType02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_DesType02;
            scnXX_ADesImg_DesType03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_DesType03;
            scnXX_ADesImg_Diferentiation01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation01;
            scnXX_ADesImg_Diferentiation02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation02;
            scnXX_ADesImg_Diferentiation03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation03;
            scnXX_ADesImg_Dimorphism01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism01;
            scnXX_ADesImg_Dimorphism02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism02;
            scnXX_ADesImg_Dimorphism03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism03;
            scnXX_ADesImg_Holotype01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Holotype01;
            scnXX_ADesImg_Holotype02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Holotype02;
            scnXX_ADesImg_Holotype03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_Holotype03;
            scnXX_ADesImg_OtherHead01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherHead01;
            scnXX_ADesImg_OtherHead02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherHead02;
            scnXX_ADesImg_OtherHead03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherHead03;
            scnXX_ADesImg_OtherLegs01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs01;
            scnXX_ADesImg_OtherLegs02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs02;
            scnXX_ADesImg_OtherLegs03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs03;
            scnXX_ADesImg_OtherTail01.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherTail01;
            scnXX_ADesImg_OtherTail02.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherTail02;
            scnXX_ADesImg_OtherTail03.ImageUrl = pRegXX.oRegTaxaAllFile.ADesImg_OtherTail03;

            scnXX_AGeoImg_ClimateEcozoneKey.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_ClimateEcozoneKey;
            scnXX_AGeoImg_ClimateWheatherBiome.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherBiome;
            scnXX_AGeoImg_ClimateWheatherRain.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherRain;
            scnXX_AGeoImg_ClimateWheatherSun.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherSun;
            scnXX_AGeoImg_ClimateWheatherTemp.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp;
            scnXX_AGeoImg_GeoRangeMapStandardDetailFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardDetailFul;

            scnXX_AGeoImg_GeoRangeMapStandardKoppenFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardKoppenFul;

            scnXX_AGeoImg_GeoRangeMapStandardWorldFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFul;

            scnXX_AGeoImg_landscapes01.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_landscapes01;
            scnXX_AGeoImg_landscapes02.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_landscapes02;
            scnXX_AGeoImg_landscapes03.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_landscapes03;

            scnXX_ANatImg_Breeding01.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Breeding01;
            scnXX_ANatImg_Breeding02.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Breeding02;
            scnXX_ANatImg_Breeding03.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Breeding03;

            scnXX_ANatImg_Food01.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Food01;
            scnXX_ANatImg_Food02.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Food02;
            scnXX_ANatImg_Food03.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Food03;

            scnXX_ANatImg_Live01.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Live01;
            scnXX_ANatImg_Live02.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Live02;
            scnXX_ANatImg_Live03.ImageUrl=pRegXX.oRegTaxaAllFile.ANatImg_Live03;


            //;
            scnXX_AGeoImg_GeoRangeMapStandardWorldFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFull;
            scnXX_AGeoImg_GeoRangeMapStandardKoppenFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFul;
             scnXX_AGeoImg_GeoRangeMapStandardDetailFul.ImageUrl=pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardKoppenFul;

            
        }

        //----------------------------
        //--------- EVENTOS Y BOTONES
        //----------------------------

        protected void scnBtnNew_Click(object sender, EventArgs e)
        {
            m_DocId = 0;
            m_DocLngId = "es";
            m_msg = "new";
            oRegES.FncClear();
            oRegEN.FncClear();
            scn_oDdoc_edit.FncClear();
            scn_oDocLng_edit_EN.FncClear();
            scn_oDocLng_edit_ES.FncClear();
            FncScreenFromReg();

        }

        protected void scnBtnListMng_Click(object sender, EventArgs e)
        {

            Response.Redirect("/es/tortoises/tortoises-list");
        }

        protected void scnBtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("/es/tortoises/tortoises-list");
        }

        protected void scnBtnSaveES_Click(object sender, EventArgs e)
        {
            FncScreenToReg_ES();
        }

        protected void scnBtnSave_EN_Click(object sender, EventArgs e)
        {
            FncScreenToReg_EN();
        }

        protected void scnBtnRbCacheES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");

            oCache.FncSqlFindTaxon_ful_html(oRegES.DocId, oRegES.DocLngId);
            oCache.FncRebuildCache(true);
        }

        protected void scnBtnRbCacheEn_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");
            oCache.FncSqlFindTaxon_ful_html(oRegEN.DocId, oRegEN.DocLngId);
            oCache.FncRebuildCache(true);
        }

        protected void scnBtnShowES_Click(object sender, EventArgs e)
        {
            UInt64 uiDocId = Convert.ToUInt64(scnDocId.Text);
            Mpg_SetDocumentId(m_DocId, "xx");

            oCache.FncSqlFindTaxon_ful_html(oRegEN.DocId, oRegES.DocLngId);
            oCache.FncRebuildCache(true);

        }

        protected void scnBtnShowEN_Click(object sender, EventArgs e)
        {

        }

        protected void scnBtnHabClimateBldGraph_Click(object sender, EventArgs e)
        {

        }
        protected void scnBtnBiblio_rebuild_Click(object sender, EventArgs e)
        {
            scnXX_Bibliography.Text = cls.ClsHtml.FncHtmlBibliographyBld(Convert.ToUInt64(scnDocId.Text));

        }

        //-----------------------------------------
        //----------------- auxiliares ------------
        //-----------------------------------------
        private bool FncScreenToReg_ES()
        {


            m_DocId = Convert.ToUInt64(scnDocId.Text);
            m_DocLngId = "es";

            // documentos globlales
            scn_oDdoc_edit.FncSave(m_DocId, "tortoise");
            // si es cero implica que es un nuevo registro
            // y recuperamos su id
            m_DocId = scn_oDdoc_edit.DocId;
            scnDocId.Text = m_DocId.ToString();
            // gardamos los metas corresponndiente al idioma
            scn_oDocLng_edit_ES.DocLngMetaTitle = oRegES.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;
            scn_oDocLng_edit_ES.FncSave(m_DocId, m_DocLngId, "/tortoises/tortoise/");

            // guardamos los datos comnes a todos los idiomas

            if (!FncScreenToReg_XX(ref oRegES)) { return false; ; }

            // guardamos los datos de idisma español.

            oRegES.DocId = m_DocId;
            oRegES.DocLngId = m_DocLngId;

            // EXCEPCION MISMO PARA TODOS LOS IDIOMAS


            //.......................................

            oRegES.oRegCare.LCareAbstract = scnES_LAbsCare.Text;

            oRegES.oRegDesc.LDesAbstract = scnES_LAbsDes.Text;
            oRegES.oRegNatu.LNatuAsbstract = scnES_LAbsHisNat.Text;
            oRegES.oRegGeo.LGeoPoliContinentNames = scnES_LAbsRngHab.Text;
            //todo new   añandir cuidados
            oRegES.oRegTaxa.LTaxEtimology = scnES_LTaxEtimology.Text;
            //oRegES.oRegAbs.LTaxNameVulgar = scnES_LTaxNameVulgar.Text;
            oRegES.oRegTaxa.LTaxNotes = scnES_LTaxNotes.Text;


            oRegES.oRegCare.LCareBreeding = scnES_LCareBreeding.Text;
            oRegES.oRegCare.LCareEspecialist = scnES_LCareEspecialist.Text;
            oRegES.oRegCare.LCareFood = scnES_LCareFood.Text;
            oRegES.oRegCare.LCareNotes = scnES_LCareNotes.Text;
            oRegES.oRegCare.LCareValues = scnES_LCareValues.Text;
            oRegES.oRegCare.LCareVivariumIndoor = scnES_LCareVivariumIndoor.Text;
            oRegES.oRegCare.LCareVivariumOutdoor = scnES_LCareVivariumOutdoor.Text;

            oRegES.oRegDesc.LDesBabysShape = scnES_LDesBabys.Text;
            oRegES.oRegDesc.LDesDiferentiation = scnES_LDesDiferentiation.Text;
            oRegES.oRegDesc.LDesDimorphism = scnES_LDesDimorphism.Text;
            oRegES.oRegDesc.LDesAbstract = scnES_LDesAbstract.Text;
            oRegES.oRegDesc.LDesHolotype = scnES_LDesHolotype.Text;
            oRegES.oRegDesc.LDesInternal = scnES_LDesInternal.Text;
            oRegES.oRegDesc.LDesKeys = scnES_LDesKeys.Text;
            oRegES.oRegDesc.LDesNotes = scnES_LDesNotes.Text;
            oRegES.oRegDesc.LDesViewDorsalShape = scnES_LDesViewDorsal.Text;
            oRegES.oRegDesc.LDesViewFrontal = scnES_LDesViewFrontal.Text;
            oRegES.oRegDesc.LDesViewHeadNeckShape = scnES_LDesViewHeadNeck.Text;
            oRegES.oRegDesc.LDesViewLateral = scnES_LDesViewLateral.Text;
            oRegES.oRegDesc.LDesViewLegsTailShape = scnES_LDesViewLegsTail.Text;
            oRegES.oRegDesc.LDesViewRear = scnES_LDesViewRear.Text;
            oRegES.oRegDesc.LDesViewVentralBridgeShape = scnES_LDesViewVentralBridge.Text;

            oRegES.oRegGeo.LGeoClimateKoppenGeigerNotes = scnES_LGeoClimate.Text;
            oRegES.oRegGeo.LGeoPoliNotes = scnES_LHabGeoCountryNotes.Text;
            oRegES.oRegGeo.LGeoBioWWFRegionNames = scnES_LHabGeoEcoBiogeographicRegion.Text;

            oRegES.oRegNatu.LNatuBreeding = scnES_LNatuBreeding.Text;
            oRegES.oRegNatu.LNatuDangers = scnES_LNatuDangers.Text;
            oRegES.oRegNatu.LNatuProAction = scnES_LNatuProAction.Text;
            oRegES.oRegNatu.LNatuFoodChain = scnES_LNatuFoodChain.Text;
            oRegES.oRegNatu.LNatuLifestyles = scnES_LNatuLifestyles.Text;
            oRegES.oRegNatu.LNatuMediaType = scnES_LNatuMediaType.Text;
            oRegES.oRegNatu.LNatuNotes = scnES_LNatuNotes.Text;

            oRegES.oRegDocLng.DocLngMetaAuthor = scn_oDdoc_edit.Authors;




            if (!oRegES.FncSqlSave(m_DocId, m_DocLngId))
            {

                return false;
            }
            m_DocId = oRegES.DocId;
            scnDocId.Text = m_DocId.ToString();
            Mpg_SetDocumentId(m_DocId, "xx");

            FncScreenFromReg_ES();
            FncScreenFromReg_XX(ref oRegES);
            return true;
        }
        private bool FncScreenToReg_EN()
        {


            m_DocId = Convert.ToUInt64(scnDocId.Text);
            m_DocLngId = "es";

            // documentos globlales
            scn_oDdoc_edit.FncSave(m_DocId, "tortoise");
            // si es cero implica que es un nuevo registro
            // y recuperamos su id
            m_DocId = scn_oDdoc_edit.DocId;
            scnDocId.Text = m_DocId.ToString();
            // gardamos los metas corresponndiente al idioma
            scn_oDocLng_edit_EN.DocLngMetaTitle = oRegEN.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded;
            scn_oDocLng_edit_EN.FncSave(m_DocId, m_DocLngId, "/tortoises/tortoise/");

            // guardamos los datos comnes a todos los idiomas

            if (!FncScreenToReg_XX(ref oRegEN)) { return false; ; }

            // guardamos los datos de idisma español.

            oRegEN.DocId = m_DocId;
            oRegEN.DocLngId = m_DocLngId;

            // EXCEPCION MISMO PARA TODOS LOS IDIOMAS


            //.......................................

            oRegEN.oRegCare.LCareAbstract = scnEN_LAbsCare.Text;

            oRegEN.oRegDesc.LDesAbstract = scnEN_LAbsDes.Text;
            oRegEN.oRegNatu.LNatuAsbstract = scnEN_LAbsHisNat.Text;
            oRegEN.oRegGeo.LGeoAbstract = scnEN_LAbsRngHab.Text;
            oRegEN.oRegTaxa.LTaxEtimology = scnEN_LTaxEtimology.Text;
            //todo new  añadir cuidados
            //oRegEN.oRegAbs.LTaxNameVulgar = scnEN_LTaxNameVulgar.Text;
            oRegEN.oRegTaxa.LTaxNotes = scnEN_LTaxNotes.Text;


            oRegEN.oRegCare.LCareBreeding = scnEN_LCareBreeding.Text;
            oRegEN.oRegCare.LCareEspecialist = scnEN_LCareEspecialist.Text;
            oRegEN.oRegCare.LCareFood = scnEN_LCareFood.Text;
            oRegEN.oRegCare.LCareNotes = scnEN_LCareNotes.Text;
            oRegEN.oRegCare.LCareValues = scnEN_LCareValues.Text;
            oRegEN.oRegCare.LCareVivariumIndoor = scnEN_LCareVivariumIndoor.Text;
            oRegEN.oRegCare.LCareVivariumOutdoor = scnEN_LCareVivariumOutdoor.Text;

            oRegEN.oRegDesc.LDesBabysShape = scnEN_LDesBabys.Text;
            oRegEN.oRegDesc.LDesDiferentiation = scnEN_LDesDiferentiation.Text;
            oRegEN.oRegDesc.LDesDimorphism = scnEN_LDesDimorphism.Text;
            oRegEN.oRegDesc.LDesAbstract = scnEN_LDesAbstract.Text;
            oRegEN.oRegDesc.LDesHolotype = scnEN_LDesHolotype.Text;
            oRegEN.oRegDesc.LDesInternal = scnEN_LDesInternal.Text;
            oRegEN.oRegDesc.LDesKeys = scnEN_LDesKeys.Text;
            oRegEN.oRegDesc.LDesNotes = scnEN_LDesNotes.Text;
            oRegEN.oRegDesc.LDesViewDorsalShape = scnEN_LDesViewDorsal.Text;
            oRegEN.oRegDesc.LDesViewFrontal = scnEN_LDesViewFrontal.Text;
            oRegEN.oRegDesc.LDesViewHeadNeckShape = scnEN_LDesViewHeadNeck.Text;
            oRegEN.oRegDesc.LDesViewLateral = scnEN_LDesViewLateral.Text;
            oRegEN.oRegDesc.LDesViewLegsTailShape = scnEN_LDesViewLegsTail.Text;
            oRegEN.oRegDesc.LDesViewRear = scnEN_LDesViewRear.Text;
            oRegEN.oRegDesc.LDesViewVentralBridgeShape = scnEN_LDesViewVentralBridge.Text;

            oRegEN.oRegGeo.LGeoClimateKoppenGeigerNotes = scnEN_LGeoClimate.Text;
            oRegEN.oRegGeo.LGeoPoliNotes = scnEN_LHabGeoCountryNotes.Text;
            oRegEN.oRegGeo.LGeoBioWWFRegionNames = scnEN_LHabGeoEcoBiogeographicRegion.Text;

            oRegEN.oRegNatu.LNatuBreeding = scnEN_LNatuBreeding.Text;
            oRegEN.oRegNatu.LNatuDangers = scnEN_LNatuDangers.Text;
            oRegEN.oRegNatu.LNatuProAction = scnEN_LNatuProAction.Text;
            oRegEN.oRegNatu.LNatuFoodChain = scnEN_LNatuFoodChain.Text;
            oRegEN.oRegNatu.LNatuLifestyles = scnEN_LNatuLifestyles.Text;
            oRegEN.oRegNatu.LNatuMediaType = scnEN_LNatuMediaType.Text;
            oRegEN.oRegNatu.LNatuNotes = scnEN_LNatuNotes.Text;

            oRegEN.oRegDocLng.DocLngMetaAuthor = scn_oDdoc_edit.Authors;




            if (!oRegEN.FncSqlSave(m_DocId, m_DocLngId))
            {

                return false;
            }
            m_DocId = oRegEN.DocId;
            scnDocId.Text = m_DocId.ToString();
            Mpg_SetDocumentId(m_DocId, "xx");
            return true;
        }

        private bool FncScreenToReg_XX(ref cls.bbdd.ClsReg_tdoclng_testudines_all pRegXX)
        {

            scnATaxGrpL0001lNameFullRecomeded_XX.Text = scnATaxGrpL0001lNameFullRecomeded_XX.Text.Trim();
            scn_oDocLng_edit_EN.DocLngMetaTitle = scnATaxGrpL0001lNameFullRecomeded_XX.Text; ;
            scn_oDocLng_edit_ES.DocLngMetaTitle = scnATaxGrpL0001lNameFullRecomeded_XX.Text; ;



            m_DocId = Convert.ToUInt64(scnDocId.Text);
            if (!FncScreenValidateXX()) return false;
            // pRegXX.oRegTaxaAll.ADesMeasureLenghtCm;()=scnXX_ADesMeasureLenghtCm.Text; 
            // pRegXX.oRegTaxaAll.ADesMeasureWeightGrm;()= scnXX_ADesMeasureWeightGrm.Text;
            // pRegXX.oRegTaxaAll.ADngLevelCites;()= scnXX_ADngLevelCites.Text;
            // pRegXX.oRegTaxaAll.ADngLevelRedList;()= scnXX_ADngLevelRedList.Text;


            oRegES.oRegDoc.DocPdfUrl=scnXX_DocPdfUrl.Text ;
            
            oRegES.oRegDoc.DocPdfVersion=Convert.ToUInt32(scnXX_DocPdfVersion.Text ) ;
            oRegES.oRegDoc.DocPdfTitle = scnXX_DocPdfTitle.Text;
            



            pRegXX.DocId = m_DocId;
            pRegXX.DocLngId = m_DocLngId;
            pRegXX.oRegOthAll.AOth_UrlImages = scnAOth_UrlImages.Text;
            pRegXX.oRegOthAll.AOth_WorkFlow_IsRewrited = Convert.ToBoolean(scnAOth_WorkFlow_IsRewrited.Checked);


            pRegXX.oRegOthAll.AOth_LnkUrl_2000 = scnXX_ALnk2000.Text;
            pRegXX.oRegOthAll.AOth_LnkUrl_CITESDoc = scnXX_ALnkCITESDoc.Text;
            pRegXX.oRegOthAll.AOth_LnkId_ITISTSN = Convert.ToUInt64(scnXX_ATax_ItisTsn.Text);
            pRegXX.oRegOthAll.AOth_LnkUrl_IUCN = scnXX_ALnkIUCN.Text;
            pRegXX.oRegOthAll.AOth_LnkUrl_Other = scnXX_ALnkOther.Text;
            pRegXX.oRegOthAll.AOth_LnkUrl_ReptileDataBase = scnXX_ALnkReptileDataBase.Text;
            pRegXX.oRegOthAll.AOth_LnkUrl_TurtlesOfTheWorld = scnXX_ALnkTurtlesOfTheWorld.Text;



            


            pRegXX.oRegNatuAll.ANatuKeyBreeding = scnXX_ANatuKeyBreeding.Text;
            pRegXX.oRegNatuAll.ANatuKeyFood = scnXX_AKeyNaturalFood.Text;
            pRegXX.oRegNatuAll.ANatuKeyMedia = scnXX_AKeyNaturalMedia.Text;

            pRegXX.oRegTaxaAll.ATaxGrpL2000Class = scnXX_ATaxGrpL2000Class.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2210Order = scnXX_ATaxGrpL2210Order.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2220SubOrder = scnXX_ATaxGrpL2210Order.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2230SupFamily = scnXX_ATaxGrpL2230SupFamily.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2240Family = scnXX_ATaxGrpL2240Family.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2250SubFamily = scnXX_ATaxGrpL2250SubFamily.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2260SupGenus = scnXX_ATaxGrpL2260SupGenus.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2270Genus = scnXX_ATaxGrpL2270Genus.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2280Specie = scnXX_ATaxGrpL2280Specie.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2281SubSpecie = scnXX_ATaxGrpL2281SubSpecie.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2282Authority = scnXX_ATaxGrpL2282Authority.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL2283Year = scnXX_ATaxGrpL2283Year.Text;
            pRegXX.oRegTaxaAll.ATaxNameVulgarEN = scnXX_ATaxNameVulgarEN.Text;
            pRegXX.oRegTaxaAll.ATaxNameVulgarES = scnXX_ATaxNameVulgarES.Text;
            //pRegXX.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded= scnXX_ATaxGrpL0001lNameFullRecomeded.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL0001lNameFullRecomeded = scnATaxGrpL0001lNameFullRecomeded_XX.Text;

            pRegXX.oRegTaxaAll.ATaxNameVulgarOthers = scnXX_ATaxNameVulgarOthers.Text;
            pRegXX.oRegTaxaAll.ATaxGrpL0002NameSinonimous = scnXX_ATaxSinonimous.Text;



            pRegXX.oRegGeoAll.AGeoClimateKoppenGeigerKeys = scnXX_AGeoKeyClimateEcozone.Text;
            pRegXX.oRegGeoAll.AGeoClimateTableLocation = scnXX_AGeoClimateTableLocation.Text;

            /*



                    
                    = oRegEN.oRegGeoAll.AGeoDrawSun;// ();

                    scnXX_AGeoDrawTempMax.Checked = oRegEN.oRegGeoAll.AGeoDrawTempMax;// ();
                    scnXX_AGeoDrawTempAvg.Checked = oRegEN.oRegGeoAll.AGeoDrawTempAvg;// ();

                     */



            pRegXX.oRegGeoAll.AGeoDrawRainDays =Convert.ToByte( scnXX_AGeoDrawRainDays.Checked);
            pRegXX.oRegGeoAll.AGeoDrawRainML  =  Convert.ToByte(scnXX_AGeoDrawRainML.Checked);
            pRegXX.oRegGeoAll.AGeoDrawSun     = Convert.ToByte(scnXX_AAGeoDrawSun.Checked);
            pRegXX.oRegGeoAll.AGeoDrawTempMax = Convert.ToByte(scnXX_AGeoDrawTempMax.Checked);
            pRegXX.oRegGeoAll.AGeoDrawTempAvg = Convert.ToByte(scnXX_AGeoDrawTempAvg.Checked);
            pRegXX.oRegGeoAll.AGeoDrawTempMin = Convert.ToByte(scnXX_AGeoDrawTempMin.Checked);

            pRegXX.oRegGeoAll.AGeoBioWWFRegionKeys = scnXX_AGeoKeyGeoBiogeographicRegion.SelectedValue.ToString(); ;

            pRegXX.oRegGeoAll.AGeoPoliContinentKeys = scnXX_AGeoKeyContinent.Text;
            pRegXX.oRegGeoAll.AGeoPoliCountriestKeys = scnXX_AGeoKeyCountries.Text;
            pRegXX.oRegGeoAll.AGeoLocLatitudMax = Convert.ToInt32(scnXX_AGeoLocLatitudMax.Text);
            pRegXX.oRegGeoAll.AGeoLocLatitudMin = Convert.ToInt32(scnXX_AGeoLocLatitudMin.Text);
            pRegXX.oRegGeoAll.AGeoPoliLocationType = scnXX_AGeoLocation.Text;

            pRegXX.oRegGeoAll.AGeoRainDays01 = Convert.ToInt32(scnXX_AGeoRainDays01.Text);
            pRegXX.oRegGeoAll.AGeoRainDays02 = Convert.ToInt32(scnXX_AGeoRainDays02.Text);
            pRegXX.oRegGeoAll.AGeoRainDays03 = Convert.ToInt32(scnXX_AGeoRainDays03.Text);
            pRegXX.oRegGeoAll.AGeoRainDays04 = Convert.ToInt32(scnXX_AGeoRainDays04.Text);
            pRegXX.oRegGeoAll.AGeoRainDays05 = Convert.ToInt32(scnXX_AGeoRainDays05.Text);
            pRegXX.oRegGeoAll.AGeoRainDays06 = Convert.ToInt32(scnXX_AGeoRainDays06.Text);
            pRegXX.oRegGeoAll.AGeoRainDays07 = Convert.ToInt32(scnXX_AGeoRainDays07.Text);
            pRegXX.oRegGeoAll.AGeoRainDays08 = Convert.ToInt32(scnXX_AGeoRainDays08.Text);
            pRegXX.oRegGeoAll.AGeoRainDays09 = Convert.ToInt32(scnXX_AGeoRainDays09.Text);
            pRegXX.oRegGeoAll.AGeoRainDays10 = Convert.ToInt32(scnXX_AGeoRainDays10.Text);
            pRegXX.oRegGeoAll.AGeoRainDays11 = Convert.ToInt32(scnXX_AGeoRainDays11.Text);
            pRegXX.oRegGeoAll.AGeoRainDays12 = Convert.ToInt32(scnXX_AGeoRainDays12.Text);
            //pRegXX.oRegGeoAll.AGeoRainDaysYear = Convert.ToInt32(scnXX_AGeoRainDaysYear.Text);

            pRegXX.oRegGeoAll.AGeoRainML01 = Convert.ToInt32(scnXX_AGeoRainML01.Text);
            pRegXX.oRegGeoAll.AGeoRainML02 = Convert.ToInt32(scnXX_AGeoRainML02.Text);
            pRegXX.oRegGeoAll.AGeoRainML03 = Convert.ToInt32(scnXX_AGeoRainML03.Text);
            pRegXX.oRegGeoAll.AGeoRainML04 = Convert.ToInt32(scnXX_AGeoRainML04.Text);
            pRegXX.oRegGeoAll.AGeoRainML05 = Convert.ToInt32(scnXX_AGeoRainML05.Text);
            pRegXX.oRegGeoAll.AGeoRainML06 = Convert.ToInt32(scnXX_AGeoRainML06.Text);
            pRegXX.oRegGeoAll.AGeoRainML07 = Convert.ToInt32(scnXX_AGeoRainML07.Text);
            pRegXX.oRegGeoAll.AGeoRainML08 = Convert.ToInt32(scnXX_AGeoRainML08.Text);
            pRegXX.oRegGeoAll.AGeoRainML09 = Convert.ToInt32(scnXX_AGeoRainML09.Text);
            pRegXX.oRegGeoAll.AGeoRainML10 = Convert.ToInt32(scnXX_AGeoRainML10.Text);
            pRegXX.oRegGeoAll.AGeoRainML11 = Convert.ToInt32(scnXX_AGeoRainML11.Text);
            pRegXX.oRegGeoAll.AGeoRainML12 = Convert.ToInt32(scnXX_AGeoRainML12.Text);
            //pRegXX.oRegGeoAll.AGeoRainMLYear= Convert.ToInt32(scnXX_AGeoRainMLYear.Text);

            pRegXX.oRegGeoAll.AGeoSunMax01 = Convert.ToDouble(scnXX_AGeoSunMax01.Text);
            pRegXX.oRegGeoAll.AGeoSunMax02 = Convert.ToDouble(scnXX_AGeoSunMax02.Text);
            pRegXX.oRegGeoAll.AGeoSunMax03 = Convert.ToDouble(scnXX_AGeoSunMax03.Text);
            pRegXX.oRegGeoAll.AGeoSunMax04 = Convert.ToDouble(scnXX_AGeoSunMax04.Text);
            pRegXX.oRegGeoAll.AGeoSunMax05 = Convert.ToDouble(scnXX_AGeoSunMax05.Text);
            pRegXX.oRegGeoAll.AGeoSunMax06 = Convert.ToDouble(scnXX_AGeoSunMax06.Text);
            pRegXX.oRegGeoAll.AGeoSunMax07 = Convert.ToDouble(scnXX_AGeoSunMax07.Text);
            pRegXX.oRegGeoAll.AGeoSunMax08 = Convert.ToDouble(scnXX_AGeoSunMax08.Text);
            pRegXX.oRegGeoAll.AGeoSunMax09 = Convert.ToDouble(scnXX_AGeoSunMax09.Text);
            pRegXX.oRegGeoAll.AGeoSunMax11 = Convert.ToDouble(scnXX_AGeoSunMax11.Text);
            // pRegXX.oRegGeoAll.AGeoSunMax12= Convert.ToInt32(scnXX_AGeoSunMax12.Text);


            double a = double.Parse(scnXX_AGeoSunMin01.Text, System.Globalization.NumberFormatInfo.CurrentInfo);

            pRegXX.oRegGeoAll.AGeoSunMin01 = Convert.ToDouble(scnXX_AGeoSunMin01.Text, System.Globalization.NumberFormatInfo.CurrentInfo);
            pRegXX.oRegGeoAll.AGeoSunMin02 = Convert.ToDouble(scnXX_AGeoSunMin02.Text);
            pRegXX.oRegGeoAll.AGeoSunMin03 = Convert.ToDouble(scnXX_AGeoSunMin03.Text);
            pRegXX.oRegGeoAll.AGeoSunMin04 = Convert.ToDouble(scnXX_AGeoSunMin04.Text);
            pRegXX.oRegGeoAll.AGeoSunMin05 = Convert.ToDouble(scnXX_AGeoSunMin05.Text);
            pRegXX.oRegGeoAll.AGeoSunMin06 = Convert.ToDouble(scnXX_AGeoSunMin06.Text);
            pRegXX.oRegGeoAll.AGeoSunMin07 = Convert.ToDouble(scnXX_AGeoSunMin07.Text);
            pRegXX.oRegGeoAll.AGeoSunMin08 = Convert.ToDouble(scnXX_AGeoSunMin08.Text);
            pRegXX.oRegGeoAll.AGeoSunMin09 = Convert.ToDouble(scnXX_AGeoSunMin09.Text);
            pRegXX.oRegGeoAll.AGeoSunMin10 = Convert.ToDouble(scnXX_AGeoSunMin10.Text);
            pRegXX.oRegGeoAll.AGeoSunMin11 = Convert.ToDouble(scnXX_AGeoSunMin11.Text);
            pRegXX.oRegGeoAll.AGeoSunMin12 = Convert.ToDouble(scnXX_AGeoSunMin12.Text);

            pRegXX.oRegGeoAll.AGeoTmpMax01 = Convert.ToInt32(scnXX_AGeoTmpMax01.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax02 = Convert.ToInt32(scnXX_AGeoTmpMax02.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax03 = Convert.ToInt32(scnXX_AGeoTmpMax03.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax04 = Convert.ToInt32(scnXX_AGeoTmpMax04.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax05 = Convert.ToInt32(scnXX_AGeoTmpMax05.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax06 = Convert.ToInt32(scnXX_AGeoTmpMax06.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax07 = Convert.ToInt32(scnXX_AGeoTmpMax07.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax08 = Convert.ToInt32(scnXX_AGeoTmpMax08.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax09 = Convert.ToInt32(scnXX_AGeoTmpMax09.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax10 = Convert.ToInt32(scnXX_AGeoTmpMax10.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax11 = Convert.ToInt32(scnXX_AGeoTmpMax11.Text);
            pRegXX.oRegGeoAll.AGeoTmpMax12 = Convert.ToInt32(scnXX_AGeoTmpMax12.Text);
            //pRegXX.oRegGeoAll.AGeoTmpMaxYear= Convert.ToInt32(scnXX_AGeoTmpMaxYear.Text);

            pRegXX.oRegGeoAll.AGeoTmpAvg01 = Convert.ToInt32(scnXX_AGeoTmpAvg01.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg02 = Convert.ToInt32(scnXX_AGeoTmpAvg02.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg03 = Convert.ToInt32(scnXX_AGeoTmpAvg03.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg04 = Convert.ToInt32(scnXX_AGeoTmpAvg04.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg05 = Convert.ToInt32(scnXX_AGeoTmpAvg05.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg06 = Convert.ToInt32(scnXX_AGeoTmpAvg06.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg07 = Convert.ToInt32(scnXX_AGeoTmpAvg07.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg08 = Convert.ToInt32(scnXX_AGeoTmpAvg08.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg09 = Convert.ToInt32(scnXX_AGeoTmpAvg09.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg10 = Convert.ToInt32(scnXX_AGeoTmpAvg10.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg11 = Convert.ToInt32(scnXX_AGeoTmpAvg11.Text);
            pRegXX.oRegGeoAll.AGeoTmpAvg12 = Convert.ToInt32(scnXX_AGeoTmpAvg12.Text);
            //pRegXX.oRegGeoAll.AGeoTmpAvgYear= scnXX_AGeoTmpAvgYear.Text);

            pRegXX.oRegGeoAll.AGeoTmpMin01 = Convert.ToInt32(scnXX_AGeoTmpMin01.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin02 = Convert.ToInt32(scnXX_AGeoTmpMin02.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin03 = Convert.ToInt32(scnXX_AGeoTmpMin03.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin04 = Convert.ToInt32(scnXX_AGeoTmpMin04.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin05 = Convert.ToInt32(scnXX_AGeoTmpMin05.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin06 = Convert.ToInt32(scnXX_AGeoTmpMin06.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin07 = Convert.ToInt32(scnXX_AGeoTmpMin07.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin08 = Convert.ToInt32(scnXX_AGeoTmpMin08.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin09 = Convert.ToInt32(scnXX_AGeoTmpMin09.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin10 = Convert.ToInt32(scnXX_AGeoTmpMin10.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin11 = Convert.ToInt32(scnXX_AGeoTmpMin11.Text);
            pRegXX.oRegGeoAll.AGeoTmpMin12 = Convert.ToInt32(scnXX_AGeoTmpMin12.Text);
            //pRegXX.oRegGeoAll.AGeoTmpMinYear= Convert.ToInt32(scnXX_AGeoTmpMinYear.Text);

            pRegXX.oRegGeoAll.AGeoClimateTableUrlTitle = scnXX_AGeoClimateTableUrlTit.Text;
            pRegXX.oRegGeoAll.AGeoClimateTableUrl = scnXX_AGeoClimateTableUrlUrl.Text;
            //------------------------------------------
            // IMAGENES
            //----------------------------------------------------------------------
            pRegXX.oRegTaxaAllFile.AAbsImg_HNatural = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AAbsImg_Range = scnXX_AAbsImg_Range.ImageUrl;
            pRegXX.oRegTaxaAllFile.AAbsImg_Specie = scnXX_AAbsImg_Specie.ImageUrl;

            scnXX_ADngLevelCites.SelectedValue = pRegXX.oRegNatuAll.ANatDngLevelCites;
            cls.ClsUtils.FncDropDownRedList(ref scnXX_ADngLevelRedList, ref scnXX_ADngLevelRedListImg, "es", pRegXX.oRegNatuAll.ANatDngLevelRedList);


            pRegXX.oRegTaxaAllFile.ACareImg_Breeding01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_Breeding02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_Breeding03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_Food01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_Food02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_Food03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_gral01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_gral02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_gral03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumIndoor03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ACareImg_VivariumOutdoor03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyDorsal03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BabyVentral03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyBridge03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyDorsal03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyFrontal03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyLateral03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyRear01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyRear02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyRear03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_BodyVentral03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_DesType01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_DesType02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_DesType03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Diferentiation03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Dimorphism03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Holotype01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Holotype02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_Holotype03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherHead01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherHead02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherHead03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherLegs03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherTail01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherTail02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ADesImg_OtherTail03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_ClimateEcozoneKey = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherBiome = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherRain = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherSun = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_ClimateWheatherTemp = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardDetailFul = scnXX_AAbsImg_HNatural.ImageUrl;

            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardKoppenFul = scnXX_AAbsImg_HNatural.ImageUrl;

            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFul = scnXX_AAbsImg_HNatural.ImageUrl;

            pRegXX.oRegTaxaAllFile.AGeoImg_landscapes01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_landscapes02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_landscapes03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Breeding01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Breeding02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Breeding03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Food01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Food02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Food03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Live01 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Live02 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Live03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Live03 = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.ANatImg_Live01 = scnXX_AAbsImg_HNatural.ImageUrl;



            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardWorldFul = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardKoppenFul = scnXX_AAbsImg_HNatural.ImageUrl;
            pRegXX.oRegTaxaAllFile.AGeoImg_GeoRangeMapStandardDetailFul = scnXX_AAbsImg_HNatural.ImageUrl;

            // scn_oDdoc_edit.DocTypeGroup = scnFilterArticleType.SelectedValue;
            // scn_oDdoc_edit.DocTypeGroupSub = scnFilterArticleTypeSub.SelectedValue;

            return true;
        }



        private bool FncScreenValidateEN()
        {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;
            String szError = "";
            scnMsgBox.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
            return bOk;
        }
        private bool FncScreenValidateES()
        {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;
            String szError = "";
            scnMsgBox.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
            return bOk;
        }
        private bool FncScreenValidateXX()
        {

            // limpiar errores validacion anterior, quitar blancos
            bool bOk = true;

            String szError = "";

            if (scnATaxGrpL0001lNameFullRecomeded_XX.Text.Length < 10)
            {
                szError += "Title, name recomended lenght lesthan 10<br/>";
                bOk = false;
            }
            if (bOk)
            {
                scnMsgBox.Text = "";
                scnMsgBox.Visible = false;
            }
            else
            {
                scnMsgBox.Text = cls.ClsHtml.FncMsgAlert(szError, cls.ClsGlobal.E_MsgType.alert.ToString());
                scnMsgBox.Visible = true;
            }
            return bOk;
        }
        protected void scnADngLevelRedList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UInt64 szRL_levelID = Convert.ToUInt64(scnXX_ADngLevelRedList.SelectedValue);

            cls.bbdd.ClsReg_tmst_iucn_redlist oRegIucn = new testudines.cls.bbdd.ClsReg_tmst_iucn_redlist();
            oRegIucn.FncSqlFind(szRL_levelID, "es");

            scnXX_ADngLevelRedListImg.ImageUrl = oRegIucn.UrlImg;
        }
        protected void scnEcozoneListCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FncGetscnAGeo_ClimateEcozoneKeyImg();
            //    scnAbsEcozone.Text = "<b>" + oRegEco.Title + ":</b>" + oRegEco.Abstract;

        }
        private void FncGetscnAGeo_ClimateEcozoneKeyImg()
        {
            cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
            oRegEco.FncSqlFindListCode(scnXX_AGeoKeyClimateEcozone.SelectedValue, "es");
            scnXX_AGeoImg_ClimateEcozoneKey.ImageUrl = oRegEco.ImgRainTemp;
        }
        protected void scnBtnsEcozoneListCodeOverWrite_Click(object sender, EventArgs e)
        {
            cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers oRegEco = new testudines.cls.bbdd.ClsReg_tdoclng_geoclimate_koppengeigers();
            oRegEco.FncSqlFindListCode(scnXX_AGeoKeyClimateEcozone.SelectedValue, "es");
            scnES_LAbsHabClimateEcozone.Text = "<b>" + oRegEco.Title + ":</b>" + oRegEco.Abstract;
            scnXX_AGeoImg_ClimateEcozoneKey.ImageUrl = oRegEco.ImgRainTemp;

        }




        protected void scnBtnBuildPdf_Click(object sender, EventArgs e)
        {
            cls.pdf.ClsPDFTaxon oPDF = new cls.pdf.ClsPDFTaxon();
            UInt64 id = Convert.ToUInt64(scnDocId.Text);
            oPDF.Fnc_01_01_Doc_Create(id ,"es","en","es-ES","en-EN");

            scnXX_DocPdfUrl.Text = oPDF.Pdf_URLShort;
            scnXX_DocPdfVersion.Text = oPDF.Doc_PdfVersion;
            scnXX_DocPdfTitle.Text = oPDF.Doc_Meta_Title;
            scnXX_PdfMsg.Text =  oPDF.Msg;

            scnXX_DocPdfUrlEmbebed.Text = cls.ClsUtils.Fnc_BldHtmPdf(scnXX_DocPdfUrl.Text);
            if (scnXX_DocPdfUrlEmbebed.Text == "")
            {
                scnXX_DocPdfUrl.Text += " [No exist]";
            }
            else
            {
                oRegES.oRegDoc.DocPdfTitle = scnXX_DocPdfTitle.Text;
                oRegES.oRegDoc.DocPdfUrl = scnXX_DocPdfUrl.Text;
                oRegES.oRegDoc.DocPdfVersion = Convert.ToUInt32(scnXX_DocPdfVersion.Text);


            }




           


           

            

        }
      


    }
}