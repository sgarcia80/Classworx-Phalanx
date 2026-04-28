using PhalanxBL;
using PhalanxCommon.Entities;
using System;
using System.Threading;
using System.Web.UI;

namespace PhalanxWeb
{
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool internalError = false;
            if (!Page.IsPostBack)
            {
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
                // chequea que tenga rol para usar la app web
                if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser))
                {
                }
                else
                {
                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                    }

                }
                if (!internalError)
                {
                    Session["CtrlTitle"] = "Mensaje";
                    Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];

                    if (Session["phxMsgError"] != null)
                        if ((int)Session["phxMsgError"] == 1)
                            LabelMsg.CssClass = "LabelInError";

                    if (Session["phxMessage"] != null)
                        LabelMsg.Text = (string)Session["phxMessage"];

                    GoPage.Text = "default.aspx";
                    if (Session["phxButtonBack"] != null)
                        GoPage.Text = (string)Session["phxButtonBack"];

                }

            }
        }

        protected void Bcancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(GoPage.Text);
            }
            catch (ThreadAbortException tae)
            {
            }


        }
    }
}