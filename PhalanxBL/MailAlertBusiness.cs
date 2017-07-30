using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using PhalanxMAL;
using System.Net.Mail;
using System.Reflection;

namespace PhalanxBL
{
    public class MailAlertBusiness
    {
        private MailTypeEntity _filMailType;
        private Nullable<bool> _filSentMail; // indica si se filtra por mails enviados o no enviados


        public MailTypeEntity FilMailType
        {
            set { _filMailType = value; }
        }
        public Nullable<bool> FilSentMail
        {
            set
            {
                _filSentMail = value;
            }
        }

        public MailAlertBusiness()
        {
        }


        public void CreateVencPwdAppMail(ApplicationUserEntity appUsr, int diasrestantes)
        {
            string MailBody = "";
            string MailSubject = "";
            string AuthGroupMail = "";

            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.VencimientoPwdApp);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                //MailToSend.ToName = appUsr.Username;
                //MailToSend.ToAddress = 

                //Obtengo grupo de seguimiento
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection SeguimientoEC = new PhxUserEntityCollection();
                SeguimientoEC = PhxUsrBL.GetAllFollowPwdRqstAuth(appUsr.UserPassword);

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                if (SeguimientoEC.Count == 0)
                {
                    /// si por algun motivo no se encuentran autorizadores se envia a la direccion
                    /// de mail del grupo de administradores
                    AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                }
                else
                {
                    //Agrego CC
                    foreach (PhxUserEntity entityUser in SeguimientoEC)
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));
                }

                MailBody = ReplaceVencPwdAppTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyVencPwdAppMails).LongTxtValue, appUsr.Id.ToString(), appUsr.ApplicationName, appUsr.Username, diasrestantes);
                MailSubject = ReplaceVencPwdAppTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectVencPwdAppMails).ShortTxtValue, appUsr.Id.ToString(), appUsr.ApplicationName, appUsr.Username, diasrestantes);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }

            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }

        public void CreatePwdAppExpMail(ApplicationUserEntity appUsr, int diasrestantes)
        {
            string MailBody = "";
            string MailSubject = "";
            string AuthGroupMail = "";

            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.PwdAppExpiradas);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                //MailToSend.ToName = appUsr.Username;
                //MailToSend.ToAddress = 

                //Obtengo grupo de seguimiento
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection SeguimientoEC = new PhxUserEntityCollection();
                SeguimientoEC = PhxUsrBL.GetAllFollowPwdRqstAuth(appUsr.UserPassword);

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                if (SeguimientoEC.Count == 0)
                {
                    /// si por algun motivo no se encuentran autorizadores se envia a la direccion
                    /// de mail del grupo de administradores
                    AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                }
                else
                {
                    //Agrego CC
                    foreach (PhxUserEntity entityUser in SeguimientoEC)
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));
                }

                MailBody = ReplaceVencPwdAppTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyPwdAppMailsExp).LongTxtValue, appUsr.Id.ToString(), appUsr.ApplicationName, appUsr.Username, diasrestantes);
                MailSubject = ReplaceVencPwdAppTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectPwdAppMailsExp).ShortTxtValue, appUsr.Id.ToString(), appUsr.ApplicationName, appUsr.Username, diasrestantes);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }

            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }

        public void CreateRqstPwdMail(PasswordRequestEntity PasswordRequest)
        {

            string RqstUserName = "";
            string RqstUserMail = "";
            string SuperiorName = "";
            string SuperiorMail = "";
            string AuthGroupName = "";
            string AuthGroupMail = "";
            string MailBody = "";
            string MailSubject = "";
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.PwdRqst);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();
                RqstUserName = PasswordRequest.RqstUser.Fullname;
                RqstUserMail = PasswordRequest.RqstUser.Email;
                AuthGroupName = "";

                /// v3.4: se deben buscar los mails de los que hagan seguimiento de solic de esta pwd
                /// en lugar de enviar a la casilla de administradores. Que pasa si no administradores
                /// asignados? dejo la casilla del grupo.

                // busco los admin que hacen seguim de esa pwd
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection AutorizadoresEC = new PhxUserEntityCollection();
                AutorizadoresEC = PhxUsrBL.GetAllFollowPwdRqstAuth(PasswordRequest.UserPassword);

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                if (AutorizadoresEC.Count == 0)
                {
                    /// si por algun motivo no se encuentran autorizadores se envia a la direccion
                    /// de mail del grupo de administradores
                    //AutorizadoresEC = PhxUsrBL.GetAllAuth();
                    AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;
                }
                else
                {
                }
                // si hay superior se envía el mail al superior con copia a los admins y al solicitante
                if (PasswordRequest.RqstUser.PhxUserSuperior != null && PasswordRequest.RqstUser.PhxUserSuperior.Id != 0)
                {
                    SuperiorName = PasswordRequest.RqstUser.PhxUserSuperior.Name;
                    SuperiorMail = PasswordRequest.RqstUser.PhxUserSuperior.Mail;
                    MailToSend.ToName = SuperiorName;
                    MailToSend.ToAddress = SuperiorMail;
                    //MailToSend.Cc1Address = AuthGroupMail;
                    //MailToSend.Cc2Name = RqstUserName;
                    //MailToSend.Cc2Address = RqstUserMail;


                    //MailToSend.Cc1Name = RqstUserName;
                    //MailToSend.Cc1Address = RqstUserMail;
                    //Agrego CC
                    //Agrego CC
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(RqstUserName, RqstUserMail, MailToSend));

                    if (AutorizadoresEC.Count == 0)
                    {
                        //MailToSend.Cc2Address = AuthGroupMail;
                        //Agrego CC
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                    }
                    else
                    {
                        //Agrego CC
                        foreach (PhxUserEntity entityUser in AutorizadoresEC)
                            MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));

                        //int cant = AutorizadoresEC.Count;
                        //if (cant >= 1)
                        //{
                        //    MailToSend.Cc2Name = AutorizadoresEC[0].Fullname;
                        //    MailToSend.Cc2Address = AutorizadoresEC[0].Email;
                        //}
                        //if (cant >= 2)
                        //{
                        //    MailToSend.Cc3Name = AutorizadoresEC[1].Fullname;
                        //    MailToSend.Cc3Address = AutorizadoresEC[1].Email;
                        //}
                        //if (cant >= 3)
                        //{
                        //    MailToSend.Cc4Name = AutorizadoresEC[2].Fullname;
                        //    MailToSend.Cc4Address = AutorizadoresEC[2].Email;
                        //}
                        //if (cant >= 4)
                        //{
                        //    MailToSend.Cc5Name = AutorizadoresEC[3].Fullname;
                        //    MailToSend.Cc5Address = AutorizadoresEC[3].Email;
                        //}
                        //if (cant >= 5)
                        //{
                        //    MailToSend.Cc6Name = AutorizadoresEC[4].Fullname;
                        //    MailToSend.Cc6Address = AutorizadoresEC[4].Email;
                        //}
                        //if (cant >= 6)
                        //{
                        //    MailToSend.Cc7Name = AutorizadoresEC[5].Fullname;
                        //    MailToSend.Cc7Address = AutorizadoresEC[5].Email;
                        //}
                        //if (cant >= 7)
                        //{
                        //    MailToSend.Cc8Name = AutorizadoresEC[6].Fullname;
                        //    MailToSend.Cc8Address = AutorizadoresEC[6].Email;
                        //}
                        //if (cant >= 8)
                        //{
                        //    MailToSend.Cc9Name = AutorizadoresEC[7].Fullname;
                        //    MailToSend.Cc9Address = AutorizadoresEC[7].Email;
                        //}
                        //if (cant >= 9)
                        //{
                        //    MailToSend.Cc10Name = AutorizadoresEC[8].Fullname;
                        //    MailToSend.Cc10Address = AutorizadoresEC[8].Email;
                        //}
                        //if (cant >= 10)
                        //{
                        //    MailToSend.Cc11Name = AutorizadoresEC[9].Fullname;
                        //    MailToSend.Cc11Address = AutorizadoresEC[9].Email;
                        //}
                    }
                }
                else
                {
                    /// si no hay superior y no se encuentran seguidores se envía mail solo a los admins (pre v3.4)
                    /// v. 3.4: se envia a los del grupo de seguimiento
                    if (AutorizadoresEC.Count == 0)
                    {
                        //MailToSend.ToAddress = AuthGroupMail;
                        //Agrego CC
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                    }
                    else
                    {
                        //Agrego CC
                        foreach (PhxUserEntity entityUser in AutorizadoresEC)
                            MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));

                        //int cant = AutorizadoresEC.Count;
                        //if (cant >= 1)
                        //{
                        //    MailToSend.ToName = AutorizadoresEC[0].Fullname;
                        //    MailToSend.ToAddress = AutorizadoresEC[0].Email;
                        //}
                        //if (cant >= 2)
                        //{
                        //    MailToSend.Cc1Name = AutorizadoresEC[1].Fullname;
                        //    MailToSend.Cc1Address = AutorizadoresEC[1].Email;
                        //}
                        //if (cant >= 3)
                        //{
                        //    MailToSend.Cc2Name = AutorizadoresEC[2].Fullname;
                        //    MailToSend.Cc2Address = AutorizadoresEC[2].Email;
                        //}
                        //if (cant >= 4)
                        //{
                        //    MailToSend.Cc3Name = AutorizadoresEC[3].Fullname;
                        //    MailToSend.Cc3Address = AutorizadoresEC[3].Email;
                        //}
                        //if (cant >= 5)
                        //{
                        //    MailToSend.Cc4Name = AutorizadoresEC[4].Fullname;
                        //    MailToSend.Cc4Address = AutorizadoresEC[4].Email;
                        //}
                        //if (cant >= 6)
                        //{
                        //    MailToSend.Cc5Name = AutorizadoresEC[5].Fullname;
                        //    MailToSend.Cc5Address = AutorizadoresEC[5].Email;
                        //}
                        //if (cant >= 7)
                        //{
                        //    MailToSend.Cc6Name = AutorizadoresEC[6].Fullname;
                        //    MailToSend.Cc6Address = AutorizadoresEC[6].Email;
                        //}
                        //if (cant >= 8)
                        //{
                        //    MailToSend.Cc7Name = AutorizadoresEC[7].Fullname;
                        //    MailToSend.Cc7Address = AutorizadoresEC[7].Email;
                        //}
                        //if (cant >= 9)
                        //{
                        //    MailToSend.Cc8Name = AutorizadoresEC[8].Fullname;
                        //    MailToSend.Cc8Address = AutorizadoresEC[8].Email;
                        //}
                        //if (cant >= 10)
                        //{
                        //    MailToSend.Cc9Name = AutorizadoresEC[9].Fullname;
                        //    MailToSend.Cc9Address = AutorizadoresEC[9].Email;
                        //}
                    }
                }
                MailBody = ReplacePwdRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodySolicPwdMails).LongTxtValue, PasswordRequest);
                MailSubject = ReplacePwdRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectPwdRqstMails).ShortTxtValue, PasswordRequest);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }
                //MailToSend.Subject =
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }
        public void CreateExpRqstPwdMail(PasswordRequestEntity PasswordRequest)
        {

            string RqstUserName = "";
            string RqstUserMail = "";
            string SuperiorName = "";
            string SuperiorMail = "";
            string AuthGroupName = "";
            string AuthGroupMail = "";
            string MailBody = "";
            string MailSubject = "";
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.RqstExpiration);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();
                RqstUserName = PasswordRequest.RqstUser.Fullname;
                RqstUserMail = PasswordRequest.RqstUser.Email;
                AuthGroupName = "";
                AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;
                MailToSend.ToName = RqstUserName;
                MailToSend.ToAddress = RqstUserMail;

                /// busca los mails de los designados en los grupos de seguimiento de la contraseña
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection AutorizadoresEC = new PhxUserEntityCollection();
                AutorizadoresEC = PhxUsrBL.GetAllFollowPwdRqstAuth(PasswordRequest.UserPassword);

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                /// si no hay administradores en los grupos de seguimiento se asigna la casilla del grupo por defecto
                if (AutorizadoresEC.Count == 0)
                {
                    //MailToSend.Cc1Address = AuthGroupMail;
                    //Agrego CC
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                }
                else
                {
                    //Agrego CC
                    foreach (PhxUserEntity entityUser in AutorizadoresEC)
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));

                    //int cant = AutorizadoresEC.Count;
                    //if (cant >= 1)
                    //{
                    //    MailToSend.Cc1Name = AutorizadoresEC[0].Fullname;
                    //    MailToSend.Cc1Address = AutorizadoresEC[0].Email;
                    //}
                    //if (cant >= 2)
                    //{
                    //    MailToSend.Cc2Name = AutorizadoresEC[1].Fullname;
                    //    MailToSend.Cc2Address = AutorizadoresEC[1].Email;
                    //}
                    //if (cant >= 3)
                    //{
                    //    MailToSend.Cc3Name = AutorizadoresEC[2].Fullname;
                    //    MailToSend.Cc3Address = AutorizadoresEC[2].Email;
                    //}
                    //if (cant >= 4)
                    //{
                    //    MailToSend.Cc4Name = AutorizadoresEC[3].Fullname;
                    //    MailToSend.Cc4Address = AutorizadoresEC[3].Email;
                    //}
                    //if (cant >= 5)
                    //{
                    //    MailToSend.Cc5Name = AutorizadoresEC[4].Fullname;
                    //    MailToSend.Cc5Address = AutorizadoresEC[4].Email;
                    //}
                    //if (cant >= 6)
                    //{
                    //    MailToSend.Cc6Name = AutorizadoresEC[5].Fullname;
                    //    MailToSend.Cc6Address = AutorizadoresEC[5].Email;
                    //}
                    //if (cant >= 7)
                    //{
                    //    MailToSend.Cc7Name = AutorizadoresEC[6].Fullname;
                    //    MailToSend.Cc7Address = AutorizadoresEC[6].Email;
                    //}
                    //if (cant >= 8)
                    //{
                    //    MailToSend.Cc8Name = AutorizadoresEC[7].Fullname;
                    //    MailToSend.Cc8Address = AutorizadoresEC[7].Email;
                    //}
                    //if (cant >= 9)
                    //{
                    //    MailToSend.Cc9Name = AutorizadoresEC[8].Fullname;
                    //    MailToSend.Cc9Address = AutorizadoresEC[8].Email;
                    //}
                    //if (cant >= 10)
                    //{
                    //    MailToSend.Cc10Name = AutorizadoresEC[9].Fullname;
                    //    MailToSend.Cc10Address = AutorizadoresEC[9].Email;
                    //}
                }

                MailBody = ReplaceExpirationRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyExpMails).LongTxtValue, PasswordRequest);
                MailSubject = ReplaceExpirationRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectExpMails).ShortTxtValue, PasswordRequest);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }
                //MailToSend.Subject =
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }
        public void CreateRespRqstPwdMail(PasswordRequestEntity PasswordRequest)
        {

            string RqstUserName = "";
            string RqstUserMail = "";
            string SuperiorName = "";
            string SuperiorMail = "";
            string AuthGroupName = "";
            string AuthGroupMail = "";
            string MailBody = "";
            string MailSubject = "";
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.RespuestaPwdRqst);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();
                RqstUserName = PasswordRequest.RqstUser.Fullname;
                RqstUserMail = PasswordRequest.RqstUser.Email;
                MailToSend.ToName = RqstUserName;
                MailToSend.ToAddress = RqstUserMail;
                AuthGroupName = "";

                // busco los admin que hacen seguim de esa pwd
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection AutorizadoresEC = new PhxUserEntityCollection();
                AutorizadoresEC = PhxUsrBL.GetAllFollowPwdRqstAuth(PasswordRequest.UserPassword);

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                if (AutorizadoresEC.Count == 0)
                {
                    /// si por algun motivo no se encuentran autorizadores se envia a la direccion
                    /// de mail del grupo de administradores
                    //AutorizadoresEC = PhxUsrBL.GetAllAuth();
                    AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;
                }
                else
                {
                }

                //MailToSend.Cc1Address = AuthGroupMail;

                //Agrego CC
                MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));

                // si hay superior se envía el mail al superior con copia a los admins y al solicitante
                if (PasswordRequest.RqstUser.PhxUserSuperior != null && PasswordRequest.RqstUser.PhxUserSuperior.Id != 0)
                {
                    SuperiorName = PasswordRequest.RqstUser.PhxUserSuperior.Name;
                    SuperiorMail = PasswordRequest.RqstUser.PhxUserSuperior.Mail;
                    MailToSend.ToName = SuperiorName;
                    MailToSend.ToAddress = SuperiorMail;
                    //MailToSend.Cc1Address = AuthGroupMail;
                    //MailToSend.Cc2Name = RqstUserName;
                    //MailToSend.Cc2Address = RqstUserMail;

                    //MailToSend.Cc1Name = RqstUserName;
                    //MailToSend.Cc1Address = RqstUserMail;
                    //Agrego CC
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(RqstUserName, RqstUserMail, MailToSend));

                    if (AutorizadoresEC.Count == 0)
                    {
                        //MailToSend.Cc2Address = AuthGroupMail;
                        //Agrego CC
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                    }
                    else
                    {
                        //Agrego CC
                        foreach (PhxUserEntity entityUser in AutorizadoresEC)
                            MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));

                        //int cant = AutorizadoresEC.Count;
                        //if (cant >= 1)
                        //{
                        //    MailToSend.Cc2Name = AutorizadoresEC[0].Fullname;
                        //    MailToSend.Cc2Address = AutorizadoresEC[0].Email;
                        //}
                        //if (cant >= 2)
                        //{
                        //    MailToSend.Cc3Name = AutorizadoresEC[1].Fullname;
                        //    MailToSend.Cc3Address = AutorizadoresEC[1].Email;
                        //}
                        //if (cant >= 3)
                        //{
                        //    MailToSend.Cc4Name = AutorizadoresEC[2].Fullname;
                        //    MailToSend.Cc4Address = AutorizadoresEC[2].Email;
                        //}
                        //if (cant >= 4)
                        //{
                        //    MailToSend.Cc5Name = AutorizadoresEC[3].Fullname;
                        //    MailToSend.Cc5Address = AutorizadoresEC[3].Email;
                        //}
                        //if (cant >= 5)
                        //{
                        //    MailToSend.Cc6Name = AutorizadoresEC[4].Fullname;
                        //    MailToSend.Cc6Address = AutorizadoresEC[4].Email;
                        //}
                        //if (cant >= 6)
                        //{
                        //    MailToSend.Cc7Name = AutorizadoresEC[5].Fullname;
                        //    MailToSend.Cc7Address = AutorizadoresEC[5].Email;
                        //}
                        //if (cant >= 7)
                        //{
                        //    MailToSend.Cc8Name = AutorizadoresEC[6].Fullname;
                        //    MailToSend.Cc8Address = AutorizadoresEC[6].Email;
                        //}
                        //if (cant >= 8)
                        //{
                        //    MailToSend.Cc9Name = AutorizadoresEC[7].Fullname;
                        //    MailToSend.Cc9Address = AutorizadoresEC[7].Email;
                        //}
                        //if (cant >= 9)
                        //{
                        //    MailToSend.Cc10Name = AutorizadoresEC[8].Fullname;
                        //    MailToSend.Cc10Address = AutorizadoresEC[8].Email;
                        //}
                        //if (cant >= 10)
                        //{
                        //    MailToSend.Cc11Name = AutorizadoresEC[9].Fullname;
                        //    MailToSend.Cc11Address = AutorizadoresEC[9].Email;
                        //}
                    }
                }
                else
                {
                    /// si no hay superior y no se encuentran seguidores se envía mail solo a los admins (pre v3.4)
                    /// v. 3.4: se envia a los del grupo de seguimiento
                    if (AutorizadoresEC.Count == 0)
                    {
                        MailToSend.ToAddress = AuthGroupMail;

                        //MailToSend.Cc1Name = RqstUserName;
                        //MailToSend.Cc1Address = RqstUserMail;
                        //Agrego CC
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(RqstUserName, RqstUserMail, MailToSend));
                    }
                    else
                    {
                        MailToSend.ToAddress = RqstUserMail;
                        MailToSend.ToName = RqstUserName;

                        //Agrego CC
                        foreach (PhxUserEntity entityUser in AutorizadoresEC)
                            MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));

                        //int cant = AutorizadoresEC.Count;
                        //if (cant >= 1)
                        //{
                        //    MailToSend.Cc1Name = AutorizadoresEC[0].Fullname;
                        //    MailToSend.Cc1Address = AutorizadoresEC[0].Email;
                        //}
                        //if (cant >= 2)
                        //{
                        //    MailToSend.Cc2Name = AutorizadoresEC[1].Fullname;
                        //    MailToSend.Cc2Address = AutorizadoresEC[1].Email;
                        //}
                        //if (cant >= 3)
                        //{
                        //    MailToSend.Cc3Name = AutorizadoresEC[2].Fullname;
                        //    MailToSend.Cc3Address = AutorizadoresEC[2].Email;
                        //}
                        //if (cant >= 4)
                        //{
                        //    MailToSend.Cc4Name = AutorizadoresEC[3].Fullname;
                        //    MailToSend.Cc4Address = AutorizadoresEC[3].Email;
                        //}
                        //if (cant >= 5)
                        //{
                        //    MailToSend.Cc5Name = AutorizadoresEC[4].Fullname;
                        //    MailToSend.Cc5Address = AutorizadoresEC[4].Email;
                        //}
                        //if (cant >= 6)
                        //{
                        //    MailToSend.Cc6Name = AutorizadoresEC[5].Fullname;
                        //    MailToSend.Cc6Address = AutorizadoresEC[5].Email;
                        //}
                        //if (cant >= 7)
                        //{
                        //    MailToSend.Cc7Name = AutorizadoresEC[6].Fullname;
                        //    MailToSend.Cc7Address = AutorizadoresEC[6].Email;
                        //}
                        //if (cant >= 8)
                        //{
                        //    MailToSend.Cc8Name = AutorizadoresEC[7].Fullname;
                        //    MailToSend.Cc8Address = AutorizadoresEC[7].Email;
                        //}
                        //if (cant >= 9)
                        //{
                        //    MailToSend.Cc9Name = AutorizadoresEC[8].Fullname;
                        //    MailToSend.Cc9Address = AutorizadoresEC[8].Email;
                        //}
                        //if (cant >= 10)
                        //{
                        //    MailToSend.Cc10Name = AutorizadoresEC[9].Fullname;
                        //    MailToSend.Cc10Address = AutorizadoresEC[9].Email;
                        //}
                    }
                }
                MailBody = ReplaceRespPwdRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyRespSolicPwdMails).LongTxtValue, PasswordRequest);
                MailSubject = ReplaceRespPwdRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectRespPwdRqstMails).ShortTxtValue, PasswordRequest);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }
                //MailToSend.Subject =
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }

        public void NuevoAplicativoBPMMail(string nombre)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.NuevoAplicativoBPM);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;

                MailToSend.Body = string.Format(Properties.Settings.Default.NuevoAplicativoBPMEmailBody, nombre);
                MailToSend.Subject = Properties.Settings.Default.NuevoAplicativoBPMEmailSubject;

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }
        }

        public void AltaUsuarioRedMail(string usuario, int numeroSolicitud, DateTime fecha)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.AltaUsuarioRed);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = PhxConfBL.GetConfigParam(ConfigCodes.TecMicroEmail).ShortTxtValue;

                MailToSend.Body = ReplaceAltaUsuarioRedBodyTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyAltaUsuarioRedMail).LongTxtValue, usuario, numeroSolicitud, fecha);
                MailToSend.Subject = ReplaceAltaUsuarioRedSubjectTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectAltaUsuarioRedMail).ShortTxtValue, usuario, numeroSolicitud, fecha);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }
        }

        public void AltaUsuarioAppSeguridadIntegradaMail(string mailTo, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            AltaUsuarioAppMail(MailTypeFactory.MailType.AltaUsuarioAplicativoSeguridadIntegrada, mailTo, ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail,
                ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail, aplicativo, numeroSolicitud, fecha);
        }

        public void AltaUsuarioAppSeguridadPropiaMail(string mailTo, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            AltaUsuarioAppMail(MailTypeFactory.MailType.AltaUsuarioAplicativoSeguridadPropia, mailTo, ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail,
                ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail, aplicativo, numeroSolicitud, fecha);
        }

        public void UpdateMailRegeneraToken(int IdMail, string NewToken, string solicitante, int numeroSolicitud, DateTime fecha, string destino)
        {
            MailAlertEntity MailToUpdate = new MailAlertFactory().Load(IdMail);
            PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();
            MailToUpdate.Body = ReplaceAltaUsuarioRedExternoBodyTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyAltaUsuarioRedExternoMail).LongTxtValue, fecha, numeroSolicitud, NewToken, destino, solicitante);
            MailToUpdate.Subject = ReplaceAltaUsuarioRedExternoBodyTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectAltaUsuarioRedExternoMail).ShortTxtValue, fecha, numeroSolicitud, NewToken, destino, solicitante);
            MailAlertFactory MAF = new MailAlertFactory();

            int IdMailAlert = MAF.Update(MailToUpdate);

            if (IdMailAlert > 0)
                SendMail(MailToUpdate);

        }
        public int? AltaUsuarioRedExternoMail(string[] to, string solicitante, int numeroSolicitud, DateTime fecha, string token, string destino)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.AltaUsuarioRedExterno);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                if (to.Length > 0)
                {
                    MailToSend.ToAddress = to[0];

                    if (to.Length > 1)
                        MailToSend.Cc10Address = to[1];
                }

                MailToSend.Body = ReplaceAltaUsuarioRedExternoBodyTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyAltaUsuarioRedExternoMail).LongTxtValue, fecha, numeroSolicitud, token, destino, solicitante);
                MailToSend.Subject = ReplaceAltaUsuarioRedExternoBodyTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectAltaUsuarioRedExternoMail).ShortTxtValue, fecha, numeroSolicitud, token, destino, solicitante);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);

                return IdMailAlert;
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }

            return null;
        }

        public int? NotificacionBlanqueoMail(string usuario, string mail, int numeroSolicitud, string aplicativo, string solicitante, DateTime fecha)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.NotificacionBlanqueo);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = mail;

                MailToSend.Body = ReplaceNotificacionBlanqueoMailTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyNotificacionBlanqueoMail).LongTxtValue, solicitante, aplicativo);
                MailToSend.Subject = ReplaceNotificacionBlanqueoMailTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectNotificacionBlanqueoMail).ShortTxtValue, solicitante, aplicativo);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);

                return IdMailAlert;
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }

            return null;
        }

        public int? ReclamoNotificacionBlanqueoMail(string usuario, string mail, int numeroSolicitud, string aplicativo, DateTime fecha)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.NotificacionBlanqueo);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = mail;

                MailToSend.Body = ReplaceReclamoNotificacionBlanqueoMailTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyReclamoNotificacionBlanqueoMail).LongTxtValue, usuario, aplicativo, fecha);
                MailToSend.Subject = ReplaceReclamoNotificacionBlanqueoMailTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectReclamoNotificacionBlanqueoMail).ShortTxtValue, usuario, aplicativo, fecha);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);

                return IdMailAlert;
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }

            return null;
        }

        private string ReplaceExpirationRqstTokens(string MailBody, PasswordRequestEntity PwdRqst)
        {
            /*
            o	Nombre del solicitante: [NombreSolic]
            o	Fecha de solicitud: [FechaSolic]
            o	Fecha de expiración: [FechaExp]
            o	Datos de contraseña solicitada: [UsuarioSolic]
            Para esto se supondrá el formato [ambiente]\[nombre de usuario]
             * */

            MailBody = MailBody.Replace("[NombreSolic]", PwdRqst.RqstUser.Fullname);
            MailBody = MailBody.Replace("[FechaSolic]", PwdRqst.RequestDate.ToString("dd/MM/yyyy"));
            MailBody = MailBody.Replace("[FechaExp]", PwdRqst.ExpirationDate.Value.ToString("dd/MM/yyyy"));
            string UsuarioSolicitado = "";
            PasswordRequestEntity PRqst = new PasswordsRequestsFactory().GetFullPassRqstByID(PwdRqst.Id);
            UsuarioSolicitado = new UserBusiness().GetUserString((UserEntity)PRqst.UserPassword.UsersList[0]);
            MailBody = MailBody.Replace("[UsuarioSolic]", UsuarioSolicitado);
            MailBody = MailBody.Replace("[NroTicket]", PwdRqst.Key);
            //PwdRqst.
            return MailBody;
        }

        private string ReplacePwdRqstTokens(string MailBody, PasswordRequestEntity PwdRqst)
        {
            /*
            o	Nombre del solicitante: [NombreSolic]
            o	Fecha de solicitud: [FechaSolic]
            o	Datos de contraseña solicitada: [UsuarioSolic]
            Para esto se supondrá el formato [ambiente]\[nombre de usuario]
             * */

            MailBody = MailBody.Replace("[NombreSolic]", PwdRqst.RqstUser.Fullname);
            MailBody = MailBody.Replace("[FechaSolic]", PwdRqst.RequestDate.ToString("dd/MM/yyyy"));
            string UsuarioSolicitado = "";
            PasswordRequestEntity PRqst = new PasswordsRequestsFactory().GetFullPassRqstByID(PwdRqst.Id);
            UsuarioSolicitado = new UserBusiness().GetUserString((UserEntity)PRqst.UserPassword.UsersList[0]);
            MailBody = MailBody.Replace("[UsuarioSolic]", UsuarioSolicitado);
            MailBody = MailBody.Replace("[DescripUso]", PwdRqst.RequestDesc);
            string TiempoUso = "";
            if (PwdRqst.UnitRequested == "H") // horas
            {
                TiempoUso = " Horas";
            }
            else if (PwdRqst.UnitRequested == "D") // dias
            {
                TiempoUso = " Días";
            }
            MailBody = MailBody.Replace("[TiempoUso]", PwdRqst.HoursRequested + TiempoUso);
            MailBody = MailBody.Replace("[NroTicket]", PwdRqst.Key);
            return MailBody;
        }
        private string ReplaceRespPwdRqstTokens(string MailBody, PasswordRequestEntity PwdRqst)
        {
            /*
            o	Nombre del solicitante: [NombreSolic]
            o	Fecha de solicitud: [FechaSolic]
            o	Datos de contraseña solicitada: [UsuarioSolic]
            Para esto se supondrá el formato [ambiente]\[nombre de usuario]
             * */

            MailBody = MailBody.Replace("[NombreSolic]", PwdRqst.RqstUser.Fullname);
            MailBody = MailBody.Replace("[FechaSolic]", PwdRqst.RequestDate.ToString("dd/MM/yyyy"));
            string UsuarioSolicitado = "";
            PasswordRequestEntity PRqst = new PasswordsRequestsFactory().GetFullPassRqstByID(PwdRqst.Id);
            UsuarioSolicitado = new UserBusiness().GetUserString((UserEntity)PRqst.UserPassword.UsersList[0]);
            MailBody = MailBody.Replace("[UsuarioSolic]", UsuarioSolicitado);
            MailBody = MailBody.Replace("[DescripUso]", PwdRqst.RequestDesc);
            string TiempoUso = "";
            if (PwdRqst.UnitRequested == "H") // horas
            {
                TiempoUso = " Horas";
            }
            else if (PwdRqst.UnitRequested == "D") // dias
            {
                TiempoUso = " Días";
            }

            MailBody = MailBody.Replace("[TiempoUso]", PwdRqst.HoursGiven + TiempoUso);
            MailBody = MailBody.Replace("[NroTicket]", PwdRqst.Key);
            MailBody = MailBody.Replace("[EstadoSolicitud]", PwdRqst.RqstState.RqstStateDesc);
            return MailBody;
        }
        private string ReplaceVencPwdAppTokens(string MailBody, string sFolio, string sAplicativo, string sUsuario, int dias)
        {
            /*
            o	Folio: [Folio]
            o	Aplicativo: [Aplicativo]
            o	Usuario: [Usuario]
             * */

            MailBody = MailBody.Replace("[Folio]", sFolio);
            MailBody = MailBody.Replace("[Aplicativo]", sAplicativo);
            MailBody = MailBody.Replace("[NombreUsuario]", sUsuario);
            MailBody = MailBody.Replace("[DiasRestantes]", dias.ToString());

            return MailBody;
        }

        public void SendMailsToSend()
        {
            MailAlertFactory MAF = new MailAlertFactory();
            MailAlertEntityCollection MailsToSend = MAF.GetMailsToSend();
            if (MailsToSend.Count > 0)
            {
                string FromName = "";
                string FromMail = "";

                PhxConfigBusiness conf = new PhxConfigBusiness();
                //string fromEmail = "\"Phalax Security Manager\" <" + conf.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue + ">";//sending email from...
                //string ToEmail = txtMailDestin.Text;//destination email                    
                //string body = "";
                //string subject = "";
                string SMTPServer = "";
                string SMTPUser = "";
                string SMTPPwd = "";
                string SMTPPort = "25";
                try
                {
                    FromName = "Phalanx Security Manager";
                    FromMail = conf.GetConfigParam(ConfigCodes.FromExpMails, false, false).ShortTxtValue;

                    SMTPServer = conf.GetConfigParam(ConfigCodes.SMTPDir, false, false).ShortTxtValue;
                    try
                    {
                        SMTPPort = (conf.GetConfigParam(ConfigCodes.SMTPPort, false).ShortTxtValue == "" ? "25" : conf.GetConfigParam(ConfigCodes.SMTPPort).ShortTxtValue);
                    }
                    catch (Exception e)
                    {
                        SMTPPort = "25";
                    }
                    try
                    {
                        SMTPUser = conf.GetConfigParam(ConfigCodes.SMTPUsr, false, false).ShortTxtValue;
                        SMTPPwd = conf.GetConfigParam(ConfigCodes.SMTPPwd, false, false).ShortTxtValue;
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    // falta alguno de los parametros
                    return;
                }
                SendMail sMail;
                if (SMTPUser == "")
                {
                    sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort));
                }
                else
                {
                    sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort), SMTPUser, SMTPPwd);
                }
                foreach (MailAlertEntity MailToSend in MailsToSend)
                {
                    bool IsSent = sMail.Send(FromName, FromMail, MailToSend.Subject, MailToSend.Body, MailToSend.ToName
                    , MailToSend.ToAddress, MailToSend.Cc1Name, MailToSend.Cc1Address, MailToSend.Cc2Name
                    , MailToSend.Cc2Address);
                    // marca el envio o en intento
                    MAF.SentMail(MailToSend, IsSent);

                }
            }
        }
        public void SendMail(int MailToSendId)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertFactory().GetMailToSend(MailToSendId);
                if (MailToSend != null)
                {
                    this.SendMail(MailToSend);
                }
            }
            catch
            {
            }

        }
        public void SendMail(MailAlertEntity MailToSend)
        {
            string FromName = "";
            string FromMail = "";

            PhxConfigBusiness conf = new PhxConfigBusiness();
            //string fromEmail = "\"Phalax Security Manager\" <" + conf.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue + ">";//sending email from...
            //string ToEmail = txtMailDestin.Text;//destination email                    
            //string body = "";
            //string subject = "";
            string SMTPServer = "";
            string SMTPUser = "";
            string SMTPPwd = "";
            string SMTPPort = "25";
            try
            {
                FromName = "Phalanx Security Manager";
                FromMail = conf.GetConfigParam(ConfigCodes.FromExpMails, false, false).ShortTxtValue;

                SMTPServer = conf.GetConfigParam(ConfigCodes.SMTPDir, false, false).ShortTxtValue;
                try
                {
                    SMTPPort = (conf.GetConfigParam(ConfigCodes.SMTPPort, false).ShortTxtValue == "" ? "25" : conf.GetConfigParam(ConfigCodes.SMTPPort).ShortTxtValue);
                }
                catch (Exception e)
                {
                    SMTPPort = "25";
                }
                try
                {
                    SMTPUser = conf.GetConfigParam(ConfigCodes.SMTPUsr, false, false).ShortTxtValue;
                    SMTPPwd = conf.GetConfigParam(ConfigCodes.SMTPPwd, false, false).ShortTxtValue;
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                // falta alguno de los parametros
                return;
            }
            SendMail sMail;
            if (SMTPUser == "")
            {
                sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort));
            }
            else
            {
                sMail = new SendMail(SMTPServer, Convert.ToInt32(SMTPPort), SMTPUser, SMTPPwd);
            }
            MailAddressCollection CCMailAddresses = new MailAddressCollection();
            if (MailToSend.ToAddress != string.Empty && MailToSend.ToAddress != "")
            {
                MailAddress MailAdd;
                if (MailToSend.ToName != string.Empty && MailToSend.ToName != "")
                {
                    MailAdd = new MailAddress(MailToSend.ToAddress, MailToSend.ToName);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.ToAddress);
                }
                CCMailAddresses.Add(MailAdd);
            }

            if (MailToSend.Cc1Address != string.Empty && MailToSend.Cc1Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc1Name != string.Empty && MailToSend.Cc1Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc1Address, MailToSend.Cc1Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc1Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc2Address != string.Empty && MailToSend.Cc2Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc2Name != string.Empty && MailToSend.Cc2Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc2Address, MailToSend.Cc2Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc2Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc3Address != string.Empty && MailToSend.Cc3Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc3Name != string.Empty && MailToSend.Cc3Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc3Address, MailToSend.Cc3Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc3Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc4Address != string.Empty && MailToSend.Cc4Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc4Name != string.Empty && MailToSend.Cc4Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc4Address, MailToSend.Cc4Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc4Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc5Address != string.Empty && MailToSend.Cc5Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc5Name != string.Empty && MailToSend.Cc5Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc5Address, MailToSend.Cc5Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc5Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc6Address != string.Empty && MailToSend.Cc6Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc6Name != string.Empty && MailToSend.Cc6Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc6Address, MailToSend.Cc6Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc6Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc7Address != string.Empty && MailToSend.Cc7Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc7Name != string.Empty && MailToSend.Cc7Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc7Address, MailToSend.Cc7Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc7Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc8Address != string.Empty && MailToSend.Cc8Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc8Name != string.Empty && MailToSend.Cc8Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc8Address, MailToSend.Cc8Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc8Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc9Address != string.Empty && MailToSend.Cc9Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc9Name != string.Empty && MailToSend.Cc9Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc9Address, MailToSend.Cc9Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc9Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc10Address != string.Empty && MailToSend.Cc10Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc10Name != string.Empty && MailToSend.Cc10Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc10Address, MailToSend.Cc10Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc10Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc11Address != string.Empty && MailToSend.Cc11Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc11Name != string.Empty && MailToSend.Cc11Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc11Address, MailToSend.Cc11Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc11Address);
                }
                CCMailAddresses.Add(MailAdd);
            }
            if (MailToSend.Cc12Address != string.Empty && MailToSend.Cc12Address != "")
            {
                MailAddress MailAdd;
                if (MailToSend.Cc12Name != string.Empty && MailToSend.Cc12Name != "")
                {
                    MailAdd = new MailAddress(MailToSend.Cc12Address, MailToSend.Cc12Name);
                }
                else
                {
                    MailAdd = new MailAddress(MailToSend.Cc12Address);
                }
                CCMailAddresses.Add(MailAdd);
            }

            //Cargo coleccion de CC
            MailAlertCCBusiness mabCC = new MailAlertCCBusiness();
            var cc = mabCC.LoadMailAddressC(MailToSend.MailAlertCCList);

            foreach (MailAddress item in cc)
            {
                CCMailAddresses.Add(item);
            }

            bool IsSent = sMail.Send(FromName, FromMail, MailToSend.Subject, MailToSend.Body, CCMailAddresses);
            /*
            bool IsSent = sMail.Send(FromName, FromMail, MailToSend.Subject, MailToSend.Body, MailToSend.ToName
                , MailToSend.ToAddress, MailToSend.Cc1Name, MailToSend.Cc1Address, MailToSend.Cc2Name
                , MailToSend.Cc2Address);
             */
            // marca el envio o en intento
            new MailAlertFactory().SentMail(MailToSend, IsSent);

        }

        public MailAlertEntityCollection GetAll()
        {
            MailAlertFactory MAF = new MailAlertFactory();
            if (_filSentMail != null) { MAF.FilSentMail = _filSentMail; }
            if (_filMailType != null) { MAF.FilMailType = _filMailType; }
            return MAF.GetAll();
        }

        private void AltaUsuarioAppMail(MailTypeFactory.MailType mailType, string mailTo, ConfigCodes body, ConfigCodes subject, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(mailType);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = mailTo;

                MailToSend.Body = ReplaceAltaUsuarioAppBodyTokens(PhxConfBL.GetConfigParam(body).LongTxtValue, aplicativo, numeroSolicitud, fecha);
                MailToSend.Subject = ReplaceAltaUsuarioAppSubjectTokens(PhxConfBL.GetConfigParam(subject).ShortTxtValue, aplicativo, numeroSolicitud, fecha);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }
        }

        private string ReplaceAltaUsuarioRedBodyTokens(string body, string usuario, int numeroSolicitud, DateTime fecha)
        {
            return ReplaceAltaUsuarioRedTokens(body, usuario, numeroSolicitud, fecha);
        }

        private string ReplaceAltaUsuarioRedSubjectTokens(string subject, string usuario, int numeroSolicitud, DateTime fecha)
        {
            return ReplaceAltaUsuarioRedTokens(subject, usuario, numeroSolicitud, fecha);
        }

        private string ReplaceAltaUsuarioRedTokens(string text, string usuario, int numeroSolicitud, DateTime fecha)
        {
            return text.Replace("[NombreUsuario]", usuario)
                            .Replace("[NroTicket]", numeroSolicitud.ToString())
                            .Replace("[FechaAlta]", fecha.ToString("dd/MM/yyyy"));
        }

        private string ReplaceAltaUsuarioAppBodyTokens(string body, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            return ReplaceAltaUsuarioAppTokens(body, aplicativo, numeroSolicitud, fecha);
        }

        private string ReplaceAltaUsuarioAppSubjectTokens(string subject, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            return ReplaceAltaUsuarioAppTokens(subject, aplicativo, numeroSolicitud, fecha);
        }

        private string ReplaceAltaUsuarioAppTokens(string text, string aplicativo, int numeroSolicitud, DateTime fecha)
        {
            return text.Replace("[Aplicativo]", aplicativo)
                            .Replace("[NroTicket]", numeroSolicitud.ToString())
                            .Replace("[FechaAlta]", fecha.ToString("dd/MM/yyyy"));
        }

        private string ReplaceNotificacionBlanqueoMailTokens(string text, string solicitante, string aplicacion)
        {
            return text.Replace("[NombreSolicitante]", solicitante)
                            .Replace("[Aplicativo]", aplicacion);
        }

        private string ReplaceReclamoNotificacionBlanqueoMailTokens(string text, string usuario, string aplicacion, DateTime fecha)
        {
            return text.Replace("[FechaSolic]", fecha.ToString("dd/MM/yyyy"))
                            .Replace("[NombreUsuario]", usuario)
                            .Replace("[Aplicativo]", aplicacion);
        }

        public void MailAltaUsuarioAplicativoConSegInt(string Aplicacion, string FTicketDDMMYYYY, string NroTicket, string MailUsuario)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.AltaUsuarioAplicativoSeguridadIntegrada);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = MailUsuario;

                MailToSend.Body = PhxConfBL.GetConfigParam(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail).LongTxtValue.Replace("[Aplicativo]", Aplicacion)
                        .Replace("[NroTicket]", NroTicket)
                        .Replace("[FechaAlta]", FTicketDDMMYYYY);
                MailToSend.Subject = PhxConfBL.GetConfigParam(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail).ShortTxtValue.Replace("[Aplicativo]", Aplicacion)
                        .Replace("[NroTicket]", NroTicket)
                        .Replace("[FechaAlta]", FTicketDDMMYYYY);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }

        }

        public void MailAltaUsuarioAplicativoConSegProp(string Aplicacion, string FTicketDDMMYYYY, string NroTicket, string MailUsuario)
        {
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.AltaUsuarioAplicativoSeguridadPropia);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                MailToSend.ToAddress = MailUsuario;

                MailToSend.Body = PhxConfBL.GetConfigParam(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail).LongTxtValue
                        .Replace("[Aplicativo]", Aplicacion)
                        .Replace("[NroTicket]", NroTicket)
                        .Replace("[FechaAlta]", FTicketDDMMYYYY);
                MailToSend.Subject = PhxConfBL.GetConfigParam(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail).ShortTxtValue
                        .Replace("[Aplicativo]", Aplicacion)
                        .Replace("[NroTicket]", NroTicket)
                        .Replace("[FechaAlta]", FTicketDDMMYYYY);

                MailAlertFactory MAF = new MailAlertFactory();

                int IdMailAlert = MAF.Save(MailToSend);

                if (IdMailAlert > 0)
                    SendMail(MailToSend);
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail;
            }

        }

        public void CreateDevRqstPwdMail(PasswordRequestEntity PasswordRequest)
        {
            string AuthGroupMail = "";
            string MailBody = "";
            string MailSubject = "";
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.DevolucionPwdRqst);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;

                /// busca los mails de los designados en los grupos de seguimiento de la contraseña
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection AutorizadoresEC = new PhxUserEntityCollection();
                AutorizadoresEC = PhxUsrBL.GetAllFollowPwdRqstAuth(PasswordRequest.UserPassword);
                /// si no hay administradores en los grupos de seguimiento se asigna la casilla del grupo por defecto
                if (AutorizadoresEC.Count == 0)
                {
                    MailToSend.ToAddress = AuthGroupMail;
                }
                else
                {
                    int cant = AutorizadoresEC.Count;
                    if (cant >= 1)
                    {
                        MailToSend.ToAddress = AutorizadoresEC[0].Email;
                        MailToSend.ToName = AutorizadoresEC[0].Fullname;
                    }
                    if (cant >= 2)
                    {
                        MailToSend.Cc1Name = AutorizadoresEC[1].Fullname;
                        MailToSend.Cc1Address = AutorizadoresEC[1].Email;
                    }
                    if (cant >= 3)
                    {
                        MailToSend.Cc2Name = AutorizadoresEC[2].Fullname;
                        MailToSend.Cc2Address = AutorizadoresEC[2].Email;
                    }
                    if (cant >= 4)
                    {
                        MailToSend.Cc3Name = AutorizadoresEC[3].Fullname;
                        MailToSend.Cc3Address = AutorizadoresEC[3].Email;
                    }
                    if (cant >= 5)
                    {
                        MailToSend.Cc4Name = AutorizadoresEC[4].Fullname;
                        MailToSend.Cc4Address = AutorizadoresEC[4].Email;
                    }
                    if (cant >= 6)
                    {
                        MailToSend.Cc5Name = AutorizadoresEC[5].Fullname;
                        MailToSend.Cc5Address = AutorizadoresEC[5].Email;
                    }
                    if (cant >= 7)
                    {
                        MailToSend.Cc6Name = AutorizadoresEC[6].Fullname;
                        MailToSend.Cc6Address = AutorizadoresEC[6].Email;
                    }
                    if (cant >= 8)
                    {
                        MailToSend.Cc7Name = AutorizadoresEC[7].Fullname;
                        MailToSend.Cc7Address = AutorizadoresEC[7].Email;
                    }
                    if (cant >= 9)
                    {
                        MailToSend.Cc8Name = AutorizadoresEC[8].Fullname;
                        MailToSend.Cc8Address = AutorizadoresEC[8].Email;
                    }
                    if (cant >= 10)
                    {
                        MailToSend.Cc9Name = AutorizadoresEC[9].Fullname;
                        MailToSend.Cc9Address = AutorizadoresEC[9].Email;
                    }
                }

                MailBody = ReplaceDevRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyDevMails).LongTxtValue, PasswordRequest);
                MailSubject = ReplaceDevRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectDevMails).ShortTxtValue, PasswordRequest);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }

        public void CreateDevRqstPwdMailNoCritic(PasswordRequestEntity PasswordRequest)
        {
            string AuthGroupMail = "";
            string MailBody = "";
            string MailSubject = "";
            try
            {
                MailAlertEntity MailToSend = new MailAlertEntity();
                MailToSend.MailType = new MailTypeFactory().GetMailType(MailTypeFactory.MailType.DevolucionPwdRqstNoCritic);

                PhxConfigBusiness PhxConfBL = new PhxConfigBusiness();

                AuthGroupMail = PhxConfBL.GetConfigParam(ConfigCodes.AdmMailGrp).ShortTxtValue;

                /// busca los mails de los designados en los grupos de seguimiento de la contraseña
                PhxUserBusiness PhxUsrBL = new PhxUserBusiness();
                PhxUserEntityCollection AutorizadoresEC = new PhxUserEntityCollection();
                AutorizadoresEC = PhxUsrBL.GetAllFollowPwdRqstAuth(PasswordRequest.UserPassword);
                /// si no hay administradores en los grupos de seguimiento se asigna la casilla del grupo por defecto

                MailAlertCCBusiness maccBL = new MailAlertCCBusiness();

                if (AutorizadoresEC.Count == 0)
                {
                    //Agrego CC
                    MailToSend.MailAlertCCList.Add(maccBL.CreateCC(AuthGroupMail));
                }
                else
                {
                    //Agrego CC
                    foreach (PhxUserEntity entityUser in AutorizadoresEC)
                        MailToSend.MailAlertCCList.Add(maccBL.CreateCC(entityUser.Fullname, entityUser.Email, MailToSend));
                }

                MailBody = ReplaceDevRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.BodyDevMailsNoCritic).LongTxtValue, PasswordRequest);
                MailSubject = ReplaceDevRqstTokens(PhxConfBL.GetConfigParam(ConfigCodes.SubjectDevMailsNoCritic).ShortTxtValue, PasswordRequest);

                MailToSend.Body = MailBody;
                MailToSend.Subject = MailSubject;

                MailAlertFactory MAF = new MailAlertFactory();
                int IdMailAlert = MAF.Save(MailToSend);
                if (IdMailAlert > 0)
                {
                    this.SendMail(MailToSend);
                }
            }
            catch (Exception ex)
            {
                // no se pudo crear el mail, seguramente por falta de parametros;
            }
        }

        private string ReplaceDevRqstTokens(string MailBody, PasswordRequestEntity PwdRqst)
        {
            MailBody = MailBody.Replace("[NombreSolic]", PwdRqst.RqstUser.Fullname);
            MailBody = MailBody.Replace("[FechaSolic]", PwdRqst.RequestDate.ToString("dd/MM/yyyy"));
            MailBody = MailBody.Replace("[FechaDev]", PwdRqst.ReturnDate.Value.ToString("dd/MM/yyyy"));
            string UsuarioSolicitado = "";
            PasswordRequestEntity PRqst = new PasswordsRequestsFactory().GetFullPassRqstByID(PwdRqst.Id);
            UsuarioSolicitado = new UserBusiness().GetUserString((UserEntity)PRqst.UserPassword.UsersList[0]);
            MailBody = MailBody.Replace("[UsuarioSolic]", UsuarioSolicitado);
            MailBody = MailBody.Replace("[NroTicket]", PwdRqst.Key);
            //PwdRqst.
            return MailBody;
        }

        private string ReplaceAltaUsuarioRedExternoBodyTokens(string text, DateTime fechaAlta, int numeroSolicitud, string token, string destino, string nombreSolicitante)
        {
            return text.Replace("[FechaAlta]", fechaAlta.ToString("dd/MM/yyyy"))
                            .Replace("[NroTicket]", numeroSolicitud.ToString())
                            .Replace("[Token]", token)
                            .Replace("[Destino]", destino)
                            .Replace("[NombreSolic]", nombreSolicitante);
        }

        public void Reenviar(int MailId)
        {
            Reenviar(MailId, null);
        }

        public void Reenviar(int MailId, IEnumerable<string> destinatarios)
        {
            MailAlertEntity mail;

            MailAlertFactory mailAlertFactory = new MailAlertFactory();

            mail = mailAlertFactory.GetMailToSend(MailId);

            mail.Id = 0;
            mail.SendAttemp = 0;

            if (destinatarios != null)
                SetearDestinatarios(mail, destinatarios);

            mailAlertFactory.Save(mail);

            SendMail(mail);
        }

        public MailAlertEntity GetMail(int MailId)
        {
            MailAlertFactory mailAlertFactory = new MailAlertFactory();

            return mailAlertFactory.GetMailToSend(MailId);
        }

        private void SetearDestinatarios(MailAlertEntity mail, IEnumerable<string> destinatarios)
        {
            int i = 0;

            Type mailType = mail.GetType();

            foreach (string destinatario in destinatarios)
            {
                if (i == 0)
                    mail.ToAddress = destinatario;
                else if (i < 13)
                {
                    PropertyInfo propertyInfo = mailType.GetProperty("Cc" + i.ToString() + "Address");
                    propertyInfo.SetValue(mail, destinatario, null);
                }
                else
                    break;

                i++;
            }
        }

    }
}
