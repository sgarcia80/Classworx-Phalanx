using System;
using System.Collections;
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
	/// Summary description for FollowupFollowupFollowupRequestGroupDefaultFactory.
	/// </summary>
    public class FollowupRequestGroupDefaultFactory
    {
        private UserTypeEntity _filUserType;
        public UserTypeEntity FilUserType
        {
            set { _filUserType = value; }
            //get { return _filNombre; }
        }

        public FollowupRequestGroupDefaultFactory()
        {
            //
            // TODO: Add constructor logic here
            //
        }       

        public FollowupRequestGroupDefaultEntityCollection GetAll()
        {
            FollowupRequestGroupDefaultEntityCollection FollowupRequestGroupDefaultEC = new FollowupRequestGroupDefaultEntityCollection();
            ICriteria DataSearch;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                // Retrieve data here (with the session)
                DataSearch = session.CreateCriteria(typeof(FollowupRequestGroupDefaultEntity));
                if (_filUserType != null)
                {
                    DataSearch.Add(Expression.Eq("UserType", _filUserType));
                }
                IList<FollowupRequestGroupDefaultEntity> lstRqstGrps = DataSearch.List<FollowupRequestGroupDefaultEntity>();
                FollowupRequestGroupDefaultEC.Add(lstRqstGrps);
            }
            return FollowupRequestGroupDefaultEC;

        }


        public void Save(FollowupRequestGroupDefaultEntity FollowupRequestGroupDefault)
        {
            ITransaction tx = null;
            using (ISession session = DBMgr.factory.OpenSession())
            {
                tx = session.BeginTransaction();
                try
                {                    
                    session.SaveOrUpdate(FollowupRequestGroupDefault);

                    /// ahora hay que actualizar el grupo de seguimiento de todas las contraseñas de ATMs
                    /*"UPDATE Roomreservation as rr set rr.FromTime= 12:15" +
                     "Inner Join Booking b ON rr.Book_ID= b.ID " +
                     "Where b.ID = 95637";*/
                    //String hql = "UPDATE FollowupRequestGroupPasswordEntity as FRGP set FRGP.frg_id = " + FollowupRequestGroupDefault.Key +
                    //    "Inner Join FRGP.UserPassword as UP Inner Join UP.UsersList Usr WHERE Usr.class = PhalanxCommon.Entities.ATMUserEntity";
                    //IQuery query = session.CreateQuery(hql);
                    //int result = query.ExecuteUpdate();
                    IList<FollowupRequestGroupPasswordEntity> FllwRqstGrpATMs = session.CreateCriteria(typeof(FollowupRequestGroupPasswordEntity))
                        .Add(Expression.Not(Expression.Eq("FollowupRqstGrp",FollowupRequestGroupDefault.FollowupRqstGrp)))
                        .CreateCriteria("UserPassword").CreateCriteria("UsersList", "UL").Add(Expression.Eq("UL.class", typeof(ATMUserEntity)))
                        .List<FollowupRequestGroupPasswordEntity>();
                    // recorrer cada uno y actualizarlo
                    foreach (FollowupRequestGroupPasswordEntity FRGPE in FllwRqstGrpATMs)
                    {
                        if (FRGPE.FollowupRqstGrp.Key != FollowupRequestGroupDefault.FollowupRqstGrp.Key)
                        {
                            FRGPE.FollowupRqstGrp = FollowupRequestGroupDefault.FollowupRqstGrp;
                            session.Update(FRGPE);
                        }
                    }
                    tx.Commit();
                    //return FollowupRequestGroupDefault.Id;
                    //return true;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw (ex);
                    // handle exception
                }
            }
        }


    }
}
