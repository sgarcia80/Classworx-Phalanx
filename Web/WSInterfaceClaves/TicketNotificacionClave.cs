using System;

/// <summary>
/// Summary description for BPMRequest
/// </summary>
public class TicketNotificacionClave
{
    private string m_string_autenticacion;
    private int m_solicitud_id;
    private string m_cod_app;
    private string m_nombre_app;
    private string m_us_app;
    private string m_pass_user;
    private string m_dom_us;
    private string m_us;
    private string m_legajo;
    private string m_tipo_doc;
    private string m_doc;
    private bool m_usa_pass_dom;
    private int? m_solicitud_id_alta;
    private string m_codigo_gerencia;
    private string m_nombre_gerencia;
    private string m_sigla_area;
    private string m_descripcion_area;
    private DateTime? m_fecha_vig_desde;
    private string m_nro_legajo_soli;
    private string m_cod_subsidiaria;
    private string m_nom_subsidiaria;
    private string m_nom_solicitante;
    private string m_ape_solicitante;


    public TicketNotificacionClave()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string StringAutenticacion
    {
        set { m_string_autenticacion = value; }
        get { return m_string_autenticacion; }
    }

    public int IdSolicitud
    {
        set { m_solicitud_id = value; }
        get { return m_solicitud_id; }
    }

    public string CodigoAplicacion
    {
        set { m_cod_app = value; }
        get { return m_cod_app; }
    }

    public string NombreAplicacion
    {
        set { m_nombre_app = value; }
        get { return m_nombre_app; }
    }

    public string UsuarioAplicacion
    {
        set { m_us_app = value; }
        get { return m_us_app; }
    }

    public string PasswordUsuario
    {
        set { m_pass_user = value; }
        get { return m_pass_user; }
    }

    public string DominioUsuario
    {
        set { m_dom_us = value; }
        get { return m_dom_us; }
    }

    public string Usuario
    {
        set { m_us = value; }
        get { return m_us; }
    }

    public string Legajo
    {
        set { m_legajo = value; }
        get { return m_legajo; }
    }

    public string TipoDocumento
    {
        set { m_tipo_doc = value; }
        get { return m_tipo_doc; }
    }

    public string Documento
    {
        set { m_doc = value; }
        get { return m_doc; }
    }

    public bool UsaPasswordDominio
    {
        set { m_usa_pass_dom = value; }
        get { return m_usa_pass_dom; }
    }

    public int? SolicitudID
    {
        get { return m_solicitud_id_alta; }
        set { m_solicitud_id_alta = value; }
    }

    public string CodigoGerencia
    {
        get { return m_codigo_gerencia; }
        set { m_codigo_gerencia = value; }
    }

    public string NombreGerencia
    {
        get { return m_nombre_gerencia; }
        set { m_nombre_gerencia = value; }
    }

    public string SiglaArea
    {
        get { return m_sigla_area; }
        set { m_sigla_area = value; }
    }

    public string DescripcionArea
    {
        get { return m_descripcion_area; }
        set { m_descripcion_area = value; }
    }

    public DateTime? FechaVigDesde
    {
        get { return m_fecha_vig_desde; }
        set { m_fecha_vig_desde = value; }
    }

    public string NroLegajoSoli
    {
        get { return m_nro_legajo_soli; }
        set { m_nro_legajo_soli = value; }
    }

    public string CodSubsidiaria
    {
        get { return m_cod_subsidiaria; }
        set { m_cod_subsidiaria = value; }
    }

    public string NomSubsidiaria
    {
        get { return m_nom_subsidiaria; }
        set { m_nom_subsidiaria = value; }
    }

    public string NomSolicitante
    {
        get { return m_nom_solicitante; }
        set { m_nom_solicitante = value; }
    }

    public string ApeSolicitante
    {
        get { return m_ape_solicitante; }
        set { m_ape_solicitante = value; }
    }
}
