using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BPMRequest
/// </summary>
public class GrupoSolicitudesRequest
{
    public GrupoSolicitudesRequest()
    {
    }

    private string m_stringautenticacion;
    private string m_dominio;
    private string m_usuario;
    private string m_id_grupo;

    public string StringAutenticacion { get { return m_stringautenticacion; } set { m_stringautenticacion = value; } }

    public string Dominio { get { return m_dominio; } set { m_dominio = value; } }

    public string Usuario { get { return m_usuario; } set { m_usuario = value; } }

    public string IdGrupos { get { return m_id_grupo; } set { m_id_grupo = value; } }
}
