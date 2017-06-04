using NDCBL;
using NDCCommon.Collections;
using NDCCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotifClavesWeb
{
    public partial class ValidaRespuestas : System.Web.UI.Page
    {
        public List<QuestionAnswerEntity> Questions
        {
            get
            {
                return (List<QuestionAnswerEntity>)Session["questions"];
            }
            set
            {
                Session["questions"] = value;
            }
        }

        protected QuestionAnswerEntityCollection randomQAEC;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["Usuario"] != null)
                {
                    if (!IsPostBack)
                    {
                        QuestionAnswerBusiness qab = new QuestionAnswerBusiness();
                        qab.FilUser = (string)Session["Usuario"];

                        QuestionAnswerEntityCollection qaEC = qab.GetAll();
                        List<QuestionAnswerEntity> list = new List<QuestionAnswerEntity>();
                        if (qaEC.Count != 5)
                        {
                            Response.Redirect(FormsAuthentication.LoginUrl);
                        }

                        QuestionBusiness qb = new QuestionBusiness();
                        randomQAEC = qaEC.GetRandomEC(3);

                        int i = 1;
                        foreach (QuestionAnswerEntity qaEntity in randomQAEC)
                        {
                            list.Add(qaEntity);

                            if (i == 1)
                            {
                                lblQuestion1.Text = qaEntity.Pregunta.Nombre;
                            }
                            if (i == 2)
                            {
                                lblQuestion2.Text = qaEntity.Pregunta.Nombre;
                            }
                            if (i == 3)
                            {
                                lblQuestion3.Text = qaEntity.Pregunta.Nombre;
                            }
                            i++;
                        }

                        this.Questions = list;
                    }
                }
                else
                    Response.Redirect(FormsAuthentication.LoginUrl);

            }
            catch (Exception)
            {
                Response.Redirect(FormsAuthentication.LoginUrl);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string mensaje = "Respuestas Incorrectas";
            lblInfo.Text = string.Empty;
            bool ok = true;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    if (!txtAnswer1.Text.Trim().ToUpper().Equals(this.Questions[i].Respuesta))
                    {
                        ok = false;
                    }
                }
                if (i == 1)
                {
                    if (!txtAnswer2.Text.Trim().ToUpper().Equals(this.Questions[i].Respuesta))
                    {
                        ok = false;
                    }
                }
                if (i == 2)
                {
                    if (!txtAnswer3.Text.Trim().ToUpper().Equals(this.Questions[i].Respuesta))
                    {
                        ok = false;
                    }
                }
            }

            int ticketid = 0;

            if (Session["ticketId"] == null)
            {
                mensaje = "No se encontró una Notifiación de Blanqueo";
                ok = false;
            }
            else
            {
                int.TryParse(Session["ticketId"].ToString(), out ticketid);
            }

            if (ok)
            {
                string url = string.Format("DetalleTicket.aspx?id={0}&tipo={1}", ticketid, "BLANQUEO");
                Response.Redirect(url);
            }
            else
            {
                TicketNotificacionBlanqueoBusiness tnb = new TicketNotificacionBlanqueoBusiness();
                TicketNotificacionBlanqueoEntity ticket = tnb.Cancelar(ticketid);

                if (ticket != null && ticket.FechaCancelado.HasValue)
                {
                    lblInfo.Text = "Se ha superado los intentos. Debe solicitar el blanqueo nuevamente.";
                    btnAceptar.Enabled = false;
                }
                else
                {
                    lblInfo.Text = mensaje;
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NotificacionClave.aspx");
        }
    }
}