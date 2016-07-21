using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using Phalanx.Util;
using PhalanxMAL;

namespace PhalanxBL
{
    public class PasswordRequestBusiness
    {
        /// <summary>
        /// Crea la solicitud de password poniendo en estado pendiente y asignando los autorizadores
        /// </summary>
        /// <param name="PasswordRequest"></param>
        /// <param name="PhxUsrRqst"></param>
        /// <returns></returns>
        public int CreateRequest(PasswordRequestEntity PasswordRequest) //, PhxUserEntity PhxUsrRqst)
        {
            /*
            PhxUserEntity SelAuth = new DemoConfBusiness().GetPwdRqstAuth();
            if (SelAuth == null)
            {
                return 0;
            }*/

            /*
            // buscar los autorizadores
            PhxUserEntityCollection Autorizadores = new RequestsGroupsFactory().GetRqstAuths(PasswordRequest); //, PhxUsrRqst);
            if (Autorizadores.Count == 0)
            {
                return 0;
            }
            PasswordRequest.Auth1Usr = Autorizadores[0];
            if (Autorizadores.Count > 1)
            {
                PasswordRequest.Auth2Usr = Autorizadores[1];
            }*/
            //PasswordRequest.Auth1Usr = SelAuth;
            // busca el obj Request State correspondiente al Estado que tiene que pasar
            RequestStatesFactory RSF = new RequestStatesFactory();
            RequestStateEntity objRS = RSF.GetRqstStateByID((int)PhxDALUtil.RequestStates.Pending);
            if (objRS == null)
            {
                return 0;
            }
            PasswordRequest.RqstState = objRS;

            //return new PasswordsRequestsFactory().Save(PasswordRequest);
            PasswordsRequestsFactory PwdRqstF = new PasswordsRequestsFactory();
            int PwdRqstId = PwdRqstF.CreatePwdRqst(PasswordRequest);
            if (PwdRqstId > 0)
            {
                MailAlertBusiness MailToSendBL = new MailAlertBusiness();
                MailToSendBL.CreateRqstPwdMail(PasswordRequest);
            }
            else
            { return 0; }
            return PwdRqstId;
        }
        public PasswordRequestEntityCollection GetPassRqstByPhxUsr(PhxUserEntity PhxUser)
        {
            return new PasswordsRequestsFactory().GetPassRqstByPhxUsr(PhxUser);
        }

        public PasswordRequestEntityCollection GetPassRqstToGetBackByPhxUsr(PhxUserEntity PhxUser)
        {
            return new PasswordsRequestsFactory().GetPassRqstToGetBackByPhxUsr(PhxUser);
        }

        public PasswordRequestEntityCollection GetPassRqst(UserEntity User, ArrayList arrayStates, string NumeroSolicitud, ArrayList arrayGroups)
        {
            return new PasswordsRequestsFactory().GetPassRqst(User, arrayStates, NumeroSolicitud, arrayGroups);
        }

        public PasswordRequestEntityCollection GetPassRqstByState(ArrayList states, ArrayList groups)
        {
            return new PasswordsRequestsFactory().GetPassRqstByState(states, groups);
        }

        /// <summary>
        /// Devuelve las solicitudes de contraseña ya devueltas, para su cierre
        /// </summary>
        /// <param name="PhxUsrId">Id del usuario autorizador responsable de la aprobación de la solicitud</param>
        /// <returns>Devuelve la lista de solicitudes de Contraseña. Si no hay datos devuelve null</returns>
        public PasswordRequestEntityCollection GetPassRqstToCloseByPhxUsr(PhxUserEntity PhxUser)
        {
            return new PasswordsRequestsFactory().GetPassRqstToCloseByPhxUsr(PhxUser);
        }
        /// <summary>
        /// Devuelve las solicitudes de contraseñas en estado expiradas
        /// </summary>
        /// <returns></returns>
        public PasswordRequestEntityCollection GetExpiredPassRqstToClose()
        {
            return new PasswordsRequestsFactory().GetExpiredPassRqstToClose();
        }
        public PasswordRequestEntityCollection GetExpiredPassRqstToClose(PhxUserEntity PhxUser)
        {
            return new PasswordsRequestsFactory().GetExpiredPassRqstToClose(PhxUser);
        }

        public PasswordRequestEntity Load(int Id)
        {
            return new PasswordsRequestsFactory().Load(Id);
        }

        public bool ViewPwdRqst(PasswordRequestEntity PwdRqst)
        {
            return new PasswordsRequestsFactory().ViewPwdRqst(PwdRqst);
        }
        public PasswordRequestEntityCollection GetRequestsToAuthByAuth(PhxUserEntity Auth)
        {
            return new PasswordsRequestsFactory().GetRequestsToAuthByAuth(Auth);
        }

        public bool AcceptWinPwdRqst(PasswordRequestEntity WinPwdRqst, PhxUserEntity Autorizador,
            string ObsAuth, string TimeGiven, string UnitGiven)
        {
            PasswordsRequestsFactory PwdRqstF = new PasswordsRequestsFactory();
            PasswordRequestEntity PwdRqstE = PwdRqstF.AcceptWinPwdRqst(WinPwdRqst, Autorizador, ObsAuth, TimeGiven, UnitGiven);
            if (PwdRqstE != null)
            {
                // crea el mail de respuesta de solicitud
                MailAlertBusiness MailToSendBL = new MailAlertBusiness();
                MailToSendBL.CreateRespRqstPwdMail(PwdRqstE);
            }
            else
            { return false; }
            return true;

        }
        public bool RejectWinPwdRqst(PasswordRequestEntity WinPwdRqst, PhxUserEntity Autorizador,
            string ObsAuth)
        {
            PasswordsRequestsFactory PwdRqstF = new PasswordsRequestsFactory();
            PasswordRequestEntity PwdRqstE = PwdRqstF.RejectWinPwdRqst(WinPwdRqst, Autorizador, ObsAuth);
            if (PwdRqstE != null)
            {
                // crea el mail de respuesta de solicitud
                MailAlertBusiness MailToSendBL = new MailAlertBusiness();
                MailToSendBL.CreateRespRqstPwdMail(PwdRqstE);
            }
            else
            { return false; }
            return true;

        }

        /// <summary>
        /// Mediante este método se devolverá una contraseña ya visualizada o expirada
        /// </summary>
        /// <param name="pwdRequest">Contraseña a devolver</param>
        /// <param name="newResquestState">Nuevo estado de la contraseña</param>
        /// <param name="note">Nota relativa a la devolución</param>
        /// <returns>Devolverá true si la devolución se efectuó exitosamente, sino devolverá false</returns>
        public uint GetRequestPwdBack(PasswordRequestEntity pwdRequest, int newResquestState, string note)
        {
            return new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, newResquestState, note, -1);
        }
        public uint GetRequestPwdBack(PasswordRequestEntity pwdRequest, int newResquestState, string note, int IdUsrDevol)
        {
            return new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, newResquestState, note, IdUsrDevol);
        }

        /// <summary>
        /// Mediante este método se devolverá una contraseña ya visualizada o expirada
        /// </summary>
        /// <param name="pwdRequest">Contraseña a devolver</param>
        /// <param name="newResquestState">Nuevo estado de la contraseña</param>
        /// <param name="note">Nota relativa a la devolución</param>
        /// <param name="administrador">Usuario que devolvió la contraseña</param>
        /// <returns>Devolverá true si la devolución se efectuó exitosamente, sino devolverá false</returns>
        public uint GetRequestPwdBack(PasswordRequestEntity pwdRequest, int newResquestState, string note, PhxUserEntity administrador)
        { 
            bool DisableUser = false;
            /// si es contraseña de ATM hay que desactivarla cuando se devuelve por el usuario y la solicitud se cierra.
            /// Queda pendiente ver si también pasa lo mismo con la expiración
            uint RtdoDevolucion;
            if (newResquestState == 8 && pwdRequest.User is ATMUserEntity) // devuelta por el usuario
            {
                DisableUser = true;
                RtdoDevolucion = new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, newResquestState, note, administrador.Id, DisableUser);
                newResquestState = 11; // PhxDALUtil.RequestStates.Closed;

                uint result = this.CloseRequestPwd(pwdRequest, "Cierre automático", administrador.Id, false);
                RtdoDevolucion = new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, newResquestState, note, administrador.Id, DisableUser);
            }
            else
            {
                RtdoDevolucion = new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, newResquestState, note, administrador.Id, DisableUser);
            }
            if (pwdRequest.User.Critical)
            {
                pwdRequest = new PasswordsRequestsFactory().Load(pwdRequest.Id);
                new MailAlertBusiness().CreateDevRqstPwdMail(pwdRequest);
            }

            return RtdoDevolucion;
        }

        /// <summary>
        /// Mediante este método se cerrará una solicitud de contraseña ya devuelta
        /// </summary>
        /// <param name="pwdRequest">Solicitud de contraseña a cerrar</param>
        /// <param name="note">Nota relativa al cierre</param>
        /// <param name="DisableUser">Bool que indica si se debe desactivar el usuario</param>
        /// <returns>Devolverá un 0 si el cierre se efectuó exitosamente, sino devolverá otro valor</returns>
        public uint CloseRequestPwd(PasswordRequestEntity pwdRequest, string note, int authUserId, bool disableUser)
        {
            return new PasswordsRequestsFactory().CloseRequestPwd(pwdRequest.Id, 11, note, authUserId, disableUser);
        }

         

        /// <summary>
        /// Busca la solicitud por la cual una contraseña no concurrente está en uso
        /// </summary>
        /// <param name="UserPassword">Contraseña para la que se busca la solicitud</param>
        /// <returns>Devuelve la solicitud. Si hay mas de una o no hay o la contraseña
        /// no es concurrente o no está en uso devuelve null</returns>
        public PasswordRequestEntity GetRequestForPwdInUse(UserPasswordEntity UserPassword)
        {
            /// la contraseña no es concurrente o no está en uso 
            if (!UserPassword.Concurrent || UserPassword.PwdLockType == null ||
                UserPassword.PwdLockType != new PwdLockTypesFactory().GetInUseType())
            {
                return null;
            }
            PasswordRequestEntityCollection PwdRqstEC = new PasswordsRequestsFactory().GetRequestsForPwdInUse(UserPassword);
            if (PwdRqstEC.Count != 1)
            {
                return null;
            }
            else
            {
                return PwdRqstEC[0];
            }
        }

        public PasswordRequestEntityCollection GetRequestCriticalPwd(DateTime fechaDesde, DateTime fechaHasta, bool orderByFecha)
        {
            return new PasswordsRequestsFactory().GetCriticalPassRqstList(fechaDesde, fechaHasta, orderByFecha);
        }

        public void ProcessPwdRqstExpiration()
        {
            PasswordsRequestsFactory PRF = new PasswordsRequestsFactory();
            PasswordRequestEntityCollection PwdRqstExpired = PRF.ProcessPwdRqstExp();

            /*
            // mandar mails
            ExpirationRqstMail ExpRqstMail = new ExpirationRqstMail();
            PhxConfigFactory ConfigFac = new PhxConfigFactory();
            ExpRqstMail.AdminMails = ConfigFac.GetConfigParam("@ADM_MAIL_GRP@").ShortTxtValue;
            ExpRqstMail.FromEmail = ConfigFac.GetConfigParam("@FROM_EXP_MAILS@").ShortTxtValue;
            ExpRqstMail.EmailSubject = ConfigFac.GetConfigParam("@SUBJECT_EXP_MAILS@").ShortTxtValue;
            ExpRqstMail.EmailBody = ConfigFac.GetConfigParam("@BODY_EXP_MAILS@").LongTxtValue;
            ExpRqstMail.SMTPName = ConfigFac.GetConfigParam("@SMTP_EXP_MAILS@").ShortTxtValue;
            */
            // mandar mail
            MailAlertBusiness MAB = new MailAlertBusiness();
            foreach (PasswordRequestEntity PwdRqstE in PwdRqstExpired)
            {
                MAB.CreateExpRqstPwdMail(PwdRqstE);
                /*
                try
                {
                    ExpRqstMail.SendMail(PwdRqstE);
                }
                catch (Exception e)
                {
                }*/
            }
        }
         



        public uint ReturnRequestPwdByAdmin(PasswordRequestEntity pwdRequest, string note, int authUserId)

        
        
        
        {
            return new PasswordsRequestsFactory().GetRequestPwdBack(pwdRequest.Id, (int)PhxDALUtil.RequestStates.ReturnedByAdmin, note, authUserId, true);
        }


        public PasswordRequestEntityCollection GetPassRqstByState(ArrayList states, string IdPwdRqst, ArrayList groups)
        {
            return this.GetPassRqstByState(states, IdPwdRqst, groups, false);
        }
        public PasswordRequestEntityCollection GetPassRqstByState(ArrayList states, string IdPwdRqst, ArrayList groups, bool LoadChangePostReturn)
        {
            PasswordRequestEntityCollection PwdReqEC = new PasswordRequestEntityCollection();
            if (IdPwdRqst == "")
            {
                PwdReqEC = this.GetPassRqstByState(states, groups);
            }
            else
            {
                PasswordsRequestsFactory RqstF = new PasswordsRequestsFactory();
                RqstF.FilPwdRqst = Convert.ToInt32(IdPwdRqst);
                PwdReqEC = RqstF.GetPassRqstByState(states, groups);
            }
            if (LoadChangePostReturn)
            {
                for (int i = 0; i < PwdReqEC.Count; i++)
                {
                    HistPasswordChangeBusiness HPCBL = new HistPasswordChangeBusiness();
                    /// puede que no haya sido devuelto todavia, ahi no se carga el cambio post devolucion
                    if (PwdReqEC[i].ReturnDate != null)
                    {
                        DateTime? ClosingDate = null;
                        if (PwdReqEC[i].CloseDate != null && PwdReqEC[i].CloseDate.HasValue)
                        { ClosingDate = PwdReqEC[i].CloseDate.Value; }
                        PwdReqEC[i].ChangePostReturn = HPCBL.GetChangePostReturn(PwdReqEC[i].User.Id, PwdReqEC[i].ReturnDate.Value, ClosingDate);
                    }
                    /// indica que se buscó el cambio
                    PwdReqEC[i].CambioLoaded = true;
                }
            }
            return PwdReqEC;
        }
        public bool IsAbleToClose(PasswordRequestEntity pwdRequest, PhxUserEntity Auth)
        {
            if (pwdRequest.RqstState.Id == (int)PhxDALUtil.RequestStates.ReturnedByAdmin
                || pwdRequest.RqstState.Id == (int)PhxDALUtil.RequestStates.ReturnedByUser)
            {
                return this.IsAbleToPwdRstFollowup(pwdRequest, Auth);
            }
            else
            {
                return false;
            }
        }
        public bool IsAbleToReturnByExpiration(PasswordRequestEntity pwdRequest, PhxUserEntity Auth)
        {
            if (pwdRequest.RqstState.Id == (int)PhxDALUtil.RequestStates.Expired)
            {
                return this.IsAbleToPwdRstFollowup(pwdRequest, Auth);
            }
            else
            {
                return false;
            }
        }
        private bool IsAbleToPwdRstFollowup(PasswordRequestEntity pwdRequest, PhxUserEntity Auth)
        {
            return new PasswordsRequestsFactory().IsAbleToPwdRqstFollowup(pwdRequest, Auth);
        }

        public SolicitudPwdEntityCollection GetAll()
        {
            return new PasswordsRequestsFactory().GetAllPwdRqstForRpt();
        }
    }

}
