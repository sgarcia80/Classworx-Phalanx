
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class MacroErrorEntity : BaseEntity
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public string Descripcion { get; set; }

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

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Id, this.Descripcion);
        }
    }
}
