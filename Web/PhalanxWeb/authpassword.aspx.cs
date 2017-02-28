using PhalanxBL;
using PhalanxCommon.Entities;
using System;
using System.Threading;
using System.Web.UI;

namespace PhalanxWeb
{
    public partial class authpassword : System.Web.UI.Page
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
                if (IdentUser != null && PhxUsrBL.ChkAuthPwdRequest(IdentUser) &&
                    Page.Request["prid"] != null)
                {
                    PasswordRequestEntity passWord = new PasswordRequestBusiness().Load(Convert.ToInt32(Page.Request["prid"]));

                    if ((passWord.UserPassword.PwdLockType.Id == 4) && (!passWord.UserPassword.Concurrent))
                    {
                        string userNameMsg = "La contraseña está en uso y no es concurrente";
                        foreach (PasswordRequestEntity pwdReqEntity in passWord.UserPassword.PasswordsRequestsList)
                        {
                            if (pwdReqEntity.Id != passWord.Id)
                            {
                                userNameMsg = "La contraseña está en uso por el usuario " + pwdReqEntity.RqstUser.Fullname + " y no es concurrente";
                                break;
                            }
                        }
                        Session["phxMsgError"] = 2;
                        Session["phxMessage"] = userNameMsg;
                        Session["phxButtonBack"] = "authorization.aspx";
                        Response.Redirect("Message.aspx");
                    }
                    if ((passWord.UserPassword.PwdLockType.Id != 4) && (!passWord.UserPassword.Concurrent))
                    {
                        bool haySolPendientes = false;
                        string userNameMsg = "La contraseña solicitada es no concurrente y hay otras solicitudes para la misma, pendientes de autorizar<br>" +
                         "Solicitudes pendientes de:<br>";
                        foreach (PasswordRequestEntity pwdReqEntity in passWord.UserPassword.PasswordsRequestsList)
                        {
                            if ((pwdReqEntity.Id != passWord.Id) && (pwdReqEntity.RqstState.Id == 1)) //Estado Solicitada
                            {
                                userNameMsg += "- <a href='authpassword.aspx?prid=" + pwdReqEntity.Id + "'>" + pwdReqEntity.RqstUser.Fullname + " (" + pwdReqEntity.RequestDate.ToString() + ")</a><br>";
                                haySolPendientes = true;
                            }
                        }
                        if (haySolPendientes)
                        {
                            InformationImage.Visible = true;
                            LabelInfo.Visible = true;
                            LabelInfo.Text = userNameMsg;
                        }
                    }

                    Session["PwdRqst"] = passWord;


                }
                else
                {
                    try
                    {
                        Response.Redirect("noAutho.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                        internalError = true;
                    }
                }

                if (!internalError)
                {

                    Session["CtrlUser"] = "Usuario: " + (string)Session["phxWinUser"];


                    PasswordRequestEntity PwdRqst = (PasswordRequestEntity)Session["PwdRqst"];
                    // muestro todos los datos
                    TbUsuarioSolicitado.Text = PwdRqst.UserName;
                    TbDesc.Text = PwdRqst.RequestDesc;

                    if (PwdRqst.UserPassword.UsersList[0] is WinLocalUserEntity)
                    {
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de Windows";
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
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de Unix - Linux";
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
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de AS400";
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
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de Base de Datos";
                        TbServerSolic.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.PCName;
                        //TbServerSolic.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.ServerName;
                        LAux1.Text = "Tipo de Base de Datos";
                        TbAux1.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.Type.Name;
                        LAux2.Text = "Base de Datos";
                        TbAux2.Text = ((DatabaseUserEntity)PwdRqst.UserPassword.UsersList[0]).Db.Name;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is ApplicationUserEntity)
                    {
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de Aplicativos";
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
                        /*las siguientes lineas ocultar la información adicional (pedido en v.14)*/
                        LAux1.Visible = false;
                        TbAux1.Visible = false;
                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;


                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is CommunicationDeviceUserEntity)
                    {
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de Equipos de Comunicación";

                        LServidor.Text = "Equipo";
                        TbServerSolic.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDevice.Name;
                        LAux1.Text = "Tipo";
                        TbAux1.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDevice.Type.Name;
                        LAux2.Text = "IP";
                        TbAux2.Text = ((CommunicationDeviceUserEntity)PwdRqst.UserPassword.UsersList[0]).CommunicationDevice.IP;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }
                    else if (PwdRqst.UserPassword.UsersList[0] is ATMUserEntity)
                    {
                        Session["CtrlTitle"] = "Autorización de Solicitud de Contraseña de ATMs";

                        LServidor.Text = "ATM";
                        TbServerSolic.Text = ((ATMUserEntity)PwdRqst.UserPassword.UsersList[0]).ATMName;
                        LAux1.Visible = false;
                        TbAux1.Visible = false;
                        LAux2.Visible = false;
                        TbAux2.Visible = false;
                        LAux3.Visible = false;
                        TbAux3.Visible = false;
                    }

                    LInFechaSol.Text = PwdRqst.RequestDate.ToString();
                    LInUsuario.Text = PwdRqst.RqstUsrFullName;
                    tbTiempoSolicitado.Text = PwdRqst.HoursRequested.ToString() +
                        (PwdRqst.UnitRequested == "H" ? " horas" : " días");

                }


                BAprobar.Attributes.Add("onclick", "this.disabled = true; this.value = 'Procesando...'; " + BRechazar.ClientID + ".disabled = true;" + Bcancel.ClientID + ".disabled = true;");
                BRechazar.Attributes.Add("onclick", "this.disabled = true; this.value = 'Procesando...'; " + BAprobar.ClientID + ".disabled = true;" + Bcancel.ClientID + ".disabled = true;");

            }
        }

        protected void Bcancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("authorization.aspx");
            }
            catch (ThreadAbortException tae)
            {
            }

        }

        protected void BAprobar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }

            Session["phxButtonBack"] = "default.aspx";
            try
            {
                PhxUserEntity Autorizador = (PhxUserEntity)Session["PhxUser"];
                PasswordRequestBusiness PwdRqstBL = new PasswordRequestBusiness();
                PasswordRequestEntity WinPwdRqst = (PasswordRequestEntity)Session["PwdRqst"];
                if (PwdRqstBL.AcceptWinPwdRqst(WinPwdRqst, Autorizador, TbObservaciones.Text.Trim(),
                    txtHsGiven.Text, cbUnitGiven.SelectedValue))
                {
                    Session["phxMsgError"] = 0;
                    Session["phxMessage"] = "Se ha Aprobado la Solicitud";
                    try
                    {
                        Response.Redirect("message.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                        return;
                    }

                    //Server.Transfer("message.aspx");
                }
                else
                {
                    Session["phxMsgError"] = 1;
                    Session["phxMessage"] = "Error al aprobar la solicitud";
                    try
                    {
                        Response.Redirect("message.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                        return;
                    }

                }
            }
            catch (ThreadAbortException tae)
            {
            }
            catch (Exception ex)
            {
                Session["phxMsgError"] = 1;
                Session["phxMessage"] = "Error al aprobar la solicitud";
                try
                {
                    Response.Redirect("message.aspx");
                }
                catch (ThreadAbortException tae)
                {
                }
            }
        }

        protected void BRechazar_Click(object sender, EventArgs e)
        {
            Page.Validate("ValidaTodo");
            if (!Page.IsValid)
            {
                return;
            }
            Session["phxButtonBack"] = "default.aspx";
            try
            {
                PhxUserEntity Autorizador = (PhxUserEntity)Session["PhxUser"];
                //Session["PhxUser"] = null;
                PasswordRequestBusiness PwdRqstBL = new PasswordRequestBusiness();
                PasswordRequestEntity WinPwdRqst = (PasswordRequestEntity)Session["PwdRqst"];
                if (PwdRqstBL.RejectWinPwdRqst(WinPwdRqst, Autorizador, TbObservaciones.Text.Trim()))
                {
                    Session["phxMsgError"] = 0;
                    Session["phxMessage"] = "Se ha Rechazado la Solicitud";
                    try
                    {
                        Response.Redirect("message.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                        return;
                    }

                    //Server.Transfer("message.aspx");
                }
                else
                {
                    Session["phxMsgError"] = 1;
                    Session["phxMessage"] = "Error al rechazar la solicitud";
                    try
                    {
                        Response.Redirect("message.aspx");
                    }
                    catch (ThreadAbortException tae)
                    {
                        return;
                    }

                }
            }
            catch (ThreadAbortException tae)
            {
            }
            catch (Exception ex)
            {
                Session["phxMsgError"] = 1;
                Session["phxMessage"] = "Error al rechazar la solicitud";
                try
                {
                    Response.Redirect("message.aspx");
                }
                catch (ThreadAbortException tae)
                {
                }
            }

        }
    }
}