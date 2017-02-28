using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhalanxWeb
{
    public partial class noAutho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Bcancel_Click(object sender, EventArgs e)
        {
            //Server.Transfer("default.aspx");	
            ClientScript.RegisterClientScriptBlock(typeof(noAutho), "myclose", "<script language='JavaScript'>window.close();</script>");
        }
    }
}