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

public partial class reqpwd : System.Web.UI.Page
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
                catch (ThreadAbortException tae)
                {
                }

            }
            MostrarPwdPnls();
        }
        if (!internalError)
        {
            Session["CtrlTitle"] = "Solicitud de Contraseña";
            Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];

        }
    }


    protected void cbPwdTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        MostrarPwdPnls();
    }

    private void MostrarPwdPnls()
    {
        trPWDs.Visible = true;
        pnlDBPwd.Visible = false;
        pnlAppPwd.Visible = false;
        pnlWinPwd.Visible = false;
        pnlUnixPwd.Visible = false;
        pnlAS400Pwd.Visible = false;
        pnlCDPwd.Visible = false;
        pnlATMPwd.Visible = false;

        pnlDBPwd.Visible = (cbPwdTypes.SelectedValue == "2");
        pnlAppPwd.Visible = (cbPwdTypes.SelectedValue == "3");
        pnlWinPwd.Visible = (cbPwdTypes.SelectedValue == "1");
        pnlUnixPwd.Visible = (cbPwdTypes.SelectedValue == "4");
        pnlAS400Pwd.Visible = (cbPwdTypes.SelectedValue == "5");
        pnlCDPwd.Visible = (cbPwdTypes.SelectedValue == "6");
        pnlATMPwd.Visible = (cbPwdTypes.SelectedValue == "7");
    }

    protected void gvPassword_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            string imageUrl = string.Empty;
            bool isInUseByMe = false;
            int linkOrdinalNumber = 5;
            Image tmpImage = (Image)e.Row.FindControl("imgTemp");

            UserEntity tmpUser = (UserEntity)e.Row.DataItem;

            if (tmpUser is DatabaseUserEntity)
            {
                DatabaseUserEntity dbUser = ((DatabaseUserEntity)tmpUser);
                e.Row.Cells[2].Text = ((DatabaseUserEntity)tmpUser).Db.Type.Name;
                //e.Row.Cells[3].Text = ((DatabaseUserEntity)tmpUser).Db.ServerName;
                e.Row.Cells[3].Text = ((DatabaseUserEntity)tmpUser).Db.PCName;
                linkOrdinalNumber = 6;
            }
            if (tmpUser is ApplicationUserEntity)
            {
                ApplicationUserEntity appUser = (ApplicationUserEntity)tmpUser;

                string tempString = (appUser.Application.Field1Desc != string.Empty
                            ? appUser.Application.Field1Desc : string.Empty);
                tempString += (appUser.Application.Field2Desc != string.Empty
                    ? " " + appUser.Application.Field2Desc : string.Empty);
                tempString += (appUser.Application.Field3Desc != string.Empty
                    ? " " + appUser.Application.Field3Desc : string.Empty);

                e.Row.Cells[4].Text = tempString;
            }
            if (tmpUser is UnixUserEntity)
            {
                e.Row.Cells[2].Text = ((UnixUserEntity)tmpUser).Unix.Ip;
            }
            if (tmpUser is AS400UserEntity)
            {
                e.Row.Cells[2].Text = ((AS400UserEntity)tmpUser).AS400.Ip;
            }
            if (tmpUser is CommunicationDeviceUserEntity)
            {
                e.Row.Cells[3].Text = ((CommunicationDeviceUserEntity)tmpUser).CommunicationDevice.IP;
            }
            if (tmpUser is ATMUserEntity)
            {
                linkOrdinalNumber = 4;
            }

            if (tmpUser.UserPassword.PwdLockType == null)
            {
                e.Row.Cells[0].ToolTip = "Contraseña disponible";
                imageUrl = "~/image/pwd_free.gif";
            }
            else
            {
                string users = "";
                e.Row.Cells[0].ToolTip = tmpUser.UserPassword.PwdLockType.Desc;
                if (tmpUser.UserPassword.PwdLockType.Code == "BEING_USED")
                {
                    try
                    {
                        foreach (object tmpObjPwdRequests in tmpUser.UserPassword.PasswordsRequestsList)
                        {
                            // Pregunto si otra solicitud fue al menos Visualizada y no está cerrada
                            if ((((PasswordRequestEntity)tmpObjPwdRequests).RqstState.Id >= 4 &&
                                 ((PasswordRequestEntity)tmpObjPwdRequests).RqstState.Id != 11)
                                //&&  ((PasswordRequestEntity)tmpObjPwdRequests).User.Id != tmpUser.Id 
                                )
                            {
                                isInUseByMe = isInUseByMe | (((PasswordRequestEntity)tmpObjPwdRequests).RqstUser.Id == ((PhxUserEntity)Session["PhxUser"]).Id);
                                users += (((PasswordRequestEntity)tmpObjPwdRequests).RqstUser != null
                                    ? ((PasswordRequestEntity)tmpObjPwdRequests).RqstUser.Fullname : string.Empty);
                            }
                        }
                    }
                    catch
                    {
                        users = string.Empty;
                    }

                    e.Row.Cells[linkOrdinalNumber].Enabled = (tmpUser.UserPassword.Concurrent);
                    if (tmpUser.UserPassword.Concurrent)
                        imageUrl = "~/image/pwd_in_use_concurrent.gif";
                    else
                        imageUrl = "~/image/pwd_in_use.gif";
                }
                else
                {
                    imageUrl = "~/image/pwd_locked.gif";
                    e.Row.Cells[linkOrdinalNumber].Enabled = false;
                }
                e.Row.Cells[linkOrdinalNumber].ToolTip = tmpUser.UserPassword.PwdLockType.Desc + "\n" + users;
                e.Row.Cells[linkOrdinalNumber].Enabled = e.Row.Cells[linkOrdinalNumber].Enabled & (!isInUseByMe);
                if (users.Length > 0) e.Row.Cells[0].ToolTip += "\n" + users;
            }
            tmpImage.ImageUrl = imageUrl;
        }
    }
    protected void btnWinSearch_Click(object sender, EventArgs e)
    {
        gvWinPwd.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (pnlAppPwd.Visible)
        {
            gvAppPwd.DataBind();
        }
        else if (pnlAS400Pwd.Visible)
        {
            gvAS400Pwd.DataBind();
        }
        else if (pnlCDPwd.Visible)
        {
            gvCDPwd.DataBind();
        }
        else if (pnlDBPwd.Visible)
        {
            gvDBPwd.DataBind();
        }
        else if (pnlUnixPwd.Visible)
        {
            gvUnixPwd.DataBind();
        }
        else if (pnlWinPwd.Visible)
        {
            gvWinPwd.DataBind();
        }

    }
}
