using System;
using NHibernate;
//using PhalanxDAL.Data;
using PhalanxCommon.Entities;
using PhalanxCommon.Collections;
using PhalanxCommon;

namespace PhalanxDAL.Factories
{
	/// <summary>
	/// Summary description for UserTypesFactory.
	/// </summary>
	public class UserTypesFactory
	{
		public UserTypesFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		/// <summary>
		/// Devuelve el objeto correspondientes al tipo de Usuario Usuario Local de Windows
		/// </summary>
		/// <returns>Devuelve el objeto correspondiente al tipo de Usuario Usuario Local de Windows</returns>
        public UserTypeEntity GetWinLocalUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.Windows);
        }
        public UserTypeEntity GetUnixUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.Unix);
        }

        public UserTypeEntity GetDataBaseUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.DataBase);
        }
        /// <summary>
		/// Busca el tipo de usuario correspondiente al ID que se pasa por parámetro
		/// </summary>
		/// <param name="UserTypeId">Id del tipo de usuario</param>
		/// <returns>Devuelve el objeto correspondiente al UserType. Si no ecuentra nada, devuelve null.</returns>
 		public UserTypeEntity GetUserType(int UserTypeId)
		{
			try
			{
				UserTypeEntity objUserType = null;
				using(ISession session = DBMgr.factory.OpenSession())
				{
					objUserType = (UserTypeEntity)session.Load(typeof(UserTypeEntity),UserTypeId);
				}
				return objUserType;
			}
			catch(NHibernate.ObjectNotFoundException ObjNotFoundEx)
			{
				return null;
			}
			catch(NHibernate.HibernateException NHEx)
			{
				return null;
			}
			catch(Exception ex)
			{
				return null;
			}
		}
        public UserTypeEntity GetApplicationUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.Application);
        }


        public UserTypeEntityCollection GetAll()
        {
            UserTypeEntityCollection WinDomLst = new UserTypeEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(UserTypeEntity));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Desc"));
                    WinDomLst.Add(DataSearch.List<UserTypeEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "UserTypeFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "UserTypeFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "UserTypeFactory GetAll()"));
            }
            return WinDomLst;

        }

        public UserTypeEntity GetAS400UserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.AS400);
        }

        public UserTypeEntity GetCommunicationDeviceUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.CommunicationDevice);
        }

        public UserTypeEntity GetATMUserType()
        {
            return this.GetUserType((int)Phalanx.Util.PhxDALUtil.UserTypes.ATM);
        }
    }
}
