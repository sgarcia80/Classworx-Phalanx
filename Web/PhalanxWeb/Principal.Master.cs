using PhalanxBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhalanxWeb
{
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
}