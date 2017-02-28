using System;
//using System.Reflection;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;


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
