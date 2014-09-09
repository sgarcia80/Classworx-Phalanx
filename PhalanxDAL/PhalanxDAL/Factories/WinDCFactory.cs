using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for WinDCFactory.
	/// </summary>
	public class WinDCFactory
	{
		public WinDCFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public IList GetDCsByDomainName(string strDomainName)
		{
			IList lstDC = null;
			//NHibernate.SqlCommand.SqlString strQry = new NHibernate.SqlCommand.SqlString("lower(WinDomainId.NtName) = lower('"+strDomainName+"')");
			NHibernate.SqlCommand.SqlString strQry = 
				new NHibernate.SqlCommand.SqlString("lower({alias}.Nt_Name) = lower('"+ strDomainName +"') ");
				//new NHibernate.SqlCommand.SqlString("lower({alias}.NtName) = lower(?) ");
			//NHibernate.SqlCommand.SqlString strQry = new NHibernate.SqlCommand.SqlString("Dc_Type = 'P'");
			//string strQry = "lower(NtName) = lower('"+strDomainName+"')";
			using(ISession session = DBMgr.factory.OpenSession())
			{
				lstDC = session.CreateCriteria(typeof(WinDomainControllerEntity))
					.CreateCriteria("WinDomain")
					//.Add(Expression.Sql(strQry))
					//.Add(Expression.Sql(strQry, strDomainName, NHibernateUtil.String))
					.Add(Expression.Sql(strQry))
					//.Add(Expression.Eq("NtName",strDomainName))
					//.Add(Expression.Eq("DcType","P"))
					.List();
			}
			return lstDC;

		}

	}
}
