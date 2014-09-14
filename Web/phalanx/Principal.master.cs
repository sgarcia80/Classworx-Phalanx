using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using PhalanxBL;
using PhalanxCommon.Entities;
using System.Threading;

public partial class Principal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            LabelTitle.Text = (string)Session["CtrlTitle"];
            LabelUser.Text = (string)Session["CtrlUser"];
            PhxContingenciaBusiness phxContB = new PhxContingenciaBusiness();
            if (!phxContB.VerificaSiConexionUsadaEstaActiva())
            {
                Response.Redirect("OutOfService.aspx");
            }
        }
        catch
        {
            Response.Redirect("OutOfService.aspx");
        }

    }
}
