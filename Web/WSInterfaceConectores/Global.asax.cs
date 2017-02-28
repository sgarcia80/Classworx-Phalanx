using System;

namespace WSInterfaceConectores
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            PhalanxDAL.DBMgr.Application = PhalanxCommon.Entities.App.Phalanx;
            //PhalanxDAL.DBMgr.NHAssembly = System.Reflection.Assembly.Load("NDCDAL");
            PhalanxDAL.DBMgr.Inicializar();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}