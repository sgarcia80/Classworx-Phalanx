using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxDAL.Factories;
using PhalanxCommon;

namespace PhalanxBL
{
    public class PhxConfigBusiness
    {
        /// <summary>
        /// Convierte el enum en el codigo de la base de datos
        /// </summary>
        /// <param name="ParamCode"></param>
        /// <returns></returns>
        public string ParamCodeToString(ConfigCodes ParamCode)
        {
            string strParamCode = "";
            switch (ParamCode)
            {
                case ConfigCodes.AdmMailGrp:
                    strParamCode = "@ADM_MAIL_GRP@";
                    break;
                case ConfigCodes.FromExpMails:
                    strParamCode = "@FROM_EXP_MAILS@";
                    break;
                case ConfigCodes.SubjectExpMails:
                    strParamCode = "@SUBJECT_EXP_MAILS@";
                    break;
                case ConfigCodes.BodyExpMails:
                    strParamCode = "@BODY_EXP_MAILS@";
                    break;
                case ConfigCodes.SMTPExpMails:
                    strParamCode = "@SMTP_EXP_MAILS@";
                    break;
                case ConfigCodes.SMTPPwd:
                    strParamCode = "@SMTP_PWD@";
                    break;
                case ConfigCodes.SMTPUsr:
                    strParamCode = "@SMTP_USR@";
                    break;
                case ConfigCodes.SMTPDir:
                    strParamCode = "@SMTP_DIR@";
                    break;
                case ConfigCodes.BodySolicPwdMails:
                    strParamCode = "@BODY_PWDRQST_MAILS@";
                    break;
                case ConfigCodes.SMTPPort:
                    strParamCode = "@SMTP_PORT@";
                    break;
                case ConfigCodes.SubjectPwdRqstMails:
                    strParamCode = "@SUBJECT_PWDRQST_MAILS@";
                    break;
                case ConfigCodes.SubjectRespPwdRqstMails:
                    strParamCode = "@SUBJECT_PWDRQST_RESP_MAILS@";
                    break;
                case ConfigCodes.BodyRespSolicPwdMails:
                    strParamCode = "@BODY_PWDRQST_RESP_MAILS@";
                    break;
                case ConfigCodes.TecMicroEmail:
                    strParamCode = "@TEC_MICRO_MAIL@";
                    break;
                case ConfigCodes.SubjectAltaUsuarioRedMail:
                    strParamCode = "@SUBJECT_ALTA_USUARIO_RED@";
                    break;
                case ConfigCodes.BodyAltaUsuarioRedMail:
                    strParamCode = "@BODY_ALTA_USUARIO_RED@";
                    break;
                case ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail:
                    strParamCode = "@SUBJECT_ALTA_US_APP_SEG_INT@";
                    break;
                case ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail:
                    strParamCode = "@BODY_ALTA_US_APP_SEG_INT@";
                    break;
                case ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail:
                    strParamCode = "@SUBJECT_ALTA_US_APP_SEG_PROP@";
                    break;
                case ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail:
                    strParamCode = "@BODY_ALTA_US_APP_SEG_PROP@";
                    break;
                case ConfigCodes.SubjectDevMails:
                    strParamCode = "@SUBJECT_DEV_CRITICA@";
                    break;
                case ConfigCodes.BodyDevMails:
                    strParamCode = "@BODY_DEV_CRITICA@";
                    break;
                case ConfigCodes.SubjectAltaUsuarioRedExternoMail:
                    strParamCode = "@SUBJECT_ALTA_US_RED_EXT_MAIL@";
                    break;
                case ConfigCodes.BodyAltaUsuarioRedExternoMail:
                    strParamCode = "@BODY_ALTA_US_RED_EXT_MAIL@";
                    break;
                case ConfigCodes.UsuariosAutorizadosWSBPM:
                    strParamCode = "@US_AUT_WSBPM@";
                    break;
                case ConfigCodes.AutenticacionUsuariosAutorizadosWSBPM:
                    strParamCode = "@AUT_US_AUT_WSBPM@";
                    break;
                case ConfigCodes.UsuarioLlamadaWSCOBIS:
                    strParamCode = "@US_LLAMADA_WSCOBIS@";
                    break;
                case ConfigCodes.IDAplicacionWSCOBIS:
                    strParamCode = "@ID_APP_WSCOBIS@";
                    break;
                case ConfigCodes.EstadoWSCOBIS:
                    strParamCode = "@ESTADO_WSCOBIS@";
                    break;
                case ConfigCodes.QuienLlamaWSCOBIS:
                    strParamCode = "@QUIEN_LLAMA_WSCOBIS@";
                    break;
                case ConfigCodes.AutenticacionLoginNDC:
                    strParamCode = "@AUT_LOGIN_NDC@";
                    break;
                case ConfigCodes.DominiosLoginNDC:
                    strParamCode = "@DOM_LOGIN_NDC@";
                    break;
                case ConfigCodes.LoginASBlanqueoWSCOBIS:
                    strParamCode = "@U_LOGIN_AS_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.ClaveASBlanqueoWSCOBIS:
                    strParamCode = "@C_CLAVE_AS_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.RolASBlanqueoWSCOBIS:
                    strParamCode = "@ROL_AS_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.OficinaASBlanqueoWSCOBIS:
                    strParamCode = "@OFICINA_AS_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.ServidorASBlanqueoWSCOBIS:
                    strParamCode = "@SERVIDOR_AS_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.ClaveBlanqueoWSCOBIS:
                    strParamCode = "@C_CLAVE_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.LoginBlanqueoWSCOBIS:
                    strParamCode = "@U_LOGIN_BLANQUEO_WSCOBIS@";
                    break;
                case ConfigCodes.SubjectNotificacionBlanqueoMail:
                    strParamCode = "@SUBJECT_NOTIF_BLANQUEO_MAIL@";
                    break;
                case ConfigCodes.BodyNotificacionBlanqueoMail:
                    strParamCode = "@BODY_NOTIF_BLANQUEO_MAIL@";
                    break;
                case ConfigCodes.SubjectReclamoNotificacionBlanqueoMail:
                    strParamCode = "@SUBJECT_RECL_NOTIF_CLAVE@";
                    break;
                case ConfigCodes.BodyReclamoNotificacionBlanqueoMail:
                    strParamCode = "@BODY_RECL_NOTIF_CLAVE@";
                    break;
                case ConfigCodes.SubjectDevMailsNoCritic:
                    strParamCode = "@SUBJECT_DEV_NO_CRITICA@";
                    break;
                case ConfigCodes.BodyDevMailsNoCritic:
                    strParamCode = "@BODY_DEV_NO_CRITICA@";
                    break;
                case ConfigCodes.AutenticacionUsuariosAutorizadosWSConectores:
                    strParamCode = "@AUT_LOGIN_WSCONECTORES@";
                    break;
                case ConfigCodes.UsuariosAutorizadosWSConectores:
                    strParamCode = "@US_AUT_WSCONECTORES@";
                    break;
                case ConfigCodes.SubjectVencPwdAppMails:
                    strParamCode = "@SUBJECT_VENCPWDAPP_MAILS@";
                    break;
                case ConfigCodes.BodyVencPwdAppMails:
                    strParamCode = "@BODY_VENCPWDAPP_MAILS@";
                    break;
                default:
                    break;
            }
            return strParamCode;

        }
        /// <summary>
        /// Busca la entidad de configuración para un codigo determinado
        /// </summary>
        /// <param name="ParamCode"></param>
        /// <returns></returns>
        public PhxConfigEntity GetConfigParam(ConfigCodes ParamCode)
        {
            PhxConfigFactory ConfFac = new PhxConfigFactory();
            return ConfFac.GetConfigParam(this.ParamCodeToString(ParamCode));
        }
        public PhxConfigEntity GetConfigParam(ConfigCodes ParamCode, bool AllowNull)
        {
            PhxConfigFactory ConfFac = new PhxConfigFactory();
            PhxConfigEntity ConfigParam = ConfFac.GetConfigParam(this.ParamCodeToString(ParamCode));
            if (!AllowNull && ConfigParam == null)
            {
                throw new CwxException("Parámetro no seteado");
            }
            return ConfigParam;
        }
        public PhxConfigEntity GetConfigParam(ConfigCodes ParamCode, bool AllowNull, bool ValueEmpty)
        {
            PhxConfigFactory ConfFac = new PhxConfigFactory();
            PhxConfigEntity ConfigParam = ConfFac.GetConfigParam(this.ParamCodeToString(ParamCode));
            if ((!AllowNull && ConfigParam == null)
                || (AllowNull && ConfigParam != null && !(ValueEmpty) && ConfigParam.ShortTxtValue == ""
                && ConfigParam.LongTxtValue == ""))
            {
                throw new CwxException("Parámetro no seteado");
            }
            return ConfigParam;
        }
        /// <summary>
        /// Trae los parametros de configuración de mails de expiracion de
        /// solicitud de contraseña.
        /// Se usa para cargar el combo en el modulo de configuración
        /// </summary>
        /// <returns></returns>
        public PhxConfigEntityCollection GetMailsExpPqdRqstParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();
            ConfEC.Add(this.GetConfigParam(ConfigCodes.AdmMailGrp));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyExpMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.FromExpMails));
            //ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPExpMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectExpMails));
            return ConfEC;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PhxConfigEntityCollection GetMailsParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();
            ConfEC.Add(this.GetConfigParam(ConfigCodes.AdmMailGrp));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyExpMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.FromExpMails));
            //ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPExpMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectExpMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPDir));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPPort));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPUsr));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SMTPPwd));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodySolicPwdMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectPwdRqstMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectRespPwdRqstMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyRespSolicPwdMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.TecMicroEmail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectAltaUsuarioRedMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyAltaUsuarioRedMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadIntegradaMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadIntegradaMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectAltaUsuarioAplicativoSeguridadPropiaMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyAltaUsuarioAplicativoSeguridadPropiaMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectDevMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyDevMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectAltaUsuarioRedExternoMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyAltaUsuarioRedExternoMail));

            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectNotificacionBlanqueoMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyNotificacionBlanqueoMail));

            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectReclamoNotificacionBlanqueoMail));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyReclamoNotificacionBlanqueoMail));

            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectDevMailsNoCritic));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyDevMailsNoCritic));

            ConfEC.Add(this.GetConfigParam(ConfigCodes.SubjectVencPwdAppMails));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.BodyVencPwdAppMails));
            return ConfEC;

        }

        public PhxConfigEntityCollection GetWSBPMParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();

            ConfEC.Add(this.GetConfigParam(ConfigCodes.UsuariosAutorizadosWSBPM));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.AutenticacionUsuariosAutorizadosWSBPM));

            return ConfEC;
        }

        public PhxConfigEntityCollection GetWSCOBISParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();

            ConfEC.Add(this.GetConfigParam(ConfigCodes.UsuarioLlamadaWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.IDAplicacionWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.EstadoWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.QuienLlamaWSCOBIS));

            ConfEC.Add(this.GetConfigParam(ConfigCodes.LoginASBlanqueoWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.ClaveASBlanqueoWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.RolASBlanqueoWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.OficinaASBlanqueoWSCOBIS));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.ServidorASBlanqueoWSCOBIS));

            return ConfEC;
        }

        public PhxConfigEntityCollection GetNDCParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();

            ConfEC.Add(this.GetConfigParam(ConfigCodes.AutenticacionLoginNDC));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.DominiosLoginNDC));

            return ConfEC;
        }

        public PhxConfigEntityCollection GetWSConectoresParams()
        {
            PhxConfigEntityCollection ConfEC = new PhxConfigEntityCollection();

            ConfEC.Add(this.GetConfigParam(ConfigCodes.UsuariosAutorizadosWSConectores));
            ConfEC.Add(this.GetConfigParam(ConfigCodes.AutenticacionUsuariosAutorizadosWSConectores));

            return ConfEC;
        }

        public void Save(PhxConfigEntity ConfigParam)
        {
            PhxConfigFactory ConfFac = new PhxConfigFactory();
            ConfFac.Save(ConfigParam);
        }
    }
}
