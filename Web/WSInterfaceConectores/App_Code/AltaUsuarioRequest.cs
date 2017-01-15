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
public class AltaUsuarioRequest
{
    public AltaUsuarioRequest()
    {
    }

    private string m_stringautenticacion;
    private string m_dominio;
    private string m_usuario;
    private string m_nombre_completo;
    private string m_email;
    private string m_legajo;

    public string StringAutenticacion { get { return m_stringautenticacion; } set { m_stringautenticacion = value; } }

    public string Dominio { get { return m_dominio; } set { m_dominio = value; } }

    public string Usuario { get { return m_usuario; } set { m_usuario = value; } }

    public string NombreCompleto { get { return m_nombre_completo; } set { m_nombre_completo = value; } }

    public string Email { get { return m_email; } set { m_email = value; } }

    public string Legajo { get { return m_legajo; } set { m_legajo = value; } }
}
