using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace WSInterfaceConectores.Request
{
    /// <summary>
    /// Summary description for BPMRequest
    /// </summary>
    public class GrupoSolicitudesRequest : BaseRequest
    {
        public GrupoSolicitudesRequest()
        {
        }

        public string Dominio { get; set; }

        public string Usuario { get; set; }

        public string IdGrupos { get; set; }
    }
}