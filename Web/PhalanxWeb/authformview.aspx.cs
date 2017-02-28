using PhalanxBL;
using PhalanxCommon.Entities;
using phxCryptMgr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PhalanxWeb
{
    public partial class authformview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool internalError = false;
            if (!Page.IsPostBack)
            {
                if (Session["PwdRqst"] != null)
                {
                    Session["PwdRqst"] = null;
                }
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntity IdentUser = (PhxUserEntity)Session["PhxUser"];
                if (IdentUser != null && PhxUsrBL.ChkPwdsRequest(IdentUser) &&
                    Page.Request["prid"] != null)
                {
                    Session["PwdRqst"] = new PasswordRequestBusiness().Load(Convert.ToInt32(Page.Request["prid"]));
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
                if (!internalError)
                {

                    Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];
                    PasswordRequestEntity PwdRqst = (PasswordRequestEntity)Session["PwdRqst"];
                    // muestro todos los datos

                    TbUsuarioSolicitado.Text = PwdRqst.UserName;
                    TbContrasenia.Text = "*******";
                    TbDesc.Text = PwdRqst.UserDesc;

                    if (PwdRqst.UserPassword.UsersList[0] is WinLocalUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de Windows";
                        TbServerSolic.Text = ((WinLocalUserEntity)PwdRqst.UserPassword.UsersList[0]).PCName;
                        LAux1.Text = "Dominio";
                        TbAux1.Text = ((WinLocalUserEntity)PwdRqst.UserPassword.UsersList[0]).Domain;

                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is UnixUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de Unix - Linux";
                        TbServerSolic.Text = ((UnixUserEntity)PwdRqst.UserPassword.UsersList[0]).Unix.ServerName;
                        LAux1.Text = "Dirección IP";
                        TbAux1.Text = ((UnixUserEntity)PwdRqst.UserPassword.UsersList[0]).Unix.Ip;
                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is AS400UserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de AS400";
                        TbServerSolic.Text = ((AS400UserEntity)PwdRqst.UserPassword.UsersList[0]).AS400.ServerName;
                        LAux1.Text = "Dirección IP";
                        TbAux1.Text = ((AS400UserEntity)PwdRqst.UserPassword.UsersList[0]).AS400.Ip;
                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is DatabaseUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de Base de Datos";
                        //TbServerSolic.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.ServerName;
                        TbServerSolic.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.PCName;
                        LAux1.Text = "Tipo de Base de Datos";
                        TbAux1.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.Type.Name;
                        LAux2.Text = "Base de Datos";
                        TbAux2.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.Name;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is ApplicationUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de Aplicativos";
                        LServidor.Text = "Aplicativo";
                        TbServerSolic.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Name;

                        if (((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field1Desc.Length > 0)
                        {
                            LAux1.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field1Desc;
                            TbAux1.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Field1Value;
                        }
                        else
                        {
                            LAux1.Visible = false;
                            TbAux1.Visible = false;
                        }

                        if (((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field2Desc.Length > 0)
                        {
                            LAux2.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field2Desc;
                            TbAux2.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Field2Value;
                        }
                        else
                        {
                            LAux2.Visible = false;
                            TbAux2.Visible = false;
                        }

                        if (((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field3Desc.Length > 0)
                        {
                            LAux3.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Application.Field3Desc;
                            TbAux3.Text = ((ApplicationUserEntity)PwdRqst.UserPassword.UsersList[0]).Field3Value;
                        }
                        else
                        {
                            LAux3.Visible = false;
                            TbAux3.Visible = false;
                        }
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is CommunicationDeviceUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de Equipos de Comunicación";
                        LServidor.Text = "Equipo";
                        TbServerSolic.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDeviceName;
                        LAux1.Text = "Tipo";
                        TbAux1.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDeviceType;
                        LAux2.Text = "IP";
                        TbAux2.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDevice.IP;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is ATMUserEntity)
                    {
                        Session["CtrlTitle"] = "Visualización de Solicitud de Contraseña de ATM";
                        LServidor.Text = "ATM";
                        TbServerSolic.Text = ((ATMUserEntity)PwdRqst.UserPassword.UsersList[0]).ATMName;
                        LAux1.Visible = false;
                        TbAux1.Visible = false;
                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }

                    if (PwdRqst.Auth1Date != null)
                    {
                        if (PwdRqst.Auth1Usr != null)
                        {
                            TbUsuarioAut.Text = PwdRqst.Auth1Usr.Fullname;
                        }
                        TbFechaAut.Text = PwdRqst.Auth1Date.ToString();
                        TbObservacionesAut.Text = PwdRqst.AuthDesc;
                    }
                    else if (PwdRqst.Auth2Date != null)
                    {
                        //TbUsuarioAut.Text = PwdRqst.Auth2Usr.Fullname;
                        TbFechaAut.Text = PwdRqst.Auth2Date.ToString();
                        TbObservacionesAut.Text = PwdRqst.AuthDesc;
                    }
                    LInFechaSol.Text = PwdRqst.RequestDate.ToString();
                    LInEstado.Text = PwdRqst.State;
                    if (PwdRqst.RqstState.Id == 2)
                    {
                        btnViewPwd.Visible = true;
                    }
                    else if (PwdRqst.RqstState.Id == 4)
                    {
                        btnViewPwd.Visible = false;
                        TbContrasenia.Text = new CCryptMgr().decryptAndClearBadChars(((PasswordRequestEntity)Session["PwdRqst"]).UserPassword.Password);
                    }
                    else
                        btnViewPwd.Visible = false;
                }
            }
        }

        protected void Bcancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("authforme.aspx");
            }
            catch (ThreadAbortException tae)
            {
            }
        }

        protected void btnViewPwd_Click(object sender, EventArgs e)
        {
            VisualizarPassword();
        }

        private void VisualizarPassword()
        {
            PasswordRequestBusiness PwdRqstBL = new PasswordRequestBusiness();
            if (PwdRqstBL.ViewPwdRqst((PasswordRequestEntity)Session["PwdRqst"]))
            {
                //TbContrasenia.Text = new WinLocalUserBusiness().DecryptPassword(((PasswordRequestEntity)Session["PwdRqst"]).UserPassword.Password);
                TbContrasenia.Text = new CCryptMgr().decryptAndClearBadChars(((PasswordRequestEntity)Session["PwdRqst"]).UserPassword.Password);
                btnViewPwd.Visible = false;
            }
            else
            {
                Session["phxMsgError"] = 1;
                Session["phxMessage"] = "Error en la aplicación";
                try
                {
                    Response.Redirect("Message.aspx");
                    return;
                }
                catch (ThreadAbortException tae)
                {
                }
            }
        }

    }
}