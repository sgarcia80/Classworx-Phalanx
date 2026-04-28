using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class BloqueoEntity : BaseEntity
    {
        public enum TipoBLoqueo
        {
            Ninguno = 0,
            AutogestionCobis = 1
        }

        #region Private Members

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Descripcion
        {
            get
            {
                string value = string.Empty;

                switch ((TipoBLoqueo)this.Codigo)
                {
                    case TipoBLoqueo.AutogestionCobis:
                        value = "Autogestión Cobis";
                        break;
                    case TipoBLoqueo.Ninguno:
                        value = "-";
                        break;
                }

                return value;
            }
            set { }
        }

        public bool Activo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string Usuario { get; set; }

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
