using System;
using System.Reflection;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using Phalanx.Util;
using NHibernate;
using NHibernate.Expression;
using NHibernate.Cfg;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for UsersFactory.
	/// </summary>
	public class UsersFactory
	{
		public UsersFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/*
		public IList GetUsrsByPwdToCheck()
		{
			IList lstUPwd = null;
			//ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				//ICriteria myCrit = session.CreateCriteria(typeof(WinLocalUserEntity));
				
				
				lstUPwd = session.CreateCriteria(typeof(UserEntity))
					//.Add(Expression.Eq("ActiveUser",true))
					//.Add(Expression.Le("UserPasswordId.DNextChk", new DateTime(2005,12,12))) //dChkDate))
					//.Add(Expression.Between("UserPasswordId.DLastChk", new DateTime(2005,1,1),new DateTime(2005,1,12))) //dChkDate))
					.Add(Expression.Between("UserPasswordId.ChkFreq", 1,100)) //dChkDate))
					//.Add(Expression.Eq("UserPasswordId.UserPasswordId", 1))
					.List();
				//lstUPwd = session.Find("select uc.Name from PhalanxDAL.Data. as uc where personid is null order by uc.Name asc");

				//ICriteria myCrit2 = myCrit.Add(Expression.Le("UserId.DNextChk", dChkDate));
				//lstUPwd = myCrit2.List();
				//lstUPwd = session.CreateCriteria(typeof(WinLocalUserEntity)).List();
			}
			return lstUPwd;

		}*/
		/// <summary>
		/// Busca el usuario que corresponde con el Id
		/// </summary>
		/// <param name="UsrId">Id de usuario. Tabla.Campo: UserEntity.User_Id</param>
		/// <returns>Devuelve el objeto UserEntity. Si no encuentra datos devuelve null</returns>
		public UserEntity GetUserByID(int UsrId)
		{
			UserEntity objUser = null;
			//ITransaction tx = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objUser = (UserEntity)session.Load(typeof(UserEntity),UsrId);
				}
			}
			catch (ObjectNotFoundException ONFex)
			{
				return null;
			}					
			catch(NHibernate.ADOException ADOex) // esto se dispara cuando por ejemplo no hay conexion a la base
			{
				//throw(ADOex);
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
			return objUser;
		}

		/// <summary>
		/// Busca el usuario asociado al Id del Password
		/// </summary>
		/// <param name="PwdId">Id del Password</param>
		/// <param name="User">Objeto Usuario Local o de dominio. Si no encuentra usuario devuelve null</param>
		/// <param name="UserType">Tipo de usuario que devuelve</param>
		/// <returns></returns>
		public uint GetUserByPwdId(int PwdId, out object User, out System.Type UserType)
		{
			UserEntity objUser = null;
			User = null;
			UserType = null;
			try
			{
				using(ISession session = DBMgr.factory.OpenSession())
				{
				
					IList Ulst = session.CreateCriteria(typeof(UserEntity))
						.Add(Expression.Eq("UserPassword.Id",PwdId))
						.List();
					if (Ulst.Count==0)
					{
						return PhxDALUtil.NO_DATA_FOUND;// hacer tratamiento de error porque no trajo User para el Pwd
					}
					else
					{
						objUser = (UserEntity)Ulst[0];
					
						if (objUser.UserType.Id == 1) //usuario local
						{
							User = (WinLocalUserEntity)session.Load(typeof(WinLocalUserEntity), objUser.Id);
							UserType = typeof(WinLocalUserEntity);
						}
						else if (objUser.UserType.Id == 2) //usuario de dominio
						{
							User = (WinDomainUserEntity)session.Load(typeof(WinDomainUserEntity), objUser.Id);
							UserType = typeof(WinDomainUserEntity);
						}
					}
				}
				return PhxDALUtil.SUCCESS;
			}
			catch (NHibernate.ObjectNotFoundException ONFex)
			{
				User = null;
				UserType = null;
				return PhxDALUtil.NO_DATA_FOUND;
			}
			catch (Exception ex)
			{
				
				string errMsg = ex.Message;
				return PhxDALUtil.ERROR;
			}

		}
	}
}
