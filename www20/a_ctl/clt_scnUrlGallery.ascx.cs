using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_ctl
{
    public partial class clt_scnUrlGallery : System.Web.UI.UserControl
    {
       
        private string m_IdParents = "";
    
        //private string m_IdParents_default = "ctl00_phcontent_tbContainer_sncPnlAbs_scnAAbsDesImg_scnidimgurl_";
        private string m_IdParents_defaul2 = "cphContent_tbContainer_scnTabDng_"; //"cphContent_tbContainer_scnTabDng_scnAGallery2_";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
//id="cphContent_tbContainer_scnTabDng_scnAGallery2_scnIDImgBtnOpen"
//id="cphContent_tbContainer_scnTabDng_scnAGallery2_scnIDImgBtnClear" 
//id="cphContent_tbContainer_scnTabDng_scnAGallery2_scnAGalleryTxt"

                //string szEmpty = "";
                if (m_IdParents == "") m_IdParents = m_IdParents_defaul2;
                m_IdParents = m_IdParents.Replace("ctl00_", "");
                string szControlId = m_IdParents + this.ID + "_scnAGalleryTxt";
             
               // scnLinkGallery.Value = scnidimg.ImageUrl;
             //   scnIDImgBtnOpen.Attributes.Add("onclick", "return jsOpenChildGallery('" + szControlId + "scnidimg" + "','" + szControlId + "scnidimgurl')");
                scnIDImgBtnOpen.Attributes.Add("onclick", "return jsOpenChildGallery('"+szControlId+"')");

                scnIDImgBtnClear.Attributes.Add("onclick", "return jsOpenChildGalleryClear('" + szControlId + "scnidimg" + "','" + szControlId + "scnidimgurl', '')");
          
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }
        public string LinkGalleryTxt
        {
            get { return scnAGalleryTxt.Text.Trim().ToLower(); }
            set { scnAGalleryTxt.Text = value.Trim().ToLower(); }
        }
        /// <summary>
        /// Chapuza para poder referir el javascript
        /// al objeto adecuado, dado que el caso
        /// de estar contenido en otros, como masterpages
        /// tabs, etc, el punto Net añade sus nombres seguidos
        /// de guiones bajos como prefijo del id del objeto
        /// </summary>
        public string ID_Parents
        {
            get { return m_IdParents; }
            set { m_IdParents = value; }
        }
        public string LinkGalleryTitle
        {
            get { return scnLinkGalleryTit.Text; }
            set { scnLinkGalleryTit.Text = value; }
        }
        public string Text
        {
            get { return scnAGalleryTxt.Text.Trim().ToLower(); }
            set { scnAGalleryTxt.Text = value; }
        }
        private string  scnLinkGalleryTxt_Width
        {
            set {

                scnAGalleryTxt.Width = new System.Web.UI.WebControls.Unit(value); ;
            }
        }

        protected void scnIDImgBtnClear_Click(object sender, EventArgs e)
        {
            scnAGalleryTxt.Text = ""; 
        }
           }
}