using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testudines.cls;
namespace testudines.a_cls.pdf
{
    public partial class pdf_bld_tortoise : System.Web.UI.Page
    {
        cls.bbdd.ClsReg_tdoclng_testudines_all oReg = new cls.bbdd.ClsReg_tdoclng_testudines_all();
      
       
        protected void Page_Load(object sender, EventArgs e)
        {
         

        }
      
        

        protected void scnBtnBuildPdf_Click(object sender, EventArgs e)
        {
            cls.pdf.ClsPDFTaxon oPDF = new cls.pdf.ClsPDFTaxon();
           
            oPDF.Fnc_01_01_Doc_Create(Convert.ToUInt64(scnSpecieId.Text),"es","en", "es-ES","en-En");
           
            // FncDebug(ref oPDF);



            scnMsg.Text = "done" + oPDF.Msg;

            scnPdfEmbed.Text = oPDF.Pdf_HtmlShow;
           // FncPdfShow(oPDF.Pdf_FileNameShort);

        }
        private void FncDebug(ref cls.pdf.ClsPDFTaxon oPDF)
        {


        }


    }
}
