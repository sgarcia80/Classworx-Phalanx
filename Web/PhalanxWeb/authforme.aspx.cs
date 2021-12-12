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
    public partial class authforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool internalError = false;
            if (!Page.IsPostBack)
            {
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];

                bool accrequest = PhxUsrBL.ChkPwdsRequest(IdentUser);
                bool accadmin = PhxUsrBL.AccPwdAll(IdentUser);

                if (IdentUser != null && (accrequest || accadmin))
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

                    /*
                catch (ThreadAbortException tae)
                {
                    internalError = true;
                }*/
                }
                if (!internalError)
                {
                    Session["CtrlTitle"] = "Visualización de Solicitudes de Contraseñas";
                    Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];
                }
            }
        }

        protected void Bcancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("default.aspx");
            }
            catch (ThreadAbortException tae)
            {
            }

        }

        protected void odsWinPWD_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
                    e.Row.Cells[1].Text = pwdRequest.UserName;
                    if (pwdRequest.UserDesc.Length > 25)
                        e.Row.Cells[2].Text = pwdRequest.UserDesc.Substring(0, 24) + "...";
                    else
                        e.Row.Cells[2].Text = pwdRequest.UserDesc;
                    e.Row.Cells[4].Text = pwdRequest.RqstDateddmmyyyy;
                    e.Row.Cells[5].Text = pwdRequest.State;
                    //e.Row.Cells[7].Text = pwdRequest.RqstDateddmmyyyy;

                    if (pwdRequest.User is WinLocalUserEntity)
                    {
                        WinLocalUserEntity winUsr = (WinLocalUserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = winUsr.WinPc.Name;
                        //e.Row.Cells[2].Text = winUsr.Domain;
                        e.Row.Cells[3].Text = "Dominio: " + winUsr.Domain + ", Equipo: " + winUsr.WinPc.Name + ", IP:" + winUsr.WinPc.PcIP;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario Windows";
                    }

                    if (pwdRequest.User is ApplicationUserEntity)
                    {
                        ApplicationUserEntity appUsr = (ApplicationUserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = appUsr.Application.Name;
                        //e.Row.Cells[2].Text = appUsr.Application.Desc;
                        tempString = "Aplicación: " + appUsr.ApplicationName;
                        //tempString += ", " + (appUsr.Application.Field1Desc != string.Empty
                        //    ? appUsr.Application.Field1Desc : string.Empty);
                        //tempString += ", " + (appUsr.Application.Field2Desc != string.Empty
                        //    ? " " + appUsr.Application.Field2Desc : string.Empty );
                        //tempString += ", " + (appUsr.Application.Field3Desc != string.Empty
                        //    ? " " + appUsr.Application.Field3Desc : string.Empty);

                        e.Row.Cells[3].Text = tempString;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario Aplicativos";
                    }

                    if (pwdRequest.User is DatabaseUserEntity)
                    {
                        DatabaseUserEntity dbUsr = (DatabaseUserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = dbUsr.Db.Name;
                        //e.Row.Cells[2].Text = dbUsr.Db.Desc;\
                        tempString = "Base: " + dbUsr.Db.Name;
                        tempString += ", Tipo: " + dbUsr.Db.Type.Name;
                        //tempString += " Servidor: " + dbUsr.Db.ServerName;
                        tempString += ", Servidor: " + dbUsr.Db.PCName;

                        e.Row.Cells[3].Text = tempString;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario Base de Datos";
                    }

                    if (pwdRequest.User is UnixUserEntity)
                    {
                        UnixUserEntity unixUsr = (UnixUserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = unixUsr.Unix.ServerName;
                        //e.Row.Cells[2].Text = unixUsr.Unix.Desc;
                        e.Row.Cells[3].Text = "Equipo Unix: " + unixUsr.Unix.ServerName + ", IP: " + unixUsr.Unix.Ip;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario Unix";
                    }
                    if (pwdRequest.User is AS400UserEntity)
                    {
                        AS400UserEntity AS400Usr = (AS400UserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = AS400Usr.AS400.ServerName;
                        //e.Row.Cells[2].Text = AS400Usr.AS400.Desc;
                        e.Row.Cells[3].Text = "Equipo AS400: " + AS400Usr.AS400.ServerName + ", IP: " + AS400Usr.AS400.Ip;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario AS400";
                    }

                    if (pwdRequest.User is CommunicationDeviceUserEntity)
                    {
                        CommunicationDeviceUserEntity cdUsr = (CommunicationDeviceUserEntity)pwdRequest.User;

                        e.Row.Cells[3].Text = string.Format("Equipo: {0}, Tipo: {1}, IP: {2}", cdUsr.CommunicationDeviceName, cdUsr.CommunicationDeviceType, cdUsr.CommunicationDevice.IP);

                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario Equipos de Comunicación";
                    }
                    if (pwdRequest.User is ATMUserEntity)
                    {
                        ATMUserEntity ATMUsr = (ATMUserEntity)pwdRequest.User;
                        //e.Row.Cells[1].Text = winUsr.WinPc.Name;
                        //e.Row.Cells[2].Text = winUsr.Domain;
                        e.Row.Cells[3].Text = "ATM: " + ATMUsr.ATMName;
                        ((HyperLink)e.Row.Controls[6].Controls[0]).NavigateUrl = "~/authformview.aspx?prid=" + pwdRequest.Id;
                        imageUrl = "~/image/pwd_free.gif";
                        strToolTip = "Usuario de ATM";
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
                }
                TempImage.ImageUrl = imageUrl;
                TempImage.ToolTip = strToolTip;
            }

        }
    }
}