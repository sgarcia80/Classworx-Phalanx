using System;
//using System.Reflection;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using PhalanxCommon.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for UsersPasswordsFactory.
	/// </summary>
	public class UsersPasswordsFactory
	{
		public UsersPasswordsFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public UserPasswordEntityCollection GetPasswordToAuthByAutomatic(PhxUserEntity Auth, UserPasswordEntity userpwd)
        {
            UserPasswordEntityCollection PwdRqstEC = new UserPasswordEntityCollection();

            IList<UserPasswordEntity> list = null;
            try
            {
                //ITransaction tx = null;
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    list = session.CreateCriteria(typeof(UserPasswordEntity), "UP")
                        .Add(Expression.Eq("UP.Id", userpwd.Id))
                        .CreateCriteria("UP.FollowupRqstGrpsPwdsList", "FRQP")
                        .CreateCriteria("FRQP.FollowupRqstGrp", "FRG")
                        .Add(Expression.Eq("FRG.Active", true))
                        .Add(Expression.Eq("FRG.AutoApproval", true))
                        .Add(Expression.IsNotNull("FRG.Approver"))
                        //.CreateCriteria("FRG.FollowupGroupUsersList", "FRGU")
                        //.Add(Expression.Eq("FRGU.PhxUser", Auth))
                        .List<UserPasswordEntity>();

                    foreach (UserPasswordEntity PwdRqstE in list)
                    {
                        int j = PwdRqstE.FollowupRqstGrpsPwdsList.Count;
                        int i = PwdRqstE.UsersList.Count;
                        PwdRqstEC.Add(PwdRqstE);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return PwdRqstEC;

        }

        public IList GetPasswordsToCheck(DateTime dChkDate)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entros a UsersPasswordsFactory.GetPasswordsToCheck(DateTime dChkDate)"
				, "dChkDate: " + dChkDate.ToString()
				, true, false);
			IList lstUPwd = null;
			//ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				lstUPwd = session.CreateCriteria(typeof(UserPasswordEntity))
					.Add(Expression.Le("DNextChk", dChkDate))
					.List();
			}
			return lstUPwd;

		}
		public IList GetPasswordsToChange(DateTime dChkDate)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entros a UsersPasswordsFactory.GetPasswordsToChange(DateTime dChkDate)"
				, "dChkDate: " + dChkDate.ToString()
				, true, false);
			IList lstUPwd = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstUPwd = session.CreateCriteria(typeof(UserPasswordEntity))
					.Add(Expression.Le("DNextChange", dChkDate))
					.List();
			}
			return lstUPwd;

		}

        public UserPasswordEntity GetUserPassword(int userID)
        {
            // busca dominio
            UsersFactory uF = new UsersFactory();
            UserEntity objUser = uF.GetUserByID(userID);
            if (objUser == null)
            {
                // no existe el Usuario
                return null;
            }
            IList lstPassword;

            using (ISession session = DBMgr.factory.OpenSession())
            {
                lstPassword = session.CreateCriteria(typeof(UserPasswordEntity))
                    .Add(Expression.Eq("UsersPasswords.UsersList", userID))
                    .List();
            }
            if (lstPassword.Count != 1)
            {
                return null;
            }
            else
            {
                return (UserPasswordEntity)lstPassword[0];
            }
        }

		public UserPasswordEntity CreateUsrPwd()
		{
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					// crear el usuario en la base
					UserPasswordEntity objUP = new UserPasswordEntity();
					tx = session.BeginTransaction();
					session.Save(objUP);
					tx.Commit();
					return objUP;
				}
				catch (Exception ex)
				{
					tx.Rollback();
					return null;
					// handle exception
				}
			}

		}

        public void Save(UserPasswordEntity userPassword)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.SaveOrUpdate(userPassword);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    // handle exception
                }
            }

        }

        public bool Update(UserPasswordEntity userPassword)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    tx = session.BeginTransaction();
                    session.Update(userPassword);
                    tx.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    // handle exception
                }
                return false;
            }

        }
        public bool Refresh(UserPasswordEntity UsrPwd)
        {
            using (ISession session = DBMgr.factory.OpenSession())
            {
                try
                {
                    session.Refresh(UsrPwd);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
