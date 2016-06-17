using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.DirectoryServices;
using PhalanxBL;
using PhalanxCommon.Entities;
using System.Text.RegularExpressions;
using Microsoft.Web.Services3.Security.Tokens;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public partial class CambioContrasenia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!Page.IsPostBack)
        {
        }

        trTitRespuesta.Visible = false;
        trRespuesta.Visible = false;

        LimpiarReglas();
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            //!s.Where((c,i)=> i >= 2 && s[i-1] == c && s[i-2] == c).Any()

            string usuario = string.Empty;

            if (Session["Usuario"] != null)
                usuario = Session["Usuario"].ToString();

            string password = tbPassword.Text;
            string passwordconfirm = tbPasswordConfirm.Text;

            bool cambioOk = Validar(password, passwordconfirm);

            if (cambioOk)
            {
                CambiarClave();
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        Response.Redirect("AltaTemprana.aspx");
    }

    private void CambiarClave()
    {
        PhxConfigBusiness pcb = new PhxConfigBusiness();

        string usuarioLlamada = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.UsuarioLlamadaWSCOBIS).ShortTxtValue;
        string idAplicacion = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.IDAplicacionWSCOBIS).ShortTxtValue;
        string estado = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.EstadoWSCOBIS).ShortTxtValue;
        string quienLlama = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.QuienLlamaWSCOBIS).ShortTxtValue;

        string loginASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.LoginASBlanqueoWSCOBIS).ShortTxtValue;
        string claveASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.ClaveASBlanqueoWSCOBIS).ShortTxtValue;
        string rolASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.RolASBlanqueoWSCOBIS).ShortTxtValue;
        string oficinaASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.OficinaASBlanqueoWSCOBIS).ShortTxtValue;
        string servidorASBlanqueoWSCOBIS = pcb.GetConfigParam(PhalanxCommon.Entities.ConfigCodes.ServidorASBlanqueoWSCOBIS).ShortTxtValue;

        //COBISDesbloqueo.BloqueoDesbloqueoUsuariosCobisServiceWse serviceProxy = new BloqueoDesbloqueoUsuariosCobisServiceWse();
        ADCambioContrasenia.ADCambioContraseniaServiceWse serviceProxy = new ADCambioContrasenia.ADCambioContraseniaServiceWse();

        UsernameToken token = new UsernameToken(usuarioLlamada, "a", PasswordOption.SendNone);
        serviceProxy.SetClientCredential(token);
        serviceProxy.SetPolicy("ClientPolicy");
        ADCambioContrasenia.RequestConnection requestConnection = new ADCambioContrasenia.RequestConnection();
        requestConnection.applicationID = idAplicacion;
        requestConnection.password = string.Empty;
        requestConnection.sessionID = string.Empty;
        requestConnection.user = string.Empty;

        ADCambioContrasenia.ADCambioContraseniaFil filtro = new ADCambioContrasenia.ADCambioContraseniaFil();

        filtro.i_u_login_adminseg = loginASBlanqueoWSCOBIS;
        filtro.i_c_clave_adminseg = claveASBlanqueoWSCOBIS;
        filtro.i_rol_adminseg = rolASBlanqueoWSCOBIS;
        filtro.i_oficina_adminseg = oficinaASBlanqueoWSCOBIS;
        filtro.i_servidor_adminseg = servidorASBlanqueoWSCOBIS;
        filtro.i_c_clave = tbPassword.Text.ToLower();
        filtro.i_u_login = Session["Usuario"].ToString();

        bool ErrorExec = true;
        lblResp2.Text = string.Empty;
        string error = string.Empty;

        try
        {
            X509Certificate2 certificate = ObtenerCertificado();

            if (certificate == null)
            {
                error = "No se encontró el certificado";
            }
            else
            {
                serviceProxy.ClientCertificates.Add(certificate);
            }
        }
        catch (Exception ex)
        {
            error = string.Format("Error: {0}", ex.Message);
        }

        if (!string.IsNullOrEmpty(error))
        {
            lblError.Text = "<BR/><BR/>" + error;
        }

        try
        {
            ADCambioContrasenia.ADCambioContraseniaRes resultado = serviceProxy.execute(requestConnection, filtro);

            if (resultado.serviceError.code == 0)
            {
                trTitRespuesta.Visible = true;
                trRespuesta.Visible = true;
                lblResp2.Text = "Se ha cambiado la contraseña en forma satisfactoria";
                ErrorExec = false;
            }

            if (resultado != null &&
                resultado.serviceError != null &&
                !string.IsNullOrEmpty(resultado.serviceError.message))
            {
                error = string.Format("serviceError: {0}", resultado.serviceError.message);
            }

            if (!string.IsNullOrEmpty(error))
            {
                error = "Error devuelto por el servicio:<BR/>" + error;
            }
        }
        catch (Microsoft.Web.Services3.Security.SecurityFault ee)
        {
            error = "Security Error:<BR/>" + ee.Actor;
        }
        catch (System.Web.Services.Protocols.SoapHeaderException ee)
        {
            error = "Soap Error:<BR/>" + ee.ToString();
            //txtRespuesta.Text += ee.Message;
        }
        catch (Exception ex)
        {
            error = "Internal Error:<BR/>" + ex.ToString();
            //txtRespuesta.Text += ex.Message;
        }

        lblError.Text = string.Empty;
        if (ErrorExec && string.IsNullOrEmpty(lblResp2.Text))
        {
            trTitRespuesta.Visible = true;
            trRespuesta.Visible = true;
            lblResp2.Text = "no se ha podido cambiar la contraseña. <br/>Por favor ingresa una solicitud vía Remedy, y te responderemos a la brevedad!";
        }

        bool showCobis = false;
        if (ConfigurationManager.AppSettings["RespuestaCobis"] != null &&
            ConfigurationManager.AppSettings["RespuestaCobis"].ToString() == "1")
        {
            showCobis = true;
        }

        if (!string.IsNullOrEmpty(error) && showCobis)
        {
            lblError.Text = "<BR/><BR/>" + error;
        }
    }

    private void LimpiarReglas()
    {
        lblregla_caracteres.ForeColor = Color.Black;
        lblregla_largo.ForeColor = Color.Black;
        lblregla_min_letras.ForeColor = Color.Black;
        lblregla_min_nro.ForeColor = Color.Black;
        lblregla_let_rep.ForeColor = Color.Black;
        lblregla_nro_rep.ForeColor = Color.Black;
    }

    private void MostrarError(string mensaje)
    {
        lbMensaje.Text = mensaje;
        lbMensaje.Visible = !string.IsNullOrEmpty(mensaje);

        trTitRespuesta.Visible = false;
        trRespuesta.Visible = false;
        lblResp2.Text = string.Empty;
    }

    private bool Validar(string password, string passwordconfirm)
    {
        bool ok = false;
        lbMensaje.Text = string.Empty;

        try
        {
            bool largoOk = true;

            //Si la clave contiene otros caracteres que no sean letras y numeros
            bool caracteresValidos = ValidarLetrasNumeros(password);
            if (!caracteresValidos)
            {
                lblregla_caracteres.ForeColor = System.Drawing.Color.Red;
            }

            //Si la longitud no esta entre 8 y 12 digitos alfanumericos.
            if (password.Length < 8 || password.Length > 12)
            {
                largoOk = false;
                lblregla_largo.ForeColor = System.Drawing.Color.Red;
            }

            //Mínimo 4 letras.
            bool minletrasOk = ValidarCantidaLetras(password, 4);
            if (!minletrasOk)
            {
                lblregla_min_letras.ForeColor = System.Drawing.Color.Red;
            }

            //Mínimo 2 números.
            bool minnroOk = ValidarCantidadNumeros(password, 2);
            if (!minnroOk)
            {
                lblregla_min_nro.ForeColor = System.Drawing.Color.Red;
            }

            //No puede haber 2 letras iguales seguidas.
            bool letrasOk = ValidarLetrasRepetidas(password);
            if (!letrasOk)
            {
                lblregla_let_rep.ForeColor = System.Drawing.Color.Red;
            }

            //No puede haber 3 números iguales seguidos.
            bool numerosOk = ValidarNumerosRepetidas(password);
            if (!numerosOk)
            {
                lblregla_nro_rep.ForeColor = System.Drawing.Color.Red;
            }

            //No importa si las letras son mayúsculas o minúsculas porque COBIS no hace diferencia.

            //Si alguna de las reglas falla
            if (!largoOk || !minletrasOk || !minnroOk || !letrasOk || !numerosOk || !caracteresValidos)
            {
                MostrarError("La nueva contraseña no cumple con todas las reglas");
            }
            else
            {
                //Por ultimo, ambas claves deben ser iguales.
                if (password != passwordconfirm)
                {
                    MostrarError("Las Contraseñas deben ser iguales");
                }
                else
                {
                    ok = true;
                }
            }

        }
        catch (Exception ex)
        {
            string mensaje = string.Format("Error al validar las contraseñas ({0})", ex.Message);

            MostrarError(mensaje);
        }

        return ok;
    }

    private bool ValidarCantidaLetras(string cadena, int cantidadminimma)
    {
        bool result = false;

        MatchCollection matches = null;
        matches = Regex.Matches(cadena, @"([a-zA-Z])");

        //Si se encontraron letras
        if (matches != null && matches.Count > 0)
        {
            //Se revisa la cantidad de letras encontradas
            result = (matches.Count >= cantidadminimma);
        }

        return result;
    }

    private bool ValidarCantidadNumeros(string cadena, int cantidadminimma)
    {
        bool result = false;

        MatchCollection matches = null;
        matches = Regex.Matches(cadena, @"(\d)");

        //Si se encontraron números
        if (matches != null && matches.Count > 0)
        {
            //Se revisa la cantidad de números encontrados
            result = (matches.Count >= cantidadminimma);
        }

        return result;
    }

    private bool ValidarLetrasRepetidas(string cadena)
    {
        bool result = false;

        Match match = null;
        match = Regex.Match(cadena, @"(\D)\1+?");

        result = !match.Success;

        return result;
    }

    private bool ValidarLetrasNumeros(string cadena)
    {
        bool result = false;

        Match match = null;
        match = Regex.Match(cadena, @"^[a-zA-Z0-9]+$");

        result = match.Success;

        return result;
    }

    private bool ValidarNumerosRepetidas(string cadena)
    {
        bool result = false;

        Match match = null;
        match = Regex.Match(cadena, @"(\d)\1\1+?");

        result = !match.Success;

        return result;
    }

    private X509Certificate2 ObtenerCertificado()
    {
        X509Certificate2 cer = null;

        string cerName = string.Empty;
        int cerStore = 0;
        StoreName storename = StoreName.My;

        if (ConfigurationManager.AppSettings["ADCambioContrasenia_CertificateName"] != null)
        {
            cerName = ConfigurationManager.AppSettings["ADCambioContrasenia_CertificateName"];
        }
        if (ConfigurationManager.AppSettings["ADCambioContrasenia_CertificateStore"] != null)
        {
            int.TryParse(ConfigurationManager.AppSettings["ADCambioContrasenia_CertificateStore"], out cerStore);
        }

        if (string.IsNullOrEmpty(cerName))
        {
            throw new ArgumentException("El nombre del certificado no está configurado");
        }
        if (cerStore == 0)
        {
            throw new ArgumentException("El respositorio del certificado no está configurado");
        }
        else
        {
            storename = (StoreName)cerStore;
        }

        X509Store store = new X509Store(storename, StoreLocation.LocalMachine);

        store.Open(OpenFlags.ReadOnly);

        X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySubjectName, cerName, false);
        
        if (cers.Count > 0)
        {
            cer = cers[0];
        };
        return cer;
    }
}
