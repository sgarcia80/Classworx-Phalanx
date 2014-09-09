using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;

namespace PhalanxBL
{
    public class AuditUsuariosBusiness
    {
        public void Save(AuditUsuariosEntity AudUsr)
        {
            new AuditUsuariosFactory().Save(AudUsr);
        }
        private AuditUsuariosEntity GenerateLog(PhxUserEntity Responsable, PhxUserEntity NewReg, PhxUserEntity OldReg)
        {
            AuditPhxUserEntity NewAuditUsrE, OldAuditUsrE;
            AuditUsuariosEntity LogAuditUsr = new AuditUsuariosEntity();
            // Convertir NewReg a Log
            if (NewReg != null)
            {
                NewAuditUsrE = CreateAudit(NewReg);
                LogAuditUsr.AuditPhxUserNew = NewAuditUsrE;
            }
            if (OldReg != null)
            {
                OldAuditUsrE = CreateAudit(OldReg);
                LogAuditUsr.AuditPhxUserOld = OldAuditUsrE;
            }
            LogAuditUsr.Recurso = "Phalanx";
            //LogAuditUsr.Fecha = DateTime.Now;
            if (OldReg == null && NewReg != null)
            {
                LogAuditUsr.Operacion = "Alta";
                LogAuditUsr.IdUsuario = NewReg.Id;
                LogAuditUsr.Username = NewReg.Username;
                LogAuditUsr.Fullname = NewReg.Fullname;
            }
            else if (OldReg != null && NewReg == null)
            {
                LogAuditUsr.Operacion = "Baja";
                LogAuditUsr.IdUsuario = OldReg.Id;
                LogAuditUsr.Username = OldReg.Username;
                LogAuditUsr.Fullname = OldReg.Fullname;
            }
            else if (OldReg != null && NewReg != null)
            {
                LogAuditUsr.Operacion = "Modificación";
                LogAuditUsr.IdUsuario = NewReg.Id;
                LogAuditUsr.Username = NewReg.Username;
                LogAuditUsr.Fullname = NewReg.Fullname;
            }
            LogAuditUsr.IdUsuarioABM = Responsable.Id;
            LogAuditUsr.UsernameABM = Responsable.Username;
            LogAuditUsr.FullnameABM = Responsable.Fullname;
            LogAuditUsr.AccionSatisfactoria = true;
            return LogAuditUsr;

        }

        private static AuditPhxUserEntity CreateAudit(PhxUserEntity NewReg)
        {
            AuditPhxUserEntity NewAuditUsrE = new AuditPhxUserEntity();
            NewAuditUsrE.Active = NewReg.Active;
            NewAuditUsrE.Branch = NewReg.Branch;
            NewAuditUsrE.BuildingAdress = NewReg.BuildingAdress;
            NewAuditUsrE.BuildingFloor = NewReg.BuildingFloor;
            NewAuditUsrE.CreationDate = NewReg.CreationDate;
            NewAuditUsrE.DeleteDate = NewReg.DeleteDate;
            NewAuditUsrE.Domain = NewReg.Domain;
            NewAuditUsrE.Email = NewReg.Email;
            NewAuditUsrE.ExtensionNumber = NewReg.ExtensionNumber;
            NewAuditUsrE.FileNumber = NewReg.FileNumber;
            NewAuditUsrE.Fullname = NewReg.Fullname;
            NewAuditUsrE.Function = NewReg.Function;
            NewAuditUsrE.PhxUserId = NewReg.Id;
            NewAuditUsrE.RelationType = NewReg.RelationType;
            NewAuditUsrE.SupId = NewReg.PhxUserSuperior.Id;
            NewAuditUsrE.SupMail = NewReg.PhxUserSuperior.Mail;
            NewAuditUsrE.SupName = NewReg.PhxUserSuperior.Name;
            NewAuditUsrE.Username = NewReg.Username;
            return NewAuditUsrE;
        }
        /// <summary>
        /// Graba el los de auditoria para Usuarios
        /// </summary>
        /// <param name="Responsable">Usuario logueado que está haciendo la acción</param>
        /// <param name="IdReg">Id del registro que se está modificando. Si es 0 es un alta</param>
        /// <param name="NewReg">Registro que se va a guardar en la base</param>
        public AuditUsuariosEntity GenerateLog(PhxUserEntity Responsable, int IdReg, PhxUserEntity NewReg)
        {
            PhxUserEntity OldReg = null;
            // si el IdReg != 0 hay que traer el registro de la base
            if (IdReg > 0)
            {
                OldReg = new PhxUsersFactory().Load(IdReg);
            }
            return this.GenerateLog(Responsable, NewReg, OldReg);
        }

        public PhalanxCommon.Collections.AuditUsuariosEntityCollection GetAll(string FechaDesde, string FechaHasta)
        {
            AuditUsuariosFactory AudLogFac = new AuditUsuariosFactory();
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
    }
}
