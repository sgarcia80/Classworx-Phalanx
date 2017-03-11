using NDCBL;
using NDCCommon.Collections;
using NDCCommon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotifClavesWeb
{
    public partial class CargaRespuestasUsr : System.Web.UI.Page
    {
        public List<QuestionEntity> Questions
        {
            get
            {
                return (List<QuestionEntity>)Session["questions"];
            }
            set
            {
                Session["questions"] = value;
            }
        }

        public List<QuestionAnswerEntity> Answers
        {
            get
            {
                return (List<QuestionAnswerEntity>)Session["answers"];
            }
            set
            {
                Session["answers"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {

                QuestionEntityCollection questions = new QuestionBusiness().GetAll();

                ddlQuestion1.DataSource = questions;
                ddlQuestion1.DataBind();
                ddlQuestion2.DataSource = questions;
                ddlQuestion2.DataBind();
                ddlQuestion3.DataSource = questions;
                ddlQuestion3.DataBind();
                ddlQuestion4.DataSource = questions;
                ddlQuestion4.DataBind();
                ddlQuestion5.DataSource = questions;
                ddlQuestion5.DataBind();

                this.Questions = questions.ToList();



                QuestionAnswerBusiness qab = new QuestionAnswerBusiness();
                qab.FilUser = (string)Session["Usuario"];

                QuestionAnswerEntityCollection qaEC = qab.GetAll();

                int i = 1;
                foreach (QuestionAnswerEntity qaEntity in qaEC)
                {

                    if (i == 1)
                    {
                        txtQuestion1.Text = qaEntity.Respuesta;
                        ddlQuestion1.SelectedValue = qaEntity.Pregunta.Key;
                    }
                    if (i == 2)
                    {
                        txtQuestion2.Text = qaEntity.Respuesta;
                        ddlQuestion2.SelectedValue = qaEntity.Pregunta.Key;
                    }
                    if (i == 3)
                    {
                        txtQuestion3.Text = qaEntity.Respuesta;
                        ddlQuestion3.SelectedValue = qaEntity.Pregunta.Key;
                    }
                    if (i == 4)
                    {
                        txtQuestion4.Text = qaEntity.Respuesta;
                        ddlQuestion4.SelectedValue = qaEntity.Pregunta.Key;
                    }
                    if (i == 5)
                    {
                        txtQuestion5.Text = qaEntity.Respuesta;
                        ddlQuestion5.SelectedValue = qaEntity.Pregunta.Key;
                    }
                    i++;
                }

                this.Answers = qaEC.ToList();


            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            GrabarRespuestas();

        }

        private bool Validar()
        {
            try
            {
                lblInfo.Text = "";

                if (ddlQuestion1.SelectedValue.Equals(String.Empty)
                    || ddlQuestion2.SelectedValue.Equals(String.Empty)
                    || ddlQuestion3.SelectedValue.Equals(String.Empty)
                    || ddlQuestion4.SelectedValue.Equals(String.Empty)
                    || ddlQuestion5.SelectedValue.Equals(String.Empty))
                {
                    lblInfo.Text = "Por favor, seleccione 5 preguntas y cargue sus respuestas";
                    return false;
                }

                if (txtQuestion1.Text.Equals(String.Empty)
                    || txtQuestion2.Text.Equals(String.Empty)
                    || txtQuestion3.Text.Equals(String.Empty)
                    || txtQuestion4.Text.Equals(String.Empty)
                    || txtQuestion5.Text.Equals(String.Empty))
                {
                    lblInfo.Text = "Por favor, seleccione 5 preguntas y cargue sus respuestas";
                    return false;
                }

                List<string> list = new List<string>();

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

                        if (sQuestionPivot.Equals(sQuestion))
                        {
                            if (k > 0)
                            {
                                lblInfo.Text = "No puede seleccionar la misma pregunta más de una vez.";
                                return false;
                            }
                            k++;
                        }
                    }
                }
            }
            catch
            {
                lblInfo.Text = "Error en carga de respuestas.";
                return false;
            }

            return true;

        }

        private void GrabarRespuestas()
        {
            if (!Validar())
            {
                return;
            }

            string usuario = Session["Usuario"].ToString();
            QuestionAnswerBusiness qab = new QuestionAnswerBusiness();

            QuestionAnswerEntityCollection list = new QuestionAnswerEntityCollection();
            QuestionAnswerEntity answer = null;

            QuestionEntityCollection questions = new QuestionEntityCollection();
            questions.Add(Questions);

            //cargo questions
            answer = new QuestionAnswerEntity();
            answer.Username = usuario;
            answer.Pregunta = questions.Find(ddlQuestion1.SelectedValue.ToString());
            answer.Respuesta = txtQuestion1.Text.ToUpper().Trim();
            if (this.Answers.Count > 0)
                answer.Id = this.Answers[0].Id;
            list.Add(answer);

            answer = new QuestionAnswerEntity();
            answer.Username = usuario;
            answer.Pregunta = questions.Find(ddlQuestion2.SelectedValue.ToString());
            answer.Respuesta = txtQuestion2.Text.ToUpper().Trim();
            if (this.Answers.Count > 0)
                answer.Id = this.Answers[1].Id;
            list.Add(answer);

            answer = new QuestionAnswerEntity();
            answer.Username = usuario;
            answer.Pregunta = questions.Find(ddlQuestion3.SelectedValue.ToString());
            answer.Respuesta = txtQuestion3.Text.ToUpper().Trim();
            if (this.Answers.Count > 0)
                answer.Id = this.Answers[2].Id;
            list.Add(answer);

            answer = new QuestionAnswerEntity();
            answer.Username = usuario;
            answer.Pregunta = questions.Find(ddlQuestion4.SelectedValue.ToString());
            answer.Respuesta = txtQuestion4.Text.ToUpper().Trim();
            if (this.Answers.Count > 0)
                answer.Id = this.Answers[3].Id;
            list.Add(answer);

            answer = new QuestionAnswerEntity();
            answer.Username = usuario;
            answer.Pregunta = questions.Find(ddlQuestion5.SelectedValue.ToString());
            answer.Respuesta = txtQuestion5.Text.ToUpper().Trim();
            if (this.Answers.Count > 0)
                answer.Id = this.Answers[4].Id;
            list.Add(answer);

            try
            {
                qab.Save(list);

                lblInfo.Text = "Las respuestas se grabaron correctamente.";
            }
            catch (Exception ex)
            {
                lblInfo.Text = string.Format("Error al guardar las respuestas. ({0})", ex.Message);
            }
        }
    }
}