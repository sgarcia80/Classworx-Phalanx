using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace NDCCommon.Entities
{
    public class Meta4LegajoEntity : BaseEntity
    {
        #region Private Members

        private string ml_id;
        private string ml_nombre;
        private string ml_apellido;
        private string ml_tipo_doc;
        private string ml_id_tipo_doc;
        private string ml_doc;
        private string ml_calle;
        private string ml_numero;
        private string ml_piso;
        private string ml_depto;
        private string ml_estado_civil;
        private string ml_EMail;
        private DateTime ml_fecha_nac;
        private Meta4SociedadEntity ml_sociedad;

        private string ml_dominiored;
        private string ml_usuariored;

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return ml_id; }
            set { ml_id = value; }
        }

        public string Nombre
        {
            get { return ml_nombre; }
            set { ml_nombre = value; }
        }

        public string Apellido
        {
            get { return ml_apellido; }
            set { ml_apellido = value; }
        }

        public string TipoDocumento
        {
            get { return ml_tipo_doc; }
            set { ml_tipo_doc = value; }
        }

        public string IdTipoDocumento
        {
            get { return ml_id_tipo_doc; }
            set { ml_id_tipo_doc = value; }
        }

        public string Documento
        {
            get { return ml_doc; }
            set { ml_doc = value; }
        }

        public string Calle
        {
            get { return ml_calle; }
            set { ml_calle = value; }
        }

        public string Numero
        {
            get { return ml_numero; }
            set { ml_numero = value; }
        }

        public string Piso
        {
            get { return ml_piso; }
            set { ml_piso = value; }
        }

        public string Departamento
        {
            get { return ml_depto; }
            set { ml_depto = value; }
        }

        public string EstadoCivil
        {
            get { return ml_estado_civil; }
            set { ml_estado_civil = value; }
        }
        public string EMail
        {
            get { return ml_EMail; }
            set { ml_EMail = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return ml_fecha_nac; }
            set { ml_fecha_nac = value; }
        }

        public Meta4SociedadEntity Sociedad
        {
            get { return ml_sociedad; }
            set { ml_sociedad = value; }
        }

        public string DominioRed
        {
            get { return ml_dominiored; }
            set { ml_dominiored = value; }
        }

        public string UsuarioRed
        {
            get { return ml_usuariored; }
            set { ml_usuariored = value; }
        }

        #endregion

        public override string Key
        {
            get
            {
                return ml_id;
            }
            set
            {
                ml_id = value;
            }
        }
    }
}
