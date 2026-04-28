using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class Meta4ClassWorxUsuariosEntity : BaseEntity
    {
        #region Private Members

        private int ml_ordinal;
        private string ml_id_sociedad;
        private string ml_id_empleado;
        private string ml_tipo_doc;
        private string ml_num_documento;
        private string ml_cod_aplicacion;
        private string ml_cod_novedad;
        private string ml_dominio_red;
        private string ml_usuario_red;
        private string ml_usuario_core;
        private DateTime ml_novedad_fecha;
        //private string ml_novedad_id_usuario;

        private string m1_direccion_mail;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int Ordinal
        {
            get { return ml_ordinal; }
            set { ml_ordinal = value; }
        }

        public string Id_Sociedad
        {
            get { return ml_id_sociedad; }
            set { ml_id_sociedad = value; }
        }

        public string Id_Empleado
        {
            get { return ml_id_empleado; }
            set { ml_id_empleado= value; }
        }

        public string TipoDocumento
        {
            get { return ml_tipo_doc; }
            set { ml_tipo_doc = value; }
        }

        public string Num_Documento
        {
            get { return ml_num_documento; }
            set { ml_num_documento= value; }
        }

        public string Cod_Aplicacion
        {
            get { return ml_cod_aplicacion; }
            set { ml_cod_aplicacion = value; }
        }

        public string Cod_Novedad
        {
            get { return ml_cod_novedad; }
            set { ml_cod_novedad = value; }
        }

        public string Dominio_Red
        {
            get { return ml_dominio_red; }
            set { ml_dominio_red = value; }
        }

        public string IdUsuarioRed
        {
            get { return ml_usuario_red; }
            set { ml_usuario_red = value; }
        }

        public string IdUsuarioCore
        {
            get { return ml_usuario_core; }
            set { ml_usuario_core = value; }
        }

        public string DireccionMail
        {
            get { return m1_direccion_mail; }
            set { m1_direccion_mail = value; }
        }

        public DateTime FechaNovedad
        {
            get { return ml_novedad_fecha; }
            set { ml_novedad_fecha = value; }
        }

        #endregion

        public override string Key
        {
            get
            {
                return ml_ordinal.ToString();
            }
            set
            {
                ml_ordinal = Convert.ToInt32(value);
            }
        }
    }
}
