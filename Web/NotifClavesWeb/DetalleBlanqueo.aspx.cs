using System;
using System.Web.Security;

namespace NotifClavesWeb
{
    public partial class DetalleBlanqueo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}