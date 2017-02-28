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

public partial class reqpwddetail1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserEntity currentUser = null;
        bool internalError = false;
        if (!Page.IsPostBack)
        {
            /// continuar con la siguietne linea para el boton de solicitar para que deshabilite ese y el otro, ver
            /// de sacar el codigo que esta puesto en el aspx
            //TextBox1.Attributes.Add("onclick", "ClickMe(this, '" + TextBox1.ClientID + "', '" + TextBox2.ClientID + "')");
            btnSolicitar.Attributes.Add("onclick", "this.disabled = true; this.value = 'Procesando...'; " + btnCancel.ClientID + ".disabled = true;");
            btnCancel.Attributes.Add("onclick", "this.disabled = true; " + btnSolicitar.ClientID + ".disabled = true;");
            PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            if (IdentUser != null && PhxUsrBL.ChkPwdsRequest(IdentUser) &&
                Page.Request["wpid"] != null)
            {
                currentUser = this.GetUserEntity(Int32.Parse(Page.Request["wpid"]));

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
                Fill_UserData(currentUser);
                Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];

                // determina si la contraseña está en uso y si es asi, si es no concurrente
                //return;
                if (currentUser.UserPassword.DInUseUntil != null &&
                    currentUser.UserPassword.DInUseUntil >= DateTime.Now &&
                    !currentUser.UserPassword.Concurrent)
                {
                    tblSolicPwd.Visible = false;
                    trTblPwdInUse.Visible = true;

                    PasswordRequestEntity SolicitudEnUso = new PasswordRequestBusiness().GetRequestForPwdInUse(currentUser.UserPassword);
                    if (SolicitudEnUso == null)
                    {
                        // si no hay una sola solicitud da error
                        Session["phxMsgError"] = 1;
                        Session["phxMessage"] = "Error al solicitar la contraseña";
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
                        lblPwdInUse.Text = "La contraseña se encuentra en uso por " + SolicitudEnUso.RqstUser.Fullname;
                    }
                }
            }
        }
    }

    private UserEntity GetUserEntity( int userId )
    {
        UserEntity currentUser = new UserBusiness().GetUserByID(userId);

        if (currentUser != null)
        {
            PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
            switch (currentUser.UserType.Id)
            {
                case 1:     // Windows
                    currentUser = (UserEntity)new WinLocalUserBusiness().GetWinPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["WinLocUsrForRqst"] = currentUser;
                    break;
                case 2:     // Bases De Datos
                    currentUser = (UserEntity)new DatabaseUserBusiness().GetDBPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["DatabaseUsrForRqst"] = currentUser;
                    break;
                case 3:     // Aplicativos
                    currentUser = (UserEntity)new ApplicationUserBusiness().GetAppPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["ApplicationUsrForRqst"] = currentUser;
                    break;
                case 4:     // Unix
                    currentUser = (UserEntity)new UnixUserBusiness().GetUnixPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["UnixUsrForRqst"] = currentUser;
                    break;
                case 5:     // AS400
                    currentUser = (UserEntity)new AS400UserBusiness().GetAS400PwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["AS400UsrForRqst"] = currentUser;
                    break;
                case 7: // ATMs
                    currentUser = (UserEntity)new ATMUserBusiness().GetATMPwdForRqst(IdentUser, Convert.ToInt32(Page.Request["wpid"]));
                    Session["ATMUsrForRqst"] = currentUser;
                    break;
            }
        }
        return currentUser;
    }

    private void Fill_UserData(UserEntity user)
    {

        // Usuario de aplicacion
        if (user is ApplicationUserEntity)
        {
            Session["CtrlTitle"] = "Solicitud de Contraseña de Aplicaciones";
            lblPwdType.Text = "Contraseña de Aplicativo";
            ApplicationUserEntity appUser = (ApplicationUserEntity)user;
            colImage.RowSpan = 5;
            lblField1.Text = "Aplicación";
            txtField1.Text = appUser.Application.Name;
            row_Data_2.Visible = false;// (appUser.Application.Field1Desc != string.Empty);
            lblField2.Text = appUser.Application.Field1Desc;
            txtField2.Text = (appUser.Application.Field1Desc != string.Empty ? "*******" : ""); // appUser.Field1Value;
            row_Data_3.Visible = false;//= (appUser.Application.Field2Desc != string.Empty);
            lblField3.Text = appUser.Application.Field2Desc;
            txtField3.Text = (appUser.Application.Field2Desc != string.Empty ? "*******" : ""); // appUser.Field2Value;
            row_Data_4.Visible = false;//= (appUser.Application.Field3Desc != string.Empty);
            lblField4.Text = appUser.Application.Field3Desc;
            txtField4.Text = (appUser.Application.Field3Desc != string.Empty ? "*******" : ""); // appUser.Field3Value;
            row_Data_5.Visible = true;
            lblField5.Text = "Usuario";
            txtField5.Text = appUser.Username;
        }

        //if (user is DatabaseUserEntity)
        //{
        //    Session["CtrlTitle"] = "Solicitud de Contraseña de Base de Datos";
        //    lblPwdType.Text = "Contraseña de ATM";
        //    DatabaseUserEntity dbUser = (DatabaseUserEntity)user;
        //    colImage.RowSpan = 4;
        //    lblField1.Text = "Base de Datos";
        //    txtField1.Text = dbUser.Db.Name;
        //    lblField2.Text = "Tipo";
        //    txtField2.Text = dbUser.Db.Type.Name;
        //    lblField3.Text = "Servidor";
        //    //txtField3.Text = dbUser.Db.ServerName;
        //    txtField3.Text = dbUser.Db.PCName;
        //    row_Data_4.Visible = true;
        //    lblField4.Text = "Usuario";
        //    txtField4.Text = dbUser.Username;
        //    row_Data_5.Visible = false;
        //}

        if (user is WinLocalUserEntity)
        {
            Session["CtrlTitle"] = "Solicitud de Contraseña de Windows";
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
            Session["CtrlTitle"] = "Solicitud de Contraseña de Unix";
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
            Session["CtrlTitle"] = "Solicitud de Contraseña de AS400";
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
        
        if (user is DatabaseUserEntity)
        {
            Session["CtrlTitle"] = "Solicitud de Contraseña de Base de Datos";
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

        if (user is CommunicationDeviceUserEntity)
        {
            Session["CtrlTitle"] = "Solicitud de Contraseña de Equipos de Comunicación";
            lblPwdType.Text = "Contraseña de Equipo de Comunicación";
            CommunicationDeviceUserEntity cdUser = (CommunicationDeviceUserEntity)user;
            colImage.RowSpan = 6;
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
            Session["CtrlTitle"] = "Solicitud de Contraseña de ATM";
            lblPwdType.Text = "Contraseña de ATM";
            ATMUserEntity ATMUser = (ATMUserEntity)user;
            colImage.RowSpan = 4;
            lblField1.Text = "ATM";
            txtField1.Text = ATMUser.ATMName;
            lblField2.Text = "Usuario";
            txtField2.Text = ATMUser.Username;
            row_Data_3.Visible = false;
            row_Data_4.Visible = false;
            row_Data_5.Visible = false;
        }
    }

    protected void btnSolicitar_Click(object sender, EventArgs e)
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
            PasswordRequestEntity PwdRqstE = new PasswordRequestEntity();
            //PwdRqstE.UserPassword = new ApplicationUserBusiness().GetAppPwdForRqst((PhxUserEntity)Session["PhxUser"], Convert.ToInt32(Page.Request["wpid"])).UserPassword;
            UserEntity currentUser = this.GetUserEntity(Convert.ToInt32(Page.Request["wpid"]));
            PwdRqstE.UserPassword = currentUser.UserPassword;
            PwdRqstE.RqstUser = (PhxUserEntity)Session["PhxUser"];
            PwdRqstE.HoursRequested = Convert.ToInt32(txtHsRequested.Text);
            PwdRqstE.RequestDesc = txtDesc.Text;
            PwdRqstE.UnitRequested = cbUnitGiven.SelectedValue;
            PwdRqstE.RequestDate = DateTime.Now;
            int PwdRqstID = PwdRqstBL.CreateRequest(PwdRqstE);

            if (PwdRqstID > 0)
            {

                Session["phxMsgError"] = 0;
                Session["phxMessage"] = "Se ha solicitado la contraseña con exito";
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
                Session["phxMessage"] = "Error al solicitar la contraseña";
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

    protected void chkAcceptPolicies_CheckedChanged(object sender, EventArgs e)
    {
        btnSolicitar.Enabled = chkAcceptPolicies.Checked;
    }
}
