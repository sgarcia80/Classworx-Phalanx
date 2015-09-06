using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using PhalanxDAL.Factories;
using System.Collections;
using PhalanxNAL;

namespace PhalanxBL
{
    public class PhxUserBusiness
    {
        private Nullable<bool> _filActive = null;
        public Nullable<bool> FilActive
        {
            set { _filActive = value; }
        }
        private string _filNombreGral = "";
        public string FilNombreGral
        {
            set { _filNombreGral = value; }
        }
        public PhxUserEntityCollection Search(string NombreGral)
        {
            PhxUsersFactory WDF = new PhxUsersFactory();
            WDF.FilNombreGral = NombreGral;
            return WDF.GetAll();

        }
        public PhxUserEntityCollection GetAllWithGroupsAndRoles()
        {
            PhxUsersFactory WDF = new PhxUsersFactory();
            WDF.FilNombreGral = _filNombreGral;
            WDF.FilActive = _filActive;
            WDF.CargaGrupos = true;
            WDF.CargaGruposSeguim = true;
            WDF.CargaRoles = true;
            WDF.FilDeleted = false; // solo los activos
            return WDF.GetAll();

        }
        public int Save(PhxUserEntity Usuario, string Responsable)
        {
            PhxUsersFactory DerivFac = new PhxUsersFactory();
            PhxUsersFactory PUF = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = PUF.GetPhxUser(Responsable);

            if (Usuario.Id == 0)
            {
                return DerivFac.Save(Usuario, PhxUsrE);
            }
            else
            {
                return DerivFac.Update(Usuario, PhxUsrE);
            }
        }
        /// <summary>
        /// Setea los roles para ese usuario. Solo setea los que se pasan. Borra los
        /// que tenga asignados y no estén en la collection
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="UsrRoles"></param>
        public void SetRoles(PhxUserEntity Usuario, PhxRoleEntityCollection UsrRoles, string Responsable)
        {
            PhxUsersFactory UsrFac = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = UsrFac.GetPhxUser(Responsable);
            UsrFac.SetRoles(PhxUsrE, Usuario, UsrRoles);

        }
        public void SetGrupos(PhxUserEntity Usuario, RequestGroupEntityCollection UsrGrps)
        {
            PhxUsersFactory UsrFac = new PhxUsersFactory();
            UsrFac.SetGrupos(Usuario, UsrGrps);
        }
        public int InactivateUser(PhxUserEntity Usuario, string Responsable)
        {
            //Usuario.DeleteDate = DateTime.Now;
            Usuario.Active = false;
            return this.Save(Usuario, Responsable);
        }
        public bool IsDeleteable(PhxUserEntity Usuario)
        {
            PhxUsersFactory UsrFac = new PhxUsersFactory();
            return UsrFac.IsDeleteable(Usuario);

        }

        public PhxUserEntity GetUserByDomUsr(string DomUsr)
        {
            return new PhxUsersFactory().GetPhxUser(DomUsr);
        }
        //public bool AuthenticateUser(string domusername)

        public PhxUserEntity AuthenticateUser(string domusername)
        {
            // toma el usuario de windows conectado con el formato dominio\usuario
            String username = domusername;

            // chequea si es un usuario habilitado en el sistema
            PhxUserEntity AuthUser = this.IsSysUser(username);

            if (AuthUser == null)
            {
                //return false;
                return null;
            }

            //this.m_SysUser = AuthUser;

            //return true;
            return AuthUser;

        }

        /// <summary>
        /// Busca el usuario en la base de datos por dominio\usuario
        /// </summary>
        /// <param name="usernamedomain">Dominio\usuario</param>
        /// <returns>Objeto SysUser correspondiente al usuario buscado. Null si no se encontró usuario</returns>
        public PhxUserEntity IsSysUser(string usernamedomain)
        {
            PhxUsersFactory PUF = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = PUF.GetPhxUser(usernamedomain);
            return PhxUsrE;
            //SysUser 

        }
        public PhxUserEntity IsActiveSysUser(string usernamedomain)
        {
            PhxUsersFactory PUF = new PhxUsersFactory();
            PUF.FilActive = true;
            PhxUserEntity PhxUsrE = PUF.GetPhxUser(usernamedomain);
            return PhxUsrE;
            //SysUser 

        }
        public PhxUserEntity AdmLogin(string usernamedomain)
        {
            PhxUsersFactory PUF = new PhxUsersFactory();
            PhxUserEntity PhxUsrE = PUF.GetPhxUser(usernamedomain);
            AuditLoginBusiness AudLogBL = new AuditLoginBusiness();
            if (PhxUsrE == null)
            {
                // hay que loguear el intento de login de usr inexistente
                AudLogBL.LogUsrInexist(usernamedomain);
                return null;
            }
            else
            {
                if (PhxUsrE.Active)
                {
                    if (ChkAccAdminApp(PhxUsrE))
                    {
                        // loguea acceso exitoso
                        AudLogBL.LogAccOK(PhxUsrE);
                    }
                    else
                    {
                        // loguea que no tiene permiso
                        AudLogBL.LogNoAcces(PhxUsrE);
                        return null;
                    }
                }
                else
                {
                    // loguea que está bloqueado
                    AudLogBL.LogDeshab(PhxUsrE);
                    return null;
                }
            }
            return PhxUsrE;

        }


        private const string ADMIN_ACCESS = "ADMINACC";
        private const string WEBAPP_ACCESS = "WEBAPPACC";
        private const string ADMINMENU_ACCESS = "ADMMENUACC";
        private const string USERSMENU_ACCESS = "USERSMENUACC";
        private const string DOMAINSMENU_ACCESS = "DOMAINSMENUACC";
        private const string PCSMENU_ACCESS = "PCSMENUACC";
        private const string PWDSMENU_ACCESS = "PWDSMENUACC";
        private const string GROUPSMENU_ACCESS = "GROUPSMENUACC";
        private const string PWDS_REQUEST = "PWDRQST";
        private const string DELEG_REQUEST = "DELEGRQST";
        private const string AUTH_PWDRQST = "AUTHPWDRQSTS";
        private const string AUTH_DELEGRQST = "AUTHDELEGRQSTS";


        private const string CONF_MAILS_RW = "@CONF_MAILS_RW@"; //Configuración de Parametría de Mails - Escritura
        private const string CONF_MAILS_R = "@CONF_MAILS_R@"; //Configuración de Parametría de Mails - Lectura
        private const string CONF_EDIFICIOS_RW = "@CONF_EDIFICIOS_RW@"; //Configuración de Edificios - Escritura
        private const string CONF_EDIFICIOS_R = "@CONF_EDIFICIOS_R@"; //Configuración de Edificios - Lectura
        private const string CONF_SUPERV_RW = "@CONF_SUPERV_RW@"; //Configuración de Supervisores - Escritura
        private const string CONF_SUPERV_R = "@CONF_SUPERV_R@"; //Configuración de Supervisores - Lectura
        private const string CONF_GRUPO_SEGUIM_ATM_RW = "@CONF_GRUPO_SEGUIM_ATM_RW@"; //Configuración de Grupo de Seguimiento de Solicitudes por Defecto para ATMs - Escritura
        private const string CONF_GRUPO_SEGUIM_ATM_R = "@CONF_GRUPO_SEGUIM_ATM_R@"; //Configuración de Grupo de Seguimiento de Solicitudes por Defecto para ATMs - Lectura
        private const string ADM_DOMINIOS_RW = "@ADM_DOMINIOS_RW@"; //Administración de Dominios - Escritura
        private const string ADM_DOMINIOS_R = "@ADM_DOMINIOS_R@"; //Administración de Dominios - Lectura
        private const string CONF_APP_BPM_RW = "@CONF_APP_BPM_RW@"; //Administración de Aplicativos BPM - Escritura
        private const string CONF_APP_BPM_R = "@CONF_APP_BPM_R@"; //Administración de Aplicativos BPM - Lectura
        private const string ADM_EQ_WIN_RW = "@ADM_EQ_WIN_RW@"; //Administración de Equipos Windows - Escritura
        private const string ADM_EQ_WIN_R = "@ADM_EQ_WIN_R@"; //Administración de Equipos Windows - Lectura
        private const string ADM_EQ_AS400_RW = "@ADM_EQ_AS400_RW@"; //Administración de Equipos AS400 - Escritura
        private const string ADM_EQ_AS400_R = "@ADM_EQ_AS400_R@"; //Administración de Equipos AS400 - Lectura
        private const string ADM_EQ_UNIX_RW = "@ADM_EQ_UNIX_RW@"; //Administración de Equipos Unix - Escritura
        private const string ADM_EQ_UNIX_R = "@ADM_EQ_UNIX_R@"; //Administración de Equipos Unix - Lectura
        private const string ADM_BD_RW = "@ADM_BD_RW@"; //Administración de Bases de Datos - Escritura
        private const string ADM_BD_R = "@ADM_BD_R@"; //Administración de Bases de Datos - Lectura
        private const string ADM_APP_RW = "@ADM_APP_RW@"; //Administración de Aplicativos - Escritura
        private const string ADM_APP_R = "@ADM_APP_R@"; //Administración de Aplicativos - Lectura
        private const string ADM_EQ_COM_RW = "@ADM_EQ_COM_RW@"; //Administración de Equipos de Comunicación - Escritura
        private const string ADM_EQ_COM_R = "@ADM_EQ_COM_R@"; //Administración de Equipos de Comunicación - Lectura
        private const string ADM_USR_RW = "@ADM_USR_RW@"; //Administración de Usuarios del Sistema - Escritura
        private const string ADM_USR_R = "@ADM_USR_R@"; //Administración de Usuarios del Sistema - Lectura
        private const string ADM_GRP_SOLIC_RW = "@ADM_GRP_SOLIC_RW@"; //Administración de Grupos de Solicitudes - Escritura
        private const string ADM_GRP_SOLIC_R = "@ADM_GRP_SOLIC_R@"; //Administración de Grupos de Solicitudes - Lectura
        private const string PWD_WIN_R = "@PWD_WIN_R@"; //Administración de Contraseñas Windows - Lectura
        private const string PWD_WIN_RW = "@PWD_WIN_RW@"; //Administración de Contraseñas Windows - Escritura
        private const string PWD_AS400_RW = "@PWD_AS400_RW@"; //Administración de Contraseñas AS400 - Escritura
        private const string PWD_AS400_R = "@PWD_AS400_R@"; //Administración de Contraseñas AS400 - Lectura
        private const string PWD_UNIX_RW = "@PWD_UNIX_RW@"; //Administración de Contraseñas Unix - Escritura
        private const string PWD_UNIX_R = "@PWD_UNIX_R@"; //Administración de Contraseñas Unix - Lectura
        private const string PWD_BD_RW = "@PWD_BD_RW@"; //Administración de Contraseñas de Bases de Datos - Escritura
        private const string PWD_BD_R = "@PWD_BD_R@"; //Administración de Contraseñas de Bases de Datos - Lectura
        private const string PWD_APP_RW = "@PWD_APP_RW@"; //Administración de Contraseñas de Aplicativos - Escritura
        private const string PWD_APP_R = "@PWD_APP_R@"; //Administración de Contraseñas de Aplicativos - Lectura
        private const string PWD_EQ_COM_RW = "@PWD_EQ_COM_RW@"; //Administración de Contraseñas de Equipos de Comunicación - Escritura
        private const string PWD_EQ_COM_R = "@PWD_EQ_COM_R@"; //Administración de Contraseñas de Equipos de Comunicación - Lectura
        private const string PWD_ATM_RW = "@PWD_ATM_RW@"; //Administración de Contraseñas de ATMs - Escritura
        private const string PWD_ATM_R = "@PWD_ATM_R@"; //Administración de Contraseñas de ATMs - Lectura
        private const string RPT_LIST_PWD = "@RPT_LIST_PWD@"; //Listado de Contraseñas
        private const string RPT_PLAN_CTRL_CLAVES = "@RPT_PLAN_CTRL_CLAVES@"; //Planilla de Control de Utilización de Claves en Custodia
        private const string RPT_INVENT_CLAVES = "@RPT_INVENT_CLAVES@"; //Inventario de Claves en Custodia
        private const string RPT_LOG_MODIF_PWD = "@RPT_LOG_MODIF_PWD@"; //Log de Modificación de Contraseñas
        private const string RPT_MAILS = "@RPT_MAILS@"; //Reporte de Mails y Notificaciones
        private const string RPT_HIST_PWD = "@RPT_HIST_PWD@"; //Histórico de Contraseñas
        private const string RPT_ABM_USR = "@RPT_ABM_USR@"; //Reporte de ABM de Usuarios
        private const string RPT_ASIG_PERF = "@RPT_ASIG_PERF@"; //Reporte de asginación de Perfiles
        private const string RPT_LOGIN = "@RPT_LOGIN@"; //Reporte de Logueos al sistema
        private const string RPT_LIST_USR_PWD = "@RPT_LIST_USR_PWD@"; //Listado de Usuarios
        private const string RPT_USR_POR_PERF = "@RPT_USR_POR_PERF@"; //Listado de Usuarios Por Perfil
        private const string RPT_LIST_PERFILES_PWD = "@RPT_LIST_PERFILES_PWD@"; //Listado de Perfiles
        private const string ADM_GRP_SEG_SOLIC_R = "@ADM_GRP_SEG_SOLIC_R@"; //Administración de grupos de seguimientos de solicitudes - Lectura
        private const string ADM_GRP_SEG_SOLIC_RW = "@ADM_GRP_SEG_SOLIC_RW@"; //Administración de grupos de seguimientos de solicitudes - Escritura
        private const string ADM_PERFILES_R = "@ADM_PERFILES_R@"; //Administración de Perfiles - Lectura
        private const string ADM_PERFILES_RW = "@ADM_PERFILES_RW@"; //Administración de Perfiles - Escritura
        private const string SEGUIMIENTO_SOLIC = "@SEGUIMIENTO_SOLIC@"; //Seguimiento de solicitudes
        private const string CONSULTA_PWD = "@CONSULTA_PWD@"; //Consulta de Contraseñas
        private const string RPT_ABM_PERF = "@RPT_ABM_PERF@"; //Reporte de ABM de Perfiles
        private const string RPT_ASIG_PERM = "@RPT_ASIG_PERM@"; //Reporte de asginación de Permisos
        private const string ACTIVACION_ESQUEMA = "@ACTIVACION_ESQUEMA@"; //Activacion de esquema de conexion ya sea produccion o contingencia
        private const string CHK_WIN_PWD = "@CHK_WIN_PWD@"; //manejo de lotes de chequeos de contraseñas de usuarios de equipos windows
        private const string RPT_LIST_TICKETS_PWD = "@RPT_LIST_TICKETS_PWD@"; //Listado de Perfiles
        private const string RPT_TICKETS_RED_REC_EXT = "@RPT_TICKETS_ALTA_RED_REC_EXT@"; //Listado de Perfiles
        private const string TICKETS = "@Tickets@"; //Control de notificación de tickets
        private const string DEPURACION_LOGS = "@DEPURACION_LOGS@"; //Depuración de logs
        private const string CONF_SUBSI_RW = "@CONF_SUBSI_RW@"; //Configuración de Subsidiarias - Escritura
        private const string CONF_SUBSI_R = "@CONF_SUBSI_R@"; //Configuración de Subsidiarias - Lectura

        private const string RPT_USR_GRP_SOL = "@RPT_USR_GRP_SOL@";
        private const string RPT_USR_GRP_SEG_SOL = "@RPT_USR_GRP_SEG_SOL@";
        private const string RPT_PWD_GRP_SOL = "@RPT_PWD_GRP_SOL@";

        /// <summary>
        /// Chequea si el usuario tiene acceso a la aplicación WEB
        /// </summary>
        /// <returns>True si el usuario tiene acceso. False si no lo tiene</returns>
        public bool ChkAccWebApp(PhxUserEntity PhxUser)
        {
            string[] PrivilegiosAccesoAppAdmin = new string[] { SEGUIMIENTO_SOLIC, CONSULTA_PWD };
            return this.UsrHasAnyPrivilege(PhxUser, PrivilegiosAccesoAppAdmin);

            //return this.CheckRole(PhxUser, WEBAPP_ACCESS);
        }
        public bool CheckRole(PhxUserEntity PhxUser, string RoleCode)
        {
            PhxRolesUsersFactory PRUF = new PhxRolesUsersFactory();
            return PRUF.UserHasRole(PhxUser, RoleCode);

        }
        private bool UsrHasAnyPrivilege(PhxUserEntity Usuario, string[] Privileges)
        {

            return new PhxRolesUsersFactory().UserHasAnyPrivilege(Usuario, Privileges);
        }
        private bool UsrHasAnyPrivilege(string usernamedomain, string[] Privileges)
        {
            PhxUsersFactory PUF = new PhxUsersFactory();
            PhxUserEntity Usuario = PUF.GetPhxUser(usernamedomain);

            return this.UsrHasAnyPrivilege(Usuario, Privileges);
        }
        /// <summary>
        /// Chequea si el usuario tiene acceso a la aplicación administrativa
        /// </summary>
        /// <param name="PhxUser"></param>
        /// <returns></returns>
        public bool ChkAccAdminApp(PhxUserEntity PhxUser)
        {
            string[] PrivilegiosAccesoAppAdmin = new string[] { CONF_MAILS_RW, CONF_MAILS_R, CONF_EDIFICIOS_RW
                , CONF_EDIFICIOS_R, CONF_SUPERV_RW, CONF_SUPERV_R, ADM_DOMINIOS_RW, ADM_DOMINIOS_R
                , ADM_EQ_WIN_RW, ADM_EQ_WIN_R, ADM_EQ_AS400_RW, ADM_EQ_AS400_R, ADM_EQ_UNIX_RW, ADM_EQ_UNIX_R
                , ADM_BD_RW, ADM_BD_R, ADM_APP_RW, ADM_APP_R, ADM_EQ_COM_RW, ADM_EQ_COM_R, ADM_USR_RW, ADM_USR_R
                , ADM_GRP_SOLIC_RW, ADM_GRP_SOLIC_R, PWD_WIN_R, PWD_WIN_RW, PWD_AS400_RW, PWD_AS400_R, PWD_UNIX_RW
                , PWD_UNIX_R, PWD_BD_RW, PWD_BD_R, PWD_APP_RW, PWD_APP_R, PWD_EQ_COM_RW, PWD_EQ_COM_R, RPT_LIST_PWD
                , RPT_PLAN_CTRL_CLAVES, RPT_INVENT_CLAVES, RPT_LOG_MODIF_PWD, RPT_MAILS, RPT_HIST_PWD, RPT_ABM_USR
                , RPT_ASIG_PERF, RPT_LOGIN, RPT_LIST_USR_PWD, RPT_LIST_PERFILES_PWD, RPT_LIST_TICKETS_PWD
                , ADM_GRP_SEG_SOLIC_R, ADM_GRP_SEG_SOLIC_RW, ADM_PERFILES_R, ADM_PERFILES_RW, RPT_ABM_PERF
                , RPT_ASIG_PERM , CONF_GRUPO_SEGUIM_ATM_RW , CONF_GRUPO_SEGUIM_ATM_R , PWD_ATM_R , PWD_ATM_RW
            };
            return this.UsrHasAnyPrivilege(PhxUser, PrivilegiosAccesoAppAdmin);
            // return this.CheckRole(PhxUser, ADMIN_ACCESS);
        }
        public bool AccAdmAplicativos(string usernamedomain)
        {

            string[] PrivilegiosAcceso = new string[] { ADM_APP_RW, ADM_APP_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqUnix(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_UNIX_RW, ADM_EQ_UNIX_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqWin(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_WIN_RW, ADM_EQ_WIN_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqAS400(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_AS400_RW, ADM_EQ_AS400_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmDominiosWin(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_DOMINIOS_RW, ADM_DOMINIOS_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmBD(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_BD_RW, ADM_BD_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccAdmEqCom(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_COM_RW, ADM_EQ_COM_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccAdmUsuarios(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_USR_RW, ADM_USR_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmGrpsSolicitudes(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_GRP_SOLIC_RW, ADM_GRP_SOLIC_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmGrpsSeguimSolicitudes(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_GRP_SEG_SOLIC_R, ADM_GRP_SEG_SOLIC_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamConfigMails(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_MAILS_RW, CONF_MAILS_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccParamEdificios(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_EDIFICIOS_RW, CONF_EDIFICIOS_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccParamSupervisores(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_SUPERV_RW, CONF_SUPERV_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccParamGrpSeguimATM(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_GRUPO_SEGUIM_ATM_RW, CONF_GRUPO_SEGUIM_ATM_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamGrpSeguimATMRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_GRUPO_SEGUIM_ATM_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccAdmPerfiles(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_PERFILES_R, ADM_PERFILES_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdWin(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_WIN_R, PWD_WIN_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdUnix(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_UNIX_RW, PWD_UNIX_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdAS400(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_AS400_RW, PWD_AS400_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdBD(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_BD_RW, PWD_BD_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdApp(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_APP_RW, PWD_APP_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccPwdEqCom(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_EQ_COM_RW, PWD_EQ_COM_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccATM(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_ATM_RW, PWD_ATM_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccATMRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_ATM_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccRptLstPwd(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LIST_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptPlanCtrlPwd(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_PLAN_CTRL_CLAVES };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptInventPwd(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_INVENT_CLAVES };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptABMUsr(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_ABM_USR };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptAsigPerf(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_ASIG_PERF };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptLstUsr(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LIST_USR_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptUsrPorPerf(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_USR_POR_PERF };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptABMPerf(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_ABM_PERF };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptAsigPerm(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_ASIG_PERM };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptLstPerf(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LIST_PERFILES_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptLogModifPwd(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LOG_MODIF_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptMailsNotif(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_MAILS };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptHistPwd(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_HIST_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptLogin(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LOGIN };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptUsrGrpSol(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_USR_GRP_SOL };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptUsrGrpSegSol(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_USR_GRP_SEG_SOL };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccRptPwdGrpSol(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_PWD_GRP_SOL };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamConfigMailsRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_MAILS_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccParamEdificiosRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_EDIFICIOS_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccParamSupervisoresRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_SUPERV_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmPerfilesRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_PERFILES_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccAdmDominiosWinRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_DOMINIOS_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqWinRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_WIN_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqUnixRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_UNIX_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmEqAS400RW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_AS400_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmBDRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_BD_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmAplicativosRW(string usernamedomain)
        {

            string[] PrivilegiosAcceso = new string[] { ADM_APP_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmUsuariosRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_USR_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmGrpsSolicitudesRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_GRP_SOLIC_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccAdmGrpsSeguimSolicitudesRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_GRP_SEG_SOLIC_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccAdmEqComRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ADM_EQ_COM_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccPwdAS400RW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_AS400_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdAppRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_APP_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdUnixRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_UNIX_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdWinRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_WIN_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }
        public bool AccPwdBDRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_BD_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccPwdEqComRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { PWD_EQ_COM_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccRptLstTickets(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_LIST_TICKETS_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccRptTicketsRedRecExt(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { RPT_TICKETS_RED_REC_EXT };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool PermisoActivacionEsquema(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { ACTIVACION_ESQUEMA };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool ChkPwdsRequest(PhxUserEntity PhxUser)
        {
            string[] PrivilegiosAccesoAppAdmin = new string[] { CONSULTA_PWD };
            return this.UsrHasAnyPrivilege(PhxUser, PrivilegiosAccesoAppAdmin);

            //return this.CheckRole(PhxUser, PWDS_REQUEST);
        }
        public bool AccChkWinPwd(string usernamedomain)
        {
            string[] PrivilegiosAccesoAppAdmin = new string[] { CHK_WIN_PWD };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAccesoAppAdmin);
        }

        public bool ChkAuthPwdRequest(PhxUserEntity PhxUser)
        {
            string[] PrivilegiosAccesoAppAdmin = new string[] { SEGUIMIENTO_SOLIC };
            return this.UsrHasAnyPrivilege(PhxUser, PrivilegiosAccesoAppAdmin);

            //return this.CheckRole(PhxUser, AUTH_PWDRQST);
        }

        public bool AccParamAplicativosBMP(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_APP_BPM_RW, CONF_APP_BPM_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamAplicativosBMPRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_APP_BPM_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccTickets(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { TICKETS };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccDepuracionLogs(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { DEPURACION_LOGS };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamSubsidiarias(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_SUBSI_RW, CONF_SUBSI_R };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool AccParamSubsidiariasRW(string usernamedomain)
        {
            string[] PrivilegiosAcceso = new string[] { CONF_SUBSI_RW };
            return this.UsrHasAnyPrivilege(usernamedomain, PrivilegiosAcceso);
        }

        public bool ChkMenuSistema(PhxUserEntity PhxUser)
        {
            return this.CheckRole(PhxUser, ADMIN_ACCESS);
        }

        public PhxUserEntityCollection GetAllAuth()
        {
            PhxUsersFactory PhxUsrFac = new PhxUsersFactory();
            return PhxUsrFac.GetPhxUsersByRole(AUTH_PWDRQST);
        }
        public PhxUserEntityCollection GetAllFollowPwdRqstAuth(UserPasswordEntity UserPassword)
        {
            PhxUsersFactory PhxUsrFac = new PhxUsersFactory();
            return PhxUsrFac.GetAllFollowPwdRqstAuth(UserPassword);
        }
        public PhxUserEntityCollection GetAuthForFilter()
        {
            PhxUserEntityCollection PhxUsrEC = new PhxUsersFactory().GetPhxUsersByRole(AUTH_PWDRQST);
            if (PhxUsrEC == null)
            {
                PhxUsrEC = new PhxUserEntityCollection();
            }
            PhxUserEntity PhxUsrNinguno = new PhxUserEntity();
            PhxUsrNinguno.Fullname = "-- Ninguno --";
            PhxUsrEC.Insert(0, PhxUsrNinguno);
            return PhxUsrEC;
        }
        public PhxUserEntity Load(int Id)
        {
            return new PhxUsersFactory().GetPhxUserByID(Id);
        }

        public void SetGruposSeguim(PhxUserEntity Usuario, FollowupRequestGroupEntityCollection UsrGroupsSeguim)
        {
            PhxUsersFactory UsrFac = new PhxUsersFactory();
            UsrFac.SetGruposSeguim(Usuario, UsrGroupsSeguim);
        }

        public IList GetAllByGrupoSolicitud(string nombreGrupo, bool? grupoActivo, bool? usuarioActivo)
        {
            return new PhxUsersFactory().GetAllByGrupoSolicitud(nombreGrupo, grupoActivo, usuarioActivo);
        }

        public IList GetAllByGrupoSeguimientoSolicitud(string nombreGrupo, bool? grupoActivo, bool? usuarioActivo)
        {
            return new PhxUsersFactory().GetAllByGrupoSeguimientoSolicitud(nombreGrupo, grupoActivo, usuarioActivo);
        }
        private string _UsuariosInactivadosOK = "";
        private string _UsuariosInactivadosNOK = "";
        public string UsuariosInactivadosOK { get { return _UsuariosInactivadosOK; } }
        public string UsuariosInactivadosNOK { get { return _UsuariosInactivadosNOK; } }
        public IList<PhxUserEntity> InactivarInexistentesEnAD()
        {
            IList<PhxUserEntity> listaUsuariosInactivados = new List<PhxUserEntity>();

            PhxUsersFactory WDF = new PhxUsersFactory();

            WDF.FilActive = true; // solo los activos

            PhxLogUsuarioInactivadoBusiness luib = new PhxLogUsuarioInactivadoBusiness();

            WinDomainBusiness wdb = new WinDomainBusiness();

            IDictionary<string, string> ldapPaths = new Dictionary<string, string>();

            foreach (PhxUserEntity usuario in WDF.GetAll())
            {
                try
                {
                    if (!ldapPaths.ContainsKey(usuario.Domain))
                    {
                        WinDomainEntity winDomain = wdb.GetByNtName(usuario.Domain);

                        ldapPaths[usuario.Domain] = winDomain != null ? winDomain.LDAPPath : string.Empty;
                    }

                    string ldapPath = ldapPaths[usuario.Domain];

                    if (!string.IsNullOrEmpty(ldapPath))
                    {
                        if (ActiveDirectoryHelper.LDAPPathExists(ldapPath))
                        {
                            if (!ActiveDirectoryHelper.UsuarioExiste(ldapPath, usuario.Username))
                            {
                                InactivateUser(usuario, System.Security.Principal.WindowsIdentity.GetCurrent().Name);

                                PhxLogUsuarioInactivado logUsuario = new PhxLogUsuarioInactivado();
                                logUsuario.Domain = usuario.Domain;
                                logUsuario.Fullname = usuario.Fullname;
                                logUsuario.PhxUser = usuario;
                                logUsuario.Username = usuario.Username;

                                luib.Save(logUsuario);

                                listaUsuariosInactivados.Add(usuario);
                                _UsuariosInactivadosOK += usuario.Domain + @"\" + usuario.Username + " - " + usuario.Fullname + Environment.NewLine;

                            }
                        }
                        else
                        {
                            _UsuariosInactivadosNOK += usuario.Domain + @"\" + usuario.Username + " - " + usuario.Fullname + Environment.NewLine;
                        }
                    }
                }
                catch
                {
                    _UsuariosInactivadosNOK += usuario.Domain + @"\" + usuario.Username + " - " + usuario.Fullname + Environment.NewLine;
                }
            }

            return listaUsuariosInactivados;
        }
    }
}
