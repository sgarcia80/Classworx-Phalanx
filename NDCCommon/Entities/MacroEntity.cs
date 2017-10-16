using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class MacroEntity : BaseEntity
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Body { get; set; }
        
        public string Footer { get; set; }

        public IList<MacroUsuarioEntity> UsuariosList { get; set; }

        public IList<AplicacionNotificacionClaveEntity> AplicacionesList { get; set; }

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
