using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class QuestionAnswerEntity : BaseEntity
    {
        #region Private Members
        
        private int ms_id;
        private int ms_id_pregunta;
        private string ms_respuesta;
        private string ms_username;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            get { return ms_id; }
            set { ms_id = value; }
        }

        public int Id_pregunta
        {
            get { return ms_id_pregunta; }
            set { ms_id_pregunta = value; }
        }

        public string Respuesta
        {
            get { return ms_respuesta; }
            set { ms_respuesta = value; }
        }

        public string Username
        {
            get { return ms_username; }
            set { ms_username = value; }
        }

        #endregion

        public override string Key
        {
            get
            {
                return Id.ToString();
            }
            set
            {
                Id = Convert.ToInt32(value);
            }
        }
    }
}
