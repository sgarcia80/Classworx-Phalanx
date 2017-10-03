using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class MacroUsuarioEntity : BaseEntity
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public PhalanxCommon.Entities.WinDomainEntity Dominio { get; set; }

        public string UsuarioRed { get; set; }

        public MacroEntity Macro { get; set; }

        public string UsuarioTC { get; set; }
        
        public string ClaveTC { get; set; }

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
