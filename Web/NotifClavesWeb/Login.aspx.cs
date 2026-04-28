using Classworx.Common.Trace;
using NDCBL;
using NDCCommon.Collections;
using NDCCommon.Entities;
using Newtonsoft.Json;
using PhalanxBL;
using PhalanxCommon.Collections;
using PhalanxCommon.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace NotifClavesWeb
{
    public partial class Login : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("externo");
            }
            catch (Exception)
            {
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            //string dominio = tbDominio.Text.Trim();
            string dominio = ddlDominio.SelectedValue;
            string usuario = tbUsuario.Text.Trim();
            string password = tbPassword.Text;

            if (Autenticar(dominio, usuario, password))
            {
                string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

                FormsAuthentication.SetAuthCookie(nombreUsuario, false);
                Session["Usuario"] = usuario;
                Session["Dominio"] = dominio;

                //FormsAuthentication.RedirectFromLoginPage(nombreUsuario, false);
                Response.Redirect("ClavesAplicativos.aspx");
            }
            else
            {
                lbMensaje.Text = "Usuario o Contraseña incorrecto";
                lbMensaje.Visible = true;
            }
        }


        protected void btnNotificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotificacionClave.aspx");
        }

        private bool Autenticar(string dominio, string usuario, string password)
        {
            bool authentic = false;
            bool esExterno = false;

            AuditLoginBusiness auditLoginBusiness = new AuditLoginBusiness();

            string nombreUsuario = string.Format(@"{0}\{1}", dominio, usuario);

            try
            {
                string provider = "LDAP";

                PhxConfigBusiness pcb = new PhxConfigBusiness();

                PhxConfigEntity config = pcb.GetConfigParam(ConfigCodes.AutenticacionLoginNDC);

                if (config.ShortTxtValue == "WINNT")
                    provider = "WinNT";

                string path = provider + "://" + dominio;

                DirectoryEntry entry = new DirectoryEntry(path, usuario, password);

                object nativeObject = entry.NativeObject;
                authentic = true;

                string legajo = PhalanxNAL.ActiveDirectoryHelper.BuscarEmployeeID(usuario, path);

                esExterno = string.IsNullOrEmpty(legajo);
                //if (!string.IsNullOrEmpty(legajo))
                //{
                //    esExterno = legajo.ToUpper().Contains("EXTERNO");
                //}

                auditLoginBusiness.LogAccOK(null, nombreUsuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves);
            }
            catch (DirectoryServicesCOMException cex)
            {
                if (cex.ExtendedError == -2146893044)
                    auditLoginBusiness.LogUsrConInexistente(null, usuario, null, Request.ServerVariables["REMOTE_ADDR"], PhalanxCommon.Entities.App.NotificacionClaves);
            }
            catch (Exception ex)
            {
                TraceHelper.Error(ex, "Error al autenticar el usuario");
            }

            if (esExterno)
            {
                //TODO
                //Session["externo"] = "N";
                Session["externo"] = (esExterno) ? "S" : "N";
            }
            return authentic;
        }



        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaTemprana.aspx");
        }

        protected void btnCerrarSession_Click(object sender, EventArgs e)
        {
            string url = @"https://localhost:7043/api/sp/execute";
            var response = Task.Run(() => SendDataToAPIAsync(url));
        }

        private async Task SendDataToAPIAsync(string url)
        {
            List<SpParam> spParams = new List<SpParam>()
            {
                new SpParam() {
                    name = "@i_login",
                    dataType = 39,
                    value = "moria",
                    ioType = 0
                },
                new SpParam() {
                    name = "@i_distrib",
                    dataType = 39,
                    value = "C",
                    ioType = 0
                },
                new SpParam() {
                    name = "@i_fin_todoservidor",
                    dataType = 39,
                    value = "S",
                    ioType = 0
                },
                new SpParam() {
                    name = "@i_fin_todasesion",
                    dataType = 39,
                    value = "S",
                    ioType = 0
                },
                new SpParam() {
                    name = "@t_trn",
                    dataType = 52,
                    value = "15814",
                    ioType = 0
                }
            };

            SpRequest request = new SpRequest()
            {
                spName = "cobis..sp_login",
                @params = spParams
            };

            var json = JsonConvert.SerializeObject(request);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await GenerateCallAsync(url,content);
            if(response.Length > 0)
            {
                SessionLabel.Visible = true;
                SessionLabel.Text = "Session Cerrada";
            }
        }

        private async Task<string> GenerateCallAsync(string url , StringContent content)
        {
            //var response = await client.GetAsync(@"https://localhost:7043/api/sp");
            var response = await client.PostAsync(url, content);

            // Checking if the request was successful
            response.EnsureSuccessStatusCode();

            // Reading the response body as a string
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }

    public class SpRequest
    {
        public string spName { get; set; }
        public List<SpParam> @params { get; set; }
    }

    public class SpParam
    {
        public string name { get; set; }
        public int dataType { get; set; }
        public string value { get; set; }
        public int ioType { get; set; }
    }
}