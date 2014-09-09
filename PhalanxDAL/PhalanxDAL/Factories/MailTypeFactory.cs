using System;
using System.Collections.Generic;
using System.Text;
using PhalanxCommon.Entities;
using NHibernate;
using NHibernate.Expression;
using PhalanxCommon;
using PhalanxCommon.Collections;
using System.Collections;

namespace PhalanxDAL.Factories
{
    public class MailTypeFactory
    {
        public enum MailType
        {
            PwdRqst = 1,
            RqstExpiration = 2,
            RespuestaPwdRqst = 3,
            NuevoAplicativoBPM = 4,
            AltaUsuarioRed = 5,
            AltaUsuarioAplicativoSeguridadIntegrada = 6,
            AltaUsuarioAplicativoSeguridadPropia = 7,
            DevolucionPwdRqst = 8
        }
        public MailTypeEntityCollection GetAll()
        {
            MailTypeEntityCollection WinDomLst = new MailTypeEntityCollection();
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    ICriteria DataSearch = session.CreateCriteria(typeof(MailTypeEntity));

                    DataSearch = DataSearch.AddOrder(NHibernate.Expression.Order.Asc("Name"));
                    IList<MailTypeEntity> lstDBTypes = DataSearch.List<MailTypeEntity>();
                    WinDomLst.Add(lstDBTypes);
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailTypeFactory GetAll()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailTypeFactory GetAll()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailTypeFactory GetAll()"));
            }
            return WinDomLst;

        }
        public MailTypeEntity GetMailType(MailType MailType)
        {
            MailTypeEntity MailTypeE;
            try
            {
                using (ISession session = DBMgr.factory.OpenSession())
                {
                    MailTypeE = session.Load<MailTypeEntity>(((int)MailType));

                    return MailTypeE;
                }
            }
            catch (NHibernate.ObjectNotFoundException ObjNotFoundEx)
            {
                throw (new CwxException(ObjNotFoundEx.Message, "MailTypeFactory GetMailType()"));
            }
            catch (NHibernate.HibernateException NHEx)
            {
                throw (new CwxException(NHEx.Message, "MailTypeFactory GetMailType()"));
            }
            catch (CwxException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (new CwxException(ex.Message, "MailTypeFactory GetAll()"));
            }
            return null;
        }
    }
}
