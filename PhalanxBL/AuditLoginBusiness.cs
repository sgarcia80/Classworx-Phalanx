using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class AuditLoginBusiness
    {
        private void Save(AuditLoginEntity AudLogin)
        {
            new AuditLoginFactory().Save(AudLogin);
        }
        /// <summary>
        /// Genera log de auditoria cuando quiere ingresar un usuario que no existe
        /// en el sistema
        /// </summary>
        /// <param name="username"></param>
        public void LogUsrInexist(string username)
        {
            AuditLoginEntity AudLogin = new AuditLoginEntity();
            AudLogin.Evento = new EventoLoginBusiness().GetEventoUsrNoExist();
            AudLogin.Username = username;
            this.Save(AudLogin);
        }

        /// <summary>
        /// Genera log de auditoria cuando un usuario se loguea, existe en el sistema y
        /// tiene acceso a la aplicación administrativa
        /// </summary>
        /// <param name="PhxUser"></param>
        public void LogAccOK(PhxUserEntity PhxUser)
        {
            AuditLoginEntity AudLogin = new AuditLoginEntity();
            AudLogin.Evento = new EventoLoginBusiness().GetEventoIngSatisf();
            AudLogin.Username = PhxUser.Username;
            AudLogin.IdUsuario = PhxUser.Id;
            AudLogin.Fullname = PhxUser.Fullname;
            this.Save(AudLogin);
        }

        public void LogAccOK(int? userid, string username, string fullname, string terminal, App application)
        {
            EventoLoginEntity evento = new EventoLoginBusiness().GetEventoIngSatisf();

            Log(userid, username, fullname, terminal, application, evento);
        }

        /// <summary>
        /// Genera el log de auditoria cuando un usuario se loguea, existe en el sistema,
        /// está habilitado pero y no tiene permisos para acceder a la aplic admin
        /// </summary>
        /// <param name="PhxUser"></param>
        public void LogNoAcces(PhxUserEntity PhxUser)
        {
            AuditLoginEntity AudLogin = new AuditLoginEntity();
            // falta definir el evento para cuando un usuario existe pero no tiene permiso
            AudLogin.Evento = new EventoLoginBusiness().GetEventoSinPermiso();
            AudLogin.Username = PhxUser.Username;
            AudLogin.IdUsuario = PhxUser.Id;
            AudLogin.Fullname = PhxUser.Fullname;
            this.Save(AudLogin);
        }
        /// <summary>
        /// Genera el log de auditoria cuando un usuario se loguea, existe en el sistema,
        /// está deshabilitado
        /// </summary>
        /// <param name="PhxUser"></param>
        public void LogDeshab(PhxUserEntity PhxUser)
        {
            AuditLoginEntity AudLogin = new AuditLoginEntity();
            // falta definir el evento para cuando un usuario existe pero no tiene permiso
            AudLogin.Evento = new EventoLoginBusiness().GetEventoUsrNoActivo();
            AudLogin.Username = PhxUser.Username;
            AudLogin.IdUsuario = PhxUser.Id;
            AudLogin.Fullname = PhxUser.Fullname;
            this.Save(AudLogin);
        }

        /// <summary>
        /// Genera el log de auditoria cuando un usuario intenta ingresar y 
        /// el nombre de usuario o la contraseña es incorrecto
        /// </summary>
        /// <param name="PhxUser"></param>
        public void LogUsrConInexistente(int? userid, string username, string fullname, string terminal, App application)
        {
            EventoLoginEntity evento = new EventoLoginBusiness().GetEventoUsrConIncorrecto();

            Log(userid, username, fullname, terminal, application, evento);
        }

        public PhalanxCommon.Collections.AuditLoginEntityCollection GetAll(string FechaDesde, string FechaHasta)
        {
            AuditLoginFactory AudLogFac = new AuditLoginFactory();
            if (FechaDesde != "" && FechaDesde.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                AudLogFac.FilFDesde = Convert.ToDateTime(FechaDesde, dtfi);
            }
            if (FechaHasta != "" && FechaHasta.Trim() != "/  /")
            {
                System.Globalization.DateTimeFormatInfo dtfi = new
                    System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd/MM/yyyy";
                AudLogFac.FilFHasta = Convert.ToDateTime(FechaHasta, dtfi);
            }
            return AudLogFac.GetAll();
        }

        private void Log(int? userid, string username, string fullname, string terminal, App application, EventoLoginEntity evento)
        {
            AuditLoginEntity AudLogin = new AuditLoginEntity();
            AudLogin.Evento = evento;
            AudLogin.Username = username;
            AudLogin.Fullname = fullname;
            AudLogin.Terminal = terminal;
            AudLogin.Application = application;
            AudLogin.IdUsuario = userid;

            this.Save(AudLogin);
        }

        public void Depurar(DateTime fecha)
        {
            new AuditLoginFactory().Depurar(fecha);
        }
    }
}
