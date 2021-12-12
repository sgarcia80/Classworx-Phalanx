using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{   
    [Serializable]
    public class MailTagEntity : BaseEntity
    {
        #region Constructors
        /// <summary>
        /// Constructor que crea el tag con todo lo necesario para armar los menúes emergentes para armado de plantillas
        /// </summary>
        /// <param name="Codigo">Key que representa al objeto en la lista</param>
        /// <param name="Tag">Texto que representa al tag en la plantilla.
        /// <example>Por ej. [ACTIVO]</example></param>
        /// <param name="SeIncluyeEnSubject">Indica si es un tag que puede usarse en el campo Short value. En las plantillas de mails, este campo representa al asunto.</param>
        /// <param name="SeIncluyeEnBody">Indica si es un tag que puede usarse en el campo long value. En las plantillas de mails, este campo representa al cuerpo.</param>
        /// <param name="Titulo">Es el texto que aparecerá como opción en el menú emergente.</param>
        public MailTagEntity(string Codigo, string Tag, bool SeIncluyeEnSubject, bool SeIncluyeEnBody, string Titulo)
        {
            this.Code = Codigo;
            this.Tag = Tag;
            this.IsBodyValue = SeIncluyeEnBody;
            this.IsSubjectValue = SeIncluyeEnSubject;
            this.Description = Titulo;
        }
        #endregion

        #region Private Members

        #endregion

        #region Public Members

        public string Code { get; set; }

        public string Description { get; set; }

        public bool IsSubjectValue { get; set; }

        public bool IsBodyValue { get; set; }

        public string Tag { get; set; }

        #endregion

        public override string Key
        {
            get
            {
                return this.Code;
            }
            set
            {
                this.Code = value; ;
            }
        }
        public override string ToString()
        {
            return this.Tag;
        }
    }
}
