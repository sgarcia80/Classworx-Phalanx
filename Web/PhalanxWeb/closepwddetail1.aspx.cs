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
using Phalanx.Util;

public partial class closepwddetail1 : System.Web.UI.Page
{
    private PasswordRequestEntity _PwdRqst
    {
        get
        {
            return (PasswordRequestEntity)this.ViewState["PwdRqst"];
        }
        set
        {
            this.ViewState["PwdRqst"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        UserEntity currentUser = null;
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && PhxUsrBL.ChkAuthPwdRequest (IdentUser) &&
                Page.Request["prid"] != null)
            {
                int pwdreqId = Int32.Parse(Page.Request["prid"]);

                PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
                //currentUser = this.GetUserEntity(Int32.Parse(Page.Request["prid"]));

                if (tmpPwdReq == null || new PasswordRequestBusiness().IsAbleToClose(tmpPwdReq, IdentUser) == false)
                {
                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException)
                    {
                    }
                }
                _PwdRqst = tmpPwdReq;
                currentUser = tmpPwdReq.User;
                txtFechaSol.Text = tmpPwdReq.RequestDate.ToString("dd/MM/yyyy HH:mm:ss");
                /// si el usuario es critico, debe verificarse que haya un cambio posterior a la
                /// devolucion
                if (tmpPwdReq.User.UserType.Id == new UserTypeBusiness().GetUserTypeATM().Id)
                {
                    lblPwdCritical.Visible = false;
                    
                    if(tmpPwdReq.User.ActiveUser == false)
                        lblTxtCambioCritical.Text = "La contraseña fue desactivada en la devolución";
                }
                else if (tmpPwdReq.User.Critical)
                {
                    lblPwdCritical.Visible = true;

                    if (tmpPwdReq.ModificadaDespuesDevolucion)
                    {
                        /// hay un cambio luego de la devolución
                        lblTxtCambioCritical.Visible = false;
                        btnClose.Enabled = true;
                    }
                    else
                    {
                        lblTxtCambioCritical.Visible = true;
                        btnClose.Enabled = false;
                    }
                }
                else
                    lblPwdCritical.Visible = false;
                
                SetUserSession(currentUser);
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
            btnClose.Attributes.Add("onclick", "this.disabled = true; this.value = 'Procesando...'; " + btnCancel.ClientID + ".disabled = true;");

        }
    }

    //private UserEntity GetUserEntity(int pwdreqId)
    //{
    //    PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
    //    UserEntity currentUser = tmpPwdReq.User;
    //}
    private void SetUserSession(UserEntity currentUser)
    {
        if (currentUser != null)
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
                case 5:     // AS400
                    //currentUser = (UserEntity)new AS400UserBusiness().GetAS400PwdForRqst(IdentUser, Convert.ToInt32(Page.Request["prid"]));
                    Session["AS400UsrForRqst"] = currentUser;
                    break;
            }
        }
        //return currentUser;
    }

    private void Fill_UserData(UserEntity user)
    {
        txtFechaUltModif.Text = user.LastChangeDate;
        // Usuario de aplicacion
        if (user is ApplicationUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de Aplicaciones";
            lblPwdType.Text = "Contraseña de Aplicación";
            ApplicationUserEntity appUser = (ApplicationUserEntity)user;
            colImage.RowSpan = 7;
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
            if (appUser.Application.Desactiva_PWD_Cierre)
            {
                int pwdreqId = Int32.Parse(Page.Request["prid"]);
                PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
                if (tmpPwdReq.ExpiradaSinVisualizar)
                {
                    row_Data_6.Visible = false;
                }
                else
                {
                    row_Data_6.Visible = true;
                    btnClose.Enabled = true; // habilita el botón de cierrar porque al mostrar el check, éste esta chequeado
                }
            }
            else
            {
                row_Data_6.Visible = false;
            }
        }

        if (user is DatabaseUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de Base de Datos";
            lblPwdType.Text = "Contraseña de Base de Datos";
            DatabaseUserEntity dbUser = (DatabaseUserEntity)user;
            colImage.RowSpan = 6;
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
            row_Data_6.Visible = false;
        }

        if (user is WinLocalUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de Windows";
            lblPwdType.Text = "Contraseña de Windows";
            WinLocalUserEntity winUser = (WinLocalUserEntity)user;
            colImage.RowSpan = 5;
            lblField1.Text = "Dominio";
            txtField1.Text = winUser.WinPc.WinDomain.NtName;
            lblField2.Text = "Servidor";
            txtField2.Text = winUser.WinPc.Name;
            lblField3.Text = "Usuario";
            txtField3.Text = winUser.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
            row_Data_6.Visible = false;
        }

        if (user is UnixUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de Unix";
            lblPwdType.Text = "Contraseña de Unix";
            UnixUserEntity unixUser = (UnixUserEntity)user;
            colImage.RowSpan = 6;
            lblField1.Text = "Servidor";
            txtField1.Text = unixUser.Unix.ServerName;
            lblField2.Text = "Dirección IP";
            txtField2.Text = unixUser.Unix.Ip;
            lblField3.Text = "Usuario";
            txtField3.Text = unixUser.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
            row_Data_6.Visible = false;
        }
        if (user is AS400UserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de AS400";
            lblPwdType.Text = "Contraseña de AS400";
            AS400UserEntity AS400User = (AS400UserEntity)user;
            colImage.RowSpan = 6;
            lblField1.Text = "Servidor";
            txtField1.Text = AS400User.AS400.ServerName;
            lblField2.Text = "Dirección IP";
            txtField2.Text = AS400User.AS400.Ip;
            lblField3.Text = "Usuario";
            txtField3.Text = AS400User.Username;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
            row_Data_6.Visible = false;
        }

        if (user is CommunicationDeviceUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de Equipos de Comunicación";
            lblPwdType.Text = "Contraseña de Equipos de comunicación";
            CommunicationDeviceUserEntity cdUser = (CommunicationDeviceUserEntity)user;
            colImage.RowSpan = 6;
            lblField1.Text = "Equipo";
            txtField1.Text = cdUser.CommunicationDeviceName;
            lblField2.Text = "Tipo";
            txtField2.Text = cdUser.CommunicationDeviceType;
            lblField3.Text = "IP";
            txtField3.Text = cdUser.CommunicationDevice.IP;
            row_Data_4.Visible = true;
            lblField4.Text = "Usuario";
            txtField4.Text = cdUser.Username;
            row_Data_5.Visible = false;
            row_Data_6.Visible = false;
        }
        if (user is ATMUserEntity)
        {
            Session["CtrlTitle"] = "Cierre de Contraseña de ATM";
            lblPwdType.Text = "Contraseña de ATM";
            ATMUserEntity ATMUser = (ATMUserEntity)user;
            colImage.RowSpan = 6;
            lblField1.Text = "ATM";
            txtField1.Text = ATMUser.ATMName;
            lblField2.Text = "Usuario";
            txtField2.Text = ATMUser.Username;
            row_Data_3.Visible = false;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
            row_Data_6.Visible = false;
        }

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
            PasswordRequestEntity pwdRqst = _PwdRqst; // PwdRqstBL.Load(Convert.ToInt32(Page.Request["prid"]));
            int authUsrId = ((PhxUserEntity) Session["PhxUser"]).Id;
            uint result;

            if (pwdRqst.User.UserType.Id != new UserTypeBusiness().GetUserTypeATM().Id 
                    && pwdRqst.User.Critical 
                    && !pwdRqst.ModificadaDespuesDevolucion)
                return;

            if (pwdRqst.User is ApplicationUserEntity)
            {
                ApplicationUserEntity appUser = (ApplicationUserEntity)pwdRqst.User;
                if (appUser.Application.Desactiva_PWD_Cierre && chkDesactivarContrasenia.Checked)
                {
                    result = PwdRqstBL.CloseRequestPwd(pwdRqst, txtDesc.Text, authUsrId, true);
                }
                else
                {
                    result = PwdRqstBL.CloseRequestPwd(pwdRqst, txtDesc.Text, authUsrId, false);
                }
            }
            else
            {
                result = PwdRqstBL.CloseRequestPwd(pwdRqst, txtDesc.Text, authUsrId, false);
            }

            if (result == Phalanx.Util.PhxDALUtil.SUCCESS)
            {
                Session["phxMsgError"] = 0;
                Session["phxMessage"] = "La contraseña se ha cerrado con exito";
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
                Session["phxMessage"] = "Error al cerrar la contraseña";
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
    protected void chkDesactivarContrasenia_CheckedChanged(object sender, EventArgs e)
    {
        /// si es critica y no hay cambio posterior a la devolución, solo se habilita el
        /// botón de cierre cuando se desactiva la clave
        /// 
        if (_PwdRqst.User.Critical && (_PwdRqst.UserPassword.DLastChange == null ||
            (_PwdRqst.UserPassword.DLastChange != null && _PwdRqst.UserPassword.DLastChange.Value < _PwdRqst.ReturnDate.Value)
            ))
        {
            if (chkDesactivarContrasenia.Checked)
            {
                btnClose.Enabled = true;
            }
            else
            {
                btnClose.Enabled = false;
            }
        }
        else
        {
            btnClose.Enabled = true;

        }
    }
}
