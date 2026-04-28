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
using log4net;

public partial class _Default : System.Web.UI.Page
{
    protected string m_DomUser;
    private static readonly ILog log = LogManager.GetLogger(typeof(_Default));

    protected void Page_Load(object sender, EventArgs e)
    {

        bool internalError = false;
        if (!Page.IsPostBack)
        {
            log.InfoFormat("Se valida si el usuario tiene acceso a Phalanx Web", m_DomUser);

            m_DomUser = HttpContext.Current.User.Identity.Name;
            log.InfoFormat("Se obtiene el usuario autenticado '{0}'", m_DomUser);

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
                log.InfoFormat("Se validan los permisos del usuario");

                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntity IdentUser = PhxUsrBL.GetUserByDomUsr(m_DomUser);

                log.InfoFormat("Se obtuvieron los permisos del usuario");

                if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && IdentUser.Active)
                {
                    log.InfoFormat("Acceso permitido");

                    Session["PhxUser"] = IdentUser;
                    Session["phxUserID"] = IdentUser.Id;
                    Session["phxUserName"] = IdentUser.Username;
                    Session["phxUserFullName"] = IdentUser.Fullname;
                }
                else
                {
                    log.InfoFormat("EL usuario no tiene permisos para acceder");

                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException)
                    {
                    }

                }

                if (IdentUser != null)
                {
                    log.InfoFormat("Se controla si el usuario puede solicitar contraseñas");

                    // si no tiene permisos para solicitar contraseñas oculta el acceso
                    //bool NotPwdRqstRole = false;
                    if (!PhxUsrBL.ChkPwdsRequest(IdentUser))
                    {
                        this.tbMenu.Rows[0].Visible = false;
                        this.tbMenu.Rows[2].Visible = false;
                        this.tbMenu.Rows[3].Visible = false;
                        //NotPwdRqstRole = true;
                    }

                    log.InfoFormat("Se controla si el usuario puede autorizar solicitudes");
                    
                    // si no tiene permisos para autorizar pedidos
                    if (!PhxUsrBL.ChkAuthPwdRequest(IdentUser))
                    {
                        this.tbMenu.Rows[1].Visible = false;
                        this.tbMenu.Rows[4].Visible = false;
                        this.tbMenu.Rows[5].Visible = false;
                    }
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
