using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class Meta4SociedadEntity : BaseEntity
    {
        #region Private Members
        
        private string ms_id;
        private string ms_nombre;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string Id
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

        public override string ToString()
        {
            return this.Nombre;
        }

        public override string Key
        {
            get
            {
                return ms_id;
            }
            set
            {
                ms_id = value;
            }
        }
    }
}
