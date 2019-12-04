using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_ctl
{
    public partial class ctl_imgfld : System.Web.UI.UserControl
    {
        private string m_szNoImageUrl = "/a_img/noimage1024px.png";
        private string m_szImageUrl = "";
        private string m_IdParents = "";
        private string m_MaxWidthDefault = "650px";
        private string m_MaxWidth = "";
        private string m_MaxHeight = "";
        private string m_MaxHeightDefault = "";
        private string m_width = "";
        private string m_scnidimg = "";
        private string m_scnidimg_txt = "";
        //private string m_IdParents_default = "ctl00_phcontent_tbContainer_sncPnlAbs_scnAAbsDesImg_scnidimgurl_";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (scnidimgurl.Value == "")
            {
                scnidimg.ImageUrl = m_szNoImageUrl;
                scnidimgurl.Value = m_szNoImageUrl;

            }
            if (m_width != "")
            {
                scnidimg.Width = Unit.Parse(m_width);
                ImageMax_Width = "100%";
                ImageMax_Height = "100%";
            }
            m_scnidimg = this.ID + "_img";
            m_scnidimg_txt = this.ID + "_imgurl";
            scnidimg.ID = m_scnidimg;
            scnidimgurl.ID = m_scnidimg_txt;



            scnidimgurl.Value = scnidimg.ImageUrl;

            //string sztest = "cphContent_tbContainer_scnATabDescription_scnAAbsDesImg_scnidimgurl";
            //scnAUrlImagesTxt= control que contiene 
            scnIDImgBtnOpen.Attributes.Add("onclick", "return jsOpenDlgBrowserFld('" + this.ID + "', '','" + this.Width + "')");
            scnIDImgBtnOpenTaxon.Attributes.Add("onclick", "return jsOpenDlgBrowserFld('" + this.ID + "', 'scnAUrlImagesTxt','" + this.Width + "')");


            scnIDImgBtnClear.Attributes.Add("onclick", "return jsOpenDlgClearImg('" + this.ID + "scnidimg" + "','" + m_szNoImageUrl + "')");


        }
        public string ImageMax_Height
        {
            set
            {
                if (scnidimg.Style["max-height"] != null)
                {
                    // si vacio valor por defecto
                    if (value == "") value = m_MaxHeightDefault;
                    scnidimg.Style["max-height"] = value;
                }
                else
                {
                    try
                    {
                        scnidimg.Style.Add("max-height", value);
                    }
                    catch
                    {
                    }
                }
            }
            get
            {
                try
                {
                    return scnidimg.Style["max-height"].ToString();
                }
                catch { return ""; }
            }
        }
        public string ImageMax_Width
        {
            set
            {
                if (scnidimg.Style["max-width"] != null)
                {
                    // si vacio valor por defecto
                    if (value == "") value = m_MaxWidthDefault;
                    scnidimg.Style["max-width"] = value;
                }
                else
                {
                    try
                    {
                        scnidimg.Style.Add("max-width", value);
                    }
                    catch
                    {
                    }
                }
            }
            get
            {
                try
                {
                    return scnidimg.Style["max-width"].ToString();
                }
                catch { return ""; }
            }
        }
        public string ImageNoImageUrl
        {
            set { m_szNoImageUrl = value; }
            get { return m_szNoImageUrl; }
        }
        public string ImageUrl
        {
            set
            {
                if (value == "")
                {
                    value = m_szNoImageUrl;
                }
                m_szImageUrl = value;
                scnidimg.ImageUrl = value;
                scnidimgurl.Value = value;
            }
            get
            {
                scnidimg.ImageUrl = scnidimgurl.Value;
                return scnidimgurl.Value;


            }

        }

        public string Width
        {
            get { return m_width; }
            set
            {
                m_width = value;
                scnidimg.Width = Unit.Parse(m_width);

            }
        }
        public string CssClass_img
        {
            set { scnidimg.CssClass = value; }
            get {

                return scnidimg.CssClass;
            }
        }
        public string ID_img
        {
            get { return scnidimg.ID; }
            set {
                m_scnidimg = value;
                m_scnidimg_txt = value + "_txt";
                scnidimg.ID = m_scnidimg;
                scnidimgurl.ID = m_scnidimg_txt;




            }
        }
       
    }
}