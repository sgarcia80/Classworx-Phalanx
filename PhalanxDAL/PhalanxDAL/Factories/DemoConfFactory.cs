using System;
using System.Collections;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for DemoConfFactory.
	/// </summary>
	public class DemoConfFactory
	{
		private const string AUTH_PWD_RQST_ID = "AUTHPWDRQSTID";
		private const string AUTH_DELEG_RQST_ID = "AUTHDELEGRQSTID";

		public DemoConfFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Busca el parámetro de configuración especificado
		/// </summary>
		/// <param name="DemoConfCode">Codigo del parámetro de configuración</param>
		/// <returns>Parámetro de configuración</returns>
		private DemoConf GetDemoConf(string DemoConfCode)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a DemoConfFactory.GetDemoConf(string DemoConfCode)"
				, "DemoConfCode: " + DemoConfCode
				, true, false);
			try
			{
				DemoConf objDC = new DemoConf();
				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList DClst = session.CreateCriteria(typeof(DemoConf))
						.Add(Expression.Eq("Code",DemoConfCode))
						.List();

					if (DClst.Count == 1)
					{
						objDC = (DemoConf)DClst[0];
					}
					else
					{
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 4, 0
							, "DemoConfFactory.GetDemoConf(string DemoConfCode)"
							, "No se encontró el parametro de configuración " + DemoConfCode
							, true, false);
						return null;
					}
				}
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
					, "DemoConfFactory.GetDemoConf(string DemoConfCode)"
					, "Se encontró el parametro de configuración " + DemoConfCode
					, true, false);
				return objDC;
			}
			catch(Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
					, "DemoConfFactory.GetDemoConf(string DemoConfCode)"
					, "Se encontró el parametro de configuración " + DemoConfCode
					, true, false);
				return null;
			}

		}


		/// <summary>
		/// Busca el Id del Autorizador de Solicitudes de Contraseñas
		/// </summary>
		/// <returns>Parámetro de configuración</returns>
		public string GetPwdRqstAuthId()
		{
			DemoConf objDC = this.GetDemoConf(AUTH_PWD_RQST_ID);
			if(objDC != null)
			{
				return objDC.Value;
			}
			else
			{
				return "";
			}
		}

		/// <summary>
		/// Busca el Id del Autorizador de Solicitudes de Delegación de permisos
		/// </summary>
		/// <returns>Parámetro de configuración</returns>
		public string GetDelegRqstAuthId()
		{
			DemoConf objDC = this.GetDemoConf(AUTH_DELEG_RQST_ID);
			if(objDC != null)
			{
				return objDC.Value;
			}
			else
			{
				return "";
			}
		}
		private bool SetDemoConf(string DemoConfCode, string ParamValue)
		{
			DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
				, "Entra a DemoConfFactory.SetDemoConf(string DemoConfCode, string ParamValue)"
				, "DemoConfCode: " + DemoConfCode + " - ParamValue: " + ParamValue
				, true, false);
			try
			{
				DemoConf objDC = new DemoConf();
				using(ISession session = DBMgr.factory.OpenSession())
				{
					IList DClst = session.CreateCriteria(typeof(DemoConf))
						.Add(Expression.Eq("Code",DemoConfCode))
						.List();

					if (DClst.Count == 1)
					{
						objDC = (DemoConf)DClst[0];
					}
					objDC.Code = DemoConfCode;
					objDC.Value = ParamValue;
					ITransaction tx = null;
					try
					{
						tx = session.BeginTransaction();
						session.SaveOrUpdate(objDC);
						tx.Commit();
						return true;
					}
					catch (Exception ex)
					{
						tx.Rollback();
						DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_ERROR, 4, 0
							, "DemoConfFactory.SetDemoConf(string DemoConfCode, string ParamValue)"
							, "Error: " + ex.Message
							, true, false);
						return false;
						// handle exception
					}
				}
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_INFORMATION, 5, 0
					, "DemoConfFactory.SetDemoConf(string DemoConfCode, string ParamValue)"
					, "Se guardó el parametro de configuración " + DemoConfCode
					, true, false);
				return true;
			}
			catch(Exception ex)
			{
				DBMgr.DBLog.registerLog(phxLog.CLogger.TYPE_ERROR, 4, 0
					, "DemoConfFactory.SetDemoConf(string DemoConfCode, string ParamValue)"
					, "Error: " + ex.Message
					, true, false);
				return false;
			}

		}
		/// <summary>
		/// Graba el Id del Autorizador de Solicitudes de Contraseñas
		/// </summary>
		/// <returns>Verdadero si se puedo guardar el parametro</returns>
		public bool SetPwdRqstAuthId(string ParamValue)
		{
			if ( this.SetDemoConf(AUTH_PWD_RQST_ID, ParamValue))
			{
				RqstGrpsPwdsFactory RGDF = new RqstGrpsPwdsFactory();
				RGDF.SetAuth1User(Convert.ToInt32(ParamValue));
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Graba el Id del Autorizador de Solicitudes de Delegación de permisos
		/// </summary>
		/// <returns>Verdadero si se puedo guardar el parametro</returns>
		public bool SetDelegRqstAuthId(string ParamValue)
		{
			//return this.SetDemoConf(AUTH_DELEG_RQST_ID, ParamValue);
			if ( this.SetDemoConf(AUTH_DELEG_RQST_ID, ParamValue))
			{
				RqstGrpsDelegFactory RGDF = new RqstGrpsDelegFactory();
				RGDF.SetAuth1User(Convert.ToInt32(ParamValue));
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
