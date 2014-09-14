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

public partial class closeexppwdrst : System.Web.UI.Page
{
    PasswordRequestEntity _PwdReq;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserEntity currentUser = null;
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && PhxUsrBL.ChkAuthPwdRequest(IdentUser) &&
                Page.Request["prid"] != null)
            {
                int pwdreqId = Int32.Parse(Page.Request["prid"]);

                PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
                //currentUser = this.GetUserEntity(Int32.Parse(Page.Request["prid"]));

                if (tmpPwdReq == null || new PasswordRequestBusiness().IsAbleToReturnByExpiration(tmpPwdReq, IdentUser) == false)
                {
                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException)
                    {
                    }
                }
                currentUser = tmpPwdReq.User;
                //SetUserSession(currentUser);
                this._PwdReq = tmpPwdReq;
                this.ViewState.Add("PwdRqst", tmpPwdReq);


                //currentUser = this.GetUserEntity(Int32.Parse(Page.Request["prid"]));

                //if (currentUser == null)
                //{
                //    try
                //    {
                //        Response.Redirect("noAutho.aspx");
                //    }
                //    catch (ThreadAbortException)
                //    {
                //    }
                //}
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
                Fill_UserData(currentUser);
                Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];
            }
        }
        else
        {
            this._PwdReq = (PasswordRequestEntity) this.ViewState["PwdRqst"];
        }
    }

    private UserEntity GetUserEntity(int pwdreqId)
    {
        PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
        this._PwdReq = tmpPwdReq;
        this.ViewState.Add("PwdRqst", tmpPwdReq);
        UserEntity currentUser = tmpPwdReq.User;

        /*if (currentUser != null)
        {
            //PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            switch (currentUser.UserType.Id)
            {
                case 1:     // Windows
                    //currentUser = (UserEntity)new WinLocalUserBusiness().GetWinPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["prid"]));
                    Session["WinLocUsrForRqst"] = currentUser;
                    break;
                case 2:     // Bases De Datos
                    //currentUser = (UserEntity)new DatabaseUserBusiness().GetDBPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["prid"]));
                    Session["DatabaseUsrForRqst"] = currentUser;
                    break;
                case 3:     // Aplicativos
                    //currentUser = (UserEntity)new ApplicationUserBusiness().GetAppPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["prid"]));
                    Session["ApplicationUsrForRqst"] = currentUser;
                    break;
                case 4:     // Unix
                    //currentUser = (UserEntity)new UnixUserBusiness().GetUnixPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["prid"]));
                    Session["UnixUsrForRqst"] = currentUser;
                    break;
            }
        }*/
        return currentUser;
    }

    private void Fill_UserData(UserEntity user)
    {

        // Usuario de aplicacion
        if (user is ApplicationUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Aplicaciones";
            lblPwdType.Text = "Contraseña de Aplicación";
            ApplicationUserEntity appUser = (ApplicationUserEntity)user;
            colImage.RowSpan = 5;
            lblField1.Text = "Aplicación";
            txtField1.Text = appUser.Application.Name;
            row_Data_2.Visible = (appUser.Application.Field1Desc != string.Empty);
            lblField2.Text = appUser.Application.Field1Desc;
            txtField2.Text = appUser.Field1Value;
            row_Data_3.Visible = (appUser.Application.Field2Desc != string.Empty);
            lblField3.Text = appUser.Application.Field2Desc;
            txtField3.Text = appUser.Field2Value;
            row_Data_4.Visible = (appUser.Application.Field3Desc != string.Empty);
            lblField4.Text = appUser.Application.Field3Desc;
            txtField4.Text = appUser.Field3Value;
            row_Data_5.Visible = true;
            lblField5.Text = "Usuario";
            txtField5.Text = appUser.Username;
        }

        if (user is DatabaseUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Base de Datos";
            lblPwdType.Text = "Contraseña de Base de Datos";
            DatabaseUserEntity dbUser = (DatabaseUserEntity)user;
            colImage.RowSpan = 4;
            lblField1.Text = "Base de Datos";
            txtField1.Text = dbUser.Db.Name;
            lblField2.Text = "Tipo";
            txtField2.Text = dbUser.Db.Type.Name;
            lblField3.Text = "Servidor";
            //txtField3.Text = dbUser.Db.ServerName;
            txtField3.Text = dbUser.Db.PCName;
            row_Data_4.Visible = true;
            lblField4.Text = "Usuario";
            txtField4.Text = dbUser.Username;
            row_Data_5.Visible = false;
        }

        if (user is WinLocalUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Windows";
            lblPwdType.Text = "Contraseña de Windows";
            WinLocalUserEntity winUser = (WinLocalUserEntity)user;
            colImage.RowSpan = 3;
            lblField1.Text = "Dominio";
            txtField1.Text = winUser.WinPc.WinDomain.NtName;
            lblField2.Text = "Servidor";
            txtField2.Text = winUser.WinPc.Name;
            lblField3.Text = "Usuario";
            txtField3.Text = winUser.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
        }

        if (user is UnixUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Unix";
            lblPwdType.Text = "Contraseña de Unix";
            UnixUserEntity unixUser = (UnixUserEntity)user;
            colImage.RowSpan = 4;
            lblField1.Text = "Servidor";
            txtField1.Text = unixUser.Unix.ServerName;
            lblField2.Text = "Dirección IP";
            txtField2.Text = unixUser.Unix.Ip;
            lblField3.Text = "Usuario";
            txtField3.Text = unixUser.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
        }
        if (user is AS400UserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de AS400";
            lblPwdType.Text = "Contraseña de AS400";
            AS400UserEntity AS400User = (AS400UserEntity)user;
            colImage.RowSpan = 4;
            lblField1.Text = "Servidor";
            txtField1.Text = AS400User.AS400.ServerName;
            lblField2.Text = "Dirección IP";
            txtField2.Text = AS400User.AS400.Ip;
            lblField3.Text = "Usuario";
            txtField3.Text = AS400User.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
        }

        if (user is CommunicationDeviceUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Equipos de Comunicación";
            lblPwdType.Text = "Contraseña de Equipos de Comunicación";
            CommunicationDeviceUserEntity cdUser = (CommunicationDeviceUserEntity)user;
            colImage.RowSpan = 4;
            lblField1.Text = "Equipo";
            txtField1.Text = cdUser.CommunicationDeviceName;
            lblField2.Text = "Tipo";
            txtField2.Text = cdUser.CommunicationDeviceType;
            lblField3.Text = "IP";
            //txtField3.Text = dbUser.Db.ServerName;
            txtField3.Text = cdUser.CommunicationDevice.IP;
            row_Data_4.Visible = true;
            lblField4.Text = "Usuario";
            txtField4.Text = cdUser.Username;
            row_Data_5.Visible = false;
        }

        txtAutorizador.Text = _PwdReq.Auth1Usr.Fullname;
        txtFAutoriz.Text = _PwdReq.Auth1Date.Value.ToString("dd/MM/yyyy HH:mm:ss");
        txtFSolic.Text = _PwdReq.RqstDateddmmyyyy;
        txtSolicUsr.Text = _PwdReq.RqstUser.Fullname;
        txtFExpirac.Text = _PwdReq.ExpirationDate.Value.ToString("dd/MM/yyyy HH:mm:ss");
       
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid)
        {
            return;
        }
        Session["phxButtonBack"] = "default.aspx";
        try
        {
            PasswordRequestBusiness PwdRqstBL = new PasswordRequestBusiness();
            //PasswordRequestEntity pwdRqst = PwdRqstBL.Load(Convert.ToInt32(Page.Request["prid"]));
            int authUsrId = ((PhxUserEntity)Session["PhxUser"]).Id;
            //uint result = PwdRqstBL.CloseRequestPwd(pwdRqst, txtDesc.Text, authUsrId);
            uint result = PwdRqstBL.ReturnRequestPwdByAdmin(_PwdReq, txtDesc.Text, authUsrId);

            if (result == Phalanx.Util.PhxDALUtil.SUCCESS)
            {
                Session["phxMsgError"] = 0;
                Session["phxMessage"] = "La solicitud de contraseña se ha devuelto con exito";
                try
                {
                    Response.Redirect("Message.aspx");
                }
                catch (ThreadAbortException)
                {
                }
            }
            else
            {
                Session["phxMsgError"] = 1;
                Session["phxMessage"] = "Error al devolver la contraseña";
                try
                {
                    Response.Redirect("Message.aspx");
                }
                catch (ThreadAbortException)
                {
                }

            }
        }
        catch (ThreadAbortException)
        {
        }
        catch
        {
            try
            {
                Session["phxMsgError"] = 1;
                Session["phxMessage"] = "Error en la aplicación";
                Response.Redirect("Message.aspx");
            }
            catch (ThreadAbortException)
            {
            }
        }
    }
}
