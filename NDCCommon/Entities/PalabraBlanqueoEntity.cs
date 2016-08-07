using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class PalabraBlanqueoEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }

        public string Valor { set; get; }

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
