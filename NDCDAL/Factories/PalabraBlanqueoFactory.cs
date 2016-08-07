using System;
using System.Collections.Generic;
using System.Text;
using NDCCommon.Collections;
using NHibernate;
using NDCCommon.Entities;
using Common;
using PhalanxDAL;
using NHibernate.Expression;

namespace NDCDAL.Factories
{
    public class PalabraBlanqueoFactory
    {
        public PalabraBlanqueoEntityCollection GetAll()
        {
            PalabraBlanqueoEntityCollection Lst = new PalabraBlanqueoEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(PalabraBlanqueoEntity));

                    //DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Valor"));
                    
                    Lst.Add(DataSearch.List<PalabraBlanqueoEntity>());
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "PalabraBlanqueoFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "PalabraBlanqueoFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "PalabraBlanqueoFactory GetAll()"));
            }
            return Lst;
        }
    }
}
