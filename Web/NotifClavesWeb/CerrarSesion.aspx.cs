using Classworx.Common.Trace;
using NDCBL;
using NDCCommon.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhalanxBL;
using PhalanxCommon.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace NotifClavesWeb
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                trTitRespuesta.Visible = false;
                trRespuesta.Visible = false;
            }
        }

        private static bool AllwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("AutogestionCOBIS.aspx");
        }

        protected async void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            trTitRespuesta.Visible = false;
            trRespuesta.Visible = false;
            lblError.Text = "";
            if (Session["Dominio"] == null || Session["Usuario"] == null)
            {
                return;
            }

            string usuarioLogin = (Session["Usuario"] ?? string.Empty).ToString().ToLower();
            var log = new StringBuilder();
            string error = string.Empty;

            bool showCobis = false;
            if (ConfigurationManager.AppSettings["RespuestaCobis"] != null &&
                ConfigurationManager.AppSettings["RespuestaCobis"].ToString() == "1")
            {
                showCobis = true;
                lblError.Visible = true;
            }

            TicketAutogestionCobisEntity ticket = TicketAutogestionCobisEntity.CreateDesbloqueo();
            ticket.Usuario = usuarioLogin;
            ticket.Fecha = DateTime.Now;
            ticket.RespuestaCodigo = 0;
            ticket.RespuestaMensaje = string.Empty;

            try
            {
                PhxConfigBusiness pcb = new PhxConfigBusiness();

                string usuarioLlamada = ConfigurationManager.AppSettings["UsuarioLlamadaWSCOBIS"];
                string idAppCTS = ConfigurationManager.AppSettings["IdAppCTSAuth"];
                string idServicioCTS = ConfigurationManager.AppSettings["IdServiceCTSAuth"];
                string AuthenticatorUrl = ConfigurationManager.AppSettings["CTSRestAuthenticationURL"];
                string ExecutorUrl = ConfigurationManager.AppSettings["CTSRestExecutorURL"];

                lblUsrName.Text = usuarioLogin;

                string urlGet = $"{AuthenticatorUrl}/CTSRestAuthentication/resource/authenticate/relation?login={Uri.EscapeDataString(usuarioLlamada)}&application_id={Uri.EscapeDataString(idAppCTS)}&servicio={Uri.EscapeDataString(idServicioCTS)}";
                log.AppendLine($"[{DateTime.Now:O}] Llamada a CTSRestAuthentication: {urlGet}");

                string credentialsResponse = await GenerateGetCallAsync(urlGet);
                log.AppendLine($"[{DateTime.Now:O}] credentialsResponse length={(credentialsResponse?.Length ?? 0)}");

                if (string.IsNullOrEmpty(credentialsResponse))
                {
                    error = "No se ha podido obtener el token de autenticación. No se puede continuar con la solicitud.";
                    log.AppendLine($"[{DateTime.Now:O}] ERROR: {error}");
                    throw new Exception(error);
                }

                log.AppendLine($"[{DateTime.Now:O}] Extrayendo token (no se registra token completo por seguridad)");
                string token = ExtractBearerToken(credentialsResponse);
                log.AppendLine($"[{DateTime.Now:O}] Token obtenido: {(string.IsNullOrEmpty(token) ? "<absent>" : $"length={token.Length}")}");

                string urlPost = $"{ExecutorUrl}/CTSRestExecutor/resource/sp/execute";
                log.AppendLine($"[{DateTime.Now:O}] Preparando POST a {urlPost}");

                string executorDistrib = ConfigurationManager.AppSettings["ExecutorCobis_distrib"] ?? "C";
                string executorFinTodoServidor = ConfigurationManager.AppSettings["ExecutorCobis_fin_todoservidor"] ?? "S";
                string executorFinTodaSesion = ConfigurationManager.AppSettings["ExecutorCobis_fin_todasesion"] ?? "S";
                string executorTTrn = ConfigurationManager.AppSettings["ExecutorCobis_t_trn"] ?? "15814";

                List<SpParam> spParams = new List<SpParam>()
                {
                    new SpParam() { name = "@i_login", dataType = 39, value = usuarioLogin, ioType = 0 },
                    new SpParam() { name = "@i_distrib", dataType = 39, value = executorDistrib, ioType = 0 },
                    new SpParam() { name = "@i_fin_todoservidor", dataType = 39, value = executorFinTodoServidor, ioType = 0 },
                    new SpParam() { name = "@i_fin_todasesion", dataType = 39, value = executorFinTodaSesion, ioType = 0 },
                    new SpParam() { name = "@t_trn", dataType = 52, value = executorTTrn, ioType = 0 }
                };

                CTSRestExecutorSpRequest requestPost = new CTSRestExecutorSpRequest()
                {
                    spName = "cobis..sp_login",
                    @params = spParams
                };

                var json = JsonConvert.SerializeObject(requestPost);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                log.AppendLine($"[{DateTime.Now:O}] Request JSON {json}");

                string sanitizedToken = token?.Trim().Trim('"');
                log.AppendLine($"[{DateTime.Now:O}] Iniciando llamada a CTSRestExecutor");

                var (statusCode, responseBody) = await GeneratePostCallAsync(urlPost, content, sanitizedToken);

                log.AppendLine($"[{DateTime.Now:O}] Resultado CTSRestExecutor - HTTP {(int)statusCode} ({statusCode})");
                log.AppendLine($"[{DateTime.Now:O}] responseBody length={(responseBody?.Length ?? 0)}");

                trTitRespuesta.Visible = true;
                trRespuesta.Visible = true;

                if (statusCode == System.Net.HttpStatusCode.OK)
                {
                    if (string.IsNullOrWhiteSpace(responseBody))
                    {
                        lblError.Text = "<BR/><BR/>Operación completada pero el servicio devolvió contenido vacío.";
                        log.AppendLine($"[{DateTime.Now:O}] WARNING: body vacío");
                    }
                    else
                    {
                        try
                        {
                            var auxResponseBody = JObject.Parse(responseBody);

                            int returnCode = auxResponseBody.Value<int?>("returnCode") ?? -1;
                            var messagesExecutor = auxResponseBody["messages"] as JArray;
                            bool messagesEmpty = messagesExecutor == null || messagesExecutor.Count == 0;

                            log.AppendLine($"[{DateTime.Now:O}] Parsed JSON: returnCode={returnCode}, messagesCount={(messagesExecutor?.Count ?? 0)}");

                            if (returnCode == 0 && messagesEmpty)
                            {
                                lblResp2.Text = "Se ha cerrado con exito todas las sesiones.";
                                log.AppendLine($"[{DateTime.Now:O}] Operación finalizada con éxito (returnCode=0 y messages vacío)");
                            }
                            else
                            {
                                ticket.RespuestaCodigo = returnCode;

                                lblResp2.Text = "Error en la operación. No se han cerrado las sesiones.";
                                if (showCobis)
                                { 
                                    lblError.Text = "<BR/><BR/>" + HttpUtility.HtmlEncode(responseBody);
                                }

                                string messagesSummary = messagesExecutor == null ? "<null>" : messagesExecutor.ToString(Newtonsoft.Json.Formatting.None);
                                log.AppendLine($"[{DateTime.Now:O}] Operación fallida: returnCode={returnCode}, messages={messagesSummary}");

                                ticket.RespuestaMensaje = messagesSummary;
                            }
                        }
                        catch (JsonException jex)
                        {
                            if (showCobis)
                            { 
                                lblError.Text = "<BR/><BR/>Respuesta inválida del servicio.";
                            }
                            log.AppendLine($"[{DateTime.Now:O}] Error parseando JSON: {jex.Message}");
                        }
                    }
                }
                else
                {

                    lblResp2.Text = "Error en la operación. No se han cerrado las sesiones.";
                    if (showCobis)
                    { 
                        lblError.Text = $"<BR/><BR/>Error en la petición. HTTP {(int)statusCode} - {statusCode}. Contenido: {HttpUtility.HtmlEncode(responseBody)}";
                    }
                    ticket.RespuestaCodigo = (int)statusCode;
                    ticket.RespuestaMensaje = responseBody;

                    string truncated = responseBody ?? "<null>";
                    if (truncated.Length > 2000) truncated = truncated.Substring(0, 2000) + "...(truncated)";
                    log.AppendLine($"[{DateTime.Now:O}] HTTP error body (truncated to 2000 chars): {truncated}");
                }
            }
            catch (Exception ex)
            {
                ticket.RespuestaCodigo = -1;
                ticket.RespuestaMensaje = ex.Message;

                log.AppendLine($"[{DateTime.Now:O}] Excepción: {ex.GetType().FullName} - {ex.Message}");
                if (showCobis)
                {
                    lblError.Text = "<BR/><BR/>Excepción: " + HttpUtility.HtmlEncode(ex.Message);
                }
                trTitRespuesta.Visible = true;
                trRespuesta.Visible = true;
            }
            finally
            {
                TicketAutogestionCobisBusiness ticketBL = new TicketAutogestionCobisBusiness();
                ticketBL.Save(ticket);

                TraceHelper.Information($"Usuario : {usuarioLogin}." + log.ToString());
            }
        }

        private async Task<(System.Net.HttpStatusCode StatusCode, string Content)> GeneratePostCallAsync(string url, HttpContent content, string bearerToken = null)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                request.Content = content;

                if (!string.IsNullOrWhiteSpace(bearerToken))
                {
                    string tokenClean = bearerToken.Trim();
                    if (tokenClean.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                        tokenClean = tokenClean.Substring("Bearer ".Length).Trim();

                    tokenClean = tokenClean.Trim('"');

                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenClean);
                }

                using (var response = await client.SendAsync(request))
                {
                    var body = await response.Content.ReadAsStringAsync();
                    return (response.StatusCode, body);
                }
            }
        }

        private static string ExtractBearerToken(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
                return null;

            int idx = source.IndexOf("Bearer", StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                return null;

            idx += "Bearer".Length;

            // saltar ':' o espacios después de "Bearer"
            while (idx < source.Length && (source[idx] == ':' || char.IsWhiteSpace(source[idx])))
                idx++;

            string remainder = source.Substring(idx).Trim();

            // tomar hasta el primer espacio o salto de línea (si hay otros encabezados)
            int end = remainder.IndexOfAny(new[] { '\r', '\n', ' ', '\t' });
            if (end > 0)
                remainder = remainder.Substring(0, end);

            return remainder;
        }

        private async Task<string> GenerateGetCallAsync(string url)
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            string responseHeaders = response.Headers.ToString();
            return responseHeaders;
        }
    }
}