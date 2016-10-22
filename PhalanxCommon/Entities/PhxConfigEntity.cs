using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    public enum ConfigCodes
    {
        AdmMailGrp, // = "@ADM_MAIL_GRP@",
        FromExpMails, // = "@FROM_EXP_MAILS@",
        SubjectExpMails, // = "@SUBJECT_EXP_MAILS@",
        BodyExpMails, // = "@BODY_EXP_MAILS@",
        SMTPExpMails, // = "@SMTP_EXP_MAILS@"
        BodySolicPwdMails,
        SMTPDir,
        SMTPUsr,
        SMTPPwd,
        SMTPPort,
        SubjectPwdRqstMails,
        SubjectRespPwdRqstMails, // @SUBJECT_PWDRQST_RESP_MAILS@
        BodyRespSolicPwdMails, // @BODY_PWDRQST_RESP_MAILS@
        TecMicroEmail,
        SubjectAltaUsuarioRedMail,
        BodyAltaUsuarioRedMail,
        SubjectAltaUsuarioAplicativoSeguridadIntegradaMail,
        BodyAltaUsuarioAplicativoSeguridadIntegradaMail,
        SubjectAltaUsuarioAplicativoSeguridadPropiaMail,
        BodyAltaUsuarioAplicativoSeguridadPropiaMail,
        BodyDevMails, // = "@BODY_DEV_MAILS@",
        SubjectDevMails, // = "@SUBJECT_DEV_MAILS@",
        BodyAltaUsuarioRedExternoMail, // = "@BODY_ALTA_US_RED_EXT_MAIL@",
        SubjectAltaUsuarioRedExternoMail, // = "@SUBJECT_ALTA_US_RED_EXT_MAIL@",
        UsuariosAutorizadosWSBPM,
        AutenticacionUsuariosAutorizadosWSBPM,
        UsuarioLlamadaWSCOBIS,
        IDAplicacionWSCOBIS,
        EstadoWSCOBIS,
        QuienLlamaWSCOBIS,
        AutenticacionLoginNDC,
        DominiosLoginNDC,
        LoginASBlanqueoWSCOBIS,
        ClaveASBlanqueoWSCOBIS,
        RolASBlanqueoWSCOBIS,
        OficinaASBlanqueoWSCOBIS,
        ServidorASBlanqueoWSCOBIS,
        ClaveBlanqueoWSCOBIS,
        LoginBlanqueoWSCOBIS,
        SubjectNotificacionBlanqueoMail,
        BodyNotificacionBlanqueoMail,
        SubjectReclamoNotificacionBlanqueoMail,
        BodyReclamoNotificacionBlanqueoMail
    }


    [Serializable]
    public class PhxConfigEntity : BaseEntity
    {
        #region Private Members
        private bool m_isChanged = false;
        private string m_code;
        private string m_description;
        private string m_short_txt_value;
        private string m_long_txt_value;
        private string m_name;
        #endregion
        #region Public Members
        public string Code
        {
            get { return m_code; }

            set
            {
                if (value != null && value.Length > 30)
                    throw new ArgumentOutOfRangeException("Invalid value for Code", value, value.ToString());

                m_isChanged |= (m_code != value); m_code = value;
            }
        }
        public string Description
        {
            get { return m_description; }

            set
            {
                if (value != null && value.Length > 400)
                    throw new ArgumentOutOfRangeException("Invalid value for Description", value, value.ToString());

                m_isChanged |= (m_description != value); m_description = value;
            }
        }
        public string ShortTxtValue
        {
            get { return m_short_txt_value; }

            set
            {
                if (value != null && value.Length > 400)
                    throw new ArgumentOutOfRangeException("Invalid value for ShortTxtValue", value, value.ToString());

                m_isChanged |= (m_short_txt_value != value); m_short_txt_value = value;
            }
        }
        public string LongTxtValue
        {
            get { return m_long_txt_value; }

            set
            {
                if (value != null && value.Length > 8000)
                    throw new ArgumentOutOfRangeException("Invalid value for LongTxtValue", value, value.ToString());

                m_isChanged |= (m_long_txt_value != value); m_long_txt_value = value;
            }
        }
        public string Name
        {
            get { return m_name; }

            set
            {
                if (value != null && value.Length > 100)
                    throw new ArgumentOutOfRangeException("Invalid value for Name", value, value.ToString());

                m_isChanged |= (m_name != value); m_name = value;
            }
        }

        /// <summary>
        /// Returns whether or not the object has changed it's values.
        /// </summary>
        public bool IsChanged
        {
            get { return m_isChanged; }
        }

        #endregion

        public override string Key
        {
            get
            {
                return this.Code;
            }
            set
            {
                this.Code = value; ;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
