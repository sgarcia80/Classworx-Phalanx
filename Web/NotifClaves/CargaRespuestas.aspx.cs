using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NDCCommon.Entities;
using NDCBL;

public partial class CargaRespuestas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id"] != null)
        {
            if (!IsPostBack)
            {
                ddlQuestion1.DataSource = new QuestionBusiness().GetAll();
                ddlQuestion1.DataBind();
                ddlQuestion2.DataSource = new QuestionBusiness().GetAll();
                ddlQuestion2.DataBind();
                ddlQuestion3.DataSource = new QuestionBusiness().GetAll();
                ddlQuestion3.DataBind();
                ddlQuestion4.DataSource = new QuestionBusiness().GetAll();
                ddlQuestion4.DataBind();
                ddlQuestion5.DataSource = new QuestionBusiness().GetAll();
                ddlQuestion5.DataBind();

            }
        }
        else
            Response.Redirect(FormsAuthentication.LoginUrl);
    }


    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (Session["id"] != null)
        {
            int id = (int)Session["id"];
            GrabarRespuestas(id);
        }
        else
            Response.Redirect("~/Login.aspx");

    }

    private bool Validar()
    {

        try{
            lblInfo.Text = "";

            if (    ddlQuestion1.SelectedValue.Equals(String.Empty)
                ||  ddlQuestion2.SelectedValue.Equals(String.Empty)
                ||  ddlQuestion3.SelectedValue.Equals(String.Empty)
                ||  ddlQuestion4.SelectedValue.Equals(String.Empty)
                ||  ddlQuestion5.SelectedValue.Equals(String.Empty)) {
                lblInfo.Text = "Por favor, seleccione 5 preguntas y cargue sus respuestas";
                return false;
            }

            if (    txtQuestion1.Text.Equals(String.Empty)
                ||  txtQuestion2.Text.Equals(String.Empty)
                ||  txtQuestion3.Text.Equals(String.Empty)
                ||  txtQuestion4.Text.Equals(String.Empty)
                ||  txtQuestion5.Text.Equals(String.Empty)) {
                lblInfo.Text = "Por favor, seleccione 5 preguntas y cargue sus respuestas";
                return false;
            }

            List<string> list = new List<string> ();

            list.Add(ddlQuestion1.SelectedItem.Text);
            list.Add(ddlQuestion2.SelectedItem.Text);
            list.Add(ddlQuestion3.SelectedItem.Text);
            list.Add(ddlQuestion4.SelectedItem.Text);
            list.Add(ddlQuestion5.SelectedItem.Text);

            for (int i = 1; i <= 5; i++)
            {
                string sQuestionPivot = list[i - 1];
                int k = 0;
                foreach (string sQuestion in list)
                {
                    
                    if (sQuestionPivot.Equals(sQuestion)) {
                        if (k > 0) {
                            lblInfo.Text = "No puede seleccionar la misma pregunta más de una vez.";
                            return false;
                        }
                        k++;
                    }

                }
            }
        
        }
        catch{
            lblInfo.Text = "Error en carga de respuestas.";
            return false;
        }

        return true;
        
    }

    private void GrabarRespuestas(int pId)
    {
        if (!Validar())
            return;
        
        TicketNotificacionClaveBusiness tncb = new TicketNotificacionClaveBusiness();
        TicketNotificacionClaveEntity ticket = tncb.GetById(pId);
        QuestionAnswerBusiness qab = new QuestionAnswerBusiness();

        List<string> listQ = new List<string> ();
        List<string> listA = new List<string> ();

        //cargo questions
        listQ.Add(ddlQuestion1.SelectedValue);
        listQ.Add(ddlQuestion2.SelectedValue);
        listQ.Add(ddlQuestion3.SelectedValue);
        listQ.Add(ddlQuestion4.SelectedValue);
        listQ.Add(ddlQuestion5.SelectedValue);

        //cargo answers
        listA.Add(txtQuestion1.Text);
        listA.Add(txtQuestion2.Text);
        listA.Add(txtQuestion3.Text);
        listA.Add(txtQuestion4.Text);
        listA.Add(txtQuestion5.Text);

        for (int i = 1; i <= 5; i++) {
            QuestionAnswerEntity qae = new QuestionAnswerEntity();
            try
            {
                qae.Id_pregunta = Int32.Parse(listQ[i - 1]);
            }
            catch (FormatException e)
            {
                lblInfo.Text = "Error en carga de respuestas.";
                return;
            }
            
            qae.Respuesta = listA[i - 1];
            qae.Username = ticket.UsuarioAplicacion;

            qab.Save(qae);
        }

        Response.Redirect("DetalleTicketIp.aspx?");

    }

}
