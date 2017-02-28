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

public partial class closepwd1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (!(IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && PhxUsrBL.ChkAuthPwdRequest(IdentUser)))
            {
                try
                {
                    Response.Redirect("noAutho.aspx");
                }
                catch (ThreadAbortException)
                {
                }
            }
            if (!internalError)
            {
                Session["CtrlTitle"] = "Cierre de Solicitudes de Contraseñas";
                Session["CtrlUser"] = "Usuario: " + Session["phxWinUser"];
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("default.aspx");
        }
        catch (ThreadAbortException)
        {
        }

    }

    protected void gvCloseRequests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string imageUrl = string.Empty;
            Image TempImage;
            string tempString = string.Empty;
            string strToolTip = string.Empty;
            TempImage = (Image)e.Row.FindControl("imgTemp");

            PasswordRequestEntity pwdRequest = (PasswordRequestEntity)e.Row.DataItem;
            if (pwdRequest != null)
            {
                if (pwdRequest.RqstUser != null)
                {
                    //e.Row.Cells[2].Text = pwdRequest.ReturnUser.Username;
                    e.Row.Cells[2].Text = pwdRequest.RqstUser.Fullname;
                    e.Row.Cells[3].Text = pwdRequest.RequestDate.ToString("dd/MM/yyyy HH:mm:ss");

                }

                if (pwdRequest.ReturnDate != null)
                    e.Row.Cells[4].Text = ((DateTime)pwdRequest.ReturnDate).ToString("dd/MM/yyyy HH:mm:ss");

                e.Row.Cells[5].Text = pwdRequest.State;
                
                if (pwdRequest.User is WinLocalUserEntity)
                {
                    e.Row.Cells[1].Text = "Dominio: " + ((WinLocalUserEntity)pwdRequest.User).Domain + " - Server: " + ((WinLocalUserEntity)pwdRequest.User).WinPc.Name + " - Ususario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de Windows";
                }

                if (pwdRequest.User is ApplicationUserEntity)
                {
                    e.Row.Cells[1].Text = "Aplicación: " + ((ApplicationUserEntity)pwdRequest.User).ApplicationName + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de Aplicativo";
                }

                if (pwdRequest.User is DatabaseUserEntity)
                {
                    e.Row.Cells[1].Text = "Base de datos: " + ((DatabaseUserEntity)pwdRequest.User).DBName + " - Tipo: " + ((DatabaseUserEntity)pwdRequest.User).Db.Type.Name + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de Base de Datos";
                }

                if (pwdRequest.User is UnixUserEntity)
                {
                    e.Row.Cells[1].Text = "Servidor: " + ((UnixUserEntity)pwdRequest.User).Server_Name + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de Unix-Linux";
                }
                if (pwdRequest.User is AS400UserEntity)
                {
                    e.Row.Cells[1].Text = "Servidor: " + ((AS400UserEntity)pwdRequest.User).Server_Name + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de AS400";
                }
                if (pwdRequest.User is ATMUserEntity)
                {
                    e.Row.Cells[1].Text = "ATM: " + ((ATMUserEntity)pwdRequest.User).ATMName + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de ATM";
                }

                if (pwdRequest.User is CommunicationDeviceUserEntity)
                {
                    CommunicationDeviceUserEntity usuario = pwdRequest.User as CommunicationDeviceUserEntity;
                  
                    e.Row.Cells[1].Text = "Equipo: " + usuario.CommunicationDeviceName + " - Tipo: " + usuario.CommunicationDeviceType + " - Usuario: " + pwdRequest.User.Username;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Contraseña de Base de Datos";
                }
            }
            TempImage.ImageUrl = imageUrl;
            TempImage.ToolTip = strToolTip;
        }
    }
}