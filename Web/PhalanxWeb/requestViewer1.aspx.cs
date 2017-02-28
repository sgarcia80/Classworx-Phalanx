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
using PhalanxCommon.Entities;
using PhalanxBL;
using System.Threading;

public partial class tempRequestViewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (IdentUser != null && PhxUsrBL.ChkPwdsRequest(IdentUser))
            {
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
            if (!internalError)
            {
                Session["CtrlTitle"] = "Devolución de Contraseñas";
                Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];
            }

        }
    }
    protected void gvRequestedWinPwd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string imageUrl = string.Empty;
            //Image TempImage;
            string tempString = string.Empty;
            string strToolTip = string.Empty;

            //TempImage = (Image)e.Row.FindControl("imgTemp");

            PasswordRequestEntity pwdRequest = (PasswordRequestEntity)e.Row.DataItem;
            if (pwdRequest != null)
            {
                //e.Row.Cells[6].Text = pwdRequest.State;
                //e.Row.Cells[7].Text = pwdRequest.RqstUsrFullName;

                if (pwdRequest.User is WinLocalUserEntity)
                {
                    WinLocalUserEntity winUsr = (WinLocalUserEntity)pwdRequest.User;
                    // Dominio
                    e.Row.Cells[0].Text = winUsr.WinPc.WinDomain.NtName;
                    // Server
                    e.Row.Cells[1].Text = winUsr.WinPc.Name;
                    // Usuario
                    e.Row.Cells[2].Text = winUsr.Username;
                    // Fecha Solicitud
                    e.Row.Cells[3].Text = pwdRequest.RqstDateddmmyyyy;
                    // Estado
                    e.Row.Cells[4].Text = pwdRequest.State;
                    //((HyperLink)e.Row.Controls[8].Controls[0]).NavigateUrl = "~/authwinpassword.aspx?prid=" + pwdRequest.Id;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Windows";
                }
                /*
                if (pwdRequest.User is ApplicationUserEntity)
                {
                    ApplicationUserEntity appUsr = (ApplicationUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = appUsr.Application.Name;
                    e.Row.Cells[2].Text = appUsr.Application.Desc;
                    tempString = (appUsr.Application.Field1Desc != string.Empty
                        ? appUsr.Application.Field1Desc + ": " + appUsr.Field1Value : string.Empty);
                    tempString += (appUsr.Application.Field2Desc != string.Empty
                        ? " " + appUsr.Application.Field2Desc + ": " + appUsr.Field2Value : string.Empty);
                    tempString += (appUsr.Application.Field3Desc != string.Empty
                        ? " " + appUsr.Application.Field3Desc + ": " + appUsr.Field3Value : string.Empty);

                    e.Row.Cells[3].Text = tempString;
                    ((HyperLink)e.Row.Controls[8].Controls[0]).NavigateUrl = "~/authapppassword.aspx?prid=" + pwdRequest.Id;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Aplicativos";
                }
                
                if (pwdRequest.User is DatabaseUserEntity)
                {
                    DatabaseUserEntity dbUsr = (DatabaseUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = dbUsr.Db.Name;
                    e.Row.Cells[2].Text = dbUsr.Db.Desc;
                    tempString = "Tipo: " + dbUsr.Db.Type.Name;
                    tempString += " Servidor: " + dbUsr.Db.ServerName;

                    e.Row.Cells[3].Text = tempString;
                    ((HyperLink)e.Row.Controls[8].Controls[0]).NavigateUrl = "~/authdbpassword.aspx?prid=" + pwdRequest.Id;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Base de Datos";
                }

                if (pwdRequest.User is UnixUserEntity)
                {
                    UnixUserEntity unixUsr = (UnixUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = unixUsr.Unix.ServerName;
                    e.Row.Cells[2].Text = unixUsr.Unix.Desc;
                    e.Row.Cells[3].Text = "Dirección IP: " + unixUsr.Unix.Ip;
                    ((HyperLink)e.Row.Controls[8].Controls[0]).NavigateUrl = "~/authunixpassword.aspx?prid=" + pwdRequest.Id;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Unix-Linux";
                }
                
            }
            else
            {
                string users = "";
                e.Row.Cells[0].ToolTip = pwdRequest.UserPassword.PwdLockType.Desc;
                if (pwdRequest.UserPassword.PwdLockType.Code == "BEING_USED")
                {
                    foreach (object tmpObj in pwdRequest.UserPassword.PwdLockType.UsersPasswordsList)
                    {
                        users += tmpObj.ToString() + "\n";
                    }

                    if (pwdRequest.UserPassword.Concurrent)
                        imageUrl = "~/image/pwd_in_use.gif";
                    else
                        imageUrl = "~/image/pwd_in_use_concurrent.gif";
                }
                else
                {
                    imageUrl = "~/image/pwd_locked.gif";
                }

                e.Row.Cells[4].ToolTip = pwdRequest.UserPassword.PwdLockType.Desc + "\n" + users;
                e.Row.Cells[4].Enabled = false;
                 * * */ 
            }
            //TempImage.ImageUrl = imageUrl;
            //TempImage.ToolTip = strToolTip;
           
        }
    }
    protected void gvSolicitudes_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[4].Text = pwdRequest.RqstUsrFullName;
                e.Row.Cells[5].Text = ((DateTime)pwdRequest.RequestDate).ToString("dd/MM/yyyy HH:mm:ss");
                if ( pwdRequest.ExpirationDate != null )
                e.Row.Cells[6].Text = ((DateTime) pwdRequest.ExpirationDate).ToString("dd/MM/yyyy HH:mm:ss");
                
                e.Row.Cells[7].Text = pwdRequest.State;
                
                if (pwdRequest.User is WinLocalUserEntity)
                {
                    WinLocalUserEntity winUsr = (WinLocalUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = winUsr.WinPc.Name;
                    e.Row.Cells[2].Text = winUsr.Domain;
                    e.Row.Cells[3].Text = winUsr.WinPc.PcIP;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Windows";
                }
                
                if (pwdRequest.User is ApplicationUserEntity)
                {
                    ApplicationUserEntity appUsr = (ApplicationUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = appUsr.Application.Name;
                    e.Row.Cells[2].Text = appUsr.Application.Desc;
                    tempString = (appUsr.Application.Field1Desc != string.Empty
                        ? appUsr.Application.Field1Desc : string.Empty);
                    tempString += (appUsr.Application.Field2Desc != string.Empty
                        ? " " + appUsr.Application.Field2Desc : string.Empty);
                    tempString += (appUsr.Application.Field3Desc != string.Empty
                        ? " " + appUsr.Application.Field3Desc : string.Empty);

                    e.Row.Cells[3].Text = tempString;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Aplicativos";
                }
                
                if (pwdRequest.User is DatabaseUserEntity)
                {
                    DatabaseUserEntity dbUsr = (DatabaseUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = dbUsr.Db.Name;
                    e.Row.Cells[2].Text = dbUsr.Db.Desc;
                    tempString = "Tipo: " + dbUsr.Db.Type.Name;
                    tempString += " Servidor: " + dbUsr.Db.PCName;
                    //tempString += " Servidor: " + dbUsr.Db.ServerName;

                    e.Row.Cells[3].Text = tempString;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Base de Datos";
                }

                if (pwdRequest.User is UnixUserEntity)
                {
                    UnixUserEntity unixUsr = (UnixUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = unixUsr.Unix.ServerName;
                    e.Row.Cells[2].Text = unixUsr.Unix.Desc;
                    e.Row.Cells[3].Text = "Dirección IP: " + unixUsr.Unix.Ip;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario Unix-Linux";
                }
                if (pwdRequest.User is AS400UserEntity)
                {
                    AS400UserEntity AS400Usr = (AS400UserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = AS400Usr.AS400.ServerName;
                    e.Row.Cells[2].Text = AS400Usr.AS400.Desc;
                    e.Row.Cells[3].Text = "Dirección IP: " + AS400Usr.AS400.Ip;
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario AS400";
                }

                if (pwdRequest.User is CommunicationDeviceUserEntity)
                {
                    CommunicationDeviceUserEntity cdUsr = (CommunicationDeviceUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = cdUsr.CommunicationDeviceName;
                    e.Row.Cells[2].Text = cdUsr.CommunicationDevice.Description;
                    e.Row.Cells[3].Text = string.Format("Tipo: {0}, IP: {1}", cdUsr.CommunicationDeviceType, cdUsr.CommunicationDevice.IP);
                    
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario de Equipos de Comunicación";
                }
                if (pwdRequest.User is ATMUserEntity)
                {
                    ATMUserEntity ATMUsr = (ATMUserEntity)pwdRequest.User;
                    e.Row.Cells[1].Text = ATMUsr.Username;
                    e.Row.Cells[2].Text = ATMUsr.Desc;
                    e.Row.Cells[3].Text = "ATM: " + ATMUsr.ATMName;                    
                    imageUrl = "~/image/pwd_free.gif";
                    strToolTip = "Usuario AS400";
                }


            }
            TempImage.ImageUrl = imageUrl;
            TempImage.ToolTip = strToolTip;

        }
    }
}
