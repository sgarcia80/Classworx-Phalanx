using PhalanxBL;
using PhalanxCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhalanxWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected string m_DomUser;
        protected void Page_Load(object sender, EventArgs e)
        {

            bool internalError = false;
            if (!Page.IsPostBack)
            {
                m_DomUser = HttpContext.Current.User.Identity.Name;
                //m_DomUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

                if (Page.Request["testing_user"] != null)
                    m_DomUser = Page.Request["testing_user"];

                Session.Clear();
                Session["phxMessage"] = "";
                Session["phxMsgError"] = 0;
                Session["phxButtonBack"] = "";
                Session["phxWinUser"] = m_DomUser;

                //Session["phxWinUser"];

                if (m_DomUser == string.Empty)
                {
                    m_DomUser = "Usuario no Identificado, comuniquese con el Administrador de Phalanx Security Manager";
                    Session.Abandon();
                }
                else
                {
                    PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                    PhxUserEntity IdentUser = PhxUsrBL.GetUserByDomUsr(m_DomUser);
                    if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && IdentUser.Active)
                    {
                        Session["PhxUser"] = IdentUser;
                        Session["phxUserID"] = IdentUser.Id;
                        Session["phxUserName"] = IdentUser.Username;
                        Session["phxUserFullName"] = IdentUser.Fullname;
                    }
                    else
                    {
                        try
                        {
                            Response.Redirect("noAutho.aspx");
                        }
                        catch (ThreadAbortException)
                        {
                        }

                    }
                    // si no tiene permisos para solicitar contraseñas oculta el acceso
                    //bool NotPwdRqstRole = false;
                    if (!PhxUsrBL.ChkPwdsRequest(IdentUser))
                    {
                        this.tbMenu.Rows[0].Visible = false;
                        this.tbMenu.Rows[2].Visible = false;
                        this.tbMenu.Rows[3].Visible = false;
                        //NotPwdRqstRole = true;
                    }
                    // si no tiene permisos para autorizar pedidos
                    if (!PhxUsrBL.ChkAuthPwdRequest(IdentUser))
                    {
                        this.tbMenu.Rows[1].Visible = false;
                        this.tbMenu.Rows[4].Visible = false;
                        this.tbMenu.Rows[5].Visible = false;
                    }
                }
            }
            if (!internalError)
            {
                //Session["CtrlTitle"] = "Menu Principal";
                Session["CtrlTitle"] = "";
                Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];
            }
        }
        protected void LBConsContras_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("reqpwd.aspx");
            }
            catch (ThreadAbortException)
            {
            }

        }
        protected void LBAutforme_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("authforme.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
        protected void LBAutPedidos_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("authorization.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
        protected void lblGetPwdBack_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("requestViewer.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
        protected void lblClosePwd_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("closepwd.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
        protected void lnkSolicExp_Click(object sender, System.EventArgs e)
        {
            try
            {
                Response.Redirect("exppwdrqst.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
    }
}