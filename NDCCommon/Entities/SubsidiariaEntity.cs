using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class SubsidiariaEntity : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }

        public string Nombre { set; get; }

        public string Codigo { set; get; }

        public string Email01 { set; get; }
        
        public string Email02 { set; get; }

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
