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

public partial class reqpwdviewdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserEntity currentUser = null;
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (IdentUser != null && PhxUsrBL.ChkAccWebApp(IdentUser) && PhxUsrBL.ChkPwdsRequest (IdentUser) &&
                Page.Request["prid"] != null)
            {
                currentUser = this.GetUserEntity(Int32.Parse(Page.Request["prid"]));

                if (currentUser == null)
                {
                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException)
                    {
                    }
                }
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
                Fill_PasswordData(currentUser);
                Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];

                PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(Int32.Parse(Page.Request["prid"]));
                lblField6.Text = "Estado de la contraseña";
                txtField6.Text = tmpPwdReq.RqstState.RqstStateDesc;
            }
        }
    }

    private UserEntity GetUserEntity( int pwdreqId )
    {
        PasswordRequestEntity tmpPwdReq = new PasswordRequestBusiness().Load(pwdreqId);
        UserEntity currentUser = tmpPwdReq.User;
        
        if (currentUser != null)
        {
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            switch (currentUser.UserType.Id)
            {
                case 1:     // Windows
                    Session["WinLocUsrForRqstBack"] = currentUser;
                    break;
                case 2:     // Bases De Datos
                    Session["DatabaseUsrForRqstBack"] = currentUser;
                    break;
                case 3:     // Aplicativos
                    Session["ApplicationUsrForRqstBack"] = currentUser;
                    break;
                case 4:     // Unix
                    Session["UnixUsrForRqstBack"] = currentUser;
                    break;
                case 5:     // AS400
                    Session["AS400UsrForRqstBack"] = currentUser;
                    break;
                case 7:     // ATM
                    Session["ATMUsrForRqstBack"] = currentUser;
                    break;
            }
        }
        return currentUser;
    }

    private void Fill_PasswordData(UserEntity user)
    {

        // Usuario de aplicacion
        if (user is ApplicationUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de Aplicaciones";
            lblPwdType.Text = "Contraseña de Aplicaciones";
            ApplicationUserEntity appUser = (ApplicationUserEntity)user;
            colImage.RowSpan = 6;
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
            colImage.RowSpan = 5;
            lblField1.Text = "Base de Datos";
            txtField1.Text = dbUser.Db.Name;
            lblField2.Text = "Tipo";
            txtField2.Text = dbUser.Db.Type.Name;
            lblField3.Text = "Servidor";
            txtField3.Text = dbUser.Db.PCName;
            //txtField3.Text = dbUser.Db.ServerName;
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
            colImage.RowSpan = 4;
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
            colImage.RowSpan = 5;
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
            colImage.RowSpan = 5;
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
            lblPwdType.Text = "Contraseña de Base de Datos";
            CommunicationDeviceUserEntity cdUser = (CommunicationDeviceUserEntity)user;

            colImage.RowSpan = 7;
            lblField1.Text = "Equipo de Comunicación";
            txtField1.Text = cdUser.CommunicationDevice.Name;
            lblField2.Text = "Tipo";
            txtField2.Text = cdUser.CommunicationDevice.Type.Name;
            lblField3.Text = "IP";
            txtField3.Text = cdUser.CommunicationDevice.IP;
            row_Data_4.Visible = true;
            lblField4.Text = "Protocolos";

            string[] protocolos = new string[cdUser.Protocols.Count];

            for (int i = 0; i < cdUser.Protocols.Count; i++)
                protocolos[i] = cdUser.Protocols[i].Name;

            txtField4.Text = string.Join(", ", protocolos);
            row_Data_5.Visible = true;
            lblField5.Text = "Usuario";
            txtField5.Text = cdUser.Username;
        }
        if (user is ATMUserEntity)
        {
            Session["CtrlTitle"] = "Devolución de Contraseña de ATM";
            lblPwdType.Text = "Contraseña de ATM";
            ATMUserEntity ATMUser = (ATMUserEntity)user;
            colImage.RowSpan = 5;
            lblField1.Text = "ATM";
            txtField1.Text = ATMUser.ATMName;
            lblField2.Text = "Usuario";
            txtField2.Text = ATMUser.Username;
            row_Data_3.Visible = false;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
        }
    }

    protected void btnDevolver_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (!Page.IsValid)
        {
            return;
        }
        Session["phxButtonBack"] = "default.aspx";
        try
        {
            PasswordRequestBusiness tmpPwdReq = new PasswordRequestBusiness();
            PasswordRequestEntity currentPwdRqst = tmpPwdReq.Load (Convert.ToInt32(Page.Request["prid"]));

            PhxDALUtil.RequestStates state = currentPwdRqst.User is ATMUserEntity ? PhxDALUtil.RequestStates.Closed : PhxDALUtil.RequestStates.ReturnedByUser;

            uint result = new PasswordRequestBusiness().GetRequestPwdBack(currentPwdRqst, (int)state, txtDesc.Text, (PhxUserEntity)Session["PhxUser"]);

            if (result == PhxDALUtil.SUCCESS )
            {
                Session["phxMsgError"] = 0;
                Session["phxMessage"] = "Se ha devuelto la contraseña con exito";
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
                Session["phxMessage"] = "Error en la devolución de la contraseña";
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
