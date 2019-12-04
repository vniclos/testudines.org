using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_test
{
    public partial class fancybox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FncFillGallery();
        }
        private void FncFillGallery()
        {
            String pImg1 ="img/img_001_Min.jpg";
            String pImg2 ="img/img_002_Min.jpg";
            String pImg3 ="img/img_003_Min.jpg";
            String pImg4 = "img/img_004_Min.jpg";
            String pImg5 = "img/img_005_Min.jpg";
            String pImg6 = "img/img_006_Min.jpg";
            String pCaption = "test 1";
            String pGroup = "group2";
            String pAlt = "tortoise";
            scnGallery3.Text= cls.tools.ClsGalleryFBox.FncHtm_ImgGroup_thuAdd_3(ref pImg1, ref pImg2, ref pImg3, ref pCaption,ref pAlt, ref pGroup);
            scnGallery3.Text = cls.tools.ClsGalleryFBox.FncHtm_ImgGroup_thuAdd_6(ref pImg1, ref pImg2, ref pImg3, ref pImg4, ref pImg5, ref pImg6, ref pCaption, ref pAlt, ref pGroup);
        }
    }
}