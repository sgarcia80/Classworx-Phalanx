using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NDCBL;
using NDCCommon.Collections;

public partial class ClavesAplicativos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("~/Login.aspx");
        }

        if (!IsPostBack)
        {
            bool esExterno = false;

            if (Session["externo"] != null)
            {
                esExterno = Session["externo"].ToString() == "S";
            }

            panelPreguntas.Visible = esExterno;

            if (esExterno)
            {
                QuestionAnswerBusiness qab = new QuestionAnswerBusiness();
                qab.FilUser = Session["Usuario"].ToString();

                QuestionAnswerEntityCollection qaEC = new QuestionAnswerEntityCollection();
                qaEC = qab.GetAll();

                btnNotifClaves.OnClientClick = "";

                if (qaEC == null || qaEC.Count == 0)
                {
                    btnNotifClaves.OnClientClick = "alert('Primero debe cargar las preguntas de seguridad'); return false;";
                }
            }
        }
    }
    protected void btnCOBIS_Click(object sender, EventArgs e)
    {
        Response.Redirect("AutogestionCOBIS.aspx");
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnNotifClaves_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tickets.aspx");
    }
    protected void btnPreguntas_Click(object sender, EventArgs e)
    {
        Response.Redirect("CargaRespuestasUsr.aspx");
    }
}