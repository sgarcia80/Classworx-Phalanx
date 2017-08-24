using Classworx.Common.Trace;
using NDCCommon.Collections;
using NDCDAL.Factories;

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

        public TicketNotificacionEntityCollection GetAllActiveByUser(string dominio, string usuario, string tipo)
        {
            TicketNotificacionFactory factory = new TicketNotificacionFactory();

            factory.FilDominio = dominio;
            factory.FilUsuario = usuario;

            string tipoCodigo = string.Empty;
            switch (tipo)
            {
                case "A":
                    tipoCodigo = "ALTA";
                    break;
                case "B":
                    tipoCodigo = "BLANQUEO";
                    break;
            }

            factory.FilTipoNotif = tipoCodigo;

            TraceHelper.Information("Se consultan los tickets de {0} para el usuario {1}.", tipoCodigo, usuario);

            TicketNotificacionEntityCollection tmpCollection = factory.GetAll();

            return tmpCollection;
        }
    }
}