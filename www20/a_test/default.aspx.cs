﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testudines.a_test
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void scnTest1_btn_Click(object sender, EventArgs e)
        {
            scnTest1_Txt.Text = "clicked button";
        }
    }
}