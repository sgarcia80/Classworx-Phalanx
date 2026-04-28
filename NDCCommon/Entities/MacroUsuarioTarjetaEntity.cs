using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class MacroUsuarioTarjetaEntity : BaseEntity
    {
        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public AplicacionNotificacionClaveEntity Aplicacion { get; set; }

        public string Dominio { get; set; }

        public string UsuarioRed { get; set; }

        /// <summary>
        /// Esta propiedad es solo para mapear en la grilla
        /// </summary>
        public string PrefijoUsuarioTC { get; set; }

        public string UsuarioTC { get; set; }
        
        public string AplicacionCodigo { get; set; }

        /// <summary>
        /// Atributo para la importación solamente
        /// </summary>
        public string Obseravaciones { get; set; }

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
