using PhalanxBL;
using System;

namespace PhalanxWeb
{
    public partial class expnow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordRequestBusiness PRBL = new PasswordRequestBusiness();
            PRBL.ProcessPwdRqstExpiration();
        }
    }
}