using System;
using System.Collections;
//using PhalanxDAL;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
    /// <summary>
    /// Summary description for PhxUsersFactory.
    /// </summary>
    public class PhxUsersFactory
    {
        private Nullable<bool> _filDeleted;
        public Nullable<bool> FilDeleted
        {
            set { _filDeleted = value; }
        }
        private string _filNombreGral = "";
        public string FilNombreGral
        {
            set { _filNombreGral = value; }
            //get { return _filNombre; }
        }
        private bool _cargaRoles = false;
        private bool _cargaGrupos = false;
        private bool _cargaGruposSeguim = false;
        public bool CargaRoles
        {
            set { _cargaRoles = value; }
        }
        public bool CargaGrupos
        {
            set { _cargaGrupos = value; }
        }
        public bool CargaGruposSeguim
        {
            set { _cargaGruposSeguim = value; }
        }
        private Nullable<bool> _filActive = null;
        public Nullable<bool> FilActive
        {
            set { _filActive = value; }
        }

        public PhxUsersFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public PhxUserEntity GetPhxUserByID(int PhxUsrId)
        {
            try
            {
                PhxUserEntity objUser = null;
                //ITransaction tx = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    //objUser = (PhxUserEntity)session.Load(typeof(PhxUserEntity), PhxUsrId);
                    objUser = session.CreateCriteria(typeof(PhxUserEntity)).Add(Expression.Eq("Id", PhxUsrId)).List<PhxUserEntity>()[0];
                }
                return objUser;
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                return null;
            }
            catch (NHibernate.HibernateException NHEx)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Busca el Usuario de Phx correspondiente al nombre de usuario y dominio
        /// </summary>
        /// <param name="PhxUsrName">Nombre de usuario de dominio</param>
        /// <param name="PhxUsrDomain">Nombre del dominio al que pertenece el usuario</param>
        /// <returns>Devuelve el objeto PhxUser</returns>
        public PhxUserEntity GetPhxUser(string PhxUsrName, string PhxUsrDomain)
        {
            string strDomUsr = PhxUsrDomain + "\\" + PhxUsrName;
            return GetPhxUser(strDomUsr);
        }
        /// <summary>
        /// Busca el Usuario de Phx correspondiente al nombre de usuario y dominio
        /// </summary>
        /// <param name="PhxDomUsrName">Dominio\Usuario</param>
        /// <returns>Devuelve el objeto PhxUser. Si no encuentra datos devuelve null</returns>
        public PhxUserEntity GetPhxUser(string PhxDomUsrName)
        {
            DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                , "Entra a PhxUsersFactory.GetPhxUser(string PhxDomUsrName)"
                , "PhxDomUsrName: " + PhxDomUsrName
                , true, false);

            PhxUserEntity objPU = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PhxUserEntity))
                        .Add(Expression.Sql("lower({alias}.user_domain)+'\\'+lower({alias}.username) = lower('" + PhxDomUsrName + "')"));

                    if (_filActive != null)
                    {
                        DataSearch = DataSearch.Add(Expression.Eq("Active", this._filActive.Value));
                    }
                    IList<PhxUserEntity> PUlst = DataSearch.List<PhxUserEntity>();
                    if (PUlst.Count == 1)
                    {
                        objPU = PUlst[0];

                        if (_cargaGrupos)
                        {
                            int i = objPU.PhxUsersGroupsList.Count;
                        }
                        if (_cargaGruposSeguim)
                        {
                            int i = objPU.PhxUsersFollowupGroupsList.Count;
                        }
                        // si está seteado para que cargue los roles hago el count para que los traiga
                        if (_cargaRoles)
                        {
                            int i = objPU.PhxRolesUsersList.Count;
                        }
                    }
                    else
                    {
                        DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
                            , "PhxUsersFactory.GetPhxUser(string PhxDomUsrName)"
                            , "No se encontró el usuario " + PhxDomUsrName
                            , true, false);
                        //return null;
                    }
                }
                DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
                    , "PhxUsersFactory.GetPhxUser(string PhxDomUsrName)"
                    , "Encontró el usuario"
                    , true, false);
            }
            catch (Exception ex)
            {
                DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
                    , "PhxUsersFactory.GetPhxUser(string PhxDomUsrName)"
                    , "No se encontró el usuario " + PhxDomUsrName + " - Ex: " + ex.Message
                    , true, false);
                //return null;
            }

            return objPU;
        }
        /// <summary>
        /// Busca a todos los usuarios del sistema
        /// </summary>
        /// <returns>Lista completa de Usuarios del sistema ordenados por Username</returns>
        public IList GetPhxUsers()
        {
            IList PUlst = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                PUlst = session.CreateCriteria(typeof(PhxUserEntity)).AddOrder(Order.Asc("Username")).List();
            }
            return PUlst;
        }

        public PhxUserEntityCollection GetAll()
        {
            IList<PhxUserEntity> PUlst = null;
            PhxUserEntityCollection PhxUsrEC = new PhxUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                ICriteria DataSearch = session.CreateCriteria(typeof(PhxUserEntity)).AddOrder(Order.Asc("Username"));
                if (_filDeleted != null)
                {
                    if (_filDeleted.Value)
                    {
                        DataSearch = DataSearch.Add(Expression.IsNotNull("DeleteDate"));
                    }
                    else
                    {
                        DataSearch = DataSearch.Add(Expression.IsNull("DeleteDate"));
                    }
                }
                if (_filNombreGral.Trim() != "")
                {
                    DataSearch = DataSearch.Add(Expression.Or(
                              Expression.Like("Fullname", _filNombreGral, MatchMode.Anywhere)
                            , Expression.Like("Username", _filNombreGral, MatchMode.Anywhere)
                            )
                        );
                }
                if (_filActive != null)
                {
                    DataSearch = DataSearch.Add(Expression.Eq("Active", _filActive.Value));
                }
                // Retrieve data here (with the session)
                PUlst = DataSearch.List<PhxUserEntity>();
                //PUlst = session.CreateCriteria(typeof(PhxUserEntity)).AddOrder(Order.Asc("Username")).List();
                foreach (PhxUserEntity PhxUsrE in PUlst)
                {
                    // si está seteado para que cargue los grupos hago el count para que los traiga
                    if (_cargaGrupos)
                    {
                        int i = PhxUsrE.PhxUsersGroupsList.Count;
                    }
                    if (_cargaGruposSeguim)
                    {
                        int i = PhxUsrE.PhxUsersFollowupGroupsList.Count;
                    }
                    // si está seteado para que cargue los roles hago el count para que los traiga
                    if (_cargaRoles)
                    {
                        int i = PhxUsrE.PhxRolesUsersList.Count;
                    }
                    PhxUsrEC.Add(PhxUsrE);
                }
            }
            return PhxUsrEC;
        }
        
        /// <summary>
        /// Busca a los usuarios del sistema que tengan el rol especificado
        /// </summary>
        /// <param name="rolecode">Rolecode del rol por el cual se filtraran los usuarios</param>
        /// <returns>Lista de Usuarios del sistema que tienen el rol especificado ordenados por Username</returns>
        //public IList GetPhxUsersByRole(string rolecode)
        public PhxUserEntityCollection GetPhxUsersByRole(string rolecode)
        {
            // busca que exista el rol en la base
            PhxRolesFactory PRF = new PhxRolesFactory();
            PhxRoleEntity objPR = PRF.GetPhxRole(rolecode);
            if (objPR == null)
            {
                return null;
            }
            PhxUserEntityCollection PhxUsrEC = new PhxUserEntityCollection();
            IList<PhxUserEntity> PUlst = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                //NHibernate.SqlCommand.SqlString strQry =
                //    new NHibernate.SqlCommand.SqlString("{alias}.phx_role_id = " + objPR.Id);

                // Retrieve data here (with the session)
                PUlst = session.CreateCriteria(typeof(PhxUserEntity)).AddOrder(Order.Asc("Fullname"))
                    .CreateCriteria("PhxRolesUsersList","UsrRoles")
                    //.Add(Expression.Sql(strQry))
                    .Add(Expression.Eq("UsrRoles.PhxRole", objPR))
                    .List<PhxUserEntity>();
                PhxUsrEC.Add(PUlst);
            }
            return PhxUsrEC;
        }
        public bool SavePhxUser(ref int phx_user_id,
            string username,
            string fullname,
            string userdomain,
            string email)
        {
            PhxUserEntity objPU;
            // si es 0 es un usuario nuevo
            if (phx_user_id == 0)
            {
                objPU = new PhxUserEntity();
            }
            else
            {
                objPU = this.GetPhxUserByID(phx_user_id);
                if (objPU == null)
                {
                    return false;
                }
            }
            objPU.Username = username;
            objPU.Fullname = fullname;
            objPU.Domain = userdomain;
            objPU.Email = email;
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(objPU);
                    tx.Commit();
                    phx_user_id = objPU.Id;
                    return true;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return false;
                    // handle exception
                }
            }
        }

        public int Save(PhxUserEntity Usuario)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.Save(Usuario);

                    tx.Commit();
                    
                    return Usuario.Id;
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return 0;
            }
        }
        public int Save(PhxUserEntity Usuario, PhxUserEntity Responsable)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    session.Save(Usuario);
                    AuditUsuariosEntity LogUsr = new AuditUsuariosEntity(Responsable, Usuario, null);
                    if (LogUsr.AuditPhxUserNew != null)
                    {
                        session.Save(LogUsr.AuditPhxUserNew);
                    }
                    if (LogUsr.AuditPhxUserOld != null)
                    {
                        session.Save(LogUsr.AuditPhxUserOld);
                    }
                    session.Save(LogUsr);
                    tx.Commit();
                    return Usuario.Id;
                    //return true;
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return 0;
                // handle exception
            }
        }
        public int Update(PhxUserEntity Usuario)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();

                    session.Update(Usuario);
                    
                    tx.Commit();
                    return Usuario.Id;
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return 0;
            }
        }
        public int Update(PhxUserEntity Usuario, PhxUserEntity Responsable)
        {
            ITransaction tx = null;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    tx = session.BeginTransaction();
                    AuditUsuariosEntity LogUsr = new AuditUsuariosEntity(Responsable, Usuario, this.Load(Usuario.Id));
                    if (LogUsr.AuditPhxUserNew != null)
                    {
                        session.Save(LogUsr.AuditPhxUserNew);
                    }
                    if (LogUsr.AuditPhxUserOld != null)
                    {
                        session.Save(LogUsr.AuditPhxUserOld);
                    }
                    session.Save(LogUsr);
                    session.Update(Usuario);
                    tx.Commit();
                    return Usuario.Id;
                    //return true;
                }
            }
            catch (Exception ex)
            {
                tx.Rollback();
                return 0;
                // handle exception
            }
        }
        public void SetRoles(PhxUserEntity Usuario, PhxRoleEntityCollection UsrRoles)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList RolesUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();

                    #region Actualización de Permisos (Roles)
                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxRoleUsrLstDEL = session.CreateCriteria(typeof(PhxRoleUserEntity));
                    PhxRoleUsrLstDEL = PhxRoleUsrLstDEL.Add(Expression.Eq("PhxUser", Usuario));
                    PhxRoleUsrLstDEL = PhxRoleUsrLstDEL.Add(
                        Expression.Not(Expression.In("PhxRole", UsrRoles)));

                    // Retrieve data here (with the session)
                    RolesUserToDEL = PhxRoleUsrLstDEL.List();

                    // borra los que trae
                    foreach (PhxRoleUserEntity UsrRoleE in RolesUserToDEL)
                    {
                        session.Delete(UsrRoleE);
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (PhxRoleEntity RoleToINS in UsrRoles)
                    {
                        IList lstUsrRole;
                        ICriteria ExistUsrRole = session.CreateCriteria(typeof(PhxRoleUserEntity));
                        ExistUsrRole = ExistUsrRole.Add(Expression.Eq("PhxUser", Usuario));
                        ExistUsrRole = ExistUsrRole.Add(Expression.Eq("PhxRole", RoleToINS));
                        lstUsrRole = ExistUsrRole.List();
                        if (lstUsrRole.Count == 0)
                        {
                            PhxRoleUserEntity newUsrRole = new PhxRoleUserEntity();
                            newUsrRole.PhxRole = RoleToINS;
                            newUsrRole.PhxUser = Usuario;
                            session.Save(newUsrRole);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetRoles"));
                    //return 0;
                    // handle exception
                }
            }
        }
        /// <summary>
        /// Setea los roles para ese usuario. Solo setea los que se pasan. Borra los
        /// que tenga asignados y no estén en la collection
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="UsrRoles"></param>
        public void SetRoles(PhxUserEntity Responsable, PhxUserEntity Usuario, PhxRoleEntityCollection UsrRoles)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList RolesUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();

                    #region Actualización de Permisos (Roles)
                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxRoleUsrLstDEL = session.CreateCriteria(typeof(PhxRoleUserEntity));
                    PhxRoleUsrLstDEL = PhxRoleUsrLstDEL.Add(Expression.Eq("PhxUser", Usuario));
                    PhxRoleUsrLstDEL = PhxRoleUsrLstDEL.Add(
                        Expression.Not(Expression.In("PhxRole", UsrRoles)));

                    // Retrieve data here (with the session)
                    RolesUserToDEL = PhxRoleUsrLstDEL.List();

                    // borra los que trae
                    foreach (PhxRoleUserEntity UsrRoleE in RolesUserToDEL)
                    {
                        session.Delete(UsrRoleE);
                        // loguear el borrado del rol
                        AuditPermisosEntity LogPerm = new AuditPermisosEntity(Responsable, Usuario, false, UsrRoleE.PhxRole);
                        session.Save(LogPerm);

                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (PhxRoleEntity RoleToINS in UsrRoles)
                    {
                        IList lstUsrRole;
                        ICriteria ExistUsrRole = session.CreateCriteria(typeof(PhxRoleUserEntity));
                        ExistUsrRole = ExistUsrRole.Add(Expression.Eq("PhxUser", Usuario));
                        ExistUsrRole = ExistUsrRole.Add(Expression.Eq("PhxRole", RoleToINS));
                        lstUsrRole = ExistUsrRole.List();
                        if (lstUsrRole.Count == 0)
                        {
                            PhxRoleUserEntity newUsrRole = new PhxRoleUserEntity();
                            newUsrRole.PhxRole = RoleToINS;
                            newUsrRole.PhxUser = Usuario;
                            session.Save(newUsrRole);
                            AuditPermisosEntity LogPerm = 
                                new AuditPermisosEntity(Responsable, Usuario, true, newUsrRole.PhxRole);
                            session.Save(LogPerm);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetRoles"));
                    //return 0;
                    // handle exception
                }
            }


        }
        //public void SetGrupos(PhxUserEntity Usuario, RequestGroupEntityCollection UsrGrps)
        //{
        //    ITransaction tx = null;
        //    using (ISession session = DBMgr.factory.OpenSession())
        //    {
        //        try
        //        {
        //            IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
        //            // abre sesión
        //            tx = session.BeginTransaction();

        //            #region Actualización de Grupos
        //            // trae los phxUserRole que están grabados y no están en la collection
        //            ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(PhxUserGroupEntity));
        //            PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("PhxUser", Usuario));
        //            PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
        //                Expression.Not(Expression.In("RqstGrp", UsrGrps)));

        //            // Retrieve data here (with the session)
        //            GrpsUserToDEL = PhxUsrGrpLstDEL.List();

        //            // borra los que trae
        //            foreach (PhxUserGroupEntity UsrGrpE in GrpsUserToDEL)
        //            {
        //                session.Delete(UsrGrpE);
        //            }
        //            // verifica cuales tiene que insertar y los inserta
        //            foreach (FollowupRequestGroupEntity GroupToINS in UsrGrps)
        //            {
        //                IList lstUsrGrp;
        //                ICriteria ExistUsrGroup = session.CreateCriteria(typeof(PhxUserGroupEntity));
        //                ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("PhxUser", Usuario));
        //                ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", GroupToINS));
        //                lstUsrGrp = ExistUsrGroup.List();
        //                if (lstUsrGrp.Count == 0)
        //                {
        //                    PhxUserGroupEntity newUsrGroup = new PhxUserGroupEntity();
        //                    newUsrGroup.RqstGrp = GroupToINS;
        //                    newUsrGroup.PhxUser = Usuario;
        //                    session.Save(newUsrGroup);
        //                }
        //            }
        //            #endregion
        //            tx.Commit();
        //            //return Usuario.Id;
        //            //return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            tx.Rollback();
        //            throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
        //            //return 0;
        //            // handle exception
        //        }
        //    }


        //}
        public void SetGrupos(PhxUserEntity Usuario, RequestGroupEntityCollection UsrGrps)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();

                    #region Actualización de Grupos
                    // trae los grupos que están grabados y no están en la collection
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(PhxUserGroupEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("PhxUser", Usuario));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("RqstGrp", UsrGrps)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra los ACTIVOS que trae ya que los inactivos no son visualizados en la interface
                    foreach (PhxUserGroupEntity UsrGrpE in GrpsUserToDEL)
                    {
                        if (UsrGrpE.RqstGrp.Active)
                        {
                            session.Delete(UsrGrpE);
                        }
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (RequestGroupEntity GroupToINS in UsrGrps)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(PhxUserGroupEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("PhxUser", Usuario));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("RqstGrp", GroupToINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            PhxUserGroupEntity newUsrGroup = new PhxUserGroupEntity();
                            newUsrGroup.RqstGrp = GroupToINS;
                            newUsrGroup.PhxUser = Usuario;
                            session.Save(newUsrGroup);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
                    //return 0;
                    // handle exception
                }
            }


        }

        public void SetGruposSeguim(PhxUserEntity Usuario, FollowupRequestGroupEntityCollection UsrGrpsSeguim)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();

                    #region Actualización de Grupos
                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(FollowupRequestGroupUserEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("PhxUser", Usuario));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("FollowupRqstGrp", UsrGrpsSeguim)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();

                    // borra ACTIVOS los que trae
                    foreach (FollowupRequestGroupUserEntity UsrGrpE in GrpsUserToDEL)
                    {
                        if (UsrGrpE.FollowupRqstGrp.Active)
                        {
                            session.Delete(UsrGrpE);
                        }
                    }
                    // verifica cuales tiene que insertar y los inserta
                    foreach (FollowupRequestGroupEntity GroupToINS in UsrGrpsSeguim)
                    {
                        IList lstUsrGrp;
                        ICriteria ExistUsrGroup = session.CreateCriteria(typeof(FollowupRequestGroupUserEntity));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("PhxUser", Usuario));
                        ExistUsrGroup = ExistUsrGroup.Add(Expression.Eq("FollowupRqstGrp", GroupToINS));
                        lstUsrGrp = ExistUsrGroup.List();
                        if (lstUsrGrp.Count == 0)
                        {
                            FollowupRequestGroupUserEntity newUsrGroup = new FollowupRequestGroupUserEntity();
                            newUsrGroup.FollowupRqstGrp = GroupToINS;
                            newUsrGroup.PhxUser = Usuario;
                            session.Save(newUsrGroup);
                        }
                    }
                    #endregion
                    tx.Commit();
                    //return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
                    //return 0;
                    // handle exception
                }
            }


        }

        public bool IsDeleteable(PhxUserEntity Usuario)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    /*IList GrpsUserToDEL; // = new PhxRoleUserEntityCollection();
                    // abre sesión
                    tx = session.BeginTransaction();

                    // trae los phxUserRole que están grabados y no están en la collection
                    ICriteria PhxUsrGrpLstDEL = session.CreateCriteria(typeof(PhxUserGroupEntity));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(Expression.Eq("PhxUser", Usuario));
                    PhxUsrGrpLstDEL = PhxUsrGrpLstDEL.Add(
                        Expression.Not(Expression.In("RqstGrp", UsrGrps)));

                    // Retrieve data here (with the session)
                    GrpsUserToDEL = PhxUsrGrpLstDEL.List();*/
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (new CwxException(ex.Message, "PhxUsersFactory.SetGrps"));
                    return false;
                    // handle exception
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public int Delete(PhxUserEntity Usuario)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(Usuario);
                    tx.Commit();
                    return Usuario.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    return 0;
                    // handle exception
                }
            }
        }

        public PhxUserEntity Load(int IdReg)
        {
            try
            {
                PhxUserEntity objPhxUsr = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    objPhxUsr = (PhxUserEntity)session.Load(typeof(PhxUserEntity), IdReg);
                }
                return objPhxUsr;
            }
            catch (NHibernate.ObjectNotFoundException)
            {
                return null;
            }
            catch (NHibernate.HibernateException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public PhxUserEntityCollection GetAllFollowPwdRqstAuth(UserPasswordEntity UserPassword)
        {
            IList<PhxUserEntity> PUlst = null;
            PhxUserEntityCollection PhxUsrEC = new PhxUserEntityCollection();
            using (ISession session = DBMgr.factory.OpenSession())
            {
                /// consulta para traer los mails de los autorizadores que estan en el/los grupo/s de seguimiento/s
                /// se hace DISTINCT. Para esto se usan projections para especificar los campos que se traen
                /// y después SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer((typeof(PhxUserEntity))))
                /// especificando la clase que se llena
                ICriteria DataSearch = session.CreateCriteria(typeof(PhxUserEntity)).AddOrder(Order.Asc("Id"))
                    .SetProjection(Projections.Distinct(Projections.ProjectionList().Add(Projections.Property("Id"), "Id")
                    .Add(Projections.Property("Fullname"), "Fullname")
                    .Add(Projections.Property("Username"), "Username")
                    .Add(Projections.Property("Email"), "Email")
                    ));
                DataSearch = DataSearch.Add(Expression.IsNull("DeleteDate"));
                DataSearch.CreateCriteria("PhxUsersFollowupGroupsList", "UFRG")
                .CreateCriteria("UFRG.FollowupRqstGrp", "FRG")
                .CreateCriteria("FRG.FollowupRequestGroupPasswordList", "FRGP")
                .Add(Expression.Eq("FRGP.UserPassword", UserPassword));
                DataSearch.SetResultTransformer(new NHibernate.Transform.AliasToBeanResultTransformer(typeof(PhxUserEntity)));
                PUlst = DataSearch.List<PhxUserEntity>();
                PhxUsrEC.Add(PUlst);
            }
            return PhxUsrEC;

        }

		public IList GetAllByGrupoSolicitud(string nombreGrupo, bool? grupoActivo, bool? usuarioActivo)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("usuariosGrupoSolicitud");

				int estadoGrupo = -1;
				int estadoUsuario = -1;

				if (grupoActivo != null)
					estadoGrupo = grupoActivo.Value ? 1 : 0;
				
				if (usuarioActivo != null)
					estadoUsuario = usuarioActivo.Value ? 1 : 0;
				
				query.SetString("nombreGrupo", nombreGrupo != null ? "%" + nombreGrupo.ToUpper() + "%" : null);
				query.SetParameter("estadoGrupo", estadoGrupo);			
				query.SetInt32("estadoUsuario", estadoUsuario);

				return query.List();
			}
		}

		public IList GetAllByGrupoSeguimientoSolicitud(string nombreGrupo, bool? grupoActivo, bool? usuarioActivo)
		{
			using (ISession session = DBMgr.factory.OpenSession())
			{
				IQuery query = session.GetNamedQuery("usuariosGrupoSeguimientoSolicitud");

				int estadoGrupo = -1;
				int estadoUsuario = -1;

				if (grupoActivo != null)
					estadoGrupo = grupoActivo.Value ? 1 : 0;

				if (usuarioActivo != null)
					estadoUsuario = usuarioActivo.Value ? 1 : 0;

				query.SetString("nombreGrupo", nombreGrupo != null ? "%" + nombreGrupo.ToUpper() + "%" : null);
				query.SetParameter("estadoGrupo", estadoGrupo);
				query.SetInt32("estadoUsuario", estadoUsuario);

				return query.List();
			}
		}
    }
}