using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class QuestionEntity : BaseEntity
    {
        #region Private Members
        
        private int ms_id;
        private string ms_nombre;

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

        public string Nombre
        {
            get { return ms_nombre; }
            set { ms_nombre = value; }
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
