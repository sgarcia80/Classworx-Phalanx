using System;
using System.Reflection;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for WinDomainUsersFactory.
	/// </summary>
	public class WinDomainUsersFactory
	{
		public WinDomainUsersFactory()
		{
		}
		/// <summary>
		/// Get All Users, should rarely be used...
		/// </summary>
		/// <returns>Complete list of customers</returns>
		public IList GetWinDomainUsers()
		{
			IList WDUlst = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				WDUlst = session.CreateCriteria(typeof(WinDomainUserEntity)).List();
			}
			return WDUlst;
		}
		/// <summary>
		/// Busca todos los usuarios de Dominios de windows de un Dominio
		/// </summary>
		/// <param name="iWinDomainId">Id del Dominio en la BD</param>
		/// <returns>La lista de Usuarios de Dominios de Windows</returns>
		public IList GetWinDomainUsrsByWinDomain(int iWinDomainId)
		{
			IList lstWDU;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstWDU = session.CreateCriteria(typeof(WinDomainUserEntity))
					.Add(Expression.Eq("WinDomain.Id",iWinDomainId))
					.List();
			}
			
			return lstWDU;
		}
		/// <summary>
		/// Busca todos los usuarios de Dominios de windows de un Dominio
		/// </summary>
		/// <param name="strWDName">Nombre del Dominio</param>
		/// <returns>La lista de Usuarios de Dominios de Windows</returns>
		public IList GetWinDomainUsrsByWinDomain(string strWDName)
		{
			IList lstWDU;

			using(ISession session = DBMgr.factory.OpenSession())
			{
				NHibernate.SqlCommand.SqlString strQry = 
					new NHibernate.SqlCommand.SqlString("lower({alias}.Nt_Name) = lower('"+ strWDName +"') ");
				lstWDU = session.CreateCriteria(typeof(WinDomainUserEntity))
					.CreateCriteria("WinDomain")
					.Add(Expression.Sql(strQry))
					//.Add(Expression.Eq("NtName",strWDName))
					.List();
			}
			
			return lstWDU;
		}

		/// <summary>
		/// Busca todos los usuarios de Dominios de windows cuya contraseña debe ser chequeada
		/// </summary>
		/// <param name="dChkDate">Fecha límite para tomar passwords a chequear</param>
		/// <returns>La lista de Usuarios de Dominios de Windows</returns>
		public IList GetUsrsByPwdToCheck(DateTime dChkDate)
		{
			IList lstUPwd = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstUPwd = session.CreateCriteria(typeof(WinDomainUserEntity))
					.CreateCriteria("UserPassword")
					.Add(Expression.Le("DNextChk", dChkDate))
					.List();
			}
			return lstUPwd;

		}

		/// <summary>
		/// Actualiza un usuario de Dominio de windows cuya contraseña fue chequeada
		/// </summary>
		/// <param name="dChkDate">Fecha en que se chequeó la contraseña</param>
		/// <param name="objWDU">Objeto Usuario para el cual se le chequeó la contraseña</param>
		public void UpdateCheckedUsrPwd(WinDomainUserEntity objWDU ,DateTime dChkDate)
		{
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					objWDU.UserPassword.DLastChk = dChkDate;
					switch (objWDU.UserPassword.ChkFreqUnit.ToUpper())
					{
						case "H":
							objWDU.UserPassword.DNextChk = dChkDate.AddHours(Convert.ToDouble(objWDU.UserPassword.ChkFreq));
							break;
						case "D":
							objWDU.UserPassword.DNextChk = dChkDate.AddDays(Convert.ToDouble(objWDU.UserPassword.ChkFreq));
							break;
						case "W":
							objWDU.UserPassword.DNextChk = dChkDate.AddDays(7*Convert.ToDouble(objWDU.UserPassword.ChkFreq));
							break;
						case "M":
							objWDU.UserPassword.DNextChk = dChkDate.AddMonths(Convert.ToInt32(objWDU.UserPassword.ChkFreq));
							break;
						case "Y":
							objWDU.UserPassword.DNextChk = dChkDate.AddYears(Convert.ToInt32(objWDU.UserPassword.ChkFreq));
							break;
						default:
							break;
					}

					tx = session.BeginTransaction();
					session.Update(objWDU.UserPassword);
					tx.Commit();
				}
				catch (Exception ex)
				{
					tx.Rollback();
					// handle exception
				}

			}

		}
		/// <summary>
		/// Actualiza un usuario de Dominio de windows cuya contraseña fue cambiada
		/// </summary>
		/// <param name="dChangeDate">Fecha en que se cambió la contraseña</param>
		/// <param name="objWDU">Objeto Usuario para el cual se le cambió la contraseña</param>
		public void UpdateChangedUsrPwd(WinDomainUserEntity objWDU ,DateTime dChangeDate)
		{
			ITransaction tx = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				try
				{
					objWDU.UserPassword.DLastChange = dChangeDate;
					switch (objWDU.UserPassword.ChangeFreqUnit.ToUpper())
					{
						case "H":
							objWDU.UserPassword.DNextChange = dChangeDate.AddHours(Convert.ToDouble(objWDU.UserPassword.ChangeFreq));
							break;
						case "D":
							objWDU.UserPassword.DNextChange = dChangeDate.AddDays(Convert.ToDouble(objWDU.UserPassword.ChangeFreq));
							break;
						case "W":
							objWDU.UserPassword.DNextChange = dChangeDate.AddDays(7*Convert.ToDouble(objWDU.UserPassword.ChangeFreq));
							break;
						case "M":
							objWDU.UserPassword.DNextChange = dChangeDate.AddMonths(Convert.ToInt32(objWDU.UserPassword.ChangeFreq));
							break;
						case "Y":
							objWDU.UserPassword.DNextChange = dChangeDate.AddYears(Convert.ToInt32(objWDU.UserPassword.ChangeFreq));
							break;
						default:
							break;
					}

					tx = session.BeginTransaction();
					session.Update(objWDU.UserPassword);
					tx.Commit();
				}
				catch (Exception ex)
				{
					tx.Rollback();
					// handle exception
				}

			}

		}
		/// <summary>
		/// Busca todos los usuarios de Dominios de windows de una PC cuya contraseña debe ser cambiada
		/// </summary>
		/// <returns>La lista de Usuarios de Dominios de Windows</returns>
		public IList GetUsrsByPwdToChange(DateTime dChkDate)
		{
			IList lstUPwd = null;
			using(ISession session = DBMgr.factory.OpenSession())
			{
				// Retrieve data here (with the session)
				lstUPwd = session.CreateCriteria(typeof(WinDomainUserEntity))
					.CreateCriteria("UserPassword")
					.Add(Expression.Le("DNextChange", dChkDate))
					.List();
			}
			return lstUPwd;

		}
	}
}
