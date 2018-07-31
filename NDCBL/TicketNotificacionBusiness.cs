using System;
using System.Data;
using System.Configuration;
using phxCryptMgr;
using NDCCommon.Entities;
using NDCCommon.Collections;
using NDCDAL.Factories;
using System.Collections.Generic;
using PhalanxBL;

namespace NDCBL
{
    /// <summary>
    /// Summary description
    /// </summary>
    public class TicketNotificacionBusiness
    {
        private const int DEFAULT_HORAS_EXPIRACION_TOKEN = 72;

        private TicketNotificacionFactory factory;
        private static int? horasExpiracionToken;

        private TicketNotificacionFactory Factory
        {
            get
            {
                if (factory == null)
                    factory = new TicketNotificacionFactory();

                return factory;
            }
        }

        //private static int HorasExpiracionToken
        //{
        //    get
        //    {
        //        if (horasExpiracionToken == null)
        //        {
        //            int horas;

        //            if (!int.TryParse(System.Configuration.ConfigurationManager.AppSettings["HorasExpiracionToken"], out horas))
        //                horas = DEFAULT_HORAS_EXPIRACION_TOKEN;

        //            horasExpiracionToken = new int?(horas);
        //        }

        //        return horasExpiracionToken.Value;
        //    }
        //}

        public TicketNotificacionBusiness()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public TicketNotificacionEntityCollection GetAllActiveByUser(string dominio, string usuario, string tipo, string sortcolumn, int sortdirection)
        {
            TicketNotificacionFactory factory = new TicketNotificacionFactory();

            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;

            switch (tipo)
            {
                case "A":
                    factory.FilTipoNotif = "ALTA";
                    break;
                case "B":
                    factory.FilTipoNotif = "BLANQUEO";
                    break;
            }

            factory.FilSortColumn = sortcolumn.Replace("DESC", string.Empty).Trim();
            factory.FilSortDirection = sortdirection;
            
            TicketNotificacionEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }

        public TicketNotificacionEntity Load(int id, string tipo)
        {
            TicketNotificacionFactory factory = new TicketNotificacionFactory();

            TicketNotificacionEntity entity = factory.Load(id, tipo);

            return entity;
        }
    }
}