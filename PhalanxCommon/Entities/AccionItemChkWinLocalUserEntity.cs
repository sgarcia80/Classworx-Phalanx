using System;
using System.Collections.Generic;
using System.Text;

namespace PhalanxCommon.Entities
{
    [Serializable]
    public class AccionItemChkWinLocalUserEntity : BaseEntity
    {
        #region Member Variables
        protected int _id;
        protected string _nombre;
        #endregion
        #region Constructors
        public AccionItemChkWinLocalUserEntity()
        {
        }
        #endregion
        #region Public Properties
        public virtual int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value != null && value.Length > 150)
                    throw new ArgumentOutOfRangeException("value", value.ToString(), "Nombre cannot contain more than 150 characters");
                _nombre = value;
            }
        }
        #endregion
        public override string Key
        {
            get
            {
                return _id.ToString();
            }
            set
            {
                _id = Convert.ToInt32(value);
            }
        }
    }
}
