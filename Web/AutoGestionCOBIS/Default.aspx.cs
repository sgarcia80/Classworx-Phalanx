using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LBConsContras_Click(object sender, System.EventArgs e)
    {
        try
        {
            Response.Redirect("COBISOffline.aspx");
        }
        catch (ThreadAbortException)
        {
        }

    }
    protected void LBAutPedidos_Click(object sender, System.EventArgs e)
    {
        try
        {
            Response.Redirect("COBISOffline.aspx");
        }
        catch (ThreadAbortException)
        {
        }

    }

}